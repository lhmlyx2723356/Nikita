using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Assist.FileLoader
{
    public partial class FrmMainFileLoader : Form
    {

        public FrmMainFileLoader()
        {
            InitializeComponent();
        }
        MyXmlFactory xmlFactory;
        LoadManager loader;
        string strPath;

        private void FrmMainFileLoader_Load(object sender, EventArgs e)
        {
            xmlFactory = new MyXmlFactory(Application.StartupPath + "\\FilesType.config");
            loader = new LoadManager();
            if (xmlFactory.definedFiles.Count > 0)
            {
                foreach (var definedType in xmlFactory.definedFiles)
                {
                    loader.LoadFiles(definedType.Value);
                }
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    FileType type = loader.GetFileType("D:\\1.xls".ToLower());
        //    if (type == FileType.gif || type == FileType.jpeg || type == FileType.jpg || type == FileType.mpeg || type == FileType.png || type == FileType.bmp)
        //    {
        //        Files file = loader.Files.Where(t => t.FileType == FileType.jpg).First();
        //        file.FilePath = "D:\\1.gif".ToLower();
        //        loader.OpenFile(file);
        //    }
        //    else if (type == FileType.doc || type == FileType.docx)
        //    {
        //        Files file = loader.Files.Where(t => t.FileType == FileType.doc).First();
        //        file.FilePath = "D:\\1.doc".ToLower();
        //        loader.OpenFile(file);
        //    }
        //    else if (type == FileType.pdf)
        //    {
        //        Files file = loader.Files.Where(t => t.FileType == FileType.pdf).First();
        //        file.FilePath = "D:\\1.pdf".ToLower();
        //        loader.OpenFile(file);
        //    }
        //    else if (type == FileType.xls || type==FileType.xlsx)
        //    {
        //        Files file = loader.Files.Where(t => t.FileType == FileType.xls).First();
        //        file.FilePath = "D:\\1.xls".ToLower();
        //        loader.OpenFile(file);
        //    }
        //    else // if (type == FileType.txt || type == FileType.mp3 || type == FileType.avi || type == FileType.mpeg)
        //    {
        //        //调用本地软件打开
        //        Process.Start("D:\\1.txt");
        //    }
        //}
    }
}
