// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.HRuler
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Drawing;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
  public class HRuler : UserControl
  {
    private TextArea textArea;

    public HRuler(TextArea textArea)
    {
      this.textArea = textArea;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      Graphics graphics = e.Graphics;
      int num1 = 0;
      float num2 = (float) this.textArea.TextView.DrawingPosition.Left;
      while ((double) num2 < (double) this.textArea.TextView.DrawingPosition.Right)
      {
        int y1 = this.Height * 2 / 3;
        if (num1 % 5 == 0)
          y1 = this.Height * 4 / 5;
        if (num1 % 10 == 0)
          y1 = 1;
        ++num1;
        graphics.DrawLine(Pens.Black, (int) num2, y1, (int) num2, this.Height - y1);
        num2 += this.textArea.TextView.WideSpaceWidth;
      }
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
      e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, this.Width, this.Height));
    }
  }
}
