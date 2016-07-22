using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
    internal interface IContentFocusManager
    {
        void Activate(IDockContent content);

        void AddToList(IDockContent content);

        void GiveUpFocus(IDockContent content);

        void RemoveFromList(IDockContent content);
    }

    partial class DockPanel
    {
        private static readonly object ActiveContentChangedEvent = new object();

        private static readonly object ActiveDocumentChangedEvent = new object();

        private static readonly object ActivePaneChangedEvent = new object();

        [LocalizedCategory("Category_PropertyChanged")]
        [LocalizedDescription("DockPanel_ActiveContentChanged_Description")]
        public event EventHandler ActiveContentChanged
        {
            add { Events.AddHandler(ActiveContentChangedEvent, value); }
            remove { Events.RemoveHandler(ActiveContentChangedEvent, value); }
        }

        [LocalizedCategory("Category_PropertyChanged")]
        [LocalizedDescription("DockPanel_ActiveDocumentChanged_Description")]
        public event EventHandler ActiveDocumentChanged
        {
            add { Events.AddHandler(ActiveDocumentChangedEvent, value); }
            remove { Events.RemoveHandler(ActiveDocumentChangedEvent, value); }
        }

        [LocalizedCategory("Category_PropertyChanged")]
        [LocalizedDescription("DockPanel_ActivePaneChanged_Description")]
        public event EventHandler ActivePaneChanged
        {
            add { Events.AddHandler(ActivePaneChangedEvent, value); }
            remove { Events.RemoveHandler(ActivePaneChangedEvent, value); }
        }

        private interface IFocusManager
        {
            IDockContent ActiveContent { get; }

            IDockContent ActiveDocument { get; }

            DockPane ActiveDocumentPane { get; }

            DockPane ActivePane { get; }

            bool IsFocusTrackingSuspended { get; }

            void ResumeFocusTracking();

            void SuspendFocusTracking();
        }

        [Browsable(false)]
        public IDockContent ActiveContent
        {
            get { return FocusManager.ActiveContent; }
        }

        [Browsable(false)]
        public IDockContent ActiveDocument
        {
            get { return FocusManager.ActiveDocument; }
        }

        [Browsable(false)]
        public DockPane ActiveDocumentPane
        {
            get { return FocusManager.ActiveDocumentPane; }
        }

        [Browsable(false)]
        public DockPane ActivePane
        {
            get { return FocusManager.ActivePane; }
        }

        internal IContentFocusManager ContentFocusManager
        {
            get { return m_focusManager; }
        }

        private IFocusManager FocusManager
        {
            get { return m_focusManager; }
        }

        internal void SaveFocus()
        {
            DummyControl.Focus();
        }

        protected void OnActiveContentChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[ActiveContentChangedEvent];
            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnActiveDocumentChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[ActiveDocumentChangedEvent];
            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnActivePaneChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[ActivePaneChangedEvent];
            if (handler != null)
                handler(this, e);
        }

        private class FocusManagerImpl : Component, IContentFocusManager, IFocusManager
        {
            // Use a static instance of the windows hook to prevent stack overflows in the windows kernel.
            [ThreadStatic]
            private static LocalWindowsHook sm_localWindowsHook;

            private readonly LocalWindowsHook.HookEventHandler m_hookEventHandler;

            private IDockContent m_activeContent = null;

            private IDockContent m_activeDocument = null;

            private DockPane m_activeDocumentPane = null;

            private DockPane m_activePane = null;

            private IDockContent m_contentActivating = null;

            private uint m_countSuspendFocusTracking = 0;

            private bool m_disposed = false;

            private DockPanel m_dockPanel;

            private bool m_inRefreshActiveWindow = false;

            private IDockContent m_lastActiveContent = null;

            private List<IDockContent> m_listContent = new List<IDockContent>();

            public FocusManagerImpl(DockPanel dockPanel)
            {
                m_dockPanel = dockPanel;
                if (Win32Helper.IsRunningOnMono)
                    return;
                m_hookEventHandler = new LocalWindowsHook.HookEventHandler(HookEventHandler);

                // Ensure the windows hook has been created for this thread
                if (sm_localWindowsHook == null)
                {
                    sm_localWindowsHook = new LocalWindowsHook(Win32.HookType.WH_CALLWNDPROCRET);
                    sm_localWindowsHook.Install();
                }

                sm_localWindowsHook.HookInvoked += m_hookEventHandler;
            }

            public IDockContent ActiveContent
            {
                get { return m_activeContent; }
            }

            public IDockContent ActiveDocument
            {
                get { return m_activeDocument; }
            }

            public DockPane ActiveDocumentPane
            {
                get { return m_activeDocumentPane; }
            }

            public DockPane ActivePane
            {
                get { return m_activePane; }
            }

            public DockPanel DockPanel
            {
                get { return m_dockPanel; }
            }

            public bool IsFocusTrackingSuspended
            {
                get { return m_countSuspendFocusTracking != 0; }
            }

            private IDockContent ContentActivating
            {
                get { return m_contentActivating; }
                set { m_contentActivating = value; }
            }

            private bool InRefreshActiveWindow
            {
                get { return m_inRefreshActiveWindow; }
            }

            private IDockContent LastActiveContent
            {
                get { return m_lastActiveContent; }
                set { m_lastActiveContent = value; }
            }

            private List<IDockContent> ListContent
            {
                get { return m_listContent; }
            }

            public void Activate(IDockContent content)
            {
                if (IsFocusTrackingSuspended)
                {
                    ContentActivating = content;
                    return;
                }

                if (content == null)
                    return;
                DockContentHandler handler = content.DockHandler;
                if (handler.Form.IsDisposed)
                    return; // Should not reach here, but better than throwing an exception
                if (ContentContains(content, handler.ActiveWindowHandle))
                {
                    if (!Win32Helper.IsRunningOnMono)
                    {
                        NativeMethod.SetFocus(handler.ActiveWindowHandle);
                    }
                }

                if (handler.Form.ContainsFocus)
                    return;

                if (handler.Form.SelectNextControl(handler.Form.ActiveControl, true, true, true, true))
                    return;

                if (Win32Helper.IsRunningOnMono)
                    return;

                // Since DockContent Form is not selectalbe, use Win32 SetFocus instead
                NativeMethod.SetFocus(handler.Form.Handle);
            }

            public void AddToList(IDockContent content)
            {
                if (ListContent.Contains(content) || IsInActiveList(content))
                    return;

                ListContent.Add(content);
            }

            public void GiveUpFocus(IDockContent content)
            {
                DockContentHandler handler = content.DockHandler;
                if (!handler.Form.ContainsFocus)
                    return;

                if (IsFocusTrackingSuspended)
                    DockPanel.DummyControl.Focus();

                if (LastActiveContent == content)
                {
                    IDockContent prev = handler.PreviousActive;
                    if (prev != null)
                        Activate(prev);
                    else if (ListContent.Count > 0)
                        Activate(ListContent[ListContent.Count - 1]);
                }
                else if (LastActiveContent != null)
                    Activate(LastActiveContent);
                else if (ListContent.Count > 0)
                    Activate(ListContent[ListContent.Count - 1]);
            }

            public void RemoveFromList(IDockContent content)
            {
                if (IsInActiveList(content))
                    RemoveFromActiveList(content);
                if (ListContent.Contains(content))
                    ListContent.Remove(content);
            }

            public void ResumeFocusTracking()
            {
                if (m_disposed || m_countSuspendFocusTracking == 0)
                    return;

                if (--m_countSuspendFocusTracking == 0)
                {
                    if (ContentActivating != null)
                    {
                        Activate(ContentActivating);
                        ContentActivating = null;
                    }

                    if (!Win32Helper.IsRunningOnMono)
                        sm_localWindowsHook.HookInvoked += m_hookEventHandler;

                    if (!InRefreshActiveWindow)
                        RefreshActiveWindow();
                }
            }

            public void SuspendFocusTracking()
            {
                if (m_disposed)
                    return;

                if (m_countSuspendFocusTracking++ == 0)
                {
                    if (!Win32Helper.IsRunningOnMono)
                        sm_localWindowsHook.HookInvoked -= m_hookEventHandler;
                }
            }

            internal void SetActiveContent()
            {
                IDockContent value = ActivePane == null ? null : ActivePane.ActiveContent;

                if (m_activeContent == value)
                    return;

                if (m_activeContent != null)
                    m_activeContent.DockHandler.IsActivated = false;

                m_activeContent = value;

                if (m_activeContent != null)
                {
                    m_activeContent.DockHandler.IsActivated = true;
                    if (!DockHelper.IsDockStateAutoHide((m_activeContent.DockHandler.DockState)))
                        AddLastToActiveList(m_activeContent);
                }
            }

            protected override void Dispose(bool disposing)
            {
                if (!m_disposed && disposing)
                {
                    if (!Win32Helper.IsRunningOnMono)
                    {
                        sm_localWindowsHook.HookInvoked -= m_hookEventHandler;
                    }

                    m_disposed = true;
                }

                base.Dispose(disposing);
            }

            private static bool ContentContains(IDockContent content, IntPtr hWnd)
            {
                Control control = Control.FromChildHandle(hWnd);
                for (Control parent = control; parent != null; parent = parent.Parent)
                    if (parent == content.DockHandler.Form)
                        return true;

                return false;
            }

            private void AddLastToActiveList(IDockContent content)
            {
                IDockContent last = LastActiveContent;
                if (last == content)
                    return;

                DockContentHandler handler = content.DockHandler;

                if (IsInActiveList(content))
                    RemoveFromActiveList(content);

                handler.PreviousActive = last;
                handler.NextActive = null;
                LastActiveContent = content;
                if (last != null)
                    last.DockHandler.NextActive = LastActiveContent;
            }

            private DockPane GetPaneFromHandle(IntPtr hWnd)
            {
                Control control = Control.FromChildHandle(hWnd);

                IDockContent content = null;
                DockPane pane = null;
                for (; control != null; control = control.Parent)
                {
                    content = control as IDockContent;
                    if (content != null)
                        content.DockHandler.ActiveWindowHandle = hWnd;

                    if (content != null && content.DockHandler.DockPanel == DockPanel)
                        return content.DockHandler.Pane;

                    pane = control as DockPane;
                    if (pane != null && pane.DockPanel == DockPanel)
                        break;
                }

                return pane;
            }

            // Windows hook event handler
            private void HookEventHandler(object sender, HookEventArgs e)
            {
                Win32.Msgs msg = (Win32.Msgs)Marshal.ReadInt32(e.lParam, IntPtr.Size * 3);

                if (msg == Win32.Msgs.WM_KILLFOCUS)
                {
                    IntPtr wParam = Marshal.ReadIntPtr(e.lParam, IntPtr.Size * 2);
                    DockPane pane = GetPaneFromHandle(wParam);
                    if (pane == null)
                        RefreshActiveWindow();
                }
                else if (msg == Win32.Msgs.WM_SETFOCUS || msg == Win32.Msgs.WM_MDIACTIVATE)
                    RefreshActiveWindow();
            }

            private bool IsInActiveList(IDockContent content)
            {
                return !(content.DockHandler.NextActive == null && LastActiveContent != content);
            }

            private void RefreshActiveWindow()
            {
                SuspendFocusTracking();
                m_inRefreshActiveWindow = true;

                DockPane oldActivePane = ActivePane;
                IDockContent oldActiveContent = ActiveContent;
                IDockContent oldActiveDocument = ActiveDocument;

                SetActivePane();
                SetActiveContent();
                SetActiveDocumentPane();
                SetActiveDocument();
                DockPanel.AutoHideWindow.RefreshActivePane();

                ResumeFocusTracking();
                m_inRefreshActiveWindow = false;

                if (oldActiveContent != ActiveContent)
                    DockPanel.OnActiveContentChanged(EventArgs.Empty);
                if (oldActiveDocument != ActiveDocument)
                    DockPanel.OnActiveDocumentChanged(EventArgs.Empty);
                if (oldActivePane != ActivePane)
                    DockPanel.OnActivePaneChanged(EventArgs.Empty);
            }

            private void RemoveFromActiveList(IDockContent content)
            {
                if (LastActiveContent == content)
                    LastActiveContent = content.DockHandler.PreviousActive;

                IDockContent prev = content.DockHandler.PreviousActive;
                IDockContent next = content.DockHandler.NextActive;
                if (prev != null)
                    prev.DockHandler.NextActive = next;
                if (next != null)
                    next.DockHandler.PreviousActive = prev;

                content.DockHandler.PreviousActive = null;
                content.DockHandler.NextActive = null;
            }

            private void SetActiveDocument()
            {
                IDockContent value = ActiveDocumentPane == null ? null : ActiveDocumentPane.ActiveContent;

                if (m_activeDocument == value)
                    return;

                m_activeDocument = value;
            }

            private void SetActiveDocumentPane()
            {
                DockPane value = null;

                if (ActivePane != null && ActivePane.DockState == DockState.Document)
                    value = ActivePane;

                if (value == null && DockPanel.DockWindows != null)
                {
                    if (ActiveDocumentPane == null)
                        value = DockPanel.DockWindows[DockState.Document].DefaultPane;
                    else if (ActiveDocumentPane.DockPanel != DockPanel || ActiveDocumentPane.DockState != DockState.Document)
                        value = DockPanel.DockWindows[DockState.Document].DefaultPane;
                    else
                        value = ActiveDocumentPane;
                }

                if (m_activeDocumentPane == value)
                    return;

                if (m_activeDocumentPane != null)
                    m_activeDocumentPane.SetIsActiveDocumentPane(false);

                m_activeDocumentPane = value;

                if (m_activeDocumentPane != null)
                    m_activeDocumentPane.SetIsActiveDocumentPane(true);
            }

            private void SetActivePane()
            {
                DockPane value = Win32Helper.IsRunningOnMono ? null : GetPaneFromHandle(NativeMethod.GetFocus());
                if (m_activePane == value)
                    return;

                if (m_activePane != null)
                    m_activePane.SetIsActivated(false);

                m_activePane = value;

                if (m_activePane != null)
                    m_activePane.SetIsActivated(true);
            }

            private class HookEventArgs : EventArgs
            {
                [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
                public int HookCode;

                public IntPtr lParam;

                [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
                public IntPtr wParam;
            }

            private class LocalWindowsHook : IDisposable
            {
                private NativeMethod.HookProc m_filterFunc = null;

                // Internal properties
                private IntPtr m_hHook = IntPtr.Zero;

                private Win32.HookType m_hookType;

                public LocalWindowsHook(Win32.HookType hook)
                {
                    m_hookType = hook;
                    m_filterFunc = new NativeMethod.HookProc(this.CoreHookProc);
                }

                ~LocalWindowsHook()
                {
                    Dispose(false);
                }

                // Event delegate
                public delegate void HookEventHandler(object sender, HookEventArgs e);

                // Event: HookInvoked
                public event HookEventHandler HookInvoked;

                // Default filter function
                public IntPtr CoreHookProc(int code, IntPtr wParam, IntPtr lParam)
                {
                    if (code < 0)
                        return NativeMethod.CallNextHookEx(m_hHook, code, wParam, lParam);

                    // Let clients determine what to do
                    HookEventArgs e = new HookEventArgs();
                    e.HookCode = code;
                    e.wParam = wParam;
                    e.lParam = lParam;
                    OnHookInvoked(e);

                    // Yield to the next hook in the chain
                    return NativeMethod.CallNextHookEx(m_hHook, code, wParam, lParam);
                }

                public void Dispose()
                {
                    Dispose(true);
                    GC.SuppressFinalize(this);
                }

                // Install the hook
                public void Install()
                {
                    if (m_hHook != IntPtr.Zero)
                        Uninstall();

                    int threadId = NativeMethod.GetCurrentThreadId();
                    m_hHook = NativeMethod.SetWindowsHookEx(m_hookType, m_filterFunc, IntPtr.Zero, threadId);
                }

                // Uninstall the hook
                public void Uninstall()
                {
                    if (m_hHook != IntPtr.Zero)
                    {
                        NativeMethod.UnhookWindowsHookEx(m_hHook);
                        m_hHook = IntPtr.Zero;
                    }
                }

                protected virtual void Dispose(bool disposing)
                {
                    Uninstall();
                }

                protected void OnHookInvoked(HookEventArgs e)
                {
                    if (HookInvoked != null)
                        HookInvoked(this, e);
                }
            }
        }
    }
}