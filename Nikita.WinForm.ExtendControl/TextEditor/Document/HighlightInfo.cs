// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.HighlightInfo
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

namespace Nikita.WinForm.ExtendControl.Document
{
  public class HighlightInfo
  {
    public bool BlockSpanOn;
    public bool Span;
    public Nikita.WinForm.ExtendControl.Document.Span CurSpan;

    public HighlightInfo(Nikita.WinForm.ExtendControl.Document.Span curSpan, bool span, bool blockSpanOn)
    {
      this.CurSpan = curSpan;
      this.Span = span;
      this.BlockSpanOn = blockSpanOn;
    }
  }
}
