using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using LibModMaker;
using Microsoft.VisualBasic;
using System.IO;

namespace ModMaker
{

    /// <summary>
    /// Main form of the app, the Mod Explorer
    /// </summary>
    /// <remarks></remarks>
    public partial class MainForm
    {
        /// <summary>
        /// List of Source mods detected from disk
        /// </summary>
        /// <remarks></remarks>

        public List<SourceMod> Mods;

        /// <summary>
        /// Options about mods no stored eleswhere, shortcuts, folders etc.
        /// </summary>
        /// <remarks></remarks>

        public static KeyValues ModOptions;

        /// <summary>
        /// A wizard for making new Source 2013 mods
        /// </summary>
        /// <remarks></remarks>

        private MakeModWizard Wizard = new MakeModWizard();

        /// <summary>
        /// Path to the file where the ModOptions are saved
        /// </summary>
        /// <value>expected in the options folder where the EXE resides</value>
        /// <returns>Path to the file where the ModOptions are saved</returns>
        /// <remarks></remarks>
        private string ModsFilePath
        {
            get { return Path.Combine(Application.StartupPath, "options","mods.txt"); }
        }

        public MainForm()
        {
            InitializeComponent();

            Icon = Properties.Resources.ModMaker;

            Load += new EventHandler(frmMain_Load);
            KeyUp += new KeyEventHandler(frmMain_KeyUp);
            FormClosing += new FormClosingEventHandler(frmMain_FormClosing);

            ModView1.GameInfoChanged += new ModView.GameInfoChangedEventHandler(ModView1_GameInfoChanged);
            mnuFileNew.Click += new EventHandler(mnuFileNew_Click);
            mnuExit.Click += new EventHandler(mnuExit_Click);
            OptionsToolStripMenuItem.Click += new EventHandler(OptionsToolStripMenuItem_Click);
            btnRefresh.Click += new EventHandler(btnRefresh_Click);
            ToolStripButton1.Click += new EventHandler(ToolStripButton1_Click);

            ValveDeveloperCommunityToolStripMenuItem.Click += new EventHandler(ValveDeveloperCommunityToolStripMenuItem_Click);
            QCCommandsVDCToolStripMenuItem.Click += new EventHandler(QCCommandsVDCToolStripMenuItem_Click);
            SteampoweredcomForumToolStripMenuItem.Click += new EventHandler(SteampoweredcomForumToolStripMenuItem_Click);
            SourceSDKDiscussionToolStripMenuItem.Click += new EventHandler(SourceSDKDiscussionToolStripMenuItem_Click);
            SourceModdingcomToolStripMenuItem.Click += new EventHandler(SourceModdingcomToolStripMenuItem_Click);
            InterlopersnetToolStripMenuItem.Click += new EventHandler(InterlopersnetToolStripMenuItem_Click);
            SteamInfoToolStripMenuItem.Click += new EventHandler(SteamInfoToolStripMenuItem_Click);
            AboutToolStripMenuItem.Click += new EventHandler(AboutToolStripMenuItem_Click);

            ModList.ItemActivate += new EventHandler(ModList_ItemActivate);
            ModList.Resize += new EventHandler(ModList_Resize);

            Wizard.Failed += new  MakeModWizard.FailedEventHandler(Wizard_Failed);
            Wizard.Finished += new MakeModWizard.FinishedEventHandler(Wizard_Finished);

        }


        /// <summary>
        /// On Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void frmMain_Load(object sender, System.EventArgs e)
        {
            TryLoadingModOptions();
            RefreshModList();
            ShowVProject();
        }

        private void TryLoadingModOptions()
        {
            ModOptions = KeyValues.LoadFile(ModsFilePath);

            if (ModOptions == null)
                ModOptions = new KeyValues("mods");
        }

