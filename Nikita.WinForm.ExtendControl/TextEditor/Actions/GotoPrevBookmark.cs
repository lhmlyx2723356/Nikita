﻿// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.GotoPrevBookmark
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Document;
using System;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class GotoPrevBookmark : AbstractEditAction
  {
    private Predicate<Bookmark> predicate;

    public GotoPrevBookmark(Predicate<Bookmark> predicate)
    {
      this.predicate = predicate;
    }

    public override void Execute(TextArea textArea)
    {
      Bookmark prevMark = textArea.Document.BookmarkManager.GetPrevMark(textArea.Caret.Line, this.predicate);
      if (prevMark == null)
        return;
      textArea.Caret.Line = prevMark.LineNumber;
      textArea.SelectionManager.ClearSelection();
    }
  }
}
