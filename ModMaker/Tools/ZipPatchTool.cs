using LibModMaker;
using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using SevenZip;

namespace ModMaker
{

    /// <summary>
    /// Tool for zipping up only files that have changed since the last pack
    /// </summary>
    public class ZipPatchTool : iTool
    {

        public LibModMaker.SourceMod MyGame;
        private List<string> _FileList;
        /// <summary>
        /// SevenZip Compressor does all the heavy work
        /// </summary>
        private SevenZip.SevenZipCompressor Compressor = new SevenZip.SevenZipCompressor();
        private string _PatchFilePath;
        private string PatchFileName;

        private ZipForm Dialog;

        /// <summary>
        /// An event to tell the UI that progress is being made compressing files
        /// </summary>
        public event ProgressEventHandler Progress;

        public delegate void ProgressEventHandler(object sender, int Percentage);

        public string Name
        {
            get { return "Make Patch (Zip)"; }
        }

        public string TipText
        {
            get { return "Make a zip file containing all the un-archived files in the mod and mark them as archived."; }
        }


        public Image Image
        {
            get { return Properties.Resources.ModMaker.ToBitmap(); }
        }

        public bool IsValidForMod(LibModMaker.SourceMod Game)
        {
            return true;
        }

        /// <summary>
        /// Initialise the Compressor component and hook up our event handlers
        /// </summary>
        public ZipPatchTool()
        {
            Compressor.ArchiveFormat = SevenZip.OutArchiveFormat.Zip;
            Compressor.CompressionMethod = SevenZip.CompressionMethod.Deflate;
            Compressor.CompressionMode = SevenZip.CompressionMode.Create;
            Compressor.CompressionLevel = SevenZip.CompressionLevel.Ultra;

            Compressor.Compressing += new EventHandler<ProgressEventArgs>(Compressor_Compressing); 
            Compressor.CompressionFinished += new EventHandler<EventArgs>(Compressor_CompressionFinished); 
        }


        public string PatchFilePath
        {
            get { return _PatchFilePath; }
            set { _PatchFilePath = value; }
        }

        /// <summary>
        /// Launch the dialog that provides this tool's UI
        /// </summary>
        /// <param name="Game"></param>
        public void Launch(LibModMaker.SourceMod Game)
        {
            MyGame = Game;

            Dialog = new ZipForm();
            Dialog.PatchTool = this;
            Dialog.ShowDialog();
        }

        /// <summary>
        /// Start the compression process
        /// </summary>
        public void Start()
        {
            _FileList = new List<string>();

            if (Dialog.RadSeven.Checked)
            {
                Compressor.ArchiveFormat = SevenZip.OutArchiveFormat.SevenZip;
                Compressor.CompressionMethod = SevenZip.CompressionMethod.Ppmd;
            } else
            {
                Compressor.ArchiveFormat = SevenZip.OutArchiveFormat.Zip;
                Compressor.CompressionMethod = SevenZip.CompressionMethod.Deflate;
            }

            AddFolder(MyGame.InstallPath);

            if (Progress != null)
            {
                Progress(this, 0);
            }

            try
            {
                Compressor.BeginCompressFiles(_PatchFilePath, Steam.SourceModPath.Length, _FileList.ToArray());
            }
            catch (ApplicationException)
            {
                //if Steam installpath is not found we might get this exception here
                //TODO prompt for install path
            }

        }

        /// <summary>
        /// Resursively add files and folders to _FileList if they do NOT have the archived attribute
        /// </summary>
        /// <param name="Path"></param>
        private void AddFolder(string Path)
        {
            string[] Files = Directory.GetFiles(Path);
            string[] Folders = Directory.GetDirectories(Path);

            foreach (string aFile in Files)
            {
                if ((File.GetAttributes(aFile) & FileAttributes.Archive) == 0)
                    continue;

                _FileList.Add(aFile);
            }

            foreach (string Folder in Folders)
            {
                AddFolder(Folder);
            }
        }

        /// <summary>
        /// Flag all the files and folders in the _FileList as archived
        /// </summary>
        private void FlagAsArchived()
        {
            foreach (string FilePath in _FileList)
            {
                if (FilePath == null)
                    continue;

                File.SetAttributes(FilePath, FileAttributes.Normal);
            }

            Interaction.MsgBox("Files Archived.", MsgBoxStyle.Information);
        }

        /// <summary>
        /// Open windows explorer to the folder where the patch file has been written
        /// </summary>
        /// <param name="Game"></param>
        private void BrowseSource(LibModMaker.SourceMod Game)
        {
            string PatchFolder = Path.GetDirectoryName(_PatchFilePath);

            Process.Start(PatchFolder);
        }

        /// <summary>
        /// Relay the compressing status through the progress event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Compressor_Compressing(object sender, SevenZip.ProgressEventArgs e)
        {
            if (Progress == null) return;

            Progress(this, e.PercentDone);
        }

        /// <summary>
        /// Notify the user that compression has finished and offer to flag the compressed files as archived
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Compressor_CompressionFinished(object sender, System.EventArgs e)
        {
            Dialog.BringToFront(); // Get the focus back to this app if we've lost it
            Dialog.Close();

            if (
                Interaction.MsgBox(
                    "Finished building patch " + PatchFileName + 
                    "\r\n\r\nDo you want to flag these files as archived, so they will be excluded from the next patch?",
                    MsgBoxStyle.Question | MsgBoxStyle.YesNo , "Finished") == MsgBoxResult.Yes)
            {
                FlagAsArchived();
                _FileList.Clear();
            }

            BrowseSource(MyGame);
        }
    }

}