        /// <summary>
        /// Select a mod based on the VProject environment variable
        /// </summary>
        /// <remarks>Valve uses VProject to store the path to the working project.  
        /// I haven't worked out how to write to it perminantly, so i'm using the option $last_mod to fake it.
        /// </remarks>
        private void ShowVProject()
        {
            if (Mods.Count == 0)
                return;

            string DefaultMod = Environment.GetEnvironmentVariable("VProject");

            if (!string.IsNullOrEmpty(DefaultMod))
            {
                DefaultMod = SourceFileSystem.FormatFolderPath(DefaultMod);

                if (Directory.Exists(DefaultMod))
                {
                    if (ShowMod(DefaultMod))
                        return;
                } else
                {
                    Environment.SetEnvironmentVariable("VProject", "", EnvironmentVariableTarget.User);
                    DefaultMod = null;
                }
            }

            string SourceModPath = null;

            try
            {
                SourceModPath = Steam.SourceModPath;
            }
            catch (ApplicationException)
            {
                //Steam install folder not found
                if (
                    MessageBox.Show(
                        "ModMaker cannot find your Steam folder and cannot continue without it.  Can you tell ModMaker where Steam is installed now?",
                        "Steam not found", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    Application.Exit();
                }

                var FolderPicker = new FolderBrowserDialog();

                FolderPicker.Description = "Please select the folder where you have Steam installed.";

                if (FolderPicker.ShowDialog() == DialogResult.Cancel)
                {
                    Application.Exit();
                }

                //Tell out Steam class where it's installed
                Steam.InstallPath = FolderPicker.SelectedPath;
                SourceModPath = Steam.SourceModPath;
            }

            DefaultMod = Path.Combine(SourceModPath, SourceFileSystem.FormatFolderPath(ModOptions.GetString("$last_mod")));

            if (ShowMod(DefaultMod))
                return;

            ShowMod(Mods[0]);
        }

        /// <summary>
        /// Refresh the list of Mods from disk
        /// </summary>
        /// <remarks></remarks>
        public void RefreshModList()
        {
            Mods = Steam.SourceMods;
            ModList.Items.Clear();
            ModIcons.Images.Clear();

            foreach (var SMod in Mods)
            {
                ModIcons.Images.Add(SMod.DefaultIcon);

                ListViewItem MnuItem = new ListViewItem(SMod.Name, ModIcons.Images.Count - 1);

                MnuItem.Tag = SMod.InstallFolder;
                MnuItem.ToolTipText = SMod.InstallPath;
                ModList.Items.Add(MnuItem);
            }

           // RefreshModListBackground();
        }

        /// <summary>
        /// Select the named mod for display
        /// </summary>
        /// <param name="Name">Path to the Gameinfo.txt of the mod being selected</param>
        /// <returns></returns>
        /// <remarks>True on sucesss</remarks>
        private bool ShowMod(string Name)
        {
            if (Mods.Count == 0)
                return false;

            foreach (SourceMod SMod in Mods)
            {
                if (!string.Equals(SMod.InstallPath, Name, StringComparison.InvariantCultureIgnoreCase))
                    continue;

                ShowMod(SMod);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Select the specified mod for display
        /// </summary>
        /// <param name="SMod">SourceMod object to be displayed</param>
        /// <remarks></remarks>
        public void ShowMod(SourceMod SMod)
        {
            if (SMod == null)
                return;
            if (ModOptions == null)
            {
                MessageBox.Show("Tell ChromeAngel ModOptions is NULL", "ModMaker - Errors", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                TryLoadingModOptions();
            }

            KeyValues OptionKey = ModOptions[SMod.InstallFolder];

            if (OptionKey == null)
                OptionKey = new KeyValues(SMod.InstallFolder, ModOptions);

            KeyValues UpdatePreviousOptions = ModView1.Options;

            ModOptions.SetValue("$last_mod", SMod.InstallFolder);

            ModView1.Value = SMod;
            ModView1.Options = OptionKey;
            ModView1.Show();
        }

        private void ModView1_GameInfoChanged(object sender, System.EventArgs e)
        {
            string ModPath = ModView1.Value.InstallPath;

            RefreshModList();

            foreach (ListViewItem ModItem in ModList.Items)
            {
                if (ModItem.ToolTipText == ModPath)
                {
                    ModItem.Selected = true;

                    break; // TODO: might not be correct. Was : Exit For
                }
            }

            ShowMod(ModPath);
        }

        /// <summary>
        /// Start the New Mod Wizard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void mnuFileNew_Click(System.Object sender, System.EventArgs e)
        {
            Wizard.Begin();
        }

        /// <summary>
        /// The New Mod Wizard may fail, this handles the failure message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="msg"></param>
        /// <remarks></remarks>
        private void Wizard_Failed(object sender, string msg)
        {
            if (msg != null)
                MessageBox.Show(msg,"ModMaker - Wizard Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// The New Mod Wizard has finished sucessfully
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="FolderName">Install path of the new mod</param>
        private void Wizard_Finished(object sender, string FolderName)
        {
            if (FolderName == null)
                return;

            TryLoadingModOptions();
            RefreshModList();

            try
            {
                FolderName = Path.Combine(Steam.SourceModPath, FolderName);

                ShowMod(FolderName);

                foreach (ListViewItem ModItem in ModList.Items)
                {
                    if (ModItem.ToolTipText == FolderName)
                    {
                        ModItem.Selected = true;

                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
            catch (ApplicationException)
            {
                return;
            }

        }

        /// <summary>
        /// Shortcut keys
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>F5 to refresh, like windows explorer</remarks>
        private void frmMain_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                RefreshModList();
        }

        /// <summary>
        /// Click to refresh the Mod list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            RefreshModList();
        }

        /// <summary>
        /// Select a Mod from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void ModList_ItemActivate(object sender, System.EventArgs e)
        {
            if (ModList.SelectedItems.Count == 0)
                return;

            ShowMod(ModList.SelectedItems[0].ToolTipText);
        }

        private void OptionsToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            OptionsForm X = new OptionsForm();

            X.ShowDialog();
        }

        private void ValveDeveloperCommunityToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            Process.Start("http://developer.valvesoftware.com/wiki/SDK_Docs");
        }

        private void QCCommandsVDCToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            Process.Start("https://developer.valvesoftware.com/wiki/Category:QC_Commands");
        }

        private void SteampoweredcomForumToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            Process.Start("http://forums.steampowered.com/forums/forumdisplay.php?f=191");
        }

        private void SourceSDKDiscussionToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            Process.Start("http://steamcommunity.com/app/211/discussions/1/");
        }

        private void SourceModdingcomToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            Process.Start("http://www.sourcemodding.com/");
        }

        private void InterlopersnetToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            Process.Start("http://www.interlopers.net/");
        }

