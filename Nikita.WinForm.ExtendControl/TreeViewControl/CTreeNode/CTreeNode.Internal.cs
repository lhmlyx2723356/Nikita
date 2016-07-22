using System;
using System.Collections.Generic;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl
{
    public partial class CTreeNode
    {
        #region Properties

        /// <summary>
        /// The list of lines for this node.
        /// </summary>
        internal List<Line> Lines { get; set; }

        /// <summary>
        /// The location of this node.
        /// </summary>
        internal Point Location { get; set; }

        /// <summary>
        /// The plus-sign (+) or minus-sign (-) button's area for this node.
        /// </summary>
        internal NodePlusMinus PlusMinus { get; set; }

        //private Size _size;
        /// <summary>
        /// The size of this node.
        /// </summary>
        internal Size Size
        {
            get
            {
                var control = Control as NodeControl;
                if (control != null) return control.Area.Size;
                return Control.Size;
            }
            //set { _size = value; }
        }

        internal struct Line
        {
            internal Point Point1;

            internal Point Point2;

            internal Line(Point p1, Point p2)
            {
                Point1 = p1;
                Point2 = p2;
            }
        }

        internal class NodePlusMinus
        {
            private const int MinCursorDistance = 3;
            private Rectangle _underMouseArea;

            internal NodePlusMinus(Rectangle plusMinusArea)
            {
                Location = plusMinusArea.Location;
                _underMouseArea = plusMinusArea;
                _underMouseArea.Inflate(MinCursorDistance, MinCursorDistance);
            }

            internal Point Location { get; private set; }

            internal bool IsUnderMouse(Point cursorLocation)
            {
                if (_underMouseArea.Contains(cursorLocation)) return true;
                else return false;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Calculates fullBounds of this node and all child nodes.
        /// </summary>
        internal void CalculateBounds()
        {
            _boundsSubtree = new Rectangle(Location, Size);
            foreach (CTreeNode child in Nodes)
            {
                if (child.Visible)
                {
                    child.CalculateBounds();
                    _boundsSubtree = Rectangle.Union(child.BoundsSubtree, _boundsSubtree);
                }
            }
        }

        /// <summary>
        /// Calculates coordinats for lines of this node and all child nodes.
        /// </summary>
        /// <param name="parentLineCalc"></param>
        /// <param name="commonLineCalc"></param>
        /// <param name="childLineCalc"></param>
        internal void CalculateLines(Func<CTreeNode, Line> parentLineCalc, Func<CTreeNodeCollection, Line> commonLineCalc, Func<CTreeNode, Line> childLineCalc)
        {
            if (Visible && IsExpanded)
            {
                if (Nodes.Count > 0)
                {
                    Lines = new List<Line> {parentLineCalc(this)};
                    Lines.AddRange(Nodes.GetLines(commonLineCalc, childLineCalc));
                    foreach (CTreeNode child in Nodes) child.CalculateLines(parentLineCalc, commonLineCalc, childLineCalc);
                }
                else Lines = null;//?
            }
        }

        /// <summary>
        /// Calculates coordinats for PlusMinus button of this node and all child nodes.
        /// </summary>
        /// <param name="plusMinusCalc"></param>
        /// <param name="needRootPlusMinus"></param>
        internal void CalculatePlusMinus(Func<CTreeNode, Point> plusMinusCalc, bool needRootPlusMinus)
        {
            if (Visible && Nodes.Count > 0)
            {
                if (needRootPlusMinus)
                {
                    Point locationPlusMinus = plusMinusCalc(this);
                    locationPlusMinus.Offset(-OwnerCTreeView.PlusMinus.Size.Width / 2, -OwnerCTreeView.PlusMinus.Size.Width / 2);
                    PlusMinus = new NodePlusMinus(new Rectangle(locationPlusMinus, OwnerCTreeView.PlusMinus.Size));
                }
                else PlusMinus = null;
                foreach (CTreeNode child in Nodes) child.CalculatePlusMinus(plusMinusCalc, true);
            }
        }

        /// <summary>
        /// Calculate locations of this node and all child nodes for the CTreeViewDrawStyle.LinearTree.
        /// </summary>
        /// <param name="currentLocation"></param>
        /// <returns></returns>
        internal Point NextLocation(Point currentLocation)
        {
            if (Visible || !OwnerCTreeView.MinimizeCollapsed)
            {
                Location = currentLocation;
                currentLocation.Offset(OwnerCTreeView.IndentDepth, Control.Height + OwnerCTreeView.IndentWidth);
                foreach (CTreeNode child in Nodes)
                {
                    currentLocation.Y = child.NextLocation(currentLocation).Y;
                }
            }
            return currentLocation;
        }

        /// <summary>
        /// Calculate locations of this node and all child nodes for the CTreeViewDrawStyle.VerticalDiagram.
        /// </summary>
        /// <param name="currentXMax"></param>
        /// <param name="currentY"></param>
        /// <returns></returns>
        internal int NextXMax(int currentXMax, int currentY)
        {
            if (Nodes.Count > 0 && (IsExpanded || !OwnerCTreeView.MinimizeCollapsed))
            {
                foreach (CTreeNode child in Nodes)
                {
                    currentXMax = child.NextXMax(currentXMax, currentY + Bounds.Height + OwnerCTreeView.IndentDepth);
                }
                int minX = FirstNode.Location.X + FirstNode.Bounds.Width / 2;
                int maxX = LastNode.Location.X + LastNode.Bounds.Width / 2;
                Location = new Point((minX + maxX) / 2 - Bounds.Width / 2, currentY);
            }
            else
            {
                Location = new Point(currentXMax, currentY);
                currentXMax += Bounds.Width + OwnerCTreeView.IndentWidth;
            }
            return currentXMax;
        }

        /// <summary>
        /// Calculate locations of this node and all child nodes for the CTreeViewDrawStyle.HorizontalDiagram.
        /// </summary>
        /// <param name="currentX"></param>
        /// <param name="currentYMax"></param>
        /// <returns></returns>
        internal int NextYMax(int currentX, int currentYMax)
        {
            int nextYMax = currentYMax;
            if (Nodes.Count > 0 && (IsExpanded || !OwnerCTreeView.MinimizeCollapsed))
            {
                foreach (CTreeNode child in Nodes)
                {
                    nextYMax = child.NextYMax(currentX + Bounds.Width + OwnerCTreeView.IndentDepth, nextYMax);
                }
                int minY = FirstNode.Location.Y + FirstNode.Bounds.Height / 2;
                int maxY = LastNode.Location.Y + LastNode.Bounds.Height / 2;
                if (nextYMax - currentYMax - OwnerCTreeView.IndentWidth < Bounds.Height)
                {
                    //
                }
                Location = new Point(currentX, (minY + maxY) / 2 - Bounds.Height / 2);
            }
            else
            {
                Location = new Point(currentX, nextYMax);
                nextYMax += Bounds.Height + OwnerCTreeView.IndentWidth;
            }
            return nextYMax;
        }

        private void BeginUpdateCTreeView()
        {
            if (OwnerCTreeView != null) OwnerCTreeView.BeginUpdate();
        }

        private void EndUpdateCTreeView()
        {
            if (OwnerCTreeView != null) OwnerCTreeView.EndUpdate();
        }

        #endregion Methods
    }
}