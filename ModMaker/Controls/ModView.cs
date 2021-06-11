using System;
using LibModMaker;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;

namespace ModMaker
{

    /// <summary>
    /// Provides a control to explore and manipulate a Source mod
    /// </summary>
    /// <remarks>
    /// This control is core to the MM app
    /// </remarks>
    public partial class ModView
    {
        private SourceMod _Value = null;
        private KeyValues _Options;

        public event GameInfoChangedEventHandler GameInfoChanged;
        public delegate void GameInfoChangedEventHandler(object sender, EventArgs e);
        public Dictionary<string, iTool> Tools = new Dictionary<string, iTool>();


        public ModView()
        {
            // This call is required by the designer.
            InitializeComponent();

            // Initialise the tools collection with new instances of all the iTool classes
            Tools["Compiler"] = new CompilerTool();
            Tools["Install Source SDK"] = new SDKInstallTool();
            Tools["Setup Source SDK"] = new SourceSDKSetupTool();
            Tools["Source SDK"] = new SourceSDKTool();
            Tools["Hammer"] = new HammerTool();
            Tools["Model Viewer"] = new ModelViewerTool();
            Tools["Face Poser"] = new FacePoserTool();
            //Tools("Shader Editor") = new ShaderEditorTool();
            //Tools("SMD to Prop") = new SMD2QC_Tool();
            Tools["FGD Editor"] = new FGD_Tool();
            Tools["RES Editor"] = new VGUI_RES_EditTool();
            Tools["Key Menu Editor"] = new KeyBindingsTool();
            //Tools("Map Builder") = New MapBuilderTool
            Tools["Lights"] = new LightTool();
            Tools["Weapon Editor"] = new WeaponsTool();
            Tools["Sound Scripter"] = new ScriptSoundsTool();
            //Tools("Soundscape Editor") = new SoundscapeTool();
            Tools["Chapter Maker"] = new ChapterTool();
            Tools["Localization"] = new LocalizationTool();
            Tools["Cleanup"] = new CleanupTool();
            Tools["Steampipe Packer"] = new VPKPackerTool();
            Tools["Make Patch (Zip)"] = new ZipPatchTool();
            Tools["Make Installer"] = new InstallScriptTool();
            Tools["Particle Tool"] = new ParticleTool();
            //Tools("Hit Box Fix") = New HitBoxFix

            //Wiring up the event handlers
            lnkMod.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkMod_LinkClicked);
            btnPlay.Click += new EventHandler(btnPlay_Click);
            btnAdvanced.Click += new EventHandler(btnAdvanced_Click);
            MapWatcher.Created += new FileSystemEventHandler(MapWatcher_Created);
            MapWatcher.Deleted += new FileSystemEventHandler(MapWatcher_Deleted);
            MapWatcher.Renamed += new RenamedEventHandler(MapWatcher_Renamed);
            chkMap.CheckedChanged += new EventHandler(chkMap_CheckedChanged);
            HelperList.DragDrop += new DragEventHandler(HelperList_DragDrop);
            HelperList.DragEnter += new DragEventHandler(HelperList_DragEnter);
            HelperList.ItemActivate += new EventHandler(HelperList_ItemActivate);
            HelperList.KeyUp += new KeyEventHandler(HelperList_KeyUp);
            lblName.Click += new EventHandler(lblName_Click);
        }

        /// <summary>
        /// Specified the Source Mod that this control is editing, using a class from LibModMaker
        /// </summary>
        public SourceMod Value
        {
            get { return _Value; }
            set
            {
                _Value = value;

                if (value == null)
                    return;

                lblName.Text = "     " + _Value.Name;
                lblName.Image = _Value.DefaultIcon;
                lnkMod.Visible = ! string.IsNullOrEmpty(_Value.DeveloperURL );

                if (lnkMod.Visible)
                {
                    if (string.IsNullOrEmpty(_Value.Developer))
                    {
                        lnkMod.Text = "Visit " + _Value.DeveloperURL.Replace("http:/", "").Replace("https:/", "");
                    }
                    else
                    {
                        lnkMod.Text = "Visit " + _Value.Developer;
                    }

                    ToolTipManager.SetToolTip(lnkMod, _Value.DeveloperURL);
                }

                //The "VProject" environment variable is referenced by some of the SDK tools and is used by ModMaker to determine the last mod viewed
                Environment.SetEnvironmentVariable("VProject", value.InstallPath, EnvironmentVariableTarget.User);

                string MapsPath = Path.Combine(_Value.InstallPath, "maps");

                if (Directory.Exists(MapsPath))
                {
                    MapWatcher.Path = MapsPath;
                    MapWatcher.EnableRaisingEvents = true;
                }
                else
                {
                    MapWatcher.EnableRaisingEvents = false;
                }

                RefreshMapList();
            }
        }

