using Nikita.Assist.DBManager.DAL;
using Nikita.Assist.DBManager.Model;
using System;
using System.Windows.Forms;

namespace Nikita.Assist.DBManager
{
    public partial class FrmSetInfoEditTable : Form
    {
        private readonly string _setordkey;

        private readonly SetTableDAL _dal = new SetTableDAL();

        private readonly int _id;

        public FrmSetInfoEditTable()
        {
            InitializeComponent();
        }

        public FrmSetInfoEditTable(int id, string setordkey)
        {
            InitializeComponent();
            this._id = id;
            this._setordkey = setordkey;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMySqlColumn.Text = string.Empty;
            txtSqlServerColumn.Text = string.Empty;
            txtChangLiang.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (txtSetValue.Text.Trim() == string.Empty)
            //{
            //    MessageBox.Show("请输入编号");
            //    this.txtSetValue.Select();
            //    return;
            //}
            //if (txtSetText.Text.Trim() == string.Empty)
            //{
            //    MessageBox.Show("请输入名称");
            //    this.txtSetText.Select();
            //    return;
            //}
            if (_id != 0)//修改
            {
                ////已经存在
                //DataSet ds = dal.GetList("State=1 and id!=" + id + " and SetKey='"+setordkey+"' and SetValue='" + txtSetValue.Text.Trim() + "' ");
                //if (ds != null && ds.Tables[0].Rows.Count > 0)
                //{
                //    MessageBox.Show("该编号已经存在");
                //    txtSetValue.Select();
                //}
                //else
                //{
                SetTable model = _dal.GetModel(_id);
                model.SetValue = txtSqlServerColumn.Text.Trim();
                model.SetText = txtMySqlColumn.Text.Trim();
                model.Remark = chkPK.Checked.ToString();
                model.ChangLiang = txtChangLiang.Text.Trim();
                bool flag = _dal.Update(model);
                if (flag)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                //}
            }
            else
            {
                //  //已经存在
                //DataSet ds = dal.GetList("State=1   and SetKey='" + setordkey + "'   and SetValue='" + txtSetValue.Text.Trim() + "' ");
                //if (ds != null && ds.Tables[0].Rows.Count > 0)
                //{
                //    MessageBox.Show("该编号已经存在");
                //    this.txtSetValue.Select();
                //    return;
                //}
                //else
                //{
                SetTable model = new SetTable
                {
                    SetText = txtMySqlColumn.Text.Trim(),
                    SetValue = txtSqlServerColumn.Text.Trim(),
                    State = 1,
                    SetKey = _setordkey,
                    Remark = chkPK.Checked.ToString(),
                    ChangLiang = txtChangLiang.Text.Trim()
                };
                int res = _dal.Add(model);
                if (res >= 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                //}
            }
        }

        private void frmSetInfoEdit_Load(object sender, EventArgs e)
        {
            if (_id != 0)
            {
                SetTable model = _dal.GetModel(_id);
                txtMySqlColumn.Text = model.SetText;
                txtSqlServerColumn.Text = model.SetValue; chkPK.Checked = model.Remark.Trim() != string.Empty;
                txtChangLiang.Text = model.ChangLiang;
            }
        }
    }
}