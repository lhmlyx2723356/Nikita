using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
    /// <summary>
    /// A Message Loop filter which detect mouse events whilst the popup form is shown
    /// and notifies the owning <see cref="PopupWindowHelper"/> class when a mouse
    /// click outside the popup occurs.
    ///
    /// Thousand thanks to Steve McMahon:
    /// http://www.vbaccelerator.com/home/NET/Code/Controls/Popup_Windows/Popup_Windows/Popup_Form_Demonstration.asp
    /// </summary>
    internal class DropDownMessageFilter : IMessageFilter
    {
        #region Private Constants

        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_MBUTTONDOWN = 0x207;
        private const int WM_NCLBUTTONDOWN = 0x0A1;
        private const int WM_NCMBUTTONDOWN = 0x0A7;
        private const int WM_NCRBUTTONDOWN = 0x0A4;
        private const int WM_RBUTTONDOWN = 0x204;

        #endregion Private Constants

        #region Private Variable Declarations

        private Form _dropDown = null;
        private DropDownWindowHelper _owner = null;

        #endregion Private Variable Declarations

        #region Event Declarations

        public event DropDownCancelEventHandler DropDownCancel;

        #endregion Event Declarations

        #region Constructor / Destructor

        /// <summary>
        /// Constructs a new instance of this class and sets the owning
        /// object.
        /// </summary>
        /// <param name="Owner">The <see cref="DropDownWindowHelper"/> object
        /// which owns this class.</param>
        public DropDownMessageFilter(DropDownWindowHelper Owner)
        {
            _owner = Owner;
        }

        #endregion Constructor / Destructor

        #region Public Properties

        /// <summary>
        /// Gets/sets the dropdown form which is being displayed.
        /// </summary>
        public Form DropDown
        {
            get { return _dropDown; }
            set { _dropDown = value; }
        }

        #endregion Public Properties

        #region Private Methods

        private void OnMouseDown()
        {
            Point cursorPos = Cursor.Position;											// Get the cursor location

            if (!_dropDown.Bounds.Contains(cursorPos))									// Check if it is within the popup form
            {
                OnDropDownCancel(new DropDownCancelEventArgs(_dropDown, cursorPos));	// If not, then call to see if it should be closed
            }
        }

        #endregion Private Methods

        #region DropDownCancelEvent Implementation

        protected virtual void OnDropDownCancel(DropDownCancelEventArgs e)
        {
            if (this.DropDownCancel != null)
            {
                this.DropDownCancel(this, e);
            }

            if (!e.Cancel)
            {
                _owner.CloseDropDown();
                _dropDown = null;					// Clear reference for GC
            }
        }

        #endregion DropDownCancelEvent Implementation

        #region IMessageFilter Implementation

        /// <summary>
        /// Checks the message loop for mouse messages whilst the popup
        /// window is displayed.  If one is detected the position is
        /// checked to see if it is outside the form, and the owner
        /// is notified if so.
        /// </summary>
        /// <param name="m">Windows Message about to be processed by the
        /// message loop</param>
        /// <returns><c>true</c> to filter the message, <c>false</c> otherwise.
        /// This implementation always returns <c>false</c>.</returns>
        public bool PreFilterMessage(ref Message m)
        {
            if (_dropDown != null)
            {
                switch (m.Msg)
                {
                    case WM_LBUTTONDOWN:
                    case WM_RBUTTONDOWN:
                    case WM_MBUTTONDOWN:
                    case WM_NCLBUTTONDOWN:
                    case WM_NCRBUTTONDOWN:
                    case WM_NCMBUTTONDOWN: OnMouseDown(); break;
                }
            }

            return false;
        }

        #endregion IMessageFilter Implementation
    }
}