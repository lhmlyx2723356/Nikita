 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nikita.Base.Define;

namespace Nikita.DataAccess4DBHelper
{
    public class DbHelper
    {
        /// <summary>获取数据库帮助类
        ///
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="strConn">数据库连接字符串</param>
        /// <returns>数据库帮助类</returns>
        public static IDbHelper GetDbHelper(SqlType dbType, string strConn)
        {
            IDbHelper dbHelper = null;
            switch (dbType)
            {
                case SqlType.SqlServer:
                    dbHelper = new MSSQLHelper(strConn);
                    break;

                case SqlType.MySql:
                    dbHelper = new MySQLHelper(strConn);
                    break;

                case SqlType.SQLite:
                    dbHelper = new SQLiteHelper(strConn);
                    break;

                case SqlType.Oracle:
                    break;
            }
            return dbHelper;
        }
    }
}