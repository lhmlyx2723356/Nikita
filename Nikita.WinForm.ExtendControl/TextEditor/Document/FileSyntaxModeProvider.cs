// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.FileSyntaxModeProvider
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class FileSyntaxModeProvider : ISyntaxModeFileProvider
  {
    private string directory;
    private ArrayList syntaxModes;

    public ArrayList SyntaxModes
    {
      get
      {
        return this.syntaxModes;
      }
    }

    public FileSyntaxModeProvider(string directory)
    {
      this.directory = directory;
      this.UpdateSyntaxModeList();
    }

    public void UpdateSyntaxModeList()
    {
      string path = Path.Combine(this.directory, "SyntaxModes.xml");
      if (File.Exists(path))
      {
        Stream xmlSyntaxModeStream = (Stream) File.OpenRead(path);
        this.syntaxModes = SyntaxMode.GetSyntaxModes(xmlSyntaxModeStream);
        xmlSyntaxModeStream.Close();
      }
      else
        this.syntaxModes = this.ScanDirectory(this.directory);
    }

    public XmlTextReader GetSyntaxModeFile(SyntaxMode syntaxMode)
    {
      string path = Path.Combine(this.directory, syntaxMode.FileName);
      if (File.Exists(path))
        return new XmlTextReader((Stream) File.OpenRead(path));
      int num = (int) MessageBox.Show("Can't load highlighting definition " + path + " (file not found)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
      return (XmlTextReader) null;
    }

    private ArrayList ScanDirectory(string directory)
    {
      string[] files = Directory.GetFiles(directory);
      ArrayList arrayList = new ArrayList();
      foreach (string str in files)
      {
        if (Path.GetExtension(str).ToUpper() == ".XSHD")
        {
          XmlTextReader xmlTextReader = new XmlTextReader(str);
          while (xmlTextReader.Read())
          {
            if (xmlTextReader.NodeType == XmlNodeType.Element)
            {
              switch (xmlTextReader.Name)
              {
                case "SyntaxDefinition":
                  string attribute1 = xmlTextReader.GetAttribute("name");
                  string attribute2 = xmlTextReader.GetAttribute("extensions");
                  arrayList.Add((object) new SyntaxMode(Path.GetFileName(str), attribute1, attribute2));
                  goto label_8;
                default:
                  int num = (int) MessageBox.Show("Unknown root node in syntax highlighting file :" + xmlTextReader.Name, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                  goto label_8;
              }
            }
          }
label_8:
          xmlTextReader.Close();
        }
      }
      return arrayList;
    }
  }
}