        /// <summary>
        /// Optional information about the mod, specificaly shortcuts which gets stored in mods.txt
        /// </summary>
        public KeyValues Options
        {
            get
            {
                if (_Options == null)
                    return new KeyValues();

                KeyValues Folders = _Options["Folders"];
                KeyValues Shortcuts = _Options["Shortcuts"];

                if (Folders == null)
                    Folders = new KeyValues("Folders", _Options);

                if (Shortcuts == null)
                    Shortcuts = new KeyValues("Shortcuts", _Options);

                Folders.Keys.Clear();
                Shortcuts.Keys.Clear();

                foreach (ListViewItem Item in HelperList.Items)
                {
                    if (Item.Group == null)
                        continue;

                    switch (Item.Group.Name.ToLowerInvariant())
                    {
                        case "foldergroup":
                            if (!string.IsNullOrEmpty(Item.Tag.ToString()))
                            {
                                switch (Item.Text.ToLowerInvariant())
                                {
                                    case "install":
                                        //do nothing
                                        break;
                                    case "sdk tools":
                                        //do nothing
                                        break;
                                    case "source":
                                        //do nothing
                                        break;
                                    default:
                                        KeyValues JunkFolder = new KeyValues(Item.Text, Item.Tag.ToString(), Folders);
                                        break;
                                }
                            } else
                            {
                                Debug.WriteLine(Item.Text + "has an empty tag");
                            }
                            break;
                        case "shortcutgroup":
                            KeyValues JunkShortCut = new KeyValues(Item.Text, Item.Tag.ToString(), Shortcuts);
                            break;
                    }
                }

                KeyValues AdvancedKey = _Options["Advanced"];

                if (AdvancedKey == null)
                    AdvancedKey = new KeyValues("Advanced", _Options);

                if (btnAdvanced.Tag == null)
                {
                    AdvancedKey.Value = "";
                }
                else
                {
                    AdvancedKey.Value = btnAdvanced.Tag.ToString();
                }

                return _Options;
            }
            set
            {
                _Options = value;

                if (value == null)
                    return;

                //int HardCodedItemCount = 7;

                HelperList.Items.Clear();

                if (_Value != null)
                {
                    ListViewItem Folder = HelperList.Items.Add("Install");

                    Folder.ImageKey = "Folder_32x32.png";
                    Folder.Tag = _Value.InstallPath;
                    Folder.ToolTipText = _Value.InstallPath;
                    Folder.Group = HelperList.Groups["FolderGroup"];

                    if (_Value.HasSDKInstalled())
                    {
                        try
                        {
                            Folder = HelperList.Items.Add("SDK Tools");
                            Folder.ImageKey = "Folder_32x32.png";
                            Folder.Tag = _Value.SDKPath;
                            Folder.ToolTipText = _Value.SDKPath;
                            Folder.Group = HelperList.Groups["FolderGroup"];

                            if (_Value.SourcePath != null)
                            {
                                Folder = HelperList.Items.Add("Source");
                                Folder.ImageKey = "Folder_32x32.png";
                                Folder.Tag = _Value.SourcePath;
                                Folder.ToolTipText = _Value.SourcePath;
                                Folder.Group = HelperList.Groups["FolderGroup"];
                            }
                        }
                        catch (ApplicationException)
                        {
                            //can get app exceptions if the SDK is not installed
                        }
                    } //End if has SDK

                    foreach (iTool Tool in Tools.Values)
                    {
                        if (!Tool.IsValidForMod(_Value)) continue;

                        ListViewItem ToolItem = HelperList.Items.Add(Tool.Name);

                        if (!HelperIcons.Images.ContainsKey(Tool.Name))
                        {
                            HelperIcons.Images.Add(Tool.Name, Tool.Image);
                        }

                        ToolItem.ImageKey = Tool.Name;
                        ToolItem.ToolTipText = Tool.TipText;
                        ToolItem.Group = HelperList.Groups["ToolGroup"];
                    }//end fpr
                }//End if value != null

                try
                {
                    //Apply saved Options
                    KeyValues Folders = _Options["Folders"];

                    if (Folders != null)
                    {
                        foreach (KeyValues FolderKey in Folders.Keys)
                        {
                            if (Directory.Exists(FolderKey.Value))
                                AddCustomFolder(FolderKey.Value);
                        }
                    }

                    KeyValues Shortcuts = _Options["Shortcuts"];

                    if (Shortcuts != null)
                    {
                        foreach (KeyValues ShortcutKey in Shortcuts.Keys)
                        {
                            if (File.Exists(ShortcutKey.Value))
                                AddCustomShortcut(ShortcutKey.Value);
                        }
                    }

                    btnAdvanced.Tag = _Options.GetString("Advanced", "");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Visit the mod developer's website
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>potential security exploit, relies on the OS to open what is presumed to be a URL</remarks>
        private void lnkMod_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            if (String.IsNullOrEmpty(_Value.DeveloperURL)) return;
            
            Process.Start(_Value.DeveloperURL);
        }

        /// <summary>
        /// Play the mod with the selected parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(System.Object sender, System.EventArgs e)
        {
            System.Text.StringBuilder Arguments = new System.Text.StringBuilder(" -steam");

            if (chkAllowDebug.Checked)
                Arguments.Append(" -allowdebug");
            if (chkWindowed.Checked)
                Arguments.Append(" -windowed");
            if (chkNoIntro.Checked)
                Arguments.Append(" -novid");
            if (chkMap.Checked & !string.IsNullOrEmpty(cboMap.SelectedValue.ToString()))
                Arguments.Append(" +map " + cboMap.SelectedValue);

            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            _Value.Play(Arguments.ToString());

            Cursor = Cursors.Default;
            Application.DoEvents();
        }

        /// <summary>
        /// Open the advanced startup window, so the user can specify their own parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdvanced_Click(System.Object sender, System.EventArgs e)
        {
            AdvancedStartupForm Dialog = new AdvancedStartupForm
            {
                SkipIntro = chkNoIntro.Checked,
                Windowed = chkWindowed.Checked,
                AllowDebug = chkAllowDebug.Checked
            };

            Dialog.RefreshMapList(MapWatcher.Path);

            if (chkMap.Checked)
            {
                Dialog.SelectMap(cboMap.SelectedValue.ToString());
            }
            else
            {
                Dialog.SelectMap(null);
            }

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            btnAdvanced.Tag = Dialog.Parameters;

            _Value.Play(btnAdvanced.Tag.ToString());
        }

        /// <summary>
        /// Browse the mod's Source folder (where MM expect to find src,mapsrc etc.)
        /// </summary>
        private void BrowseSource()
        {
            try
            {
                string Path = _Value.SourcePath;

                if (Path == null || !Directory.Exists(Path) )
                {
                    if (
                        MessageBox.Show(
                            "Unable to find the Source folder.  Do you want to setup this mod in the Source SDK now? (this will help us find the Source folder in future)", 
                            "Setup Source SDK?",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Question) == DialogResult.Cancel)
                        return;
                    Tools["Source SDK Setup"].Launch(_Value);
                    BrowseSource();
                }
                else
                {
                    //pass Path to the OS and let it handle it, Windows uses WindowsExplorer.exe to browse a given path
                    Process.Start(Path);
                }
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message,ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// MM watches the mod's maps sub-folder if it's contents change the list of maps show in MM are rebuilt to reflect the changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            RefreshMapList();
        }
        private void MapWatcher_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            RefreshMapList();
        }
        private void MapWatcher_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            RefreshMapList();
        }

        /// <summary>
        /// Refreshes the maps lists to contain the filenames of the BSPs in the maps folder
        /// </summary>
        public void RefreshMapList()
        {
            string[] RawBSPs = Directory.GetFiles(MapWatcher.Path, "*.bsp");
            List<string> BSPs = new List<string>();
            var oldestMapsFirst = new SortedDictionary<DateTime, string>();

            foreach (string RawBsp in RawBSPs)
            {
                FileInfo BSPinfo = new FileInfo(RawBsp);
                // trim the trailing .bsp
                string innerRawBsp = Path.GetFileNameWithoutExtension(RawBsp);

                DateTime LastWritten = BSPinfo.LastWriteTime;
                while(oldestMapsFirst.Keys.Contains(LastWritten))
                {
                    LastWritten.AddMilliseconds(1);
                }
                oldestMapsFirst.Add(LastWritten, innerRawBsp);
            }

            //Reverse the sort order, so the newest is first
            foreach (var pair in oldestMapsFirst.Reverse())
            {
                BSPs.Add(pair.Value);
            }

            cboMap.DataSource = BSPs;
        }

        /// <summary>
        /// Enable the map dropdown list when the box is checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkMap_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            cboMap.Enabled = chkMap.Checked;
        }

