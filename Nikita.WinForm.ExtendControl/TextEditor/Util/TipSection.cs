// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Util.TipSection
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Util
{
  internal abstract class TipSection
  {
    private SizeF tipAllocatedSize;
    private Graphics tipGraphics;
    private SizeF tipMaxSize;
    private SizeF tipRequiredSize;

    protected Graphics Graphics
    {
      get
      {
        return this.tipGraphics;
      }
    }

    protected SizeF AllocatedSize
    {
      get
      {
        return this.tipAllocatedSize;
      }
    }

    protected SizeF MaximumSize
    {
      get
      {
        return this.tipMaxSize;
      }
    }

    protected TipSection(Graphics graphics)
    {
      this.tipGraphics = graphics;
    }

    public abstract void Draw(PointF location);

    public SizeF GetRequiredSize()
    {
      return this.tipRequiredSize;
    }

    public void SetAllocatedSize(SizeF allocatedSize)
    {
      this.tipAllocatedSize = allocatedSize;
      this.OnAllocatedSizeChanged();
    }

    public void SetMaximumSize(SizeF maximumSize)
    {
      this.tipMaxSize = maximumSize;
      this.OnMaximumSizeChanged();
    }

    protected virtual void OnAllocatedSizeChanged()
    {
    }

    protected virtual void OnMaximumSizeChanged()
    {
    }

    protected void SetRequiredSize(SizeF requiredSize)
    {
      requiredSize.Width = Math.Max(0.0f, requiredSize.Width);
      requiredSize.Height = Math.Max(0.0f, requiredSize.Height);
      requiredSize.Width = Math.Min(this.tipMaxSize.Width, requiredSize.Width);
      requiredSize.Height = Math.Min(this.tipMaxSize.Height, requiredSize.Height);
      this.tipRequiredSize = requiredSize;
    }
  }
}
