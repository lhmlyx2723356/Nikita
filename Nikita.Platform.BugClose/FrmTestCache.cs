using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.Base.CacheStore;

namespace Nikita.Platform.BugClose
{
    public partial class FrmTestCache : Form
    {
        public FrmTestCache()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //SendService sendService = new SendService();
            //sendService.AddMessage(); 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //SendCachMessage sendService = new SendCachMessage();
            //sendService.GetMessage();
        }
    }
}
