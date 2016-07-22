using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace Nikita.Core.Autofac
{
    public interface IIocRegisterType
    {
        IContainer RegisterType<T, IT>();
        IContainer RegisterTypeByName<T, IT>(string strName);
        IContainer RegisterTypeByEnum<T, IT>(Enum enumName);
        IContainer RegisterTypeByAssembly<IT>();
    }
}
