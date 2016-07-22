using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Nikita.WinForm.ExtendControl
{
    /// <summary>
    /// 此类用来定义折叠的DataGridView
    /// </summary>
    [ToolboxItem(false)]
    public class MasterControl : DataGridView
    {
        #region 字段

        public DetailControl ChildView = new DetailControl() { Visible = false };
        public int ExpandRowIndex;
        internal static bool CollapseRow;
        internal static int RowDefaultDivider = 0;
        internal static int RowDefaultHeight = 22;
        internal static int RowDividerMargin = 5;
        internal static int RowExpandedDivider = 300 - 22;
        internal static int RowExpandedHeight = 300;
        internal ImageList RowHeaderIconList;
        private readonly List<int> _rowCurrent = new List<int>();
        private DataSet _cDataset;
        private Container _components;
        private ControlType _eControlType;
        private string _filterFormat;
        private string _foreignKey;
        private string _primaryKey;

        #endregion 字段

        #region 构造函数

        /// <summary>
        /// 通过传递过来的枚举判断是两级还是三级展开，表的对应关系通过Relations来读取
        /// 所以调用此构造函数的时候必须要讲Relations设置正确，才能正确显示层级关系。
        ///  oDataSet.Relations.Add("1", oDataSet.Tables["T1"].Columns["Menu_ID"], oDataSet.Tables["T2"].Columns["Menu_ID"]);
        ///  oDataSet.Relations.Add("2", oDataSet.Tables["T2"].Columns["Menu_Name2"], oDataSet.Tables["T3"].Columns["Menu_Name2"]);
        ///  这两次Add的顺序不能颠倒，必须先添加一、二级的表关联，再添加二、三级的表关联
        /// </summary>
        /// <param name="cDataset">数据源DataSet，里面还有各个表的对应关系</param>
        /// <param name="eControlType">枚举类型</param>
        public MasterControl(DataSet cDataset, ControlType eControlType)
        {
            SetMasterControl(cDataset, eControlType);
        }

        /// <summary>
        /// 第二种使用方法
        /// </summary>
        /// <param name="lstData1">折叠控件第一层的集合</param>
        /// <param name="lstData2">折叠控件第二层的集合</param>
        /// <param name="lstData3">折叠控件第三层的集合</param>
        /// <param name="dicRelateKey1">第一二层之间对应主外键</param>
        /// <param name="dicRelateKey2">第二三层之间对应主外键</param>
        /// <param name="eControlType">枚举类型</param>
        public MasterControl(object lstData1, object lstData2,
                             object lstData3, Dictionary<string, string> dicRelateKey1,
                             Dictionary<string, string> dicRelateKey2, ControlType eControlType)
        {
            var oDataSet = new DataSet();
            try
            {
                DataTable oTable1 = Fill(lstData1);
                oTable1.TableName = "T1";

                var oTable2 = Fill(lstData2);
                oTable2.TableName = "T2";

                if (lstData3 == null || dicRelateKey2 == null || dicRelateKey2.Keys.Count <= 0)
                {
                    oDataSet.Tables.AddRange(new[] { oTable1, oTable2 });
                    string first = dicRelateKey1.Keys.FirstOrDefault();
                    string first1 = dicRelateKey1.Values.FirstOrDefault();
                    if (first != null && first1 != null)
                    {
                        oDataSet.Relations.Add("1", oDataSet.Tables["T1"].Columns[first], oDataSet.Tables["T2"].Columns[first1]);
                    }
                }
                else
                {
                    var oTable3 = Fill(lstData3);
                    oTable3.TableName = "T3";

                    oDataSet.Tables.AddRange(new[] { oTable1, oTable2, oTable3 });
                    //这是对应关系的时候主键必须唯一
                    string first = dicRelateKey1.Keys.FirstOrDefault();
                    string first1 = dicRelateKey1.Values.FirstOrDefault();
                    if (first != null && first1 != null)
                    {
                        oDataSet.Relations.Add("1", oDataSet.Tables["T1"].Columns[first], oDataSet.Tables["T2"].Columns[first1]);
                    }
                    string first2 = dicRelateKey2.Keys.FirstOrDefault();
                    string first3 = dicRelateKey2.Values.FirstOrDefault();
                    if (first2 != null && first3 != null)
                    {
                        oDataSet.Relations.Add("2", oDataSet.Tables["T2"].Columns[first2], oDataSet.Tables["T3"].Columns[first3]);
                    }
                }
            }
            catch
            {
                oDataSet = new DataSet();
            }
            SetMasterControl(oDataSet, eControlType);
        }

        /// <summary>
        /// 控件初始化
        /// </summary>
        private void InitializeComponent()
        {
            this._components = new Container();
            RowHeaderMouseClick += MasterControl_RowHeaderMouseClick;
            RowPostPaint += MasterControl_RowPostPaint;
            Scroll += MasterControl_Scroll;
            SelectionChanged += MasterControl_SelectionChanged;
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MasterControl));
            this.RowHeaderIconList = new ImageList(this._components);
            ((ISupportInitialize)this).BeginInit();
            this.SuspendLayout();
            //
            //RowHeaderIconList
            //
            this.RowHeaderIconList.ImageStream = (ImageListStreamer)(resources.GetObject("RowHeaderIconList.ImageStream"));
            this.RowHeaderIconList.TransparentColor = Color.Transparent;
            this.RowHeaderIconList.Images.SetKeyName(0, "expand.png");
            this.RowHeaderIconList.Images.SetKeyName(1, "collapse.png");
            //
            //MasterControl
            //
            ((ISupportInitialize)this).EndInit();
            this.ResumeLayout(false);
        }

        #endregion 构造函数

        #region 数据绑定

        /// <summary>
        /// 设置表之间的主外键关联
        /// </summary>
        /// <param name="tableName">DataTable的表名称</param>
        /// <param name="primarykey"></param>
        /// <param name="foreignKey">外键</param>
        public void SetParentSource(string tableName, string primarykey, string foreignKey)
        {
            this.DataSource = new DataView(_cDataset.Tables[tableName]);
            CModule.SetGridRowHeader(this);
            _foreignKey = foreignKey;
            _primaryKey = primarykey;
            if (_cDataset.Tables[tableName].Columns[primarykey].GetType().ToString() == typeof(int).ToString()
                || _cDataset.Tables[tableName].Columns[primarykey].GetType().ToString() == typeof(double).ToString()
                || _cDataset.Tables[tableName].Columns[primarykey].GetType().ToString() == typeof(long).ToString()
                || _cDataset.Tables[tableName].Columns[primarykey].GetType().ToString() == typeof(decimal).ToString())
            {
                _filterFormat = foreignKey + "={0}";
            }
            else
            {
                _filterFormat = foreignKey + "=\'{0}\'";
            }
        }

        #endregion 数据绑定

        #region 事件

        //控件的行头点击事件
        private void MasterControl_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Rectangle rect = new Rectangle(Convert.ToInt32((double)(RowDefaultHeight - 16) / 2), Convert.ToInt32((double)(RowDefaultHeight - 16) / 2), 16, 16);
                if (rect.Contains(e.Location))
                {
                    //缩起
                    if (_rowCurrent.Contains(e.RowIndex))
                    {
                        _rowCurrent.Clear();
                        this.Rows[e.RowIndex].Height = RowDefaultHeight;
                        this.Rows[e.RowIndex].DividerHeight = RowDefaultDivider;

                        this.ClearSelection();
                        CollapseRow = true;
                        this.Rows[e.RowIndex].Selected = true;
                        if (_eControlType == ControlType.Middle)
                        {
                            var oParent = ((MasterControl)this.Parent.Parent);
                            oParent.Rows[oParent.ExpandRowIndex].Height = RowDefaultHeight * (this.Rows.Count + 4);
                            oParent.Rows[oParent.ExpandRowIndex].DividerHeight = RowDefaultHeight * (this.Rows.Count + 3);
                            if (oParent.Rows[oParent.ExpandRowIndex].Height > 500)
                            {
                                oParent.Rows[oParent.ExpandRowIndex].Height = 500;
                                oParent.Rows[oParent.ExpandRowIndex].Height = 480;
                            }
                        }
                    }
                    //展开
                    else
                    {
                        if (_rowCurrent.Count != 0)
                        {
                            var eRow = _rowCurrent[0];
                            _rowCurrent.Clear();
                            this.Rows[eRow].Height = RowDefaultHeight;
                            this.Rows[eRow].DividerHeight = RowDefaultDivider;
                            this.ClearSelection();
                            CollapseRow = true;
                            this.Rows[eRow].Selected = true;
                        }
                        _rowCurrent.Add(e.RowIndex);
                        this.ClearSelection();
                        CollapseRow = true;
                        this.Rows[e.RowIndex].Selected = true;
                        this.ExpandRowIndex = e.RowIndex;

                        this.Rows[e.RowIndex].Height = 66 + RowDefaultHeight * (((DataView)(ChildView.ChildGrid[0].DataSource)).Count + 1);
                        this.Rows[e.RowIndex].DividerHeight = 66 + RowDefaultHeight * (((DataView)(ChildView.ChildGrid[0].DataSource)).Count);
                        //设置一个最大高度
                        if (this.Rows[e.RowIndex].Height > 500)
                        {
                            this.Rows[e.RowIndex].Height = 500;
                            this.Rows[e.RowIndex].DividerHeight = 480;
                        }
                        if (_eControlType == ControlType.Middle)
                        {
                            if (this.Parent.Parent.GetType() != typeof(MasterControl))
                                return;
                            var oParent = ((MasterControl)this.Parent.Parent);
                            oParent.Rows[oParent.ExpandRowIndex].Height = this.Rows[e.RowIndex].Height + RowDefaultHeight * (this.Rows.Count + 3);
                            oParent.Rows[oParent.ExpandRowIndex].DividerHeight = this.Rows[e.RowIndex].DividerHeight + RowDefaultHeight * (this.Rows.Count + 3);
                            if (oParent.Rows[oParent.ExpandRowIndex].Height > 500)
                            {
                                oParent.Rows[oParent.ExpandRowIndex].Height = 500;
                                oParent.Rows[oParent.ExpandRowIndex].Height = 480;
                            }
                        }
                        //if (EControlType == controlType.outside)
                        //{
                        //    //SetControl(this);
                        //}
                        //this.Rows[e.RowIndex].Height = rowExpandedHeight;
                        //this.Rows[e.RowIndex].DividerHeight = rowExpandedDivider;
                    }
                    //this.ClearSelection();
                    //collapseRow = true;
                    //this.Rows[e.RowIndex].Selected = true;
                }
                else
                {
                    CollapseRow = false;
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        //控件的行重绘事件
        private void MasterControl_RowPostPaint(object objSender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                var sender = (DataGridView)objSender;
                //set childview control
                var rect = new Rectangle((int)(e.RowBounds.X + ((double)(RowDefaultHeight - 16) / 2)), (int)(e.RowBounds.Y + ((double)(RowDefaultHeight - 16) / 2)), 16, 16);
                if (CollapseRow)
                {
                    if (this._rowCurrent.Contains(e.RowIndex))
                    {
                        #region 更改点开后背景色

                        var rect1 = new Rectangle(e.RowBounds.X, e.RowBounds.Y + RowDefaultHeight, e.RowBounds.Width, e.RowBounds.Height - RowDefaultHeight);
                        using (Brush b = new SolidBrush(Color.FromArgb(164, 169, 143)))
                        {
                            e.Graphics.FillRectangle(b, rect1);
                        }
                        using (Pen p = new Pen(Color.GhostWhite))
                        {
                            var iHalfWidth = (e.RowBounds.Left + sender.RowHeadersWidth) / 2;
                            var oPointHLineStart = new Point(rect1.X + iHalfWidth, rect1.Y);
                            var oPointHLineEnd = new Point(rect1.X + iHalfWidth, rect1.Y + rect1.Height / 2);
                            e.Graphics.DrawLine(p, oPointHLineStart, oPointHLineEnd);
                            //折叠线
                            e.Graphics.DrawLine(p, oPointHLineEnd, new Point(oPointHLineEnd.X + iHalfWidth, oPointHLineEnd.Y));
                        }

                        #endregion 更改点开后背景色

                        sender.Rows[e.RowIndex].DividerHeight = sender.Rows[e.RowIndex].Height - RowDefaultHeight;
                        e.Graphics.DrawImage(RowHeaderIconList.Images[(int)RowHeaderIcons.Collapse], rect);
                        ChildView.Location = new Point(e.RowBounds.Left + sender.RowHeadersWidth, e.RowBounds.Top + RowDefaultHeight + 5);
                        ChildView.Width = e.RowBounds.Right - sender.RowHeadersWidth;
                        ChildView.Height = Convert.ToInt32(sender.Rows[e.RowIndex].DividerHeight - 10);
                        ChildView.Visible = true;
                    }
                    else
                    {
                        ChildView.Visible = false;
                        e.Graphics.DrawImage(RowHeaderIconList.Images[(int)RowHeaderIcons.Expand], rect);
                    }
                    CollapseRow = false;
                }
                else
                {
                    if (this._rowCurrent.Contains(e.RowIndex))
                    {
                        #region 更改点开后背景色

                        var rect1 = new Rectangle(e.RowBounds.X, e.RowBounds.Y + RowDefaultHeight, e.RowBounds.Width, e.RowBounds.Height - RowDefaultHeight);
                        using (Brush b = new SolidBrush(Color.FromArgb(164, 169, 143)))
                        {
                            e.Graphics.FillRectangle(b, rect1);
                        }
                        using (Pen p = new Pen(Color.GhostWhite))
                        {
                            var iHalfWidth = (e.RowBounds.Left + sender.RowHeadersWidth) / 2;
                            var oPointHLineStart = new Point(rect1.X + iHalfWidth, rect1.Y);
                            var oPointHLineEnd = new Point(rect1.X + iHalfWidth, rect1.Y + rect1.Height / 2);
                            e.Graphics.DrawLine(p, oPointHLineStart, oPointHLineEnd);
                            //折叠线
                            e.Graphics.DrawLine(p, oPointHLineEnd, new Point(oPointHLineEnd.X + iHalfWidth, oPointHLineEnd.Y));
                        }

                        #endregion 更改点开后背景色

                        sender.Rows[e.RowIndex].DividerHeight = sender.Rows[e.RowIndex].Height - RowDefaultHeight;
                        e.Graphics.DrawImage(RowHeaderIconList.Images[(int)RowHeaderIcons.Collapse], rect);
                        ChildView.Location = new Point(e.RowBounds.Left + sender.RowHeadersWidth, e.RowBounds.Top + RowDefaultHeight + 5);
                        ChildView.Width = e.RowBounds.Right - sender.RowHeadersWidth;
                        ChildView.Height = Convert.ToInt32(sender.Rows[e.RowIndex].DividerHeight - 10);
                        ChildView.Visible = true;
                    }
                    else
                    {
                        ChildView.Visible = false;
                        e.Graphics.DrawImage(RowHeaderIconList.Images[(int)RowHeaderIcons.Expand], rect);
                    }
                }
                CModule.rowPostPaint_HeaderCount(sender, e);
            }
            catch
            {
                // ignored
            }
        }

        //控件的滚动条滚动事件
        private void MasterControl_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (_rowCurrent.Count != 0)
                {
                    CollapseRow = true;
                    this.ClearSelection();
                    this.Rows[_rowCurrent[0]].Selected = true;
                }
            }
            catch
            {
                // ignored
            }
        }

        //控件的单元格选择事件
        private void MasterControl_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.RowCount != 0)
                {
                    DataGridViewRow dataGridViewRow = this.CurrentRow;
                    if (dataGridViewRow != null && _rowCurrent.Contains(dataGridViewRow.Index))
                    {
                        foreach (DataGridView cGrid in ChildView.ChildGrid)
                        {
                            DataGridViewRow gridViewRow = this.CurrentRow;
                            if (gridViewRow != null)
                                ((DataView)cGrid.DataSource).RowFilter = string.Format(_filterFormat, this[_primaryKey, gridViewRow.Index].Value);
                        }
                    }
                }
            }
            catch
            {
                // ignored
            }
        }

        #endregion 事件

        #region Private

        public void SetControl(MasterControl oGrid)
        {
            oGrid.ChildView.RemoveControl();
            //oGrid.childView.Controls.RemoveByKey("ChildrenMaster");
            //
            //var oRelates = _cDataset.Relations[1];
            //oGrid.childView.Add(oRelates.ParentTable.TableName, oRelates.ChildColumns[0].ColumnName);

            //foreach (var oGridControl in oGrid.Controls)
            //{
            //    if (oGridControl.GetType() != typeof(detailControl))
            //    {
            //        continue;
            //    }
            //    var DetailControl =(detailControl)oGridControl;
            //    foreach (var odetailControl in DetailControl.Controls)
            //    {
            //        if (odetailControl.GetType() != typeof(MasterControl))
            //        {
            //            continue;
            //        }
            //        var OMasterControl = (MasterControl)odetailControl;
            //        foreach (var oMasterControl in OMasterControl.Controls)
            //        {
            //            if (oMasterControl.GetType() == typeof(detailControl))
            //            {
            //                ((detailControl)oMasterControl).Visible = false;
            //                return;
            //            }
            //        }
            //    }
            //}
        }

        //将List集合转换成DataTable
        private DataTable Fill(object obj)
        {
            if (!(obj is IList))
            {
                return null;
            }
            var objlist = (IList)obj;
            if (objlist.Count <= 0)
            {
                return null;
            }
            var tType = objlist[0];
            DataTable dt = new DataTable(tType.GetType().Name);
            var myPropertyInfo = tType.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var t in objlist)
            {
                if (t == null)
                {
                    continue;
                }
                var row = dt.NewRow();
                for (int i = 0, j = myPropertyInfo.Length; i < j; i++)
                {
                    PropertyInfo pi = myPropertyInfo[i];
                    string name = pi.Name;
                    if (dt.Columns[name] == null)
                    {
                        var column = new DataColumn(name, pi.PropertyType);
                        dt.Columns.Add(column);
                    }
                    row[name] = pi.GetValue(t, null);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        //设置构造函数的参数
        private void SetMasterControl(DataSet cDataset, ControlType eControlType)
        {
            //1.控件初始化赋值
            this.Controls.Add(ChildView);
            InitializeComponent();
            _cDataset = cDataset;
            ChildView.CDataset = cDataset;
            CModule.ApplyGridTheme(this);
            Dock = DockStyle.Fill;
            _eControlType = eControlType;
            this.AllowUserToAddRows = false;

            //2.通过读取DataSet里面的Relations得到表的关联关系
            if (cDataset.Relations.Count <= 0)
            {
                return;
            }
            DataRelation oRelates;
            if (eControlType == ControlType.OutSide)
            {
                oRelates = cDataset.Relations[1];
                ChildView.Add(oRelates.ParentTable.TableName, oRelates.ParentColumns[0].ColumnName, oRelates.ChildColumns[0].ColumnName);
            }
            else if (eControlType == ControlType.Middle)
            {
                oRelates = cDataset.Relations[cDataset.Relations.Count - 1];
                ChildView.Add2(oRelates.ChildTable.TableName);
            }

            //3.设置主外键对应关系
            oRelates = cDataset.Relations[0];
            //主表里面的值，副表里面的过滤字段
            SetParentSource(oRelates.ParentTable.TableName, oRelates.ParentColumns[0].ColumnName, oRelates.ChildColumns[0].ColumnName);
        }

        #endregion Private
    }
}