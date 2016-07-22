using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
    /// <summary>
    /// Manages opened popups
    /// </summary>
    public static class RibbonPopupManager
    {
        #region Subclasses

        /// <summary>
        /// Specifies reasons why pop-ups can be dismissed
        /// </summary>
        public enum DismissReason
        {
            /// <summary>
            /// An item has been clicked
            /// </summary>
            ItemClicked,

            /// <summary>
            /// The app has been clicked
            /// </summary>
            AppClicked,

            /// <summary>
            /// A new popup is showing and will hide sibling's popups
            /// </summary>
            NewPopup,

            /// <summary>
            /// The aplication window has been deactivated
            /// </summary>
            AppFocusChanged,

            /// <summary>
            /// User has pressed escape on the keyboard
            /// </summary>
            EscapePressed
        }

        #endregion

        #region Fields

        private static List<RibbonPopup> pops;

        #endregion

        #region Ctor

        static RibbonPopupManager()
        {
            pops = new List<RibbonPopup>();
        }

        #endregion

        #region Props

        /// <summary>
        /// Gets the last pop-up of the collection
        /// </summary>
        internal static RibbonPopup LastPopup
        {
            get
            {
                if (pops.Count > 0)
                {
                    return pops[pops.Count - 1];
                }

                return null;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Registers a popup existance
        /// </summary>
        /// <param name="p"></param>
        internal static void Register(RibbonPopup p)
        {
            if (!pops.Contains(p))
            {
                pops.Add(p); 
            }
        }

        /// <summary>
        /// Unregisters a popup from existance
        /// </summary>
        /// <param name="p"></param>
        internal static void Unregister(RibbonPopup p)
        {
            if (pops.Contains(p))
            {
                pops.Remove(p);
            }
        }

        /// <summary>
        /// Feeds a click generated on the mouse hook
        /// </summary>
        /// <param name="e"></param>
        internal static void FeedHookClick(MouseEventArgs e)
        {
            foreach (RibbonPopup p in pops)
            {
                if (p.WrappedDropDown.Bounds.Contains(e.Location))
                {
                    return;
                }
            }

            //If click was in no dropdown, let's go everyone
            Dismiss(DismissReason.AppClicked);
        }

        /// <summary>
        /// Feeds mouse Wheel. If applied on a IScrollableItem it's sended to it
        /// </summary>
        /// <param name="e"></param>
        /// <returns>True if handled. False otherwise</returns>
        internal static bool FeedMouseWheel(MouseEventArgs e)
        {
            RibbonDropDown dd = LastPopup as RibbonDropDown;
            
            if (dd != null)
            {
                foreach (RibbonItem item in dd.Items)
                {
                    if (dd.RectangleToScreen(item.Bounds).Contains(e.Location))
                    {
                        IScrollableRibbonItem sc = item as IScrollableRibbonItem;

                        if (sc != null)
                        {
                            if (e.Delta < 0)
                            {
                                sc.ScrollDown();
                            }
                            else
                            {
                                sc.ScrollUp();
                            }

                            return true;
                        }
                    }
                    
                }
            }

            return false;
        }

        /// <summary>
        /// Closes all children of specified pop-up
        /// </summary>
        /// <param name="parent">Pop-up of which children will be closed</param>
        /// <param name="reason">Reason for dismissing</param>
        public static void DismissChildren(RibbonPopup parent, DismissReason reason)
        {
            int index = pops.IndexOf(parent);

            if (index >= 0)
            {
                Dismiss(index + 1, reason);
            }
        }

        /// <summary>
        /// Closes all currently registered pop-ups
        /// </summary>
        /// <param name="reason"></param>
        public static void Dismiss(DismissReason reason)
        {
            Dismiss(0, reason);
        }

        /// <summary>
        /// Closes specified pop-up and all its descendants
        /// </summary>
        /// <param name="startPopup">Pop-up to close (and its descendants)</param>
        /// <param name="reason">Reason for closing</param>
        public static void Dismiss(RibbonPopup startPopup, DismissReason reason)
        {
            int index = pops.IndexOf(startPopup);

            if (index >= 0)
            {
                Dismiss(index, reason);
            }
        }

        /// <summary>
        /// Closes pop-up of the specified index and all its descendants
        /// </summary>
        /// <param name="startPopup">Index of the pop-up to close</param>
        /// <param name="reason">Reason for closing</param>
        private static void Dismiss(int startPopup, DismissReason reason)
        {
            for (int i = pops.Count - 1; i >= startPopup; i--)
            {
                pops[i].Close();
            }
        }

        #endregion
    }
}
