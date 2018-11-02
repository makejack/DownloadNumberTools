using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DownloadNumberTools.Controls
{
    public class PanelEx : Panel
    {
        public PanelEx()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.UpdateStyles();
        }

        public void MoveControl(Form form)
        {
            WinApi.ReleaseCapture();
            WinApi.SendMessage(form.Handle, WinApi.WM_SYSCOMMAND, WinApi.SC_MOVE + WinApi.HTCAPTION, 0);
        }
    }
}
