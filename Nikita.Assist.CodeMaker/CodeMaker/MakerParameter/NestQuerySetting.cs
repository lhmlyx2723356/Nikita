using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nikita.Assist.CodeMaker
{
   public class NestQuerySetting
    {
        public string Key1 { get; internal set; }
        public string Key2 { get; internal set; }
        public string Key3 { get; internal set; } 
        public string Sql { get; internal set; } 
        public DataTable DataTableQuery { get; internal set; }
        public string FormClassName { get; internal set; }
    }
}
