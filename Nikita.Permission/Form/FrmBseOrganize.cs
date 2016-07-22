using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class FrmBseOrganize : FrmBase
    {
        public bool blInitBound = false;

        private readonly Bse_SetInfoDAL _setInfoDal = new Bse_SetInfoDAL();

        private readonly string _systemId = UserInfoHelper.SystemId;

        private string _organizeId;

        private Control CtrlCurrent;

        private string[] CtrlNextArray = new string[] { "txtName", "txtNumber", "txtSort", "lueCategory", "txtOuterPhone", "txtInnerPhone", "txtAddress", "txtRemark" };

        private string[] CtrlSaveArray = new string[] { "txtName", "机构名" };

        private string[] CtrlSaveArrayTxt = new string[] { "名称", "机构编码" };

        private DataTable DtTreeList;

        private string Mode;

        private Bse_OrganizeDAL organizeDal = new Bse_OrganizeDAL();

        private Bse_User_OrganizeDAL organizeUserDal = new Bse_User_OrganizeDAL();

        private Bse_User_OrganizeDALExtend organizeUserDalExtend = new Bse_User_OrganizeDALExtend();

        private string strFocusedControlName;

        public FrmBseOrganize()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (CtrlCurrent == null)
                {
                    return false;
                }
                string controlNext = GetNextCtrl();
                if (controlNext != string.Empty)
                {
                    Control NextCtrl = layoutControl1.Controls.Find(controlNext, false)[0];
                    DoFocus(NextCtrl);
                    return true;
                }
                else
                {
                    DoSave();
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private bool CheckSave(Control ctrl, string[] CtrlSaveArray, string[] CtrlSaveArrayTxt)
        {
            for (int i = 0; i < ctrl.Controls.Count; i++)
            {
                for (int j = 0; j < CtrlSaveArray.Length; j++)
                {
                    if (ctrl.Controls[i].Name == CtrlSaveArray[j])
                    {
                        if (DoCheck(ctrl.Controls[i].GetType().ToString(), ctrl.Controls[i].Name, layoutControl1, CtrlSaveArrayTxt[j]) == false)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void Ctrl_Enter(object sender, EventArgs e)
        {
            strFocusedControlName = (sender as Control).Name;
            CtrlCurrent = sender as Control;
        }

        private void DoBind()
        {
            DataTable dtOrganizeType = _setInfoDal.GetList("State=1 and SystemId=" + _systemId + " and SetInfo_Key='OrganizeType'").Tables[0]; DxCtlHelper.BindLookUpEditWithInt(lueCategory, dtOrganizeType, "Name", "SetInfo_Value");
            DtTreeList = organizeDal.GetList("State=1 and SystemId=" + _systemId + "").Tables[0];
            DxCtlHelper.BindTreeList(TreeListMain, DtTreeList, "Organize_Id", "ParentId", "Name", "组织机构列表");
        }

        //添加
        private void DoNew()
        {
            FrmSelectUserForOrganize selectUser = new FrmSelectUserForOrganize(_organizeId);
            if (selectUser.ShowDialog() == DialogResult.OK)
            {
                DataTable dtUserName = organizeUserDalExtend.GetUserByOrganizeId("a.Organize_Id=" + _organizeId + " and a.SystemId=" + UserInfoHelper.SystemId + "").Tables[0];
                gridCMain.DataSource = dtUserName;
            }
        }

        //移除用户
        private void DoRemove()
        {
            if (TreeListMain.FocusedNode == null)
            {
                MessageBox.Show(@"请先选中角色");
                return;
            }

            if (gridVMain.SelectedRowsCount == 0)
            {
                MessageBox.Show(@"请先选中要移除的用户");
                return;
            }
            string userOrganizeIds = DxCtlHelper.GetSelectRowsFileValue(gridVMain, "User_Organize_Id", ',');
            bool flag = organizeUserDal.DeleteByCond("User_Organize_Id in(" + userOrganizeIds + ")");
            if (flag)
            {
                MessageBox.Show(@"移除成功");
                DataTable dtUserName = organizeUserDalExtend.GetUserByOrganizeId("a.Organize_Id=" + _organizeId + " and a.SystemId=" + UserInfoHelper.SystemId + "").Tables[0];
                gridCMain.DataSource = dtUserName;
            }
            else
            {
                MessageBox.Show(@"移除失败");
            }
        }

        private void DoSave()
        {
            var dataRowView = TreeListMain.GetDataRecordByNode(TreeListMain.FocusedNode) as DataRowView;
            if (dataRowView != null)
            {
                DataRow dr = dataRowView.Row;
                if (dr == null)
                {
                    return;
                }

                if (CheckSave(this.layoutControl1, CtrlSaveArray, CtrlSaveArrayTxt) == false)
                {
                    return;
                }

                btnSave.Enabled = false;
                bool blChgState = false;

                try
                {
                    if (dr["Organize_Id"].ToString() == string.Empty || _organizeId == "-1")
                    {
                        if (organizeDal.GetList("  Number='" + txtNumber.Text + "'  and SystemId=" + _systemId + " ").Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show(@"输入的编码已经存在");
                            btnSave.Enabled = true;
                            return;
                        }
                        Bse_Organize organize = new Bse_Organize();
                        organize.Name = txtName.Text.Trim();
                        organize.Number = txtNumber.Text.Trim();
                        organize.Sort = int.Parse(txtSort.Text.Trim());
                        organize.Category = lueCategory.EditValue.ToString();
                        organize.OuterPhone = txtOuterPhone.Text.Trim();
                        organize.InnerPhone = txtInnerPhone.Text.Trim();
                        organize.Address = txtAddress.Text.Trim();
                        organize.Remark = txtRemark.Text.Trim();
                        organize.CreateName = txtCreateUserId.Text.Trim();
                        organize.CreateUserId = int.Parse(UserInfoHelper.CreateUserId);
                        organize.Dept_Id = int.Parse(UserInfoHelper.Dept_Id);
                        organize.SystemId = int.Parse(UserInfoHelper.SystemId);
                        organize.Bloc_Id = int.Parse(UserInfoHelper.Bloc_Id);
                        organize.Company_Id = int.Parse(UserInfoHelper.Company_Id);
                        organize.Layer = int.Parse(dr["Layer"].ToString());
                        organize.ParentId = int.Parse(dr["ParentId"].ToString());
                        organize.State = 1;
                        int flag = organizeDal.Add(organize);
                        if (flag > 0)
                        {
                            MessageDxUtilHelper.ShowWarning("操作成功");
                            //DataRow drNew = ds.Tables[0].Rows[0];
                            dr["Organize_Id"] = flag;
                        }
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        if (organizeDal.GetList("Organize_Id!=" + _organizeId + " and Number='" + txtNumber.Text + "' ").Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show(@"输入的编码已经存在");
                            btnSave.Enabled = true;
                            return;
                        }

                        List<Bse_Organize> roleModel = ModelHandler<Bse_Organize>.FillModel(organizeDal.GetList("Organize_Id=" + _organizeId + "").Tables[0]);
                        Bse_Organize organize = roleModel[0];
                        organize.Organize_Id = int.Parse(_organizeId);
                        organize.Name = txtName.Text.Trim();
                        organize.Number = txtNumber.Text.Trim();
                        organize.Sort = int.Parse(txtSort.Text.Trim());
                        organize.Category = lueCategory.EditValue.ToString();
                        organize.OuterPhone = txtOuterPhone.Text.Trim();
                        organize.InnerPhone = txtInnerPhone.Text.Trim();
                        organize.Address = txtAddress.Text.Trim();
                        organize.Remark = txtRemark.Text.Trim();
                        organize.CreateName = txtCreateUserId.Text.Trim();
                        organize.CreateUserId = int.Parse(UserInfoHelper.CreateUserId);
                        organize.Dept_Id = int.Parse(UserInfoHelper.Dept_Id);
                        organize.SystemId = int.Parse(UserInfoHelper.SystemId);
                        organize.Bloc_Id = int.Parse(UserInfoHelper.Bloc_Id);
                        organize.Company_Id = int.Parse(UserInfoHelper.Company_Id);
                        organize.Layer = int.Parse(dr["Layer"].ToString());
                        organize.ParentId = int.Parse(dr["ParentId"].ToString());
                        bool flag = organizeDal.Update(organize);
                        EntityCovert.SetDataRowByEntity<Bse_Organize>(dr, organize);
                        //dr["Number"] = organize.Number;
                        if (flag)
                        {
                            MessageDxUtilHelper.ShowWarning("操作成功");
                            if (dr.Table.Columns.Contains("State") && dr["State"].ToString() != dr["State", DataRowVersion.Original].ToString())
                            {
                                blChgState = true;
                            }
                        }
                        btnSave.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                dr.AcceptChanges();
                SetMode("VIEW");
                if (blChgState)
                    SetFocRowstyleFormat(dr);
            }
        }

        private void FrmBseOrganize_Load(object sender, EventArgs e)
        {
            gridVMain.OptionsSelection.MultiSelect = true;
            gridVMain.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gridVMain.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DefaultBoolean.True;
            Mode = "View";
            SetMode("View");
            DoBind();
            TreeListMain.ExpandAll();
        }

        #region 事件

        private void btn_Click(object sender, ItemClickEventArgs e)
        {
            try
            {
                TreeListNode nodeSel = TreeListMain.FocusedNode;

                DataRow dr = null;
                if (nodeSel != null)
                {
                    var dataRowView = TreeListMain.GetDataRecordByNode(TreeListMain.FocusedNode) as DataRowView;
                    if (dataRowView != null)
                        dr = dataRowView.Row;
                }
                Cursor = Cursors.WaitCursor;
                DtTreeList.Columns["Organize_Id"].ReadOnly = false;
                switch (e.Item.Name)
                {
                    case "btnAddSameLevel":
                        SetMode("Add");
                        string strCtrlAddSameLevel = CtrlNextArray[0];
                        Control ctrlAddSameLevel = layoutControl1.Controls.Find(strCtrlAddSameLevel, true)[0];
                        DoFocus(ctrlAddSameLevel);
                        DataRow drNew = DtTreeList.NewRow();
                        drNew["Organize_Id"] = -1;
                        if (dr == null)
                        {
                            drNew["Layer"] = 1;
                            drNew["ParentId"] = 0;
                        }
                        else
                        {
                            drNew["Layer"] = dr["Layer"];
                            drNew["ParentId"] = dr["ParentId"];
                        }

                        blInitBound = true;
                        TreeListNode nodeA;
                        if (dr == null)
                        {
                            nodeA = TreeListMain.AppendNode(drNew, 0);
                        }
                        else
                        {
                            nodeA = TreeListMain.AppendNode(drNew, nodeSel.ParentNode);
                        }
                        TreeListMain.SetFocusedNode(nodeA);
                        blInitBound = false;
                        TreeListMain_FocusedNodeChanged(TreeListMain, new DevExpress.XtraTreeList.FocusedNodeChangedEventArgs(null, TreeListMain.FocusedNode));
                        txtCreateTime.Text = DateTime.Now.ToString();
                        txtCreateUserId.Text = UserInfoHelper.CreateName;
                        break;

                    case "btnAddNextLevel":
                        if (dr == null)
                        {
                            return;
                        }
                        SetMode("Add");
                        string strCtrlAddNextLevel = CtrlNextArray[0];
                        Control ctrlAddNextLevel = layoutControl1.Controls.Find(strCtrlAddNextLevel, true)[0];
                        DoFocus(ctrlAddNextLevel);
                        DataRow drNewS = DtTreeList.NewRow();
                        drNewS["Organize_Id"] = -1;
                        drNewS["Layer"] = int.Parse(dr["Layer"].ToString()) + 1;
                        drNewS["ParentId"] = dr["Organize_Id"];

                        blInitBound = true;
                        TreeListNode nodeAs = TreeListMain.AppendNode(drNewS, nodeSel);
                        nodeSel.ExpandAll();
                        TreeListMain.SetFocusedNode(nodeAs);
                        blInitBound = false;
                        TreeListMain_FocusedNodeChanged(TreeListMain, new DevExpress.XtraTreeList.FocusedNodeChangedEventArgs(null, TreeListMain.FocusedNode));
                        txtCreateTime.Text = DateTime.Now.ToString();
                        txtCreateUserId.Text = UserInfoHelper.CreateName;
                        break;

                    case "btnEdit":
                        if (dr == null)
                        {
                            return;
                        }
                        Mode = "Edit";
                        SetMode("Edit");
                        string StrCtrlEdit = CtrlNextArray[0];
                        Control CtrlEdit = layoutControl1.Controls.Find(StrCtrlEdit, true)[0];
                        DoFocus(CtrlEdit);
                        break;

                    case "btnCancel":
                        if (dr == null)
                        {
                            return;
                        }
                        blInitBound = true;
                        DtTreeList.RejectChanges();//引发gridView1_FocusedRowChanged
                        DtTreeList.AcceptChanges();
                        blInitBound = false;
                        SetMode("View");
                        TreeListMain_FocusedNodeChanged(TreeListMain, new DevExpress.XtraTreeList.FocusedNodeChangedEventArgs(null, TreeListMain.FocusedNode));
                        break;

                    case "btnSave":
                        if (dr == null)
                        {
                            return;
                        }
                        DoSave();
                        break;

                    case "btnDelete":
                        if (dr == null)
                        {
                            return;
                        } List<Bse_Organize> roleModel = ModelHandler<Bse_Organize>.FillModel(organizeDal.GetList("Organize_Id=" + _organizeId + "").Tables[0]);
                        Bse_Organize model = roleModel[0];
                        model.State = 0;
                        bool flag = organizeDal.Update(roleModel[0]);
                        if (flag)
                        {
                            MessageBox.Show(@"作废成功");
                            TreeListMain.DeleteSelectedNodes();
                        }
                        else
                        {
                            MessageBox.Show(@"作废失败");
                        }
                        SetMode("View");
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
                    case "btnNew":
                        DoNew();
                        break;

                    case "btnRemove":
                        DoRemove();
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

        #endregion 事件

        private string GetNextCtrl()
        {
            string ctrlNext = string.Empty;
            for (int i = 0; i < CtrlNextArray.Length; i++)
            {
                if (strFocusedControlName == CtrlNextArray[i].Trim() && (i + 1) < CtrlNextArray.Length)
                {
                    ctrlNext = CtrlNextArray[i + 1].Trim();
                }
            }
            return ctrlNext;
        }

        private void SetFocRowstyleFormat(DataRow dr)
        {
            //if (dr.Table.Columns.Contains("State") && Boolean.Parse(dr["State"].ToString()).ToString() == "False")
            //{
            //    TreeListMain.Appearance.FocusedCell.BackColor = Color.Coral;
            //    TreeListMain.Appearance.FocusedCell.Options.UseBackColor = true;
            //    TreeListMain.Appearance.FocusedRow.BackColor = Color.Coral;
            //    TreeListMain.Appearance.FocusedRow.Options.UseBackColor = true;
            //}
            //else
            //{
            //    TreeListMain.Appearance.FocusedCell.Options.UseBackColor = false;
            //    TreeListMain.Appearance.FocusedRow.Options.UseBackColor = false;
            //}
        }

        private void SetMode(string Mode)
        {
            switch (Mode.ToUpper())
            {
                case "ADD":
                    DxCtlHelper.SetControlEnabled(layoutControl1, false);
                    DxCtlHelper.SetBtnEnabled(new Component[] { btnSave, btnCancel }, true);
                    DxCtlHelper.SetBtnEnabled(new Component[] { btnAddNextLevel, btnAddSameLevel, btnDelete, btnEdit }, false);
                    DxCtlHelper.SetControlEmpty(layoutControl1);
                    DxCtlHelper.SetControlEnabled(layoutControl1, true, CtrlNextArray);
                    break;

                case "EDIT":
                    DxCtlHelper.SetControlEnabled(layoutControl1, false);
                    DxCtlHelper.SetBtnEnabled(new Component[] { btnSave, btnCancel }, true);
                    DxCtlHelper.SetBtnEnabled(new Component[] { btnAddNextLevel, btnAddSameLevel, btnDelete, btnEdit }, false);
                    DxCtlHelper.SetControlEnabled(layoutControl1, true, CtrlNextArray);
                    break;

                case "VIEW":
                    DxCtlHelper.SetControlEnabled(layoutControl1, false);
                    DxCtlHelper.SetBtnEnabled(new Component[] { btnSave, btnCancel }, false);
                    DxCtlHelper.SetBtnEnabled(new Component[] { btnAddNextLevel, btnAddSameLevel, btnDelete, btnEdit }, true);
                    DxCtlHelper.SetControlEnabled(layoutControl1, false, CtrlNextArray);
                    break;

                default:
                    break;
            }
        }

        private void TreeListMain_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (blInitBound)
                return;

            if (e.OldNode != null)
            {
                var dataRowView = TreeListMain.GetDataRecordByNode(e.OldNode) as DataRowView;
                if (dataRowView != null)
                {
                    DataRow drP = dataRowView.Row;
                    if (drP != null && drP.RowState != DataRowState.Unchanged)
                    {
                        blInitBound = true;
                        drP.RejectChanges();//引发gridView1_FocusedRowChanged
                        blInitBound = false;
                    }
                }
            }
            if (e.Node != null)
            {
                var dataRowView = TreeListMain.GetDataRecordByNode(e.Node) as DataRowView;
                if (dataRowView != null)
                {
                    DataRow dr = dataRowView.Row;
                    if (dr == null)
                        return;

                    if (dr.RowState != DataRowState.Added && Mode != "VIEW")
                    {
                        SetMode("View");
                    }
                    _organizeId = dr["Organize_Id"].ToString();
                    //DataTable DtTreeListRow = organizeDal.GetList("State=1 and SystemId=" + _systemId + " and  Organize_Id=" + _organizeId + " ").Tables[0];
                    DxCtlHelper.SetControlBindings(layoutControl1, DtTreeList);
                    DataTable dtUserName = organizeUserDalExtend.GetUserByOrganizeId("a.Organize_Id=" + _organizeId + " and a.SystemId=" + UserInfoHelper.SystemId + "").Tables[0];
                    gridCMain.DataSource = dtUserName;
                    SetFocRowstyleFormat(dr);
                }
            }
        }
    }
}