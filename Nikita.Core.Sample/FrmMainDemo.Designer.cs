namespace Nikita.Core.Sample
{
    partial class FrmMainDemo
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            Nikita.WinForm.ExtendControl.DockPanelSkin dockPanelSkin1 = new Nikita.WinForm.ExtendControl.DockPanelSkin();
            Nikita.WinForm.ExtendControl.AutoHideStripSkin autoHideStripSkin1 = new Nikita.WinForm.ExtendControl.AutoHideStripSkin();
            Nikita.WinForm.ExtendControl.DockPanelGradient dockPanelGradient1 = new Nikita.WinForm.ExtendControl.DockPanelGradient();
            Nikita.WinForm.ExtendControl.TabGradient tabGradient1 = new Nikita.WinForm.ExtendControl.TabGradient();
            Nikita.WinForm.ExtendControl.DockPaneStripSkin dockPaneStripSkin1 = new Nikita.WinForm.ExtendControl.DockPaneStripSkin();
            Nikita.WinForm.ExtendControl.DockPaneStripGradient dockPaneStripGradient1 = new Nikita.WinForm.ExtendControl.DockPaneStripGradient();
            Nikita.WinForm.ExtendControl.TabGradient tabGradient2 = new Nikita.WinForm.ExtendControl.TabGradient();
            Nikita.WinForm.ExtendControl.DockPanelGradient dockPanelGradient2 = new Nikita.WinForm.ExtendControl.DockPanelGradient();
            Nikita.WinForm.ExtendControl.TabGradient tabGradient3 = new Nikita.WinForm.ExtendControl.TabGradient();
            Nikita.WinForm.ExtendControl.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new Nikita.WinForm.ExtendControl.DockPaneStripToolWindowGradient();
            Nikita.WinForm.ExtendControl.TabGradient tabGradient4 = new Nikita.WinForm.ExtendControl.TabGradient();
            Nikita.WinForm.ExtendControl.TabGradient tabGradient5 = new Nikita.WinForm.ExtendControl.TabGradient();
            Nikita.WinForm.ExtendControl.DockPanelGradient dockPanelGradient3 = new Nikita.WinForm.ExtendControl.DockPanelGradient();
            Nikita.WinForm.ExtendControl.TabGradient tabGradient6 = new Nikita.WinForm.ExtendControl.TabGradient();
            Nikita.WinForm.ExtendControl.TabGradient tabGradient7 = new Nikita.WinForm.ExtendControl.TabGradient();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.dockPanel1 = new Nikita.WinForm.ExtendControl.DockPanel();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(884, 24);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "menuStrip1";
            // 
            // dockPanel1
            // 
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.Location = new System.Drawing.Point(0, 24);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.RightToLeftLayout = true;
            this.dockPanel1.Size = new System.Drawing.Size(884, 537);
            dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
            tabGradient1.EndColor = System.Drawing.SystemColors.Control;
            tabGradient1.StartColor = System.Drawing.SystemColors.Control;
            tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin1.TabGradient = tabGradient1;
            autoHideStripSkin1.TextFont = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
            tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
            dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
            tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
            dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
            dockPaneStripSkin1.TextFont = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
            tabGradient5.EndColor = System.Drawing.SystemColors.Control;
            tabGradient5.StartColor = System.Drawing.SystemColors.Control;
            tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
            dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
            tabGradient6.EndColor = System.Drawing.SystemColors.InactiveCaption;
            tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
            dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
            tabGradient7.EndColor = System.Drawing.Color.Transparent;
            tabGradient7.StartColor = System.Drawing.Color.Transparent;
            tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
            dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
            dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
            this.dockPanel1.Skin = dockPanelSkin1;
            this.dockPanel1.TabIndex = 13;
            // 
            // FrmMainDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmMainDemo";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "代码测试主窗体";
            this.Load += new System.EventHandler(this.FrmMainDemo_Load);
            this.Shown += new System.EventHandler(this.FrmMainDemo_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private Nikita.WinForm.ExtendControl.DockPanel dockPanel1;

    }
}

