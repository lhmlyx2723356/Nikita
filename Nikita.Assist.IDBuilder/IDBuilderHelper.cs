 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Nikita.Base.Define;
using Nikita.DataAccess4DBHelper;

namespace Nikita.Assist.IDBuilder
{
    public class IDBuilderHelper : IIDBuilder
    { 
 

        public DataTable GetInfo(SqlType dbType, string strConn, string strTableName)
        {
            IDbHelper dbHelper = DbHelper.GetDbHelper(dbType, strConn);
            dbHelper.CreateCommand("select * from  " + strTableName + "");
            return dbHelper.ExecuteQuery();
        }

        /// <summary>生成主键
        ///
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="strTableName">表名</param>
        /// <param name="strConn">IDBuilder数据库连接字符串</param>
        /// <returns>组件</returns>
        public long GetNewID(SqlType dbType, string strTableName, string strConn)
        {
            long lngNewId = 0;
            IDbHelper dbHelper = DbHelper.GetDbHelper(dbType, strConn);
            if (dbType == SqlType.MySql || dbType == SqlType.SqlServer)
            {
                dbHelper.CreateStoredCommand("Get_TableKey");
                dbHelper.AddParameter("@TableName", strTableName);
                lngNewId = long.Parse(dbHelper.ExecuteScalar());
            }
            else if (dbType == SqlType.SQLite)
            {

            }
            return lngNewId;
        }

        /// <summary>获取业务单据
        ///
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="strType">单据前缀：如：'ORD'等</param>
        /// <param name="strTableName">表名</param>
        /// <param name="strTableField">字段名</param>
        /// <param name="strPreficLength">单据流水长度，如果一天可以产生1000张，则长度为4</param>
        /// <param name="blnDt">是否需要日期，格式20151227</param>
        /// <param name="intFyId">公司ID</param>
        /// <param name="strConn">IDBuilder数据库连接字符串</param>
        /// <returns>单据流水号</returns>
        public string GetSeriesNumber(SqlType dbType, string strType, string strTableName, string strTableField, string strPreficLength, bool blnDt, int intFyId, string strConn)
        {
            IDbHelper dbHelper = DbHelper.GetDbHelper(dbType, strConn);
            string strSeriesNumber = string.Empty;
            if (dbType == SqlType.MySql || dbType == SqlType.SqlServer)
            {
                dbHelper.CreateStoredCommand("Get_Sys_Series_Number");
                dbHelper.AddParameter("@strType", strType);
                dbHelper.AddParameter("@TableName", strTableName);
                dbHelper.AddParameter("@TableField ", strTableField);
                dbHelper.AddParameter("@preficLength", strPreficLength);
                dbHelper.AddParameter("@BlnDt", blnDt);
                dbHelper.AddParameter("@Fy_Id", intFyId);
                strSeriesNumber = dbHelper.ExecuteScalar();
            }
            else if (dbType == SqlType.SQLite)
            {

            }
            return strSeriesNumber;
        }
         
    }
}