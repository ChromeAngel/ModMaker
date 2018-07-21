

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LibModMaker;
using Microsoft.VisualBasic;
using System.IO;

namespace ModMaker {

    /// <summary>
    /// UI for the Forge Game Data (FGD) editor, enables creation of boilerplate entity code and integration of entities into Hammer
    /// </summary>
    public partial class FGDForm
    {
        public SourceMod Game;
        private ForgeGameData _fgd = new ForgeGameData();
        private Dictionary<string, ForgeGameData.EntityDef> _subset;
        private ForgeGameData.EntityDef _entity = null;
        private DataTable _dtFlags;

        private string ScriptTo = null;
        public ForgeGameData.EntityDef Entity {
            get {
                GetEdits();

                return _entity;
            }
            set {
                if (_entity != null) {
                    GetEdits();
                }

                _entity = value;

                if (_entity == null) {
                    mnuEdit.Enabled = false;
                    SplitComments.Enabled = false;

                    return;
                } else {
                    mnuEdit.Enabled = true;
                    SplitComments.Enabled = true;
                }

                SetProperties();
                SetFlags();
                SetInputs();
                SetOutputs();
                SetWidgets();

                txtComment.Text = _entity.Comment;
                txtPreview.Text = _entity.ToString();
            }
        }

        public FGDForm()
        {
            // This call is required by the designer.
            InitializeComponent();
        }

        private void frmFGD_Load(object sender, System.EventArgs e)
        {
            this.Icon = Properties.Resources.ModMaker;

            if (Game != null) {
                string GuessedFGD = Path.Combine(Game.InstallPath, Game.InstallFolder + ".fgd");

                if (File.Exists(GuessedFGD)) {
                    _fgd.Load(GuessedFGD);

                    this.Text = Path.GetFileName(_fgd.FileName) + " - Forge Game Data - Mod Maker";
                }
            }

            RefreshEntityList();
        }

        private void mnuFileNew_Click(object sender, System.EventArgs e)
        {
            _fgd = new ForgeGameData();
            this.Text = Path.GetFileName(_fgd.FileName) + " - Forge Game Data - Mod Maker";
            RefreshEntityList();
        }

        private void mnuLoad_Click(System.Object sender, System.EventArgs e)
        {
            var Dialog = new OpenFileDialog {
                DefaultExt = ".fgd",
                Multiselect = false,
                Filter = "Forge Game Data (*.fgd)|*.fgd"
            };

            if (Game != null) {
                Dialog.CustomPlaces.Add(Game.InstallPath);
                Dialog.CustomPlaces.Add(Game.SourcePath);
                Dialog.CustomPlaces.Add(Game.SDKPath);

                Dialog.InitialDirectory = Game.InstallPath;
                Dialog.FileName = Game.InstallFolder + ".fgd";
            }

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            _fgd = new ForgeGameData();
            _fgd.Load(Dialog.FileName);
            this.Text = Path.GetFileName(_fgd.FileName) + " - Forge Game Data - Mod Maker";
            RefreshEntityList();
        }

        private void mnuSave_Click(System.Object sender, System.EventArgs e)
        {
            GetEdits();
            _fgd.Save();
        }

