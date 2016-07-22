using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Nikita.DataAccess4DBHelper;

namespace Nikita.Assist.CodeMaker.DAL
{
    /// <summary>Tb_Set表数据访问类
    /// </summary>
    public class SetDal
    {
        /// <summary>增加一条数据
        ///
        /// </summary>
        public int Add(Model.Set model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tb_Set(");
            strSql.Append("SetKey, SetText, SetValue, State, Remark )");
            strSql.Append(" values (");
            strSql.Append("@SetKey, @SetText, @SetValue, @State, @Remark )");
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();

            h.CreateCommand(strSql.ToString());
            if (model.SetKey == null)
            {
                h.AddParameter("@SetKey", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SetKey", model.SetKey);
            }
            if (model.SetText == null)
            {
                h.AddParameter("@SetText", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SetText", model.SetText);
            }
            if (model.SetValue == null)
            {
                h.AddParameter("@SetValue", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SetValue", model.SetValue);
            }
            h.AddParameter("@State", model.State);
            if (model.Remark == null)
            {
                h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Remark", model.Remark);
            }

            h.ExecuteNonQuery();
            const string strSql2 = "select max(id) from Tb_Set";
            h.CreateCommand(strSql2);
            int result;
            string obj = h.ExecuteScalar();
            if (!int.TryParse(obj, out result))
            {
                return 0;
            }
            return result;
        }

        ///  <summary>计算记录数
        ///
        ///  </summary>
        /// <returns></returns>
        public int CalcCount(string cond)
        {
            string sql = "select count(1) from Tb_Set";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            h.CreateCommand(sql);
            return int.Parse(h.ExecuteScalar());
        }

        /// <summary>删除一条数据
        ///
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tb_Set ");
            strSql.Append(" where id=@id ");
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
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
            strSql.Append("delete from Tb_Set ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
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
            strSql.Append(" FROM Tb_Set  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得数据列表
        ///
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="strFilds"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere, string strFilds)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + strFilds + " ");
            strSql.Append(" FROM Tb_Set  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
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
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            DataTable dt = h.FengYe("Tb_Set", fileds, order, ordertype, strWhere, intPageSize, intPageIndex);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得数据列表（比DataSet效率高，推荐使用）
        ///
        /// </summary>
        public List<Model.Set> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Tb_Set ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Model.Set> list = new List<Model.Set>();
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
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
        public List<Model.Set> GetListArray(string fileds, string order, string ordertype, int intPageSize, int intPageIndex, string strWhere)
        {
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            DataTable dt = h.FengYe("Tb_Set", fileds, order, ordertype, strWhere, intPageSize, intPageIndex);
            return (from DataRow row in dt.Rows
                    select new Model.Set()
                    {
                        Id = int.Parse(row["id"].ToString()),
                        SetKey = row["SetKey"].ToString(),
                        SetText = row["SetText"].ToString(),
                        SetValue = row["SetValue"].ToString(),
                        State = int.Parse(row["State"].ToString()),
                        Remark = row["Remark"].ToString(),
                    }).ToList();
        }

        /// <summary>得到一个对象实体
        ///
        /// </summary>
        public Model.Set GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Tb_Set ");
            strSql.Append(" where id=@id ");
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", id);
            Model.Set model = null;
            using (IDataReader dataReader = h.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            h.CloseConn();
            return model;
        }

        /// <summary>根据条件得到一个对象实体
        ///
        /// </summary>
        public Model.Set GetModelByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Tb_Set ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            strSql.Append(" limit 1");
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            h.CreateCommand(strSql.ToString());
            Model.Set model = null;
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
        public Model.Set ReaderBind(IDataReader dataReader)
        {
            Model.Set model = new Model.Set();
            var ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Id = int.Parse(ojb.ToString());
            }
            model.SetKey = dataReader["SetKey"].ToString();
            model.SetText = dataReader["SetText"].ToString();
            model.SetValue = dataReader["SetValue"].ToString();
            ojb = dataReader["State"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.State = int.Parse(ojb.ToString());
            }
            model.Remark = dataReader["Remark"].ToString();

            return model;
        }

        /// <summary>更新一条数据
        ///
        /// </summary>
        public bool Update(Model.Set model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tb_Set set ");
            strSql.Append("SetKey=@SetKey, SetText=@SetText, SetValue=@SetValue, State=@State, Remark=@Remark  ");
            strSql.Append(" where id=@id ");
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            h.CreateCommand(strSql.ToString());
            if (model.SetKey == null)
            {
                h.AddParameter("@SetKey", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SetKey", model.SetKey);
            }
            if (model.SetText == null)
            {
                h.AddParameter("@SetText", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SetText", model.SetText);
            }
            if (model.SetValue == null)
            {
                h.AddParameter("@SetValue", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SetValue", model.SetValue);
            }
            h.AddParameter("@State", model.State);
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