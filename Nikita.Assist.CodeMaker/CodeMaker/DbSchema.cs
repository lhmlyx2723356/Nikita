using Nikita.Base.DbSchemaReader;
using Nikita.Base.DbSchemaReader.DataSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.CodeMaker
{
    public class DbSchema
    {
        public string DatabaseName
        {
            get;
            set;
        }

        public DatabaseSchema DatabaseSchema
        {
            get;
            set;
        }

        public SqlType SqlType
        {
            get;
            set;
        }
    }
}