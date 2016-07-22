using Nikita.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Applications.WinFramework
{
    public partial class FrmAutoUpdateInfo : Form
    {
        public FrmAutoUpdateInfo(string AutoUpdateInfo)
        {
            InitializeComponent();
            this.richTextBox1.Text = AutoUpdateInfo;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAutoUpdateInfo_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Image.FromFile(FileHelper.GetFilePath("image", "autoupdate.png"));
        }
    }
}