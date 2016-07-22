﻿// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.AbstractLineFormatAction
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Document;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public abstract class AbstractLineFormatAction : AbstractEditAction
  {
    protected TextArea textArea;

    protected abstract void Convert(IDocument document, int startLine, int endLine);

    public override void Execute(TextArea textArea)
    {
      this.textArea = textArea;
      textArea.BeginUpdate();
      if (textArea.SelectionManager.HasSomethingSelected)
      {
        foreach (ISelection selection in textArea.SelectionManager.SelectionCollection)
          this.Convert(textArea.Document, selection.StartPosition.Y, selection.EndPosition.Y);
      }
      else
        this.Convert(textArea.Document, 0, textArea.Document.TotalNumberOfLines - 1);
      textArea.Caret.ValidateCaretPos();
      textArea.EndUpdate();
      textArea.Refresh();
    }
  }
}
