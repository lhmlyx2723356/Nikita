using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Nikita.Base.DbSchemaReader.DataSchema;

namespace Nikita.Assist.CodeMaker
{
    public class NestQueryParameter : BaseParameter
    {
        public string QueryColumns { get; set; }
        public string ShowColumns { get; set; } 
        public string Key1 { get; internal set; }
        public string Key2 { get; internal set; }
        public string Key3 { get; internal set; }
        public string Sql { get; internal set; }
        public DataTable DataTableQuery { get; internal set; }
        public string FormClassName { get; internal set; }
    }
}
