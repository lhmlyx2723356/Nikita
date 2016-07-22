using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nikita.Base.Define;

namespace Nikita.Base.IDAL
{
    public class BindClass
    {
        public SqlType SqlType { get; set; }
        public string Connections { get; set; }
        public string BindSql { get; set; }
    }
}
