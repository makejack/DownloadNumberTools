using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormAnimation;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DownloadNumberTools.Controls
{
    public class FormEx : Form
    {
        const ulong ANIMATOR_DURATION = 250;


        public FormEx() : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.UpdateStyles();

            this.StartPosition = FormStartPosition.CenterScreen;

            SetWindowsAngle();
        }

        public new FormWindowState WindowState
        {
            get { return base.WindowState; }
            set
            {
                if (this.FormBorderStyle == FormBorderStyle.None)
                {
                    int sc = WinApi.SC_RESTORE;
                    switch (value)
                    {
                        case FormWindowState.Minimized:
                            sc = WinApi.SC_MINIMIZE;
                            break;
                        case FormWindowState.Maximized:
                            sc = WinApi.SC_MAXIMIZE;
                            break;
                    }
                    WinApi.SendMessage(this.Handle, WinApi.WM_SYSCOMMAND, sc, 0);
                }
                else
                {
                    base.WindowState = value;
                }
            }
        }

        private Color m_borderColor = Color.Black;
        [DefaultValue(typeof(Color), "Black")]
        public Color BorderColor
        {
            get { return m_borderColor; }
            set
            {
                if (this.m_borderColor != value)
                {
                    m_borderColor = value;
                    this.Invalidate();
                }
            }
        }

        private int m_angle = 1;
        [DefaultValue(typeof(int), "1")]
        public int Angle
        {
            get { return m_angle; }
            set
            {
                if (m_angle != value)
                {
                    m_angle = value;
                    SetWindowsAngle();
                }
            }
        }

        private void SetWindowsAngle()
        {
            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                IntPtr hRgn = WinApi.CreateRoundRectRgn(0, 0, this.Width + 1, this.Height + 1, Angle, Angle);
                WinApi.SetWindowRgn(this.Handle, hRgn, true);
                WinApi.DeleteObject(hRgn);
            }
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            SetWindowsAngle();
            base.OnClientSizeChanged(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            new Animator(new Path(0, 1, ANIMATOR_DURATION)).Play(this, Animator.KnownProperties.Opacity);
            base.OnLoad(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.Opacity == 1)
            {
                e.Cancel = true;

                // float endLeft = this.Left + this.Width / 2;
                // float endTop = this.Top + this.Height / 2;

                // new Animator(new Path(this.Left, endLeft, ANIMATOR_DURATION)).Play(this, "Left");
                // new Animator(new Path(this.Top, endTop, ANIMATOR_DURATION)).Play(this, "Top");
                new Animator(new Path(this.Width, 0, ANIMATOR_DURATION)).Play(this, "Width");
                // new Animator(new Path(this.Height, 0, ANIMATOR_DURATION)).Play(this, "Height");
                new Animator(new Path(1, 0, ANIMATOR_DURATION)).Play(this, Animator.KnownProperties.Opacity, new SafeInvoker(() =>
                 {
                     if (this.InvokeRequired)
                     {
                         this.Invoke(new EventHandler(delegate
                         {
                             this.Close();
                         }));
                     }
                 }));
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WinApi.WM_SYSCOMMAND && this.FormBorderStyle == FormBorderStyle.None)
            {
                int sc = m.WParam.ToInt32();
                if (sc == WinApi.SC_RESTORE)
                {
                    new Animator(new Path((float)this.Opacity, 1, ANIMATOR_DURATION)).Play(this, Animator.KnownProperties.Opacity);
                }
                else if (sc == WinApi.SC_MINIMIZE)
                {
                    new Animator(new Path((float)this.Opacity, 0, ANIMATOR_DURATION)).Play(this, Animator.KnownProperties.Opacity, new SafeInvoker(delegate
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new EventHandler(delegate
                            {
                                base.WindowState = FormWindowState.Minimized;
                            }));
                        }
                    }));
                }
            }
        }
    }
}
