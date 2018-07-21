using LibModMaker;
using System.Drawing;
using System.Windows.Forms;

namespace ModMaker
{
    /// <summary>
    /// Helper class for the VGUI res file editor
    /// </summary>
    public class PanelRectangle
    {
        internal const int ScreenWidth = 640;
        internal const int ScreenHeight = 480;

        public enum Alignments
        {
            TopLeft,
            Center,
            Fill,
            BottomRight
        }

        public Alignments XAlignment = Alignments.TopLeft;
        public Alignments YAlignment = Alignments.TopLeft;
        public Alignments WAlignment = Alignments.TopLeft;
        public Alignments TAlignment = Alignments.TopLeft;
        public KeyValues VGUI_Panel;
        public Panel WinPanel;
        public Rectangle Editor;

        private Rectangle WinRect;

        internal class PanelProperty
        {
            public string Name;
            public string DataType;
            public string Comment;
            public string Value;
        }

        public int XREStoPixel(int raw)
        {
            double dblRaw = raw/ScreenWidth;

            return (int)(dblRaw*Editor.Width);
        }

        public int YREStoPixel(int raw)
        {
            double dblRaw = raw/ScreenHeight;

            return (int)(dblRaw *Editor.Height);
        }

        public int PixelToXRES(int raw)
        {
            double dblRaw = raw/Editor.Width;

            return (int)(dblRaw *ScreenWidth);
        }

        public int PixeltoYRES(int raw)
        {
            double dblRaw = raw/Editor.Height;

            return (int)(dblRaw *ScreenHeight);
        }

        public Point WinPointToVGUI_Point(Point P)
        {
            return new Point
            {
                X = PixelToXRES(P.X),
                Y = PixeltoYRES(P.Y)
            };
        }

        public Rectangle ToRectangle()
        {
            return WinRect;
        }

        public Rectangle VGUI_ToRectangle()
        {
            PanelProperty xpos = new PanelProperty
            {
                Name = "xpos",
                Value = VGUI_Panel.GetString("xpos", "0")
            };
            PanelProperty ypos = new PanelProperty
            {
                Name = "ypos",
                Value = VGUI_Panel.GetString("ypos", "0")
            };
            PanelProperty tall = new PanelProperty
            {
                Name = "tall",
                Value = VGUI_Panel.GetString("tall", "0")
            };
            PanelProperty wide = new PanelProperty
            {
                Name = "wide",
                Value = VGUI_Panel.GetString("wide", "0")
            };

            PropertySet(xpos);
            PropertySet(ypos);
            PropertySet(tall);
            PropertySet(wide);

            return ToRectangle();
        }

        internal void PropertySet(PanelProperty WorkingProperty)
        {
            if (WorkingProperty.Value == null)
                return;

            string pValue = WorkingProperty.Value.ToLower();
            int iValue = 0;

            switch (WorkingProperty.Name.ToLower())
            {
                case "xpos":
                    if (pValue.StartsWith("c"))
                    {
                        XAlignment = Alignments.Center;
                        pValue = pValue.Substring(1);
                    }
                    if (pValue.StartsWith("r"))
                    {
                        XAlignment = Alignments.BottomRight;
                        pValue = pValue.Substring(1);
                    }
                    if (int.TryParse(pValue,out iValue))
                    {
                        iValue = XREStoPixel(iValue);

                        switch (XAlignment)
                        {
                            case Alignments.BottomRight:
                                WinRect.X = XREStoPixel(ScreenWidth) - iValue;
                                break;
                            case Alignments.Center:
                                WinRect.X = XREStoPixel(ScreenWidth/2) - iValue;break;
                            default:
                                WinRect.X = iValue;break;
                        }
                    }
                    break;
                case "ypos":
                    if (pValue.StartsWith("c"))
                    {
                        YAlignment = Alignments.Center;
                        pValue = pValue.Substring(1);
                    }
                    if (pValue.StartsWith("r"))
                    {
                        YAlignment = Alignments.BottomRight;
                        pValue = pValue.Substring(1);
                    }
                    if (int.TryParse(pValue,out iValue))
                    {
                        iValue = YREStoPixel(iValue);

                        switch (YAlignment)
                        {
                            case Alignments.BottomRight:
                                WinRect.Y = YREStoPixel(ScreenHeight) - iValue;
                                break;
                            case Alignments.Center:
                                WinRect.Y = YREStoPixel(ScreenHeight/2) - iValue;
                                break;
                            default:
                                WinRect.Y = iValue;
                                break;
                        }
                    }
                    break;
                case "tall":
                    if (pValue.StartsWith("f"))
                    {
                        TAlignment = Alignments.Fill;
                        pValue = pValue.Substring(1);
                    }
                    if (int.TryParse(pValue,out iValue))
                    {
                        iValue = YREStoPixel(iValue);

                        switch (TAlignment)
                        {
                            case Alignments.Fill:
                                WinRect.Height = YREStoPixel(ScreenHeight) - iValue;
                                break;
                            default:
                                WinRect.Height = iValue;break;
                        }
                    }
                    break;
                case "wide":
                    if (pValue.StartsWith("f"))
                    {
                        WAlignment = Alignments.Fill;
                        pValue = pValue.Substring(1);
                    }
                    if (int.TryParse(pValue, out iValue))
                    {
                        iValue = XREStoPixel(iValue);

                        switch (WAlignment)
                        {
                            case Alignments.Fill:
                                WinRect.Width = XREStoPixel(ScreenWidth) - iValue;
                                break;
                            default:
                                WinRect.Width = iValue;break;
                        }
                    }
                    break;
            }
        }
    }

}