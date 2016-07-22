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
    public partial class FrmSetOrdEdit : Form
    {
        private readonly SetOrdDal _dal = new SetOrdDal();

        private readonly int _id;

        public FrmSetOrdEdit()
        {
            InitializeComponent();
        }

        public FrmSetOrdEdit(int id)
        {
            InitializeComponent();
            _id = id;
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
                MessageBox.Show(@"请输入代码");
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
                DataSet ds = _dal.GetList("State=1 and id!=" + _id + "  and SetOrdKey='" + txtSetValue.Text.Trim() + "' ");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(@"该代码已经存在");
                    txtSetValue.Select();
                }
                else
                {
                    SetOrd model = _dal.GetModel(_id);
                    model.SetOrdKey = txtSetValue.Text.Trim();
                    model.SetOrdText = txtSetText.Text.Trim();
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
                DataSet ds = _dal.GetList("State=1   and  SetOrdKey='" + txtSetValue.Text.Trim() + "' ");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(@"该代码已经存在");
                    txtSetValue.Select();
                }
                else
                {
                    SetOrd model = new SetOrd
                    {
                        SetOrdText = txtSetText.Text.Trim(),
                        SetOrdKey = txtSetValue.Text.Trim(),
                        State = 1
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
                SetOrd model = _dal.GetModel(_id);
                txtSetText.Text = model.SetOrdText;
                txtSetValue.Text = model.SetOrdKey;
                txtSetValue.ReadOnly = true;
            }
        }
    }
}