using System;
using System.Drawing;
using LibModMaker;
using System.IO;
using System.Windows.Forms;

namespace ModMaker
{

    /// <summary>
    /// UI for generating ZIP patches of a game/mod
    /// </summary>
    public partial class ZipForm
    {

        protected ZipPatchTool MyPatchTool;
        public ZipPatchTool PatchTool
        {
            get { return MyPatchTool; }
            set
            {
                MyPatchTool = value;
                MyPatchTool.Progress += new ZipPatchTool.ProgressEventHandler(PatchTool_Progress);

                RefreshPath();
            }
        }

        public ZipForm()
        {
            InitializeComponent();
        }

        void RefreshPath()
        {
            if (MyPatchTool == null)
                return;

            string ProductName = MyPatchTool.MyGame.Name.Trim();

            if (ProductName.EndsWith(txtVersion.Text))
            {
                ProductName = ProductName.Substring(0, ProductName.Length - txtVersion.Text.Length).Trim();
            }

            string PatchFileName = string.Format("{0}_patch_{1}.{2}", ProductName, txtVersion.Text, radZip.Checked ? "zip" : "7z");

            string PatchFolder;
            KeyValues ModKeys = MainForm.ModOptions[MyPatchTool.MyGame.InstallFolder];

            if (ModKeys == null)
            {
                PatchFolder = MyPatchTool.MyGame.SourcePath;
            }
            else
            {
                PatchFolder = ModKeys.GetString("ZipPath", MyPatchTool.MyGame.SourcePath);
            }

            if (PatchFolder == null)
            {
                PatchFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            //Not Source folder for the mod!
            txtSaveAs.Text = Path.Combine(PatchFolder, PatchFileName);
        }

        private void PatchTool_Progress(object sender, int Percentage)
        {
            Progress.Maximum = 100;
            Progress.Value = Percentage;
        }

        private void radZip_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            RefreshPath();
        }

        private void txtVersion_TextChanged(System.Object sender, System.EventArgs e)
        {
            RefreshPath();
        }

        private void btnStart_Click(System.Object sender, System.EventArgs e)
        {
            MyPatchTool.PatchFilePath = txtSaveAs.Text;
            grpFormat.Enabled = false;
            pnlVersion.Enabled = false;
            pnlSaveAs.Enabled = false;
            pnlCleanup.Enabled = false;
            Label1.Visible = true;
            Progress.Visible = true;
            btnStart.Enabled = false;
            UseWaitCursor = true;
            Application.DoEvents();

            try
            {
                CleanupTool Cleanup = new CleanupTool { ShouldPrompt = false };
                Cleanup.Launch(MyPatchTool.MyGame);

                MyPatchTool.Start();
            }
            finally
            {
                UseWaitCursor = false;
            }
        }

        private void btnBrowse_Click(System.Object sender, System.EventArgs e)
        {
            SaveFileDialog Dialog = new SaveFileDialog
            {
                FileName = txtSaveAs.Text,
                DefaultExt = radZip.Checked ? ".zip" : ".7z",
                Filter = "Zip Archive (*.zip)|*.zip|7 zip Archive (*.7z)|*.7z",
                InitialDirectory = Path.GetDirectoryName(txtSaveAs.Text),
                OverwritePrompt = true
            };

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            txtSaveAs.Text = Dialog.FileName;
        }

        private void frmZip_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            KeyValues ModKeys = MainForm.ModOptions[MyPatchTool.MyGame.InstallFolder];

            if (ModKeys != null)
            {
                ModKeys.SetValue("ZipPath", Path.GetDirectoryName(txtSaveAs.Text));
            }
        }
    }

}