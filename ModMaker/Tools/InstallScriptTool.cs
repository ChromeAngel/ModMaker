namespace ModMaker
{

    /// <summary>
    /// Launch the NSI install script builder
    /// </summary>
    public class InstallScriptTool : iTool
    {
        public string PropertyScriptPath;

        public System.Drawing.Image Image
        {
            get { return Properties.Resources.modern_install_full.ToBitmap(); }
        }

        public bool IsValidForMod(LibModMaker.SourceMod Game)
        {
            return true;
        }

        public void Launch(LibModMaker.SourceMod Game)
        {
            InstallScriptMaker Helper = new InstallScriptMaker(Game);
            InstallerForm Dialog = new InstallerForm();

            Dialog.InstallerTool = Helper;
            Dialog.Show();
        }

        public string Name
        {
            get { return "Make Installer"; }
        }

        public string TipText
        {
            get { return "Make a stand alone installer using the Nullsoft install system"; }
        }
    }
}