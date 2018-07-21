using System.Windows.Forms;

namespace ModMaker
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class frmParticleTool : System.Windows.Forms.Form
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
     //   [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Particles");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParticleTool));
            this.SourceFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ColorPicker = new System.Windows.Forms.ColorDialog();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManifest = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFind = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLaunch = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExplorerSplit = new System.Windows.Forms.SplitContainer();
            this.PartTree = new System.Windows.Forms.TreeView();
            this.ChildList = new System.Windows.Forms.ListView();
            this.pnlTask = new System.Windows.Forms.Panel();
            this.chkTransformChildren = new System.Windows.Forms.CheckBox();
            this.udColour = new System.Windows.Forms.NumericUpDown();
            this.udSize = new System.Windows.Forms.NumericUpDown();
            this.udSpeed = new System.Windows.Forms.NumericUpDown();
            this.picColour = new System.Windows.Forms.PictureBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblSystemName = new System.Windows.Forms.Label();
            this.MenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExplorerSplit)).BeginInit();
            this.ExplorerSplit.Panel1.SuspendLayout();
            this.ExplorerSplit.Panel2.SuspendLayout();
            this.ExplorerSplit.SuspendLayout();
            this.pnlTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picColour)).BeginInit();
            this.SuspendLayout();
            // 
            // SourceFileDialog
            // 
            this.SourceFileDialog.DefaultExt = "pcf";
            this.SourceFileDialog.FileName = "particle.pcf";
            this.SourceFileDialog.Filter = "Particle Systems(*.pcf)|*.pcf";
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.MenuLaunch,
            this.HelpToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(788, 28);
            this.MenuStrip1.TabIndex = 1;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileNew,
            this.ToolStripMenuItem1,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.FileToolStripMenuItem.Text = "&File";
            // 
            // MenuFileNew
            // 
            this.MenuFileNew.Name = "MenuFileNew";
            this.MenuFileNew.Size = new System.Drawing.Size(114, 26);
            this.MenuFileNew.Text = "&New";
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(111, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.ExitToolStripMenuItem.Text = "E&xit";
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCopy,
            this.MenuPaste,
            this.MenuDelete,
            this.mnuManifest,
            this.MenuFind});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.EditToolStripMenuItem.Text = "&Edit";
            // 
            // MenuCopy
            // 
            this.MenuCopy.Name = "MenuCopy";
            this.MenuCopy.Size = new System.Drawing.Size(209, 26);
            this.MenuCopy.Text = "&Copy";
            // 
            // MenuPaste
            // 
            this.MenuPaste.Name = "MenuPaste";
            this.MenuPaste.Size = new System.Drawing.Size(209, 26);
            this.MenuPaste.Text = "&Paste";
            // 
            // MenuDelete
            // 
            this.MenuDelete.Name = "MenuDelete";
            this.MenuDelete.Size = new System.Drawing.Size(209, 26);
            this.MenuDelete.Text = "&Delete";
            // 
            // mnuManifest
            // 
            this.mnuManifest.Name = "mnuManifest";
            this.mnuManifest.Size = new System.Drawing.Size(209, 26);
            this.mnuManifest.Text = "Include in &Manifest";
            // 
            // MenuFind
            // 
            this.MenuFind.Name = "MenuFind";
            this.MenuFind.Size = new System.Drawing.Size(209, 26);
            this.MenuFind.Text = "&Find";
            // 
            // MenuLaunch
            // 
            this.MenuLaunch.Name = "MenuLaunch";
            this.MenuLaunch.Size = new System.Drawing.Size(150, 24);
            this.MenuLaunch.Text = "Launch Tools Mode";
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.HelpToolStripMenuItem.Text = "&Help";
            // 
            // ExplorerSplit
            // 
            this.ExplorerSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExplorerSplit.Location = new System.Drawing.Point(0, 28);
            this.ExplorerSplit.Name = "ExplorerSplit";
            // 
            // ExplorerSplit.Panel1
            // 
            this.ExplorerSplit.Panel1.Controls.Add(this.PartTree);
            // 
            // ExplorerSplit.Panel2
            // 
            this.ExplorerSplit.Panel2.Controls.Add(this.ChildList);
            this.ExplorerSplit.Panel2.Controls.Add(this.pnlTask);
            this.ExplorerSplit.Panel2.Controls.Add(this.lblSystemName);
            this.ExplorerSplit.Size = new System.Drawing.Size(788, 572);
            this.ExplorerSplit.SplitterDistance = 333;
            this.ExplorerSplit.TabIndex = 0;
            // 
            // PartTree
            // 
            this.PartTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PartTree.Location = new System.Drawing.Point(0, 0);
            this.PartTree.Name = "PartTree";
            treeNode1.Name = "ParticlesFolder";
            treeNode1.Text = "Particles";
            this.PartTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.PartTree.ShowNodeToolTips = true;
            this.PartTree.Size = new System.Drawing.Size(333, 572);
            this.PartTree.TabIndex = 0;
            // 
            // ChildList
            // 
            this.ChildList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChildList.Location = new System.Drawing.Point(0, 30);
            this.ChildList.Name = "ChildList";
            this.ChildList.Size = new System.Drawing.Size(451, 307);
            this.ChildList.TabIndex = 0;
            this.ChildList.UseCompatibleStateImageBehavior = false;
            this.ChildList.View = System.Windows.Forms.View.List;
            // 
            // pnlTask
            // 
            this.pnlTask.Controls.Add(this.chkTransformChildren);
            this.pnlTask.Controls.Add(this.udColour);
            this.pnlTask.Controls.Add(this.udSize);
            this.pnlTask.Controls.Add(this.udSpeed);
            this.pnlTask.Controls.Add(this.picColour);
            this.pnlTask.Controls.Add(this.Label5);
            this.pnlTask.Controls.Add(this.Label4);
            this.pnlTask.Controls.Add(this.Label3);
            this.pnlTask.Controls.Add(this.txtTarget);
            this.pnlTask.Controls.Add(this.Label2);
            this.pnlTask.Controls.Add(this.btnGo);
            this.pnlTask.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTask.Location = new System.Drawing.Point(0, 337);
            this.pnlTask.Name = "pnlTask";
            this.pnlTask.Size = new System.Drawing.Size(451, 235);
            this.pnlTask.TabIndex = 1;
            // 
            // chkTransformChildren
            // 
            this.chkTransformChildren.AutoSize = true;
            this.chkTransformChildren.Location = new System.Drawing.Point(136, 129);
            this.chkTransformChildren.Name = "chkTransformChildren";
            this.chkTransformChildren.Size = new System.Drawing.Size(187, 21);
            this.chkTransformChildren.TabIndex = 5;
            this.chkTransformChildren.Text = "Transform Child Systems";
            this.chkTransformChildren.UseVisualStyleBackColor = true;
            // 
            // udColour
            // 
            this.udColour.Location = new System.Drawing.Point(188, 84);
            this.udColour.Name = "udColour";
            this.udColour.Size = new System.Drawing.Size(68, 22);
            this.udColour.TabIndex = 4;
            // 
            // udSize
            // 
            this.udSize.Location = new System.Drawing.Point(136, 37);
            this.udSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udSize.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.udSize.Name = "udSize";
            this.udSize.Size = new System.Drawing.Size(120, 22);
            this.udSize.TabIndex = 1;
            // 
            // udSpeed
            // 
            this.udSpeed.Location = new System.Drawing.Point(136, 7);
            this.udSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udSpeed.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.udSpeed.Name = "udSpeed";
            this.udSpeed.Size = new System.Drawing.Size(120, 22);
            this.udSpeed.TabIndex = 0;
            // 
            // picColour
            // 
            this.picColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picColour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picColour.Location = new System.Drawing.Point(136, 75);
            this.picColour.Name = "picColour";
            this.picColour.Size = new System.Drawing.Size(38, 37);
            this.picColour.TabIndex = 39;
            this.picColour.TabStop = false;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(81, 84);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(49, 17);
            this.Label5.TabIndex = 3;
            this.Label5.Text = "Colour";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(18, 42);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(112, 17);
            this.Label4.TabIndex = 37;
            this.Label4.Text = "Size (% change)";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(4, 9);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(126, 17);
            this.Label3.TabIndex = 36;
            this.Label3.Text = "Speed (% change)";
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(136, 156);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(249, 22);
            this.txtTarget.TabIndex = 6;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(70, 156);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(60, 17);
            this.Label2.TabIndex = 18;
            this.Label2.Text = "Copy As";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(343, 193);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(96, 30);
            this.btnGo.TabIndex = 7;
            this.btnGo.Text = "&Transform";
            this.btnGo.UseVisualStyleBackColor = true;
            // 
            // lblSystemName
            // 
            this.lblSystemName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSystemName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemName.Location = new System.Drawing.Point(0, 0);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(451, 30);
            this.lblSystemName.TabIndex = 28;
            this.lblSystemName.Text = "Particle Systems";
            // 
            // frmParticleTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 600);
            this.Controls.Add(this.ExplorerSplit);
            this.Controls.Add(this.MenuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip1;
            this.Name = "frmParticleTool";
            this.Text = "Mod Maker - Particle Tool";
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ExplorerSplit.Panel1.ResumeLayout(false);
            this.ExplorerSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExplorerSplit)).EndInit();
            this.ExplorerSplit.ResumeLayout(false);
            this.pnlTask.ResumeLayout(false);
            this.pnlTask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picColour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal OpenFileDialog SourceFileDialog;
        internal ColorDialog ColorPicker;
        internal MenuStrip MenuStrip1;
        internal ToolStripMenuItem FileToolStripMenuItem;
        internal ToolStripMenuItem MenuFileNew;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripMenuItem ExitToolStripMenuItem;
        internal ToolStripMenuItem EditToolStripMenuItem;
        internal ToolStripMenuItem MenuCopy;
        internal ToolStripMenuItem MenuPaste;
        internal ToolStripMenuItem MenuDelete;
        internal ToolStripMenuItem HelpToolStripMenuItem;
        internal ToolStripMenuItem MenuLaunch;
        internal SplitContainer ExplorerSplit;
        internal TreeView PartTree;
        internal Label lblSystemName;
        internal Panel pnlTask;
        internal CheckBox chkTransformChildren;
        internal NumericUpDown udColour;
        internal NumericUpDown udSize;
        internal NumericUpDown udSpeed;
        internal PictureBox picColour;
        internal Label Label5;
        internal Label Label4;
        internal Label Label3;
        internal TextBox txtTarget;
        internal Label Label2;
        internal Button btnGo;
        internal ListView ChildList;
        internal ToolStripMenuItem mnuManifest;
        internal ToolStripMenuItem MenuFind;
    }

}