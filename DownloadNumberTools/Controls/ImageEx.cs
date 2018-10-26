using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DownloadNumberTools.Controls
{
    public class ImageEx : PictureBox
    {
        public ImageEx()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.UpdateStyles();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            GraphicsPath gPath = new GraphicsPath();
            gPath.AddEllipse(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            this.Region = new Region(gPath);

            base.OnPaint(pe);
        }
    }
}