        private void mnuFileSaveAs_Click(System.Object sender, System.EventArgs e)
        {
            var Dialog = new SaveFileDialog {
                DefaultExt = ".fgd",
                Filter = "Forge Game Data (*.fgd)|*.fgd"
            };

            if (Game != null) {
                Dialog.CustomPlaces.Add(Game.InstallPath);
                Dialog.CustomPlaces.Add(Game.SourcePath);

                Dialog.InitialDirectory = Game.InstallPath;
                Dialog.FileName = Game.InstallFolder + ".fgd";
            }

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            GetEdits();
            _fgd.Save(Dialog.FileName);
            this.Text = Path.GetFileName(_fgd.FileName) + " - Forge Game Data - Mod Maker";
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuEntBases_Click(System.Object sender, System.EventArgs e)
        {
            ToolStripMenuItem ThisItem = sender as ToolStripMenuItem;

            if (ThisItem.Checked) {
                if (!object.ReferenceEquals(mnuEntBases, ThisItem))
                    mnuEntBases.Checked = false;
                if (!object.ReferenceEquals(mnuEntSolids, ThisItem))
                    mnuEntSolids.Checked = false;
                if (!object.ReferenceEquals(mnuEntPoints, ThisItem))
                    mnuEntPoints.Checked = false;
            }

            RefreshEntityList();
        }

        void RefreshEntityList()
        {
            cboEntList.Items.Clear();
            cboInclude.Items.Clear();

            if (_fgd == null)
                return;

            RefreshIncludesList();

            _subset = null;

            if (mnuEntBases.Checked)
                _subset = _fgd.Bases;
            if (mnuEntSolids.Checked)
                _subset = _fgd.Solids;
            if (mnuEntPoints.Checked)
                _subset = _fgd.Points;

            if (_subset == null)
                return;
            if (_subset.Count == 0)
                return;

            string[] EntityNames = new string[_subset.Keys.Count()];

            _subset.Keys.CopyTo(EntityNames, 0);
            cboEntList.Items.AddRange(EntityNames);
            cboEntList.SelectedIndex = 0;
        }

        private void RefreshIncludesList()
        {
            foreach (string ImportFile in _fgd.Includes.Keys) {
                cboInclude.Items.Add(ImportFile);
            }

            cboInclude.BackColor = SystemColors.Window;
            cboInclude.SelectedIndex = _fgd.Includes.Count == 0 ? -1 : 0;
        }

        private void cboImports_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            string NewInclude = cboInclude.Text;

            if (_fgd.Includes.ContainsKey(NewInclude))
                return;

            string Folder = Directory.GetCurrentDirectory();

            if (Game != null)
                Folder = Game.InstallPath;
            if (_fgd.FileName != null)
                Folder = Path.GetDirectoryName(_fgd.FileName);

            string IncludePath = Path.Combine(Folder, NewInclude);

            if (File.Exists(IncludePath)) {
                _fgd.Includes[NewInclude] = new ForgeGameData();
                _fgd.Includes[NewInclude].Load(IncludePath);
                cboInclude.Items.Add(NewInclude);
                cboInclude.BackColor = SystemColors.Window;

                return;
            }

            if (Game != null)
            {
                if (Game.SDKPath != null)
                {
                    Folder = Game.SDKPath;
                    IncludePath = Path.Combine(Folder, NewInclude);

                    if (File.Exists(IncludePath))
                    {
                        _fgd.Includes[NewInclude] = new ForgeGameData();
                        _fgd.Includes[NewInclude].Load(IncludePath);
                        cboInclude.Items.Add(NewInclude);
                        cboInclude.BackColor = SystemColors.Window;

                        return;
                    }
                }
            }

            //Invalid file name
            cboInclude.BackColor = Color.DarkSalmon;
        }
        private void cboEntList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cboEntList.SelectedIndex == -1)
                return;

            Entity = _subset[cboEntList.SelectedItem.ToString()];
        }

