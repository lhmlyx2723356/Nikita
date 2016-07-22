using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Nikita.WinForm.ExtendControl.CommonQuery
{
    public static class DynamicExtention
    {
        public static IQueryable<T> Where<T>(this IQueryable<T> query, Filter[] filters)
        {
            var param = DynamicLinq.CreateLambdaParam<T>("c");
            //初始默认一个true
            Expression body = Expression.Constant(true); 
            //foreach (var filter in filters)
            //{
            //    Expression express = param.GenerateBody<T>(filter);
            //    body = body.AndAlso(express); //这里可以根据需要自由组合
            //}
            body = filters.Select(filter => param.GenerateBody<T>(filter)).Aggregate(body, (current, express) => current.AndAlso(express));
            //最终组成lambda
            var lambda = param.GenerateTypeLambda<T>(body); 
            return query.Where(lambda);
        }
    }
}