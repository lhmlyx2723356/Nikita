namespace Nikita.Assist.WcfHost
{
    partial class FrmWcfHost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWcfHost));
            this.btnStartService = new System.Windows.Forms.Button();
            this.btnStopService = new System.Windows.Forms.Button();
            this.chkAutoRun = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.MenuItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ItemStart = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemStop = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grpServices = new System.Windows.Forms.GroupBox();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.rcbAddress = new System.Windows.Forms.RichTextBox();
            this.grpAddress = new System.Windows.Forms.GroupBox();
            this.rcbState = new System.Windows.Forms.RichTextBox();
            this.MenuItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.grpServices.SuspendLayout();
            this.grpStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.grpAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartService
            // 
            this.btnStartService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartService.Location = new System.Drawing.Point(15, 19);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(89, 30);
            this.btnStartService.TabIndex = 1;
            this.btnStartService.Text = "启动服务";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // btnStopService
            // 
            this.btnStopService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopService.Location = new System.Drawing.Point(111, 19);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(89, 30);
            this.btnStopService.TabIndex = 2;
            this.btnStopService.Text = "停止服务";
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // chkAutoRun
            // 
            this.chkAutoRun.AutoSize = true;
            this.chkAutoRun.Location = new System.Drawing.Point(206, 32);
            this.chkAutoRun.Name = "chkAutoRun";
            this.chkAutoRun.Size = new System.Drawing.Size(96, 16);
            this.chkAutoRun.TabIndex = 3;
            this.chkAutoRun.Text = "开机自动启动";
            this.chkAutoRun.UseVisualStyleBackColor = true;
            this.chkAutoRun.CheckedChanged += new System.EventHandler(this.chkAutoRun_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(632, 18);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(89, 30);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "完全退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.MenuItem.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnStartService);
            this.splitContainer1.Panel2.Controls.Add(this.btnStopService);
            this.splitContainer1.Panel2.Controls.Add(this.btnExit);
            this.splitContainer1.Panel2.Controls.Add(this.chkAutoRun);
            this.splitContainer1.Size = new System.Drawing.Size(733, 438);
            this.splitContainer1.SplitterDistance = 371;
            this.splitContainer1.TabIndex = 5;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.grpServices);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grpStatus);
            this.splitContainer2.Size = new System.Drawing.Size(733, 371);
            this.splitContainer2.SplitterDistance = 347;
            this.splitContainer2.TabIndex = 1;
            // 
            // grpServices
            // 
            this.grpServices.Controls.Add(this.splitContainer3);
            this.grpServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpServices.Location = new System.Drawing.Point(0, 0);
            this.grpServices.Name = "grpServices";
            this.grpServices.Size = new System.Drawing.Size(347, 371);
            this.grpServices.TabIndex = 0;
            this.grpServices.TabStop = false;
            this.grpServices.Text = "服务列表";
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.rcbState);
            this.grpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStatus.Location = new System.Drawing.Point(0, 0);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(382, 371);
            this.grpStatus.TabIndex = 0;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "启动状态";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 17);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.grpAddress);
            this.splitContainer3.Size = new System.Drawing.Size(341, 351);
            this.splitContainer3.SplitterDistance = 253;
            this.splitContainer3.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(341, 253);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // rcbAddress
            // 
            this.rcbAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rcbAddress.Location = new System.Drawing.Point(3, 17);
            this.rcbAddress.Name = "rcbAddress";
            this.rcbAddress.Size = new System.Drawing.Size(335, 74);
            this.rcbAddress.TabIndex = 4;
            this.rcbAddress.Text = "";
            // 
            // grpAddress
            // 
            this.grpAddress.Controls.Add(this.rcbAddress);
            this.grpAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAddress.Location = new System.Drawing.Point(0, 0);
            this.grpAddress.Name = "grpAddress";
            this.grpAddress.Size = new System.Drawing.Size(341, 94);
            this.grpAddress.TabIndex = 0;
            this.grpAddress.TabStop = false;
            this.grpAddress.Text = "服务地址";
            // 
            // rcbState
            // 
            this.rcbState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rcbState.Location = new System.Drawing.Point(3, 17);
            this.rcbState.Name = "rcbState";
            this.rcbState.Size = new System.Drawing.Size(376, 351);
            this.rcbState.TabIndex = 2;
            this.rcbState.Text = "";
            // 
            // FrmWcfHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 438);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWcfHost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWcfHost_FormClosing);
            this.Load += new System.EventHandler(this.FrmWcfHost_Load);
            this.SizeChanged += new System.EventHandler(this.FrmWcfHost_SizeChanged);
            this.MenuItem.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.grpServices.ResumeLayout(false);
            this.grpStatus.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.grpAddress.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartService;
        private System.Windows.Forms.Button btnStopService;
        private System.Windows.Forms.CheckBox chkAutoRun;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ItemStart;
        private System.Windows.Forms.ToolStripMenuItem ItemStop;
        private System.Windows.Forms.ToolStripMenuItem ItemRestart;
        private System.Windows.Forms.ToolStripMenuItem ItemExit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox grpServices;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox grpAddress;
        private System.Windows.Forms.RichTextBox rcbAddress;
        private System.Windows.Forms.RichTextBox rcbState;
    }
}