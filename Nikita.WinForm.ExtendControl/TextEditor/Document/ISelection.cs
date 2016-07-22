// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.ISelection
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Document
{
  public interface ISelection
  {
    Point StartPosition { get; set; }

    Point EndPosition { get; set; }

    int Offset { get; }

    int EndOffset { get; }

    int Length { get; }

    bool IsRectangularSelection { get; }

    bool IsEmpty { get; }

    string SelectedText { get; }

    bool ContainsOffset(int offset);

    bool ContainsPosition(Point position);
  }
}
