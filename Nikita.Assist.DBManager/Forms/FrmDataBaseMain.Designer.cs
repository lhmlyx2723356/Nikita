namespace Nikita.Assist.DBManager
{
    partial class FrmDataBaseMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDataBaseMain));
            Nikita.WinForm.ExtendControl.DockPanelSkin dockPanelSkin2 = new Nikita.WinForm.ExtendControl.DockPanelSkin();
            Nikita.WinForm.ExtendControl.AutoHideStripSkin autoHideStripSkin2 = new Nikita.WinForm.ExtendControl.AutoHideStripSkin();
            Nikita.WinForm.ExtendControl.DockPanelGradient dockPanelGradient4 = new Nikita.WinForm.ExtendControl.DockPanelGradient();
            Nikita.WinForm.ExtendControl.TabGradient tabGradient8 = new Nikita.WinForm.ExtendControl.TabGradient();
            Nikita.WinForm.ExtendControl.DockPaneStripSkin dockPaneStripSkin2 = new Nikita.WinForm.ExtendControl.DockPaneStripSkin();
            Nikita.WinForm.ExtendControl.DockPaneStripGradient dockPaneStripGradient2 = new Nikita.WinForm.ExtendControl.DockPaneStripGradient();
            Nikita.WinForm.ExtendControl.TabGradient tabGradient9 = new Nikita.WinForm.ExtendControl.TabGradient();
            Nikita.WinForm.ExtendControl.DockPanelGradient dockPanelGradient5 = new Nikita.WinForm.ExtendControl.DockPanelGradient();
            Nikita.WinForm.ExtendControl.TabGradient tabGradient10 = new Nikita.WinForm.ExtendControl.TabGradient();
            Nikita.WinForm.ExtendControl.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient2 = new Nikita.WinForm.ExtendControl.DockPaneStripToolWindowGradient();
            Nikita.WinForm.ExtendControl.TabGradient tabGradient11 = new Nikita.WinForm.ExtendControl.TabGradient();
            Nikita.WinForm.ExtendControl.TabGradient tabGradient12 = new Nikita.WinForm.ExtendControl.TabGradient();
            Nikita.WinForm.ExtendControl.DockPanelGradient dockPanelGradient6 = new Nikita.WinForm.ExtendControl.DockPanelGradient();
            Nikita.WinForm.ExtendControl.TabGradient tabGradient13 = new Nikita.WinForm.ExtendControl.TabGradient();
            Nikita.WinForm.ExtendControl.TabGradient tabGradient14 = new Nikita.WinForm.ExtendControl.TabGradient();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdLinkDB = new System.Windows.Forms.ToolStripMenuItem();
            this.新建SQLServer连接ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.新建MySql连接ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.新建SQLite连接ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.新建MongoDB连接ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.断开连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分析ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.脚本批量执行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.代码生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据同步ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.表信息设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同步数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.快捷键列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.版本记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试批量插入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.cmdNewLink = new System.Windows.Forms.ToolStripDropDownButton();
            this.新建SqlServer连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建MySql连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建SQLite连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建MongoDB连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdNewQuery = new System.Windows.Forms.ToolStripButton();
            this.cmdTable = new System.Windows.Forms.ToolStripButton();
            this.cmdView = new System.Windows.Forms.ToolStripButton();
            this.cmdFunction = new System.Windows.Forms.ToolStripButton();
            this.cmdProc = new System.Windows.Forms.ToolStripButton();
            this.cmdDbRelationView = new System.Windows.Forms.ToolStripButton();
            this.cmdRefreshAgain = new System.Windows.Forms.ToolStripButton();
            this.cmdSearch = new System.Windows.Forms.ToolStripButton();
            this.cmdCodeMaker = new System.Windows.Forms.ToolStripButton();
            this.txtDefaultDatabase = new System.Windows.Forms.ToolStripTextBox();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.bckWorker = new System.ComponentModel.BackgroundWorker();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmdProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblMemory = new System.Windows.Forms.ToolStripStatusLabel();
            this.dockPanel = new Nikita.WinForm.ExtendControl.DockPanel();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.分析ToolStripMenuItem,
            this.数据同步ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(920, 25);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdLinkDB,
            this.断开连接ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(50, 21);
            this.文件FToolStripMenuItem.Text = "文件&F";
            // 
            // cmdLinkDB
            // 
            this.cmdLinkDB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建SQLServer连接ToolStripMenuItem1,
            this.新建MySql连接ToolStripMenuItem1,
            this.新建SQLite连接ToolStripMenuItem1,
            this.新建MongoDB连接ToolStripMenuItem1});
            this.cmdLinkDB.Image = ((System.Drawing.Image)(resources.GetObject("cmdLinkDB.Image")));
            this.cmdLinkDB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLinkDB.Name = "cmdLinkDB";
            this.cmdLinkDB.Size = new System.Drawing.Size(124, 22);
            this.cmdLinkDB.Text = "新建连接";
            // 
            // 新建SQLServer连接ToolStripMenuItem1
            // 
            this.新建SQLServer连接ToolStripMenuItem1.Name = "新建SQLServer连接ToolStripMenuItem1";
            this.新建SQLServer连接ToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.新建SQLServer连接ToolStripMenuItem1.Text = "新建SqlServer连接";
            this.新建SQLServer连接ToolStripMenuItem1.Click += new System.EventHandler(this.NewLinkServer_Click);
            // 
            // 新建MySql连接ToolStripMenuItem1
            // 
            this.新建MySql连接ToolStripMenuItem1.Name = "新建MySql连接ToolStripMenuItem1";
            this.新建MySql连接ToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.新建MySql连接ToolStripMenuItem1.Text = "新建MySql连接";
            this.新建MySql连接ToolStripMenuItem1.Click += new System.EventHandler(this.NewLinkServer_Click);
            // 
            // 新建SQLite连接ToolStripMenuItem1
            // 
            this.新建SQLite连接ToolStripMenuItem1.Name = "新建SQLite连接ToolStripMenuItem1";
            this.新建SQLite连接ToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.新建SQLite连接ToolStripMenuItem1.Text = "新建SQLite连接";
            this.新建SQLite连接ToolStripMenuItem1.Click += new System.EventHandler(this.NewLinkServer_Click);
            // 
            // 新建MongoDB连接ToolStripMenuItem1
            // 
            this.新建MongoDB连接ToolStripMenuItem1.Name = "新建MongoDB连接ToolStripMenuItem1";
            this.新建MongoDB连接ToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.新建MongoDB连接ToolStripMenuItem1.Text = "新建MongoDB连接";
            this.新建MongoDB连接ToolStripMenuItem1.Click += new System.EventHandler(this.NewLinkServer_Click);
            // 
            // 断开连接ToolStripMenuItem
            // 
            this.断开连接ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("断开连接ToolStripMenuItem.Image")));
            this.断开连接ToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.断开连接ToolStripMenuItem.Name = "断开连接ToolStripMenuItem";
            this.断开连接ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.断开连接ToolStripMenuItem.Text = "断开连接";
            this.断开连接ToolStripMenuItem.Click += new System.EventHandler(this.断开连接ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("退出ToolStripMenuItem.Image")));
            this.退出ToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 分析ToolStripMenuItem
            // 
            this.分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.分析ToolStripMenuItem1,
            this.脚本批量执行ToolStripMenuItem,
            this.代码生成ToolStripMenuItem});
            this.分析ToolStripMenuItem.Name = "分析ToolStripMenuItem";
            this.分析ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.分析ToolStripMenuItem.Text = "工具";
            // 
            // 分析ToolStripMenuItem1
            // 
            this.分析ToolStripMenuItem1.Name = "分析ToolStripMenuItem1";
            this.分析ToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.分析ToolStripMenuItem1.Text = "分析";
            this.分析ToolStripMenuItem1.Click += new System.EventHandler(this.分析ToolStripMenuItem1_Click);
            // 
            // 脚本批量执行ToolStripMenuItem
            // 
            this.脚本批量执行ToolStripMenuItem.Name = "脚本批量执行ToolStripMenuItem";
            this.脚本批量执行ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.脚本批量执行ToolStripMenuItem.Text = "脚本批量执行";
            this.脚本批量执行ToolStripMenuItem.Click += new System.EventHandler(this.脚本批量执行ToolStripMenuItem_Click);
            // 
            // 代码生成ToolStripMenuItem
            // 
            this.代码生成ToolStripMenuItem.Name = "代码生成ToolStripMenuItem";
            this.代码生成ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.代码生成ToolStripMenuItem.Text = "代码生成";
            this.代码生成ToolStripMenuItem.Click += new System.EventHandler(this.代码生成ToolStripMenuItem_Click);
            // 
            // 数据同步ToolStripMenuItem
            // 
            this.数据同步ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.表信息设置ToolStripMenuItem,
            this.同步数据ToolStripMenuItem});
            this.数据同步ToolStripMenuItem.Name = "数据同步ToolStripMenuItem";
            this.数据同步ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据同步ToolStripMenuItem.Text = "数据同步";
            // 
            // 表信息设置ToolStripMenuItem
            // 
            this.表信息设置ToolStripMenuItem.Name = "表信息设置ToolStripMenuItem";
            this.表信息设置ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.表信息设置ToolStripMenuItem.Text = "表信息设置";
            this.表信息设置ToolStripMenuItem.Click += new System.EventHandler(this.表信息设置ToolStripMenuItem_Click);
            // 
            // 同步数据ToolStripMenuItem
            // 
            this.同步数据ToolStripMenuItem.Name = "同步数据ToolStripMenuItem";
            this.同步数据ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.同步数据ToolStripMenuItem.Text = "同步数据";
            this.同步数据ToolStripMenuItem.Click += new System.EventHandler(this.同步数据ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.快捷键列表ToolStripMenuItem,
            this.版本记录ToolStripMenuItem,
            this.关于工具ToolStripMenuItem,
            this.测试批量插入ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 快捷键列表ToolStripMenuItem
            // 
            this.快捷键列表ToolStripMenuItem.Name = "快捷键列表ToolStripMenuItem";
            this.快捷键列表ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.快捷键列表ToolStripMenuItem.Text = "快捷键列表";
            this.快捷键列表ToolStripMenuItem.Click += new System.EventHandler(this.快捷键列表ToolStripMenuItem_Click);
            // 
            // 版本记录ToolStripMenuItem
            // 
            this.版本记录ToolStripMenuItem.Name = "版本记录ToolStripMenuItem";
            this.版本记录ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.版本记录ToolStripMenuItem.Text = "版本记录";
            // 
            // 关于工具ToolStripMenuItem
            // 
            this.关于工具ToolStripMenuItem.Name = "关于工具ToolStripMenuItem";
            this.关于工具ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.关于工具ToolStripMenuItem.Text = "关于工具";
            // 
            // 测试批量插入ToolStripMenuItem
            // 
            this.测试批量插入ToolStripMenuItem.Name = "测试批量插入ToolStripMenuItem";
            this.测试批量插入ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.测试批量插入ToolStripMenuItem.Text = "测试批量插入";
            this.测试批量插入ToolStripMenuItem.Click += new System.EventHandler(this.测试批量插入ToolStripMenuItem_Click);
            // 
            // toolBar
            // 
            this.toolBar.AutoSize = false;
            this.toolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdNewLink,
            this.cmdNewQuery,
            this.cmdTable,
            this.cmdView,
            this.cmdFunction,
            this.cmdProc,
            this.cmdDbRelationView,
            this.cmdRefreshAgain,
            this.cmdSearch,
            this.cmdCodeMaker,
            this.txtDefaultDatabase});
            this.toolBar.Location = new System.Drawing.Point(0, 25);
            this.toolBar.Name = "toolBar";
            this.toolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolBar.Size = new System.Drawing.Size(920, 80);
            this.toolBar.TabIndex = 16;
            // 
            // cmdNewLink
            // 
            this.cmdNewLink.AutoSize = false;
            this.cmdNewLink.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建SqlServer连接ToolStripMenuItem,
            this.新建MySql连接ToolStripMenuItem,
            this.新建SQLite连接ToolStripMenuItem,
            this.新建MongoDB连接ToolStripMenuItem});
            this.cmdNewLink.Image = ((System.Drawing.Image)(resources.GetObject("cmdNewLink.Image")));
            this.cmdNewLink.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdNewLink.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdNewLink.Name = "cmdNewLink";
            this.cmdNewLink.Size = new System.Drawing.Size(80, 55);
            this.cmdNewLink.Text = "新建连接";
            this.cmdNewLink.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdNewLink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // 新建SqlServer连接ToolStripMenuItem
            // 
            this.新建SqlServer连接ToolStripMenuItem.Name = "新建SqlServer连接ToolStripMenuItem";
            this.新建SqlServer连接ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.新建SqlServer连接ToolStripMenuItem.Text = "新建SqlServer连接";
            this.新建SqlServer连接ToolStripMenuItem.Click += new System.EventHandler(this.NewLinkServer_Click);
            // 
            // 新建MySql连接ToolStripMenuItem
            // 
            this.新建MySql连接ToolStripMenuItem.Name = "新建MySql连接ToolStripMenuItem";
            this.新建MySql连接ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.新建MySql连接ToolStripMenuItem.Text = "新建MySql连接";
            this.新建MySql连接ToolStripMenuItem.Click += new System.EventHandler(this.NewLinkServer_Click);
            // 
            // 新建SQLite连接ToolStripMenuItem
            // 
            this.新建SQLite连接ToolStripMenuItem.Name = "新建SQLite连接ToolStripMenuItem";
            this.新建SQLite连接ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.新建SQLite连接ToolStripMenuItem.Text = "新建SQLite连接";
            this.新建SQLite连接ToolStripMenuItem.Click += new System.EventHandler(this.NewLinkServer_Click);
            // 
            // 新建MongoDB连接ToolStripMenuItem
            // 
            this.新建MongoDB连接ToolStripMenuItem.Name = "新建MongoDB连接ToolStripMenuItem";
            this.新建MongoDB连接ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.新建MongoDB连接ToolStripMenuItem.Text = "新建MongoDB连接";
            this.新建MongoDB连接ToolStripMenuItem.Click += new System.EventHandler(this.NewLinkServer_Click);
            // 
            // cmdNewQuery
            // 
            this.cmdNewQuery.AutoSize = false;
            this.cmdNewQuery.Image = ((System.Drawing.Image)(resources.GetObject("cmdNewQuery.Image")));
            this.cmdNewQuery.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdNewQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdNewQuery.Name = "cmdNewQuery";
            this.cmdNewQuery.Size = new System.Drawing.Size(80, 55);
            this.cmdNewQuery.Text = "新建查询(&Z)";
            this.cmdNewQuery.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdNewQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdNewQuery.Click += new System.EventHandler(this.cmdNewQuery_Click);
            // 
            // cmdTable
            // 
            this.cmdTable.AutoSize = false;
            this.cmdTable.Image = ((System.Drawing.Image)(resources.GetObject("cmdTable.Image")));
            this.cmdTable.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdTable.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdTable.Name = "cmdTable";
            this.cmdTable.Size = new System.Drawing.Size(80, 55);
            this.cmdTable.Text = "表";
            this.cmdTable.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdTable.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdTable.Click += new System.EventHandler(this.cmdTable_Click);
            // 
            // cmdView
            // 
            this.cmdView.AutoSize = false;
            this.cmdView.Image = ((System.Drawing.Image)(resources.GetObject("cmdView.Image")));
            this.cmdView.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdView.Name = "cmdView";
            this.cmdView.Size = new System.Drawing.Size(80, 55);
            this.cmdView.Text = "视图";
            this.cmdView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
            // 
            // cmdFunction
            // 
            this.cmdFunction.AutoSize = false;
            this.cmdFunction.Image = ((System.Drawing.Image)(resources.GetObject("cmdFunction.Image")));
            this.cmdFunction.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdFunction.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdFunction.Name = "cmdFunction";
            this.cmdFunction.Size = new System.Drawing.Size(80, 55);
            this.cmdFunction.Text = "函数";
            this.cmdFunction.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdFunction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdFunction.Click += new System.EventHandler(this.cmdFunction_Click);
            // 
            // cmdProc
            // 
            this.cmdProc.AutoSize = false;
            this.cmdProc.Image = ((System.Drawing.Image)(resources.GetObject("cmdProc.Image")));
            this.cmdProc.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdProc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdProc.Name = "cmdProc";
            this.cmdProc.Size = new System.Drawing.Size(80, 55);
            this.cmdProc.Text = "存储过程";
            this.cmdProc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdProc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdProc.Click += new System.EventHandler(this.cmdProc_Click);
            // 
            // cmdDbRelationView
            // 
            this.cmdDbRelationView.AutoSize = false;
            this.cmdDbRelationView.Image = ((System.Drawing.Image)(resources.GetObject("cmdDbRelationView.Image")));
            this.cmdDbRelationView.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdDbRelationView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdDbRelationView.Name = "cmdDbRelationView";
            this.cmdDbRelationView.Size = new System.Drawing.Size(80, 55);
            this.cmdDbRelationView.Text = "数据库关系图";
            this.cmdDbRelationView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdDbRelationView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdDbRelationView.Click += new System.EventHandler(this.cmdDbRelationView_Click);
            // 
            // cmdRefreshAgain
            // 
            this.cmdRefreshAgain.AutoSize = false;
            this.cmdRefreshAgain.Image = ((System.Drawing.Image)(resources.GetObject("cmdRefreshAgain.Image")));
            this.cmdRefreshAgain.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdRefreshAgain.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdRefreshAgain.Name = "cmdRefreshAgain";
            this.cmdRefreshAgain.Size = new System.Drawing.Size(80, 55);
            this.cmdRefreshAgain.Text = "重新刷新";
            this.cmdRefreshAgain.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdRefreshAgain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdRefreshAgain.Click += new System.EventHandler(this.cmdRefreshAgain_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.AutoSize = false;
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 55);
            this.cmdSearch.Text = "搜索";
            this.cmdSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdCodeMaker
            // 
            this.cmdCodeMaker.AutoSize = false;
            this.cmdCodeMaker.Image = ((System.Drawing.Image)(resources.GetObject("cmdCodeMaker.Image")));
            this.cmdCodeMaker.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdCodeMaker.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdCodeMaker.Name = "cmdCodeMaker";
            this.cmdCodeMaker.Size = new System.Drawing.Size(80, 55);
            this.cmdCodeMaker.Text = "代码生成";
            this.cmdCodeMaker.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdCodeMaker.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdCodeMaker.Click += new System.EventHandler(this.cmdCodeMaker_Click_1);
            // 
            // txtDefaultDatabase
            // 
            this.txtDefaultDatabase.Name = "txtDefaultDatabase";
            this.txtDefaultDatabase.Size = new System.Drawing.Size(100, 80);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "00758.png");
            this.imgList.Images.SetKeyName(1, "00066.png");
            this.imgList.Images.SetKeyName(2, "00083.png");
            this.imgList.Images.SetKeyName(3, "00405.png");
            this.imgList.Images.SetKeyName(4, "");
            // 
            // bckWorker
            // 
            this.bckWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BckWorkerDoWork);
            this.bckWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BckWorkerRunWorkerCompleted);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.cmdProgressBar,
            this.lblMemory});
            this.statusStrip.Location = new System.Drawing.Point(0, 401);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(920, 22);
            this.statusStrip.TabIndex = 27;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // cmdProgressBar
            // 
            this.cmdProgressBar.Name = "cmdProgressBar";
            this.cmdProgressBar.Size = new System.Drawing.Size(100, 16);
            this.cmdProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.cmdProgressBar.Visible = false;
            // 
            // lblMemory
            // 
            this.lblMemory.Name = "lblMemory";
            this.lblMemory.Size = new System.Drawing.Size(905, 17);
            this.lblMemory.Spring = true;
            // 
            // dockPanel
            // 
            this.dockPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.Location = new System.Drawing.Point(0, 105);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.RightToLeftLayout = true;
            this.dockPanel.Size = new System.Drawing.Size(920, 296);
            dockPanelGradient4.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient4.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin2.DockStripGradient = dockPanelGradient4;
            tabGradient8.EndColor = System.Drawing.SystemColors.Control;
            tabGradient8.StartColor = System.Drawing.SystemColors.Control;
            tabGradient8.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin2.TabGradient = tabGradient8;
            autoHideStripSkin2.TextFont = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            dockPanelSkin2.AutoHideStripSkin = autoHideStripSkin2;
            tabGradient9.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient9.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient9.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient2.ActiveTabGradient = tabGradient9;
            dockPanelGradient5.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient5.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient2.DockStripGradient = dockPanelGradient5;
            tabGradient10.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient10.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient10.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient2.InactiveTabGradient = tabGradient10;
            dockPaneStripSkin2.DocumentGradient = dockPaneStripGradient2;
            dockPaneStripSkin2.TextFont = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            tabGradient11.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient11.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient11.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient11.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient2.ActiveCaptionGradient = tabGradient11;
            tabGradient12.EndColor = System.Drawing.SystemColors.Control;
            tabGradient12.StartColor = System.Drawing.SystemColors.Control;
            tabGradient12.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient2.ActiveTabGradient = tabGradient12;
            dockPanelGradient6.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient6.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient2.DockStripGradient = dockPanelGradient6;
            tabGradient13.EndColor = System.Drawing.SystemColors.InactiveCaption;
            tabGradient13.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient13.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient13.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
            dockPaneStripToolWindowGradient2.InactiveCaptionGradient = tabGradient13;
            tabGradient14.EndColor = System.Drawing.Color.Transparent;
            tabGradient14.StartColor = System.Drawing.Color.Transparent;
            tabGradient14.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient2.InactiveTabGradient = tabGradient14;
            dockPaneStripSkin2.ToolWindowGradient = dockPaneStripToolWindowGradient2;
            dockPanelSkin2.DockPaneStripSkin = dockPaneStripSkin2;
            this.dockPanel.Skin = dockPanelSkin2;
            this.dockPanel.TabIndex = 30;
            // 
            // contextMenu
            // 
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // timer
            // 
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FrmDataBaseMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 423);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmDataBaseMain";
            this.RightToLeftLayout = true;
            this.Text = "数据库管理工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDataBaseMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmDataBaseMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripMenuItem cmdLinkDB;
        private System.Windows.Forms.ImageList imgList;
        private System.ComponentModel.BackgroundWorker bckWorker;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem 断开连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton cmdTable;
        private System.Windows.Forms.ToolStripButton cmdView;
        private System.Windows.Forms.ToolStripButton cmdProc;
        private System.Windows.Forms.ToolStripButton cmdFunction;
        private Nikita.WinForm.ExtendControl.DockPanel dockPanel;
        private System.Windows.Forms.ToolStripButton cmdNewQuery;
        private System.Windows.Forms.ToolStripProgressBar cmdProgressBar;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 版本记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton cmdRefreshAgain;
        private System.Windows.Forms.ToolStripButton cmdDbRelationView;
        private System.Windows.Forms.ToolStripDropDownButton cmdNewLink;
        private System.Windows.Forms.ToolStripMenuItem 新建SqlServer连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建MySql连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建SQLServer连接ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 新建MySql连接ToolStripMenuItem1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripStatusLabel lblMemory;
        private System.Windows.Forms.ToolStripMenuItem 快捷键列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建MongoDB连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建MongoDB连接ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分析ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 数据同步ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 表信息设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 同步数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试批量插入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建SQLite连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建SQLite连接ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 脚本批量执行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton cmdSearch;
        private System.Windows.Forms.ToolStripMenuItem 代码生成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton cmdCodeMaker;
        private System.Windows.Forms.ToolStripTextBox txtDefaultDatabase;
    }
}

