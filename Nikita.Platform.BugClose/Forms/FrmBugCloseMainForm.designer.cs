using Nikita.WinForm.ExtendControl;
using WeifenLuo.WinFormsUI.Docking;

namespace Nikita.Platform.BugClose
{
    sealed partial class FrmBugCloseMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCloseAllButThisOne = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSchemaVS2012Light = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.vS2013LightTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2013LightTheme();
            this.vS2013DarkTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2013DarkTheme();
            this.vS2012BlueTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2012BlueTheme();
            this.vS2013BlueTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2013BlueTheme();
            this.vS2012DarkTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2012DarkTheme();
            this.menuItemSchemaVS2012Blue = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSchemaVS2012Dark = new System.Windows.Forms.ToolStripMenuItem();
            this.vS2012ToolStripExtender1 = new Nikita.Platform.BugClose.VSToolStripExtender(this.components);
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemTools,
            this.menuItemHelp});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(784, 25);
            this.mainMenu.TabIndex = 7;
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemClose,
            this.menuItemCloseAll,
            this.menuItemCloseAllButThisOne,
            this.menuItem4,
            this.menuItemExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(44, 21);
            this.menuItemFile.Text = "系统";
            // 
            // menuItemClose
            // 
            this.menuItemClose.Name = "menuItemClose";
            this.menuItemClose.Size = new System.Drawing.Size(172, 22);
            this.menuItemClose.Text = "关闭";
            this.menuItemClose.Click += new System.EventHandler(this.menuItemClose_Click);
            // 
            // menuItemCloseAll
            // 
            this.menuItemCloseAll.Name = "menuItemCloseAll";
            this.menuItemCloseAll.Size = new System.Drawing.Size(172, 22);
            this.menuItemCloseAll.Text = "关闭所有";
            this.menuItemCloseAll.Click += new System.EventHandler(this.menuItemCloseAll_Click);
            // 
            // menuItemCloseAllButThisOne
            // 
            this.menuItemCloseAllButThisOne.Name = "menuItemCloseAllButThisOne";
            this.menuItemCloseAllButThisOne.Size = new System.Drawing.Size(172, 22);
            this.menuItemCloseAllButThisOne.Text = "除此之外全部关闭";
            this.menuItemCloseAllButThisOne.Click += new System.EventHandler(this.menuItemCloseAllButThisOne_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Name = "menuItem4";
            this.menuItem4.Size = new System.Drawing.Size(169, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(172, 22);
            this.menuItemExit.Text = "退出";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemTools
            // 
            this.menuItemTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSchemaVS2012Light,
            this.menuItemSchemaVS2012Blue,
            this.menuItemSchemaVS2012Dark});
            this.menuItemTools.MergeIndex = 2;
            this.menuItemTools.Name = "menuItemTools";
            this.menuItemTools.Size = new System.Drawing.Size(44, 21);
            this.menuItemTools.Text = "样式";
            // 
            // menuItemSchemaVS2012Light
            // 
            this.menuItemSchemaVS2012Light.Checked = true;
            this.menuItemSchemaVS2012Light.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemSchemaVS2012Light.Name = "menuItemSchemaVS2012Light";
            this.menuItemSchemaVS2012Light.Size = new System.Drawing.Size(203, 22);
            this.menuItemSchemaVS2012Light.Text = "Schema: VS2012 Light";
            this.menuItemSchemaVS2012Light.Click += new System.EventHandler(this.SetSchema);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAbout});
            this.menuItemHelp.MergeIndex = 3;
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(44, 21);
            this.menuItemHelp.Text = "帮助";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.Size = new System.Drawing.Size(100, 22);
            this.menuItemAbout.Text = "关于";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 539);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(784, 22);
            this.statusBar.TabIndex = 4;
            // 
            // dockPanel
            // 
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DockBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.dockPanel.DockBottomPortion = 150D;
            this.dockPanel.DockLeftPortion = 200D;
            this.dockPanel.DockRightPortion = 200D;
            this.dockPanel.DockTopPortion = 150D;
            this.dockPanel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.dockPanel.Location = new System.Drawing.Point(0, 25);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.RightToLeftLayout = true;
            this.dockPanel.Size = new System.Drawing.Size(784, 514);
            this.dockPanel.TabIndex = 10;
            // 
            // menuItemSchemaVS2012Blue
            // 
            this.menuItemSchemaVS2012Blue.Name = "menuItemSchemaVS2012Blue";
            this.menuItemSchemaVS2012Blue.Size = new System.Drawing.Size(203, 22);
            this.menuItemSchemaVS2012Blue.Text = "Schema: VS2012 Blue";
            this.menuItemSchemaVS2012Blue.Click += new System.EventHandler(this.SetSchema);
            // 
            // menuItemSchemaVS2012Dark
            // 
            this.menuItemSchemaVS2012Dark.Name = "menuItemSchemaVS2012Dark";
            this.menuItemSchemaVS2012Dark.Size = new System.Drawing.Size(203, 22);
            this.menuItemSchemaVS2012Dark.Text = "Schema: VS2012 Dark";
            this.menuItemSchemaVS2012Dark.Click += new System.EventHandler(this.SetSchema);
            // 
            // vS2012ToolStripExtender1
            // 
            this.vS2012ToolStripExtender1.DefaultRenderer = null;
            this.vS2012ToolStripExtender1.VS2012Renderer = null;
            this.vS2012ToolStripExtender1.VS2013Renderer = null;
            // 
            // FrmBugCloseMainForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.statusBar);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "FrmBugCloseMainForm";
            this.ShowIcon = false;
            this.Text = "主界面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
         
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemClose;
        private System.Windows.Forms.ToolStripMenuItem menuItemCloseAll;
        private System.Windows.Forms.ToolStripMenuItem menuItemCloseAllButThisOne;
        private System.Windows.Forms.ToolStripSeparator menuItem4;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemTools;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripMenuItem menuItemSchemaVS2012Light;
        private VS2012LightTheme vS2012LightTheme1;
        private VS2003Theme vS2003Theme1;
        private DockPanel dockPanel;
        private VS2013LightTheme vS2013LightTheme1;
        private VS2013DarkTheme vS2013DarkTheme1;
        private VS2012BlueTheme vS2012BlueTheme1;
        private VS2013BlueTheme vS2013BlueTheme1;
        private VS2012DarkTheme vS2012DarkTheme1;
        private VSToolStripExtender vS2012ToolStripExtender1;
        private System.Windows.Forms.ToolStripMenuItem menuItemSchemaVS2012Blue;
        private System.Windows.Forms.ToolStripMenuItem menuItemSchemaVS2012Dark;
    }
}