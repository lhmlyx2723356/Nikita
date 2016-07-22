// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.ToggleLineComment
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Document;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class ToggleLineComment : AbstractEditAction
  {
    private int firstLine;
    private int lastLine;

    private void RemoveCommentAt(IDocument document, string comment, ISelection selection, int y1, int y2)
    {
      int x = 0;
      this.firstLine = y1;
      this.lastLine = y2;
      for (int lineNumber = y2; lineNumber >= y1; --lineNumber)
      {
        LineSegment lineSegment = document.GetLineSegment(lineNumber);
        if (selection != null && lineNumber == y2 && lineSegment.Offset == selection.Offset + selection.Length)
        {
          --this.lastLine;
        }
        else
        {
          string text = document.GetText(lineSegment.Offset, lineSegment.Length);
          if (text.Trim().StartsWith(comment))
          {
            document.Remove(lineSegment.Offset + text.IndexOf(comment), comment.Length);
            ++x;
          }
        }
      }
      if (x <= 0)
        return;
      document.UndoStack.UndoLast(x);
    }

    private void SetCommentAt(IDocument document, string comment, ISelection selection, int y1, int y2)
    {
      int x = 0;
      this.firstLine = y1;
      this.lastLine = y2;
      for (int lineNumber = y2; lineNumber >= y1; --lineNumber)
      {
        LineSegment lineSegment = document.GetLineSegment(lineNumber);
        if (selection != null && lineNumber == y2 && lineSegment.Offset == selection.Offset + selection.Length)
        {
          --this.lastLine;
        }
        else
        {
          document.GetText(lineSegment.Offset, lineSegment.Length);
          document.Insert(lineSegment.Offset, comment);
          ++x;
        }
      }
      if (x <= 0)
        return;
      document.UndoStack.UndoLast(x);
    }

    private bool ShouldComment(IDocument document, string comment, ISelection selection, int startLine, int endLine)
    {
      for (int lineNumber = endLine; lineNumber >= startLine; --lineNumber)
      {
        LineSegment lineSegment = document.GetLineSegment(lineNumber);
        if (selection != null && lineNumber == endLine && lineSegment.Offset == selection.Offset + selection.Length)
          --this.lastLine;
        else if (!document.GetText(lineSegment.Offset, lineSegment.Length).Trim().StartsWith(comment))
          return true;
      }
      return false;
    }

    public override void Execute(TextArea textArea)
    {
      if (textArea.Document.ReadOnly)
        return;
      string comment = (string) null;
      if (textArea.Document.HighlightingStrategy.Properties.ContainsKey("LineComment"))
        comment = textArea.Document.HighlightingStrategy.Properties["LineComment"].ToString();
      if (comment == null || comment.Length == 0)
        return;
      if (textArea.SelectionManager.HasSomethingSelected)
      {
        bool flag = true;
        foreach (ISelection selection in textArea.SelectionManager.SelectionCollection)
        {
          if (!this.ShouldComment(textArea.Document, comment, selection, selection.StartPosition.Y, selection.EndPosition.Y))
          {
            flag = false;
            break;
          }
        }
        foreach (ISelection selection in textArea.SelectionManager.SelectionCollection)
        {
          textArea.BeginUpdate();
          if (flag)
            this.SetCommentAt(textArea.Document, comment, selection, selection.StartPosition.Y, selection.EndPosition.Y);
          else
            this.RemoveCommentAt(textArea.Document, comment, selection, selection.StartPosition.Y, selection.EndPosition.Y);
          textArea.Document.UpdateQueue.Clear();
          textArea.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.LinesBetween, this.firstLine, this.lastLine));
          textArea.EndUpdate();
        }
        textArea.Document.CommitUpdate();
        textArea.AutoClearSelection = false;
      }
      else
      {
        textArea.BeginUpdate();
        int line = textArea.Caret.Line;
        if (this.ShouldComment(textArea.Document, comment, (ISelection) null, line, line))
          this.SetCommentAt(textArea.Document, comment, (ISelection) null, line, line);
        else
          this.RemoveCommentAt(textArea.Document, comment, (ISelection) null, line, line);
        textArea.Document.UpdateQueue.Clear();
        textArea.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.SingleLine, line));
        textArea.EndUpdate();
      }
    }
  }
}
