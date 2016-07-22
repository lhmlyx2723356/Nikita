namespace Nikita.DataAccess.Expression2Sql
{
    public class MySQLSqlParser : IDbSqlParser
    {
        public virtual string DbParamPrefix
        {
            get
            {
                return "?";
            }
        }
    }
}