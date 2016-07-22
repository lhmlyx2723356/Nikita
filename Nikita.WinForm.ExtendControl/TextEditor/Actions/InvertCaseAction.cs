// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Actions.InvertCaseAction
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Document;
using System.Text;

namespace Nikita.WinForm.ExtendControl.Actions
{
  public class InvertCaseAction : AbstractSelectionFormatAction
  {
    protected override void Convert(IDocument document, int startOffset, int length)
    {
      StringBuilder stringBuilder = new StringBuilder(document.GetText(startOffset, length));
      for (int index = 0; index < stringBuilder.Length; ++index)
        stringBuilder[index] = char.IsUpper(stringBuilder[index]) ? char.ToLower(stringBuilder[index]) : char.ToUpper(stringBuilder[index]);
      document.Replace(startOffset, length, stringBuilder.ToString());
    }
  }
}
