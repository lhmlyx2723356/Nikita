using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
    /// <summary>
    /// Represents the method which responds to a <see cref="DropDownCancel"/> event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void DropDownCancelEventHandler(object sender, DropDownCancelEventArgs e);

    /// <summary>
    /// Represents the method which responds to a <see cref="DropDownClosed"/> event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void DropDownClosedEventHandler(object sender, DropDownClosedEventArgs e);

    /// <summary>
    ///
    /// </summary>
    /// <param name="sender">The object firing the event.</param>
    /// <param name="e"></param>
    public delegate void DropDownValueChangedEventHandler(object sender, DropDownValueChangedEventArgs e);

    /// <summary>
    /// Arguments to a <see cref="DropDownCancelEvent"/>.  Provides a
    /// reference to the popup form that is to be closed and
    /// allows the operation to be cancelled.
    ///
    /// Thousand thanks to Steve McMahon:
    /// http://www.vbaccelerator.com/home/NET/Code/Controls/Popup_Windows/Popup_Windows/Popup_Form_Demonstration.asp
    /// </summary>
    public class DropDownCancelEventArgs : EventArgs
    {
        #region Private Variable Declarations

        private bool _cancel = false;
        private Point _cursorLocation;
        private Form _dropDown = null;

        #endregion Private Variable Declarations

        #region Constructor / Destructor

        /// <summary>
        /// Constructs a new instance of this class.
        /// </summary>
        /// <param name="DropDown">The popup form</param>
        /// <param name="CursorLocation">The mouse location, if any, where the
        /// mouse event that would cancel the popup occured.</param>
        public DropDownCancelEventArgs(Form DropDown, Point CursorLocation)
        {
            _dropDown = DropDown;
            _cursorLocation = CursorLocation;
            _cancel = false;
        }

        #endregion Constructor / Destructor

        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public bool Cancel
        {
            get { return _cancel; }
            set { _cancel = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public Point CursorLocation
        {
            get { return _cursorLocation; }
        }

        /// <summary>
        ///
        /// </summary>
        public Form DropDown
        {
            get { return _dropDown; }
        }

        #endregion Public Properties
    }

    /// <summary>
    /// Contains event information for a <see cref="DropDownClosed"/> event.
    ///
    /// Thousand thanks to Steve McMahon:
    /// http://www.vbaccelerator.com/home/NET/Code/Controls/Popup_Windows/Popup_Windows/Popup_Form_Demonstration.asp
    /// </summary>
    public class DropDownClosedEventArgs : EventArgs
    {
        #region Private Variable Declarations

        private Form _dropDown = null;

        #endregion Private Variable Declarations

        #region Constructor / Destructor

        /// <summary>
        /// Constructs a new instance of this class for the specified
        /// popup form.
        /// </summary>
        /// <param name="DropDown">DropDown Form which is being closed.</param>
        public DropDownClosedEventArgs(Form DropDown)
        {
            _dropDown = DropDown;
        }

        #endregion Constructor / Destructor

        #region Public Properties

        /// <summary>
        /// Gets the dropdown form which is being closed.
        /// </summary>
        public Form DropDown
        {
            get { return _dropDown; }
        }

        #endregion Public Properties
    }

    /// <summary>
    /// Contains event information for DropDownValueChangedEventHandler.
    /// </summary>
    public class DropDownValueChangedEventArgs : EventArgs
    {
        #region Private Variable Declarations

        private object _value = null;

        #endregion Private Variable Declarations

        #region Constructor / Destructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DropDownValueChangedEventArgs()
        {
        }

        /// <summary>
        /// Initialization with the control's value.
        /// </summary>
        /// <param name="Value"></param>
        public DropDownValueChangedEventArgs(object Value)
        {
            _value = Value;
        }

        #endregion Constructor / Destructor

        #region Public Properties

        /// <summary>
        /// Gets or sets the control's value.
        /// </summary>
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        #endregion Public Properties
    }
}