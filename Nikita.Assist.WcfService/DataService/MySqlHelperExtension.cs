using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nikita.Assist.WcfService
{
    /// <summary>
    /// MySqlHelper扩展(依赖AutoMapper.dll)
    /// </summary>
    public sealed partial class MySqlHelper
    {
        #region 实例方法

        public T ExecuteObject<T>(string commandText, params MySqlParameter[] parms)
        {
            return ExecuteObject<T>(ConnectionString, commandText, parms);
        }

        public List<T> ExecuteObjects<T>(string commandText, params MySqlParameter[] parms)
        {
            return ExecuteObjects<T>(ConnectionString, commandText, parms);
        }

        #endregion 实例方法

        #region 静态方法

        public static T ExecuteObject<T>(string connectionString, string commandText, params MySqlParameter[] parms)
        {
            //DataTable dt = ExecuteDataTable(connectionString, commandText, parms);
            //return AutoMapper.Mapper.DynamicMap<List<T>>(dt.CreateDataReader()).FirstOrDefault();
            using (MySqlDataReader reader = ExecuteDataReader(connectionString, commandText, parms))
            {
                return AutoMapper.Mapper.DynamicMap<List<T>>(reader).FirstOrDefault();
            }
        }

        public static List<T> ExecuteObjects<T>(string connectionString, string commandText, params MySqlParameter[] parms)
        {
            //DataTable dt = ExecuteDataTable(connectionString, commandText, parms);
            //return AutoMapper.Mapper.DynamicMap<List<T>>(dt.CreateDataReader());
            using (MySqlDataReader reader = ExecuteDataReader(connectionString, commandText, parms))
            {
                return AutoMapper.Mapper.DynamicMap<List<T>>(reader);
            }
        }

        #endregion 静态方法
    }
}