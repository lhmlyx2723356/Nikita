// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.LineManagerEventArgs
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class LineManagerEventArgs : EventArgs
  {
    private IDocument document;
    private int start;
    private int moved;

    public IDocument Document
    {
      get
      {
        return this.document;
      }
    }

    public int LineStart
    {
      get
      {
        return this.start;
      }
    }

    public int LinesMoved
    {
      get
      {
        return this.moved;
      }
    }

    public LineManagerEventArgs(IDocument document, int lineStart, int linesMoved)
    {
      this.document = document;
      this.start = lineStart;
      this.moved = linesMoved;
    }
  }
}
