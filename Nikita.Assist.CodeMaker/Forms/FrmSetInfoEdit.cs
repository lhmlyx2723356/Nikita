using Nikita.Assist.CodeMaker.DAL;
using Nikita.Assist.CodeMaker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Assist.CodeMaker
{
    public partial class FrmSetInfoEdit : Form
    {
        private readonly SetDal _dal = new SetDal();

        private readonly int _id;

        private readonly string _setordkey;

        public FrmSetInfoEdit()
        {
            InitializeComponent();
        }

        public FrmSetInfoEdit(int id, string setordkey)
        {
            InitializeComponent();
            _id = id;
            _setordkey = setordkey;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSetText.Text = string.Empty;
            txtSetValue.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSetValue.Text.Trim() == string.Empty)
            {
                MessageBox.Show(@"请输入编号");
                txtSetValue.Select();
                return;
            }
            if (txtSetText.Text.Trim() == string.Empty)
            {
                MessageBox.Show(@"请输入名称");
                txtSetText.Select();
                return;
            }
            if (_id != 0)//修改
            {
                //已经存在
                DataSet ds = _dal.GetList("State=1 and id!=" + _id + " and SetKey='" + _setordkey + "' and SetValue='" + txtSetValue.Text.Trim() + "' ");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(@"该编号已经存在");
                    txtSetValue.Select();
                }
                else
                {
                    Set model = _dal.GetModel(_id);
                    model.SetValue = txtSetValue.Text.Trim();
                    model.SetText = txtSetText.Text.Trim();
                    bool flag = _dal.Update(model);
                    if (flag)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
            else
            {
                //已经存在
                DataSet ds = _dal.GetList("State=1   and SetKey='" + _setordkey + "'   and SetValue='" + txtSetValue.Text.Trim() + "' ");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(@"该编号已经存在");
                    txtSetValue.Select();
                }
                else
                {
                    Set model = new Set
                    {
                        SetText = txtSetText.Text.Trim(),
                        SetValue = txtSetValue.Text.Trim(),
                        State = 1,
                        SetKey = _setordkey
                    };
                    int res = _dal.Add(model);
                    if (res >= 0)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
        }

        private void FrmSetInfoEdit_Load(object sender, EventArgs e)
        {
            if (_id != 0)
            {
                Set model = _dal.GetModel(_id);
                if (model.SetKey != "1")
                {
                    txtSetText.Text = model.SetText;
                    txtSetValue.Text = model.SetValue;
                }
                else
                {
                    txtSetText.Text = model.SetText;
                    txtSetValue.Text = model.SetValue;
                }
            }
        }
    }
}