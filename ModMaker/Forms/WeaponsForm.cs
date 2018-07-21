using System.IO;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using LibModMaker;

namespace ModMaker
{

    /// <summary>
    /// UI for editing the weapons manifest and weapon scripts
    /// </summary>
    public partial class WeaponsForm
    {
        public SourceMod Game
        {
            get { return WeaponEditor.Game; }
            set { WeaponEditor.Game = value; }
        }

        public KeyValues SelectedWeapon
        {
            get { return WeaponEditor.Value; }
            set
            {
                if (value == null)
                    return;

                UseWaitCursor = true;
                string OtherWeaponName = Path.GetFileNameWithoutExtension(_SelectedWeaponFileName);

                if (string.IsNullOrEmpty(OtherWeaponName))
                    OtherWeaponName = value.GetString("player_anim_prefix", "anon");
                if (OtherWeaponName.Contains("weapon_"))
                    OtherWeaponName = OtherWeaponName.Substring("weapon_".Length);

                WeaponEditor.WeaponName = OtherWeaponName;
                WeaponEditor.Value = value;
                UseWaitCursor = false;
            }
        }

        private string _SelectedWeaponFileName = null;
        private KeyValues _SelectedWeapon = null;

        public WeaponsForm()
        {
            InitializeComponent();
        }

        private WeaponManifest WeaponKeys;
        // ERROR: Handles clauses are not supported in C#
        private void frmWeapons_Load(object sender, System.EventArgs e)
        {
            Icon = Properties.Resources.Weapon;
            RefreshData();
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuRefresh_Click(System.Object sender, System.EventArgs e)
        {
            RefreshData();
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuNew_Click(System.Object sender, System.EventArgs e)
        {
            string WeaponName = Interaction.InputBox("Please specify a short name for your new weapon type.", "Weapon Name",
                "weapon");

            if (string.IsNullOrEmpty(WeaponName))
                return;

            SaveChanges();

            WeaponName = EntityScriptGenerator.ToCPP_ID(WeaponName).ToLower();

            WeaponScript Helper = new WeaponScript(Game);
            string ScriptName = Path.Combine(Game.InstallPath, "scripts/weapon_" + WeaponName + ".txt");
            KeyValues WeaponData = Helper.MakeWeapon(WeaponName);

            WeaponData.Save(ScriptName);
            WeaponKeys.Add(ScriptName, WeaponData);
            WeaponKeys.Save();
            RefreshData();

            _SelectedWeaponFileName = ScriptName;
            SelectedWeapon = WeaponKeys[ScriptName];
        }

        void SaveChanges()
        {
            if (_SelectedWeaponFileName == null)
                return;

            UseWaitCursor = true;
            SourceFileSystem.BackUpFile(_SelectedWeaponFileName);

            WeaponKeys[_SelectedWeaponFileName] = SelectedWeapon;
            WeaponKeys[_SelectedWeaponFileName].Save(_SelectedWeaponFileName);

            WeaponScript Helper = new WeaponScript(Game);

            Helper.SetDeathTexture(WeaponEditor.WeaponName, WeaponEditor.DeathTexureData);

            UseWaitCursor = false;
        }

        void RefreshData()
        {
            if (Game == null)
                return;

            UseWaitCursor = true;

            WeaponKeys = new WeaponManifest(Game);

            this.ListWeapons.Items.Clear();

            foreach (string WeaponScript in WeaponKeys.Keys)
            {
                KeyValues WeaponKey = WeaponKeys[WeaponScript];

                if (WeaponKey == null)
                    continue;
                // in the manifest, but not on disk

                string PrintName = WeaponKey.GetString("printname", "unknwown");

                if (PrintName.StartsWith("#"))
                    PrintName = Game.Localize(PrintName);
                if (PrintName.StartsWith("#"))
                    PrintName = PrintName.TrimStart('#');

                ListViewItem ListItem = ListWeapons.Items.Add(PrintName);
                ListItem.Tag = WeaponScript;
            }

            UseWaitCursor = false;
        }

        // ERROR: Handles clauses are not supported in C#
        private void ListWeapons_ItemActivate(object sender, System.EventArgs e)
        {
            if (ListWeapons.SelectedItems.Count == 0)
                return;

            SaveChanges();

            ListViewItem SelectedItem = ListWeapons.SelectedItems[0];
            _SelectedWeaponFileName = SelectedItem.Tag.ToString();
            SelectedWeapon = WeaponKeys[_SelectedWeaponFileName];
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuScriptCpp_Click(System.Object sender, System.EventArgs e)
        {
            FolderDialog Dialog = new FolderDialog();

            Dialog.AddSpecialFolder(Game.InstallPath, "Install");

            if (Game.SourcePath != null)
                Dialog.AddSpecialFolder(Game.SourcePath, "Source");

            Dialog.Folder = Path.Combine(Game.SourcePath, "src/game/shared");

            if (Dialog.ShowDialog() != DialogResult.OK)
                return;

            WeaponScriptGenerator Helper = new WeaponScriptGenerator
            {
                Game = Game,
                WeaponName = WeaponEditor.WeaponName
            };

            Helper.Export(Dialog.Folder, SelectedWeapon);
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuHelpOverview_Click(System.Object sender, System.EventArgs e)
        {
            Interaction.MsgBox(
                "Source enabled you to configure many aspects of it's weapons\r\n" +
                "outside the code via txt script files.\r\n" +
                "This editor is built to help manage those scripts.\r\n\r\n" + 
                "Weapons are listed on the left and the details of the selected\r\n" +
                "weapon are displayed on the right hand side.\r\n\r\n" +
                "Before publishing weapon scripts should be protected\r\n" +
                "from tampering using VICE to encrypt them into .CTX files,\r\n" + 
                "which this tool cannot edit.", MsgBoxStyle.Information, "Weapons Help Overview");
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuHelpSounds_Click(System.Object sender, System.EventArgs e)
        {
            Interaction.MsgBox(
                "Source scripting lets you specify a set of sounds per weapon.\r\n" +
                "The weapon script specifies the sounds by their script names,\r\n" +
                "rather than their file names, this editor displays lets you \r\n" +
                "pick the file name of the scripted sound.\r\n\r\n" + 
                "When changes to the script are saved the script name for the\r\n" + 
                "specified file is looked up or created for you in the script\r\n" + 
                "game_sounds_weapons.txt\r\n\r\n" +
                "Source is quite particular about what format of WAV file\r\n" + 
                "it will play, but you can use any MP3 file.\r\n\r\n" +
                "You do not need to specify all of the types of sound.", MsgBoxStyle.Information, "Weapons Help Sounds");
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuHelpGraphics_Click(System.Object sender, System.EventArgs e)
        {
            Interaction.MsgBox(
                "Source scripting lets you specify a set weapon specific graphics.\r\n" + 
                "to display to the player on the HUD for events such as:\r\n" + 
                "Weapon selection\r\n" + 
                "Weapon and ammo pickup\r\n\r\n" + 
                "Custom crosshairs can also be specified here.\r\n\r\n" +
                "These graphics can be VTF images or Font glyphs\r\n" + 
                "see the Texture Data help for more details.", MsgBoxStyle.Information, "Weapons Help HUD Graphics");
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuExit_Click(System.Object sender, System.EventArgs e)
        {
            Close();
        }

        // ERROR: Handles clauses are not supported in C#
        private void frmWeapons_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            SaveChanges();
            WeaponKeys.Save();
        }


    }

}