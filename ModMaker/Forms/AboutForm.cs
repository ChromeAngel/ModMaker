
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace ModMaker
{
    /// <summary>
    /// UI to give credit to contributors to this project
    /// </summary>
    public partial class AboutForm
    {
        public AboutForm()
        {
            InitializeComponent();

            OKButton.Click += new EventHandler(OKButton_Click);
            
        }

        private void frmAboutvb_Load(System.Object sender, System.EventArgs e)
        {
            PictureBox1.Image = Properties.Resources.ModMaker.ToBitmap();

            // Set the title of the form.
            this.Text = string.Format("About {0}", Application.ProductName);
            // Initialize all of the text displayed on the About Box.
            // TODO: Customize the application's assembly information in the "Application" pane of the project 
            //    properties dialog (under the "Project" menu).
            this.LabelProductName.Text = Application.ProductName;
            this.LabelVersion.Text = string.Format("Version {0}", Application.ProductVersion);
            this.LabelCopyright.Text = "Copyright Matthew Rye";
            this.LabelCompanyName.Text = Application.CompanyName;
            //Me.TextBoxDescription.Text = My.Application.Info.Description
            this.TextBoxDescription.Text =
                "Mod Maker (MM) is a utility to assist with Source modding from day to day.  \n\n" +
                "Please report any bugs to me@chromeangel.co.uk \n\n" + 
                "MM makes use of the following libraries:\nSeven Zip Sharp for patch compression, \n" +
                "NSIS to script and compile installers, \n" + 
                "Targa image reader by David Polomis, \n" + 
                "VTFLib for VTF image reading by Neil Jedrzejewski and Ryan Gregg";
        }

        private void OKButton_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmAboutvb_Resize(object sender, System.EventArgs e)
        {
            RefreshModListBackground();
        }

        void RefreshModListBackground()
        {
            if (this.Size.Width*this.Size.Height == 0)
                return;

            GraphicsUnit pixel = GraphicsUnit.Pixel;
            Bitmap Buffer = new Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics Gfx = Graphics.FromImage(Buffer);

            System.Drawing.Drawing2D.LinearGradientBrush Grad = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(0, 0),
                new Point(0, this.Height), Color.FromArgb(255, 16, 16, 16), Color.FromArgb(255, 48, 48, 48));

            Gfx.FillRectangle(Grad, Buffer.GetBounds(ref pixel));
            Gfx.Flush();
            this.BackgroundImage = Buffer;
        }
    }

}