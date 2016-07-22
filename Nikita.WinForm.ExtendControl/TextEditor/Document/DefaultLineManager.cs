// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.DefaultLineManager
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System;
using System.Collections.Generic;

namespace Nikita.WinForm.ExtendControl.Document
{
  internal class DefaultLineManager : ILineManager
  {
    private List<LineSegment> lineCollection = new List<LineSegment>();
    private List<LineSegment> markLines = new List<LineSegment>();
    private DefaultLineManager.DelimiterSegment delimiterSegment = new DefaultLineManager.DelimiterSegment();
    private IDocument document;
    private IHighlightingStrategy highlightingStrategy;
    private int textLength;

    public List<LineSegment> LineSegmentCollection
    {
      get
      {
        return this.lineCollection;
      }
    }

    public int TotalNumberOfLines
    {
      get
      {
        if (this.lineCollection.Count == 0)
          return 1;
        if (this.lineCollection[this.lineCollection.Count - 1].DelimiterLength <= 0)
          return this.lineCollection.Count;
        return this.lineCollection.Count + 1;
      }
    }

    public IHighlightingStrategy HighlightingStrategy
    {
      get
      {
        return this.highlightingStrategy;
      }
      set
      {
        if (this.highlightingStrategy == value)
          return;
        this.highlightingStrategy = value;
        if (this.highlightingStrategy == null)
          return;
        this.highlightingStrategy.MarkTokens(this.document);
      }
    }

    public event LineLengthEventHandler LineLengthChanged;

    public event LineManagerEventHandler LineCountChanged;

    public DefaultLineManager(IDocument document, IHighlightingStrategy highlightingStrategy)
    {
      this.document = document;
      this.highlightingStrategy = highlightingStrategy;
    }

    public int GetLineNumberForOffset(int offset)
    {
      if (offset < 0 || offset > this.textLength)
        throw new ArgumentOutOfRangeException("offset", (object) offset, "should be between 0 and " + (object) this.textLength);
      if (offset != this.textLength)
        return this.FindLineNumber(offset);
      if (this.lineCollection.Count == 0)
        return 0;
      if (this.lineCollection[this.lineCollection.Count - 1].DelimiterLength <= 0)
        return this.lineCollection.Count - 1;
      return this.lineCollection.Count;
    }

    public LineSegment GetLineSegmentForOffset(int offset)
    {
      if (offset < 0 || offset > this.textLength)
        throw new ArgumentOutOfRangeException("offset", (object) offset, "should be between 0 and " + (object) this.textLength);
      if (offset != this.textLength)
        return this.GetLineSegment(this.FindLineNumber(offset));
      if (this.lineCollection.Count == 0)
        return new LineSegment(0, 0);
      LineSegment lineSegment = this.lineCollection[this.lineCollection.Count - 1];
      if (lineSegment.DelimiterLength <= 0)
        return lineSegment;
      return new LineSegment(this.textLength, 0);
    }

    public LineSegment GetLineSegment(int lineNr)
    {
      if (lineNr < 0 || lineNr > this.lineCollection.Count)
        throw new ArgumentOutOfRangeException("lineNr", (object) lineNr, "should be between 0 and " + (object) this.lineCollection.Count);
      if (lineNr != this.lineCollection.Count)
        return this.lineCollection[lineNr];
      if (this.lineCollection.Count == 0)
        return new LineSegment(0, 0);
      LineSegment lineSegment = this.lineCollection[this.lineCollection.Count - 1];
      if (lineSegment.DelimiterLength <= 0)
        return lineSegment;
      return new LineSegment(lineSegment.Offset + lineSegment.TotalLength, 0);
    }

    private int Insert(int lineNumber, int offset, string text)
    {
      if (text == null || text.Length == 0)
        return 0;
      this.textLength += text.Length;
      if (this.lineCollection.Count == 0 || lineNumber >= this.lineCollection.Count)
        return this.CreateLines(text, this.lineCollection.Count, offset);
      LineSegment lineSegment1 = this.lineCollection[lineNumber];
      ISegment segment = this.NextDelimiter(text, 0);
      if (segment == null || segment.Offset < 0)
      {
        lineSegment1.TotalLength += text.Length;
        this.markLines.Add(lineSegment1);
        this.OnLineLengthChanged(new LineLengthEventArgs(this.document, lineNumber, offset - lineSegment1.Offset, text.Length));
        return 0;
      }
      int length = lineSegment1.Offset + lineSegment1.TotalLength - offset;
      if (length > 0)
      {
        LineSegment lineSegment2 = new LineSegment(offset, length);
        lineSegment2.DelimiterLength = lineSegment1.DelimiterLength;
        lineSegment2.Offset += text.Length;
        this.markLines.Add(lineSegment2);
        if (length - lineSegment1.DelimiterLength < 0)
          throw new ApplicationException("tried to insert inside delimiter string " + lineSegment2.ToString() + "!!!");
        this.lineCollection.Insert(lineNumber + 1, lineSegment2);
        this.OnLineCountChanged(new LineManagerEventArgs(this.document, lineNumber - 1, 1));
      }
      lineSegment1.DelimiterLength = segment.Length;
      int offset1 = offset + segment.Offset + segment.Length;
      lineSegment1.TotalLength = offset1 - lineSegment1.Offset;
      this.markLines.Add(lineSegment1);
      text = text.Substring(segment.Offset + segment.Length);
      return this.CreateLines(text, lineNumber + 1, offset1) + 1;
    }

