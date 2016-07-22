// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.DocumentEventArgs
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class DocumentEventArgs : EventArgs
  {
    private IDocument document;
    private int offset;
    private int length;
    private string text;

    public IDocument Document
    {
      get
      {
        return this.document;
      }
    }

    public int Offset
    {
      get
      {
        return this.offset;
      }
    }

    public string Text
    {
      get
      {
        return this.text;
      }
    }

    public int Length
    {
      get
      {
        return this.length;
      }
    }

    public DocumentEventArgs(IDocument document)
      : this(document, -1, -1, (string) null)
    {
    }

    public DocumentEventArgs(IDocument document, int offset)
      : this(document, offset, -1, (string) null)
    {
    }

    public DocumentEventArgs(IDocument document, int offset, int length)
      : this(document, offset, length, (string) null)
    {
    }

    public DocumentEventArgs(IDocument document, int offset, int length, string text)
    {
      this.document = document;
      this.offset = offset;
      this.length = length;
      this.text = text;
    }

    public override string ToString()
    {
      return string.Format("[DocumentEventArgs: Document = {0}, Offset = {1}, Text = {2}, Length = {3}]", (object) this.Document, (object) this.Offset, (object) this.Text, (object) this.Length);
    }
  }
}
