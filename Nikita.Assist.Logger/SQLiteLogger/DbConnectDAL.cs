using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nikita.Assist.Logger.DAL
{
    /// <summary>DbConnect表数据访问类
    /// 作者:UsTeam(QQ:871939149、944527357、363458293)
    /// 创建时间:2015-08-18 20:46:04
    /// </summary>
    public partial class DbConnectDAL
    {
        public DbConnectDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(Nikita.Assist.Logger.Model.DbConnect model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DbConnect(");
            strSql.Append("IP, User, Pwd, CreateDate, Remark  )");
            strSql.Append(" values (");
            strSql.Append("@IP, @User, @Pwd, @CreateDate, @Remark  )");
            SQLiteHelper h = new SQLiteHelper();

            h.CreateCommand(strSql.ToString());
            if (model.IP == null)
            {
                 h.AddParameter("@IP", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@IP", model.IP);
            }
if (model.User == null)
            {
                 h.AddParameter("@User", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@User", model.User);
            }
if (model.Pwd == null)
            {
                 h.AddParameter("@Pwd", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Pwd", model.Pwd);
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
            string sql2 = "select max(id) from DbConnect";
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
        public bool Update(Nikita.Assist.Logger.Model.DbConnect model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DbConnect set ");
            strSql.Append("IP=@IP, User=@User, Pwd=@Pwd, CreateDate=@CreateDate, Remark=@Remark   ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
                        if (model.IP == null)
            {
                 h.AddParameter("@IP", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@IP", model.IP);
            }
            if (model.User == null)
            {
                 h.AddParameter("@User", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@User", model.User);
            }
            if (model.Pwd == null)
            {
                 h.AddParameter("@Pwd", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Pwd", model.Pwd);
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
           
            h.AddParameter("@id", model.id);

            return h.ExecuteNonQuery();
        }

        /// <summary>删除一条数据
        /// 
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DbConnect ");
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
            strSql.Append("delete from DbConnect ");
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
        public Nikita.Assist.Logger.Model.DbConnect GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from DbConnect ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", id);
            Nikita.Assist.Logger.Model.DbConnect model = null;
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
        public Nikita.Assist.Logger.Model.DbConnect GetModelByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from DbConnect ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            strSql.Append(" limit 1");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            Nikita.Assist.Logger.Model.DbConnect model = null;
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
            strSql.Append(" FROM DbConnect  ");
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
            strSql.Append(" FROM DbConnect  ");
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
            DataTable dt = h.FengYe("DbConnect", fileds, order, ordertype, strWhere, PageSize, PageIndex);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得数据列表（比DataSet效率高，推荐使用）
        /// 
        /// </summary>
        public List<Nikita.Assist.Logger.Model.DbConnect> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM DbConnect ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Nikita.Assist.Logger.Model.DbConnect> list = new List<Nikita.Assist.Logger.Model.DbConnect>();
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
        public List<Nikita.Assist.Logger.Model.DbConnect> GetListArray(string fileds, string order, string ordertype, int PageSize, int PageIndex, string strWhere)
        {
            SQLiteHelper h = new SQLiteHelper();
            DataTable dt = h.FengYe("DbConnect", fileds, order, ordertype, strWhere, PageSize, PageIndex);
            List<Nikita.Assist.Logger.Model.DbConnect> list = new List<Nikita.Assist.Logger.Model.DbConnect>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Model.DbConnect()
                {
                    id = int.Parse(row["id"].ToString()),IP = row["IP"].ToString(),User = row["User"].ToString(),Pwd = row["Pwd"].ToString(),CreateDate = row["CreateDate"].ToString(),Remark = row["Remark"].ToString() 
                });
            }
            return list;
        }

        /// <summary>对象实体绑定数据
        /// 
        /// </summary>
        public Nikita.Assist.Logger.Model.DbConnect ReaderBind(IDataReader dataReader)
        {
            Nikita.Assist.Logger.Model.DbConnect model = new Nikita.Assist.Logger.Model.DbConnect();
            object ojb;
                        ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = int.Parse(ojb.ToString());
            }
            model.IP = dataReader["IP"].ToString();
            model.User = dataReader["User"].ToString();
            model.Pwd = dataReader["Pwd"].ToString();
            model.CreateDate = dataReader["CreateDate"].ToString();
            model.Remark = dataReader["Remark"].ToString(); 

            return model;
        }

        /// <summary>计算记录数
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int CalcCount(string cond)
        {
            string sql = "select count(1) from DbConnect";
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

