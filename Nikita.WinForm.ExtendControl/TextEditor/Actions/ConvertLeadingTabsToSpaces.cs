// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.ConvertLeadingTabsToSpaces
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Document;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class ConvertLeadingTabsToSpaces : AbstractLineFormatAction
  {
    protected override void Convert(IDocument document, int y1, int y2)
    {
      int x = 0;
      for (int lineNumber = y2; lineNumber >= y1; --lineNumber)
      {
        LineSegment lineSegment = document.GetLineSegment(lineNumber);
        if (lineSegment.Length > 0)
        {
          int length = 0;
          while (length < lineSegment.Length && char.IsWhiteSpace(document.GetCharAt(lineSegment.Offset + length)))
            ++length;
          if (length > 0)
          {
            string text = document.GetText(lineSegment.Offset, length).Replace("\t", new string(' ', document.TextEditorProperties.TabIndent));
            document.Replace(lineSegment.Offset, length, text);
            ++x;
          }
        }
      }
      if (x <= 0)
        return;
      document.UndoStack.UndoLast(x);
    }
  }
}
