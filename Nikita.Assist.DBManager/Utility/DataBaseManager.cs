using Nikita.Base.DbSchemaReader.DataSchema;
using Nikita.Assist.DBManager.DAL;
using System.Data;
using System.Text;

namespace Nikita.Assist.DBManager
{
    public class DataBaseManager
    {
        /// <summary>建立数据库连接
        /// 建立数据库连接
        /// </summary>
        /// <param name="dbType">dbType</param>
        /// <param name="strServer">strServer</param>
        /// <param name="strUid">strUID</param>
        /// <param name="strPwd">strPWD</param>
        /// <param name="strPort">strPort</param>
        /// <param name="strDbName">strDbName</param>
        /// <returns>Connection</returns>
        public static string BuildConn(SqlType dbType, string strServer, string strUid, string strPwd, string strPort, string strDbName)
        {
            string strConn = string.Empty;
            switch (dbType)
            {
                case SqlType.SqlServer:
                    strConn = "server=" + strServer + ";uid=" + strUid + ";pwd=" + strPwd + ";database=" + strDbName + "";
                    break;

                case SqlType.MySql:
                    strConn = " server=" + strServer + ";Port=" + strPort + ";database=" + strDbName + ";uid=" + strUid + ";pwd=" + strPwd + ";charset=utf8;Allow User Variables=True";
                    break;

                case SqlType.Oracle:
                    break;
            }
            return strConn;
        }

        public static string GenCreateDatabaseScripts(SqlType dbType, string strDbName, string strPath)
        {
            string strSql = string.Empty;
            switch (dbType)
            {
                case SqlType.SqlServer:
                    strSql = GenCreateDatabase4SqlServer(strDbName, strPath);
                    break;

                case SqlType.Oracle:
                    break;

                case SqlType.MySql:
                    break;

                case SqlType.SQLite:
                    break;

                case SqlType.SqlServerCe:
                    break;

                case SqlType.PostgreSql:
                    break;

                case SqlType.Db2:
                    break;
            }
            return strSql;
        }

        /// <summary>获取服务器下所有库的表/视图/存储过程/函数 的名称，内容，类型等信息表
        ///  获取服务器下所有库的表/视图/存储过程/函数 的名称，内容，类型等信息表
        /// </summary>
        /// <param name="dbType">dbType</param>
        /// <param name="strConn">strConn</param>
        /// <param name="dtDbNames">dtDBNames</param>
        /// <param name="objType">objType</param>
        /// <returns>DataSet</returns>
        public static DataSet GetAllDbObject(SqlType dbType, string strConn, DataTable dtDbNames, DatabaseObjectType objType)
        {
            IDBHelper dbHelper = GetDbHelper(dbType, strConn);
            string strSql = string.Empty;
            switch (dbType)
            {
                case SqlType.SqlServer:
                    strSql = GetSqlServerObjectSqls(dtDbNames, objType);
                    break;

                case SqlType.MySql:
                    break;

                case SqlType.Oracle:
                    break;
            }
            dbHelper.CreateCommand(strSql);
            return dbHelper.ExecuteQueryDataSet();
        }

        public static string GetCreateFunction(SqlType dbType)
        {
            StringBuilder sb = new StringBuilder();
            switch (dbType)
            {
                case SqlType.SqlServer:
                    sb.AppendLine("CREATE FUNCTION --函数名称");
                    sb.AppendLine("(");
                    sb.AppendLine("--函数参数");
                    sb.AppendLine(")");
                    sb.AppendLine("RETURNS");
                    sb.AppendLine("--返回类型");
                    sb.AppendLine("AS");
                    sb.AppendLine("BEGIN");
                    sb.AppendLine(" --函数内容");
                    sb.AppendLine("RETURN");
                    sb.AppendLine("END");
                    break;

                case SqlType.Oracle:
                    break;

                case SqlType.MySql:
                    break;

                case SqlType.SQLite:
                    break;

                case SqlType.SqlServerCe:
                    break;

                case SqlType.PostgreSql:
                    break;

                case SqlType.Db2:
                    break;
            }
            return sb.ToString();
        }

