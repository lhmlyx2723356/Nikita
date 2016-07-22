using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FrmEmailSend.DAL
{
    /// <summary>EmailSendLog表数据访问类
    /// </summary>
    public class EmailSendLogDAL
    {
        /// <summary>增加一条数据
        ///
        /// </summary>
        public int Add(Model.EmailSendLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into EmailSendLog(");
            strSql.Append("EmailSubject, EmailToAddress, EmailFromAddress, CreateDate, IsSuccess, Remark )");
            strSql.Append(" values (");
            strSql.Append("@EmailSubject, @EmailToAddress, @EmailFromAddress, @CreateDate, @IsSuccess, @Remark )");
            SQLiteHelper h = new SQLiteHelper();

            h.CreateCommand(strSql.ToString());
            if (model.EmailSubject == null)
            {
                h.AddParameter("@EmailSubject", DBNull.Value);
            }
            else
            {
                h.AddParameter("@EmailSubject", model.EmailSubject);
            }
            if (model.EmailToAddress == null)
            {
                h.AddParameter("@EmailToAddress", DBNull.Value);
            }
            else
            {
                h.AddParameter("@EmailToAddress", model.EmailToAddress);
            }
            if (model.EmailFromAddress == null)
            {
                h.AddParameter("@EmailFromAddress", DBNull.Value);
            }
            else
            {
                h.AddParameter("@EmailFromAddress", model.EmailFromAddress);
            }
            if (model.CreateDate == null)
            {
                h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateDate", model.CreateDate);
            }
            if (model.IsSuccess == null)
            {
                h.AddParameter("@IsSuccess", DBNull.Value);
            }
            else
            {
                h.AddParameter("@IsSuccess", model.IsSuccess);
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
            const string sql2 = "select max(id) from EmailSendLog";
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
            string sql = "select count(1) from EmailSendLog";
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
            strSql.Append("delete from EmailSendLog ");
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
            strSql.Append("delete from EmailSendLog ");
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
            strSql.Append(" FROM EmailSendLog  ");
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
        public DataSet GetList(string strWhere, string strFilds)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + strFilds + " ");
            strSql.Append(" FROM EmailSendLog  ");
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
            DataTable dt = h.FengYe("EmailSendLog", fileds, order, ordertype, strWhere, intPageSize, intPageIndex);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得数据列表（比DataSet效率高，推荐使用）
        ///
        /// </summary>
        public List<Model.EmailSendLog> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM EmailSendLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Model.EmailSendLog> list = new List<Model.EmailSendLog>();
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
        public List<Model.EmailSendLog> GetListArray(string fileds, string order, string ordertype, int intPageSize, int intPageIndex, string strWhere)
        {
            SQLiteHelper h = new SQLiteHelper();
            DataTable dt = h.FengYe("EmailSendLog", fileds, order, ordertype, strWhere, intPageSize, intPageIndex);
            return (from DataRow row in dt.Rows
                    select new Model.EmailSendLog()
                    {
                        Id = int.Parse(row["id"].ToString()),
                        EmailSubject = row["EmailSubject"].ToString(),
                        EmailToAddress = row["EmailToAddress"].ToString(),
                        EmailFromAddress = row["EmailFromAddress"].ToString(),
                        CreateDate = row["CreateDate"].ToString(),
                        IsSuccess = row["IsSuccess"].ToString(),
                        Remark = row["Remark"].ToString(),
                    }).ToList();
        }

        /// <summary>得到一个对象实体
        ///
        /// </summary>
        public Model.EmailSendLog GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from EmailSendLog ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", id);
            Model.EmailSendLog model = null;
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
        public Model.EmailSendLog GetModelByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from EmailSendLog ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            strSql.Append(" limit 1");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            Model.EmailSendLog model = null;
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
        public Model.EmailSendLog ReaderBind(IDataReader dataReader)
        {
            Model.EmailSendLog model = new Model.EmailSendLog();
            var ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Id = int.Parse(ojb.ToString());
            }
            model.EmailSubject = dataReader["EmailSubject"].ToString();
            model.EmailToAddress = dataReader["EmailToAddress"].ToString();
            model.EmailFromAddress = dataReader["EmailFromAddress"].ToString();
            model.CreateDate = dataReader["CreateDate"].ToString();
            model.IsSuccess = dataReader["IsSuccess"].ToString();
            model.Remark = dataReader["Remark"].ToString();

            return model;
        }

        /// <summary>更新一条数据
        ///
        /// </summary>
        public bool Update(Model.EmailSendLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update EmailSendLog set ");
            strSql.Append("EmailSubject=@EmailSubject, EmailToAddress=@EmailToAddress, EmailFromAddress=@EmailFromAddress, CreateDate=@CreateDate, IsSuccess=@IsSuccess, Remark=@Remark  ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            if (model.EmailSubject == null)
            {
                h.AddParameter("@EmailSubject", DBNull.Value);
            }
            else
            {
                h.AddParameter("@EmailSubject", model.EmailSubject);
            }
            if (model.EmailToAddress == null)
            {
                h.AddParameter("@EmailToAddress", DBNull.Value);
            }
            else
            {
                h.AddParameter("@EmailToAddress", model.EmailToAddress);
            }
            if (model.EmailFromAddress == null)
            {
                h.AddParameter("@EmailFromAddress", DBNull.Value);
            }
            else
            {
                h.AddParameter("@EmailFromAddress", model.EmailFromAddress);
            }
            if (model.CreateDate == null)
            {
                h.AddParameter("@CreateDate", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateDate", model.CreateDate);
            }
            if (model.IsSuccess == null)
            {
                h.AddParameter("@IsSuccess", DBNull.Value);
            }
            else
            {
                h.AddParameter("@IsSuccess", model.IsSuccess);
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