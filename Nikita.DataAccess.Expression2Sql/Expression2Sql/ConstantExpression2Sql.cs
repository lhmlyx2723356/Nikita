using System.Linq.Expressions;

namespace Nikita.DataAccess.Expression2Sql
{
    internal class ConstantExpression2Sql : BaseExpression2Sql<ConstantExpression>
    {
        protected override SqlBuilder In(ConstantExpression expression, SqlBuilder sqlBuilder)
        {
            if (expression.Type.Name == "String")
            {
                sqlBuilder.AppendFormat("'{0}',", expression.Value);
            }
            else
            {
                sqlBuilder.AppendFormat("{0},", expression.Value);
            }
            return sqlBuilder;
        }

        protected override SqlBuilder Where(ConstantExpression expression, SqlBuilder sqlBuilder)
        {
            sqlBuilder.AddDbParameter(expression.Value);
            return sqlBuilder;
        }
    }
}