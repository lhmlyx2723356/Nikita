using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nikita.Core;
using Nikita.DataAccess.Expression2Sql;
using Nikita.Base.Define;
using Nikita.DataAccess4DBHelper;
using Nikita.Core.Literacy;
using System.Data.Common;
using System.Data;

namespace Nikita.DataAccess.ORM
{
    public class DbContext
    {
        public SqlType SqlType { get; set; }

        public string ConnectionString { get; set; }


        private IDbHelper dbHelper;
        public IExpressionToSql ExpressionToSql { get; private set; }


        public DbContext(SqlType SqlType, string strConnectionString)
        {
            this.SqlType = SqlType;
            this.ConnectionString = strConnectionString;
            switch (this.SqlType)
            {
                case SqlType.SqlServer:
                    ExpressionToSql = new ExpressionToSqlSQLServer();
                    break;
                case SqlType.Oracle:
                    ExpressionToSql = new ExpressionToSqlOracle();
                    break;
                case SqlType.MySql:
                    ExpressionToSql = new ExpressionToSqlMySQL();
                    break;
                case SqlType.SQLite:
                    ExpressionToSql = new ExpressionToSqlSQLite();
                    break;
                case SqlType.SqlServerCe:
                case SqlType.PostgreSql:
                case SqlType.Db2:
                case SqlType.Accesss:
                    throw new Exception("暂不支持此类型数据库");
            }
            dbHelper = DbHelper.GetDbHelper(this.SqlType, this.ConnectionString);
        }

        public List<T> ToList<T>(ExpressionToSql<T> expresstionTosql)
        {
            if (dbHelper != null && expresstionTosql != null)
            {
                dbHelper.CreateCommand(expresstionTosql.Sql);
                foreach (var item in expresstionTosql.DbParams)
                {
                    dbHelper.AddParameter(item.Key, item.Value);
                }
                return Convert2.ToList<T>((DbDataReader)dbHelper.ExecuteReader());
            }
            return null;
        }

        public long ToLong<T>(ExpressionToSql<T> expresstionTosql)
        {
            if (dbHelper != null && expresstionTosql != null)
            {
                dbHelper.CreateCommand(expresstionTosql.Sql);
                foreach (var item in expresstionTosql.DbParams)
                {
                    dbHelper.AddParameter(item.Key, item.Value);
                }
                return Convert2.ToInt64(dbHelper.ExecuteScalar());
            }
            return 0;
        }

        public bool ToBool<T>(ExpressionToSql<T> expresstionTosql)
        {
            if (dbHelper != null && expresstionTosql != null)
            {
                dbHelper.CreateCommand(expresstionTosql.Sql);
                foreach (var item in expresstionTosql.DbParams)
                {
                    dbHelper.AddParameter(item.Key, item.Value);
                }
                return Convert2.ToBoolean(dbHelper.ExecuteNonQuery());
            }
            return false;
        }

        public DataTable ToDataTable<T>(ExpressionToSql<T> expresstionTosql)
        {
            if (dbHelper != null && expresstionTosql != null)
            {
                dbHelper.CreateCommand(expresstionTosql.Sql);
                foreach (var item in expresstionTosql.DbParams)
                {
                    dbHelper.AddParameter(item.Key, item.Value);
                }
                return dbHelper.ExecuteQuery();
            }
            return null;
        }

    }


}
