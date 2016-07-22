using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
    public class CheckedComboBox : ComboBox
    {
        // A form-derived object representing the drop-down list of the checked combo box.
        private readonly Dropdown _dropdown;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private readonly System.ComponentModel.IContainer components = null;

        public CheckedComboBox()
        {
            // We want to do the drawing of the dropdown.
            this.DrawMode = DrawMode.OwnerDrawVariable;
            // Default value separator.
            this.ValueSeparator = ", ";
            // This prevents the actual ComboBox dropdown to show, although it's not strickly-speaking necessary.
            // But including this remove a slight flickering just before our dropdown appears (which is caused by
            // the empty-dropdown list of the ComboBox which is displayed for fractions of a second).
            this.DropDownHeight = 1;
            // This is the default setting - text portion is editable and user must click the arrow button
            // to see the list portion. Although we don't want to allow the user to edit the text portion
            // the DropDownList style is not being used because for some reason it wouldn't allow the text
            // portion to be programmatically set. Hence we set it as editable but disable keyboard input (see below).
            this.DropDownStyle = ComboBoxStyle.DropDown;
            this._dropdown = new Dropdown(this);
            // CheckOnClick style for the dropdown (NOTE: must be set after dropdown is created).
            this.CheckOnClick = true;
        }

        // Event handler for when an item check state changes.
        public event ItemCheckEventHandler ItemCheck;

        public CheckedListBox.CheckedIndexCollection CheckedIndices
        {
            get { return _dropdown.List.CheckedIndices; }
        }

        public string CheckedItemNames
        {
            get
            {
                string strCheckedItemNames = CheckedItems.Cast<CCBoxItem>().Aggregate(string.Empty, (current, item) => current + (item.Name + ","));
                return strCheckedItemNames.TrimEnd(',');
            }
        }

        public CheckedListBox.CheckedItemCollection CheckedItems
        {
            get { return _dropdown.List.CheckedItems; }
        }

        public string CheckedItemValues
        {
            get
            {
                string strCheckedItemValues = CheckedItems.Cast<CCBoxItem>().Aggregate(string.Empty, (current, item) => current + (item.Value + ","));
                return strCheckedItemValues.TrimEnd(',');
            }
        }

        public bool CheckOnClick
        {
            get { return _dropdown.List.CheckOnClick; }
            set { _dropdown.List.CheckOnClick = value; }
        }

        public new string DisplayMember
        {
            get { return _dropdown.List.DisplayMember; }
            set { _dropdown.List.DisplayMember = value; }
        }

        public new CheckedListBox.ObjectCollection Items
        {
            get { return _dropdown.List.Items; }
        }

        public bool ValueChanged
        {
            get { return _dropdown.ValueChanged; }
        }

        public string ValueSeparator { get; set; }

        public void CheckeAll()
        {
            for (int i = 0; i < _dropdown.List.Items.Count; i++)
            {
                SetItemChecked(i, true);
            }
        }

        public void ClearChecked()
        {
            for (int i = 0; i < _dropdown.List.Items.Count; i++)
            {
                SetItemChecked(i, false);
            }
        }

        public bool GetItemChecked(int index)
        {
            if (index < 0 || index > Items.Count)
            {
                throw new ArgumentOutOfRangeException("index", "value out of range");
            }
            else
            {
                return _dropdown.List.GetItemChecked(index);
            }
        }

        public CheckState GetItemCheckState(int index)
        {
            if (index < 0 || index > Items.Count)
            {
                throw new ArgumentOutOfRangeException("index", "value out of range");
            }
            return _dropdown.List.GetItemCheckState(index);
        }

        // The valueSeparator character(s) between the ticked elements as they appear in the
        // text portion of the CheckedComboBox.
        public void SetItemCheckByValues(string strValues)
        {
            ClearChecked();
            string[] strArray = strValues.Split(',');
            for (int i = 0; i < Items.Count; i++)
            {
                CCBoxItem ccBoxItem = Items[i] as CCBoxItem;
                if (ccBoxItem != null && strArray.Contains(ccBoxItem.Value.ToString()))
                {
                    SetItemChecked(i, true);
                }
            }
        }

        public void SetItemChecked(int index, bool isChecked)
        {
            if (index < 0 || index > Items.Count)
            {
                throw new ArgumentOutOfRangeException("index", "value out of range");
            }
            _dropdown.List.SetItemChecked(index, isChecked);
            // Need to update the Text.
            Text = _dropdown.GetCheckedItemsStringValue();
        }

        public void SetItemCheckState(int index, CheckState state)
        {
            if (index < 0 || index > Items.Count)
            {
                throw new ArgumentOutOfRangeException("index", "value out of range");
            }
            else
            {
                _dropdown.List.SetItemCheckState(index, state);
                // Need to update the Text.
                Text = _dropdown.GetCheckedItemsStringValue();
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // ******************************** Construction ********************************
        // ******************************** Operations ********************************
        protected override void OnDropDown(EventArgs e)
        {
            base.OnDropDown(e);
            DoDropDown();
        }

        protected override void OnDropDownClosed(EventArgs e)
        {
            // Call the handlers for this event only if the call comes from our code - NOT the framework's!
            // NOTE: that is because the events were being fired in a wrong order, due to the actual dropdown list
            //       of the ComboBox which lies underneath our dropdown and gets involved every time.
            if (e is Dropdown.CCBoxEventArgs)
            {
                base.OnDropDownClosed(e);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                // Signal that the dropdown is "down". This is required so that the behaviour of the dropdown is the same
                // when it is a result of user pressing the Down_Arrow (which we handle and the framework wouldn't know that
                // the list portion is down unless we tell it so).
                // NOTE: all that so the DropDownClosed event fires correctly!
                OnDropDown(null);
            }
            // Make sure that certain keys or combinations are not blocked.
            e.Handled = !e.Alt && e.KeyCode != Keys.Tab &&
                !((e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Right) || (e.KeyCode == Keys.Home) || (e.KeyCode == Keys.End));

            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.Handled = true;
            base.OnKeyPress(e);
        }

        private void DoDropDown()
        {
            if (!_dropdown.Visible)
            {
                Rectangle rect = RectangleToScreen(this.ClientRectangle);
                _dropdown.Location = new Point(rect.X, rect.Y + this.Size.Height);
                int count = _dropdown.List.Items.Count;
                if (count > this.MaxDropDownItems)
                {
                    count = this.MaxDropDownItems;
                }
                else if (count == 0)
                {
                    count = 1;
                }
                _dropdown.Size = new Size(this.Size.Width, (_dropdown.List.ItemHeight) * count + 2);
                _dropdown.Show(this);
            }
        }

        /// <summary>
        /// Internal class to represent the dropdown list of the CheckedComboBox
        /// </summary>
        internal class Dropdown : Form
        {
            private readonly CheckedComboBox _ccbParent;

            private CustomCheckedListBox _cclb;

            // Array holding the checked states of the items. This will be used to reverse any changes if user cancels selection.
            private bool[] _checkedStateArr;

            // Whether the dropdown is closed.
            private bool _dropdownClosed = true;

            // Keeps track of whether checked item(s) changed, hence the value of the CheckedComboBox as a whole changed.
            // This is simply done via maintaining the old string-representation of the value(s) and the new one and comparing them!
            private string _oldStrValue = "";

            public Dropdown(CheckedComboBox ccbParent)
            {
                _ccbParent = ccbParent;
                InitializeComponent();
                ShowInTaskbar = false;
                // Add a handler to notify our parent of ItemCheck events.
                _cclb.ItemCheck += cclb_ItemCheck;
            }

            public CustomCheckedListBox List
            {
                get { return _cclb; }
                set { _cclb = value; }
            }

            public bool ValueChanged
            {
                get
                {
                    string newStrValue = _ccbParent.Text;
                    if ((_oldStrValue.Length > 0) && (newStrValue.Length > 0))
                    {
                        return (String.Compare(_oldStrValue, newStrValue, StringComparison.Ordinal) != 0);
                    }
                    return (_oldStrValue.Length != newStrValue.Length);
                }
            }

            /// <summary>
            /// Closes the dropdown portion and enacts any changes according to the specified boolean parameter.
            /// NOTE: even though the caller might ask for changes to be enacted, this doesn't necessarily mean
            ///       that any changes have occurred as such. Caller should check the ValueChanged property of the
            ///       CheckedComboBox (after the dropdown has closed) to determine any actual value changes.
            /// </summary>
            /// <param name="enactChanges"></param>
            public void CloseDropdown(bool enactChanges)
            {
                if (_dropdownClosed)
                {
                    return;
                }
                Debug.WriteLine("CloseDropdown");
                // Perform the actual selection and display of checked items.
                if (enactChanges)
                {
                    _ccbParent.SelectedIndex = -1;
                    // Set the text portion equal to the string comprising all checked items (if any, otherwise empty!).
                    _ccbParent.Text = GetCheckedItemsStringValue();
                }
                else
                {
                    // Caller cancelled selection - need to restore the checked items to their original state.
                    for (int i = 0; i < _cclb.Items.Count; i++)
                    {
                        _cclb.SetItemChecked(i, _checkedStateArr[i]);
                    }
                }
                // From now on the dropdown is considered closed. We set the flag here to prevent OnDeactivate() calling
                // this method once again after hiding this window.
                _dropdownClosed = true;
                // Set the focus to our parent CheckedComboBox and hide the dropdown check list.
                _ccbParent.Focus();
                this.Hide();
                // Notify CheckedComboBox that its dropdown is closed. (NOTE: it does not matter which parameters we pass to
                // OnDropDownClosed() as long as the argument is CCBoxEventArgs so that the method knows the notification has
                // come from our code and not from the framework).
                _ccbParent.OnDropDownClosed(new CCBoxEventArgs(null, false));
            }

            public string GetCheckedItemsStringValue()
            {
                StringBuilder sb = new StringBuilder("");
                foreach (object item in _cclb.CheckedItems)
                {
                    sb.Append(_cclb.GetItemText(item)).Append(_ccbParent.ValueSeparator);
                }
                if (sb.Length > 0)
                {
                    sb.Remove(sb.Length - _ccbParent.ValueSeparator.Length, _ccbParent.ValueSeparator.Length);
                }
                return sb.ToString();
            }

            protected override void OnActivated(EventArgs e)
            {
                Debug.WriteLine("OnActivated");
                base.OnActivated(e);
                _dropdownClosed = false;
                // Assign the old string value to compare with the new value for any changes.
                _oldStrValue = _ccbParent.Text;
                // Make a copy of the checked state of each item, in cace caller cancels selection.
                _checkedStateArr = new bool[_cclb.Items.Count];
                for (int i = 0; i < _cclb.Items.Count; i++)
                {
                    _checkedStateArr[i] = _cclb.GetItemChecked(i);
                }
            }

            protected override void OnDeactivate(EventArgs e)
            {
                Debug.WriteLine("OnDeactivate");
                base.OnDeactivate(e);
                CCBoxEventArgs ce = e as CCBoxEventArgs;
                CloseDropdown(ce == null || ce.AssignValues);
            }

            private void cclb_ItemCheck(object sender, ItemCheckEventArgs e)
            {
                if (_ccbParent.ItemCheck != null)
                {
                    _ccbParent.ItemCheck(sender, e);
                }
            }

            // Create a CustomCheckedListBox which fills up the entire form area.
            private void InitializeComponent()
            {
                _cclb = new CustomCheckedListBox();
                SuspendLayout();
                //
                // cclb
                //
                _cclb.BorderStyle = BorderStyle.None;
                _cclb.Dock = DockStyle.Fill;
                _cclb.FormattingEnabled = true;
                _cclb.Location = new Point(0, 0);
                _cclb.Name = "_cclb";
                _cclb.Size = new Size(47, 15);
                _cclb.TabIndex = 0;
                //
                // Dropdown
                //
                this.AutoScaleDimensions = new SizeF(6F, 13F);
                this.AutoScaleMode = AutoScaleMode.Font;
                this.BackColor = SystemColors.Menu;
                this.ClientSize = new Size(47, 16);
                this.ControlBox = false;
                this.Controls.Add(this._cclb);
                this.ForeColor = SystemColors.ControlText;
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                this.MinimizeBox = false;
                this.Name = "_ccbParent";
                this.StartPosition = FormStartPosition.Manual;
                this.ResumeLayout(false);
            }

            /// <summary>
            /// Custom EventArgs encapsulating value as to whether the combo box value(s) should be assignd to or not.
            /// </summary>
            internal class CCBoxEventArgs : EventArgs
            {
                public CCBoxEventArgs(EventArgs e, bool assignValues)
                {
                    EventArgs = e;
                    AssignValues = assignValues;
                }

                public bool AssignValues { get; set; }

                public EventArgs EventArgs { get; set; }
            }

            /// <summary>
            /// A custom CheckedListBox being shown within the dropdown form representing the dropdown list of the CheckedComboBox.
            /// </summary>
            internal class CustomCheckedListBox : CheckedListBox
            {
                private int _curSelIndex = -1;

                public CustomCheckedListBox()
                {
                    SelectionMode = SelectionMode.One;
                    HorizontalScrollbar = true;
                }

                public override sealed SelectionMode SelectionMode
                {
                    get { return base.SelectionMode; }
                    set { base.SelectionMode = value; }
                }

                /// <summary>
                /// Intercepts the keyboard input, [Enter] confirms a selection and [Esc] cancels it.
                /// </summary>
                /// <param name="e">The Key event arguments</param>
                protected override void OnKeyDown(KeyEventArgs e)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        // Enact selection.
                        ((Dropdown)Parent).OnDeactivate(new CCBoxEventArgs(null, true));
                        e.Handled = true;
                    }
                    else if (e.KeyCode == Keys.Escape)
                    {
                        // Cancel selection.
                        ((Dropdown)Parent).OnDeactivate(new CCBoxEventArgs(null, false));
                        e.Handled = true;
                    }
                    else if (e.KeyCode == Keys.Delete)
                    {
                        // Delete unckecks all, [Shift + Delete] checks all.
                        for (int i = 0; i < Items.Count; i++)
                        {
                            SetItemChecked(i, e.Shift);
                        }
                        e.Handled = true;
                    }
                    // If no Enter or Esc keys presses, let the base class handle it.
                    base.OnKeyDown(e);
                }

                protected override void OnMouseMove(MouseEventArgs e)
                {
                    base.OnMouseMove(e);
                    int index = IndexFromPoint(e.Location);
                    Debug.WriteLine("Mouse over item: " + (index >= 0 ? GetItemText(Items[index]) : "None"));
                    if ((index >= 0) && (index != _curSelIndex))
                    {
                        _curSelIndex = index;
                        SetSelected(index, true);
                    }
                }
            }
        }
    } // end public class CheckedComboBox
}