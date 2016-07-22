// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.DefaultDocument
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
  internal class DefaultDocument : IDocument
  {
    private UndoStack undoStack = new UndoStack();
    private ITextEditorProperties textEditorProperties = (ITextEditorProperties) new DefaultTextEditorProperties();
    private List<TextAreaUpdate> updateQueue = new List<TextAreaUpdate>();
    private bool readOnly;
    private ILineManager lineTrackingStrategy;
    private ICustomLineManager customLineManager;
    private BookmarkManager bookmarkManager;
    private ITextBufferStrategy textBufferStrategy;
    private IFormattingStrategy formattingStrategy;
    private FoldingManager foldingManager;
    private MarkerStrategy markerStrategy;

    public MarkerStrategy MarkerStrategy
    {
      get
      {
        return this.markerStrategy;
      }
      set
      {
        this.markerStrategy = value;
      }
    }

    public ITextEditorProperties TextEditorProperties
    {
      get
      {
        return this.textEditorProperties;
      }
      set
      {
        this.textEditorProperties = value;
      }
    }

    public UndoStack UndoStack
    {
      get
      {
        return this.undoStack;
      }
    }

    public List<LineSegment> LineSegmentCollection
    {
      get
      {
        return this.lineTrackingStrategy.LineSegmentCollection;
      }
    }

    public bool ReadOnly
    {
      get
      {
        return this.readOnly;
      }
      set
      {
        this.readOnly = value;
      }
    }

    public ILineManager LineManager
    {
      get
      {
        return this.lineTrackingStrategy;
      }
      set
      {
        this.lineTrackingStrategy = value;
      }
    }

    public ITextBufferStrategy TextBufferStrategy
    {
      get
      {
        return this.textBufferStrategy;
      }
      set
      {
        this.textBufferStrategy = value;
      }
    }

    public IFormattingStrategy FormattingStrategy
    {
      get
      {
        return this.formattingStrategy;
      }
      set
      {
        this.formattingStrategy = value;
      }
    }

    public FoldingManager FoldingManager
    {
      get
      {
        return this.foldingManager;
      }
      set
      {
        this.foldingManager = value;
      }
    }

    public IHighlightingStrategy HighlightingStrategy
    {
      get
      {
        return this.lineTrackingStrategy.HighlightingStrategy;
      }
      set
      {
        this.lineTrackingStrategy.HighlightingStrategy = value;
      }
    }

    public int TextLength
    {
      get
      {
        return this.textBufferStrategy.Length;
      }
    }

    public BookmarkManager BookmarkManager
    {
      get
      {
        return this.bookmarkManager;
      }
      set
      {
        this.bookmarkManager = value;
      }
    }

    public ICustomLineManager CustomLineManager
    {
      get
      {
        return this.customLineManager;
      }
      set
      {
        this.customLineManager = value;
      }
    }

    public string TextContent
    {
      get
      {
        return this.GetText(0, this.textBufferStrategy.Length);
      }
      set
      {
        this.OnDocumentAboutToBeChanged(new DocumentEventArgs((IDocument) this, 0, 0, value));
        this.textBufferStrategy.SetContent(value);
        this.lineTrackingStrategy.SetContent(value);
        this.OnDocumentChanged(new DocumentEventArgs((IDocument) this, 0, 0, value));
        this.OnTextContentChanged(EventArgs.Empty);
      }
    }

    public int TotalNumberOfLines
    {
      get
      {
        return this.lineTrackingStrategy.TotalNumberOfLines;
      }
    }

    public List<TextAreaUpdate> UpdateQueue
    {
      get
      {
        return this.updateQueue;
      }
    }

    public event DocumentEventHandler DocumentAboutToBeChanged;

    public event DocumentEventHandler DocumentChanged;

    public event EventHandler UpdateCommited;

    public event EventHandler TextContentChanged;

    public void Insert(int offset, string text)
    {
      if (this.readOnly)
        return;
      this.OnDocumentAboutToBeChanged(new DocumentEventArgs((IDocument) this, offset, -1, text));
      DateTime now1 = DateTime.Now;
      this.textBufferStrategy.Insert(offset, text);
      DateTime now2 = DateTime.Now;
      this.lineTrackingStrategy.Insert(offset, text);
      DateTime now3 = DateTime.Now;
      this.undoStack.Push((IUndoableOperation) new UndoableInsert((IDocument) this, offset, text));
      DateTime now4 = DateTime.Now;
      this.OnDocumentChanged(new DocumentEventArgs((IDocument) this, offset, -1, text));
    }

    public void Remove(int offset, int length)
    {
      if (this.readOnly)
        return;
      this.OnDocumentAboutToBeChanged(new DocumentEventArgs((IDocument) this, offset, length));
      this.undoStack.Push((IUndoableOperation) new UndoableDelete((IDocument) this, offset, this.GetText(offset, length)));
      this.textBufferStrategy.Remove(offset, length);
      this.lineTrackingStrategy.Remove(offset, length);
      this.OnDocumentChanged(new DocumentEventArgs((IDocument) this, offset, length));
    }

    public void Replace(int offset, int length, string text)
    {
      if (this.readOnly)
        return;
      this.OnDocumentAboutToBeChanged(new DocumentEventArgs((IDocument) this, offset, length, text));
      this.undoStack.Push((IUndoableOperation) new UndoableReplace((IDocument) this, offset, this.GetText(offset, length), text));
      this.textBufferStrategy.Replace(offset, length, text);
      this.lineTrackingStrategy.Replace(offset, length, text);
      this.OnDocumentChanged(new DocumentEventArgs((IDocument) this, offset, length, text));
    }

    public char GetCharAt(int offset)
    {
      return this.textBufferStrategy.GetCharAt(offset);
    }

    public string GetText(int offset, int length)
    {
      return this.textBufferStrategy.GetText(offset, length);
    }

    public string GetText(ISegment segment)
    {
      return this.GetText(segment.Offset, segment.Length);
    }

    public int GetLineNumberForOffset(int offset)
    {
      return this.lineTrackingStrategy.GetLineNumberForOffset(offset);
    }

    public LineSegment GetLineSegmentForOffset(int offset)
    {
      return this.lineTrackingStrategy.GetLineSegmentForOffset(offset);
    }

    public LineSegment GetLineSegment(int line)
    {
      return this.lineTrackingStrategy.GetLineSegment(line);
    }

    public int GetFirstLogicalLine(int lineNumber)
    {
      return this.lineTrackingStrategy.GetFirstLogicalLine(lineNumber);
    }

    public int GetLastLogicalLine(int lineNumber)
    {
      return this.lineTrackingStrategy.GetLastLogicalLine(lineNumber);
    }

    public int GetVisibleLine(int lineNumber)
    {
      return this.lineTrackingStrategy.GetVisibleLine(lineNumber);
    }

    public int GetNextVisibleLineAbove(int lineNumber, int lineCount)
    {
      return this.lineTrackingStrategy.GetNextVisibleLineAbove(lineNumber, lineCount);
    }

    public int GetNextVisibleLineBelow(int lineNumber, int lineCount)
    {
      return this.lineTrackingStrategy.GetNextVisibleLineBelow(lineNumber, lineCount);
    }

    public Point OffsetToPosition(int offset)
    {
      int lineNumberForOffset = this.GetLineNumberForOffset(offset);
      LineSegment lineSegment = this.GetLineSegment(lineNumberForOffset);
      return new Point(offset - lineSegment.Offset, lineNumberForOffset);
    }

    public int PositionToOffset(Point p)
    {
      if (p.Y >= this.TotalNumberOfLines)
        return 0;
      LineSegment lineSegment = this.GetLineSegment(p.Y);
      return Math.Min(this.TextLength, lineSegment.Offset + Math.Min(lineSegment.Length, p.X));
    }

    public void UpdateSegmentListOnDocumentChange<T>(List<T> list, DocumentEventArgs e) where T : ISegment
    {
      for (int index = 0; index < list.Count; ++index)
      {
        ISegment segment = (ISegment) list[index];
        if (e.Offset <= segment.Offset && segment.Offset <= e.Offset + e.Length || e.Offset <= segment.Offset + segment.Length && segment.Offset + segment.Length <= e.Offset + e.Length)
        {
          list.RemoveAt(index);
          --index;
        }
        else if (segment.Offset <= e.Offset && e.Offset <= segment.Offset + segment.Length)
        {
          if (e.Text != null)
            segment.Length += e.Text.Length;
          if (e.Length > 0)
            segment.Length -= e.Length;
        }
        else if (segment.Offset >= e.Offset)
        {
          if (e.Text != null)
            segment.Offset += e.Text.Length;
          if (e.Length > 0)
            segment.Offset -= e.Length;
        }
      }
    }

    protected void OnDocumentAboutToBeChanged(DocumentEventArgs e)
    {
      if (this.DocumentAboutToBeChanged == null)
        return;
      this.DocumentAboutToBeChanged((object) this, e);
    }

    protected void OnDocumentChanged(DocumentEventArgs e)
    {
      if (this.DocumentChanged == null)
        return;
      this.DocumentChanged((object) this, e);
    }

    public void RequestUpdate(TextAreaUpdate update)
    {
      this.updateQueue.Add(update);
    }

    public void CommitUpdate()
    {
      if (this.UpdateCommited == null)
        return;
      this.UpdateCommited((object) this, EventArgs.Empty);
    }

    protected virtual void OnTextContentChanged(EventArgs e)
    {
      if (this.TextContentChanged == null)
        return;
      this.TextContentChanged((object) this, e);
    }
  }
}
