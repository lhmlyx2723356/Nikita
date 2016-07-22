namespace Nikita.Assist.DBManager
{
    partial class FrmTableNew
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtTableDescription = new System.Windows.Forms.TextBox();
            this.lblTableDescription = new System.Windows.Forms.Label();
            this.txtTableHistoryName = new System.Windows.Forms.TextBox();
            this.lblTableHistoryName = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.lblTableName = new System.Windows.Forms.Label();
            this.grdTable = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtSql = new System.Windows.Forms.RichTextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnScript = new System.Windows.Forms.Button();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColumnType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colColumnLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColumnScale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColumnAllowNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colColumnPK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colColumnIdentity = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colColumnRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColumnDefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColumnHistory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTableHistoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTableDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDatabaseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDbType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTable)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
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
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Panel2MinSize = 150;
            this.splitContainer1.Size = new System.Drawing.Size(1131, 486);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtTableDescription);
            this.splitContainer2.Panel1.Controls.Add(this.lblTableDescription);
            this.splitContainer2.Panel1.Controls.Add(this.txtTableHistoryName);
            this.splitContainer2.Panel1.Controls.Add(this.lblTableHistoryName);
            this.splitContainer2.Panel1.Controls.Add(this.txtTableName);
            this.splitContainer2.Panel1.Controls.Add(this.lblTableName);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grdTable);
            this.splitContainer2.Size = new System.Drawing.Size(1131, 266);
            this.splitContainer2.SplitterDistance = 48;
            this.splitContainer2.TabIndex = 0;
            // 
            // txtTableDescription
            // 
            this.txtTableDescription.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTableDescription.Location = new System.Drawing.Point(434, 12);
            this.txtTableDescription.Name = "txtTableDescription";
            this.txtTableDescription.Size = new System.Drawing.Size(198, 23);
            this.txtTableDescription.TabIndex = 2;
            // 
            // lblTableDescription
            // 
            this.lblTableDescription.AutoSize = true;
            this.lblTableDescription.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTableDescription.ForeColor = System.Drawing.Color.Red;
            this.lblTableDescription.Location = new System.Drawing.Point(384, 15);
            this.lblTableDescription.Name = "lblTableDescription";
            this.lblTableDescription.Size = new System.Drawing.Size(44, 17);
            this.lblTableDescription.TabIndex = 6;
            this.lblTableDescription.Text = "表说明";
            // 
            // txtTableHistoryName
            // 
            this.txtTableHistoryName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTableHistoryName.Location = new System.Drawing.Point(736, 12);
            this.txtTableHistoryName.Name = "txtTableHistoryName";
            this.txtTableHistoryName.Size = new System.Drawing.Size(186, 23);
            this.txtTableHistoryName.TabIndex = 3;
            // 
            // lblTableHistoryName
            // 
            this.lblTableHistoryName.AutoSize = true;
            this.lblTableHistoryName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTableHistoryName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTableHistoryName.Location = new System.Drawing.Point(650, 15);
            this.lblTableHistoryName.Name = "lblTableHistoryName";
            this.lblTableHistoryName.Size = new System.Drawing.Size(80, 17);
            this.lblTableHistoryName.TabIndex = 4;
            this.lblTableHistoryName.Text = "对应历史表名";
            // 
            // txtTableName
            // 
            this.txtTableName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTableName.Location = new System.Drawing.Point(106, 12);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(257, 23);
            this.txtTableName.TabIndex = 1;
            this.txtTableName.Leave += new System.EventHandler(this.txtTableName_Leave);
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTableName.ForeColor = System.Drawing.Color.Red;
            this.lblTableName.Location = new System.Drawing.Point(15, 15);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(80, 17);
            this.lblTableName.TabIndex = 0;
            this.lblTableName.Text = "请先输入表名";
            // 
            // grdTable
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colColumnName,
            this.colColumnType,
            this.colColumnLength,
            this.colColumnScale,
            this.colColumnAllowNull,
            this.colColumnPK,
            this.colColumnIdentity,
            this.colColumnRemark,
            this.colColumnDefaultValue,
            this.colColumnHistory,
            this.colTableName,
            this.ColTableHistoryName,
            this.colTableDescription,
            this.colServerName,
            this.colDatabaseName,
            this.colDbType,
            this.colOperationType});
            this.grdTable.ContextMenuStrip = this.contextMenuStrip;
            this.grdTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTable.Location = new System.Drawing.Point(0, 0);
            this.grdTable.Name = "grdTable";
            this.grdTable.RowTemplate.Height = 23;
            this.grdTable.Size = new System.Drawing.Size(1129, 212);
            this.grdTable.TabIndex = 3;
            this.grdTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTable_CellEndEdit);
            this.grdTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTable_CellValueChanged);
            this.grdTable.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdTable_DataError);
            this.grdTable.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.grdTable_DefaultValuesNeeded);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(113, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItem1.Text = "删除列";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItem2.Text = "插入列";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnRun);
            this.splitContainer3.Panel2.Controls.Add(this.btnScript);
            this.splitContainer3.Size = new System.Drawing.Size(1131, 216);
            this.splitContainer3.SplitterDistance = 972;
            this.splitContainer3.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(972, 216);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtSql);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(964, 186);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "脚本信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtSql
            // 
            this.txtSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSql.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSql.Location = new System.Drawing.Point(3, 3);
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(958, 180);
            this.txtSql.TabIndex = 2;
            this.txtSql.Text = "";
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun.Location = new System.Drawing.Point(40, 114);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 32);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "执行";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnScript
            // 
            this.btnScript.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScript.Location = new System.Drawing.Point(40, 44);
            this.btnScript.Name = "btnScript";
            this.btnScript.Size = new System.Drawing.Size(75, 32);
            this.btnScript.TabIndex = 2;
            this.btnScript.Text = "查看脚本";
            this.btnScript.UseVisualStyleBackColor = true;
            this.btnScript.Click += new System.EventHandler(this.btnScript_Click);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "id";
            this.colId.HeaderText = "序号";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colColumnName
            // 
            this.colColumnName.DataPropertyName = "ColumnName";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.colColumnName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colColumnName.HeaderText = "列名";
            this.colColumnName.Name = "colColumnName";
            // 
            // colColumnType
            // 
            this.colColumnType.DataPropertyName = "ColumnType";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.colColumnType.DefaultCellStyle = dataGridViewCellStyle3;
            this.colColumnType.HeaderText = "数据类型";
            this.colColumnType.Name = "colColumnType";
            this.colColumnType.Width = 130;
            // 
            // colColumnLength
            // 
            this.colColumnLength.DataPropertyName = "ColumnLength";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.colColumnLength.DefaultCellStyle = dataGridViewCellStyle4;
            this.colColumnLength.HeaderText = "字段长度";
            this.colColumnLength.Name = "colColumnLength";
            // 
            // colColumnScale
            // 
            this.colColumnScale.HeaderText = "小数位数";
            this.colColumnScale.Name = "colColumnScale";
            // 
            // colColumnAllowNull
            // 
            this.colColumnAllowNull.DataPropertyName = "ColumnAllowNull";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.NullValue = false;
            this.colColumnAllowNull.DefaultCellStyle = dataGridViewCellStyle5;
            this.colColumnAllowNull.HeaderText = "允许NULL值";
            this.colColumnAllowNull.Name = "colColumnAllowNull";
            // 
            // colColumnPK
            // 
            this.colColumnPK.DataPropertyName = "ColumnPK";
            this.colColumnPK.HeaderText = "是否主键";
            this.colColumnPK.Name = "colColumnPK";
            this.colColumnPK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colColumnPK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colColumnIdentity
            // 
            this.colColumnIdentity.DataPropertyName = "ColumnIdentity";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.NullValue = false;
            this.colColumnIdentity.DefaultCellStyle = dataGridViewCellStyle6;
            this.colColumnIdentity.HeaderText = "是否自增";
            this.colColumnIdentity.Name = "colColumnIdentity";
            this.colColumnIdentity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colColumnIdentity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colColumnRemark
            // 
            this.colColumnRemark.DataPropertyName = "ColumnRemark";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.colColumnRemark.DefaultCellStyle = dataGridViewCellStyle7;
            this.colColumnRemark.HeaderText = "字段说明";
            this.colColumnRemark.Name = "colColumnRemark";
            // 
            // colColumnDefaultValue
            // 
            this.colColumnDefaultValue.DataPropertyName = "ColumnDefaultValue";
            this.colColumnDefaultValue.HeaderText = "默认值";
            this.colColumnDefaultValue.Name = "colColumnDefaultValue";
            // 
            // colColumnHistory
            // 
            this.colColumnHistory.DataPropertyName = "ColumnHistory";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.colColumnHistory.DefaultCellStyle = dataGridViewCellStyle8;
            this.colColumnHistory.HeaderText = "对应历史字段";
            this.colColumnHistory.Name = "colColumnHistory";
            this.colColumnHistory.Width = 120;
            // 
            // colTableName
            // 
            this.colTableName.DataPropertyName = "TableName";
            this.colTableName.HeaderText = "表名";
            this.colTableName.Name = "colTableName";
            this.colTableName.Visible = false;
            // 
            // ColTableHistoryName
            // 
            this.ColTableHistoryName.DataPropertyName = "TableHistoryName";
            this.ColTableHistoryName.HeaderText = "历史表名";
            this.ColTableHistoryName.Name = "ColTableHistoryName";
            this.ColTableHistoryName.Visible = false;
            // 
            // colTableDescription
            // 
            this.colTableDescription.DataPropertyName = "TableDescription";
            this.colTableDescription.HeaderText = "表说明";
            this.colTableDescription.Name = "colTableDescription";
            this.colTableDescription.Visible = false;
            // 
            // colServerName
            // 
            this.colServerName.DataPropertyName = "ServerName";
            this.colServerName.HeaderText = "服务器名称";
            this.colServerName.Name = "colServerName";
            this.colServerName.Visible = false;
            // 
            // colDatabaseName
            // 
            this.colDatabaseName.DataPropertyName = "DatabaseName";
            this.colDatabaseName.HeaderText = "数据库名称";
            this.colDatabaseName.Name = "colDatabaseName";
            this.colDatabaseName.Visible = false;
            // 
            // colDbType
            // 
            this.colDbType.DataPropertyName = "DbType";
            this.colDbType.HeaderText = "数据库类型";
            this.colDbType.Name = "colDbType";
            this.colDbType.Visible = false;
            // 
            // colOperationType
            // 
            this.colOperationType.DataPropertyName = "OperationType";
            this.colOperationType.HeaderText = "操作类型";
            this.colOperationType.Name = "colOperationType";
            this.colOperationType.Visible = false;
            // 
            // FrmTableNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 486);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmTableNew";
            this.Text = "表编辑";
            this.Shown += new System.EventHandler(this.FrmTableNew_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTable)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.TextBox txtTableHistoryName;
        private System.Windows.Forms.Label lblTableHistoryName;
        private System.Windows.Forms.TextBox txtTableDescription;
        private System.Windows.Forms.Label lblTableDescription;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnScript;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox txtSql;
        private System.Windows.Forms.DataGridView grdTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColumnName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColumnLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColumnScale;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colColumnAllowNull;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colColumnPK;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colColumnIdentity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColumnRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColumnDefaultValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColumnHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTableHistoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatabaseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDbType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperationType;

    }
}