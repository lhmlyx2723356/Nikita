using Nikita.Base.DbSchemaReader;
using Nikita.Base.DbSchemaReader.CodeGen;
using Nikita.Base.DbSchemaReader.CodeGen.Procedures;
using Nikita.Base.DbSchemaReader.Data;
using Nikita.Base.DbSchemaReader.DataSchema;
using Nikita.Base.DbSchemaReader.SqlGen;
using Nikita.Base.DbSchemaReader.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Nikita.Assist.DBManager
{
    /// <summary>
    /// 方法集合
    /// </summary>
    public class SqlTasks
    {
        private readonly IDictionary<string, string> m_mapping = new Dictionary<string, string>();
        private readonly IMigrationGenerator m_migrationGenerator;
        private readonly SqlType m_sqlType;

        public SqlTasks(SqlType sqlType)
        {
            m_sqlType = sqlType;
            m_migrationGenerator = new DdlGeneratorFactory(sqlType).MigrationGenerator();
            if (m_mapping.Count == 0)
            {
                InitMapping();
            }
        }

        /// <summary>修改列类型、默认值、是否为NULL等
        /// 修改列类型、默认值、是否为NULL等
        /// </summary>
        /// <param name="table"></param>
        /// <param name="databaseColumn"></param>
        /// <param name="originalColumn"></param>
        /// <returns></returns>
        public string AlterColumn(DatabaseTable table, DatabaseColumn databaseColumn, DatabaseColumn originalColumn)
        {
            return m_migrationGenerator.AlterColumn(table, databaseColumn, originalColumn);
        }

        public string BuildAddColumn(DatabaseColumn column)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append(m_migrationGenerator.AddColumn(column.Table, column));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string BuildAddConstraint(DatabaseTable databaseTable, DatabaseConstraint constraint)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append(m_migrationGenerator.AddConstraint(databaseTable, constraint));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string BuildAddIndex(DatabaseTable databaseTable, DatabaseIndex index)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append(m_migrationGenerator.AddIndex(databaseTable, index));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string BuildAddTrigger(DatabaseTable databaseTable, DatabaseTrigger trigger)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append(m_migrationGenerator.AddTrigger(databaseTable, trigger));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string BuildAllTableDdl(DatabaseSchema databaseSchema)
        {
            string strSql = string.Empty;
            var tg = new DdlGeneratorFactory(m_sqlType).AllTablesGenerator(databaseSchema);
            tg.IncludeSchema = false;
            try
            {
                strSql = tg.Write();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return strSql;
        }

        public string BuildAlterColumn(DatabaseColumn column)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append(m_migrationGenerator.AlterColumn(column.Table, column, null));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string BuildClass(DatabaseTable databaseTable)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                var cw = new ClassWriter(databaseTable, new CodeWriterSettings());
                sb.Append(cw.Write());
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string BuildDropAllTable(DatabaseSchema databaseSchema)
        {
            StringBuilder sb = new StringBuilder();

            return sb.ToString();
        }

        public string BuildDropConstraint(DatabaseTable databaseTable, DatabaseConstraint constraint)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append(m_migrationGenerator.DropConstraint(databaseTable, constraint));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string BuildDropIndex(DatabaseTable databaseTable, DatabaseIndex index)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append(m_migrationGenerator.DropIndex(databaseTable, index));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string BuildDropTable(DatabaseTable table)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.AppendLine(m_migrationGenerator.DropTable(table));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string BuildDropTrigger(DatabaseTrigger trigger)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append(m_migrationGenerator.DropTrigger(trigger));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string BuildFunction(DatabaseFunction databaseFunction)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.AppendLine(m_migrationGenerator.AddFunction(databaseFunction));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string BuildPackage(DatabasePackage package)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append(m_migrationGenerator.AddPackage(package));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string BuildProcedure(DatabaseStoredProcedure storedProcedure)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.AppendLine(m_migrationGenerator.AddProcedure(storedProcedure));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string BuildProcedureCode(DatabaseSchema databaseSchema, DatabaseStoredProcedure databaseStoredProcedure)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                if (databaseStoredProcedure.ResultSets.Count == 0)
                {
                    var sprocRunner = new Nikita.Base.DbSchemaReader.Procedures.ResultSetReader(databaseSchema);
                    sprocRunner.ExecuteProcedure(databaseStoredProcedure);
                }

                var sprocWriter = new ProcedureWriter(databaseStoredProcedure, "Domain");
                sb.Append(sprocWriter.Write());
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string BuildTableDdl(DatabaseTable databaseTable)
        {
            StringBuilder sb = new StringBuilder();
            var tg = new DdlGeneratorFactory(m_sqlType).TableGenerator(databaseTable);

            tg.IncludeSchema = false;
            try
            {
                sb.AppendLine(tg.Write());
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string BuildTableDelete(DatabaseTable databaseTable)
        {
            StringBuilder sb = new StringBuilder();
            var sqlWriter = new SqlWriter(databaseTable, m_sqlType);
            try
            {
                sb.Append(sqlWriter.DeleteSql());
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string BuildTableInsert(DatabaseTable databaseTable)
        {
            StringBuilder sb = new StringBuilder();
            var sqlWriter = new SqlWriter(databaseTable, m_sqlType);
            try
            {
                sb.Append(sqlWriter.InsertSqlWithoutOutputParameter());
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string BuildTableSelect(DatabaseTable databaseTable)
        {
            StringBuilder sb = new StringBuilder();
            var sqlWriter = new SqlWriter(databaseTable, m_sqlType);
            try
            {
                sb.AppendLine(sqlWriter.SelectAllSql());
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string BuildTableSelectPaged(DatabaseTable databaseTable)
        {
            StringBuilder sb = new StringBuilder();
            var sqlWriter = new SqlWriter(databaseTable, m_sqlType);
            try
            {
                sb.Append(sqlWriter.SelectPageSql());
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string BuildTableUpdate(DatabaseTable databaseTable)
        {
            StringBuilder sb = new StringBuilder();
            var sqlWriter = new SqlWriter(databaseTable, m_sqlType);
            try
            {
                sb.Append(sqlWriter.UpdateSql());
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string BuildView(DatabaseView view)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append(m_migrationGenerator.AddView(view));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public string DeleteAllData(DatabaseSchema databaseSchema)
        {
            var sb = new StringBuilder();
            try
            {
                var orderedTables = SchemaTablesSorter.TopologicalSort(databaseSchema).Reverse();
                sb.AppendLine("-- 删除所有表的数据");
                foreach (var databaseTable in orderedTables)
                {
                    if (databaseTable.ForeignKeyChildren.Contains(databaseTable))
                    {
                        sb.AppendLine("-- 警告: " + databaseTable.Name + "有主外键关联");
                    }
                    var sqlWriter = new SqlWriter(databaseTable, m_sqlType);
                    sb.AppendLine("DELETE FROM " + sqlWriter.EscapedTableName);
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        public DataTable GenDataTable(DatabaseTable table, string strServer, string strDbName, string strTableHistoryName, string strTableDescription)
        {
            DataTable dt = new DataTable();
            if (table == null)
            {
                return dt;
            }
            else
            {
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("ServerName", typeof(string));
                dt.Columns.Add("DatabaseName", typeof(string));
                dt.Columns.Add("TableName", typeof(string));
                dt.Columns.Add("TableRemark", typeof(string));
                dt.Columns.Add("TableHistoryName", typeof(string));
                dt.Columns.Add("ColumnName", typeof(string));
                dt.Columns.Add("ColumnIdentity", typeof(string));
                dt.Columns.Add("ColumnPK", typeof(string));
                dt.Columns.Add("ColumnType", typeof(string));
                dt.Columns.Add("ColumnSpace", typeof(string));
                dt.Columns.Add("ColumnLength", typeof(string));
                dt.Columns.Add("ColumnScale", typeof(string));
                dt.Columns.Add("ColumnAllowNull", typeof(string));
                dt.Columns.Add("ColumnDefaultValue", typeof(string));
                dt.Columns.Add("ColumnRemark", typeof(string));
                dt.Columns.Add("ColumnHistory", typeof(string));
                int intIndex = 0;
                foreach (DatabaseColumn column in table.Columns)
                {
                    DataRow dr = dt.NewRow();
                    dr["id"] = intIndex + 1;
                    dr["ServerName"] = strServer;
                    dr["DatabaseName"] = strDbName;
                    dr["TableName"] = table.Name;
                    dr["TableHistoryName"] = strTableHistoryName;
                    dr["TableRemark"] = strTableDescription;
                    dr["ColumnName"] = column.Name;
                    dr["ColumnIdentity"] = column.IsAutoNumber;
                    dr["ColumnPK"] = column.IsPrimaryKey;
                    dr["ColumnType"] = GetDbType(column);
                    dr["ColumnLength"] = column.Length;
                    dr["ColumnScale"] = column.Scale;
                    dr["ColumnAllowNull"] = column.Nullable;
                    dr["ColumnDefaultValue"] = column.DefaultValue;
                    dr["ColumnRemark"] = column.Description;
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        public string GetData(DatabaseTable databaseTable, string connectionString, string providerName)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                var sw = new ScriptWriter();
                sw.IncludeBlobs = false;
                sw.IncludeIdentity = true;
                sw.PageSize = 10000;
                sb.Append(sw.ReadTable(databaseTable, connectionString, providerName));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            return sb.ToString();
        }

        /// <summary>初始化数据类型
        /// 初始化数据类型
        /// </summary>
        /// <returns></returns>
        public DataTable InitDataTypeDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeName", typeof(string));
            //string[] strDataTypeArray = new string[] { "bigint", "binary(50)", "bit", "char(10)", "date", "datetime", "datetime2(7)", "datetimeoffset(7)", "decimal(18,0)", "float", "geography", "geometry", "hierarchyid", "image", "int", "money", "nchar(10)", "ntext", "numberic(18,0)", "nvarchar(50)", "nvarchar(MAX)", "real", "smalldatetime", "smallint", "smallmoney", "sql_variant", "text", "time(7)", "timestamp", "tinyint", "uniqueidentifier", "varbinary(50)", "varbinary(Max)", "varchar(50)", "varchar(MAX)", "xml" };
            //去除不常用数据类型
            string[] strDataTypeArray = new string[] { "int", "bigint", "tinyint", "varchar(50)", "datetime", "decimal(18,0)", "bit", "date", "float", "image", "money", "nchar(10)", "numberic(18,0)", "nvarchar(50)", "nvarchar(MAX)", "smalldatetime", "smallint", "text", "timestamp", "varchar(MAX)" };
            foreach (var item in strDataTypeArray)
            {
                DataRow dr = dt.NewRow();
                dr[0] = item;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>重命名列
        /// 重命名列
        /// </summary>
        /// <param name="table"></param>
        /// <param name="databaseColumn"></param>
        /// <param name="originalColumn"></param>
        /// <returns></returns>
        public string RenameColumn(DatabaseTable table, DatabaseColumn databaseColumn, DatabaseColumn originalColumn)
        {
            return m_migrationGenerator.RenameColumn(originalColumn.Table, databaseColumn, originalColumn.Name);
        }

        /// <summary>重命名表
        /// 重命名表
        /// </summary>
        /// <param name="newTableName"></param>
        /// <param name="originalTableName"></param>
        /// <returns></returns>
        public string RenameTable(string newTableName, string originalTableName)
        {
            return m_migrationGenerator.RenameTable(newTableName, originalTableName);
        }

        private string GetDbType(DatabaseColumn column)
        {
            if (m_mapping.ContainsKey(column.DbDataType.ToUpper()))
            {
                return m_mapping[column.DbDataType.ToUpper()].ToLower();
            }
            return column.DbDataType.ToLower();
        }

        private void InitMapping()
        {
            m_mapping.Add("CHAR", "CHAR(10)");
            m_mapping.Add("VARCHAR", "VARCHAR(50)");
            m_mapping.Add("VARBINARY", "VARBINARY(50)");
            m_mapping.Add("DECIMAL", "DECIMAL(18,0)");
            m_mapping.Add("NCHAR", "NCHAR(10)");
            m_mapping.Add("NVARCHAR", "NVARCHAR(50)");
        }
    }
}