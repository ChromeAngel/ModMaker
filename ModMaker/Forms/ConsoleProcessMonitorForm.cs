using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualBasic;
using System.IO;

namespace ModMaker
{

    /// <summary>
    /// User interface for starting and monitoring the progress command line applications/processes
    /// </summary>
    /// <remarks>Inspired by the limitations of the Hammer compile window</remarks>
    public partial class ConsoleProcessMonitorForm
    {

        public event ProcessEndedEventHandler ProcessEnded;

        public delegate void ProcessEndedEventHandler(object sender, EventArgs e);

        public string SaveLogAs = null;
        private System.Diagnostics.Process _Process = new System.Diagnostics.Process();
        private System.Text.StringBuilder ConsoleText = new System.Text.StringBuilder();

        private bool IsClosed;

        public ConsoleProcessMonitorForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.ModMaker;
            Closing += new CancelEventHandler(frmConsoleProcessMonitor_Closing); 
        }

        public void Monitor(string Executable, string Arguments = null, string WorkingFolder = null)
        {
            ConsoleText.Length = 0;
            //pnlLog.Height = 0
            btnCancel.Enabled = true;
            btnRepeat.Enabled = false;
            Show();
            IsClosed = false;

            if (string.IsNullOrEmpty(Arguments))
            {
                ReadLine(Executable);
            }
            else
            {
                ReadLine(Executable + " " + Arguments);
            }

            if (string.IsNullOrEmpty(WorkingFolder))
            {
                WorkingFolder = Environment.CurrentDirectory;
            }

            _Process = new System.Diagnostics.Process();

            _Process.ErrorDataReceived += new DataReceivedEventHandler(_Process_ErrorDataReceived);
            _Process.Exited += new EventHandler(_Process_Exited);
            _Process.OutputDataReceived += new DataReceivedEventHandler(_Process_OutputDataReceived);

            try
            {
                _Process.StartInfo.FileName = Executable;
                _Process.StartInfo.Arguments = Arguments;
                _Process.StartInfo.WorkingDirectory = WorkingFolder;
                _Process.StartInfo.CreateNoWindow = true;
                _Process.StartInfo.UseShellExecute = false;
                _Process.StartInfo.RedirectStandardOutput = true;
                _Process.StartInfo.RedirectStandardError = true;
                _Process.StartInfo.StandardOutputEncoding = new System.Text.UTF8Encoding();

                _Process.EnableRaisingEvents = true;
                _Process.Start();
                _Process.BeginOutputReadLine();

                btnRepeat.Enabled = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetType().Name);
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("Monitor({0},{1},{2})", Executable, Arguments, WorkingFolder);

                Interaction.MsgBox(Application.ProductName + " encountered an error while processing " + Executable,
                    MsgBoxStyle.Exclamation, "Whoops!");
            }
        }

        private void _Process_ErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            if (IsClosed)
                return;

            string Line = e.Data;

            this.Invoke(new ReadLineAsync(ReadLine), new object[] {Line});
        }

        private void _Process_Exited(object sender, System.EventArgs e)
        {
            if (IsClosed)
                return;

            this.Invoke(new Action(ProcessExitAsync));
        }

        private void _Process_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            if (IsClosed)
                return;

            string Line = e.Data;

            this.Invoke(new ReadLineAsync(ReadLine), new object[] {Line});
        }

        private void ProcessExitAsync()
        {
            if (ProcessEnded != null)
            {
                ProcessEnded(this, EventArgs.Empty);
            }

            btnCancel.Enabled = false;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            _Process.Kill();
            _Process = null;
            IsClosed = true;
        }

        delegate void ReadLineAsync(string Line);

        public void ReadLine(string Line)
        {
            Debug.WriteLine(Line);

            ConsoleText.AppendLine(Line);
            lbllog.Text = ConsoleText.ToString();
            lbllog.SelectionStart = ConsoleText.Length;
            lbllog.ScrollToCaret();

            Application.DoEvents();
        }

        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            IsClosed = true;
            //VisualStyleElement.ToolTip.Close();
            Close();
        }

        private void btnSave_Click(System.Object sender, System.EventArgs e)
        {
            var SaveAS = new SaveFileDialog();

            SaveAS.Title = "Save Compile Log as...";
            SaveAS.Filter = "Log files(*.log)|*.log|Text files(*.txt)|*.txt";
            if (!string.IsNullOrEmpty(SaveLogAs))
            {
                FileInfo FO = new FileInfo(SaveLogAs);

                SaveAS.InitialDirectory = FO.DirectoryName;
                SaveAS.FileName = SaveLogAs;
            }

            if (SaveAS.ShowDialog() == DialogResult.Cancel) return;

            using (StreamWriter x = new StreamWriter(SaveAS.FileName))
            {
                x.Write(lbllog.Text);
                x.Flush();
            }

            Interaction.MsgBox("Done.", MsgBoxStyle.Information, "Log Saved");
        }

        private void btnRepeat_Click(object sender, System.EventArgs e)
        {
            try
            {
                Monitor(_Process.StartInfo.FileName, _Process.StartInfo.Arguments, _Process.StartInfo.WorkingDirectory);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetType().Name);
                Debug.WriteLine(ex.Message);

                Interaction.MsgBox(
                    Application.ProductName + " encountered an error while processing " + _Process.StartInfo.FileName,
                    MsgBoxStyle.Exclamation, "Whoops!");
            }
        }

        private void frmConsoleProcessMonitor_Closing(object sender, CancelEventArgs e)
        {
            IsClosed = true;
        }
    }

}