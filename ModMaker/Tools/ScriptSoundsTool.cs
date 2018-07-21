using LibModMaker;
using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace ModMaker
{
    /// <summary>
    /// A tool for making sound scripts for loose WAV and MP3 files
    /// </summary>
    public class ScriptSoundsTool : iTool
    {
        private LibModMaker.SoundManifest SoundManifest;
        private List<string> Log;
        private List<string> Scripts;
        private List<string> Sounds;

        public string Name
        {
            get { return "Sound Scripter"; }
        }

        public string TipText
        {
            get { return "Creates sound script entries for loose WAVs and MP3s in the Intall/sound folder"; }
        }

        public System.Drawing.Image Image
        {
            get { return Properties.Resources.Sound.ToBitmap(); }
        }

        public bool IsValidForMod(LibModMaker.SourceMod Game)
        {
            return true;
        }

        public void Launch(LibModMaker.SourceMod Game)
        {
            SoundManifest = new LibModMaker.SoundManifest(Game);
            Log = new List<string>();
            Scripts = new List<string>();
            Sounds = new List<string>();

            SoundManifest.CreatedScriptEntry += new SoundManifest.CreatedScriptEntryEventHandler(SoundManifest_CreatedScriptEntry);
            SoundManifest.CreatedScriptFile += new SoundManifest.CreatedScriptFileEventHandler(SoundManifest_CreatedScriptFile);
            SoundManifest.Progress += new SoundManifest.ProgressEventHandler(SoundManifest_Progress);
            SoundManifest.AddLooseFilesToManifest();

            if (Log.Count > 0)
            {
                Interaction.MsgBox(string.Join("\r\n", Log.ToArray()), MsgBoxStyle.Information);
            }

            if (Scripts.Count > 0)
            {
                Interaction.MsgBox("Created new script files :\r\n" + string.Join("\r\n", Scripts.ToArray()),
                    MsgBoxStyle.Information);
            }
        }

        private void SoundManifest_CreatedScriptEntry(object sender, string ScriptFilePath, string SoundFile,
            string ScriptSoundName)
        {
            Sounds.Add(SoundFile);
        }

        private void SoundManifest_CreatedScriptFile(object sender, string FilePath)
        {
            Scripts.Add(FilePath);
        }

        private void SoundManifest_Progress(object sender, string Text)
        {
            Log.Add(Text);
        }
    }

}