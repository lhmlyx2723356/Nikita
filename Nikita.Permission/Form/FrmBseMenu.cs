using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using Nikita.Core;
using Nikita.Permission.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Nikita.Permission
{
    public partial class FrmBseMenu : FrmBase
    {
        private readonly Bse_MenuDAL _systemDal = new Bse_MenuDAL();

        private readonly string _systemId = UserInfoHelper.SystemId;

        public FrmBseMenu()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                SimpleButton btn = sender as SimpleButton; 
                if (btn == null) return;
                switch (btn.Name)
                {
                    case "btnQuery":
                        DoQuery();
                        break;

                    case "btnAdd":
                        DoAdd();
                        break;

                    case "btnEdit":
                        DoEdit();
                        break;

                    case "btnDelete":
                        DoDelete();
                        break;

                    case "btnImportOut":
                        ExcelHelper.ImportExcel(gridCMain, this, "菜单列表信息");
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
            FrmBseMenuEdit bseSystemEdit = new FrmBseMenuEdit(string.Empty);
            if (bseSystemEdit.ShowDialog() == DialogResult.OK)
            {
                if (bseSystemEdit.IsAddMenuWithoutFormName)
                {
                    DoBindTree();
                }
                DoBind();
            }
        }

        private void DoBind()
        {
            DataTable dtSystem = _systemDal.GetList("State=1 and SystemId=" + _systemId + " and ParentId=" + treMenu.FocusedNode["Module_Id"] + " and (Name like'%" + txtName.Text.Trim() + "%' or '" + txtName.Text.Trim() + "'='' )     ").Tables[0];
            DxCtlHelper.BindGridControl(gridCMain, gridVMain, dtSystem);
        }

        private void DoDelete()
        {
            if (gridVMain.GetFocusedDataRow() == null)
            {
                MessageBox.Show(@"请选中要作废的数据");
                return;
            }
            string systemId = gridVMain.GetFocusedDataRow()["Module_Id"].ToString();
            bool flag = _systemDal.Delete(int.Parse(systemId));
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
            string moduleId = gridVMain.GetFocusedDataRow()["Module_Id"].ToString();
            FrmBseMenuEdit bseSystemEdit = new FrmBseMenuEdit(moduleId);
            if (bseSystemEdit.ShowDialog() == DialogResult.OK)
            {
                DoBind();
            }
        }

        private void DoQuery()
        {
            DoBind();
        }

        private void FrmBseMenu_Load(object sender, EventArgs e)
        {
            DoBindTree();
            DoBind();
            treMenu.FocusedNodeChanged += treMenu_FocusedNodeChanged;
        }

        private void DoBindTree()
        {
            DataTable dtSystem = _systemDal.GetList("State=1 and SystemId=" + _systemId + "").Tables[0];
            DxCtlHelper.BindTreeList(treMenu, dtSystem, "Module_Id", "ParentId", "Name", "菜单列表");
            treMenu.ExpandAll();
        }

        private void gridVMain_DoubleClick(object sender, EventArgs e)
        {
            DoEdit();
        }

        private void treMenu_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                var dataRowView = treMenu.GetDataRecordByNode(e.Node) as DataRowView;
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