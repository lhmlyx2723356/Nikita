using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nikita.Assist.DBManager.DAL
{
    /// <summary>Bse_ExcuteAnalyze表数据访问类
    ///
    /// </summary>
    public partial class Bse_ExcuteAnalyzeDAL
    {
        public Bse_ExcuteAnalyzeDAL()
        { }

        /// <summary>增加一条数据
        ///
        /// </summary>
        public int Add(Nikita.Assist.DBManager.Model.Bse_ExcuteAnalyze model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Bse_ExcuteAnalyze(");
            strSql.Append("ExcuteName, ExcuteSql, ExcuteType, DbType, Remark, CreateDate  )");
            strSql.Append(" values (");
            strSql.Append("@ExcuteName, @ExcuteSql, @ExcuteType, @DbType, @Remark, @CreateDate  )");
            strSql.Append(";select @@IDENTITY");
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
            h.CreateCommand(strSql.ToString());
            if (model.ExcuteName == null)
            {
                h.AddParameter("@ExcuteName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ExcuteName", model.ExcuteName);
            }
            if (model.ExcuteSql == null)
            {
                h.AddParameter("@ExcuteSql", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ExcuteSql", model.ExcuteSql);
            }
            if (model.ExcuteType == null)
            {
                h.AddParameter("@ExcuteType", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ExcuteType", model.ExcuteType);
            }
            if (model.DbType == null)
            {
                h.AddParameter("@DbType", DBNull.Value);
            }
            else
            {
                h.AddParameter("@DbType", model.DbType);
            }
            if (model.Remark == null)
            {
                h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Remark", model.Remark);
            }
            if (model.CreateDate == null)
            {
                h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateDate", model.CreateDate);
            }

            int result;
            string obj = h.ExecuteScalar();
            if (!int.TryParse(obj, out result))
            {
                return 0;
            }
            return result;
        }

        /// <summary>计算记录数
        ///
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int CalcCount(string cond)
        {
            string sql = "select count(1) from Bse_ExcuteAnalyze";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
            h.CreateCommand(sql);
            return int.Parse(h.ExecuteScalar());
        }

        /// <summary>删除一条数据
        ///
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Bse_ExcuteAnalyze ");
            strSql.Append(" where id=@id ");
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
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
            strSql.Append("delete from Bse_ExcuteAnalyze ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }

        /// <summary>获得数据列表
        ///
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Bse_ExcuteAnalyze ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
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
            strSql.Append(" FROM Bse_ExcuteAnalyze ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
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
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "Bse_ExcuteAnalyze");
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
        public List<Nikita.Assist.DBManager.Model.Bse_ExcuteAnalyze> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Bse_ExcuteAnalyze ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Nikita.Assist.DBManager.Model.Bse_ExcuteAnalyze> list = new List<Nikita.Assist.DBManager.Model.Bse_ExcuteAnalyze>();
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
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
        public List<Nikita.Assist.DBManager.Model.Bse_ExcuteAnalyze> GetListArray(string fileds, string order, string ordertype, int PageSize, int PageIndex, string strWhere)
        {
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "Bse_ExcuteAnalyze");
            h.AddParameter("@strFields", fileds);
            h.AddParameter("@strOrder", order);
            h.AddParameter("@strOrderType", ordertype);
            h.AddParameter("@PageSize", PageSize);
            h.AddParameter("@PageIndex", PageIndex);
            h.AddParameter("@strWhere", strWhere);
            List<Nikita.Assist.DBManager.Model.Bse_ExcuteAnalyze> list = new List<Nikita.Assist.DBManager.Model.Bse_ExcuteAnalyze>();
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

        /// <summary>得到一个对象实体
        ///
        /// </summary>
        public Nikita.Assist.DBManager.Model.Bse_ExcuteAnalyze GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Bse_ExcuteAnalyze ");
            strSql.Append(" where id=@id ");
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", id);
            Nikita.Assist.DBManager.Model.Bse_ExcuteAnalyze model = null;
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
        public Nikita.Assist.DBManager.Model.Bse_ExcuteAnalyze GetModelByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Bse_ExcuteAnalyze ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
            h.CreateCommand(strSql.ToString());
            Nikita.Assist.DBManager.Model.Bse_ExcuteAnalyze model = null;
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

        /// <summary>对象实体绑定数据
        ///
        /// </summary>
        public Nikita.Assist.DBManager.Model.Bse_ExcuteAnalyze ReaderBind(IDataReader dataReader)
        {
            Nikita.Assist.DBManager.Model.Bse_ExcuteAnalyze model = new Nikita.Assist.DBManager.Model.Bse_ExcuteAnalyze();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = int.Parse(ojb.ToString());
            }
            model.ExcuteName = dataReader["ExcuteName"].ToString();
            model.ExcuteSql = dataReader["ExcuteSql"].ToString();
            model.ExcuteType = dataReader["ExcuteType"].ToString();
            model.DbType = dataReader["DbType"].ToString();
            model.Remark = dataReader["Remark"].ToString();
            ojb = dataReader["CreateDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreateDate = DateTime.Parse(ojb.ToString());
            }

            return model;
        }

        /// <summary>更新一条数据
        ///
        /// </summary>
        public bool Update(Nikita.Assist.DBManager.Model.Bse_ExcuteAnalyze model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Bse_ExcuteAnalyze set ");
            strSql.Append("ExcuteName=@ExcuteName, ExcuteSql=@ExcuteSql, ExcuteType=@ExcuteType, DbType=@DbType, Remark=@Remark, CreateDate=@CreateDate  ");
            strSql.Append(" where id=@id ");
            MSSQLHelper h = new MSSQLHelper(GlobalHelp.ConfigConn);
            h.CreateCommand(strSql.ToString());
            if (model.id == null)
            {
                h.AddParameter("@id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@id", model.id);
            }
            if (model.ExcuteName == null)
            {
                h.AddParameter("@ExcuteName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ExcuteName", model.ExcuteName);
            }
            if (model.ExcuteSql == null)
            {
                h.AddParameter("@ExcuteSql", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ExcuteSql", model.ExcuteSql);
            }
            if (model.ExcuteType == null)
            {
                h.AddParameter("@ExcuteType", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ExcuteType", model.ExcuteType);
            }
            if (model.DbType == null)
            {
                h.AddParameter("@DbType", DBNull.Value);
            }
            else
            {
                h.AddParameter("@DbType", model.DbType);
            }
            if (model.Remark == null)
            {
                h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Remark", model.Remark);
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
    }
}