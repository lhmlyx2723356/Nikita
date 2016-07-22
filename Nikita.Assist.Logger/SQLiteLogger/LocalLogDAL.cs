using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nikita.Assist.Logger.DAL
{
    /// <summary>LocalLog表数据访问类
    /// 作者:UsTeam(QQ:871939149、944527357、363458293)
    /// 创建时间:2015-08-16 10:57:46
    /// </summary>
    public partial class LocalLogDAL :ILog
    {
        public LocalLogDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(Exception objectEx, string Logger)
        {
            Nikita.Assist.Logger.Model.LocalLog model = new  Nikita.Assist.Logger.Model.LocalLog();
            model.Date = DateTime.Now;
            model.Logger = Logger;
            model.Message = objectEx.ToString();
            model.Level = "1";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LocalLog(");
            strSql.Append("Date, Level, Logger, Message )");
            strSql.Append(" values (");
            strSql.Append("@Date, @Level, @Logger, @Message )");
            SQLiteHelper h = new SQLiteHelper();

            h.CreateCommand(strSql.ToString());
            if (model.Date == null)
            {
                 h.AddParameter("@Date", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Date", model.Date.ToString("s"));
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


            h.ExecuteNonQuery();
            string sql2 = "select max(id) from LocalLog";
            h.CreateCommand(sql2);
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
        public bool Update(Nikita.Assist.Logger.Model.LocalLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LocalLog set ");
            strSql.Append("Date=@Date, Level=@Level, Logger=@Logger, Message=@Message  ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
                        if (model.Date == null)
            {
                 h.AddParameter("@Date", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Date", model.Date.ToString("s"));
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
            h.AddParameter("@id", model.id);

            return h.ExecuteNonQuery();
        }

        /// <summary>删除一条数据
        /// 
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LocalLog ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper();
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
            strSql.Append("delete from LocalLog ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        public Nikita.Assist.Logger.Model.LocalLog GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from LocalLog ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", id);
            Nikita.Assist.Logger.Model.LocalLog model = null;
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
        public Nikita.Assist.Logger.Model.LocalLog GetModelByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from LocalLog ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            strSql.Append(" limit 1");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            Nikita.Assist.Logger.Model.LocalLog model = null;
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
            strSql.Append(" FROM LocalLog  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }
		        /// <summary>获得数据列表
        /// 
        /// </summary>
        public DataSet GetList(string strWhere,string Filds)
        {
            StringBuilder strSql = new StringBuilder();
			  strSql.Append("select " + Filds + " ");
            strSql.Append(" FROM LocalLog  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            SQLiteHelper h = new SQLiteHelper();
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
            SQLiteHelper h = new SQLiteHelper();
            DataTable dt = h.FengYe("LocalLog", fileds, order, ordertype, strWhere, PageSize, PageIndex);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得数据列表（比DataSet效率高，推荐使用）
        /// 
        /// </summary>
        public List<Nikita.Assist.Logger.Model.LocalLog> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM LocalLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Nikita.Assist.Logger.Model.LocalLog> list = new List<Nikita.Assist.Logger.Model.LocalLog>();
            SQLiteHelper h = new SQLiteHelper();
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
        public List<Nikita.Assist.Logger.Model.LocalLog> GetListArray(string fileds, string order, string ordertype, int PageSize, int PageIndex, string strWhere)
        {
            SQLiteHelper h = new SQLiteHelper();
            DataTable dt = h.FengYe("LocalLog", fileds, order, ordertype, strWhere, PageSize, PageIndex);
            List<Nikita.Assist.Logger.Model.LocalLog> list = new List<Nikita.Assist.Logger.Model.LocalLog>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Model.LocalLog()
                {
                    id = int.Parse(row["id"].ToString()),Date = DateTime.Parse(row["Date"].ToString()),Level = row["Level"].ToString(),Logger = row["Logger"].ToString(),Message = row["Message"].ToString(),
                });
            }
            return list;
        }

        /// <summary>对象实体绑定数据
        /// 
        /// </summary>
        public Nikita.Assist.Logger.Model.LocalLog ReaderBind(IDataReader dataReader)
        {
            Nikita.Assist.Logger.Model.LocalLog model = new Nikita.Assist.Logger.Model.LocalLog();
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
            model.Level = dataReader["Level"].ToString();
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
            string sql = "select count(1) from LocalLog";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(sql);
            return int.Parse(h.ExecuteScalar());
        }
    }
}

