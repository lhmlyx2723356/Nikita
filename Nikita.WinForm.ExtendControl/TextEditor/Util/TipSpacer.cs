// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Util.TipSpacer
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Util
{
  internal class TipSpacer : TipSection
  {
    private SizeF spacerSize;

    public TipSpacer(Graphics graphics, SizeF size)
      : base(graphics)
    {
      this.spacerSize = size;
    }

    public override void Draw(PointF location)
    {
    }

    protected override void OnMaximumSizeChanged()
    {
      base.OnMaximumSizeChanged();
      this.SetRequiredSize(new SizeF(Math.Min(this.MaximumSize.Width, this.spacerSize.Width), Math.Min(this.MaximumSize.Height, this.spacerSize.Height)));
    }
  }
}
