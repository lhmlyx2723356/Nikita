// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Util.TipPainterTools
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Drawing;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl.Util
{
  internal class TipPainterTools
  {
    private const int SpacerSize = 4;
    public static Rectangle DrawingRectangle1;
    public static Rectangle DrawingRectangle2;

    private TipPainterTools()
    {
    }

    public static Size GetDrawingSizeHelpTipFromCombinedDescription(Control control, Graphics graphics, Font font, string countMessage, string description)
    {
      string basicDescription = (string) null;
      string documentation = (string) null;
      if (TipPainterTools.IsVisibleText(description))
      {
        string[] strArray = description.Split(new char[1]
        {
          '\n'
        }, 2);
        if (strArray.Length > 0)
        {
          basicDescription = strArray[0];
          if (strArray.Length > 1)
            documentation = strArray[1].Trim();
        }
      }
      return TipPainterTools.GetDrawingSizeDrawHelpTip(control, graphics, font, countMessage, basicDescription, documentation);
    }

    public static Size DrawHelpTipFromCombinedDescription(Control control, Graphics graphics, Font font, string countMessage, string description)
    {
      string basicDescription = (string) null;
      string documentation = (string) null;
      if (TipPainterTools.IsVisibleText(description))
      {
        string[] strArray = description.Split(new char[1]
        {
          '\n'
        }, 2);
        if (strArray.Length > 0)
        {
          basicDescription = strArray[0];
          if (strArray.Length > 1)
            documentation = strArray[1].Trim();
        }
      }
      return TipPainterTools.DrawHelpTip(control, graphics, font, countMessage, basicDescription, documentation);
    }

    public static Size GetDrawingSizeDrawHelpTip(Control control, Graphics graphics, Font font, string countMessage, string basicDescription, string documentation)
    {
      if (!TipPainterTools.IsVisibleText(countMessage) && !TipPainterTools.IsVisibleText(basicDescription) && !TipPainterTools.IsVisibleText(documentation))
        return Size.Empty;
      CountTipText countTipText = new CountTipText(graphics, font, countMessage);
      TipSpacer tipSpacer1 = new TipSpacer(graphics, new SizeF(TipPainterTools.IsVisibleText(countMessage) ? 4f : 0.0f, 0.0f));
      TipText tipText1 = new TipText(graphics, font, basicDescription);
      TipSpacer tipSpacer2 = new TipSpacer(graphics, new SizeF(0.0f, TipPainterTools.IsVisibleText(documentation) ? 4f : 0.0f));
      TipText tipText2 = new TipText(graphics, font, documentation);
      TipSplitter tipSplitter1 = new TipSplitter(graphics, 0 != 0, new TipSection[2]
      {
        (TipSection) tipText1,
        (TipSection) tipSpacer2
      });
      TipSplitter tipSplitter2 = new TipSplitter(graphics, 1 != 0, new TipSection[3]
      {
        (TipSection) countTipText,
        (TipSection) tipSpacer1,
        (TipSection) tipSplitter1
      });
      TipSplitter tipSplitter3 = new TipSplitter(graphics, 0 != 0, new TipSection[2]
      {
        (TipSection) tipSplitter2,
        (TipSection) tipText2
      });
      Size tipSize = TipPainter.GetTipSize(control, graphics, (TipSection) tipSplitter3);
      TipPainterTools.DrawingRectangle1 = countTipText.DrawingRectangle1;
      TipPainterTools.DrawingRectangle2 = countTipText.DrawingRectangle2;
      return tipSize;
    }

    public static Size DrawHelpTip(Control control, Graphics graphics, Font font, string countMessage, string basicDescription, string documentation)
    {
      if (!TipPainterTools.IsVisibleText(countMessage) && !TipPainterTools.IsVisibleText(basicDescription) && !TipPainterTools.IsVisibleText(documentation))
        return Size.Empty;
      CountTipText countTipText = new CountTipText(graphics, font, countMessage);
      TipSpacer tipSpacer1 = new TipSpacer(graphics, new SizeF(TipPainterTools.IsVisibleText(countMessage) ? 4f : 0.0f, 0.0f));
      TipText tipText1 = new TipText(graphics, font, basicDescription);
      TipSpacer tipSpacer2 = new TipSpacer(graphics, new SizeF(0.0f, TipPainterTools.IsVisibleText(documentation) ? 4f : 0.0f));
      TipText tipText2 = new TipText(graphics, font, documentation);
      TipSplitter tipSplitter1 = new TipSplitter(graphics, 0 != 0, new TipSection[2]
      {
        (TipSection) tipText1,
        (TipSection) tipSpacer2
      });
      TipSplitter tipSplitter2 = new TipSplitter(graphics, 1 != 0, new TipSection[3]
      {
        (TipSection) countTipText,
        (TipSection) tipSpacer1,
        (TipSection) tipSplitter1
      });
      TipSplitter tipSplitter3 = new TipSplitter(graphics, 0 != 0, new TipSection[2]
      {
        (TipSection) tipSplitter2,
        (TipSection) tipText2
      });
      Size size = TipPainter.DrawTip(control, graphics, (TipSection) tipSplitter3);
      TipPainterTools.DrawingRectangle1 = countTipText.DrawingRectangle1;
      TipPainterTools.DrawingRectangle2 = countTipText.DrawingRectangle2;
      return size;
    }

    private static bool IsVisibleText(string text)
    {
      if (text != null)
        return text.Length > 0;
      return false;
    }
  }
}
