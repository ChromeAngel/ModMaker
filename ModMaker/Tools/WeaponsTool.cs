using LibModMaker;
using System;
using System.IO;
using System.Drawing;

namespace ModMaker
{

    /// <summary>
    /// Launch a tool for editing the Source weapons manifest and weapons scripts
    /// </summary>
    public class WeaponsTool : iTool
    {

        public Image Image
        {
            get { return Properties.Resources.Weapon.ToBitmap(); }
        }

        public bool IsValidForMod(LibModMaker.SourceMod Game)
        {
            return true;
        }

        public void Launch(LibModMaker.SourceMod Game)
        {
            WeaponsForm ToolWindow = new WeaponsForm {Game = Game};

            ToolWindow.Show();
        }

        public string Name
        {
            get { return "Weapon Editor"; }
        }

        public string TipText
        {
            get { return "Edit weapon the behaviour and appearance"; }
        }
    }

}