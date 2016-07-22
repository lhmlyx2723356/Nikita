// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.IndentFoldingStrategy
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Collections.Generic;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class IndentFoldingStrategy : IFoldingStrategy
  {
    public List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation)
    {
      List<FoldMarker> list = new List<FoldMarker>();
      Stack<int> stack1 = new Stack<int>();
      Stack<string> stack2 = new Stack<string>();
      return list;
    }

    private int GetLevel(IDocument document, int offset)
    {
      int num1 = 0;
      int num2 = 0;
      for (int offset1 = offset; offset1 < document.TextLength; ++offset1)
      {
        switch (document.GetCharAt(offset1))
        {
          case '\t':
            num2 = 0;
            ++num1;
            continue;
          case ' ':
            int num3;
            if ((num3 = num2 + 1) != 4)
              goto label_5;
            else
              goto case '\t';
          default:
            goto label_5;
        }
      }
label_5:
      return num1;
    }
  }
}
