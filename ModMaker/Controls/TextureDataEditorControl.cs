using System.Windows.Forms;
using LibModMaker;
using System.Drawing;
using System.IO;

namespace ModMaker
{
    /// <summary>
    /// Control for editing HUD textures/sprites
    /// </summary>
    public partial class TextureDataEditorControl
    {
        public TextureDataEditorControl()
        {
            InitializeComponent();
        }

        private KeyValues _TextureData;
        public SourceMod Game { get; set; }

        public KeyValues TextureData
        {
            get
            {
                if (_TextureData == null)
                    _TextureData = new KeyValues();

                _TextureData.Keys.Clear();

                if (radFont.Checked)
                {
                    _TextureData.SetValue("font", txtFontFace.Text);
                    _TextureData.SetValue("character", txtChar.Text);
                }
                else
                {
                    _TextureData.SetValue("file", txtFile.Text);
                    _TextureData.SetValue("x", udX.Value);
                    _TextureData.SetValue("y", udY.Value);
                    _TextureData.SetValue("width", udWide.Value);
                    _TextureData.SetValue("height", udTall.Value);
                }

                return _TextureData;
            }
            set
            {
                _TextureData = value;

                if (_TextureData == null)
                    return;

                string FontFile = _TextureData.GetString("file", "::NO FILE::");

                if (FontFile == "::NO FILE::")
                {
                    radFont.Checked = true;
                    radImage.Checked = false;
                    txtFontFace.Text = _TextureData.GetString("font");
                    txtChar.Text = _TextureData.GetString("character");
                }
                else
                {
                    radFont.Checked = false;
                    radImage.Checked = true;
                    vtfPreview = null;
                    txtFile.Text = FontFile;
                    udX.Value = _TextureData.GetInt("x");
                    udY.Value = _TextureData.GetInt("y");
                    udWide.Value = _TextureData.GetInt("width", 16);
                    udTall.Value = _TextureData.GetInt("height", 16);
                }
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void radFont_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            pnlFont.Enabled = radFont.Checked;
            pnlImage.Enabled = !radFont.Checked;
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnEdit_Click(System.Object sender, System.EventArgs e)
        {
            string FilePath;
            OpenFileDialog Dialog = new OpenFileDialog
            {
                Title = "Select Material",
                Filter = "Valve Materials (*.vmt)|*.vmt",
                DefaultExt = ".vmt",
                FileName = Path.GetFileName(txtFile.Text)
            };

            if (Game != null)
            {
                FilePath = Path.Combine(Game.InstallPath, "materials");
                FilePath = Path.Combine(FilePath, txtFile.Text);
                Dialog.InitialDirectory = Path.GetDirectoryName(FilePath);
            }

            if (Dialog.ShowDialog() != DialogResult.OK)
                return;

            if (Game == null)
            {
                FilePath = Dialog.FileName;
            }
            else
            {
                FilePath = Path.Combine(Game.InstallPath, "materials");

                if (Dialog.FileName.StartsWith(FilePath))
                {
                    FilePath = Dialog.FileName.Substring(FilePath.Length);
                }
                else
                {
                    if (Dialog.FileName.StartsWith(Game.InstallPath))
                    {
                        FilePath = Dialog.FileName.Substring(Game.InstallPath.Length);
                    }
                    else
                    {
                        FilePath = Dialog.FileName;
                    }
                }
            }

            if (FilePath.EndsWith(".vmt"))
                FilePath = FilePath.Substring(0, FilePath.Length - 4);

            FilePath = FilePath.Trim(Path.DirectorySeparatorChar).Trim(Path.AltDirectorySeparatorChar);

            txtFile.Text = FilePath;
        }

        // ERROR: Handles clauses are not supported in C#
        private void txtFile_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFile.Text))
                return;

            string MaterialPath = txtFile.Text;
            string Ext = Path.GetExtension(MaterialPath);

            if (!(string.IsNullOrEmpty(Ext) || Ext == ".vmt"))
                return;
            if (string.IsNullOrEmpty(Ext))
                MaterialPath += ".vmt";
            //no extension implies .VMT

            MaterialPath = Path.Combine(Path.Combine(Game.InstallPath, "materials"), MaterialPath);
            //expand out to the full game material path

            if (!File.Exists(MaterialPath))
                return;

            KeyValues Material = KeyValues.LoadFile(MaterialPath);

            if (Material == null)
                return;

            string BaseTexturePath = Material.GetString("$basetexture");

            if (BaseTexturePath.Length == 0)
                return;
            if (!BaseTexturePath.EndsWith(".vtf"))
                BaseTexturePath += ".vtf";
            //no extension implies .VTF

            BaseTexturePath = Path.Combine(Path.Combine(Game.InstallPath, "materials"), BaseTexturePath);
            //expand out to the full game material path

            if (!File.Exists(BaseTexturePath))
                return;

            using (VTFConverter Converter = new VTFConverter())
            {
                vtfPreview = Converter.ToBitmap(BaseTexturePath);
            }
        }


        private Bitmap vtfPreview = null;
        // ERROR: Handles clauses are not supported in C#
        private void picPreview_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            udX.Value = e.X;
            udY.Value = e.Y;
        }

        // ERROR: Handles clauses are not supported in C#
        private void picPreview_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            udWide.Value = e.X - udX.Value;
            udTall.Value = e.Y - udY.Value;
        }

        public void RefreshPreview()
        {
            if (vtfPreview == null)
                return;

            Bitmap PreviewImage = vtfPreview.Clone() as Bitmap;
            Graphics Gfx = Graphics.FromImage(PreviewImage);
            SolidBrush Brush = new SolidBrush(Color.FromArgb(64, SystemColors.Highlight));

            Gfx.FillRectangle(Brush, (float)udX.Value, (float)udY.Value, (float)udWide.Value, (float)udTall.Value);
            Gfx.Flush();

            picPreview.Image = PreviewImage;
        }

        // ERROR: Handles clauses are not supported in C#
        private void ud_ValueChanged(object sender, System.EventArgs e)
        {
            RefreshPreview();
        }
    }

}