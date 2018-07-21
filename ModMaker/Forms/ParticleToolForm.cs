using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using LibModMaker;
using Microsoft.VisualBasic;

namespace ModMaker
{
    /// <summary>
    /// UI for managing particle systems
    /// </summary>
    public partial class frmParticleTool
    {
        public ParticleTool Tool;

        public string SystemClipboard = null;

        public bool SystemPropertiesEnabled
        {
            get { return ExplorerSplit.Panel2.Enabled; }
            set { ExplorerSplit.Panel2.Enabled = value; }
        }

        public frmParticleTool()
        {
            InitializeComponent();

            this.Load += new EventHandler(frmParticleTool_Load);
            MenuFileNew.Click += new EventHandler(MenuFileNew_Click);
            MenuCopy.Click += new EventHandler(MenuCopy_Click);
            MenuPaste.Click += new EventHandler(MenuPaste_Click);
            MenuDelete.Click += new EventHandler(MenuDelete_Click);
            MenuLaunch.Click += new EventHandler(MenuLaunch_Click);
            mnuManifest.Click += new EventHandler(mnuManifest_Click);
            PartTree.BeforeExpand += new TreeViewCancelEventHandler(PartTree_BeforeExpand);
            PartTree.AfterSelect += new TreeViewEventHandler(PartTree_AfterSelect);
            PartTree.KeyUp += new KeyEventHandler(PartTree_KeyUp);
            picColour.Click += new EventHandler(picColour_Click);
            btnGo.Click += new EventHandler(btnGo_Click);
            ExitToolStripMenuItem.Click += new EventHandler(ExitToolStripMenuItem_Click);
        }

        private void frmParticleTool_Load(object sender, EventArgs e)
        {
            SourceFileDialog.InitialDirectory = Path.Combine(Tool.Game.InstallPath, "particles") + Path.DirectorySeparatorChar;

            RefreshTree();
        }

        private void MenuFileNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog Dialog = new SaveFileDialog
            {
                InitialDirectory = Tool.ParticlesPath,
                DefaultExt = ".pcf",
                Filter = "Particle Systems(*.pcf)|*.pcf",
                Title = "Please choose a filename for your new particle system",
                FileName = Tool.Game.InstallFolder + "_NewParticleSystem.pcf"
            };
            if (Dialog.ShowDialog() != DialogResult.OK)
                return;

            if (File.Exists(Dialog.FileName))
            {
                Interaction.MsgBox("That filename is already in use", MsgBoxStyle.Exclamation);
                return;
            }

            if (Tool.CreateParticleSystemFile(Dialog.FileName))
            {
                RefreshTree();
            }
        }

        private void MenuCopy_Click(object sender, EventArgs e)
        {
            CopySelectedSystem();
        }

        private void MenuPaste_Click(object sender, EventArgs e)
        {
            PasteSelectedSystem();
        }

