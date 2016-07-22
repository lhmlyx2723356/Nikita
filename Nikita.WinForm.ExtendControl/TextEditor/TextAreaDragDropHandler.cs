// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.TextAreaDragDropHandler
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Document;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
  public class TextAreaDragDropHandler
  {
    private TextArea textArea;

    public void Attach(TextArea textArea)
    {
      this.textArea = textArea;
      textArea.AllowDrop = true;
      textArea.DragEnter += new DragEventHandler(this.OnDragEnter);
      textArea.DragDrop += new DragEventHandler(this.OnDragDrop);
      textArea.DragOver += new DragEventHandler(this.OnDragOver);
    }

    private static DragDropEffects GetDragDropEffect(DragEventArgs e)
    {
      if ((e.AllowedEffect & DragDropEffects.Move) > DragDropEffects.None && (e.AllowedEffect & DragDropEffects.Copy) > DragDropEffects.None)
        return (e.KeyState & 8) <= 0 ? DragDropEffects.Move : DragDropEffects.Copy;
      if ((e.AllowedEffect & DragDropEffects.Move) > DragDropEffects.None)
        return DragDropEffects.Move;
      return (e.AllowedEffect & DragDropEffects.Copy) > DragDropEffects.None ? DragDropEffects.Copy : DragDropEffects.None;
    }

    protected void OnDragEnter(object sender, DragEventArgs e)
    {
      if (!e.Data.GetDataPresent(typeof (string)))
        return;
      e.Effect = TextAreaDragDropHandler.GetDragDropEffect(e);
    }

    private void InsertString(int offset, string str)
    {
      this.textArea.Document.Insert(offset, str);
      this.textArea.SelectionManager.SetSelection((ISelection) new DefaultSelection(this.textArea.Document, this.textArea.Document.OffsetToPosition(offset), this.textArea.Document.OffsetToPosition(offset + str.Length)));
      this.textArea.Caret.Position = this.textArea.Document.OffsetToPosition(offset + str.Length);
      this.textArea.Refresh();
    }

    protected void OnDragDrop(object sender, DragEventArgs e)
    {
      this.textArea.PointToClient(new Point(e.X, e.Y));
      if (!e.Data.GetDataPresent(typeof (string)))
        return;
      bool flag = false;
      this.textArea.BeginUpdate();
      try
      {
        int offset = this.textArea.Caret.Offset;
        if (e.Data.GetDataPresent(typeof (DefaultSelection)))
        {
          ISelection selection = (ISelection) e.Data.GetData(typeof (DefaultSelection));
          if (selection.ContainsPosition(this.textArea.Caret.Position))
            return;
          if (TextAreaDragDropHandler.GetDragDropEffect(e) == DragDropEffects.Move)
          {
            int length = selection.Length;
            this.textArea.Document.Remove(selection.Offset, length);
            if (selection.Offset < offset)
              offset -= length;
          }
          flag = true;
        }
        this.textArea.SelectionManager.ClearSelection();
        this.InsertString(offset, (string) e.Data.GetData(typeof (string)));
        if (flag)
          this.textArea.Document.UndoStack.UndoLast(2);
        this.textArea.Document.UpdateQueue.Clear();
        this.textArea.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.WholeTextArea));
      }
      finally
      {
        this.textArea.EndUpdate();
      }
    }

    protected void OnDragOver(object sender, DragEventArgs e)
    {
      if (!this.textArea.Focused)
        this.textArea.Focus();
      Point point = this.textArea.PointToClient(new Point(e.X, e.Y));
      if (!this.textArea.TextView.DrawingPosition.Contains(point.X, point.Y))
        return;
      Point logicalPosition = this.textArea.TextView.GetLogicalPosition(point.X - this.textArea.TextView.DrawingPosition.X, point.Y - this.textArea.TextView.DrawingPosition.Y);
      int y = Math.Min(this.textArea.Document.TotalNumberOfLines - 1, Math.Max(0, logicalPosition.Y));
      this.textArea.Caret.Position = new Point(logicalPosition.X, y);
      this.textArea.SetDesiredColumn();
      if (!e.Data.GetDataPresent(typeof (string)))
        return;
      e.Effect = TextAreaDragDropHandler.GetDragDropEffect(e);
    }
  }
}
