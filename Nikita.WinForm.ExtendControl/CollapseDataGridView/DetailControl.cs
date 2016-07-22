using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Nikita.WinForm.ExtendControl
{
    /// <summary>此类用来定义盛放子DataGridview的容器
    ///
    /// </summary>
    [ToolboxItem(false)]
    public class DetailControl : Panel
    {
        #region 字段

        public DataSet CDataset;
        public List<DataGridView> ChildGrid = new List<DataGridView>();

        #endregion 字段

        #region 方法

        public void Add(string tableName, string strPrimaryKey, string strForeignKey)
        {
            //TabPage tPage = new TabPage() { Text = pageCaption };
            //this.Controls.Add(tPage);
            MasterControl newGrid = new MasterControl(CDataset, ControlType.Middle)
            {
                Dock = DockStyle.Fill,
                DataSource = new DataView(CDataset.Tables[tableName])
            };
            newGrid.SetParentSource(tableName, strPrimaryKey, strForeignKey);//设置主外键
            //newGrid.Name = "ChildrenMaster";
            //tPage.Controls.Add(newGrid);
            this.Controls.Add(newGrid);
            //this.BorderStyle = BorderStyle.FixedSingle;
            CModule.ApplyGridTheme(newGrid);
            CModule.SetGridRowHeader(newGrid);
            newGrid.RowPostPaint += CModule.rowPostPaint_HeaderCount;
            ChildGrid.Add(newGrid);
        }

        public void Add2(string tableName)
        {
            //TabPage tPage = new TabPage() { Text = pageCaption };
            //this.Controls.Add(tPage);
            DataGridView newGrid = new DataGridView
            {
                Dock = DockStyle.Fill,
                DataSource = new DataView(CDataset.Tables[tableName]),
                AllowUserToAddRows = false
            };
            //tPage.Controls.Add(newGrid);
            this.Controls.Add(newGrid);
            CModule.ApplyGridTheme(newGrid);
            CModule.SetGridRowHeader(newGrid);
            newGrid.RowPostPaint += CModule.rowPostPaint_HeaderCount;
            ChildGrid.Add(newGrid);
        }

        public void RemoveControl()
        {
            this.Controls.Remove(ChildGrid[0]);
            ChildGrid.Clear();
        }

        #endregion 方法
    }
}