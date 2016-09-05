using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using Nikita.Base.Define;
using Nikita.DataAccess4DBHelper;

namespace Nikita.Assist.Logger.DAL
{
    /// <summary>SqlserverLog表数据访问类
    /// 作者:UsTeam(QQ:871939149、944527357、363458293)
    /// 创建时间:2015-08-16 19:05:30
    /// </summary>
    public partial class SqlserverLogDAL : ILog
    {
         
        public SqlserverLogDAL()
        { 
        }
   

        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(Exception objectEx, string Logger)
        { 
            Nikita.Assist.Logger.Model.SqlserverLog model = new
            Nikita.Assist.Logger.Model.SqlserverLog();
            model.Date = DateTime.Now;
            model.Logger = Logger;
            model.Message = objectEx.ToString();
            model.Level = 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SqlserverLog(");
            strSql.Append("Date, Level, Logger, Message  )");
            strSql.Append(" values (");
            strSql.Append("@Date, @Level, @Logger, @Message  )");
            strSql.Append(";select @@IDENTITY");
            IDbHelper h = DbHelper.GetDbHelper(SqlType.SqlServer, GlobalHelp.Connection);
            h.CreateCommand(strSql.ToString());
            if (model.Date == null)
            {
                h.AddParameter("@Date", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Date", model.Date);
            }
            if (model.Level == null)
            {
                h.AddParameter("@Level", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Level", model.Level);
            }
            if (model.Logger == null)
            {
                h.AddParameter("@Logger", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Logger", model.Logger);
            }
            if (model.Message == null)
            {
                h.AddParameter("@Message", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Message", model.Message);
            }

            int result;
            string obj = h.ExecuteScalar();
            if (!int.TryParse(obj, out result))
            {
                return 0;
            }
            return result;
        }

          
        /// <summary>更新一条数据
        /// 
        /// </summary>
        public bool Update(Nikita.Assist.Logger.Model.SqlserverLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SqlserverLog set ");
            strSql.Append("Date=@Date, Level=@Level, Logger=@Logger, Message=@Message  ");
            strSql.Append(" where id=@id ");
            IDbHelper h = DbHelper.GetDbHelper(SqlType.SqlServer, GlobalHelp.Connection);
            h.CreateCommand(strSql.ToString());
            if (model.id == null)
            {
                h.AddParameter("@id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@id", model.id);
            }
            if (model.Date == null)
            {
                h.AddParameter("@Date", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Date", model.Date);
            }
            if (model.Level == null)
            {
                h.AddParameter("@Level", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Level", model.Level);
            }
            if (model.Logger == null)
            {
                h.AddParameter("@Logger", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Logger", model.Logger);
            }
            if (model.Message == null)
            {
                h.AddParameter("@Message", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Message", model.Message);
            }

            return h.ExecuteNonQuery();
        }

        /// <summary>删除一条数据
        /// 
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SqlserverLog ");
            strSql.Append(" where id=@id ");
            IDbHelper h = DbHelper.GetDbHelper(SqlType.SqlServer, GlobalHelp.Connection);
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", id);
            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件删除数据
        /// 
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SqlserverLog ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            IDbHelper h = DbHelper.GetDbHelper(SqlType.SqlServer, GlobalHelp.Connection);
            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        public Nikita.Assist.Logger.Model.SqlserverLog GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SqlserverLog ");
            strSql.Append(" where id=@id ");
            IDbHelper h = DbHelper.GetDbHelper(SqlType.SqlServer, GlobalHelp.Connection);
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", id);
            Nikita.Assist.Logger.Model.SqlserverLog model = null;
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
        public Nikita.Assist.Logger.Model.SqlserverLog GetModelByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from SqlserverLog ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            } 
            IDbHelper h = DbHelper.GetDbHelper(SqlType.SqlServer, GlobalHelp.Connection);
            h.CreateCommand(strSql.ToString());
            Nikita.Assist.Logger.Model.SqlserverLog model = null;
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
            strSql.Append(" FROM SqlserverLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            IDbHelper h = DbHelper.GetDbHelper(SqlType.SqlServer, GlobalHelp.Connection);
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }


        /// <summary>获得数据列表
        /// 
        /// </summary>
        public DataSet GetList(string strWhere, string Filds)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + Filds + " ");
            strSql.Append(" FROM SqlserverLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            IDbHelper h = DbHelper.GetDbHelper(SqlType.SqlServer, GlobalHelp.Connection);
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }


        /// <summary>分页获取数据列表
        /// 
        /// </summary>
        public DataSet GetList(string fileds, string order, string ordertype, int PageSize, int PageIndex, string strWhere)
        {
            IDbHelper h = DbHelper.GetDbHelper(SqlType.SqlServer, GlobalHelp.Connection);
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "SqlserverLog");
            h.AddParameter("@strFields", fileds);
            h.AddParameter("@strOrder", order);
            h.AddParameter("@strOrderType", ordertype);
            h.AddParameter("@PageSize", PageSize);
            h.AddParameter("@PageIndex", PageIndex);
            h.AddParameter("@strWhere", strWhere);
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得数据列表（比DataSet效率高，推荐使用）
        /// 
        /// </summary>
        public List<Nikita.Assist.Logger.Model.SqlserverLog> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM SqlserverLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Nikita.Assist.Logger.Model.SqlserverLog> list = new List<Nikita.Assist.Logger.Model.SqlserverLog>();
            IDbHelper h = DbHelper.GetDbHelper(SqlType.SqlServer, GlobalHelp.Connection);
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
        public List<Nikita.Assist.Logger.Model.SqlserverLog> GetListArray(string fileds, string order, string ordertype, int PageSize, int PageIndex, string strWhere)
        {
            IDbHelper h = DbHelper.GetDbHelper(SqlType.SqlServer, GlobalHelp.Connection);
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "SqlserverLog");
            h.AddParameter("@strFields", fileds);
            h.AddParameter("@strOrder", order);
            h.AddParameter("@strOrderType", ordertype);
            h.AddParameter("@PageSize", PageSize);
            h.AddParameter("@PageIndex", PageIndex);
            h.AddParameter("@strWhere", strWhere);
            List<Nikita.Assist.Logger.Model.SqlserverLog> list = new List<Nikita.Assist.Logger.Model.SqlserverLog>();
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
        public Nikita.Assist.Logger.Model.SqlserverLog ReaderBind(IDataReader dataReader)
        {
            Nikita.Assist.Logger.Model.SqlserverLog model = new Nikita.Assist.Logger.Model.SqlserverLog();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = int.Parse(ojb.ToString());
            }
            ojb = dataReader["Date"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Date = DateTime.Parse(ojb.ToString());
            }
            ojb = dataReader["Level"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Level = int.Parse(ojb.ToString());
            }
            model.Logger = dataReader["Logger"].ToString();
            model.Message = dataReader["Message"].ToString();

            return model;
        }

        /// <summary>计算记录数
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int CalcCount(string cond)
        {
            string sql = "select count(1) from SqlserverLog";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
            IDbHelper h = DbHelper.GetDbHelper(SqlType.SqlServer, GlobalHelp.Connection);
            h.CreateCommand(sql);
            return int.Parse(h.ExecuteScalar());
        }
    }
}

