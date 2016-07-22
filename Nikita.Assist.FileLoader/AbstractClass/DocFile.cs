using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.FileLoader
{
    public abstract class DocFile : Files
    {
        public int GetPageCount()
        {
            return 250;
        }
    }
}
