// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Util.TipPainter
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl.Util
{
  internal sealed class TipPainter
  {
    private static RectangleF workingArea = RectangleF.Empty;
    private const float HorizontalBorder = 2f;
    private const float VerticalBorder = 1f;

    private TipPainter()
    {
    }

    public static Size GetTipSize(Control control, Graphics graphics, Font font, string description)
    {
      return TipPainter.GetTipSize(control, graphics, (TipSection) new TipText(graphics, font, description));
    }

    public static Size GetTipSize(Control control, Graphics graphics, TipSection tipData)
    {
      Size size = Size.Empty;
      SizeF sizeF = SizeF.Empty;
      if (TipPainter.workingArea == RectangleF.Empty)
      {
        Form form = control.FindForm();
        if (form.Owner != null)
          form = form.Owner;
        TipPainter.workingArea = (RectangleF) Screen.GetWorkingArea((Control) form);
      }
      PointF pointF = (PointF) control.PointToScreen(Point.Empty);
      SizeF maximumSize = new SizeF((float) ((double) TipPainter.workingArea.Right - (double) pointF.X - 4.0), (float) ((double) TipPainter.workingArea.Bottom - (double) pointF.Y - 2.0));
      if ((double) maximumSize.Width > 0.0 && (double) maximumSize.Height > 0.0)
      {
        graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        tipData.SetMaximumSize(maximumSize);
        SizeF requiredSize = tipData.GetRequiredSize();
        tipData.SetAllocatedSize(requiredSize);
        size = Size.Ceiling(requiredSize + new SizeF(4f, 2f));
      }
      if (control.ClientSize != size)
        control.ClientSize = size;
      return size;
    }

    public static Size DrawTip(Control control, Graphics graphics, Font font, string description)
    {
      return TipPainter.DrawTip(control, graphics, (TipSection) new TipText(graphics, font, description));
    }

    public static Size DrawTip(Control control, Graphics graphics, TipSection tipData)
    {
      Size size = Size.Empty;
      SizeF sizeF = SizeF.Empty;
      PointF pointF = (PointF) control.PointToScreen(Point.Empty);
      if (TipPainter.workingArea == RectangleF.Empty)
      {
        Form form = control.FindForm();
        if (form.Owner != null)
          form = form.Owner;
        TipPainter.workingArea = (RectangleF) Screen.GetWorkingArea((Control) form);
      }
      SizeF maximumSize = new SizeF((float) ((double) TipPainter.workingArea.Right - (double) pointF.X - 4.0), (float) ((double) TipPainter.workingArea.Bottom - (double) pointF.Y - 2.0));
      if ((double) maximumSize.Width > 0.0 && (double) maximumSize.Height > 0.0)
      {
        graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        tipData.SetMaximumSize(maximumSize);
        SizeF requiredSize = tipData.GetRequiredSize();
        tipData.SetAllocatedSize(requiredSize);
        sizeF = requiredSize + new SizeF(4f, 2f);
        size = Size.Ceiling(sizeF);
      }
      if (control.ClientSize != size)
        control.ClientSize = size;
      if (size != Size.Empty)
      {
        Rectangle rect = new Rectangle(Point.Empty, size - new Size(1, 1));
        RectangleF rectangleF = new RectangleF(2f, 1f, sizeF.Width - 4f, sizeF.Height - 2f);
        graphics.DrawRectangle(SystemPens.WindowFrame, rect);
        tipData.Draw(new PointF(2f, 1f));
      }
      return size;
    }
  }
}