        public static string GetCreateProc(SqlType dbType)
        {
            StringBuilder sb = new StringBuilder();
            switch (dbType)
            {
                case SqlType.SqlServer:
                    sb.AppendLine("CREATE PROCEDURE --存储过程名称");
                    sb.AppendLine(" --存储过程参数");
                    sb.AppendLine("AS");
                    sb.AppendLine("BEGIN");
                    sb.AppendLine(" --存储过程内容");
                    sb.AppendLine("END");
                    break;

                case SqlType.Oracle:
                    break;

                case SqlType.MySql:
                    sb.AppendLine("  #存储过程名称调用方法  call 存储过程名称 (输入参数1,输入参数2)");
                    sb.AppendLine(" CREATE PROCEDURE  #存储过程名称  ((#存储过程参数 如：IN Id int)   )");
                    sb.AppendLine(" BEGIN  ");
                    sb.AppendLine("#存储过程名称内容(注意每条语句结束后带分号) ;");
                    sb.AppendLine(" END   ");
                    break;

                case SqlType.SQLite:
                    break;

                case SqlType.SqlServerCe:
                    break;

                case SqlType.PostgreSql:
                    break;

                case SqlType.Db2:
                    break;
            }
            return sb.ToString();
        }

        public static string GetCreateView(SqlType dbType)
        {
            StringBuilder sb = new StringBuilder();
            switch (dbType)
            {
                case SqlType.SqlServer:
                    sb.AppendLine("CREATE VIEW --视图名称");
                    sb.AppendLine("AS");
                    sb.AppendLine(" --视图内容");
                    break;

                case SqlType.Oracle:
                    break;

                case SqlType.MySql:
                    break;

                case SqlType.SQLite:
                    break;

                case SqlType.SqlServerCe:
                    break;

                case SqlType.PostgreSql:
                    break;

                case SqlType.Db2:
                    break;
            }
            return sb.ToString();
        }

        /// <summary>根据类型获取服务器的所有数据库
        /// 根据类型获取服务器的所有数据库
        /// </summary>
        /// <param name="dbType">strDBType</param>
        /// <param name="strConn">strConn</param>
        /// <returns>表结构</returns>
        public static DataTable GetDataBase(SqlType dbType, string strConn)
        {
            IDBHelper dbHelper = GetDbHelper(dbType, strConn);
            string strSql = string.Empty;
            switch (dbType)
            {
                case SqlType.SqlServer:
                    strSql = "SELECT name FROM  Master.dbo.SysDatabases Where name not in ('master','model','msdb','tempdb')  ";
                    break;

                case SqlType.MySql:
                    strSql = " SELECT `SCHEMA_NAME` as name  FROM `information_schema`.`SCHEMATA` where  `SCHEMA_NAME` not in('information_schema','mysql','test')";
                    break;

                case SqlType.Oracle:
                    break;
            }
            dbHelper.CreateCommand(strSql);
            return dbHelper.ExecuteQuery();
        }

