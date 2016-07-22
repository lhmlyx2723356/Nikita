namespace Nikita.Assist.WcfHost
{
    partial class FrmWcfDataHost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWcfDataHost));
            this.btnStartService = new DevExpress.XtraEditors.SimpleButton();
            this.btnStopService = new DevExpress.XtraEditors.SimpleButton();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.MenuItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ItemStart = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemStop = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.chkAutoRun = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            this.MenuItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoRun.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartService
            // 
            this.btnStartService.Location = new System.Drawing.Point(38, 301);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(89, 30);
            this.btnStartService.TabIndex = 0;
            this.btnStartService.Text = "启动服务";
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // btnStopService
            // 
            this.btnStopService.Location = new System.Drawing.Point(143, 301);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(89, 30);
            this.btnStopService.TabIndex = 1;
            this.btnStopService.Text = "停止服务";
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Location = new System.Drawing.Point(31, 14);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(590, 274);
            this.listBoxControl1.TabIndex = 2;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.MenuItem;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "数据访问服务端";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // MenuItem
            // 
            this.MenuItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemStart,
            this.ItemStop,
            this.ItemRestart,
            this.ItemExit});
            this.MenuItem.Name = "MenuItem";
            this.MenuItem.Size = new System.Drawing.Size(125, 92);
            // 
            // ItemStart
            // 
            this.ItemStart.Name = "ItemStart";
            this.ItemStart.Size = new System.Drawing.Size(124, 22);
            this.ItemStart.Text = "启动服务";
            this.ItemStart.Click += new System.EventHandler(this.ItemStart_Click);
            // 
            // ItemStop
            // 
            this.ItemStop.Name = "ItemStop";
            this.ItemStop.Size = new System.Drawing.Size(124, 22);
            this.ItemStop.Text = "停止服务";
            this.ItemStop.Click += new System.EventHandler(this.ItemStop_Click);
            // 
            // ItemRestart
            // 
            this.ItemRestart.Name = "ItemRestart";
            this.ItemRestart.Size = new System.Drawing.Size(124, 22);
            this.ItemRestart.Text = "重启服务";
            this.ItemRestart.Click += new System.EventHandler(this.ItemRestart_Click);
            // 
            // ItemExit
            // 
            this.ItemExit.Name = "ItemExit";
            this.ItemExit.Size = new System.Drawing.Size(124, 22);
            this.ItemExit.Text = "退出";
            this.ItemExit.Click += new System.EventHandler(this.ItemExit_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(533, 300);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(89, 30);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "完全退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // chkAutoRun
            // 
            this.chkAutoRun.Location = new System.Drawing.Point(239, 311);
            this.chkAutoRun.Name = "chkAutoRun";
            this.chkAutoRun.Properties.Caption = "开机自动启动";
            this.chkAutoRun.Size = new System.Drawing.Size(99, 19);
            this.chkAutoRun.TabIndex = 4;
            this.chkAutoRun.CheckedChanged += new System.EventHandler(this.chkAutoRun_CheckedChanged);
            // 
            // FrmWcfDataHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 338);
            this.Controls.Add(this.chkAutoRun);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.listBoxControl1);
            this.Controls.Add(this.btnStopService);
            this.Controls.Add(this.btnStartService);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWcfDataHost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据访问服务端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWcfDataHost_FormClosing);
            this.Load += new System.EventHandler(this.frmWcfDataHost_Load);
            this.SizeChanged += new System.EventHandler(this.frmWcfDataHost_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            this.MenuItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoRun.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnStartService;
        private DevExpress.XtraEditors.SimpleButton btnStopService;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ItemRestart;
        private System.Windows.Forms.ToolStripMenuItem ItemStart;
        private System.Windows.Forms.ToolStripMenuItem ItemStop;
        private System.Windows.Forms.ToolStripMenuItem ItemExit;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.CheckEdit chkAutoRun;
    }
}

