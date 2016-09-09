using Nikita.Assist.DBManager.DAL;
using System;
using System.Data;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;
using WeifenLuo.WinFormsUI.Docking;

namespace Nikita.Assist.DBManager
{
    /*To-DO：后续导入需优化大批量Insert*/

    public partial class FrmSynchronization : DockContentEx
    {
        private DataTable m_dtSource1;

        private DataTable m_dtSource2;

        private DataTable m_dtSource3;

        private DataTable m_dtSource4;

        private DataTable m_dtSource5;

        private MySQLHelper m_myhelper = null;

        private SetOrdTableDAL m_orddal;

        private SetTableDAL m_setdal;

        private MSSQLHelper m_sqlserverhelper = null;

        private int MsSqlImprortToMysqlAmount;

        private int MsSqlUpdateToMysqlAmount;

        private int MySqlImprortToMssqlAmount;

        private int MysqlUpdateChangLiang;

        private int MysqlUpdateToMsSqlAmount;

        public FrmSynchronization()
        {
            InitializeComponent();
        }

        /// <summary>执行
        /// 执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnWork_Click(object sender, EventArgs e)
        {
            if (m_dtSource1 == null || m_dtSource2 == null || m_dtSource3 == null || m_dtSource4 == null || m_dtSource5 == null)
            {
                btnConnect_Click(null, null);
            }
            MsSqlImprortToMysqlAmount = 0;
            MsSqlUpdateToMysqlAmount = 0;
            MySqlImprortToMssqlAmount = 0;
            MysqlUpdateToMsSqlAmount = 0;
            MysqlUpdateChangLiang = 0;

            if (chkmssqladdtomysql.Checked)
            {
                if (m_dtSource1.Rows.Count == 0)
                {
                    MessageBox.Show(@"mssql添加到mysql未维护表数据");
                    return;
                }
            }
            if (chkmssqlupdatetomysql.Checked)
            {
                if (m_dtSource2.Rows.Count == 0)
                {
                    MessageBox.Show(@"mssql更新到mysql未维护表数据");
                    return;
                }
            }
            if (chkmysqladdtomssql.Checked)
            {
                if (m_dtSource3.Rows.Count == 0)
                {
                    MessageBox.Show(@"mysql添加到mssql未维护表数据");
                    return;
                }
            }
            if (chkmysqlupdatetomssql.Checked)
            {
                if (m_dtSource4.Rows.Count == 0)
                {
                    MessageBox.Show(@"mysql更新到mssql未维护表数据");
                    return;
                }
            } if (chkChangLiang.Checked)
            {
                if (m_dtSource5.Rows.Count == 0)
                {
                    MessageBox.Show(@"mysql更新常量未维护表数据");
                    return;
                }
            }
            DoWork();
        }

