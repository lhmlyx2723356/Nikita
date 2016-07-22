using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.CodeMaker
{
    public class CodeMakeDirector
    {
        public string[] Construct(CodeMakeBulider bulider, BasicParameter basicParameter, BaseParameter baseParameter)
        {
            string[] strArray = new string[2];
            strArray[0] = bulider.GenWinFormCS(basicParameter, baseParameter);
            strArray[1] = bulider.GenWinFormDesign(basicParameter, baseParameter);
            return strArray;
        }
    }
}
