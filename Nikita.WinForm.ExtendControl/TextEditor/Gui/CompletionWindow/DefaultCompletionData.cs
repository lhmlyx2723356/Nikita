// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Gui.CompletionWindow.DefaultCompletionData
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl;
using System;

namespace Nikita.WinForm.ExtendControl.Gui.CompletionWindow
{
  public class DefaultCompletionData : ICompletionData, IComparable
  {
    private string text;
    private string description;
    private int imageIndex;
    private double priority;

    public int ImageIndex
    {
      get
      {
        return this.imageIndex;
      }
    }

    public string Text
    {
      get
      {
        return this.text;
      }
      set
      {
        this.text = value;
      }
    }

    public string Description
    {
      get
      {
        return this.description;
      }
    }

    public double Priority
    {
      get
      {
        return this.priority;
      }
      set
      {
        this.priority = value;
      }
    }

    public DefaultCompletionData(string text, string description, int imageIndex)
    {
      this.text = text;
      this.description = description;
      this.imageIndex = imageIndex;
    }

    public virtual bool InsertAction(TextArea textArea, char ch)
    {
      textArea.InsertString(this.text);
      return false;
    }

    public int CompareTo(object obj)
    {
      if (obj == null || !(obj is DefaultCompletionData))
        return -1;
      return this.text.CompareTo(((DefaultCompletionData) obj).Text);
    }
  }
}
