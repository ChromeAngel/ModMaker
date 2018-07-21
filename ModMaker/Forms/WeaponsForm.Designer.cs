namespace ModMaker
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class WeaponsForm : System.Windows.Forms.Form
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
            LibModMaker.KeyValues keyValues9 = new LibModMaker.KeyValues();
            LibModMaker.KeyValues keyValues10 = new LibModMaker.KeyValues();
            LibModMaker.KeyValues keyValues11 = new LibModMaker.KeyValues();
            LibModMaker.KeyValues keyValues12 = new LibModMaker.KeyValues();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuScriptCpp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIce = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpOverview = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpSounds = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpGraphics = new System.Windows.Forms.ToolStripMenuItem();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ListWeapons = new System.Windows.Forms.ListView();
            this.WeaponEditor = new ModMaker.WeaponControl();
            this.MenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.mnuRefresh,
            this.mnuHelp});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuStrip1.Size = new System.Drawing.Size(698, 24);
            this.MenuStrip1.TabIndex = 0;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.ToolStripMenuItem2,
            this.mnuScriptCpp,
            this.mnuIce,
            this.ToolStripMenuItem1,
            this.mnuExit});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "&File";
            // 
            // mnuNew
            // 
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(176, 22);
            this.mnuNew.Text = "&New";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(173, 6);
            // 
            // mnuScriptCpp
            // 
            this.mnuScriptCpp.Name = "mnuScriptCpp";
            this.mnuScriptCpp.Size = new System.Drawing.Size(176, 22);
            this.mnuScriptCpp.Text = "&Generate C++";
            this.mnuScriptCpp.Click += new System.EventHandler(this.mnuScriptCpp_Click);
            // 
            // mnuIce
            // 
            this.mnuIce.Enabled = false;
            this.mnuIce.Name = "mnuIce";
            this.mnuIce.Size = new System.Drawing.Size(176, 22);
            this.mnuIce.Text = "&ICE Weapon Scripts";
            this.mnuIce.Visible = false;
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(173, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(176, 22);
            this.mnuExit.Text = "&Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(58, 20);
            this.mnuRefresh.Text = "&Refresh";
            this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpOverview,
            this.mnuHelpSounds,
            this.mnuHelpGraphics});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuHelpOverview
            // 
            this.mnuHelpOverview.Name = "mnuHelpOverview";
            this.mnuHelpOverview.Size = new System.Drawing.Size(152, 22);
            this.mnuHelpOverview.Text = "Overview";
            this.mnuHelpOverview.Click += new System.EventHandler(this.mnuHelpOverview_Click);
            // 
            // mnuHelpSounds
            // 
            this.mnuHelpSounds.Name = "mnuHelpSounds";
            this.mnuHelpSounds.Size = new System.Drawing.Size(152, 22);
            this.mnuHelpSounds.Text = "Sounds";
            this.mnuHelpSounds.Click += new System.EventHandler(this.mnuHelpSounds_Click);
            // 
            // mnuHelpGraphics
            // 
            this.mnuHelpGraphics.Name = "mnuHelpGraphics";
            this.mnuHelpGraphics.Size = new System.Drawing.Size(152, 22);
            this.mnuHelpGraphics.Text = "HUD Graphics";
            this.mnuHelpGraphics.Click += new System.EventHandler(this.mnuHelpGraphics_Click);
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 24);
            this.SplitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.ListWeapons);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.WeaponEditor);
            this.SplitContainer1.Size = new System.Drawing.Size(698, 494);
            this.SplitContainer1.SplitterDistance = 174;
            this.SplitContainer1.SplitterWidth = 3;
            this.SplitContainer1.TabIndex = 1;
            // 
            // ListWeapons
            // 
            this.ListWeapons.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListWeapons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListWeapons.HideSelection = false;
            this.ListWeapons.Location = new System.Drawing.Point(0, 0);
            this.ListWeapons.Margin = new System.Windows.Forms.Padding(2);
            this.ListWeapons.MultiSelect = false;
            this.ListWeapons.Name = "ListWeapons";
            this.ListWeapons.Size = new System.Drawing.Size(174, 494);
            this.ListWeapons.TabIndex = 0;
            this.ListWeapons.UseCompatibleStateImageBehavior = false;
            this.ListWeapons.View = System.Windows.Forms.View.List;
            this.ListWeapons.ItemActivate += new System.EventHandler(this.ListWeapons_ItemActivate);
            // 
            // WeaponEditor
            // 
            this.WeaponEditor.DeathTexureData = keyValues9;
            this.WeaponEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WeaponEditor.Game = null;
            this.WeaponEditor.Item_Flags = ((uint)(0u));
            this.WeaponEditor.Location = new System.Drawing.Point(0, 0);
            this.WeaponEditor.Name = "WeaponEditor";
            this.WeaponEditor.Size = new System.Drawing.Size(521, 494);
            this.WeaponEditor.SoundData = keyValues10;
            this.WeaponEditor.TabIndex = 0;
            this.WeaponEditor.TextureData = keyValues11;
            this.WeaponEditor.Value = keyValues12;
            this.WeaponEditor.WeaponName = "";
            // 
            // WeaponsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 518);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.MenuStrip1);
            this.MainMenuStrip = this.MenuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WeaponsForm";
            this.Text = "Weapons";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWeapons_FormClosing);
            this.Load += new System.EventHandler(this.frmWeapons_Load);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mnuNew;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem2;
        internal System.Windows.Forms.ToolStripMenuItem mnuScriptCpp;
        internal System.Windows.Forms.ToolStripMenuItem mnuIce;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem mnuExit;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.ListView ListWeapons;
        internal ModMaker.WeaponControl WeaponEditor;
        internal System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        internal System.Windows.Forms.ToolStripMenuItem mnuHelp;
        internal System.Windows.Forms.ToolStripMenuItem mnuHelpOverview;
        internal System.Windows.Forms.ToolStripMenuItem mnuHelpSounds;
        internal System.Windows.Forms.ToolStripMenuItem mnuHelpGraphics;
    }

}