using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using LibModMaker;

namespace ModMaker
{
    /// <summary>
    /// UI for editing the GameInfo.txt file that tells HL2.exe how to run, what file systems to mount etc.
    /// </summary>
    public partial class GameInfoForm
    {
        private KeyValues _GameInfo = null;
        private SourceMod Game;

        private string _FileName;

        public GameInfoForm()
        {
            InitializeComponent();

            PicIcon.Click += new EventHandler(PicIcon_Click); 
            chkGameLogo.CheckedChanged += new EventHandler(chkGameLogo_CheckedChanged);
            btnBrowse.Click += new EventHandler(btnBrowse_Click);
        }

        public void LoadFile(string FileName)
        {
            _FileName = FileName;
            _GameInfo = KeyValues.LoadFile(FileName);
            Game = new SourceMod(Path.GetDirectoryName(FileName));

            PicIcon.Image = Game.BigIcon;
            txtGame.Text = _GameInfo.GetString("game");
            txtDeveloper.Text = _GameInfo.GetString("developer");
            txtDevURL.Text = _GameInfo.GetString("developer_url");
            txtManURL.Text = _GameInfo.GetString("manual");

            chkGameLogo.Checked = _GameInfo.GetBool("gamelogo");
            txtTitle.Text = _GameInfo.GetString("title");
            txtTitle2.Text = _GameInfo.GetString("title2");

            switch (_GameInfo.GetString("type"))
            {
                case "singleplayer_only":
                    radTypeSP.Checked = true;
                    break;
                case "multiplayer_only":
                    radTypeMP.Checked = true;
                    break;
                default:
                    radTypeBoth.Checked = true;
                    break;
            }

            chkNoModels.Checked = _GameInfo.GetBool("nomodels");
            chkNoDoff.Checked = _GameInfo.GetBool("nodifficulty");
            chkHasPortals.Checked = _GameInfo.GetBool("hasportals");
            chkNoCrosshair.Checked = _GameInfo.GetBool("nocrosshair");
            chkAdvCrosshair.Checked = _GameInfo.GetBool("advcrosshair");

            ListMaps.SuspendLayout();
            ListMaps.Items.Clear();

            KeyValues HiddenMaps = _GameInfo.GetKey("hidden_maps");
            string[] MapList = Directory.GetFiles(Path.Combine(Game.InstallPath, "maps"), "*.bsp");
            ListViewItem MapItem;
            string MapName;

            foreach (string BSP in MapList)
            {
                MapName = Path.GetFileNameWithoutExtension(BSP);
                MapItem = ListMaps.Items.Add(MapName);

                if (HiddenMaps != null)
                {
                    foreach (KeyValues MapKey in HiddenMaps.Keys)
                    {
                        MapItem.Checked = string.Equals(MapKey.Name, MapName,
                            StringComparison.InvariantCultureIgnoreCase);
                    }
                }
            }

            ListMaps.ResumeLayout();
        }

