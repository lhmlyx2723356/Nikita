using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FrmEmailSend.DAL
{
    /// <summary>EmailList表数据访问类
    /// </summary>
    public class EmailListDAL
    {
        /// <summary>增加一条数据
        ///
        /// </summary>
        public int Add(Model.EmailList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into EmailList(");
            strSql.Append("EmailAddress, CreateDate, Remark )");
            strSql.Append(" values (");
            strSql.Append("@EmailAddress, @CreateDate, @Remark )");
            SQLiteHelper h = new SQLiteHelper();

            h.CreateCommand(strSql.ToString());
            if (model.EmailAddress == null)
            {
                h.AddParameter("@EmailAddress", DBNull.Value);
            }
            else
            {
                h.AddParameter("@EmailAddress", model.EmailAddress);
            }
            if (model.CreateDate == null)
            {
                h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateDate", model.CreateDate);
            }
            if (model.Remark == null)
            {
                h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Remark", model.Remark);
            }

            h.ExecuteNonQuery();
            const string sql2 = "select max(id) from EmailList";
            h.CreateCommand(sql2);
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
        /// <param name="cond"></param>
        /// <returns></returns>
        public int CalcCount(string cond)
        {
            string sql = "select count(1) from EmailList";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(sql);
            return int.Parse(h.ExecuteScalar());
        }

        /// <summary>删除一条数据
        ///
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from EmailList ");
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
            strSql.Append("delete from EmailList ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            SQLiteHelper h = new SQLiteHelper();
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
            strSql.Append(" FROM EmailList  ");
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
        public DataSet GetList(string strWhere, string strFileds)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + strFileds + " ");
            strSql.Append(" FROM EmailList  ");
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
        public DataSet GetList(string fileds, string order, string ordertype, int intPageSize, int intPageIndex, string strWhere)
        {
            SQLiteHelper h = new SQLiteHelper();
            DataTable dt = h.FengYe("EmailList", fileds, order, ordertype, strWhere, intPageSize, intPageIndex);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得数据列表（比DataSet效率高，推荐使用）
        ///
        /// </summary>
        public List<Model.EmailList> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM EmailList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Model.EmailList> list = new List<Model.EmailList>();
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
        public List<Model.EmailList> GetListArray(string fileds, string order, string ordertype, int intPageSize, int intPageIndex, string strWhere)
        {
            SQLiteHelper h = new SQLiteHelper();
            DataTable dt = h.FengYe("EmailList", fileds, order, ordertype, strWhere, intPageSize, intPageIndex);
            return (from DataRow row in dt.Rows
                    select new Model.EmailList()
                    {
                        Id = int.Parse(row["id"].ToString()),
                        EmailAddress = row["EmailAddress"].ToString(),
                        CreateDate = row["CreateDate"].ToString(),
                        Remark = row["Remark"].ToString(),
                    }).ToList();
        }

        /// <summary>得到一个对象实体
        ///
        /// </summary>
        public Model.EmailList GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from EmailList ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", id);
            Model.EmailList model = null;
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
        public Model.EmailList GetModelByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from EmailList ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            strSql.Append(" limit 1");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            Model.EmailList model = null;
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
        public Model.EmailList ReaderBind(IDataReader dataReader)
        {
            Model.EmailList model = new Model.EmailList();
            var ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Id = int.Parse(ojb.ToString());
            }
            model.EmailAddress = dataReader["EmailAddress"].ToString();
            model.CreateDate = dataReader["CreateDate"].ToString();
            model.Remark = dataReader["Remark"].ToString();

            return model;
        }

        /// <summary>更新一条数据
        ///
        /// </summary>
        public bool Update(Model.EmailList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update EmailList set ");
            strSql.Append("EmailAddress=@EmailAddress, CreateDate=@CreateDate, Remark=@Remark  ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            if (model.EmailAddress == null)
            {
                h.AddParameter("@EmailAddress", DBNull.Value);
            }
            else
            {
                h.AddParameter("@EmailAddress", model.EmailAddress);
            }
            if (model.CreateDate == null)
            {
                h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateDate", model.CreateDate);
            }
            if (model.Remark == null)
            {
                h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Remark", model.Remark);
            }
            h.AddParameter("@id", model.Id);

            return h.ExecuteNonQuery();
        }
    }
}