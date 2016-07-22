// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Undo.UndoStack
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using System;
using System.Collections;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Undo
{
  public class UndoStack
  {
    private Stack undostack = new Stack();
    private Stack redostack = new Stack();
    public bool AcceptChanges = true;
    public TextEditorControlBase TextEditorControl;

    internal Stack _UndoStack
    {
      get
      {
        return this.undostack;
      }
    }

    public bool CanUndo
    {
      get
      {
        return this.undostack.Count > 0;
      }
    }

    public bool CanRedo
    {
      get
      {
        return this.redostack.Count > 0;
      }
    }

    public event EventHandler ActionUndone;

    public event EventHandler ActionRedone;

    public void UndoLast(int x)
    {
      this.undostack.Push((object) new UndoQueue(this, x));
    }

    public void Undo()
    {
      if (this.undostack.Count <= 0)
        return;
      IUndoableOperation undoableOperation = (IUndoableOperation) this.undostack.Pop();
      this.redostack.Push((object) undoableOperation);
      undoableOperation.Undo();
      this.OnActionUndone();
    }

    public void Redo()
    {
      if (this.redostack.Count <= 0)
        return;
      IUndoableOperation undoableOperation = (IUndoableOperation) this.redostack.Pop();
      this.undostack.Push((object) undoableOperation);
      undoableOperation.Redo();
      this.OnActionRedone();
    }

    public void Push(IUndoableOperation operation)
    {
      if (operation == null)
        throw new ArgumentNullException("UndoStack.Push(UndoableOperation operation) : operation can't be null");
      if (!this.AcceptChanges)
        return;
      this.undostack.Push((object) operation);
      if (this.TextEditorControl != null)
      {
        this.undostack.Push((object) new UndoStack.UndoableSetCaretPosition(this, this.TextEditorControl.ActiveTextAreaControl.Caret.Position));
        this.UndoLast(2);
      }
      this.ClearRedoStack();
    }

    public void ClearRedoStack()
    {
      this.redostack.Clear();
    }

    public void ClearAll()
    {
      this.undostack.Clear();
      this.redostack.Clear();
    }

    protected void OnActionUndone()
    {
      if (this.ActionUndone == null)
        return;
      this.ActionUndone((object) null, (EventArgs) null);
    }

    protected void OnActionRedone()
    {
      if (this.ActionRedone == null)
        return;
      this.ActionRedone((object) null, (EventArgs) null);
    }

    private class UndoableSetCaretPosition : IUndoableOperation
    {
      private UndoStack stack;
      private Point pos;
      private Point redoPos;

      public UndoableSetCaretPosition(UndoStack stack, Point pos)
      {
        this.stack = stack;
        this.pos = pos;
      }

      public void Undo()
      {
        this.redoPos = this.stack.TextEditorControl.ActiveTextAreaControl.Caret.Position;
        this.stack.TextEditorControl.ActiveTextAreaControl.Caret.Position = this.pos;
      }

      public void Redo()
      {
        this.stack.TextEditorControl.ActiveTextAreaControl.Caret.Position = this.redoPos;
      }
    }
  }
}