        /// <summary>执行同步
        /// 执行同步
        /// </summary>
        public void DoWork()
        {
            try
            {
                #region mssqlserver   addto===>   mysql

                if (chkmssqladdtomysql.Checked)
                {
                    for (int i = 0; i < m_dtSource1.Rows.Count; i++)
                    {
                        string id = m_dtSource1.Rows[i]["id"].ToString();
                        string mssqltabname = m_dtSource1.Rows[i]["SetOrdText"].ToString();
                        string mysqltabname = m_dtSource1.Rows[i]["Remark"].ToString();

                        DoMssqlAddToMysql(mssqltabname, mysqltabname, id);
                    }
                }

                #endregion mssqlserver   addto===>   mysql

                #region mssqlserver   updateto===>   mysql

                if (chkmssqlupdatetomysql.Checked)
                {
                    for (int i = 0; i < m_dtSource2.Rows.Count; i++)
                    {
                        string id = m_dtSource2.Rows[i]["id"].ToString();
                        string mssqltabname = m_dtSource2.Rows[i]["SetOrdText"].ToString();
                        string mysqltabname = m_dtSource2.Rows[i]["Remark"].ToString();

                        DoMssqlUpdateToMysql(mssqltabname, mysqltabname, id);
                    }
                }

                #endregion mssqlserver   updateto===>   mysql

                #region mysql  addto===>  mssqlserver

                if (chkmysqladdtomssql.Checked)
                {
                    for (int i = 0; i < m_dtSource3.Rows.Count; i++)
                    {
                        string id = m_dtSource3.Rows[i]["id"].ToString();
                        string mssqltabname = m_dtSource3.Rows[i]["SetOrdText"].ToString();
                        string mysqltabname = m_dtSource3.Rows[i]["Remark"].ToString();

                        DoMysqlAddToMssql(mysqltabname, mssqltabname, id);
                    }
                }

                #endregion mysql  addto===>  mssqlserver

                #region mysql  updateto===>  mssqlserver

                if (chkmysqlupdatetomssql.Checked)
                {
                    for (int i = 0; i < m_dtSource4.Rows.Count; i++)
                    {
                        string id = m_dtSource4.Rows[i]["id"].ToString();
                        string mssqltabname = m_dtSource4.Rows[i]["SetOrdText"].ToString();
                        string mysqltabname = m_dtSource4.Rows[i]["Remark"].ToString();

                        DoMysqlUpdateToMssql(mysqltabname, mssqltabname, id);
                    }
                }

                #endregion mysql  updateto===>  mssqlserver

                #region mysql  update 常量值

                if (chkChangLiang.Checked)
                {
                    for (int i = 0; i < m_dtSource5.Rows.Count; i++)
                    {
                        string id = m_dtSource5.Rows[i]["id"].ToString();
                        string mssqltabname = m_dtSource5.Rows[i]["SetOrdText"].ToString();
                        string mysqltabname = m_dtSource5.Rows[i]["Remark"].ToString();

                        DoMysqlUpdateChangLiang(mysqltabname, mssqltabname, id);
                    }
                }

                #endregion mysql  update 常量值
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnWork.Enabled = true;
                //label7.Text = @"执行完毕，一共从MsSql导入到Mysql" + MsSqlImprortToMysqlAmount + @"条数据，从MsSql更新到到Mysql" + MsSqlUpdateToMysqlAmount + "条数据，从Mysql导入到Mssql" + System.Environment.NewLine + MySqlImprortToMssqlAmount + "条数据，从Mysql更新到Mssql" + MysqlUpdateToMsSqlAmount + "条数据" + System.Environment.NewLine + "，一共更新常量" + MysqlUpdateChangLiang + @"条数据";
            }
        }

        /// <summary>连接
        /// 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            m_dtSource1 = m_orddal.GetList("State=1 and AllowWorkType like '%mssql导入到mysql%' ", "id,SetOrdText,Remark").Tables[0];
            dataGridView1.DataSource = m_dtSource1;

            m_dtSource2 = m_orddal.GetList("State=1 and AllowWorkType like '%mssql更新到mysql%' ", "id,SetOrdText,Remark").Tables[0];
            dataGridView2.DataSource = m_dtSource2;

            m_dtSource3 = m_orddal.GetList("State=1 and AllowWorkType like '%mysql导入到mssql%' ", "id,SetOrdText,Remark").Tables[0];
            dataGridView3.DataSource = m_dtSource3;

            m_dtSource4 = m_orddal.GetList("State=1 and AllowWorkType like '%mysql更新到mssql%' ", "id,SetOrdText,Remark").Tables[0];
            dataGridView4.DataSource = m_dtSource4;

            m_dtSource5 = m_orddal.GetListForChangLiang("", "b.id,b.SetOrdText,b.Remark").Tables[0];
            dataGridView5.DataSource = m_dtSource5;
        }

