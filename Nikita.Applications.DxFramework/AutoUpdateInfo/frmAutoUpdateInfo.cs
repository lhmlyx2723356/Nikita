
using Nikita.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Applications.DxFramework
{
    public partial class frmAutoUpdateInfo : Form
    { 
        public frmAutoUpdateInfo(string AutoUpdateInfo)
        {
            InitializeComponent(); 
            this.memoEdit1.Text = AutoUpdateInfo;
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void frmAutoUpdateInfo_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image=Image.FromFile(FileHelper.GetFilePath("image","autoupdate.png"));
        }
         
    }
}