    private bool Remove(int lineNumber, int offset, int length)
    {
      if (length == 0)
        return false;
      int num = this.GetNumberOfLines(lineNumber, offset, length) - 1;
      LineSegment lineSegment1 = this.lineCollection[lineNumber];
      if (lineNumber == this.lineCollection.Count - 1 && num > 0)
      {
        lineSegment1.TotalLength -= length;
        lineSegment1.DelimiterLength = 0;
      }
      else
      {
        ++lineNumber;
        for (int index = 1; index <= num; ++index)
        {
          if (lineNumber == this.lineCollection.Count)
          {
            lineSegment1.DelimiterLength = 0;
            break;
          }
          LineSegment lineSegment2 = this.lineCollection[lineNumber];
          lineSegment1.TotalLength += lineSegment2.TotalLength;
          lineSegment1.DelimiterLength = lineSegment2.DelimiterLength;
          this.lineCollection.RemoveAt(lineNumber);
        }
        lineSegment1.TotalLength -= length;
        if (lineNumber < this.lineCollection.Count && num > 0)
          this.markLines.Add(this.lineCollection[lineNumber]);
      }
      this.textLength -= length;
      if (lineSegment1.TotalLength == 0)
      {
        this.lineCollection.Remove(lineSegment1);
        this.OnLineCountChanged(new LineManagerEventArgs(this.document, lineNumber, -num));
        return true;
      }
      this.markLines.Add(lineSegment1);
      this.OnLineCountChanged(new LineManagerEventArgs(this.document, lineNumber, -num));
      return false;
    }

    public void Insert(int offset, string text)
    {
      this.Replace(offset, 0, text);
    }

    public void Remove(int offset, int length)
    {
      this.Replace(offset, length, string.Empty);
    }

    public void Replace(int offset, int length, string text)
    {
      int lineNumberForOffset = this.GetLineNumberForOffset(offset);
      int lineNumber1 = lineNumberForOffset;
      if (this.Remove(lineNumberForOffset, offset, length))
        --lineNumberForOffset;
      int lineNumber2 = lineNumberForOffset + this.Insert(lineNumber1, offset, text);
      int delta = -length;
      if (text != null)
        delta = text.Length + delta;
      if (delta != 0)
        this.AdaptLineOffsets(lineNumber2, delta);
      this.RunHighlighter();
    }

    private void RunHighlighter()
    {
      DateTime now = DateTime.Now;
      if (this.highlightingStrategy != null)
        this.highlightingStrategy.MarkTokens(this.document, this.markLines);
      this.markLines.Clear();
    }

    public void SetContent(string text)
    {
      this.lineCollection.Clear();
      if (text == null)
        return;
      this.textLength = text.Length;
      this.CreateLines(text, 0, 0);
      this.RunHighlighter();
    }

    private void AdaptLineOffsets(int lineNumber, int delta)
    {
      for (int index = lineNumber + 1; index < this.lineCollection.Count; ++index)
        this.lineCollection[index].Offset += delta;
    }

    private int GetNumberOfLines(int startLine, int offset, int length)
    {
      if (length == 0)
        return 1;
      int offset1 = offset + length;
      LineSegment lineSegment = this.lineCollection[startLine];
      if (lineSegment.DelimiterLength == 0 || lineSegment.Offset + lineSegment.TotalLength > offset1)
        return 1;
      if (lineSegment.Offset + lineSegment.TotalLength == offset1)
        return 2;
      return this.GetLineNumberForOffset(offset1) - startLine + 1;
    }

    private int FindLineNumber(int offset)
    {
      if (this.lineCollection.Count == 0)
        return -1;
      int index1 = 0;
      int num = this.lineCollection.Count - 1;
      while (index1 < num)
      {
        int index2 = (index1 + num) / 2;
        LineSegment lineSegment = this.lineCollection[index2];
        if (offset < lineSegment.Offset)
          num = index2 - 1;
        else if (offset > lineSegment.Offset)
        {
          index1 = index2 + 1;
        }
        else
        {
          index1 = index2;
          break;
        }
      }
      if (this.lineCollection[index1].Offset <= offset)
        return index1;
      return index1 - 1;
    }

