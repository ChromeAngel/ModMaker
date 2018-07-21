using LibModMaker;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ModMaker
{

    /// <summary>
    /// UI for editing key bindings
    /// </summary>
    public partial class KeyBindingForm
    {
        public KeyBindingForm()
        {
            InitializeComponent();
        }

        private void frmKeyBinding_Load(object sender, System.EventArgs e)
        {
            Icon = Properties.Resources.Keys;
        }


        string MyConfig = null;
        public void LoadFiles(SourceMod Game)
        {
            this.KeyBindControl1.Game = Game;
            this.KeyBindControl1.LoadFiles();

            MyConfig = Path.Combine(Game.InstallPath, "cfg/config.cfg");
            btnUseMyKeys.Visible = File.Exists(MyConfig);
        }

        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            KeyBindControl1.Save();

            DialogResult = DialogResult.OK;
        }
  
        private void btnNewGroup_Click(System.Object sender, System.EventArgs e)
        {
            string Group = Interaction.InputBox("Enter the name of your new group", "New Group");

            if (Group == null)
                return;

            KeyBindControl1.AddGroup(Group);
        }

        private void btnUseMyKeys_Click(System.Object sender, System.EventArgs e)
        {
            this.KeyBindControl1.LoadKeyBindings(MyConfig);
        }
    }

}