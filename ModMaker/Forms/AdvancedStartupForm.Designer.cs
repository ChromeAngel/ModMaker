namespace ModMaker
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class AdvancedStartupForm : System.Windows.Forms.Form
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
            this.FlowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlMapArg = new System.Windows.Forms.Panel();
            this.cboMap = new System.Windows.Forms.ComboBox();
            this.chkMap = new System.Windows.Forms.CheckBox();
            this.chkNoIntro = new System.Windows.Forms.CheckBox();
            this.chkWindowed = new System.Windows.Forms.CheckBox();
            this.chkNoBorder = new System.Windows.Forms.CheckBox();
            this.chkDeveloper = new System.Windows.Forms.CheckBox();
            this.chkAllowDebug = new System.Windows.Forms.CheckBox();
            this.chkCondebug = new System.Windows.Forms.CheckBox();
            this.chkToolsMode = new System.Windows.Forms.CheckBox();
            this.chkToConsole = new System.Windows.Forms.CheckBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.FlowLayoutPanel1.SuspendLayout();
            this.FlowLayoutPanel2.SuspendLayout();
            this.pnlMapArg.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            //
            //FlowLayoutPanel1
            //
            this.FlowLayoutPanel1.Controls.Add(this.btnCancel);
            this.FlowLayoutPanel1.Controls.Add(this.btnOK);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(0, 153);
            this.FlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(536, 37);
            this.FlowLayoutPanel1.TabIndex = 1;
            //
            //btnCancel
            //
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(432, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            //btnOK
            //
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(324, 4);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            //FlowLayoutPanel2
            //
            this.FlowLayoutPanel2.Controls.Add(this.pnlMapArg);
            this.FlowLayoutPanel2.Controls.Add(this.chkNoIntro);
            this.FlowLayoutPanel2.Controls.Add(this.chkWindowed);
            this.FlowLayoutPanel2.Controls.Add(this.chkNoBorder);
            this.FlowLayoutPanel2.Controls.Add(this.chkDeveloper);
            this.FlowLayoutPanel2.Controls.Add(this.chkAllowDebug);
            this.FlowLayoutPanel2.Controls.Add(this.chkCondebug);
            this.FlowLayoutPanel2.Controls.Add(this.chkToolsMode);
            this.FlowLayoutPanel2.Controls.Add(this.chkToConsole);
            this.FlowLayoutPanel2.Controls.Add(this.Panel1);
            this.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.FlowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.FlowLayoutPanel2.Name = "FlowLayoutPanel2";
            this.FlowLayoutPanel2.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.FlowLayoutPanel2.Size = new System.Drawing.Size(536, 153);
            this.FlowLayoutPanel2.TabIndex = 34;
            //
            //pnlMapArg
            //
            this.pnlMapArg.Controls.Add(this.cboMap);
            this.pnlMapArg.Controls.Add(this.chkMap);
            this.pnlMapArg.Location = new System.Drawing.Point(11, 10);
            this.pnlMapArg.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMapArg.Name = "pnlMapArg";
            this.pnlMapArg.Size = new System.Drawing.Size(293, 27);
            this.pnlMapArg.TabIndex = 35;
            //
            //cboMap
            //
            this.cboMap.Enabled = false;
            this.cboMap.FormattingEnabled = true;
            this.cboMap.Location = new System.Drawing.Point(64, 1);
            this.cboMap.Margin = new System.Windows.Forms.Padding(4);
            this.cboMap.Name = "cboMap";
            this.cboMap.Size = new System.Drawing.Size(220, 24);
            this.cboMap.TabIndex = 34;
            //
            //chkMap
            //
            this.chkMap.AutoSize = true;
            this.chkMap.Location = new System.Drawing.Point(0, 4);
            this.chkMap.Margin = new System.Windows.Forms.Padding(4);
            this.chkMap.Name = "chkMap";
            this.chkMap.Size = new System.Drawing.Size(57, 21);
            this.chkMap.TabIndex = 33;
            this.chkMap.Text = "Map";
            this.chkMap.UseVisualStyleBackColor = true;
            //
            //chkNoIntro
            //
            this.chkNoIntro.Location = new System.Drawing.Point(312, 10);
            this.chkNoIntro.Margin = new System.Windows.Forms.Padding(4);
            this.chkNoIntro.Name = "chkNoIntro";
            this.chkNoIntro.Size = new System.Drawing.Size(99, 27);
            this.chkNoIntro.TabIndex = 37;
            this.chkNoIntro.Text = "Skip Intro";
            this.chkNoIntro.UseVisualStyleBackColor = true;
            //
            //chkWindowed
            //
            this.chkWindowed.Location = new System.Drawing.Point(419, 10);
            this.chkWindowed.Margin = new System.Windows.Forms.Padding(4);
            this.chkWindowed.Name = "chkWindowed";
            this.chkWindowed.Size = new System.Drawing.Size(103, 27);
            this.chkWindowed.TabIndex = 36;
            this.chkWindowed.Text = "Windowed";
            this.chkWindowed.UseVisualStyleBackColor = true;
            //
            //chkNoBorder
            //
            this.chkNoBorder.Location = new System.Drawing.Point(11, 45);
            this.chkNoBorder.Margin = new System.Windows.Forms.Padding(4);
            this.chkNoBorder.Name = "chkNoBorder";
            this.chkNoBorder.Size = new System.Drawing.Size(99, 27);
            this.chkNoBorder.TabIndex = 38;
            this.chkNoBorder.Text = "No Border";
            this.chkNoBorder.UseVisualStyleBackColor = true;
            //
            //chkDeveloper
            //
            this.chkDeveloper.Location = new System.Drawing.Point(118, 45);
            this.chkDeveloper.Margin = new System.Windows.Forms.Padding(4);
            this.chkDeveloper.Name = "chkDeveloper";
            this.chkDeveloper.Size = new System.Drawing.Size(140, 27);
            this.chkDeveloper.TabIndex = 28;
            this.chkDeveloper.Text = "Developer Mode";
            this.chkDeveloper.UseVisualStyleBackColor = true;
            //
            //chkAllowDebug
            //
            this.chkAllowDebug.Location = new System.Drawing.Point(266, 45);
            this.chkAllowDebug.Margin = new System.Windows.Forms.Padding(4);
            this.chkAllowDebug.Name = "chkAllowDebug";
            this.chkAllowDebug.Size = new System.Drawing.Size(156, 27);
            this.chkAllowDebug.TabIndex = 29;
            this.chkAllowDebug.Text = "Allow Debug Builds";
            this.chkAllowDebug.UseVisualStyleBackColor = true;
            //
            //chkCondebug
            //
            this.chkCondebug.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkCondebug.Location = new System.Drawing.Point(11, 80);
            this.chkCondebug.Margin = new System.Windows.Forms.Padding(4);
            this.chkCondebug.Name = "chkCondebug";
            this.chkCondebug.Size = new System.Drawing.Size(113, 27);
            this.chkCondebug.TabIndex = 30;
            this.chkCondebug.Text = "Log Console";
            this.chkCondebug.UseVisualStyleBackColor = true;
            //
            //chkToolsMode
            //
            this.chkToolsMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkToolsMode.Location = new System.Drawing.Point(132, 80);
            this.chkToolsMode.Margin = new System.Windows.Forms.Padding(4);
            this.chkToolsMode.Name = "chkToolsMode";
            this.chkToolsMode.Size = new System.Drawing.Size(113, 27);
            this.chkToolsMode.TabIndex = 39;
            this.chkToolsMode.Tag = "-tools";
            this.chkToolsMode.Text = "Tools Mode";
            this.chkToolsMode.UseVisualStyleBackColor = true;
            //
            //chkToConsole
            //
            this.chkToConsole.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkToConsole.Location = new System.Drawing.Point(253, 80);
            this.chkToConsole.Margin = new System.Windows.Forms.Padding(4);
            this.chkToConsole.Name = "chkToConsole";
            this.chkToConsole.Size = new System.Drawing.Size(133, 27);
            this.chkToConsole.TabIndex = 40;
            this.chkToConsole.Tag = "-toconsole";
            this.chkToConsole.Text = "Open Console";
            this.chkToConsole.UseVisualStyleBackColor = true;
            //
            //Panel1
            //
            this.Panel1.Controls.Add(this.txtOther);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Location = new System.Drawing.Point(11, 115);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(425, 27);
            this.Panel1.TabIndex = 41;
            //
            //txtOther
            //
            this.txtOther.Location = new System.Drawing.Point(64, 0);
            this.txtOther.Margin = new System.Windows.Forms.Padding(4);
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(360, 22);
            this.txtOther.TabIndex = 36;
            //
            //Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(5, 7);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(61, 17);
            this.Label1.TabIndex = 35;
            this.Label1.Text = "Other(s)";
            //
            //frmAdvancedStartup
            //
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(536, 190);
            this.Controls.Add(this.FlowLayoutPanel2);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAdvancedStartup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced Play Options";
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.FlowLayoutPanel2.ResumeLayout(false);
            this.pnlMapArg.ResumeLayout(false);
            this.pnlMapArg.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel2;
        internal System.Windows.Forms.Panel pnlMapArg;
        internal System.Windows.Forms.ComboBox cboMap;
        internal System.Windows.Forms.CheckBox chkMap;
        internal System.Windows.Forms.CheckBox chkNoIntro;
        internal System.Windows.Forms.CheckBox chkWindowed;
        internal System.Windows.Forms.CheckBox chkNoBorder;
        internal System.Windows.Forms.CheckBox chkDeveloper;
        internal System.Windows.Forms.CheckBox chkAllowDebug;
        internal System.Windows.Forms.CheckBox chkCondebug;
        internal System.Windows.Forms.CheckBox chkToolsMode;
        internal System.Windows.Forms.CheckBox chkToConsole;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TextBox txtOther;
        internal System.Windows.Forms.Label Label1;
    }

}