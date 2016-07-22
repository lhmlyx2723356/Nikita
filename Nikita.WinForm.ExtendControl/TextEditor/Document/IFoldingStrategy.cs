// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.IFoldingStrategy
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Collections.Generic;

namespace Nikita.WinForm.ExtendControl.Document
{
  public interface IFoldingStrategy
  {
    List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation);
  }
}
