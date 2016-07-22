using System;
using System.Collections.Generic; 
using System.Text;
using System.Data;  
using Nikita.DataAccess4DBHelper;
using Nikita.Base.IDAL;
using Nikita.Base.CacheStore.Model; 

namespace Nikita.Base.CacheStore.DAL
{
    /// <summary>CacheConfig表数据访问类
    /// 作者:Luhm
    /// 创建时间:2016-06-26 10:00:31
    /// </summary>
    public partial class CacheConfigDAL : IBseDAL<CacheConfig>
    {
        public CacheConfigDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(Nikita.Base.CacheStore.Model.CacheConfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CacheConfig(");
            strSql.Append("ConnectionString, TableName, Filter, CacheTableName, CacheChekGuid, CacheVersion, CreateUser, CreateDate, Remark, Status  )");
            strSql.Append(" values (");
            strSql.Append("@ConnectionString, @TableName, @Filter, @CacheTableName, @CacheChekGuid, @CacheVersion, @CreateUser, @CreateDate, @Remark, @Status  )");
            strSql.Append(";select @@IDENTITY");
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            if (model.ConnectionString == null)
            {
                h.AddParameter("@ConnectionString", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ConnectionString", model.ConnectionString);
            }
            if (model.TableName == null)
            {
                h.AddParameter("@TableName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@TableName", model.TableName);
            }
            if (model.Filter == null)
            {
                h.AddParameter("@Filter", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Filter", model.Filter);
            }
            if (model.CacheTableName == null)
            {
                h.AddParameter("@CacheTableName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CacheTableName", model.CacheTableName);
            }
            if (model.CacheChekGuid == null)
            {
                h.AddParameter("@CacheChekGuid", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CacheChekGuid", model.CacheChekGuid);
            }
            if (model.CacheVersion == null)
            {
                h.AddParameter("@CacheVersion", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CacheVersion", model.CacheVersion);
            }
            if (model.CreateUser == null)
            {
                h.AddParameter("@CreateUser", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateUser", model.CreateUser);
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
            if (model.Status == null)
            {
                h.AddParameter("@Status", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Status", model.Status);
            }
            model.CacheChekGuid = Guid.NewGuid().ToString();
            int intResult;
            string obj = h.ExecuteScalar();
            if (!int.TryParse(obj, out intResult))
            {
                return 0;
            }
            #region 新增缓存配置：如果是则需要推送更新缓存的消息。。即是发消息告诉服务端我修改了缓存配置，让服务端统一向所有在线客户端发送更新缓存消息 
          
            h.CreateCommand("select * from  CacheConfig where id =" + intResult + "");
            DataTable dt = h.ExecuteQuery();
            dt.TableName = "CacheConfig";
            CacheMessageEntity messageEntity = new CacheMessageEntity { CacheKey = model.CacheTableName, Operation = "Add", DataTableCache = dt }; 
            CacheListener.AddMessage(messageEntity);
            #endregion
            return intResult;
        }

        /// <summary>删除一条数据
        /// 
        /// </summary>
        public bool Delete(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CacheConfig ");
            strSql.Append(" where Id=@Id ");
            IDbHelper h = GlobalHelp.GetDataAccessHelper();

            #region 缓存配置行 
            h.CreateCommand("select * from  CacheConfig where id =" + Id + "");
            DataTable dt = h.ExecuteQuery();
            dt.TableName = "CacheConfig";
            #endregion

            h.CreateCommand(strSql.ToString());
            h.AddParameter("@Id", Id);
            bool blnReturn= h.ExecuteNonQuery();
            if (blnReturn)
            {
                #region 修改缓存配置：如果是则需要推送更新缓存的消息。即是发消息告诉服务端我修改了缓存配置，让服务端统一向所有在线客户端发送更新缓存消息 
                string strCacheTableName = dt.Rows[0]["CacheTableName"].ToString();
                CacheMessageEntity messageEntity = new CacheMessageEntity { CacheKey = strCacheTableName, Operation = "Delete", DataTableCache = dt };
                CacheListener.AddMessage(messageEntity);
                #endregion
            }
            return blnReturn;
        }
        /// <summary>更新一条数据
        /// 
        /// </summary>
        public bool Update(Nikita.Base.CacheStore.Model.CacheConfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CacheConfig set ");
            strSql.Append("ConnectionString=@ConnectionString, TableName=@TableName, Filter=@Filter, CacheTableName=@CacheTableName, CacheChekGuid=@CacheChekGuid, CacheVersion=@CacheVersion, CreateUser=@CreateUser, CreateDate=@CreateDate, Remark=@Remark, Status=@Status  ");
            strSql.Append(" where Id=@Id ");
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            if (model.Id == null)
            {
                h.AddParameter("@Id", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Id", model.Id);
            }
            if (model.ConnectionString == null)
            {
                h.AddParameter("@ConnectionString", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ConnectionString", model.ConnectionString);
            }
            if (model.TableName == null)
            {
                h.AddParameter("@TableName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@TableName", model.TableName);
            }
            if (model.Filter == null)
            {
                h.AddParameter("@Filter", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Filter", model.Filter);
            }
            if (model.CacheTableName == null)
            {
                h.AddParameter("@CacheTableName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CacheTableName", model.CacheTableName);
            }
            if (model.CacheChekGuid == null)
            {
                h.AddParameter("@CacheChekGuid", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CacheChekGuid", model.CacheChekGuid);
            }
            if (model.CacheVersion == null)
            {
                h.AddParameter("@CacheVersion", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CacheVersion", model.CacheVersion);
            }
            if (model.CreateUser == null)
            {
                h.AddParameter("@CreateUser", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateUser", model.CreateUser);
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
            if (model.Status == null)
            {
                h.AddParameter("@Status", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Status", model.Status);
            }

            bool blnReturn = h.ExecuteNonQuery(); 
            return blnReturn;
        }

        /// <summary>根据条件更新字段
        /// 
        /// </summary>
        public bool Update(string strFieldWithValue, string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CacheConfig set ");
            strSql.Append(strFieldWithValue);
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond);
            }
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }


        /// <summary>根据条件删除数据
        /// 
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CacheConfig ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        public Nikita.Base.CacheStore.Model.CacheConfig GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from CacheConfig ");
            strSql.Append(" where Id=@Id ");
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@Id", Id);
            Nikita.Base.CacheStore.Model.CacheConfig model = null;
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
        public Nikita.Base.CacheStore.Model.CacheConfig GetModelByCond(string strCond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from CacheConfig ");
            if (!string.IsNullOrEmpty(strCond))
            {
                strSql.Append(" where " + strCond);
            }
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(strSql.ToString());
            Nikita.Base.CacheStore.Model.CacheConfig model = null;
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
            strSql.Append(" FROM CacheConfig ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
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
            strSql.Append("select " + strFields + " ");
            strSql.Append(" FROM CacheConfig ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
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
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "CacheConfig");
            h.AddParameter("@strFields", strFileds);
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
        public List<Nikita.Base.CacheStore.Model.CacheConfig> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM CacheConfig ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Nikita.Base.CacheStore.Model.CacheConfig> list = new List<Nikita.Base.CacheStore.Model.CacheConfig>();
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
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
        public List<Nikita.Base.CacheStore.Model.CacheConfig> GetListArray(string strFileds, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere)
        {
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
            h.CreateStoredCommand("[proc_SplitPage]");
            h.AddParameter("@tblName", "CacheConfig");
            h.AddParameter("@strFields", strFileds);
            h.AddParameter("@strOrder", strOrder);
            h.AddParameter("@strOrderType", strOrderType);
            h.AddParameter("@PageSize", intPageSize);
            h.AddParameter("@PageIndex", intPageIndex);
            h.AddParameter("@strWhere", strWhere);
            List<Nikita.Base.CacheStore.Model.CacheConfig> list = new List<Nikita.Base.CacheStore.Model.CacheConfig>();
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
        public Nikita.Base.CacheStore.Model.CacheConfig ReaderBind(IDataReader dataReader)
        {
            Nikita.Base.CacheStore.Model.CacheConfig model = new Nikita.Base.CacheStore.Model.CacheConfig();
            object ojb;
            ojb = dataReader["Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Id = int.Parse(ojb.ToString());
            }
            model.ConnectionString = dataReader["ConnectionString"].ToString();
            model.TableName = dataReader["TableName"].ToString();
            model.Filter = dataReader["Filter"].ToString();
            model.CacheTableName = dataReader["CacheTableName"].ToString();
            model.CacheChekGuid = dataReader["CacheChekGuid"].ToString();
            model.CacheVersion = dataReader["CacheVersion"].ToString();
            model.CreateUser = dataReader["CreateUser"].ToString();
            ojb = dataReader["CreateDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreateDate = DateTime.Parse(ojb.ToString());
            }
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
            string sql = "select count(1) from CacheConfig";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
            IDbHelper h = GlobalHelp.GetDataAccessHelper();
            h.CreateCommand(sql);
            return int.Parse(h.ExecuteScalar());
        }
    }
}

