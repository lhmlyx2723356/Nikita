using System.Linq.Expressions;

namespace Nikita.DataAccess.Expression2Sql
{
    internal class ParameterExpression2Sql : BaseExpression2Sql<ParameterExpression>
    {
        protected override SqlBuilder Avg(ParameterExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Avg(expression, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Count(ParameterExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Count(expression, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder GroupBy(ParameterExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.GroupBy(expression, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Max(ParameterExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Max(expression, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Min(ParameterExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Min(expression, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder OrderBy(ParameterExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.OrderBy(expression, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Select(ParameterExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Select(expression, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Sum(ParameterExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Sum(expression, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Where(ParameterExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Where(expression, sqlBuilder);
            return sqlBuilder;
        }
    }
}