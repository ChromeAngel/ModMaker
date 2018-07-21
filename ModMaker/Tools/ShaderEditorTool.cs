using System.IO;

namespace ModMaker
{

    public class ShaderEditorTool : iTool
    {

        public System.Drawing.Image Image
        {
            get { return Properties.Resources.ModMaker.ToBitmap(); }
        }

        public bool IsValidForMod(LibModMaker.SourceMod Game)
        {
            if (Game == null)
                return false;

            string BinPath = Path.Combine(Game.InstallPath, "bin");

            if (!Directory.Exists(BinPath))
                return false;

            string[] ShaderEditorDLLs = Directory.GetFiles(BinPath, "shadereditor_*.dll");

            return ShaderEditorDLLs.Length > 0;
        }

        public void Launch(LibModMaker.SourceMod Game)
        {
            Game.Play("-shaderedit");
        }

        public string Name
        {
            get { return "Shader Editor"; }
        }

        public string TipText
        {
            get { return "Launch the Shader Editor"; }
        }
    }

}