using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Base.IDAL
{
    public interface IProperty
    {
         object GetProperty<T>(T obj, string strPropertyName);

         void SetProperty<T>(T obj, string strPropertyName, object objValue);
    }
}