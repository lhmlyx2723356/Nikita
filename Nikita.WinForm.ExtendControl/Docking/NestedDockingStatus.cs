using System;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl
{
    public sealed class NestedDockingStatus
    {
        private DockAlignment m_alignment = DockAlignment.Left;

        private DockAlignment m_displayingAlignment = DockAlignment.Left;

        private DockPane m_displayingPreviousPane = null;

        private double m_displayingProportion = 0.5;

        private DockPane m_dockPane = null;

        private bool m_isDisplaying = false;

        private Rectangle m_logicalBounds = Rectangle.Empty;

        private NestedPaneCollection m_nestedPanes = null;

        private Rectangle m_paneBounds = Rectangle.Empty;

        private DockPane m_previousPane = null;

        private double m_proportion = 0.5;

        private Rectangle m_splitterBounds = Rectangle.Empty;

        internal NestedDockingStatus(DockPane pane)
        {
            m_dockPane = pane;
        }

        public DockAlignment Alignment
        {
            get { return m_alignment; }
        }

        public DockAlignment DisplayingAlignment
        {
            get { return m_displayingAlignment; }
        }

        public DockPane DisplayingPreviousPane
        {
            get { return m_displayingPreviousPane; }
        }

        public double DisplayingProportion
        {
            get { return m_displayingProportion; }
        }

        public DockPane DockPane
        {
            get { return m_dockPane; }
        }

        public bool IsDisplaying
        {
            get { return m_isDisplaying; }
        }

        public Rectangle LogicalBounds
        {
            get { return m_logicalBounds; }
        }

        public NestedPaneCollection NestedPanes
        {
            get { return m_nestedPanes; }
        }

        public Rectangle PaneBounds
        {
            get { return m_paneBounds; }
        }

        public DockPane PreviousPane
        {
            get { return m_previousPane; }
        }

        public double Proportion
        {
            get { return m_proportion; }
        }

        public Rectangle SplitterBounds
        {
            get { return m_splitterBounds; }
        }

        internal void SetDisplayingBounds(Rectangle logicalBounds, Rectangle paneBounds, Rectangle splitterBounds)
        {
            m_logicalBounds = logicalBounds;
            m_paneBounds = paneBounds;
            m_splitterBounds = splitterBounds;
        }

        internal void SetDisplayingStatus(bool isDisplaying, DockPane displayingPreviousPane, DockAlignment displayingAlignment, double displayingProportion)
        {
            m_isDisplaying = isDisplaying;
            m_displayingPreviousPane = displayingPreviousPane;
            m_displayingAlignment = displayingAlignment;
            m_displayingProportion = displayingProportion;
        }

        internal void SetStatus(NestedPaneCollection nestedPanes, DockPane previousPane, DockAlignment alignment, double proportion)
        {
            m_nestedPanes = nestedPanes;
            m_previousPane = previousPane;
            m_alignment = alignment;
            m_proportion = proportion;
        }
    }
}