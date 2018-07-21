namespace ModMaker
{


    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class LocalForm : System.Windows.Forms.Form
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
            this.SplitTokens = new System.Windows.Forms.SplitContainer();
            this.ListTokens = new System.Windows.Forms.ListBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SplitTranslation = new System.Windows.Forms.SplitContainer();
            this.txtEnglish = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtTranslation = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTokens = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewTaken = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteToken = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboLangugae = new System.Windows.Forms.ToolStripComboBox();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolTipManager = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SplitTokens)).BeginInit();
            this.SplitTokens.Panel1.SuspendLayout();
            this.SplitTokens.Panel2.SuspendLayout();
            this.SplitTokens.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitTranslation)).BeginInit();
            this.SplitTranslation.Panel1.SuspendLayout();
            this.SplitTranslation.Panel2.SuspendLayout();
            this.SplitTranslation.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitTokens
            // 
            this.SplitTokens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitTokens.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitTokens.Location = new System.Drawing.Point(0, 32);
            this.SplitTokens.Name = "SplitTokens";
            // 
            // SplitTokens.Panel1
            // 
            this.SplitTokens.Panel1.Controls.Add(this.ListTokens);
            this.SplitTokens.Panel1.Controls.Add(this.Panel1);
            // 
            // SplitTokens.Panel2
            // 
            this.SplitTokens.Panel2.Controls.Add(this.SplitTranslation);
            this.SplitTokens.Size = new System.Drawing.Size(695, 418);
            this.SplitTokens.SplitterDistance = 200;
            this.SplitTokens.TabIndex = 1;
            // 
            // ListTokens
            // 
            this.ListTokens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListTokens.FormattingEnabled = true;
            this.ListTokens.IntegralHeight = false;
            this.ListTokens.ItemHeight = 16;
            this.ListTokens.Location = new System.Drawing.Point(0, 22);
            this.ListTokens.Name = "ListTokens";
            this.ListTokens.Size = new System.Drawing.Size(200, 396);
            this.ListTokens.TabIndex = 0;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.txtFilter);
            this.Panel1.Controls.Add(this.btnAdd);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(200, 22);
            this.Panel1.TabIndex = 1;
            // 
            // txtFilter
            // 
            this.txtFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilter.Location = new System.Drawing.Point(0, 0);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(175, 22);
            this.txtFilter.TabIndex = 1;
            this.ToolTipManager.SetToolTip(this.txtFilter, "New token");
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAdd.Location = new System.Drawing.Point(175, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 22);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "+";
            this.ToolTipManager.SetToolTip(this.btnAdd, "Add new token");
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // SplitTranslation
            // 
            this.SplitTranslation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitTranslation.Location = new System.Drawing.Point(0, 0);
            this.SplitTranslation.Name = "SplitTranslation";
            this.SplitTranslation.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitTranslation.Panel1
            // 
            this.SplitTranslation.Panel1.Controls.Add(this.txtEnglish);
            this.SplitTranslation.Panel1.Controls.Add(this.Label1);
            // 
            // SplitTranslation.Panel2
            // 
            this.SplitTranslation.Panel2.Controls.Add(this.txtTranslation);
            this.SplitTranslation.Panel2.Controls.Add(this.Label2);
            this.SplitTranslation.Size = new System.Drawing.Size(491, 418);
            this.SplitTranslation.SplitterDistance = 208;
            this.SplitTranslation.TabIndex = 0;
            // 
            // txtEnglish
            // 
            this.txtEnglish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEnglish.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnglish.Location = new System.Drawing.Point(0, 17);
            this.txtEnglish.Multiline = true;
            this.txtEnglish.Name = "txtEnglish";
            this.txtEnglish.Size = new System.Drawing.Size(491, 191);
            this.txtEnglish.TabIndex = 1;
            this.ToolTipManager.SetToolTip(this.txtEnglish, "English version of the phrase that the selected token stands for");
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(54, 17);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "English";
            // 
            // txtTranslation
            // 
            this.txtTranslation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTranslation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTranslation.Location = new System.Drawing.Point(0, 17);
            this.txtTranslation.Multiline = true;
            this.txtTranslation.Name = "txtTranslation";
            this.txtTranslation.Size = new System.Drawing.Size(491, 189);
            this.txtTranslation.TabIndex = 2;
            this.ToolTipManager.SetToolTip(this.txtTranslation, "Localized version of the text that the selected token stands for in the langauge " +
        "selected above");
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label2.Location = new System.Drawing.Point(0, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(79, 17);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Translation";
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuTokens,
            this.LanguageToolStripMenuItem,
            this.cboLangugae,
            this.mnuHelp});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(695, 32);
            this.MenuStrip1.TabIndex = 2;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewFile,
            this.mnuOpenFile,
            this.mnuSaveAs,
            this.ToolStripMenuItem1,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(44, 28);
            this.mnuFile.Text = "&File";
            // 
            // mnuNewFile
            // 
            this.mnuNewFile.Name = "mnuNewFile";
            this.mnuNewFile.Size = new System.Drawing.Size(135, 26);
            this.mnuNewFile.Text = "&New";
            // 
            // mnuOpenFile
            // 
            this.mnuOpenFile.Name = "mnuOpenFile";
            this.mnuOpenFile.Size = new System.Drawing.Size(135, 26);
            this.mnuOpenFile.Text = "&Load";
            // 
            // mnuSaveAs
            // 
            this.mnuSaveAs.Name = "mnuSaveAs";
            this.mnuSaveAs.Size = new System.Drawing.Size(135, 26);
            this.mnuSaveAs.Text = "Save &As";
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(132, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(135, 26);
            this.mnuExit.Text = "E&xit";
            // 
            // mnuTokens
            // 
            this.mnuTokens.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewTaken,
            this.mnuDeleteToken});
            this.mnuTokens.Name = "mnuTokens";
            this.mnuTokens.Size = new System.Drawing.Size(67, 28);
            this.mnuTokens.Text = "&Tokens";
            // 
            // mnuNewTaken
            // 
            this.mnuNewTaken.Name = "mnuNewTaken";
            this.mnuNewTaken.Size = new System.Drawing.Size(128, 26);
            this.mnuNewTaken.Text = "&New";
            // 
            // mnuDeleteToken
            // 
            this.mnuDeleteToken.Name = "mnuDeleteToken";
            this.mnuDeleteToken.Size = new System.Drawing.Size(128, 26);
            this.mnuDeleteToken.Text = "&Delete";
            // 
            // LanguageToolStripMenuItem
            // 
            this.LanguageToolStripMenuItem.Name = "LanguageToolStripMenuItem";
            this.LanguageToolStripMenuItem.Size = new System.Drawing.Size(86, 28);
            this.LanguageToolStripMenuItem.Text = "Language";
            // 
            // cboLangugae
            // 
            this.cboLangugae.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLangugae.Items.AddRange(new object[] {
            "English",
            "French",
            "Dutch",
            "German",
            "Spanish"});
            this.cboLangugae.Name = "cboLangugae";
            this.cboLangugae.Size = new System.Drawing.Size(200, 28);
            // 
            // mnuHelp
            // 
            this.mnuHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mnuHelp.Size = new System.Drawing.Size(53, 28);
            this.mnuHelp.Text = "&Help";
            // 
            // LocalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 450);
            this.Controls.Add(this.SplitTokens);
            this.Controls.Add(this.MenuStrip1);
            this.MainMenuStrip = this.MenuStrip1;
            this.Name = "LocalForm";
            this.Text = "Localization";
            this.SplitTokens.Panel1.ResumeLayout(false);
            this.SplitTokens.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitTokens)).EndInit();
            this.SplitTokens.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.SplitTranslation.Panel1.ResumeLayout(false);
            this.SplitTranslation.Panel1.PerformLayout();
            this.SplitTranslation.Panel2.ResumeLayout(false);
            this.SplitTranslation.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitTranslation)).EndInit();
            this.SplitTranslation.ResumeLayout(false);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.SplitContainer SplitTokens;
        internal System.Windows.Forms.SplitContainer SplitTranslation;
        internal System.Windows.Forms.TextBox txtEnglish;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtTranslation;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ListBox ListTokens;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem mnuFile;
        internal System.Windows.Forms.ToolStripMenuItem mnuNewFile;
        internal System.Windows.Forms.ToolStripMenuItem mnuOpenFile;
        internal System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem mnuExit;
        internal System.Windows.Forms.ToolStripMenuItem mnuTokens;
        internal System.Windows.Forms.ToolStripMenuItem mnuNewTaken;
        internal System.Windows.Forms.ToolStripMenuItem mnuDeleteToken;
        internal System.Windows.Forms.ToolStripMenuItem LanguageToolStripMenuItem;
        internal System.Windows.Forms.ToolStripComboBox cboLangugae;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TextBox txtFilter;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.ToolTip ToolTipManager;
        internal System.Windows.Forms.ToolStripMenuItem mnuHelp;
    }

}