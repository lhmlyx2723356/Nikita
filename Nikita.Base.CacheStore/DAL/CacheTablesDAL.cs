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
    /// <summary>CacheTables表数据访问类
    /// 作者:Luhm
    /// 创建时间:2016-06-26 09:32:28
    /// </summary>
    public partial class CacheTablesDAL : IBseDAL<CacheTables>
    {
        public CacheTablesDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(Nikita.Base.CacheStore.Model.CacheTables model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CacheTables(");
            strSql.Append("TableName, Remark, Status  )");
            strSql.Append(" values (");
            strSql.Append("@TableName, @Remark, @Status  )");
            strSql.Append(";select @@IDENTITY");
            IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            if (model.TableName == null)
            {
                 h.AddParameter("@TableName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@TableName", model.TableName);
            }
            if (model.Remark == null)
            {
                 h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Remark", model.Remark);
            }
            if (model.Status == null)
            {
                 h.AddParameter("@Status", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Status", model.Status);
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
        public bool Update(Nikita.Base.CacheStore.Model.CacheTables model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CacheTables set ");
            strSql.Append("TableName=@TableName, Remark=@Remark, Status=@Status  ");
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
            if (model.TableName == null)
            {
                 h.AddParameter("@TableName", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@TableName", model.TableName);
            }
            if (model.Remark == null)
            {
                 h.AddParameter("@Remark", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Remark", model.Remark);
            }
            if (model.Status == null)
            {
                 h.AddParameter("@Status", DBNull.Value);
            }
            else
            {
                 h.AddParameter("@Status", model.Status);
            }

            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件更新字段
        /// 
        /// </summary>
        public bool Update(string strFieldWithValue,string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CacheTables set ");
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
            strSql.Append("delete from CacheTables ");
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
            strSql.Append("delete from CacheTables ");
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
        public Nikita.Base.CacheStore.Model.CacheTables GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from CacheTables ");
            strSql.Append(" where Id=@Id ");
            IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@Id", Id);
            Nikita.Base.CacheStore.Model.CacheTables model = null;
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
        public Nikita.Base.CacheStore.Model.CacheTables GetModelByCond(string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from CacheTables ");
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond);
            }
            IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            Nikita.Base.CacheStore.Model.CacheTables model = null;
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
            strSql.Append(" FROM CacheTables ");
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
            strSql.Append(" FROM CacheTables ");
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
            h.AddParameter("@tblName", "CacheTables");
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
        public List<Nikita.Base.CacheStore.Model.CacheTables> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM CacheTables ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Nikita.Base.CacheStore.Model.CacheTables> list = new List<Nikita.Base.CacheStore.Model.CacheTables>();
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
        public List<Nikita.Base.CacheStore.Model.CacheTables> GetListArray(string strFileds, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere)
        {
            IDbHelper h=GlobalHelp.GetDataAccessHelper();
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "CacheTables");
            h.AddParameter("@strFields", strFileds);
            h.AddParameter("@strOrder", strOrder);
            h.AddParameter("@strOrderType", strOrderType);
            h.AddParameter("@PageSize", intPageSize);
            h.AddParameter("@PageIndex", intPageIndex);
            h.AddParameter("@strWhere", strWhere);
            List<Nikita.Base.CacheStore.Model.CacheTables> list = new List<Nikita.Base.CacheStore.Model.CacheTables>();
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
        public Nikita.Base.CacheStore.Model.CacheTables ReaderBind(IDataReader dataReader)
        {
            Nikita.Base.CacheStore.Model.CacheTables model = new Nikita.Base.CacheStore.Model.CacheTables();
            object ojb;
            ojb = dataReader["Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Id = int.Parse(ojb.ToString());
            }
            model.TableName = dataReader["TableName"].ToString();
            model.Remark = dataReader["Remark"].ToString();
            ojb = dataReader["Status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = int.Parse(ojb.ToString());
            }

            return model;
        }

        /// <summary>计算记录数
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int CalcCount(string cond)
        {
            string sql = "select count(1) from CacheTables";
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

