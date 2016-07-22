// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Util.CountTipText
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Util
{
  internal class CountTipText : TipText
  {
    private float triHeight = 10f;
    private float triWidth = 10f;
    public Rectangle DrawingRectangle1;
    public Rectangle DrawingRectangle2;

    public CountTipText(Graphics graphics, Font font, string text)
      : base(graphics, font, text)
    {
    }

    private void DrawTriangle(float x, float y, bool flipped)
    {
      this.Graphics.FillRectangle(BrushRegistry.GetBrush(Color.FromArgb(192, 192, 192)), new RectangleF(x, y, this.triHeight, this.triHeight));
      float num1 = this.triHeight / 2f;
      float num2 = this.triHeight / 4f;
      Brush black = Brushes.Black;
      if (flipped)
        this.Graphics.FillPolygon(black, new PointF[3]
        {
          new PointF(x, y + num1 - num2),
          new PointF(x + this.triWidth / 2f, y + num1 + num2),
          new PointF(x + this.triWidth, y + num1 - num2)
        });
      else
        this.Graphics.FillPolygon(black, new PointF[3]
        {
          new PointF(x, y + num1 + num2),
          new PointF(x + this.triWidth / 2f, y + num1 - num2),
          new PointF(x + this.triWidth, y + num1 + num2)
        });
    }

    public override void Draw(PointF location)
    {
      if (this.tipText == null || this.tipText.Length <= 0)
        return;
      base.Draw(new PointF((float) ((double) location.X + (double) this.triWidth + 4.0), location.Y));
      this.DrawingRectangle1 = new Rectangle((int) location.X + 2, (int) location.Y + 2, (int) this.triWidth, (int) this.triHeight);
      this.DrawingRectangle2 = new Rectangle((int) ((double) location.X + (double) this.AllocatedSize.Width - (double) this.triWidth - 2.0), (int) location.Y + 2, (int) this.triWidth, (int) this.triHeight);
      this.DrawTriangle(location.X + 2f, location.Y + 2f, false);
      this.DrawTriangle((float) ((double) location.X + (double) this.AllocatedSize.Width - (double) this.triWidth - 2.0), location.Y + 2f, true);
    }

    protected override void OnMaximumSizeChanged()
    {
      if (this.IsTextVisible())
      {
        SizeF requiredSize = this.Graphics.MeasureString(this.tipText, this.tipFont, this.MaximumSize, this.GetInternalStringFormat());
        requiredSize.Width += (float) ((double) this.triWidth * 2.0 + 8.0);
        this.SetRequiredSize(requiredSize);
      }
      else
        this.SetRequiredSize(SizeF.Empty);
    }
  }
}
