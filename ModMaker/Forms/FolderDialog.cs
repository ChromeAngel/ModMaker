using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace ModMaker
{
    /// <summary>
    /// A folder selection dialog, because the standard Windows one is aweful (this is however slower and more clunky)
    /// </summary>
    public partial class FolderDialog
    {
        public FolderDialog()
        {
            // This call is required by the designer.
            InitializeComponent();

            //Set icon form resources
            this.Icon = Properties.Resources.ModMaker;

            this.FolderImages.Images.Add("Computer"    , Properties.Resources.computer);
            this.FolderImages.Images.Add("Drive"       , Properties.Resources.Hard_Drive);
            this.FolderImages.Images.Add("FolderClosed", Properties.Resources.Folder_Closed);
            this.FolderImages.Images.Add("FolderOpen"  , Properties.Resources.Folder_Open);

            //Add users special folders
            AddSpecialFolder(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Desktop");
            AddSpecialFolder(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Documents");

            //Add each drive on the machine to the tree
            foreach (var Drive in System.IO.DriveInfo.GetDrives())
            {
                if (!Drive.IsReady) continue;

                string Text;

                if (string.IsNullOrEmpty(Drive.VolumeLabel))
                {
                    Text = Drive.Name;
                }
                else
                {
                    Text = string.Format("{0} ({1})", Drive.VolumeLabel, Drive.Name.TrimEnd(Path.DirectorySeparatorChar));
                }

                TreeNode Item = FolderTree.Nodes[0].Nodes.Add(Text);

                Item.ImageKey = "Drive";
                Item.SelectedImageKey = "Drive";
                Item.Tag = Drive.RootDirectory.FullName;
                Item.Name = Drive.Name.TrimEnd(Path.DirectorySeparatorChar);

                //Add 1st level of folders to the tree
                AddTreeFolders(Item);
            }

            //Expand "my computer"
            FolderTree.Nodes[0].Expand();
        }

        public string Folder
        {
            get { return cboFolderPath.Text; }
            set
            {
                cboFolderPath.Text = value;

                if (string.IsNullOrEmpty(cboFolderPath.Text))
                    return;

                cboFolderPath.Text = cboFolderPath.Text.Replace(Path.AltDirectorySeparatorChar,
                    Path.DirectorySeparatorChar);

                if (!cboFolderPath.Text.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    cboFolderPath.Text += Path.DirectorySeparatorChar;
            }
        }

        public string Description
        {
            get { return lblMessage.Text; }
            set
            {
                lblMessage.Text = value;
                lblMessage.Visible = !string.IsNullOrEmpty(value);
            }
        }

        public string SelectedPath
        {
            get { return Folder; }
            set { Folder = value; }
        }

        public bool ShowNewFolderButton
        {
            get { return btnNew.Visible; }
            set { btnNew.Visible = value; }
        }

        

        //Add folders below the specified root filesystem node
        private void AddTreeFolders(TreeNode Root)
        {
            if (Root == null)
                return;
            if (Root.Nodes.Count > 0)
                return;
            if (!Directory.Exists(Root.Tag.ToString()))
                return;

            string[] Folders;
            try
            {
                Folders = Directory.GetDirectories(Root.Tag.ToString());
            }
            catch (System.UnauthorizedAccessException)
            {
                return;
            }

            foreach (string Folder in Folders)
            {
                DirectoryInfo Info = new DirectoryInfo(Folder);

                if ((Info.Attributes & FileAttributes.Hidden) > 0)
                    continue;

                TreeNode Item = Root.Nodes.Add(Path.GetFileName(Folder));

                Item.ImageKey = "FolderOpen";
                Item.SelectedImageKey = "FolderOpen";
                Item.Tag = Folder;
                Item.ToolTipText = Folder;
                Item.Name = Item.Text;
            }
        }

        //Allow our caller to hint at their own special folders
        public void AddSpecialFolder(string FolderPath, string FolderTitle = null)
        {
            if (FolderPath == null) return;

            FolderPath = Path.GetFullPath(FolderPath).TrimEnd(Path.DirectorySeparatorChar);

            if (!Directory.Exists(FolderPath))
                return;
            if (FolderTitle == null)
                FolderTitle = Path.GetFileName(FolderPath);

            ListViewItem Item = this.ListSpecial.Items.Add(FolderTitle);

            Item.Tag = FolderPath;
            Item.ImageKey = "FolderClosed";
            Item.ToolTipText = FolderPath;

            if (SplitExplorer.SplitterDistance < Item.Bounds.Width + 30)
            {
                SplitExplorer.SplitterDistance = Item.Bounds.Width + 30;
            }
        }

        private void ListSpecial_ItemActivate(object sender, System.EventArgs e)
        {
            if (ListSpecial.SelectedItems.Count == 0) return;

            cboFolderPath.Text = ListSpecial.SelectedItems[0].Tag.ToString();
        }

        private void FolderTree_AfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            foreach (TreeNode SubFolder in e.Node.Nodes)
            {
                if (SubFolder.Nodes.Count > 0)  continue;

                AddTreeFolders(SubFolder);
            }
        }

        private void FolderTree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            cboFolderPath.Text = e.Node.Tag.ToString();
        }

        private void cboFolderPath_TextChanged(object sender, System.EventArgs e)
        {
            if (!Directory.Exists(cboFolderPath.Text))
            {
                btnOK.Enabled = false;

                return;
            }

            btnOK.Enabled = true;

            string strPath = Path.GetFullPath(cboFolderPath.Text);
            string[] Folders = strPath.Split(Path.DirectorySeparatorChar);
            TreeNode Node = FolderTree.Nodes[0];

            foreach (string aFolder in Folders)
            {
                // If aFolder.EndsWith(Path.VolumeSeparatorChar) Then aFolder = aFolder & Path.DirectorySeparatorChar

                Node = Node.Nodes[aFolder];

                if (Node == null) continue;

                AddTreeFolders(Node);
                Node.Expand();
            }

            if (Node != null)
                FolderTree.SelectedNode = Node;
        }

        private void btnNew_Click(System.Object sender, System.EventArgs e)
        {
            if (!btnOK.Enabled) return;

            string NewFolderName = Interaction.InputBox("Please enter the name of the new folder", "New Folder", "New Folder");

            if (string.IsNullOrEmpty(NewFolderName)) return;

            string NewFolderPath = Path.Combine(cboFolderPath.Text, NewFolderName);

            Directory.CreateDirectory(NewFolderPath);
            cboFolderPath.Text = NewFolderPath;
        }
    }

}