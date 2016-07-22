//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd.
//-----------------------------------------------------------------

using System;

using System.ComponentModel;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
    public delegate void PageChangedEventHandler(object sender, EventArgs e);

    /// <summary>
    /// 分页工具条用户控件，仅提供分页信息显示及改变页码操作
    /// </summary>
    public class Pager : UserControl
    {
        private Button btnFirst;

        private Button btnGo;

        private Button btnLast;

        private Button btnNext;

        private Button btnPrevious;

        /// <summary>  必需的设计器变量。
        ///
        /// </summary>
        private System.ComponentModel.Container components = null;

        private Label label1;

        private Label lblCustPageSize;

        private Label lblPageInfo;

        private int m_PageCount;

        private int m_PageIndex;

        private int m_PageSize;

        private int m_RecordCount;

        private TextBox txtCustPageSize;

        private TextBox txtPageIndex;

        /// <summary> 默认构造函数，设置分页初始信息
        ///
        /// </summary>
        public Pager()
        {
            InitializeComponent();

            m_PageSize = 50;
            m_RecordCount = 0;
            m_PageIndex = 1; //默认为第一页
        }

        /// <summary>
        /// 带参数的构造函数
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// </summary>
        public Pager(int recordCount, int pageSize)
        {
            InitializeComponent();

            m_PageSize = pageSize;
            m_RecordCount = recordCount;
            m_PageIndex = 1; //默认为第一页
            InitPageInfo();
        }

        public event PageChangedEventHandler PageChanged;

        [Description("获取记录总页数"), DefaultValue(0), Category("分页")]
        public int PageCount
        {
            get
            {
                return m_PageCount;
            }
        }

        [Description("当前的页面索引, 开始为1"), DefaultValue(0), Category("分页")]
        [Browsable(false)]
        public int PageIndex
        {
            set
            {
                m_PageIndex = value;
            }
            get
            {
                return m_PageIndex;
            }
        }

        [Description("设置或获取一页中显示的记录数目"), DefaultValue(50), Category("分页")]
        public int PageSize
        {
            set
            {
                m_PageSize = value;
            }
            get
            {
                return m_PageSize;
            }
        }

        [Description("设置或获取记录总数"), Category("分页")]
        public int RecordCount
        {
            set
            {
                m_RecordCount = value;
            }
            get
            {
                return m_RecordCount;
            }
        }

        /// <summary>
        /// 初始化分页信息
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// </summary>
        public void InitPageInfo(int recordCount, int pageSize)
        {
            m_RecordCount = recordCount;
            m_PageSize = pageSize;
            InitPageInfo();
        }

        /// <summary>
        /// 初始化分页信息
        /// <param name="recordCount">总记录数</param>
        /// </summary>
        public void InitPageInfo(int recordCount)
        {
            m_RecordCount = recordCount;
            InitPageInfo();
        }

        /// <summary>
        /// 初始化分页信息
        /// </summary>
        public void InitPageInfo()
        {
            if (m_PageSize < 1)
                m_PageSize = 50; //如果每页记录数不正确，即更改为50
            if (m_RecordCount < 0)
                m_RecordCount = 0; //如果记录总数不正确，即更改为0

            //取得总页数
            if (m_RecordCount % m_PageSize == 0)
            {
                m_PageCount = m_RecordCount / m_PageSize;
            }
            else
            {
                m_PageCount = m_RecordCount / m_PageSize + 1;
            }

            //设置当前页
            if (m_PageIndex > m_PageCount)
            {
                m_PageIndex = m_PageCount;
            }
            if (m_PageIndex < 1)
            {
                m_PageIndex = 1;
            }

            //设置上一页按钮的可用性
            bool enable = (PageIndex > 1);
            btnPrevious.Enabled = enable;

            //设置首页按钮的可用性
            enable = (PageIndex > 1);
            btnFirst.Enabled = enable;

            //设置下一页按钮的可用性
            enable = (PageIndex < PageCount);
            btnNext.Enabled = enable;

            //设置末页按钮的可用性
            enable = (PageIndex < PageCount);
            btnLast.Enabled = enable;

            txtPageIndex.Text = m_PageIndex.ToString();
            lblPageInfo.Text = string.Format("共 {0} 条记录，每页 {1} 条，共 {2} 页", m_RecordCount, m_PageSize, m_PageCount);
        }

        public void RefreshData(int page)
        {
            m_PageIndex = page;
            EventArgs e = new EventArgs();
            OnPageChanged(e);
        }

        /// <summary> 清理所有正在使用的资源。
        ///
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器
        /// 修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.txtPageIndex = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblCustPageSize = new System.Windows.Forms.Label();
            this.txtCustPageSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblPageInfo
            //
            this.lblPageInfo.Location = new System.Drawing.Point(0, 7);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(224, 17);
            this.lblPageInfo.TabIndex = 0;
            this.lblPageInfo.Text = "共 {0} 条记录，每页 {1} 条，共 {2} 页";
            this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // txtPageIndex
            //
            this.txtPageIndex.Location = new System.Drawing.Point(520, 5);
            this.txtPageIndex.Margin = new System.Windows.Forms.Padding(1);
            this.txtPageIndex.Name = "txtPageIndex";
            this.txtPageIndex.Size = new System.Drawing.Size(44, 23);
            this.txtPageIndex.TabIndex = 5;
            this.txtPageIndex.Text = "1";
            this.txtPageIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // btnNext
            //
            this.btnNext.Location = new System.Drawing.Point(621, 5);
            this.btnNext.Margin = new System.Windows.Forms.Padding(1);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(49, 25);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            //
            // btnFirst
            //
            this.btnFirst.Location = new System.Drawing.Point(412, 5);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(1);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(49, 25);
            this.btnFirst.TabIndex = 7;
            this.btnFirst.Text = "|<";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            //
            // btnPrevious
            //
            this.btnPrevious.Location = new System.Drawing.Point(465, 5);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(1);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(49, 25);
            this.btnPrevious.TabIndex = 8;
            this.btnPrevious.Text = "<";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            //
            // btnLast
            //
            this.btnLast.Location = new System.Drawing.Point(676, 5);
            this.btnLast.Margin = new System.Windows.Forms.Padding(1);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(49, 25);
            this.btnLast.TabIndex = 9;
            this.btnLast.Text = ">|";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            //
            // btnGo
            //
            this.btnGo.Location = new System.Drawing.Point(570, 5);
            this.btnGo.Margin = new System.Windows.Forms.Padding(1);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(49, 25);
            this.btnGo.TabIndex = 50;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            //
            // lblCustPageSize
            //
            this.lblCustPageSize.Location = new System.Drawing.Point(226, 7);
            this.lblCustPageSize.Name = "lblCustPageSize";
            this.lblCustPageSize.Size = new System.Drawing.Size(92, 17);
            this.lblCustPageSize.TabIndex = 11;
            this.lblCustPageSize.Text = "自定义页大小:";
            this.lblCustPageSize.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // txtCustPageSize
            //
            this.txtCustPageSize.Location = new System.Drawing.Point(311, 5);
            this.txtCustPageSize.Margin = new System.Windows.Forms.Padding(1);
            this.txtCustPageSize.Name = "txtCustPageSize";
            this.txtCustPageSize.Size = new System.Drawing.Size(44, 23);
            this.txtCustPageSize.TabIndex = 12;
            this.txtCustPageSize.Text = "50";
            this.txtCustPageSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCustPageSize.TextChanged += new System.EventHandler(this.txtCustPageSize_TextChanged);
            //
            // label1
            //
            this.label1.Location = new System.Drawing.Point(360, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "条/每页";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // Pager
            //
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCustPageSize);
            this.Controls.Add(this.lblCustPageSize);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtPageIndex);
            this.Controls.Add(this.lblPageInfo);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Name = "Pager";
            this.Size = new System.Drawing.Size(735, 34);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion 组件设计器生成的代码

        protected virtual void OnPageChanged(EventArgs e)
        {
            if (PageChanged != null)
            {
                InitPageInfo();
                PageChanged(this, e);
            }
        }

        private void btnFirst_Click(object sender,
            EventArgs e)
        {
            RefreshData(1);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            int num;
            try
            {
                num = Convert.ToInt16(txtPageIndex.Text);
            }
            catch// (Exception ex)
            {
                num = 1;
            }

            if (num > m_PageCount)
                num = m_PageCount;
            if (num < 1)
                num = 1;

            RefreshData(num);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            RefreshData(m_PageCount > 0 ? m_PageCount : 1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (m_PageIndex < m_PageCount)
            {
                RefreshData(m_PageIndex + 1);
            }
            else if (m_PageCount < 1)
            {
                RefreshData(1);
            }
            else
            {
                RefreshData(m_PageCount);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (m_PageIndex > 1)
            {
                RefreshData(m_PageIndex - 1);
            }
            else
            {
                RefreshData(1);
            }
        }

        private void txtCustPageSize_TextChanged(object sender, EventArgs e)
        {
            int intCustPageSize;
            PageSize = int.TryParse(txtCustPageSize.Text.Trim(), out intCustPageSize) ? intCustPageSize : 50;
        }
    }
}