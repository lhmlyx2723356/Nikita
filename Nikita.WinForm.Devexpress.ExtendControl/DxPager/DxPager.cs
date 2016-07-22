
using System;

using System.ComponentModel;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl4DX
{
    public delegate void DxPageChangedEventHandler(object sender, EventArgs e);

    /// <summary>
    /// 分页工具条用户控件，仅提供分页信息显示及改变页码操作
    /// </summary>
    public class DxPager : UserControl
    {
        public event DxPageChangedEventHandler PageChanged;

        private int m_PageSize;
        private int m_PageCount;
        private int m_RecordCount;
        private int m_PageIndex;
        private int m_CustPageSize;

        private Label lblPageInfo;
        private DevExpress.XtraEditors.SimpleButton btnFirst;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnLast;
        private DevExpress.XtraEditors.SimpleButton btnPrevious;
        private DevExpress.XtraEditors.SimpleButton btnGo;
        private DevExpress.XtraEditors.TextEdit txtPageIndex;
        private Label lblPageSize;
        private DevExpress.XtraEditors.TextEdit txtPageSize;
        private Label label1;

        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary> 
        /// 默认构造函数，设置分页初始信息
        /// </summary>
        public DxPager()
        {
            InitializeComponent();

            this.m_PageSize = 10;
            this.m_RecordCount = 0;
            this.m_PageIndex = 1; //默认为第一页 
            this.m_CustPageSize = 10;
            //this.txtPageSize.Text = this.m_PageSize.ToString();
        }

        /// <summary> 
        /// 带参数的构造函数
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// </summary>
        public DxPager(int recordCount, int pageSize)
        {
            InitializeComponent();

            this.m_PageSize = pageSize;
            this.m_RecordCount = recordCount;
            this.m_PageIndex = 1; //默认为第一页 
            this.InitPageInfo();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
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
            this.btnFirst = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnLast = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrevious = new DevExpress.XtraEditors.SimpleButton();
            this.btnGo = new DevExpress.XtraEditors.SimpleButton();
            this.txtPageIndex = new DevExpress.XtraEditors.TextEdit();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.txtPageSize = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageIndex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageSize.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPageInfo.Location = new System.Drawing.Point(3, 5);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(282, 20);
            this.lblPageInfo.TabIndex = 0;
            this.lblPageInfo.Text = "共 {0} 条记录，每页 {1} 条，共 {2} 页";
            this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(289, 5);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(35, 23);
            this.btnFirst.TabIndex = 1;
            this.btnFirst.Text = "|<";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(469, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(35, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(510, 5);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(35, 23);
            this.btnLast.TabIndex = 3;
            this.btnLast.Text = ">|";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(330, 5);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(35, 23);
            this.btnPrevious.TabIndex = 4;
            this.btnPrevious.Text = "<";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(428, 5);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(35, 23);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtPageIndex
            // 
            this.txtPageIndex.Location = new System.Drawing.Point(372, 5);
            this.txtPageIndex.Name = "txtPageIndex";
            this.txtPageIndex.Properties.Mask.EditMask = "d";
            this.txtPageIndex.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPageIndex.Size = new System.Drawing.Size(50, 22);
            this.txtPageIndex.TabIndex = 6;
            // 
            // lblPageSize
            // 
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPageSize.Location = new System.Drawing.Point(552, 5);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(96, 20);
            this.lblPageSize.TabIndex = 7;
            this.lblPageSize.Text = "自定义页大小:";
            // 
            // txtPageSize
            // 
            this.txtPageSize.Location = new System.Drawing.Point(646, 5);
            this.txtPageSize.Name = "txtPageSize";
            this.txtPageSize.Properties.Mask.EditMask = "d";
            this.txtPageSize.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPageSize.Size = new System.Drawing.Size(50, 22);
            this.txtPageSize.TabIndex = 8;
            this.txtPageSize.EditValueChanged += new System.EventHandler(this.txtPageSize_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(700, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "条/页";
            // 
            // DxPager
            // 
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPageSize);
            this.Controls.Add(this.lblPageSize);
            this.Controls.Add(this.txtPageIndex);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.lblPageInfo);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "DxPager";
            this.Size = new System.Drawing.Size(782, 32);
            ((System.ComponentModel.ISupportInitialize)(this.txtPageIndex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageSize.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion



        protected virtual void OnPageChanged(EventArgs e)
        {
            if (PageChanged != null)
            {
                InitPageInfo();
                PageChanged(this, e);
            }
        }

        [Description("设置或获取一页中显示的记录数目"), DefaultValue(10), Category("分页")]
        public int PageSize
        {
            set
            {
                this.m_PageSize = value;
            }
            get
            {
                return this.m_PageSize;
            }
        }

        [Description("获取记录总页数"), DefaultValue(0), Category("分页")]
        public int PageCount
        {
            get
            {
                return this.m_PageCount;
            }
        }

        [Description("设置或获取记录总数"), Category("分页")]
        public int RecordCount
        {
            set
            {
                this.m_RecordCount = value;
            }
            get
            {
                return this.m_RecordCount;
            }
        }

        [Description("当前的页面索引, 开始为1"), DefaultValue(0), Category("分页")]
        [Browsable(false)]
        public int PageIndex
        {
            set
            {
                this.m_PageIndex = value;
            }
            get
            {
                return this.m_PageIndex;
            }
        }

        [Description("当前的页面自定义页面大小"), DefaultValue(0), Category("分页")]
        [Browsable(false)]
        public int CustPageSize
        {
            set
            {
                this.m_CustPageSize = value;
            }
            get
            {
                return this.m_CustPageSize;
            }
        }

        /// <summary> 
        /// 初始化分页信息
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// </summary>
        public void InitPageInfo(int recordCount, int pageSize)
        {
            this.m_RecordCount = recordCount;
            this.m_PageSize = pageSize;
            this.InitPageInfo();
        }

        /// <summary> 
        /// 初始化分页信息
        /// <param name="recordCount">总记录数</param>
        /// </summary>
        public void InitPageInfo(int recordCount)
        {
            this.m_RecordCount = recordCount;
            this.InitPageInfo();
        }

        /// <summary> 
        /// 初始化分页信息
        /// </summary>
        public void InitPageInfo()
        {
            if (this.m_PageSize < 1)
            {
                this.m_PageSize = 10; //如果每页记录数不正确，即更改为10
            }
            if (this.m_CustPageSize < 1)
            {
                this.m_CustPageSize = 10; //如果每页记录数不正确，即更改为10 
            }
            if (this.m_RecordCount < 0)
            {
                this.m_RecordCount = 0; //如果记录总数不正确，即更改为0
            }
            if (this.m_PageSize != m_CustPageSize)
            {
                this.m_PageSize = m_CustPageSize;//this.m_CustPageSize;
            }
            //取得总页数
            if (this.m_RecordCount % this.m_PageSize == 0)
            {
                this.m_PageCount = this.m_RecordCount / this.m_PageSize;
            }
            else
            {
                this.m_PageCount = this.m_RecordCount / this.m_PageSize + 1;
            }

            //设置当前页
            if (this.m_PageIndex > this.m_PageCount)
            {
                this.m_PageIndex = this.m_PageCount;
            }
            if (this.m_PageIndex < 1)
            {
                this.m_PageIndex = 1;
            }

            //设置上一页按钮的可用性
            bool enable = (this.PageIndex > 1);
            this.btnPrevious.Enabled = enable;

            //设置首页按钮的可用性
            enable = (this.PageIndex > 1);
            this.btnFirst.Enabled = enable;

            //设置下一页按钮的可用性
            enable = (this.PageIndex < this.PageCount);
            this.btnNext.Enabled = enable;

            //设置末页按钮的可用性
            enable = (this.PageIndex < this.PageCount);
            this.btnLast.Enabled = enable;

            this.txtPageIndex.Text = this.m_PageIndex.ToString();
            this.lblPageInfo.Text = string.Format("共 {0} 条记录，每页 {1} 条，共 {2} 页", this.m_RecordCount, this.m_PageSize, this.m_PageCount);
        }

        public void RefreshData(int page)
        {
            this.m_PageIndex = page;
            EventArgs e = new EventArgs();
            OnPageChanged(e);
        }

        private void btnFirst_Click(object sender, System.EventArgs e)
        {
            this.RefreshData(1);
        }

        private void btnPrevious_Click(object sender, System.EventArgs e)
        {
            if (this.m_PageIndex > 1)
            {
                this.RefreshData(this.m_PageIndex - 1);
            }
            else
            {
                this.RefreshData(1);
            }
        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            if (this.m_PageIndex < this.m_PageCount)
            {
                this.RefreshData(this.m_PageIndex + 1);
            }
            else if (this.m_PageCount < 1)
            {
                this.RefreshData(1);
            }
            else
            {
                this.RefreshData(this.m_PageCount);
            }
        }

        private void btnLast_Click(object sender, System.EventArgs e)
        {
            if (this.m_PageCount > 0)
            {
                this.RefreshData(this.m_PageCount);
            }
            else
            {
                this.RefreshData(1);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            int num;
            try
            {
                num = Convert.ToInt16(this.txtPageIndex.Text);
            }
            catch// (Exception ex)
            {
                num = 1;
            }

            if (num > this.m_PageCount)
                num = this.m_PageCount;
            if (num < 1)
                num = 1;

            this.RefreshData(num);
        }

        private void txtPageSize_EditValueChanged(object sender, EventArgs e)
        {
            int CustPageSize = Convert.ToInt32(txtPageSize.Text.Trim());
            if (CustPageSize < 10)
            {
                this.m_CustPageSize = 10;
                return;
            }
            else
            {
                this.m_CustPageSize = CustPageSize;
            }
            btnGo_Click(null, null);

        }

    }
}

