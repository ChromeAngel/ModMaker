using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibModMaker;
using System.Drawing;
using System.Windows.Forms;

namespace ModMaker
{
    internal class CompilerTool : iFileTool 
    {
        Compiler oCompiler = null;

        public string Name { get { return "Compiler"; } }
        public Image Image { get { return Properties.Resources.ModMaker.ToBitmap(); } }
        public string TipText { get { return "Drag and drop source files on to this icon"; } }
        public bool IsValidForMod(SourceMod Game)
        {
            if (Game == null) return false;
            return true;
        }

        /// <summary>
        /// Launch a dialog to pick a file to compile for a given game
        /// </summary>
        /// <param name="Game"></param>
        public void Launch(SourceMod Game)
        {
            if (oCompiler == null) oCompiler = new Compiler(Game);

            var dialog = new OpenFileDialog() { Title = "Select file to Compile" };

            dialog.Filter = oCompiler.GetFileTypeFilter();

            if (dialog.ShowDialog() == DialogResult.Cancel) return;

            string FilePath = dialog.FileName;

            LaunchFile(Game, FilePath);
        }

        /// <summary>
        /// Launch the compiler with the given file and game
        /// </summary>
        /// <param name="Game"></param>
        /// <param name="FilePath"></param>
        public void LaunchFile(SourceMod Game, string FilePath)
        {
            if (oCompiler == null) oCompiler = new Compiler(Game);

            oCompiler.Compile(FilePath);
        }
    }
}
