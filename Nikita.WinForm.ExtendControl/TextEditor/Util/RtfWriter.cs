// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Util.RtfWriter
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Document;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Nikita.WinForm.ExtendControl.Util
{
  public class RtfWriter
  {
    private static Dictionary<string, int> colors;
    private static int colorNum;
    private static StringBuilder colorString;

    public static string GenerateRtf(TextArea textArea)
    {
      RtfWriter.colors = new Dictionary<string, int>();
      RtfWriter.colorNum = 0;
      RtfWriter.colorString = new StringBuilder();
      StringBuilder rtf = new StringBuilder();
      rtf.Append("{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1031");
      RtfWriter.BuildFontTable(textArea.Document, rtf);
      rtf.Append('\n');
      string str = RtfWriter.BuildFileContent(textArea);
      RtfWriter.BuildColorTable(textArea.Document, rtf);
      rtf.Append('\n');
      rtf.Append("\\viewkind4\\uc1\\pard");
      rtf.Append(str);
      rtf.Append("}");
      return rtf.ToString();
    }

    private static void BuildColorTable(IDocument doc, StringBuilder rtf)
    {
      rtf.Append("{\\colortbl ;");
      rtf.Append(RtfWriter.colorString.ToString());
      rtf.Append("}");
    }

    private static void BuildFontTable(IDocument doc, StringBuilder rtf)
    {
      rtf.Append("{\\fonttbl");
      rtf.Append("{\\f0\\fmodern\\fprq1\\fcharset0 " + FontContainer.DefaultFont.Name + ";}");
      rtf.Append("}");
    }

    private static string BuildFileContent(TextArea textArea)
    {
      StringBuilder stringBuilder = new StringBuilder();
      bool flag1 = true;
      Color color1 = Color.Black;
      bool flag2 = false;
      bool flag3 = false;
      bool flag4 = false;
      foreach (ISelection selection in textArea.SelectionManager.SelectionCollection)
      {
        int num1 = textArea.Document.PositionToOffset(selection.StartPosition);
        int num2 = textArea.Document.PositionToOffset(selection.EndPosition);
        for (int y = selection.StartPosition.Y; y <= selection.EndPosition.Y; ++y)
        {
          LineSegment lineSegment = textArea.Document.GetLineSegment(y);
          int offset = lineSegment.Offset;
          if (lineSegment.Words != null)
          {
            foreach (TextWord textWord in lineSegment.Words)
            {
              switch (textWord.Type)
              {
                case TextWordType.Word:
                  Color color2 = textWord.Color;
                  if (offset + textWord.Word.Length > num1 && offset < num2)
                  {
                    string key = (string) (object) color2.R + (object) ", " + (string) (object) color2.G + ", " + (string) (object) color2.B;
                    if (!RtfWriter.colors.ContainsKey(key))
                    {
                      RtfWriter.colors[key] = ++RtfWriter.colorNum;
                      RtfWriter.colorString.Append("\\red" + (object) color2.R + "\\green" + (string) (object) color2.G + "\\blue" + (string) (object) color2.B + ";");
                    }
                    if (color2 != color1 || flag1)
                    {
                      stringBuilder.Append("\\cf" + RtfWriter.colors[key].ToString());
                      color1 = color2;
                      flag4 = true;
                    }
                    if (flag2 != textWord.Font.Italic)
                    {
                      if (textWord.Font.Italic)
                        stringBuilder.Append("\\i");
                      else
                        stringBuilder.Append("\\i0");
                      flag2 = textWord.Font.Italic;
                      flag4 = true;
                    }
                    if (flag3 != textWord.Font.Bold)
                    {
                      if (textWord.Font.Bold)
                        stringBuilder.Append("\\b");
                      else
                        stringBuilder.Append("\\b0");
                      flag3 = textWord.Font.Bold;
                      flag4 = true;
                    }
                    if (flag1)
                    {
                      stringBuilder.Append("\\f0\\fs" + (object) (float) ((double) FontContainer.DefaultFont.Size * 2.0));
                      flag1 = false;
                    }
                    if (flag4)
                    {
                      stringBuilder.Append(' ');
                      flag4 = false;
                    }
                    string str = offset >= num1 ? (offset + textWord.Word.Length <= num2 ? textWord.Word : textWord.Word.Substring(0, offset + textWord.Word.Length - num2)) : textWord.Word.Substring(num1 - offset);
                    stringBuilder.Append(str.Replace("{", "\\{").Replace("}", "\\}"));
                  }
                  offset += textWord.Length;
                  continue;
                case TextWordType.Space:
                  if (selection.ContainsOffset(offset))
                    stringBuilder.Append(' ');
                  ++offset;
                  continue;
                case TextWordType.Tab:
                  if (selection.ContainsOffset(offset))
                    stringBuilder.Append("\\tab");
                  ++offset;
                  flag4 = true;
                  continue;
                default:
                  continue;
              }
            }
            if (offset < num2)
              stringBuilder.Append("\\par");
            stringBuilder.Append('\n');
          }
        }
      }
      return stringBuilder.ToString();
    }
  }
}
