using Nikita.Core;
using Nikita.Permission.DAL;
using Nikita.Permission.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Nikita.Permission
{
    public partial class FrmBseMenuEdit : FrmBase
    {
        private readonly Bse_MenuDAL _menuDal;  
        private readonly Bse_SetInfoDAL _setInfoDal;
        private readonly string _moduleId;
        public bool IsAddMenuWithoutFormName { get; private set; }

        public FrmBseMenuEdit(string moduleId)
        {
            InitializeComponent();
            _moduleId = moduleId;
            _setInfoDal = new Bse_SetInfoDAL();
            _menuDal = new Bse_MenuDAL();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text.Trim().Length == 0)
            {
                MessageBox.Show(@"请输入菜单编号");
                txtName.Select();
                return;
            }
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show(@"请输入菜单名称");
                txtName.Select();
                return;
            } 
            if (lueMenuGroupTxt.Text.Trim().Length == 0)
            {
                MessageBox.Show(@"请选择菜单组");
                lueMenuGroupTxt.ShowPopup();
                return;
            }
            if (_moduleId == string.Empty)
            {
                if (_menuDal.GetList("Name='" + txtName.Text + "'  ").Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(@"输入的名称已经存在");
                    return;
                } 
                Bse_Menu system = new Bse_Menu
                {
                    FormName = txtClass.Text.Trim(),
                    Number = txtNumber.Text.Trim(),
                    ImagUrl = txtIcon.Text.Trim(),
                    State =chkIsVisible.Checked ? 1 : 0,
                    Category = lueMenuType.EditValue.ToString(),
                    ParentId = int.Parse(trePreMenu.EditValue == null ||  trePreMenu.EditValue.ToString()==string.Empty ? "0" : trePreMenu.EditValue.ToString()),
                    Bloc_Id = int.Parse(UserInfoHelper.Bloc_Id),
                    Company_Id = int.Parse(UserInfoHelper.Company_Id),
                    Dept_Id = int.Parse(UserInfoHelper.Dept_Id),
                    SystemId = int.Parse(UserInfoHelper.SystemId),
                    GroupTxt = lueMenuGroupTxt.EditValue.ToString(),
                    Name = txtName.Text.Trim(),
                    ControlPower = txtControlPower.Text.Trim()
                };

                int flag = _menuDal.Add(system);
                if (flag > 0)
                {
                    MessageBox.Show(@"添加成功");
                    DialogResult = DialogResult.OK;
                    IsAddMenuWithoutFormName = string.IsNullOrEmpty(system.FormName);
                }
                else
                {
                    MessageBox.Show(@"添加失败");
                }
            }
            else
            {
                if (_menuDal.GetList("  Module_Id !=" + _moduleId + " and  Name='" + txtName.Text + "' ").Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(@"输入的名称已经存在");
                    return;
                }
                DataTable dtMenuTable= _menuDal.GetList("Module_Id=" + _moduleId + "").Tables[0];
                List<Bse_Menu> roleModel = ModelHandler<Bse_Menu>.FillModel(dtMenuTable);
                Bse_Menu model = roleModel[0];
                model.Name = txtName.Text.Trim();
                model.Number = txtNumber.Text.Trim();
                model.ImagUrl = txtIcon.Text.Trim(); 
                model.State = chkIsVisible.Checked ? 1 : 0;
                model.ParentId = int.Parse(trePreMenu.EditValue.ToString());
                model.Category = lueMenuType.EditValue.ToString();
                model.GroupTxt = lueMenuGroupTxt.EditValue.ToString();
                model.ControlPower = txtControlPower.Text.Trim();
                bool flag = _menuDal.Update(model);
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

        private void DoBind()
        {
            DataTable dtSystem = _menuDal.GetList("State=1  and SystemId='" + UserInfoHelper.SystemId + "'").Tables[0];
            DataTable dtMenuType = _setInfoDal.GetList("SetInfo_Key='MenuType' and State=1 and SystemId='" + UserInfoHelper.SystemId + "'").Tables[0];
            DataTable dtMenuGroupTxt = _setInfoDal.GetList("SetInfo_Key='MenuGroupTxt' and State=1 and SystemId='" + UserInfoHelper.SystemId + "'").Tables[0];
            DxCtlHelper.BindTreeListLookUpEdit(trePreMenu, dtSystem, "Module_Id", "ParentId", "Module_Id", "Name");
            DxCtlHelper.BindLookUpEdit(lueMenuType, dtMenuType, "Name", "SetInfo_Value");
            DxCtlHelper.BindLookUpEdit(lueMenuGroupTxt, dtMenuGroupTxt, "Name", "SetInfo_Value");
        }

        private void FrmBseMenuEdit_Load(object sender, EventArgs e)
        {
            DoBind();
            if (_moduleId == string.Empty) return;
            DataTable dtMenuTable = _menuDal.GetList("Module_Id=" + _moduleId + "  and SystemId='" + UserInfoHelper.SystemId + "' ").Tables[0];
            txtName.Text = dtMenuTable.Rows[0]["Name"].ToString();
            txtRemark.Text = dtMenuTable.Rows[0]["Remark"].ToString();
            txtClass.Text = dtMenuTable.Rows[0]["FormName"].ToString();
            trePreMenu.EditValue = int.Parse(dtMenuTable.Rows[0]["ParentId"].ToString());
            lueMenuType.EditValue = dtMenuTable.Rows[0]["Category"].ToString();
            lueMenuGroupTxt.EditValue = dtMenuTable.Rows[0]["GroupTxt"].ToString();
            txtIcon.Text = dtMenuTable.Rows[0]["ImagUrl"].ToString();
            chkIsVisible.Checked = dtMenuTable.Rows[0]["State"].ToString() == "1";
            txtNumber.Text = dtMenuTable.Rows[0]["Number"].ToString();
            txtControlPower.Text = dtMenuTable.Rows[0]["ControlPower"].ToString();
        }
    }
}