// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.GutterMargin
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Document;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
  public class GutterMargin : AbstractMargin, IDisposable
  {
    private StringFormat numberStringFormat = (StringFormat) StringFormat.GenericTypographic.Clone();
    public static Cursor RightLeftCursor;
    private Point selectionStartPos;
    private bool selectionComeFromGutter;
    private bool selectionGutterDirectionDown;

    public override Cursor Cursor
    {
      get
      {
        return GutterMargin.RightLeftCursor;
      }
    }

    public override Size Size
    {
      get
      {
        return new Size((int) ((double) this.textArea.TextView.WideSpaceWidth * (double) Math.Max(3, (int) Math.Log10((double) this.textArea.Document.TotalNumberOfLines) + 1)), -1);
      }
    }

    public override bool IsVisible
    {
      get
      {
        return this.textArea.TextEditorProperties.ShowLineNumbers;
      }
    }

    static GutterMargin()
    {
      //Stream manifestResourceStream = Assembly.GetCallingAssembly().GetManifestResourceStream("Nikita.WinForm.ExtendControl.Resources.RightArrow.cur");

        Stream manifestResourceStream = Nikita.WinForm.ExtendControl.Properties.Resources.Rightarrow;
      GutterMargin.RightLeftCursor = new Cursor(manifestResourceStream);
      manifestResourceStream.Close();
    }

    public GutterMargin(TextArea textArea)
      : base(textArea)
    {
      this.numberStringFormat.LineAlignment = StringAlignment.Far;
      this.numberStringFormat.FormatFlags = StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
    }

    public void Dispose()
    {
      this.numberStringFormat.Dispose();
    }

    public override void Paint(Graphics g, Rectangle rect)
    {
      if (rect.Width <= 0 || rect.Height <= 0)
        return;
      HighlightColor colorFor = this.textArea.Document.HighlightingStrategy.GetColorFor("LineNumbers");
      int fontHeight = this.textArea.TextView.FontHeight;
      Brush brush1 = this.textArea.Enabled ? BrushRegistry.GetBrush(colorFor.BackgroundColor) : SystemBrushes.InactiveBorder;
      Brush brush2 = BrushRegistry.GetBrush(colorFor.Color);
      for (int index = 0; index < (this.DrawingPosition.Height + this.textArea.TextView.VisibleLineDrawingRemainder) / fontHeight + 1; ++index)
      {
        Rectangle rect1 = new Rectangle(this.drawingPosition.X, this.drawingPosition.Y + fontHeight * index - this.textArea.TextView.VisibleLineDrawingRemainder, this.drawingPosition.Width, fontHeight);
        if (rect.IntersectsWith(rect1))
        {
          g.FillRectangle(brush1, rect1);
          int firstLogicalLine = this.textArea.Document.GetFirstLogicalLine(this.textArea.Document.GetVisibleLine(this.textArea.TextView.FirstVisibleLine) + index);
          if (firstLogicalLine < this.textArea.Document.TotalNumberOfLines)
            g.DrawString((firstLogicalLine + 1).ToString(), colorFor.Font, brush2, (RectangleF) rect1, this.numberStringFormat);
        }
      }
    }

    public override void HandleMouseDown(Point mousepos, MouseButtons mouseButtons)
    {
      this.selectionComeFromGutter = true;
      int logicalLine = this.textArea.TextView.GetLogicalLine(mousepos);
      if (logicalLine < 0 || logicalLine >= this.textArea.Document.TotalNumberOfLines)
        return;
      if ((Control.ModifierKeys & Keys.Shift) != Keys.None && this.textArea.SelectionManager.HasSomethingSelected)
      {
        this.HandleMouseMove(mousepos, mouseButtons);
      }
      else
      {
        this.selectionGutterDirectionDown = false;
        this.selectionStartPos = new Point(0, logicalLine);
        this.textArea.SelectionManager.ClearSelection();
        this.textArea.SelectionManager.SetSelection((ISelection) new DefaultSelection(this.textArea.Document, this.selectionStartPos, new Point(this.textArea.Document.GetLineSegment(logicalLine).Length + 1, logicalLine)));
        this.textArea.Caret.Position = this.selectionStartPos;
      }
    }

    public override void HandleMouseLeave(EventArgs e)
    {
      this.selectionComeFromGutter = false;
    }

    public override void HandleMouseMove(Point mousepos, MouseButtons mouseButtons)
    {
      if (mouseButtons != MouseButtons.Left)
        return;
      if (this.selectionComeFromGutter)
      {
        Point point = new Point(0, this.textArea.TextView.GetLogicalLine(mousepos));
        if (point.Y >= this.textArea.Document.TotalNumberOfLines)
          return;
        if (this.selectionStartPos.Y == point.Y)
        {
          this.textArea.SelectionManager.SetSelection((ISelection) new DefaultSelection(this.textArea.Document, point, new Point(0, point.Y + 1)));
          this.selectionGutterDirectionDown = false;
        }
        else if (this.selectionStartPos.Y < point.Y && this.textArea.SelectionManager.HasSomethingSelected)
        {
          if (!this.selectionGutterDirectionDown)
          {
            this.selectionGutterDirectionDown = true;
            this.textArea.SelectionManager.SetSelection((ISelection) new DefaultSelection(this.textArea.Document, this.selectionStartPos, new Point(0, this.selectionStartPos.Y)));
            this.textArea.SelectionManager.ExtendSelection(this.textArea.SelectionManager.SelectionCollection[0].EndPosition, new Point(0, point.Y + 1));
          }
          else
            this.textArea.SelectionManager.ExtendSelection(this.textArea.SelectionManager.SelectionCollection[0].EndPosition, new Point(0, point.Y + 1));
        }
        else if (this.textArea.SelectionManager.HasSomethingSelected)
        {
          if (this.selectionGutterDirectionDown)
          {
            this.selectionGutterDirectionDown = false;
            this.textArea.SelectionManager.SetSelection((ISelection) new DefaultSelection(this.textArea.Document, this.selectionStartPos, new Point(0, point.Y + 1)));
            this.textArea.SelectionManager.ExtendSelection(this.selectionStartPos, point);
          }
          else
            this.textArea.SelectionManager.ExtendSelection(this.textArea.Caret.Position, point);
        }
        this.textArea.Caret.Position = point;
      }
      else
      {
        if (!this.textArea.SelectionManager.HasSomethingSelected)
          return;
        this.selectionStartPos = this.textArea.Document.OffsetToPosition(this.textArea.SelectionManager.SelectionCollection[0].Offset);
        Point newPosition = new Point(0, this.textArea.TextView.GetLogicalLine(mousepos));
        if (newPosition.Y < this.textArea.Document.TotalNumberOfLines)
          this.textArea.SelectionManager.ExtendSelection(this.textArea.Caret.Position, newPosition);
        this.textArea.Caret.Position = newPosition;
      }
    }
  }
}
