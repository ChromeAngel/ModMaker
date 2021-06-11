namespace ModMaker
{


    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class MainForm : System.Windows.Forms.Form
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
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            LibModMaker.KeyValues keyValues1 = new LibModMaker.KeyValues();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.ToolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.ValveDeveloperCommunityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QCCommandsVDCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SourceSDKDiscussionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SourceModdingcomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SteampoweredcomForumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InterlopersnetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.SteamInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.ModIcons = new System.Windows.Forms.ImageList(this.components);
            this.ExplorerSplit = new System.Windows.Forms.SplitContainer();
            this.ModList = new System.Windows.Forms.ListView();
            this.ModView1 = new ModMaker.ModView();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExplorerSplit)).BeginInit();
            this.ExplorerSplit.Panel1.SuspendLayout();
            this.ExplorerSplit.Panel2.SuspendLayout();
            this.ExplorerSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripDropDownButton1,
            this.btnRefresh,
            this.ToolStripDropDownButton2,
            this.ToolStripButton1});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(868, 27);
            this.ToolStrip1.TabIndex = 0;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripDropDownButton1
            // 
            this.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileNew,
            this.ToolStripMenuItem3,
            this.OptionsToolStripMenuItem,
            this.ToolStripMenuItem1,
            this.mnuExit});
            this.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1";
            this.ToolStripDropDownButton1.Size = new System.Drawing.Size(46, 24);
            this.ToolStripDropDownButton1.Text = "&File";
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Name = "mnuFileNew";
            this.mnuFileNew.Size = new System.Drawing.Size(144, 26);
            this.mnuFileNew.Text = "&New";
            // 
            // ToolStripMenuItem3
            // 
            this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            this.ToolStripMenuItem3.Size = new System.Drawing.Size(141, 6);
            // 
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.OptionsToolStripMenuItem.Text = "&Options";
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(141, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(144, 26);
            this.mnuExit.Text = "E&xit";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(62, 24);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.ToolTipText = "Refresh Source Mods";
            // 
            // ToolStripDropDownButton2
            // 
            this.ToolStripDropDownButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ValveDeveloperCommunityToolStripMenuItem,
            this.QCCommandsVDCToolStripMenuItem,
            this.SourceSDKDiscussionToolStripMenuItem,
            this.SourceModdingcomToolStripMenuItem,
            this.SteampoweredcomForumToolStripMenuItem,
            this.InterlopersnetToolStripMenuItem,
            this.ToolStripMenuItem2,
            this.SteamInfoToolStripMenuItem,
            this.ToolStripMenuItem4,
            this.AboutToolStripMenuItem});
            this.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2";
            this.ToolStripDropDownButton2.ShowDropDownArrow = false;
            this.ToolStripDropDownButton2.Size = new System.Drawing.Size(45, 24);
            this.ToolStripDropDownButton2.Text = "Help";
            // 
            // ValveDeveloperCommunityToolStripMenuItem
            // 
            this.ValveDeveloperCommunityToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValveDeveloperCommunityToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.ValveDeveloperCommunityToolStripMenuItem.Name = "ValveDeveloperCommunityToolStripMenuItem";
            this.ValveDeveloperCommunityToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.ValveDeveloperCommunityToolStripMenuItem.Text = "Valve Developer Community";
            // 
            // QCCommandsVDCToolStripMenuItem
            // 
            this.QCCommandsVDCToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.QCCommandsVDCToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.QCCommandsVDCToolStripMenuItem.Name = "QCCommandsVDCToolStripMenuItem";
            this.QCCommandsVDCToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.QCCommandsVDCToolStripMenuItem.Text = "QC Commands (VDC)";
            // 
            // SourceSDKDiscussionToolStripMenuItem
            // 
            this.SourceSDKDiscussionToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.SourceSDKDiscussionToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.SourceSDKDiscussionToolStripMenuItem.Name = "SourceSDKDiscussionToolStripMenuItem";
            this.SourceSDKDiscussionToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.SourceSDKDiscussionToolStripMenuItem.Text = "Source SDK Discussion";
            // 
            // SourceModdingcomToolStripMenuItem
            // 
            this.SourceModdingcomToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SourceModdingcomToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.SourceModdingcomToolStripMenuItem.Name = "SourceModdingcomToolStripMenuItem";
            this.SourceModdingcomToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.SourceModdingcomToolStripMenuItem.Text = "SourceModding.com";
            // 
            // SteampoweredcomForumToolStripMenuItem
            // 
            this.SteampoweredcomForumToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SteampoweredcomForumToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.SteampoweredcomForumToolStripMenuItem.Name = "SteampoweredcomForumToolStripMenuItem";
            this.SteampoweredcomForumToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.SteampoweredcomForumToolStripMenuItem.Text = "Steampowered.com Forum";
            // 
            // InterlopersnetToolStripMenuItem
            // 
            this.InterlopersnetToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InterlopersnetToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.InterlopersnetToolStripMenuItem.Name = "InterlopersnetToolStripMenuItem";
            this.InterlopersnetToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.InterlopersnetToolStripMenuItem.Text = "Interlopers.net";
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(262, 6);
            // 
            // SteamInfoToolStripMenuItem
            // 
            this.SteamInfoToolStripMenuItem.Name = "SteamInfoToolStripMenuItem";
            this.SteamInfoToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.SteamInfoToolStripMenuItem.Text = "Steam Info";
            // 
            // ToolStripMenuItem4
            // 
            this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            this.ToolStripMenuItem4.Size = new System.Drawing.Size(262, 6);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.AboutToolStripMenuItem.Text = "About";
            // 
            // ToolStripButton1
            // 
            this.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton1.Name = "ToolStripButton1";
            this.ToolStripButton1.Size = new System.Drawing.Size(40, 24);
            this.ToolStripButton1.Text = "Test";
            this.ToolStripButton1.Visible = false;
            //this.ToolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click_1);
            // 
            // ModIcons
            // 
            this.ModIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ModIcons.ImageSize = new System.Drawing.Size(32, 32);
            this.ModIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ExplorerSplit
            // 
            this.ExplorerSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExplorerSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ExplorerSplit.Location = new System.Drawing.Point(0, 27);
            this.ExplorerSplit.Margin = new System.Windows.Forms.Padding(4);
            this.ExplorerSplit.Name = "ExplorerSplit";
            this.ExplorerSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ExplorerSplit.Panel1
            // 
            this.ExplorerSplit.Panel1.Controls.Add(this.ModList);
            // 
            // ExplorerSplit.Panel2
            // 
            this.ExplorerSplit.Panel2.Controls.Add(this.ModView1);
            this.ExplorerSplit.Size = new System.Drawing.Size(868, 462);
            this.ExplorerSplit.SplitterDistance = 48;
            this.ExplorerSplit.SplitterWidth = 5;
            this.ExplorerSplit.TabIndex = 3;
            // 
            // ModList
            // 
            this.ModList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ModList.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ModList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ModList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModList.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ModList.HideSelection = false;
            this.ModList.LabelWrap = false;
            this.ModList.LargeImageList = this.ModIcons;
            this.ModList.Location = new System.Drawing.Point(0, 0);
            this.ModList.Margin = new System.Windows.Forms.Padding(4);
            this.ModList.MultiSelect = false;
            this.ModList.Name = "ModList";
            this.ModList.ShowGroups = false;
            this.ModList.ShowItemToolTips = true;
            this.ModList.Size = new System.Drawing.Size(868, 48);
            this.ModList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ModList.TabIndex = 3;
            this.ModList.TileSize = new System.Drawing.Size(200, 40);
            this.ModList.UseCompatibleStateImageBehavior = false;
            this.ModList.View = System.Windows.Forms.View.Tile;
            // 
            // ModView1
            // 
            this.ModView1.AllowDrop = true;
            this.ModView1.BackColor = System.Drawing.SystemColors.Control;
            this.ModView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModView1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ModView1.Location = new System.Drawing.Point(0, 0);
            this.ModView1.Margin = new System.Windows.Forms.Padding(5);
            this.ModView1.Name = "ModView1";
            this.ModView1.Options = keyValues1;
            this.ModView1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.ModView1.Size = new System.Drawing.Size(868, 409);
            this.ModView1.TabIndex = 0;
            this.ModView1.Value = null;
            this.ModView1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(868, 489);
            this.Controls.Add(this.ExplorerSplit);
            this.Controls.Add(this.ToolStrip1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Mod Maker";
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ExplorerSplit.Panel1.ResumeLayout(false);
            this.ExplorerSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExplorerSplit)).EndInit();
            this.ExplorerSplit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ImageList ModIcons;
        internal System.Windows.Forms.ToolStripDropDownButton ToolStripDropDownButton1;
        internal System.Windows.Forms.ToolStripMenuItem OptionsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem mnuExit;
        internal System.Windows.Forms.ToolStripButton btnRefresh;
        internal System.Windows.Forms.ToolStripDropDownButton ToolStripDropDownButton2;
        internal System.Windows.Forms.ToolStripMenuItem ValveDeveloperCommunityToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem SteampoweredcomForumToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem InterlopersnetToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem2;
        internal System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        internal System.Windows.Forms.ToolStripButton ToolStripButton1;
        internal System.Windows.Forms.SplitContainer ExplorerSplit;
        internal System.Windows.Forms.ListView ModList;
        internal ModMaker.ModView ModView1;
        internal System.Windows.Forms.ToolStripMenuItem SourceSDKDiscussionToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem QCCommandsVDCToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mnuFileNew;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem3;
        internal System.Windows.Forms.ToolStripMenuItem SteamInfoToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem4;

        internal System.Windows.Forms.ToolStripMenuItem SourceModdingcomToolStripMenuItem;

    }
}