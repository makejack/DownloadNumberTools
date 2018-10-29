using System;
using System.Collections.Generic;
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
            this.SetStyle(ControlStyles.Selectable, false);
            this.UpdateStyles();

            FontAwesomeFactory.InitiailseFont();
        }

        public Font FontAwesome
        {
            get;
            private set;
        }

    }
}
