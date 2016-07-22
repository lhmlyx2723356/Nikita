 
using Nikita.WinForm.ExtendControl;
namespace Nikita.WinForm.ExtendControl.CommonQuery
{
    partial class LambdaBuilder
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tvTaskList = new TreeGridView();
            this.Column1 = new TreeGridColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.优先ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消优先ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除选中ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboFiled = new System.Windows.Forms.ComboBox();
            this.radAnd = new System.Windows.Forms.RadioButton();
            this.radOR = new System.Windows.Forms.RadioButton();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cboOperation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tvTaskList)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvTaskList
            // 
            this.tvTaskList.AllowUserToAddRows = false;
            this.tvTaskList.AllowUserToDeleteRows = false;
            this.tvTaskList.AllowUserToOrderColumns = true;
            this.tvTaskList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tvTaskList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.tvTaskList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tvTaskList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.tvTaskList.ContextMenuStrip = this.contextMenu;
            this.tvTaskList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTaskList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tvTaskList.ImageList = null;
            this.tvTaskList.Location = new System.Drawing.Point(0, 0);
            this.tvTaskList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tvTaskList.Name = "tvTaskList";
            this.tvTaskList.RowHeadersVisible = false;
            this.tvTaskList.RowHeadersWidth = 20;
            this.tvTaskList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tvTaskList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tvTaskList.Size = new System.Drawing.Size(412, 483);
            this.tvTaskList.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.DefaultNodeImage = null;
            this.Column1.HeaderText = "关系";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "字段";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "操作符";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "输入值";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.优先ToolStripMenuItem,
            this.取消优先ToolStripMenuItem,
            this.删除选中ToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(125, 70);
            // 
            // 优先ToolStripMenuItem
            // 
            this.优先ToolStripMenuItem.Name = "优先ToolStripMenuItem";
            this.优先ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.优先ToolStripMenuItem.Text = "优先";
            this.优先ToolStripMenuItem.Click += new System.EventHandler(this.优先ToolStripMenuItem_Click);
            // 
            // 取消优先ToolStripMenuItem
            // 
            this.取消优先ToolStripMenuItem.Name = "取消优先ToolStripMenuItem";
            this.取消优先ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.取消优先ToolStripMenuItem.Text = "取消优先";
            this.取消优先ToolStripMenuItem.Click += new System.EventHandler(this.取消优先ToolStripMenuItem_Click);
            // 
            // 删除选中ToolStripMenuItem
            // 
            this.删除选中ToolStripMenuItem.Name = "删除选中ToolStripMenuItem";
            this.删除选中ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除选中ToolStripMenuItem.Text = "删除选中";
            this.删除选中ToolStripMenuItem.Click += new System.EventHandler(this.删除选中ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnAdd);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.cboFiled);
            this.splitContainer1.Panel1.Controls.Add(this.radAnd);
            this.splitContainer1.Panel1.Controls.Add(this.radOR);
            this.splitContainer1.Panel1.Controls.Add(this.txtValue);
            this.splitContainer1.Panel1.Controls.Add(this.cboOperation);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tvTaskList);
            this.splitContainer1.Size = new System.Drawing.Size(412, 637);
            this.splitContainer1.SplitterDistance = 148;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(331, 106);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 27);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "逻辑";
            // 
            // cboFiled
            // 
            this.cboFiled.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFiled.FormattingEnabled = true;
            this.cboFiled.Items.AddRange(new object[] {
            "等于",
            "不等于",
            "包含",
            "在列表中",
            "不在列表中"});
            this.cboFiled.Location = new System.Drawing.Point(82, 15);
            this.cboFiled.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboFiled.Name = "cboFiled";
            this.cboFiled.Size = new System.Drawing.Size(303, 25);
            this.cboFiled.TabIndex = 16;
            this.cboFiled.SelectedIndexChanged += new System.EventHandler(this.cboFiled_SelectedIndexChanged);
            // 
            // radAnd
            // 
            this.radAnd.AutoSize = true;
            this.radAnd.Checked = true;
            this.radAnd.Location = new System.Drawing.Point(85, 112);
            this.radAnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radAnd.Name = "radAnd";
            this.radAnd.Size = new System.Drawing.Size(50, 21);
            this.radAnd.TabIndex = 15;
            this.radAnd.TabStop = true;
            this.radAnd.Text = "并且";
            this.radAnd.UseVisualStyleBackColor = true;
            // 
            // radOR
            // 
            this.radOR.AutoSize = true;
            this.radOR.Location = new System.Drawing.Point(148, 112);
            this.radOR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radOR.Name = "radOR";
            this.radOR.Size = new System.Drawing.Size(50, 21);
            this.radOR.TabIndex = 14;
            this.radOR.TabStop = true;
            this.radOR.Text = "或者";
            this.radOR.UseVisualStyleBackColor = true;
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(82, 81);
            this.txtValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(303, 23);
            this.txtValue.TabIndex = 13;
            this.txtValue.Text = "1";
            // 
            // cboOperation
            // 
            this.cboOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOperation.FormattingEnabled = true;
            this.cboOperation.Items.AddRange(new object[] {
            "等于",
            "不等于",
            "包含",
            "在列表中",
            "不在列表中"});
            this.cboOperation.Location = new System.Drawing.Point(82, 46);
            this.cboOperation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboOperation.Name = "cboOperation";
            this.cboOperation.Size = new System.Drawing.Size(303, 25);
            this.cboOperation.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "输入值";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "比较方式";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "字段属性";
            // 
            // LambdaBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LambdaBuilder";
            this.Size = new System.Drawing.Size(412, 637);
            ((System.ComponentModel.ISupportInitialize)(this.tvTaskList)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TreeGridView tvTaskList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cboFiled;
        private System.Windows.Forms.RadioButton radAnd;
        private System.Windows.Forms.RadioButton radOR;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ComboBox cboOperation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ToolStripMenuItem 优先ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消优先ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除选中ToolStripMenuItem;
        private TreeGridColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}
