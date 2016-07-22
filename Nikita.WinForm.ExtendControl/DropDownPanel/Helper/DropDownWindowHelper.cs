using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
    /// <summary>
    /// A class to assist in creating popup windows like Combo Box drop-downs and Menus.
    /// This class includes functionality to keep the title bar of the popup owner form
    /// active whilst the popup is displayed, and to automatically cancel the popup
    /// whenever the user clicks outside the popup window or shifts focus to another
    /// application.
    ///
    /// Thousand thanks to Steve McMahon:
    /// http://www.vbaccelerator.com/home/NET/Code/Controls/Popup_Windows/Popup_Windows/Popup_Form_Demonstration.asp
    /// </summary>
    internal class DropDownWindowHelper : NativeWindow
    {
        #region Private Variable Declarations

        private Form _dropDown = null;
        private bool _dropDownShowing = false;
        private DropDownMessageFilter _filter = null;
        private Form _owner = null;
        private bool _skipClose = false;
        private EventHandler DropDownClosedHandler = null;

        #endregion Private Variable Declarations

        #region Event Declarations

        public event DropDownCancelEventHandler DropDownCancel;

        public event DropDownClosedEventHandler DropDownClosed;

        #endregion Event Declarations

        #region Constructor / Destructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <remarks>Use the <see cref="System.Windows.Forms.NativeWindow.AssignHandle"/>
        /// method to attach this class to the form you want to show popups from.</remarks>
        public DropDownWindowHelper()
        {
            _filter = new DropDownMessageFilter(this);
            _filter.DropDownCancel += new DropDownCancelEventHandler(Popup_Cancel);
        }

        #endregion Constructor / Destructor

        #region Event Handler

        /// <summary>
        /// Subclasses the owning form's existing Window Procedure to enables the
        /// title bar to remain active when a popup is show, and to detect if
        /// the user clicks onto another application whilst the popup is visible.
        /// </summary>
        /// <param name="m">Window Procedure Message</param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (DropDownShowing)
            {
                if (m.Msg == UIApiCalls.WM_NCACTIVATE)
                {
                    if (((int)m.WParam) == 0)																// Check if the title bar will made inactive:
                    {	// Note it's no good to try and consume this message; if you try to do that you'll end up with windows
                        UIApiCalls.SendMessage(this.Handle, UIApiCalls.WM_NCACTIVATE, 1, IntPtr.Zero);		// If so reactivate it.
                    }
                }
                else if (m.Msg == UIApiCalls.WM_ACTIVATEAPP)
                {
                    if ((int)m.WParam == 0)																	// Check if the application is being deactivated.
                    {
                        CloseDropDown();																		// It is so cancel the popup:
                        UIApiCalls.PostMessage(this.Handle, UIApiCalls.WM_NCACTIVATE, 0, IntPtr.Zero);		// And put the title bar into the inactive state:
                    }
                }
            }
        }

        private void Popup_Cancel(object sender, DropDownCancelEventArgs e)
        {
            OnDropDownCancel(e);
        }

        /// <summary>
        /// Responds to the <see cref="System.Windows.Forms.Form.Closed"/>
        /// event from the popup form.
        /// </summary>
        /// <param name="sender">Popup form that has been closed.</param>
        /// <param name="e">Not used.</param>
        private void Popup_Closed(object sender, EventArgs e)
        {
            CloseDropDown();
        }

        #endregion Event Handler

        #region Public Methods

        /// <summary>
        /// Called when the popup is being hidden.
        /// </summary>
        public void CloseDropDown()
        {
            if (DropDownShowing)
            {
                if (!_skipClose)
                {
                    OnPDropDownClosed(new DropDownClosedEventArgs(_dropDown));
                }

                _skipClose = false;

                _owner.RemoveOwnedForm(_dropDown);					// Make sure the popup is closed and we've cleaned up:
                _dropDownShowing = false;
                _dropDown.Closed -= DropDownClosedHandler;
                DropDownClosedHandler = null;
                _dropDown.Close();

                Application.RemoveMessageFilter(_filter);			// No longer need to filter for clicks outside the popup.

                // If we did something from the popup which shifted focus to a new form, like showing another popup
                // or dialog, then Windows won't know how to bring the original owner back to the foreground, so
                // force it here:
                _owner.Activate();

                _dropDown = null;									// Null out references for GC
                _owner = null;
            }
        }

        /// <summary>
        /// Shows the specified Form as a popup window, keeping the
        /// Owner's title bar active and preparing to cancel the popup
        /// should the user click anywhere outside the popup window.
        /// <para>Typical code to use this message is as follows:</para>
        /// <code>
        ///    frmPopup popup = new frmPopup();
        ///    Point location = this.PointToScreen(new Point(button1.Left, button1.Bottom));
        ///    popupHelper.ShowPopup(this, popup, location);
        /// </code>
        /// <para>Put as much initialisation code as possible
        /// into the popup form's constructor, rather than the <see cref="System.Windows.Forms.Load"/>
        /// event as this will improve visual appearance.</para>
        /// </summary>
        /// <param name="Owner">Main form which owns the popup</param>
        /// <param name="Popup">Window to show as a popup</param>
        /// <param name="v">Location relative to the screen to show the popup at.</param>
        public void ShowDropDown(Form Owner, Form DropDown, Point Location)
        {
            _owner = Owner;
            _dropDown = DropDown;
            Application.AddMessageFilter(_filter);					// Start checking for the popup being cancelled
            DropDown.StartPosition = FormStartPosition.Manual;		// Set the location of the popup form:
            DropDown.Location = Location;
            Owner.AddOwnedForm(DropDown);							// Make it owned by the window that's displaying it:
            DropDownClosedHandler = new EventHandler(Popup_Closed);	// Respond to the Closed event in case the popup is closed by its own internal means
            DropDown.Closed += DropDownClosedHandler;

            _dropDownShowing = true;								// Show the popup:
            DropDown.Show();
            DropDown.Activate();

            // A little bit of fun.  We've shown the popup, but because we've kept the main window's
            // title bar in focus the tab sequence isn't quite right.  This can be fixed by sending a tab,
            // but that on its own would shift focus to the second control in the form.  So send a tab,
            // followed by a reverse-tab.
            UIApiCalls.keybd_event((byte)Keys.Tab, 0, 0, 0);
            UIApiCalls.keybd_event((byte)Keys.Tab, 0, UIApiCalls.KEYEVENTF_KEYUP, 0);
            UIApiCalls.keybd_event((byte)Keys.ShiftKey, 0, 0, 0);
            UIApiCalls.keybd_event((byte)Keys.Tab, 0, 0, 0);
            UIApiCalls.keybd_event((byte)Keys.Tab, 0, UIApiCalls.KEYEVENTF_KEYUP, 0);
            UIApiCalls.keybd_event((byte)Keys.ShiftKey, 0, UIApiCalls.KEYEVENTF_KEYUP, 0);

            _filter.DropDown = DropDown;							// Start filtering for mouse clicks outside the popup
        }

        #endregion Public Methods

        #region Public Properties

        /// <summary>
        /// Indicator weither the DropDown is showing.
        /// </summary>
        public bool DropDownShowing
        {
            get { return _dropDownShowing; }
        }

        #endregion Public Properties

        #region Event Implementation

        protected virtual void OnDropDownCancel(DropDownCancelEventArgs e)
        {
            if (this.DropDownCancel != null)
            {
                this.DropDownCancel(this, e);

                if (!e.Cancel)
                {
                    _skipClose = true;
                }
            }
        }

        protected virtual void OnPDropDownClosed(DropDownClosedEventArgs e)
        {
            if (this.DropDownClosed != null)
            {
                this.DropDownClosed(this, e);
            }
        }

        #endregion Event Implementation
    }
}