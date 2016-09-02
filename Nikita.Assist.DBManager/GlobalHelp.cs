using Nikita.Base.DbSchemaReader.DataSchema;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Nikita.Base.ConnectionManager;
using Nikita.WinForm.ExtendControl;

namespace Nikita.Assist.DBManager
{
    public static class GlobalHelp
    {
        public static string DefauleDatabase { get; set; }

        public static string ConfigConn = ConfigConnection.CodeMgrDemoConnection;

        public static string DatabaseManagerDB = SQLiteConfigConnection.DatabaseManagerDBConnection;


        public static string SynchronizationDB = SQLiteConfigConnection.SynchronizationDBConnection;

        public static string TestConn = ConfigConnection.TestConnection;

        public static SqlTasks sqlTasks;
        /// <summary>
        /// Dic<服务器名称，Dic<数据库名称，结构>>
        /// </summary>
        public static Dictionary<string, Dictionary<string, DatabaseSchema>> DicMySqlDatabaseSchema
        {
            get;
            set;
        }

        /// <summary>
        /// Dic<服务器名称，Dic<数据库名称，结构>>
        /// </summary>
        public static Dictionary<string, Dictionary<string, DatabaseSchema>> DicSQLiteDatabaseSchema
        {
            get;
            set;
        }

        /// <summary>
        /// Dic<服务器名称，Dic<数据库名称，结构>>
        /// </summary>
        public static Dictionary<string, Dictionary<string, DatabaseSchema>> DicSqlServerDatabaseSchema
        {
            get;
            set;
        }

        public static DockPanel DockPanel
        {
            get;
            set;
        }

        public static TreeView TreeView
        {
            get;
            set;
        }

        public static DatabaseSchema GetDatabaseSchema(SqlType dbType, string strServer, string strDbName)
        {
            DatabaseSchema databaseSchema = null;
            switch (dbType)
            {
                case SqlType.SqlServer:
                    databaseSchema = DicSqlServerDatabaseSchema[strServer][strDbName];
                    break;

                case SqlType.Oracle:
                    break;

                case SqlType.MySql:
                    databaseSchema = DicMySqlDatabaseSchema[strServer][strDbName];
                    break;

                case SqlType.SQLite:
                    databaseSchema = DicSQLiteDatabaseSchema[strServer][strDbName];
                    break;

                case SqlType.SqlServerCe:
                    break;

                case SqlType.PostgreSql:
                    break;

                case SqlType.Db2:
                    break;
            }
            return databaseSchema;
        }

        /// <summary>获取内存
        /// 获取内存
        /// </summary>
        /// <returns></returns>
        public static double GetProcessUsedMemory()
        {
            var usedMemory = Process.GetCurrentProcess().WorkingSet64 / 1024.0 / 1024.0;
            return usedMemory;
        }

        public static SqlTasks GetSqlTasks(SqlType dbType)
        {
            if (sqlTasks == null)
            {
                sqlTasks = new SqlTasks(dbType);
            }
            return sqlTasks;
        }
    }
}