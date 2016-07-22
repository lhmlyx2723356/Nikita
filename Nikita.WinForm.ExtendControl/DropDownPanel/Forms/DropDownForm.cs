using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
    /// <summary>
    /// The form that pops up instead of the dropdown portion of the
    /// DropDownPanel's combobox. It containes the actual control to
    /// display.
    /// </summary>
    internal partial class DropDownForm : Form, IDropDownAware
    {
        #region Private Variable Declaration

        private IDropDownAware _control = null;

        #endregion Private Variable Declaration

        #region Constructor / Destructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DropDownForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor to initialize the for with the control to display.
        /// </summary>
        /// <param name="Ctrl">The control to display.</param>
        public DropDownForm(IDropDownAware Ctrl)
            : this()
        {
            if (Ctrl != null)
            {
                _control = Ctrl;

                InitializeControl(_control as Control);
            }
        }

        #endregion Constructor / Destructor

        #region Form Events

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Controls.Remove(_control as Control);
            base.OnClosing(e);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            _control.FinishEditing += new DropDownValueChangedEventHandler(Ctrl_FinishEditing);
            _control.ValueChanged += new DropDownValueChangedEventHandler(Ctrl_ValueChanged);
        }

        #endregion Form Events

        #region Event Handler

        private void Ctrl_FinishEditing(object sender, DropDownValueChangedEventArgs e)
        {
            if (this.FinishEditing != null)
            {
                this.FinishEditing(this, e);
            }

            _control.FinishEditing -= new DropDownValueChangedEventHandler(Ctrl_FinishEditing);
            _control.ValueChanged -= new DropDownValueChangedEventHandler(Ctrl_ValueChanged);
        }

        private void Ctrl_ValueChanged(object sender, DropDownValueChangedEventArgs e)
        {
            if (this.ValueChanged != null)
            {
                this.ValueChanged(this, e);
            }
        }

        #endregion Event Handler

        #region IDropDownAware Implementation

        /// <summary>
        /// Fired either on OK, Cancel or a click outside the control to indicate
        /// that the user has finished editing.
        /// </summary>
        public event DropDownValueChangedEventHandler FinishEditing;

        /// <summary>
        /// Fired on any change of the controls's value during the editing process.
        /// </summary>
        public event DropDownValueChangedEventHandler ValueChanged;

        /// <summary>
        /// Gets or sets the controls' value.
        /// </summary>
        public object Value
        {
            get { return _control.Value; }
            set { _control.Value = value; }
        }

        #endregion IDropDownAware Implementation

        #region Private Methods

        private void InitializeControl(Control Ctrl)
        {
            Size size = Ctrl.Size;
            Size inner = this.ClientRectangle.Size;
            Size outer = this.Size;
            int gap = outer.Width - inner.Width;

            size.Width += gap;
            size.Height += gap;

            this.Size = size;
            this.Controls.Add(Ctrl);
            Ctrl.Location = new Point(0, 0);
            Ctrl.Visible = true;
            Ctrl.Invalidate();
        }

        #endregion Private Methods
    }
}