        private void MenuDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedSystem();
        }

        private void MenuLaunch_Click(object sender, EventArgs e)
        {
            Tool.Game.Play(" -tools -nop4");
        }

        private void mnuManifest_Click(object sender, EventArgs e)
        {
            ToggleManifest();
        }

        private void PartTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            ExpandFileNode(e.Node);
        }

        private void PartTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (e.Node == null || e.Node.Parent == null)
            {
                SystemPropertiesEnabled = false;
                return;
            }

            if (e.Node.Parent.Parent == null)
            {
                //File Nodes
                SystemPropertiesEnabled = false;
                mnuManifest.Text = e.Node.BackColor == SystemColors.Info
                    ? "Exclude from &Manifest"
                    : "Include in &Manifest";

                return;
            }

            //System node

            lblSystemName.Text = e.Node.Text;
            lblSystemName.Tag = e.Node.Parent.ToolTipText;

            SystemPropertiesEnabled = true;

            ChildList.Items.Clear();

            string[] children = Tool.GetChildNames(lblSystemName.Tag.ToString(), lblSystemName.Text);

            if (children == null || children.Length == 0)
                return;

            foreach (string Child in children)
            {
                ChildList.Items.Add(Child);
            }
        }

        private void PartTree_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.Control)
            {
                if (e.KeyCode == Keys.C)
                {
                    CopySelectedSystem();
                    e.Handled = true;
                }

                if (e.KeyCode == Keys.V)
                {
                    PasteSelectedSystem();
                    e.Handled = true;
                }

                if (e.KeyCode == Keys.M)
                {
                    ToggleManifest();
                    e.Handled = true;
                }
            }
            else
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DeleteSelectedSystem();
                    e.Handled = true;
                }
            }

        }

        private void picColour_Click(object sender, EventArgs e)
        {
            ColorPicker.Color = picColour.BackColor;

            if (ColorPicker.ShowDialog() != DialogResult.OK)
                return;

            picColour.BackColor = ColorPicker.Color;
        }

        private void btnGo_Click(System.Object sender, System.EventArgs e)
        {
            UseWaitCursor = true;
            SystemPropertiesEnabled = false;
            Application.DoEvents();

            try
            {
                Tool.Transform(lblSystemName.Tag.ToString(), lblSystemName.Text, udSpeed.Value, udSize.Value, udColour.Value,
                    picColour.BackColor, chkTransformChildren.Checked, txtTarget.Text);
                RefreshTree();
            }
            finally
            {
                SystemPropertiesEnabled = true;

                UseWaitCursor = false;
                Application.DoEvents();
            }

            Interaction.MsgBox("Transformation Complete", MsgBoxStyle.Information);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void RefreshTree()
        {
            UseWaitCursor = true;
            Application.DoEvents();

            try
            {
                string[] ParticleFiles = Tool.GetParticleFiles();
                KeyValues Manifest = Tool.GetParticleManifest();

                PartTree.Nodes.Clear();

                if (Manifest == null)
                    return;

                TreeNode RootNode = new TreeNode("Particles");
                PartTree.Nodes.Add(RootNode);

                foreach (string FilePath in ParticleFiles)
                {
                    string FileName = Path.GetFileNameWithoutExtension(FilePath);
                    TreeNode FileNode = new TreeNode(FileName);
                    FileNode.Tag = FilePath;
                    FileNode.ToolTipText = FilePath;

                    TreeNode DummyNode = new TreeNode("***dummy***");
                    FileNode.Nodes.Add(DummyNode);

                    RootNode.Nodes.Add(FileNode);
                }

                foreach (KeyValues Key in Manifest.Keys)
                {
                    bool matched = false;

                    foreach (TreeNode FileNode in RootNode.Nodes)
                    {
                        if (
                            FileNode.Tag.ToString()
                                .ToLower()
                                .EndsWith(
                                    Key.Value.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar)
                                        .ToLower()))
                        {
                            matched = true;
                            FileNode.BackColor = SystemColors.Info;
                            FileNode.ForeColor = SystemColors.InfoText;
                        }
                    }

                    if (!matched)
                    {
                        TreeNode FileNode = new TreeNode(Key.Value);
                        FileNode.Tag = Path.Combine(Tool.Game.InstallPath, Key.Value);
                        FileNode.ToolTipText = "Missing - presumed packed";
                        FileNode.ForeColor = SystemColors.GrayText;

                        RootNode.Nodes.Add(FileNode);
                    }
                }

                RootNode.Expand();
            }
            finally
            {
                UseWaitCursor = false;
                Application.DoEvents();
            }
        }

        public void RefreshFileNode(TreeNode FileNode)
        {
            bool IsExpanded = FileNode.IsExpanded;

            FileNode.Nodes.Clear();
            FileNode.Nodes.Add(new TreeNode("***dummy***"));

            if (IsExpanded)
            {
                ExpandFileNode(FileNode);
            }
        }

        public void ExpandFileNode(TreeNode FileNode)
        {
            if (FileNode == null)
                return;
            if (FileNode.Parent == null)
                return;
            if (!object.ReferenceEquals(FileNode.Parent, PartTree.Nodes[0]))
                return;
            if (FileNode.Nodes.Count == 0)
                return;


            if (FileNode.Nodes[0].Text == "***dummy***")
            {
                FileNode.Nodes.Clear();
                string[] Systems = Tool.GetParticleSystemNames(FileNode.Tag.ToString());

                foreach (string Name in Systems)
                {
                    TreeNode SystemNode = new TreeNode(Name);
                    FileNode.Nodes.Add(SystemNode);
                }
            }
        }


        void CopySelectedSystem()
        {
            if (PartTree.SelectedNode == null)
                return;
            if (object.ReferenceEquals(PartTree.SelectedNode, PartTree.Nodes[0]))
                return;

            if (PartTree.SelectedNode.Nodes.Count == 0)
            {
                SystemClipboard = PartTree.SelectedNode.Parent.ToolTipText + ";" + PartTree.SelectedNode.Text;
            }
        }

        void PasteSelectedSystem()
        {
            if (PartTree.SelectedNode == null)
                return;
            if (object.ReferenceEquals(PartTree.SelectedNode, PartTree.Nodes[0]))
                return;
            if (SystemClipboard == null)
                return;

            if (object.ReferenceEquals(PartTree.SelectedNode.Parent, PartTree.Nodes[0]))
            {
                string SourceFilePath = SystemClipboard.Substring(0, SystemClipboard.IndexOf(";"));
                string SourceParticleSystem = SystemClipboard.Substring(SystemClipboard.IndexOf(";") + 1);
                string TargetFilePath = PartTree.SelectedNode.ToolTipText;

                if (Tool.Copy(SourceFilePath, SourceParticleSystem, TargetFilePath))
                {
                    RefreshFileNode(PartTree.SelectedNode);
                }
            }
        }

        void DeleteSelectedSystem()
        {
            if (PartTree.SelectedNode == null)
                return;
            if (object.ReferenceEquals(PartTree.SelectedNode, PartTree.Nodes[0]))
                return;
            if (PartTree.SelectedNode.Nodes.Count > 0)
                return;
            if (PartTree.SelectedNode.Parent == null)
                return;

            string FileName = PartTree.SelectedNode.Parent.ToolTipText;

            if (Tool.Delete(FileName, PartTree.SelectedNode.Text))
            {
                RefreshFileNode(PartTree.SelectedNode.Parent);
            }
        }

        void ToggleManifest()
        {
            if (PartTree.SelectedNode == null)
                return;
            if (object.ReferenceEquals(PartTree.SelectedNode, PartTree.Nodes[0]))
                return;
            if (string.IsNullOrEmpty(PartTree.SelectedNode.ToolTipText))
                return;

            UseWaitCursor = true;
            Application.DoEvents();

            try
            {
                if (PartTree.SelectedNode.BackColor == SystemColors.Info)
                {
                    PartTree.SelectedNode.BackColor = SystemColors.Window;
                }
                else
                {
                    PartTree.SelectedNode.BackColor = SystemColors.Info;
                }

                if (PartTree.SelectedNode.ForeColor == SystemColors.GrayText)
                {
                    PartTree.Nodes[0].Nodes.Remove(PartTree.SelectedNode);
                }

                TreeNode ParticlesNode = PartTree.Nodes[0];
                List<string> Files = new List<string>();

                foreach (TreeNode FileNode in ParticlesNode.Nodes)
                {
                    if (FileNode.BackColor == SystemColors.Info)
                    {
                        Files.Add(FileNode.ToolTipText);
                    }
                    if (FileNode.ForeColor == SystemColors.GrayText)
                    {
                        Files.Add(FileNode.Text);
                    }
                }

                Tool.SetManifest(Files);
            }
            finally
            {
                UseWaitCursor = false;
                Application.DoEvents();
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void MenuFind_Click(object sender, EventArgs e)
        {
            string SystemName = Interaction.InputBox("Please enter the name of the particle system to find.");

            FindParticleSystemByName(SystemName);
        }

        private void FindParticleSystemByName(string SystemName)
        {
            if (string.IsNullOrEmpty(SystemName))
                return;

            TreeNode RootNode = PartTree.Nodes[0];

            RootNode.Collapse(false);
            RootNode.Expand();

            foreach (TreeNode FileNode in RootNode.Nodes)
            {
                foreach (TreeNode SystemNode in FileNode.Nodes)
                {
                    if (SystemNode.Text.Contains(SystemName))
                    {
                        FileNode.Expand();
                        PartTree.Focus();
                        PartTree.SelectedNode = SystemNode;

                        if (SystemNode.Text == SystemName)
                            return;
                    }
                }
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void ChildList_ItemActivate(object sender, EventArgs e)
        {
            if (ChildList.SelectedItems.Count == 0)
                return;
            FindParticleSystemByName(ChildList.SelectedItems[0].Text);
        }


        // ERROR: Handles clauses are not supported in C#
        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Interaction.MsgBox(
                "Source particle systems can be created using the Particle System Editor in the Source engines Tools Mode.  Particle Systems are stored in the particles/ folder in PCF files. \r\n" +
                "This tool is designed to assist you with launching your mod in Tools Mode and managing your particle systems. \r\n\r\n " +
                "The left hand pane is a list of PCF files.  Expand a file to view the particle systems inside it.  File names shown in grey are named in the manifest, but are not present on disk, these are presumed to exist in a VPK package." +
                "Vanilla files exist on disk and are listed in the manifest.  Other files exist on disk but are not listed in the manifest.  Source can only cache PCFs listed in particles/particles_manifest.txt.\r\n\r\n" +
                "Selecting a particle system in the left hand pane will display it's name and child systems on the right hand side, where you can choose to Transform the system (and optionaly it's children).\r\n" +
                "Double click a child system to view it's details.  Use the Edit menu to Copy and Paste the selected system between files or the Transform options to make bulk edits.\r\n" +
                "Any files changed by this tool will be backed up first to prevent acidental loss.",
                MsgBoxStyle.Information,
                "Particle Systems Help");
        }


        //Public Overloads Sub Debug(e As Datamodel.Element, indent As Integer)

        //    Dim strIndent As String = "".PadRight(indent, '\t')

        //    txtDebug.AppendText(String.Format("{0}{1}: {3}{2}", strIndent, e.Name, "\r\n", "{"))

        //    For Each pair As KeyValuePair(Of String, Object) In e
        //        Select Case pair.Value.GetType().Name
        //            Case "ElementArray"
        //                txtDebug.AppendText(strIndent & """" & pair.Key & """: [" & "\r\n")
        //                Debug(pair.Value, indent + 1)
        //                txtDebug.AppendText(strIndent & "]," & "\r\n")
        //            Case "String"
        //                txtDebug.AppendText(strIndent & pair.Key & ": """ & CStr(pair.Value) & """," & "\r\n")
        //            Case "Single", "Int32"
        //                txtDebug.AppendText(String.Format("{0}""{1}"": {2},{3}", strIndent, pair.Key, pair.Value, "\r\n"))
        //            Case "Boolean"
        //                Dim bln As Boolean = pair.Value
        //                txtDebug.AppendText(String.Format("{0}""{1}"": {2},{3}", strIndent, pair.Key, If(bln, "true", "false"), "\r\n"))
        //            Case "Vector3"
        //                Dim vthree As Vector3 = pair.Value
        //                txtDebug.AppendText(String.Format("{0}""{1}"": [{2},{3},{4}],{5}", strIndent, pair.Key, vthree.X, vthree.Y, vthree.Z, "\r\n"))
        //            Case "Color"
        //                Dim colour As Color = pair.Value
        //                txtDebug.AppendText(String.Format("{0}""{1}"": [{2},{3},{4}],{5}", strIndent, pair.Key, colour.R, colour.G, colour.B, "\r\n"))
        //            Case "Element"
        //                txtDebug.AppendText(strIndent & """" & pair.Key & """: [" & "\r\n")
        //                Debug(pair.Value, indent + 1)
        //                txtDebug.AppendText(strIndent & "]," & "\r\n")
        //            Case Else
        //                txtDebug.AppendText(strIndent & pair.Key & ": *" & pair.Value.GetType().FullName & "*, " & "\r\n")
        //        End Select
        //    Next

        //    txtDebug.AppendText(String.Format("{0}{2}{1}", strIndent, "\r\n", "}"))
        //End Sub

        //Public Overloads Sub Debug(el As Datamodel.ElementArray, indent As Integer)
        //    Dim strIndent As String = "".PadRight(indent, '\t')

        //    For Each e As Datamodel.Element In el
        //        Debug(e, indent)
        //        txtDebug.AppendText(strIndent & "," & "\r\n")
        //    Next
        //End Sub

    }

}