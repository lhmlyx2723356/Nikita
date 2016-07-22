using Nikita.Core;
using Nikita.Permission.DAL;
using Nikita.Permission.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Nikita.Permission
{
    public partial class FrmBseSystemEdit : FrmBase
    {
        private readonly Bse_SystemDAL _systemDal = new Bse_SystemDAL();
        private readonly string _systemId;

        public FrmBseSystemEdit()
        {
            InitializeComponent();
        }

        public FrmBseSystemEdit(string systemId)
        {
            InitializeComponent();
            _systemId = systemId;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show(@"请输入系统名称");
                txtName.Select();
                return;
            }

            if (_systemId == string.Empty)
            {
                if (_systemDal.GetList("   System_Name='" + txtName.Text + "' ").Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(@"输入的名称已经存在");
                    return;
                }
                Bse_System system = new Bse_System
                {
                    Bloc_Id = int.Parse(UserInfoHelper.Bloc_Id),
                    Company_Id = int.Parse(UserInfoHelper.Company_Id),
                    Dept_Id = int.Parse(UserInfoHelper.Dept_Id),
                    System_Name = txtName.Text.Trim(),
                    LimitNumber = txtLimitNumber.Text,
                    CustNumber = txtCustNumber.Text
                };
                int flag = _systemDal.Add(system);
                if (flag > 0)
                {
                    MessageBox.Show(@"添加成功");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(@"添加失败");
                }
            }
            else
            {
                if (_systemDal.GetList("  System_Id !=" + _systemId + " and  System_Name='" + txtName.Text + "' ").Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(@"输入的名称已经存在");
                    return;
                }
                DataTable dtSystem = _systemDal.GetList("System_Id=" + _systemId + "").Tables[0];
                List<Bse_System> roleModel = ModelHandler<Bse_System>.FillModel(dtSystem);
                Bse_System model = roleModel[0];
                model.System_Name = txtName.Text.Trim();
                model.LimitNumber = txtLimitNumber.Text;
                model.CustNumber = txtCustNumber.Text;
                bool flag = _systemDal.Update(model);
                if (flag)
                {
                    MessageBox.Show(@"修改成功");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(@"修改失败");
                }
            }
        }

        private void FrmBseSystemEdit_Load(object sender, EventArgs e)
        {
            if (_systemId != string.Empty)
            {
                DataTable dtSystem = _systemDal.GetList("System_Id=" + _systemId + "").Tables[0];
                txtName.Text = dtSystem.Rows[0]["System_Name"].ToString();
                txtCustNumber.Text = dtSystem.Rows[0]["CustNumber"].ToString();
                txtLimitNumber.Text = dtSystem.Rows[0]["LimitNumber"].ToString();
                txtRemark.Text = dtSystem.Rows[0]["Remark"].ToString();
            }
        }
    }
}