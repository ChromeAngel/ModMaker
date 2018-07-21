namespace ModMaker
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class KeyBindingForm : System.Windows.Forms.Form
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnNewGroup = new System.Windows.Forms.Button();
            this.btnUseMyKeys = new System.Windows.Forms.Button();
            this.KeyBindControl1 = new ModMaker.KeyBindControl();
            this.FlowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.Controls.Add(this.btnCancel);
            this.FlowLayoutPanel1.Controls.Add(this.btnOK);
            this.FlowLayoutPanel1.Controls.Add(this.btnNewGroup);
            this.FlowLayoutPanel1.Controls.Add(this.btnUseMyKeys);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(0, 243);
            this.FlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(674, 28);
            this.FlowLayoutPanel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(604, 2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(532, 2);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(68, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnNewGroup
            // 
            this.btnNewGroup.Location = new System.Drawing.Point(460, 2);
            this.btnNewGroup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNewGroup.Name = "btnNewGroup";
            this.btnNewGroup.Size = new System.Drawing.Size(68, 23);
            this.btnNewGroup.TabIndex = 2;
            this.btnNewGroup.Text = "&New Group";
            this.btnNewGroup.UseVisualStyleBackColor = true;
            this.btnNewGroup.Click += new System.EventHandler(this.btnNewGroup_Click);
            // 
            // btnUseMyKeys
            // 
            this.btnUseMyKeys.Location = new System.Drawing.Point(376, 2);
            this.btnUseMyKeys.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUseMyKeys.Name = "btnUseMyKeys";
            this.btnUseMyKeys.Size = new System.Drawing.Size(80, 23);
            this.btnUseMyKeys.TabIndex = 3;
            this.btnUseMyKeys.Text = "&Use My Keys";
            this.btnUseMyKeys.UseVisualStyleBackColor = true;
            this.btnUseMyKeys.Visible = false;
            this.btnUseMyKeys.Click += new System.EventHandler(this.btnUseMyKeys_Click);
            // 
            // KeyBindControl1
            // 
            this.KeyBindControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeyBindControl1.Game = null;
            this.KeyBindControl1.Location = new System.Drawing.Point(0, 0);
            this.KeyBindControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.KeyBindControl1.Name = "KeyBindControl1";
            this.KeyBindControl1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.KeyBindControl1.Size = new System.Drawing.Size(674, 243);
            this.KeyBindControl1.TabIndex = 0;
            // 
            // KeyBindingForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(674, 271);
            this.Controls.Add(this.KeyBindControl1);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "KeyBindingForm";
            this.Text = "Key Menu Editor";
            this.Load += new System.EventHandler(this.frmKeyBinding_Load);
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        internal ModMaker.KeyBindControl KeyBindControl1;
        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnNewGroup;
        internal System.Windows.Forms.Button btnUseMyKeys;
    }

}