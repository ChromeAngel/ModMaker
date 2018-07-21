namespace ModMaker
{


    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class FGDChoicesForm : System.Windows.Forms.Form
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
            this.Button1 = new System.Windows.Forms.Button();
            this.dbgGrid = new System.Windows.Forms.DataGridView();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) this.dbgGrid).BeginInit();
            this.SuspendLayout();
            //
            //FlowLayoutPanel1
            //
            this.FlowLayoutPanel1.Controls.Add(this.btnOK);
            this.FlowLayoutPanel1.Controls.Add(this.Button1);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(0, 193);
            this.FlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(368, 37);
            this.FlowLayoutPanel1.TabIndex = 0;
            //
            //btnOK
            //
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(264, 4);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            //Button1
            //
            this.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button1.Location = new System.Drawing.Point(156, 4);
            this.Button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(100, 28);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "Cancel";
            this.Button1.UseVisualStyleBackColor = true;
            //
            //dbgGrid
            //
            this.dbgGrid.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbgGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colValue,
                this.colText
            });
            this.dbgGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbgGrid.Location = new System.Drawing.Point(0, 0);
            this.dbgGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dbgGrid.Name = "dbgGrid";
            this.dbgGrid.Size = new System.Drawing.Size(368, 193);
            this.dbgGrid.TabIndex = 1;
            //
            //colValue
            //
            this.colValue.DataPropertyName = "Value";
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            //
            //colText
            //
            this.colText.DataPropertyName = "Text";
            this.colText.HeaderText = "Display Text";
            this.colText.Name = "colText";
            this.colText.Width = 200;
            //
            //frmFGDChoices
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 230);
            this.Controls.Add(this.dbgGrid);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmFGDChoices";
            this.Text = "Choices - Mod Maker";
            this.FlowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) this.dbgGrid).EndInit();
            this.ResumeLayout(false);

        }

        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.DataGridView dbgGrid;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colText;
    }

}
