// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.IDocument
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Undo;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Document
{
  public interface IDocument
  {
    ITextEditorProperties TextEditorProperties { get; set; }

    UndoStack UndoStack { get; }

    bool ReadOnly { get; set; }

    IFormattingStrategy FormattingStrategy { get; set; }

    ITextBufferStrategy TextBufferStrategy { get; }

    FoldingManager FoldingManager { get; }

    IHighlightingStrategy HighlightingStrategy { get; set; }

    BookmarkManager BookmarkManager { get; }

    ICustomLineManager CustomLineManager { get; }

    MarkerStrategy MarkerStrategy { get; }

    List<LineSegment> LineSegmentCollection { get; }

    int TotalNumberOfLines { get; }

    string TextContent { get; set; }

    int TextLength { get; }

    List<TextAreaUpdate> UpdateQueue { get; }

    event EventHandler UpdateCommited;

    event DocumentEventHandler DocumentAboutToBeChanged;

    event DocumentEventHandler DocumentChanged;

    event EventHandler TextContentChanged;

    int GetLineNumberForOffset(int offset);

    LineSegment GetLineSegmentForOffset(int offset);

    LineSegment GetLineSegment(int lineNumber);

    int GetFirstLogicalLine(int lineNumber);

    int GetLastLogicalLine(int lineNumber);

    int GetVisibleLine(int lineNumber);

    int GetNextVisibleLineAbove(int lineNumber, int lineCount);

    int GetNextVisibleLineBelow(int lineNumber, int lineCount);

    void Insert(int offset, string text);

    void Remove(int offset, int length);

    void Replace(int offset, int length, string text);

    char GetCharAt(int offset);

    string GetText(int offset, int length);

    string GetText(ISegment segment);

    Point OffsetToPosition(int offset);

    int PositionToOffset(Point p);

    void RequestUpdate(TextAreaUpdate update);

    void CommitUpdate();

    void UpdateSegmentListOnDocumentChange<T>(List<T> list, DocumentEventArgs e) where T : ISegment;
  }
}
