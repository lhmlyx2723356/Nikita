// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.ILineManager
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Collections.Generic;

namespace Nikita.WinForm.ExtendControl.Document
{
  public interface ILineManager
  {
    List<LineSegment> LineSegmentCollection { get; }

    int TotalNumberOfLines { get; }

    IHighlightingStrategy HighlightingStrategy { get; set; }

    event LineManagerEventHandler LineCountChanged;

    event LineLengthEventHandler LineLengthChanged;

    int GetLineNumberForOffset(int offset);

    LineSegment GetLineSegmentForOffset(int offset);

    LineSegment GetLineSegment(int lineNumber);

    void Insert(int offset, string text);

    void Remove(int offset, int length);

    void Replace(int offset, int length, string text);

    void SetContent(string text);

    int GetFirstLogicalLine(int lineNumber);

    int GetLastLogicalLine(int lineNumber);

    int GetVisibleLine(int lineNumber);

    int GetNextVisibleLineAbove(int lineNumber, int lineCount);

    int GetNextVisibleLineBelow(int lineNumber, int lineCount);
  }
}
