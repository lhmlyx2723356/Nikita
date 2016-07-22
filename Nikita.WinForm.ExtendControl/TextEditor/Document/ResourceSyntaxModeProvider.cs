// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.ResourceSyntaxModeProvider
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Collections;
using System.IO;
using System.Xml;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class ResourceSyntaxModeProvider : ISyntaxModeFileProvider
  {
    private ArrayList syntaxModes;

    public ArrayList SyntaxModes
    {
      get
      {
        return this.syntaxModes;
      }
    }

    public ResourceSyntaxModeProvider()
    {
        Stream manifestResourceStream = typeof(SyntaxMode).Assembly.GetManifestResourceStream("Nikita.WinForm.ExtendControl.TextEditor.Resources.SyntaxModes.xml");
      if (manifestResourceStream != null)
        this.syntaxModes = SyntaxMode.GetSyntaxModes(manifestResourceStream);
      else
        this.syntaxModes = new ArrayList();
    }

    public XmlTextReader GetSyntaxModeFile(SyntaxMode syntaxMode)
    {
        return new XmlTextReader(typeof(SyntaxMode).Assembly.GetManifestResourceStream("Nikita.WinForm.ExtendControl.TextEditor.Resources." + syntaxMode.FileName));
    }

    public void UpdateSyntaxModeList()
    {
    }
  }
}
