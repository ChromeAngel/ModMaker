namespace ModMaker
{


    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class ChaptersForm : System.Windows.Forms.Form
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
            this.components = new System.ComponentModel.Container();
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.ChapterImages = new System.Windows.Forms.ImageList(this.components);
            this.SplitList = new System.Windows.Forms.SplitContainer();
            this.ListChapters = new System.Windows.Forms.ListView();
            this.SplitProperties = new System.Windows.Forms.SplitContainer();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.txtMapPath = new System.Windows.Forms.TextBox();
            this.btnBrowseMap = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.txtThumbnailPath = new System.Windows.Forms.TextBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.FlowLayoutPanel1.SuspendLayout();
            this.SplitList.Panel1.SuspendLayout();
            this.SplitList.Panel2.SuspendLayout();
            this.SplitList.SuspendLayout();
            this.SplitProperties.Panel1.SuspendLayout();
            this.SplitProperties.Panel2.SuspendLayout();
            this.SplitProperties.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            //
            //FlowLayoutPanel1
            //
            this.FlowLayoutPanel1.Controls.Add(this.btnCancel);
            this.FlowLayoutPanel1.Controls.Add(this.btnOK);
            this.FlowLayoutPanel1.Controls.Add(this.btnNew);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(0, 321);
            this.FlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(635, 38);
            this.FlowLayoutPanel1.TabIndex = 0;
            //
            //btnCancel
            //
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(526, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 28);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            //btnOK
            //
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(413, 4);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(105, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            //btnNew
            //
            this.btnNew.Location = new System.Drawing.Point(300, 4);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(105, 28);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New Chapter";
            this.btnNew.UseVisualStyleBackColor = true;
            //
            //ChapterImages
            //
            this.ChapterImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.ChapterImages.ImageSize = new System.Drawing.Size(152, 86);
            this.ChapterImages.TransparentColor = System.Drawing.Color.Transparent;
            //
            //SplitList
            //
            this.SplitList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitList.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitList.Location = new System.Drawing.Point(0, 0);
            this.SplitList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SplitList.Name = "SplitList";
            this.SplitList.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //
            //SplitList.Panel1
            //
            this.SplitList.Panel1.Controls.Add(this.ListChapters);
            //
            //SplitList.Panel2
            //
            this.SplitList.Panel2.Controls.Add(this.SplitProperties);
            this.SplitList.Size = new System.Drawing.Size(635, 321);
            this.SplitList.SplitterDistance = 207;
            this.SplitList.SplitterWidth = 5;
            this.SplitList.TabIndex = 1;
            this.SplitList.TabStop = false;
            //
            //ListChapters
            //
            this.ListChapters.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListChapters.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.ListChapters.BackColor = System.Drawing.Color.DimGray;
            this.ListChapters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListChapters.ForeColor = System.Drawing.Color.White;
            this.ListChapters.LargeImageList = this.ChapterImages;
            this.ListChapters.Location = new System.Drawing.Point(0, 0);
            this.ListChapters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ListChapters.MultiSelect = false;
            this.ListChapters.Name = "ListChapters";
            this.ListChapters.ShowGroups = false;
            this.ListChapters.Size = new System.Drawing.Size(635, 207);
            this.ListChapters.TabIndex = 2;
            this.ListChapters.TileSize = new System.Drawing.Size(200, 200);
            this.ListChapters.UseCompatibleStateImageBehavior = false;
            //
            //SplitProperties
            //
            this.SplitProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitProperties.Location = new System.Drawing.Point(0, 0);
            this.SplitProperties.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SplitProperties.Name = "SplitProperties";
            //
            //SplitProperties.Panel1
            //
            this.SplitProperties.Panel1.Controls.Add(this.Label3);
            this.SplitProperties.Panel1.Controls.Add(this.Label2);
            this.SplitProperties.Panel1.Controls.Add(this.Label1);
            //
            //SplitProperties.Panel2
            //
            this.SplitProperties.Panel2.Controls.Add(this.Panel3);
            this.SplitProperties.Panel2.Controls.Add(this.Panel2);
            this.SplitProperties.Panel2.Controls.Add(this.Panel1);
            this.SplitProperties.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.SplitProperties.Size = new System.Drawing.Size(635, 109);
            this.SplitProperties.SplitterDistance = 121;
            this.SplitProperties.SplitterWidth = 5;
            this.SplitProperties.TabIndex = 0;
            this.SplitProperties.TabStop = false;
            //
            //Label3
            //
            this.Label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label3.Location = new System.Drawing.Point(0, 68);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(121, 37);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Start Map";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //Label2
            //
            this.Label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label2.Location = new System.Drawing.Point(0, 31);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(121, 37);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Thumbnail Image";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //Label1
            //
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.Label1.Size = new System.Drawing.Size(121, 31);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Title";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //Panel3
            //
            this.Panel3.Controls.Add(this.txtMapPath);
            this.Panel3.Controls.Add(this.btnBrowseMap);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel3.Location = new System.Drawing.Point(0, 74);
            this.Panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Panel3.Name = "Panel3";
            this.Panel3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 9);
            this.Panel3.Size = new System.Drawing.Size(501, 37);
            this.Panel3.TabIndex = 2;
            //
            //txtMapPath
            //
            this.txtMapPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMapPath.Location = new System.Drawing.Point(0, 0);
            this.txtMapPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMapPath.Name = "txtMapPath";
            this.txtMapPath.Size = new System.Drawing.Size(401, 22);
            this.txtMapPath.TabIndex = 2;
            //
            //btnBrowseMap
            //
            this.btnBrowseMap.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBrowseMap.Location = new System.Drawing.Point(401, 0);
            this.btnBrowseMap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowseMap.Name = "btnBrowseMap";
            this.btnBrowseMap.Size = new System.Drawing.Size(100, 28);
            this.btnBrowseMap.TabIndex = 1;
            this.btnBrowseMap.Text = "Browse";
            this.btnBrowseMap.UseVisualStyleBackColor = true;
            //
            //Panel2
            //
            this.Panel2.Controls.Add(this.txtThumbnailPath);
            this.Panel2.Controls.Add(this.btnBrowseImage);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(0, 37);
            this.Panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 9);
            this.Panel2.Size = new System.Drawing.Size(501, 37);
            this.Panel2.TabIndex = 1;
            //
            //txtThumbnailPath
            //
            this.txtThumbnailPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtThumbnailPath.Location = new System.Drawing.Point(0, 0);
            this.txtThumbnailPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtThumbnailPath.Name = "txtThumbnailPath";
            this.txtThumbnailPath.Size = new System.Drawing.Size(401, 22);
            this.txtThumbnailPath.TabIndex = 1;
            //
            //btnBrowseImage
            //
            this.btnBrowseImage.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBrowseImage.Location = new System.Drawing.Point(401, 0);
            this.btnBrowseImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(100, 28);
            this.btnBrowseImage.TabIndex = 0;
            this.btnBrowseImage.Text = "Browse";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            //
            //Panel1
            //
            this.Panel1.Controls.Add(this.txtTitle);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(501, 37);
            this.Panel1.TabIndex = 0;
            //
            //txtTitle
            //
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTitle.Location = new System.Drawing.Point(0, 0);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(501, 22);
            this.txtTitle.TabIndex = 0;
            //
            //frmChapters
            //
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(635, 359);
            this.Controls.Add(this.SplitList);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmChapters";
            this.Text = "Chapter Maker";
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.SplitList.Panel1.ResumeLayout(false);
            this.SplitList.Panel2.ResumeLayout(false);
            this.SplitList.ResumeLayout(false);
            this.SplitProperties.Panel1.ResumeLayout(false);
            this.SplitProperties.Panel2.ResumeLayout(false);
            this.SplitProperties.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnNew;
        internal System.Windows.Forms.ImageList ChapterImages;
        internal System.Windows.Forms.SplitContainer SplitList;
        internal System.Windows.Forms.ListView ListChapters;
        internal System.Windows.Forms.SplitContainer SplitProperties;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TextBox txtMapPath;
        internal System.Windows.Forms.Button btnBrowseMap;
        internal System.Windows.Forms.TextBox txtThumbnailPath;
        internal System.Windows.Forms.Button btnBrowseImage;
        internal System.Windows.Forms.TextBox txtTitle;
    }

}