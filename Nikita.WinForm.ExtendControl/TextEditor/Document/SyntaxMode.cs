// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.SyntaxMode
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class SyntaxMode
  {
    private string fileName;
    private string name;
    private string[] extensions;

    public string FileName
    {
      get
      {
        return this.fileName;
      }
      set
      {
        this.fileName = value;
      }
    }

    public string Name
    {
      get
      {
        return this.name;
      }
      set
      {
        this.name = value;
      }
    }

    public string[] Extensions
    {
      get
      {
        return this.extensions;
      }
      set
      {
        this.extensions = value;
      }
    }

    public SyntaxMode(string fileName, string name, string extensions)
    {
      this.fileName = fileName;
      this.name = name;
      this.extensions = extensions.Split(new char[3]
      {
        ';',
        '|',
        ','
      });
    }

    public SyntaxMode(string fileName, string name, string[] extensions)
    {
      this.fileName = fileName;
      this.name = name;
      this.extensions = extensions;
    }

    public static ArrayList GetSyntaxModes(Stream xmlSyntaxModeStream)
    {
      XmlTextReader xmlTextReader = new XmlTextReader(xmlSyntaxModeStream);
      ArrayList arrayList = new ArrayList();
      while (xmlTextReader.Read())
      {
        if (xmlTextReader.NodeType == XmlNodeType.Element)
        {
          switch (xmlTextReader.Name)
          {
            case "SyntaxModes":
              string attribute = xmlTextReader.GetAttribute("version");
              if (attribute != "1.0")
              {
                int num = (int) MessageBox.Show("Unknown syntax mode file defininition with version " + attribute, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                return arrayList;
              }
              continue;
            case "Mode":
              arrayList.Add((object) new SyntaxMode(xmlTextReader.GetAttribute("file"), xmlTextReader.GetAttribute("name"), xmlTextReader.GetAttribute("extensions")));
              continue;
            default:
              int num1 = (int) MessageBox.Show("Unknown node in syntax mode file :" + xmlTextReader.Name, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
              return arrayList;
          }
        }
      }
      xmlTextReader.Close();
      return arrayList;
    }

    public override string ToString()
    {
      return string.Format("[SyntaxMode: FileName={0}, Name={1}, Extensions=({2})]", (object) this.fileName, (object) this.name, (object) string.Join(",", this.extensions));
    }
  }
}
