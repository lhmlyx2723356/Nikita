//---------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using System.Diagnostics;

namespace Nikita.WinForm.ExtendControl
{
	/// <summary>
	/// Summary description for TreeGridCell.
	/// </summary>
	public class TreeGridCell:DataGridViewTextBoxCell
	{
		private const int IndentWidth = 20;
		private const int IndentMargin = 5;
		private int _glyphWidth;
		private int _calculatedLeftPadding;
		internal bool IsSited;
		private Padding _previousPadding;
		private int _imageWidth, _imageHeight, _imageHeightOffset;
		private Rectangle _lastKnownGlyphRect;

		public TreeGridCell()
		{			
			_glyphWidth = 15;
			_calculatedLeftPadding = 0;
			this.IsSited = false;

		}

        public override object Clone()
        {
			TreeGridCell c = (TreeGridCell)base.Clone();
			
            c._glyphWidth = this._glyphWidth;
            c._calculatedLeftPadding = this._calculatedLeftPadding;

            return c;
        }

		internal protected virtual void UnSited()
		{
			// The row this cell is in is being removed from the grid.
			this.IsSited = false;
			this.Style.Padding = this._previousPadding;
		}

		internal protected virtual void Sited()
		{
			// when we are added to the DGV we can realize our style
			this.IsSited = true;

			// remember what the previous padding size is so it can be restored when unsiting
			this._previousPadding = this.Style.Padding;

			this.UpdateStyle();
		}		

		internal protected virtual void UpdateStyle(){
			// styles shouldn't be modified when we are not sited.
			if (this.IsSited == false) return;

			int level = this.Level;

			Padding p = this._previousPadding;
			Size preferredSize;

			using (Graphics g = this.OwningNode._grid.CreateGraphics() ) {
				preferredSize =this.GetPreferredSize(g, this.InheritedStyle, this.RowIndex, new Size(0, 0));
			}

			Image image = this.OwningNode.Image;

			if (image != null)
			{
				// calculate image size
				_imageWidth = image.Width+2;
				_imageHeight = image.Height+2;

			}
			else
			{
				_imageWidth = _glyphWidth;
				_imageHeight = 0;
			}

			// TODO: Make this cleaner
			if (preferredSize.Height < _imageHeight)
			{

				this.Style.Padding = new Padding(p.Left + (level * IndentWidth) + _imageWidth + IndentMargin,
												 p.Top + (_imageHeight / 2), p.Right, p.Bottom + (_imageHeight / 2));
				_imageHeightOffset = 2;// (_imageHeight - preferredSize.Height) / 2;
			}
			else
			{
				this.Style.Padding = new Padding(p.Left + (level * IndentWidth) + _imageWidth + IndentMargin,
												 p.Top , p.Right, p.Bottom );

			}

			_calculatedLeftPadding = ((level - 1) * _glyphWidth) + _imageWidth + IndentMargin;
		}

		public int Level
		{
			get
			{
				TreeGridNode row = this.OwningNode;
				if (row != null)
				{
					return row.Level;
				}
				else
					return -1;
			}
		}

		protected virtual int GlyphMargin
		{
			get
			{
				return ((this.Level - 1) * IndentWidth) + IndentMargin;
			}
		}

		protected virtual int GlyphOffset
		{
			get
			{
				return ((this.Level - 1) * IndentWidth);
			}
		}

		protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
		{

            TreeGridNode node = this.OwningNode;
            if (node == null) return;

            Image image = node.Image;

            if (this._imageHeight == 0 && image != null) this.UpdateStyle();

			// paint the cell normally
			base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

            // TODO: Indent width needs to take image size into account
			Rectangle glyphRect = new Rectangle(cellBounds.X + this.GlyphMargin, cellBounds.Y, IndentWidth, cellBounds.Height - 1);
			int glyphHalf = glyphRect.Width / 2;

			//TODO: This painting code needs to be rehashed to be cleaner
			int level = this.Level;

            //TODO: Rehash this to take different Imagelayouts into account. This will speed up drawing
			//		for images of the same size (ImageLayout.None)
			if (image != null)
			{
				Point pp;
				if (_imageHeight > cellBounds.Height)
                    pp = new Point(glyphRect.X + this._glyphWidth, cellBounds.Y + _imageHeightOffset);
				else
                    pp = new Point(glyphRect.X + this._glyphWidth, (cellBounds.Height / 2 - _imageHeight / 2) + cellBounds.Y);

				// Graphics container to push/pop changes. This enables us to set clipping when painting
				// the cell's image -- keeps it from bleeding outsize of cells.
				System.Drawing.Drawing2D.GraphicsContainer gc = graphics.BeginContainer();
				{
					graphics.SetClip(cellBounds);
					graphics.DrawImageUnscaled(image, pp);
				}
				graphics.EndContainer(gc);
			}

			// Paint tree lines			
            if (node._grid.ShowLines)
            {
                using (Pen linePen = new Pen(SystemBrushes.ControlDark, 1.0f))
                {
                    linePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    bool isLastSibling = node.IsLastSibling;
                    bool isFirstSibling = node.IsFirstSibling;
                    if (node.Level == 1)
                    {
                        // the Root nodes display their lines differently
                        if (isFirstSibling && isLastSibling)
                        {
                            // only node, both first and last. Just draw horizontal line
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.Right, cellBounds.Top + cellBounds.Height / 2);
                        }
                        else if (isLastSibling)
                        {
                            // last sibling doesn't draw the line extended below. Paint horizontal then vertical
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.Right, cellBounds.Top + cellBounds.Height / 2);
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2);
                        }
                        else if (isFirstSibling)
                        {
                            // first sibling doesn't draw the line extended above. Paint horizontal then vertical
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.Right, cellBounds.Top + cellBounds.Height / 2);
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.X + 4, cellBounds.Bottom);
                        }
                        else
                        {
                            // normal drawing draws extended from top to bottom. Paint horizontal then vertical
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.Right, cellBounds.Top + cellBounds.Height / 2);
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top, glyphRect.X + 4, cellBounds.Bottom);
                        }
                    }
                    else
                    {
                        if (isLastSibling)
                        {
                            // last sibling doesn't draw the line extended below. Paint horizontal then vertical
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.Right, cellBounds.Top + cellBounds.Height / 2);
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2);
                        }
                        else
                        {
                            // normal drawing draws extended from top to bottom. Paint horizontal then vertical
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.Right, cellBounds.Top + cellBounds.Height / 2);
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top, glyphRect.X + 4, cellBounds.Bottom);
                        }

                        // paint lines of previous levels to the root
                        TreeGridNode previousNode = node.Parent;
                        int horizontalStop = (glyphRect.X + 4) - IndentWidth;

                        while (!previousNode.IsRoot)
                        {
                            if (previousNode.HasChildren && !previousNode.IsLastSibling)
                            {
                                // paint vertical line
                                graphics.DrawLine(linePen, horizontalStop, cellBounds.Top, horizontalStop, cellBounds.Bottom);
                            }
                            previousNode = previousNode.Parent;
                            horizontalStop = horizontalStop - IndentWidth;
                        }
                    }

                }
            }

            if (node.HasChildren || node._grid.VirtualNodes)
            {
                // Paint node glyphs				
                if (node.IsExpanded)
                    node._grid.ROpen.DrawBackground(graphics, new Rectangle(glyphRect.X, glyphRect.Y + (glyphRect.Height / 2) - 4, 10, 10));
                else
                    node._grid.RClosed.DrawBackground(graphics, new Rectangle(glyphRect.X, glyphRect.Y + (glyphRect.Height / 2) - 4, 10, 10));
            }


		}
        protected override void OnMouseUp(DataGridViewCellMouseEventArgs e)
        {
            base.OnMouseUp(e);

            TreeGridNode node = this.OwningNode;
            if (node != null)
                node._grid.InExpandCollapseMouseCapture = false;
        }
		protected override void OnMouseDown(DataGridViewCellMouseEventArgs e)
		{
			if (e.Location.X > this.InheritedStyle.Padding.Left)
			{
				base.OnMouseDown(e);
			}
			else
			{
				// Expand the node
				//TODO: Calculate more precise location
				TreeGridNode node = this.OwningNode;
                if (node != null)
				{
                    node._grid.InExpandCollapseMouseCapture = true;
                    if (node.IsExpanded)
                        node.Collapse();
					else
                        node.Expand();
                }
			}
		}
		public TreeGridNode OwningNode
		{
			get { return base.OwningRow as TreeGridNode; }
		}
	}

	public class TreeGridColumn : DataGridViewTextBoxColumn
	{
		internal Image _defaultNodeImage;
		
		public TreeGridColumn()
		{		
			this.CellTemplate = new TreeGridCell();
		}

		// Need to override Clone for design-time support.
		public override object Clone()
		{
			TreeGridColumn c = (TreeGridColumn)base.Clone();
			c._defaultNodeImage = this._defaultNodeImage;
			return c;
		}

		public Image DefaultNodeImage
		{
			get { return _defaultNodeImage; }
			set { _defaultNodeImage = value; }
		}
	}
}
