// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.TextAreaUpdate
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Drawing;

namespace Nikita.WinForm.ExtendControl
{
  public class TextAreaUpdate
  {
    private Point position;
    private TextAreaUpdateType type;

    public TextAreaUpdateType TextAreaUpdateType
    {
      get
      {
        return this.type;
      }
    }

    public Point Position
    {
      get
      {
        return this.position;
      }
    }

    public TextAreaUpdate(TextAreaUpdateType type)
    {
      this.type = type;
    }

    public TextAreaUpdate(TextAreaUpdateType type, Point position)
    {
      this.type = type;
      this.position = position;
    }

    public TextAreaUpdate(TextAreaUpdateType type, int startLine, int endLine)
    {
      this.type = type;
      this.position = new Point(startLine, endLine);
    }

    public TextAreaUpdate(TextAreaUpdateType type, int singleLine)
    {
      this.type = type;
      this.position = new Point(0, singleLine);
    }

    public override string ToString()
    {
      return string.Format("[TextAreaUpdate: Type={0}, Position={1}]", (object) this.type, (object) this.position);
    }
  }
}
