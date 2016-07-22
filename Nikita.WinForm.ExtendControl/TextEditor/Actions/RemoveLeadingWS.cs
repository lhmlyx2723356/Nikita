// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.RemoveLeadingWS
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Document;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class RemoveLeadingWS : AbstractLineFormatAction
  {
    protected override void Convert(IDocument document, int y1, int y2)
    {
      int x = 0;
      for (int lineNumber = y1; lineNumber < y2; ++lineNumber)
      {
        LineSegment lineSegment = document.GetLineSegment(lineNumber);
        int length = 0;
        for (int offset = lineSegment.Offset; offset < lineSegment.Offset + lineSegment.Length && char.IsWhiteSpace(document.GetCharAt(offset)); ++offset)
          ++length;
        if (length > 0)
        {
          document.Remove(lineSegment.Offset, length);
          ++x;
        }
      }
      if (x <= 0)
        return;
      document.UndoStack.UndoLast(x);
    }
  }
}
