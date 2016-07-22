using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.CodeMaker
{
    public interface IModelMaker
    {
        string GenModelCode(string strNameSpace, string strTableName, string strClassName, string strConn, string anthor);
    }
}