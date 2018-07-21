
using System;
using System.Windows.Forms;

namespace ModMaker
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class TextureDataEditorControl : System.Windows.Forms.UserControl
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
            this.radFont = new System.Windows.Forms.RadioButton();
            this.radImage = new System.Windows.Forms.RadioButton();
            this.pnlFont = new System.Windows.Forms.Panel();
            this.txtChar = new System.Windows.Forms.TextBox();
            this.txtFontFace = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.Label6 = new System.Windows.Forms.Label();
            this.udTall = new System.Windows.Forms.NumericUpDown();
            this.udWide = new System.Windows.Forms.NumericUpDown();
            this.udY = new System.Windows.Forms.NumericUpDown();
            this.udX = new System.Windows.Forms.NumericUpDown();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.pnlFont.SuspendLayout();
            this.pnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) this.udTall).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.udWide).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.udY).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.udX).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.picPreview).BeginInit();
            this.SuspendLayout();
            //
            //radFont
            //
            this.radFont.AutoSize = true;
            this.radFont.Checked = true;
            this.radFont.Dock = System.Windows.Forms.DockStyle.Top;
            this.radFont.Location = new System.Drawing.Point(0, 0);
            this.radFont.Margin = new System.Windows.Forms.Padding(4);
            this.radFont.Name = "radFont";
            this.radFont.Size = new System.Drawing.Size(501, 21);
            this.radFont.TabIndex = 0;
            this.radFont.TabStop = true;
            this.radFont.Text = "Font";
            this.radFont.UseVisualStyleBackColor = true;
            this.radFont.CheckedChanged += new EventHandler(radFont_CheckedChanged);
            //
            //radImage
            //
            this.radImage.AutoSize = true;
            this.radImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.radImage.Location = new System.Drawing.Point(0, 94);
            this.radImage.Margin = new System.Windows.Forms.Padding(4);
            this.radImage.Name = "radImage";
            this.radImage.Size = new System.Drawing.Size(501, 21);
            this.radImage.TabIndex = 1;
            this.radImage.Text = "Image";
            this.radImage.UseVisualStyleBackColor = true;
            //
            //pnlFont
            //
            this.pnlFont.Controls.Add(this.txtChar);
            this.pnlFont.Controls.Add(this.txtFontFace);
            this.pnlFont.Controls.Add(this.Label2);
            this.pnlFont.Controls.Add(this.Label1);
            this.pnlFont.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFont.Location = new System.Drawing.Point(0, 21);
            this.pnlFont.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFont.Name = "pnlFont";
            this.pnlFont.Padding = new System.Windows.Forms.Padding(27, 0, 0, 0);
            this.pnlFont.Size = new System.Drawing.Size(501, 73);
            this.pnlFont.TabIndex = 2;
            //
            //txtChar
            //
            this.txtChar.Location = new System.Drawing.Point(185, 34);
            this.txtChar.Margin = new System.Windows.Forms.Padding(4);
            this.txtChar.MaxLength = 1;
            this.txtChar.Name = "txtChar";
            this.txtChar.Size = new System.Drawing.Size(40, 22);
            this.txtChar.TabIndex = 3;
            //
            //txtFontFace
            //
            this.txtFontFace.Location = new System.Drawing.Point(184, 0);
            this.txtFontFace.Margin = new System.Windows.Forms.Padding(4);
            this.txtFontFace.Name = "txtFontFace";
            this.txtFontFace.Size = new System.Drawing.Size(312, 22);
            this.txtFontFace.TabIndex = 2;
            //
            //Label2
            //
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(105, 38);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(70, 17);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Charecter";
            //
            //Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(107, 4);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(68, 17);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Font-face";
            //
            //pnlImage
            //
            this.pnlImage.Controls.Add(this.picPreview);
            this.pnlImage.Controls.Add(this.btnEdit);
            this.pnlImage.Controls.Add(this.Label6);
            this.pnlImage.Controls.Add(this.udTall);
            this.pnlImage.Controls.Add(this.udWide);
            this.pnlImage.Controls.Add(this.udY);
            this.pnlImage.Controls.Add(this.udX);
            this.pnlImage.Controls.Add(this.txtFile);
            this.pnlImage.Controls.Add(this.Label5);
            this.pnlImage.Controls.Add(this.Label4);
            this.pnlImage.Controls.Add(this.Label3);
            this.pnlImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlImage.Enabled = false;
            this.pnlImage.Location = new System.Drawing.Point(0, 115);
            this.pnlImage.Margin = new System.Windows.Forms.Padding(4);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Padding = new System.Windows.Forms.Padding(27, 0, 0, 0);
            this.pnlImage.Size = new System.Drawing.Size(501, 358);
            this.pnlImage.TabIndex = 3;
            //
            //btnEdit
            //
            this.btnEdit.Location = new System.Drawing.Point(464, 4);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(33, 22);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new EventHandler(btnEdit_Click);
            //
            //Label6
            //
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(271, 70);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(14, 17);
            this.Label6.TabIndex = 9;
            this.Label6.Text = "x";
            //
            //udTall
            //
            this.udTall.Location = new System.Drawing.Point(288, 67);
            this.udTall.Margin = new System.Windows.Forms.Padding(4);
            this.udTall.Maximum = new decimal(new int[]
            {
                4096,
                0,
                0,
                0
            });
            this.udTall.Name = "udTall";
            this.udTall.Size = new System.Drawing.Size(84, 22);
            this.udTall.TabIndex = 8;
            this.udTall.ValueChanged += new EventHandler(ud_ValueChanged);
            //
            //udWide
            //
            this.udWide.Location = new System.Drawing.Point(184, 67);
            this.udWide.Margin = new System.Windows.Forms.Padding(4);
            this.udWide.Maximum = new decimal(new int[]
            {
                4096,
                0,
                0,
                0
            });
            this.udWide.Name = "udWide";
            this.udWide.Size = new System.Drawing.Size(84, 22);
            this.udWide.TabIndex = 7;
            this.udWide.ValueChanged += new EventHandler(ud_ValueChanged);
            //
            //udY
            //
            this.udY.Location = new System.Drawing.Point(288, 37);
            this.udY.Margin = new System.Windows.Forms.Padding(4);
            this.udY.Maximum = new decimal(new int[]
            {
                4096,
                0,
                0,
                0
            });
            this.udY.Name = "udY";
            this.udY.Size = new System.Drawing.Size(84, 22);
            this.udY.TabIndex = 6;
            this.udY.ValueChanged += new EventHandler(ud_ValueChanged);
            //
            //udX
            //
            this.udX.Location = new System.Drawing.Point(184, 37);
            this.udX.Margin = new System.Windows.Forms.Padding(4);
            this.udX.Maximum = new decimal(new int[]
            {
                4096,
                0,
                0,
                0
            });
            this.udX.Name = "udX";
            this.udX.Size = new System.Drawing.Size(84, 22);
            this.udX.TabIndex = 5;
            this.udX.ValueChanged += new EventHandler(ud_ValueChanged);
            //
            //txtFile
            //
            this.txtFile.Location = new System.Drawing.Point(184, 4);
            this.txtFile.Margin = new System.Windows.Forms.Padding(4);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(279, 22);
            this.txtFile.TabIndex = 4;
            this.txtFile.TextChanged += new EventHandler(txtFile_TextChanged);
            //
            //Label5
            //
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(93, 70);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(84, 17);
            this.Label5.TabIndex = 3;
            this.Label5.Text = "Size (pixels)";
            //
            //Label4
            //
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(31, 39);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(148, 17);
            this.Label4.TabIndex = 2;
            this.Label4.Text = "Top-left Offset (pixels)";
            //
            //Label3
            //
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(117, 9);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(58, 17);
            this.Label3.TabIndex = 1;
            this.Label3.Text = "Material";
            //
            //picPreview
            //
            this.picPreview.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPreview.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picPreview.Location = new System.Drawing.Point(185, 97);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(256, 256);
            this.picPreview.TabIndex = 11;
            this.picPreview.TabStop = false;
            this.picPreview.MouseDown += new MouseEventHandler(picPreview_MouseDown);
            this.picPreview.MouseMove += new MouseEventHandler(picPreview_MouseMove);
            //
            //TextureDataEditorControl
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlImage);
            this.Controls.Add(this.radImage);
            this.Controls.Add(this.pnlFont);
            this.Controls.Add(this.radFont);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TextureDataEditorControl";
            this.Size = new System.Drawing.Size(501, 481);
            this.pnlFont.ResumeLayout(false);
            this.pnlFont.PerformLayout();
            this.pnlImage.ResumeLayout(false);
            this.pnlImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) this.udTall).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.udWide).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.udY).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.udX).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.picPreview).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal System.Windows.Forms.RadioButton radFont;
        internal System.Windows.Forms.RadioButton radImage;
        internal System.Windows.Forms.Panel pnlFont;
        internal System.Windows.Forms.Panel pnlImage;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtChar;
        internal System.Windows.Forms.TextBox txtFontFace;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.NumericUpDown udTall;
        internal System.Windows.Forms.NumericUpDown udWide;
        internal System.Windows.Forms.NumericUpDown udY;
        internal System.Windows.Forms.NumericUpDown udX;
        internal System.Windows.Forms.TextBox txtFile;
        internal System.Windows.Forms.Button btnEdit;

        internal System.Windows.Forms.PictureBox picPreview;
    }

}