using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Permission
{
    public class ExcelHelper
    {
        /// <summary>GridControl导出Excel
        ///
        /// </summary>
        /// <param name="GridControl">GridControl控件实例</param>
        /// <param name="Frm">窗体</param>
        /// <param name="FileName">导出Excel的名称</param>
        public static void ImportExcel(DevExpress.XtraGrid.GridControl GridControl, Form Frm, string FileName)
        {
            SaveFileDialog FileDia = new SaveFileDialog();
            FileDia.Title = "导出Excel数据字典";
            FileDia.Filter = "Excel文件(*.xls)|*.xls";
            FileDia.FileName = FileName;
            DialogResult DialogRes = FileDia.ShowDialog(Frm);
            if (DialogRes == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                GridControl.ExportToXls(FileDia.FileName);
                if (DevExpress.XtraEditors.XtraMessageBox.Show("导出成功，是否打开文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
                    info.FileName = FileDia.FileName;
                    System.Diagnostics.Process.Start(info);
                }
            }
        }
    }
}