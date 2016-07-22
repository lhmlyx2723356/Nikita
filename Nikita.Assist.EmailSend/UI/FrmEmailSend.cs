using FrmEmailSend.DAL;
using FrmEmailSend.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nikita.Assist.EmailSend
{
    public partial class FrmEmailSend : Form
    {
        private DatagridViewCheckBoxHeaderCell cbHeader = new DatagridViewCheckBoxHeaderCell();

        private DataGridViewCheckBoxColumn colCB = new DataGridViewCheckBoxColumn();

        private EmailListDAL dal = new EmailListDAL();

        private EmailSendLogDAL dalLog = new EmailSendLogDAL();

        private EmailHelper helper = new EmailHelper();

        private List<string> lstAttemts = new List<string>();

        private List<string> lstToMail = new List<string>();

        public FrmEmailSend()
        {
            InitializeComponent();
        }

        private void AddLog(bool flag)
        {
            EmailSendLog model = new EmailSendLog();
            model.CreateDate = DateTime.Now.ToString();
            model.EmailFromAddress = txtFromUser.Text.Trim();
            model.EmailSubject = txtSubject.Text.Trim();
            model.EmailToAddress = lstToMail[0];
            model.IsSuccess = flag == true ? "发送成功" : "发送失败";
            dalLog.Add(model);
        }

        //添加收件人
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DoAdd();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            string strSql = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='EmailSendLog';";
            string strSqlCreate = @" CREATE TABLE  EmailSendLog  (
                                                                        id  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                                                                        EmailSubject  TEXT,
                                                                        EmailToAddress  TEXT,
                                                                        EmailFromAddress  TEXT,
                                                                        CreateDate  TEXT,
                                                                        IsSuccess  TEXT,
                                                                        Remark  TEXT
                                                                        );";
            bool flag = InitTable(strSql, strSqlCreate);

            string strSql1 = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='EmailList';";
            string strSqlCreate1 = @" CREATE TABLE EmailList (
                                                            id  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                                                            EmailAddress  TEXT,
                                                            CreateDate  TEXT,
                                                            Remark  TEXT
                                                            );";
            bool flag1 = InitTable(strSql1, strSqlCreate1);
            if (flag && flag1)
            {
                MessageBox.Show("初始化成功");
            }
            else
            {
                MessageBox.Show("初始化失败");
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            FrmEmailLog frmLog = new FrmEmailLog();
            frmLog.Show();
        }

        //选择附件
        private void btnSelect_Click(object sender, EventArgs e)
        {
            DoSelectAttemt();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtBody.Text.Trim().Length == 0)
            {
                txtBody.Select();
                return;
            }

            if (txtEmailDomain.Text.Trim().Length == 0)
            {
                txtEmailDomain.Select();
                return;
            }

            if (txtFromPwd.Text.Trim().Length == 0)
            {
                txtFromPwd.Select();
                return;
            }

            if (txtFromUser.Text.Trim().Length == 0)
            {
                txtFromUser.Select();
                return;
            }

            if (txtShowUser.Text.Trim().Length == 0)
            {
                txtShowUser.Select();
                return;
            }

            if (txtSubject.Text.Trim().Length == 0)
            {
                txtSubject.Select();
                return;
            }

            if (GetSelectRows(grdEmailAddress).Count == 0)
            {
                MessageBox.Show("请选择要发送的人员");
                return;
            }

            foreach (DataGridViewRow row in GetSelectRows(grdEmailAddress))
            {
                if (lstToMail.Contains(row.Cells["ColEmailAddress"].Value.ToString()) == false)
                {
                    lstToMail.Add(row.Cells["ColEmailAddress"].Value.ToString());
                }
            }

            foreach (DataGridViewRow row in grdAttemt.Rows)
            {
                if (lstAttemts.Contains(row.Cells[0].Value.ToString()) == false)
                {
                    lstAttemts.Add(row.Cells[0].Value.ToString());
                }
            }

            if (chkUserSetting.Checked)
            {
                int intTime;
                if (!int.TryParse(txtTime.Text.Trim(), out intTime))
                {
                    MessageBox.Show("请输入正确的间隔时间");
                    return;
                }
                timer1.Interval = int.Parse(txtTime.Text.Trim());
                timer1.Start();
            }
            else
            {
                foreach (var item in lstToMail)
                {
                    bool flag = false;
                    try
                    {
                        flag = helper.Send(txtSubject.Text.Trim(), txtBody.Text.Trim(), item, txtFromUser.Text.Trim(), txtShowUser.Text.Trim(), txtEmailDomain.Text.Trim(), txtFromUser.Text.Trim(), txtFromPwd.Text.Trim(), lstAttemts);
                    }
                    catch
                    {
                        continue;
                    }
                    AddLog(flag);
                }
            }
        }

        private void cbHeader_OnCheckBoxClicked(bool state)
        {
            //这一句很重要结束编辑状态
            grdEmailAddress.EndEdit();
            if (grdEmailAddress.Rows.Count > 0)
            {
                for (int i = 0; i < grdEmailAddress.Rows.Count; i++)
                {
                    grdEmailAddress.Rows[i].Cells[0].Value = state;
                }
            }
        }

        private void DoAdd()
        {
            FrmEmailAddressEdit frmEdit = new FrmEmailAddressEdit();
            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                DoBindEmailAddress();
                grdEmailAddress.Rows[grdEmailAddress.RowCount - 1].Selected = true;
            }
        }

        private void DoBindEmailAddress()
        {
            DataSet dsEmail = dal.GetList(string.Empty);
            if (dsEmail != null && dsEmail.Tables.Count > 0)
            {
                grdEmailAddress.DataSource = dsEmail.Tables[0];
            }
        }

        private void DoSelectAttemt()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename in dialog.FileNames)
                {
                    int rowindex = grdAttemt.Rows.Add();
                    grdAttemt.Rows[rowindex].Cells[0].Value = filename;
                }
            }
        }

        private void FrmEmailSend_Load(object sender, EventArgs e)
        {
            grdEmailAddress.AutoGenerateColumns = false;
            colCB.DataPropertyName = "Select";
            cbHeader.Value = string.Empty;
            cbHeader.OnCheckBoxClicked += new CheckBoxClickedHandler(cbHeader_OnCheckBoxClicked);
            grdEmailAddress.Columns.Insert(0, colCB);
            grdEmailAddress.Columns[0].HeaderCell = cbHeader;

            DoBindEmailAddress();
        }

        private string GetSelectIds(DataGridView grdView)
        {
            StringBuilder sb = new StringBuilder();

            foreach (DataGridViewRow row in grdView.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    sb.Append(row.Cells["ColId"].Value.ToString() + ",");
                }
            }
            return sb.ToString().TrimEnd(',');
        }

        private List<DataGridViewRow> GetSelectRows(DataGridView grdView)
        {
            List<DataGridViewRow> lstSelectRows = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in grdView.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    lstSelectRows.Add(row);
                }
            }
            return lstSelectRows;
        }

        /// <summary>
        /// 点击DataGridView的行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdEmailAddress_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdEmailAddress.CurrentCell == null)
            {
                return;
            }
            DataGridView dgvv = ((DataGridView)sender);
            if (grdEmailAddress.CurrentCell.OwningColumn.DataPropertyName == "Select")
            {
                if (e.RowIndex != -1)
                {
                    this.SetSelected(dgvv, e.RowIndex);
                }
            }
        }

        private bool InitTable(string strSql, string strCreate)
        {
            bool flag = false;
            try
            {
                SQLiteHelper helper = new SQLiteHelper();
                helper.CreateCommand(strSql);
                DataTable dt = helper.ExecuteQuery();
                if (dt.Rows[0][0].ToString() == "0")
                {
                    helper.CreateCommand(strCreate);
                    helper.ExecuteQuery();
                    flag = true;
                }
                else if (dt.Rows[0][0].ToString() == "1")
                {
                    flag = true;
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        private void SetHeaderCheckState(DataGridView dgv)
        {
            if (dgv.RowCount == 0)
            {
                return;
            }
            if (dgv.RowCount == 1)
            {
                cbHeader.OnChangeCheckBoxStatus(Convert.ToBoolean(dgv.Rows[0].Cells[0].Value));
            }
            bool blnChange = Convert.ToBoolean(dgv.Rows[0].Cells[0].Value);
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Index == 0)
                {
                    continue;
                }
                if (blnChange != Convert.ToBoolean(row.Cells[0].Value))
                {
                    cbHeader.OnChangeCheckBoxStatus(false);
                    break;
                }

                if (blnChange == Convert.ToBoolean(row.Cells[0].Value) && row.Index == dgv.RowCount - 1)
                {
                    cbHeader.OnChangeCheckBoxStatus(blnChange);
                }
            }
        }

        private void SetSelected(DataGridView dgvb, int rowIndex)
        {
            if (dgvb.Rows[rowIndex] != null)
            {
                if (dgvb.Rows[rowIndex].Cells[0].Value != null && dgvb.Rows[rowIndex].Cells[0].Value.ToString() != "")
                {
                    bool status = !Convert.ToBoolean(dgvb.Rows[rowIndex].Cells[0].Value);
                    dgvb.Rows[rowIndex].Cells[0].Value = status;
                    dgvb.EndEdit();
                    SetHeaderCheckState(grdEmailAddress);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lstToMail.Count == 0)
            {
                timer1.Stop();
            }
            bool flag = helper.Send(txtSubject.Text.Trim(), txtBody.Text.Trim(), lstToMail[0], txtFromUser.Text.Trim(), txtShowUser.Text.Trim(), txtEmailDomain.Text.Trim(), txtFromUser.Text.Trim(), txtFromPwd.Text.Trim(), lstAttemts);
            AddLog(flag);
            lstToMail.Remove(lstToMail[0]);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (grdAttemt.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的附件");
                return;
            }
            foreach (DataGridViewRow item in grdAttemt.SelectedRows)
            {
                grdAttemt.Rows.Remove(item);
            }
            grdAttemt.Refresh();
        }

        private void 删除收件人ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strSelectIds = GetSelectIds(grdEmailAddress);
            bool falg = dal.DeleteByCond("Id in (" + strSelectIds + ")");
            if (falg)
            {
                MessageBox.Show("删除成功");
                DoBindEmailAddress();
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoAdd();
        }

        private void 选择附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoSelectAttemt();
        }
    }
}