        public static DataTable GetDataDictionary(SqlType dbType, string strConn)
        {
            IDBHelper dbHelper = GetDbHelper(dbType, strConn); 
            string strSql = string.Empty;
            switch (dbType)
            {
                case SqlType.SqlServer:
                    strSql = "SELECT   表名= case when a.colorder=1 then d.name else '' end,  表说明= case when a.colorder=1 then isnull(f.value,'') else '' end,  字段序号= a.colorder,  字段名 = a.name,   标识= case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then '√'else '' end,  主键 = case when exists(SELECT 1 FROM sysobjects where xtype='PK' and parent_obj=a.id and name in (SELECT name	  FROM sysindexes WHERE indid in( SELECT indid FROM sysindexkeys WHERE id = a.id AND colid=a.colid))) then '√'	   else '' end,    类型  = b.name, 占用字节数 = a.length,  长度= COLUMNPROPERTY(a.id,a.name,'PRECISION'),   小数位数= isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0), 允许空= case when a.isnullable=1 then '√'else '' end,  默认值= isnull(e.text,''),  字段说明= isnull(g.[value],'') FROM  syscolumns a left join  systypes b  on  a.xusertype=b.xusertype 	inner join sysobjects d on  a.id=d.id  and d.xtype='U' and  d.name<>'dtproperties'  and d.name<>'sysdiagrams' 	left join  syscomments e  on  a.cdefault=e.id left join  	sys.extended_properties   g  on a.id=G.major_id and a.colid=g.minor_id   left join  sys.extended_properties f on  d.id=f.major_id and f.minor_id=0  	order by  a.id,a.colorder ";
                    break;
            }
            dbHelper.CreateCommand(strSql);
            return dbHelper.ExecuteQuery();
        }

