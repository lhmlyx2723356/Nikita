namespace Nikita.Assist.CodeMaker
{
    partial class FrmNestQuerySetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNestQuerySetting));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdQuery = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSet = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtKey2 = new System.Windows.Forms.TextBox();
            this.lblKey2 = new System.Windows.Forms.Label();
            this.txtKey1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSql2 = new ICSharpCode.TextEditor.TextEditorControl();
            this.txtSql1 = new ICSharpCode.TextEditor.TextEditorControl();
            this.txtSql = new ICSharpCode.TextEditor.TextEditorControl();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboNestType = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1002, 561);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(994, 531);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "嵌套查询";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtClassName);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txtKey2);
            this.splitContainer1.Panel1.Controls.Add(this.lblKey2);
            this.splitContainer1.Panel1.Controls.Add(this.txtKey1);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.txtKey);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.txtSql2);
            this.splitContainer1.Panel1.Controls.Add(this.txtSql1);
            this.splitContainer1.Panel1.Controls.Add(this.txtSql);
            this.splitContainer1.Panel1.Controls.Add(this.lblInfo);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.cboNestType);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnOK);
            this.splitContainer1.Size = new System.Drawing.Size(988, 525);
            this.splitContainer1.SplitterDistance = 468;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(328, 9);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(199, 23);
            this.txtClassName.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(257, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "窗体类名:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdQuery);
            this.groupBox1.Controls.Add(this.btnSet);
            this.groupBox1.Location = new System.Drawing.Point(682, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 406);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件区域";
            // 
            // grdQuery
            // 
            this.grdQuery.AllowUserToAddRows = false;
            this.grdQuery.AllowUserToDeleteRows = false;
            this.grdQuery.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdQuery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2});
            this.grdQuery.GridColor = System.Drawing.SystemColors.Control;
            this.grdQuery.Location = new System.Drawing.Point(7, 57);
            this.grdQuery.Name = "grdQuery";
            this.grdQuery.RowHeadersWidth = 5;
            this.grdQuery.RowTemplate.Height = 23;
            this.grdQuery.Size = new System.Drawing.Size(287, 343);
            this.grdQuery.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ColumnName";
            this.Column1.HeaderText = "字段名";
            this.Column1.Name = "Column1";
            this.Column1.Width = 90;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "LabelText";
            this.Column3.HeaderText = "名称";
            this.Column3.Name = "Column3";
            this.Column3.Width = 90;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ControlType";
            this.Column2.HeaderText = "控件类型";
            this.Column2.Name = "Column2";
            this.Column2.Width = 90;
            // 
            // btnSet
            // 
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSet.Location = new System.Drawing.Point(6, 22);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(141, 28);
            this.btnSet.TabIndex = 1;
            this.btnSet.Text = "预览并设置查询条件";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(76, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(361, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "子表，明细表Select语句需要设置别名,如Select Name as 名称......";
            // 
            // txtKey2
            // 
            this.txtKey2.Location = new System.Drawing.Point(533, 341);
            this.txtKey2.Name = "txtKey2";
            this.txtKey2.Size = new System.Drawing.Size(125, 23);
            this.txtKey2.TabIndex = 13;
            // 
            // lblKey2
            // 
            this.lblKey2.AutoSize = true;
            this.lblKey2.Location = new System.Drawing.Point(533, 321);
            this.lblKey2.Name = "lblKey2";
            this.lblKey2.Size = new System.Drawing.Size(71, 17);
            this.lblKey2.TabIndex = 12;
            this.lblKey2.Text = "关联子表键:";
            // 
            // txtKey1
            // 
            this.txtKey1.Location = new System.Drawing.Point(534, 220);
            this.txtKey1.Name = "txtKey1";
            this.txtKey1.Size = new System.Drawing.Size(125, 23);
            this.txtKey1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(532, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "关联主表键:";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(533, 66);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(125, 23);
            this.txtKey.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(531, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "关联键:";
            // 
            // txtSql2
            // 
            this.txtSql2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSql2.Encoding = ((System.Text.Encoding)(resources.GetObject("txtSql2.Encoding")));
            this.txtSql2.IsIconBarVisible = false;
            this.txtSql2.Location = new System.Drawing.Point(76, 318);
            this.txtSql2.Name = "txtSql2";
            this.txtSql2.ShowEOLMarkers = true;
            this.txtSql2.ShowInvalidLines = false;
            this.txtSql2.ShowLineNumbers = false;
            this.txtSql2.ShowMatchingBracket = false;
            this.txtSql2.ShowSpaces = true;
            this.txtSql2.ShowTabs = true;
            this.txtSql2.ShowVRuler = true;
            this.txtSql2.Size = new System.Drawing.Size(451, 121);
            this.txtSql2.TabIndex = 7;
            // 
            // txtSql1
            // 
            this.txtSql1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSql1.Encoding = ((System.Text.Encoding)(resources.GetObject("txtSql1.Encoding")));
            this.txtSql1.IsIconBarVisible = false;
            this.txtSql1.Location = new System.Drawing.Point(76, 195);
            this.txtSql1.Name = "txtSql1";
            this.txtSql1.ShowEOLMarkers = true;
            this.txtSql1.ShowInvalidLines = false;
            this.txtSql1.ShowLineNumbers = false;
            this.txtSql1.ShowMatchingBracket = false;
            this.txtSql1.ShowSpaces = true;
            this.txtSql1.ShowTabs = true;
            this.txtSql1.ShowVRuler = true;
            this.txtSql1.Size = new System.Drawing.Size(451, 116);
            this.txtSql1.TabIndex = 6;
            // 
            // txtSql
            // 
            this.txtSql.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSql.Encoding = ((System.Text.Encoding)(resources.GetObject("txtSql.Encoding")));
            this.txtSql.IsIconBarVisible = false;
            this.txtSql.Location = new System.Drawing.Point(76, 43);
            this.txtSql.Name = "txtSql";
            this.txtSql.ShowEOLMarkers = true;
            this.txtSql.ShowInvalidLines = false;
            this.txtSql.ShowLineNumbers = false;
            this.txtSql.ShowMatchingBracket = false;
            this.txtSql.ShowSpaces = true;
            this.txtSql.ShowTabs = true;
            this.txtSql.ShowVRuler = true;
            this.txtSql.Size = new System.Drawing.Size(451, 121);
            this.txtSql.TabIndex = 5;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(16, 322);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(47, 17);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "明细表:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "子表:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "主表:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "嵌套层次:";
            // 
            // cboNestType
            // 
            this.cboNestType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboNestType.FormattingEnabled = true;
            this.cboNestType.Items.AddRange(new object[] {
            "两层",
            "三层"});
            this.cboNestType.Location = new System.Drawing.Point(76, 8);
            this.cboNestType.Name = "cboNestType";
            this.cboNestType.Size = new System.Drawing.Size(164, 25);
            this.cboNestType.TabIndex = 0;
            this.cboNestType.SelectedIndexChanged += new System.EventHandler(this.cboNestType_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(901, 14);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 28);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定生成";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmNestQuerySetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 561);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmNestQuerySetting";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNestQuerySetting";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboNestType;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ICSharpCode.TextEditor.TextEditorControl txtSql2;
        private ICSharpCode.TextEditor.TextEditorControl txtSql1;
        private ICSharpCode.TextEditor.TextEditorControl txtSql;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtKey2;
        private System.Windows.Forms.Label lblKey2;
        private System.Windows.Forms.TextBox txtKey1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdQuery;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label7;
    }
}