// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.GapTextBufferStrategy
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System;
using System.Text;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class GapTextBufferStrategy : ITextBufferStrategy
  {
    private char[] buffer = new char[0];
    private int minGapLength = 32;
    private int maxGapLength = 256;
    private int gapBeginOffset;
    private int gapEndOffset;

    public int Length
    {
      get
      {
        return this.buffer.Length - this.GapLength;
      }
    }

    private int GapLength
    {
      get
      {
        return this.gapEndOffset - this.gapBeginOffset;
      }
    }

    public void SetContent(string text)
    {
      if (text == null)
        text = string.Empty;
      this.buffer = text.ToCharArray();
      this.gapBeginOffset = this.gapEndOffset = 0;
    }

    public char GetCharAt(int offset)
    {
      if (offset >= this.gapBeginOffset)
        return this.buffer[offset + this.GapLength];
      return this.buffer[offset];
    }

    public string GetText(int offset, int length)
    {
      int num = offset + length;
      if (num < this.gapBeginOffset)
        return new string(this.buffer, offset, length);
      if (offset > this.gapBeginOffset)
        return new string(this.buffer, offset + this.GapLength, length);
      int charCount1 = this.gapBeginOffset - offset;
      int charCount2 = num - this.gapBeginOffset;
      StringBuilder stringBuilder = new StringBuilder(charCount1 + charCount2);
      stringBuilder.Append(this.buffer, offset, charCount1);
      stringBuilder.Append(this.buffer, this.gapEndOffset, charCount2);
      return stringBuilder.ToString();
    }

    public void Insert(int offset, string text)
    {
      this.Replace(offset, 0, text);
    }

    public void Remove(int offset, int length)
    {
      this.Replace(offset, length, string.Empty);
    }

    public void Replace(int offset, int length, string text)
    {
      if (text == null)
        text = string.Empty;
      this.PlaceGap(offset + length, Math.Max(text.Length - length, 0));
      text.CopyTo(0, this.buffer, offset, text.Length);
      this.gapBeginOffset += text.Length - length;
    }

    private void PlaceGap(int offset, int length)
    {
      int num1 = this.GapLength - length;
      if (this.minGapLength <= num1 && num1 <= this.maxGapLength)
      {
        int length1 = this.gapBeginOffset - offset;
        if (offset == this.gapBeginOffset)
          return;
        if (offset < this.gapBeginOffset)
        {
          int num2 = this.gapEndOffset - this.gapBeginOffset;
          Array.Copy((Array) this.buffer, offset, (Array) this.buffer, offset + num2, length1);
        }
        else
          Array.Copy((Array) this.buffer, this.gapEndOffset, (Array) this.buffer, this.gapBeginOffset, -length1);
        this.gapBeginOffset -= length1;
        this.gapEndOffset -= length1;
      }
      else
      {
        int gapLength = this.GapLength;
        int num2 = this.maxGapLength + length;
        int destinationIndex = offset + num2;
        char[] chArray = new char[this.buffer.Length + num2 - gapLength];
        if (gapLength == 0)
        {
          Array.Copy((Array) this.buffer, 0, (Array) chArray, 0, offset);
          Array.Copy((Array) this.buffer, offset, (Array) chArray, destinationIndex, chArray.Length - destinationIndex);
        }
        else if (offset < this.gapBeginOffset)
        {
          int length1 = this.gapBeginOffset - offset;
          Array.Copy((Array) this.buffer, 0, (Array) chArray, 0, offset);
          Array.Copy((Array) this.buffer, offset, (Array) chArray, destinationIndex, length1);
          Array.Copy((Array) this.buffer, this.gapEndOffset, (Array) chArray, destinationIndex + length1, this.buffer.Length - this.gapEndOffset);
        }
        else
        {
          int length1 = offset - this.gapBeginOffset;
          Array.Copy((Array) this.buffer, 0, (Array) chArray, 0, this.gapBeginOffset);
          Array.Copy((Array) this.buffer, this.gapEndOffset, (Array) chArray, this.gapBeginOffset, length1);
          Array.Copy((Array) this.buffer, this.gapEndOffset + length1, (Array) chArray, destinationIndex, chArray.Length - destinationIndex);
        }
        this.buffer = chArray;
        this.gapBeginOffset = offset;
        this.gapEndOffset = destinationIndex;
      }
    }
  }
}
