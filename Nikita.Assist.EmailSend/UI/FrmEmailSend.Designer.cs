namespace Nikita.Assist.EmailSend
{
    partial class FrmEmailSend
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.grpFromInfo = new System.Windows.Forms.GroupBox();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtShowUser = new System.Windows.Forms.TextBox();
            this.lblShowName = new System.Windows.Forms.Label();
            this.txtEmailDomain = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFromUser = new System.Windows.Forms.TextBox();
            this.txtFromPwd = new System.Windows.Forms.TextBox();
            this.lblFromPwd = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.grpSendSettion = new System.Windows.Forms.GroupBox();
            this.chkUserSetting = new System.Windows.Forms.CheckBox();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grpToUserList = new System.Windows.Forms.GroupBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.grdEmailAddress = new System.Windows.Forms.DataGridView();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEmailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除收件人ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdd = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.grpAttentmentInfo = new System.Windows.Forms.GroupBox();
            this.grdAttemt = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.选择附件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.grpFromInfo.SuspendLayout();
            this.grpSendSettion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.grpToUserList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmailAddress)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.grpAttentmentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAttemt)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(884, 561);
            this.splitContainer1.SplitterDistance = 233;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.grpFromInfo);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.grpSendSettion);
            this.splitContainer5.Size = new System.Drawing.Size(233, 561);
            this.splitContainer5.SplitterDistance = 383;
            this.splitContainer5.TabIndex = 0;
            // 
            // grpFromInfo
            // 
            this.grpFromInfo.Controls.Add(this.txtBody);
            this.grpFromInfo.Controls.Add(this.label1);
            this.grpFromInfo.Controls.Add(this.txtSubject);
            this.grpFromInfo.Controls.Add(this.lblSubject);
            this.grpFromInfo.Controls.Add(this.txtShowUser);
            this.grpFromInfo.Controls.Add(this.lblShowName);
            this.grpFromInfo.Controls.Add(this.txtEmailDomain);
            this.grpFromInfo.Controls.Add(this.label2);
            this.grpFromInfo.Controls.Add(this.txtFromUser);
            this.grpFromInfo.Controls.Add(this.txtFromPwd);
            this.grpFromInfo.Controls.Add(this.lblFromPwd);
            this.grpFromInfo.Controls.Add(this.lblFrom);
            this.grpFromInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFromInfo.Location = new System.Drawing.Point(0, 0);
            this.grpFromInfo.Name = "grpFromInfo";
            this.grpFromInfo.Size = new System.Drawing.Size(233, 383);
            this.grpFromInfo.TabIndex = 9;
            this.grpFromInfo.TabStop = false;
            this.grpFromInfo.Text = "发送人信息";
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(17, 235);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(213, 134);
            this.txtBody.TabIndex = 19;
            this.txtBody.Text = "测试主题";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "内容：";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(17, 196);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(213, 21);
            this.txtSubject.TabIndex = 17;
            this.txtSubject.Text = "测试主题";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(15, 181);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(41, 12);
            this.lblSubject.TabIndex = 16;
            this.lblSubject.Text = "主题：";
            // 
            // txtShowUser
            // 
            this.txtShowUser.Location = new System.Drawing.Point(17, 157);
            this.txtShowUser.Name = "txtShowUser";
            this.txtShowUser.Size = new System.Drawing.Size(213, 21);
            this.txtShowUser.TabIndex = 15;
            this.txtShowUser.Text = "卢华明";
            // 
            // lblShowName
            // 
            this.lblShowName.AutoSize = true;
            this.lblShowName.Location = new System.Drawing.Point(15, 142);
            this.lblShowName.Name = "lblShowName";
            this.lblShowName.Size = new System.Drawing.Size(65, 12);
            this.lblShowName.TabIndex = 14;
            this.lblShowName.Text = "显示名称：";
            // 
            // txtEmailDomain
            // 
            this.txtEmailDomain.Location = new System.Drawing.Point(17, 118);
            this.txtEmailDomain.Name = "txtEmailDomain";
            this.txtEmailDomain.Size = new System.Drawing.Size(213, 21);
            this.txtEmailDomain.TabIndex = 13;
            this.txtEmailDomain.Text = "smtp.163.com";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "邮箱服务：";
            // 
            // txtFromUser
            // 
            this.txtFromUser.Location = new System.Drawing.Point(14, 35);
            this.txtFromUser.Name = "txtFromUser";
            this.txtFromUser.Size = new System.Drawing.Size(213, 21);
            this.txtFromUser.TabIndex = 11;
            this.txtFromUser.Text = "lhmlyx2723356@163.com";
            // 
            // txtFromPwd
            // 
            this.txtFromPwd.Location = new System.Drawing.Point(14, 75);
            this.txtFromPwd.Name = "txtFromPwd";
            this.txtFromPwd.PasswordChar = '*';
            this.txtFromPwd.Size = new System.Drawing.Size(213, 21);
            this.txtFromPwd.TabIndex = 10;
            this.txtFromPwd.Text = "lhmlyx596568568";
            // 
            // lblFromPwd
            // 
            this.lblFromPwd.AutoSize = true;
            this.lblFromPwd.Location = new System.Drawing.Point(15, 60);
            this.lblFromPwd.Name = "lblFromPwd";
            this.lblFromPwd.Size = new System.Drawing.Size(41, 12);
            this.lblFromPwd.TabIndex = 9;
            this.lblFromPwd.Text = "密码：";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(12, 20);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(77, 12);
            this.lblFrom.TabIndex = 8;
            this.lblFrom.Text = "发送人邮箱：";
            // 
            // grpSendSettion
            // 
            this.grpSendSettion.Controls.Add(this.label4);
            this.grpSendSettion.Controls.Add(this.btnInit);
            this.grpSendSettion.Controls.Add(this.chkUserSetting);
            this.grpSendSettion.Controls.Add(this.chkRemember);
            this.grpSendSettion.Controls.Add(this.txtTime);
            this.grpSendSettion.Controls.Add(this.label3);
            this.grpSendSettion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSendSettion.Location = new System.Drawing.Point(0, 0);
            this.grpSendSettion.Name = "grpSendSettion";
            this.grpSendSettion.Size = new System.Drawing.Size(233, 174);
            this.grpSendSettion.TabIndex = 0;
            this.grpSendSettion.TabStop = false;
            this.grpSendSettion.Text = "发送设置";
            // 
            // chkUserSetting
            // 
            this.chkUserSetting.AutoSize = true;
            this.chkUserSetting.Location = new System.Drawing.Point(18, 30);
            this.chkUserSetting.Name = "chkUserSetting";
            this.chkUserSetting.Size = new System.Drawing.Size(96, 16);
            this.chkUserSetting.TabIndex = 3;
            this.chkUserSetting.Text = "开启定时发送";
            this.chkUserSetting.UseVisualStyleBackColor = true;
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.Checked = true;
            this.chkRemember.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemember.Location = new System.Drawing.Point(18, 101);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(120, 16);
            this.chkRemember.TabIndex = 2;
            this.chkRemember.Text = "记录发送失败列表";
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(102, 62);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(57, 21);
            this.txtTime.TabIndex = 1;
            this.txtTime.Text = "30000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "每封间隔时间";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.grpToUserList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(647, 561);
            this.splitContainer2.SplitterDistance = 298;
            this.splitContainer2.TabIndex = 0;
            // 
            // grpToUserList
            // 
            this.grpToUserList.Controls.Add(this.splitContainer4);
            this.grpToUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpToUserList.Location = new System.Drawing.Point(0, 0);
            this.grpToUserList.Name = "grpToUserList";
            this.grpToUserList.Size = new System.Drawing.Size(298, 561);
            this.grpToUserList.TabIndex = 0;
            this.grpToUserList.TabStop = false;
            this.grpToUserList.Text = "接收人邮件列表";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 17);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.grdEmailAddress);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.btnAdd);
            this.splitContainer4.Size = new System.Drawing.Size(292, 541);
            this.splitContainer4.SplitterDistance = 495;
            this.splitContainer4.TabIndex = 0;
            // 
            // grdEmailAddress
            // 
            this.grdEmailAddress.AllowUserToAddRows = false;
            this.grdEmailAddress.AllowUserToDeleteRows = false;
            this.grdEmailAddress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEmailAddress.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.Column1,
            this.ColEmailAddress});
            this.grdEmailAddress.ContextMenuStrip = this.contextMenuStrip1;
            this.grdEmailAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEmailAddress.Location = new System.Drawing.Point(0, 0);
            this.grdEmailAddress.Name = "grdEmailAddress";
            this.grdEmailAddress.RowTemplate.Height = 23;
            this.grdEmailAddress.Size = new System.Drawing.Size(292, 495);
            this.grdEmailAddress.TabIndex = 1;
            this.grdEmailAddress.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdEmailAddress_CellClick);
            // 
            // ColId
            // 
            this.ColId.DataPropertyName = "id";
            this.ColId.HeaderText = "序号";
            this.ColId.Name = "ColId";
            this.ColId.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Remark";
            this.Column1.HeaderText = "名称";
            this.Column1.Name = "Column1";
            // 
            // ColEmailAddress
            // 
            this.ColEmailAddress.DataPropertyName = "EmailAddress";
            this.ColEmailAddress.HeaderText = "地址";
            this.ColEmailAddress.Name = "ColEmailAddress";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加ToolStripMenuItem,
            this.删除收件人ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 48);
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.添加ToolStripMenuItem.Text = "添加收件人";
            this.添加ToolStripMenuItem.Click += new System.EventHandler(this.添加ToolStripMenuItem_Click);
            // 
            // 删除收件人ToolStripMenuItem
            // 
            this.删除收件人ToolStripMenuItem.Name = "删除收件人ToolStripMenuItem";
            this.删除收件人ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.删除收件人ToolStripMenuItem.Text = "删除收件人";
            this.删除收件人ToolStripMenuItem.Click += new System.EventHandler(this.删除收件人ToolStripMenuItem_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(112, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(77, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "添加收件人";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.grpAttentmentInfo);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnLog);
            this.splitContainer3.Panel2.Controls.Add(this.btnSelect);
            this.splitContainer3.Panel2.Controls.Add(this.btnSend);
            this.splitContainer3.Size = new System.Drawing.Size(345, 561);
            this.splitContainer3.SplitterDistance = 513;
            this.splitContainer3.TabIndex = 0;
            // 
            // grpAttentmentInfo
            // 
            this.grpAttentmentInfo.Controls.Add(this.grdAttemt);
            this.grpAttentmentInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAttentmentInfo.Location = new System.Drawing.Point(0, 0);
            this.grpAttentmentInfo.Name = "grpAttentmentInfo";
            this.grpAttentmentInfo.Size = new System.Drawing.Size(345, 513);
            this.grpAttentmentInfo.TabIndex = 0;
            this.grpAttentmentInfo.TabStop = false;
            this.grpAttentmentInfo.Text = "附件信息";
            // 
            // grdAttemt
            // 
            this.grdAttemt.AllowUserToAddRows = false;
            this.grdAttemt.AllowUserToDeleteRows = false;
            this.grdAttemt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAttemt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2});
            this.grdAttemt.ContextMenuStrip = this.contextMenuStrip2;
            this.grdAttemt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAttemt.Location = new System.Drawing.Point(3, 17);
            this.grdAttemt.Name = "grdAttemt";
            this.grdAttemt.RowTemplate.Height = 23;
            this.grdAttemt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAttemt.Size = new System.Drawing.Size(339, 493);
            this.grdAttemt.TabIndex = 1;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "附件路径";
            this.Column2.Name = "Column2";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择附件ToolStripMenuItem,
            this.toolStripMenuItem2});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(125, 48);
            // 
            // 选择附件ToolStripMenuItem
            // 
            this.选择附件ToolStripMenuItem.Name = "选择附件ToolStripMenuItem";
            this.选择附件ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.选择附件ToolStripMenuItem.Text = "选择附件";
            this.选择附件ToolStripMenuItem.Click += new System.EventHandler(this.选择附件ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem2.Text = "删除附件";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(242, 11);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(91, 23);
            this.btnLog.TabIndex = 3;
            this.btnLog.Text = "查看发送日志";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(13, 11);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(69, 23);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "选择附件";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(88, 11);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "序号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Remark";
            this.dataGridViewTextBoxColumn2.HeaderText = "名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "EmailAddress";
            this.dataGridViewTextBoxColumn3.HeaderText = "地址";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "附件路径";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(12, 139);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(141, 23);
            this.btnInit.TabIndex = 4;
            this.btnInit.Text = "初始化日志记录结构表";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "1秒=1000";
            // 
            // FrmEmailSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmEmailSend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "邮件发送";
            this.Load += new System.EventHandler(this.FrmEmailSend_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.grpFromInfo.ResumeLayout(false);
            this.grpFromInfo.PerformLayout();
            this.grpSendSettion.ResumeLayout(false);
            this.grpSendSettion.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.grpToUserList.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEmailAddress)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.grpAttentmentInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAttemt)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox grpToUserList;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox grpAttentmentInfo;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridView grdAttemt;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridView grdEmailAddress;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除收件人ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEmailAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.GroupBox grpFromInfo;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TextBox txtShowUser;
        private System.Windows.Forms.Label lblShowName;
        private System.Windows.Forms.TextBox txtEmailDomain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFromUser;
        private System.Windows.Forms.TextBox txtFromPwd;
        private System.Windows.Forms.Label lblFromPwd;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.GroupBox grpSendSettion;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.CheckBox chkUserSetting;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.ToolStripMenuItem 选择附件ToolStripMenuItem;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Label label4;
    }
}