
namespace ModMaker
{


    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class ZipForm : System.Windows.Forms.Form
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
            this.Label1 = new System.Windows.Forms.Label();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.pnlSaveAs = new System.Windows.Forms.Panel();
            this.txtSaveAs = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.grpFormat = new System.Windows.Forms.GroupBox();
            this.RadSeven = new System.Windows.Forms.RadioButton();
            this.radZip = new System.Windows.Forms.RadioButton();
            this.pnlVersion = new System.Windows.Forms.Panel();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.pnlCleanup = new System.Windows.Forms.Panel();
            this.chkCleanup = new System.Windows.Forms.CheckBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlSaveAs.SuspendLayout();
            this.grpFormat.SuspendLayout();
            this.pnlVersion.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.pnlCleanup.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Location = new System.Drawing.Point(20, 205);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.Label1.Size = new System.Drawing.Size(453, 41);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Compressing files, please wait";
            this.Label1.Visible = false;
            // 
            // Progress
            // 
            this.Progress.Dock = System.Windows.Forms.DockStyle.Top;
            this.Progress.Location = new System.Drawing.Point(20, 246);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(453, 23);
            this.Progress.TabIndex = 2;
            this.Progress.Visible = false;
            // 
            // pnlSaveAs
            // 
            this.pnlSaveAs.Controls.Add(this.txtSaveAs);
            this.pnlSaveAs.Controls.Add(this.btnBrowse);
            this.pnlSaveAs.Controls.Add(this.Label2);
            this.pnlSaveAs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSaveAs.Location = new System.Drawing.Point(20, 167);
            this.pnlSaveAs.Name = "pnlSaveAs";
            this.pnlSaveAs.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.pnlSaveAs.Size = new System.Drawing.Size(453, 38);
            this.pnlSaveAs.TabIndex = 3;
            // 
            // txtSaveAs
            // 
            this.txtSaveAs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSaveAs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtSaveAs.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSaveAs.Location = new System.Drawing.Point(110, 8);
            this.txtSaveAs.Name = "txtSaveAs";
            this.txtSaveAs.Size = new System.Drawing.Size(306, 22);
            this.txtSaveAs.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBrowse.Location = new System.Drawing.Point(416, 8);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(37, 22);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // Label2
            // 
            this.Label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label2.Location = new System.Drawing.Point(0, 8);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(110, 22);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Save As";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grpFormat
            // 
            this.grpFormat.Controls.Add(this.RadSeven);
            this.grpFormat.Controls.Add(this.radZip);
            this.grpFormat.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFormat.Location = new System.Drawing.Point(20, 20);
            this.grpFormat.Name = "grpFormat";
            this.grpFormat.Size = new System.Drawing.Size(453, 70);
            this.grpFormat.TabIndex = 0;
            this.grpFormat.TabStop = false;
            this.grpFormat.Text = "Compression Format";
            // 
            // RadSeven
            // 
            this.RadSeven.AutoSize = true;
            this.RadSeven.Location = new System.Drawing.Point(6, 44);
            this.RadSeven.Name = "RadSeven";
            this.RadSeven.Size = new System.Drawing.Size(193, 21);
            this.RadSeven.TabIndex = 1;
            this.RadSeven.Text = "7 Zip - Makes smaller files";
            this.RadSeven.UseVisualStyleBackColor = true;
            // 
            // radZip
            // 
            this.radZip.AutoSize = true;
            this.radZip.Checked = true;
            this.radZip.Location = new System.Drawing.Point(6, 21);
            this.radZip.Name = "radZip";
            this.radZip.Size = new System.Drawing.Size(228, 21);
            this.radZip.TabIndex = 0;
            this.radZip.TabStop = true;
            this.radZip.Text = "Zip - Opens on most computers";
            this.radZip.UseVisualStyleBackColor = true;
            this.radZip.CheckedChanged += new System.EventHandler(this.radZip_CheckedChanged);
            // 
            // pnlVersion
            // 
            this.pnlVersion.Controls.Add(this.txtVersion);
            this.pnlVersion.Controls.Add(this.Label3);
            this.pnlVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlVersion.Location = new System.Drawing.Point(20, 90);
            this.pnlVersion.Name = "pnlVersion";
            this.pnlVersion.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.pnlVersion.Size = new System.Drawing.Size(453, 39);
            this.pnlVersion.TabIndex = 1;
            // 
            // txtVersion
            // 
            this.txtVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtVersion.Location = new System.Drawing.Point(110, 8);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(343, 22);
            this.txtVersion.TabIndex = 0;
            this.txtVersion.TextChanged += new System.EventHandler(this.txtVersion_TextChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label3.Location = new System.Drawing.Point(0, 8);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(110, 17);
            this.Label3.TabIndex = 5;
            this.Label3.Text = "Version Number";
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.btnStart);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(20, 286);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(453, 33);
            this.Panel2.TabIndex = 4;
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnStart.Location = new System.Drawing.Point(371, 0);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(82, 33);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pnlCleanup
            // 
            this.pnlCleanup.Controls.Add(this.chkCleanup);
            this.pnlCleanup.Controls.Add(this.Label4);
            this.pnlCleanup.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCleanup.Location = new System.Drawing.Point(20, 129);
            this.pnlCleanup.Name = "pnlCleanup";
            this.pnlCleanup.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.pnlCleanup.Size = new System.Drawing.Size(453, 38);
            this.pnlCleanup.TabIndex = 2;
            // 
            // chkCleanup
            // 
            this.chkCleanup.AutoSize = true;
            this.chkCleanup.Location = new System.Drawing.Point(117, 11);
            this.chkCleanup.Name = "chkCleanup";
            this.chkCleanup.Size = new System.Drawing.Size(18, 17);
            this.chkCleanup.TabIndex = 0;
            this.ToolTip1.SetToolTip(this.chkCleanup, "Send temporary, auto-generated and player specific files to the Recycle Bin?");
            this.chkCleanup.UseVisualStyleBackColor = true;
            // 
            // Label4
            // 
            this.Label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label4.Location = new System.Drawing.Point(0, 8);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(110, 22);
            this.Label4.TabIndex = 4;
            this.Label4.Text = "Cleanup?";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ZipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 339);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.pnlSaveAs);
            this.Controls.Add(this.pnlCleanup);
            this.Controls.Add(this.pnlVersion);
            this.Controls.Add(this.grpFormat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ZipForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Mod Maker - Making Patch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmZip_FormClosing);
            this.pnlSaveAs.ResumeLayout(false);
            this.pnlSaveAs.PerformLayout();
            this.grpFormat.ResumeLayout(false);
            this.grpFormat.PerformLayout();
            this.pnlVersion.ResumeLayout(false);
            this.pnlVersion.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.pnlCleanup.ResumeLayout(false);
            this.pnlCleanup.PerformLayout();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ProgressBar Progress;
        internal System.Windows.Forms.Panel pnlSaveAs;
        internal System.Windows.Forms.TextBox txtSaveAs;
        internal System.Windows.Forms.Button btnBrowse;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.GroupBox grpFormat;
        internal System.Windows.Forms.RadioButton RadSeven;
        internal System.Windows.Forms.RadioButton radZip;
        internal System.Windows.Forms.Panel pnlVersion;
        internal System.Windows.Forms.TextBox txtVersion;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.Panel pnlCleanup;
        internal System.Windows.Forms.CheckBox chkCleanup;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ToolTip ToolTip1;
    }

}