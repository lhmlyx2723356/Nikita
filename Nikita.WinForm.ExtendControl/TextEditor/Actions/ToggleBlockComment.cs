// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.ToggleBlockComment
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Document;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class ToggleBlockComment : AbstractEditAction
  {
    public override void Execute(TextArea textArea)
    {
      if (textArea.Document.ReadOnly)
        return;
      string commentStart = (string) null;
      if (textArea.Document.HighlightingStrategy.Properties.ContainsKey("BlockCommentBegin"))
        commentStart = textArea.Document.HighlightingStrategy.Properties["BlockCommentBegin"].ToString();
      string commentEnd = (string) null;
      if (textArea.Document.HighlightingStrategy.Properties.ContainsKey("BlockCommentEnd"))
        commentEnd = textArea.Document.HighlightingStrategy.Properties["BlockCommentEnd"].ToString();
      if (commentStart == null || commentStart.Length == 0 || (commentEnd == null || commentEnd.Length == 0))
        return;
      int offset;
      int num;
      if (textArea.SelectionManager.HasSomethingSelected)
      {
        offset = textArea.SelectionManager.SelectionCollection[0].Offset;
        num = textArea.SelectionManager.SelectionCollection[textArea.SelectionManager.SelectionCollection.Count - 1].EndOffset;
      }
      else
      {
        offset = textArea.Caret.Offset;
        num = offset;
      }
      BlockCommentRegion selectedCommentRegion = ToggleBlockComment.FindSelectedCommentRegion(textArea.Document, commentStart, commentEnd, offset, num);
      if (selectedCommentRegion != null)
        this.RemoveComment(textArea.Document, selectedCommentRegion);
      else if (textArea.SelectionManager.HasSomethingSelected)
        this.SetCommentAt(textArea.Document, offset, num, commentStart, commentEnd);
      textArea.Document.CommitUpdate();
      textArea.AutoClearSelection = false;
    }

    public static BlockCommentRegion FindSelectedCommentRegion(IDocument document, string commentStart, string commentEnd, int selectionStartOffset, int selectionEndOffset)
    {
      if (document.TextLength == 0)
        return (BlockCommentRegion) null;
      string text = document.GetText(selectionStartOffset, selectionEndOffset - selectionStartOffset);
      int startOffset = text.IndexOf(commentStart);
      if (startOffset >= 0)
        startOffset += selectionStartOffset;
      int endOffset = startOffset < 0 ? text.IndexOf(commentEnd) : text.IndexOf(commentEnd, startOffset + commentStart.Length - selectionStartOffset);
      if (endOffset >= 0)
        endOffset += selectionStartOffset;
      if (startOffset == -1)
      {
        int length = selectionEndOffset + commentStart.Length - 1;
        if (length > document.TextLength)
          length = document.TextLength;
        startOffset = document.GetText(0, length).LastIndexOf(commentStart);
      }
      if (endOffset == -1)
      {
        int offset = selectionStartOffset + 1 - commentEnd.Length;
        if (offset < 0)
          offset = selectionStartOffset;
        endOffset = document.GetText(offset, document.TextLength - offset).IndexOf(commentEnd);
        if (endOffset >= 0)
          endOffset += offset;
      }
      if (startOffset != -1 && endOffset != -1)
        return new BlockCommentRegion(commentStart, commentEnd, startOffset, endOffset);
      return (BlockCommentRegion) null;
    }

    private void SetCommentAt(IDocument document, int offsetStart, int offsetEnd, string commentStart, string commentEnd)
    {
      document.Insert(offsetEnd, commentEnd);
      document.Insert(offsetStart, commentStart);
      document.UndoStack.UndoLast(2);
    }

    private void RemoveComment(IDocument document, BlockCommentRegion commentRegion)
    {
      document.Remove(commentRegion.EndOffset, commentRegion.CommentEnd.Length);
      document.Remove(commentRegion.StartOffset, commentRegion.CommentStart.Length);
      document.UndoStack.UndoLast(2);
    }
  }
}
