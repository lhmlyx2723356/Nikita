// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.DeleteWord
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Document;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class DeleteWord : Delete
  {
    public override void Execute(TextArea textArea)
    {
      textArea.BeginUpdate();
      if (textArea.SelectionManager.HasSomethingSelected)
      {
        textArea.SelectionManager.RemoveSelectedText();
        textArea.ScrollToCaret();
      }
      LineSegment segmentForOffset = textArea.Document.GetLineSegmentForOffset(textArea.Caret.Offset);
      if (textArea.Caret.Offset == segmentForOffset.Offset + segmentForOffset.Length)
      {
        base.Execute(textArea);
      }
      else
      {
        int nextWordStart = TextUtilities.FindNextWordStart(textArea.Document, textArea.Caret.Offset);
        if (nextWordStart > textArea.Caret.Offset)
          textArea.Document.Remove(textArea.Caret.Offset, nextWordStart - textArea.Caret.Offset);
      }
      textArea.UpdateMatchingBracket();
      textArea.EndUpdate();
      textArea.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.PositionToEnd, new Point(0, textArea.Document.GetLineNumberForOffset(textArea.Caret.Offset))));
      textArea.Document.CommitUpdate();
    }
  }
}
