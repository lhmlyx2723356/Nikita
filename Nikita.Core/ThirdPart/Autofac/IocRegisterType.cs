using System;
using System.Reflection;
using Autofac;

namespace Nikita.Core.Autofac
{
    public class IocRegisterType : IIocRegisterType
    {
        private ContainerBuilder builder;
        public ContainerBuilder Builder
        {
            get { return builder ?? (builder = new ContainerBuilder()); }
        }
         
        public IContainer RegisterType<T, IT>()
        {
            Builder.RegisterType<T>().As<IT>();
         return   Builder.Build();
        }


        public IContainer RegisterTypeByName<T, IT>(string strName)
        {
            Builder.RegisterType<T>().Named<IT>(strName);
            return  Builder.Build();
        }

        public IContainer RegisterTypeByEnum<T, IT>(Enum enumName)
        {
            Builder.RegisterType<T>().Keyed<IT>(enumName); 
            return Builder.Build();  
        }

        public IContainer RegisterTypeByAssembly<IT>()
        {
            var basetype = typeof(IT);
            var assembly = Assembly.GetAssembly(basetype);
            Builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces(); 
            return Builder.Build();
        }
    }
}