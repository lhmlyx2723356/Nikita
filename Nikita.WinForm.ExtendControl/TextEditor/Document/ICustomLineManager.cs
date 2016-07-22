// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.ICustomLineManager
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System;
using System.Collections;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl.Document
{
  public interface ICustomLineManager
  {
    ArrayList CustomLines { get; }

    event EventHandler BeforeChanged;

    event EventHandler Changed;

    Color GetCustomColor(int lineNr, Color defaultColor);

    bool IsReadOnly(int lineNr, bool defaultReadOnly);

    bool IsReadOnly(ISelection selection, bool defaultReadOnly);

    void AddCustomLine(int lineNr, Color customColor, bool readOnly);

    void AddCustomLine(int startLineNr, int endLineNr, Color customColor, bool readOnly);

    void RemoveCustomLine(int lineNr);

    void Clear();
  }
}
