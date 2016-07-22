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
    public partial class FrmPdfPreview : Form
    {
        public FrmPdfPreview()
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
        //public bool SaveFileButton
        //{
        //    get;
        //    set;
        //}

        public FrmPdfPreview(string strPath)
        {
            InitializeComponent();
            pdfViewer1.DocumentChanged += new DevExpress.XtraPdfViewer.PdfDocumentChangedEventHandler(pdfViewer1_DocumentChanged);
            if (File.Exists(strPath))
            {
                this.pdfViewer1.LoadDocument(strPath);
            }
        }


        void pdfViewer1_DocumentChanged(object sender, DevExpress.XtraPdfViewer.PdfDocumentChangedEventArgs e)
        {
            string fileName = Path.GetFileName(e.DocumentFilePath);
            if (!String.IsNullOrEmpty(fileName))
            {
                Text = fileName + " - " +"预览";
            }
        } 

        private void 打开文件ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "(*.pdf)|*.pdf";
            string strPath = string.Empty;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                strPath = dialog.FileName;
            }
            if (!string.IsNullOrEmpty(strPath))
            {
                this.pdfViewer1.LoadDocument(strPath);
            }
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.pdfViewer1.Print();
        }

        private void FrmPdfPreview_Load(object sender, EventArgs e)
        {
            if (!OpenFileButton && !PrintButton)
            {
                this.menuStrip1.Visible = false;
            }

            if (!OpenFileButton)
            {
                this.打开文件ToolStripMenuItem1.Visible = false;
            }

            if (!PrintButton)
            {
                this.打印ToolStripMenuItem.Visible = false;
            } 
        }
    }
}
