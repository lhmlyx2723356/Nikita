using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using Nikita.Core;
using Nikita.Permission.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Nikita.Permission
{
    public partial class FrmSelectUser : FrmBase
    {
        private readonly Bse_OrganizeDAL _organizeDal = new Bse_OrganizeDAL();
        private readonly Bse_RoleDAL _roleDal = new Bse_RoleDAL();
        private readonly string _roleId;
        private readonly Bse_UserDAL _userDal = new Bse_UserDAL();

        private readonly Bse_User_RoleDALExtend _userRoleDalExtend = new Bse_User_RoleDALExtend();

        private Bse_User_RoleDAL _userRoleDal = new Bse_User_RoleDAL();

        private string strUserIds;

        public FrmSelectUser()
        {
            InitializeComponent();
        }

        public FrmSelectUser(string roleId)
        {
            InitializeComponent();
            _roleId = roleId;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (memoEdit2.Text.Trim().Length == 0)
            {
                MessageBox.Show(@"请选择要添加的人员");
                return;
            }
            bool flag = _userRoleDalExtend.AddUserToRole(DxCtlHelper.GetSelectRowsFileValue(gridVMain, "User_Id", ','), _roleId, UserInfoHelper.CreateUserId,
                      UserInfoHelper.Dept_Id, UserInfoHelper.Company_Id, UserInfoHelper.Bloc_Id, UserInfoHelper.SystemId, "");

            if (flag)
            {
                MessageBox.Show(@"添加成功"); DialogResult = DialogResult.OK;
            }
        }

        private void DoBind()
        {
            DataTable dtDept = _organizeDal.GetList("State=1 and SystemId=" + UserInfoHelper.SystemId + "").Tables[0];
            DxCtlHelper.BindTreeList(treDept, dtDept, "Organize_Id", "ParentId", "Name", "机构列表", true);
            DataTable dtRole = _roleDal.GetList("State=1 and SystemId=" + UserInfoHelper.SystemId + "").Tables[0];
            DxCtlHelper.BindTreeList(treeList2, dtRole, "Role_Id", "Role_Id", "Name", "角色列表", true);
            DataTable dtUserName = _userRoleDalExtend.GetUserByRoleId("a.RoleId=" + _roleId + " and a.SystemId=" + UserInfoHelper.SystemId + "").Tables[0];
            if (DataTableHelper.IsHaveRows(dtUserName))
            {
                memoEdit1.Text = DataTableHelper.GetStringWithSplit(dtUserName, "Realname", ',');
                strUserIds = DataTableHelper.GetStringWithSplit(dtUserName, "User_Id", ',');
            }
            else
            {
                strUserIds = string.Empty;
            }
        }

        private void frmSelectUser_Load(object sender, EventArgs e)
        {
            gridVMain.OptionsSelection.MultiSelect = true;
            gridVMain.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gridVMain.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DefaultBoolean.True;
            DoBind();
            treDept.FocusedNodeChanged += treDept_FocusedNodeChanged;
            treeList2.FocusedNodeChanged += treeList2_FocusedNodeChanged;
            treDept_FocusedNodeChanged(treDept, new FocusedNodeChangedEventArgs(null, treDept.FocusedNode));
            treDept.ExpandAll();
            treeList2.ExpandAll();
        }

        private void gridVMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            memoEdit2.Text = DxCtlHelper.GetSelectRowsFileValue(gridVMain, "Realname", ',');
        }

        private void treDept_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                string organizeId = e.Node["Organize_Id"].ToString();
                DataTable dtFocusDeptUser =
                    _userDal.GetList("State=1 and SystemId=" + UserInfoHelper.SystemId + " and ( Dept_Id =" + organizeId + "  or  Company_Id =" + organizeId + " or  Bloc_Id =" + organizeId + "  )").Tables[0];
                //过滤已经存在的用户
                if (strUserIds.Length > 0)
                {
                    DataRow[] drs = dtFocusDeptUser.Select(" User_Id not in (" + strUserIds + ") ");
                    if (drs.Length > 0)
                    {
                        gridCMain.DataSource = drs.CopyToDataTable();
                    }
                    else
                    {
                        gridCMain.DataSource = null;
                    }
                }
                else
                {
                    gridCMain.DataSource = dtFocusDeptUser;
                }
            }
        }

        private void treeList2_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                string roleId = e.Node["Role_Id"].ToString();
                DataTable dtFocusRoleUser = _userRoleDalExtend.GetUserByRoleId("a.RoleId=" + roleId + " and a.SystemId=" + UserInfoHelper.SystemId + "").Tables[0];
                //过滤已经存在的用户
                if (strUserIds.Length > 0)
                {
                    DataRow[] drs = dtFocusRoleUser.Select(" User_Id not in (" + strUserIds + ") ");
                    if (drs.Length > 0)
                    {
                        gridCMain.DataSource = drs.CopyToDataTable();
                    }
                    else
                    {
                        gridCMain.DataSource = null;
                    }
                }
                else
                {
                    gridCMain.DataSource = dtFocusRoleUser;
                }
            }
        }
    }
}