        private void SteamInfoToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            var Dialog = new SteamInfoForm();
           Dialog.ShowDialog();
        }

        private void AboutToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            AboutForm X = new AboutForm();

            X.ShowDialog();
        }

        private void ModList_Resize(object sender, System.EventArgs e)
        {
         //   RefreshModListBackground();
        }

        /// <summary>
        /// Draws a gradiented background to the list of mods
        /// </summary>
        /// <remarks>Trying to look like the Steam Library</remarks>
        void RefreshModListBackground()
        {
            if (ModList.Size.Width*ModList.Size.Height == 0)
                return;

            GraphicsUnit pixels = GraphicsUnit.Pixel;
            int ImgHeight = Math.Max(ModList.Height, ModList.Items.Count*ModList.TileSize.Height);
            Bitmap Buffer = new Bitmap(ModList.Width, ImgHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics Gfx = Graphics.FromImage(Buffer);

            System.Drawing.Drawing2D.LinearGradientBrush Grad = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(0, 0),
                new Point(0, ImgHeight), Color.FromArgb(255, 16, 16, 16), Color.FromArgb(255, 48, 48, 48));

            Gfx.FillRectangle(Grad, Buffer.GetBounds(ref pixels));
            Gfx.Flush();
            ModList.BackgroundImage = Buffer;
        }



        /// <summary>
        /// File->Exit menu item , close the form and end the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuExit_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
            System.Environment.Exit(0);
        }

        /// <summary>
        /// Save our options on closeure
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void frmMain_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            KeyValues UpdateCurrentOptions = ModView1.Options;

            ModOptions.Save(ModsFilePath);
        }

        /// <summary>
        /// Menu item for testing code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>should be hidden in releases</remarks>
        private void ToolStripButton1_Click(System.Object sender, System.EventArgs e)
        {
            //Using Converter As New LibModMaker.VTFConverter
            //    Dim X As New Form

            //    X.BackgroundImage = Converter.ToBitmap("G:\Steam\steamapps\SourceMods\Spherical Nightmares\materials\billboard\billboard1.vtf")
            //    X.Show()
            //End Using
        }

        //private void ToolStripButton1_Click_1(object sender, EventArgs e)
        //{
        //    SourceFileSystem sfs = new SourceFileSystem(ModView1.Value);

        //    var files = sfs.Listing();

        //    using (var fs = new StreamWriter("X:\\EX_Filesystem.txt"))
        //    {
        //        foreach (string path in files)
        //        {
        //            var info = sfs.GetInfo(path);
        //            fs.WriteLine(string.Format("{0}\t{1}\t{2}", path, info.Size, info.Mount));
        //        }
        //    }

        //    Debug.WriteLine("Done");

        //}
    }

}