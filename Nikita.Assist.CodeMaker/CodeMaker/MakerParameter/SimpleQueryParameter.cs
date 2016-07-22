using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nikita.Base.DbSchemaReader.DataSchema;

namespace Nikita.Assist.CodeMaker
{
   public class SimpleQueryParameter : BaseParameter
    {
        public string QueryColumns { get; set; }
        public string ShowColumns { get; set; }
        public DatabaseTable DatabaseTable { get; set; } 
    }
}
