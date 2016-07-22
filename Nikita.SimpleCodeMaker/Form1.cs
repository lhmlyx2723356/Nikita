using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using System.Data.SQLite;

namespace Nikita.Assist.SimpleCodeMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //窗体加载
        private void Form1_Load(object sender, EventArgs e)
        {

            XDocument xdoc = XDocument.Load(System.Environment.CurrentDirectory + "\\appconfig.xml");

            var ad = from a in xdoc.Descendants("Config")
                     select new
                     {
                         dbtype = a.Element("dbtype").Value,
                         connstr = a.Element("connstr").Value,
                         genway = a.Element("genway").Value,
                         ns = a.Element("namespace").Value,
                         front = a.Element("front").Value,
                         output = a.Element("output").Value
                     };

            cobdbtype.SelectedItem = ad.ElementAt(0).dbtype;
            txtconnstr.Text = ad.ElementAt(0).connstr;
            if (ad.ElementAt(0).genway == "0")
            {
                rad0.Checked = true;
            }
            else
            {
                rad1.Checked = true;
            }
            txtnamespace.Text = ad.ElementAt(0).ns;
            txtfront.Text = ad.ElementAt(0).front;
            txtoutput.Text = ad.ElementAt(0).output;
        }

        List<string> listleft = new List<string>();
        List<string> listright = new List<string>();

        //连接数据库,显示所有的表
        private void btnlink_Click(object sender, EventArgs e)
        {
            try
            {
                lsbleft.Items.Clear();
                lsbright.Items.Clear();
                listleft.Clear();
                listright.Clear();
                string connstr = txtconnstr.Text.Trim();

                string tmp = cobdbtype.SelectedItem.ToString();

                //sqlite
                if (tmp == "Sqlite")
                {
                    SQLiteConnection conn = new SQLiteConnection(connstr);
                    conn.Open();
                    string sql = "select name from sqlite_master where type='table'";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    SQLiteDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        listleft.Add(sdr[0].ToString());
                    }
                    lsbleft.Items.AddRange(listleft.ToArray());
                    conn.Close();
                }

                //MySQL
                if (tmp == "MySQL")
                {
                    MySqlConnection conn = new MySqlConnection(connstr);
                    conn.Open();
                    string sql = "show tables";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader mdr = cmd.ExecuteReader();
                    while (mdr.Read())
                    {
                        listleft.Add(mdr[0].ToString());
                    }
                    lsbleft.Items.AddRange(listleft.ToArray());
                    conn.Close();
                }

                //Access
                if (tmp == "Access")
                {
                    OleDbConnection conn = new OleDbConnection(connstr);
                    conn.Open();
                    string sql = "SELECT MSysObjects.Name FROM MsysObjects WHERE (Left([Name],1)<>\"~\") AND (Left$([Name],4) <> \"Msys\") AND (MSysObjects.Type)=1 ORDER BY MSysObjects.Name;";
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader odr = cmd.ExecuteReader();
                    while (odr.Read())
                    {
                        listleft.Add(odr["name"].ToString());
                    }
                    lsbleft.Items.AddRange(listleft.ToArray());
                    conn.Close();
                }

                //SQL Server
                if (tmp == "SQL Server")
                {
                    SqlConnection conn = new SqlConnection(connstr);
                    conn.Open();
                    string sql = "SELECT name FROM sysobjects WHERE xtype = 'U' AND OBJECTPROPERTY (id, 'IsMSShipped') = 0  order by name ";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        listleft.Add(sdr["name"].ToString());
                    }
                    lsbleft.Items.AddRange(listleft.ToArray());
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //窗体关闭时,记录配置到配置文件中
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string dbtype = cobdbtype.SelectedItem.ToString();
                string connstr = txtconnstr.Text.Trim();
                string genway = rad0.Checked ? "0" : "1";
                string ns = txtnamespace.Text.Trim();
                string front = txtfront.Text.Trim();
                string output = txtoutput.Text.Trim();


                XElement owner = new XElement("Config", new XElement[]{  
                        new XElement("dbtype",dbtype),  
                        new XElement("connstr",connstr),  
                        new XElement("genway",genway),  
                        new XElement("namespace",ns),  
                        new XElement("front",front),  
                        new XElement("output",output),  
                   });
                owner.Save(System.Environment.CurrentDirectory + "\\appconfig.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //左边到右边
        private void btntoright_Click(object sender, EventArgs e)
        {
            foreach (string item in lsbleft.SelectedItems)
            {
                listright.Add(item);
                listleft.Remove(item);
            }

            listleft.Sort();
            listright.Sort();

            lsbright.Items.Clear();
            lsbright.Items.AddRange(listright.ToArray());
            lsbleft.Items.Clear();
            lsbleft.Items.AddRange(listleft.ToArray());
        }

        //右边到左边
        private void btntoleft_Click(object sender, EventArgs e)
        {
            foreach (string item in lsbright.SelectedItems)
            {
                listright.Remove(item);
                listleft.Add(item);
            }

            listleft.Sort();
            listright.Sort();

            lsbright.Items.Clear();
            lsbright.Items.AddRange(listright.ToArray());
            lsbleft.Items.Clear();
            lsbleft.Items.AddRange(listleft.ToArray());
        }

        //左边全部到右边
        private void btnalltoright_Click(object sender, EventArgs e)
        {
            foreach (string item in lsbleft.Items)
            {
                listright.Add(item);
                listleft.Remove(item);
            }

            listleft.Sort();
            listright.Sort();

            lsbright.Items.Clear();
            lsbright.Items.AddRange(listright.ToArray());
            lsbleft.Items.Clear();
            lsbleft.Items.AddRange(listleft.ToArray());
        }


        //右边全部到左边
        private void btnalltoleft_Click(object sender, EventArgs e)
        {
            foreach (string item in lsbright.Items)
            {
                listright.Remove(item);
                listleft.Add(item);
            }

            listleft.Sort();
            listright.Sort();

            lsbright.Items.Clear();
            lsbright.Items.AddRange(listright.ToArray());
            lsbleft.Items.Clear();
            lsbleft.Items.AddRange(listleft.ToArray());
        }

        //左边鼠标双击时
        private void lsbleft_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (string item in lsbleft.SelectedItems)
            {
                listright.Add(item);
                listleft.Remove(item);
            }

            listleft.Sort();
            listright.Sort();

            lsbright.Items.Clear();
            lsbright.Items.AddRange(listright.ToArray());
            lsbleft.Items.Clear();
            lsbleft.Items.AddRange(listleft.ToArray());
        }

        //右边鼠标双击时
        private void lsbright_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (string item in lsbright.SelectedItems)
            {
                listright.Remove(item);
                listleft.Add(item);
            }

            listleft.Sort();
            listright.Sort();

            lsbright.Items.Clear();
            lsbright.Items.AddRange(listright.ToArray());
            lsbleft.Items.Clear();
            lsbleft.Items.AddRange(listleft.ToArray());
        }

        // model预览
        private void btnmodelyl_Click(object sender, EventArgs e)
        {
            if (lsbright.Items.Count == 0)
            {
                MessageBox.Show("请选择操作表.");
                return;
            }

            string tmp = cobdbtype.SelectedItem.ToString();

            string tabname = lsbright.Items[0].ToString();
            string ns = txtnamespace.Text.Trim();
            if (string.IsNullOrEmpty(ns))
            {
                MessageBox.Show("请输入命名空间.");
                return;
            }
            string front = txtfront.Text.Trim();
            string classname = tabname;
            if (front.Length > 0)
            {
                classname = tabname.Replace(front, "");
            }
            classname = classname.Substring(0, 1).ToUpper() + classname.Substring(1);
            string connstr = txtconnstr.Text.Trim();

            if (tmp == "Sqlite")
            {
                txtyl.Text = GenModel_SQLite.GenAllCode(ns, tabname, classname, connstr);
            }


            if (tmp == "MySQL")
            {
                txtyl.Text = GenModel_MySQL.GenAllCode(ns, tabname, classname, connstr);
            }

            if (tmp == "Access")
            {
                txtyl.Text = GenModel_Access.GenAllCode(ns, tabname, classname, connstr);
            }

            if (tmp == "SQL Server")
            {
                txtyl.Text = GenModel_MSSQL.GenAllCode(ns, tabname, classname, connstr);
            }
        }

        //dal预览
        private void btndalyl_Click(object sender, EventArgs e)
        {
            if (lsbright.Items.Count == 0)
            {
                MessageBox.Show("请选择操作表.");
                return;
            }

            string tmp = cobdbtype.SelectedItem.ToString();


            string tabname = lsbright.Items[0].ToString();
            string ns = txtnamespace.Text.Trim();
            if (string.IsNullOrEmpty(ns))
            {
                MessageBox.Show("请输入命名空间.");
                return;
            }
            string front = txtfront.Text.Trim();
            string classname = tabname;
            if (front.Length > 0)
            {
                classname = tabname.Replace(front, "");
            }
            classname = classname.Substring(0, 1).ToUpper() + classname.Substring(1);
            string connstr = txtconnstr.Text.Trim();

            if (rad0.Checked)
            {
                //基于微软企业库生成DAL
                txtyl.Text = GenDAL_MSSQL.GenAllCode(ns, tabname, classname, connstr);
            }
            else if (rad1.Checked)
            {
                //基于UsTeam数据库操作类生成DAL
                if (tmp == "Sqlite")
                {
                    txtyl.Text = GenDAL_SQLite_niunan.GenAllCode(ns, tabname, classname, connstr);
                }
                if (tmp == "MySQL")
                {
                    txtyl.Text = GenDAL_MySQL_niunan.GenAllCode(ns, tabname, classname, connstr);
                }
                if (tmp == "Access")
                {
                    txtyl.Text = GenDAL_Access_niunan.GenAllCode(ns, tabname, classname, connstr);
                }
                if (tmp == "SQL Server")
                {
                    txtyl.Text = GenDAL_MSSQL_niunan.GenAllCode(ns, tabname, classname, connstr);
                }
            }
            else
            {
                //基于Wcf数据库操作类生成DAL
                if (tmp == "Sqlite")
                {
                    txtyl.Text = GenDAL_SQLite_Wcf.GenAllCode(ns, tabname, classname, connstr);
                }
                if (tmp == "MySQL")
                {
                    txtyl.Text = GenDAL_MySQL_Wcf.GenAllCode(ns, tabname, classname, connstr);
                }
                if (tmp == "Access")
                {
                    txtyl.Text = GenDAL_Access_Wcf.GenAllCode(ns, tabname, classname, connstr);
                }
                if (tmp == "SQL Server")
                {
                    txtyl.Text = GenDAL_MSSQL_Wcf.GenAllCode(ns, tabname, classname, connstr);
                }

            }

        }


        //生成代码
        private void btngen_Click(object sender, EventArgs e)
        {
            if (lsbright.Items.Count == 0)
            {
                MessageBox.Show("请选择操作表.");
                return;
            }

            string tmp = cobdbtype.SelectedItem.ToString();


            string output = txtoutput.Text.Trim();
            if (!Directory.Exists(output))
            {
                Directory.CreateDirectory(output);
            }

            #region Model
            string output_model = "";
            if (output.Substring(output.Length - 2, 2) == "\\")
            {
                output_model = output + "Model\\";
            }
            else
            {
                output_model = output + "\\Model\\";
            }
            if (!Directory.Exists(output_model))
            {
                Directory.CreateDirectory(output_model);
            }

            string ns = txtnamespace.Text.Trim();
            if (string.IsNullOrEmpty(ns))
            {
                MessageBox.Show("请输入命名空间.");
                return;
            }
            string front = txtfront.Text.Trim();
            string classname = "";
            string connstr = txtconnstr.Text.Trim();

            foreach (string tabname in lsbright.Items)
            {
                classname = tabname;
                if (front.Length > 0)
                {
                    classname = tabname.Replace(front, "");
                }
                classname = classname.Substring(0, 1).ToUpper() + classname.Substring(1);

                string filepath = output_model + classname + ".cs";
                StreamWriter sw = new StreamWriter(filepath, false);
                if (tmp == "Sqlite")
                {
                    sw.Write(GenModel_SQLite.GenAllCode(ns, tabname, classname, connstr));
                }
                if (tmp == "MySQL")
                {
                    sw.Write(GenModel_MySQL.GenAllCode(ns, tabname, classname, connstr));
                }
                if (tmp == "SQL Server")
                {
                    sw.Write(GenModel_MSSQL.GenAllCode(ns, tabname, classname, connstr));
                }
                else if (tmp == "Access")
                {
                    sw.Write(GenModel_Access.GenAllCode(ns, tabname, classname, connstr));
                }
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
            #endregion

            #region DAL
            string output_dal = "";
            if (output.Substring(output.Length - 2, 2) == "\\")
            {
                output_dal = output + "DAL\\";
            }
            else
            {
                output_dal = output + "\\DAL\\";
            }
            if (!Directory.Exists(output_dal))
            {
                Directory.CreateDirectory(output_dal);
            }

            foreach (string tabname in lsbright.Items)
            {
                classname = tabname;

                if (front.Length > 0)
                {
                    classname = tabname.Replace(front, "");
                }
                classname = classname.Substring(0, 1).ToUpper() + classname.Substring(1);

                string filepath = output_dal + classname + "DAL.cs";
                string filepathExtend = output_dal + classname + "DALExtend.cs";
                StreamWriter sw = new StreamWriter(filepath, false);
                StreamWriter swExtend = new StreamWriter(filepathExtend, false);
                if (rad0.Checked)
                {
                    //基于微软企业库
                    sw.Write(GenDAL_MSSQL.GenAllCode(ns, tabname, classname, connstr));
                }
                else if (rad1.Checked)
                {
                    //基于UsTeam数据库操作类生成DAL 
                    if (tmp == "Sqlite")
                    {
                        sw.Write(GenDAL_SQLite_niunan.GenAllCode(ns, tabname, classname, connstr));
                        swExtend.Write(GenExtendClass.GenSqliteExtend(ns, tabname, classname, connstr));

                    }
                    if (tmp == "MySQL")
                    {
                        sw.Write(GenDAL_MySQL_niunan.GenAllCode(ns, tabname, classname, connstr));
                        swExtend.Write(GenExtendClass.GenMysqlExtend(ns, tabname, classname, connstr));
                    }
                    if (tmp == "SQL Server")
                    {
                        sw.Write(GenDAL_MSSQL_niunan.GenAllCode(ns, tabname, classname, connstr));
                        swExtend.Write(GenExtendClass.GenMssqlExtend(ns, tabname, classname, connstr));
                    }
                    else if (tmp == "Access")
                    {
                        sw.Write(GenDAL_Access_niunan.GenAllCode(ns, tabname, classname, connstr));
                        swExtend.Write(GenExtendClass.GenAccessExtend(ns, tabname, classname, connstr));
                    }
                }
                else
                {
                    //基于Wcf数据库操作类生成DAL
                    if (tmp == "Sqlite")
                    {
                        sw.Write(GenDAL_SQLite_Wcf.GenAllCode(ns, tabname, classname, connstr));
                        swExtend.Write(GenExtendClass.GenSqliteExtend(ns, tabname, classname, connstr));
                    }
                    if (tmp == "MySQL")
                    {
                        sw.Write( GenDAL_MySQL_Wcf.GenAllCode(ns, tabname, classname, connstr));
                        swExtend.Write(GenExtendClass.GenMysqlExtend(ns, tabname, classname, connstr));
                    }
                    if (tmp == "Access")
                    {
                       sw.Write( GenDAL_Access_Wcf.GenAllCode(ns, tabname, classname, connstr));
                        swExtend.Write(GenExtendClass.GenAccessExtend(ns, tabname, classname, connstr));
                    }
                    if (tmp == "SQL Server")
                    {
                       sw.Write(GenDAL_MSSQL_Wcf.GenAllCode(ns, tabname, classname, connstr));
                        swExtend.Write(GenExtendClass.GenMssqlExtend(ns, tabname, classname, connstr));
                    }

                }


                sw.Flush();
                sw.Close();
                sw.Dispose();
                swExtend.Flush();
                swExtend.Close();
                swExtend.Dispose();
            }
            #endregion

            #region MSSQLHelper
            if (rad1.Checked)
            {
                if (tmp == "Sqlite")
                {
                    string filepath = output_dal + "SQLiteHelper.cs";
                    StreamWriter sw = new StreamWriter(filepath, false);
                    sw.Write(GenDAL_SQLite_niunan.GenSQLiteHelper(ns, connstr));
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
                if (tmp == "SQL Server")
                {
                    string filepath = output_dal + "MSSQLHelper.cs";
                    StreamWriter sw = new StreamWriter(filepath, false);
                    sw.Write(GenDAL_MSSQL_niunan.GenMSSQLHelper(ns, connstr));
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
                else if (tmp == "Access")
                {
                    string filepath = output_dal + "AccessHelper.cs";
                    StreamWriter sw = new StreamWriter(filepath, false);
                    sw.Write(GenDAL_Access_niunan.GenAccessHelper(ns, connstr));
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
                else if (tmp == "MySQL")
                {
                    string filepath = output_dal + "MySQLHelper.cs";
                    StreamWriter sw = new StreamWriter(filepath, false);
                    sw.Write(GenDAL_MySQL_niunan.GenMySQLHelper(ns, connstr));
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
            #endregion

            MessageBox.Show("代码生成功.");
            txtyl.Text = "代码已生成到:" + output;
            System.Diagnostics.Process.Start(output);
        }

        //选择数据库时,右边显示示例连接字符串
        private void cobdbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsbright.Items.Clear();
            switch (cobdbtype.SelectedItem.ToString())
            {
                case "SQL Server":
                    rad0.Enabled = true;
                    txtyl.Text = @"示例连接字符串: server=.\sqlexpress;uid=sa;pwd=123456;database=UsTeamtest";
                    break;
                case "MySQL":
                    rad0.Enabled = false;
                    txtyl.Text = @"示例连接字符串: server=localhost;database=test;uid=root;pwd=123456;charset=utf8";
                    break;
                case "Access":
                    rad0.Enabled = false;
                    txtyl.Text = @"示例连接字符串: Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|data.mdb";
                    break;
                case "Sqlite":
                    rad0.Enabled = false;
                    txtyl.Text = @"示例连接字符串: Data Source=d:/data/fdm.sqlite";
                    break;
                default:
                    break;
            }
        }

        //生成数据库文档
        private void button1_Click(object sender, EventArgs e)
        {
            if (lsbright.Items.Count == 0)
            {
                MessageBox.Show("请选择操作表.");
                return;
            }

            List<string> list_right = new List<string>(); //要生成数据库文档的表名集合
            string connstr = txtconnstr.Text.Trim(); // 数据库连接字符串

            foreach (string tabname in lsbright.Items)
            {
                list_right.Add(tabname);
            }

            string tmp = cobdbtype.SelectedItem.ToString(); //数据库类型


            string output = txtoutput.Text.Trim();
            if (!Directory.Exists(output))
            {
                Directory.CreateDirectory(output);
            }

            string filepath = string.Empty;
            if (output.Substring(output.Length - 2, 2) == "\\")
            {

                filepath = output + Tools.GetDBName(tmp, connstr) + "数据库文档.html";
            }
            else
            {
                filepath = output + "\\" + Tools.GetDBName(tmp, connstr) + "数据库文档.html";
            }
            StreamWriter sw = new StreamWriter(filepath, false, Encoding.UTF8);
            sw.Write(DBDocGen.GenDoc(tmp, connstr, list_right));
            sw.Flush();
            sw.Close();
            sw.Dispose();


            MessageBox.Show("文档生成功.");
            txtyl.Text = "文档已生成到:" + output;
            System.Diagnostics.Process.Start(output);
        }





    }
}
