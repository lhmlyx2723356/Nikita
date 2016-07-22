using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
    public interface IDockContent
    {
        DockContentHandler DockHandler { get; }

        void OnActivated(EventArgs e);

        void OnDeactivate(EventArgs e);
    }

    public interface INestedPanesContainer
    {
        Rectangle DisplayingRectangle { get; }
        DockState DockState { get; }
        bool IsFloat { get; }
        NestedPaneCollection NestedPanes { get; }
        VisibleNestedPaneCollection VisibleNestedPanes { get; }
    }

    internal interface IDockDragSource : IDragSource
    {
        Rectangle BeginDrag(Point ptMouse);

        bool CanDockTo(DockPane pane);

        void DockTo(DockPane pane, DockStyle dockStyle, int contentIndex);

        void DockTo(DockPanel panel, DockStyle dockStyle);

        void EndDrag();

        void FloatAt(Rectangle floatWindowBounds);

        bool IsDockStateValid(DockState dockState);
    }

    internal interface IDragSource
    {
        Control DragControl { get; }
    }

    internal interface ISplitterDragSource : IDragSource
    {
        Rectangle DragLimitBounds { get; }

        bool IsVertical { get; }

        void BeginDrag(Rectangle rectSplitter);

        void EndDrag();

        void MoveSplitter(int offset);
    }
}