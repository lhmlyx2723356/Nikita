using System.Linq.Expressions;

namespace Nikita.DataAccess.Expression2Sql
{
    public interface IExpression2Sql
    {
        SqlBuilder Avg(Expression expression, SqlBuilder sqlBuilder);

        SqlBuilder Count(Expression expression, SqlBuilder sqlBuilder);

        SqlBuilder GroupBy(Expression expression, SqlBuilder sqlBuilder);

        SqlBuilder In(Expression expression, SqlBuilder sqlBuilder);

        SqlBuilder Insert(Expression expression, SqlBuilder sqlBuilder);

        SqlBuilder Join(Expression expression, SqlBuilder sqlBuilder);

        SqlBuilder Max(Expression expression, SqlBuilder sqlBuilder);

        SqlBuilder Min(Expression expression, SqlBuilder sqlBuilder);

        SqlBuilder OrderBy(Expression expression, SqlBuilder sqlBuilder);

        SqlBuilder Select(Expression expression, SqlBuilder sqlBuilder);

        SqlBuilder Sum(Expression expression, SqlBuilder sqlBuilder);

        SqlBuilder Update(Expression expression, SqlBuilder sqlBuilder);

        SqlBuilder Where(Expression expression, SqlBuilder sqlBuilder);
    }
}