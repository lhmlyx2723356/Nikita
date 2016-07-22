using System;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl
{
    /// <summary>
    /// The DragAndDrop mode of CTreeView.
    /// </summary>
    public enum CTreeViewDragAndDropMode
    {
        /*CopyReplaceReorder,*/
        ReplaceReorder, Reorder, Nothing
    }

    /// <summary>
    /// The draw style of CTreeView.
    /// </summary>
    public enum CTreeViewDrawStyle
    {
        LinearTree, HorizontalDiagram, VerticalDiagram
    }

    /// <summary>
    /// The selection mode of CTreeView.
    /// </summary>
    public enum CTreeViewSelectionMode
    {
        Multi, MultiSameParent, Single, None
    }

    /// <summary>
    /// The bitmaps for plus and minus buttons of nodes.
    /// </summary>
    public struct CTreeViewPlusMinus
    {
        private Bitmap _Minus;
        private Bitmap _Plus;
        private Size _Size;

        public CTreeViewPlusMinus(Bitmap plus, Bitmap minus)
        {
            _Size = plus.Size;
            if (_Size != minus.Size) throw new ArgumentException("Images are of different sizes");
            _Plus = plus;
            _Minus = minus;
        }

        public Bitmap Minus
        {
            get { return _Minus; }
        }

        public Bitmap Plus
        {
            get { return _Plus; }
        }

        internal Size Size
        {
            get { return _Size; }
        }
    }
}