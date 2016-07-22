using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nikita.Assist.CodeMaker.CodeMakerDemoForm;

namespace Nikita.Assist.CodeMaker.DAL
{
    /// <summary>OrderDetail表数据访问类
    /// 作者:Luhm
    /// 创建时间:2016-05-10 20:46:17
    /// </summary>
    public partial class OrderDetailDAL
    {
        public OrderDetailDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(Nikita.Assist.CodeMaker.Model.OrderDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrderDetail(");
            strSql.Append("OrderId, Customer, ProductName, Amount, SumMoney, Status  )");
            strSql.Append(" values (");
            strSql.Append("@OrderId, @Customer, @ProductName, @Amount, @SumMoney, @Status  )");
            strSql.Append(";select @@IDENTITY");
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
            if (model.Customer == null)
            {
                 h.AddParameter("@Customer", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Customer", model.Customer);
            }
            if (model.ProductName == null)
            {
                 h.AddParameter("@ProductName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ProductName", model.ProductName);
            }
            if (model.Amount == null)
            {
                 h.AddParameter("@Amount", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Amount", model.Amount);
            }
            if (model.SumMoney == null)
            {
                 h.AddParameter("@SumMoney", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@SumMoney", model.SumMoney);
            }
            if (model.Status == null)
            {
                 h.AddParameter("@Status", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Status", model.Status);
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
        public bool Update(Nikita.Assist.CodeMaker.Model.OrderDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrderDetail set ");
            strSql.Append("OrderId=@OrderId, Customer=@Customer, ProductName=@ProductName, Amount=@Amount, SumMoney=@SumMoney, Status=@Status  ");
            strSql.Append(" where DetailId=@DetailId ");
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            if (model.DetailId == null)
            {
                 h.AddParameter("@DetailId", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@DetailId", model.DetailId);
            }
            if (model.OrderId == null)
            {
                 h.AddParameter("@OrderId", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@OrderId", model.OrderId);
            }
            if (model.Customer == null)
            {
                 h.AddParameter("@Customer", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Customer", model.Customer);
            }
            if (model.ProductName == null)
            {
                 h.AddParameter("@ProductName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ProductName", model.ProductName);
            }
            if (model.Amount == null)
            {
                 h.AddParameter("@Amount", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Amount", model.Amount);
            }
            if (model.SumMoney == null)
            {
                 h.AddParameter("@SumMoney", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@SumMoney", model.SumMoney);
            }
            if (model.Status == null)
            {
                 h.AddParameter("@Status", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Status", model.Status);
            }

            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件更新字段
        /// 
        /// </summary>
        public bool Update(string strFieldWithValue,string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrderDetail set ");
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
        public bool Delete(int DetailId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrderDetail ");
            strSql.Append(" where DetailId=@DetailId ");
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@DetailId", DetailId);
            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件删除数据
        /// 
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrderDetail ");
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
        public Nikita.Assist.CodeMaker.Model.OrderDetail GetModel(int DetailId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from OrderDetail ");
            strSql.Append(" where DetailId=@DetailId ");
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@DetailId", DetailId);
            Nikita.Assist.CodeMaker.Model.OrderDetail model = null;
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
        public Nikita.Assist.CodeMaker.Model.OrderDetail GetModelByCond(string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from OrderDetail ");
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond);
            }
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateCommand(strSql.ToString());
            Nikita.Assist.CodeMaker.Model.OrderDetail model = null;
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
            strSql.Append(" FROM OrderDetail ");
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
            strSql.Append(" FROM OrderDetail ");
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
            h.AddParameter("@tblName", "OrderDetail");
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
        public List<Nikita.Assist.CodeMaker.Model.OrderDetail> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM OrderDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Nikita.Assist.CodeMaker.Model.OrderDetail> list = new List<Nikita.Assist.CodeMaker.Model.OrderDetail>();
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
        public List<Nikita.Assist.CodeMaker.Model.OrderDetail> GetListArray(string strFileds, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere)
        {
            DataAccess4DBHelper.IDbHelper h = GlobalHelpDemoForm.GetDataAccessHelperDemo();
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "OrderDetail");
            h.AddParameter("@strFields", strFileds);
            h.AddParameter("@strOrder", strOrder);
            h.AddParameter("@strOrderType", strOrderType);
            h.AddParameter("@PageSize", intPageSize);
            h.AddParameter("@PageIndex", intPageIndex);
            h.AddParameter("@strWhere", strWhere);
            List<Nikita.Assist.CodeMaker.Model.OrderDetail> list = new List<Nikita.Assist.CodeMaker.Model.OrderDetail>();
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
        public Nikita.Assist.CodeMaker.Model.OrderDetail ReaderBind(IDataReader dataReader)
        {
            Nikita.Assist.CodeMaker.Model.OrderDetail model = new Nikita.Assist.CodeMaker.Model.OrderDetail();
            object ojb;
            ojb = dataReader["DetailId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.DetailId = int.Parse(ojb.ToString());
            }
            ojb = dataReader["OrderId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderId = int.Parse(ojb.ToString());
            }
            model.Customer = dataReader["Customer"].ToString();
            model.ProductName = dataReader["ProductName"].ToString();
            ojb = dataReader["Amount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Amount = int.Parse(ojb.ToString());
            }
            ojb = dataReader["SumMoney"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SumMoney = double.Parse(ojb.ToString());
            }
            ojb = dataReader["Status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = bool.Parse(ojb.ToString());
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
            string sql = "select count(1) from OrderDetail";
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

