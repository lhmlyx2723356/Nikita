/// <summary>说明:FrmTestNestQuery文件
/// 作者:卢华明
/// 创建时间:2016-05-04 22:32:07
/// </summary>
using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;
using System.Reflection;
using Nikita.Core;
using Nikita.DataAccess4DBHelper;
using Nikita.Assist.CodeMaker.CodeMakerDemoForm;
namespace Nikita.Assist.CodeMaker
{
    public partial class FrmTestNestQuery
    {
        #region 变量、常量
        /// <summary>显示控件
        /// 
        /// </summary> 
        MasterControl _masterDetail;
        #endregion
        #region 构造函数
        public FrmTestNestQuery()
        {
            InitializeComponent();
        }
        #endregion
        #region 基本事件
        public void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion
        #region 基本方法
        /// <summary>加载数据
        /// 
        /// </summary>
        public void LoadData()
        {
            Clear();
            CreateMasterDetailView();
        }
        /// <summary>清空
        /// 
        /// </summary>
        public void Clear()
        {
            panelView.Controls.Clear();
            _masterDetail = null;
            Refresh();
        }
        /// <summary>创建主从关系
        /// 
        /// </summary>
        public void CreateMasterDetailView()
        {
            var oDataSet = GetData();
            _masterDetail = new MasterControl(oDataSet, ControlType.Middle);
            panelView.Controls.Add(_masterDetail);
        }
        /// <summary> 获取数据源
        /// 
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetData()
        {
            IDbHelper dbHelper = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            string strWhere = GetSearchSql();
            string strSql ="SELECT * FROM  dbo.Sys_Departments WHERE  " + strWhere + "   SELECT  b.DepID,a.* FROM   dbo.Sys_Users a  INNER JOIN Sys_Users_Departments b ON a.KeyId =b.UserID    " 
;
            dbHelper.CreateCommand(strSql);
            DataSet dataSet = dbHelper.ExecuteQueryDataSet();
         string[] strKeyArray = {"keyid","depid" };
            for (int i = 0; i < dataSet.Tables.Count; i++)
            {
                dataSet.Tables[i].TableName = "T" + (i + 1);
                HashSet<string> hsSet = new HashSet<string>();
                foreach (DataRow drRow in dataSet.Tables[i].Rows)
                {
                    string strKey = strKeyArray[i];
                    string strValue = drRow[strKey].ToString();
                    if (!hsSet.Contains(strValue))
                    {
                        hsSet.Add(strValue);
                    }
                }
                if (i < dataSet.Tables.Count - 1)
                {
                    for (int j = 0; j < dataSet.Tables[i + 1].Rows.Count; j++)
                    {
                        string strKey2 = strKeyArray[i + 1];
                        string strValue2 = dataSet.Tables[i + 1].Rows[j][strKey2].ToString();
                        if (!hsSet.Contains(strValue2))
                        {
                            dataSet.Tables[i + 1].Rows.RemoveAt(j);
                            j--;
                        }
                    }
                }
            }
            //这是对应关系的时候主键必须唯一
            dataSet.Relations.Add("1", dataSet.Tables["T1"].Columns["keyid"], dataSet.Tables["T2"].Columns["depid"]);
            return dataSet;
        }

        /// <summary>根据查询条件构造查询语句
        ///
        /// </summary>
        /// <returns>查询条件</returns>
        private string GetSearchSql()
        {
            SearchCondition condition = new SearchCondition();
condition.AddCondition("DepartmentName", this.txtQueryDepartmentName.Text, SqlOperator.Like);
condition.AddCondition("Sortnum", this.txtQuerySortnum.Text, SqlOperator.Like);
            return condition.BuildConditionSql().Replace("Where", "");

        }
        #endregion
    }
}
