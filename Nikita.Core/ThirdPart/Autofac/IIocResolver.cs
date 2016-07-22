using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Core.Autofac
{ 
    /// <summary>
    /// 依赖注入对象解析获取器
    /// </summary>
    public interface IIocResolver
    {
        /// <summary>
        /// 获取指定类型的实例
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns></returns>
        T Resolve<T>();

        ///// <summary>
        ///// 使用参数获取指定类型的实例
        ///// </summary>
        ///// <typeparam name="T">类型</typeparam>
        ///// <param name="args">参数</param>
        ///// <returns></returns>
        //T Resolve<T>(params KeyValuePair<string, object>[] args);

        ///// <summary>
        ///// 获取指定类型的实例
        ///// </summary>
        ///// <param name="type">类型</param>
        ///// <returns></returns>
        //object Resolve(Type type);

        ///// <summary>
        ///// 使用参数获取指定类型的实例
        ///// </summary>
        ///// <param name="type">类型</param>
        ///// <param name="args">参数</param>
        //object Resolve(Type type, params KeyValuePair<string, object>[] args);

        ///// <summary>
        ///// 获取指定类型的所有实例
        ///// </summary>
        ///// <typeparam name="T">类型</typeparam>
        ///// <returns></returns>
        //IEnumerable<T> Resolves<T>();

        ///// <summary>
        ///// 获取指定类型的所有实例
        ///// </summary>
        ///// <param name="type">类型</param>
        ///// <returns></returns>
        //IEnumerable<object> Resolves(Type type);
    }
}
