using DevExpress.XtraTreeList.Nodes;
using Nikita.Core;
using Nikita.Permission.DAL;
using Nikita.Permission.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Permission
{
    public partial class FrmBseUserEdit : FrmBase
    {
        private readonly Bse_SetInfoDAL _setInfoDal = new Bse_SetInfoDAL();

        private readonly string _systemId = UserInfoHelper.SystemId;

        private string _roleId;

        private string _userId;

        private Bse_MenuDAL menuDal = new Bse_MenuDAL();

        private Bse_OrganizeDAL organizeDal = new Bse_OrganizeDAL();

        private Bse_Role_MenuDAL roleMenuDal = new Bse_Role_MenuDAL();

        private Bse_UserDAL userDal = new Bse_UserDAL();

        private Bse_UserDALExtend userDalExtend = new Bse_UserDALExtend();

        private Bse_User_OrganizeDAL userOrganizeDal = new Bse_User_OrganizeDAL();

        public FrmBseUserEdit()
        {
            InitializeComponent();
        }

        public FrmBseUserEdit(string userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void BindMenuToRole()
        {
            if (_roleId == string.Empty)
            {
                return;
            }
            DataTable dtRoleMenu = roleMenuDal.GetList("State=1 and SystemId=" + _systemId + "and  Role_Id in(" + _roleId + ")").Tables[0];
            if (DataTableHelper.IsHaveRows(dtRoleMenu))
            {
                treeList1.CheckAll(); List<TreeListNode> nodes = treeList1.GetAllCheckedNodes();
                List<TreeListNode> nodesRole = new List<TreeListNode>();
                foreach (TreeListNode currentNode in nodes)
                {
                    for (int i = 0; i < dtRoleMenu.Rows.Count; i++)
                    {
                        if (dtRoleMenu.Rows[i]["Module_Id"].ToString() == currentNode["Module_Id"].ToString())
                        {
                            nodesRole.Add(currentNode);
                        }
                        currentNode.Checked = false;
                    }
                }
                foreach (TreeListNode t in nodesRole)
                {
                    treeList1.SetNodeCheckState(t, CheckState.Checked);
                }
            }
            else
            {
                if (treeList1.Nodes.Count > 0)
                {
                    DxCtlHelper.SetCheckedChildNodes(treeList1.Nodes[0], CheckState.Unchecked);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckSave())
            {
                return;
            }

            if (_userId != string.Empty)//修改
            {
                if (userDal.GetList("  User_Id !=" + _userId + " and  UserName='" + txtUserName.Text + "' ").Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(@"输入的用户名已经存在");
                    return;
                }
                DataTable dtSystem = userDal.GetList("User_Id=" + _userId + "").Tables[0];
                List<Bse_User> roleModel = ModelHandler<Bse_User>.FillModel(dtSystem);
                Bse_User user = roleModel[0];
                user.Company_Id = int.Parse(tllCompany.EditValue.ToString());
                user.Dept_Id = int.Parse(tllDept.EditValue.ToString());
                user.Birthday = txtBirthday.Text;
                user.Email = txtEmail.Text;
                user.HomeAddress = txtHomeAddress.Text;
                user.HomeTel = txtHomeTel.Text;
                user.Mobile = txtMobile.Text;
                user.AuditStatus = lueAuditState.EditValue.ToString();
                user.WorkAddress = txtWorkAddress.Text;
                user.WorkTel = txtWorkTel.Text;
                user.UserName = txtUserName.Text;
                user.Realname = txtRealName.Text;
                user.Number = txtNumber.Text;
                user.Sort = txtSort.Text == string.Empty ? 0 : int.Parse(txtSort.Text);
                user.NiName = txtNiName.Text;
                user.QQ = txtQQ.Text;
                user.Sex = cmbSex.Text;
                user.State = chkDelete.Checked ? 0 : 1;
                bool flag = userDal.Update(user);
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
            else
            {
                if (userDal.GetList("   UserName='" + txtUserName.Text + "'  ").Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(@"输入的用户名已经存在");
                    return;
                }
                Bse_User user = new Bse_User();
                user.State = 1;
                user.Bloc_Id = int.Parse(UserInfoHelper.Bloc_Id);
                user.CreateUserId = int.Parse(UserInfoHelper.CreateUserId);
                user.CreateName = UserInfoHelper.CreateName;
                user.Company_Id = int.Parse(tllCompany.EditValue.ToString());
                user.Dept_Id = int.Parse(tllDept.EditValue.ToString());
                user.Birthday = txtBirthday.Text;
                user.Email = txtEmail.Text;
                user.HomeAddress = txtHomeAddress.Text;
                user.HomeTel = txtHomeTel.Text;
                user.Mobile = txtMobile.Text;
                user.AuditStatus = lueAuditState.EditValue.ToString();
                user.WorkAddress = txtWorkAddress.Text;
                user.WorkTel = txtWorkTel.Text;
                user.UserName = txtUserName.Text;
                user.Realname = txtRealName.Text;
                user.Number = txtNumber.Text;
                user.Sort = txtSort.Text == string.Empty ? 0 : int.Parse(txtSort.Text);
                user.NiName = txtNiName.Text;
                user.QQ = txtQQ.Text;
                user.Sex = cmbSex.Text;
                user.State = chkDelete.Checked ? 0 : 1;
                user.SystemId = int.Parse(UserInfoHelper.SystemId);
                int flag = userDal.Add(user);

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
        }

        private bool CheckSave()
        {
            bool flag = true;
            if (txtUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入用户名");
                txtUserName.Select();
                flag = false;
            }
            if (txtRealName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入真实姓名");
                txtRealName.Select();
                flag = false;
            } if (tllCompany.EditValue == null)
            {
                MessageBox.Show("请选择公司");
                tllCompany.ShowPopup();
                flag = false;
            } if (tllDept.EditValue == null)
            {
                MessageBox.Show("请选择部门");
                tllDept.ShowPopup();
                flag = false;
            }
            return flag;
        }

        private void DoBind()
        {
            DataTable dtAuditState = _setInfoDal.GetList("State=1 and SystemId=" + _systemId + " and SetInfo_Key='AuditState'").Tables[0];
            DxCtlHelper.BindLookUpEdit(lueAuditState, dtAuditState, "Name", "SetInfo_Value");
            DataTable dtOrganize = organizeDal.GetList("State=1 and SystemId=" + _systemId + "").Tables[0];
            DxCtlHelper.BindTreeListLookUpEdit(tllCompany, dtOrganize, "Organize_Id", "ParentId", "Organize_Id", "Name");
            DxCtlHelper.BindTreeListLookUpEdit(tllDept, dtOrganize, "Organize_Id", "ParentId", "Organize_Id", "Name");
            DataTable dtMenu = menuDal.GetList("State=1 and SystemId=" + _systemId + "").Tables[0];
            DxCtlHelper.BindTreeList(treeList1, dtMenu, "Module_Id", "ParentId", "Name", "页面/操作名称", true);
        }

        private void FrmBseUserEdit_Load(object sender, EventArgs e)
        {
            DoBind();
            txtCreateName.Text = UserInfoHelper.UserName;
            dteCreateTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            if (_userId != string.Empty)
            {
                DataTable dt =
                    userDal.GetList("State=1 and SystemId=" + _systemId + " and User_Id=" + _userId + "  ").Tables[0];
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("发生异常:未找到用户");
                    return;
                }
                txtBirthday.Text = dt.Rows[0]["Birthday"].ToString();
                txtCreateName.Text = dt.Rows[0]["CreateName"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtHomeAddress.Text = dt.Rows[0]["HomeAddress"].ToString();
                txtHomeTel.Text = dt.Rows[0]["HomeTel"].ToString();
                txtNiName.Text = dt.Rows[0]["NiName"].ToString();
                txtNumber.Text = dt.Rows[0]["Number"].ToString();
                txtQQ.Text = dt.Rows[0]["QQ"].ToString();
                txtRealName.Text = dt.Rows[0]["RealName"].ToString();
                txtSFZ.Text = dt.Rows[0]["SFZNumber"].ToString();
                txtSort.Text = dt.Rows[0]["Sort"].ToString();
                txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                txtWorkAddress.Text = dt.Rows[0]["WorkAddress"].ToString();
                txtWorkTel.Text = dt.Rows[0]["WorkTel"].ToString();
                lueAuditState.EditValue = dt.Rows[0]["AuditStatus"].ToString();
                tllCompany.EditValue = int.Parse(dt.Rows[0]["Company_Id"].ToString());
                tllDept.EditValue = int.Parse(dt.Rows[0]["Dept_Id"].ToString());
                cmbSex.Text = dt.Rows[0]["Sex"].ToString();
                DataTable organizeTable = userDalExtend.GetListUserOrganize("a.User_Id=" + _userId + "").Tables[0];
                txtOrganize.Text = organizeTable.Rows[0]["BlockName"] + "-" + organizeTable.Rows[0]["CompanyName"] + "-" +
                                   organizeTable.Rows[0]["DeptName"]
                    ;
                DataTable roleTable = userDalExtend.GetListUserRole("a.User_Id=" + _userId + "").Tables[0];
                txtRole.Text = roleTable.Rows[0][0].ToString();

                DataTable roleIdTable = userDalExtend.GetListUserRoleIds("a.User_Id=" + _userId + "").Tables[0];
                _roleId = roleIdTable.Rows[0][0].ToString();
                BindMenuToRole();
            }
        }
    }
}