        /// <summary>
        /// Add a folder shortcut to the items for this Mod
        /// </summary>
        /// <param name="Path"></param>
        private void AddCustomFolder(string Path)
        {
            DirectoryInfo DirInfo = new DirectoryInfo(Path);
            ListViewItem I = new ListViewItem(DirInfo.Name)
            {
                Group = HelperList.Groups["FolderGroup"],
                Tag = Path,
                ToolTipText = Path,
                ImageIndex = 0
            };
            HelperList.Items.Add(I);
        }

        /// <summary>
        /// Add a file shortcut to the items for this Mod
        /// </summary>
        /// <param name="FilePath"></param>
        private void AddCustomShortcut(string FilePath)
        {
            ListViewItem I = new ListViewItem(Path.GetFileNameWithoutExtension(FilePath))
            {
                Group = HelperList.Groups["ShortcutGroup"],
                Tag = FilePath,
                ToolTipText = FilePath,
                ImageIndex = 1 //TODO:find the right icon for this type of file
            };

            HelperList.Items.Add(I);
        }

        /// <summary>
        /// Drag and drop support for adding new shortcuts and passing file paths to tools
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelperList_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            object oFilename = e.Data.GetData("FileNameW");
            string[] filenames = oFilename as string[];
            string FilePath = filenames[0]; //[0];

