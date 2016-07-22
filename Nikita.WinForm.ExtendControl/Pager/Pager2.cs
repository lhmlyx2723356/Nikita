using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
    /// <summary>
    /// 申明委托
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public delegate int EventPagingHandler(EventPagingArg e);

    /// <summary>
    /// 自定义事件数据基类
    /// </summary>
    public class EventPagingArg : EventArgs
    {
        private int _intPageIndex;

        public EventPagingArg(int PageIndex)
        {
            _intPageIndex = PageIndex;
        }
    }

    /// <summary>
    /// 数据源提供
    /// </summary>
    public class PageData
    {
        private bool _isQueryTotalCounts = true;
        private string _OrderStr = string.Empty;
        private int _PageCount = 0;
        private int _PageIndex = 1;
        private int _PageSize = 10;
        private string _PrimaryKey = string.Empty;

        //排序_SortStr
        private string _QueryCondition = string.Empty;

        private string _QueryFieldName = "*";
        private string _TableName;
        private int _TotalCount = 0;

        //表名
        //表字段FieldStr
        //查询的条件 RowFilter
        //主键
        //是否查询总的记录条数
        /// <summary>
        /// 是否查询总的记录条数
        /// </summary>
        public bool IsQueryTotalCounts
        {
            get { return _isQueryTotalCounts; }
            set { _isQueryTotalCounts = value; }
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string OrderStr
        {
            get
            {
                return _OrderStr;
            }
            set
            {
                _OrderStr = value;
            }
        }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                return _PageCount;
            }
        }

        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex
        {
            get
            {
                return _PageIndex;
            }
            set
            {
                _PageIndex = value;
            }
        }

        /// <summary>
        /// 显示页数
        /// </summary>
        public int PageSize
        {
            get
            {
                return _PageSize;
            }
            set
            {
                _PageSize = value;
            }
        }

        /// <summary>
        /// 主键
        /// </summary>
        public string PrimaryKey
        {
            get
            {
                return _PrimaryKey;
            }
            set
            {
                _PrimaryKey = value;
            }
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        public string QueryCondition
        {
            get
            {
                return _QueryCondition;
            }
            set
            {
                _QueryCondition = value;
            }
        }

        /// <summary>
        /// 表字段FieldStr
        /// </summary>
        public string QueryFieldName
        {
            get
            {
                return _QueryFieldName;
            }
            set
            {
                _QueryFieldName = value;
            }
        }

        /// <summary>
        /// 表名，包括视图
        /// </summary>
        public string TableName
        {
            get
            {
                return _TableName;
            }
            set
            {
                _TableName = value;
            }
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount
        {
            get
            {
                return _TotalCount;
            }
        }

        public int GetTotalCount()
        {
            string strSql = " select count(1) from " + _TableName;
            if (_QueryCondition != string.Empty)
            {
                strSql += " where " + _QueryCondition;
            }
            return int.Parse(DbHelper.GetSingle(strSql, SysConst.SourceDbConnectionString).ToString());
        }

        public DataSet QueryDataTable()
        {
            SqlParameter[] parameters = {
					new SqlParameter("@Tables", SqlDbType.VarChar, 255),
				    new SqlParameter("@PrimaryKey" , SqlDbType.VarChar , 255),
                    new SqlParameter("@Sort", SqlDbType.VarChar , 255 ),
                    new SqlParameter("@CurrentPage", SqlDbType.Int),
					new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@Fields", SqlDbType.VarChar, 255),
					new SqlParameter("@Filter", SqlDbType.VarChar,1000),
                    new SqlParameter("@Group" ,SqlDbType.VarChar , 1000 )
					};
            parameters[0].Value = _TableName;
            parameters[1].Value = _PrimaryKey;
            parameters[2].Value = _OrderStr;
            parameters[3].Value = PageIndex;
            parameters[4].Value = PageSize;
            parameters[5].Value = _QueryFieldName;
            parameters[6].Value = _QueryCondition;
            parameters[7].Value = string.Empty;
            DataSet ds = DbHelper.RunProcedure("SP_Pagination", parameters, "dd", SysConst.SourceDbConnectionString);
            if (_isQueryTotalCounts)
            {
                _TotalCount = GetTotalCount();
            }
            if (_TotalCount == 0)
            {
                _PageIndex = 0;
                _PageCount = 0;
            }
            else
            {
                _PageCount = _TotalCount % _PageSize == 0 ? _TotalCount / _PageSize : _TotalCount / _PageSize + 1;
                if (_PageIndex > _PageCount)
                {
                    _PageIndex = _PageCount;

                    parameters[4].Value = _PageSize;

                    ds = QueryDataTable();
                }
            }
            return ds;
        }
    }

    /// <summary>
    /// 分页控件呈现
    /// </summary>
    public partial class Pager2 : UserControl
    {
        private DataTable _dataSource;

        private int _nMax = 0;

        private int _pageCount = 0;

        private int _pageCurrent = 0;

        /// <summary>
        /// 每页显示记录数
        /// </summary>
        private int _pageSize = 20;

        public Pager2()
        {
            InitializeComponent();
        }

        public event EventPagingHandler EventPaging;

        /// <summary>
        ///  数据源
        /// </summary>
        public DataTable DataSource
        {
            get { return _dataSource; }
            set
            {
                _dataSource = value;
                bindingSource.DataSource = value;
                bindingNavigator.BindingSource = bindingSource;
            }
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int NMax
        {
            get { return _nMax; }
            set
            {
                _nMax = value;
                GetPageCount();
            }
        }

        /// <summary>
        /// 页数=总记录数/每页显示记录数
        /// </summary>
        public int PageCount
        {
            get { return _pageCount; }
            set { _pageCount = value; }
        }

        /// <summary>
        /// 当前页号
        /// </summary>
        public int PageCurrent
        {
            get { return _pageCurrent; }
            set { _pageCurrent = value; }
        }

        /// <summary>
        /// 每页显示记录数
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
                GetPageCount();
            }
        }

        public BindingNavigator ToolBar
        {
            get { return this.bindingNavigator; }
        }

        /// <summary>
        /// 翻页控件数据绑定的方法
        /// </summary>
        public void Bind()
        {
            if (this.EventPaging != null)
            {
                this.NMax = this.EventPaging(new EventPagingArg(this.PageCurrent));
            }

            if (this.PageCurrent > this.PageCount)
            {
                this.PageCurrent = this.PageCount;
            }
            if (this.PageCount == 1)
            {
                this.PageCurrent = 1;
            }
            lblPageCount.Text = this.PageCount.ToString();
            this.lblMaxPage.Text = "共" + this.NMax.ToString() + "条记录";
            this.txtCurrentPage.Text = this.PageCurrent.ToString();

            if (this.PageCurrent == 1)
            {
                this.btnPrev.Enabled = false;
                this.btnFirst.Enabled = false;
            }
            else
            {
                btnPrev.Enabled = true;
                btnFirst.Enabled = true;
            }

            if (this.PageCurrent == this.PageCount)
            {
                this.btnLast.Enabled = false;
                this.btnNext.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnNext.Enabled = true;
            }

            if (this.NMax == 0)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            PageCurrent = 1;
            this.Bind();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (this.txtCurrentPage.Text != null && txtCurrentPage.Text != "")
            {
                if (Int32.TryParse(txtCurrentPage.Text, out _pageCurrent))
                {
                    this.Bind();
                }
                else
                {
                    MessageBox.Show("输入数字格式错误！");
                }
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            PageCurrent = PageCount;
            this.Bind();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.PageCurrent += 1;
            if (PageCurrent > PageCount)
            {
                PageCurrent = PageCount;
            }
            this.Bind();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            PageCurrent -= 1;
            if (PageCurrent <= 0)
            {
                PageCurrent = 1;
            }
            this.Bind();
        }

        private void GetPageCount()
        {
            if (this.NMax > 0)
            {
                this.PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.NMax) / Convert.ToDouble(this.PageSize)));
            }
            else
            {
                this.PageCount = 0;
            }
        }

        private void txtCurrentPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Bind();
            }
        }
    }

    /*

     Create PROCEDURE SP_Pagination
/*
***************************************************************
** 千万数量级分页存储过程 **
***************************************************************
参数说明:
1.Tables :表名称,视图
2.PrimaryKey :主关键字
3.Sort :排序语句，不带Order By 比如：NewsID Desc,OrderRows Asc
4.CurrentPage :当前页码
5.PageSize :分页尺寸
6.Filter :过滤语句，不带Where
7.Group :Group语句,不带Group By
***************************************************************
(
@Tables varchar(2000),
@PrimaryKey varchar(500),
@Sort varchar(500) = NULL,
@CurrentPage int = 1,
@PageSize int = 10,
@Fields varchar(2000) = '*',
@Filter varchar(1000) = NULL,
@Group varchar(1000) = NULL
)
AS
--默认排序
IF @Sort IS NULL OR @Sort = ''
SET @Sort = @PrimaryKey
DECLARE @SortTable varchar(1000)
DECLARE @SortName varchar(1000)
DECLARE @strSortColumn varchar(1000)
DECLARE @operator char(2)
DECLARE @type varchar(1000)
DECLARE @prec int
--设定排序语句.
IF CHARINDEX('DESC',@Sort)>0
BEGIN
SET @strSortColumn = REPLACE(@Sort, 'DESC', '')
SET @operator = '<='
END
ELSE
BEGIN
IF CHARINDEX('ASC', @Sort) = 0
SET @strSortColumn = REPLACE(@Sort, 'ASC', '')
SET @operator = '>='
END
IF CHARINDEX('.', @strSortColumn) > 0
BEGIN
SET @SortTable = SUBSTRING(@strSortColumn, 0, CHARINDEX('.',@strSortColumn))
SET @SortName = SUBSTRING(@strSortColumn, CHARINDEX('.',@strSortColumn) + 1, LEN(@strSortColumn))
END
ELSE
BEGIN
SET @SortTable = @Tables
SET @SortName = @strSortColumn
END
SELECT @type=t.name, @prec=c.prec
FROM sysobjects o
JOIN syscolumns c on o.id=c.id
JOIN systypes t on c.xusertype=t.xusertype
WHERE o.name = @SortTable AND c.name = @SortName
IF CHARINDEX('char', @type) > 0
SET @type = @type + '(' + CAST(@prec AS varchar) + ')'
DECLARE @strPageSize varchar(500)
DECLARE @strStartRow varchar(500)
DECLARE @strFilter varchar(1000)
DECLARE @strSimpleFilter varchar(1000)
DECLARE @strGroup varchar(1000)
--默认当前页
IF @CurrentPage < 1
SET @CurrentPage = 1
--设置分页参数
SET @strPageSize = CAST(@PageSize AS varchar(500))
SET @strStartRow = CAST(((@CurrentPage - 1)*@PageSize + 1) AS varchar(500))
--筛选以及分组语句.
IF @Filter IS NOT NULL AND @Filter != ''
BEGIN
SET @strFilter = ' WHERE ' + @Filter + ' '
SET @strSimpleFilter = ' AND ' + @Filter + ' '
END
ELSE
BEGIN
SET @strSimpleFilter = ''
SET @strFilter = ''
END
IF @Group IS NOT NULL AND @Group != ''
SET @strGroup = ' GROUP BY ' + @Group + ' '
ELSE
SET @strGroup = ''
--执行查询语句
EXEC(
'
DECLARE @SortColumn ' + @type + '
SET ROWCOUNT ' + @strStartRow + '
SELECT @SortColumn=' + @strSortColumn + ' FROM ' + @Tables + @strFilter + ' ' + @strGroup + ' ORDER BY ' + @Sort + '
SET ROWCOUNT ' + @strPageSize + '
SELECT ' + @Fields + ' FROM ' + @Tables + ' WHERE ' + @strSortColumn + @operator + ' @SortColumn ' + @strSimpleFilter + ' ' + @strGroup + ' ORDER BY ' + @Sort + '
'
)

     */
}