namespace ModMaker
{
    /// <summary>
    /// Tool for editing VGUI res files
    /// </summary>
    public class VGUI_RES_EditTool : iTool
    {

        public System.Drawing.Image Image
        {
            get { return Properties.Resources.ModMaker.ToBitmap(); }
        }

        public bool IsValidForMod(LibModMaker.SourceMod Game)
        {
            return true;
        }

        public void Launch(LibModMaker.SourceMod Game)
        {
            var Dialog = new ResEditorForm();

            Dialog.Game = Game;
            Dialog.Show();
        }

        public string Name
        {
            get { return "RES Editor"; }
        }

        public string TipText
        {
            get { return "VGUI Resource (.res) Editor"; }
        }
    }

}