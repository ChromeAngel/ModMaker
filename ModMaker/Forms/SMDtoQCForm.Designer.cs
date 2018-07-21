using System;
using System.Windows.Forms;

namespace ModMaker
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class SMDtoQCForm : System.Windows.Forms.Form
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
            this.pnlFastCmd = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.cboSurfaceProps = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnBrowseSMD = new System.Windows.Forms.Button();
            this.pnlFastCmd.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFastCmd
            // 
            this.pnlFastCmd.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFastCmd.Controls.Add(this.btnGo);
            this.pnlFastCmd.Controls.Add(this.btnCancel);
            this.pnlFastCmd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFastCmd.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlFastCmd.Location = new System.Drawing.Point(0, 78);
            this.pnlFastCmd.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFastCmd.Name = "pnlFastCmd";
            this.pnlFastCmd.Size = new System.Drawing.Size(529, 37);
            this.pnlFastCmd.TabIndex = 4;
            // 
            // btnGo
            // 
            this.btnGo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGo.Enabled = false;
            this.btnGo.Location = new System.Drawing.Point(425, 4);
            this.btnGo.Margin = new System.Windows.Forms.Padding(4);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(100, 28);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = "&OK";
            this.btnGo.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(318, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 29);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.SystemColors.Window;
            this.Panel3.Controls.Add(this.Panel2);
            this.Panel3.Controls.Add(this.Panel1);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(0, 0);
            this.Panel3.Name = "Panel3";
            this.Panel3.Padding = new System.Windows.Forms.Padding(10);
            this.Panel3.Size = new System.Drawing.Size(529, 78);
            this.Panel3.TabIndex = 6;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.cboSurfaceProps);
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(10, 38);
            this.Panel2.Margin = new System.Windows.Forms.Padding(4);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(509, 28);
            this.Panel2.TabIndex = 6;
            // 
            // cboSurfaceProps
            // 
            this.cboSurfaceProps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboSurfaceProps.FormattingEnabled = true;
            this.cboSurfaceProps.Location = new System.Drawing.Point(129, 0);
            this.cboSurfaceProps.Margin = new System.Windows.Forms.Padding(4);
            this.cboSurfaceProps.Name = "cboSurfaceProps";
            this.cboSurfaceProps.Size = new System.Drawing.Size(380, 24);
            this.cboSurfaceProps.TabIndex = 10;
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(129, 28);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "Surface Properties";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.txtFilePath);
            this.Panel1.Controls.Add(this.Label3);
            this.Panel1.Controls.Add(this.btnBrowseSMD);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(10, 10);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(509, 28);
            this.Panel1.TabIndex = 2;
            // 
            // txtFilePath
            // 
            this.txtFilePath.AllowDrop = true;
            this.txtFilePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtFilePath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilePath.Location = new System.Drawing.Point(129, 0);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(304, 22);
            this.txtFilePath.TabIndex = 6;
            this.txtFilePath.TextChanged += new System.EventHandler(this.txtFilePath_TextChanged);
            this.txtFilePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFilePath_DragDrop);
            this.txtFilePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFilePath_DragEnter);
            // 
            // Label3
            // 
            this.Label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label3.Location = new System.Drawing.Point(0, 0);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(129, 28);
            this.Label3.TabIndex = 9;
            this.Label3.Text = "SMD or OBJ File";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBrowseSMD
            // 
            this.btnBrowseSMD.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBrowseSMD.Location = new System.Drawing.Point(433, 0);
            this.btnBrowseSMD.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseSMD.Name = "btnBrowseSMD";
            this.btnBrowseSMD.Size = new System.Drawing.Size(76, 28);
            this.btnBrowseSMD.TabIndex = 5;
            this.btnBrowseSMD.Text = "Browse";
            this.btnBrowseSMD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrowseSMD.UseVisualStyleBackColor = true;
            this.btnBrowseSMD.Click += new System.EventHandler(this.btnBrowseSMD_Click);
            // 
            // SMDtoQCForm
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(529, 115);
            this.Controls.Add(this.Panel3);
            this.Controls.Add(this.pnlFastCmd);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SMDtoQCForm";
            this.Text = "SMD to Prop";
            this.pnlFastCmd.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        internal System.Windows.Forms.FlowLayoutPanel pnlFastCmd;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.ComboBox cboSurfaceProps;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TextBox txtFilePath;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button btnBrowseSMD;

        internal System.Windows.Forms.Button btnCancel;
    }

}