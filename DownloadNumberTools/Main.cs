using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormAnimation;

namespace DownloadNumberTools
{
    public partial class Main : Controls.FormEx
    {
        private readonly Color m_tabSelectedBackColor = Color.FromArgb(39, 42, 44);
        private Hashtable m_formHashTable = new Hashtable();

        public Main()
        {
            InitializeComponent();
        }

        private void OnShown(object sender, EventArgs e)
        {

        }

        private void OnLoad(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Title_MouseDown(object sender, MouseEventArgs e)
        {
            panelTitle.MoveControl(this);
        }

        private void Tab_Click(object sender, EventArgs e)
        {
            btnTab.BackColor = m_tabSelectedBackColor;
            btnTab2.BackColor = panelNav.BackColor;

            TabForm form = null;
            if (m_formHashTable.ContainsKey("Tab"))
            {
                form = m_formHashTable["Tab"] as TabForm;
            }
            else
            {
                form = new TabForm();
                form.TopLevel = false;
                form.Size = panelContent.Size;
                panelContent.Controls.Add(form);
                m_formHashTable.Add("Tab", form);
            }
            TabFormSwitchAnimation(form);
        }

        private void Tab2_Click(object sender, EventArgs e)
        {
            btnTab.BackColor = panelNav.BackColor;
            btnTab2.BackColor = m_tabSelectedBackColor;

            TabForm2 form = null;
            if (m_formHashTable.ContainsKey("Tab2"))
            {
                form = m_formHashTable["Tab2"] as TabForm2;
            }
            else
            {
                form = new TabForm2();
                form.TopLevel = false;
                form.Size = panelContent.Size;
                panelContent.Controls.Add(form);
                m_formHashTable.Add("Tab2", form);
            }
            TabFormSwitchAnimation(form);
        }

        private void TabFormSwitchAnimation(Form form)
        {
            form.Location = new Point(0 - this.Width, 0);
            form.Show();

            new Animator(new Path(-this.Width, 0, 250)).Play(form, "Left");
        }
    }
}