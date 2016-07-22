namespace Nikita.DataAccess.Expression2Sql
{
    public class SQLiteSqlParser : IDbSqlParser
    {
        public string DbParamPrefix
        {
            get
            {
                return "@";
            }
        }
    }
}