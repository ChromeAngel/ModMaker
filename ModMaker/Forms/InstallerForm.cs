using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;
using LibModMaker;

namespace ModMaker
{
    /// <summary>
    /// UI for the Installer makering tool
    /// </summary>
    public partial class InstallerForm
    {
        protected InstallScriptMaker MyInstallerTool;

        private ConsoleProcessMonitorForm Monitor;

        public InstallerForm()
        {
            InitializeComponent();

            btnBrowse.Click += new EventHandler(btnBrowse_Click);
            btnStart.Click += new EventHandler(btnStart_Click);
            txtVersion.TextChanged += new EventHandler(txtVersion_TextChanged);
        }

        public InstallScriptMaker InstallerTool
        {
            get { return MyInstallerTool; }
            set
            {
                MyInstallerTool = value;

                RefreshPath();
            }
        }

        public string ScriptPath
        {
            get { return txtSaveAs.Text; }
            set { txtSaveAs.Text = value; }
        }

        void RefreshPath()
        {
            if (MyInstallerTool == null)
                return;

            //Not Source folder for the mod!
            txtSaveAs.Text = MyInstallerTool.CreateScriptPath(txtVersion.Text);
        }

        private void txtVersion_TextChanged(System.Object sender, System.EventArgs e)
        {
            RefreshPath();
        }

        private void btnStart_Click(System.Object sender, System.EventArgs e)
        {
            MyInstallerTool.ScriptPath = txtSaveAs.Text;
            MyInstallerTool.PerformCleanup = chkCleanup.Checked;
            pnlVersion.Enabled = false;
            pnlSaveAs.Enabled = false;
            pnlCleanup.Enabled = false;
            pnlCompile.Enabled = false;
            btnStart.Enabled = false;

            UseWaitCursor = true;
            Application.DoEvents();

            if (!MyInstallerTool.Make(txtVersion.Text))
            {
                Interaction.MsgBox("Unable to script your installer to the specified path.", MsgBoxStyle.Critical);

                return;
            }

            if (!File.Exists(ScriptPath))
                return;

            KeyValues ModKeys = MainForm.ModOptions[MyInstallerTool.Game.InstallFolder];

            if (ModKeys != null)
            {
                ModKeys.SetValue("InstallerPath", Path.GetDirectoryName(ScriptPath));
            }

            if (!chkCompile.Checked)
            {
                Interaction.MsgBox("Installer script saved to:\r\n" + MyInstallerTool.ScriptPath);

                string ScriptFolder = Path.GetDirectoryName(MyInstallerTool.ScriptPath);

                Process.Start(ScriptFolder);

                Close();
                return;
            }

            Monitor = new ConsoleProcessMonitorForm();

            Monitor.ProcessEnded += new ConsoleProcessMonitorForm.ProcessEndedEventHandler(Monitor_ProcessEnded);

            Monitor.Monitor("NSIS/makensis.exe", string.Format("/V4 /PAUSE \"{0}\"", ScriptPath),
                MyInstallerTool.Game.SourcePath);
        }

        private void BrowseSource(LibModMaker.SourceMod Game)
        {
            try
            {
                string Path = Game.SourcePath;

                if (Path == null)
                {
                    if (
                        Interaction.MsgBox(
                            "Unable to find the Source folder.  Do you want to setup this mod in the Source SDK now? (this will help us find the Source folder in future)",
                            MsgBoxStyle.Question & MsgBoxStyle.OkCancel, "Setup Source SDK?") == MsgBoxResult.Cancel)
                        return;
                    SourceSDKSetupTool Tool = new SourceSDKSetupTool();

                    Tool.Launch(Game);
                    BrowseSource(Game);
                }
                else
                {
                    if (Directory.Exists(Path))
                    {
                        Process.Start(Path);
                    }
                    else
                    {
                        Interaction.MsgBox("Invalid path " + Path, MsgBoxStyle.Information);
                    }
                }
            }
            catch (ApplicationException ex)
            {
                Interaction.MsgBox(ex.Message, MsgBoxStyle.Exclamation);
            }
        }

        private void btnBrowse_Click(System.Object sender, System.EventArgs e)
        {
            SaveFileDialog Dialog = new SaveFileDialog
            {
                FileName = txtSaveAs.Text,
                DefaultExt = ".nsi",
                Filter = "Nullsoft Install System scripts (*.nsi)|*.nsi",
                InitialDirectory = Path.GetDirectoryName(txtSaveAs.Text),
                OverwritePrompt = true
            };

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            txtSaveAs.Text = Dialog.FileName;
        }

        private void Monitor_ProcessEnded(object sender, System.EventArgs e)
        {
            UseWaitCursor = false;

            Interaction.MsgBox("Installer compilation finished", MsgBoxStyle.Information, "Finished");

            Close();
        }
    }

}