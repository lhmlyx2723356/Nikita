using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
    partial class DockPanel
    {
        private abstract class DragHandler : DragHandlerBase
        {
            private DockPanel m_dockPanel;

            private IDragSource m_dragSource;

            protected DragHandler(DockPanel dockPanel)
            {
                m_dockPanel = dockPanel;
            }

            public DockPanel DockPanel
            {
                get { return m_dockPanel; }
            }

            protected sealed override Control DragControl
            {
                get { return DragSource == null ? null : DragSource.DragControl; }
            }

            protected IDragSource DragSource
            {
                get { return m_dragSource; }
                set { m_dragSource = value; }
            }

            protected sealed override bool OnPreFilterMessage(ref Message m)
            {
                if ((m.Msg == (int)Win32.Msgs.WM_KEYDOWN || m.Msg == (int)Win32.Msgs.WM_KEYUP) &&
                    ((int)m.WParam == (int)Keys.ControlKey || (int)m.WParam == (int)Keys.ShiftKey))
                    OnDragging();

                return base.OnPreFilterMessage(ref m);
            }
        }

        /// <summary>
        /// DragHandlerBase is the base class for drag handlers. The derived class should:
        ///   1. Define its public method BeginDrag. From within this public BeginDrag method,
        ///      DragHandlerBase.BeginDrag should be called to initialize the mouse capture
        ///      and message filtering.
        ///   2. Override the OnDragging and OnEndDrag methods.
        /// </summary>
        private abstract class DragHandlerBase : NativeWindow, IMessageFilter
        {
            private Point m_startMousePosition = Point.Empty;

            protected DragHandlerBase()
            {
            }

            protected abstract Control DragControl
            {
                get;
            }

            protected Point StartMousePosition
            {
                get { return m_startMousePosition; }
                private set { m_startMousePosition = value; }
            }

            bool IMessageFilter.PreFilterMessage(ref Message m)
            {
                if (m.Msg == (int)Win32.Msgs.WM_MOUSEMOVE)
                    OnDragging();
                else if (m.Msg == (int)Win32.Msgs.WM_LBUTTONUP)
                    EndDrag(false);
                else if (m.Msg == (int)Win32.Msgs.WM_CAPTURECHANGED)
                    EndDrag(true);
                else if (m.Msg == (int)Win32.Msgs.WM_KEYDOWN && (int)m.WParam == (int)Keys.Escape)
                    EndDrag(true);

                return OnPreFilterMessage(ref m);
            }

            protected bool BeginDrag()
            {
                if (DragControl == null)
                    return false;

                StartMousePosition = Control.MousePosition;

                if (!Win32Helper.IsRunningOnMono)
                {
                    if (!NativeMethod.DragDetect(DragControl.Handle, StartMousePosition))
                    {
                        return false;
                    }
                }

                DragControl.FindForm().Capture = true;
                AssignHandle(DragControl.FindForm().Handle);
                Application.AddMessageFilter(this);
                return true;
            }

            protected abstract void OnDragging();

            protected abstract void OnEndDrag(bool abort);

            protected virtual bool OnPreFilterMessage(ref Message m)
            {
                return false;
            }

            protected sealed override void WndProc(ref Message m)
            {
                if (m.Msg == (int)Win32.Msgs.WM_CANCELMODE || m.Msg == (int)Win32.Msgs.WM_CAPTURECHANGED)
                    EndDrag(true);

                base.WndProc(ref m);
            }

            private void EndDrag(bool abort)
            {
                ReleaseHandle();
                Application.RemoveMessageFilter(this);
                DragControl.FindForm().Capture = false;

                OnEndDrag(abort);
            }
        }
    }
}