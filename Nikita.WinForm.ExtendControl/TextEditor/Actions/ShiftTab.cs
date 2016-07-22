// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.ShiftTab
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Document;
using System;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class ShiftTab : AbstractEditAction
  {
    private void RemoveTabs(IDocument document, ISelection selection, int y1, int y2)
    {
      int x = 0;
      for (int lineNumber = y2; lineNumber >= y1; --lineNumber)
      {
        LineSegment lineSegment = document.GetLineSegment(lineNumber);
        if ((lineNumber != y2 || lineSegment.Offset != selection.EndOffset) && (lineSegment.Length > 0 && lineSegment.Length > 0))
        {
          int length = 0;
          if ((int) document.GetCharAt(lineSegment.Offset) == 9)
            length = 1;
          else if ((int) document.GetCharAt(lineSegment.Offset) == 32)
          {
            int tabIndent = document.TextEditorProperties.TabIndent;
            int num = 1;
            while (num < lineSegment.Length && (int) document.GetCharAt(lineSegment.Offset + num) == 32)
              ++num;
            length = num < tabIndent ? (lineSegment.Length <= num || (int) document.GetCharAt(lineSegment.Offset + num) != 9 ? num : num + 1) : tabIndent;
          }
          if (length > 0)
          {
            document.Remove(lineSegment.Offset, length);
            ++x;
          }
        }
      }
      if (x <= 0)
        return;
      document.UndoStack.UndoLast(x);
    }

    public override void Execute(TextArea textArea)
    {
      if (textArea.SelectionManager.HasSomethingSelected)
      {
        foreach (ISelection selection in textArea.SelectionManager.SelectionCollection)
        {
          int y1 = selection.StartPosition.Y;
          int y2 = selection.EndPosition.Y;
          textArea.BeginUpdate();
          this.RemoveTabs(textArea.Document, selection, y1, y2);
          textArea.Document.UpdateQueue.Clear();
          textArea.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.LinesBetween, y1, y2));
          textArea.EndUpdate();
        }
        textArea.AutoClearSelection = false;
      }
      else
      {
        LineSegment segmentForOffset = textArea.Document.GetLineSegmentForOffset(textArea.Caret.Offset);
        textArea.Document.GetText(segmentForOffset.Offset, textArea.Caret.Offset - segmentForOffset.Offset);
        int tabIndent = textArea.Document.TextEditorProperties.TabIndent;
        int column = textArea.Caret.Column;
        int num = column % tabIndent;
        textArea.Caret.DesiredColumn = num != 0 ? Math.Max(0, column - num) : Math.Max(0, column - tabIndent);
        textArea.SetCaretToDesiredColumn(textArea.Caret.Line);
      }
    }
  }
}
