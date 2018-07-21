using System;
using System.Drawing;
using LibModMaker;
using System.IO;

namespace ModMaker
{
    /// <summary>
    /// UI for the start of the new mod wizard
    /// </summary>
    public partial class NewModForm
    {
        private MakeModWizard _wizard;
        public MakeModWizard Wizard
        {
            get {
                _wizard.Title = txtTitle.Text;
                _wizard.InstallFolder = txtFolderName.Text;
                _wizard.SourcePath = txtPath.Text;

                return _wizard;
            }
            set {
                _wizard = value;

                txtTitle.Text = _wizard.Title;
                txtFolderName.Text = _wizard.InstallFolder;
                txtPath.Text = _wizard.SourcePath;
            }
        }

        public string Title
        {
            get { return txtTitle.Text; }
            set { txtTitle.Text = value; }
        }

        public string FolderName
        {
            get { return txtFolderName.Text; }
            set { txtFolderName.Text = value; }
        }

        public string SourcePath
        {
            get { return txtPath.Text; }
            set { txtPath.Text = value; }
        }

        public MakeModWizard.ModTypes ModType
        {
            get { return radHL2MP.Checked ? MakeModWizard.ModTypes.HL2MP : radHL2.Checked ? MakeModWizard.ModTypes.HL2 : MakeModWizard.ModTypes.Episodic; }
            set
            {
                switch (value)
                {
                    case MakeModWizard.ModTypes.HL2MP:
                        radHL2MP.Checked = true;
                        break;
                    case MakeModWizard.ModTypes.HL2:
                        radHL2.Checked = true;
                        break;
                    case MakeModWizard.ModTypes.Episodic:
                        radEpisodic.Checked = true;
                        break;
                }
            }
        }



        public NewModForm()
        {
            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            Icon = Properties.Resources.ModMaker;

            btnBrowse.Click += new EventHandler(btnBrowse_Click);
            txtTitle.LostFocus += new EventHandler(txtTitle_LostFocus);
            txtFolderName.LostFocus += new EventHandler(txtFolderName_LostFocus);
            SplitColumns.Resize += new EventHandler(SplitColumns_Resize);
            
        }

        private void btnBrowse_Click(System.Object sender, System.EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog Dialog = new System.Windows.Forms.FolderBrowserDialog
            {
                Description = "Select source folder",
                ShowNewFolderButton = true,
                SelectedPath = txtPath.Text
            };

            if (Dialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;

            txtPath.Text = Dialog.SelectedPath;
        }

        private void txtTitle_LostFocus(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
                return;
            if (!string.IsNullOrEmpty(txtFolderName.Text))
                return;

            string Result = txtTitle.Text.Trim();
            string[] FillWords =
            {
                "and",
                "of",
                "the",
                "for",
                "in",
                ":",
                "/",
                "\\",
                "?",
                "$",
                ".",
                "act",
                "chapter",
                "episode",
                "part"
            };

            foreach (string Filler in FillWords)
            {
                Result = Result.Replace(Filler, "");
            }

            if (Result.Length < 8)
            {
                txtFolderName.Text = Result.ToLower();

                return;
            }

            string Initials = "";
            bool Initialise = true;

            foreach (char C in Result.ToCharArray())
            {
                if (Initialise)
                {
                    Initials += char.ToLower(C);
                    Initialise = false;
                }
                else
                {
                    if (char.IsWhiteSpace(C))
                    {
                        Initialise = true;
                    }
                    else
                    {
                        Initialise = false;
                    }
                }
            }

            if (Initials.Length < 2)
            {
                txtFolderName.Text = Result.Substring(0, 2).ToLower();

                return;
            }

            txtFolderName.Text = Initials;
        }

        private void txtFolderName_LostFocus(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFolderName.Text))
                return;

            char[] Invarchars = Path.GetInvalidPathChars();

            foreach (char badChar in Invarchars)
            {
                txtFolderName.Text = txtFolderName.Text.Replace(badChar.ToString(),"");
            }

            if (!string.IsNullOrEmpty(txtPath.Text))
                return;

            txtPath.Text = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                txtFolderName.Text);
        }

        void RefreshModListBackground()
        {
            if (SplitColumns.Size.Width*SplitColumns.Size.Height == 0)
                return;

            GraphicsUnit pixel = GraphicsUnit.Pixel;
            Bitmap Buffer = new Bitmap(SplitColumns.Width, SplitColumns.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics Gfx = Graphics.FromImage(Buffer);

            System.Drawing.Drawing2D.LinearGradientBrush Grad = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(0, 0),
                new Point(0, this.Height), Color.FromArgb(255, 16, 16, 16), Color.FromArgb(255, 48, 48, 48));

            var Rect = Buffer.GetBounds(ref pixel);
            Gfx.FillRectangle(Grad, Rect);
            Gfx.Flush();
            SplitColumns.BackgroundImage = Buffer;
            SplitColumns.Panel1.BackgroundImage = Buffer;
            SplitColumns.Panel2.BackgroundImage = Buffer;
        }

        private void SplitColumns_Resize(object sender, System.EventArgs e)
        {
            RefreshModListBackground();
        }
    }

}