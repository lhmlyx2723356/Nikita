// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.DefaultSelection
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class DefaultSelection : ISelection
  {
    private Point startPosition = new Point(-1, -1);
    private Point endPosition = new Point(-1, -1);
    private IDocument document;
    private bool isRectangularSelection;

    public Point StartPosition
    {
      get
      {
        return this.startPosition;
      }
      set
      {
        this.startPosition = value;
      }
    }

    public Point EndPosition
    {
      get
      {
        return this.endPosition;
      }
      set
      {
        this.endPosition = value;
      }
    }

    public int Offset
    {
      get
      {
        return this.document.PositionToOffset(this.startPosition);
      }
    }

    public int EndOffset
    {
      get
      {
        return this.document.PositionToOffset(this.endPosition);
      }
    }

    public int Length
    {
      get
      {
        return this.EndOffset - this.Offset;
      }
    }

    public bool IsEmpty
    {
      get
      {
        return this.startPosition == this.endPosition;
      }
    }

    public bool IsRectangularSelection
    {
      get
      {
        return this.isRectangularSelection;
      }
      set
      {
        this.isRectangularSelection = value;
      }
    }

    public string SelectedText
    {
      get
      {
        if (this.document == null)
          return (string) null;
        if (this.Length < 0)
          return (string) null;
        return this.document.GetText(this.Offset, this.Length);
      }
    }

    public DefaultSelection(IDocument document, Point startPosition, Point endPosition)
    {
      this.document = document;
      this.startPosition = startPosition;
      this.endPosition = endPosition;
    }

    public override string ToString()
    {
      return string.Format("[DefaultSelection : StartPosition={0}, EndPosition={1}]", (object) this.startPosition, (object) this.endPosition);
    }

    public bool ContainsPosition(Point position)
    {
      if (this.startPosition.Y < position.Y && position.Y < this.endPosition.Y || this.startPosition.Y == position.Y && this.startPosition.X <= position.X && (this.startPosition.Y != this.endPosition.Y || position.X <= this.endPosition.X))
        return true;
      if (this.endPosition.Y == position.Y && this.startPosition.Y != this.endPosition.Y)
        return position.X <= this.endPosition.X;
      return false;
    }

    public bool ContainsOffset(int offset)
    {
      if (this.Offset <= offset)
        return offset <= this.EndOffset;
      return false;
    }
  }
}
