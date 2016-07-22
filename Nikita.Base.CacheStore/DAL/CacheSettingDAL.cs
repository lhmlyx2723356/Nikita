using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; 
using Nikita.DataAccess4DBHelper;
using Nikita.Base.IDAL;
using Nikita.Base.CacheStore.Model;
namespace Nikita.Base.CacheStore.DAL
{
    /// <summary>CacheSetting表数据访问类
    /// 作者:Luhm
    /// 创建时间:2016-06-30 21:56:07
    /// </summary>
    public partial class CacheSettingDAL  : IBseDAL<CacheSetting> 
    {
        public CacheSettingDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(Nikita.Base.CacheStore.Model.CacheSetting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CacheSetting(");
            strSql.Append("SetKey, SetText, CreateDate, Remark  )");
            strSql.Append(" values (");
            strSql.Append("@SetKey, @SetText, @CreateDate, @Remark  )");
            strSql.Append(";select @@IDENTITY");
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
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

            int intResult;
            string obj = h.ExecuteScalar();
            if (!int.TryParse(obj, out intResult))
            {
                return 0;
            }
            return   intResult;
        }

        /// <summary>更新一条数据
        /// 
        /// </summary>
        public bool Update(Nikita.Base.CacheStore.Model.CacheSetting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CacheSetting set ");
            strSql.Append("SetKey=@SetKey, SetText=@SetText, CreateDate=@CreateDate, Remark=@Remark  ");
            strSql.Append(" where Id=@Id ");
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            if (model.Id == null)
            {
                 h.AddParameter("@Id", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Id", model.Id);
            }
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

            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件更新字段
        /// 
        /// </summary>
        public bool Update(string strFieldWithValue,string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CacheSetting set ");
            strSql.Append(strFieldWithValue);
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond );
            }
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString()); 
            return h.ExecuteNonQuery();
        }

        /// <summary>删除一条数据
        /// 
        /// </summary>
        public bool Delete(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CacheSetting ");
            strSql.Append(" where Id=@Id ");
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@Id", Id);
            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件删除数据
        /// 
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CacheSetting ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        public Nikita.Base.CacheStore.Model.CacheSetting GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from CacheSetting ");
            strSql.Append(" where Id=@Id ");
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@Id", Id);
            Nikita.Base.CacheStore.Model.CacheSetting model = null;
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
        public Nikita.Base.CacheStore.Model.CacheSetting GetModelByCond(string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from CacheSetting ");
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond);
            }
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            Nikita.Base.CacheStore.Model.CacheSetting model = null;
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
            strSql.Append(" FROM CacheSetting ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

		
        /// <summary>获得数据列表
        /// 
        /// </summary>
        public DataSet GetList(string strWhere, string strFields)
        {
            StringBuilder strSql = new StringBuilder(); 
			  strSql.Append("select " +strFields + " ");
            strSql.Append(" FROM CacheSetting ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }


        /// <summary>分页获取数据列表
        /// 
        /// </summary>
        public DataSet GetList(string strFileds, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere)
        {
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "CacheSetting");
            h.AddParameter("@strFields",strFileds);
            h.AddParameter("@strOrder", strOrder);
            h.AddParameter("@strOrderType", strOrderType);
            h.AddParameter("@PageSize", intPageSize);
            h.AddParameter("@PageIndex", intPageIndex);
            h.AddParameter("@strWhere", strWhere);
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得数据列表（比DataSet效率高，推荐使用）
        /// 
        /// </summary>
        public List<Nikita.Base.CacheStore.Model.CacheSetting> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM CacheSetting ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Nikita.Base.CacheStore.Model.CacheSetting> list = new List<Nikita.Base.CacheStore.Model.CacheSetting>();
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
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
        public List<Nikita.Base.CacheStore.Model.CacheSetting> GetListArray(string strFileds, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere)
        {
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "CacheSetting");
            h.AddParameter("@strFields", strFileds);
            h.AddParameter("@strOrder", strOrder);
            h.AddParameter("@strOrderType", strOrderType);
            h.AddParameter("@PageSize", intPageSize);
            h.AddParameter("@PageIndex", intPageIndex);
            h.AddParameter("@strWhere", strWhere);
            List<Nikita.Base.CacheStore.Model.CacheSetting> list = new List<Nikita.Base.CacheStore.Model.CacheSetting>();
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

        /// <summary>对象实体绑定数据
        /// 
        /// </summary>
        public Nikita.Base.CacheStore.Model.CacheSetting ReaderBind(IDataReader dataReader)
        {
            Nikita.Base.CacheStore.Model.CacheSetting model = new Nikita.Base.CacheStore.Model.CacheSetting();
            object ojb;
            ojb = dataReader["Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Id = int.Parse(ojb.ToString());
            }
            model.SetKey = dataReader["SetKey"].ToString();
            model.SetText = dataReader["SetText"].ToString();
            ojb = dataReader["CreateDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreateDate = DateTime.Parse(ojb.ToString());
            }
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
            string sql = "select count(1) from CacheSetting";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
           IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(sql);
            return int.Parse(h.ExecuteScalar());
        }
    }
}

