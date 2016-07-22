using System;
using System.IO;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;

namespace Nikita.Assist.DBManager
{
    public partial class FrmShutcutList : DockContentEx
    {
        public FrmShutcutList()
        {
            InitializeComponent();
        }

        private void FrmShutcutList_Load(object sender, EventArgs e)
        {
            string strPath = Application.StartupPath + "\\Shutcut.txt";
            using (FileStream fsRead = new FileStream(strPath, FileMode.Open))
            {
                int fsLen = (int)fsRead.Length;
                byte[] heByte = new byte[fsLen];
                int r = fsRead.Read(heByte, 0, heByte.Length);
                txtShutcut.Text = System.Text.Encoding.Default.GetString(heByte);
            }
        }
    }
}