using LibModMaker;
using System;
using System.IO;
using System.Drawing;

namespace ModMaker
{

    /// <summary>
    /// Launch a tool for managing key bindings in game
    /// </summary>
    public class KeyBindingsTool : iTool
    {

        public System.Drawing.Image Image
        {
            get { return Properties.Resources.Keys.ToBitmap(); }
        }

        public bool IsValidForMod(LibModMaker.SourceMod Game)
        {
            return true;
        }

        public void Launch(LibModMaker.SourceMod Game)
        {
            KeyBindingForm x = new KeyBindingForm();

            x.LoadFiles(Game);
            x.ShowDialog();
        }

        public string Name
        {
            get { return "Key Menu Editor"; }
        }

        public string TipText
        {
            get { return "Edit which commands can be bound to keys via the menu and specify default keys"; }
        }
    }

}