using System;
using System.Windows.Forms;

namespace ModMaker
{


    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class FolderDialog : System.Windows.Forms.Form
    {

        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        //Required by the Windows Form Designer

        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
       // [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(FolderDialog));
            System.Windows.Forms.TreeNode TreeNode1 = new System.Windows.Forms.TreeNode("My Computer");
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.SplitExplorer = new System.Windows.Forms.SplitContainer();
            this.ListSpecial = new System.Windows.Forms.ListView();
            this.FolderImages = new System.Windows.Forms.ImageList(this.components);
            this.FolderTree = new System.Windows.Forms.TreeView();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.cboFolderPath = new System.Windows.Forms.ComboBox();
            this.FlowLayoutPanel1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SplitExplorer.Panel1.SuspendLayout();
            this.SplitExplorer.Panel2.SuspendLayout();
            this.SplitExplorer.SuspendLayout();
            this.SuspendLayout();
            //
            //FlowLayoutPanel1
            //
            this.FlowLayoutPanel1.Controls.Add(this.btnCancel);
            this.FlowLayoutPanel1.Controls.Add(this.btnOK);
            this.FlowLayoutPanel1.Controls.Add(this.btnNew);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(0, 308);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(582, 33);
            this.FlowLayoutPanel1.TabIndex = 0;
            //
            //btnCancel
            //
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(504, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            //btnOK
            //
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(423, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 26);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            //btnNew
            //
            this.btnNew.Location = new System.Drawing.Point(314, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(103, 26);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "&New Folder";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Visible = false;
            this.btnNew.Click += new EventHandler(btnNew_Click);
            //
            //lblMessage
            //
            this.lblMessage.BackColor = System.Drawing.SystemColors.Window;
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMessage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(582, 22);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Select a folder";
            //
            //Panel1
            //
            this.Panel1.Controls.Add(this.SplitExplorer);
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Controls.Add(this.cboFolderPath);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 22);
            this.Panel1.Name = "Panel1";
            this.Panel1.Padding = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.Panel1.Size = new System.Drawing.Size(582, 286);
            this.Panel1.TabIndex = 2;
            //
            //SplitExplorer
            //
            this.SplitExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitExplorer.Location = new System.Drawing.Point(8, 44);
            this.SplitExplorer.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.SplitExplorer.Name = "SplitExplorer";
            //
            //SplitExplorer.Panel1
            //
            this.SplitExplorer.Panel1.Controls.Add(this.ListSpecial);
            //
            //SplitExplorer.Panel2
            //
            this.SplitExplorer.Panel2.Controls.Add(this.FolderTree);
            this.SplitExplorer.Size = new System.Drawing.Size(566, 242);
            this.SplitExplorer.SplitterDistance = 101;
            this.SplitExplorer.TabIndex = 5;
            this.SplitExplorer.TabStop = false;
            //
            //ListSpecial
            //
            this.ListSpecial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListSpecial.LargeImageList = this.FolderImages;
            this.ListSpecial.Location = new System.Drawing.Point(0, 0);
            this.ListSpecial.Name = "ListSpecial";
            this.ListSpecial.ShowItemToolTips = true;
            this.ListSpecial.Size = new System.Drawing.Size(101, 242);
            this.ListSpecial.TabIndex = 0;
            this.ListSpecial.UseCompatibleStateImageBehavior = false;
            this.ListSpecial.ItemActivate += new EventHandler(ListSpecial_ItemActivate);

            //
            //FolderImages
            //
            //this.FolderImages.ImageStream =
            //    (System.Windows.Forms.ImageListStreamer) resources.GetObject("FolderImages.ImageStream");
            this.FolderImages.TransparentColor = System.Drawing.Color.Transparent;
            //this.FolderImages.Images.SetKeyName(0, "computer.ico");
            //this.FolderImages.Images.SetKeyName(1, "Hard_Drive.ico");
            //this.FolderImages.Images.SetKeyName(2, "folder.ico");
            //this.FolderImages.Images.SetKeyName(3, "folder_open.ico");
            //
            //FolderTree
            //
            this.FolderTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FolderTree.HideSelection = false;
            this.FolderTree.ImageIndex = 0;
            this.FolderTree.ImageList = this.FolderImages;
            this.FolderTree.Location = new System.Drawing.Point(0, 0);
            this.FolderTree.Name = "FolderTree";
            TreeNode1.Name = "MyComputer";
            TreeNode1.Text = "My Computer";
            this.FolderTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {TreeNode1});
            this.FolderTree.SelectedImageIndex = 0;
            this.FolderTree.ShowNodeToolTips = true;
            this.FolderTree.ShowRootLines = false;
            this.FolderTree.Size = new System.Drawing.Size(461, 242);
            this.FolderTree.TabIndex = 0;
            this.FolderTree.AfterExpand += new TreeViewEventHandler(FolderTree_AfterExpand);
            this.FolderTree.AfterSelect += new TreeViewEventHandler(FolderTree_AfterSelect);
            //
            //Panel2
            //
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(8, 36);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(566, 8);
            this.Panel2.TabIndex = 4;
            //
            //cboFolderPath
            //
            this.cboFolderPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFolderPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.cboFolderPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboFolderPath.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, (byte) 0);
            this.cboFolderPath.FormattingEnabled = true;
            this.cboFolderPath.Location = new System.Drawing.Point(8, 8);
            this.cboFolderPath.Name = "cboFolderPath";
            this.cboFolderPath.Size = new System.Drawing.Size(566, 28);
            this.cboFolderPath.TabIndex = 0;
            this.cboFolderPath.TextChanged += new EventHandler(cboFolderPath_TextChanged);
            //
            //FolderDialog
            //
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(582, 341);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FolderDialog";
            this.Text = "Select Folder";
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.SplitExplorer.Panel1.ResumeLayout(false);
            this.SplitExplorer.Panel2.ResumeLayout(false);
            this.SplitExplorer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Label lblMessage;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.SplitContainer SplitExplorer;
        internal System.Windows.Forms.ListView ListSpecial;
        internal System.Windows.Forms.TreeView FolderTree;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.ComboBox cboFolderPath;
        internal System.Windows.Forms.ImageList FolderImages;
        internal System.Windows.Forms.Button btnNew;
    }

}