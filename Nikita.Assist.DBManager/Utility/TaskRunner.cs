using Nikita.Base.DbSchemaReader.Data;
using Nikita.Base.DbSchemaReader.DataSchema;
using Nikita.Base.DbSchemaReader.SqlGen;
using System;
using System.IO;

namespace Nikita.Assist.DBManager
{
    internal class TaskRunner
    {
        private readonly DatabaseSchema _databaseSchema;

        public TaskRunner(DatabaseSchema databaseSchema)
        {
            _databaseSchema = databaseSchema;
        }

        public string Message { get; private set; }

        public bool RunData(DirectoryInfo directory, SqlType dialect, DatabaseTable table)
        {
            if (table == null)
            {
                Message = "未选择表";
                return false;
            }
            var path = Path.Combine(directory.FullName, table.Name + "_data.sql");
            try
            {
                var rdr = new Reader(table, table.DatabaseSchema.ConnectionString, table.DatabaseSchema.Provider);
                var dt = rdr.Read();

                var insertWriter = new InsertWriter(table, dt);
                if (dialect == SqlType.SqlServer || dialect == SqlType.SqlServerCe
                    || dialect == SqlType.SQLite
                    || dialect == SqlType.Db2 || dialect == SqlType.MySql)
                {
                    insertWriter.IncludeIdentity = true;
                }

                string txt = insertWriter.Write(dialect);

                File.WriteAllText(path, txt);
                Message = path;
                return true;
            }
            catch (Exception exception)
            {
                Message = exception.Message;
            }
            return false;
        }

        public bool RunSprocs(DirectoryInfo directory, SqlType dialect, DatabaseTable table)
        {
            if (table == null)
            {
                Message = "未选择表";
                return false;
            }

            var gen = new DdlGeneratorFactory(dialect).ProcedureGenerator(table);
            if (gen == null)
            {
                Message = @"SQLite不支持存储过程";
                return false;
            }
            var path = Path.Combine(directory.FullName, table.Name + "_sprocs.sql");
            try
            {
                gen.WriteToScript(path);
                Message = path;
                return true;
            }
            catch (Exception exception)
            {
                Message = exception.Message;
            }
            return false;
        }

        public bool RunTableDdl(DirectoryInfo directory, SqlType dialect)
        {
            var tg = new DdlGeneratorFactory(dialect).AllTablesGenerator(_databaseSchema);
            tg.IncludeSchema = false;
            string txt;
            try
            {
                txt = tg.Write();
            }
            catch (Exception exception)
            {
                Message = exception.Message;
                return false;
            }
            try
            {
                var path = Path.Combine(directory.FullName, dialect.ToString() + "_table.sql");
                File.WriteAllText(path, txt);
                return true;
            }
            catch (Exception exception)
            {
                Message = exception.Message;
            }
            return false;
        }
    }
}