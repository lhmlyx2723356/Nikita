using Nikita.WinForm.ExtendControl.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
    public delegate string GetPersistStringCallback();

    public class DockContentHandler : IDisposable, IDockDragSource
    {
        private IntPtr m_activeWindowHandle = IntPtr.Zero;

        private DockAreas m_allowedAreas = DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.DockBottom | DockAreas.Document | DockAreas.Float;

        private bool m_allowEndUserDocking = true;

        private double m_autoHidePortion = 0.25;

        private IDisposable m_autoHideTab = null;

        private bool m_closeButton = true;

        private bool m_closeButtonVisible = true;

        private int m_countSetDockState = 0;

        private DockPanel m_dockPanel = null;

        private DockState m_dockState = DockState.Unknown;

        private EventHandlerList m_events;

        private bool m_flagClipWindow = false;

        private DockPane m_floatPane = null;

        private Form m_form;

        private GetPersistStringCallback m_getPersistStringCallback = null;

        private bool m_hideOnClose = false;

        private bool m_isActivated = false;

        private bool m_isFloat = false;

        private bool m_isHidden = true;

        private IDockContent m_nextActive = null;

        private DockPane m_panelPane = null;

        private IDockContent m_previousActive = null;

        private DockState m_showHint = DockState.Unknown;

        private DockPaneStripBase.Tab m_tab = null;

        private ContextMenu m_tabPageContextMenu = null;

        private ContextMenuStrip m_tabPageContextMenuStrip = null;

        private string m_tabText = null;

        private string m_toolTipText = null;

        private DockState m_visibleState = DockState.Unknown;

        public DockContentHandler(Form form)
            : this(form, null)
        {
        }

        public DockContentHandler(Form form, GetPersistStringCallback getPersistStringCallback)
        {
            if (!(form is IDockContent))
                throw new ArgumentException(Strings.DockContent_Constructor_InvalidForm, "form");

            m_form = form;
            m_getPersistStringCallback = getPersistStringCallback;

            m_events = new EventHandlerList();
            Form.Disposed += new EventHandler(Form_Disposed);
            Form.TextChanged += new EventHandler(Form_TextChanged);
        }

        public bool AllowEndUserDocking
        {
            get { return m_allowEndUserDocking; }
            set { m_allowEndUserDocking = value; }
        }

        public double AutoHidePortion
        {
            get { return m_autoHidePortion; }
            set
            {
                if (value <= 0)
                    throw (new ArgumentOutOfRangeException(Strings.DockContentHandler_AutoHidePortion_OutOfRange));

                if (m_autoHidePortion == value)
                    return;

                m_autoHidePortion = value;

                if (DockPanel == null)
                    return;

                if (DockPanel.ActiveAutoHideContent == Content)
                    DockPanel.PerformLayout();
            }
        }

        public bool CloseButton
        {
            get { return m_closeButton; }
            set
            {
                if (m_closeButton == value)
                    return;

                m_closeButton = value;
                if (IsActiveContentHandler)
                    Pane.RefreshChanges();
            }
        }

        /// <summary>
        /// Determines whether the close button is visible on the content
        /// </summary>
        public bool CloseButtonVisible
        {
            get { return m_closeButtonVisible; }
            set
            {
                if (m_closeButtonVisible == value)
                    return;

                m_closeButtonVisible = value;
                if (IsActiveContentHandler)
                    Pane.RefreshChanges();
            }
        }

        public IDockContent Content
        {
            get { return Form as IDockContent; }
        }

        public DockAreas DockAreas
        {
            get { return m_allowedAreas; }
            set
            {
                if (m_allowedAreas == value)
                    return;

                if (!DockHelper.IsDockStateValid(DockState, value))
                    throw (new InvalidOperationException(Strings.DockContentHandler_DockAreas_InvalidValue));

                m_allowedAreas = value;

                if (!DockHelper.IsDockStateValid(ShowHint, m_allowedAreas))
                    ShowHint = DockState.Unknown;
            }
        }

        public DockPanel DockPanel
        {
            get { return m_dockPanel; }
            set
            {
                if (m_dockPanel == value)
                    return;

                Pane = null;

                if (m_dockPanel != null)
                    m_dockPanel.RemoveContent(Content);

                if (m_tab != null)
                {
                    m_tab.Dispose();
                    m_tab = null;
                }

                if (m_autoHideTab != null)
                {
                    m_autoHideTab.Dispose();
                    m_autoHideTab = null;
                }

                m_dockPanel = value;

                if (m_dockPanel != null)
                {
                    m_dockPanel.AddContent(Content);
                    Form.TopLevel = false;
                    Form.FormBorderStyle = FormBorderStyle.None;
                    Form.ShowInTaskbar = false;
                    Form.WindowState = FormWindowState.Normal;
                    if (Win32Helper.IsRunningOnMono)
                        return;

                    NativeMethod.SetWindowPos(Form.Handle, IntPtr.Zero, 0, 0, 0, 0,
                        Win32.FlagsSetWindowPos.SWP_NOACTIVATE |
                        Win32.FlagsSetWindowPos.SWP_NOMOVE |
                        Win32.FlagsSetWindowPos.SWP_NOSIZE |
                        Win32.FlagsSetWindowPos.SWP_NOZORDER |
                        Win32.FlagsSetWindowPos.SWP_NOOWNERZORDER |
                        Win32.FlagsSetWindowPos.SWP_FRAMECHANGED);
                }
            }
        }

        public DockState DockState
        {
            get { return m_dockState; }
            set
            {
                if (m_dockState == value)
                    return;

                DockPanel.SuspendLayout(true);

                if (value == DockState.Hidden)
                    IsHidden = true;
                else
                    SetDockState(false, value, Pane);

                DockPanel.ResumeLayout(true, true);
            }
        }

        public DockPane FloatPane
        {
            get { return m_floatPane; }
            set
            {
                if (m_floatPane == value)
                    return;

                if (value != null)
                {
                    if (!value.IsFloat || value.DockPanel != DockPanel)
                        throw new InvalidOperationException(Strings.DockContentHandler_FloatPane_InvalidValue);
                }

                DockPane oldPane = Pane;

                if (m_floatPane != null)
                    RemoveFromPane(m_floatPane);
                m_floatPane = value;
                if (m_floatPane != null)
                {
                    m_floatPane.AddContent(Content);
                    SetDockState(IsHidden, IsFloat ? DockState.Float : VisibleState, oldPane);
                }
                else
                    SetDockState(IsHidden, DockState.Unknown, oldPane);
            }
        }

        public Form Form
        {
            get { return m_form; }
        }

        public GetPersistStringCallback GetPersistStringCallback
        {
            get { return m_getPersistStringCallback; }
            set { m_getPersistStringCallback = value; }
        }

        public bool HideOnClose
        {
            get { return m_hideOnClose; }
            set { m_hideOnClose = value; }
        }

        public Icon Icon
        {
            get { return Form.Icon; }
        }

        public bool IsActivated
        {
            get { return m_isActivated; }
            internal set
            {
                if (m_isActivated == value)
                    return;

                m_isActivated = value;
            }
        }

        public bool IsFloat
        {
            get { return m_isFloat; }
            set
            {
                if (m_isFloat == value)
                    return;

                DockState visibleState = CheckDockState(value);

                if (visibleState == DockState.Unknown)
                    throw new InvalidOperationException(Strings.DockContentHandler_IsFloat_InvalidValue);

                SetDockState(IsHidden, visibleState, Pane);
            }
        }

        public bool IsHidden
        {
            get { return m_isHidden; }
            set
            {
                if (m_isHidden == value)
                    return;

                SetDockState(value, VisibleState, Pane);
            }
        }

        public IDockContent NextActive
        {
            get { return m_nextActive; }
            internal set { m_nextActive = value; }
        }

        public DockPane Pane
        {
            get { return IsFloat ? FloatPane : PanelPane; }
            set
            {
                if (Pane == value)
                    return;

                DockPanel.SuspendLayout(true);

                DockPane oldPane = Pane;

                SuspendSetDockState();
                FloatPane = (value == null ? null : (value.IsFloat ? value : FloatPane));
                PanelPane = (value == null ? null : (value.IsFloat ? PanelPane : value));
                ResumeSetDockState(IsHidden, value != null ? value.DockState : DockState.Unknown, oldPane);

                DockPanel.ResumeLayout(true, true);
            }
        }

        public DockPane PanelPane
        {
            get { return m_panelPane; }
            set
            {
                if (m_panelPane == value)
                    return;

                if (value != null)
                {
                    if (value.IsFloat || value.DockPanel != DockPanel)
                        throw new InvalidOperationException(Strings.DockContentHandler_DockPane_InvalidValue);
                }

                DockPane oldPane = Pane;

                if (m_panelPane != null)
                    RemoveFromPane(m_panelPane);
                m_panelPane = value;
                if (m_panelPane != null)
                {
                    m_panelPane.AddContent(Content);
                    SetDockState(IsHidden, IsFloat ? DockState.Float : m_panelPane.DockState, oldPane);
                }
                else
                    SetDockState(IsHidden, DockState.Unknown, oldPane);
            }
        }

        public IDockContent PreviousActive
        {
            get { return m_previousActive; }
            internal set { m_previousActive = value; }
        }

        public DockState ShowHint
        {
            get { return m_showHint; }
            set
            {
                if (!DockHelper.IsDockStateValid(value, DockAreas))
                    throw (new InvalidOperationException(Strings.DockContentHandler_ShowHint_InvalidValue));

                if (m_showHint == value)
                    return;

                m_showHint = value;
            }
        }

        public ContextMenu TabPageContextMenu
        {
            get { return m_tabPageContextMenu; }
            set { m_tabPageContextMenu = value; }
        }

        public ContextMenuStrip TabPageContextMenuStrip
        {
            get { return m_tabPageContextMenuStrip; }
            set { m_tabPageContextMenuStrip = value; }
        }

        public string TabText
        {
            get { return m_tabText == null || m_tabText == "" ? Form.Text : m_tabText; }
            set
            {
                if (m_tabText == value)
                    return;

                m_tabText = value;
                if (Pane != null)
                    Pane.RefreshChanges();
            }
        }

        public string ToolTipText
        {
            get { return m_toolTipText; }
            set { m_toolTipText = value; }
        }

        public DockState VisibleState
        {
            get { return m_visibleState; }
            set
            {
                if (m_visibleState == value)
                    return;

                SetDockState(IsHidden, value, Pane);
            }
        }

        internal IntPtr ActiveWindowHandle
        {
            get { return m_activeWindowHandle; }
            set { m_activeWindowHandle = value; }
        }

        internal IDisposable AutoHideTab
        {
            get { return m_autoHideTab; }
            set { m_autoHideTab = value; }
        }

        internal bool FlagClipWindow
        {
            get { return m_flagClipWindow; }
            set
            {
                if (m_flagClipWindow == value)
                    return;

                m_flagClipWindow = value;
                if (m_flagClipWindow)
                    Form.Region = new Region(Rectangle.Empty);
                else
                    Form.Region = null;
            }
        }

        internal bool IsSuspendSetDockState
        {
            get { return m_countSetDockState != 0; }
        }

        internal string PersistString
        {
            get { return GetPersistStringCallback == null ? Form.GetType().ToString() : GetPersistStringCallback(); }
        }

        private DockState DefaultDockState
        {
            get
            {
                if (ShowHint != DockState.Unknown && ShowHint != DockState.Hidden)
                    return ShowHint;

                if ((DockAreas & DockAreas.Document) != 0)
                    return DockState.Document;
                if ((DockAreas & DockAreas.DockRight) != 0)
                    return DockState.DockRight;
                if ((DockAreas & DockAreas.DockLeft) != 0)
                    return DockState.DockLeft;
                if ((DockAreas & DockAreas.DockBottom) != 0)
                    return DockState.DockBottom;
                if ((DockAreas & DockAreas.DockTop) != 0)
                    return DockState.DockTop;

                return DockState.Unknown;
            }
        }

        private DockState DefaultShowState
        {
            get
            {
                if (ShowHint != DockState.Unknown)
                    return ShowHint;

                if ((DockAreas & DockAreas.Document) != 0)
                    return DockState.Document;
                if ((DockAreas & DockAreas.DockRight) != 0)
                    return DockState.DockRight;
                if ((DockAreas & DockAreas.DockLeft) != 0)
                    return DockState.DockLeft;
                if ((DockAreas & DockAreas.DockBottom) != 0)
                    return DockState.DockBottom;
                if ((DockAreas & DockAreas.DockTop) != 0)
                    return DockState.DockTop;
                if ((DockAreas & DockAreas.Float) != 0)
                    return DockState.Float;

                return DockState.Unknown;
            }
        }

        private EventHandlerList Events
        {
            get { return m_events; }
        }

        private bool IsActiveContentHandler
        {
            get { return Pane != null && Pane.ActiveContent != null && Pane.ActiveContent.DockHandler == this; }
        }

        public void Activate()
        {
            if (DockPanel == null)
                Form.Activate();
            else if (Pane == null)
                Show(DockPanel);
            else
            {
                IsHidden = false;
                Pane.ActiveContent = Content;
                if (DockState == DockState.Document && DockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                {
                    Form.Activate();
                    return;
                }
                else if (DockHelper.IsDockStateAutoHide(DockState))
                {
                    if (DockPanel.ActiveAutoHideContent != Content)
                    {
                        DockPanel.ActiveAutoHideContent = null;
                        return;
                    }
                }

                if (Form.ContainsFocus)
                    return;

                if (Win32Helper.IsRunningOnMono)
                    return;

                DockPanel.ContentFocusManager.Activate(Content);
            }
        }

        [SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters")]
        public DockState CheckDockState(bool isFloat)
        {
            DockState dockState;

            if (isFloat)
            {
                if (!IsDockStateValid(DockState.Float))
                    dockState = DockState.Unknown;
                else
                    dockState = DockState.Float;
            }
            else
            {
                dockState = (PanelPane != null) ? PanelPane.DockState : DefaultDockState;
                if (dockState != DockState.Unknown && !IsDockStateValid(dockState))
                    dockState = DockState.Unknown;
            }

            return dockState;
        }

        public void Close()
        {
            DockPanel dockPanel = DockPanel;
            if (dockPanel != null)
                dockPanel.SuspendLayout(true);
            Form.Close();
            if (dockPanel != null)
                dockPanel.ResumeLayout(true, true);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void GiveUpFocus()
        {
            if (!Win32Helper.IsRunningOnMono)
                DockPanel.ContentFocusManager.GiveUpFocus(Content);
        }

        public void Hide()
        {
            IsHidden = true;
        }

        public bool IsDockStateValid(DockState dockState)
        {
            if (DockPanel != null && dockState == DockState.Document && DockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                return false;
            else
                return DockHelper.IsDockStateValid(dockState, DockAreas);
        }

        public void Show()
        {
            if (DockPanel == null)
                Form.Show();
            else
                Show(DockPanel);
        }

        public void Show(DockPanel dockPanel)
        {
            if (dockPanel == null)
                throw (new ArgumentNullException(Strings.DockContentHandler_Show_NullDockPanel));

            if (DockState == DockState.Unknown)
                Show(dockPanel, DefaultShowState);
            else if (DockPanel != dockPanel)
                Show(dockPanel, DockState == DockState.Hidden ? m_visibleState : DockState);
            else
                Activate();
        }

        public void Show(DockPanel dockPanel, DockState dockState)
        {
            if (dockPanel == null)
                throw (new ArgumentNullException(Strings.DockContentHandler_Show_NullDockPanel));

            if (dockState == DockState.Unknown || dockState == DockState.Hidden)
                throw (new ArgumentException(Strings.DockContentHandler_Show_InvalidDockState));

            dockPanel.SuspendLayout(true);

            DockPanel = dockPanel;

            if (dockState == DockState.Float)
            {
                if (FloatPane == null)
                    Pane = DockPanel.DockPaneFactory.CreateDockPane(Content, DockState.Float, true);
            }
            else if (PanelPane == null)
            {
                DockPane paneExisting = null;
                foreach (DockPane pane in DockPanel.Panes)
                    if (pane.DockState == dockState)
                    {
                        if (paneExisting == null || pane.IsActivated)
                            paneExisting = pane;

                        if (pane.IsActivated)
                            break;
                    }

                if (paneExisting == null)
                    Pane = DockPanel.DockPaneFactory.CreateDockPane(Content, dockState, true);
                else
                    Pane = paneExisting;
            }

            DockState = dockState;
            dockPanel.ResumeLayout(true, true); //we'll resume the layout before activating to ensure that the position
            Activate();                         //and size of the form are finally processed before the form is shown
        }

        [SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters")]
        public void Show(DockPanel dockPanel, Rectangle floatWindowBounds)
        {
            if (dockPanel == null)
                throw (new ArgumentNullException(Strings.DockContentHandler_Show_NullDockPanel));

            dockPanel.SuspendLayout(true);

            DockPanel = dockPanel;
            if (FloatPane == null)
            {
                IsHidden = true;	// to reduce the screen flicker
                FloatPane = DockPanel.DockPaneFactory.CreateDockPane(Content, DockState.Float, false);
                FloatPane.FloatWindow.StartPosition = FormStartPosition.Manual;
            }

            FloatPane.FloatWindow.Bounds = floatWindowBounds;

            Show(dockPanel, DockState.Float);
            Activate();

            dockPanel.ResumeLayout(true, true);
        }

        public void Show(DockPane pane, IDockContent beforeContent)
        {
            if (pane == null)
                throw (new ArgumentNullException(Strings.DockContentHandler_Show_NullPane));

            if (beforeContent != null && pane.Contents.IndexOf(beforeContent) == -1)
                throw (new ArgumentException(Strings.DockContentHandler_Show_InvalidBeforeContent));

            pane.DockPanel.SuspendLayout(true);

            DockPanel = pane.DockPanel;
            Pane = pane;
            pane.SetContentIndex(Content, pane.Contents.IndexOf(beforeContent));
            Show();

            pane.DockPanel.ResumeLayout(true, true);
        }

        public void Show(DockPane previousPane, DockAlignment alignment, double proportion)
        {
            if (previousPane == null)
                throw (new ArgumentException(Strings.DockContentHandler_Show_InvalidPrevPane));

            if (DockHelper.IsDockStateAutoHide(previousPane.DockState))
                throw (new ArgumentException(Strings.DockContentHandler_Show_InvalidPrevPane));

            previousPane.DockPanel.SuspendLayout(true);

            DockPanel = previousPane.DockPanel;
            DockPanel.DockPaneFactory.CreateDockPane(Content, previousPane, alignment, proportion, true);
            Show();

            previousPane.DockPanel.ResumeLayout(true, true);
        }

        internal DockPaneStripBase.Tab GetTab(DockPaneStripBase dockPaneStrip)
        {
            if (m_tab == null)
                m_tab = dockPaneStrip.CreateTab(Content);

            return m_tab;
        }

        internal void SetDockState(bool isHidden, DockState visibleState, DockPane oldPane)
        {
            if (IsSuspendSetDockState)
                return;

            if (DockPanel == null && visibleState != DockState.Unknown)
                throw new InvalidOperationException(Strings.DockContentHandler_SetDockState_NullPanel);

            if (visibleState == DockState.Hidden || (visibleState != DockState.Unknown && !IsDockStateValid(visibleState)))
                throw new InvalidOperationException(Strings.DockContentHandler_SetDockState_InvalidState);

            DockPanel dockPanel = DockPanel;
            if (dockPanel != null)
                dockPanel.SuspendLayout(true);

            SuspendSetDockState();

            DockState oldDockState = DockState;

            if (m_isHidden != isHidden || oldDockState == DockState.Unknown)
            {
                m_isHidden = isHidden;
            }
            m_visibleState = visibleState;
            m_dockState = isHidden ? DockState.Hidden : visibleState;

            if (visibleState == DockState.Unknown)
                Pane = null;
            else
            {
                m_isFloat = (m_visibleState == DockState.Float);

                if (Pane == null)
                    Pane = DockPanel.DockPaneFactory.CreateDockPane(Content, visibleState, true);
                else if (Pane.DockState != visibleState)
                {
                    if (Pane.Contents.Count == 1)
                        Pane.SetDockState(visibleState);
                    else
                        Pane = DockPanel.DockPaneFactory.CreateDockPane(Content, visibleState, true);
                }
            }

            if (Form.ContainsFocus)
            {
                if (DockState == DockState.Hidden || DockState == DockState.Unknown)
                {
                    if (!Win32Helper.IsRunningOnMono)
                    {
                        DockPanel.ContentFocusManager.GiveUpFocus(Content);
                    }
                }
            }

            SetPaneAndVisible(Pane);

            if (oldPane != null && !oldPane.IsDisposed && oldDockState == oldPane.DockState)
                RefreshDockPane(oldPane);

            if (Pane != null && DockState == Pane.DockState)
            {
                if ((Pane != oldPane) ||
                    (Pane == oldPane && oldDockState != oldPane.DockState))
                {
                    // Avoid early refresh of hidden AutoHide panes
                    if ((Pane.DockWindow == null || Pane.DockWindow.Visible || Pane.IsHidden) && !Pane.IsAutoHide)
                    {
                        RefreshDockPane(Pane);
                    }
                }
            }

            if (oldDockState != DockState)
            {
                if (DockState == DockState.Hidden || DockState == DockState.Unknown ||
                    DockHelper.IsDockStateAutoHide(DockState))
                {
                    if (!Win32Helper.IsRunningOnMono)
                    {
                        DockPanel.ContentFocusManager.RemoveFromList(Content);
                    }
                }
                else if (!Win32Helper.IsRunningOnMono)
                {
                    DockPanel.ContentFocusManager.AddToList(Content);
                }

                ResetAutoHidePortion(oldDockState, DockState);
                OnDockStateChanged(EventArgs.Empty);
            }

            ResumeSetDockState();

            if (dockPanel != null)
                dockPanel.ResumeLayout(true, true);
        }

        internal void SetPaneAndVisible(DockPane pane)
        {
            SetPane(pane);
            SetVisible();
        }

        internal void SetVisible()
        {
            bool visible;

            if (IsHidden)
                visible = false;
            else if (Pane != null && Pane.DockState == DockState.Document && DockPanel.DocumentStyle == DocumentStyle.DockingMdi)
                visible = true;
            else if (Pane != null && Pane.ActiveContent == Content)
                visible = true;
            else if (Pane != null && Pane.ActiveContent != Content)
                visible = false;
            else
                visible = Form.Visible;

            if (Form.Visible != visible)
                Form.Visible = visible;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DockPanel = null;
                if (m_autoHideTab != null)
                    m_autoHideTab.Dispose();
                if (m_tab != null)
                    m_tab.Dispose();

                Form.Disposed -= new EventHandler(Form_Disposed);
                Form.TextChanged -= new EventHandler(Form_TextChanged);
                m_events.Dispose();
            }
        }

        private static void RefreshDockPane(DockPane pane)
        {
            pane.RefreshChanges();
            pane.ValidateActiveContent();
        }

        private void Form_Disposed(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Form_TextChanged(object sender, EventArgs e)
        {
            if (DockHelper.IsDockStateAutoHide(DockState))
                DockPanel.RefreshAutoHideStrip();
            else if (Pane != null)
            {
                if (Pane.FloatWindow != null)
                    Pane.FloatWindow.SetText();
                Pane.RefreshChanges();
            }
        }

        private void RemoveFromPane(DockPane pane)
        {
            pane.RemoveContent(Content);
            SetPane(null);
            if (pane.Contents.Count == 0)
                pane.Dispose();
        }

        private void ResetAutoHidePortion(DockState oldState, DockState newState)
        {
            if (oldState == newState || DockHelper.ToggleAutoHideState(oldState) == newState)
                return;

            switch (newState)
            {
                case DockState.DockTop:
                case DockState.DockTopAutoHide:
                    AutoHidePortion = DockPanel.DockTopPortion;
                    break;

                case DockState.DockLeft:
                case DockState.DockLeftAutoHide:
                    AutoHidePortion = DockPanel.DockLeftPortion;
                    break;

                case DockState.DockBottom:
                case DockState.DockBottomAutoHide:
                    AutoHidePortion = DockPanel.DockBottomPortion;
                    break;

                case DockState.DockRight:
                case DockState.DockRightAutoHide:
                    AutoHidePortion = DockPanel.DockRightPortion;
                    break;
            }
        }

        private void ResumeSetDockState()
        {
            m_countSetDockState--;
            if (m_countSetDockState < 0)
                m_countSetDockState = 0;
        }

        private void ResumeSetDockState(bool isHidden, DockState visibleState, DockPane oldPane)
        {
            ResumeSetDockState();
            SetDockState(isHidden, visibleState, oldPane);
        }

        private void SetPane(DockPane pane)
        {
            if (pane != null && pane.DockState == DockState.Document && DockPanel.DocumentStyle == DocumentStyle.DockingMdi)
            {
                if (Form.Parent is DockPane)
                    SetParent(null);
                if (Form.MdiParent != DockPanel.ParentForm)
                {
                    FlagClipWindow = true;
                    Form.MdiParent = DockPanel.ParentForm;
                }
            }
            else
            {
                FlagClipWindow = true;
                if (Form.MdiParent != null)
                    Form.MdiParent = null;
                if (Form.TopLevel)
                    Form.TopLevel = false;
                SetParent(pane);
            }
        }

        private void SetParent(Control value)
        {
            if (Form.Parent == value)
                return;

            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Workaround of .Net Framework bug:
            // Change the parent of a control with focus may result in the first
            // MDI child form get activated.
            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            bool bRestoreFocus = false;
            if (Form.ContainsFocus)
            {
                // Suggested as a fix for a memory leak by bugreports
                if (value == null && !IsFloat)
                {
                    if (!Win32Helper.IsRunningOnMono)
                    {
                        DockPanel.ContentFocusManager.GiveUpFocus(this.Content);
                    }
                }
                else
                {
                    DockPanel.SaveFocus();
                    bRestoreFocus = true;
                }
            }

            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Form.Parent = value;

            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Workaround of .Net Framework bug:
            // Change the parent of a control with focus may result in the first
            // MDI child form get activated.
            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if (bRestoreFocus)
                Activate();

            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }

        private void SuspendSetDockState()
        {
            m_countSetDockState++;
        }

        #region Events

        private static readonly object DockStateChangedEvent = new object();

        public event EventHandler DockStateChanged
        {
            add { Events.AddHandler(DockStateChangedEvent, value); }
            remove { Events.RemoveHandler(DockStateChangedEvent, value); }
        }

        protected virtual void OnDockStateChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[DockStateChangedEvent];
            if (handler != null)
                handler(this, e);
        }

        #endregion Events

        #region IDockDragSource Members

        Control IDragSource.DragControl
        {
            get { return Form; }
        }

        public void DockTo(DockPane pane, DockStyle dockStyle, int contentIndex)
        {
            if (dockStyle == DockStyle.Fill)
            {
                bool samePane = (Pane == pane);
                if (!samePane)
                    Pane = pane;

                if (contentIndex == -1 || !samePane)
                    pane.SetContentIndex(Content, contentIndex);
                else
                {
                    DockContentCollection contents = pane.Contents;
                    int oldIndex = contents.IndexOf(Content);
                    int newIndex = contentIndex;
                    if (oldIndex < newIndex)
                    {
                        newIndex += 1;
                        if (newIndex > contents.Count - 1)
                            newIndex = -1;
                    }
                    pane.SetContentIndex(Content, newIndex);
                }
            }
            else
            {
                DockPane paneFrom = DockPanel.DockPaneFactory.CreateDockPane(Content, pane.DockState, true);
                INestedPanesContainer container = pane.NestedPanesContainer;
                if (dockStyle == DockStyle.Left)
                    paneFrom.DockTo(container, pane, DockAlignment.Left, 0.5);
                else if (dockStyle == DockStyle.Right)
                    paneFrom.DockTo(container, pane, DockAlignment.Right, 0.5);
                else if (dockStyle == DockStyle.Top)
                    paneFrom.DockTo(container, pane, DockAlignment.Top, 0.5);
                else if (dockStyle == DockStyle.Bottom)
                    paneFrom.DockTo(container, pane, DockAlignment.Bottom, 0.5);

                paneFrom.DockState = pane.DockState;
            }
        }

        public void DockTo(DockPanel panel, DockStyle dockStyle)
        {
            if (panel != DockPanel)
                throw new ArgumentException(Strings.IDockDragSource_DockTo_InvalidPanel, "panel");

            DockPane pane;

            if (dockStyle == DockStyle.Top)
                pane = DockPanel.DockPaneFactory.CreateDockPane(Content, DockState.DockTop, true);
            else if (dockStyle == DockStyle.Bottom)
                pane = DockPanel.DockPaneFactory.CreateDockPane(Content, DockState.DockBottom, true);
            else if (dockStyle == DockStyle.Left)
                pane = DockPanel.DockPaneFactory.CreateDockPane(Content, DockState.DockLeft, true);
            else if (dockStyle == DockStyle.Right)
                pane = DockPanel.DockPaneFactory.CreateDockPane(Content, DockState.DockRight, true);
            else if (dockStyle == DockStyle.Fill)
                pane = DockPanel.DockPaneFactory.CreateDockPane(Content, DockState.Document, true);
            else
                return;
        }

        public void FloatAt(Rectangle floatWindowBounds)
        {
            // TODO: where is the pane used?
            DockPane pane = DockPanel.DockPaneFactory.CreateDockPane(Content, floatWindowBounds, true);
        }

        Rectangle IDockDragSource.BeginDrag(Point ptMouse)
        {
            Size size;
            DockPane floatPane = this.FloatPane;
            if (DockState == DockState.Float || floatPane == null || floatPane.FloatWindow.NestedPanes.Count != 1)
                size = DockPanel.DefaultFloatWindowSize;
            else
                size = floatPane.FloatWindow.Size;

            Point location;
            Rectangle rectPane = Pane.ClientRectangle;
            if (DockState == DockState.Document)
            {
                if (Pane.DockPanel.DocumentTabStripLocation == DocumentTabStripLocation.Bottom)
                    location = new Point(rectPane.Left, rectPane.Bottom - size.Height);
                else
                    location = new Point(rectPane.Left, rectPane.Top);
            }
            else
            {
                location = new Point(rectPane.Left, rectPane.Bottom);
                location.Y -= size.Height;
            }
            location = Pane.PointToScreen(location);

            if (ptMouse.X > location.X + size.Width)
                location.X += ptMouse.X - (location.X + size.Width) + Measures.SplitterSize;

            return new Rectangle(location, size);
        }

        bool IDockDragSource.CanDockTo(DockPane pane)
        {
            if (!IsDockStateValid(pane.DockState))
                return false;

            if (Pane == pane && pane.DisplayingContents.Count == 1)
                return false;

            return true;
        }

        void IDockDragSource.EndDrag()
        {
        }

        #endregion IDockDragSource Members
    }
}