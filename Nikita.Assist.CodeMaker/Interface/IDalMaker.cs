using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.CodeMaker
{
    public interface IDalMaker
    {
        string GenDalCode(string strNameSpace, string strTableName, string strClassName, string strConn);
    }
}