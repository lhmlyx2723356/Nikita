// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.Tab
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Document;
using System.Text;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class Tab : AbstractEditAction
  {
    public static string GetIndentationString(IDocument document)
    {
      return Tab.GetIndentationString(document, (TextArea) null);
    }

    public static string GetIndentationString(IDocument document, TextArea textArea)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (document.TextEditorProperties.ConvertTabsToSpaces)
      {
        int tabIndent = document.TextEditorProperties.TabIndent;
        if (textArea != null)
        {
          int visualColumn = textArea.TextView.GetVisualColumn(textArea.Caret.Line, textArea.Caret.Column);
          stringBuilder.Append(new string(' ', tabIndent - visualColumn % tabIndent));
        }
        else
          stringBuilder.Append(new string(' ', tabIndent));
      }
      else
        stringBuilder.Append('\t');
      return stringBuilder.ToString();
    }

    private void InsertTabs(IDocument document, ISelection selection, int y1, int y2)
    {
      int x = 0;
      string indentationString = Tab.GetIndentationString(document);
      for (int lineNumber = y2; lineNumber >= y1; --lineNumber)
      {
        LineSegment lineSegment = document.GetLineSegment(lineNumber);
        if (lineNumber != y2 || lineNumber != selection.EndPosition.Y || selection.EndPosition.X != 0)
        {
          document.Insert(lineSegment.Offset, indentationString);
          ++x;
        }
      }
      if (x <= 0)
        return;
      document.UndoStack.UndoLast(x);
    }

    private void InsertTabAtCaretPosition(TextArea textArea)
    {
      switch (textArea.Caret.CaretMode)
      {
        case CaretMode.InsertMode:
          textArea.InsertString(Tab.GetIndentationString(textArea.Document, textArea));
          break;
        case CaretMode.OverwriteMode:
          string indentationString = Tab.GetIndentationString(textArea.Document, textArea);
          textArea.ReplaceChar(indentationString[0]);
          if (indentationString.Length > 1)
          {
            textArea.InsertString(indentationString.Substring(1));
            break;
          }
          break;
      }
      textArea.SetDesiredColumn();
    }

    public override void Execute(TextArea textArea)
    {
      if (textArea.Document.ReadOnly)
        return;
      if (textArea.SelectionManager.HasSomethingSelected)
      {
        foreach (ISelection selection in textArea.SelectionManager.SelectionCollection)
        {
          int y1 = selection.StartPosition.Y;
          int y2 = selection.EndPosition.Y;
          if (y1 != y2)
          {
            textArea.BeginUpdate();
            this.InsertTabs(textArea.Document, selection, y1, y2);
            textArea.Document.UpdateQueue.Clear();
            textArea.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.LinesBetween, y1, y2));
            textArea.EndUpdate();
          }
          else
          {
            this.InsertTabAtCaretPosition(textArea);
            break;
          }
        }
        textArea.Document.CommitUpdate();
        textArea.AutoClearSelection = false;
      }
      else
        this.InsertTabAtCaretPosition(textArea);
    }
  }
}
