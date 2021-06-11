using System.Drawing;
using System.Windows.Forms;
using LibModMaker;
using System.IO;

namespace ModMaker
{
    /// <summary>
    /// User interface for editing chapters in single player games/mods
    /// </summary>
    public partial class ChaptersForm
    {
        public SourceMod Game;

        private int _SelectedChapter = -1;
        public int SelectedChapter {
            get { return _SelectedChapter; }
            set {
                if (_SelectedChapter > -1) GatherChanges();

                _SelectedChapter = value;

                ChapterTool.Chapter Chapter = ListChapters.Items[_SelectedChapter].Tag as ChapterTool.Chapter;
                txtMapPath.Text = Chapter.Map;
                txtTitle.Text = Chapter.Title;
                txtThumbnailPath.Text = Chapter.Thumbnail;
            }
        }

        public ChapterTool.ChapterList Chapters {
            get {
                GatherChanges();

                ChapterTool.ChapterList Result = new ChapterTool.ChapterList();

                foreach (ListViewItem Item in ListChapters.Items) {
                    Result.Add(Item.Tag as ChapterTool.Chapter);
                }

                return Result;
            }
            set {
                ListChapters.Items.Clear();
                ChapterImages.Images.Clear();

                if (value == null)
                    return;

                _SelectedChapter = -1;
                ListChapters.LargeImageList = ChapterImages;

                using (LibModMaker.VTFConverter Converter = new LibModMaker.VTFConverter()) {
                    foreach (ChapterTool.Chapter X in value) {
                        ListViewItem ChapterItem = ListChapters.Items.Add(X.Title);

                        if (X.Thumbnail != null) {
                            Bitmap ThummbailImage = ChapterTool.GetThumbnailBitmap(X.Thumbnail);

                            if (ThummbailImage != null) {
                                ChapterImages.Images.Add(X.Title,ThummbailImage);
                                ChapterItem.ImageKey = X.Title;
                            }
                        }

                        ChapterItem.Tag = X;
                    }
                }

                if (value.Count > 0)
                    SelectedChapter = 0;
            }
        }

        public ChaptersForm()
        {
            InitializeComponent();
            this.Load += frmChapters_Load;
            ListChapters.Resize += ListChapters_Resize;
            btnNew.Click += btnNew_Click;
            btnBrowseImage.Click += btnBrowseImage_Click;
            btnBrowseMap.Click += btnBrowseMap_Click;
            txtThumbnailPath.TextChanged += txtThumbnailPath_TextChanged;
            ListChapters.ItemActivate += ListChapters_ItemActivate;
        }

        // ERROR: Handles clauses are not supported in C#
        private void frmChapters_Load(object sender, System.EventArgs e)
        {
            Icon = Properties.Resources.Chapter;
        }

        private void ListChapters_Resize(object sender, System.EventArgs e)
        {
            RefreshChapterListBackground();
        }

        /// <summary>
        /// Draws a gradiented background to the list of mods
        /// </summary>
        /// <remarks>Trying to look like the Steam Library</remarks>
        void RefreshChapterListBackground()
        {
            if (ListChapters.Size.Width * ListChapters.Size.Height == 0)
                return;

            GraphicsUnit pixel = GraphicsUnit.Pixel;
            Bitmap Buffer = new Bitmap(ListChapters.Width, ListChapters.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics Gfx = Graphics.FromImage(Buffer);

            System.Drawing.Drawing2D.LinearGradientBrush Grad = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(0, 0), new Point(0, ListChapters.Height), Color.FromArgb(255, 16, 16, 16), Color.FromArgb(255, 48, 48, 48));

            Gfx.FillRectangle(Grad, Buffer.GetBounds(ref pixel));
            Gfx.Flush();
            ListChapters.BackgroundImage = Buffer;
        }

        private void btnNew_Click(System.Object sender, System.EventArgs e)
        {
            int temp = ListChapters.Items.Count + 1;

            ChapterTool.Chapter Chapter = new ChapterTool.Chapter {
                Index = temp,
                Title = "Chapter " + temp.ToString()
            };

            ListViewItem ChapterItem = ListChapters.Items.Add(Chapter.Title);

            ChapterItem.Tag = Chapter;
            ChapterItem.Selected = true;
        }

        private void btnBrowseImage_Click(System.Object sender, System.EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog {
                Title = "Select Thumbnail Image",
                Filter = "Images (*.bmp;*.jpg;*.gif;*.png;*.tga;*.vtf)|*.bmp;*.jpg;*.gif;*.png;*.tga;*.vtf",
                CheckFileExists = true
            };

            if (Game != null) {
                Dialog.CustomPlaces.Add(Game.InstallPath);

                if (Game.SourcePath != null) {
                    Dialog.CustomPlaces.Add(Game.SourcePath);
                    Dialog.InitialDirectory = Path.Combine(Game.SourcePath, "materialsrc/vgui/chapters");
                }
            }

            if (txtThumbnailPath.Text.Length > 0) {
                Dialog.InitialDirectory = Path.GetDirectoryName(txtThumbnailPath.Text);
                Dialog.FileName = Path.GetFileName(txtThumbnailPath.Text);
            }

            if (Dialog.ShowDialog() != DialogResult.OK) return;

            txtThumbnailPath.Text = Dialog.FileName;
        }

        private void btnBrowseMap_Click(System.Object sender, System.EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog {
                Title = "Select chapter start map",
                Filter = "Maps (*.bsp)|*.bsp",
                CheckFileExists = true
            };

            if (Game != null) {
                Dialog.CustomPlaces.Add(Game.InstallPath);
                Dialog.InitialDirectory = Path.Combine(Game.InstallPath, "maps");
            }

            if (txtMapPath.Text.Length > 0) {
                Dialog.InitialDirectory = Path.GetDirectoryName(txtMapPath.Text);
                Dialog.FileName = Path.GetFileName(txtMapPath.Text);
            }

            if (Dialog.ShowDialog() != DialogResult.OK)
                return;

            txtMapPath.Text = Dialog.FileName;
        }

        private void txtThumbnailPath_TextChanged(object sender, System.EventArgs e)
        {
            if (!File.Exists(txtThumbnailPath.Text)) return;

            ChapterImages.Images.Add(ChapterTool.GetThumbnailBitmap(txtThumbnailPath.Text));
        }

        private void ListChapters_ItemActivate(object sender, System.EventArgs e)
        {
            SelectedChapter = ListChapters.SelectedIndices[0];
        }

        public void GatherChanges()
        {
            ChapterTool.Chapter OldChapter = ListChapters.Items[_SelectedChapter].Tag as ChapterTool.Chapter;
            OldChapter.Map = Path.GetFileNameWithoutExtension(txtMapPath.Text);
            OldChapter.Title = txtTitle.Text;
            OldChapter.Thumbnail = txtThumbnailPath.Text;
            ListChapters.Items[_SelectedChapter].Text = OldChapter.Title;
        }
    } //class

}