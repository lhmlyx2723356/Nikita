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
    public partial class FrmEmailAddressEdit : Form
    {
        private EmailListDAL dal = new EmailListDAL();

        public FrmEmailAddressEdit()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入收件人名称");
                txtName.Select();
                return;
            }

            if (txtEmailAddress.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入邮件地址");
                txtEmailAddress.Select();
                return;
            }
            EmailList model = new EmailList();
            model.Remark = txtName.Text.Trim();
            model.EmailAddress = txtEmailAddress.Text.Trim();
            model.CreateDate = DateTime.Now.ToString();
            int intFlag = dal.Add(model);
            if (intFlag > 0)
            {
                MessageBox.Show("添加成功");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEmailAddressEdit_Load(object sender, EventArgs e)
        {
            txtName.Select();
        }
    }
}