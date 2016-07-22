// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.FoldMarker
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class FoldMarker : AbstractSegment, IComparable
  {
    private string foldText = "...";
    private bool isFolded;
    private FoldType foldType;
    private IDocument document;

    public FoldType FoldType
    {
      get
      {
        return this.foldType;
      }
      set
      {
        this.foldType = value;
      }
    }

    public int StartLine
    {
      get
      {
        if (this.offset > this.document.TextLength)
          return -1;
        return this.document.GetLineNumberForOffset(this.offset);
      }
    }

    public int StartColumn
    {
      get
      {
        if (this.offset > this.document.TextLength)
          return -1;
        return this.offset - this.document.GetLineSegmentForOffset(this.offset).Offset;
      }
    }

    public int EndLine
    {
      get
      {
        if (this.offset + this.length > this.document.TextLength)
          return this.document.TotalNumberOfLines + 1;
        return this.document.GetLineNumberForOffset(this.offset + this.length);
      }
    }

    public int EndColumn
    {
      get
      {
        if (this.offset + this.length > this.document.TextLength)
          return -1;
        return this.offset + this.length - this.document.GetLineSegmentForOffset(this.offset + this.length).Offset;
      }
    }

    public bool IsFolded
    {
      get
      {
        return this.isFolded;
      }
      set
      {
        this.isFolded = value;
      }
    }

    public string FoldText
    {
      get
      {
        return this.foldText;
      }
    }

    public string InnerText
    {
      get
      {
        return this.document.GetText(this.offset, this.length);
      }
    }

    public FoldMarker(IDocument document, int offset, int length, string foldText, bool isFolded)
    {
      this.document = document;
      this.offset = offset;
      this.length = length;
      this.foldText = foldText;
      this.isFolded = isFolded;
    }

    public FoldMarker(IDocument document, int startLine, int startColumn, int endLine, int endColumn)
      : this(document, startLine, startColumn, endLine, endColumn, FoldType.Unspecified)
    {
    }

    public FoldMarker(IDocument document, int startLine, int startColumn, int endLine, int endColumn, FoldType foldType)
      : this(document, startLine, startColumn, endLine, endColumn, foldType, "...")
    {
    }

    public FoldMarker(IDocument document, int startLine, int startColumn, int endLine, int endColumn, FoldType foldType, string foldText)
      : this(document, startLine, startColumn, endLine, endColumn, foldType, foldText, false)
    {
    }

    public FoldMarker(IDocument document, int startLine, int startColumn, int endLine, int endColumn, FoldType foldType, string foldText, bool isFolded)
    {
      this.document = document;
      startLine = Math.Min(document.TotalNumberOfLines - 1, Math.Max(startLine, 0));
      ISegment segment1 = (ISegment) document.GetLineSegment(startLine);
      endLine = Math.Min(document.TotalNumberOfLines - 1, Math.Max(endLine, 0));
      ISegment segment2 = (ISegment) document.GetLineSegment(endLine);
      this.FoldType = foldType;
      this.foldText = foldText;
      this.offset = segment1.Offset + Math.Min(startColumn, segment1.Length);
      this.length = segment2.Offset + Math.Min(endColumn, segment2.Length) - this.offset;
      this.isFolded = isFolded;
    }

    public int CompareTo(object o)
    {
      if (!(o is FoldMarker))
        throw new ArgumentException();
      FoldMarker foldMarker = (FoldMarker) o;
      if (this.offset != foldMarker.offset)
        return this.offset.CompareTo(foldMarker.offset);
      return this.length.CompareTo(foldMarker.length);
    }
  }
}
