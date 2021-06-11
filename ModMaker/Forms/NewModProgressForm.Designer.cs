namespace ModMaker
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class NewModProgressForm : System.Windows.Forms.Form
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblConfigured = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.ProgressUnzip = new System.Windows.Forms.ProgressBar();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.ProgressDownload = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoEllipsis = true;
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(9, 9);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(410, 39);
            this.TitleLabel.TabIndex = 5;
            this.TitleLabel.Text = "Please wait your mod is being set up.";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(9, 48);
            this.SplitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.Label3);
            this.SplitContainer1.Panel1.Controls.Add(this.Label2);
            this.SplitContainer1.Panel1.Controls.Add(this.Label1);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.lblConfigured);
            this.SplitContainer1.Panel2.Controls.Add(this.Panel2);
            this.SplitContainer1.Panel2.Controls.Add(this.Panel1);
            this.SplitContainer1.Size = new System.Drawing.Size(410, 110);
            this.SplitContainer1.SplitterDistance = 108;
            this.SplitContainer1.SplitterWidth = 5;
            this.SplitContainer1.TabIndex = 6;
            this.SplitContainer1.TabStop = false;
            // 
            // Label3
            // 
            this.Label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label3.Location = new System.Drawing.Point(0, 74);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(108, 37);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "Progress";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label2
            // 
            this.Label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label2.Location = new System.Drawing.Point(0, 37);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(108, 37);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Unzipped";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(108, 37);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Downloaded";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblConfigured
            // 
            this.lblConfigured.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConfigured.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigured.Location = new System.Drawing.Point(0, 74);
            this.lblConfigured.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConfigured.Name = "lblConfigured";
            this.lblConfigured.Size = new System.Drawing.Size(297, 22);
            this.lblConfigured.TabIndex = 2;
            this.lblConfigured.Text = "Waiting for GitHub...";
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.ProgressUnzip);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(0, 37);
            this.Panel2.Margin = new System.Windows.Forms.Padding(4);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(297, 37);
            this.Panel2.TabIndex = 1;
            // 
            // ProgressUnzip
            // 
            this.ProgressUnzip.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProgressUnzip.Location = new System.Drawing.Point(0, 0);
            this.ProgressUnzip.Margin = new System.Windows.Forms.Padding(4);
            this.ProgressUnzip.Name = "ProgressUnzip";
            this.ProgressUnzip.Size = new System.Drawing.Size(297, 28);
            this.ProgressUnzip.TabIndex = 0;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.ProgressDownload);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(297, 37);
            this.Panel1.TabIndex = 0;
            // 
            // ProgressDownload
            // 
            this.ProgressDownload.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProgressDownload.Location = new System.Drawing.Point(0, 0);
            this.ProgressDownload.Margin = new System.Windows.Forms.Padding(4);
            this.ProgressDownload.Name = "ProgressDownload";
            this.ProgressDownload.Size = new System.Drawing.Size(297, 28);
            this.ProgressDownload.TabIndex = 0;
            // 
            // NewModProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 167);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.TitleLabel);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NewModProgressForm";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.Text = "Making New Mod - Mod Maker";
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.Label TitleLabel;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lblConfigured;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.ProgressBar ProgressUnzip;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.ProgressBar ProgressDownload;
    }

}