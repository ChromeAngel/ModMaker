using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Net.Http;

namespace LibModMaker
{
    /// <summary>
    /// Impliments the TGA image format
    /// </summary>
    /// <remarks>Mainly used for writing out TGAs as it does nto support all the many and varied formats of TGA in the wild</remarks>
    public class TGA
    {

        //See http://www.gamers.org/dEngine/quake3/TGA.txt

        private TGA_Header Header;
        private TGA_Image Image;
        private TGA_Developer Developer;
        private TGA_Extensions Extension;

        private TGA_Footer Footer;

        public Bitmap Bitmap
        {
            get
            {
                if (Image == null)
                {
                    return null;
                }
                else
                {
                    return Image.MyBitmap;
                }
            }
            set
            {
                Header = new TGA_Header(this, value);
                Image = new TGA_Image(this, value);
                Developer = new TGA_Developer(this, value);
                Extension = new TGA_Extensions(this, value);
                Footer = new TGA_Footer(this, value);
            }
        }

        public void Save(string Filename)
        {
            if (string.IsNullOrEmpty(Filename)) throw new ArgumentException("Filename is null or empty", "Filename");

            byte[] TempBytes;
            using (FileStream F = new FileStream(Filename, FileMode.Create))
            {
                TempBytes = Header.Save();
                F.Write(TempBytes, 0, TempBytes.Length);
                TempBytes = Image.Save();
                F.Write(TempBytes, 0, TempBytes.Length);
                TempBytes = Developer.Save();
                F.Write(TempBytes, 0, TempBytes.Length);
                TempBytes = Extension.Save();
                F.Write(TempBytes, 0, TempBytes.Length);
                TempBytes = Footer.Save();
                F.Write(TempBytes, 0, TempBytes.Length);
            }
        }


        public TGA()
        {
        }

        public TGA(Bitmap SourceBitmap)
        {
            Header = new TGA_Header(this, SourceBitmap);
            Image = new TGA_Image(this, SourceBitmap);
            Developer = new TGA_Developer(this, SourceBitmap);
            Extension = new TGA_Extensions(this, SourceBitmap);
            Footer = new TGA_Footer(this, SourceBitmap);
        }

        public TGA(ref string Filename)
        {
            if (!File.Exists(Filename))
                return;

            FileStream F = new FileStream(Filename, FileMode.Open);
            Header = new TGA_Header(this, F);
            Image = new TGA_Image(this, F);
            Developer = new TGA_Developer(this, F);
            Extension = new TGA_Extensions(this, F);
        }

        internal class TGA_Section
        {

            public TGA TGA;

            internal TGA_Section(LibModMaker.TGA NewTGA)
            {
                TGA = NewTGA;
            }

            internal TGA_Section(LibModMaker.TGA NewTGA, Bitmap SourceBitmap)
            {
                TGA = NewTGA;
            }

            internal TGA_Section(LibModMaker.TGA NewTGA, FileStream F)
            {
                TGA = NewTGA;
            }

            public virtual byte[] Save()
            {
                byte[] Work = new byte[0];
                return Work;
            }
        }

        internal interface ImageType
        {
            void Read(TGA_Header Header, Bitmap TargetBitmap, FileStream F);
        }

        internal class NoImageType : ImageType
        {
            void ImageType.Read(TGA_Header Header, System.Drawing.Bitmap TargetBitmap, FileStream F)
            {
            }
        }

        internal class ColorMappedImageType : ImageType
        {
            void ImageType.Read(TGA_Header Header, System.Drawing.Bitmap TargetBitmap, FileStream F)
            {
            }
        }

        internal class TrueColorImageType : ImageType
        {

            void ImageType.Read(TGA_Header Header, System.Drawing.Bitmap TargetBitmap,FileStream F)
            {
                int Index;
                int X;
                int Y;
                int ByteSize = (int) Header.ImageSpec.Width*(int) Header.ImageSpec.Height*
                               (int) Header.ImageSpec.BitsPerPixel/8;
                Color ThisPixel = Color.Transparent;
                byte[] Work = new byte[ByteSize];

                F.Read(Work, 0, ByteSize);
                Index = 0;

                for (Y = 0; Y <= (Header.ImageSpec.Height - 1); Y++)
                {
                    for (X = 0; X <= (Header.ImageSpec.Width - 1); X++)
                    {
                        if (Header.ImageSpec.BitsPerPixel == 24)
                        {
                            ThisPixel = Color.FromArgb(255, Work[Index], Work[Index + 1], Work[Index + 2]);
                            Index += 3;
                        }
                        if (Header.ImageSpec.BitsPerPixel == 32)
                        {
                            ThisPixel = Color.FromArgb(Work[Index], Work[Index + 1], Work[Index + 2], Work[Index + 3]);
                            Index += 4;
                        }

                        TargetBitmap.SetPixel(X, Y, ThisPixel);
                    }
                }
            }
        }

