using LibModMaker;
using System;
using System.IO;
using System.Drawing;

namespace ModMaker
{

    /// <summary>
    /// Launch a tool for managing texture lights
    /// </summary>
    public class LightTool : iTool
    {

        public System.Drawing.Image Image
        {
            get { return Properties.Resources.Light.ToBitmap(); }
        }

        public bool IsValidForMod(LibModMaker.SourceMod Game)
        {
            return true;
        }

        public void Launch(LibModMaker.SourceMod Game)
        {
            LightsForm Dialog = new LightsForm();

            Dialog.Game = Game;
            Dialog.Show();
        }

        public string Name
        {
            get { return "Lights"; }
        }

        public string TipText
        {
            get { return "Texture Lights (.rad) Editor"; }
        }
    }

}