//# Region "Get and set entity properties, flags, IO and Widgets"

        const int PropertyHeight = 22;
        void SetProperties()
        {
            //TODO clear handlers
            pnlPropertyList.SuspendLayout();
            pnlPropertyList.Controls.Clear();

            AddProperties(_entity);

            foreach (string Basename in _entity.Bases) {
                AddProperties(_fgd.GetBaseByName(Basename), true);
            }

            pnlPropertyList.ResumeLayout();
        }

        void AddProperties(ForgeGameData.EntityDef Source, bool IsReadOnly = false)
        {
            if (Source == null)
                return;

            foreach (ForgeGameData.iEntityProperty P in Source.Properties.Values) {
                switch (P.DataType) {
                    case "choices":
                        FGD_ChoicesControl Ctl = new FGD_ChoicesControl(P as ForgeGameData.ChoicesProperty);

                        Ctl.Dock = DockStyle.Top;
                        Ctl.IsReadOnly = IsReadOnly;
                        pnlPropertyList.Controls.Add(Ctl);

                        Ctl.OnDelete += OnDeleteProperty;
                        break;
                    case "flags":
                        break;
                    default:
                        FGD_PropertyControl Ctlp = new FGD_PropertyControl(P as ForgeGameData.BaseProperty);

                        Ctlp.Dock = DockStyle.Top;
                        Ctlp.IsReadOnly = IsReadOnly;
                        pnlPropertyList.Controls.Add(Ctlp);

                        Ctlp.OnDelete += OnDeleteProperty;
                        break;
                }
            }
        }

        void GetProperties()
        {
            foreach (Control Ctl in pnlPropertyList.Controls) {
                FGD_PropertyControl PropertyCtl = Ctl as FGD_PropertyControl;

                if (PropertyCtl != null) {
                    if (PropertyCtl.IsReadOnly)
                        continue;

                    _entity.Properties[PropertyCtl.BaseProperty.Name] = PropertyCtl.BaseProperty;

                    continue;
                }

                FGD_ChoicesControl ChoiceCtl = Ctl as FGD_ChoicesControl;
                if (ChoiceCtl != null) {
                    if (ChoiceCtl.IsReadOnly)
                        continue;

                    _entity.Properties[ChoiceCtl.ChoicesProperty.Name] = ChoiceCtl.ChoicesProperty;
                }
            }
        }

        void OnDeleteProperty(object sender, string Name)
        {
            GetProperties();
            _entity.Properties.Remove(Name);
            SetProperties();
        }

        void SetFlags()
        {
            foreach (FGD_FlagControl Ctl in pnlFlagList.Controls) {
                Ctl.OnDelete -= OnDeleteFlag;
            }

            pnlFlagList.SuspendLayout();
            pnlFlagList.Controls.Clear();

            if (!_entity.Properties.ContainsKey("spawnflags")) {
                pnlFlagList.ResumeLayout();

                return;
            }

            AddFlags(_entity);

            foreach (string Basename in _entity.Bases) {
                if (!_fgd.Bases.ContainsKey(Basename))
                    continue;

                AddFlags(_fgd.GetBaseByName(Basename), true);
            }

            pnlFlagList.ResumeLayout();
        }

        void AddFlags(ForgeGameData.EntityDef Source, bool IsReadOnly = false)
        {
            if (Source == null)
                return;
            if (!Source.Properties.ContainsKey("spawnflags"))
                return;

            ForgeGameData.FlagsProperty SpawnFlags = Source.Properties["spawnflags"] as ForgeGameData.FlagsProperty;

            if (SpawnFlags == null)
                return;

            foreach (int Flag in SpawnFlags.flags.Keys) {
                FGD_FlagControl Ctl = new FGD_FlagControl {
                    Flag = SpawnFlags.flags[Flag],
                    IsReadOnly = IsReadOnly,
                    Dock = DockStyle.Top
                };

                pnlFlagList.Controls.Add(Ctl);

                Ctl.OnDelete += OnDeleteFlag;
            }
        }

        ForgeGameData.FlagsProperty GetFlags(bool AllowEmpty = false)
        {
            ForgeGameData.FlagsProperty SpawnFlags = null;

            //use the existing property if we have one
            if (_entity.Properties.ContainsKey("spawnflags"))
            {
                SpawnFlags = _entity.Properties["spawnflags"] as ForgeGameData.FlagsProperty;
            }

            //if we dont have an existing property make a new one
            if (SpawnFlags == null)
            {
                SpawnFlags = new ForgeGameData.FlagsProperty {
                    _Name = "spawnflags",
                    DataType = "flags"
                };
            }

            //gather all out flags
            foreach (FGD_FlagControl Ctl in pnlFlagList.Controls)
            {
                if (Ctl.IsReadOnly) continue; //ignore inheritted flags

                SpawnFlags.flags[Ctl.Flag.BitFlags] = Ctl.Flag;
            }

            //don't add an empty spawnflags
            if (SpawnFlags.flags.Count == 0 && !AllowEmpty) {
                if (_entity.Properties.ContainsKey("spawnflags")) {
                    _entity.Properties.Remove("spawnflags");
                }

                return null;
            } else {
                _entity.Properties["spawnflags"] = SpawnFlags;
            }

            return SpawnFlags;
        }

        void OnDeleteFlag(object sender, string Name)
        {
            ForgeGameData.FlagsProperty SpawnFlags =  GetFlags();

            if (SpawnFlags == null) return;

            //SpawnFlags.flags.Remove(Name); //TODO FIXME
            SetFlags();
        }

        void SetInputs()
        {
            foreach (FGD_IOControl Ctl in pnlInputList.Controls) {
                Ctl.OnDelete -= OnDeleteInput;
            }

            pnlInputList.SuspendLayout();
            pnlInputList.Controls.Clear();

            AddInputs(_entity);

            foreach (string Basename in _entity.Bases) {
                AddInputs(_fgd.GetBaseByName(Basename), true);
            }

            pnlInputList.ResumeLayout();
        }

        void AddInputs(ForgeGameData.EntityDef Source, bool IsReadOnly = false)
        {
            if (Source == null)
                return;

            foreach (string InputName in Source.Inputs.Keys) {
                FGD_IOControl Ctl = new FGD_IOControl {
                    Connector = Source.Inputs[InputName],
                    IsReadonly = IsReadOnly,
                    Dock = DockStyle.Top
                };

                pnlInputList.Controls.Add(Ctl);

                Ctl.OnDelete += OnDeleteInput;
            }
        }

        void GetInputs()
        {
            foreach (FGD_IOControl Ctl in pnlInputList.Controls) {
                if (Ctl.IsReadonly)
                    continue;

                _entity.Inputs[Ctl.Connector.Name] = Ctl.Connector;
            }
        }

        void OnDeleteInput(object sender, string Name)
        {
            GetInputs();
            _entity.Inputs.Remove(Name);
            SetInputs();
        }

        void SetOutputs()
        {
            foreach (FGD_IOControl Ctl in pnlOutputList.Controls) {
                Ctl.OnDelete -= OnDeleteOutput;
            }

            pnlOutputList.SuspendLayout();
            pnlOutputList.Controls.Clear();

            AddOutputs(_entity);

            foreach (string Basename in _entity.Bases) {
                AddOutputs(_fgd.GetBaseByName(Basename), true);
            }

            pnlOutputList.ResumeLayout();
        }

        void AddOutputs(ForgeGameData.EntityDef Source, bool IsReadOnly = false)
        {
            if (Source == null)
                return;

            foreach (string OutputName in Source.Outputs.Keys) {
                FGD_IOControl Ctl = new FGD_IOControl {
                    Connector = Source.Outputs[OutputName],
                    IsReadonly = IsReadOnly,
                    Dock = DockStyle.Top
                };

                pnlOutputList.Controls.Add(Ctl);

                Ctl.OnDelete += OnDeleteOutput;
            }
        }

        void GetOutputs()
        {
            foreach (FGD_IOControl Ctl in pnlOutputList.Controls) {
                if (Ctl.IsReadonly)
                    continue;

                _entity.Outputs[Ctl.Connector.Name] = Ctl.Connector;
            }
        }

        void OnDeleteOutput(object sender, string Name)
        {
            GetOutputs();
            _entity.Outputs.Remove(Name);
            SetOutputs();
        }

        void SetWidgets()
        {
            foreach (FGD_WidgetControl Ctl in pnlWidgetList.Controls) {
                Ctl.OnDelete -= OnDeleteWidget;
            }

            pnlWidgetList.SuspendLayout();
            pnlWidgetList.Controls.Clear();

            AddWidgets(_entity);

            foreach (string Basename in _entity.Bases) {
                AddWidgets(_fgd.GetBaseByName(Basename), true);
            }

            pnlWidgetList.ResumeLayout();
        }

        void AddWidgets(ForgeGameData.EntityDef Source, bool IsReadOnly = false)
        {
            if (Source == null)
                return;

            foreach (ForgeGameData.Widget aWidget in Source.Widgets) {
                FGD_WidgetControl Ctl = new FGD_WidgetControl {
                    Widget = aWidget,
                    IsReadOnly = IsReadOnly,
                    Dock = DockStyle.Top
                };

                pnlWidgetList.Controls.Add(Ctl);

                Ctl.OnDelete += OnDeleteWidget;
            }
        }

        void GetWidgets()
        {
            _entity.Widgets.Clear();

            foreach (FGD_WidgetControl Ctl in pnlWidgetList.Controls) {
                if (Ctl.IsReadOnly)
                    continue;

                _entity.Widgets.Add(Ctl.Widget);
            }
        }

        void OnDeleteWidget(object sender, string Name)
        {
            GetWidgets();

            foreach (ForgeGameData.Widget W in _entity.Widgets) {
                if (W.Name == Name) {
                    _entity.Widgets.Remove(W);

                    break; // TODO: might not be correct. Was : Exit For
                }
            }

            SetWidgets();
        }

        void GetEdits()
        {
            if (_entity == null)
                return;

            _entity.Comment = txtComment.Text;
            GetProperties();
            GetFlags();
            GetInputs();
            GetOutputs();
            GetWidgets();
        }
