using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DownloadNumberTools.Controls
{
    internal static class FontAwesomeFactory
    {

        public static PrivateFontCollection Fonts;

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        public static void InitiailseFont()
        {
            if (Fonts == null)
            {
                Fonts = new PrivateFontCollection();
                byte[] fontAwesomeData = Properties.Resources.fontawesome_webfont;
                IntPtr pFontData = Marshal.AllocHGlobal(fontAwesomeData.Length);
                try
                {
                    Marshal.Copy(fontAwesomeData, 0, pFontData, fontAwesomeData.Length);
                    Fonts.AddMemoryFont(pFontData, fontAwesomeData.Length);
                    uint dummy = 0;
                    AddFontMemResourceEx(pFontData, (uint)fontAwesomeData.Length, IntPtr.Zero, ref dummy);
                }
                catch (Exception)
                {
                    Marshal.FreeHGlobal(pFontData);
                }
            }
        }

    }
}
