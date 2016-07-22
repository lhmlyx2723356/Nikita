using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Nikita.Assist.Uploader.ServiceReference1;

namespace Nikita.Assist.Uploader
{
    public partial class FrmUploadFile : Form
    {
        private DataTable _dt;
        public FrmUploadFile()
        {
            InitializeComponent();
        }



        readonly XmlHelper _helper = new XmlHelper(Application.StartupPath + "\\config\\UploadFile.xml");
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            btnSelectFile.Enabled = false;
            _dt.Clear();
            FolderBrowserDialog dialog = new FolderBrowserDialog { Description = @"请选择文件路径" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                DirectoryInfo folder = new DirectoryInfo(foldPath);
                foreach (FileInfo file in folder.GetFiles("*.*"))
                {
                    DataRow dr = _dt.NewRow();
                    dr["filepath"] = file.FullName;
                    _dt.Rows.Add(dr);
                }
            }
            gridControl1.DataSource = _dt;
            btnSelectFile.Enabled = true;
        }

        private void FrmUploadFile_Load(object sender, EventArgs e)
        {
            _dt = new DataTable();
            _dt.Columns.Add("filepath", typeof(string));
            _dt.Columns.Add("filename", typeof(string));
            #region gridVDalMain勾选列（编辑列）
            gridVMain.OptionsSelection.MultiSelect = true;
            gridVMain.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gridVMain.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DefaultBoolean.True;
            #endregion
            //string path = ConfigurationManager.AppSettings["defaultpath"];
            //string defaultfilename = ConfigurationManager.AppSettings["defaultfilename"]; 
            string path = _helper.ReadValue("appsetting", "defaultpath");
            string defaultfilename = _helper.ReadValue("appsetting", "defaultfilename");
            if (Directory.Exists(path))
            {
                DirectoryInfo folder = new DirectoryInfo(path);
                foreach (FileInfo file in folder.GetFiles("*.*"))
                {
                    DataRow dr = _dt.NewRow();
                    dr["filepath"] = file.FullName;
                    dr["filename"] = file.Name;
                    _dt.Rows.Add(dr);
                }
                gridControl1.DataSource = _dt;
            }

            if (defaultfilename.Trim().Length > 0)
            {
                txtFileName.Text = defaultfilename;
            }
            if (path.Trim().Length>0)
            {

                txtFilePath.Text = path;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text.Trim().Length == 0)
            {
                MessageBox.Show(@"请输入压缩后的文件名");
                txtFileName.Select();
                return;
            }
            try
            {
                splashScreenManager1.ShowWaitForm();

                List<FileInfo> fileList = new List<FileInfo>();
                for (int i = 0; i < gridVMain.SelectedRowsCount; i++)
                {
                    string path = gridVMain.GetDataRow(gridVMain.GetSelectedRows()[i])["filepath"].ToString();
                    FileInfo fi = new FileInfo(path);
                    fileList.Add(fi);
                }
                FileCompression.Compress(fileList, Application.StartupPath + "\\" + txtFileName.Text.Trim() + ".zip", 5, 5);
                splashScreenManager1.CloseWaitForm();
                SplashScreenManager.ShowForm(typeof(SplashScreen1));
                FileStream fileData = new FileStream(Application.StartupPath + "\\" + txtFileName.Text.Trim() + ".zip", FileMode.Open);
                bool flag = UploadFile(txtFileName.Text.Trim() + ".zip", "D:\\Image", fileData);
                if (flag)
                {
                    SplashScreenManager.CloseForm();
                }
            }
            catch (Exception)
            {
              
                //splashScreenManager1.CloseWaitForm();
                //SplashScreenManager.CloseForm();
            }

        }
        public static bool UploadFile(string fileName, string savePath, Stream fileData)
        {
            Service1Client service1 = new Service1Client();
            bool flag = service1.UploadFile(fileName, savePath, fileData);
            return flag;
        }

        private void btnSetDefault_Click(object sender, EventArgs e)
        {
            try
            { 
                _helper.ReplaceValue("appsetting", "defaultpath", txtFilePath.Text.Trim());
                _helper.ReplaceValue("appsetting", "defaultfilename", txtFileName.Text.Trim());
                _helper.Save();
                MessageBox.Show(@"设置成功");
            }
            catch (Exception)
            {

                MessageBox.Show(@"设置失败");
            }
        }
    }
}
