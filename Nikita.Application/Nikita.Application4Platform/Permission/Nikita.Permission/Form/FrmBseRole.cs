using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Nikita.Core;
using Nikita.Permission.DAL;
using Nikita.Permission.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nikita.Permission
{
    public partial class FrmBseRole : FrmBase
    {
        private readonly string[] _ctrlNextArray = { "txtRoleName", "treCompany", "txtRoleNumber", "txtSort", "lueCategory", "txtRemark" };

        private readonly Bse_OrganizeDAL _organizeDal = new Bse_OrganizeDAL();

        private readonly Bse_RoleDAL _roleDal = new Bse_RoleDAL();

        private readonly Bse_SetInfoDAL _setInfoDal = new Bse_SetInfoDAL();

        private readonly string _systemId = UserInfoHelper.SystemId;

        private string _mode;

        private string _roleId;

        private Bse_UserDAL _userDal = new Bse_UserDAL();

        private Bse_MenuDAL menuDal = new Bse_MenuDAL();

        private Bse_Role_MenuDAL roleMenuDal = new Bse_Role_MenuDAL();

        private Bse_Role_MenuDALExtend roleMenuDalExtend = new Bse_Role_MenuDALExtend();

        private Bse_User_RoleDAL userRoleDal = new Bse_User_RoleDAL();

        private Bse_User_RoleDALExtend userRoleDalExtend = new Bse_User_RoleDALExtend();

        public FrmBseRole()
        {
            InitializeComponent();
        }

        private void FrmBseRole_Load(object sender, EventArgs e)
        {
            gridVMain.OptionsSelection.MultiSelect = true;
            gridVMain.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gridVMain.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DefaultBoolean.True;
            DoBind();
            _mode = "VIEW";
            SetMode(_mode);
            treeList1.ExpandAll();
        }

        #region 事件

        private void btn_Click(object sender, ItemClickEventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                switch (e.Item.Name)
                {
                    case "btnAdd":
                        DoAdd();
                        break;

                    case "btnEdit":
                        DoEdit();
                        break;

                    case "btnCancel":
                        DoCancel();
                        break;

                    case "btnSave":
                        DoSave();
                        break;

                    case "btnDelete":
                        DoDelete();
                        break;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(@"错误:" + err.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                SimpleButton btn = sender as SimpleButton;
                Cursor = Cursors.WaitCursor;
                if (btn == null) return;
                switch (btn.Name)
                {
                    case "btnRefresh":
                        DoBindMenu();
                        break;

                    case "btnSaveOperation":
                        DoSaveOperation();
                        break;

                    case "btnNew":
                        DoNew();
                        break;

                    case "btnRemove":
                        DoRemove();
                        break;

                    case "btnRefreshDept":
                        DoRefreshDept();
                        break;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(@"错误:" + err.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                var dataRowView = treeList1.GetDataRecordByNode(e.Node) as DataRowView;
                if (dataRowView != null)
                {
                    DataRow dr = dataRowView.Row;
                    if (dr == null)
                        return;

                    if (dr.RowState != DataRowState.Added && _mode != "VIEW")
                    {
                        SetMode("View");
                    }
                    _roleId = dr["Role_Id"].ToString();
                    DxCtlHelper.SetControlBindings(layoutControl1, dr.Table);
                    DataTable dtUserName = userRoleDalExtend.GetUserByRoleId("a.RoleId=" + _roleId + " and a.SystemId=" + UserInfoHelper.SystemId + "").Tables[0];
                    gridCMain.DataSource = dtUserName;
                    BindMenuToRole();
                }
            }
        }

        private void treeList2_AfterCheckNode(object sender, NodeEventArgs e)
        {
            DxCtlHelper.SetCheckedChildNodes(e.Node, e.Node.CheckState);
            DxCtlHelper.SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }

        #endregion 事件

        #region 方法

        public Dictionary<string, string> GetSelectTreeNodeValues(TreeList TreeListMain, string FileName, char split)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            List<TreeListNode> nodes = TreeListMain.GetAllCheckedNodes();
            foreach (TreeListNode currentNode in nodes)
            {
                if (currentNode["Types"] == "System")
                {
                    dic.Add(currentNode[FileName].ToString(), string.Empty);
                }
                if (currentNode["Types"] == "Menu")
                {
                    List<TreeListNode> lstNodes = nodes.Where(t => t.ParentNode == currentNode).ToList();
                    if (lstNodes.Count > 0)
                    {
                        string strControlPower = string.Empty;
                        foreach (TreeListNode item in lstNodes)
                        {
                            strControlPower += item["Value"].ToString() + "=" + item["Name"].ToString() + ",";
                        }
                        strControlPower = strControlPower.TrimEnd(',');
                        dic.Add(currentNode[FileName].ToString(), strControlPower);
                    }
                    else
                    {
                        dic.Add(currentNode[FileName].ToString(), string.Empty);
                    }
                }
            }
            return dic;
        }

        public void SetMode(string strMode)
        {
            switch (strMode.ToUpper())
            {
                case "ADD":
                    DxCtlHelper.SetControlEnabled(layoutControl1, false);
                    DxCtlHelper.SetBtnEnabled(new Component[] { btnSave, btnCancel }, true);
                    DxCtlHelper.SetBtnEnabled(new Component[] { btnAdd, btnDelete, btnEdit }, false);
                    DxCtlHelper.SetControlEmpty(layoutControl1);
                    DxCtlHelper.SetControlEnabled(layoutControl1, true, _ctrlNextArray);
                    break;

                case "EDIT":
                    DxCtlHelper.SetControlEnabled(layoutControl1, false);
                    DxCtlHelper.SetBtnEnabled(new Component[] { btnSave, btnCancel }, true);
                    DxCtlHelper.SetBtnEnabled(new Component[] { btnAdd, btnDelete, btnEdit }, false);
                    DxCtlHelper.SetControlEnabled(layoutControl1, true, _ctrlNextArray);
                    break;

                case "VIEW":
                    DxCtlHelper.SetControlEnabled(layoutControl1, false);
                    DxCtlHelper.SetBtnEnabled(new Component[] { btnSave, btnCancel }, false);
                    DxCtlHelper.SetBtnEnabled(new Component[] { btnAdd, btnDelete, btnEdit }, true);
                    DxCtlHelper.SetControlEnabled(layoutControl1, false, _ctrlNextArray);
                    break;
            }
        }

        private void BindMenuToRole()
        {
            DataTable dtRoleMenu = roleMenuDal.GetList("State=1 and SystemId=" + _systemId + "and  Role_Id =" + _roleId + "").Tables[0];
            if (DataTableHelper.IsHaveRows(dtRoleMenu))
            {
                treeList2.CheckAll();
                List<TreeListNode> nodes = treeList2.GetAllCheckedNodes();
                List<TreeListNode> nodesRole = new List<TreeListNode>();
                foreach (TreeListNode currentNode in nodes)
                {
                    for (int i = 0; i < dtRoleMenu.Rows.Count; i++)
                    {
                        if (dtRoleMenu.Rows[i]["Module_Id"].ToString() == currentNode["Module_Id"].ToString())
                        {
                            nodesRole.Add(currentNode);

                            if (dtRoleMenu.Rows[i]["Allowed_Operator"].ToString() != string.Empty)
                            {
                                string[] strAllowed_Operator = dtRoleMenu.Rows[i]["Allowed_Operator"].ToString().Split(',');
                                foreach (TreeListNode item in currentNode.Nodes)
                                {
                                    foreach (var itemAllow in strAllowed_Operator)
                                    {
                                        if (item.GetDisplayText("Name") == itemAllow.Split('=')[1])
                                        {
                                            nodesRole.Add(item);
                                        }
                                    }
                                }
                            }
                        }
                        currentNode.Checked = false;
                    }
                }
                foreach (TreeListNode t in nodesRole)
                {
                    treeList2.SetNodeCheckState(t, CheckState.Checked);
                }
            }
            else
            {
                if (treeList2.Nodes.Count > 0)
                {
                    DxCtlHelper.SetCheckedChildNodes(treeList2.Nodes[0], CheckState.Unchecked);
                }
            }
        }

        private bool CheckSave()
        {
            bool flag = true;
            if (treCompany.EditValue == null)
            {
                MessageBox.Show(@"请先选择所属公司");
                treCompany.ShowPopup();
                return false;
            }
            if (txtRoleName.Text.Trim().Length == 0)
            {
                MessageBox.Show(@"请先输入角色名称");
                txtRoleName.Select();
                return false;
            }
            if (txtRoleNumber.Text.Trim().Length == 0)
            {
                MessageBox.Show(@"请先输入角色编码");
                treCompany.ShowPopup();
                return false;
            }
            return flag;
        }

        //新增
        private void DoAdd()
        {
            _mode = "ADD";
            SetMode(_mode);
        }

        private void DoBind()
        {
            DataTable dtRole = _roleDal.GetList("State=1").Tables[0];
            DxCtlHelper.BindTreeList(treeList1, dtRole, "Role_Id", "Role_Id", "Name", "角色列表", true);
            DataTable dtRoleType = _setInfoDal.GetList("State=1 and SystemId=" + _systemId + " and SetInfo_Key='RoleType'").Tables[0]; DxCtlHelper.BindLookUpEditWithInt(lueCategory, dtRoleType, "Name", "SetInfo_Value");
            DataTable dtDepart = _organizeDal.GetList("State=1 and SystemId=" + _systemId + "").Tables[0];
            DxCtlHelper.BindTreeListLookUpEdit(treCompany, dtDepart, "Organize_Id", "ParentId", "Organize_Id", "Name");
            DataTable dtUserName = userRoleDalExtend.GetUserByRoleId("a.RoleId=" + _roleId + " and a.SystemId=" + UserInfoHelper.SystemId + "").Tables[0];
            gridCMain.DataSource = dtUserName;
            DoBindMenu();
            BindMenuToRole();
            //treeList1.FocusedNodeChanged += new FocusedNodeChangedEventHandler(treeList1_FocusedNodeChanged); ;
        }

        //刷新功能菜单列表
        private void DoBindMenu()
        {
            DataTable dtMenu = menuDal.GetList("State=1 and SystemId=" + _systemId + "").Tables[0];
            DataTable dtMenuNew = GetMenuTable(dtMenu);
            DxCtlHelper.BindTreeList(treeList2, dtMenuNew, "Module_Id", "ParentId", "Name", "页面/操作名称", true);
        }

        //撤销
        private void DoCancel()
        {
            SetMode(_mode);
            treeList1_FocusedNodeChanged(treeList1, new FocusedNodeChangedEventArgs(null, treeList1.FocusedNode));
        }

        //private void GetChildNodes(TreeListNode parentNode, List<TreeListNode> list)
        //{
        //    if (parentNode.Nodes.Count > 0)
        //    {
        //        foreach (TreeListNode node in parentNode.Nodes)
        //        {
        //            list.Add(node);
        //            if (node.Nodes.Count > 0)
        //            {
        //                GetChildNodes(node, list);
        //            }
        //        }
        //    }
        //}
        //作废
        private void DoDelete()
        {
            List<Bse_Role> roleModel = ModelHandler<Bse_Role>.FillModel(_roleDal.GetList("Role_Id=" + _roleId + "").Tables[0]);
            Bse_Role model = roleModel[0];
            model.State = 0;
            bool flag = _roleDal.Update(roleModel[0]);
            if (flag)
            {
                MessageBox.Show(@"作废成功");
                DataTable dtRole = _roleDal.GetList("State=1").Tables[0];
                DxCtlHelper.BindTreeList(treeList1, dtRole, "Role_Id", "Role_Id", "Name", "角色列表", true);
            }
            else
            {
                MessageBox.Show(@"作废失败");
            }
        }

        //修改
        private void DoEdit()
        {
            _mode = "EDIT";
            SetMode(_mode);
        }

        //添加
        private void DoNew()
        {
            FrmSelectUser selectUser = new FrmSelectUser(_roleId);
            if (selectUser.ShowDialog() == DialogResult.OK)
            {
                DataTable dtUserName = userRoleDalExtend.GetUserByRoleId("a.RoleId=" + _roleId + " and a.SystemId=" + UserInfoHelper.SystemId + "").Tables[0];
                gridCMain.DataSource = dtUserName;
            }
        }

        //刷新机构
        private void DoRefreshDept()
        {
            DataTable dtDepart = _organizeDal.GetList("State=1 and SystemId=" + _systemId + "").Tables[0];
            DxCtlHelper.BindTreeListLookUpEdit(treCompany, dtDepart, "Organize_Id", "ParentId", "Organize_Id", "Name");
        }

        //移除用户
        private void DoRemove()
        {
            if (treeList1.FocusedNode == null)
            {
                MessageBox.Show(@"请先选中角色");
                return;
            }

            if (gridVMain.SelectedRowsCount == 0)
            {
                MessageBox.Show(@"请先选中要移除的用户");
                return;
            }
            string userRoleIds = DxCtlHelper.GetSelectRowsFileValue(gridVMain, "User_Role_Id", ',');
            bool flag = userRoleDal.DeleteByCond("User_Role_Id in(" + userRoleIds + ")");
            if (flag)
            {
                MessageBox.Show(@"移除成功"); DataTable dtUserName = userRoleDalExtend.GetUserByRoleId("a.RoleId=" + _roleId + " and a.SystemId=" + UserInfoHelper.SystemId + "").Tables[0];
                gridCMain.DataSource = dtUserName;
            }
            else
            {
                MessageBox.Show(@"移除失败");
            }
        }

        //保存
        private void DoSave()
        {
            if (!CheckSave()) return;
            if (_mode == "ADD")
            {
                if (_roleDal.GetList("  RoleNumber=" + txtRoleNumber.Text + "  and SystemId=" + _systemId + "").Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(@"输入的编码已经存在");
                    return;
                }

                Bse_Role role = new Bse_Role
                {
                    Name = txtRoleName.Text.Trim(),
                    OwnerCompany = int.Parse(treCompany.EditValue.ToString()),
                    RoleNumber = txtRoleNumber.Text.Trim(),
                    Type = lueCategory.EditValue == null || lueCategory.Text.Trim() == string.Empty ? "-1" : lueCategory.EditValue.ToString(),
                    Sort = txtSort.Text.Trim() == string.Empty ? 1000 : int.Parse(txtSort.Text.Trim()),
                    Remark = txtRemark.Text,
                    SystemId = int.Parse(_systemId),
                    State = 1
                };
                int flag = _roleDal.Add(role);
                if (flag > 0)
                {
                    MessageBox.Show(@"添加成功");
                    DataTable dtRole = _roleDal.GetList("State=1").Tables[0];
                    DxCtlHelper.BindTreeList(treeList1, dtRole, "Role_Id", "Role_Id", "Name", "角色列表", true);
                }
                else
                {
                    MessageBox.Show(@"添加失败");
                }
            }

            if (_mode == "EDIT")
            {
                if (treeList1.FocusedNode == null)
                {
                    MessageBox.Show(@"请先选择要修改的角色");
                    return;
                }
                if (_roleDal.GetList("Role_Id!=" + _roleId + " and  RoleNumber=" + txtRoleNumber.Text + " ").Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(@"输入的编码已经存在");
                    return;
                }

                List<Bse_Role> roleModel = ModelHandler<Bse_Role>.FillModel(_roleDal.GetList("Role_Id=" + _roleId + "").Tables[0]);
                Bse_Role model = roleModel[0];
                model.Name = txtRoleName.Text.Trim();
                model.OwnerCompany = int.Parse(treCompany.EditValue.ToString());
                model.RoleNumber = txtRoleNumber.Text.Trim();
                model.Type = lueCategory.EditValue == null ? "-1" : lueCategory.EditValue.ToString();
                model.Sort = int.Parse(txtSort.Text.Trim());
                model.Remark = txtRemark.Text;
                model.SystemId = int.Parse(_systemId);

                bool flag = _roleDal.Update(roleModel[0]);
                if (flag)
                {
                    MessageBox.Show(@"修改成功");
                    DataTable dtRole = _roleDal.GetList("State=1").Tables[0];
                    DxCtlHelper.BindTreeList(treeList1, dtRole, "Role_Id", "Role_Id", "Name", "角色列表", true);
                }
                else
                {
                    MessageBox.Show(@"修改失败");
                }
            }
        }

        //保存操作
        private void DoSaveOperation()
        {
            Dictionary<string, string> checkValues = GetSelectTreeNodeValues(treeList2, "Module_Id", ',');
            if (checkValues.Count == 0)
            {
                MessageBox.Show(@"请先选择要保存的页面功能");
                return;
            }
            roleMenuDal.DeleteByCond("Role_Id=" + _roleId + " and   SystemId=" + UserInfoHelper.SystemId + "");
            bool flag = roleMenuDalExtend.AddMenuToRole(checkValues, _roleId, UserInfoHelper.CreateUserId, UserInfoHelper.Dept_Id, UserInfoHelper.Company_Id, UserInfoHelper.Bloc_Id, UserInfoHelper.SystemId);
            MessageBox.Show(flag ? @"添加成功" : @"添加失败");
        }

        private DataTable GetMenuTable(DataTable dtMenu)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Module_Id", typeof(int));
            dt.Columns.Add("ParentId", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Value", typeof(string));
            dt.Columns.Add("Types", typeof(string));
            foreach (DataRow dr in dtMenu.Rows)
            {
                string strControlType = string.Empty;
                if (dr["ParentId"].ToString() == "0")
                {
                    strControlType = "System";
                }
                else if (int.Parse(dr["ParentId"].ToString()) > 0)
                {
                    strControlType = "Menu";
                }
                DataRow drNew = dt.NewRow();

                drNew["Module_Id"] = dr["Module_Id"];
                drNew["ParentId"] = dr["ParentId"];
                drNew["Name"] = dr["Name"];
                drNew["Value"] = string.Empty;
                drNew["Types"] = strControlType;
                dt.Rows.Add(drNew);
                if (dr["ControlPower"].ToString().Trim() != string.Empty)
                {
                    string[] strControlPower = dr["ControlPower"].ToString().Trim().Split(',');
                    for (int i = 0; i < strControlPower.Length; i++)
                    {
                        DataRow drPower = dt.NewRow();
                        drPower["Module_Id"] = int.Parse(dr["Module_Id"].ToString()) + 100000 + i;
                        drPower["ParentId"] = dr["Module_Id"];
                        drPower["Value"] = strControlPower[i].Split('=')[0];
                        drPower["Name"] = strControlPower[i].Split('=')[1];
                        drPower["Types"] = "Control";
                        dt.Rows.Add(drPower);
                    }
                }
            }
            return dt;
        }

        #endregion 方法
    }
}