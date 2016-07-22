using System.Linq.Expressions;

namespace Nikita.DataAccess.Expression2Sql
{
    internal class UnaryExpression2Sql : BaseExpression2Sql<UnaryExpression>
    {
        protected override SqlBuilder Avg(UnaryExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Avg(expression.Operand, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Count(UnaryExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Count(expression.Operand, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder GroupBy(UnaryExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.GroupBy(expression.Operand, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Max(UnaryExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Max(expression.Operand, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Min(UnaryExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Min(expression.Operand, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder OrderBy(UnaryExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.OrderBy(expression.Operand, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Select(UnaryExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Select(expression.Operand, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Sum(UnaryExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Sum(expression.Operand, sqlBuilder);
            return sqlBuilder;
        }

        protected override SqlBuilder Where(UnaryExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Where(expression.Operand, sqlBuilder);
            return sqlBuilder;
        }
    }
}