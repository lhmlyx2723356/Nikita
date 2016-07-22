using DevExpress.XtraRichEdit.API.Native;
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
    public partial class FrmDocPreview : Form
    {
        public FrmDocPreview()
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

        public FrmDocPreview(string strFilePath)
        {
            InitializeComponent();
            this.richEditControl1.DocumentLoaded += new EventHandler(richEditControl1_DocumentLoaded);
            if (File.Exists(strFilePath))
            {
                richEditControl1.LoadDocument(strFilePath);
            }
        }

        /// <summary>
        /// WORD文档变化后，实现对新文件名称的显示
        /// </summary>
        void richEditControl1_DocumentLoaded(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(this.richEditControl1.Options.DocumentSaveOptions.CurrentFileName);
            if (String.IsNullOrEmpty(fileName))
            {
                Text = fileName + " - 预览";
            }

            //修改默认字体
            DocumentRange range = richEditControl1.Document.Range;
            CharacterProperties cp = this.richEditControl1.Document.BeginUpdateCharacters(range);
            cp.FontName = "新宋体";
            this.richEditControl1.Document.EndUpdateCharacters(cp);
        }


        private void 打开文件ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "(*.doc,*.docx)|*.doc;*.docx";
            string strPath = string.Empty;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                strPath = dialog.FileName;
            }
            if (!string.IsNullOrEmpty(strPath))
            {
                richEditControl1.LoadDocument(strPath);
            }
        }

        private void FrmDocPreview_Load(object sender, EventArgs e)
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

        private void 保存文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richEditControl1.SaveDocument();
        }

        private void 另存为WordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richEditControl1.SaveDocumentAs();
                MessageBox.Show("保存成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richEditControl1.ShowPrintPreview();
        }
    }
}
