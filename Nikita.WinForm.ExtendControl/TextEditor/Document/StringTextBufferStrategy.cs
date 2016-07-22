// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.StringTextBufferStrategy
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Util;
using System;
using System.IO;
using System.Text;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class StringTextBufferStrategy : ITextBufferStrategy
  {
    private string storedText = "";

    public int Length
    {
      get
      {
        return this.storedText.Length;
      }
    }

    public StringTextBufferStrategy()
    {
    }

    private StringTextBufferStrategy(string fileName)
    {
      Encoding @default = Encoding.Default;
      this.SetContent(FileReader.ReadFileContent(fileName, ref @default, @default));
    }

    public void Insert(int offset, string text)
    {
      if (text == null)
        return;
      this.storedText = this.storedText.Insert(offset, text);
    }

    public void Remove(int offset, int length)
    {
      this.storedText = this.storedText.Remove(offset, length);
    }

    public void Replace(int offset, int length, string text)
    {
      this.Remove(offset, length);
      this.Insert(offset, text);
    }

    public string GetText(int offset, int length)
    {
      if (length == 0)
        return "";
      if (offset == 0 && length >= this.storedText.Length)
        return this.storedText;
      return this.storedText.Substring(offset, Math.Min(length, this.storedText.Length - offset));
    }

    public char GetCharAt(int offset)
    {
      if (offset == this.Length)
        return char.MinValue;
      return this.storedText[offset];
    }

    public void SetContent(string text)
    {
      this.storedText = text;
    }

    public static ITextBufferStrategy CreateTextBufferFromFile(string fileName)
    {
      if (!File.Exists(fileName))
        throw new FileNotFoundException(fileName);
      return (ITextBufferStrategy) new StringTextBufferStrategy(fileName);
    }
  }
}
