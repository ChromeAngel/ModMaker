namespace ModMaker
{


    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class InstallerForm : System.Windows.Forms.Form
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
            this.Panel2 = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.pnlSaveAs = new System.Windows.Forms.Panel();
            this.txtSaveAs = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.pnlVersion = new System.Windows.Forms.Panel();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.pnlCleanup = new System.Windows.Forms.Panel();
            this.chkCleanup = new System.Windows.Forms.CheckBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.pnlCompile = new System.Windows.Forms.Panel();
            this.chkCompile = new System.Windows.Forms.CheckBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Panel2.SuspendLayout();
            this.pnlSaveAs.SuspendLayout();
            this.pnlVersion.SuspendLayout();
            this.pnlCleanup.SuspendLayout();
            this.pnlCompile.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.btnStart);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(20, 198);
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
            // 
            // pnlSaveAs
            // 
            this.pnlSaveAs.Controls.Add(this.txtSaveAs);
            this.pnlSaveAs.Controls.Add(this.btnBrowse);
            this.pnlSaveAs.Controls.Add(this.Label2);
            this.pnlSaveAs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSaveAs.Location = new System.Drawing.Point(20, 97);
            this.pnlSaveAs.Name = "pnlSaveAs";
            this.pnlSaveAs.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.pnlSaveAs.Size = new System.Drawing.Size(453, 38);
            this.pnlSaveAs.TabIndex = 2;
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
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
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
            // pnlVersion
            // 
            this.pnlVersion.Controls.Add(this.txtVersion);
            this.pnlVersion.Controls.Add(this.Label3);
            this.pnlVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlVersion.Location = new System.Drawing.Point(20, 20);
            this.pnlVersion.Name = "pnlVersion";
            this.pnlVersion.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.pnlVersion.Size = new System.Drawing.Size(453, 39);
            this.pnlVersion.TabIndex = 0;
            // 
            // txtVersion
            // 
            this.txtVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtVersion.Location = new System.Drawing.Point(110, 8);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(343, 22);
            this.txtVersion.TabIndex = 0;
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
            // pnlCleanup
            // 
            this.pnlCleanup.Controls.Add(this.chkCleanup);
            this.pnlCleanup.Controls.Add(this.Label1);
            this.pnlCleanup.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCleanup.Location = new System.Drawing.Point(20, 59);
            this.pnlCleanup.Name = "pnlCleanup";
            this.pnlCleanup.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.pnlCleanup.Size = new System.Drawing.Size(453, 38);
            this.pnlCleanup.TabIndex = 1;
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
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label1.Location = new System.Drawing.Point(0, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(110, 22);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Cleanup?";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlCompile
            // 
            this.pnlCompile.Controls.Add(this.chkCompile);
            this.pnlCompile.Controls.Add(this.Label4);
            this.pnlCompile.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCompile.Location = new System.Drawing.Point(20, 135);
            this.pnlCompile.Name = "pnlCompile";
            this.pnlCompile.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.pnlCompile.Size = new System.Drawing.Size(453, 38);
            this.pnlCompile.TabIndex = 3;
            // 
            // chkCompile
            // 
            this.chkCompile.AutoSize = true;
            this.chkCompile.Location = new System.Drawing.Point(117, 8);
            this.chkCompile.Name = "chkCompile";
            this.chkCompile.Size = new System.Drawing.Size(18, 17);
            this.chkCompile.TabIndex = 0;
            this.chkCompile.UseVisualStyleBackColor = true;
            // 
            // Label4
            // 
            this.Label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label4.Location = new System.Drawing.Point(0, 8);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(110, 22);
            this.Label4.TabIndex = 4;
            this.Label4.Text = "Compile Exe?";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // InstallerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 251);
            this.Controls.Add(this.pnlCompile);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.pnlSaveAs);
            this.Controls.Add(this.pnlCleanup);
            this.Controls.Add(this.pnlVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InstallerForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Mod Maker - Make Installer";
            this.Panel2.ResumeLayout(false);
            this.pnlSaveAs.ResumeLayout(false);
            this.pnlSaveAs.PerformLayout();
            this.pnlVersion.ResumeLayout(false);
            this.pnlVersion.PerformLayout();
            this.pnlCleanup.ResumeLayout(false);
            this.pnlCleanup.PerformLayout();
            this.pnlCompile.ResumeLayout(false);
            this.pnlCompile.PerformLayout();
            this.ResumeLayout(false);

        }

        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.Panel pnlSaveAs;
        internal System.Windows.Forms.TextBox txtSaveAs;
        internal System.Windows.Forms.Button btnBrowse;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel pnlVersion;
        internal System.Windows.Forms.TextBox txtVersion;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Panel pnlCleanup;
        internal System.Windows.Forms.CheckBox chkCleanup;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel pnlCompile;
        internal System.Windows.Forms.CheckBox chkCompile;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ToolTip ToolTip1;
    }

}
