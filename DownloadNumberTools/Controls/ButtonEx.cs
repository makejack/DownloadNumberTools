using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace DownloadNumberTools.Controls
{
    public class ButtonEx : Button
    {
        private bool m_mouseEnter = false;

        private Color m_defaultForeColor = Color.Empty;

        public ButtonEx()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.Selectable, false);
            this.UpdateStyles();

            FontAwesomeFactory.InitiailseFont();
            ReloadFontAwesome();
        }

        #region Mouse

        public Color m_mouseEnterForeColor = Color.White;
        public Color MouseEnterForeColor
        {
            get { return m_mouseEnterForeColor; }
            set { m_mouseEnterForeColor = value; }
        }

        private Color m_mouseDownForeColor = Color.White;
        public Color MouseDownForeColor
        {
            get { return m_mouseDownForeColor; }
            set { m_mouseDownForeColor = value; }
        }

        #endregion

        #region FontAwesome

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

        #endregion

        #region Override Event

        protected override void OnMouseEnter(EventArgs e)
        {
            if (m_defaultForeColor == Color.Empty)
            {
                m_defaultForeColor = Color.FromArgb(this.ForeColor.A, this.ForeColor.R, this.ForeColor.G, this.ForeColor.B);
            }

            m_mouseEnter = true;
            this.ForeColor = MouseEnterForeColor;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            m_mouseEnter = false;
            this.ForeColor = m_defaultForeColor;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            this.ForeColor = MouseDownForeColor;
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            this.ForeColor = m_mouseEnter ? MouseEnterForeColor : m_defaultForeColor;
            base.OnMouseUp(mevent);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            if (this.FlatStyle == FlatStyle.Flat && this.Enabled == false)
            {
                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
                Graphics g = pevent.Graphics;
                g.FillRectangle(new SolidBrush(Color.FromArgb(204, 204, 204)), rect);
                Size textSize = TextRenderer.MeasureText(this.Text, this.Font);
                RectangleF textRect = RectangleF.Empty;
                Image img = GetImage();
                if (img != null)
                {
                    Rectangle imgRect = GetImageLocadtion(img, textSize);
                    g.DrawImage(img, imgRect);
                }
                else
                {
                    textRect = GetTextLocadtion(textSize);
                }
                g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), textRect);
            }
        }

        private void DrawImage(Graphics g, Rectangle rect)
        {

        }

        private Rectangle GetTextLocadtion(Size size)
        {
            int padding = 5, interval = 1;
            Rectangle textRect = new Rectangle(new Point(padding, padding - interval), size);
            switch (this.TextAlign)
            {
                case ContentAlignment.TopLeft:
                    break;
                case ContentAlignment.TopCenter:
                    textRect.X = (this.Width - size.Width) / 2 + interval;
                    break;
                case ContentAlignment.TopRight:
                    textRect.X = (this.Width - size.Width) - padding + (interval * 2);
                    break;
                case ContentAlignment.MiddleLeft:
                    textRect.Y = (this.Height - size.Height) / 2;
                    break;
                case ContentAlignment.MiddleCenter:
                    textRect.X = (this.Width - size.Width) / 2 + interval;
                    textRect.Y = (this.Height - size.Height) / 2;
                    break;
                case ContentAlignment.MiddleRight:
                    textRect.X = (this.Width - size.Width) - padding + (interval * 2);
                    textRect.Y = (this.Height - size.Height) / 2;
                    break;
                case ContentAlignment.BottomLeft:
                    textRect.Y = (this.Height - size.Height) - padding + interval;
                    break;
                case ContentAlignment.BottomCenter:
                    textRect.X = (this.Width - size.Width) / 2 + interval;
                    textRect.Y = (this.Height - size.Height) - padding + interval;
                    break;
                case ContentAlignment.BottomRight:
                    textRect.X = (this.Width - size.Width) - padding + (interval * 2);
                    textRect.Y = (this.Height - size.Height) - padding + interval;
                    break;
            }
            if (textRect.Y < padding)
            {
                textRect.Y = padding;
            }
            return textRect;
        }

        private Image GetImage()
        {
            Image img = this.Image;
            if (this.ImageList != null)
            {
                if (this.ImageIndex > -1)
                {
                    img = this.ImageList.Images[this.ImageIndex];
                }
                else if (this.ImageKey != string.Empty)
                {
                    img = this.ImageList.Images[this.ImageKey];
                }
            }
            return img;
        }

        private Rectangle GetImageLocadtion(Image img, Size textSize)
        {
            Rectangle rect = Rectangle.Empty;
            switch (this.TextImageRelation)
            {
                case TextImageRelation.Overlay:
                    rect = ImageOverlayLocadtion(img);
                    break;
                case TextImageRelation.ImageAboveText:
                    rect = ImageAboveTextLocadtion(img, textSize);
                    break;
                case TextImageRelation.TextAboveImage:
                    rect = TextAboveImageLocadtion(img, textSize);
                    break;
                case TextImageRelation.ImageBeforeText:
                    rect = ImageBeforeTextLocadtion(img, textSize);
                    break;
                case TextImageRelation.TextBeforeImage:
                    rect = TextBeforeImageLocadtion(img, textSize);
                    break;
            }

            return rect;
        }

        private Rectangle TextBeforeImageLocadtion(Image img, Size textSize)
        {
            Size imgSize = img.Size;
            int padding = 5, interval = 1;
            Rectangle rect = new Rectangle(new Point(padding, padding), imgSize);
            switch (this.ImageAlign)
            {
                case ContentAlignment.TopLeft:
                    break;
                case ContentAlignment.TopCenter:
                    break;
                case ContentAlignment.TopRight:
                    break;
                case ContentAlignment.MiddleLeft:
                    break;
                case ContentAlignment.MiddleCenter:
                    break;
                case ContentAlignment.MiddleRight:
                    break;
                case ContentAlignment.BottomLeft:
                    break;
                case ContentAlignment.BottomCenter:
                    break;
                case ContentAlignment.BottomRight:
                    break;
                default:
                    break;
            }
            return rect;
        }

        private Rectangle TextAboveImageLocadtion(Image img, Size textSize)
        {
            Size imgSize = img.Size;
            int padding = 5, interval = 1;
            Rectangle rect = new Rectangle(new Point(padding, padding), imgSize);
            switch (this.ImageAlign)
            {
                case ContentAlignment.TopLeft:
                    rect.Y = GetTextAboveImageToTopY(imgSize, textSize, padding, interval);
                    break;
                case ContentAlignment.TopCenter:
                    rect.Y = GetTextAboveImageToTopY(imgSize, textSize, padding, interval);
                    rect.X = (this.Width - imgSize.Width) / 2 + interval;
                    break;
                case ContentAlignment.TopRight:
                    rect.Y = GetTextAboveImageToTopY(imgSize, textSize, padding, interval);
                    rect.X = (this.Width - imgSize.Width) - padding + (interval * 2);
                    break;
                case ContentAlignment.MiddleLeft:
                    rect.Y = GetTextAboveImageToMiddleY(imgSize, textSize, padding, interval);
                    break;
                case ContentAlignment.MiddleCenter:
                    rect.Y = GetTextAboveImageToMiddleY(imgSize, textSize, padding, interval);
                    rect.X = (this.Width - imgSize.Width) / 2 + interval;
                    break;
                case ContentAlignment.MiddleRight:
                    rect.Y = GetTextAboveImageToMiddleY(imgSize, textSize, padding, interval);
                    rect.X = (this.Width - imgSize.Width) - padding + (interval * 2);
                    break;
                case ContentAlignment.BottomLeft:
                    rect.Y = (this.Height - imgSize.Height) - padding + (interval * 2);
                    break;
                case ContentAlignment.BottomCenter:
                    rect.X = (this.Width - imgSize.Width) / 2 + interval;
                    rect.Y = (this.Height - imgSize.Height) - padding + (interval * 2);
                    break;
                case ContentAlignment.BottomRight:
                    rect.X = (this.Width - imgSize.Width) - padding + (interval * 2);
                    rect.Y = (this.Height - imgSize.Height) - padding + (interval * 2);
                    break;
            }
            if (rect.X < padding)
            {
                rect.X = padding;
            }
            return rect;
        }

        private int GetTextAboveImageToTopY(Size imgSize, Size textSize, int padding, int interval)
        {
            int y = 0;
            switch (this.TextAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    y = textSize.Height + padding;
                    break;
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    y = (this.Height / 2) - padding + interval;
                    break;
            }
            return y;
        }

        private int GetTextAboveImageToMiddleY(Size imgSize, Size textSize, int padding, int interval)
        {
            int y = 0;
            switch (this.TextAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    y = (this.Height / 2) - padding + interval;
                    break;
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    int halfHeight = this.Height / 2;
                    y = this.Height - halfHeight + ((halfHeight / 2) - (imgSize.Height / 2)) - padding + interval;
                    break;
            }
            return y;
        }

        private Rectangle ImageOverlayLocadtion(Image img)
        {
            Size imgSize = img.Size;
            int padding = 5;
            Rectangle rect = new Rectangle(new Point(padding, padding), imgSize);
            switch (this.ImageAlign)
            {
                case ContentAlignment.TopLeft:
                    break;
                case ContentAlignment.TopCenter:
                    rect.X = (this.Width - imgSize.Width) / 2;
                    break;
                case ContentAlignment.TopRight:
                    rect.X = (this.Width - imgSize.Width) - padding;
                    break;
                case ContentAlignment.MiddleLeft:
                    rect.Y = (this.Height - imgSize.Height) / 2;
                    break;
                case ContentAlignment.MiddleCenter:
                    rect.X = (this.Width - imgSize.Width) / 2;
                    rect.Y = (this.Height - imgSize.Height) / 2;
                    break;
                case ContentAlignment.MiddleRight:
                    rect.X = (this.Width - imgSize.Width) - padding;
                    rect.Y = (this.Height - imgSize.Height) / 2;
                    break;
                case ContentAlignment.BottomLeft:
                    rect.Y = (this.Height - imgSize.Height) - padding + 2;
                    break;
                case ContentAlignment.BottomCenter:
                    rect.X = (this.Width - imgSize.Width) / 2;
                    rect.Y = (this.Height - imgSize.Height) - padding + 2;
                    break;
                case ContentAlignment.BottomRight:
                    rect.X = (this.Width - imgSize.Width) - padding;
                    rect.Y = (this.Height - imgSize.Height) - padding + 2;
                    break;
            }
            if (rect.X < padding)
            {
                rect.X = padding;
            }
            if (rect.Y < padding)
            {
                rect.Y = padding;
            }
            return rect;
        }

        private Rectangle ImageBeforeTextLocadtion(Image img, Size textSize)
        {
            Size imgSize = img.Size;
            int padding = 5, interval = 1;
            Rectangle rect = new Rectangle(new Point(padding, padding), imgSize);
            switch (this.ImageAlign)
            {
                case ContentAlignment.TopLeft:
                    break;
                case ContentAlignment.TopCenter:
                    switch (this.TextAlign)
                    {
                        case ContentAlignment.TopLeft:
                        case ContentAlignment.MiddleLeft:
                        case ContentAlignment.BottomLeft:
                        case ContentAlignment.TopCenter:
                        case ContentAlignment.MiddleCenter:
                        case ContentAlignment.BottomCenter:
                            rect.X = (this.Width / 2) / 2 - (imgSize.Width / 2);
                            break;
                        case ContentAlignment.TopRight:
                        case ContentAlignment.MiddleRight:
                        case ContentAlignment.BottomRight:
                            rect.X = (this.Width / 2) - imgSize.Width - padding;
                            break;
                    }
                    break;
                case ContentAlignment.TopRight:
                    rect.X = GetImageBeforeTextToRightX(imgSize, textSize, padding, interval);
                    break;
                case ContentAlignment.MiddleLeft:
                    rect.Y = (this.Height - imgSize.Height) / 2;
                    break;
                case ContentAlignment.MiddleCenter:
                    rect.X = GetImageBeforeTextToCenterX(imgSize, textSize, padding, interval);
                    rect.Y = (this.Height - imgSize.Height) / 2 + 1;
                    break;
                case ContentAlignment.MiddleRight:
                    rect.X = GetImageBeforeTextToRightX(imgSize, textSize, padding, interval);
                    rect.Y = (this.Height - imgSize.Height) / 2 + 1;
                    break;
                case ContentAlignment.BottomLeft:
                    rect.Y = (this.Height - imgSize.Height) - padding + interval;
                    break;
                case ContentAlignment.BottomCenter:
                    rect.X = GetImageBeforeTextToCenterX(imgSize, textSize, padding, interval);
                    rect.Y = (this.Height - imgSize.Height) - padding + (interval * 2);
                    break;
                case ContentAlignment.BottomRight:
                    rect.X = GetImageBeforeTextToRightX(imgSize, textSize, padding, interval);
                    rect.Y = (this.Height - imgSize.Height) - padding + (interval * 2);
                    break;
            }
            if (rect.X < padding)
            {
                rect.X = padding;
            }
            if (rect.Y < padding)
            {
                rect.Y = padding;
            }
            return rect;
        }

        private int GetImageBeforeTextToCenterX(Size imgSize, Size textSize, int padding, int interval)
        {
            int x = 0;
            switch (this.TextAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    x = (this.Width / 2) / 2 - (imgSize.Width / 2);
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    x = (this.Width / 2) - imgSize.Width - padding - interval;
                    break;
            }
            return x;
        }

        private int GetImageBeforeTextToRightX(Size imgSize, Size textSize, int padding, int interval)
        {
            int x = 0;
            switch (this.TextAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    x = (this.Width / 2) - imgSize.Width - padding;
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    x = this.Width - imgSize.Width - textSize.Width - padding + interval;
                    break;
            }
            return x;
        }

        private Rectangle ImageAboveTextLocadtion(Image img, Size textSize)
        {
            Size imgSize = img.Size;
            int padding = 5, interval = 1;
            Rectangle rect = new Rectangle(new Point(padding, padding), imgSize);
            switch (this.ImageAlign)
            {
                case ContentAlignment.TopLeft:
                    break;
                case ContentAlignment.TopCenter:
                    rect.X = (this.Width - imgSize.Width) / 2;
                    break;
                case ContentAlignment.TopRight:
                    rect.X = (this.Width - imgSize.Width) - padding + (interval * 2);
                    break;
                case ContentAlignment.MiddleLeft:
                    switch (this.TextAlign)
                    {
                        case ContentAlignment.TopLeft:
                        case ContentAlignment.TopCenter:
                        case ContentAlignment.TopRight:
                        case ContentAlignment.MiddleLeft:
                        case ContentAlignment.MiddleCenter:
                        case ContentAlignment.MiddleRight:
                            rect.Y = (this.Height / 2) / 2 - (imgSize.Height / 2) + padding;
                            break;
                        case ContentAlignment.BottomLeft:
                        case ContentAlignment.BottomCenter:
                        case ContentAlignment.BottomRight:
                            rect.Y = (this.Height - imgSize.Height - textSize.Height) / 2;
                            break;
                    }
                    break;
                case ContentAlignment.MiddleCenter:
                    rect.Y = GetImageAboveTextToMiddeY(imgSize, textSize, padding, interval);
                    rect.X = (this.Width - imgSize.Width) / 2 + interval;
                    break;
                case ContentAlignment.MiddleRight:
                    rect.Y = GetImageAboveTextToMiddeY(imgSize, textSize, padding, interval);
                    rect.X = (this.Width - imgSize.Width) - padding + (interval * 2);
                    break;
                case ContentAlignment.BottomLeft:
                    rect.Y = GetImageAboveTextToBottomY(imgSize, textSize, padding, interval);
                    break;
                case ContentAlignment.BottomCenter:
                    rect.Y = GetImageAboveTextToBottomY(imgSize, textSize, padding, interval);
                    rect.X = (this.Width - imgSize.Width) / 2 + interval;
                    break;
                case ContentAlignment.BottomRight:
                    rect.Y = GetImageAboveTextToBottomY(imgSize, textSize, padding, interval);
                    rect.X = (this.Width - imgSize.Width) - padding + (interval * 2);
                    break;
            }
            if (rect.X < padding)
            {
                rect.X = padding;
            }
            if (rect.Y < padding)
            {
                rect.Y = padding;
            }
            return rect;
        }

        private int GetImageAboveTextToMiddeY(Size imgSize, Size textSize, int padding, int interval)
        {
            int y = 0;
            switch (this.TextAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                    y = (this.Height / 2) / 2 - (imgSize.Height / 2) + padding;
                    break;
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    y = (this.Height - imgSize.Height - textSize.Height) / 2 + interval;
                    break;
            }
            return y;
        }

        private int GetImageAboveTextToBottomY(Size imgSize, Size textSize, int padding, int interval)
        {
            int y = 0;
            switch (this.TextAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                    y = (this.Height / 2) - imgSize.Height + padding + interval;
                    break;
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    y = (this.Height - imgSize.Height - textSize.Height) - padding + (interval * 2);
                    break;
            }
            return y;
        }
        #endregion

    }
}
