using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.Base.CacheStore.DAL;
using Nikita.Base.CacheStore.Model;
using Nikita.Base.DbSchemaReader.Data;
using Nikita.Base.DbSchemaReader.DataSchema;
using Nikita.Base.DbSchemaReader.SqlGen;
using Nikita.Base.DbSchemaReader;
using Nikita.Base.DbSchemaReader.Conversion;
using Nikita.Base.IDAL;
using Nikita.DataAccess4DBHelper;

namespace Nikita.Base.CacheStore
{
    public class CacheManager
    {
        private static int m_allowCache = -1;
        /// <summary>是否开启缓存功能
        /// 
        /// </summary>
        public static bool AllowCache
        {
            get
            {
                if (m_allowCache==-1)
                {
                    m_allowCache= GetAllowCache();
                }
                return m_allowCache==1;
            }   
        }
        /// <summary>判断是否开启缓存
        /// 
        /// </summary>
        /// <returns></returns>
        private static int GetAllowCache()
        {
            IDbHelper helper = GlobalHelp.GetDataAccessHelper();
            helper.CreateCommand("Select SetText From CacheSetting Where SetKey='AllowCache'");
            string strResult = helper.ExecuteScalar();
            if (strResult != string.Empty)
            {
                bool blnReturn;
                if (bool.TryParse(strResult, out blnReturn))
                {
                    return blnReturn?1:0; 
                }
                return 0;
            } 
            return 0;
        }

        /// <summary>根据表生成脚本
        /// 
        /// </summary>
        /// <param name="databaseTable">databaseTable</param>
        /// <param name="sqlType">sqlType</param>
        /// <returns></returns>
        internal static string RunTableDdl(DatabaseTable databaseTable, SqlType sqlType)
        {
            var tg = new DdlGeneratorFactory(sqlType).TableGenerator(databaseTable);
            tg.IncludeSchema = false;
            string strDdl = tg.Write();
            return strDdl;
        }

        /// <summary>获取DatabaseTable
        /// 
        /// </summary>
        /// <param name="strConnectionString">strConnectionString</param>
        /// <param name="sqlType">sqlType</param>
        /// <param name="strTableName">strTableName</param>
        /// <returns></returns>
        internal static DatabaseTable GetDatabaseTable(string strConnectionString,
            SqlType sqlType,
            string strTableName)
        {
            var rdr = new DatabaseReader(strConnectionString, ProviderToSqlType.Convert(sqlType));
            return rdr.Table(strTableName);
        }

        /// <summary>获取缓存表配置
        /// 
        /// </summary>
        /// <returns></returns>
        internal static List<CacheConfig> GetCacheStoreConfig()
        {
            IBseDAL<CacheConfig> cacheDal = GlobalHelp.GetResolve<IBseDAL<CacheConfig>>();
            return cacheDal.GetListArray("");
        }
        /// <summary>同步缓存
        /// 
        /// </summary>
        public static void SynCache()
        {
            IDbHelper helperSqlServer = GlobalHelp.GetDataAccessHelper();
            IDbHelper helperSqlite = GlobalHelp.GetDataAccessSqliteHelper();
            string strSql = "Select * from CacheConfig";
            string strIds = GetLocalCacheIds();
            if (strIds != string.Empty)
            {
                strSql = strSql + " where Id  not in(" + strIds + ") ";
            }
            helperSqlServer.CreateCommand(strSql);
            DataTable dtCacheTable = helperSqlServer.ExecuteQuery();
            if (dtCacheTable.Rows.Count <= 0) return;
            foreach (DataRow dr in dtCacheTable.Rows)
            {
                string strTableName = dr["TableName"].ToString();
                string strId = dr["Id"].ToString();
                string strConn = dr["ConnectionString"].ToString();
                DatabaseTable databaseTable = GetDatabaseTable(strConn, SqlType.SqlServer, strTableName);
                if (databaseTable != null)
                {
                    #region 创建本地脚本
                    string strDdl = RunTableDdl(databaseTable, SqlType.SQLite);
                    strDdl += "; SELECT 'ok'";
                    helperSqlite.CreateCommand("DROP Table IF EXISTS [" + strTableName + "]");
                    helperSqlite.ExecuteNonQuery();
                    helperSqlite.CreateCommand(strDdl);
                    DataTable dtCache = helperSqlite.ExecuteQuery();
                    #endregion 
                    if (dtCache.Rows.Count > 0 && dtCache.Rows[0][0].ToString().Trim() == "ok")
                    {
                        //删除本地缓存设置表数据
                        helperSqlite.CreateCommand("DELETE FROM CacheConfig WHERE TableName ='" + strTableName + "' ");
                        helperSqlite.ExecuteNonQuery();
                        //获取服务器缓存表数据，并同步至本地缓存数据库  
                        IDbHelper helperTemp = new MSSQLHelper(strConn);
                        helperTemp.CreateCommand("SELECT * FROM " + strTableName + " with(nolock)");
                        DataTable dtBatch = helperTemp.ExecuteQuery();
                        dtBatch.TableName = strTableName;
                        for (int i = 0; i < dtBatch.Columns.Count; i++)
                        {
                            dtBatch.Columns[i].AutoIncrement = false;
                        }
                        helperSqlite.BatchInsert(dtBatch);
                        //同步本地缓存设置表数据
                        dtCacheTable.TableName = "CacheConfig";
                        for (int i = 0; i < dtCacheTable.Columns.Count; i++)
                        {
                            dtCacheTable.Columns[i].AutoIncrement = false;
                        }
                        for (int i = 0; i < dtCacheTable.Rows.Count; i++)
                        {
                            dtCacheTable.Rows[i]["ConnectionString"] = string.Empty;
                        }
                        helperSqlite.BatchInsert(dtCacheTable);
                    }
                }
            }
        }

        internal static string GetLocalCacheIds()
        {
            IDbHelper dbSqliteHelper = GlobalHelp.GetDataAccessSqliteHelper();
            string strSql = "Select Id from CacheConfig ";
            dbSqliteHelper.CreateCommand(strSql);
            //dbSqliteHelper.
            DataTable dt = dbSqliteHelper.ExecuteQuery();
            if (dt.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(("("));
                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append(dr["Id"]);
                    sb.Append(",");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append((")"));
                return sb.ToString();
            }
            return string.Empty;
        }

        private static Dictionary<string, string> m_dicCache ;

        public static Dictionary<string, string> CacheDictionary
        {
            get
            {
                if (m_dicCache==null)
                {
                    m_dicCache = GetCacheDictinary();
                }
                return m_dicCache;
            }

        }

        internal static Dictionary<string, string>   GetCacheDictinary()
        {
            m_dicCache=new Dictionary<string, string>();
             IDbHelper dbHelper = GlobalHelp.GetDataAccessHelper();
            string strSql = "Select Distinct TableName from CacheConfig ";
            dbHelper.CreateCommand(strSql); 
            DataTable dt = dbHelper.ExecuteQuery();
            if (dt.Rows.Count > 0)
            {
                string strCacheTableName = dt.Rows[0][0].ToString();
                m_dicCache.Add(strCacheTableName, strCacheTableName);
            }
            return m_dicCache;
        } 

    }
}
