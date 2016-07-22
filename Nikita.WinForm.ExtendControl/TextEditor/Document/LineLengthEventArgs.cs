// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.LineLengthEventArgs
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class LineLengthEventArgs : EventArgs
  {
    private IDocument document;
    private int lineNumber;
    private int lineOffset;
    private int moved;

    public IDocument Document
    {
      get
      {
        return this.document;
      }
    }

    public int LineNumber
    {
      get
      {
        return this.lineNumber;
      }
    }

    public int LineOffset
    {
      get
      {
        return this.lineOffset;
      }
    }

    public int Moved
    {
      get
      {
        return this.moved;
      }
    }

    public LineLengthEventArgs(IDocument document, int lineNumber, int lineOffset, int moved)
    {
      this.document = document;
      this.lineNumber = lineNumber;
      this.lineOffset = lineOffset;
      this.moved = moved;
    }

    public override string ToString()
    {
      return string.Format("[LineLengthEventArgs: Document = {0}, LineNumber = {1}, LineOffset = {2}, Moved = {3}]", (object) this.Document, (object) this.LineNumber, (object) this.LineOffset, (object) this.Moved);
    }
  }
}
