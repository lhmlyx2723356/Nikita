using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq; 
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Nikita.Assist.CommonQuery
{
    public static class DynamicLinq
    {
        public static Expression And(this Expression expression, Expression expressionRight)
        {
            return Expression.And(expression, expressionRight);
        }

        public static Expression AndAlso(this Expression expression, Expression expressionRight)
        {
            return Expression.AndAlso(expression, expressionRight);
        }

        /// <summary>  创建lambda中的参数,即c=>c.xxx==xx 中的c
        ///
        /// </summary>
        public static ParameterExpression CreateLambdaParam<T>(string name)
        {
            return Expression.Parameter(typeof(T), name);
        }

        /// <summary>   创建linq表达示的body部分,即c=>c.xxx==xx 中的c.xxx==xx
        ///
        /// </summary>
        public static Expression GenerateBody<T>(this ParameterExpression param, Filter filterObj)
        {
            PropertyInfo property = typeof(T).GetProperty(filterObj.Key);

            //组装左边
            Expression left = Expression.Property(param, property);
            //组装右边
            Expression right = null;
            Expression filter = null;
            Expression expressAll = null;
            if (!filterObj.Contract.Contains("in"))
            {
                bool blnCheckFlag = CheckInput(property.PropertyType, filterObj.Value);
                if (!blnCheckFlag)
                {
                    throw new Exception("输入的值有误");
                }
                //todo: 下面根据需要，扩展自己的类型
                if (property.PropertyType == typeof(int))
                {
                    right = Expression.Constant(int.Parse(filterObj.Value));
                }
                else if (property.PropertyType == typeof(DateTime))
                {
                    right = Expression.Constant(DateTime.Parse(filterObj.Value));
                }
                else if (property.PropertyType == typeof(string))
                {
                    right = Expression.Constant((filterObj.Value));
                }
                else if (property.PropertyType == typeof(decimal))
                {
                    right = Expression.Constant(decimal.Parse(filterObj.Value));
                }
                else if (property.PropertyType == typeof(Guid))
                {
                    right = Expression.Constant(Guid.Parse(filterObj.Value));
                }
                else if (property.PropertyType == typeof(bool))
                {
                    right = Expression.Constant(filterObj.Value.Equals("1"));
                }
                else
                {
                    throw new Exception("暂不能解析该Key的类型");
                }
            }
            else
            {
                switch (filterObj.Contract)
                {
                    case "in":
                    case "not in":
                        {
                            Type type = property.PropertyType;
                            string strValue = filterObj.Value;
                            List<object> lstObjects = ChangeType(type, strValue);
                            if (type == typeof(int))
                            {
                                List<int> lstValueList = lstObjects.Cast<int>().ToList();
                                Expression rightValue = Expression.Constant(lstValueList);
                                expressAll = Expression.Call(typeof(Enumerable), "Contains", new[] { type }, rightValue,
                                        left);
                            }
                            else if (type == typeof(long))
                            {
                                List<long> lstValueList = lstObjects.Cast<long>().ToList();
                                Expression rightValue = Expression.Constant(lstValueList);
                                expressAll = Expression.Call(typeof(Enumerable), "Contains", new[] { type }, rightValue,
                                        left);
                            }
                            else if (type == typeof(short))
                            {
                                List<short> lstValueList = lstObjects.Cast<short>().ToList();
                                Expression rightValue = Expression.Constant(lstValueList);
                                expressAll = Expression.Call(typeof(Enumerable), "Contains", new[] { type }, rightValue,
                                        left);
                            }
                            else if (type == typeof(byte))
                            {
                                List<byte> lstValueList = lstObjects.Cast<byte>().ToList();
                                Expression rightValue = Expression.Constant(lstValueList);
                                expressAll = Expression.Call(typeof(Enumerable), "Contains", new[] { type }, rightValue,
                                        left);
                            }
                            else if (type == typeof(DateTime))
                            {
                                List<DateTime> lstValueList = lstObjects.Cast<DateTime>().ToList();
                                Expression rightValue = Expression.Constant(lstValueList);
                                expressAll = Expression.Call(typeof(Enumerable), "Contains", new[] { type }, rightValue,
                                        left);
                            }
                            else if (type == typeof(decimal))
                            {
                                List<decimal> lstValueList = lstObjects.Cast<decimal>().ToList();
                                Expression rightValue = Expression.Constant(lstValueList);
                                expressAll = Expression.Call(typeof(Enumerable), "Contains", new[] { type }, rightValue,
                                        left);
                            }
                            else if (type == typeof(Guid))
                            {
                                List<Guid> lstValueList = lstObjects.Cast<Guid>().ToList();
                                Expression rightValue = Expression.Constant(lstValueList);
                                expressAll = Expression.Call(typeof(Enumerable), "Contains", new[] { type }, rightValue,
                                        left);
                            }
                            else if (type == typeof(bool))
                            {
                                List<bool> lstValueList = lstObjects.Cast<bool>().ToList();
                                Expression rightValue = Expression.Constant(lstValueList);
                                expressAll = Expression.Call(typeof(Enumerable), "Contains", new[] { type }, rightValue,
                                        left);
                            }
                        }
                        if (filterObj.Contract == "not in")
                        {
                            if (expressAll != null) expressAll = Expression.Not(expressAll);
                        }
                        break;
                }
            }
            //todo: 下面根据需要扩展自己的比较
            if (!filterObj.Contract.Contains("in"))
            {
                if (right != null) filter = Expression.Equal(left, right);
            }
            switch (filterObj.Contract)
            {
                case "=":
                    if (right != null) filter = Expression.Equal(left, right);
                    break;

                case "<>":
                    if (right != null) filter = Expression.NotEqual(left, right);
                    break;

                case ">":
                    if (right != null) filter = Expression.GreaterThan(left, right);
                    break;

                case ">=":
                    if (right != null) filter = Expression.GreaterThanOrEqual(left, right);
                    break;

                case "<":
                    if (right != null) filter = Expression.LessThan(left, right);
                    break;

                case "<=":
                    if (right != null) filter = Expression.LessThanOrEqual(left, right);
                    break;

                case "like":
                    if (right != null) filter = Expression.Call(left, typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                                 Expression.Constant(filterObj.Value));
                    break;

                case "in":
                case "not in":
                    filter = expressAll;
                    break;
            }
            return filter;
        }

        /// <summary>  创建完整的lambda,即c=>c.xxx==xx
        ///
        /// </summary>
        public static LambdaExpression GenerateLambda(this ParameterExpression param, Expression body)
        {
            return Expression.Lambda(body, param);
        }

        //private static MethodInfo method_Contains =
        //                (from m in typeof(Enumerable).GetMethods()
        //                 where m.Name.Equals("Contains")
        //                     && m.IsGenericMethod
        //                     && m.GetGenericArguments().Length == 1
        //                     && m.GetParameters().Length == 2
        //                 select m
        //                ).First();
        /// <summary>  创建完整的lambda，为了兼容EF中的where语句
        ///
        /// </summary>
        public static Expression<Func<T, bool>> GenerateTypeLambda<T>(this ParameterExpression param, Expression body)
        {
            return (Expression<Func<T, bool>>)(param.GenerateLambda(body));
        }

        //public static Func<ObjT, bool> PropertyCheck<ObjT, PropT>(string propertyName, Expression<Func<PropT, bool>> predicate)
        //{
        //    var paramExpr = Expression.Parameter(typeof(ObjT));
        //    var propExpr = Expression.Property(paramExpr, propertyName);
        //    return Expression.Lambda<Func<ObjT, bool>>(Expression.Invoke(predicate, propExpr), paramExpr).Compile();
        //}
        public static Expression Or(this Expression expression, Expression expressionRight)
        {
            return Expression.Or(expression, expressionRight);
        }

        /// <summary>检查输入合法性
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <param name="strValue"></param>
        /// <returns></returns>
        private static bool CheckInput(Type type, string strValue)
        {
            bool falg = true;
            if (type == typeof(int))
            {
                int result;
                if (!int.TryParse(strValue, out result))
                {
                    falg = false;
                }
            }
            else if (type == typeof(DateTime))
            {
                DateTime result;
                if (!DateTime.TryParse(strValue, out result))
                {
                    falg = false;
                }
            }
            else if (type == typeof(decimal))
            {
                decimal result;
                if (!decimal.TryParse(strValue, out result))
                {
                    falg = false;
                }
            }
            else if (type == typeof(Guid))
            {
                Guid result;
                if (!Guid.TryParse(strValue, out result))
                {
                    falg = false;
                }
            }
            else if (type == typeof(bool))
            {
                bool result;
                if (!bool.TryParse(strValue, out result))
                {
                    falg = false;
                }
            }
            return falg;
        }

        private static List<object> ChangeType(Type type, string strValue)
        {
            List<object> lstValue = new List<object>();
            if (type == typeof(int))
            {
                foreach (var value in strValue.Split(','))
                {
                    if (value.Trim() == string.Empty)
                    {
                        continue;
                    }
                    int result = int.Parse(value.Trim());
                    lstValue.Add(result);
                }
            }
            else if (type == typeof(long))
            {
                foreach (var value in strValue.Split(','))
                {
                    if (value.Trim() == string.Empty)
                    {
                        continue;
                    }
                    lstValue.Add(long.Parse(value.Trim()));
                }
            }
            else if (type == typeof(short))
            {
                foreach (var value in strValue.Split(','))
                {
                    if (value.Trim() == string.Empty)
                    {
                        continue;
                    }
                    lstValue.Add(short.Parse(value.Trim()));
                }
            }
            else if (type == typeof(byte))
            {
                foreach (var value in strValue.Split(','))
                {
                    if (value.Trim() == string.Empty)
                    {
                        continue;
                    }
                    lstValue.Add(byte.Parse(value.Trim()));
                }
            }
            else if (type == typeof(DateTime))
            {
                foreach (var value in strValue.Split(','))
                {
                    if (value.Trim() == string.Empty)
                    {
                        continue;
                    }
                    lstValue.Add(DateTime.Parse(value.Trim()));
                }
            }
            else if (type == typeof(decimal))
            {
                foreach (var value in strValue.Split(','))
                {
                    if (value.Trim() == string.Empty)
                    {
                        continue;
                    }
                    lstValue.Add(decimal.Parse(value.Trim()));
                }
            }
            else if (type == typeof(Guid))
            {
                foreach (var value in strValue.Split(','))
                {
                    if (value.Trim() == string.Empty)
                    {
                        continue;
                    }
                    lstValue.Add(Guid.Parse(value.Trim()));
                }
            }
            else if (type == typeof(bool))
            {
                foreach (var value in strValue.Split(','))
                {
                    if (value.Trim() == string.Empty)
                    {
                        continue;
                    }
                    lstValue.Add(bool.Parse(value.Trim()));
                }
            }
            return lstValue;
        }
    }
}