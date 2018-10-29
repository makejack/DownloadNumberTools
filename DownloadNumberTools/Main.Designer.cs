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
            this.panelEx1 = new DownloadNumberTools.Controls.PanelEx();
            this.btnMin = new DownloadNumberTools.Controls.ButtonEx();
            this.btnClose = new DownloadNumberTools.Controls.ButtonEx();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(63)))), ((int)(((byte)(228)))));
            this.panelEx1.Controls.Add(this.btnMin);
            this.panelEx1.Controls.Add(this.btnClose);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(800, 50);
            this.panelEx1.TabIndex = 0;
            // 
            // btnMin
            // 
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Font = new System.Drawing.Font("FontAwesome", 12F);
            this.btnMin.FontAwesomeSize = 12;
            this.btnMin.ForeColor = System.Drawing.Color.White;
            this.btnMin.IconCode = "f2d1";
            this.btnMin.Location = new System.Drawing.Point(710, 0);
            this.btnMin.Margin = new System.Windows.Forms.Padding(0);
            this.btnMin.MouseDownForeColor = System.Drawing.Color.White;
            this.btnMin.MouseEnterForeColor = System.Drawing.Color.White;
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(45, 29);
            this.btnMin.TabIndex = 2;
            this.btnMin.Text = "";
            this.btnMin.UseFontAwesome = true;
            this.btnMin.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(112)))), ((int)(((byte)(122)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("FontAwesome", 14F);
            this.btnClose.FontAwesomeSize = 14;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.IconCode = "f00d";
            this.btnClose.Location = new System.Drawing.Point(755, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.MouseDownForeColor = System.Drawing.Color.White;
            this.btnClose.MouseEnterForeColor = System.Drawing.Color.White;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 29);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "";
            this.btnClose.UseFontAwesome = true;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.PanelEx panelEx1;
        private Controls.ButtonEx btnMin;
        private Controls.ButtonEx btnClose;
    }
}

