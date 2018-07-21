using System.Windows.Forms;
using System.IO;

namespace ModMaker
{
    /// <summary>
    /// Part of the weapon editor UI, enables picking a sound script for one of the events a weapon can do (firing, reloading etc.)
    /// </summary>
    public partial class WeaponSoundPickerControl
    {
        public string ModInstallFolder { get; set; }

        public string SoundPath
        {
            get
            {
                if (DesignMode) return string.Empty;

                return txtPath.Text;
            }
            set
            {
                if (DesignMode) return;

                txtPath.Text = value;
            }
        }

        public WeaponSoundPickerControl()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(System.Object sender, System.EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog
            {
                Title = "Select sound",
                Filter = "Uncompressed Sound (*.wav)|*.wav|Compressed Sound (*.mp3)|*.mp3",
                DefaultExt = ".wav"
            };

            if (SoundPath.Length > 0)
            {
                string FullPath = Path.Combine(ModInstallFolder, SoundPath);

                Dialog.InitialDirectory = Path.GetDirectoryName(FullPath);
                Dialog.FileName = Path.GetFileName(FullPath);
            }

            if (Dialog.ShowDialog() != DialogResult.OK)
                return;

            if (Dialog.FileName.StartsWith(ModInstallFolder))
            {
                SoundPath = Dialog.FileName.Substring(ModInstallFolder.Length);
            }
            else
            {
                SoundPath = Dialog.FileName;
            }
        }
    }

}