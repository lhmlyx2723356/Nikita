using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.FileLoader
{
    public abstract class Files : IFileOpen
    {
        private FileType filetype = FileType.doc;

        public FileType FileType
        {
            get
            {
                return this.filetype;
            }
            protected set
            {
                this.filetype = value;
            }
        }

        public abstract void Open();

        public string FilePath
        {
            get;
            set;
        }
    }
}