    private int CreateLines(string text, int insertPosition, int offset)
    {
      int linesMoved = 0;
      int offset1 = 0;
      for (ISegment segment = this.NextDelimiter(text, 0); segment != null && segment.Offset >= 0; segment = this.NextDelimiter(text, offset1))
      {
        int num = segment.Offset + (segment.Length - 1);
        LineSegment lineSegment = new LineSegment(offset + offset1, offset + num, segment.Length);
        this.markLines.Add(lineSegment);
        if (insertPosition + linesMoved >= this.lineCollection.Count)
          this.lineCollection.Add(lineSegment);
        else
          this.lineCollection.Insert(insertPosition + linesMoved, lineSegment);
        ++linesMoved;
        offset1 = num + 1;
      }
      if (offset1 < text.Length)
      {
        if (insertPosition + linesMoved < this.lineCollection.Count)
        {
          LineSegment lineSegment = this.lineCollection[insertPosition + linesMoved];
          int num = text.Length - offset1;
          lineSegment.Offset -= num;
          lineSegment.TotalLength += num;
        }
        else
        {
          LineSegment lineSegment = new LineSegment(offset + offset1, text.Length - offset1);
          this.markLines.Add(lineSegment);
          this.lineCollection.Add(lineSegment);
          ++linesMoved;
        }
      }
      this.OnLineCountChanged(new LineManagerEventArgs(this.document, insertPosition, linesMoved));
      return linesMoved;
    }

    public int GetVisibleLine(int logicalLineNumber)
    {
      if (!this.document.TextEditorProperties.EnableFolding)
        return logicalLineNumber;
      int num1 = 0;
      int num2 = 0;
      foreach (FoldMarker foldMarker in this.document.FoldingManager.GetTopLevelFoldedFoldings())
      {
        if (foldMarker.StartLine < logicalLineNumber)
        {
          if (foldMarker.StartLine >= num2)
          {
            num1 += foldMarker.StartLine - num2;
            if (foldMarker.EndLine > logicalLineNumber)
              return num1;
            num2 = foldMarker.EndLine;
          }
        }
        else
          break;
      }
      return num1 + (logicalLineNumber - num2);
    }

    public int GetFirstLogicalLine(int visibleLineNumber)
    {
      if (!this.document.TextEditorProperties.EnableFolding)
        return visibleLineNumber;
      int num1 = 0;
      int num2 = 0;
      List<FoldMarker> levelFoldedFoldings = this.document.FoldingManager.GetTopLevelFoldedFoldings();
      foreach (FoldMarker foldMarker in levelFoldedFoldings)
      {
        if (foldMarker.StartLine >= num2)
        {
          if (num1 + foldMarker.StartLine - num2 < visibleLineNumber)
          {
            num1 += foldMarker.StartLine - num2;
            num2 = foldMarker.EndLine;
          }
          else
            break;
        }
      }
      levelFoldedFoldings.Clear();
      return num2 + visibleLineNumber - num1;
    }

    public int GetLastLogicalLine(int visibleLineNumber)
    {
      if (!this.document.TextEditorProperties.EnableFolding)
        return visibleLineNumber;
      return this.GetFirstLogicalLine(visibleLineNumber + 1) - 1;
    }

    public int GetNextVisibleLineAbove(int lineNumber, int lineCount)
    {
      int num = lineNumber;
      if (this.document.TextEditorProperties.EnableFolding)
      {
        for (int index = 0; index < lineCount && num < this.TotalNumberOfLines; ++index)
        {
          ++num;
          while (num < this.TotalNumberOfLines && (num >= this.lineCollection.Count || !this.document.FoldingManager.IsLineVisible(num)))
            ++num;
        }
      }
      else
        num += lineCount;
      return Math.Min(this.TotalNumberOfLines - 1, num);
    }

    public int GetNextVisibleLineBelow(int lineNumber, int lineCount)
    {
      int num = lineNumber;
      if (this.document.TextEditorProperties.EnableFolding)
      {
        for (int index = 0; index < lineCount; ++index)
        {
          --num;
          while (num >= 0 && !this.document.FoldingManager.IsLineVisible(num))
            --num;
        }
      }
      else
        num -= lineCount;
      return Math.Max(0, num);
    }

    protected virtual void OnLineCountChanged(LineManagerEventArgs e)
    {
      if (this.LineCountChanged == null)
        return;
      this.LineCountChanged((object) this, e);
    }

    private ISegment NextDelimiter(string text, int offset)
    {
      for (int index = offset; index < text.Length; ++index)
      {
        switch (text[index])
        {
          case '\n':
            this.delimiterSegment.Offset = index;
            this.delimiterSegment.Length = 1;
            return (ISegment) this.delimiterSegment;
          case '\r':
            if (index + 1 < text.Length && (int) text[index + 1] == 10)
            {
              this.delimiterSegment.Offset = index;
              this.delimiterSegment.Length = 2;
              return (ISegment) this.delimiterSegment;
            }
            goto case '\n';
          //default:
            //goto default;
        }
      }
      return (ISegment) null;
    }

    protected virtual void OnLineLengthChanged(LineLengthEventArgs e)
    {
      if (this.LineLengthChanged == null)
        return;
      this.LineLengthChanged((object) this, e);
    }

    public class DelimiterSegment : ISegment
    {
      private int offset;
      private int length;

      public int Offset
      {
        get
        {
          return this.offset;
        }
        set
        {
          this.offset = value;
        }
      }

      public int Length
      {
        get
        {
          return this.length;
        }
        set
        {
          this.length = value;
        }
      }
    }
  }
}
