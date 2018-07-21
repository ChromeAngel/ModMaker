using LibModMaker;
using Microsoft.VisualBasic;

namespace ModMaker
{


    public partial class frmTextureData
    {
        public SourceMod Game
        {
            get { return Editor.Game; }
            set { Editor.Game = value; }
        }

        public KeyValues TextureData
        {
            get { return Editor.TextureData; }
            set { Editor.TextureData = value; }
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuHelp_Click(System.Object sender, System.EventArgs e)
        {
            Interaction.MsgBox(
                "Texture Data is how Source enables scripting of graphics.\r\n\r\n" +
                "VTF bitmaps pixelate or blur as they are scaled up to higher\r\n" +
                "resolutions, to combat this weakness Source also supports the\r\n" +
                "use of single colour vector graphics (that can be scaled up\r\n" +
                "very large, without any loss of sharpness) in the form of\r\n" + 
                "True Type fonts." + "\r\n\r\n" + 
                "The texture data format allows modders to specify a graphic\r\n" +
                "in the form of either:" + "\r\n" + 
                "A single glyph (letter/number/symbol) from a font\r\n" +
                "A region within a VTF bitmap image\r\n\r\n" +
                "Windows system fonts are assumed to be available,\r\n" +
                "custom fonts can be loaded by adding them to the\r\n" +
                "fonts section of your resources/clientscheme.res\r\n" +
                "Windows charmap utility can be used to find specific glyphs.\r\n\r\n" +
                "Regions are used to reduce the number of files needed.", MsgBoxStyle.Information, "Texture Data Help");
        }
    }

}