// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.FoldMargin
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Document;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
  public class FoldMargin : AbstractMargin
  {
    private int selectedFoldLine = -1;

    public override Size Size
    {
      get
      {
        return new Size(this.textArea.TextView.FontHeight, -1);
      }
    }

    public override bool IsVisible
    {
      get
      {
        return this.textArea.TextEditorProperties.EnableFolding;
      }
    }

    public FoldMargin(TextArea textArea)
      : base(textArea)
    {
    }

    public override void Paint(Graphics g, Rectangle rect)
    {
      if (rect.Width <= 0 || rect.Height <= 0)
        return;
      HighlightColor colorFor = this.textArea.Document.HighlightingStrategy.GetColorFor("LineNumbers");
      this.textArea.Document.HighlightingStrategy.GetColorFor("FoldLine");
      for (int index = 0; index < (this.DrawingPosition.Height + this.textArea.TextView.VisibleLineDrawingRemainder) / this.textArea.TextView.FontHeight + 1; ++index)
      {
        Rectangle rectangle = new Rectangle(this.DrawingPosition.X, this.DrawingPosition.Top + index * this.textArea.TextView.FontHeight - this.textArea.TextView.VisibleLineDrawingRemainder, this.DrawingPosition.Width, this.textArea.TextView.FontHeight);
        if (rect.IntersectsWith(rectangle))
        {
          if (this.textArea.Document.TextEditorProperties.ShowLineNumbers)
          {
            g.FillRectangle(BrushRegistry.GetBrush(this.textArea.Enabled ? colorFor.BackgroundColor : SystemColors.InactiveBorder), new Rectangle(rectangle.X + 1, rectangle.Y, rectangle.Width - 1, rectangle.Height));
            g.DrawLine(BrushRegistry.GetDotPen(colorFor.Color, colorFor.BackgroundColor), this.drawingPosition.X, rectangle.Y, this.drawingPosition.X, rectangle.Bottom);
          }
          else
            g.FillRectangle(BrushRegistry.GetBrush(this.textArea.Enabled ? colorFor.BackgroundColor : SystemColors.InactiveBorder), rectangle);
          int firstLogicalLine = this.textArea.Document.GetFirstLogicalLine(this.textArea.Document.GetVisibleLine(this.textArea.TextView.FirstVisibleLine) + index);
          this.PaintFoldMarker(g, firstLogicalLine, rectangle);
        }
      }
    }

    private bool SelectedFoldingFrom(List<FoldMarker> list)
    {
      if (list != null)
      {
        for (int index = 0; index < list.Count; ++index)
        {
          if (this.selectedFoldLine == list[index].StartLine)
            return true;
        }
      }
      return false;
    }

    private void PaintFoldMarker(Graphics g, int lineNumber, Rectangle drawingRectangle)
    {
      HighlightColor colorFor1 = this.textArea.Document.HighlightingStrategy.GetColorFor("FoldLine");
      HighlightColor colorFor2 = this.textArea.Document.HighlightingStrategy.GetColorFor("SelectedFoldLine");
      List<FoldMarker> foldingsWithStart = this.textArea.Document.FoldingManager.GetFoldingsWithStart(lineNumber);
      List<FoldMarker> containsLineNumber = this.textArea.Document.FoldingManager.GetFoldingsContainsLineNumber(lineNumber);
      List<FoldMarker> foldingsWithEnd = this.textArea.Document.FoldingManager.GetFoldingsWithEnd(lineNumber);
      bool flag1 = foldingsWithStart.Count > 0;
      bool flag2 = containsLineNumber.Count > 0;
      bool flag3 = foldingsWithEnd.Count > 0;
      bool isSelected = this.SelectedFoldingFrom(foldingsWithStart);
      bool flag4 = this.SelectedFoldingFrom(containsLineNumber);
      bool flag5 = this.SelectedFoldingFrom(foldingsWithEnd);
      int num1 = (int) Math.Round((double) this.textArea.TextView.FontHeight * 0.569999992847443);
      int num2 = num1 - num1 % 2;
      int num3 = drawingRectangle.Y + (drawingRectangle.Height - num2) / 2;
      int num4 = drawingRectangle.X + (drawingRectangle.Width - num2) / 2 + num2 / 2;
      if (flag1)
      {
        bool isOpened = true;
        bool flag6 = false;
        foreach (FoldMarker foldMarker in foldingsWithStart)
        {
          if (foldMarker.IsFolded)
            isOpened = false;
          else
            flag6 = foldMarker.EndLine > foldMarker.StartLine;
        }
        bool flag7 = false;
        foreach (FoldMarker foldMarker in foldingsWithEnd)
        {
          if (foldMarker.EndLine > foldMarker.StartLine && !foldMarker.IsFolded)
            flag7 = true;
        }
        this.DrawFoldMarker(g, new RectangleF((float) (drawingRectangle.X + (drawingRectangle.Width - num2) / 2), (float) num3, (float) num2, (float) num2), isOpened, isSelected);
        if (flag2 || flag7)
          g.DrawLine(BrushRegistry.GetPen(flag4 ? colorFor2.Color : colorFor1.Color), num4, drawingRectangle.Top, num4, num3 - 1);
        if (!flag2 && !flag6)
          return;
        g.DrawLine(BrushRegistry.GetPen(flag5 || isSelected && isOpened || flag4 ? colorFor2.Color : colorFor1.Color), num4, num3 + num2 + 1, num4, drawingRectangle.Bottom);
      }
      else if (flag3)
      {
        int num5 = drawingRectangle.Top + drawingRectangle.Height / 2;
        g.DrawLine(BrushRegistry.GetPen(flag4 || flag5 ? colorFor2.Color : colorFor1.Color), num4, drawingRectangle.Top, num4, num5);
        g.DrawLine(BrushRegistry.GetPen(flag4 || flag5 ? colorFor2.Color : colorFor1.Color), num4, num5, num4 + num2 / 2, num5);
        if (!flag2)
          return;
        g.DrawLine(BrushRegistry.GetPen(flag4 ? colorFor2.Color : colorFor1.Color), num4, num5 + 1, num4, drawingRectangle.Bottom);
      }
      else
      {
        if (!flag2)
          return;
        g.DrawLine(BrushRegistry.GetPen(flag4 ? colorFor2.Color : colorFor1.Color), num4, drawingRectangle.Top, num4, drawingRectangle.Bottom);
      }
    }

    public override void HandleMouseMove(Point mousepos, MouseButtons mouseButtons)
    {
      bool enableFolding = this.textArea.Document.TextEditorProperties.EnableFolding;
      int firstLogicalLine = this.textArea.Document.GetFirstLogicalLine((mousepos.Y + this.textArea.VirtualTop.Y) / this.textArea.TextView.FontHeight);
      if (!enableFolding || firstLogicalLine < 0 || firstLogicalLine + 1 >= this.textArea.Document.TotalNumberOfLines)
        return;
      List<FoldMarker> foldingsWithStart = this.textArea.Document.FoldingManager.GetFoldingsWithStart(firstLogicalLine);
      int num = this.selectedFoldLine;
      this.selectedFoldLine = foldingsWithStart.Count <= 0 ? -1 : firstLogicalLine;
      if (num == this.selectedFoldLine)
        return;
      this.textArea.Refresh((AbstractMargin) this);
    }

    public override void HandleMouseDown(Point mousepos, MouseButtons mouseButtons)
    {
      bool enableFolding = this.textArea.Document.TextEditorProperties.EnableFolding;
      int firstLogicalLine = this.textArea.Document.GetFirstLogicalLine((mousepos.Y + this.textArea.VirtualTop.Y) / this.textArea.TextView.FontHeight);
      this.textArea.Focus();
      if (!enableFolding || firstLogicalLine < 0 || firstLogicalLine + 1 >= this.textArea.Document.TotalNumberOfLines)
        return;
      foreach (FoldMarker foldMarker in this.textArea.Document.FoldingManager.GetFoldingsWithStart(firstLogicalLine))
        foldMarker.IsFolded = !foldMarker.IsFolded;
      this.textArea.Document.FoldingManager.NotifyFoldingsChanged(EventArgs.Empty);
    }

    public override void HandleMouseLeave(EventArgs e)
    {
      if (this.selectedFoldLine == -1)
        return;
      this.selectedFoldLine = -1;
      this.textArea.Refresh((AbstractMargin) this);
    }

    private void DrawFoldMarker(Graphics g, RectangleF rectangle, bool isOpened, bool isSelected)
    {
      HighlightColor colorFor1 = this.textArea.Document.HighlightingStrategy.GetColorFor("FoldMarker");
      HighlightColor colorFor2 = this.textArea.Document.HighlightingStrategy.GetColorFor("FoldLine");
      HighlightColor colorFor3 = this.textArea.Document.HighlightingStrategy.GetColorFor("SelectedFoldLine");
      Rectangle rect = new Rectangle((int) rectangle.X, (int) rectangle.Y, (int) rectangle.Width, (int) rectangle.Height);
      g.FillRectangle(BrushRegistry.GetBrush(colorFor1.BackgroundColor), rect);
      g.DrawRectangle(BrushRegistry.GetPen(isSelected ? colorFor3.Color : colorFor1.Color), rect);
      int num1 = (int) Math.Round((double) rectangle.Height / 8.0) + 1;
      int num2 = rect.Height / 2 + rect.Height % 2;
      g.DrawLine(BrushRegistry.GetPen(colorFor2.BackgroundColor), rectangle.X + (float) num1, rectangle.Y + (float) num2, rectangle.X + rectangle.Width - (float) num1, rectangle.Y + (float) num2);
      if (isOpened)
        return;
      g.DrawLine(BrushRegistry.GetPen(colorFor2.BackgroundColor), rectangle.X + (float) num2, rectangle.Y + (float) num1, rectangle.X + (float) num2, rectangle.Y + rectangle.Height - (float) num1);
    }
  }
}
