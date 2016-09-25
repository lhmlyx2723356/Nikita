using Nikita.Base.Define;
using System;

namespace Nikita.DataAccess.Expression2Sql
{
    public class DbContext
    {
        public SqlType SqlType { get; set; }

        public string ConnectionString { get; set; }

        public IExpressionToSql ExpressionToSql { get; private set; }

        public DbContext(SqlType SqlType, string strConnectionString)
        {
            this.SqlType = SqlType;
            this.ConnectionString = strConnectionString;
            switch (this.SqlType)
            {
                case SqlType.SqlServer:
                    ExpressionToSql = new ExpressionToSqlSQLServer(this);
                    break;

                case SqlType.Oracle:
                    ExpressionToSql = new ExpressionToSqlOracle(this);
                    break;

                case SqlType.MySql:
                    ExpressionToSql = new ExpressionToSqlMySQL(this);
                    break;

                case SqlType.SQLite:
                    ExpressionToSql = new ExpressionToSqlSQLite(this);
                    break;

                case SqlType.SqlServerCe:
                case SqlType.PostgreSql:
                case SqlType.Db2:
                case SqlType.Accesss:
                    throw new Exception("暂不支持此类型数据库");
            }
        }
    }
}