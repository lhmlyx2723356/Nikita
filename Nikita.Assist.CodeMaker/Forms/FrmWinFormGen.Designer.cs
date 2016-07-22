namespace Nikita.Assist.CodeMaker
{
    partial class FrmWinFormGen
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUIGen = new System.Windows.Forms.Button();
            this.cboTable = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radNikitaFramework = new System.Windows.Forms.RadioButton();
            this.radSimpleTwoLayer = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radDevExpress = new System.Windows.Forms.RadioButton();
            this.radWinFrom = new System.Windows.Forms.RadioButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpTree = new System.Windows.Forms.GroupBox();
            this.txtParentKey = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lstShowFileds = new System.Windows.Forms.CheckedListBox();
            this.lstQueryFileds = new System.Windows.Forms.CheckedListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radDataTable = new System.Windows.Forms.RadioButton();
            this.radModel = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstDontRepeatFileds = new System.Windows.Forms.CheckedListBox();
            this.lstCheckInputFileds = new System.Windows.Forms.CheckedListBox();
            this.lstEditShowFileds = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.全选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.反选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdGenCode = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdGenModel = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdGenDAL = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpTree.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(837, 522);
            this.splitContainer1.SplitterDistance = 102;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(837, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 19);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox6);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(831, 80);
            this.splitContainer3.SplitterDistance = 343;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtPrefix);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.btnUIGen);
            this.groupBox6.Controls.Add(this.cboTable);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(343, 80);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "基础设置";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(92, 53);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(161, 23);
            this.txtPrefix.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "过滤表名前缀:";
            // 
            // btnUIGen
            // 
            this.btnUIGen.Location = new System.Drawing.Point(259, 18);
            this.btnUIGen.Name = "btnUIGen";
            this.btnUIGen.Size = new System.Drawing.Size(78, 23);
            this.btnUIGen.TabIndex = 12;
            this.btnUIGen.Text = "界面生成";
            this.btnUIGen.UseVisualStyleBackColor = true;
            this.btnUIGen.Click += new System.EventHandler(this.btnUIGen_Click);
            // 
            // cboTable
            // 
            this.cboTable.FormattingEnabled = true;
            this.cboTable.Location = new System.Drawing.Point(92, 18);
            this.cboTable.Name = "cboTable";
            this.cboTable.Size = new System.Drawing.Size(161, 25);
            this.cboTable.TabIndex = 11;
            this.cboTable.SelectedIndexChanged += new System.EventHandler(this.cboTable_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "操作表:";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer4.Size = new System.Drawing.Size(484, 80);
            this.splitContainer4.SplitterDistance = 225;
            this.splitContainer4.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radNikitaFramework);
            this.groupBox4.Controls.Add(this.radSimpleTwoLayer);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(225, 80);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "架构类型";
            // 
            // radNikitaFramework
            // 
            this.radNikitaFramework.AutoSize = true;
            this.radNikitaFramework.Location = new System.Drawing.Point(98, 22);
            this.radNikitaFramework.Name = "radNikitaFramework";
            this.radNikitaFramework.Size = new System.Drawing.Size(125, 21);
            this.radNikitaFramework.TabIndex = 3;
            this.radNikitaFramework.Tag = "NikitaFramework";
            this.radNikitaFramework.Text = "NikitaFramework";
            this.radNikitaFramework.UseVisualStyleBackColor = true;
            // 
            // radSimpleTwoLayer
            // 
            this.radSimpleTwoLayer.AutoSize = true;
            this.radSimpleTwoLayer.Checked = true;
            this.radSimpleTwoLayer.Location = new System.Drawing.Point(18, 22);
            this.radSimpleTwoLayer.Name = "radSimpleTwoLayer";
            this.radSimpleTwoLayer.Size = new System.Drawing.Size(74, 21);
            this.radSimpleTwoLayer.TabIndex = 2;
            this.radSimpleTwoLayer.TabStop = true;
            this.radSimpleTwoLayer.Tag = "简易两层";
            this.radSimpleTwoLayer.Text = "简易两层";
            this.radSimpleTwoLayer.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radDevExpress);
            this.groupBox5.Controls.Add(this.radWinFrom);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(255, 80);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "界面样式";
            // 
            // radDevExpress
            // 
            this.radDevExpress.AutoSize = true;
            this.radDevExpress.Location = new System.Drawing.Point(136, 22);
            this.radDevExpress.Name = "radDevExpress";
            this.radDevExpress.Size = new System.Drawing.Size(93, 21);
            this.radDevExpress.TabIndex = 3;
            this.radDevExpress.Tag = "DevExpress";
            this.radDevExpress.Text = "DevExpress";
            this.radDevExpress.UseVisualStyleBackColor = true;
            // 
            // radWinFrom
            // 
            this.radWinFrom.AutoSize = true;
            this.radWinFrom.Checked = true;
            this.radWinFrom.Location = new System.Drawing.Point(18, 22);
            this.radWinFrom.Name = "radWinFrom";
            this.radWinFrom.Size = new System.Drawing.Size(102, 21);
            this.radWinFrom.TabIndex = 2;
            this.radWinFrom.TabStop = true;
            this.radWinFrom.Tag = "传统WinForm";
            this.radWinFrom.Text = "传统WinForm";
            this.radWinFrom.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Size = new System.Drawing.Size(837, 416);
            this.splitContainer2.SplitterDistance = 165;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grpTree);
            this.groupBox2.Controls.Add(this.lstShowFileds);
            this.groupBox2.Controls.Add(this.lstQueryFileds);
            this.groupBox2.Controls.Add(this.groupBox7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(837, 165);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询设置";
            // 
            // grpTree
            // 
            this.grpTree.Controls.Add(this.txtParentKey);
            this.grpTree.Controls.Add(this.label9);
            this.grpTree.Controls.Add(this.txtKey);
            this.grpTree.Controls.Add(this.label8);
            this.grpTree.Location = new System.Drawing.Point(448, 83);
            this.grpTree.Name = "grpTree";
            this.grpTree.Size = new System.Drawing.Size(383, 68);
            this.grpTree.TabIndex = 5;
            this.grpTree.TabStop = false;
            this.grpTree.Text = "树形父子键设置";
            // 
            // txtParentKey
            // 
            this.txtParentKey.Location = new System.Drawing.Point(250, 39);
            this.txtParentKey.Name = "txtParentKey";
            this.txtParentKey.Size = new System.Drawing.Size(110, 23);
            this.txtParentKey.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(183, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "父键字段:";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(71, 39);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(108, 23);
            this.txtKey.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "子键字段:";
            // 
            // lstShowFileds
            // 
            this.lstShowFileds.FormattingEnabled = true;
            this.lstShowFileds.Location = new System.Drawing.Point(248, 43);
            this.lstShowFileds.Name = "lstShowFileds";
            this.lstShowFileds.Size = new System.Drawing.Size(175, 112);
            this.lstShowFileds.TabIndex = 6;
            // 
            // lstQueryFileds
            // 
            this.lstQueryFileds.FormattingEnabled = true;
            this.lstQueryFileds.Location = new System.Drawing.Point(17, 42);
            this.lstQueryFileds.Name = "lstQueryFileds";
            this.lstQueryFileds.Size = new System.Drawing.Size(155, 112);
            this.lstQueryFileds.TabIndex = 5;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.radDataTable);
            this.groupBox7.Controls.Add(this.radModel);
            this.groupBox7.Location = new System.Drawing.Point(448, 21);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(233, 56);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "绑定列表的数据类型";
            // 
            // radDataTable
            // 
            this.radDataTable.AutoSize = true;
            this.radDataTable.Checked = true;
            this.radDataTable.Location = new System.Drawing.Point(18, 22);
            this.radDataTable.Name = "radDataTable";
            this.radDataTable.Size = new System.Drawing.Size(85, 21);
            this.radDataTable.TabIndex = 3;
            this.radDataTable.TabStop = true;
            this.radDataTable.Tag = "DataTable";
            this.radDataTable.Text = "DataTable";
            this.radDataTable.UseVisualStyleBackColor = true;
            // 
            // radModel
            // 
            this.radModel.AutoSize = true;
            this.radModel.Location = new System.Drawing.Point(122, 22);
            this.radModel.Name = "radModel";
            this.radModel.Size = new System.Drawing.Size(98, 21);
            this.radModel.TabIndex = 2;
            this.radModel.Tag = "实体对象集合";
            this.radModel.Text = "实体对象集合";
            this.radModel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "列表显示字段";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "查询条件字段";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstDontRepeatFileds);
            this.groupBox3.Controls.Add(this.lstCheckInputFileds);
            this.groupBox3.Controls.Add(this.lstEditShowFileds);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(837, 247);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "编辑设置";
            // 
            // lstDontRepeatFileds
            // 
            this.lstDontRepeatFileds.FormattingEnabled = true;
            this.lstDontRepeatFileds.Location = new System.Drawing.Point(494, 51);
            this.lstDontRepeatFileds.Name = "lstDontRepeatFileds";
            this.lstDontRepeatFileds.Size = new System.Drawing.Size(175, 184);
            this.lstDontRepeatFileds.TabIndex = 16;
            // 
            // lstCheckInputFileds
            // 
            this.lstCheckInputFileds.FormattingEnabled = true;
            this.lstCheckInputFileds.Location = new System.Drawing.Point(248, 50);
            this.lstCheckInputFileds.Name = "lstCheckInputFileds";
            this.lstCheckInputFileds.Size = new System.Drawing.Size(175, 184);
            this.lstCheckInputFileds.TabIndex = 15;
            // 
            // lstEditShowFileds
            // 
            this.lstEditShowFileds.FormattingEnabled = true;
            this.lstEditShowFileds.Location = new System.Drawing.Point(13, 50);
            this.lstEditShowFileds.Name = "lstEditShowFileds";
            this.lstEditShowFileds.Size = new System.Drawing.Size(159, 184);
            this.lstEditShowFileds.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(491, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "已经存在不能重复添加字段:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(246, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "检查输入必填字段";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "数据显示字段";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.全选ToolStripMenuItem,
            this.反选ToolStripMenuItem,
            this.清空ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 70);
            // 
            // 全选ToolStripMenuItem
            // 
            this.全选ToolStripMenuItem.Name = "全选ToolStripMenuItem";
            this.全选ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.全选ToolStripMenuItem.Text = "全选";
            this.全选ToolStripMenuItem.Click += new System.EventHandler(this.全选ToolStripMenuItem_Click);
            // 
            // 反选ToolStripMenuItem
            // 
            this.反选ToolStripMenuItem.Name = "反选ToolStripMenuItem";
            this.反选ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.反选ToolStripMenuItem.Text = "反选";
            this.反选ToolStripMenuItem.Click += new System.EventHandler(this.反选ToolStripMenuItem_Click);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdGenCode,
            this.cmdGenModel,
            this.cmdGenDAL});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(163, 92);
            // 
            // cmdGenCode
            // 
            this.cmdGenCode.Name = "cmdGenCode";
            this.cmdGenCode.Size = new System.Drawing.Size(162, 22);
            this.cmdGenCode.Text = "生成Form代码";
            this.cmdGenCode.Click += new System.EventHandler(this.cmdGenCode_Click);
            // 
            // cmdGenModel
            // 
            this.cmdGenModel.Name = "cmdGenModel";
            this.cmdGenModel.Size = new System.Drawing.Size(162, 22);
            this.cmdGenModel.Text = "生成Model代码";
            this.cmdGenModel.Click += new System.EventHandler(this.cmdGenModel_Click);
            // 
            // cmdGenDAL
            // 
            this.cmdGenDAL.Name = "cmdGenDAL";
            this.cmdGenDAL.Size = new System.Drawing.Size(162, 22);
            this.cmdGenDAL.Text = "生成DAL代码";
            this.cmdGenDAL.Click += new System.EventHandler(this.cmdGenDAL_Click);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(61, 4);
            // 
            // FrmWinFormGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 522);
            this.ContextMenuStrip = this.contextMenuStrip2;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmWinFormGen";
            this.ShowIcon = false;
            this.Text = "WinForm代码生成";
            this.Load += new System.EventHandler(this.FrmWinFormGen_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpTree.ResumeLayout(false);
            this.grpTree.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radNikitaFramework;
        private System.Windows.Forms.RadioButton radSimpleTwoLayer;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radDevExpress;
        private System.Windows.Forms.RadioButton radWinFrom;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUIGen;
        private System.Windows.Forms.ComboBox cboTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton radDataTable;
        private System.Windows.Forms.RadioButton radModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 全选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 反选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox lstQueryFileds;
        private System.Windows.Forms.CheckedListBox lstShowFileds;
        private System.Windows.Forms.CheckedListBox lstEditShowFileds;
        private System.Windows.Forms.CheckedListBox lstCheckInputFileds;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem cmdGenCode;
        private System.Windows.Forms.ToolStripMenuItem cmdGenModel;
        private System.Windows.Forms.ToolStripMenuItem cmdGenDAL;
        private System.Windows.Forms.CheckedListBox lstDontRepeatFileds;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.GroupBox grpTree;
        private System.Windows.Forms.TextBox txtParentKey;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label8;
    }
}