using System.Linq.Expressions;

namespace Nikita.DataAccess.Expression2Sql
{
    internal class NewArrayExpression2Sql : BaseExpression2Sql<NewArrayExpression>
    {
        protected override SqlBuilder In(NewArrayExpression expression, SqlBuilder sqlBuilder)
        {
            sqlBuilder += "(";

            foreach (Expression expressionItem in expression.Expressions)
            {
                Expression2SqlProvider.In(expressionItem, sqlBuilder);
            }

            if (sqlBuilder[sqlBuilder.Length - 1] == ',')
            {
                sqlBuilder.Remove(sqlBuilder.Length - 1, 1);
            }

            sqlBuilder += ")";

            return sqlBuilder;
        }
    }
}