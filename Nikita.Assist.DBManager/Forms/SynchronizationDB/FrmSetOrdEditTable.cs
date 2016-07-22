using Nikita.Assist.DBManager.DAL;
using Nikita.Assist.DBManager.Model;
using System;
using System.Data;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;

namespace Nikita.Assist.DBManager
{
    public partial class FrmSetOrdEditTable : Form
    {
        private readonly SetOrdTableDAL _dal = new SetOrdTableDAL();
        private readonly int _id;
        private string[] AllowTypeAry = { "mssql导入到mysql", "mssql更新到mysql", "mysql导入到mssql", "mysql更新到mssql" };

        public FrmSetOrdEditTable()
        {
            InitializeComponent();
        }

        public FrmSetOrdEditTable(int id)
        {
            InitializeComponent();
            _id = id;
            for (int i = 0; i < AllowTypeAry.Length; i++)
            {
                CCBoxItem item = new CCBoxItem(AllowTypeAry[i], i);
                chkAllowType.Items.Add(item);
            }
            chkAllowType.MaxDropDownItems = 5;
            chkAllowType.DisplayMember = "Name";
            chkAllowType.ValueSeparator = ",";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSqlServer.Text = string.Empty;
            txtMySql.Text = string.Empty;
            txtCode.Text = string.Empty;
            for (int i = 0; i < chkAllowType.Items.Count; i++)
            {
                chkAllowType.SetItemChecked(i, false);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() == string.Empty)
            {
                MessageBox.Show(@"请输入编码");
                txtCode.Select();
                return;
            }
            if (txtSqlServer.Text.Trim() == string.Empty)
            {
                MessageBox.Show(@"请输入mssql表名称");
                txtSqlServer.Select();
                return;
            }
            if (txtMySql.Text.Trim() == string.Empty)
            {
                MessageBox.Show(@"请输入mysql表名称");
                txtSqlServer.Select();
                return;
            }
            if (_id != 0)//修改
            {
                //已经存在
                DataSet ds = _dal.GetList("State=1 and id!=" + _id + "  and SetOrdKey='" + txtCode.Text.Trim() + "' ");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(@"该编码已经存在");
                    txtCode.Select();
                }
                else
                {
                    SetOrdTable model = _dal.GetModel(_id);
                    model.SetOrdKey = txtCode.Text.Trim();
                    model.SetOrdText = txtSqlServer.Text.Trim();
                    model.Remark = txtMySql.Text.Trim();
                    model.AllowWorkType = chkAllowType.Text;
                    bool flag = _dal.Update(model);
                    if (flag != true) return;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                //已经存在
                DataSet ds = _dal.GetList("State=1   and  SetOrdKey='" + txtCode.Text.Trim() + "' ");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(@"该编码已经存在");
                    txtCode.Select();
                }
                else
                {
                    SetOrdTable model = new SetOrdTable
                    {
                        SetOrdText = txtSqlServer.Text.Trim(),
                        SetOrdKey = txtCode.Text.Trim(),
                        State = 1,
                        Remark = txtMySql.Text.Trim(),
                        AllowWorkType = chkAllowType.Text
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

        private void frmSetInfoEdit_Load(object sender, EventArgs e)
        {
            if (_id != 0)
            {
                SetOrdTable model = _dal.GetModel(_id);
                txtSqlServer.Text = model.SetOrdText;
                txtCode.Text = model.SetOrdKey;
                txtMySql.Text = model.Remark;
                //model.AllowWorkType = chkAllowType.Text;
                string[] strArray = model.AllowWorkType.Split(',');
                for (int i = 0; i < strArray.Length; i++)
                {
                    for (int j = 0; j < AllowTypeAry.Length; j++)
                    {
                        if (strArray[i].Trim() == AllowTypeAry[j].Trim())
                        {
                            chkAllowType.SetItemChecked(j, true);
                        }
                    }
                }
                txtCode.ReadOnly = true;
            }
        }
    }
}