        internal class GreyscaleImageType : ImageType
        {
            void ImageType.Read(TGA_Header Header, System.Drawing.Bitmap TargetBitmap,FileStream F)
            {
            }
        }

        internal class RLE_ColorMappedImageType : ImageType
        {
            void ImageType.Read(TGA_Header Header, System.Drawing.Bitmap TargetBitmap,FileStream F)
            {
            }
        }

        internal class RLE_TrueColorImageType : ImageType
        {

            void ImageType.Read(TGA_Header Header, System.Drawing.Bitmap TargetBitmap,FileStream F)
            {
                int X;
                int Y;
                int R;
                Color ThisPixel = Color.Transparent;
                byte[] Work = new byte[5];
                bool IsRLE;

                const byte HighBit = 128;
                const byte HightBitMask = 127;

                X = 0;
                Y = 0;

                while (Y < Header.ImageSpec.Height)
                {
                    if (Header.ImageSpec.BitsPerPixel == 24)
                    {
                        F.Read(Work, 0, 4);
                        ThisPixel = Color.FromArgb(255, Work[1], Work[2], Work[3]);
                    }

                    if (Header.ImageSpec.BitsPerPixel == 32)
                    {
                        F.Read(Work, 0, 5);
                        ThisPixel = Color.FromArgb(Work[4], Work[1], Work[2], Work[3]);
                    }

                    IsRLE = (Work[0] & HighBit) == HighBit;
                    Work[0] = (byte)((Work[0] & HightBitMask) + 1);

                    if (IsRLE)
                    {
                        for (R = 1; R <= Work[0]; R++)
                        {
                            TargetBitmap.SetPixel(X, Y, ThisPixel);
                            X = X + 1;

                            if (X == Header.ImageSpec.Width)
                            {
                                Y = Y + 1;
                                X = 0;
                            }

                            if (Y == Header.ImageSpec.Height)
                                break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                    else
                    {
                        TargetBitmap.SetPixel(X, Y, ThisPixel);

                        for (R = 1; R <= Work[0]; R++)
                        {
                            X = X + 1;

                            if (X == Header.ImageSpec.Width)
                            {
                                Y = Y + 1;
                                X = 0;
                            }

                            if (Y == Header.ImageSpec.Height)
                                break; // TODO: might not be correct. Was : Exit For

                            if (Header.ImageSpec.BitsPerPixel == 24)
                            {
                                F.Read(Work, 0, 3);
                                ThisPixel = Color.FromArgb(255, Work[0], Work[1], Work[2]);
                            }
                            if (Header.ImageSpec.BitsPerPixel == 32)
                            {
                                F.Read(Work, 0, 4);
                                ThisPixel = Color.FromArgb(Work[3], Work[0], Work[1], Work[2]);
                            }

                            TargetBitmap.SetPixel(X, Y, ThisPixel);
                        }
                    }
                }
            }
        }

        internal class RLE_GreyscaleImageType : ImageType
        {
            void ImageType.Read(TGA_Header Header, System.Drawing.Bitmap TargetBitmap, FileStream F)
            {
            }
        }

        internal class TGA_Header : TGA_Section
        {
            private Bitmap MyBitmap;
            public byte IDLength = 0;
            public byte ColorMapLength = 0;
            public ImageTypes ImageType = ImageTypes.NoImage;

            public byte[] ColorMap =
            {
                0,
                0,
                0,
                0,
                0
            };

            public TGA_Header_Image_Specification ImageSpec;

            public enum ImageTypes
            {
                NoImage = 0,
                ColorMapped,
                TrueColor,
                Greyscale,
                RLE_ColorMapped = 9,
                RLE_TrueColor,
                RLE_Greyscale
            }

            internal TGA_Header(LibModMaker.TGA NewTGA, Bitmap SourceBitmap) : base(NewTGA, SourceBitmap)
            {
                MyBitmap = SourceBitmap;
                ImageType = ImageTypes.TrueColor;
                ImageSpec = new TGA_Header_Image_Specification(TGA, SourceBitmap);
            }

            internal TGA_Header(LibModMaker.TGA NewTGA, FileStream F) : base(NewTGA, F)
            {
                byte[] Work = new byte[2];

                F.Read(Work, 0, 3);
                IDLength = Work[0];
                ColorMapLength = Work[1];
                ImageType = (ImageTypes)Work[2];
                F.Read(ColorMap, 0, 5);
                ImageSpec = new TGA_Header_Image_Specification(TGA, F);
            }

            public override byte[] Save()
            {
                byte[] Work = new byte[18];

                //1 byte, length of the image ID
                //1 byte, use 0 for truecolor images
                //1 byte, image type (eg truecolor), set to 2
                //5 bytes, color map, set to 0
                //10 bytes, image specification
                Work[2] = 2;
                Array.Copy(ImageSpec.Save(), 0, Work, 8, 10);

                return Work;
            }

            internal ImageType GetImageType()
            {
                switch (ImageType)
                {
                    case ImageTypes.ColorMapped:
                        return new TGA.ColorMappedImageType();
                    case ImageTypes.TrueColor:
                        return new TGA.TrueColorImageType();
                    case ImageTypes.RLE_TrueColor:
                        return new TGA.RLE_TrueColorImageType();
                }

                return new TGA.NoImageType();
            }
        }

        internal class TGA_Header_Image_Specification : TGA_Section
        {
            public int X = 0;
            public int Y = 0;
            public int Width = 0;
            public int Height = 0;
            public byte BitsPerPixel = 0;

            public BitArray Descriptor;

            internal TGA_Header_Image_Specification(TGA NewTGA, Bitmap SourceBitmap) : base(NewTGA, SourceBitmap)
            {

                Width = SourceBitmap.Width;
                Height = SourceBitmap.Height;
                BitsPerPixel = (byte)Bitmap.GetPixelFormatSize(SourceBitmap.PixelFormat);
                //Descriptor.Set(0, False) '8 bit alpha channel
                //Descriptor.Set(1, False)
                //Descriptor.Set(2, False)
                //Descriptor.Set(3, False)
                //Descriptor.Set(4, False) 'left to right
                //Descriptor.Set(5, True) ' top to bottom
                //Descriptor.Set(6, False)
                //Descriptor.Set(7, False)
            }

            internal TGA_Header_Image_Specification( TGA NewTGA,  FileStream F) : base(NewTGA, F)
            {
                byte[] Work = new byte[2];

                F.Read(Work, 0, 2);
                X = System.BitConverter.ToInt16(Work, 0);
                F.Read(Work, 0, 2);
                Y = System.BitConverter.ToInt16(Work, 0);
                F.Read(Work, 0, 2);
                Width = System.BitConverter.ToInt16(Work, 0);
                F.Read(Work, 0, 2);
                Height = System.BitConverter.ToInt16(Work, 0);
                F.Read(Work, 0, 1);
                BitsPerPixel = Work[0];
                F.Read(Work, 0, 1);
                Descriptor = new BitArray(Work[0]);

                //MsgBox(Descriptor.ToString())
            }

            public override byte[] Save()
            {
                byte[] Work = new byte[10];
                //2 bytes, X origin
                //2 bytes, y origin
                //2 bytes, width
                //2 bytes, height
                //1 byte, Pixel deapth as  BPP, 24
                //1 byte, Image descriptor. bitfield [
                //bits 0 to 3, attribute bits per pixel
                //byts 4 & 5, pixel to screen ordering, bit 4=left to right, bit 5 top to bottom
                //bits 6 & 7, must be 0]
                Array.Copy(System.BitConverter.GetBytes(X), 0, Work, 0, 2);
                Array.Copy(System.BitConverter.GetBytes(Y), 0, Work, 2, 2);
                Array.Copy(System.BitConverter.GetBytes(Width), 0, Work, 4, 2);
                Array.Copy(System.BitConverter.GetBytes(Height), 0, Work, 6, 2);
                Work[8] = BitsPerPixel;
                Work[9] = 32;

                return Work;
            }
        }

        internal class TGA_Image : TGA_Section
        {

            public Bitmap MyBitmap;

            internal TGA_Image(LibModMaker.TGA NewTGA,  Bitmap SourceBitmap) : base(NewTGA, SourceBitmap)
            {
                MyBitmap = SourceBitmap;
            }

            internal TGA_Image(LibModMaker.TGA NewTGA,  FileStream F) : base(NewTGA, F)
            {
                MyBitmap = new Bitmap(TGA.Header.ImageSpec.Width, TGA.Header.ImageSpec.Height,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                TGA.Header.GetImageType().Read(TGA.Header, MyBitmap, F);
            }

            public override byte[] Save()
            {
                byte[] Work;
                int Index;
                int X;
                int Y;
                Color ThisPixel;

                Index = 0;

                //(variable bytes, see header field 1) Image ID, leave blank?
                //(varible bytes), for the color map, don't include it
                // width x height pixels
                if (TGA.Header.ImageSpec.BitsPerPixel == 24)
                {
                    Work = new byte[MyBitmap.Height*MyBitmap.Width*3];

                    for (Y = 0; Y <= (MyBitmap.Height - 1); Y++)
                    {
                        for (X = 0; X <= (MyBitmap.Width - 1); X++)
                        {
                            ThisPixel = MyBitmap.GetPixel(X, Y);
                            //Work[Index) = ThisPixel.A
                            //Index += 1
                            Work[Index] = ThisPixel.B;
                            Index += 1;
                            Work[Index] = ThisPixel.G;
                            Index += 1;
                            Work[Index] = ThisPixel.R;
                            Index += 1;
                        }
                    }
                }
                else
                {
                    Work = new byte[MyBitmap.Height * MyBitmap.Width * 4];

                    for (Y = 0; Y <= (MyBitmap.Height - 1); Y++)
                    {
                        for (X = 0; X <= (MyBitmap.Width - 1); X++)
                        {
                            ThisPixel = MyBitmap.GetPixel(X, Y);
                            Work[Index] = ThisPixel.B;
                            Index += 1;
                            Work[Index] = ThisPixel.G;
                            Index += 1;
                            Work[Index] = ThisPixel.R;
                            Index += 1;
                            Work[Index] = ThisPixel.A;
                            Index += 1;
                        }
                    }
                }

                return Work;
            }
        }

        internal class TGA_Developer : TGA_Section
        {

            internal TGA_Developer(LibModMaker.TGA NewTGA, Bitmap SourceBitmap) : base(NewTGA, SourceBitmap)
            {
            }

            internal TGA_Developer(LibModMaker.TGA NewTGA, FileStream F) : base(NewTGA, F)
            {
            }

            public override byte[] Save()
            {
                byte[] Work = new byte[0];
                //leave blank
                return Work;
            }
        }

        internal class TGA_Extensions : TGA_Section
        {

            internal TGA_Extensions(LibModMaker.TGA NewTGA, Bitmap SourceBitmap) : base(NewTGA, SourceBitmap)
            {
            }

            internal TGA_Extensions(LibModMaker.TGA NewTGA, FileStream F) : base(NewTGA, F)
            {
            }

            public override byte[] Save()
            {
                byte[] Work = new byte[0];
                //leave blank
                return Work;
            }
        }

        internal class TGA_Footer : TGA_Section
        {
            public byte[] ExtensionAreaOffset = new byte[2];
            public byte[] DeveloperAreaOffset = new byte[3];
            public string Signature;
            public byte[] Terminator = new byte[1];

            internal TGA_Footer(LibModMaker.TGA NewTGA, Bitmap SourceBitmap) : base(NewTGA, SourceBitmap)
            {
            }

            internal TGA_Footer(LibModMaker.TGA NewTGA, FileStream F) : base(NewTGA, F)
            {
            }

            public override byte[] Save()
            {
                byte[] Work = new byte[25];
                //Bytes 0-3: The Extension Area Offset

                //Bytes 4-7: The Developer Directory Offset

                //        Bytes(8 - 23) : The(Signature)

                //Byte 24: ASCII Character "."

                //Byte 25: Binary zero string terminator (0x00)
                System.Text.ASCIIEncoding.ASCII.GetBytes("TRUEVISION-XFILE.", 0, 17, Work, 7);
                Work[24] = 0;

                return Work;
            }
        }
    } //end class
}