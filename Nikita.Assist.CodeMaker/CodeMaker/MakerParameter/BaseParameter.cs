using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nikita.Base.Define;


namespace Nikita.Assist.CodeMaker 
{
  public  class BaseParameter
    {
        public FrameworkType FrameworkType { get; set; }
        public ListBindType ListBindType { get; set; }
        public UiStyle UiStyle { get; set; }
        public CodeGenType CodeGenType { get; set; }
    }
}
