namespace ModMaker
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class ModView : System.Windows.Forms.UserControl
    {

        //UserControl overrides dispose to clean up the component list.
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Folders", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Tools", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Shortcuts", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModView));
            this.lblName = new System.Windows.Forms.Label();
            this.lnkMod = new System.Windows.Forms.LinkLabel();
            this.CompileFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlMapArg = new System.Windows.Forms.Panel();
            this.cboMap = new System.Windows.Forms.ComboBox();
            this.chkMap = new System.Windows.Forms.CheckBox();
            this.chkNoIntro = new System.Windows.Forms.CheckBox();
            this.chkWindowed = new System.Windows.Forms.CheckBox();
            this.chkAllowDebug = new System.Windows.Forms.CheckBox();
            this.btnAdvanced = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.MapWatcher = new System.IO.FileSystemWatcher();
            this.HelperList = new System.Windows.Forms.ListView();
            this.HelperIcons = new System.Windows.Forms.ImageList(this.components);
            this.ToolTipManager = new System.Windows.Forms.ToolTip(this.components);
            this.Panel1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.FlowLayoutPanel1.SuspendLayout();
            this.pnlMapArg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblName.Location = new System.Drawing.Point(5, 0);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblName.Size = new System.Drawing.Size(771, 43);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "ModName";
            this.ToolTipManager.SetToolTip(this.lblName, "Click to edit Game Information");
            // 
            // lnkMod
            // 
            this.lnkMod.BackColor = System.Drawing.Color.Transparent;
            this.lnkMod.Dock = System.Windows.Forms.DockStyle.Top;
            this.lnkMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkMod.Location = new System.Drawing.Point(5, 43);
            this.lnkMod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkMod.Name = "lnkMod";
            this.lnkMod.Size = new System.Drawing.Size(771, 18);
            this.lnkMod.TabIndex = 2;
            this.lnkMod.TabStop = true;
            this.lnkMod.Text = "Visit Developer Homepage";
            this.lnkMod.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.GroupBox1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(5, 61);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.Panel1.Size = new System.Drawing.Size(771, 97);
            this.Panel1.TabIndex = 18;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.FlowLayoutPanel1);
            this.GroupBox1.Controls.Add(this.btnPlay);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(8, 4, 4, 6);
            this.GroupBox1.Size = new System.Drawing.Size(771, 92);
            this.GroupBox1.TabIndex = 26;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Play";
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.Controls.Add(this.pnlMapArg);
            this.FlowLayoutPanel1.Controls.Add(this.chkNoIntro);
            this.FlowLayoutPanel1.Controls.Add(this.chkWindowed);
            this.FlowLayoutPanel1.Controls.Add(this.chkAllowDebug);
            this.FlowLayoutPanel1.Controls.Add(this.btnAdvanced);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(101, 19);
            this.FlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(666, 67);
            this.FlowLayoutPanel1.TabIndex = 33;
            // 
            // pnlMapArg
            // 
            this.pnlMapArg.Controls.Add(this.cboMap);
            this.pnlMapArg.Controls.Add(this.chkMap);
            this.pnlMapArg.Location = new System.Drawing.Point(4, 4);
            this.pnlMapArg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMapArg.Name = "pnlMapArg";
            this.pnlMapArg.Size = new System.Drawing.Size(293, 27);
            this.pnlMapArg.TabIndex = 35;
            // 
            // cboMap
            // 
            this.cboMap.Enabled = false;
            this.cboMap.FormattingEnabled = true;
            this.cboMap.Location = new System.Drawing.Point(64, 1);
            this.cboMap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboMap.Name = "cboMap";
            this.cboMap.Size = new System.Drawing.Size(220, 24);
            this.cboMap.TabIndex = 34;
            // 
            // chkMap
            // 
            this.chkMap.AutoSize = true;
            this.chkMap.Location = new System.Drawing.Point(0, 4);
            this.chkMap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkMap.Name = "chkMap";
            this.chkMap.Size = new System.Drawing.Size(57, 21);
            this.chkMap.TabIndex = 33;
            this.chkMap.Text = "Map";
            this.chkMap.UseVisualStyleBackColor = true;
            // 
            // chkNoIntro
            // 
            this.chkNoIntro.Location = new System.Drawing.Point(305, 4);
            this.chkNoIntro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkNoIntro.Name = "chkNoIntro";
            this.chkNoIntro.Size = new System.Drawing.Size(99, 27);
            this.chkNoIntro.TabIndex = 37;
            this.chkNoIntro.Text = "Skip Intro";
            this.chkNoIntro.UseVisualStyleBackColor = true;
            // 
            // chkWindowed
            // 
            this.chkWindowed.Location = new System.Drawing.Point(412, 4);
            this.chkWindowed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkWindowed.Name = "chkWindowed";
            this.chkWindowed.Size = new System.Drawing.Size(103, 27);
            this.chkWindowed.TabIndex = 36;
            this.chkWindowed.Text = "Windowed";
            this.chkWindowed.UseVisualStyleBackColor = true;
            // 
            // chkAllowDebug
            // 
            this.chkAllowDebug.Location = new System.Drawing.Point(4, 39);
            this.chkAllowDebug.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkAllowDebug.Name = "chkAllowDebug";
            this.chkAllowDebug.Size = new System.Drawing.Size(156, 27);
            this.chkAllowDebug.TabIndex = 29;
            this.chkAllowDebug.Text = "Allow Debug Builds";
            this.chkAllowDebug.UseVisualStyleBackColor = true;
            // 
            // btnAdvanced
            // 
            this.btnAdvanced.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdvanced.Location = new System.Drawing.Point(168, 39);
            this.btnAdvanced.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdvanced.Name = "btnAdvanced";
            this.btnAdvanced.Size = new System.Drawing.Size(100, 28);
            this.btnAdvanced.TabIndex = 39;
            this.btnAdvanced.Text = "Advanced...";
            this.btnAdvanced.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPlay.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlay.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Image = global::ModMaker.Properties.Resources.FormRunHS;
            this.btnPlay.Location = new System.Drawing.Point(8, 19);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(93, 67);
            this.btnPlay.TabIndex = 26;
            this.btnPlay.Text = "PLAY";
            this.btnPlay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPlay.UseVisualStyleBackColor = true;
            // 
            // MapWatcher
            // 
            this.MapWatcher.EnableRaisingEvents = true;
            this.MapWatcher.Filter = "*.bsp";
            this.MapWatcher.NotifyFilter = System.IO.NotifyFilters.FileName;
            this.MapWatcher.SynchronizingObject = this;
            // 
            // HelperList
            // 
            this.HelperList.AllowDrop = true;
            this.HelperList.BackColor = System.Drawing.SystemColors.Window;
            this.HelperList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HelperList.ForeColor = System.Drawing.SystemColors.WindowText;
            listViewGroup1.Header = "Folders";
            listViewGroup1.Name = "FolderGroup";
            listViewGroup2.Header = "Tools";
            listViewGroup2.Name = "ToolGroup";
            listViewGroup3.Header = "Shortcuts";
            listViewGroup3.Name = "ShortcutGroup";
            this.HelperList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.HelperList.LargeImageList = this.HelperIcons;
            this.HelperList.Location = new System.Drawing.Point(5, 158);
            this.HelperList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HelperList.MultiSelect = false;
            this.HelperList.Name = "HelperList";
            this.HelperList.ShowItemToolTips = true;
            this.HelperList.Size = new System.Drawing.Size(771, 289);
            this.HelperList.TabIndex = 19;
            this.HelperList.UseCompatibleStateImageBehavior = false;
            // 
            // HelperIcons
            // 
            this.HelperIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("HelperIcons.ImageStream")));
            this.HelperIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.HelperIcons.Images.SetKeyName(0, "Folder_32x32.png");
            this.HelperIcons.Images.SetKeyName(1, "Shortcut.png");
            // 
            // ModView
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.HelperList);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.lnkMod);
            this.Controls.Add(this.lblName);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ModView";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.Size = new System.Drawing.Size(781, 452);
            this.Panel1.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.pnlMapArg.ResumeLayout(false);
            this.pnlMapArg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapWatcher)).EndInit();
            this.ResumeLayout(false);

        }

        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.LinkLabel lnkMod;
        internal System.Windows.Forms.OpenFileDialog CompileFileDialog;
        internal System.Windows.Forms.Panel Panel1;
        internal System.IO.FileSystemWatcher MapWatcher;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnPlay;
        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        internal System.Windows.Forms.CheckBox chkAllowDebug;
        internal System.Windows.Forms.Panel pnlMapArg;
        internal System.Windows.Forms.ComboBox cboMap;
        internal System.Windows.Forms.CheckBox chkMap;
        internal System.Windows.Forms.CheckBox chkWindowed;
        internal System.Windows.Forms.ListView HelperList;
        internal System.Windows.Forms.ImageList HelperIcons;
        internal System.Windows.Forms.CheckBox chkNoIntro;
        internal System.Windows.Forms.Button btnAdvanced;

        internal System.Windows.Forms.ToolTip ToolTipManager;
    }

}