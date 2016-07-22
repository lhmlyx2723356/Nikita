using DevExpress.XtraEditors;
using Nikita.Core;
using Nikita.Permission.DAL;
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
    public partial class FrmBseUser : FrmBase
    {
        private readonly Bse_OrganizeDAL _organizeDal = new Bse_OrganizeDAL();

        private readonly Bse_RoleDAL _roleDal = new Bse_RoleDAL();

        private readonly string _systemId = UserInfoHelper.SystemId;

        private readonly Bse_UserDAL _userDal = new Bse_UserDAL();

        private readonly Bse_UserDALExtend _userDalExtend = new Bse_UserDALExtend();

        public FrmBseUser()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                SimpleButton btn = sender as SimpleButton;
                Cursor = Cursors.WaitCursor;
                if (btn == null) return;
                switch (btn.Name)
                {
                    case "btnQuery":
                        DoQuery();
                        break;

                    case "btnNew":
                        DoAdd();
                        break;

                    case "btnEdit":
                        DoEdit();
                        break;

                    case "btnDelete":
                        DoDelete();
                        break;

                    case "btnImportOut":
                        if ((gridCMain.DataSource as DataTable) != null && (gridCMain.DataSource as DataTable).Rows.Count == 0)
                        {
                            MessageBox.Show("没有可导出的信息");
                            return;
                        }
                        ExcelHelper.ImportExcel(gridCMain, this, "用户列表信息");
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

        private void DoAdd()
        {
            FrmBseUserEdit bseSystemEdit = new FrmBseUserEdit(string.Empty);
            if (bseSystemEdit.ShowDialog() == DialogResult.OK)
            {
                DoBind();
            }
        }

        private void DoBind()
        {
            DataTable dtSystem = new DataTable();
            if (tab.SelectedTabPage == xtraTabPage1)
            {
                string organizeId = treOrganize.FocusedNode["Organize_Id"].ToString();
                dtSystem = _userDal.GetList("State=1 and SystemId=" + _systemId + " and  ( Dept_Id =" + organizeId + "  or  Company_Id =" + organizeId + " or  Bloc_Id =" + organizeId + "  )   and (UserName like'%" + txtUserName.Text.Trim() + "%' or '" + txtUserName.Text.Trim() + "'='' )and    (Number like'%" + txtNumber.Text.Trim() + "%' or '" + txtNumber.Text.Trim() + "'='' )    and    (Realname like'%" + txtRealName.Text.Trim() + "%' or '" + txtRealName.Text.Trim() + "'='' )     and    (Sex like'%" + cmbSex.Text.Trim() + "%' or '" + cmbSex.Text.Trim() + "'='' )     ").Tables[0];
            }
            if (tab.SelectedTabPage == xtraTabPage2)
            {
                string roleId = treRole.FocusedNode["Role_Id"].ToString();
                dtSystem = _userDalExtend.GetList(txtRealName.Text.Trim(), txtNumber.Text.Trim(), txtUserName.Text.Trim(),
                      cmbSex.Text.Trim(), roleId).Tables[0];
            }
            DxCtlHelper.BindGridControl(gridCMain, gridVMain, dtSystem);
        }

        private void DoDelete()
        {
            if (gridVMain.GetFocusedDataRow() == null)
            {
                MessageBox.Show(@"请选中要作废的数据");
                return;
            }
            string userId = gridVMain.GetFocusedDataRow()["User_Id"].ToString();
            bool flag = _userDalExtend.Update(0, userId);
            if (flag)
            {
                MessageBox.Show(@"作废成功");
                DoBind();
            }
            else
            {
                MessageBox.Show(@"作废失败");
            }
        }

        private void DoEdit()
        {
            if (gridVMain.GetFocusedDataRow() == null)
            {
                MessageBox.Show(@"请选中要修改的数据");
                return;
            }
            string userId = gridVMain.GetFocusedDataRow()["User_Id"].ToString();
            FrmBseUserEdit bseSystemEdit = new FrmBseUserEdit(userId);
            if (bseSystemEdit.ShowDialog() == DialogResult.OK)
            {
                DoBind();
            }
        }

        private void DoQuery()
        {
            DoBind();
        }

        private void FrmBseUser_Load(object sender, EventArgs e)
        {
            DataTable dtOrganize = _organizeDal.GetList("State=1 and SystemId=" + _systemId + "").Tables[0];
            DxCtlHelper.BindTreeList(treOrganize, dtOrganize, "Organize_Id", "ParentId", "Name", "机构列表");
            DataTable dtRole = _roleDal.GetList("State=1 and SystemId=" + _systemId + "").Tables[0];
            DxCtlHelper.BindTreeList(treRole, dtRole, "Role_Id", "Role_Id", "Name", "角色列表");
            treOrganize.FocusedNodeChanged += treOrganize_FocusedNodeChanged;
            treRole.FocusedNodeChanged += treRole_FocusedNodeChanged;
            treOrganize_FocusedNodeChanged(treOrganize, new DevExpress.XtraTreeList.FocusedNodeChangedEventArgs(null, treOrganize.FocusedNode));
            treRole.ExpandAll();
            treOrganize.ExpandAll();
        }

        private void gridCMain_DoubleClick(object sender, EventArgs e)
        {
            DoEdit();
        }

        private void treOrganize_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null) return;
            var dataRowView = treOrganize.GetDataRecordByNode(e.Node) as DataRowView;
            if (dataRowView == null) return;
            DataRow dr = dataRowView.Row;
            if (dr == null)
                return;
            DoBind();
        }

        private void treRole_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                var dataRowView = treRole.GetDataRecordByNode(e.Node) as DataRowView;
                if (dataRowView != null)
                {
                    DataRow dr = dataRowView.Row;
                    if (dr == null)
                        return;
                    DoBind();
                }
            }
        }
    }
}