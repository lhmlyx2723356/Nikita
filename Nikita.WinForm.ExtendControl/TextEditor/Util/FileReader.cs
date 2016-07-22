// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Util.FileReader
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System;
using System.IO;
using System.Text;

namespace Nikita.WinForm.ExtendControl.Util
{
  public static class FileReader
  {
    public static bool IsUnicode(Encoding encoding)
    {
      int codePage = encoding.CodePage;
      switch (codePage)
      {
        case 65001:
        case 65000:
        case 1200:
          return true;
        default:
          return codePage == 1201;
      }
    }

    public static string ReadFileContent(string fileName, ref Encoding encoding, Encoding defaultEncoding)
    {
      using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
      {
        using (StreamReader streamReader = FileReader.OpenStream(fs, encoding, defaultEncoding))
        {
          encoding = streamReader.CurrentEncoding;
          return streamReader.ReadToEnd();
        }
      }
    }

    public static StreamReader OpenStream(FileStream fs, Encoding suggestedEncoding, Encoding defaultEncoding)
    {
      if (fs.Length > 3L)
      {
        int num1 = fs.ReadByte();
        int num2 = fs.ReadByte();
        switch (num1 << 8 | num2)
        {
          case 65279:
          case 65534:
          case 0:
          case 61371:
            fs.Position = 0L;
            return new StreamReader((Stream) fs);
          default:
            return FileReader.AutoDetect(fs, (byte) num1, (byte) num2, defaultEncoding);
        }
      }
      else
      {
        if (suggestedEncoding != null)
          return new StreamReader((Stream) fs, suggestedEncoding);
        return new StreamReader((Stream) fs);
      }
    }

    private static StreamReader AutoDetect(FileStream fs, byte firstByte, byte secondByte, Encoding defaultEncoding)
    {
      int num1 = (int) Math.Min(fs.Length, 500000L);
      int num2 = 0;
      int num3 = 0;
      for (int index = 0; index < num1; ++index)
      {
        byte num4 = index != 0 ? (index != 1 ? (byte) fs.ReadByte() : secondByte) : firstByte;
        if ((int) num4 < 128)
        {
          if (num2 == 3)
          {
            num2 = 1;
            break;
          }
        }
        else if ((int) num4 < 192)
        {
          if (num2 == 3)
          {
            --num3;
            if (num3 < 0)
            {
              num2 = 1;
              break;
            }
            if (num3 == 0)
              num2 = 2;
          }
          else
          {
            num2 = 1;
            break;
          }
        }
        else if ((int) num4 >= 194 && (int) num4 < 245)
        {
          if (num2 == 2 || num2 == 0)
          {
            num2 = 3;
            num3 = (int) num4 >= 224 ? ((int) num4 >= 240 ? 3 : 2) : 1;
          }
          else
          {
            num2 = 1;
            break;
          }
        }
        else
        {
          num2 = 1;
          break;
        }
      }
      fs.Position = 0L;
      switch (num2)
      {
        case 0:
        case 1:
          if (FileReader.IsUnicode(defaultEncoding))
            defaultEncoding = Encoding.Default;
          return new StreamReader((Stream) fs, defaultEncoding);
        default:
          return new StreamReader((Stream) fs);
      }
    }
  }
}
