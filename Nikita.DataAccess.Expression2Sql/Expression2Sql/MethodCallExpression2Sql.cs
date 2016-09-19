using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.NetworkInformation;

namespace Nikita.DataAccess.Expression2Sql
{
    internal class MethodCallExpression2Sql : BaseExpression2Sql<MethodCallExpression>
    {
        private static Dictionary<string, Action<MethodCallExpression, SqlBuilder>> _Methods = new Dictionary<string, Action<MethodCallExpression, SqlBuilder>>
        {
            {"Like",Like},
            {"LikeLeft",LikeLeft},
            {"LikeRight",LikeRight},
            {"StartsWith",StartsWith},
            {"EndsWith",EndsWith},
            {"In",InnerIn}
        };

        protected override SqlBuilder Where(MethodCallExpression expression, SqlBuilder sqlBuilder)
        {
            var key = expression.Method;
            if (key.IsGenericMethod)
            {
                key = key.GetGenericMethodDefinition();
            }

            Action<MethodCallExpression, SqlBuilder> action;
            if (_Methods.TryGetValue(key.Name, out action))
            {
                action(expression, sqlBuilder);
                return sqlBuilder;
            }

            if (expression.NodeType == ExpressionType.Call && _Methods.ContainsKey(expression.Method.Name) == false)
            {
                var Value = Expression.Lambda(expression).Compile().DynamicInvoke();
                sqlBuilder.AddDbParameter(Value);
                return sqlBuilder;
            }
            throw new NotImplementedException("Unimplemented method:" + expression.Method);
        }

        private static void InnerIn(MethodCallExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Where(expression.Arguments[0], sqlBuilder);
            sqlBuilder += " in";
            Expression2SqlProvider.In(expression.Arguments[1], sqlBuilder);
        }



        private static void Like(MethodCallExpression expression, SqlBuilder sqlBuilder)
        {
            if (expression.Object != null)
            {
                Expression2SqlProvider.Where(expression.Object, sqlBuilder);
            }
            Expression2SqlProvider.Where(expression.Arguments[0], sqlBuilder);
            sqlBuilder += " like '%'+";
            Expression2SqlProvider.Where(expression.Arguments[1], sqlBuilder);
            sqlBuilder += " +'%'";
        }

        private static void StartsWith(MethodCallExpression expression, SqlBuilder sqlBuilder)
        {
            if (expression.Object != null)
            {
                Expression2SqlProvider.Where(expression.Object, sqlBuilder);
            }
            sqlBuilder += " like '+";
            Expression2SqlProvider.Where(expression.Arguments[0], sqlBuilder);
            sqlBuilder += "+'%'";
        }

        private static void EndsWith(MethodCallExpression expression, SqlBuilder sqlBuilder)
        {
            if (expression.Object != null)
            {
                Expression2SqlProvider.Where(expression.Object, sqlBuilder);
            }
            sqlBuilder += " like '%+";
            Expression2SqlProvider.Where(expression.Arguments[0], sqlBuilder);
            sqlBuilder += "+'";
        }


        private static void LikeLeft(MethodCallExpression expression, SqlBuilder sqlBuilder)
        {
            if (expression.Object != null)
            {
                Expression2SqlProvider.Where(expression.Object, sqlBuilder);
            }
            Expression2SqlProvider.Where(expression.Arguments[0], sqlBuilder);
            sqlBuilder += " like '%' +";
            Expression2SqlProvider.Where(expression.Arguments[1], sqlBuilder);
        }

        private static void LikeRight(MethodCallExpression expression, SqlBuilder sqlBuilder)
        {
            if (expression.Object != null)
            {
                Expression2SqlProvider.Where(expression.Object, sqlBuilder);
            }
            Expression2SqlProvider.Where(expression.Arguments[0], sqlBuilder);
            sqlBuilder += " like ";
            Expression2SqlProvider.Where(expression.Arguments[1], sqlBuilder);
            sqlBuilder += " + '%'";
        }
    }
}