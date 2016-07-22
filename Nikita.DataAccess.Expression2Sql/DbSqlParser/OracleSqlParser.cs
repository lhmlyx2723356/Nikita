namespace Nikita.DataAccess.Expression2Sql
{
    public class OracleSqlParser : IDbSqlParser
    {
        public string DbParamPrefix
        {
            get
            {
                return ":";
            }
        }
    }
}