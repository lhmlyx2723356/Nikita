using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nikita.Assist.DBManager.DAL
{
    /// <summary>Tb_SetTable表数据访问类
    ///
    /// </summary>
    public partial class SetTableDAL
    {
        public SetTableDAL()
        { }

        /// <summary>增加一条数据
        ///
        /// </summary>
        public int Add(Nikita.Assist.DBManager.Model.SetTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tb_SetTable(");
            strSql.Append("SetKey, SetText, SetValue, State, Remark, ChangLiang )");
            strSql.Append(" values (");
            strSql.Append("@SetKey, @SetText, @SetValue, @State, @Remark,@ChangLiang )");
            SQLiteHelper h = new SQLiteHelper(GlobalHelp.SynchronizationDB);

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
            if (model.State == null)
            {
                h.AddParameter("@State", DBNull.Value);
            }
            else
            {
                h.AddParameter("@State", model.State);
            }
            if (model.Remark == null)
            {
                h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Remark", model.Remark);
            }
            if (model.ChangLiang == null)
            {
                h.AddParameter("@ChangLiang", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ChangLiang", model.ChangLiang);
            }

            h.ExecuteNonQuery();
            string sql2 = "select max(id) from Tb_SetTable";
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
        /// <param name="p"></param>
        /// <returns></returns>
        public int CalcCount(string cond)
        {
            string sql = "select count(1) from Tb_SetTable";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
            SQLiteHelper h = new SQLiteHelper(GlobalHelp.SynchronizationDB);
            h.CreateCommand(sql);
            return int.Parse(h.ExecuteScalar());
        }

        /// <summary>删除一条数据
        ///
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tb_SetTable ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper(GlobalHelp.SynchronizationDB);
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
            strSql.Append("delete from Tb_SetTable ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            SQLiteHelper h = new SQLiteHelper(GlobalHelp.SynchronizationDB);
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
            strSql.Append(" FROM Tb_SetTable  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            SQLiteHelper h = new SQLiteHelper(GlobalHelp.SynchronizationDB);
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
            strSql.Append(" FROM Tb_SetTable  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            SQLiteHelper h = new SQLiteHelper(GlobalHelp.SynchronizationDB);
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
            SQLiteHelper h = new SQLiteHelper(GlobalHelp.SynchronizationDB);
            DataTable dt = h.FengYe("Tb_SetTable", fileds, order, ordertype, strWhere, PageSize, PageIndex);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得数据列表（比DataSet效率高，推荐使用）
        ///
        /// </summary>
        public List<Nikita.Assist.DBManager.Model.SetTable> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Tb_SetTable ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Nikita.Assist.DBManager.Model.SetTable> list = new List<Nikita.Assist.DBManager.Model.SetTable>();
            SQLiteHelper h = new SQLiteHelper(GlobalHelp.SynchronizationDB);
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
        public List<Nikita.Assist.DBManager.Model.SetTable> GetListArray(string fileds, string order, string ordertype, int PageSize, int PageIndex, string strWhere)
        {
            SQLiteHelper h = new SQLiteHelper(GlobalHelp.SynchronizationDB);
            DataTable dt = h.FengYe("Tb_SetTable", fileds, order, ordertype, strWhere, PageSize, PageIndex);
            List<Nikita.Assist.DBManager.Model.SetTable> list = new List<Nikita.Assist.DBManager.Model.SetTable>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Model.SetTable()
                {
                    id = int.Parse(row["id"].ToString()),
                    SetKey = row["SetKey"].ToString(),
                    SetText = row["SetText"].ToString(),
                    SetValue = row["SetValue"].ToString(),
                    State = int.Parse(row["State"].ToString()),
                    Remark = row["Remark"].ToString(),
                    ChangLiang = row["ChangLiang"].ToString()
                });
            }
            return list;
        }

        /// <summary>得到一个对象实体
        ///
        /// </summary>
        public Nikita.Assist.DBManager.Model.SetTable GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Tb_SetTable ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper(GlobalHelp.SynchronizationDB);
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", id);
            Nikita.Assist.DBManager.Model.SetTable model = null;
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
        public Nikita.Assist.DBManager.Model.SetTable GetModelByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Tb_SetTable ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            strSql.Append(" limit 1");
            SQLiteHelper h = new SQLiteHelper(GlobalHelp.SynchronizationDB);
            h.CreateCommand(strSql.ToString());
            Nikita.Assist.DBManager.Model.SetTable model = null;
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
        public Nikita.Assist.DBManager.Model.SetTable ReaderBind(IDataReader dataReader)
        {
            Nikita.Assist.DBManager.Model.SetTable model = new Nikita.Assist.DBManager.Model.SetTable();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = int.Parse(ojb.ToString());
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
            model.ChangLiang = dataReader["ChangLiang"].ToString();

            return model;
        }

        /// <summary>更新一条数据
        ///
        /// </summary>
        public bool Update(Nikita.Assist.DBManager.Model.SetTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tb_SetTable set ");
            strSql.Append("SetKey=@SetKey, SetText=@SetText, SetValue=@SetValue, State=@State, Remark=@Remark,ChangLiang=@ChangLiang  ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper(GlobalHelp.SynchronizationDB);
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
            if (model.State == null)
            {
                h.AddParameter("@State", DBNull.Value);
            }
            else
            {
                h.AddParameter("@State", model.State);
            }
            if (model.Remark == null)
            {
                h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Remark", model.Remark);
            }

            if (model.ChangLiang == null)
            {
                h.AddParameter("@ChangLiang", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ChangLiang", model.ChangLiang);
            }
            h.AddParameter("@id", model.id);

            return h.ExecuteNonQuery();
        }
    }
}