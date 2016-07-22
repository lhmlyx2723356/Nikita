using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nikita.Core.Sample.DAL
{
    /// <summary>T_Sample_Menu表数据访问类
    /// 作者:UsTeam(QQ:871939149、944527357、363458293)
    /// 创建时间:2015-06-06 14:48:22
    /// </summary>
    public partial class T_Sample_MenuDAL
    {
        public T_Sample_MenuDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(Model.T_Sample_Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Sample_Menu(");
            strSql.Append("ParentId, MenuClass, MenuName, MenuIcon, State, Remark, Fileld1, Field2, Field3, Field4, Field5 )");
            strSql.Append(" values (");
            strSql.Append("@ParentId, @MenuClass, @MenuName, @MenuIcon, @State, @Remark, @Fileld1, @Field2, @Field3, @Field4, @Field5 )");
            SQLiteHelper h = new SQLiteHelper();

            h.CreateCommand(strSql.ToString());
            if (model.ParentId == null)
            {
                 h.AddParameter("@ParentId", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ParentId", model.ParentId);
            }
if (model.MenuClass == null)
            {
                 h.AddParameter("@MenuClass", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@MenuClass", model.MenuClass);
            }
if (model.MenuName == null)
            {
                 h.AddParameter("@MenuName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@MenuName", model.MenuName);
            }
if (model.MenuIcon == null)
            {
                 h.AddParameter("@MenuIcon", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@MenuIcon", model.MenuIcon);
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
if (model.Fileld1 == null)
            {
                 h.AddParameter("@Fileld1", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Fileld1", model.Fileld1);
            }
if (model.Field2 == null)
            {
                 h.AddParameter("@Field2", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Field2", model.Field2);
            }
if (model.Field3 == null)
            {
                 h.AddParameter("@Field3", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Field3", model.Field3);
            }
if (model.Field4 == null)
            {
                 h.AddParameter("@Field4", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Field4", model.Field4);
            }
if (model.Field5 == null)
            {
                 h.AddParameter("@Field5", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Field5", model.Field5);
            }


            h.ExecuteNonQuery();
            string sql2 = "select max(id) from T_Sample_Menu";
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
        public bool Update(Model.T_Sample_Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Sample_Menu set ");
            strSql.Append("ParentId=@ParentId, MenuClass=@MenuClass, MenuName=@MenuName, MenuIcon=@MenuIcon, State=@State, Remark=@Remark, Fileld1=@Fileld1, Field2=@Field2, Field3=@Field3, Field4=@Field4, Field5=@Field5  ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
                        if (model.ParentId == null)
            {
                 h.AddParameter("@ParentId", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@ParentId", model.ParentId);
            }
            if (model.MenuClass == null)
            {
                 h.AddParameter("@MenuClass", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@MenuClass", model.MenuClass);
            }
            if (model.MenuName == null)
            {
                 h.AddParameter("@MenuName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@MenuName", model.MenuName);
            }
            if (model.MenuIcon == null)
            {
                 h.AddParameter("@MenuIcon", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@MenuIcon", model.MenuIcon);
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
            if (model.Fileld1 == null)
            {
                 h.AddParameter("@Fileld1", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Fileld1", model.Fileld1);
            }
            if (model.Field2 == null)
            {
                 h.AddParameter("@Field2", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Field2", model.Field2);
            }
            if (model.Field3 == null)
            {
                 h.AddParameter("@Field3", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Field3", model.Field3);
            }
            if (model.Field4 == null)
            {
                 h.AddParameter("@Field4", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Field4", model.Field4);
            }
            if (model.Field5 == null)
            {
                 h.AddParameter("@Field5", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Field5", model.Field5);
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
            strSql.Append("delete from T_Sample_Menu ");
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
            strSql.Append("delete from T_Sample_Menu ");
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
        public Model.T_Sample_Menu GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_Sample_Menu ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", id);
            Model.T_Sample_Menu model = null;
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
        public Model.T_Sample_Menu GetModelByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_Sample_Menu ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            strSql.Append(" limit 1");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            Model.T_Sample_Menu model = null;
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
            strSql.Append(" FROM T_Sample_Menu  ");
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
            strSql.Append(" FROM T_Sample_Menu  ");
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
            DataTable dt = h.FengYe("T_Sample_Menu", fileds, order, ordertype, strWhere, PageSize, PageIndex);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得数据列表（比DataSet效率高，推荐使用）
        /// 
        /// </summary>
        public List<Model.T_Sample_Menu> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM T_Sample_Menu ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Model.T_Sample_Menu> list = new List<Model.T_Sample_Menu>();
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
        public List<Model.T_Sample_Menu> GetListArray(string fileds, string order, string ordertype, int PageSize, int PageIndex, string strWhere)
        {
            SQLiteHelper h = new SQLiteHelper();
            DataTable dt = h.FengYe("T_Sample_Menu", fileds, order, ordertype, strWhere, PageSize, PageIndex);
            List<Model.T_Sample_Menu> list = new List<Model.T_Sample_Menu>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Model.T_Sample_Menu()
                {
                    id = int.Parse(row["id"].ToString()),ParentId = int.Parse(row["ParentId"].ToString()),MenuClass = row["MenuClass"].ToString(),MenuName = row["MenuName"].ToString(),MenuIcon = row["MenuIcon"].ToString(),State = int.Parse(row["State"].ToString()),Remark = row["Remark"].ToString(),Fileld1 = row["Fileld1"].ToString(),Field2 = row["Field2"].ToString(),Field3 = row["Field3"].ToString(),Field4 = row["Field4"].ToString(),Field5 = row["Field5"].ToString(),
                });
            }
            return list;
        }

        /// <summary>对象实体绑定数据
        /// 
        /// </summary>
        public Model.T_Sample_Menu ReaderBind(IDataReader dataReader)
        {
            Model.T_Sample_Menu model = new Model.T_Sample_Menu();
            object ojb;
                        ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = int.Parse(ojb.ToString());
            }
            ojb = dataReader["ParentId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ParentId = int.Parse(ojb.ToString());
            }
            model.MenuClass = dataReader["MenuClass"].ToString();
            model.MenuName = dataReader["MenuName"].ToString();
            model.MenuIcon = dataReader["MenuIcon"].ToString();
            ojb = dataReader["State"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.State = int.Parse(ojb.ToString());
            }
            model.Remark = dataReader["Remark"].ToString();
            model.Fileld1 = dataReader["Fileld1"].ToString();
            model.Field2 = dataReader["Field2"].ToString();
            model.Field3 = dataReader["Field3"].ToString();
            model.Field4 = dataReader["Field4"].ToString();
            model.Field5 = dataReader["Field5"].ToString();

            return model;
        }

        /// <summary>计算记录数
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int CalcCount(string cond)
        {
            string sql = "select count(1) from T_Sample_Menu";
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

