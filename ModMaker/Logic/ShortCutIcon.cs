using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ModMaker.Logic
{
    class ShortCutIcon
    {
        //[StructLayout(LayoutKind.Sequential)]
        //public struct SHFILEINFO
        //{
        //    public const int NAMESIZE = 80;
        //    public IntPtr hIcon;
        //    public int iIcon;
        //    public uint dwAttributes;
        //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
        //    public string szDisplayName;
        //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NAMESIZE)]
        //    public string szTypeName;
        //};

        //[DllImport("Shell32.dll")]
        //public static extern IntPtr SHGetFileInfo(
        //    string pszPath,
        //    uint dwFileAttributes,
        //    ref SHFILEINFO psfi,
        //    uint cbFileInfo,
        //    uint uFlags
        //);

        //public static System.Drawing.Icon GetFileIcon(string name, IconSize size,
        //                                      bool linkOverlay)
        //{
        //    Shell32.SHFILEINFO shfi = new Shell32.SHFILEINFO();
        //    uint flags = Shell32.SHGFI_ICON | Shell32.SHGFI_USEFILEATTRIBUTES;

        //    if (true == linkOverlay) flags += Shell32.SHGFI_LINKOVERLAY;


        //    /* Check the size specified for return. */
        //    if (IconSize.Small == size)
        //    {
        //        flags += Shell32.SHGFI_SMALLICON; // include the small icon flag
        //    }
        //    else
        //    {
        //        flags += Shell32.SHGFI_LARGEICON;  // include the large icon flag
        //    }

        //    Shell32.SHGetFileInfo(name,
        //        Shell32.FILE_ATTRIBUTE_NORMAL,
        //        ref shfi,
        //        (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi),
        //        flags);


        //    // Copy (clone) the returned icon to a new object, thus allowing us 
        //    // to call DestroyIcon immediately
        //    System.Drawing.Icon icon = (System.Drawing.Icon)
        //                         System.Drawing.Icon.FromHandle(shfi.hIcon).Clone();
        //    User32.DestroyIcon(shfi.hIcon); // Cleanup
        //    return icon;
        //}
    }
}
