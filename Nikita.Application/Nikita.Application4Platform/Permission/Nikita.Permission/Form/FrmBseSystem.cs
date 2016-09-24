using DevExpress.XtraBars;
using Nikita.Core;
using Nikita.Permission.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Nikita.Permission
{
    public partial class FrmBseSystem : FrmBase
    {
        private readonly Bse_SystemDAL _systemDal = new Bse_SystemDAL();

        public FrmBseSystem()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, ItemClickEventArgs e)
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

                    case "btnClose":
                        Close();
                        break;

                    case "btnDelete":
                        DoDelete();
                        break;

                    case "btnRefresh":
                        DoRefresh();
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
            FrmBseSystemEdit bseSystemEdit = new FrmBseSystemEdit(string.Empty);
            if (bseSystemEdit.ShowDialog() == DialogResult.OK)
            {
                DoBind();
            }
        }

        private void DoBind()
        {
            DataTable dtSystem = _systemDal.GetList("State=1").Tables[0];
            DxCtlHelper.BindGridControl(gridCMain, gridVMain, dtSystem);
        }

        private void DoDelete()
        {
            if (gridVMain.GetFocusedDataRow() == null)
            {
                MessageBox.Show("请选中要修改的数据");
                return;
                ;
            }
            string systemId = gridVMain.GetFocusedDataRow()["System_Id"].ToString();
            bool flag = _systemDal.Delete(int.Parse(systemId));
            if (flag)
            {
                MessageBox.Show("作废成功");
                DoBind();
            }
            else
            {
                MessageBox.Show("作废失败");
            }
        }

        private void DoEdit()
        {
            if (gridVMain.GetFocusedDataRow() == null)
            {
                MessageBox.Show("请选中要修改的数据");
                return;
                ;
            }
            string systemId = gridVMain.GetFocusedDataRow()["System_Id"].ToString();
            FrmBseSystemEdit bseSystemEdit = new FrmBseSystemEdit(systemId);
            if (bseSystemEdit.ShowDialog() == DialogResult.OK)
            {
                DoBind();
            }
        }

        private void DoRefresh()
        {
            DoBind();
        }

        private void FrmBseSystem_Load(object sender, EventArgs e)
        {
            DoBind();
        }
    }
}