            ListViewItem Hit = GetDroppedOnItem(e.X, e.Y);

            if (Hit == null)
            {
                // the user did not drop onto a tool, so add it to the Mod as a shortcut
                if (Directory.Exists(FilePath))
                {
                    AddCustomFolder(FilePath);
                }
                else
                {
                    if (File.Exists(FilePath))
                    {
                        AddCustomShortcut(FilePath);
                    }
                }
            }
            else
            {
                //Dropped it on a tool, but which tool?
                if (Tools.ContainsKey(Hit.Text))
                {
                    try
                    {
                        iFileTool fileTool;
                        fileTool = Tools[Hit.Text] as iFileTool;
                        fileTool.LaunchFile(Value, FilePath);
                    }
                    catch (Exception)
                    {
                        //will fail here if the tool is not an iFileTool
                    }
                }


                //Dropped it on a folder icon, copy the file to the folder that was dropped on
                if (Hit.Group.Name == "FolderGroup")
                {
                    if (
                        MessageBox.Show("Copy " + FilePath + " to " + Hit.Tag + "?", "Confirm copy", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        return;

                    UseWaitCursor = true;
                    Application.DoEvents();

                    File.Copy(FilePath, Hit.Tag.ToString());

                    UseWaitCursor = false;
                    Application.DoEvents();
                }
            }
        }

        /// <summary>
        /// Determine which ListViewItem is at the co-ordinates where a drag+drop finished
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private ListViewItem GetDroppedOnItem(int x, int y)
        {
            Point DropPoint = new Point(x, y);

            DropPoint = HelperList.PointToClient(DropPoint);

            return HelperList.GetItemAt(DropPoint.X, DropPoint.Y);
        }

        /// <summary>
        /// Enable drang and drop of file names
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelperList_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            bool Match = false;
            foreach (string Format in e.Data.GetFormats())
            {
                if (Format != "FileNameW")
                    continue;

                Match = true;

                break; // TODO: might not be correct. Was : Exit For
            }

            if (!Match)
                return;

            e.Effect = DragDropEffects.All;
        }

