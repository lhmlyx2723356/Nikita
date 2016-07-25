using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq; 
using Nikita.WinForm.ExtendControl;
namespace Nikita.Assist.AutoUpdater
{
    public partial class FrmAutoUpdate : Form
    {
        private readonly string _strAppName = GetXmlNodeValue(GetFilePath("config", "AutoUpdate.xml"), "appsetting", "SystemName");

        private bool _blnFlag;

        public FrmAutoUpdate()
        {
            InitializeComponent();
        }

        /// <summary>获取当前运行系统bin目录下的文件夹下的某个文件路径
        /// 获取当前运行系统bin目录下的文件夹下的某个文件路径
        /// </summary>
        /// <param name="folder">bin 目录下的文件夹名字</param>
        /// <param name="fileName">文件名称</param>
        /// <returns> E:\\....\\bin\\Debug\\Images\\1.png </returns>
        public static string GetFilePath(string folder, string fileName)
        {
            return Application.StartupPath + "\\" + folder + "\\" + fileName;
        }

        /// <summary>获取路径下的xml文件夹的节点value值
        /// 获取路径下的xml文件夹的节点value值
        /// </summary>
        /// <param name="path"></param>
        /// <param name="category"></param>
        /// <param name="categoryName"></param>
        public static string GetXmlNodeValue(string path, string category, string categoryName)
        {
            XDocument root = XDocument.Load(path);
            XElement xElement = root.Element(category);
            if (xElement != null)
            {
                XElement xele = xElement.Element(categoryName);
                if (xele != null) return xele.Value;
            }
            return null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
            if (_blnFlag)
            {
                Process.Start(_strAppName + ".exe");
            }
        }

        private void frmAutoUpdate_Load(object sender, EventArgs e)
        {
            var result = WaitWindow.Show(WorkerMethod, "正在更新");
            _blnFlag = bool.Parse(result.ToString());
            if (!_blnFlag)
            {
                label1.Text = @"更新出错,请联系系统管理员";
            }
            else
            {
                if (File.Exists(GetFilePath("image", "warning.png")))
                {
                    pictureBox1.Image = Image.FromFile(GetFilePath("image", "warning.png"));
                }
            }
        }

        private bool IsUpdate()
        {
            try
            {
                string strPath = Environment.CurrentDirectory;
                if (File.Exists(strPath + "\\" + _strAppName + ".zip"))
                {
                    if (FileZipUnZip.CompressFile(strPath + "\\" + _strAppName + ".zip", strPath))
                    {
                        _blnFlag = true;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(@"更新出错：" + err.Message);
            }
            return _blnFlag;
        }

        private void WorkerMethod(object sender, WaitWindowEventArgs e)
        { 
            bool flag = IsUpdate();
            if (e.Arguments.Count > 0)
            {
                e.Result = flag.ToString().ToLower() == "true" ? "true" : "false";
            }
        }
    }
}