using LibModMaker;
using System;
using System.IO;
using System.Drawing;

namespace ModMaker
{

    /// <summary>
    /// Launch a tool to aid localization of a game into multiple languages
    /// </summary>
    public class LocalizationTool : iTool
    {

        public System.Drawing.Image Image
        {
            get { return Properties.Resources.Localization.ToBitmap(); }
        }

        public bool IsValidForMod(LibModMaker.SourceMod Game)
        {
            return true;
        }

        public void Launch(LibModMaker.SourceMod Game)
        {
            var LocalForm = new LocalForm();

            LocalForm.GameDir = Game.InstallFolder;
            LocalForm.Show();
        }

        public string Name
        {
            get { return "Localization"; }
        }

        public string TipText
        {
            get { return "Translate your mod into other languages"; }
        }
    }

}