        ///  <summary>获取数据库帮助类
        /// 
        ///  </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="strConn">数据库连接字符串</param>
        ///  <returns>数据库帮助类</returns>
        public static IDBHelper GetDbHelper(SqlType dbType, string strConn)
        {
            IDBHelper dbHelper = null;
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

        /// <summary>获取数据库下的表/视图/存储过程/函数 的名称，内容，类型等信息表
        /// 获取数据库下的表/视图/存储过程/函数 的名称，内容，类型等信息表
        /// </summary>
        /// <param name="dbType">dbType</param>
        /// <param name="strConn">strConn</param>
        /// <param name="strDbName">strDBName</param>
        /// <param name="objType">objType</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDbObject(SqlType dbType, string strConn, string strDbName, DatabaseObjectType objType)
        {
            IDBHelper dbHelper = GetDbHelper(dbType, strConn);
            string strSql = string.Empty;
            switch (dbType)
            {
                case SqlType.SqlServer:
                    strSql = GetSqlServerObjectSql(strDbName, objType);
                    break;

                case SqlType.MySql:
                    break;

                case SqlType.Oracle:
                    break;
            }
            dbHelper.CreateCommand(strSql);
            return dbHelper.ExecuteQuery();
        }

        /// <summary>根据对象表，生成所有删除对象脚本
        /// 根据对象表，生成所有删除对象脚本
        /// </summary>
        /// <param name="dbType">dbType</param>
        /// <param name="strConn">strConn</param>
        /// <param name="strDbName">strDBName</param>
        /// <param name="objType">objType</param>
        /// <returns>删除对象脚本</returns>
        public static string GetDropObjectScripts(SqlType dbType, string strConn, string strDbName, DatabaseObjectType objType)
        {
            string strSqlScripts = string.Empty;
            //IDBHelper dbHelper = GetDBHelper(dbType, strConn);
            switch (dbType)
            {
                case SqlType.SqlServer:
                    //dt包含字段Type，Type的内容是对象类型：Function、Table等
                    var dtObjects = GetDbObject(dbType, strConn, strDbName, objType);
                    strSqlScripts = GenDropObjectScripts(dtObjects);
                    break;

                case SqlType.MySql:
                    break;

                case SqlType.Oracle:
                    break;
            }
            return strSqlScripts;
        }

        /// <summary>判断数据库对象是否存在
        /// 判断数据库对象是否存在
        /// </summary>
        /// <param name="dbType">dbType</param>
        /// <param name="strConn">strConn</param>
        /// <param name="strObjectName">strObjectName</param>
        /// <returns>true:存在，false:不存在</returns>
        public static bool DbObjectExists(SqlType dbType, string strConn, string strObjectName)
        {
            bool flag = false;
            string strSql = string.Empty;
            IDBHelper dbHelper = GetDbHelper(dbType, strConn);
            switch (dbType)
            {
                case SqlType.SqlServer:
                    strSql = string.Format("SELECT 1 FROM sys.objects WHERE object_id=OBJECT_ID('{0}')", strObjectName);
                    break;

                case SqlType.MySql:
                    break;

                case SqlType.Oracle:
                    break;
            }
            if (strSql != string.Empty)
            {
                dbHelper.CreateCommand(strSql);
                flag = !string.IsNullOrEmpty(dbHelper.ExecuteScalar());
            }
            return flag;
        }

        private static string GenCreateDatabase4SqlServer(string strDbName, string strPath)
        {
            string strData = strDbName + "_data";
            string strMdf = strData + ".mdf";
            string strLdf = strPath + "\\" + strDbName + "_log.ldf";
            string strLogName = strDbName + "_log";
            string strpath = strPath + "\\" + strMdf;
            string strSql = @"    create database " + strDbName + "  on  primary  (  name='" + strData + "',    filename='" + strpath + "',    size=7168KB,     maxsize=UNLIMITED,  filegrowth=15% ) log on(    name='" + strLogName + "',     filename='" + strLdf + "',   size=2mb,   filegrowth=1mb)";
            return strSql;
        }

        /// <summary> 根据对象表，生成所有删除对象脚本
        /// 根据对象表，生成所有删除对象脚本
        /// </summary>
        /// <param name="dtObjects">dtObjects</param>
        /// <returns>删除对象脚本</returns>
        private static string GenDropObjectScripts(DataTable dtObjects)
        {
            StringBuilder sbSqlScripts = new StringBuilder();
            foreach (DataRow drObj in dtObjects.Rows)
            {
                sbSqlScripts.AppendLine("DROP " + drObj["Type"] + " " + drObj["name"]);
            }
            return sbSqlScripts.ToString();
        }

        /// <summary>根据DatabaseObjectType获取某个数据库下所有sqlServer数据库查询对象信息语句
        /// 根据DatabaseObjectType获取某个数据库下所有sqlServer数据库查询对象信息语句
        /// </summary>
        /// <param name="strDbName">strDBName</param>
        /// <param name="objType">objType</param>
        /// <returns>返回查询表/视图/存储过程/函数等信息的语句</returns>
        private static string GetSqlServerObjectSql(string strDbName, DatabaseObjectType objType)
        {
            string strSql = string.Empty;
            switch (objType)
            {
                case DatabaseObjectType.Table:
                    strSql = " USE [" + strDbName + "] SELECT '" + strDbName + "' as DBName,   name , 'Table' as Type  FROM  dbo.sysobjects where OBJECTPROPERTY(id, N'IsUserTable') = 1  ORDER BY Name   ";
                    break;

                case DatabaseObjectType.Procedure:
                    strSql = " USE [" + strDbName + "] SELECT  '" + strDbName + "' as DBName, Name ,object_definition(OBJECT_ID) AS ObjectContent,'PROCEDURE' as Type FROM sys.procedures ORDER BY NAME ";
                    break;

                case DatabaseObjectType.View:
                    strSql = " USE [" + strDbName + "]  SELECT '" + strDbName + "' as DBName,  Name ,object_definition(OBJECT_ID) AS ObjectContent,'VIEW' as Type FROM sys.views ORDER BY Name      ";
                    break;

                case DatabaseObjectType.Function:
                    strSql = " USE [" + strDbName + "]  SELECT '" + strDbName + "' as DBName,name , object_definition(ID) AS ObjectContent,'FUNCTION' as Type FROM sysobjects WHERE [type] IN (N'FN', N'IF', N'TF', N'FS', N'FT') AND category = 0  ORDER BY name    ";
                    break;

                case DatabaseObjectType.Trigger:
                    strSql = " USE [" + strDbName + "]  SELECT '" + strDbName + "' as DBName, NAME ,object_definition(ID) AS  ObjectContent, 'TRIGGER' AS Type FROM sysobjects WHERE TYPE='TR' ORDER BY Name    ";
                    break;
            }
            return strSql;
        }

        /// <summary>根据DatabaseObjectType获取某个服务器下所有sqlServer数据库查询对象信息语句
        ///根据DatabaseObjectType获取某个服务器下所有sqlServer数据库查询对象信息语句
        /// </summary>
        /// <param name="dtDbNames"></param>
        /// <param name="objType"></param>
        /// <returns>返回查询表/视图/存储过程/函数等信息的语句</returns>
        private static string GetSqlServerObjectSqls(DataTable dtDbNames, DatabaseObjectType objType)
        {
            string strSql = string.Empty;
            switch (objType)
            {
                case DatabaseObjectType.Table:
                    foreach (DataRow dr in dtDbNames.Rows)
                    {
                        string strDbName = dr[0].ToString();
                        strSql += " USE [" + strDbName + "]  SELECT  '" + strDbName + "' as DBName,  name  , 'Table' as Type   FROM  dbo.sysobjects where OBJECTPROPERTY(id, N'IsUserTable') = 1 ORDER BY Name    ";
                    }
                    break;

                case DatabaseObjectType.Procedure:
                    foreach (DataRow dr in dtDbNames.Rows)
                    {
                        string strDbName = dr[0].ToString();
                        strSql += " USE [" + strDbName + "] SELECT  '" + strDbName + "' as DBName, Name ,object_definition(OBJECT_ID) AS ObjectContent,'PROCEDURE' as Type FROM sys.procedures ORDER BY NAME ";
                    }
                    break;

                case DatabaseObjectType.View:
                    foreach (DataRow dr in dtDbNames.Rows)
                    {
                        string strDbName = dr[0].ToString();
                        strSql += " USE [" + strDbName + "]  SELECT '" + strDbName + "' as DBName,  Name ,object_definition(OBJECT_ID) AS ObjectContent ,'VIEW' AS Type  FROM sys.views ORDER BY Name      ";
                    }
                    break;

                case DatabaseObjectType.Function:
                    foreach (DataRow dr in dtDbNames.Rows)
                    {
                        string strDbName = dr[0].ToString();
                        strSql += " USE [" + strDbName + "]  SELECT '" + strDbName + "' as DBName, NAME ,object_definition(ID) AS  ObjectContent, 'TRIGGER' AS Type FROM sysobjects WHERE TYPE='TR' ORDER BY Name    ";
                    }
                    break;
            }
            return strSql;
        }

        #region 获取数据库对象名称、内容、类型

        public static DataSet GetAllFunctions(SqlType dbType, string strConn, DataTable dtDbNames)
        {
            IDBHelper dbHelper = GetDbHelper(dbType, strConn);
            string strSql = string.Empty;
            switch (dbType)
            {
                case SqlType.SqlServer:
                    foreach (DataRow dr in dtDbNames.Rows)
                    {
                        string strDbName = dr[0].ToString();
                        strSql += " USE [" + strDbName + "]  SELECT '" + strDbName + "' as DBName,name , object_definition(ID) AS ObjectContent,'FUNCTION' as Type FROM sysobjects WHERE [type] IN (N'FN', N'IF', N'TF', N'FS', N'FT') AND category = 0  ORDER BY name    ";
                    }
                    break;

                case SqlType.MySql:
                    break;

                case SqlType.Oracle:
                    break;
            }
            dbHelper.CreateCommand(strSql);
            return dbHelper.ExecuteQueryDataSet();
        }

        public static DataSet GetAllProcs(SqlType dbType, string strConn, DataTable dtDbNames)
        {
            IDBHelper dbHelper = GetDbHelper(dbType, strConn);
            string strSql = string.Empty;
            switch (dbType)
            {
                case SqlType.SqlServer:
                    foreach (DataRow dr in dtDbNames.Rows)
                    {
                        string strDbName = dr[0].ToString();
                        //strSql += " USE [" + strDBName + "]  SELECT  '" + strDBName + "' as DBName,  name     FROM  dbo.sysobjects where OBJECTPROPERTY(id, N'IsProcedure') = 1    ";
                        strSql += " USE [" + strDbName + "] SELECT  '" + strDbName + "' as DBName, Name ,object_definition(OBJECT_ID) AS ObjectContent,'PROCEDURE' as Type FROM sys.procedures ORDER BY NAME ";
                    }
                    break;

                case SqlType.MySql:
                    break;

                case SqlType.Oracle:
                    break;
            }
            dbHelper.CreateCommand(strSql);
            return dbHelper.ExecuteQueryDataSet();
        }

        public static DataSet GetAllTables(SqlType dbType, string strConn, DataTable dtDbNames)
        {
            IDBHelper dbHelper = GetDbHelper(dbType, strConn);
            string strSql = string.Empty;
            switch (dbType)
            {
                case SqlType.SqlServer:
                    foreach (DataRow dr in dtDbNames.Rows)
                    {
                        string strDbName = dr[0].ToString();
                        strSql += " USE [" + strDbName + "]  SELECT  '" + strDbName + "' as DBName,  name  ,'Table' as Type   FROM  dbo.sysobjects where OBJECTPROPERTY(id, N'IsUserTable') = 1 ORDER BY Name    ";
                    }
                    break;

                case SqlType.MySql:
                    break;

                case SqlType.Oracle:
                    break;
            }
            dbHelper.CreateCommand(strSql);
            return dbHelper.ExecuteQueryDataSet();
        }

        public static DataSet GetAllTriggers(SqlType dbType, string strConn, DataTable dtDbNames)
        {
            IDBHelper dbHelper = GetDbHelper(dbType, strConn);
            string strSql = string.Empty;
            switch (dbType)
            {
                case SqlType.SqlServer:
                    foreach (DataRow dr in dtDbNames.Rows)
                    {
                        string strDbName = dr[0].ToString();
                        strSql += " USE [" + strDbName + "]  SELECT '" + strDbName + "' as DBName, NAME ,object_definition(ID) AS  ObjectContent, 'TRIGGER' AS Type FROM sysobjects WHERE TYPE='TR' ORDER BY Name    ";
                    }
                    break;

                case SqlType.MySql:
                    break;

                case SqlType.Oracle:
                    break;
            }
            dbHelper.CreateCommand(strSql);
            return dbHelper.ExecuteQueryDataSet();
        }

        public static DataSet GetAllViews(SqlType dbType, string strConn, DataTable dtDbNames)
        {
            IDBHelper dbHelper = GetDbHelper(dbType, strConn);
            string strSql = string.Empty;
            switch (dbType)
            {
                case SqlType.SqlServer:
                    foreach (DataRow dr in dtDbNames.Rows)
                    {
                        string strDbName = dr[0].ToString();
                        //strSql += " USE [" + strDBName + "]  SELECT  '" + strDBName + "' as DBName,  name     FROM  dbo.sysobjects where OBJECTPROPERTY(id, N'IsView') = 1    ";
                        strSql += " USE [" + strDbName + "]  SELECT '" + strDbName + "' as DBName,  Name ,object_definition(OBJECT_ID) AS ObjectContent ,'VIEW' AS Type  FROM sys.views ORDER BY Name      ";
                    }
                    break;

                case SqlType.MySql:
                    break;

                case SqlType.Oracle:
                    break;
            }
            dbHelper.CreateCommand(strSql);
            return dbHelper.ExecuteQueryDataSet();
        }

        public static DataTable GetFunctions(SqlType dbType, string strConn, string strDbName)
        {
            IDBHelper dbHelper = GetDbHelper(dbType, strConn);
            string strSql = string.Empty;
            switch (dbType)
            {
                case SqlType.SqlServer:
                    strSql = " USE [" + strDbName + "]  SELECT '" + strDbName + "' as DBName,name , object_definition(ID) AS ObjectContent,'FUNCTION' as Type FROM sysobjects WHERE [type] IN (N'FN', N'IF', N'TF', N'FS', N'FT') AND category = 0  ORDER BY name    ";
                    break;

                case SqlType.MySql:
                    break;

                case SqlType.Oracle:
                    break;
            }
            dbHelper.CreateCommand(strSql);
            return dbHelper.ExecuteQuery();
        }

        public static DataTable GetProcs(SqlType dbType, string strConn, string strDbName)
        {
            IDBHelper dbHelper = GetDbHelper(dbType, strConn);
            string strSql = string.Empty;
            switch (dbType)
            {
                case SqlType.SqlServer:
                    //strSql = " USE [" + strDBName + "]  SELECT  '" + strDBName + "' as DBName,  name     FROM  dbo.sysobjects where OBJECTPROPERTY(id, N'IsProcedure') = 1    ";
                    strSql = " USE [" + strDbName + "] SELECT  '" + strDbName + "' as DBName, Name ,object_definition(OBJECT_ID) AS ObjectContent,'PROCEDURE' as Type FROM sys.procedures ORDER BY NAME ";
                    break;

                case SqlType.MySql:
                    break;

                case SqlType.Oracle:
                    break;
            }
            dbHelper.CreateCommand(strSql);
            return dbHelper.ExecuteQuery();
        }

        public static DataTable GetTables(SqlType dbType, string strConn, string strDbName)
        {
            IDBHelper dbHelper = GetDbHelper(dbType, strConn);
            string strSql = string.Empty;
            switch (dbType)
            {
                case SqlType.SqlServer:
                    strSql = " USE [" + strDbName + "] SELECT   '" + strDbName + "' as DBName,   name , 'Table' as Type  FROM  dbo.sysobjects where OBJECTPROPERTY(id, N'IsUserTable') = 1  ORDER BY Name   ";
                    break;

                case SqlType.MySql:
                    break;

                case SqlType.Oracle:
                    break;
            }
            dbHelper.CreateCommand(strSql);
            return dbHelper.ExecuteQuery();
        }

        public static DataTable GetTriggerss(SqlType dbType, string strConn, string strDbName)
        {
            IDBHelper dbHelper = GetDbHelper(dbType, strConn);
            string strSql = string.Empty;
            switch (dbType)
            {
                case SqlType.SqlServer:
                    strSql = " USE [" + strDbName + "]  SELECT '" + strDbName + "' as DBName NAME ,object_definition(ID) AS  ObjectContent, 'TRIGGER' AS Type FROM sysobjects WHERE TYPE='TR' ORDER BY Name  ";
                    break;

                case SqlType.MySql:
                    break;

                case SqlType.Oracle:
                    break;
            }
            dbHelper.CreateCommand(strSql);
            return dbHelper.ExecuteQuery();
        }

        public static DataTable GetViews(SqlType dbType, string strConn, string strDbName)
        {
            IDBHelper dbHelper = GetDbHelper(dbType, strConn);
            string strSql = string.Empty;
            switch (dbType)
            {
                case SqlType.SqlServer:
                    //strSql = " USE [" + strDBName + "] SELECT  *  FROM  dbo.sysobjects where OBJECTPROPERTY(id, N'IsView') = 1    ";
                    strSql = " USE [" + strDbName + "]  SELECT '" + strDbName + "' as DBName,  Name ,object_definition(OBJECT_ID) AS ObjectContent,'VIEW' as Type FROM sys.views ORDER BY Name      ";
                    break;

                case SqlType.MySql:
                    break;

                case SqlType.Oracle:
                    break;
            }
            dbHelper.CreateCommand(strSql);
            return dbHelper.ExecuteQuery();
        }

        #endregion 获取数据库对象名称、内容、类型
    }
}