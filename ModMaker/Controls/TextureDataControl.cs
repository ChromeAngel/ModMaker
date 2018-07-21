using System.Windows.Forms;
using LibModMaker;

namespace ModMaker
{
    /// <summary>
    /// part of the Weapon Editor UI ... something to do with HUD textures IO think
    /// </summary>
    public partial class TextureDataControl
    {

        private KeyValues _Data;
        public string Key { get; set; }
        public SourceMod Game { get; set; }

        public KeyValues Data
        {
            get
            {
                if (_Data == null)
                    _Data = new KeyValues(Key);

                _Data.Name = Key;

                return _Data;
            }
            set
            {
                _Data = value;

                if (_Data == null)
                {
                    this.Value = "";
                }
                else
                {
                    Key = _Data.Name;
                    this.Value = _Data.ToString();
                }
            }
        }

        public string Value
        {
            get { return txtValue.Text; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    txtValue.Text = "";
                }
                else
                {
                    txtValue.Text =
                        value.Replace("\t", "")
                            .Replace("\r\n", "")
                            .Replace("\r", "");
                }
            }
        }

        public TextureDataControl()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(System.Object sender, System.EventArgs e)
        {
            frmTextureData Dialog = new frmTextureData
            {
                Game = Game,
                TextureData = _Data
            };

            if (Dialog.ShowDialog() != DialogResult.OK)
                return;

            Data = Dialog.TextureData;
        }

        private void txtValue_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (txtValue.Text.Length == 0)
                _Data = null;
        }
    }

}