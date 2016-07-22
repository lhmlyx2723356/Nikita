using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nikita.Core
{
        /// <summary>GridView添加CheckBox列（全选类）
        /// 
        /// </summary>
    public class GridChedkMarksSelectionHelper
    {
   
            protected GridView _GridView;
            protected ArrayList _Selection;
            private GridColumn _CheckColumn; //自动创建的Column 
            private RepositoryItemCheckEdit _CheckEdit;

            public GridChedkMarksSelectionHelper()
            {
                _Selection = new ArrayList();
            }

            public  GridChedkMarksSelectionHelper(GridView view)
                : this()
            {
                this.View = view;
                for (int i = 0; i < view.Columns.Count - 1; i++)
                {
                    view.Columns[i].VisibleIndex += 1;
                }
            }

            protected virtual void Attach(GridView view)
            {
                if (view == null)
                {
                    return;
                }
                _Selection.Clear();
                this._GridView = view;
                _CheckEdit = (RepositoryItemCheckEdit)view.GridControl.RepositoryItems.Add("CheckEdit");
                _CheckEdit.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
                _CheckEdit.EditValueChanged += Edit_EditValueChanged;

                _CheckColumn = view.Columns.Add();
                _CheckColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                _CheckColumn.VisibleIndex = 0;// int.MaxValue;
                _CheckColumn.FieldName = "CheckMarkSelection";
                _CheckColumn.Caption = "Mark";
                _CheckColumn.OptionsColumn.ShowCaption = false;
                _CheckColumn.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
                _CheckColumn.ColumnEdit = _CheckEdit;


                view.Click += View_Click;
                view.CustomDrawColumnHeader += View_CustomDrawColumnHeader;
                view.CustomDrawGroupRow += View_CustomDrawGroupRow;
                view.CustomUnboundColumnData += view_CustomUnboundColumnData;
                //         view.RowStyle += view_RowStyle; //设置选中颜色
            }

            protected virtual void Detach()
            {
                if (View == null)
                {
                    return;
                }
                if ((_CheckColumn != null))
                {
                    _CheckColumn.Dispose();
                }
                if ((_CheckEdit != null))
                {
                    View.GridControl.RepositoryItems.Remove(_CheckEdit);
                    _CheckEdit.Dispose();
                }
                _GridView.Click -= View_Click;
                _GridView.CustomDrawColumnHeader -= View_CustomDrawColumnHeader;
                _GridView.CustomDrawGroupRow -= View_CustomDrawGroupRow;
                _GridView.CustomUnboundColumnData -= (view_CustomUnboundColumnData);
                //          _GridView.RowStyle -= view_RowStyle;

                View = null;
            }

            protected void DrawCheckBox(Graphics g, Rectangle r, bool Checked, bool Grayed)
            {
                DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info = default(DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo);
                DevExpress.XtraEditors.Drawing.CheckEditPainter painter = default(DevExpress.XtraEditors.Drawing.CheckEditPainter);
                DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args = default(DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs);
                info = (DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo)_CheckEdit.CreateViewInfo();
                painter = (DevExpress.XtraEditors.Drawing.CheckEditPainter)_CheckEdit.CreatePainter();
                if (Grayed)
                {
                    info.EditValue = _CheckEdit.ValueGrayed;
                }
                else
                {
                    info.EditValue = Checked;
                }
                info.Bounds = r;
                info.CalcViewInfo(g);
                args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
                painter.Draw(args);
                args.Cache.Dispose();
            }

            private void View_Click(object sender, EventArgs e)
            {
                GridHitInfo info = default(GridHitInfo);
                Point pt = View.GridControl.PointToClient(Control.MousePosition);
                info = View.CalcHitInfo(pt);
                if (info.InColumn & object.ReferenceEquals(info.Column, _CheckColumn))
                {
                    if (SelectedCount == View.DataRowCount)
                    {
                        ClearSelection();
                    }
                    else
                    {
                        SelectAll();
                    }
                }
                if (info.InRow & View.IsGroupRow(info.RowHandle) & info.HitTest != GridHitTest.RowGroupButton)
                {
                    bool selected = IsGroupRowSelected(info.RowHandle);
                    SelectGroup(info.RowHandle, !selected);
                }
            }

            private void View_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
            {
                if (object.ReferenceEquals(e.Column, _CheckColumn))
                {
                    e.Info.InnerElements.Clear();
                    e.Painter.DrawObject(e.Info);
                    bool gray = SelectedCount > 0 & SelectedCount < View.DataRowCount;
                    DrawCheckBox(e.Graphics, e.Bounds, SelectedCount == View.DataRowCount, gray);
                    e.Handled = true;
                }
            }

            private void View_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo info = default(DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo);
                info = (DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo)e.Info;

                info.GroupText = " " + info.GroupText.TrimStart();
                e.Info.Paint.FillRectangle(e.Graphics, e.Appearance.GetBackBrush(e.Cache), e.Bounds);
                e.Painter.DrawObject(e.Info);

                Rectangle r = info.ButtonBounds;
                r.Offset(r.Width * 2, 0);

                int g = GroupRowSelectionStatus(e.RowHandle);
                DrawCheckBox(e.Graphics, r, g > 0, g < 0);
                e.Handled = true;
            }

            private void view_RowStyle(object sender, RowStyleEventArgs e)
            {
                if (IsRowSelected(e.RowHandle))
                {
                    e.Appearance.BackColor = SystemColors.Highlight;
                    e.Appearance.ForeColor = SystemColors.HighlightText;
                }
            }

            public GridView View
            {
                get { return _GridView; }
                set
                {
                    if ((!object.ReferenceEquals(_GridView, value)))
                    {
                        Detach();
                        Attach(value);
                    }
                }
            }

            public GridColumn CheckMarkColumn
            {
                get { return _CheckColumn; }
            }

            public int SelectedCount
            {
                get { return _Selection.Count; }
            }

            public object GetSelectedRow(int index)
            {
                return this._Selection[index];
            }

            public int GetSelectedIndex(object row)
            {
                return _Selection.IndexOf(row);
            }

            public void ClearSelection()
            {
                _Selection.Clear();
                Invalidate();
            }

            private void Invalidate()
            {
                View.BeginUpdate();
                View.EndUpdate();
            }

            public void SelectAll()
            {
                _Selection.Clear();
                if (View.DataSource is ICollection)
                {
                    // fast 
                    _Selection.AddRange((ICollection)View.DataSource);
                }
                else
                {
                    int i = 0;
                    for (i = 0; i <= View.DataRowCount - 1; i++)
                    {
                        // slow 
                        _Selection.Add(View.GetRow(i));
                    }
                }
                Invalidate();
            }

            public void SelectGroup(int rowHandle, bool @select)
            {
                if (IsGroupRowSelected(rowHandle) & @select)
                {
                    return;
                }
                int i = 0;
                for (i = 0; i <= (View.GetChildRowCount(rowHandle)) - 1; i++)
                {
                    int childRowHandle = View.GetChildRowHandle(rowHandle, i);
                    if (View.IsGroupRow(childRowHandle))
                    {
                        SelectGroup(childRowHandle, @select);
                    }
                    else
                    {
                        SelectRow(childRowHandle, @select, false);
                    }
                }
                Invalidate();
            }

            public void SelectRow(int rowHandle, bool @select)
            {
                SelectRow(rowHandle, @select, true);
            }
         

            private void SelectRow(int rowHandle, bool @select, bool invalidate)
            {
                if (IsRowSelected(rowHandle) == @select)
                {
                    return;
                }
                object row = View.GetRow(rowHandle);
                if (@select)
                {
                    _Selection.Add(row);
                }
                else
                {
                    _Selection.Remove(row);
                }
                if (invalidate)
                {
                    this.Invalidate();
                }
            }

            public int GroupRowSelectionStatus(int rowHandle)
            {
                int count = 0;
                int i = 0;
                for (i = 0; i <= (View.GetChildRowCount(rowHandle)) - 1; i++)
                {
                    int row = View.GetChildRowHandle(rowHandle, i);
                    if (View.IsGroupRow(row))
                    {
                        int g = GroupRowSelectionStatus(row);
                        if (g < 0)
                        {
                            return g;
                        }
                        if (g > 0)
                        {
                            count += 1;
                        }
                    }
                    else
                    {
                        if (IsRowSelected(row))
                        {
                            count += 1;
                        }
                    }
                }
                if (count == 0)
                {
                    return 0;
                }
                if (count == View.GetChildRowCount(rowHandle))
                {
                    return 1;
                }
                return -1;
            }

            public bool IsGroupRowSelected(int rowHandle)
            {
                int i = 0;
                for (i = 0; i <= (View.GetChildRowCount(rowHandle)) - 1; i++)
                {
                    int row = View.GetChildRowHandle(rowHandle, i);
                    if (View.IsGroupRow(row))
                    {
                        if (!IsGroupRowSelected(row))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!IsRowSelected(row))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            public bool IsRowSelected(int rowHandle)
            {
                if (View.IsGroupRow(rowHandle))
                {
                    return IsGroupRowSelected(rowHandle);
                }

                object row = View.GetRow(rowHandle);
                return GetSelectedIndex(row) != -1;
            }

            private void view_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
            {
                if (object.ReferenceEquals(e.Column, CheckMarkColumn))
                {
                    if (e.IsGetData)
                    {
                        e.Value = IsRowSelected(e.ListSourceRowIndex);
                    }
                    else
                    {
                        SelectRow(e.ListSourceRowIndex, (bool)e.Value);
                    }
                }
            }

            private void Edit_EditValueChanged(object sender, EventArgs e)
            {
                View.PostEditor();
            }

            public string GetKeyIds(string strField)
            {
                string menu_ids = string.Empty;
                for (int i = 0; i <= _Selection.Count - 1; i++)
                {
                    DataRowView dr = (DataRowView)GetSelectedRow(i);
                    menu_ids += menu_ids == string.Empty ? dr[strField].ToString() : "," + dr[strField].ToString();
                }
                return menu_ids;
            }


            //public void SetState(int Status, string KeyId, string State)
            //{
            //    for (int i = 0; i <= _Selection.Count - 1; i++)
            //    {
            //        DataRowView dv = (DataRowView)_Selection[i];
            //        DataRow dr = dv.Row;
            //        for (int j = 0; j <= View.DataRowCount - 1; j++)
            //        {
            //            if (dr[KeyId].ToString().Trim() == View.GetDataRow(j)[KeyId].ToString().Trim())
            //            {
            //                View.SetRowCellValue(j, View.Columns[State], Status);
            //                continue;
            //            }
            //        }
            //    }
            //}

            public void SetStatus(string Status, int State)
            {
                for (int i = 0; i <= View.DataRowCount - 1; i++)
                {
                    if (IsRowSelected(i))
                    {
                        View.SetRowCellValue(i, View.Columns[Status], State);
                    }
                }
                ClearSelection();
            }


            public string StrGridKeyField
            {
                get;
                set;
            }

            //选中
            public void SelectRow(DataRow[] drs, bool blClear)
            {
                if (StrGridKeyField == string.Empty)
                    return;

                if (drs.Length == 0)
                    return;

                if (blClear)
                {
                    _Selection.Clear();
                }

                List<string> lis = new List<string>();
                foreach (DataRow drv in drs)
                {
                    lis.Add(drv[StrGridKeyField].ToString());
                }

                for (int i = 0; i <= View.DataRowCount - 1; i++)
                {
                    DataRowView drRow = View.GetRow(i) as DataRowView;
                    if (!lis.Contains(drRow[StrGridKeyField].ToString()))
                        continue;

                    if (IsRowSelected(i))
                        continue;

                    _Selection.Add(drRow);
                }
                Invalidate();
            }
 
    }
}
