// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.ColumnRange
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

namespace Nikita.WinForm.ExtendControl.Document
{
  public class ColumnRange
  {
    public static readonly ColumnRange NoColumn = new ColumnRange(-2, -2);
    public static readonly ColumnRange WholeColumn = new ColumnRange(-1, -1);
    private int startColumn;
    private int endColumn;

    public int StartColumn
    {
      get
      {
        return this.startColumn;
      }
      set
      {
        this.startColumn = value;
      }
    }

    public int EndColumn
    {
      get
      {
        return this.endColumn;
      }
      set
      {
        this.endColumn = value;
      }
    }

    public ColumnRange(int startColumn, int endColumn)
    {
      this.startColumn = startColumn;
      this.endColumn = endColumn;
    }

    public override int GetHashCode()
    {
      return this.startColumn + (this.endColumn << 16);
    }

    public override bool Equals(object obj)
    {
      if (obj is ColumnRange && ((ColumnRange) obj).startColumn == this.startColumn)
        return ((ColumnRange) obj).endColumn == this.endColumn;
      return false;
    }

    public override string ToString()
    {
      return string.Format("[ColumnRange: StartColumn={0}, EndColumn={1}]", (object) this.startColumn, (object) this.endColumn);
    }
  }
}
