namespace ModMaker
{


    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class FGD_WidgetControl : System.Windows.Forms.UserControl
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSeperator = new System.Windows.Forms.TextBox();
            this.cboParameters = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(0, 2);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(151, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtSeperator
            // 
            this.txtSeperator.Location = new System.Drawing.Point(151, 2);
            this.txtSeperator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSeperator.Name = "txtSeperator";
            this.txtSeperator.Size = new System.Drawing.Size(76, 20);
            this.txtSeperator.TabIndex = 1;
            // 
            // cboParameters
            // 
            this.cboParameters.FormattingEnabled = true;
            this.cboParameters.Location = new System.Drawing.Point(228, 1);
            this.cboParameters.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboParameters.Name = "cboParameters";
            this.cboParameters.Size = new System.Drawing.Size(148, 21);
            this.cboParameters.TabIndex = 2;
            this.cboParameters.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboParameters_KeyUp);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Lucida Console", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(376, 2);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(17, 19);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "X";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FGD_WidgetControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cboParameters);
            this.Controls.Add(this.txtSeperator);
            this.Controls.Add(this.txtName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FGD_WidgetControl";
            this.Size = new System.Drawing.Size(396, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.TextBox txtSeperator;
        internal System.Windows.Forms.ComboBox cboParameters;

        internal System.Windows.Forms.Button btnDelete;
    }

}