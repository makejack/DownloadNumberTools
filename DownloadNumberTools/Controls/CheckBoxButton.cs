using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DownloadNumberTools.Controls
{
    public class CheckBoxButton : Button
    {
        public CheckBoxButton() : base()
        {
            this.SetStyle(ControlStyles.UserPaint,true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint,true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer,true);
            this.UpdateStyles();
        }

    }
}
