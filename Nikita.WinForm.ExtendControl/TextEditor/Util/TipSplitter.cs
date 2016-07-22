// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Util.TipSplitter
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Util
{
  internal class TipSplitter : TipSection
  {
    private bool isHorizontal;
    private float[] offsets;
    private TipSection[] tipSections;

    public TipSplitter(Graphics graphics, bool horizontal, params TipSection[] sections)
      : base(graphics)
    {
      this.isHorizontal = horizontal;
      this.offsets = new float[sections.Length];
      this.tipSections = (TipSection[]) sections.Clone();
    }

    public override void Draw(PointF location)
    {
      if (this.isHorizontal)
      {
        for (int index = 0; index < this.tipSections.Length; ++index)
          this.tipSections[index].Draw(new PointF(location.X + this.offsets[index], location.Y));
      }
      else
      {
        for (int index = 0; index < this.tipSections.Length; ++index)
          this.tipSections[index].Draw(new PointF(location.X, location.Y + this.offsets[index]));
      }
    }

    protected override void OnMaximumSizeChanged()
    {
      base.OnMaximumSizeChanged();
      float num1 = 0.0f;
      float num2 = 0.0f;
      SizeF maximumSize = this.MaximumSize;
      for (int index = 0; index < this.tipSections.Length; ++index)
      {
        TipSection tipSection = this.tipSections[index];
        tipSection.SetMaximumSize(maximumSize);
        SizeF requiredSize = tipSection.GetRequiredSize();
        this.offsets[index] = num1;
        if (this.isHorizontal)
        {
          float num3 = (float) Math.Ceiling((double) requiredSize.Width);
          num1 += num3;
          maximumSize.Width = Math.Max(0.0f, maximumSize.Width - num3);
          num2 = Math.Max(num2, requiredSize.Height);
        }
        else
        {
          float num3 = (float) Math.Ceiling((double) requiredSize.Height);
          num1 += num3;
          maximumSize.Height = Math.Max(0.0f, maximumSize.Height - num3);
          num2 = Math.Max(num2, requiredSize.Width);
        }
      }
      foreach (TipSection tipSection in this.tipSections)
      {
        if (this.isHorizontal)
          tipSection.SetAllocatedSize(new SizeF(tipSection.GetRequiredSize().Width, num2));
        else
          tipSection.SetAllocatedSize(new SizeF(num2, tipSection.GetRequiredSize().Height));
      }
      if (this.isHorizontal)
        this.SetRequiredSize(new SizeF(num1, num2));
      else
        this.SetRequiredSize(new SizeF(num2, num1));
    }
  }
}