        /// <summary>
        /// The use has "activated" on of the items, follow th shortcut or launch the tool for that item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelperList_ItemActivate(object sender, System.EventArgs e)
        {
            if (HelperList.SelectedItems.Count == 0)
                return;

            ListViewItem SelectedItem = HelperList.SelectedItems[0];

            switch (SelectedItem.Group.Name)
            {
                case "FolderGroup":
                    Process.Start("explorer.exe", "/n," + SelectedItem.Tag);
                    break;
                case "ShortcutGroup":
                    Process.Start(SelectedItem.Tag.ToString());
                    break;
                case "ToolGroup":
                    if (Tools.ContainsKey(SelectedItem.Text))
                    {
                        UseWaitCursor = true;
                        Tools[SelectedItem.Text].Launch(_Value);
                        UseWaitCursor = false;
                    }
                    break;
                default:
                    //Special built-in folder shortcuts
                    switch (SelectedItem.Text)
                    {
                        case "Install":
                            _Value.Browse(); //Where the mod is installed
                            break;
                        case "Source":
                            BrowseSource(); //Where the Source code lives
                            break;
                        case "SDK Tools":
                            Process.Start(_Value.SDKPath); //Where the source SDK for this mod lives
                            break;
                    }
                    break;
            }
        }


        /// <summary>
        /// Key handler to enable deleting shortcuts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelperList_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (HelperList.SelectedItems.Count == 0)
                return;

            if (e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem Item in HelperList.SelectedItems)
                {
                    if (Item.Tag != null)
                        HelperList.Items.Remove(Item);
                }
            }
        }

        /// <summary>
        /// Launch the GameInfo form by clicking on the Mod's name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblName_Click(System.Object sender, System.EventArgs e)
        {
            GameInfoForm Dialog = new GameInfoForm();

            Dialog.LoadFile(Path.Combine(_Value.InstallPath, "gameinfo.txt"));

            if (Dialog.ShowDialog() != DialogResult.OK)
                return;

            Dialog.Save();

            if (GameInfoChanged != null)
            {
                GameInfoChanged(this, EventArgs.Empty);
            }

            //Dim Dialog As New OpenFileDialog With {.Title = "Select Mod Icon", .Filter = "Images (*.png;*.jpg;*.gif;*.bmp;*.tga)|*.png;*.jpg;*.gif;*.bmp;*.tga|Icons (*.ico)|*.ico", .DefaultExt = ".tga"}
            //Dim IconPath As String = _Value.GameIconPath

            //If IconPath Is Nothing Then IconPath = _Value.BigIconPath
            //If IconPath Is Nothing Then IconPath = _Value.IconPath
            //If IconPath Is Nothing Then
            //    If _Value.SourcePath Is Nothing Then
            //        Dialog.InitialDirectory = _Value.InstallPath
            //    Else
            //        Dialog.InitialDirectory = Path.Combine(_Value.SourcePath, "materialsrc")
            //    End If
            //Else
            //    Dialog.InitialDirectory = Path.GetDirectoryName(IconPath)
            //    Dialog.FileName = Path.GetFileName(IconPath)
            //End If

            //Dialog.CustomPlaces.Add(_Value.InstallPath)
            //Dialog.CustomPlaces.Add(_Value.SourcePath)

            //If Dialog.ShowDialog = DialogResult.Cancel Then Exit Sub
            //If Dialog.FileName = Path.GetFileName(IconPath) Then Exit Sub

            //_Value.SetIcon(Dialog.FileName)

            //Me.Value = _Value
        }
    }

}