        /// <summary>保存连接
        /// 保存连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigHelper.SetConfigKeyValue("mssqlserver", txtmssqlserver.Text);
                ConfigHelper.SetConfigKeyValue("mysql", txtmysql.Text);
                MessageBox.Show(@"保存成功,下次重新登录后生效");
            }
            catch (Exception)
            {
                MessageBox.Show(@"保存失败");
            }
        }

        /// <summary>测试连接
        /// 测试连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestConn_Click(object sender, EventArgs e)
        {
            if (txtmssqlserver.Text.Trim() == string.Empty)
            {
                txtmssqlserver.Select();
                MessageBox.Show("请输入SqlServer连接串");
                return;
            }

            if (txtmysql.Text.Trim() == string.Empty)
            {
                txtmysql.Select();
                MessageBox.Show("请输入MySql连接串");
                return;
            }
            try
            {
                MSSQLHelper helper = new MSSQLHelper(txtmssqlserver.Text.Trim());
                helper.CreateCommand("Select 1");
                helper.CloseConn();
            }
            catch (Exception)
            {
                MessageBox.Show(@"MSSqlserver测试连接失败！");
            }

            try
            {
                MySQLHelper helper = new MySQLHelper(txtmysql.Text.Trim());
                helper.CreateCommand("Select 1");
                helper.CloseConn();
            }
            catch (Exception)
            {
                MessageBox.Show(@"MySql测试连接失败！");
            }

            MessageBox.Show("连接成功");
            m_sqlserverhelper = new MSSQLHelper(txtmssqlserver.Text.Trim());
            m_myhelper = new MySQLHelper(txtmysql.Text.Trim());
        }

        /// <summary>mssql导入到mysql
        ///
        /// </summary>
        /// <param name="mssqltabname"></param>
        /// <param name="mysqltabname"></param>
        /// <param name="id"></param>
        private void DoMssqlAddToMysql(string mssqltabname, string mysqltabname, string id)
        {
            try
            {
                DataTable dt = m_orddal.GetList("State=1 and id='" + id + "'").Tables[0];
                string setordkey = dt.Rows[0]["id"].ToString();
                DataTable dtColumns = m_setdal.GetList("State=1 and SetKey='" + setordkey + "'and (ChangLiang='' OR  ChangLiang IS nULL )").Tables[0];
                string mysqlColumns = string.Empty;
                string mssqlColumns = string.Empty;
                string mysqlColumnsParas = string.Empty;
                for (int i = 0; i < dtColumns.Rows.Count; i++)
                {
                    mssqlColumns = mssqlColumns + dtColumns.Rows[i]["SetValue"] + ",";
                }
                for (int i = 0; i < dtColumns.Rows.Count; i++)
                {
                    mysqlColumns = mysqlColumns + dtColumns.Rows[i]["SetText"] + ",";
                    mysqlColumnsParas = mysqlColumnsParas + "@" + dtColumns.Rows[i]["SetText"] + ",";
                }
                string getmssql = "Select " + mssqlColumns.TrimEnd(',') + " from " + mssqltabname;
                m_sqlserverhelper.CreateCommand(getmssql);
                DataTable dtmssql = m_sqlserverhelper.ExecuteQuery();
                //标记ID
                DataRow[] drs = dtColumns.Select("Remark ='True'");
                //if (drs.Length == 0)
                //{
                //    MessageBox.Show(@"未找到设置的对应标记ID");
                //    return;
                //}
                string mysqlColumnsId = drs[0]["SetText"].ToString();
                string mssqlColumnsId = drs[0]["SetValue"].ToString();
                string getmysql = "Select " + mysqlColumns.TrimEnd(',') + " from " + mysqltabname;
                m_myhelper.CreateCommand(getmysql);
                DataTable dtmysql = m_myhelper.ExecuteQuery();
                string ids = string.Empty;
                for (int i = 0; i < dtmysql.Rows.Count; i++)
                {
                    ids = ids + dtmysql.Rows[i][mysqlColumnsId].ToString().Trim() + ",";
                }
                ids = ids.TrimEnd(',');

                var drsRows = ids.Length > 0 ? dtmssql.Select(" " + mssqlColumnsId + " not in (" + ids + " )") : dtmssql.Select(" 1=1");
                foreach (DataRow dr in drsRows)
                {
                    m_myhelper.CreateCommand("set names 'gbk' ;insert into " + mysqltabname + "(" + mysqlColumns.TrimEnd(',') + ") values (" + mysqlColumnsParas.TrimEnd(',') + ")");
                    for (int j = 0; j < dr.Table.Columns.Count; j++)
                    {
                        m_myhelper.AddParameter(mysqlColumnsParas.Split(',')[j], dr[dr.Table.Columns[j].ColumnName]);
                    }
                    m_myhelper.ExecuteNonQuery();
                    MsSqlImprortToMysqlAmount = MsSqlImprortToMysqlAmount + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        /// <summary>mssql更新到mysql
        ///
        /// </summary>
        /// <param name="mssqltabname"></param>
        /// <param name="mysqltabname"></param>
        /// <param name="id"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void DoMssqlUpdateToMysql(string mssqltabname, string mysqltabname, string id)
        {
            DataTable dt = m_orddal.GetList("State=1 and id='" + id + "'").Tables[0];
            string setordkey = dt.Rows[0]["id"].ToString();
            DataTable dtColumns = m_setdal.GetList("State=1 and SetKey='" + setordkey + "'   and (ChangLiang='' OR  ChangLiang IS nULL ) ").Tables[0];
            string mysqlColumns = string.Empty;
            string mssqlColumns = string.Empty;
            string mysqlColumnsParas = string.Empty; string mysqlColumnsUpdate = string.Empty;
            for (int i = 0; i < dtColumns.Rows.Count; i++)
            {
                mssqlColumns = mssqlColumns + dtColumns.Rows[i]["SetValue"] + ",";
            }

            string getmssql = "Select " + mssqlColumns.TrimEnd(',') + " from " + mssqltabname;
            m_sqlserverhelper.CreateCommand(getmssql);
            DataTable dtmssql = m_sqlserverhelper.ExecuteQuery();

            //标记ID
            DataRow[] drs = dtColumns.Select("Remark ='True'");
            if (drs.Length == 0)
            {
                MessageBox.Show(@"未找到设置的对应标记ID");
                return;
            }
            string mysqlColumnsId = drs[0]["SetText"].ToString();
            string mssqlColumnsId = drs[0]["SetValue"].ToString();
            for (int i = 0; i < dtColumns.Rows.Count; i++)
            {
                if (dtColumns.Rows[i]["SetText"].ToString().Trim() != mysqlColumnsId)
                {
                    mysqlColumnsUpdate = mysqlColumnsUpdate + dtColumns.Rows[i]["SetText"] + "=@" +
                                         dtColumns.Rows[i]["SetText"] + ",";
                }
                mysqlColumns = mysqlColumns + dtColumns.Rows[i]["SetText"] + ",";
                mysqlColumnsParas = mysqlColumnsParas + "@" + dtColumns.Rows[i]["SetText"] + ",";
            }
            string getmysql = "Select " + mysqlColumns.TrimEnd(',') + " from " + mysqltabname;
            m_myhelper.CreateCommand(getmysql);
            DataTable dtmysql = m_myhelper.ExecuteQuery();
            string ids = string.Empty;
            for (int i = 0; i < dtmysql.Rows.Count; i++)
            {
                ids = ids + dtmysql.Rows[i][mysqlColumnsId].ToString().Trim() + ",";
            }
            ids = ids.TrimEnd(',');
            var drsRows = ids.Length > 0 ? dtmssql.Select(" " + mssqlColumnsId + " in (" + ids + " )") : dtmssql.Select(" 1=1");

            foreach (DataRow dr in drsRows)
            {
                m_myhelper.CreateCommand("set names 'gbk' ;update " + mysqltabname + " set    " + mysqlColumnsUpdate.TrimEnd(',') + " where  " + mysqlColumnsId + "=@" + mysqlColumnsId + " ");
                for (int j = 0; j < dr.Table.Columns.Count; j++)
                {
                    m_myhelper.AddParameter(mysqlColumnsParas.Split(',')[j], dr[dr.Table.Columns[j].ColumnName]);
                }
                m_myhelper.ExecuteNonQuery();

                MsSqlUpdateToMysqlAmount = MsSqlUpdateToMysqlAmount + 1;
            }
        }

        /// <summary>mysql导入到mssql
        ///
        /// </summary>
        /// <param name="mysqltabname">mysql表名</param>
        /// <param name="mssqltabname">SqlServer表名</param>
        /// <param name="id"></param>
        private void DoMysqlAddToMssql(string mysqltabname, string mssqltabname, string id)
        {
            DataTable dt = m_orddal.GetList("State=1 and id='" + id + "'").Tables[0];
            string setordkey = dt.Rows[0]["id"].ToString();
            DataTable dtColumns = m_setdal.GetList("State=1 and SetKey='" + setordkey + "' and (ChangLiang='' OR  ChangLiang IS nULL ) ").Tables[0];
            string mysqlColumns = string.Empty;
            string mssqlColumns = string.Empty;
            string mssqlColumnsParas = string.Empty;
            for (int i = 0; i < dtColumns.Rows.Count; i++)
            {
                mysqlColumns = mysqlColumns + dtColumns.Rows[i]["SetText"] + ",";
            }
            for (int i = 0; i < dtColumns.Rows.Count; i++)
            {
                mssqlColumns = mssqlColumns + dtColumns.Rows[i]["SetValue"] + ",";
                mssqlColumnsParas = mssqlColumnsParas + "@" + dtColumns.Rows[i]["SetValue"] + ",";
            }
            string getmysql = "Select " + mysqlColumns.TrimEnd(',') + " from " + mysqltabname;
            m_myhelper.CreateCommand(getmysql);
            DataTable dtmysql = m_myhelper.ExecuteQuery();

            //标记ID
            DataRow[] drs = dtColumns.Select("Remark ='True'");
            //if (drs.Length == 0)
            //{
            //    MessageBox.Show(@"未找到设置的对应标记ID");
            //    return;
            //}
            string mysqlColumnsId = drs[0]["SetText"].ToString();
            string mssqlColumnsId = drs[0]["SetValue"].ToString();
            string getmssql = "Select " + mssqlColumns.TrimEnd(',') + " from " + mssqltabname;
            m_sqlserverhelper.CreateCommand(getmssql);
            var dtmssql = m_sqlserverhelper.ExecuteQuery();
            string ids = string.Empty;
            for (int i = 0; i < dtmssql.Rows.Count; i++)
            {
                ids = ids + dtmssql.Rows[i][mssqlColumnsId].ToString().Trim() + ",";
            }
            ids = ids.TrimEnd(',');

            var drsRows = ids.Length > 0 ? dtmysql.Select(" " + mysqlColumnsId + " not in (" + ids + " )") : dtmysql.Select(" 1=1");
            foreach (DataRow dr in drsRows)
            {
                m_sqlserverhelper.CreateCommand("insert into " + mssqltabname + "(" + mssqlColumns.TrimEnd(',') + ") values (" + mssqlColumnsParas.TrimEnd(',') + ")");
                for (int j = 0; j < dr.Table.Columns.Count; j++)
                {
                    m_sqlserverhelper.AddParameter(mssqlColumnsParas.Split(',')[j], dr[dr.Table.Columns[j].ColumnName]);
                }
                m_sqlserverhelper.ExecuteNonQuery();
                MySqlImprortToMssqlAmount = MySqlImprortToMssqlAmount + 1;
            }
        }

        /// <summary>mysql更新常量
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoMysqlUpdateChangLiang(string mysqltabname, string mssqltabname, string id)
        {
            DataTable dt = m_orddal.GetList("State=1 and id='" + id + "'").Tables[0];
            string setordkey = dt.Rows[0]["id"].ToString();
            DataTable dtColumns = m_setdal.GetList("State=1 and SetKey='" + setordkey + "' and (ChangLiang<>'' OR Remark='True') ").Tables[0];
            string mysqlColumns = string.Empty;
            string mssqlColumns = string.Empty;
            string mysqlColumnsParas = string.Empty;
            string mysqlColumnsUpdate = string.Empty;
            for (int i = 0; i < dtColumns.Rows.Count; i++)
            {
                if (dtColumns.Rows[i]["SetValue"].ToString().Trim() != string.Empty)
                {
                    mssqlColumns = mssqlColumns + dtColumns.Rows[i]["SetValue"] + ",";
                }
                //if (dtColumns.Rows[i]["ChangLiang"].ToString().Trim() != string.Empty)
                //{
                //    mssqlColumns = mssqlColumns + "ChangLiang" + i + "=" + dtColumns.Rows[i]["ChangLiang"] + ",";
                //}
            }

            string getmssql = "Select " + mssqlColumns.TrimEnd(',') + " from " + mssqltabname;
            m_sqlserverhelper.CreateCommand(getmssql);
            DataTable dtmssql = m_sqlserverhelper.ExecuteQuery();

            //标记ID
            DataRow[] drs = dtColumns.Select("Remark ='True'");
            if (drs.Length == 0)
            {
                MessageBox.Show(@"未找到设置的对应标记ID");
                return;
            }
            string mysqlColumnsId = drs[0]["SetText"].ToString();
            string mssqlColumnsId = drs[0]["SetValue"].ToString();
            for (int i = 0; i < dtColumns.Rows.Count; i++)
            {
                if (dtColumns.Rows[i]["SetText"].ToString().Trim() != mysqlColumnsId)
                {
                    mysqlColumnsUpdate = mysqlColumnsUpdate + dtColumns.Rows[i]["SetText"] + "=@" +
                                         dtColumns.Rows[i]["SetText"] + ",";
                }
                mysqlColumns = mysqlColumns + dtColumns.Rows[i]["SetText"] + ",";
                mysqlColumnsParas = mysqlColumnsParas + "@" + dtColumns.Rows[i]["SetText"] + ",";
            }
            string getmysql = "Select " + mysqlColumns.TrimEnd(',') + " from " + mysqltabname;
            m_myhelper.CreateCommand(getmysql);
            DataTable dtmysql = m_myhelper.ExecuteQuery();
            string ids = string.Empty;
            for (int i = 0; i < dtmysql.Rows.Count; i++)
            {
                ids = ids + dtmysql.Rows[i][mysqlColumnsId].ToString().Trim() + ",";
            }
            ids = ids.TrimEnd(',');
            var drsRows = ids.Length > 0
                ? dtmssql.Select(" " + mssqlColumnsId + " in (" + ids + " )")
                : dtmssql.Select(" 1=1");

            DataRow[] drsChangLiang = dtColumns.Select("ChangLIang <>''");
            DataTable dtChangLiang = drsChangLiang.CopyToDataTable();
            foreach (DataRow dr in drsRows)
            {
                m_myhelper.CreateCommand("set names 'gbk' ;update " + mysqltabname + " set    " +
                                       mysqlColumnsUpdate.TrimEnd(',') + " where  " + mysqlColumnsId + "=@" +
                                       mysqlColumnsId + " ");
                for (int j = 0; j < dr.Table.Columns.Count; j++)
                {
                    m_myhelper.AddParameter(mysqlColumnsParas.Split(',')[j], dr[dr.Table.Columns[j].ColumnName]);
                }

                for (int j = 0; j < dtChangLiang.Rows.Count; j++)
                {
                    m_myhelper.AddParameter("@" + dtChangLiang.Rows[j]["SetText"].ToString(), dtChangLiang.Rows[j]["ChangLiang"].ToString());
                }
                m_myhelper.ExecuteNonQuery();
                MysqlUpdateChangLiang = MysqlUpdateChangLiang + 1;
            }
        }

        /// <summary>mysql更新到mssql
        ///
        /// </summary>
        /// <param name="mysqltabname"></param>
        /// <param name="mssqltabname"></param>
        /// <param name="id"></param>
        private void DoMysqlUpdateToMssql(string mysqltabname, string mssqltabname, string id)
        {
            DataTable dt = m_orddal.GetList("State=1 and id='" + id + "'").Tables[0];
            string setordkey = dt.Rows[0]["id"].ToString();
            DataTable dtColumns = m_setdal.GetList("State=1 and SetKey='" + setordkey + "' and (ChangLiang='' OR  ChangLiang IS nULL ) ").Tables[0];
            string mysqlColumns = string.Empty;
            string mssqlColumns = string.Empty;
            string mssqlColumnsParas = string.Empty; string mssqlColumnsUpdate = string.Empty;
            for (int i = 0; i < dtColumns.Rows.Count; i++)
            {
                mysqlColumns = mysqlColumns + dtColumns.Rows[i]["SetText"] + ",";
            }

            string getmysql = "Select " + mysqlColumns.TrimEnd(',') + " from " + mysqltabname;
            m_myhelper.CreateCommand(getmysql);
            DataTable dtmysql = m_myhelper.ExecuteQuery();

            //标记ID
            DataRow[] drs = dtColumns.Select("Remark ='True'");
            if (drs.Length == 0)
            {
                MessageBox.Show(@"未找到设置的对应标记ID");
                return;
            }

            string mysqlColumnsId = drs[0]["SetText"].ToString();
            string mssqlColumnsId = drs[0]["SetValue"].ToString();
            for (int i = 0; i < dtColumns.Rows.Count; i++)
            {
                if (dtColumns.Rows[i]["SetText"].ToString().Trim() != mysqlColumnsId)
                {
                    mssqlColumnsUpdate = mssqlColumnsUpdate + dtColumns.Rows[i]["SetValue"] + "=@" +
                                         dtColumns.Rows[i]["SetValue"] + ",";
                }
                mssqlColumns = mssqlColumns + dtColumns.Rows[i]["SetValue"] + ",";
                mssqlColumnsParas = mssqlColumnsParas + "@" + dtColumns.Rows[i]["SetValue"] + ",";
            }
            string getmssql = "Select " + mssqlColumns.TrimEnd(',') + " from " + mssqltabname;
            m_sqlserverhelper.CreateCommand(getmssql);
            DataTable dtmssql = m_sqlserverhelper.ExecuteQuery();
            string ids = string.Empty;
            for (int i = 0; i < dtmssql.Rows.Count; i++)
            {
                ids = ids + dtmssql.Rows[i][mssqlColumnsId].ToString().Trim() + ",";
            }
            ids = ids.TrimEnd(',');

            var drsRows = ids.Length > 0 ? dtmysql.Select(" " + mysqlColumnsId + "   in (" + ids + " )") : dtmysql.Select(" 1=1");
            foreach (DataRow dr in drsRows)
            {
                m_sqlserverhelper.CreateCommand(" update " + mssqltabname + " set    " + mssqlColumnsUpdate.TrimEnd(',') + " where  " + mssqlColumnsId + "=@" + mssqlColumnsId + " ");
                for (int j = 0; j < dr.Table.Columns.Count; j++)
                {
                    m_sqlserverhelper.AddParameter(mssqlColumnsParas.Split(',')[j], dr[dr.Table.Columns[j].ColumnName]);
                }
                m_sqlserverhelper.ExecuteNonQuery();
                MysqlUpdateToMsSqlAmount = MysqlUpdateToMsSqlAmount + 1;
            }
        }

        /// <summary>窗体加载
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSynchronization_Load(object sender, EventArgs e)
        {
            m_orddal = new SetOrdTableDAL();
            m_setdal = new SetTableDAL();
            txtmssqlserver.Text = ConfigHelper.GetConfigKeyValue("sqlserver");
            txtmysql.Text = ConfigHelper.GetConfigKeyValue("mysql");
            if (txtmssqlserver.Text.Trim() != string.Empty)
            {
                m_sqlserverhelper = new MSSQLHelper(txtmssqlserver.Text.Trim());
            }
            if (txtmysql.Text.Trim() != string.Empty)
            {
                m_myhelper = new MySQLHelper(txtmysql.Text.Trim());
            }
            btnConnect_Click(null, null);
        }
    }
}