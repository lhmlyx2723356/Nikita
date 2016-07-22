using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.CodeMaker
{
  public   abstract class CodeMakeBulider
    {
        public   abstract string GenWinFormCS(BasicParameter basicParameter, BaseParameter baseParameter);
        public abstract string GenWinFormDesign(BasicParameter basicParameter, BaseParameter baseParameter);
    }
}
