// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.TextAreaMouseHandler
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Document;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
  public class TextAreaMouseHandler
  {
    private static readonly Point nilPoint = new Point(-1, -1);
    private Point mousepos = new Point(0, 0);
    private Point mousedownpos = TextAreaMouseHandler.nilPoint;
    private Point lastmousedownpos = TextAreaMouseHandler.nilPoint;
    private Point selectionStartPos = TextAreaMouseHandler.nilPoint;
    private DateTime lastTime = DateTime.Now;
    private Point minSelection = TextAreaMouseHandler.nilPoint;
    private Point maxSelection = TextAreaMouseHandler.nilPoint;
    private TextArea textArea;
    private bool doubleclick;
    private int selbegin;
    private int selend;
    private bool clickedOnSelectedText;
    private MouseButtons button;
    private bool gotmousedown;
    private bool dodragdrop;

    public TextAreaMouseHandler(TextArea textArea)
    {
      this.textArea = textArea;
    }

    public void Attach()
    {
      this.textArea.Click += new EventHandler(this.TextAreaClick);
      this.textArea.MouseMove += new MouseEventHandler(this.TextAreaMouseMove);
      this.textArea.MouseDown += new MouseEventHandler(this.OnMouseDown);
      this.textArea.DoubleClick += new EventHandler(this.OnDoubleClick);
      this.textArea.MouseLeave += new EventHandler(this.OnMouseLeave);
      this.textArea.MouseUp += new MouseEventHandler(this.OnMouseUp);
      this.textArea.LostFocus += new EventHandler(this.TextAreaLostFocus);
      this.textArea.ToolTipRequest += new ToolTipRequestEventHandler(this.OnToolTipRequest);
    }

    private void OnToolTipRequest(object sender, ToolTipRequestEventArgs e)
    {
      if (e.ToolTipShown)
        return;
      Point mousePosition = e.MousePosition;
      FoldMarker markerFromPosition = this.textArea.TextView.GetFoldMarkerFromPosition(mousePosition.X - this.textArea.TextView.DrawingPosition.X, mousePosition.Y - this.textArea.TextView.DrawingPosition.Y);
      if (markerFromPosition != null && markerFromPosition.IsFolded)
      {
        StringBuilder stringBuilder = new StringBuilder(markerFromPosition.InnerText);
        int num = 0;
        for (int index = 0; index < stringBuilder.Length; ++index)
        {
          if ((int) stringBuilder[index] == 10)
          {
            ++num;
            if (num >= 10)
            {
              stringBuilder.Remove(index + 1, stringBuilder.Length - index - 1);
              stringBuilder.Append(Environment.NewLine);
              stringBuilder.Append("...");
              break;
            }
          }
        }
        stringBuilder.Replace("\t", "    ");
        e.ShowToolTip(stringBuilder.ToString());
      }
      else
      {
        foreach (TextMarker textMarker in this.textArea.Document.MarkerStrategy.GetMarkers(e.LogicalPosition))
        {
          if (textMarker.ToolTip != null)
          {
            e.ShowToolTip(textMarker.ToolTip.Replace("\t", "    "));
            break;
          }
        }
      }
    }

    private void ShowHiddenCursor()
    {
      if (!TextArea.HiddenMouseCursor)
        return;
      Cursor.Show();
      TextArea.HiddenMouseCursor = false;
    }

    private void TextAreaLostFocus(object sender, EventArgs e)
    {
      this.ShowHiddenCursor();
    }

    private void OnMouseLeave(object sender, EventArgs e)
    {
      this.ShowHiddenCursor();
      this.gotmousedown = false;
      this.mousedownpos = TextAreaMouseHandler.nilPoint;
    }

    private void OnMouseUp(object sender, MouseEventArgs e)
    {
      this.gotmousedown = false;
      this.mousedownpos = TextAreaMouseHandler.nilPoint;
    }

    private void TextAreaClick(object sender, EventArgs e)
    {
      if (this.dodragdrop || !this.clickedOnSelectedText || !this.textArea.TextView.DrawingPosition.Contains(this.mousepos.X, this.mousepos.Y))
        return;
      this.textArea.SelectionManager.ClearSelection();
      this.textArea.Caret.Position = this.textArea.TextView.GetLogicalPosition(this.mousepos.X - this.textArea.TextView.DrawingPosition.X, this.mousepos.Y - this.textArea.TextView.DrawingPosition.Y);
      this.textArea.SetDesiredColumn();
    }

    private void TextAreaMouseMove(object sender, MouseEventArgs e)
    {
      this.ShowHiddenCursor();
      if (this.dodragdrop)
      {
        this.dodragdrop = false;
      }
      else
      {
        this.doubleclick = false;
        this.mousepos = new Point(e.X, e.Y);
        if (this.clickedOnSelectedText)
        {
          if (Math.Abs(this.mousedownpos.X - this.mousepos.X) < SystemInformation.DragSize.Width / 2 && Math.Abs(this.mousedownpos.Y - this.mousepos.Y) < SystemInformation.DragSize.Height / 2)
            return;
          this.clickedOnSelectedText = false;
          ISelection selectionAt = this.textArea.SelectionManager.GetSelectionAt(this.textArea.Caret.Offset);
          if (selectionAt == null)
            return;
          string selectedText = selectionAt.SelectedText;
          if (selectedText == null || selectedText.Length <= 0)
            return;
          DataObject dataObject = new DataObject();
          dataObject.SetData(DataFormats.UnicodeText, true, (object) selectedText);
          dataObject.SetData((object) selectionAt);
          this.dodragdrop = true;
          int num = (int) this.textArea.DoDragDrop((object) dataObject, DragDropEffects.All);
        }
        else
        {
          if (e.Button != MouseButtons.Left || !this.gotmousedown)
            return;
          this.ExtendSelectionToMouse();
        }
      }
    }

    private void ExtendSelectionToMouse()
    {
      Point logicalPosition = this.textArea.TextView.GetLogicalPosition(Math.Max(0, this.mousepos.X - this.textArea.TextView.DrawingPosition.X), this.mousepos.Y - this.textArea.TextView.DrawingPosition.Y);
      int y = logicalPosition.Y;
      Point point1 = this.textArea.Caret.ValidatePosition(logicalPosition);
      Point position = this.textArea.Caret.Position;
      if (position == point1)
        return;
      this.textArea.Caret.Position = point1;
      if (this.minSelection != TextAreaMouseHandler.nilPoint && this.textArea.SelectionManager.SelectionCollection.Count > 0)
      {
        ISelection selection = this.textArea.SelectionManager.SelectionCollection[0];
        Point point2 = this.textArea.SelectionManager.GreaterEqPos(this.minSelection, this.maxSelection) ? this.maxSelection : this.minSelection;
        Point point3 = this.textArea.SelectionManager.GreaterEqPos(this.minSelection, this.maxSelection) ? this.minSelection : this.maxSelection;
        if (this.textArea.SelectionManager.GreaterEqPos(point3, point1) && this.textArea.SelectionManager.GreaterEqPos(point1, point2))
          this.textArea.SelectionManager.SetSelection(point2, point3);
        else if (this.textArea.SelectionManager.GreaterEqPos(point3, point1))
        {
          this.textArea.SelectionManager.SetSelection(this.textArea.Document.OffsetToPosition(this.FindWordStart(this.textArea.Document, this.textArea.Document.PositionToOffset(point1))), point3);
        }
        else
        {
          Point endPosition = this.textArea.Document.OffsetToPosition(this.FindWordEnd(this.textArea.Document, this.textArea.Document.PositionToOffset(point1)));
          this.textArea.SelectionManager.SetSelection(point2, endPosition);
        }
      }
      else
        this.textArea.SelectionManager.ExtendSelection(position, this.textArea.Caret.Position);
      this.textArea.SetDesiredColumn();
    }

    private void DoubleClickSelectionExtend()
    {
      this.textArea.SelectionManager.ClearSelection();
      if (!this.textArea.TextView.DrawingPosition.Contains(this.mousepos.X, this.mousepos.Y))
        return;
      FoldMarker markerFromPosition = this.textArea.TextView.GetFoldMarkerFromPosition(this.mousepos.X - this.textArea.TextView.DrawingPosition.X, this.mousepos.Y - this.textArea.TextView.DrawingPosition.Y);
      if (markerFromPosition != null && markerFromPosition.IsFolded)
      {
        markerFromPosition.IsFolded = false;
        this.textArea.MotherTextAreaControl.AdjustScrollBars((object) null, (DocumentEventArgs) null);
      }
      if (this.textArea.Caret.Offset < this.textArea.Document.TextLength)
      {
        if ((int) this.textArea.Document.GetCharAt(this.textArea.Caret.Offset) == 34)
        {
          if (this.textArea.Caret.Offset < this.textArea.Document.TextLength)
          {
            int next = this.FindNext(this.textArea.Document, this.textArea.Caret.Offset + 1, '"');
            this.minSelection = this.textArea.Caret.Position;
            this.maxSelection = this.textArea.Document.OffsetToPosition(next > this.textArea.Caret.Offset ? next + 1 : next);
          }
        }
        else
        {
          this.minSelection = this.textArea.Document.OffsetToPosition(this.FindWordStart(this.textArea.Document, this.textArea.Caret.Offset));
          this.maxSelection = this.textArea.Document.OffsetToPosition(this.FindWordEnd(this.textArea.Document, this.textArea.Caret.Offset));
        }
        this.textArea.SelectionManager.ExtendSelection(this.minSelection, this.maxSelection);
      }
      this.textArea.Refresh();
    }

    private void OnMouseDown(object sender, MouseEventArgs e)
    {
      if (this.dodragdrop)
        return;
      if (this.doubleclick)
      {
        this.doubleclick = false;
      }
      else
      {
        if (this.textArea.TextView.DrawingPosition.Contains(this.mousepos.X, this.mousepos.Y))
        {
          this.gotmousedown = true;
          this.button = e.Button;
          if ((DateTime.Now - this.lastTime).Milliseconds < SystemInformation.DoubleClickTime && (Math.Abs(this.lastmousedownpos.X - e.X) <= SystemInformation.DoubleClickSize.Width && Math.Abs(this.lastmousedownpos.Y - e.Y) <= SystemInformation.DoubleClickSize.Height))
          {
            this.DoubleClickSelectionExtend();
            this.lastTime = DateTime.Now;
            this.lastmousedownpos = new Point(e.X, e.Y);
            return;
          }
          this.minSelection = TextAreaMouseHandler.nilPoint;
          this.maxSelection = TextAreaMouseHandler.nilPoint;
          this.lastTime = DateTime.Now;
          this.lastmousedownpos = this.mousedownpos = new Point(e.X, e.Y);
          if (this.button == MouseButtons.Left)
          {
            FoldMarker markerFromPosition = this.textArea.TextView.GetFoldMarkerFromPosition(this.mousepos.X - this.textArea.TextView.DrawingPosition.X, this.mousepos.Y - this.textArea.TextView.DrawingPosition.Y);
            if (markerFromPosition != null && markerFromPosition.IsFolded)
            {
              if (this.textArea.SelectionManager.HasSomethingSelected)
                this.clickedOnSelectedText = true;
              this.textArea.SelectionManager.SetSelection((ISelection) new DefaultSelection(this.textArea.TextView.Document, new Point(markerFromPosition.StartColumn, markerFromPosition.StartLine), new Point(markerFromPosition.EndColumn, markerFromPosition.EndLine)));
              this.textArea.Focus();
              return;
            }
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
              this.ExtendSelectionToMouse();
            }
            else
            {
              Point logicalPosition = this.textArea.TextView.GetLogicalPosition(this.mousepos.X - this.textArea.TextView.DrawingPosition.X, this.mousepos.Y - this.textArea.TextView.DrawingPosition.Y);
              this.clickedOnSelectedText = false;
              int offset = this.textArea.Document.PositionToOffset(logicalPosition);
              if (this.textArea.SelectionManager.HasSomethingSelected && this.textArea.SelectionManager.IsSelected(offset))
              {
                this.clickedOnSelectedText = true;
              }
              else
              {
                this.selbegin = this.selend = offset;
                this.textArea.SelectionManager.ClearSelection();
                if (this.mousepos.Y > 0 && this.mousepos.Y < this.textArea.TextView.DrawingPosition.Height)
                {
                  this.textArea.Caret.Position = new Point()
                  {
                    Y = Math.Min(this.textArea.Document.TotalNumberOfLines - 1, logicalPosition.Y),
                    X = logicalPosition.X
                  };
                  this.textArea.SetDesiredColumn();
                }
              }
            }
          }
          else if (this.button == MouseButtons.Right)
          {
            Point logicalPosition = this.textArea.TextView.GetLogicalPosition(this.mousepos.X - this.textArea.TextView.DrawingPosition.X, this.mousepos.Y - this.textArea.TextView.DrawingPosition.Y);
            int offset = this.textArea.Document.PositionToOffset(logicalPosition);
            if (!this.textArea.SelectionManager.HasSomethingSelected || !this.textArea.SelectionManager.IsSelected(offset))
            {
              this.selbegin = this.selend = offset;
              this.textArea.SelectionManager.ClearSelection();
              if (this.mousepos.Y > 0 && this.mousepos.Y < this.textArea.TextView.DrawingPosition.Height)
              {
                this.textArea.Caret.Position = new Point()
                {
                  Y = Math.Min(this.textArea.Document.TotalNumberOfLines - 1, logicalPosition.Y),
                  X = logicalPosition.X
                };
                this.textArea.SetDesiredColumn();
              }
            }
          }
        }
        this.textArea.Focus();
      }
    }

    private int FindNext(IDocument document, int offset, char ch)
    {
      LineSegment segmentForOffset = document.GetLineSegmentForOffset(offset);
      int num = segmentForOffset.Offset + segmentForOffset.Length;
      while (offset < num && (int) document.GetCharAt(offset) != (int) ch)
        ++offset;
      return offset;
    }

    private bool IsSelectableChar(char ch)
    {
      if (!char.IsLetterOrDigit(ch))
        return (int) ch == 95;
      return true;
    }

    private int FindWordStart(IDocument document, int offset)
    {
      LineSegment segmentForOffset = document.GetLineSegmentForOffset(offset);
      if (offset > 0 && char.IsWhiteSpace(document.GetCharAt(offset - 1)) && char.IsWhiteSpace(document.GetCharAt(offset)))
      {
        while (offset > segmentForOffset.Offset && char.IsWhiteSpace(document.GetCharAt(offset - 1)))
          --offset;
      }
      else if (this.IsSelectableChar(document.GetCharAt(offset)) || offset > 0 && char.IsWhiteSpace(document.GetCharAt(offset)) && this.IsSelectableChar(document.GetCharAt(offset - 1)))
      {
        while (offset > segmentForOffset.Offset && this.IsSelectableChar(document.GetCharAt(offset - 1)))
          --offset;
      }
      else if (offset > 0 && !char.IsWhiteSpace(document.GetCharAt(offset - 1)) && !this.IsSelectableChar(document.GetCharAt(offset - 1)))
        return Math.Max(0, offset - 1);
      return offset;
    }

    private int FindWordEnd(IDocument document, int offset)
    {
      LineSegment segmentForOffset = document.GetLineSegmentForOffset(offset);
      int num = segmentForOffset.Offset + segmentForOffset.Length;
      if (this.IsSelectableChar(document.GetCharAt(offset)))
      {
        while (offset < num && this.IsSelectableChar(document.GetCharAt(offset)))
          ++offset;
      }
      else
      {
        if (!char.IsWhiteSpace(document.GetCharAt(offset)))
          return Math.Max(0, offset + 1);
        if (offset > 0 && char.IsWhiteSpace(document.GetCharAt(offset - 1)))
        {
          while (offset < num && char.IsWhiteSpace(document.GetCharAt(offset)))
            ++offset;
        }
      }
      return offset;
    }

    private void OnDoubleClick(object sender, EventArgs e)
    {
      if (this.dodragdrop)
        return;
      this.doubleclick = true;
    }
  }
}
