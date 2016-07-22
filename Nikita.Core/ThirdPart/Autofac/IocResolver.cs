using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace Nikita.Core.Autofac
{
    public class IocResolver : IIocResolver
    {
        private IContainer Container;
        public IocResolver(IContainer Container)
        {
            this.Container = Container;
        }

        /// <summary>
        /// 获取指定类型的实例
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            T it = Container.Resolve<T>();
            return it;
        }


        ///// <summary>
        ///// 获取指定类型的实例
        ///// </summary>
        ///// <param name="type">类型</param>
        ///// <returns></returns>
        //public object Resolve(Type type)
        //{
        //}


        ///// <summary>
        ///// 获取指定类型的所有实例
        ///// </summary>
        ///// <typeparam name="T">类型</typeparam>
        ///// <returns></returns>
        //public IEnumerable<T> Resolves<T>()
        //{
        //}

        ///// <summary>
        ///// 获取指定类型的所有实例
        ///// </summary>
        ///// <param name="type">类型</param>
        ///// <returns></returns>
        //public IEnumerable<object> Resolves(Type type)
        //{
        //}
    }
}
