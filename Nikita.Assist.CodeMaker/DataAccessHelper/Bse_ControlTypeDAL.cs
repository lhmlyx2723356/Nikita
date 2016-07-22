using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nikita.DataAccess4DBHelper;

namespace Nikita.Assist.CodeMaker.DAL
{
    /// <summary>Bse_ControlType表数据访问类
    /// 作者:Luhm
    /// 创建时间:2016-02-04 12:04:21
    /// </summary>
    public partial class Bse_ControlTypeDAL
    {
        public Bse_ControlTypeDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        /// <param name="model">实体对象</param> 
        /// <returns>返回新增实体ID</returns>
        public int Add(Nikita.Assist.CodeMaker.Model.Bse_ControlType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Bse_ControlType(");
            strSql.Append(" ControlType, Ctl_Simple, Ctl_Name, Ctl_NameSpace, Ctl_Width, Ctl_Height, Ctl_Type, State, Sort, Type, IsSelf )");
            strSql.Append(" values (");
            strSql.Append(" @ControlType, @Ctl_Simple, @Ctl_Name, @Ctl_NameSpace, @Ctl_Width, @Ctl_Height, @Ctl_Type, @State, @Sort, @Type, @IsSelf )");
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();

            h.CreateCommand(strSql.ToString());
            if (model.ControlType == null)
            {
                h.AddParameter("@ControlType", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ControlType", model.ControlType);
            }
            if (model.Ctl_Simple == null)
            {
                h.AddParameter("@Ctl_Simple", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Ctl_Simple", model.Ctl_Simple);
            }
            if (model.Ctl_Name == null)
            {
                h.AddParameter("@Ctl_Name", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Ctl_Name", model.Ctl_Name);
            }
            if (model.Ctl_NameSpace == null)
            {
                h.AddParameter("@Ctl_NameSpace", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Ctl_NameSpace", model.Ctl_NameSpace);
            }
            if (model.Ctl_Width == null)
            {
                h.AddParameter("@Ctl_Width", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Ctl_Width", model.Ctl_Width);
            }
            if (model.Ctl_Height == null)
            {
                h.AddParameter("@Ctl_Height", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Ctl_Height", model.Ctl_Height);
            }
            if (model.Ctl_Type == null)
            {
                h.AddParameter("@Ctl_Type", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Ctl_Type", model.Ctl_Type);
            }
            if (model.State == null)
            {
                h.AddParameter("@State", DBNull.Value);
            }
            else
            {
                h.AddParameter("@State", model.State);
            }
            if (model.Sort == null)
            {
                h.AddParameter("@Sort", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Sort", model.Sort);
            }
            if (model.Type == null)
            {
                h.AddParameter("@Type", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Type", model.Type);
            }
            if (model.IsSelf == null)
            {
                h.AddParameter("@IsSelf", DBNull.Value);
            }
            else
            {
                h.AddParameter("@IsSelf", model.IsSelf);
            }


            h.ExecuteNonQuery();
            string strSql2 = "select max(id) from Bse_ControlType";
            h.CreateCommand(strSql2);
            int intResult;
            string strObj = h.ExecuteScalar();
            if (!int.TryParse(strObj, out intResult))
            {
                return 0;
            }
            return intResult;
        }

        /// <summary>更新一条数据
        /// 
        /// </summary>
        /// <param name="model">实体对象</param> 
        /// <returns>返回受影响的行数</returns>
        public bool Update(Nikita.Assist.CodeMaker.Model.Bse_ControlType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Bse_ControlType set ");
            strSql.Append("  ControlType=@ControlType, Ctl_Simple=@Ctl_Simple, Ctl_Name=@Ctl_Name, Ctl_NameSpace=@Ctl_NameSpace, Ctl_Width=@Ctl_Width, Ctl_Height=@Ctl_Height, Ctl_Type=@Ctl_Type, State=@State, Sort=@Sort, Type=@Type, IsSelf=@IsSelf  ");
            strSql.Append(" where id=@id ");
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            h.CreateCommand(strSql.ToString());

            if (model.ControlType == null)
            {
                h.AddParameter("@ControlType", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ControlType", model.ControlType);
            }
            if (model.Ctl_Simple == null)
            {
                h.AddParameter("@Ctl_Simple", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Ctl_Simple", model.Ctl_Simple);
            }
            if (model.Ctl_Name == null)
            {
                h.AddParameter("@Ctl_Name", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Ctl_Name", model.Ctl_Name);
            }
            if (model.Ctl_NameSpace == null)
            {
                h.AddParameter("@Ctl_NameSpace", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Ctl_NameSpace", model.Ctl_NameSpace);
            }
            if (model.Ctl_Width == null)
            {
                h.AddParameter("@Ctl_Width", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Ctl_Width", model.Ctl_Width);
            }
            if (model.Ctl_Height == null)
            {
                h.AddParameter("@Ctl_Height", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Ctl_Height", model.Ctl_Height);
            }
            if (model.Ctl_Type == null)
            {
                h.AddParameter("@Ctl_Type", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Ctl_Type", model.Ctl_Type);
            }
            if (model.State == null)
            {
                h.AddParameter("@State", DBNull.Value);
            }
            else
            {
                h.AddParameter("@State", model.State);
            }
            if (model.Sort == null)
            {
                h.AddParameter("@Sort", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Sort", model.Sort);
            }
            if (model.Type == null)
            {
                h.AddParameter("@Type", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Type", model.Type);
            }
            if (model.IsSelf == null)
            {
                h.AddParameter("@IsSelf", DBNull.Value);
            }
            else
            {
                h.AddParameter("@IsSelf", model.IsSelf);
            }
            h.AddParameter("@id", model.Ctl_Id);

            return h.ExecuteNonQuery();
        }

        /// <summary>删除一条数据
        /// 
        /// </summary>
        /// <param name="intId">主键ID</param> 
        /// <returns>返回受影响的行数</returns>
        public bool Delete(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Bse_ControlType ");
            strSql.Append(" where Ctl_Id=@id ");
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", intId);
            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件删除数据
        /// 
        /// </summary>
        /// <param name="strCond">条件</param> 
        /// <returns>返回受影响的行数</returns>
        public bool DeleteByCond(string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Bse_ControlType ");
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond);
            }
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        /// <param name="intId">主键</param> 
        /// <returns>返回对象实体</returns>
        public Nikita.Assist.CodeMaker.Model.Bse_ControlType GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Bse_ControlType ");
            strSql.Append(" where Ctl_Id=@id ");
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", intId);
            Nikita.Assist.CodeMaker.Model.Bse_ControlType model = null;
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
        /// <param name="strCond">条件</param> 
        /// <returns>返回对象实体</returns>
        public Nikita.Assist.CodeMaker.Model.Bse_ControlType GetModelByCond(string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Bse_ControlType ");
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond);
            }
            strSql.Append(" limit 1");
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            h.CreateCommand(strSql.ToString());
            Nikita.Assist.CodeMaker.Model.Bse_ControlType model = null;
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
        /// <param name="strWhere">条件</param> 
        /// <returns>返回符合条件的DataSet数据集</returns>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Bse_ControlType  ");
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
        /// <param name="strWhere">条件</param> 
        /// <param name="strFields">字段</param> 
        /// <returns>返回符合条件的DataSet数据集</returns>
        public DataSet GetList(string strWhere, string strFields)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + strFields + " ");
            strSql.Append(" FROM Bse_ControlType  ");
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
        /// <param name="strFields">字段</param> 
        /// <param name="strOrder">排序</param> 
        /// <param name="strOrderType">排序类型</param> 
        /// <param name="intPageSize">每页大小</param> 
        /// <param name="intPageIndex">当前第N页</param> 
        /// <param name="strWhere">条件</param> 
        /// <returns>返回符合条件的DataSet数据集</returns>
        public DataSet GetList(string strFields, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere)
        {
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            DataTable dt = h.FengYe("Bse_ControlType", strFields, strOrder, strOrderType, strWhere, intPageSize, intPageIndex);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得数据列表（比DataSet效率高，推荐使用）
        /// 
        /// </summary>
        /// <param name="strWhere">条件</param> 
        /// <returns>返回符合条件的对象集合</returns>
        public List<Nikita.Assist.CodeMaker.Model.Bse_ControlType> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Bse_ControlType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Nikita.Assist.CodeMaker.Model.Bse_ControlType> list = new List<Nikita.Assist.CodeMaker.Model.Bse_ControlType>();
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
        /// <param name="strFields">字段</param> 
        /// <param name="strOrder">排序</param> 
        /// <param name="strOrderType">排序类型</param> 
        /// <param name="intPageSize">每页大小</param> 
        /// <param name="intPageIndex">当前第N页</param> 
        /// <param name="strWhere">条件</param> 
        /// <returns>返回符合条件的对象集合</returns>
        public List<Nikita.Assist.CodeMaker.Model.Bse_ControlType> GetListArray(string strFields, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere)
        {
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            DataTable dt = h.FengYe("Bse_ControlType", strFields, strOrder, strOrderType, strWhere, intPageSize, intPageIndex);
            List<Nikita.Assist.CodeMaker.Model.Bse_ControlType> list = new List<Nikita.Assist.CodeMaker.Model.Bse_ControlType>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Model.Bse_ControlType()
                {
                    Ctl_Id = int.Parse(row["Ctl_Id"].ToString()),
                    ControlType = row["ControlType"].ToString(),
                    Ctl_Simple = row["Ctl_Simple"].ToString(),
                    Ctl_Name = row["Ctl_Name"].ToString(),
                    Ctl_NameSpace = row["Ctl_NameSpace"].ToString(),
                    Ctl_Width = int.Parse(row["Ctl_Width"].ToString()),
                    Ctl_Height = int.Parse(row["Ctl_Height"].ToString()),
                    Ctl_Type = row["Ctl_Type"].ToString(),
                    State = row["State"].ToString(),
                    Sort = int.Parse(row["Sort"].ToString()),
                    Type = row["Type"].ToString(),
                    IsSelf = row["IsSelf"].ToString(),
                });
            }
            return list;
        }

        /// <summary>对象实体绑定数据
        /// 
        /// </summary>
        /// <param name="dataReader">IDataReader对象</param> 
        /// <returns>返回实体对象</returns>
        public Nikita.Assist.CodeMaker.Model.Bse_ControlType ReaderBind(IDataReader dataReader)
        {
            Nikita.Assist.CodeMaker.Model.Bse_ControlType model = new Nikita.Assist.CodeMaker.Model.Bse_ControlType();
            object ojb;
            ojb = dataReader["Ctl_Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Ctl_Id = int.Parse(ojb.ToString());
            }
            model.ControlType = dataReader["ControlType"].ToString();
            model.Ctl_Simple = dataReader["Ctl_Simple"].ToString();
            model.Ctl_Name = dataReader["Ctl_Name"].ToString();
            model.Ctl_NameSpace = dataReader["Ctl_NameSpace"].ToString();
            ojb = dataReader["Ctl_Width"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Ctl_Width = int.Parse(ojb.ToString());
            }
            ojb = dataReader["Ctl_Height"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Ctl_Height = int.Parse(ojb.ToString());
            }
            model.Ctl_Type = dataReader["Ctl_Type"].ToString();
            model.State = dataReader["State"].ToString();
            ojb = dataReader["Sort"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Sort = int.Parse(ojb.ToString());
            }
            model.Type = dataReader["Type"].ToString();
            model.IsSelf = dataReader["IsSelf"].ToString();

            return model;
        }

        /// <summary>计算记录数
        /// 
        /// </summary>
        /// <param name="strCond">条件</param>
        /// <returns>总数量</returns>
        public int CalcCount(string strCond)
        {
            string sql = "select count(1) from Bse_ControlType";
            if (!string.IsNullOrEmpty(strCond))
            {
                sql += " where " + strCond;
            }
           SQLiteHelper h = GlobalHelp.GetSQLiteHelper();
            h.CreateCommand(sql);
            return int.Parse(h.ExecuteScalar());
        }
    }
}

