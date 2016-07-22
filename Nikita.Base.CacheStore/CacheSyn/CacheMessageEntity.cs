using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nikita.Base.CacheStore
{
  public  class CacheMessageEntity
    { 
        public string CacheKey { get; set; }
         
        public string Operation { get; set; }
         
        public DataTable DataTableCache { get; set; }
    }
}
