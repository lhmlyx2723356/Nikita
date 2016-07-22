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
using Nikita.Assist.CodeMaker.CodeMakerDemoForm;
//using Nikita.Assist.CodeMaker.CodeMakerDemoForm;
using Nikita.Core;
using Nikita.DataAccess4DBHelper;

namespace Nikita.Assist.CodeMaker
{
    public partial class FrmNestQuery
    {
        #region 变量、常量
        /// <summary>显示控件
        /// 
        /// </summary> 
        MasterControl _masterDetail;
        #endregion

        #region 构造函数
        public FrmNestQuery()
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
            string strSql = "SELECT * INTO #TempTable FROM  dbo.Sys_Departments  WHERE  " + strWhere + "" +
                                       "  SELECT  * FROM   #TempTable " +
                                       "  SELECT  b.DepID,a.* FROM   dbo.Sys_Users a " +
                                       "  INNER JOIN  #TempTable b ON a.KeyId =b.UserID" +

              //+ 
                //"  SELECT   b.UserID ,c.* FROM  Sys_Users  a" +
                //"  INNER JOIN dbo.Sys_UserRoles b ON a.KeyId=b.UserID" +
                //"  INNER JOIN dbo.Sys_Roles c ON c.KeyId=b.RoleID WHERE  UserID=15 "

                     "  Drop Table  #TempTable "
;
            dbHelper.CreateCommand(strSql);
            DataSet oDataSet = dbHelper.ExecuteQueryDataSet();
            for (int i = 0; i < oDataSet.Tables.Count; i++)
            {
                oDataSet.Tables[i].TableName = "T" + (i + 1);
            }
            //这是对应关系的时候主键必须唯一
            oDataSet.Relations.Add("1", oDataSet.Tables["T1"].Columns["KeyId"], oDataSet.Tables["T2"].Columns["DepID"]);
            //oDataSet.Relations.Add("2", oDataSet.Tables["T2"].Columns["KeyId"], oDataSet.Tables["T3"].Columns["UserId"]);
            return oDataSet;
        }

        /// <summary>根据查询条件构造查询语句
        ///
        /// </summary>
        /// <returns>查询条件</returns>
        private string GetSearchSql()
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("UserName", this.txtDepartmentName.Text, SqlOperator.Like);
            return condition.BuildConditionSql().Replace("Where", "");
        }

        #endregion
    }
}
