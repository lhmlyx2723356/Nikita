using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Nikita.Assist.FileLoader
{
    public class WordFile : DocFile
    {
        public WordFile()
        {
            FileType = FileType.doc;
        }

        public override void Open()
        {
            if (ApplicationInstallHelper.IsWordInstalled())
            {
                Process.Start(this.FilePath);
            }
            else
            {
                FrmDocPreview docPre = new FrmDocPreview(this.FilePath);
                docPre.Show();
            }
        }
    }
}
