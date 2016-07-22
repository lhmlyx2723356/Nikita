using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nikita.Assist.DBManager.DAL
{
    /// <summary>Tb_SetOrdTable表数据访问类
    ///
    /// </summary>
    public partial class SetOrdTableDAL
    {
        public SetOrdTableDAL()
        { }

        /// <summary>增加一条数据
        ///
        /// </summary>
        public int Add(Nikita.Assist.DBManager.Model.SetOrdTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tb_SetOrdTable(");
            strSql.Append("SetOrdText, SetOrdKey, State, Remark, AllowWorkType )");
            strSql.Append(" values (");
            strSql.Append("@SetOrdText, @SetOrdKey, @State, @Remark, @AllowWorkType )");
            SQLiteHelper h = new SQLiteHelper(GlobalHelp.SynchronizationDB);

            h.CreateCommand(strSql.ToString());
            if (model.SetOrdText == null)
            {
                h.AddParameter("@SetOrdText", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SetOrdText", model.SetOrdText);
            }
            if (model.SetOrdKey == null)
            {
                h.AddParameter("@SetOrdKey", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SetOrdKey", model.SetOrdKey);
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
            if (model.AllowWorkType == null)
            {
                h.AddParameter("@AllowWorkType", DBNull.Value);
            }
            else
            {
                h.AddParameter("@AllowWorkType", model.AllowWorkType);
            }

            h.ExecuteNonQuery();
            string sql2 = "select max(id) from Tb_SetOrdTable";
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
            string sql = "select count(1) from Tb_SetOrdTable";
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
            strSql.Append("delete from Tb_SetOrdTable ");
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
            strSql.Append("delete from Tb_SetOrdTable ");
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
            strSql.Append(" FROM Tb_SetOrdTable  ");
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
            strSql.Append(" FROM Tb_SetOrdTable  ");
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
            DataTable dt = h.FengYe("Tb_SetOrdTable", fileds, order, ordertype, strWhere, PageSize, PageIndex);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得数据列表（比DataSet效率高，推荐使用）
        ///
        /// </summary>
        public List<Nikita.Assist.DBManager.Model.SetOrdTable> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Tb_SetOrdTable ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Nikita.Assist.DBManager.Model.SetOrdTable> list = new List<Nikita.Assist.DBManager.Model.SetOrdTable>();
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
        public List<Nikita.Assist.DBManager.Model.SetOrdTable> GetListArray(string fileds, string order, string ordertype, int PageSize, int PageIndex, string strWhere)
        {
            SQLiteHelper h = new SQLiteHelper(GlobalHelp.SynchronizationDB);
            DataTable dt = h.FengYe("Tb_SetOrdTable", fileds, order, ordertype, strWhere, PageSize, PageIndex);
            List<Nikita.Assist.DBManager.Model.SetOrdTable> list = new List<Nikita.Assist.DBManager.Model.SetOrdTable>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Model.SetOrdTable()
                {
                    id = int.Parse(row["id"].ToString()),
                    SetOrdText = row["SetOrdText"].ToString(),
                    SetOrdKey = row["SetOrdKey"].ToString(),
                    State = int.Parse(row["State"].ToString()),
                    Remark = row["Remark"].ToString(),
                    AllowWorkType = row["AllowWorkType"].ToString(),
                });
            }
            return list;
        }

        /// <summary>获得数据列表
        ///
        /// </summary>
        public DataSet GetListForChangLiang(string strWhere, string Filds)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + Filds + " ");
            strSql.Append("        from Tb_SetTable a inner join Tb_SetOrdTable b on a.SetKey=b.id where b.state=1 and a.ChangLiang <>''  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            SQLiteHelper h = new SQLiteHelper(GlobalHelp.SynchronizationDB);
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>得到一个对象实体
        ///
        /// </summary>
        public Nikita.Assist.DBManager.Model.SetOrdTable GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Tb_SetOrdTable ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper(GlobalHelp.SynchronizationDB);
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", id);
            Nikita.Assist.DBManager.Model.SetOrdTable model = null;
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
        public Nikita.Assist.DBManager.Model.SetOrdTable GetModelByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Tb_SetOrdTable ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            strSql.Append(" limit 1");
            SQLiteHelper h = new SQLiteHelper(GlobalHelp.SynchronizationDB);
            h.CreateCommand(strSql.ToString());
            Nikita.Assist.DBManager.Model.SetOrdTable model = null;
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
        public Nikita.Assist.DBManager.Model.SetOrdTable ReaderBind(IDataReader dataReader)
        {
            Nikita.Assist.DBManager.Model.SetOrdTable model = new Nikita.Assist.DBManager.Model.SetOrdTable();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = int.Parse(ojb.ToString());
            }
            model.SetOrdText = dataReader["SetOrdText"].ToString();
            model.SetOrdKey = dataReader["SetOrdKey"].ToString();
            ojb = dataReader["State"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.State = int.Parse(ojb.ToString());
            }
            model.Remark = dataReader["Remark"].ToString();
            model.AllowWorkType = dataReader["AllowWorkType"].ToString();

            return model;
        }

        /// <summary>更新一条数据
        ///
        /// </summary>
        public bool Update(Nikita.Assist.DBManager.Model.SetOrdTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tb_SetOrdTable set ");
            strSql.Append("SetOrdText=@SetOrdText, SetOrdKey=@SetOrdKey, State=@State, Remark=@Remark, AllowWorkType=@AllowWorkType  ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper(GlobalHelp.SynchronizationDB);
            h.CreateCommand(strSql.ToString());
            if (model.SetOrdText == null)
            {
                h.AddParameter("@SetOrdText", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SetOrdText", model.SetOrdText);
            }
            if (model.SetOrdKey == null)
            {
                h.AddParameter("@SetOrdKey", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SetOrdKey", model.SetOrdKey);
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
            if (model.AllowWorkType == null)
            {
                h.AddParameter("@AllowWorkType", DBNull.Value);
            }
            else
            {
                h.AddParameter("@AllowWorkType", model.AllowWorkType);
            }
            h.AddParameter("@id", model.id);

            return h.ExecuteNonQuery();
        }
    }
}