using System.Data;
using Nikita.Base.CacheStore;
using Nikita.Base.Define;
using Nikita.DataAccess4DBHelper;

namespace Nikita.Base.Aop
{
    public class CacheHandler : ICacheHandler
    {
        public   object GetCache(string strTableName, string strWhere)
        {
            if (CacheManager.CacheDictionary.ContainsKey(strTableName))
            {
                IDbHelper helper = GlobalHelp.GetDataAccessSqliteHelper();
                string strSql = "Select * from " + strTableName;
                if (strWhere.Trim() != string.Empty)
                {
                    strSql += " where " + strWhere;
                }
                helper.CreateCommand(strSql);
                return helper.ExecuteQuery();
            }
            return null;
        }
    }
}