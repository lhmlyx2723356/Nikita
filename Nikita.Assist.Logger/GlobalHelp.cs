using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.Logger
{
   public class GlobalHelp
    {
       public static string Connection
       {

           get { return LoggerHelper.GetConn(); }
       }

    }
}
