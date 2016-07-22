using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
    public abstract class DockOutlineBase
    {
        private int m_contentIndex;

        private DockStyle m_dock;

        private Control m_dockTo;

        private bool m_flagTestDrop = false;

        private Rectangle m_floatWindowBounds;

        private int m_oldContentIndex;

        private DockStyle m_oldDock;

        private Control m_oldDockTo;

        private Rectangle m_oldFloatWindowBounds;

        public DockOutlineBase()
        {
            Init();
        }

        public int ContentIndex
        {
            get { return m_contentIndex; }
        }

        public DockStyle Dock
        {
            get { return m_dock; }
        }

        public Control DockTo
        {
            get { return m_dockTo; }
        }

        public bool FlagFullEdge
        {
            get { return m_contentIndex != 0; }
        }

        public bool FlagTestDrop
        {
            get { return m_flagTestDrop; }
            set { m_flagTestDrop = value; }
        }

        public Rectangle FloatWindowBounds
        {
            get { return m_floatWindowBounds; }
        }

        protected int OldContentIndex
        {
            get { return m_oldContentIndex; }
        }

        protected DockStyle OldDock
        {
            get { return m_oldDock; }
        }

        protected Control OldDockTo
        {
            get { return m_oldDockTo; }
        }

        protected Rectangle OldFloatWindowBounds
        {
            get { return m_oldFloatWindowBounds; }
        }

        protected bool SameAsOldValue
        {
            get
            {
                return FloatWindowBounds == OldFloatWindowBounds &&
                    DockTo == OldDockTo &&
                    Dock == OldDock &&
                    ContentIndex == OldContentIndex;
            }
        }

        public void Close()
        {
            OnClose();
        }

        public void Show()
        {
            SaveOldValues();
            SetValues(Rectangle.Empty, null, DockStyle.None, -1);
            TestChange();
        }

        public void Show(DockPane pane, DockStyle dock)
        {
            SaveOldValues();
            SetValues(Rectangle.Empty, pane, dock, -1);
            TestChange();
        }

        public void Show(DockPane pane, int contentIndex)
        {
            SaveOldValues();
            SetValues(Rectangle.Empty, pane, DockStyle.Fill, contentIndex);
            TestChange();
        }

        public void Show(DockPanel dockPanel, DockStyle dock, bool fullPanelEdge)
        {
            SaveOldValues();
            SetValues(Rectangle.Empty, dockPanel, dock, fullPanelEdge ? -1 : 0);
            TestChange();
        }

        public void Show(Rectangle floatWindowBounds)
        {
            SaveOldValues();
            SetValues(floatWindowBounds, null, DockStyle.None, -1);
            TestChange();
        }

        protected abstract void OnClose();

        protected abstract void OnShow();

        private void Init()
        {
            SetValues(Rectangle.Empty, null, DockStyle.None, -1);
            SaveOldValues();
        }

        private void SaveOldValues()
        {
            m_oldDockTo = m_dockTo;
            m_oldDock = m_dock;
            m_oldContentIndex = m_contentIndex;
            m_oldFloatWindowBounds = m_floatWindowBounds;
        }

        private void SetValues(Rectangle floatWindowBounds, Control dockTo, DockStyle dock, int contentIndex)
        {
            m_floatWindowBounds = floatWindowBounds;
            m_dockTo = dockTo;
            m_dock = dock;
            m_contentIndex = contentIndex;
            FlagTestDrop = true;
        }

        private void TestChange()
        {
            if (m_floatWindowBounds != m_oldFloatWindowBounds ||
                m_dockTo != m_oldDockTo ||
                m_dock != m_oldDock ||
                m_contentIndex != m_oldContentIndex)
                OnShow();
        }
    }
}