using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Nikita.Assist.FileLoader
{
    public class ExcelFile : DocFile
    {
        public ExcelFile()
        {
            FileType = FileType.xls;
        }

        public override void Open()
        {
            if (ApplicationInstallHelper.IsExcelInstalled())
            {
                Process.Start(this.FilePath);
            }
            else
            {
                FrmExcelPreview excelPre = new FrmExcelPreview(this.FilePath);
                excelPre.Show();
            }
        }
    }
}
