using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.Logger
{
   public  interface ILog
    {
       int Add(Exception objectEx, string Logger);
         
       bool Delete(int id);
        
         
       //bool DeleteLog(string ids);

       //bool DeleteAllLog();
    }
}
