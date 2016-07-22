// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.TextView
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
  public class TextView : AbstractMargin, IDisposable
  {
    private StringFormat measureStringFormat = (StringFormat) StringFormat.GenericTypographic.Clone();
    private Dictionary<TextView.WordFontPair, float> measureCache = new Dictionary<TextView.WordFontPair, float>();
    private Dictionary<Font, Dictionary<char, float>> fontBoundCharWidth = new Dictionary<Font, Dictionary<char, float>>();
    private const int MaximumWordLength = 1000;
    private const float MinTabWidth = 4f;
    private int fontHeight;
    private Highlight highlight;
    private int physicalColumn;
    private float spaceWidth;
    private float wideSpaceWidth;
    private Font lastFont;

    public Highlight Highlight
    {
      get
      {
        return this.highlight;
      }
      set
      {
        this.highlight = value;
      }
    }

    public override Cursor Cursor
    {
      get
      {
        return Cursors.IBeam;
      }
    }

    public int FirstPhysicalLine
    {
      get
      {
        return this.textArea.VirtualTop.Y / this.fontHeight;
      }
    }

    public int LineHeightRemainder
    {
      get
      {
        return this.textArea.VirtualTop.Y % this.fontHeight;
      }
    }

    public int FirstVisibleLine
    {
      get
      {
        return this.textArea.Document.GetFirstLogicalLine(this.textArea.VirtualTop.Y / this.fontHeight);
      }
      set
      {
        if (this.FirstVisibleLine == value)
          return;
        this.textArea.VirtualTop = new Point(this.textArea.VirtualTop.X, this.textArea.Document.GetVisibleLine(value) * this.fontHeight);
      }
    }

    public int VisibleLineDrawingRemainder
    {
      get
      {
        return this.textArea.VirtualTop.Y % this.fontHeight;
      }
    }

    public int FontHeight
    {
      get
      {
        return this.fontHeight;
      }
    }

    public int VisibleLineCount
    {
      get
      {
        return 1 + this.DrawingPosition.Height / this.fontHeight;
      }
    }

    public int VisibleColumnCount
    {
      get
      {
        return (int) ((double) this.DrawingPosition.Width / (double) this.WideSpaceWidth) - 1;
      }
    }

    public float SpaceWidth
    {
      get
      {
        return this.spaceWidth;
      }
    }

    public float WideSpaceWidth
    {
      get
      {
        return this.wideSpaceWidth;
      }
    }

    public TextView(TextArea textArea)
      : base(textArea)
    {
      this.measureStringFormat.LineAlignment = StringAlignment.Near;
      this.measureStringFormat.FormatFlags = StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
      this.OptionsChanged();
    }

    public void Dispose()
    {
      this.measureCache.Clear();
      this.measureStringFormat.Dispose();
    }

    private static int GetFontHeight(Font font)
    {
      int height = font.Height;
      if (height >= 16)
        return height;
      return height + 1;
    }

    public void OptionsChanged()
    {
      this.lastFont = this.TextEditorProperties.Font;
      this.fontHeight = TextView.GetFontHeight(this.lastFont);
      this.spaceWidth = Math.Max(this.GetWidth(' ', this.lastFont), 1f);
      this.wideSpaceWidth = Math.Max(this.spaceWidth, this.GetWidth('x', this.lastFont));
    }

    public override void Paint(Graphics g, Rectangle rect)
    {
      if (rect.Width <= 0 || rect.Height <= 0)
        return;
      if (this.lastFont != this.TextEditorProperties.Font)
      {
        this.OptionsChanged();
        this.TextArea.BeginInvoke((Delegate) new MethodInvoker(((Control) this.TextArea).Refresh));
      }
      int num = (int) ((double) this.textArea.VirtualTop.X * (double) this.WideSpaceWidth);
      if (num > 0)
        g.SetClip(this.DrawingPosition);
      for (int index = 0; index < (this.DrawingPosition.Height + this.VisibleLineDrawingRemainder) / this.fontHeight + 1; ++index)
      {
        Rectangle rectangle = new Rectangle(this.DrawingPosition.X - num, this.DrawingPosition.Top + index * this.fontHeight - this.VisibleLineDrawingRemainder, this.DrawingPosition.Width + num, this.fontHeight);
        if (rect.IntersectsWith(rectangle))
        {
          this.textArea.Document.GetVisibleLine(this.FirstVisibleLine);
          int firstLogicalLine = this.textArea.Document.GetFirstLogicalLine(this.textArea.Document.GetVisibleLine(this.FirstVisibleLine) + index);
          this.PaintDocumentLine(g, firstLogicalLine, rectangle);
        }
      }
      if (num <= 0)
        return;
      g.ResetClip();
    }

    private void PaintDocumentLine(Graphics g, int lineNumber, Rectangle lineRectangle)
    {
      Brush bgColorBrush = this.GetBgColorBrush(lineNumber);
      Brush brush1 = this.textArea.Enabled ? bgColorBrush : SystemBrushes.InactiveBorder;
      if (lineNumber >= this.textArea.Document.TotalNumberOfLines)
      {
        g.FillRectangle(brush1, lineRectangle);
        if (this.TextEditorProperties.ShowInvalidLines)
          this.DrawInvalidLineMarker(g, (float) lineRectangle.Left, (float) lineRectangle.Top);
        if (!this.TextEditorProperties.ShowVerticalRuler)
          return;
        this.DrawVerticalRuler(g, lineRectangle);
      }
      else
      {
        float num = (float) lineRectangle.X;
        int startColumn = 0;
        this.physicalColumn = 0;
        if (this.TextEditorProperties.EnableFolding)
        {
          while (true)
          {
            List<FoldMarker> startAfterColumn = this.textArea.Document.FoldingManager.GetFoldedFoldingsWithStartAfterColumn(lineNumber, startColumn - 1);
            if (startAfterColumn != null && startAfterColumn.Count > 0)
            {
              FoldMarker foldMarker1 = startAfterColumn[0];
              foreach (FoldMarker foldMarker2 in startAfterColumn)
              {
                if (foldMarker2.StartColumn < foldMarker1.StartColumn)
                  foldMarker1 = foldMarker2;
              }
              startAfterColumn.Clear();
              float physicalXPos = this.PaintLinePart(g, lineNumber, startColumn, foldMarker1.StartColumn, lineRectangle, num);
              startColumn = foldMarker1.EndColumn;
              lineNumber = foldMarker1.EndLine;
              ColumnRange selectionAtLine = this.textArea.SelectionManager.GetSelectionAtLine(lineNumber);
              bool drawSelected = ColumnRange.WholeColumn.Equals((object) selectionAtLine) || foldMarker1.StartColumn >= selectionAtLine.StartColumn && foldMarker1.EndColumn <= selectionAtLine.EndColumn;
              num = this.PaintFoldingText(g, lineNumber, physicalXPos, lineRectangle, foldMarker1.FoldText, drawSelected);
            }
            else
              break;
          }
          if (lineNumber < this.textArea.Document.TotalNumberOfLines)
            num = this.PaintLinePart(g, lineNumber, startColumn, this.textArea.Document.GetLineSegment(lineNumber).Length, lineRectangle, num);
        }
        else
          num = this.PaintLinePart(g, lineNumber, 0, this.textArea.Document.GetLineSegment(lineNumber).Length, lineRectangle, num);
        if (lineNumber < this.textArea.Document.TotalNumberOfLines)
        {
          ColumnRange selectionAtLine = this.textArea.SelectionManager.GetSelectionAtLine(lineNumber);
          LineSegment lineSegment = this.textArea.Document.GetLineSegment(lineNumber);
          HighlightColor colorFor1 = this.textArea.Document.HighlightingStrategy.GetColorFor("Selection");
          bool flag = selectionAtLine.EndColumn > lineSegment.Length || ColumnRange.WholeColumn.Equals((object) selectionAtLine);
          if (this.TextEditorProperties.ShowEOLMarker)
          {
            HighlightColor colorFor2 = this.textArea.Document.HighlightingStrategy.GetColorFor("EOLMarkers");
            num += this.DrawEOLMarker(g, colorFor2.Color, flag ? bgColorBrush : brush1, num, (float) lineRectangle.Y);
          }
          else if (flag)
          {
            g.FillRectangle(BrushRegistry.GetBrush(colorFor1.BackgroundColor), new RectangleF(num, (float) lineRectangle.Y, this.WideSpaceWidth, (float) lineRectangle.Height));
            num += this.WideSpaceWidth;
          }
          Brush brush2 = !flag || !this.TextEditorProperties.AllowCaretBeyondEOL ? brush1 : bgColorBrush;
          g.FillRectangle(brush2, new RectangleF(num, (float) lineRectangle.Y, (float) lineRectangle.Width - num + (float) lineRectangle.X, (float) lineRectangle.Height));
        }
        if (!this.TextEditorProperties.ShowVerticalRuler)
          return;
        this.DrawVerticalRuler(g, lineRectangle);
      }
    }

    private bool DrawLineMarkerAtLine(int lineNumber)
    {
      if (lineNumber == this.textArea.Caret.Line)
        return this.textArea.MotherTextAreaControl.TextEditorProperties.LineViewerStyle == LineViewerStyle.FullRow;
      return false;
    }

    private Brush GetBgColorBrush(int lineNumber)
    {
      if (this.DrawLineMarkerAtLine(lineNumber))
        return BrushRegistry.GetBrush(this.textArea.Document.HighlightingStrategy.GetColorFor("CaretMarker").Color);
      Color color = this.textArea.Document.HighlightingStrategy.GetColorFor("DefaultBackground").BackgroundColor;
      if (this.textArea.MotherTextAreaControl.TextEditorProperties.UseCustomLine)
        color = this.textArea.Document.CustomLineManager.GetCustomColor(lineNumber, color);
      return BrushRegistry.GetBrush(color);
    }

    private float PaintFoldingText(Graphics g, int lineNumber, float physicalXPos, Rectangle lineRectangle, string text, bool drawSelected)
    {
      HighlightColor colorFor = this.textArea.Document.HighlightingStrategy.GetColorFor("Selection");
      Brush brush = this.textArea.Enabled ? (drawSelected ? BrushRegistry.GetBrush(colorFor.BackgroundColor) : this.GetBgColorBrush(lineNumber)) : SystemBrushes.InactiveBorder;
      float width = this.MeasureStringWidth(g, text, this.textArea.Font);
      RectangleF rectangleF = new RectangleF(physicalXPos, (float) lineRectangle.Y, width, (float) (lineRectangle.Height - 1));
      g.FillRectangle(brush, rectangleF);
      this.physicalColumn += text.Length;
      g.DrawString(text, this.textArea.Font, BrushRegistry.GetBrush(drawSelected ? colorFor.Color : Color.Gray), rectangleF, this.measureStringFormat);
      g.DrawRectangle(BrushRegistry.GetPen(drawSelected ? Color.DarkGray : Color.Gray), rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height);
      float num = (float) Math.Ceiling((double) physicalXPos + (double) width);
      if ((double) num - ((double) physicalXPos + (double) width) < 0.5)
        ++num;
      return num;
    }

    private void DrawMarker(Graphics g, TextMarker marker, RectangleF drawingRect)
    {
      float num1 = drawingRect.Bottom - 1f;
      switch (marker.TextMarkerType)
      {
        case TextMarkerType.SolidBlock:
          g.FillRectangle(BrushRegistry.GetBrush(marker.Color), drawingRect);
          break;
        case TextMarkerType.Underlined:
          g.DrawLine(BrushRegistry.GetPen(marker.Color), drawingRect.X, num1, drawingRect.Right, num1);
          break;
        case TextMarkerType.WaveLine:
          int num2 = (int) drawingRect.X % 6;
          float x1 = drawingRect.X - (float) num2;
          while ((double) x1 < (double) drawingRect.Right + (double) num2)
          {
            g.DrawLine(BrushRegistry.GetPen(marker.Color), x1, (float) ((double) num1 + 3.0 - 4.0), x1 + 3f, (float) ((double) num1 + 1.0 - 4.0));
            g.DrawLine(BrushRegistry.GetPen(marker.Color), x1 + 3f, (float) ((double) num1 + 1.0 - 4.0), x1 + 6f, (float) ((double) num1 + 3.0 - 4.0));
            x1 += 6f;
          }
          break;
      }
    }

    private Brush GetMarkerBrushAt(int offset, int length, ref Color foreColor, out List<TextMarker> markers)
    {
      markers = this.Document.MarkerStrategy.GetMarkers(offset, length);
      foreach (TextMarker textMarker in markers)
      {
        if (textMarker.TextMarkerType == TextMarkerType.SolidBlock)
        {
          if (textMarker.OverrideForeColor)
            foreColor = textMarker.ForeColor;
          return BrushRegistry.GetBrush(textMarker.Color);
        }
      }
      return (Brush) null;
    }

    private float PaintLinePart(Graphics g, int lineNumber, int startColumn, int endColumn, Rectangle lineRectangle, float physicalXPos)
    {
      bool flag = this.DrawLineMarkerAtLine(lineNumber);
      Brush brush1 = this.textArea.Enabled ? this.GetBgColorBrush(lineNumber) : SystemBrushes.InactiveBorder;
      HighlightColor colorFor1 = this.textArea.Document.HighlightingStrategy.GetColorFor("Selection");
      ColumnRange selectionAtLine = this.textArea.SelectionManager.GetSelectionAtLine(lineNumber);
      HighlightColor colorFor2 = this.textArea.Document.HighlightingStrategy.GetColorFor("TabMarkers");
      HighlightColor colorFor3 = this.textArea.Document.HighlightingStrategy.GetColorFor("SpaceMarkers");
      LineSegment lineSegment = this.textArea.Document.GetLineSegment(lineNumber);
      int num1 = startColumn;
      Brush brush2 = BrushRegistry.GetBrush(colorFor1.BackgroundColor);
      Brush brush3 = brush1;
      if (lineSegment.Words != null)
      {
        int index1 = 0;
        int num2;
        for (num2 = 0; index1 < lineSegment.Words.Count && num2 < startColumn; ++index1)
        {
          TextWord textWord = lineSegment.Words[index1];
          if (textWord.Type == TextWordType.Tab)
            ++num2;
          else if (textWord.Type == TextWordType.Space)
            ++num2;
          else
            num2 += textWord.Length;
        }
        for (int index2 = index1; index2 < lineSegment.Words.Count && (double) physicalXPos < (double) lineRectangle.Right && num1 < endColumn; ++index2)
        {
          List<TextMarker> markers = this.Document.MarkerStrategy.GetMarkers(lineSegment.Offset + num2);
          foreach (TextMarker textMarker in markers)
          {
            if (textMarker.TextMarkerType == TextMarkerType.SolidBlock)
            {
              brush3 = BrushRegistry.GetBrush(textMarker.Color);
              break;
            }
          }
          TextWord textWord = lineSegment.Words[index2];
          switch (textWord.Type)
          {
            case TextWordType.Word:
              string word = textWord.Word;
              float x = physicalXPos;
              Color color1 = textWord.Color;
              Brush markerBrushAt1 = this.GetMarkerBrushAt(lineSegment.Offset + num1, word.Length, ref color1, out markers);
              Brush backBrush = flag || markerBrushAt1 == null ? (flag || !textWord.SyntaxColor.HasBackground ? brush3 : BrushRegistry.GetBrush(textWord.SyntaxColor.BackgroundColor)) : markerBrushAt1;
              if (ColumnRange.WholeColumn.Equals((object) selectionAtLine) || selectionAtLine.EndColumn - 1 >= word.Length + num1 && selectionAtLine.StartColumn <= num1)
                physicalXPos += this.DrawDocumentWord(g, word, new Point((int) physicalXPos, lineRectangle.Y), textWord.Font, colorFor1.HasForgeground ? colorFor1.Color : color1, brush2);
              else if (ColumnRange.NoColumn.Equals((object) selectionAtLine))
              {
                physicalXPos += this.DrawDocumentWord(g, word, new Point((int) physicalXPos, lineRectangle.Y), textWord.Font, color1, backBrush);
              }
              else
              {
                int num3 = Math.Min(word.Length, Math.Max(0, selectionAtLine.StartColumn - num1));
                int startIndex = Math.Max(num3, Math.Min(word.Length, selectionAtLine.EndColumn - num1));
                physicalXPos += this.DrawDocumentWord(g, word.Substring(0, num3), new Point((int) physicalXPos, lineRectangle.Y), textWord.Font, color1, backBrush);
                physicalXPos += this.DrawDocumentWord(g, word.Substring(num3, startIndex - num3), new Point((int) physicalXPos, lineRectangle.Y), textWord.Font, colorFor1.HasForgeground ? colorFor1.Color : color1, brush2);
                physicalXPos += this.DrawDocumentWord(g, word.Substring(startIndex), new Point((int) physicalXPos, lineRectangle.Y), textWord.Font, color1, backBrush);
              }
              foreach (TextMarker marker in markers)
              {
                if (marker.TextMarkerType != TextMarkerType.SolidBlock)
                  this.DrawMarker(g, marker, new RectangleF(x, (float) lineRectangle.Y, physicalXPos - x, (float) lineRectangle.Height));
              }
              if (this.highlight != null && (this.highlight.OpenBrace.Y == lineNumber && this.highlight.OpenBrace.X == num1 || this.highlight.CloseBrace.Y == lineNumber && this.highlight.CloseBrace.X == num1))
                this.DrawBracketHighlight(g, new Rectangle((int) x, lineRectangle.Y, (int) ((double) physicalXPos - (double) x) - 1, lineRectangle.Height - 1));
              this.physicalColumn += word.Length;
              num1 += word.Length;
              break;
            case TextWordType.Space:
              RectangleF rectangleF1 = new RectangleF(physicalXPos, (float) lineRectangle.Y, (float) Math.Ceiling((double) this.SpaceWidth), (float) lineRectangle.Height);
              Color color2 = colorFor3.Color;
              Brush brush4;
              if (ColumnRange.WholeColumn.Equals((object) selectionAtLine) || num1 >= selectionAtLine.StartColumn && num1 < selectionAtLine.EndColumn)
              {
                brush4 = brush2;
              }
              else
              {
                Brush markerBrushAt2 = this.GetMarkerBrushAt(lineSegment.Offset + num1, 1, ref color2, out markers);
                brush4 = flag || markerBrushAt2 == null ? (flag || textWord.SyntaxColor == null || !textWord.SyntaxColor.HasBackground ? brush3 : BrushRegistry.GetBrush(textWord.SyntaxColor.BackgroundColor)) : markerBrushAt2;
              }
              g.FillRectangle(brush4, rectangleF1);
              if (this.TextEditorProperties.ShowSpaces)
                this.DrawSpaceMarker(g, color2, physicalXPos, (float) lineRectangle.Y);
              foreach (TextMarker marker in markers)
              {
                if (marker.TextMarkerType != TextMarkerType.SolidBlock)
                  this.DrawMarker(g, marker, rectangleF1);
              }
              physicalXPos += this.SpaceWidth;
              ++num1;
              ++this.physicalColumn;
              break;
            case TextWordType.Tab:
              this.physicalColumn += this.TextEditorProperties.TabIndent;
              this.physicalColumn = this.physicalColumn / this.TextEditorProperties.TabIndent * this.TextEditorProperties.TabIndent;
              float num4 = (float) (int) (((double) physicalXPos + 4.0 - (double) lineRectangle.X) / (double) this.WideSpaceWidth / (double) this.TextEditorProperties.TabIndent) * this.WideSpaceWidth * (float) this.TextEditorProperties.TabIndent + (float) lineRectangle.X + this.WideSpaceWidth * (float) this.TextEditorProperties.TabIndent;
              RectangleF rectangleF2 = new RectangleF(physicalXPos, (float) lineRectangle.Y, (float) Math.Ceiling((double) num4 - (double) physicalXPos), (float) lineRectangle.Height);
              Color color3 = colorFor2.Color;
              Brush brush5;
              if (ColumnRange.WholeColumn.Equals((object) selectionAtLine) || num1 >= selectionAtLine.StartColumn && num1 <= selectionAtLine.EndColumn - 1)
              {
                brush5 = brush2;
              }
              else
              {
                Brush markerBrushAt2 = this.GetMarkerBrushAt(lineSegment.Offset + num1, 1, ref color3, out markers);
                brush5 = flag || markerBrushAt2 == null ? (flag || textWord.SyntaxColor == null || !textWord.SyntaxColor.HasBackground ? brush3 : BrushRegistry.GetBrush(textWord.SyntaxColor.BackgroundColor)) : markerBrushAt2;
              }
              g.FillRectangle(brush5, rectangleF2);
              if (this.TextEditorProperties.ShowTabs)
                this.DrawTabMarker(g, color3, physicalXPos, (float) lineRectangle.Y);
              foreach (TextMarker marker in markers)
              {
                if (marker.TextMarkerType != TextMarkerType.SolidBlock)
                  this.DrawMarker(g, marker, rectangleF2);
              }
              physicalXPos = num4;
              ++num1;
              break;
          }
        }
      }
      return physicalXPos;
    }

    private float DrawDocumentWord(Graphics g, string word, Point position, Font font, Color foreColor, Brush backBrush)
    {
      if (word == null || word.Length == 0)
        return 0.0f;
      if (word.Length > 1000)
      {
        float num = 0.0f;
        int startIndex = 0;
        while (startIndex < word.Length)
        {
          Point position1 = position;
          position1.X += (int) num;
          if (startIndex + 1000 < word.Length)
            num += this.DrawDocumentWord(g, word.Substring(startIndex, 1000), position1, font, foreColor, backBrush);
          else
            num += this.DrawDocumentWord(g, word.Substring(startIndex, word.Length - startIndex), position1, font, foreColor, backBrush);
          startIndex += 1000;
        }
        return num;
      }
      float num1 = this.MeasureStringWidth(g, word, font);
      g.FillRectangle(backBrush, new RectangleF((float) position.X, (float) position.Y, (float) Math.Ceiling((double) num1 + 1.0), (float) this.FontHeight));
      g.DrawString(word, font, BrushRegistry.GetBrush(foreColor), (float) position.X, (float) position.Y, this.measureStringFormat);
      return num1;
    }

    private float MeasureStringWidth(Graphics g, string word, Font font)
    {
      if (word == null || word.Length == 0)
        return 0.0f;
      if (word.Length > 1000)
      {
        float num = 0.0f;
        int startIndex = 0;
        while (startIndex < word.Length)
        {
          if (startIndex + 1000 < word.Length)
            num += this.MeasureStringWidth(g, word.Substring(startIndex, 1000), font);
          else
            num += this.MeasureStringWidth(g, word.Substring(startIndex, word.Length - startIndex), font);
          startIndex += 1000;
        }
        return num;
      }
      float num1;
      if (this.measureCache.TryGetValue(new TextView.WordFontPair(word, font), out num1))
        return num1;
      if (this.measureCache.Count > 1000)
        this.measureCache.Clear();
      Rectangle rectangle = new Rectangle(0, 0, 32768, 1000);
      CharacterRange[] ranges = new CharacterRange[1]
      {
        new CharacterRange(0, word.Length)
      };
      Region[] regionArray = new Region[1];
      this.measureStringFormat.SetMeasurableCharacterRanges(ranges);
      float right = g.MeasureCharacterRanges(word, font, (RectangleF) rectangle, this.measureStringFormat)[0].GetBounds(g).Right;
      this.measureCache.Add(new TextView.WordFontPair(word, font), right);
      return right;
    }

    public float GetWidth(char ch, Font font)
    {
      if (!this.fontBoundCharWidth.ContainsKey(font))
        this.fontBoundCharWidth.Add(font, new Dictionary<char, float>());
      if (this.fontBoundCharWidth[font].ContainsKey(ch))
        return this.fontBoundCharWidth[font][ch];
      using (Graphics graphics = this.textArea.CreateGraphics())
        return this.GetWidth(graphics, ch, font);
    }

    public float GetWidth(Graphics g, char ch, Font font)
    {
      if (!this.fontBoundCharWidth.ContainsKey(font))
        this.fontBoundCharWidth.Add(font, new Dictionary<char, float>());
      if (!this.fontBoundCharWidth[font].ContainsKey(ch))
        this.fontBoundCharWidth[font].Add(ch, this.MeasureStringWidth(g, ch.ToString(), font));
      return this.fontBoundCharWidth[font][ch];
    }

    public int GetVisualColumn(int logicalLine, int logicalColumn)
    {
      int column = 0;
      using (Graphics graphics = this.textArea.CreateGraphics())
      {
        double num = (double) this.CountColumns(ref column, 0, logicalColumn, logicalLine, graphics);
      }
      return column;
    }

    public int GetVisualColumnFast(LineSegment line, int logicalColumn)
    {
      int offset = line.Offset;
      int tabIndent = this.Document.TextEditorProperties.TabIndent;
      int num = 0;
      for (int index = 0; index < logicalColumn; ++index)
      {
        if ((index < line.Length ? (int) this.Document.GetCharAt(offset + index) : (int) ' ') == 9)
          num = (num + tabIndent) / tabIndent * tabIndent;
        else
          ++num;
      }
      return num;
    }

    public Point GetLogicalPosition(int xPos, int yPos)
    {
      xPos += (int) ((double) this.textArea.VirtualTop.X * (double) this.WideSpaceWidth);
      return this.GetLogicalColumn(this.Document.GetFirstLogicalLine(Math.Max(0, (yPos + this.textArea.VirtualTop.Y) / this.fontHeight)), xPos);
    }

    public int GetLogicalLine(Point mousepos)
    {
      return this.Document.GetFirstLogicalLine(Math.Max(0, (mousepos.Y + this.textArea.VirtualTop.Y) / this.fontHeight));
    }

    public Point GetLogicalColumn(int firstLogicalLine, int xPos)
    {
      float wideSpaceWidth = this.WideSpaceWidth;
      LineSegment lineSegment = firstLogicalLine < this.Document.TotalNumberOfLines ? this.Document.GetLineSegment(firstLogicalLine) : (LineSegment) null;
      if (lineSegment == null)
        return new Point((int) ((double) xPos / (double) wideSpaceWidth), firstLogicalLine);
      int num1 = firstLogicalLine;
      int tabIndent = this.Document.TextEditorProperties.TabIndent;
      int num2 = 0;
      int x = 0;
      float num3 = 0.0f;
      List<FoldMarker> foldingsWithStart = this.textArea.Document.FoldingManager.GetFoldedFoldingsWithStart(num1);
      while (true)
      {
        float num4 = num3;
        if (foldingsWithStart.Count > 0)
        {
          foreach (FoldMarker foldMarker in foldingsWithStart)
          {
            if (foldMarker.IsFolded && x >= foldMarker.StartColumn && (x < foldMarker.EndColumn || num1 != foldMarker.EndLine))
            {
              num2 += foldMarker.FoldText.Length;
              num3 += (float) foldMarker.FoldText.Length * wideSpaceWidth;
              if ((double) xPos <= (double) num3 - ((double) num3 - (double) num4) / 2.0)
                return new Point(x, num1);
              x = foldMarker.EndColumn;
              if (num1 != foldMarker.EndLine)
              {
                num1 = foldMarker.EndLine;
                lineSegment = this.Document.GetLineSegment(num1);
                foldingsWithStart = this.textArea.Document.FoldingManager.GetFoldedFoldingsWithStart(num1);
                break;
              }
              break;
            }
          }
        }
        char ch = x >= lineSegment.Length ? ' ' : this.Document.GetCharAt(lineSegment.Offset + x);
        if ((int) ch == 9)
        {
          int num5 = num2;
          num2 = (num2 + tabIndent) / tabIndent * tabIndent;
          num3 += (float) (num2 - num5) * wideSpaceWidth;
        }
        else
        {
          num3 += this.GetWidth(ch, this.TextEditorProperties.Font);
          ++num2;
        }
        if ((double) xPos > (double) num3 - ((double) num3 - (double) num4) / 2.0)
          ++x;
        else
          break;
      }
      return new Point(x, num1);
    }

    public FoldMarker GetFoldMarkerFromPosition(int xPos, int yPos)
    {
      xPos += (int) ((double) this.textArea.VirtualTop.X * (double) this.WideSpaceWidth);
      return this.GetFoldMarkerFromColumn(this.Document.GetFirstLogicalLine((yPos + this.textArea.VirtualTop.Y) / this.fontHeight), xPos);
    }

    private FoldMarker GetFoldMarkerFromColumn(int firstLogicalLine, int xPos)
    {
      LineSegment lineSegment = firstLogicalLine < this.Document.TotalNumberOfLines ? this.Document.GetLineSegment(firstLogicalLine) : (LineSegment) null;
      if (lineSegment == null)
        return (FoldMarker) null;
      int lineNumber = firstLogicalLine;
      int tabIndent = this.Document.TextEditorProperties.TabIndent;
      int num1 = 0;
      int num2 = 0;
      float num3 = 0.0f;
      List<FoldMarker> foldingsWithStart = this.textArea.Document.FoldingManager.GetFoldedFoldingsWithStart(lineNumber);
      while (true)
      {
        float num4 = num3;
        if (foldingsWithStart.Count > 0)
        {
          foreach (FoldMarker foldMarker in foldingsWithStart)
          {
            if (foldMarker.IsFolded && num2 >= foldMarker.StartColumn && (num2 < foldMarker.EndColumn || lineNumber != foldMarker.EndLine))
            {
              num1 += foldMarker.FoldText.Length;
              num3 += (float) foldMarker.FoldText.Length * this.WideSpaceWidth;
              if ((double) xPos <= (double) num3)
                return foldMarker;
              num2 = foldMarker.EndColumn;
              if (lineNumber != foldMarker.EndLine)
              {
                lineNumber = foldMarker.EndLine;
                lineSegment = this.Document.GetLineSegment(lineNumber);
                foldingsWithStart = this.textArea.Document.FoldingManager.GetFoldedFoldingsWithStart(lineNumber);
                break;
              }
              break;
            }
          }
        }
        char ch = num2 >= lineSegment.Length ? ' ' : this.Document.GetCharAt(lineSegment.Offset + num2);
        if ((int) ch == 9)
        {
          int num5 = num1;
          num1 = (num1 + tabIndent) / tabIndent * tabIndent;
          num3 += (float) (num1 - num5) * this.WideSpaceWidth;
        }
        else
        {
          num3 += this.GetWidth(ch, this.TextEditorProperties.Font);
          ++num1;
        }
        if ((double) xPos > (double) num3 - ((double) num3 - (double) num4) / 2.0)
          ++num2;
        else
          break;
      }
      return (FoldMarker) null;
    }

    private float CountColumns(ref int column, int start, int end, int logicalLine, Graphics g)
    {
      if (start > end)
        throw new ArgumentException("start > end");
      if (start == end)
        return 0.0f;
      float spaceWidth = this.SpaceWidth;
      float num1 = 0.0f;
      int tabIndent = this.Document.TextEditorProperties.TabIndent;
      LineSegment lineSegment = this.Document.GetLineSegment(logicalLine);
      List<TextWord> words = lineSegment.Words;
      if (words == null)
        return 0.0f;
      int count = words.Count;
      int val1 = 0;
      for (int index = 0; index < count; ++index)
      {
        TextWord textWord = words[index];
        if (val1 < end)
        {
          if (val1 + textWord.Length >= start)
          {
            switch (textWord.Type)
            {
              case TextWordType.Word:
                int num2 = Math.Max(val1, start);
                int length = Math.Min(val1 + textWord.Length, end) - num2;
                string text = this.Document.GetText(lineSegment.Offset + num2, length);
                num1 += this.MeasureStringWidth(g, text, textWord.Font ?? this.TextEditorProperties.Font);
                break;
              case TextWordType.Space:
                num1 += spaceWidth;
                break;
              case TextWordType.Tab:
                num1 = (float) ((int) (((double) num1 + 4.0) / (double) tabIndent / (double) this.WideSpaceWidth) * tabIndent) * this.WideSpaceWidth + (float) tabIndent * this.WideSpaceWidth;
                break;
            }
            val1 += textWord.Length;
          }
        }
        else
          break;
      }
      for (int length = lineSegment.Length; length < end; ++length)
        num1 += this.WideSpaceWidth;
      column += (int) (((double) num1 + 1.0) / (double) this.WideSpaceWidth);
      return num1;
    }

    public int GetDrawingXPos(int logicalLine, int logicalColumn)
    {
      List<FoldMarker> levelFoldedFoldings = this.Document.FoldingManager.GetTopLevelFoldedFoldings();
      FoldMarker foldMarker1 = (FoldMarker) null;
      int index1;
      for (index1 = levelFoldedFoldings.Count - 1; index1 >= 0; --index1)
      {
        foldMarker1 = levelFoldedFoldings[index1];
        if (foldMarker1.StartLine >= logicalLine && (foldMarker1.StartLine != logicalLine || foldMarker1.StartColumn >= logicalColumn))
        {
          FoldMarker foldMarker2 = levelFoldedFoldings[index1 / 2];
          if (foldMarker2.StartLine > logicalLine || foldMarker2.StartLine == logicalLine && foldMarker2.StartColumn >= logicalColumn)
            index1 /= 2;
        }
        else
          break;
      }
      int column = 0;
      int tabIndent = this.Document.TextEditorProperties.TabIndent;
      Graphics graphics = this.textArea.CreateGraphics();
      if (foldMarker1 == null || foldMarker1.StartLine >= logicalLine && (foldMarker1.StartLine != logicalLine || foldMarker1.StartColumn >= logicalColumn))
        return (int) ((double) this.CountColumns(ref column, 0, logicalColumn, logicalLine, graphics) - (double) this.textArea.VirtualTop.X * (double) this.WideSpaceWidth);
      if (foldMarker1.EndLine > logicalLine || foldMarker1.EndLine == logicalLine && foldMarker1.EndColumn > logicalColumn)
      {
        logicalColumn = foldMarker1.StartColumn;
        logicalLine = foldMarker1.StartLine;
        --index1;
      }
      int num1 = index1;
      while (index1 >= 0 && levelFoldedFoldings[index1].EndLine >= logicalLine)
        --index1;
      int num2 = index1 + 1;
      if (num1 < num2)
        return (int) ((double) this.CountColumns(ref column, 0, logicalColumn, logicalLine, graphics) - (double) this.textArea.VirtualTop.X * (double) this.WideSpaceWidth);
      int start = 0;
      float num3 = 0.0f;
      for (int index2 = num2; index2 <= num1; ++index2)
      {
        FoldMarker foldMarker2 = levelFoldedFoldings[index2];
        float num4 = num3 + this.CountColumns(ref column, start, foldMarker2.StartColumn, foldMarker2.StartLine, graphics);
        start = foldMarker2.EndColumn;
        column += foldMarker2.FoldText.Length;
        num3 = num4 + this.MeasureStringWidth(graphics, foldMarker2.FoldText, this.TextEditorProperties.Font);
      }
      float num5 = num3 + this.CountColumns(ref column, start, logicalColumn, logicalLine, graphics);
      graphics.Dispose();
      return (int) ((double) num5 - (double) this.textArea.VirtualTop.X * (double) this.WideSpaceWidth);
    }

    private void DrawBracketHighlight(Graphics g, Rectangle rect)
    {
      g.FillRectangle(BrushRegistry.GetBrush(Color.FromArgb(50, 0, 0, (int) byte.MaxValue)), rect);
      g.DrawRectangle(Pens.Blue, rect);
    }

    private void DrawInvalidLineMarker(Graphics g, float x, float y)
    {
      HighlightColor colorFor = this.textArea.Document.HighlightingStrategy.GetColorFor("InvalidLines");
      g.DrawString("~", colorFor.Font, BrushRegistry.GetBrush(colorFor.Color), x, y, this.measureStringFormat);
    }

    private void DrawSpaceMarker(Graphics g, Color color, float x, float y)
    {
      HighlightColor colorFor = this.textArea.Document.HighlightingStrategy.GetColorFor("SpaceMarkers");
      g.DrawString("·", colorFor.Font, BrushRegistry.GetBrush(color), x, y, this.measureStringFormat);
    }

    private void DrawTabMarker(Graphics g, Color color, float x, float y)
    {
      HighlightColor colorFor = this.textArea.Document.HighlightingStrategy.GetColorFor("TabMarkers");
      g.DrawString("»", colorFor.Font, BrushRegistry.GetBrush(color), x, y, this.measureStringFormat);
    }

    private float DrawEOLMarker(Graphics g, Color color, Brush backBrush, float x, float y)
    {
      float width = this.GetWidth('¶', this.TextEditorProperties.Font);
      g.FillRectangle(backBrush, new RectangleF(x, y, width, (float) this.fontHeight));
      HighlightColor colorFor = this.textArea.Document.HighlightingStrategy.GetColorFor("EOLMarkers");
      g.DrawString("¶", colorFor.Font, BrushRegistry.GetBrush(color), x, y, this.measureStringFormat);
      return width;
    }

    private void DrawVerticalRuler(Graphics g, Rectangle lineRectangle)
    {
      if (this.TextEditorProperties.VerticalRulerRow < this.textArea.VirtualTop.X)
        return;
      HighlightColor colorFor = this.textArea.Document.HighlightingStrategy.GetColorFor("VRuler");
      int num = (int) ((double) this.drawingPosition.Left + (double) this.WideSpaceWidth * (double) (this.TextEditorProperties.VerticalRulerRow - this.textArea.VirtualTop.X));
      g.DrawLine(BrushRegistry.GetPen(colorFor.Color), num, lineRectangle.Top, num, lineRectangle.Bottom);
    }

    private struct WordFontPair
    {
      private string word;
      private Font font;

      public WordFontPair(string word, Font font)
      {
        this.word = word;
        this.font = font;
      }

      public override bool Equals(object obj)
      {
        TextView.WordFontPair wordFontPair = (TextView.WordFontPair) obj;
        if (!this.word.Equals(wordFontPair.word))
          return false;
        return this.font.Equals((object) wordFontPair.font);
      }

      public override int GetHashCode()
      {
        return this.word.GetHashCode() ^ this.font.GetHashCode();
      }
    }
  }
}
