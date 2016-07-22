// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.CustomLineManager
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System;
using System.Collections;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class CustomLineManager : ICustomLineManager
  {
    private ArrayList lines = new ArrayList();

    public ArrayList CustomLines
    {
      get
      {
        return this.lines;
      }
    }

    public event EventHandler BeforeChanged;

    public event EventHandler Changed;

    public CustomLineManager(ILineManager lineTracker)
    {
      lineTracker.LineCountChanged += new LineManagerEventHandler(this.MoveIndices);
    }

    public Color GetCustomColor(int lineNr, Color defaultColor)
    {
      foreach (CustomLine customLine in this.lines)
      {
        if (customLine.StartLineNr <= lineNr && customLine.EndLineNr >= lineNr)
          return customLine.Color;
      }
      return defaultColor;
    }

    public bool IsReadOnly(int lineNr, bool defaultReadOnly)
    {
      foreach (CustomLine customLine in this.lines)
      {
        if (customLine.StartLineNr <= lineNr && customLine.EndLineNr >= lineNr)
          return customLine.ReadOnly;
      }
      return defaultReadOnly;
    }

    public bool IsReadOnly(ISelection selection, bool defaultReadOnly)
    {
      int y1 = selection.StartPosition.Y;
      int y2 = selection.EndPosition.Y;
      foreach (CustomLine customLine in this.lines)
      {
        if (customLine.ReadOnly && (y1 >= customLine.StartLineNr || y2 >= customLine.StartLineNr) && (y1 <= customLine.EndLineNr || y2 <= customLine.EndLineNr))
          return true;
      }
      return defaultReadOnly;
    }

    public void Clear()
    {
      this.OnBeforeChanged();
      this.lines.Clear();
      this.OnChanged();
    }

    private void OnChanged()
    {
      if (this.Changed == null)
        return;
      this.Changed((object) this, (EventArgs) null);
    }

    private void OnBeforeChanged()
    {
      if (this.BeforeChanged == null)
        return;
      this.BeforeChanged((object) this, (EventArgs) null);
    }

    public void AddCustomLine(int lineNr, Color customColor, bool readOnly)
    {
      this.OnBeforeChanged();
      this.lines.Add((object) new CustomLine(lineNr, customColor, readOnly));
      this.OnChanged();
    }

    public void AddCustomLine(int startLineNr, int endLineNr, Color customColor, bool readOnly)
    {
      this.OnBeforeChanged();
      this.lines.Add((object) new CustomLine(startLineNr, endLineNr, customColor, readOnly));
      this.OnChanged();
    }

    public void RemoveCustomLine(int lineNr)
    {
      for (int index = 0; index < this.lines.Count; ++index)
      {
        if (((CustomLine) this.lines[index]).StartLineNr <= lineNr && ((CustomLine) this.lines[index]).EndLineNr >= lineNr)
        {
          this.OnBeforeChanged();
          this.lines.RemoveAt(index);
          this.OnChanged();
          break;
        }
      }
    }

    private void MoveIndices(object sender, LineManagerEventArgs e)
    {
      bool flag = false;
      this.OnBeforeChanged();
      for (int index = 0; index < this.lines.Count; ++index)
      {
        int num1 = ((CustomLine) this.lines[index]).StartLineNr;
        int num2 = ((CustomLine) this.lines[index]).EndLineNr;
        if (e.LineStart >= num1 && e.LineStart < num2)
        {
          flag = true;
          ((CustomLine) this.lines[index]).EndLineNr += e.LinesMoved;
        }
        else if (e.LineStart < num1)
        {
          ((CustomLine) this.lines[index]).StartLineNr += e.LinesMoved;
          ((CustomLine) this.lines[index]).EndLineNr += e.LinesMoved;
        }
      }
      if (!flag)
        return;
      this.OnChanged();
    }
  }
}
