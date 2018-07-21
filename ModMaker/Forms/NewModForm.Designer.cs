using System;

namespace ModMaker
{


    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class NewModForm : System.Windows.Forms.Form
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
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SplitColumns = new System.Windows.Forms.SplitContainer();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.radEpisodic = new System.Windows.Forms.RadioButton();
            this.radHL2 = new System.Windows.Forms.RadioButton();
            this.radHL2MP = new System.Windows.Forms.RadioButton();
            this.Label8 = new System.Windows.Forms.Label();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.Label7 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.FlowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitColumns)).BeginInit();
            this.SplitColumns.Panel1.SuspendLayout();
            this.SplitColumns.Panel2.SuspendLayout();
            this.SplitColumns.SuspendLayout();
            this.Panel4.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.Controls.Add(this.btnOK);
            this.FlowLayoutPanel1.Controls.Add(this.btnCancel);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(0, 259);
            this.FlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(807, 38);
            this.FlowLayoutPanel1.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(703, 4);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(595, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // SplitColumns
            // 
            this.SplitColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitColumns.ForeColor = System.Drawing.Color.White;
            this.SplitColumns.Location = new System.Drawing.Point(0, 0);
            this.SplitColumns.Margin = new System.Windows.Forms.Padding(4);
            this.SplitColumns.Name = "SplitColumns";
            // 
            // SplitColumns.Panel1
            // 
            this.SplitColumns.Panel1.Controls.Add(this.Label4);
            this.SplitColumns.Panel1.Controls.Add(this.Label3);
            this.SplitColumns.Panel1.Controls.Add(this.Label2);
            this.SplitColumns.Panel1.Controls.Add(this.Label1);
            this.SplitColumns.Panel1.Padding = new System.Windows.Forms.Padding(0, 34, 0, 0);
            // 
            // SplitColumns.Panel2
            // 
            this.SplitColumns.Panel2.Controls.Add(this.Panel4);
            this.SplitColumns.Panel2.Controls.Add(this.Panel3);
            this.SplitColumns.Panel2.Controls.Add(this.Panel2);
            this.SplitColumns.Panel2.Controls.Add(this.Panel1);
            this.SplitColumns.Panel2.Padding = new System.Windows.Forms.Padding(0, 12, 13, 0);
            this.SplitColumns.Size = new System.Drawing.Size(807, 259);
            this.SplitColumns.SplitterDistance = 130;
            this.SplitColumns.SplitterWidth = 5;
            this.SplitColumns.TabIndex = 1;
            this.SplitColumns.TabStop = false;
            this.SplitColumns.Resize += new System.EventHandler(this.SplitColumns_Resize);
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label4.Location = new System.Drawing.Point(0, 233);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(130, 46);
            this.Label4.TabIndex = 3;
            this.Label4.Text = "Mod Type";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label3.Location = new System.Drawing.Point(0, 178);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(130, 55);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Source Folder";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label2.Location = new System.Drawing.Point(0, 103);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(130, 75);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Install Folder Name";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Location = new System.Drawing.Point(0, 34);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(130, 69);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Full Mod Name";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.Color.Transparent;
            this.Panel4.Controls.Add(this.radEpisodic);
            this.Panel4.Controls.Add(this.radHL2);
            this.Panel4.Controls.Add(this.radHL2MP);
            this.Panel4.Controls.Add(this.Label8);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel4.Location = new System.Drawing.Point(0, 227);
            this.Panel4.Margin = new System.Windows.Forms.Padding(4);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(659, 28);
            this.Panel4.TabIndex = 3;
            // 
            // radEpisodic
            // 
            this.radEpisodic.AutoSize = true;
            this.radEpisodic.Location = new System.Drawing.Point(261, 4);
            this.radEpisodic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radEpisodic.Name = "radEpisodic";
            this.radEpisodic.Size = new System.Drawing.Size(173, 21);
            this.radEpisodic.TabIndex = 3;
            this.radEpisodic.Text = "Single Player Episodic ";
            this.radEpisodic.UseVisualStyleBackColor = true;
            // 
            // radHL2
            // 
            this.radHL2.AutoSize = true;
            this.radHL2.Location = new System.Drawing.Point(125, 2);
            this.radHL2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radHL2.Name = "radHL2";
            this.radHL2.Size = new System.Drawing.Size(112, 21);
            this.radHL2.TabIndex = 2;
            this.radHL2.TabStop = true;
            this.radHL2.Text = "Single Player";
            this.radHL2.UseVisualStyleBackColor = true;
            // 
            // radHL2MP
            // 
            this.radHL2MP.AutoSize = true;
            this.radHL2MP.Checked = true;
            this.radHL2MP.Location = new System.Drawing.Point(4, 4);
            this.radHL2MP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radHL2MP.Name = "radHL2MP";
            this.radHL2MP.Size = new System.Drawing.Size(97, 21);
            this.radHL2MP.TabIndex = 1;
            this.radHL2MP.TabStop = true;
            this.radHL2MP.Text = "Multiplayer";
            this.radHL2MP.UseVisualStyleBackColor = true;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Label8.Location = new System.Drawing.Point(0, 11);
            this.Label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(0, 17);
            this.Label8.TabIndex = 0;
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.Color.Transparent;
            this.Panel3.Controls.Add(this.txtPath);
            this.Panel3.Controls.Add(this.btnBrowse);
            this.Panel3.Controls.Add(this.Label7);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel3.Location = new System.Drawing.Point(0, 156);
            this.Panel3.Margin = new System.Windows.Forms.Padding(4);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(659, 71);
            this.Panel3.TabIndex = 2;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(0, 21);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(435, 22);
            this.txtPath.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.ForeColor = System.Drawing.Color.Black;
            this.btnBrowse.Location = new System.Drawing.Point(435, 18);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(69, 26);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Location = new System.Drawing.Point(4, 0);
            this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(306, 17);
            this.Label7.TabIndex = 0;
            this.Label7.Text = "Where do you want your Source files saved to?";
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.Panel2.Controls.Add(this.txtFolderName);
            this.Panel2.Controls.Add(this.Label6);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(0, 86);
            this.Panel2.Margin = new System.Windows.Forms.Padding(4);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(659, 70);
            this.Panel2.TabIndex = 1;
            // 
            // txtFolderName
            // 
            this.txtFolderName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtFolderName.Location = new System.Drawing.Point(0, 18);
            this.txtFolderName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size(659, 22);
            this.txtFolderName.TabIndex = 0;
            // 
            // Label6
            // 
            this.Label6.AutoEllipsis = true;
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label6.Location = new System.Drawing.Point(0, 0);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(659, 18);
            this.Label6.TabIndex = 0;
            this.Label6.Text = "Short, but distinct name for the mod, possibly even initials.  You will be typing" +
    " this a LOT.";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.Controls.Add(this.txtTitle);
            this.Panel1.Controls.Add(this.Label5);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 12);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(659, 74);
            this.Panel1.TabIndex = 0;
            // 
            // txtTitle
            // 
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTitle.Location = new System.Drawing.Point(0, 22);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(659, 22);
            this.txtTitle.TabIndex = 0;
            // 
            // Label5
            // 
            this.Label5.AutoEllipsis = true;
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label5.Location = new System.Drawing.Point(0, 0);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(659, 22);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "As it appears in the Steam Library.  Suggest you try googling to see if it has be" +
    "en used by anyone else.";
            // 
            // NewModForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(807, 297);
            this.Controls.Add(this.SplitColumns);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NewModForm";
            this.Text = "New Mod - Mod Maker";
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.SplitColumns.Panel1.ResumeLayout(false);
            this.SplitColumns.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitColumns)).EndInit();
            this.SplitColumns.ResumeLayout(false);
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.SplitContainer SplitColumns;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtPath;
        internal System.Windows.Forms.Button btnBrowse;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtFolderName;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtTitle;
        internal System.Windows.Forms.RadioButton radEpisodic;
        internal System.Windows.Forms.RadioButton radHL2;
        internal System.Windows.Forms.RadioButton radHL2MP;
    }

}