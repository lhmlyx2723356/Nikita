// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Ime
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Nikita.WinForm.ExtendControl
{
  internal class Ime
  {
    private const int WM_IME_CONTROL = 643;
    private const int IMC_SETCOMPOSITIONWINDOW = 12;
    private const int CFS_POINT = 2;
    private const int IMC_SETCOMPOSITIONFONT = 10;
    private Font font;
    private IntPtr hIMEWnd;
    private IntPtr hWnd;
    private Ime.LOGFONT lf;

    public Font Font
    {
      get
      {
        return this.font;
      }
      set
      {
        if (this.font == null)
        {
          this.font = value;
          this.lf = (Ime.LOGFONT) null;
        }
        else if (!this.font.Equals((object) value))
        {
          this.font = value;
          this.lf = (Ime.LOGFONT) null;
        }
        this.SetIMEWindowFont(value);
      }
    }

    public IntPtr HWnd
    {
      set
      {
        if (!(this.hWnd != value))
          return;
        this.hWnd = value;
        this.hIMEWnd = Ime.ImmGetDefaultIMEWnd(value);
        this.SetIMEWindowFont(this.font);
      }
    }

    public Ime(IntPtr hWnd, Font font)
    {
      this.hWnd = hWnd;
      this.hIMEWnd = Ime.ImmGetDefaultIMEWnd(hWnd);
      this.font = font;
      this.SetIMEWindowFont(font);
    }

    [DllImport("imm32.dll")]
    private static extern IntPtr ImmGetDefaultIMEWnd(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, Ime.COMPOSITIONFORM lParam);

    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPStruct), In] Ime.LOGFONT lParam);

    private void SetIMEWindowFont(Font f)
    {
      if (this.lf == null)
      {
        this.lf = new Ime.LOGFONT();
        f.ToLogFont((object) this.lf);
        this.lf.lfFaceName = f.Name;
      }
      Ime.SendMessage(this.hIMEWnd, 643, new IntPtr(10), this.lf);
    }

    public void SetIMEWindowLocation(int x, int y)
    {
      Ime.SendMessage(this.hIMEWnd, 643, new IntPtr(12), new Ime.COMPOSITIONFORM()
      {
        dwStyle = 2,
        ptCurrentPos = new Ime.POINT()
        {
          x = x,
          y = y
        },
        rcArea = new Ime.RECT()
      });
    }

    [StructLayout(LayoutKind.Sequential)]
    private class COMPOSITIONFORM
    {
      public int dwStyle;
      public Ime.POINT ptCurrentPos;
      public Ime.RECT rcArea;
    }

    [StructLayout(LayoutKind.Sequential)]
    private class POINT
    {
      public int x;
      public int y;
    }

    [StructLayout(LayoutKind.Sequential)]
    private class RECT
    {
      public int left;
      public int top;
      public int right;
      public int bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    private class LOGFONT
    {
      public int lfHeight;
      public int lfWidth;
      public int lfEscapement;
      public int lfOrientation;
      public int lfWeight;
      public byte lfItalic;
      public byte lfUnderline;
      public byte lfStrikeOut;
      public byte lfCharSet;
      public byte lfOutPrecision;
      public byte lfClipPrecision;
      public byte lfQuality;
      public byte lfPitchAndFamily;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
      public string lfFaceName;
    }
  }
}
