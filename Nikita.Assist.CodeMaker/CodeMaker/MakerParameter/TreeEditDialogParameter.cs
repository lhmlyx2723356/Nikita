using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nikita.Base.DbSchemaReader.DataSchema;

namespace Nikita.Assist.CodeMaker
{
    public class TreeEditDialogParameter : EditDialogParameter
    {
        public string  KeyId { get; set; }
        public string  ParentId { get; set; }
    }
}
