using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DownloadNumberTools
{
    public partial class Main : Form
    {
        public Main()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.UpdateStyles();

            InitializeComponent();
            
            this.Load += OnLoad;
        }
        
        private void OnLoad(object sender, EventArgs e)
        {
            btnClose.Font = Fonts.FontAwesome;
            btnClose.Text = Fonts.fa.times;

        }
    }
}
