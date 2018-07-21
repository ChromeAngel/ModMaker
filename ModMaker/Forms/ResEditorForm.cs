using System;
using LibModMaker;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;

namespace ModMaker {

    /// <summary>
    /// UI for editing VGUI RES files
    /// </summary>
    public partial class ResEditorForm
    {
        private KeyValues vgui_controls;
        private KeyValues res_file;

        private string FilePath;

        //List of rectangles outlining the panels in this res file, keyed by the panel name

        private Dictionary<string, Rectangle> PanelAreas = new Dictionary<string, Rectangle>();
        private Dictionary<string, PanelRectangle.PanelProperty> PanelProperties = new Dictionary<string, PanelRectangle.PanelProperty>();
        private KeyValues PanelKey;
        private PanelRectangle Selected;

        private List<Control> PropertyControls = new List<Control>();

        public SourceMod Game;
        /// <summary>
        /// VGUI panel that is selected for editing
        /// </summary>
        /// <remarks>displayes it's properties for editign and allows positioning in the window</remarks>
        public LibModMaker.KeyValues Panel {
            get { return PanelKey; }
            set {
                PanelKey = value;
                RemoveOldPropertyControls();

                if (value == null)
                    return;

                AddNewPropertyControls();

                lblPanelName.Text = PanelKey.GetString("fieldname");
                PanelPosition.Visible = true;
                PanelPosition.Bounds = Selected.ToRectangle();
                SplitPanelProperties.Height = SplitPanelProperties.Panel1.Controls.Count * 26;
            }
        }


        public ResEditorForm()
        {
            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            Icon = Properties.Resources.ModMaker;
            //Load defintions for the standard built-in controls, so the editor knows about the standard properties
            vgui_controls = KeyValues.LoadFile("options/vgui_controls.txt");
            Panel = null;
            ListControlTypes();
        }

        //List the standard types in the "Add Panel" menu
        void ListControlTypes()
        {
            foreach (ToolStripItem MenuItem in AddPanelMenu.DropDownItems) {
                MenuItem.Click -= mnuAddPanel_Click;
            }

            AddPanelMenu.DropDownItems.Clear();

            if (vgui_controls == null)
                return;

            foreach (KeyValues ControlType in vgui_controls.Keys) {
                ToolStripItem MenuItem = AddPanelMenu.DropDownItems.Add(ControlType.Name);
                MenuItem.Click += mnuAddPanel_Click;
            }
        }

        //Start a new res file
        private void mnuNew_Click(System.Object sender, System.EventArgs e)
        {
            res_file = new KeyValues("New.res");
            FilePath = Path.Combine(Game.InstallPath, "resource/New.res");
            AddPanelMenu.Enabled = true;
            RefreshPanelsCombo();
            Text = "New.res - Resource Editor - Mod Maker";
        }

        //save under a new name
        private void SaveAsToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            if (res_file == null)
                return;

            SaveFileDialog Dialog = new SaveFileDialog {
                Filter = "Resource File (*.res)|*.res",
                DefaultExt = ".res",
                FileName = Path.GetFileName(res_file.Name)
            };

            if (Game != null) {
                Dialog.InitialDirectory = Path.Combine(Game.InstallPath, "resource");
            }

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            this.FilePath = Dialog.FileName;
            res_file.Name = Path.GetFileName(Dialog.FileName);
            res_file.Save(this.FilePath);
            Text = Path.GetFileName(this.FilePath) + " - VGUI Resource Editor - Mod Maker";
        }

        private void SaveToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            if (this.FilePath == null || res_file == null)
                return;

