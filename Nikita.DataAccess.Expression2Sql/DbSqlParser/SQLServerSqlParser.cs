namespace Nikita.DataAccess.Expression2Sql
{
    public class SQLServerSqlParser : IDbSqlParser
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