// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Undo.UndoQueue
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System;
using System.Collections;

namespace Nikita.WinForm.ExtendControl.Undo
{
  public class UndoQueue : IUndoableOperation
  {
    private ArrayList undolist = new ArrayList();

    public UndoQueue(UndoStack stack, int numops)
    {
      if (stack == null)
        throw new ArgumentNullException("stack");
      for (int index = 0; index < numops; ++index)
      {
        if (stack._UndoStack.Count > 0)
          this.undolist.Add(stack._UndoStack.Pop());
      }
    }

    public void Undo()
    {
      for (int index = 0; index < this.undolist.Count; ++index)
        ((IUndoableOperation) this.undolist[index]).Undo();
    }

    public void Redo()
    {
      for (int index = this.undolist.Count - 1; index >= 0; --index)
        ((IUndoableOperation) this.undolist[index]).Redo();
    }
  }
}
