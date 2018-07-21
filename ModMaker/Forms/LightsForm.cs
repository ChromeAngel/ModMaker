using LibModMaker;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace ModMaker
{

    /// <summary>
    /// UI for editing .RAD files for light emiting textures and other asset based RAD configuration
    /// </summary>
    public partial class LightsForm
    {
        public enum Views
        {
            TextureLights,
            NoShadows,
            ForceTextureShadow
        }


        private Lights _Lights;
        private SourceMod _Game;
        private Views _View = Views.TextureLights;
        private Lights.HDR_TextureLight _TextureLight;
        private Lights.NoShadow _NoShadow;

        private Lights.ForceTextureShadow _ForceTextureShadow;
        private List<string> AutoCompleteSuggestMaterials = new List<string>();

        private List<string> AutoCompleteSuggestModels = new List<string>();
        public Lights Lights {
            get {
                //Gather outstanding changes from the UI
                object OldLight = this.TextureLight;
                object OldShadow = this.NoShadow;
                object OldModel = this.ForceTextureShadow;

                return _Lights;
            }
            set {
                _Lights = value;

                if (_Lights.FilePath == null) {
                    Text = "Lights - Mod Maker";
                    SaveToolStripMenuItem.Enabled = false;
                } else {
                    Text = Path.GetFileName(_Lights.FilePath) + " - Lights - Mod Maker";
                    SaveToolStripMenuItem.Enabled = true;
                }

                RefreshLights();
                View = Views.TextureLights;
            }
        }

        public Views View {
            get { return _View; }
            set {
                _View = value;

                SetView(SplitMaterials, mnuViewLight, (_View == Views.TextureLights));
                SetView(SplitNoShadows, mnuViewShadows, (_View == Views.NoShadows));
                SetView(SplitModels, mnuViewModels, (_View == Views.ForceTextureShadow));
            }
        }

        public Lights.HDR_TextureLight TextureLight {
            get {
                if (_TextureLight == null) return null;

                _TextureLight.material = txtLightMaterial.Text;
                _TextureLight.color = pnlLDRColor.BackColor;
                _TextureLight.HDR_color = pnlHDRColor.BackColor;
                _TextureLight.HDR_Only = radLightHDR.Checked;
                _TextureLight.LDR_Only = radLightLDR.Checked;
                _TextureLight.intensity = int.Parse(txtLDR_Intensity.Text);
                _TextureLight.HDR_intensity = int.Parse(txtHDR_Intensity.Text);

                return _TextureLight;
            }
            set {
                if (value == null) return;

                _TextureLight = value;
                txtLightMaterial.Text = value.material;
                pnlLDRColor.BackColor = value.color;
                pnlHDRColor.BackColor = value.HDR_color;
                radLightHDR.Checked = value.HDR_Only;
                radLightLDR.Checked = value.LDR_Only;
                radLightBoth.Checked = !(value.HDR_Only | value.LDR_Only);
                txtLDR_Intensity.Text = value.intensity.ToString();
                txtHDR_Intensity.Text = value.HDR_intensity.ToString();
            }
        }

        public Lights.NoShadow NoShadow {
            get {
                if (_NoShadow == null) return null;

                _NoShadow.material = txtShadowMaterial.Text;
                _NoShadow.HDR_Only = radShadowHDR.Checked;
                _NoShadow.LDR_Only = radShadowLDR.Checked;

                return _NoShadow;
            }
            set {
                if (value == null) return;

                _NoShadow = value;

                txtShadowMaterial.Text = value.material;
                radShadowHDR.Checked = value.HDR_Only;
                radShadowLDR.Checked = value.LDR_Only;
                radShadowBoth.Checked = !(value.HDR_Only | value.LDR_Only);
            }
        }

        public Lights.ForceTextureShadow ForceTextureShadow {
            get {
                if (_ForceTextureShadow == null) return null;

                _ForceTextureShadow.model = txtModel.Text;
                _ForceTextureShadow.HDR_Only = radModelHDR.Checked;
                _ForceTextureShadow.LDR_Only = radModelLDR.Checked;

                return _ForceTextureShadow;
            }
            set {
                if (value == null) return;

                _ForceTextureShadow = value;

                txtModel.Text = value.model;
                radModelHDR.Checked = value.HDR_Only;
                radModelLDR.Checked = value.LDR_Only;
                radModelBoth.Checked = !(value.HDR_Only | value.LDR_Only);
            }
        }

        public SourceMod Game {
            get { return _Game; }
            set {
                _Game = value;

                AutoCompleteSuggestMaterials.Clear();
                AddSuggestedMaterials(Path.Combine(Game.InstallPath, "materials"), Path.Combine(Game.InstallPath, "materials"));
                txtNewLight.AutoCompleteCustomSource.Clear();
                txtNewLight.AutoCompleteCustomSource.AddRange(AutoCompleteSuggestMaterials.ToArray());
                txtNewShadow.AutoCompleteCustomSource.Clear();
                txtNewShadow.AutoCompleteCustomSource.AddRange(AutoCompleteSuggestMaterials.ToArray());

                AutoCompleteSuggestModels.Clear();
                AddSuggestedModels(Path.Combine(Game.InstallPath, "models"), Path.Combine(Game.InstallPath, "models"));
                txtNewModel.AutoCompleteCustomSource.Clear();
                txtNewModel.AutoCompleteCustomSource.AddRange(AutoCompleteSuggestModels.ToArray());

                if (_Lights.FilePath == null) {
                    string DefaultLights = Path.Combine(_Game.InstallPath, "lights.rad");

                    if (!File.Exists(DefaultLights))
                        return;

                    Lights = Lights.Load(DefaultLights);
                }
            }
        }

        void AddSuggestedMaterials(string Root, string Path)
        {
            string[] Candidates = Directory.GetFiles(Path, "*.vmt");

            foreach (string vmt in Candidates) {
                using (var temp = new StreamReader(vmt)) {
                    //Only add materials using the LightmappedGeneric shader
                    if (temp.ReadLine().Contains("LightmappedGeneric")) {
                        //Trim off the root path and the .vmt extension
                        string Result = vmt.Substring(Root.Length + 1, vmt.Length - (Root.Length + 5));

                        Result = Result.Replace("\\", "/");
                        AutoCompleteSuggestMaterials.Add(Result);
                    }
                }
            }

            string[] SubFolders = Directory.GetDirectories(Path);

            foreach (string Folder in SubFolders) {
                AddSuggestedMaterials(Root, Folder);
            }
        }

        void AddSuggestedModels(string Root, string Path)
        {
            if (!Directory.Exists(Path))
                return;

            string[] Candidates = Directory.GetFiles(Path, "*.mdl");

            foreach (string mdl in Candidates) {
                AutoCompleteSuggestModels.Add(mdl.Substring(Root.Length + 1).Replace("\\", "/"));
            }

            string[] SubFolders = Directory.GetDirectories(Path);

            foreach (string Folder in SubFolders) {
                AddSuggestedModels(Root, Folder);
            }
        }

        public LightsForm()
        {
            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            Lights = new Lights();
            Icon = Properties.Resources.Light;
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuFileNew_Click(System.Object sender, System.EventArgs e)
        {
            Lights = new Lights();
        }

        // ERROR: Handles clauses are not supported in C#
        private void LoadToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
           var Dialog = new OpenFileDialog {
                Title = "Open RAD File",
                DefaultExt = ".rad",
                Filter = "lights file (*.rad)|*.rad",
                CheckFileExists = true
            };

            if (_Game != null) {
                Dialog.CustomPlaces.Add(Game.InstallPath);
                Dialog.CustomPlaces.Add(Game.SourcePath);
                Dialog.InitialDirectory = _Game.InstallPath;
            }

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            Lights = Lights.Load(Dialog.FileName);
        }

        void RefreshLights()
        {
            ListLights.Clear();
            ListShadows.Clear();
            ListModels.Clear();

            if (_Lights == null)
                return;

            List<Lights.Rule> NewRules = new List<Lights.Rule>();

            foreach (var Rule in _Lights.Rules) {
                switch (Rule.GetType().Name) {
                    case "TextureLight":
                        var Light = new Lights.HDR_TextureLight(Rule as Lights.TextureLight);

                        ListLights.Items.Add(Light.material).Tag = Light;
                        //upgrade all Texturelights to HDR_TextureLights
                        NewRules.Add(Light);
                        break;
                    case "HDR_TextureLight":
                        var HDR_Light = Rule as Lights.HDR_TextureLight;

                        ListLights.Items.Add(HDR_Light.material).Tag = Rule;
                        NewRules.Add(HDR_Light);
                        break;
                    case "NoShadow":
                        var Shadow = Rule as Lights.NoShadow;

                        ListShadows.Items.Add(Shadow.material).Tag = Rule;
                        NewRules.Add(Shadow);
                        break;
                    case "ForceTextureShadow":
                        var Model = Rule as Lights.ForceTextureShadow;

                        ListModels.Items.Add(Model.model).Tag = Rule;
                        NewRules.Add(Model);
                        break;
                }
            }

            _Lights.Rules.Clear();
            _Lights.Rules.AddRange(NewRules);
        }

        void SetView(Control Splitter, ToolStripMenuItem menu, bool Active)
        {
            Splitter.Enabled = Active;
            Splitter.Visible = Active;
            menu.Checked = Active;

            if (!Active)
                return;

            Splitter.BringToFront();
            Splitter.Dock = DockStyle.Fill;
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuViewLight_Click(System.Object sender, System.EventArgs e)
        {
            View = Views.TextureLights;
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuViewShadows_Click(System.Object sender, System.EventArgs e)
        {
            View = Views.NoShadows;
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuViewModels_Click(System.Object sender, System.EventArgs e)
        {
            View = Views.ForceTextureShadow;
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnNewLight_Click(System.Object sender, System.EventArgs e)
        {
            if (txtNewLight.Text.Length == 0)
                return;

            Lights.HDR_TextureLight Light = new Lights.HDR_TextureLight { material = txtNewLight.Text };
            ListViewItem ListItem = ListLights.Items.Add(txtNewLight.Text);

            _Lights.Rules.Add(Light);
            ListItem.Tag = Light;
            ListItem.Selected = true;
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnNewShadow_Click(System.Object sender, System.EventArgs e)
        {
            if (txtNewShadow.Text.Length == 0)
                return;

            Lights.NoShadow Light = new Lights.NoShadow { material = txtNewShadow.Text };
            ListViewItem ListItem = ListShadows.Items.Add(txtNewShadow.Text);

            _Lights.Rules.Add(Light);
            ListItem.Tag = Light;
            ListItem.Selected = true;
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnAddModel_Click(System.Object sender, System.EventArgs e)
        {
            if (txtNewModel.Text.Length == 0)
                return;

            Lights.ForceTextureShadow Light = new Lights.ForceTextureShadow { model = txtNewModel.Text };
            ListViewItem ListItem = ListModels.Items.Add(txtNewModel.Text);

            _Lights.Rules.Add(Light);
            ListItem.Tag = Light;
            ListItem.Selected = true;
        }

        // ERROR: Handles clauses are not supported in C#
        private void ListLights_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            object Old = this.TextureLight;

            if (ListLights.SelectedItems.Count == 0)
                return;

            TextureLight = ListLights.SelectedItems[0].Tag as Lights.HDR_TextureLight;
        }

        // ERROR: Handles clauses are not supported in C#
        private void ListShadows_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            object Old = this.NoShadow;

            if (ListShadows.SelectedItems.Count == 0)
                return;

            NoShadow = ListShadows.SelectedItems[0].Tag as Lights.NoShadow;
        }

        // ERROR: Handles clauses are not supported in C#
        private void ListModels_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            object Old = this.ForceTextureShadow;

            if (ListModels.SelectedItems.Count == 0)
                return;

            ForceTextureShadow = ListModels.SelectedItems[0].Tag as Lights.ForceTextureShadow;
        }

        // ERROR: Handles clauses are not supported in C#
        private void pnlLDRColor_Click(object sender, System.EventArgs e)
        {
            var Dialog = new ColorDialog {
                FullOpen = true,
                Color = pnlLDRColor.BackColor
            };

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            pnlLDRColor.BackColor = Dialog.Color;
        }

        // ERROR: Handles clauses are not supported in C#
        private void pnlHDRColor_Click(object sender, System.EventArgs e)
        {
            var Dialog = new ColorDialog {
                FullOpen = true,
                Color = pnlHDRColor.BackColor
            };

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            pnlHDRColor.BackColor = Dialog.Color;
        }

        // ERROR: Handles clauses are not supported in C#
        private void Intensity_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.D0 & e.KeyCode <= Keys.D9) | (e.KeyCode >= Keys.NumPad0 & e.KeyCode >=Keys.NumPad9)) {
                //Pass through
            } else {
                switch (e.KeyCode) {
                    case Keys.Left:
                    case Keys.Right:
                    case Keys.Delete:
                    case Keys.Back:
                    //Pass through
                    default:
                        e.SuppressKeyPress = true;
                        e.Handled = true;
                        break;
                }
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuFileSaveAs_Click(System.Object sender, System.EventArgs e)
        {
            SaveFileDialog Dialog = new SaveFileDialog {
                Title = "Save RAD file as...",
                FileName = _Lights.FilePath,
                Filter = "lights file (*.rad)|*.rad",
                DefaultExt = ".rad"
            };

            if (_Lights.FilePath == null) {
                if (_Game != null)
                    Dialog.InitialDirectory = _Game.InstallPath;
            } else {
                Dialog.InitialDirectory = Path.GetDirectoryName(_Lights.FilePath);
            }

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            if (Lights.Save(Dialog.FileName)) {
                Lights = _Lights;
                Interaction.MsgBox(Dialog.FileName + " saved", MsgBoxStyle.Information);
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void SaveToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            if (Lights.Save())
                Interaction.MsgBox(_Lights.FilePath + " saved", MsgBoxStyle.Information);
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuHelp_Click(System.Object sender, System.EventArgs e)
        {
            Interaction.MsgBox("This is the editor for .RAD files, which are used to tell VRAD which materials emit light, which materials do not cast a shadow and which models have textures that should cast a shadow.\r\n\r\n" +
                "VRAD always loads any lights.rad and <mapname.rad> in the game folder, you can specify more using -light <filename> parameter.\r\n\r\n" + 
                "The default view is the list of meterials that emit light.  You can switch to the other list using the view menu.", MsgBoxStyle.Information, "Help - Lights");
        }

        // ERROR: Handles clauses are not supported in C#
        private void ExitToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            Close();
        }

    }
}