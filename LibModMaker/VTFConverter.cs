using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace LibModMaker
{

    /// <summary>
    /// Helper class for convertign Valve Texture Files (VTFs) to other image formats
    /// </summary>
    public class VTFConverter : IDisposable
    {

        private List<string> TempFiles = new List<string>();

        private byte ConversionStatus = 0;

        public string SDKPath = null;

        public VTFConverter()
        {
        }

        public VTFConverter(string SDKPath)
        {
            this.SDKPath = SDKPath;
        }

        public Bitmap ToBitmap(string FilePath)
        {
            if (FilePath == null)
                return null;

            FilePath = FilePath.Replace('/', Path.DirectorySeparatorChar)
    .
            Replace("\\\\", Path.DirectorySeparatorChar.ToString());

            string Ext = Path.GetExtension(FilePath);

            switch (Ext)
            {
                case ".bmp":
                case ".jpg":
                case ".gif":
                case ".png":
                    return new Bitmap(FilePath);
            }

            if (Ext != ".vtf") return null;

            string VTFBinFolder = Path.Combine(Environment.CurrentDirectory, "VTFBin\\");
            string TempFolder = VTFBinFolder.TrimEnd('\\');
            string ResultFile = Path.Combine(TempFolder, Path.GetFileNameWithoutExtension(FilePath) + ".png");

            if (File.Exists(ResultFile)) File.Delete(ResultFile);

            ConversionStatus = 0;

            using (System.Diagnostics.Process VTFCmd = new System.Diagnostics.Process())
            {
                VTFCmd.StartInfo.FileName = Path.Combine(VTFBinFolder, "VTFCmd.exe");
                VTFCmd.StartInfo.Arguments = String.Format(
                    "-file \"{0}\" -output \"{1}\" -exportformat \"png\"",
                    FilePath,
                    TempFolder
                );
                VTFCmd.StartInfo.WorkingDirectory = VTFBinFolder;
                VTFCmd.StartInfo.RedirectStandardOutput = true;
                VTFCmd.StartInfo.CreateNoWindow = true;
                VTFCmd.StartInfo.UseShellExecute = false;

                VTFCmd.Start();
                VTFCmd.WaitForExit();
                string Ouptut = VTFCmd.StandardOutput.ReadToEnd();

                Debug.WriteLine(Ouptut);

                if (Ouptut.Contains("0/1 files completed"))
                    ConversionStatus = 1;
                if (Ouptut.Contains("1/1 files completed"))
                    ConversionStatus = 2;
            }

            if (ConversionStatus != 2) return null;
            //Failed

            TempFiles.Add(ResultFile);

            return new Bitmap(ResultFile);
        }

        public string ToVTF(Bitmap Bitmap)
        {
            if (Bitmap == null)
                return null;

            TGA MyTGA = new TGA(Bitmap);
            string TempFileName = Path.GetTempFileName();

            try
            {
                TempFiles.Add(TempFileName);
                MyTGA.Save(TempFileName);

                return TgaToVTF(TempFileName);
            }
            catch (ApplicationException)
            {
                return null;
            }
            finally
            {
                File.Delete(TempFileName);
            }
        }

        public string ToVTF(string FilePath)
        {
            if (FilePath == null)
                return null;
            string Ext = Path.GetExtension(FilePath);

            if (!(Ext == ".tga" || Ext == ".psd"))
            {
                FilePath = ConvertToTga(FilePath, Ext);

                if (FilePath == null)
                    return null;
            }

            try
            {
                return TgaToVTF(FilePath);
            }
            catch (ApplicationException)
            {
                return null;
            }
        }

        private string TgaToVTF(string FilePath)
        {
            if (FilePath == null) return null;

            System.Diagnostics.Process Vtex = new System.Diagnostics.Process();
            string ResultFile = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(FilePath));

            Vtex.StartInfo.FileName = "vtex.exe";
            Vtex.StartInfo.Arguments = String.Format(
                "-outdir \"{0}\" -mkdir -quiet -shader UnlitGeneric \"{1}\"", 
                ResultFile, 
                FilePath 
            );
            Vtex.StartInfo.CreateNoWindow = true;
            Vtex.StartInfo.WorkingDirectory = SDKPath;
            Vtex.StartInfo.UseShellExecute = false;

            Vtex.Start();
            Vtex.WaitForExit();

            if (!File.Exists(ResultFile + ".vtf"))
                throw new ApplicationException("Conversion to VTF failed");

            return ResultFile + ".vtf";
        }

        public static string ConvertToTga(string SourceFile, string Ext)
        {
            string[] SupportedFormats =
            {
                ".bmp",
                ".jpg",
                ".gif",
                ".png"
            };

            if (Array.IndexOf(SupportedFormats, Ext) == -1)
                return null;

            Bitmap Bitmap = new Bitmap(SourceFile);
            TGA TGA = new TGA(Bitmap);
            string TGAPath = Path.Combine(Path.GetTempPath(),
                Path.GetFileNameWithoutExtension(SourceFile) + ".tga");

            if (File.Exists(TGAPath))
                File.Delete(TGAPath);

            TGA.Save(TGAPath);

            return TGAPath;
        }

        // To detect redundant calls
        private bool disposedValue;

        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    foreach (string TempFile in TempFiles)
                    {
                        try
                        {
                            File.Delete(TempFile);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }

                TempFiles.Clear();
                TempFiles = null;
            }
            this.disposedValue = true;
        }

        // This code added by Visual Basic to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }//end class

}