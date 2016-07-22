// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.GotoNextBookmark
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Document;
using System;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class GotoNextBookmark : AbstractEditAction
  {
    private Predicate<Bookmark> predicate;

    public GotoNextBookmark(Predicate<Bookmark> predicate)
    {
      this.predicate = predicate;
    }

    public override void Execute(TextArea textArea)
    {
      Bookmark nextMark = textArea.Document.BookmarkManager.GetNextMark(textArea.Caret.Line, this.predicate);
      if (nextMark == null)
        return;
      textArea.Caret.Line = nextMark.LineNumber;
      textArea.SelectionManager.ClearSelection();
    }
  }
}
