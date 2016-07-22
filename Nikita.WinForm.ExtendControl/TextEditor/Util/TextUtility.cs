// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Util.TextUtility
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Document;

namespace Nikita.WinForm.ExtendControl.Util
{
  public class TextUtility
  {
    public static bool RegionMatches(IDocument document, int offset, int length, string word)
    {
      if (length != word.Length || document.TextLength < offset + length)
        return false;
      for (int index = 0; index < length; ++index)
      {
        if ((int) document.GetCharAt(offset + index) != (int) word[index])
          return false;
      }
      return true;
    }

    public static bool RegionMatches(IDocument document, bool casesensitive, int offset, int length, string word)
    {
      if (casesensitive)
        return TextUtility.RegionMatches(document, offset, length, word);
      if (length != word.Length || document.TextLength < offset + length)
        return false;
      for (int index = 0; index < length; ++index)
      {
        if ((int) char.ToUpper(document.GetCharAt(offset + index)) != (int) char.ToUpper(word[index]))
          return false;
      }
      return true;
    }

    public static bool RegionMatches(IDocument document, int offset, int length, char[] word)
    {
      if (length != word.Length || document.TextLength < offset + length)
        return false;
      for (int index = 0; index < length; ++index)
      {
        if ((int) document.GetCharAt(offset + index) != (int) word[index])
          return false;
      }
      return true;
    }

    public static bool RegionMatches(IDocument document, bool casesensitive, int offset, int length, char[] word)
    {
      if (casesensitive)
        return TextUtility.RegionMatches(document, offset, length, word);
      if (length != word.Length || document.TextLength < offset + length)
        return false;
      for (int index = 0; index < length; ++index)
      {
        if ((int) char.ToUpper(document.GetCharAt(offset + index)) != (int) char.ToUpper(word[index]))
          return false;
      }
      return true;
    }
  }
}
