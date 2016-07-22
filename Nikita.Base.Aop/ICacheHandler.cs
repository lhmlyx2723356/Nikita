using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Base.Aop
{
    public interface ICacheHandler
    {
        Object GetCache(string strTableName, string strWhere);
    }
}
