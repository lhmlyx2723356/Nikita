using FrmEmailSend.DAL;
using FrmEmailSend.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Assist.EmailSend
{
    public partial class FrmEmailLog : Form
    {
        private EmailSendLogDAL dal = new EmailSendLogDAL();

        public FrmEmailLog()
        {
            InitializeComponent();
        }

        private void FrmEmailLog_Load(object sender, EventArgs e)
        {
            grdLog.AutoGenerateColumns = false;
            DataSet ds = dal.GetList("");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdLog.DataSource = ds.Tables[0];
            }
        }
    }
}