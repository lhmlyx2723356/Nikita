// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.ConvertLeadingSpacesToTabs
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Document;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class ConvertLeadingSpacesToTabs : AbstractLineFormatAction
  {
    protected override void Convert(IDocument document, int y1, int y2)
    {
      int x = 0;
      for (int lineNumber = y2; lineNumber >= y1; --lineNumber)
      {
        LineSegment lineSegment = document.GetLineSegment(lineNumber);
        if (lineSegment.Length > 0)
        {
          string text = TextUtilities.LeadingWhiteSpaceToTabs(document.GetText(lineSegment.Offset, lineSegment.Length), document.TextEditorProperties.TabIndent);
          document.Replace(lineSegment.Offset, lineSegment.Length, text);
          ++x;
        }
      }
      if (x <= 0)
        return;
      document.UndoStack.UndoLast(x);
    }
  }
}
