using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Nikita.Assist.FileLoader
{
    public class PDFFile : DocFile
    {
        public PDFFile()
        {
            FileType = FileType.pdf;
        }

        public override void Open()
        {
            FrmPdfPreview pdfPre = new FrmPdfPreview(this.FilePath);
            pdfPre.Show();
        }
    }
}