        public void Save()
        {
            _GameInfo.SetValue("game", txtGame.Text);
            _GameInfo.SetValue("developer", txtDeveloper.Text);
            _GameInfo.SetValue("developer_url", txtDevURL.Text);
            _GameInfo.SetValue("manual", txtManURL.Text);
            SetBooleanKey("gamelogo", chkGameLogo.Checked);
            _GameInfo.SetValue("title", txtTitle.Text);
            _GameInfo.SetValue("title2", txtTitle2.Text);

            if (radTypeBoth.Checked)
                _GameInfo.SetValue("type", "");
            if (radTypeSP.Checked)
                _GameInfo.SetValue("type", "singleplayer_only");
            if (radTypeMP.Checked)
                _GameInfo.SetValue("type", "multiplayer_only");

            SetBooleanKey("nomodels", chkNoModels.Checked);
            SetBooleanKey("nodifficulty", chkNoDoff.Checked);
            SetBooleanKey("hasportals", chkHasPortals.Checked);
            SetBooleanKey("nocrosshair", chkNoCrosshair.Checked);
            SetBooleanKey("advcrosshair", chkAdvCrosshair.Checked);

            string MapList = Path.Combine(Game.InstallPath, "maplist.txt");
            KeyValues MapsKey = _GameInfo.GetKey("hidden_maps");

            if (MapsKey == null)
                MapsKey = new KeyValues("hidden_maps", _GameInfo);
            if (ListMaps.Items.Count > ListMaps.CheckedItems.Count)
                SourceFileSystem.BackUpFile(MapList);

            using (StreamWriter MapListFile = new StreamWriter(MapList))
            {
                MapsKey.Keys.Clear();

                foreach (ListViewItem MapItem in ListMaps.Items)
                {
                    if (MapItem.Checked)
                    {
                        KeyValues Flag = new KeyValues(MapItem.Text, "1", MapsKey);
                    }
                    else
                    {
                        MapListFile.WriteLine(MapItem.Text);
                    }
                }

                if (MapsKey.Keys.Count == 0)
                    _GameInfo.Keys.Remove(MapsKey);
                //no hidden maps? supress this section
            }

            SourceFileSystem.BackUpFile(_FileName);
            _GameInfo.Save(_FileName, System.Text.Encoding.ASCII);
        }

        private void SetBooleanKey(string KeyName, bool Value)
        {
            if (Value)
            {
                _GameInfo.SetValue(KeyName, "1");
            }
            else
            {
                KeyValues BoolKey = _GameInfo.GetKey(KeyName);

                if (BoolKey != null)
                    _GameInfo.Keys.Remove(BoolKey);
            }
        }

        private void PicIcon_Click(System.Object sender, System.EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog
            {
                Title = "Select Mod Icon",
                Filter = "Images (*.png;*.jpg;*.gif;*.bmp;*.tga)|*.png;*.jpg;*.gif;*.bmp;*.tga|Icons (*.ico)|*.ico",
                DefaultExt = ".tga"
            };
            string IconPath = Game.GameIconPath;

            if (IconPath == null)
                IconPath = Game.BigIconPath;
            if (IconPath == null)
                IconPath = Game.IconPath;
            if (IconPath == null)
            {
                if (Game.SourcePath == null)
                {
                    Dialog.InitialDirectory = Game.InstallPath;
                }
                else
                {
                    Dialog.InitialDirectory = Path.Combine(Game.SourcePath, "materialsrc");
                }
            }
            else
            {
                Dialog.InitialDirectory = Path.GetDirectoryName(IconPath);
                Dialog.FileName = Path.GetFileName(IconPath);
            }

            Dialog.CustomPlaces.Add(Game.InstallPath);
            Dialog.CustomPlaces.Add(Game.SourcePath);

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;
            if (Dialog.FileName == Path.GetFileName(IconPath))
                return;

            Game.SetIcon(Dialog.FileName);
            _GameInfo.SetValue("icon", Game.InstallFolder);
            PicIcon.Image = Game.BigIcon;
        }

        private void chkGameLogo_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            btnBrowse.Visible = chkGameLogo.Checked;
        }

        private void btnBrowse_Click(System.Object sender, System.EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog
            {
                Title = "Select Mod Logo",
                Filter = "Images (*.png;*.jpg;*.gif;*.bmp;*.tga;*.psd)|*.png;*.jpg;*.gif;*.bmp;*.tga;*.psd",
                DefaultExt = ".tga"
            };

            Dialog.CustomPlaces.Add(Game.InstallPath);

            if (Game.SourcePath == null)
            {
                Dialog.InitialDirectory = Path.Combine(Game.InstallPath, "materials/vgui/logo");
            }
            else
            {
                Dialog.InitialDirectory = Path.Combine(Game.SourcePath, "materialsrc");
                Dialog.CustomPlaces.Add(Game.SourcePath);
            }

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            Game.SetLogo(Dialog.FileName);
        }
    }

}