            res_file.Save(this.FilePath);
        }

        //Let the user pick a res file to open
        private void LoadToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            var Dialog = new OpenFileDialog {
                Title = "Select File",
                Filter = "Resource File (*.res)|*.res",
                DefaultExt = ".res"
            };

            if (Game != null) {
                Dialog.CustomPlaces.Add(Game.InstallPath);
                Dialog.CustomPlaces.Add(Game.SourcePath);
                Dialog.InitialDirectory = Path.Combine(Game.InstallPath, "resource");
            }

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            Open(Dialog.FileName);
        }


        //Try to open a res file
        void Open(string FilePath)
        {
            if (!File.Exists(FilePath))
                return;

            Text = Path.GetFileName(FilePath) + " - VGUI Resource Editor - Mod Maker";
            res_file = KeyValues.LoadFile(FilePath);
            AddPanelMenu.Enabled = true;
            this.FilePath = FilePath;

            RefreshPanelsCombo();
            PanelsDropdown.SelectedIndex = 0;
            RefreshEditorBackground();
        }

        //Add a new panel of the chosen type to the res file
        private void mnuAddPanel_Click(System.Object sender, System.EventArgs e)
        {
            if (res_file == null)
                return;

            ToolStripMenuItem MenuItem = sender as ToolStripMenuItem;
            string PanelName = Interaction.InputBox("Please enter a name for the new " + MenuItem.Text, "New Panel Name", "Panel" + res_file.Keys.Count() + 1.ToString());

            if (string.IsNullOrEmpty(PanelName))
                return;

            KeyValues NewPanel = new KeyValues(PanelName, res_file);
            KeyValues Temp = new KeyValues("fieldname", PanelName, NewPanel);
            Temp = new KeyValues("controlname", MenuItem.Text, NewPanel);

            RefreshPanelsCombo();

            PanelsDropdown.SelectedIndex = PanelsDropdown.Items.Count - 1;
        }

        //When a new panel is selected remove the properties for the old VGUI panel
        void RemoveOldPropertyControls()
        {
            PanelRectangle.PanelProperty WorkingProperty;

            //Unhook all the event handlers or they just leak memory
            foreach (var OldControl in PropertyControls) {
                WorkingProperty = OldControl.Tag as PanelRectangle.PanelProperty;

                OldControl.GotFocus -= Property_GotFocus;

                switch (WorkingProperty.DataType) {
                    case "int":
                        TextBox OldTextbox = OldControl as TextBox;

                        OldTextbox.TextChanged -= Property_TextChanged;
                        OldTextbox.KeyDown -= IntProperty_KeyDown;
                        break;
                    case "bool":
                        CheckBox OldCheckbox = OldControl as CheckBox;
                        OldCheckbox.CheckedChanged -= Property_CheckedChanged;
                        break;
                    case "color":
                    default:
                        TextBox anyOldTextbox = OldControl as TextBox;

                        if (anyOldTextbox != null)
                        {
                            anyOldTextbox.TextChanged -= Property_TextChanged;
                        }

                        break;
                }
            }

            //remove the controls
            SplitPanelProperties.SuspendLayout();
            PropertyControls.Clear();
            SplitPanelProperties.Panel1.Controls.Clear();
            SplitPanelProperties.Panel2.Controls.Clear();
            SplitPanelProperties.Height = 0;
            PanelProperties.Clear();
            lblComment.Text = "";
            SplitPanelProperties.ResumeLayout();
        }

        //Add properties of the selected VGUI panel
        private void AddNewPropertyControls()
        {
            string ControlName = PanelKey.GetString("ControlName");
            

            //Everyhting has the properties of a Panel
            AddControlProperties("panel");

            //Find all the standard properties of a control of this type
            AddControlProperties(ControlName.ToLower());

            //list all the properties, plus those from value not already listed
            Selected = new PanelRectangle {
                Editor = PanelEditSpace.Bounds,
                VGUI_Panel = PanelKey
            };

            //Add all the bespoke properites of this particular panel
            foreach (KeyValues PropertyKey in PanelKey.Keys) {
                PanelRectangle.PanelProperty WorkingProperty;

                if (PanelProperties.ContainsKey(PropertyKey.Name.ToLower())) {
                    WorkingProperty = PanelProperties[PropertyKey.Name.ToLower()];
                } else {
                    WorkingProperty = new PanelRectangle.PanelProperty {
                        Name = PropertyKey.Name.ToLower(),
                        DataType = "text",
                        Comment = ""
                    };
                }

                WorkingProperty.Value = PropertyKey.Value;
                PanelProperties[PropertyKey.Name] = WorkingProperty;
            }

            SplitPanelProperties.SuspendLayout();

            foreach (var WorkingProperty in PanelProperties.Values) {
                if (WorkingProperty.Name.ToLower() == "controlname" || WorkingProperty.Name.ToLower() == "fieldname")
                    continue;

                AddNewControlForProperty(WorkingProperty);
                Selected.PropertySet(WorkingProperty);
            }

            SplitPanelProperties.ResumeLayout();
        }

        //Add controls to represent the working property if the selected VGUI panel
        private void AddNewControlForProperty(PanelRectangle.PanelProperty WorkingProperty)
        {
            SplitPanelProperties.Panel1.Controls.Add(new Label {
                Text = WorkingProperty.Name,
                TextAlign = ContentAlignment.MiddleRight,
                AutoSize = false,
                Height = 26,
                Dock = DockStyle.Top
            });
            Panel TextPanel = new Panel {
                Text = WorkingProperty.Name,
                Height = 26,
                Dock = DockStyle.Top
            };

            switch (WorkingProperty.DataType) {
                case "bool":
                    CheckBox PropertyCheckBox = new CheckBox {
                        Text = WorkingProperty.Value,
                        Dock = DockStyle.Top,
                        Tag = WorkingProperty
                    };

                    PropertyControls.Add(PropertyCheckBox);

                    PropertyCheckBox.GotFocus += Property_GotFocus;
                    PropertyCheckBox.CheckedChanged += Property_CheckedChanged;
                    TextPanel.Controls.Add(PropertyCheckBox);
                    break;
                case "int":
                    TextBox PropertyIntBox = new TextBox {
                        Text = WorkingProperty.Value,
                        TextAlign = HorizontalAlignment.Right,
                        Dock = DockStyle.Top,
                        Tag = WorkingProperty
                    };

                    PropertyControls.Add(PropertyIntBox);

                    PropertyIntBox.GotFocus += Property_GotFocus;
                    PropertyIntBox.TextChanged += Property_TextChanged;
                    PropertyIntBox.KeyDown += IntProperty_KeyDown;
                    TextPanel.Controls.Add(PropertyIntBox);
                    break;
                case "color":
                    Button PopupButton = new Button {
                        Text = "...",
                        Dock = DockStyle.Right,
                        Width = 26,
                        Tag = WorkingProperty
                    };

                    TextBox PropertyColourBox = new TextBox {
                        Text = WorkingProperty.Value,
                        Dock = DockStyle.Top,
                        Tag = WorkingProperty
                    };

                    PropertyControls.Add(PopupButton);
                    PropertyControls.Add(PropertyColourBox);

                    PropertyColourBox.GotFocus += Property_GotFocus;
                    PropertyColourBox.TextChanged += Property_TextChanged;
                    PopupButton.Click += ColorPropertyButton_Click;

                    TextPanel.Controls.Add(PropertyColourBox);
                    TextPanel.Controls.Add(PopupButton);
                    break;
                default:
                    TextBox PropertyTextBox = new TextBox {
                        Text = WorkingProperty.Value,
                        Dock = DockStyle.Top,
                        Tag = WorkingProperty
                    };

                    PropertyControls.Add(PropertyTextBox);

                    PropertyTextBox.GotFocus += Property_GotFocus;
                    PropertyTextBox.TextChanged += Property_TextChanged;
                    TextPanel.Controls.Add(PropertyTextBox);
                    break;
            }

            SplitPanelProperties.Panel2.Controls.Add(TextPanel);
        }

        //Display a comment for the currently edited property
        private void Property_GotFocus(object sender, System.EventArgs e)
        {
            Control control = sender as Control;
            PanelRectangle.PanelProperty PanelProperty = control.Tag as PanelRectangle.PanelProperty;

            lblComment.Text = PanelProperty.Comment;
        }

        //When properties are changed reflect them back in the panel
        private void Property_TextChanged(System.Object sender, System.EventArgs e)
        {
            TextBox TextBox = sender as TextBox;
            PanelRectangle.PanelProperty WorkingProperty = TextBox.Tag as PanelRectangle.PanelProperty;

            WorkingProperty.Value = TextBox.Text;
            PanelKey.SetValue(WorkingProperty.Name, TextBox.Text);
            Selected.PropertySet(WorkingProperty);

            switch (WorkingProperty.Name) {
                case "xpos":
                case "ypos":
                case "tall":
                case "wide":
                    Rectangle Bounds = Selected.ToRectangle();
                    PanelPosition.SetBounds(Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);
                    RefreshEditorBackground();
                    break;
            }
        }

        //When checkbox properties are changed reflect them back in the panel
        private void Property_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            CheckBox CheckBox = sender as CheckBox;
            PanelRectangle.PanelProperty WorkingProperty = CheckBox.Tag as PanelRectangle.PanelProperty;

            WorkingProperty.Value = CheckBox.Checked ? "1" : "0";
            PanelKey.SetValue(WorkingProperty.Name, WorkingProperty.Value);
            Selected.PropertySet(WorkingProperty);
        }

        private void IntProperty_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode) {
                case Keys.D0:
                case Keys.D1:
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D5:
                case Keys.D6:
                case Keys.D7:
                case Keys.D8:
                case Keys.D9:
                case Keys.Delete:
                case Keys.Back:
                case Keys.Left:
                case Keys.Right:
                //allow these
                default:
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void ColorPropertyButton_Click(System.Object sender, System.EventArgs e)
        {
            Button btnSender = sender as Button;
            PanelRectangle.PanelProperty WorkingProperty = btnSender.Tag as PanelRectangle.PanelProperty;
            string strColor = WorkingProperty.Value;
            string[] aColor = new string[4];
            Color sColor = Color.Black;

            if (!string.IsNullOrEmpty(strColor)) {
                aColor = strColor.Split(" ".ToCharArray(), 4);

                if (aColor.Length > 2) {
                    int[] iColor = new int[3];

                    for (Byte Channel = 0; Channel <= 2; Channel++) {
                        int.TryParse(aColor[Channel], out iColor[Channel]);
                    }

                    sColor = Color.FromArgb(iColor[0], iColor[1], iColor[2]);
                }
            }

            var Dialog = new ColorDialog {
                Color = sColor,
                FullOpen = true
            };

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            //Set the property to the color we picked
            aColor[0] = Dialog.Color.R.ToString();
            aColor[1] = Dialog.Color.G.ToString();
            aColor[2] = Dialog.Color.B.ToString();

            if (string.IsNullOrEmpty(aColor[3]))
                aColor[3] = "255";

            WorkingProperty.Value = string.Join(" ", aColor);
            PanelKey.SetValue(WorkingProperty.Name, WorkingProperty.Value.ToString());

            //update the corrisponding textbox
            PanelRectangle.PanelProperty ControlProperty;

            foreach (var PanelControl in PropertyControls) {
                ControlProperty = PanelControl.Tag as PanelRectangle.PanelProperty;

                if (ControlProperty.Name != WorkingProperty.Name)
                    continue;

                if ((PanelControl) is TextBox) {
                    PanelControl.Text = WorkingProperty.Value;

                    break; // TODO: might not be correct. Was : Exit For
                }
            }
        }

        //Add a controls properties to the list of properties
        void AddControlProperties(string ControlName)
        {
            KeyValues ControlDef = vgui_controls[ControlName.ToLower()];

            if (ControlDef == null)
                return;

            string BaseControlName = ControlDef.GetString("inherits");

            if (BaseControlName != null)
                AddControlProperties(BaseControlName);

            KeyValues ControlProps = ControlDef.GetKey("properties");

            if (ControlProps == null)
                return;

            foreach (var Key in ControlProps.Keys) {
                PanelProperties[Key.Name] = new PanelRectangle.PanelProperty {
                    Name = Key.Name,
                    DataType = Key.GetString("type"),
                    Comment = Key.GetString("comment")
                };
            }
        }

        //List all the panels in this res file, so the user can pick one to edit
        private void RefreshPanelsCombo()
        {
            PanelsDropdown.Items.Clear();

            if (res_file == null)
                return;

            foreach (KeyValues Panel in res_file.Keys) {
                PanelsDropdown.Items.Add(Panel.Name);
            }
        }

        //Pick a panel to edit from the list
        private void cboPanels_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            Panel = res_file[PanelsDropdown.SelectedItem.ToString()];
        }

        //Draw outlines of all the panels in this res file onto the background of the edit space
        private void RefreshEditorBackground()
        {
            Bitmap Result = null;

            if (PanelEditSpace.BackgroundImage != null)
                Result = new Bitmap(PanelEditSpace.BackgroundImage);
            if (Result == null)
                Result = new Bitmap(PanelEditSpace.Width, PanelEditSpace.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            if (Result.Width != PanelEditSpace.Width || Result.Height != PanelEditSpace.Height)
                Result = new Bitmap(PanelEditSpace.Width, PanelEditSpace.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            Graphics GFX = Graphics.FromImage(Result);

            GFX.Clear(Color.Black);
            PanelAreas.Clear();

            if (res_file != null) {
                foreach (KeyValues Panel in res_file.Keys) {
                    PanelRectangle Worker = new PanelRectangle {
                        Editor = PanelEditSpace.Bounds,
                        VGUI_Panel = Panel
                    };
                    Rectangle Bounds = Worker.VGUI_ToRectangle();

                    PanelAreas.Add(Panel.Name, Bounds);
                    GFX.DrawRectangle(SystemPens.GrayText, Bounds);
                    GFX.DrawString(Panel.Name, lblPanelName.Font, SystemBrushes.GrayText, Bounds.Location);
                }
            }

            GFX.Flush();
            PanelEditSpace.BackgroundImage = Result;
            PanelEditSpace.Invalidate();
        }

        //keep the PanelEditSpace vertically centered at 4:3 ratio
        private void SplitEditor_Resize(object sender, System.EventArgs e)
        {
            PanelEditSpace.Width = SplitEditor.Panel1.Width;
            PanelEditSpace.Height = (PanelEditSpace.Width / 4) * 3;
            PanelEditSpace.Top = (SplitEditor.Panel1.Height - PanelEditSpace.Height) / 2;
        }

        //drag the selected panel to a new place/size
        private void PanelEditSpace_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Point VGUI_Point = Selected.WinPointToVGUI_Point(PanelPosition.Location);

            PanelKey.SetValue("xpos", VGUI_Point.X.ToString());
            PanelKey.SetValue("ypos", VGUI_Point.Y.ToString());
            PanelKey.SetValue("wide", Selected.PixelToXRES(PanelPosition.Width));
            PanelKey.SetValue("tall", Selected.PixeltoYRES(PanelPosition.Height));

            Panel = PanelKey;

            RefreshEditorBackground();
        }

        private void PanelEditSpace_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        //When the edit space resizes we need to redraw all our VGUI panels
        private void PanelEditSpace_Resize(object sender, System.EventArgs e)
        {
            RefreshEditorBackground();

            if (Selected == null)
                return;

            Selected.Editor = PanelEditSpace.Bounds;

            Rectangle Bound = Selected.VGUI_ToRectangle();

            PanelPosition.SetBounds(Bound.X, Bound.Y, Bound.Width, Bound.Height);
        }

        //Show a hit for the VGUI location of the cursor
        private void PanelEditSpace_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            string MousePosText = string.Format("xpos:{0}\r\nypos:{1}", Math.Floor((double)e.X / PanelEditSpace.Width * PanelRectangle.ScreenWidth),  Math.Floor((double)e.Y / PanelEditSpace.Height * PanelRectangle.ScreenHeight));

            if (EditorToolTip.GetToolTip(PanelEditSpace) == MousePosText)
                return;

            EditorToolTip.SetToolTip(PanelEditSpace, MousePosText);
        }

        //select a panel by clicking in it's rectangle in the edit space
        private void PanelEditSpace_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            foreach (string PanelName in PanelAreas.Keys) {
                Rectangle Bounds = PanelAreas[PanelName];

                if (Bounds.Contains(e.Location)) {
                    PanelsDropdown.SelectedItem = PanelName;
                    return;
                }
            }
        }

        //start moving the selected panel
        private void PanelPosition_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            PanelPosition.DoDragDrop(string.Format("POS:{0},{1}", e.X, e.Y), DragDropEffects.Move);
        }

        //start changing the width of the selected panel
        private void PanelResizeWidth_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            PanelPosition.DoDragDrop(string.Format("WIDE:{0},{1}", e.X, e.Y), DragDropEffects.Move);
        }

        //start changing the height of the selected panel
        private void PanelResizeTall_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            PanelPosition.DoDragDrop(string.Format("TALL:{0},{1}", e.X, e.Y), DragDropEffects.Move);
        }

        //drag the selected panel to a new place/size
        private void PanelEditSpace_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string strPoint = e.Data.GetData("Text").ToString();
            string[] aMode = strPoint.Split(':');
            string[] aPoint = aMode[1].Split(',');
            Point ScreenPoint = new Point(e.X, e.Y);
            Point localPoint = PanelEditSpace.PointToClient(ScreenPoint);

            switch (aMode[0]) {
                case "POS":
                    PanelPosition.Location = new Point(localPoint.X - int.Parse(aPoint[0]), localPoint.Y - int.Parse(aPoint[1]));
                    break;
                case "TALL":
                    PanelPosition.Height = localPoint.Y - int.Parse(aPoint[1]) - PanelPosition.Height;break;
                case "WIDE":
                    PanelPosition.Width = localPoint.X - int.Parse(aPoint[0]) - PanelPosition.Width;break;
            }
        }

        //if you switch to the code tab refresh the code
        private void Tabs_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (Tabs.SelectedIndex != 1)
                return;

            if (res_file == null) {
                txtCode.Text = string.Empty;
            } else {
                txtCode.Text = res_file.ToString();
            }
        }

        private void ScriptCPanelToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            if (res_file == null)
                return;

            FolderDialog Dialog = new FolderDialog { Description = "Select folder to export C++ files to" };

            if (Game != null) {
                Dialog.SelectedPath = Path.Combine(Game.SourcePath, "src/game/client/");
            }

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            VGUI_ScriptGenerator Helper = new VGUI_ScriptGenerator();

            Helper.Export(Game, res_file, Dialog.SelectedPath, Path.GetFileName(FilePath));
        }

        private void mnuHelp_Click(System.Object sender, System.EventArgs e)
        {
            Interaction.MsgBox("Valve Graphical User Interface (VGUI) resource files (*.res) \r\n"  + 
                "are key/value files as used by VGUI panels descended from \r\n" + 
                "EditablePanel (such as Frame and HUDElement) to edit\r\n"  +
                "the layout and appearenace of the panel outside C++\r\n." +
                "Resource files are often stored in Install/Resource/UI \r\n" +
                "HUD layout which is an exception, located in Install/Scripts\r\n\r\n" +
                "Additional VGUI panels can be added from the menu.\r\n" +
                "Properties for the selected panel are edited on the right. \r\n" +
                "Drag the highlighted area in the layout tab to position or scale the panel.", 
                MsgBoxStyle.Information, "VGUI Resource File Help");
        }

        private void ExitToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            Close();
        }
    }

}