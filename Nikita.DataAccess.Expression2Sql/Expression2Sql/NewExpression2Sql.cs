using System.Linq.Expressions;
using System.Reflection;

namespace Nikita.DataAccess.Expression2Sql
{
    internal class NewExpression2Sql : BaseExpression2Sql<NewExpression>
    {
        protected override SqlBuilder GroupBy(NewExpression expression, SqlBuilder sqlBuilder)
        {
            foreach (Expression item in expression.Arguments)
            {
                Expression2SqlProvider.GroupBy(item, sqlBuilder);
            }
            return sqlBuilder;
        }

        protected override SqlBuilder Insert(NewExpression expression, SqlBuilder sqlBuilder)
        {
            string columns = " (";
            string values = " values ("; 
            for (int i = 0; i < expression.Members.Count; i++)
            {
                MemberInfo m = expression.Members[i];
                columns += m.Name + ",";

                ConstantExpression c = expression.Arguments[i] as ConstantExpression;
                if (c == null)
                {
                    MemberExpression expressionMember = expression.Arguments[i] as MemberExpression;
                    if (expressionMember == null) continue;
                    switch (expressionMember.Expression.NodeType)
                    {
                        case ExpressionType.Constant:
                            object value = GetValue(expressionMember);
                            string dbParamName = sqlBuilder.AddDbParameter(value, false);
                            values += dbParamName + ",";
                            break;

                        case ExpressionType.Parameter:
                            break;
                    }
                }
                else
                {
                    string dbParamName = sqlBuilder.AddDbParameter(c.Value, false);
                    values += dbParamName + ",";
                }
            }

            if (columns[columns.Length - 1] == ',')
            {
                columns = columns.Remove(columns.Length - 1, 1);
            }
            columns += ")";

            if (values[values.Length - 1] == ',')
            {
                values = values.Remove(values.Length - 1, 1);
            }
            values += ")";

            sqlBuilder += columns + values;

            return sqlBuilder;
        }

        protected override SqlBuilder OrderBy(NewExpression expression, SqlBuilder sqlBuilder)
        {
            foreach (Expression item in expression.Arguments)
            {
                Expression2SqlProvider.OrderBy(item, sqlBuilder);
            }
            return sqlBuilder;
        }

        protected override SqlBuilder Select(NewExpression expression, SqlBuilder sqlBuilder)
        {
            foreach (Expression item in expression.Arguments)
            {
                Expression2SqlProvider.Select(item, sqlBuilder);
            }

            foreach (MemberInfo item in expression.Members)
            {
                sqlBuilder.SelectFieldsAlias.Add(item.Name);
            }

            return sqlBuilder;
        }

        protected override SqlBuilder Update(NewExpression expression, SqlBuilder sqlBuilder)
        {
            for (int i = 0; i < expression.Members.Count; i++)
            {
                MemberInfo m = expression.Members[i];
                ConstantExpression c = expression.Arguments[i] as ConstantExpression;
                if (c == null)
                {
                    MemberExpression expressionMember = expression.Arguments[i] as MemberExpression;
                    if (expressionMember == null) continue;
                    switch (expressionMember.Expression.NodeType)
                    {
                        case ExpressionType.Constant:
                            sqlBuilder += m.Name + " =";
                            object value = GetValue(expressionMember);
                            sqlBuilder.AddDbParameter(value, true);
                            sqlBuilder += ",";
                            break;

                        case ExpressionType.Parameter:
                            break;
                    }
                }
                else
                {
                    sqlBuilder += m.Name + " =";
                    sqlBuilder.AddDbParameter(c.Value, true);
                    sqlBuilder += ",";
                }
            }
            if (sqlBuilder[sqlBuilder.Length - 1] == ',')
            {
                sqlBuilder.Remove(sqlBuilder.Length - 1, 1);
            }
            return sqlBuilder;
        }

        protected override SqlBuilder Where(NewExpression expression, SqlBuilder sqlBuilder)
        {
            return base.Where(expression, sqlBuilder);
        }

        //public ExpressionToSql<T> Where(Expression<Func<T, bool>> expression)
        //{
        //    if (expression == null)
        //    {
        //        throw new ArgumentNullException("expression", "Value cannot be null");
        //    }

        //    if (expression.Body != null && expression.Body.NodeType == ExpressionType.Constant)
        //    {
        //        throw new ArgumentException("Cannot be parse expression", "expression");
        //    }

        //    this._sqlBuilder += "\nwhere";
        //    Expression2SqlProvider.Where(expression.Body, this._sqlBuilder);
        //    return this;
        //}
        private static object GetValue(MemberExpression expr)
        {
            var field = expr.Member as FieldInfo;
            var value = field != null ? field.GetValue(((ConstantExpression)expr.Expression).Value) : ((PropertyInfo)expr.Member).GetValue(((ConstantExpression)expr.Expression).Value, null);
            return value;
        }
    }
}