//# End Region

        private void mnuNewEnt_Click(System.Object sender, System.EventArgs e)
        {
            ForgeGameData.EntityDef.EntityTypes EntType = ForgeGameData.EntityDef.EntityTypes.Point;

            if (mnuEntBases.Checked)
                EntType = ForgeGameData.EntityDef.EntityTypes.Base;
            if (mnuEntSolids.Checked)
                EntType = ForgeGameData.EntityDef.EntityTypes.Solid;
            if (mnuEntPoints.Checked)
                EntType = ForgeGameData.EntityDef.EntityTypes.Point;

            NewEntityForm Dialog = new NewEntityForm();

            Dialog.FGD = _fgd;
            Dialog.Game = Game;
            Dialog.EntityType = EntType;

            if (Dialog.ShowDialog() == DialogResult.Cancel) return;

            ForgeGameData.EntityDef NewEntity = Dialog.MakeEntity();

            mnuEntBases.Checked = false;
            mnuEntSolids.Checked = false;
            mnuEntPoints.Checked = false;

            switch (NewEntity.EntityType) {
                case ForgeGameData.EntityDef.EntityTypes.Base:
                    mnuEntBases.Checked = true; break;
                case ForgeGameData.EntityDef.EntityTypes.Point:
                    mnuEntPoints.Checked = true;break;
                case ForgeGameData.EntityDef.EntityTypes.Solid:
                    mnuEntSolids.Checked = true;break;
            }

            RefreshEntityList();
            cboEntList.SelectedItem = NewEntity.Name;
        }

        private void mnuNewProperty_Click(System.Object sender, System.EventArgs e)
        {
            if (_entity == null) return;

            ForgeGameData.BaseProperty Result = new ForgeGameData.BaseProperty();

            Result.LabelText = Interaction.InputBox("Please enter the name for your new property.", "New Property");

            if (string.IsNullOrEmpty(Result.LabelText))
                return;

            Result.DataType = "string";
            Result._Name = ForgeGameData.BaseProperty.Sanitize(Result.LabelText);
            GetProperties();
            _entity.Properties.Add(Result.Name, Result);
            SetProperties();
            EntityTabs.SelectedIndex = 0;
        }


        private void mnuNewChoice_Click(System.Object sender, System.EventArgs e)
        {
            ForgeGameData.ChoicesProperty Result = new ForgeGameData.ChoicesProperty();

            Result.LabelText = Interaction.InputBox("Please enter the name for your new choices property.", "New Choice");

            if (string.IsNullOrEmpty(Result.LabelText))
                return;

            Result.DataType = "choices";
            Result._Name = ForgeGameData.BaseProperty.Sanitize(Result.LabelText);
            GetProperties();
            _entity.Properties.Add(Result.Name, Result);
            SetProperties();
            EntityTabs.SelectedIndex = 0;
        }

        private void mnuNewFlag_Click(System.Object sender, System.EventArgs e)
        {
            string Name = Interaction.InputBox("Please enter the label for your new flag.", "New Flag");

            if (string.IsNullOrEmpty(Name))
                return;

            ForgeGameData.FlagsProperty SpawnFlags = GetFlags(true);

            int Max = 1;

            foreach (int I in SpawnFlags.flags.Keys) {
                if (I >= Max)
                    Max = I * 2;
            }

            SpawnFlags.flags[Max] = new ForgeGameData.SpawnFlag
            {
                BitFlags = Max,
                Name = Name
            };

            _entity.Properties["spawnflags"] = SpawnFlags;

            SetFlags();
            EntityTabs.SelectedIndex = 1;
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuNewInput_Click(System.Object sender, System.EventArgs e)
        {
            ForgeGameData.IOConnector Result = new ForgeGameData.IOConnector {
                IsOutput = false,
                DataType = "void"
            };

            Result.Name = Interaction.InputBox("Please enter the name for your new Input.", "New Input");

            if (string.IsNullOrEmpty(Result.Name))
                return;

            GetInputs();
            _entity.Inputs[Result.Name] = Result;
            SetInputs();
            EntityTabs.SelectedIndex = 2;
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuNewOutput_Click(System.Object sender, System.EventArgs e)
        {
            ForgeGameData.IOConnector Result = new ForgeGameData.IOConnector {
                IsOutput = true,
                DataType = "void"
            };

            Result.Name = Interaction.InputBox("Please enter the name for your new Ouput.", "New Output", "On");

            if (string.IsNullOrEmpty(Result.Name))
                return;

            GetOutputs();
            _entity.Outputs[Result.Name] = Result;
            SetOutputs();
            EntityTabs.SelectedIndex = 3;
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuNewWidget_Click(object sender, System.EventArgs e)
        {
            ForgeGameData.Widget Result = new ForgeGameData.Widget() { Seperator = " " };

            Result.Name = Interaction.InputBox("Please enter the name of the widget you wish to add");

            if (string.IsNullOrEmpty(Result.Name))
                return;

            GetWidgets();
            _entity.Widgets.Add(Result);
            SetWidgets();
            EntityTabs.SelectedIndex = 4;
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuEntDelete_Click(System.Object sender, System.EventArgs e)
        {
            if (Interaction.MsgBox("Are you sure you want to delete " + _entity.Name + "?", MsgBoxStyle.Question & MsgBoxStyle.YesNo, "Delete Entity?") != MsgBoxResult.Yes)
                return;

            switch (_entity.EntityType) {
                case ForgeGameData.EntityDef.EntityTypes.Base:
                    _fgd.Bases.Remove(_entity.Name);break;
                case ForgeGameData.EntityDef.EntityTypes.Solid:
                    _fgd.Solids.Remove(_entity.Name);break;
                default:
                    _fgd.Points.Remove(_entity.Name);break;
            }

            RefreshEntityList();
        }

        // ERROR: Handles clauses are not supported in C#
        private void EntityTabs_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (_entity == null)
                return;
            if (EntityTabs.SelectedTab.Name != "TabPreview")
                return;

            GetEdits();
            txtPreview.Text = _entity.ToString();
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuFileExport_Click(System.Object sender, System.EventArgs e)
        {
            if (_entity == null)
                return;

            FolderDialog Dialog = new FolderDialog {
                Description = "Select folder to export C++ files to",
                Text = "Select Folder",
                ShowNewFolderButton = true
            };

            if (Game != null) {
                if (ScriptTo == null) {
                    ScriptTo = Path.Combine(Game.SourcePath, "src", "game", "server");
                }

                try
                {
                    Dialog.AddSpecialFolder(Steam.InstallPath, "Steam");
                    Dialog.AddSpecialFolder(Game.SourcePath, "Source");
                }
                catch (ApplicationException)
                {
                    //we don't care if we cannot find the Steam's or the SDKs install path
                }
                
                Dialog.AddSpecialFolder(Game.InstallPath, "Install");
            }

            Dialog.Folder = ScriptTo;

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            ScriptTo = Dialog.Folder;

            EntityScriptGenerator Helper = new EntityScriptGenerator();

            Helper.Export(Game, Entity, Dialog.Folder);
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuHelp_Click(System.Object sender, System.EventArgs e)
        {
            Interaction.MsgBox("Forge Game Data (FGD) files are used to describe game specific\r\n"+
                "entity types to the Valve Hammer (Hammer) level editor.\r\n" +
                "Add FGD files to your mod's game configuration through\r\n" +
                "Tools->Options menu in Hammer.\r\n\r\n" +
                "FGD files are plain ASCII text files (Notepad can open them)\r\n" +
                "with their own particular syntax.  This utility is designed\r\n" +
                "to handle the proper syntax of the FGD for you.\r\n" + 
                "FGD code for an entity can be viewed in the code tab.\r\n\r\n" +
                "Three groups of entity type can be managed through this utility:\r\n" +
                "Bases - Not listed in Hammer but have common properties, \r\n" +
                "flags or IO upon which other entities can be based.\r\n" + 
                "Solids - Brush based entities in Hammer, such as func_door.\r\n" + 
                "Points - Non-Brush entities such as lights, NPCs and sprites.", MsgBoxStyle.Information, "FGD editor help");
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuExit_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }
    }

}