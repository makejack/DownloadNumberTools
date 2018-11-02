using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace DownloadNumberTools.Controls
{
    [ToolboxBitmap(typeof(TextBox))]
    public class TextBoxEx : TextBox
    {
        private Pen m_borderPen = null;
        private bool m_mouseEnter = false;

        public TextBoxEx()
        {
            this.DoubleBuffered = true;
            // this.SetStyle(ControlStyles.UserPaint, true);
            // this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            // this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            // this.UpdateStyles();

            m_borderPen = new Pen(this.BorderColor, 1);
        }

        private string m_watermarkText = string.Empty;
        [DefaultValue(typeof(string), ""), Category("WaterMark")]
        public string WaterMarkText
        {
            get { return m_watermarkText; }
            set
            {
                if (m_watermarkText != value)
                {
                    m_watermarkText = value;
                    WinApi.SendMessage(this.Handle, WinApi.EM_SETCUEBANNER, 0, WaterMarkText);
                }
            }
        }

        private Color m_borderColor = Color.FromArgb(122, 122, 122);
        [DefaultValue(typeof(Color), "122,122,122")]
        public Color BorderColor
        {
            get { return m_borderColor; }
            set
            {
                if (m_borderColor != value)
                {
                    m_borderColor = value;
                    this.Invalidate();
                }
            }
        }

        private Color m_mouseOverBorderColor = Color.Black;
        [DefaultValue(typeof(Color), "Black")]
        public Color MouseOverBorderColor
        {
            get { return m_mouseOverBorderColor; }
            set
            {
                if (m_mouseOverBorderColor != value)
                {
                    m_mouseOverBorderColor = value;
                    this.Invalidate();
                }
            }
        }

        private Color m_focusBorderColor = Color.FromArgb(0, 120, 215);
        [DefaultValue(typeof(Color), "0, 120, 215")]
        public Color FocusBorderColor
        {
            get { return m_focusBorderColor; }
            set
            {
                if (m_focusBorderColor != value)
                {
                    m_focusBorderColor = value;
                    this.Invalidate();
                }
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            m_mouseEnter = true;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            m_mouseEnter = false;
            base.OnMouseLeave(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (this.BorderStyle != BorderStyle.None)
            {
                switch (m.Msg)
                {
                    case WinApi.WM_PAINT:
                    case WinApi.WM_CTLCOLOREDIT:
                        DrawBorder(ref m);
                        break;
                }
            }
        }

        private void DrawBorder(ref Message m)
        {
            IntPtr hDC = WinApi.GetWindowDC(m.HWnd);
            if (hDC == IntPtr.Zero)
            {
                return;
            }

            SetBorderColor();
            Graphics g = Graphics.FromHdc(hDC);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawRectangle(m_borderPen, 0, 0, this.Width - 1, this.Height - 1);

            m.Result = IntPtr.Zero;
            //释放hDC资源
            WinApi.ReleaseDC(m.HWnd, hDC);
        }

        private void SetBorderColor()
        {
            if (this.Focused)
            {
                m_borderPen.Color = FocusBorderColor;
            }
            else if (m_mouseEnter)
            {
                m_borderPen.Color = MouseOverBorderColor;
            }
            else
            {
                m_borderPen.Color = BorderColor;
            }
        }
    }
}
