using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nikita.Assist.CodeMaker.CodeMakerDemoForm;

namespace Nikita.Assist.CodeMaker.DAL
{
    /// <summary>OrderMaster表数据访问类
    /// 作者:Luhm
    /// 创建时间:2016-05-10 20:46:32
    /// </summary>
    public partial class OrderMasterDAL
    {
        public OrderMasterDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(Nikita.Assist.CodeMaker.Model.OrderMaster model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrderMaster(");
            strSql.Append("OrderNumber, Status, CreateDate  )");
            strSql.Append(" values (");
            strSql.Append("@OrderNumber, @Status, @CreateDate  )");
            strSql.Append(";select @@IDENTITY");
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            if (model.OrderNumber == null)
            {
                 h.AddParameter("@OrderNumber", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@OrderNumber", model.OrderNumber);
            }
            if (model.Status == null)
            {
                 h.AddParameter("@Status", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Status", model.Status);
            }
            if (model.CreateDate == null)
            {
                 h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@CreateDate", model.CreateDate);
            }

            int intResult;
            string obj = h.ExecuteScalar();
            if (!int.TryParse(obj, out intResult))
            {
                return 0;
            }
            return   intResult;
        }

        /// <summary>更新一条数据
        /// 
        /// </summary>
        public bool Update(Nikita.Assist.CodeMaker.Model.OrderMaster model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrderMaster set ");
            strSql.Append("OrderNumber=@OrderNumber, Status=@Status, CreateDate=@CreateDate  ");
            strSql.Append(" where OrderId=@OrderId ");
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            if (model.OrderId == null)
            {
                 h.AddParameter("@OrderId", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@OrderId", model.OrderId);
            }
            if (model.OrderNumber == null)
            {
                 h.AddParameter("@OrderNumber", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@OrderNumber", model.OrderNumber);
            }
            if (model.Status == null)
            {
                 h.AddParameter("@Status", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Status", model.Status);
            }
            if (model.CreateDate == null)
            {
                 h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@CreateDate", model.CreateDate);
            }

            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件更新字段
        /// 
        /// </summary>
        public bool Update(string strFieldWithValue,string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrderMaster set ");
            strSql.Append(strFieldWithValue);
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond );
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString()); 
            return h.ExecuteNonQuery();
        }

        /// <summary>删除一条数据
        /// 
        /// </summary>
        public bool Delete(int OrderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrderMaster ");
            strSql.Append(" where OrderId=@OrderId ");
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@OrderId", OrderId);
            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件删除数据
        /// 
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrderMaster ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        public Nikita.Assist.CodeMaker.Model.OrderMaster GetModel(int OrderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from OrderMaster ");
            strSql.Append(" where OrderId=@OrderId ");
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@OrderId", OrderId);
            Nikita.Assist.CodeMaker.Model.OrderMaster model = null;
            using (IDataReader dataReader = h.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
                h.CloseConn();
            }
            return model;
        }

        /// <summary>根据条件得到一个对象实体
        /// 
        /// </summary>
        public Nikita.Assist.CodeMaker.Model.OrderMaster GetModelByCond(string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from OrderMaster ");
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond);
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            Nikita.Assist.CodeMaker.Model.OrderMaster model = null;
            using (IDataReader dataReader = h.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
                h.CloseConn();
            }
            return model;
        }

        /// <summary>获得数据列表
        /// 
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM OrderMaster ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

		
        /// <summary>获得数据列表
        /// 
        /// </summary>
        public DataSet GetList(string strWhere, string strFields)
        {
            StringBuilder strSql = new StringBuilder(); 
			  strSql.Append("select " +strFields + " ");
            strSql.Append(" FROM OrderMaster ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }


        /// <summary>分页获取数据列表
        /// 
        /// </summary>
        public DataSet GetList(string strFileds, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere)
        {
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "OrderMaster");
            h.AddParameter("@strFields",strFileds);
            h.AddParameter("@strOrder", strOrder);
            h.AddParameter("@strOrderType", strOrderType);
            h.AddParameter("@PageSize", intPageSize);
            h.AddParameter("@PageIndex", intPageIndex);
            h.AddParameter("@strWhere", strWhere);
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得数据列表（比DataSet效率高，推荐使用）
        /// 
        /// </summary>
        public List<Nikita.Assist.CodeMaker.Model.OrderMaster> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM OrderMaster ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Nikita.Assist.CodeMaker.Model.OrderMaster> list = new List<Nikita.Assist.CodeMaker.Model.OrderMaster>();
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            using (IDataReader dataReader = h.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
                h.CloseConn();
            }
            return list;
        }

        /// <summary>分页获取数据列表
        /// 
        /// </summary>
        public List<Nikita.Assist.CodeMaker.Model.OrderMaster> GetListArray(string strFileds, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere)
        {
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "OrderMaster");
            h.AddParameter("@strFields", strFileds);
            h.AddParameter("@strOrder", strOrder);
            h.AddParameter("@strOrderType", strOrderType);
            h.AddParameter("@PageSize", intPageSize);
            h.AddParameter("@PageIndex", intPageIndex);
            h.AddParameter("@strWhere", strWhere);
            List<Nikita.Assist.CodeMaker.Model.OrderMaster> list = new List<Nikita.Assist.CodeMaker.Model.OrderMaster>();
            using (IDataReader dataReader = h.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
                h.CloseConn();
            }
            return list;
        }

        /// <summary>对象实体绑定数据
        /// 
        /// </summary>
        public Nikita.Assist.CodeMaker.Model.OrderMaster ReaderBind(IDataReader dataReader)
        {
            Nikita.Assist.CodeMaker.Model.OrderMaster model = new Nikita.Assist.CodeMaker.Model.OrderMaster();
            object ojb;
            ojb = dataReader["OrderId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderId = int.Parse(ojb.ToString());
            }
            model.OrderNumber = dataReader["OrderNumber"].ToString();
            ojb = dataReader["Status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = bool.Parse(ojb.ToString());
            }
            ojb = dataReader["CreateDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreateDate = DateTime.Parse(ojb.ToString());
            }

            return model;
        }

        /// <summary>计算记录数
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int CalcCount(string cond)
        {
            string sql = "select count(1) from OrderMaster";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(sql);
            return int.Parse(h.ExecuteScalar());
        }
    }
}

