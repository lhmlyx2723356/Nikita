using DevExpress.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Assist.FileLoader
{
    public partial class FrmExcelPreview : Form
    {
        public FrmExcelPreview()
        {
            InitializeComponent();
        }
        
        public bool OpenFileButton
        {
            get;
            set;
        }
        public bool PrintButton
        {
            get;
            set;
        }
        public bool SaveFileButton
        {
            get;
            set;
        }

        public bool SaveAsFileButton
        {
            get;
            set;
        }
        private string strFilePath;
        public FrmExcelPreview(string strFilePath)
        {
            InitializeComponent();
            this.strFilePath = strFilePath;
            this.spreadsheetControl1.DocumentLoaded += new EventHandler(spreadsheetControl1_DocumentLoaded);
            if (File.Exists(strFilePath))
            {
                spreadsheetControl1.LoadDocument(strFilePath);
            }
        }

        /// <summary>
        /// 文档变化后，实现对新文件名称的显示
        /// </summary>
        void spreadsheetControl1_DocumentLoaded(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(this.spreadsheetControl1.Document.Path);
            if (String.IsNullOrEmpty(fileName))
            { 
                Text = fileName + " - 预览";
            }
        }
        private void 打开文件ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "(*.xls,*.xlsx)|*.xls;*.xlsx";
            string strPath = string.Empty;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                strPath = dialog.FileName;
            }
            if (!string.IsNullOrEmpty(strPath))
            {
                spreadsheetControl1.LoadDocument(strPath);
            }
        } 

        private void 保存文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spreadsheetControl1.SaveDocument(strFilePath);
        }

        private void 另存为WordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            string strPath = dialog.FileName;
            if (!string.IsNullOrEmpty(strPath))
            {
                try
                {
                    IWorkbook workbook = spreadsheetControl1.Document;
                    workbook.SaveDocument(strPath);
                    MessageBox.Show("保存成功"); 
                }
                catch (Exception ex)
                { 
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void FrmExcelPreview_Load(object sender, EventArgs e)
        {
            if (!OpenFileButton && !PrintButton && !SaveFileButton && !SaveAsFileButton)
            {
                this.menuStrip1.Visible = false;
            }

            if (!OpenFileButton)
            {
                this.打开文件ToolStripMenuItem1.Visible = false;
            }

            if (!SaveFileButton)
            {

                this.保存文件ToolStripMenuItem.Visible = false;
            }

            if (!SaveAsFileButton)
            {

                this.另存为WordToolStripMenuItem.Visible = false;
            }

            if (!PrintButton)
            {
                this.打印ToolStripMenuItem.Visible = false;
            }
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            this.spreadsheetControl1.ShowPrintPreview();
        }
    }
}
