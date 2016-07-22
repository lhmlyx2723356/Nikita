// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Util.TipText
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Util
{
  internal class TipText : TipSection
  {
    protected StringAlignment horzAlign;
    protected StringAlignment vertAlign;
    protected Color tipColor;
    protected Font tipFont;
    protected StringFormat tipFormat;
    protected string tipText;

    public Color Color
    {
      get
      {
        return this.tipColor;
      }
      set
      {
        this.tipColor = value;
      }
    }

    public StringAlignment HorizontalAlignment
    {
      get
      {
        return this.horzAlign;
      }
      set
      {
        this.horzAlign = value;
        this.tipFormat = (StringFormat) null;
      }
    }

    public StringAlignment VerticalAlignment
    {
      get
      {
        return this.vertAlign;
      }
      set
      {
        this.vertAlign = value;
        this.tipFormat = (StringFormat) null;
      }
    }

    public TipText(Graphics graphics, Font font, string text)
      : base(graphics)
    {
      this.tipFont = font;
      this.tipText = text;
      this.Color = SystemColors.InfoText;
      this.HorizontalAlignment = StringAlignment.Near;
      this.VerticalAlignment = StringAlignment.Near;
    }

    public override void Draw(PointF location)
    {
      if (!this.IsTextVisible())
        return;
      this.Graphics.DrawString(this.tipText, this.tipFont, BrushRegistry.GetBrush(this.Color), new RectangleF(location, this.AllocatedSize), this.GetInternalStringFormat());
    }

    protected StringFormat GetInternalStringFormat()
    {
      if (this.tipFormat == null)
        this.tipFormat = TipText.CreateTipStringFormat(this.horzAlign, this.vertAlign);
      return this.tipFormat;
    }

    protected override void OnMaximumSizeChanged()
    {
      base.OnMaximumSizeChanged();
      if (this.IsTextVisible())
        this.SetRequiredSize(this.Graphics.MeasureString(this.tipText, this.tipFont, this.MaximumSize, this.GetInternalStringFormat()));
      else
        this.SetRequiredSize(SizeF.Empty);
    }

    private static StringFormat CreateTipStringFormat(StringAlignment horizontalAlignment, StringAlignment verticalAlignment)
    {
      StringFormat stringFormat = (StringFormat) StringFormat.GenericTypographic.Clone();
      stringFormat.FormatFlags = StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces;
      stringFormat.Alignment = horizontalAlignment;
      stringFormat.LineAlignment = verticalAlignment;
      return stringFormat;
    }

    protected bool IsTextVisible()
    {
      if (this.tipText != null)
        return this.tipText.Length > 0;
      return false;
    }
  }
}
