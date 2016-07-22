using ICSharpCode.TextEditor.Document;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Nikita.Assist.CodeMaker
{
    public partial class FrmModelCreater : Form
    {
        private readonly BasicParameter m_basicParameter;
        private readonly DbSchema m_dbSchema;
        private readonly List<string> m_lstLeft = new List<string>();
        private readonly List<string> m_lstRight = new List<string>();
        private IModelMaker m_modelMaker;

        public FrmModelCreater(BasicParameter basicParameter, DbSchema dbSchema)
        {
            InitializeComponent();

            #region 设置高亮显示属性

            txtCode.ShowEOLMarkers = false;
            txtCode.ShowHRuler = false;
            txtCode.ShowInvalidLines = false;
            txtCode.ShowMatchingBracket = true;
            txtCode.ShowSpaces = false;
            txtCode.ShowTabs = false;
            txtCode.ShowVRuler = false;
            txtCode.AllowCaretBeyondEOL = false;
            txtCode.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
            txtCode.Encoding = Encoding.GetEncoding("GB2312");

            #endregion 设置高亮显示属性

            this.m_basicParameter = basicParameter;
            this.m_dbSchema = dbSchema;
            foreach (var item in m_dbSchema.DatabaseSchema.Tables)
            {
                m_lstLeft.Add(item.Name);
                lsbleft.Items.Add(item.Name);
            }
        }

        //右边全部到左边
        private void btnAllToLeft_Click(object sender, EventArgs e)
        {
            foreach (string item in lsbright.Items)
            {
                m_lstRight.Remove(item);
                m_lstLeft.Add(item);
            }

            m_lstLeft.Sort();
            m_lstRight.Sort();

            lsbright.Items.Clear();
            if (m_lstRight.Count > 0)
            {
                lsbright.Items.AddRange(m_lstRight.ToArray());
            }
            lsbleft.Items.Clear();
            if (m_lstLeft.Count > 0)
            {
                lsbleft.Items.AddRange(m_lstLeft.ToArray());
            }
        }

        //左边全部到右边
        private void btnAllToRight_Click(object sender, EventArgs e)
        {
            foreach (string item in lsbleft.Items)
            {
                m_lstRight.Add(item);
                m_lstLeft.Remove(item);
            }

            m_lstLeft.Sort();
            m_lstRight.Sort();

            lsbright.Items.Clear();
            lsbright.Items.AddRange(m_lstRight.ToArray());
            lsbleft.Items.Clear();
            lsbleft.Items.AddRange(m_lstLeft.ToArray());
        }

        //生成代码
        private void btnGen_Click(object sender, EventArgs e)
        {
            if (lsbright.Items.Count == 0)
            {
                MessageBox.Show(@"请选择操作表.");
                return;
            }
            if (m_basicParameter.OutFolderPath == string.Empty)
            {
                MessageBox.Show(@"请在基础设置里面设置代码生成路径");
                return;
            }
            if (string.IsNullOrEmpty(m_basicParameter.NameSpace))
            {
                MessageBox.Show(@"请在基础设置里面设置命名空间.");
                return;
            }
            if (!Directory.Exists(m_basicParameter.OutFolderPath))
            {
                Directory.CreateDirectory(m_basicParameter.OutFolderPath);
            }

            #region 生成实体

            string strOutPutModel;
            if (m_basicParameter.OutFolderPath.Substring(m_basicParameter.OutFolderPath.Length - 2, 2) == "\\")
            {
                strOutPutModel = m_basicParameter.OutFolderPath + "Model\\";
            }
            else
            {
                strOutPutModel = m_basicParameter.OutFolderPath + "\\Model\\";
            }
            if (!Directory.Exists(strOutPutModel))
            {
                Directory.CreateDirectory(strOutPutModel);
            }

            string strPrefix = txtPrefix.Text.Trim();
            foreach (string strTableName in lsbright.Items)
            {
                var strClassName = strTableName;
                if (strPrefix.Length > 0)
                {
                    strClassName = strTableName.Replace(strPrefix, "");
                }
                strClassName = strClassName.Substring(0, 1).ToUpper() + strClassName.Substring(1);
                string strFilePath = strOutPutModel + strClassName + ".cs";
                StreamWriter sw = new StreamWriter(strFilePath, false);
                if (m_modelMaker == null)
                {
                    m_modelMaker = ModelMakerManager.GetModelMaker(m_dbSchema.SqlType);
                }
                sw.Write(m_modelMaker.GenModelCode(m_basicParameter.NameSpace, strTableName, strClassName, m_dbSchema.DatabaseSchema.ConnectionString, m_basicParameter.Author));
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }

            #endregion 生成实体

            MessageBox.Show(@"代码生成功.");
            txtCode.Text = @"代码已生成到:" + m_basicParameter.OutFolderPath;
            System.Diagnostics.Process.Start(m_basicParameter.OutFolderPath);
        }

        // 实体预览
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (lsbright.Items.Count == 0)
            {
                MessageBox.Show(@"请选择操作表.");
                return;
            }
            if (m_modelMaker == null)
            {
                m_modelMaker = ModelMakerManager.GetModelMaker(m_dbSchema.SqlType);
            }
            string strTableName = lsbright.Items[0].ToString();
            txtCode.Text = m_modelMaker.GenModelCode(m_basicParameter.NameSpace, strTableName, strTableName, m_dbSchema.DatabaseSchema.ConnectionString, m_basicParameter.Author);
        }

        //右边到左边
        private void btnToLeft_Click(object sender, EventArgs e)
        {
            foreach (string item in lsbright.SelectedItems)
            {
                m_lstRight.Remove(item);
                m_lstLeft.Add(item);
            }

            m_lstLeft.Sort();
            m_lstRight.Sort();

            lsbright.Items.Clear();
            lsbright.Items.AddRange(m_lstRight.ToArray());
            lsbleft.Items.Clear();
            lsbleft.Items.AddRange(m_lstLeft.ToArray());
        }

        //左边到右边
        private void btnToRight_Click(object sender, EventArgs e)
        {
            foreach (string item in lsbleft.SelectedItems)
            {
                m_lstRight.Add(item);
                m_lstLeft.Remove(item);
            }

            m_lstLeft.Sort();
            m_lstRight.Sort();

            lsbright.Items.Clear();
            lsbright.Items.AddRange(m_lstRight.ToArray());
            lsbleft.Items.Clear();
            lsbleft.Items.AddRange(m_lstLeft.ToArray());
        }

        //左边鼠标双击时
        private void lsbleft_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (string item in lsbleft.SelectedItems)
            {
                m_lstRight.Add(item);
                m_lstLeft.Remove(item);
            }

            m_lstLeft.Sort();
            m_lstRight.Sort();

            lsbright.Items.Clear();
            lsbright.Items.AddRange(m_lstRight.ToArray());
            lsbleft.Items.Clear();
            lsbleft.Items.AddRange(m_lstLeft.ToArray());
        }

        //右边鼠标双击时
        private void lsbright_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (string item in lsbright.SelectedItems)
            {
                m_lstRight.Remove(item);
                m_lstLeft.Add(item);
            }

            m_lstLeft.Sort();
            m_lstRight.Sort();

            lsbright.Items.Clear();
            lsbright.Items.AddRange(m_lstRight.ToArray());
            lsbleft.Items.Clear();
            lsbleft.Items.AddRange(m_lstLeft.ToArray());
        }
    }
}