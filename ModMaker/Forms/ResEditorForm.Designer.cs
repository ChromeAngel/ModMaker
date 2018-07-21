namespace ModMaker
{


    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class ResEditorForm : System.Windows.Forms.Form
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
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileLoadMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveAsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ScriptCPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.FileExitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AddPanelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SplitEditor = new System.Windows.Forms.SplitContainer();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.TabLayout = new System.Windows.Forms.TabPage();
            this.PanelEditSpace = new System.Windows.Forms.Panel();
            this.PanelPosition = new System.Windows.Forms.Panel();
            this.PanelResizeTall = new System.Windows.Forms.Panel();
            this.PanelResizeWidth = new System.Windows.Forms.Panel();
            this.lblPanelName = new System.Windows.Forms.Label();
            this.TabCode = new System.Windows.Forms.TabPage();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.pnlProperties = new System.Windows.Forms.Panel();
            this.SplitPanelProperties = new System.Windows.Forms.SplitContainer();
            this.lblComment = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.PanelsDropdown = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.EditorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitEditor)).BeginInit();
            this.SplitEditor.Panel1.SuspendLayout();
            this.SplitEditor.Panel2.SuspendLayout();
            this.SplitEditor.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.TabLayout.SuspendLayout();
            this.PanelEditSpace.SuspendLayout();
            this.PanelPosition.SuspendLayout();
            this.TabCode.SuspendLayout();
            this.pnlProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitPanelProperties)).BeginInit();
            this.SplitPanelProperties.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.HelpMenu,
            this.AddPanelMenu});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuStrip1.Size = new System.Drawing.Size(701, 24);
            this.MenuStrip1.TabIndex = 0;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNewMenu,
            this.FileLoadMenu,
            this.FileSaveAsMenu,
            this.FileSaveMenu,
            this.ToolStripMenuItem2,
            this.ScriptCPanelToolStripMenuItem,
            this.ToolStripMenuItem1,
            this.FileExitMenu});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "&File";
            // 
            // FileNewMenu
            // 
            this.FileNewMenu.Name = "FileNewMenu";
            this.FileNewMenu.Size = new System.Drawing.Size(160, 22);
            this.FileNewMenu.Text = "&New Resource";
            this.FileNewMenu.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // FileLoadMenu
            // 
            this.FileLoadMenu.Name = "FileLoadMenu";
            this.FileLoadMenu.Size = new System.Drawing.Size(160, 22);
            this.FileLoadMenu.Text = "&Load";
            this.FileLoadMenu.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // FileSaveAsMenu
            // 
            this.FileSaveAsMenu.Name = "FileSaveAsMenu";
            this.FileSaveAsMenu.Size = new System.Drawing.Size(160, 22);
            this.FileSaveAsMenu.Text = "Save &As";
            this.FileSaveAsMenu.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // FileSaveMenu
            // 
            this.FileSaveMenu.Name = "FileSaveMenu";
            this.FileSaveMenu.Size = new System.Drawing.Size(160, 22);
            this.FileSaveMenu.Text = "&Save";
            this.FileSaveMenu.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(157, 6);
            // 
            // ScriptCPanelToolStripMenuItem
            // 
            this.ScriptCPanelToolStripMenuItem.Name = "ScriptCPanelToolStripMenuItem";
            this.ScriptCPanelToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.ScriptCPanelToolStripMenuItem.Text = "Script &C++Panel";
            this.ScriptCPanelToolStripMenuItem.Click += new System.EventHandler(this.ScriptCPanelToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(157, 6);
            // 
            // FileExitMenu
            // 
            this.FileExitMenu.Name = "FileExitMenu";
            this.FileExitMenu.Size = new System.Drawing.Size(160, 22);
            this.FileExitMenu.Text = "E&xit";
            this.FileExitMenu.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // HelpMenu
            // 
            this.HelpMenu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(44, 20);
            this.HelpMenu.Text = "&Help";
            this.HelpMenu.Click += new System.EventHandler(this.mnuHelp_Click);
            // 
            // AddPanelMenu
            // 
            this.AddPanelMenu.Enabled = false;
            this.AddPanelMenu.Name = "AddPanelMenu";
            this.AddPanelMenu.Size = new System.Drawing.Size(82, 20);
            this.AddPanelMenu.Text = "&Add Panel...";
            this.AddPanelMenu.Click += new System.EventHandler(this.mnuAddPanel_Click);
            // 
            // SplitEditor
            // 
            this.SplitEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitEditor.Location = new System.Drawing.Point(0, 24);
            this.SplitEditor.Margin = new System.Windows.Forms.Padding(2);
            this.SplitEditor.Name = "SplitEditor";
            // 
            // SplitEditor.Panel1
            // 
            this.SplitEditor.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.SplitEditor.Panel1.Controls.Add(this.Tabs);
            // 
            // SplitEditor.Panel2
            // 
            this.SplitEditor.Panel2.Controls.Add(this.pnlProperties);
            this.SplitEditor.Panel2.Controls.Add(this.lblComment);
            this.SplitEditor.Panel2.Controls.Add(this.Panel1);
            this.SplitEditor.Size = new System.Drawing.Size(701, 403);
            this.SplitEditor.SplitterDistance = 486;
            this.SplitEditor.SplitterWidth = 3;
            this.SplitEditor.TabIndex = 1;
            this.SplitEditor.Resize += new System.EventHandler(this.SplitEditor_Resize);
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.TabLayout);
            this.Tabs.Controls.Add(this.TabCode);
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Margin = new System.Windows.Forms.Padding(2);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(486, 403);
            this.Tabs.TabIndex = 0;
            this.Tabs.SelectedIndexChanged += new System.EventHandler(this.Tabs_SelectedIndexChanged);
            // 
            // TabLayout
            // 
            this.TabLayout.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TabLayout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TabLayout.Controls.Add(this.PanelEditSpace);
            this.TabLayout.Location = new System.Drawing.Point(4, 22);
            this.TabLayout.Margin = new System.Windows.Forms.Padding(2);
            this.TabLayout.Name = "TabLayout";
            this.TabLayout.Padding = new System.Windows.Forms.Padding(2);
            this.TabLayout.Size = new System.Drawing.Size(478, 377);
            this.TabLayout.TabIndex = 0;
            this.TabLayout.Text = "Layout";
            // 
            // PanelEditSpace
            // 
            this.PanelEditSpace.AllowDrop = true;
            this.PanelEditSpace.BackColor = System.Drawing.SystemColors.Desktop;
            this.PanelEditSpace.Controls.Add(this.PanelPosition);
            this.PanelEditSpace.Location = new System.Drawing.Point(0, 16);
            this.PanelEditSpace.Margin = new System.Windows.Forms.Padding(2);
            this.PanelEditSpace.Name = "PanelEditSpace";
            this.PanelEditSpace.Size = new System.Drawing.Size(479, 348);
            this.PanelEditSpace.TabIndex = 1;
            this.PanelEditSpace.DragDrop += new System.Windows.Forms.DragEventHandler(this.PanelEditSpace_DragDrop);
            this.PanelEditSpace.DragEnter += new System.Windows.Forms.DragEventHandler(this.PanelEditSpace_DragEnter);
            this.PanelEditSpace.DragOver += new System.Windows.Forms.DragEventHandler(this.PanelEditSpace_DragOver);
            this.PanelEditSpace.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelEditSpace_MouseClick);
            this.PanelEditSpace.Resize += new System.EventHandler(this.PanelEditSpace_Resize);
            // 
            // PanelPosition
            // 
            this.PanelPosition.BackColor = System.Drawing.SystemColors.Highlight;
            this.PanelPosition.Controls.Add(this.PanelResizeTall);
            this.PanelPosition.Controls.Add(this.PanelResizeWidth);
            this.PanelPosition.Controls.Add(this.lblPanelName);
            this.PanelPosition.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.PanelPosition.Location = new System.Drawing.Point(0, 0);
            this.PanelPosition.Margin = new System.Windows.Forms.Padding(2);
            this.PanelPosition.Name = "PanelPosition";
            this.PanelPosition.Size = new System.Drawing.Size(60, 58);
            this.PanelPosition.TabIndex = 2;
            this.PanelPosition.Visible = false;
            this.PanelPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelPosition_MouseDown);
            // 
            // PanelResizeTall
            // 
            this.PanelResizeTall.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.PanelResizeTall.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelResizeTall.Location = new System.Drawing.Point(0, 52);
            this.PanelResizeTall.Margin = new System.Windows.Forms.Padding(2);
            this.PanelResizeTall.Name = "PanelResizeTall";
            this.PanelResizeTall.Size = new System.Drawing.Size(54, 6);
            this.PanelResizeTall.TabIndex = 2;
            this.PanelResizeTall.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelResizeTall_MouseDown);
            // 
            // PanelResizeWidth
            // 
            this.PanelResizeWidth.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.PanelResizeWidth.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelResizeWidth.Location = new System.Drawing.Point(54, 0);
            this.PanelResizeWidth.Margin = new System.Windows.Forms.Padding(2);
            this.PanelResizeWidth.Name = "PanelResizeWidth";
            this.PanelResizeWidth.Size = new System.Drawing.Size(6, 58);
            this.PanelResizeWidth.TabIndex = 1;
            this.PanelResizeWidth.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelResizeWidth_MouseDown);
            // 
            // lblPanelName
            // 
            this.lblPanelName.AutoSize = true;
            this.lblPanelName.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPanelName.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblPanelName.Location = new System.Drawing.Point(0, 0);
            this.lblPanelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPanelName.Name = "lblPanelName";
            this.lblPanelName.Size = new System.Drawing.Size(41, 9);
            this.lblPanelName.TabIndex = 0;
            this.lblPanelName.Text = "PanelName";
            // 
            // TabCode
            // 
            this.TabCode.Controls.Add(this.txtCode);
            this.TabCode.Location = new System.Drawing.Point(4, 22);
            this.TabCode.Margin = new System.Windows.Forms.Padding(2);
            this.TabCode.Name = "TabCode";
            this.TabCode.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabCode.Size = new System.Drawing.Size(478, 377);
            this.TabCode.TabIndex = 1;
            this.TabCode.Text = "Code";
            this.TabCode.UseVisualStyleBackColor = true;
            // 
            // txtCode
            // 
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(4, 5);
            this.txtCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCode.Size = new System.Drawing.Size(470, 367);
            this.txtCode.TabIndex = 0;
            this.txtCode.WordWrap = false;
            // 
            // pnlProperties
            // 
            this.pnlProperties.AutoScroll = true;
            this.pnlProperties.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pnlProperties.Controls.Add(this.SplitPanelProperties);
            this.pnlProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProperties.Location = new System.Drawing.Point(0, 23);
            this.pnlProperties.Margin = new System.Windows.Forms.Padding(2);
            this.pnlProperties.Name = "pnlProperties";
            this.pnlProperties.Size = new System.Drawing.Size(212, 346);
            this.pnlProperties.TabIndex = 1;
            // 
            // SplitPanelProperties
            // 
            this.SplitPanelProperties.BackColor = System.Drawing.SystemColors.Control;
            this.SplitPanelProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.SplitPanelProperties.Location = new System.Drawing.Point(0, 0);
            this.SplitPanelProperties.Margin = new System.Windows.Forms.Padding(2);
            this.SplitPanelProperties.Name = "SplitPanelProperties";
            this.SplitPanelProperties.Size = new System.Drawing.Size(212, 106);
            this.SplitPanelProperties.SplitterDistance = 101;
            this.SplitPanelProperties.SplitterWidth = 3;
            this.SplitPanelProperties.TabIndex = 0;
            // 
            // lblComment
            // 
            this.lblComment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblComment.Location = new System.Drawing.Point(0, 369);
            this.lblComment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(212, 34);
            this.lblComment.TabIndex = 2;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.PanelsDropdown);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(2);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(212, 23);
            this.Panel1.TabIndex = 0;
            // 
            // PanelsDropdown
            // 
            this.PanelsDropdown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelsDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PanelsDropdown.FormattingEnabled = true;
            this.PanelsDropdown.Location = new System.Drawing.Point(34, 0);
            this.PanelsDropdown.Margin = new System.Windows.Forms.Padding(2);
            this.PanelsDropdown.Name = "PanelsDropdown";
            this.PanelsDropdown.Size = new System.Drawing.Size(178, 21);
            this.PanelsDropdown.TabIndex = 1;
            this.PanelsDropdown.SelectedIndexChanged += new System.EventHandler(this.cboPanels_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(34, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Panel";
            // 
            // ResEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 427);
            this.Controls.Add(this.SplitEditor);
            this.Controls.Add(this.MenuStrip1);
            this.MainMenuStrip = this.MenuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ResEditorForm";
            this.Text = "VGUI Resource Editor - Mod Maker";
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.SplitEditor.Panel1.ResumeLayout(false);
            this.SplitEditor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitEditor)).EndInit();
            this.SplitEditor.ResumeLayout(false);
            this.Tabs.ResumeLayout(false);
            this.TabLayout.ResumeLayout(false);
            this.PanelEditSpace.ResumeLayout(false);
            this.PanelPosition.ResumeLayout(false);
            this.PanelPosition.PerformLayout();
            this.TabCode.ResumeLayout(false);
            this.TabCode.PerformLayout();
            this.pnlProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitPanelProperties)).EndInit();
            this.SplitPanelProperties.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem FileNewMenu;
        internal System.Windows.Forms.ToolStripMenuItem FileLoadMenu;
        internal System.Windows.Forms.ToolStripMenuItem FileSaveAsMenu;
        internal System.Windows.Forms.ToolStripMenuItem FileSaveMenu;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem FileExitMenu;
        internal System.Windows.Forms.ToolStripMenuItem HelpMenu;
        internal System.Windows.Forms.ToolStripMenuItem AddPanelMenu;
        internal System.Windows.Forms.SplitContainer SplitEditor;
        internal System.Windows.Forms.Panel pnlProperties;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.ComboBox PanelsDropdown;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.SplitContainer SplitPanelProperties;
        internal System.Windows.Forms.Label lblComment;
        internal System.Windows.Forms.ToolTip EditorToolTip;
        internal System.Windows.Forms.TabControl Tabs;
        internal System.Windows.Forms.TabPage TabLayout;
        internal System.Windows.Forms.Panel PanelEditSpace;
        internal System.Windows.Forms.Panel PanelPosition;
        internal System.Windows.Forms.TabPage TabCode;
        internal System.Windows.Forms.TextBox txtCode;
        internal System.Windows.Forms.Label lblPanelName;
        internal System.Windows.Forms.Panel PanelResizeTall;
        internal System.Windows.Forms.Panel PanelResizeWidth;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem2;
        internal System.Windows.Forms.ToolStripMenuItem ScriptCPanelToolStripMenuItem;
    }

}