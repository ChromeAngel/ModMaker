using Microsoft.VisualBasic;

namespace ModMaker
{
    /// <summary>
    /// Progress indicator for the new mod wizard
    /// </summary>
    public partial class NewModProgressForm
    {
        private MakeModWizard _wizard;
        public MakeModWizard Wizard
        {
            get
            {
                return _wizard;
            }
            set
            {
                _wizard = value;
                TitleLabel.Text = string.Format("Please wait {0} is being set up.", _wizard.Title);
                _wizard.Failed += new MakeModWizard.FailedEventHandler(Wizard_Failed);
                _wizard.Finished += new MakeModWizard.FinishedEventHandler(Wizard_Finished);
                _wizard.Progress += new MakeModWizard.ProgressEventHandler(Wizard_Progress);
            }
        }
        public NewModProgressForm()
        {
            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            this.Icon = Properties.Resources.ModMaker;
        }

        private void Wizard_Failed(object sender, string msg)
        {
        }

        private void Wizard_Progress(object sender, MakeModWizard.ProgressEventArgs e)
        {
            if (e.msg.StartsWith("Downloaded"))
            {
                ProgressDownload.Value = e.percent;
                lblConfigured.Text = e.msg;
                return;
            }

            if (e.msg.StartsWith("Extracted"))
            {
                ProgressUnzip.Value = e.percent;
                return;
            }

            lblConfigured.Text = e.msg;
        }

        private void Wizard_Finished(object sender, string folder)
        {
            Interaction.MsgBox(string.Format("Mod Maker has finished it's automatic setup of {0}", Wizard.Title), MsgBoxStyle.Information, "New Mod - Mod Maker");
            Close();
        }
    }

}