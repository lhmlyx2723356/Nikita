using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Nikita.Core.NPOIs
{
    public class ExcelHelper
    {
        /// <summary>工作薄
        ///
        /// </summary>
        private static IWorkbook _iWorkbook;

        public ExcelHelper()
        {
        }

        /// <summary>文件流初始化对象
        ///
        /// </summary>
        /// <param name="stream"></param>
        public ExcelHelper(Stream stream)
        {
            _iWorkbook = CreateWorkbook(stream);
        }

        /// <summary>传入文件名
        ///
        /// </summary>
        /// <param name="fileName"></param>
        public ExcelHelper(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                _iWorkbook = CreateWorkbook(fileStream);
            }
        }

        /// <summary>Excel中默认第一张Sheet导出到集合
        ///
        /// </summary>
        /// <param name="fields">Excel各个列，依次要转换成为的对象字段名称</param>
        /// <returns></returns>
        public static IList<T> ExcelToList<T>(string[] fields) where T : class,new()
        {
            return ExportToList<T>(_iWorkbook.GetSheetAt(0), fields);
        }

        /// <summary>Excel中指定的Sheet导出到集合
        ///
        /// </summary>
        /// <param name="sheetIndex">第几张Sheet,从1开始</param>
        /// <param name="fields">Excel各个列，依次要转换成为的对象字段名称</param>
        /// <returns></returns>
        public static IList<T> ExcelToList<T>(int sheetIndex, string[] fields) where T : class,new()
        {
            return ExportToList<T>(_iWorkbook.GetSheetAt(sheetIndex - 1), fields);
        }

        /// <summary>第一个Sheet数据，转换为DataTable
        ///
        /// </summary>
        /// <returns></returns>
        public static DataTable ExportExcelToDataTable()
        {
            return ExportToDataTable(_iWorkbook.GetSheetAt(0));
        }

        /// <summary>第sheetIndex表数据，转换为DataTable
        ///
        /// </summary>
        /// <param name="sheetIndex">第几个Sheet，从1开始</param>
        /// <returns></returns>
        public static DataTable ExportExcelToDataTable(int sheetIndex)
        {
            return ExportToDataTable(_iWorkbook.GetSheetAt(sheetIndex - 1));
        }

        /// <summary> 获取一行的所有数据
        ///
        /// </summary>
        /// <param name="x">第x行</param>
        /// <returns></returns>
        public static string[] GetCells(int x)
        {
            List<string> list = new List<string>();

            ISheet sheet = _iWorkbook.GetSheetAt(0);

            IRow row = sheet.GetRow(x - 1);

            for (int i = 0, len = row.LastCellNum; i < len; i++)
            {
                list.Add(row.GetCell(i).StringCellValue);//这里没有考虑数据格式转换，会出现bug
            }
            return list.ToArray();
        }

        /// <summary> 获取第一个Sheet的第X行，第Y列的值。起始点为1
        ///
        /// </summary>
        /// <param name="x">行</param>
        /// <param name="y">列</param>
        /// <returns></returns>
        public static string GetCellValue(int x, int y)
        {
            ISheet sheet = _iWorkbook.GetSheetAt(0);

            IRow row = sheet.GetRow(x - 1);

            return row.GetCell(y - 1).ToString();
        }

        /// <summary> 创建工作簿对象
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static IWorkbook CreateWorkbook(Stream stream)
        {
            IWorkbook workbook = WorkbookFactory.Create(stream);
            return workbook;
        }

        /// <summary> 把Sheet中的数据转换为DataTable
        ///
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private static DataTable ExportToDataTable(ISheet sheet)
        {
            DataTable dt = new DataTable();

            //默认，第一行是字段
            IRow headRow = sheet.GetRow(0);

            //设置datatable字段
            for (int i = headRow.FirstCellNum, len = headRow.LastCellNum; i < len; i++)
            {
                dt.Columns.Add(headRow.Cells[i].StringCellValue);
            }
            //遍历数据行
            for (int i = (sheet.FirstRowNum + 1), len = sheet.LastRowNum + 1; i < len; i++)
            {
                IRow tempRow = sheet.GetRow(i);
                DataRow dataRow = dt.NewRow();

                //遍历一行的每一个单元格
                for (int r = 0, j = tempRow.FirstCellNum, len2 = tempRow.LastCellNum; j < len2; j++, r++)
                {
                    ICell cell = tempRow.GetCell(j);

                    if (cell != null)
                    {
                        switch (cell.CellType)
                        {
                            case CellType.String:
                                dataRow[r] = cell.StringCellValue;
                                break;

                            case CellType.Numeric:
                                dataRow[r] = cell.NumericCellValue;
                                break;

                            case CellType.Boolean:
                                dataRow[r] = cell.BooleanCellValue;
                                break;

                            default: dataRow[r] = "ERROR";
                                break;
                        }
                    }
                }
                dt.Rows.Add(dataRow);
            }
            return dt;
        }

        /// <summary>Sheet中的数据转换为List集合
        ///
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        private static IList<T> ExportToList<T>(ISheet sheet, string[] fields) where T : class,new()
        {
            IList<T> list = new List<T>();

            //遍历每一行数据
            for (int i = sheet.FirstRowNum + 1, len = sheet.LastRowNum + 1; i < len; i++)
            {
                T t = new T();
                IRow row = sheet.GetRow(i);

                for (int j = 0, len2 = fields.Length; j < len2; j++)
                {
                    ICell cell = row.GetCell(j);
                    object cellValue;

                    switch (cell.CellType)
                    {
                        case CellType.String: //文本
                            cellValue = cell.StringCellValue;
                            break;

                        case CellType.Numeric: //数值
                            cellValue = Convert.ToInt32(cell.NumericCellValue);//Double转换为int
                            break;

                        case CellType.Boolean: //bool
                            cellValue = cell.BooleanCellValue;
                            break;

                        case CellType.Blank: //空白
                            cellValue = "";
                            break;

                        default: cellValue = "ERROR";
                            break;
                    }

                    typeof(T).GetProperty(fields[j]).SetValue(t, cellValue, null);
                }
                list.Add(t);
            }

            return list;
        }

        ///// <summary>NPOI导出Excel，不依赖本地是否装有Excel，导出速度快
        /////
        ///// </summary>
        ///// <param name="dataGridView1">要导出的dataGridView控件</param>
        ///// <param name="sheetName">sheet表名</param>
        //public static void ExportToExcel(GridView dataGridView1, string sheetName)
        //{
        //    SaveFileDialog fileDialog = new SaveFileDialog();
        //    fileDialog.Filter = "Excel|*.xls";
        //    fileDialog.FileName = sheetName;
        //    if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
        //    {
        //        return;
        //    }
        //    //不允许dataGridView显示添加行，负责导出时会报最后一行未实例化错误
        //    dataGridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
        //    HSSFWorkbook workbook = new HSSFWorkbook();
        //    ISheet sheet = workbook.CreateSheet(sheetName);
        //    IRow rowHead = sheet.CreateRow(0);

        //    //填写表头
        //    for (int i = 0; i < dataGridView1.Columns.Count; i++)
        //    {
        //        rowHead.CreateCell(i, CellType.String).SetCellValue(dataGridView1.Columns[i].Caption);
        //    }
        //    //填写内容
        //    for (int i = 0; i < dataGridView1.RowCount; i++)
        //    {
        //        IRow row = sheet.CreateRow(i + 1);
        //        for (int j = 0; j < dataGridView1.Columns.Count; j++)
        //        {
        //            row.CreateCell(j, CellType.String).SetCellValue(dataGridView1.GetDataRow(i)[j].ToString());
        //        }
        //    }

        //    using (FileStream stream = File.OpenWrite(fileDialog.FileName))
        //    {
        //        workbook.Write(stream);
        //        stream.Close();
        //    }
        //    if (DevExpress.XtraEditors.XtraMessageBox.Show("导出成功，是否打开文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
        //    {
        //        System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
        //        info.FileName = fileDialog.FileName;
        //        System.Diagnostics.Process.Start(info);
        //    }

        //}

        ///// <summary>GridControl导出Excel
        /////
        ///// </summary>
        ///// <param name="GridControl">GridControl控件实例</param>
        ///// <param name="Frm">窗体</param>
        ///// <param name="FileName">导出Excel的名称</param>
        //public static void ImportExcel(DevExpress.XtraGrid.GridControl GridControl, Form Frm, string FileName)
        //{
        //    SaveFileDialog FileDia = new SaveFileDialog();
        //    FileDia.Title = "导出Excel数据字典";
        //    FileDia.Filter = "Excel文件(*.xls)|*.xls";
        //    FileDia.FileName = FileName;
        //    DialogResult DialogRes = FileDia.ShowDialog(Frm);
        //    if (DialogRes == DialogResult.OK)
        //    {
        //        DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
        //        GridControl.ExportToXls(FileDia.FileName);
        //        if (DevExpress.XtraEditors.XtraMessageBox.Show("导出成功，是否打开文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
        //        {
        //            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
        //            info.FileName = FileDia.FileName;
        //            System.Diagnostics.Process.Start(info);
        //        }
        //    }
        //}

        ///// <summary>NPOI导出Excel，不依赖本地是否装有Excel，导出速度快
        /////
        ///// </summary>
        ///// <param name="dataGridView1">要导出的DataTable</param>
        ///// <param name="sheetName">sheet表名</param>
        //public static void ExportToExcelFromDataTable(DataTable dt, GridView gridview, string sheetName, string WarningMsg)
        //{
        //    if (MessageUtil.ShowYesNoAndWarning(WarningMsg) == DialogResult.Yes)
        //    {
        //        SaveFileDialog fileDialog = new SaveFileDialog();
        //        fileDialog.Filter = "Excel|*.xls";
        //        fileDialog.FileName = sheetName;
        //        if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
        //        {
        //            return;
        //        }
        //        HSSFWorkbook workbook = new HSSFWorkbook();
        //        ISheet sheet = workbook.CreateSheet(sheetName);
        //        IRow rowHead = sheet.CreateRow(0);

        //        //填写表头
        //        for (int i = 0; i < gridview.VisibleColumns.Count; i++)
        //        {
        //            for (int j = 0; j < dt.Columns.Count; j++)
        //            {
        //                if (dt.Columns[j].ColumnName == gridview.VisibleColumns[i].FieldName)
        //                {
        //                    rowHead.CreateCell(i, CellType.String).SetCellValue(gridview.VisibleColumns[i].Caption);
        //                }
        //            }
        //        }
        //        //填写内容
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            IRow row = sheet.CreateRow(i + 1);
        //            for (int j = 0; j < gridview.VisibleColumns.Count; j++)
        //            {
        //                for (int k = 0; k < dt.Columns.Count; k++)
        //                {
        //                    if (dt.Columns[k].ColumnName == gridview.VisibleColumns[j].FieldName)
        //                    {
        //                        row.CreateCell(j, CellType.String).SetCellValue(dt.Rows[i][k].ToString());
        //                    }
        //                }
        //            }
        //        }

        //        using (FileStream stream = File.OpenWrite(fileDialog.FileName))
        //        {
        //            workbook.Write(stream);
        //            stream.Close();
        //        }
        //        if (DevExpress.XtraEditors.XtraMessageBox.Show("导出成功，是否打开文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
        //        {
        //            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
        //            info.FileName = fileDialog.FileName;
        //            System.Diagnostics.Process.Start(info);
        //        }
        //    }
        //}
    }
}