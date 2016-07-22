using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.FileLoader
{
    public class MPEGFile : MediaFile
    {
        public MPEGFile()
        {
            FileType = FileType.mpeg;
        }

        public override void Open()
        {
            Console.WriteLine("Open the MPEG file.");
        }
    }
}
