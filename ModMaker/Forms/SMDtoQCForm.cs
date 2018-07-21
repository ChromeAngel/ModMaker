using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using LibModMaker;

namespace ModMaker
{
    /// <summary>
    /// UI for the SMD to QC/MDL tool
    /// </summary>
    public partial class SMDtoQCForm
    {
        public const string defaultSurfaceTypes =
            "default,weapon,item,player,concrete,solidmetal,metal,Wood_solid,Wood_Box,flesh,alienflesh,bloodyflesh,armorflesh,foliage,glass,plastic,rubber,pottery,computer";
        private List<string> _SurfaceProperties = new List<string>();

        public SMDtoQCForm()
        {
            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            _SurfaceProperties.AddRange(defaultSurfaceTypes.Split(','));

            Icon = Properties.Resources.ModMaker;
        }

        public List<string> SurfaceProperties
        {
            get { return _SurfaceProperties; }
            set
            {
                _SurfaceProperties = value;
                cboSurfaceProps.Items.Clear();

                if (value == null)
                    return;
                if (value.Count > 0)
                {
                    cboSurfaceProps.Items.AddRange(_SurfaceProperties.ToArray());
                }
                else
                {
                    cboSurfaceProps.Items.AddRange( defaultSurfaceTypes .Split(','));
                }
            }
        }

        public string SurfaceProperty
        {
            get { return cboSurfaceProps.SelectedItem.ToString(); }
        }

        public string FilePath
        {
            get { return txtFilePath.Text; }
            set { txtFilePath.Text = value; }
        }

        public SourceMod Game { get; set; }


        //Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        //    cboSurfaceProps.Items.Clear()
        //    cboSurfaceProps.Items.AddRange(_SurfaceProperties.ToArray())
        //End Sub
        
        private void btnBrowseSMD_Click(System.Object sender, System.EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog
            {
                Title = "Select SMD",
                Filter = "Model Geometry(*.smd)|*.smd|Obj Model(*.obj)|*.obj",
                FileName = txtFilePath.Text
            };

            if (Game != null)
            {
                Dialog.CustomPlaces.Add(Game.InstallPath);
                Dialog.CustomPlaces.Add(Game.SourcePath);
                Dialog.InitialDirectory = Path.Combine(Game.SourcePath, "modelsrc");
            }

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            txtFilePath.Text = Dialog.FileName;
        }

        private void txtFilePath_TextChanged(object sender, System.EventArgs e)
        {
            string FilePath = txtFilePath.Text.ToLowerInvariant();

            btnGo.Enabled = File.Exists(FilePath) && (FilePath.EndsWith(".smd") || FilePath.EndsWith(".obj"));
        }

        private void txtFilePath_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            txtFilePath.Text = e.Data.GetData("FileNameW").ToString();
        }

        private void txtFilePath_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            bool Match = false;

            foreach (string Format in e.Data.GetFormats())
            {
                if (Format != "FileNameW") continue;

                Match = true;

                break; // TODO: might not be correct. Was : Exit For
            }

            if (!Match) return;

            e.Effect = DragDropEffects.All;
        }
    }

}