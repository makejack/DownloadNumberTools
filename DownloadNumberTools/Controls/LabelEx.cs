using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DownloadNumberTools.Controls
{
    public class LabelEx : Label
    {
        public LabelEx()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.UpdateStyles();

            FontAwesomeFactory.InitiailseFont();
            ReloadFontAwesome();
        }

        private string m_iconCode = string.Empty;
        [DefaultValue(typeof(string), ""), Category("FontAwesome")]
        public string IconCode
        {
            get { return m_iconCode; }
            set
            {
                if (m_iconCode != value)
                {
                    m_iconCode = value;
                    ShowFontAwesomeIcon();
                }
            }
        }

        private bool m_useFontAwesome = false;
        [DefaultValue(typeof(bool), "false"), Category("FontAwesome")]
        public bool UseFontAwesome
        {
            get { return m_useFontAwesome; }
            set
            {
                if (m_useFontAwesome != value)
                {
                    m_useFontAwesome = value;
                    if (value)
                    {
                        this.Font = FontAwesome;
                        ShowFontAwesomeIcon();
                    }
                    else
                    {
                        this.Font = SystemFonts.DefaultFont;
                    }
                }
            }
        }

        private void ShowFontAwesomeIcon()
        {
            if (UseFontAwesome)
            {
                if (IconCode != string.Empty)
                {
                    this.Text = UniCodeToChar(IconCode);
                }
            }
        }

        private string UniCodeToChar(string hex)
        {
            int code = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            string unicodeString = char.ConvertFromUtf32(code);
            return unicodeString;
        }

        private int m_FontAwesomeSize = 9;
        [DefaultValue(typeof(int), "9"), Category("FontAwesome")]
        public int FontAwesomeSize
        {
            get
            {
                return m_FontAwesomeSize;
            }
            set
            {
                m_FontAwesomeSize = value;
                ReloadFontAwesome();
                if (UseFontAwesome)
                {
                    this.Font = FontAwesome;
                }
            }
        }

        private void ReloadFontAwesome()
        {
            if (FontAwesomeFactory.Fonts.Families.Length > 0)
                FontAwesome = new Font(FontAwesomeFactory.Fonts.Families[0], FontAwesomeSize, FontStyle.Regular);
        }

        [Category("FontAwesome")]
        public Font FontAwesome { get; private set; }

    }
}
