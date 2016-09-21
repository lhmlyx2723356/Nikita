using System;
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

        //protected override SqlBuilder Take(ConstantExpression expression, SqlBuilder sqlBuilder)
        //{
        //    int intOutTakeNum;
        //    if (int.TryParse(expression.Value.ToString(), out intOutTakeNum) == false)
        //    {
        //        throw new Exception("Take 方法输入数字有误");
        //    }
        //    int intStart = sqlBuilder.Sql.IndexOf("select", StringComparison.Ordinal);
        //    sqlBuilder.Insert(intStart + 6, " top " + intOutTakeNum + " ");
        //    return sqlBuilder;
        //}

        protected override SqlBuilder First(ConstantExpression expression, SqlBuilder sqlBuilder)
        {
            int intOutTakeNum;
            if (int.TryParse(expression.Value.ToString(), out intOutTakeNum) == false)
            {
                throw new Exception("First 方法输入数字有误");
            }
            int intStart = sqlBuilder.Sql.IndexOf("select", StringComparison.Ordinal);
            sqlBuilder.Insert(intStart + 6, " top " + intOutTakeNum + " ");
            return sqlBuilder;
        }

        protected override SqlBuilder Where(ConstantExpression expression, SqlBuilder sqlBuilder)
        {
            if (sqlBuilder.AllowAppendEmpty == false)
            {
                sqlBuilder.AddDbParameter(expression.Value, false);
                return sqlBuilder;
            }
            sqlBuilder.AddDbParameter(expression.Value, true);
            return sqlBuilder;
        }
    }
}