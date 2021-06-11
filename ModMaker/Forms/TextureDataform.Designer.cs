

namespace ModMaker
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class frmTextureData : System.Windows.Forms.Form
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
            LibModMaker.KeyValues ValveKey1 = new LibModMaker.KeyValues();
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Editor = new ModMaker.TextureDataEditorControl();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.FlowLayoutPanel1.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            //
            //FlowLayoutPanel1
            //
            this.FlowLayoutPanel1.Controls.Add(this.Button1);
            this.FlowLayoutPanel1.Controls.Add(this.Button2);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(0, 501);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(505, 36);
            this.FlowLayoutPanel1.TabIndex = 0;
            //
            //Button1
            //
            this.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button1.Location = new System.Drawing.Point(427, 3);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 28);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "&Cancel";
            this.Button1.UseVisualStyleBackColor = true;
            //
            //Button2
            //
            this.Button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Button2.Location = new System.Drawing.Point(346, 3);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 28);
            this.Button2.TabIndex = 1;
            this.Button2.Text = "OK";
            this.Button2.UseVisualStyleBackColor = true;
            //
            //Editor
            //
            this.Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Editor.Game = null;
            this.Editor.Location = new System.Drawing.Point(0, 28);
            this.Editor.Margin = new System.Windows.Forms.Padding(4);
            this.Editor.Name = "Editor";
            this.Editor.Size = new System.Drawing.Size(505, 473);
            this.Editor.TabIndex = 1;
            this.Editor.TextureData = null;
            //
            //MenuStrip1
            //
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.mnuHelp});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(505, 28);
            this.MenuStrip1.TabIndex = 2;
            this.MenuStrip1.Text = "MenuStrip1";
            //
            //mnuHelp
            //
            this.mnuHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(53, 24);
            this.mnuHelp.Text = "&Help";
            //
            //frmTextureData
            //
            this.AcceptButton = this.Button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Button1;
            this.ClientSize = new System.Drawing.Size(505, 537);
            this.Controls.Add(this.Editor);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Controls.Add(this.MenuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.MenuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTextureData";
            this.Text = "Texture Data";
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Button Button2;
        internal ModMaker.TextureDataEditorControl Editor;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem mnuHelp;
    }

}