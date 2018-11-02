using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DownloadNumberTools
{
    public partial class TabForm2 : Form
    {
        public TabForm2()
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++)
            {
                dataGridView1.Rows.Add(new object[] {i,i,i,i });
            }
        }
    }
}
