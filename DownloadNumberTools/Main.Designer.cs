using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace DownloadNumberTools
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panelContent = new DownloadNumberTools.Controls.PanelEx();
            this.panelNav = new DownloadNumberTools.Controls.PanelEx();
            this.btnSetting = new DownloadNumberTools.Controls.ButtonEx();
            this.btnTab2 = new DownloadNumberTools.Controls.ButtonEx();
            this.btnTab = new DownloadNumberTools.Controls.ButtonEx();
            this.panelTitle = new DownloadNumberTools.Controls.PanelEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgIcon = new DownloadNumberTools.Controls.ImageEx();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMin = new DownloadNumberTools.Controls.ButtonEx();
            this.btnClose = new DownloadNumberTools.Controls.ButtonEx();
            this.panelNav.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(160, 50);
            this.panelContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(690, 450);
            this.panelContent.TabIndex = 2;
            // 
            // panelNav
            // 
            this.panelNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(74)))));
            this.panelNav.Controls.Add(this.btnSetting);
            this.panelNav.Controls.Add(this.btnTab2);
            this.panelNav.Controls.Add(this.btnTab);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelNav.Location = new System.Drawing.Point(0, 50);
            this.panelNav.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(160, 450);
            this.panelNav.TabIndex = 1;
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Font = new System.Drawing.Font("FontAwesome", 16F);
            this.btnSetting.FontAwesomeSize = 16;
            this.btnSetting.ForeColor = System.Drawing.Color.White;
            this.btnSetting.IconCode = "f013";
            this.btnSetting.Location = new System.Drawing.Point(64, 414);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSetting.MouseDownForeColor = System.Drawing.Color.White;
            this.btnSetting.MouseEnterForeColor = System.Drawing.Color.White;
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(32, 32);
            this.btnSetting.TabIndex = 2;
            this.btnSetting.Text = "";
            this.btnSetting.UseFontAwesome = true;
            this.btnSetting.UseVisualStyleBackColor = true;
            // 
            // btnTab2
            // 
            this.btnTab2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTab2.FlatAppearance.BorderSize = 0;
            this.btnTab2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(42)))), ((int)(((byte)(44)))));
            this.btnTab2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTab2.ForeColor = System.Drawing.Color.White;
            this.btnTab2.Image = global::DownloadNumberTools.Properties.Resources.Count_tool_123_32;
            this.btnTab2.Location = new System.Drawing.Point(0, 66);
            this.btnTab2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTab2.MouseDownForeColor = System.Drawing.Color.White;
            this.btnTab2.MouseEnterForeColor = System.Drawing.Color.White;
            this.btnTab2.Name = "btnTab2";
            this.btnTab2.Size = new System.Drawing.Size(160, 50);
            this.btnTab2.TabIndex = 3;
            this.btnTab2.Text = " 下载客户序列号";
            this.btnTab2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTab2.UseVisualStyleBackColor = true;
            this.btnTab2.Click += new System.EventHandler(this.Tab2_Click);
            // 
            // btnTab
            // 
            this.btnTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(42)))), ((int)(((byte)(44)))));
            this.btnTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTab.FlatAppearance.BorderSize = 0;
            this.btnTab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(42)))), ((int)(((byte)(44)))));
            this.btnTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTab.ForeColor = System.Drawing.Color.White;
            this.btnTab.Image = global::DownloadNumberTools.Properties.Resources.format_list_numbered_32;
            this.btnTab.Location = new System.Drawing.Point(0, 8);
            this.btnTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTab.MouseDownForeColor = System.Drawing.Color.White;
            this.btnTab.MouseEnterForeColor = System.Drawing.Color.White;
            this.btnTab.Name = "btnTab";
            this.btnTab.Size = new System.Drawing.Size(160, 50);
            this.btnTab.TabIndex = 2;
            this.btnTab.Text = " 下载卡片编号";
            this.btnTab.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTab.UseVisualStyleBackColor = false;
            this.btnTab.Click += new System.EventHandler(this.Tab_Click);
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.White;
            this.panelTitle.Controls.Add(this.panel1);
            this.panelTitle.Controls.Add(this.btnMin);
            this.panelTitle.Controls.Add(this.btnClose);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(850, 50);
            this.panelTitle.TabIndex = 0;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Title_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.panel1.Controls.Add(this.imgIcon);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 50);
            this.panel1.TabIndex = 0;
            // 
            // imgIcon
            // 
            this.imgIcon.Image = global::DownloadNumberTools.Properties.Resources.Count_tool;
            this.imgIcon.Location = new System.Drawing.Point(10, 9);
            this.imgIcon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.imgIcon.Name = "imgIcon";
            this.imgIcon.Size = new System.Drawing.Size(32, 32);
            this.imgIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgIcon.TabIndex = 1;
            this.imgIcon.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(50, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "下载编号工具";
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Font = new System.Drawing.Font("FontAwesome", 12F);
            this.btnMin.FontAwesomeSize = 12;
            this.btnMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(157)))), ((int)(((byte)(157)))));
            this.btnMin.IconCode = "f2d1";
            this.btnMin.Location = new System.Drawing.Point(745, 0);
            this.btnMin.Margin = new System.Windows.Forms.Padding(0);
            this.btnMin.MouseDownForeColor = System.Drawing.Color.White;
            this.btnMin.MouseEnterForeColor = System.Drawing.Color.White;
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(52, 41);
            this.btnMin.TabIndex = 2;
            this.btnMin.Text = "";
            this.btnMin.UseFontAwesome = true;
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.Min_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(112)))), ((int)(((byte)(122)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("FontAwesome", 14F);
            this.btnClose.FontAwesomeSize = 14;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(157)))), ((int)(((byte)(157)))));
            this.btnClose.IconCode = "f00d";
            this.btnClose.Location = new System.Drawing.Point(798, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.MouseDownForeColor = System.Drawing.Color.White;
            this.btnClose.MouseEnterForeColor = System.Drawing.Color.White;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 41);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "";
            this.btnClose.UseFontAwesome = true;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.Close_Click);
            // 
            // Main
            // 
            this.Angle = 5;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(850, 500);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelNav);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.Opacity = 0D;
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.OnShown);
            this.panelNav.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.PanelEx panelTitle;
        private Controls.ButtonEx btnMin;
        private Controls.ButtonEx btnClose;
        private Label label1;
        private Controls.ImageEx imgIcon;
        private Controls.PanelEx panelNav;
        private Controls.ButtonEx btnTab;
        private Controls.ButtonEx btnTab2;
        private Controls.ButtonEx btnSetting;
        private Controls.PanelEx panelContent;
        private Panel panel1;
    }
}

