using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Assist.EmailSend
{
    /// <summary>
    /// 改变列头的CheckBox的状态
    /// </summary>
    /// <param name="state"></param>
    public delegate void ChangeCheckBoxStatusHandler(bool state);

    public delegate void CheckBoxClickedHandler(bool state);

    public class DataGridViewCheckBoxHeaderCellEventArgs : EventArgs
    {
        private bool _bChecked;

        public DataGridViewCheckBoxHeaderCellEventArgs(bool bChecked)
        {
            _bChecked = bChecked;
        }

        public bool Checked
        {
            get { return _bChecked; }
        }
    }

    internal class DatagridViewCheckBoxHeaderCell : DataGridViewColumnHeaderCell
    {
        private System.Windows.Forms.VisualStyles.CheckBoxState _cbState =
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;

        private Point _cellLocation;
        private Point _checkBoxLocation;
        private Size _checkBoxSize;
        private bool _checked;

        public event ChangeCheckBoxStatusHandler OnChangeCheckBoxStatusHandler;

        public event CheckBoxClickedHandler OnCheckBoxClicked;

        /// <summary>
        /// 改变列头CheckBox的状态的事件
        /// </summary>
        /// <param name="newStatus"></param>
        public void OnChangeCheckBoxStatus(bool newStatus)
        {
            if (OnCheckBoxClicked != null)
            {
                _checked = newStatus;
                if (OnChangeCheckBoxStatusHandler != null)
                {
                    OnChangeCheckBoxStatusHandler(newStatus);
                }
                if (DataGridView != null)
                {
                    DataGridView.InvalidateCell(this);
                }
            }
        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            Point p = new Point(e.X + _cellLocation.X, e.Y + _cellLocation.Y);
            if (p.X >= _checkBoxLocation.X && p.X <=
                _checkBoxLocation.X + _checkBoxSize.Width
            && p.Y >= _checkBoxLocation.Y && p.Y <=
                _checkBoxLocation.Y + _checkBoxSize.Height)
            {
                _checked = !_checked;
                if (OnCheckBoxClicked != null)
                {
                    OnCheckBoxClicked(_checked);
                    DataGridView.InvalidateCell(this);
                }
            }
            base.OnMouseClick(e);
        }

        protected override void Paint(Graphics graphics,
            Rectangle clipBounds,
            Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates dataGridViewElementState,
            object value,
            object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                dataGridViewElementState, value,
                formattedValue, errorText, cellStyle,
                advancedBorderStyle, paintParts);
            Point p = new Point();
            Size s = CheckBoxRenderer.GetGlyphSize(graphics,
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            p.X = cellBounds.Location.X +
                (cellBounds.Width / 2) - (s.Width / 2);
            p.Y = cellBounds.Location.Y +
                (cellBounds.Height / 2) - (s.Height / 2);
            _cellLocation = cellBounds.Location;
            _checkBoxLocation = p;
            _checkBoxSize = s;
            if (_checked)
                _cbState = System.Windows.Forms.VisualStyles.
                    CheckBoxState.CheckedNormal;
            else
                _cbState = System.Windows.Forms.VisualStyles.
                    CheckBoxState.UncheckedNormal;
            CheckBoxRenderer.DrawCheckBox
            (graphics, _checkBoxLocation, _cbState);
        }
    }
}