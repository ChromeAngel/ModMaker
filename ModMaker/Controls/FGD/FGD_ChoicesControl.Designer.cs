namespace ModMaker
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class FGD_ChoicesControl : System.Windows.Forms.UserControl
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
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.lblChoices = new System.Windows.Forms.Label();
            this.cboOptions = new System.Windows.Forms.ComboBox();
            this.btnManageOptions = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(153, 2);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(200, 20);
            this.txtNotes.TabIndex = 6;
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(1, 2);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(150, 20);
            this.txtClassName.TabIndex = 4;
            // 
            // lblChoices
            // 
            this.lblChoices.AutoSize = true;
            this.lblChoices.Location = new System.Drawing.Point(359, 3);
            this.lblChoices.Name = "lblChoices";
            this.lblChoices.Size = new System.Drawing.Size(44, 13);
            this.lblChoices.TabIndex = 7;
            this.lblChoices.Text = "choices";
            // 
            // cboOptions
            // 
            this.cboOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOptions.FormattingEnabled = true;
            this.cboOptions.Location = new System.Drawing.Point(404, 1);
            this.cboOptions.Name = "cboOptions";
            this.cboOptions.Size = new System.Drawing.Size(122, 21);
            this.cboOptions.TabIndex = 8;
            // 
            // btnManageOptions
            // 
            this.btnManageOptions.Location = new System.Drawing.Point(526, 0);
            this.btnManageOptions.Name = "btnManageOptions";
            this.btnManageOptions.Size = new System.Drawing.Size(25, 21);
            this.btnManageOptions.TabIndex = 9;
            this.btnManageOptions.Text = "...";
            this.btnManageOptions.UseVisualStyleBackColor = true;
            this.btnManageOptions.Click += new System.EventHandler(this.btnManageOptions_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Lucida Console", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(550, 2);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(17, 19);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "X";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FGD_ChoicesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnManageOptions);
            this.Controls.Add(this.cboOptions);
            this.Controls.Add(this.lblChoices);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtClassName);
            this.Name = "FGD_ChoicesControl";
            this.Size = new System.Drawing.Size(571, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal System.Windows.Forms.TextBox txtNotes;
        internal System.Windows.Forms.TextBox txtClassName;
        internal System.Windows.Forms.Label lblChoices;
        internal System.Windows.Forms.ComboBox cboOptions;
        internal System.Windows.Forms.Button btnManageOptions;

        internal System.Windows.Forms.Button btnDelete;
    }

}