// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.HighlightingDefinitionParser
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace Nikita.WinForm.ExtendControl.Document
{
  internal class HighlightingDefinitionParser
  {
    private static ArrayList errors;

    private HighlightingDefinitionParser()
    {
    }

    public static DefaultHighlightingStrategy Parse(SyntaxMode syntaxMode, XmlTextReader xmlTextReader)
    {
      if (syntaxMode == null)
        throw new ArgumentNullException("syntaxMode");
      if (xmlTextReader == null)
        throw new ArgumentNullException("xmlTextReader");
      try
      {
        XmlReaderSettings settings = new XmlReaderSettings();
        Stream manifestResourceStream = typeof (HighlightingDefinitionParser).Assembly.GetManifestResourceStream("Nikita.WinForm.ExtendControl.TextEditor.Resources.Mode.xsd");
        settings.Schemas.Add("", (XmlReader) new XmlTextReader(manifestResourceStream));
        settings.Schemas.ValidationEventHandler += new ValidationEventHandler(HighlightingDefinitionParser.ValidationHandler);
        settings.ValidationType = ValidationType.Schema;
        XmlReader reader = XmlReader.Create((XmlReader) xmlTextReader, settings);
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(reader);
        DefaultHighlightingStrategy highlightingStrategy = new DefaultHighlightingStrategy(xmlDocument.DocumentElement.Attributes["name"].InnerText);
        if (xmlDocument.DocumentElement.Attributes["extensions"] != null)
          highlightingStrategy.Extensions = xmlDocument.DocumentElement.Attributes["extensions"].InnerText.Split(new char[2]
          {
            ';',
            '|'
          });
        XmlElement xmlElement1 = xmlDocument.DocumentElement["Environment"];
        if (xmlElement1 != null)
        {
          foreach (XmlNode xmlNode in xmlElement1.ChildNodes)
          {
            if (xmlNode is XmlElement)
            {
              XmlElement el = (XmlElement) xmlNode;
              highlightingStrategy.SetColorFor(el.Name, el.HasAttribute("bgcolor") ? (HighlightColor) new HighlightBackground(el) : new HighlightColor(el));
            }
          }
        }
        if (xmlDocument.DocumentElement["Properties"] != null)
        {
          foreach (XmlElement xmlElement2 in xmlDocument.DocumentElement["Properties"].ChildNodes)
            highlightingStrategy.Properties[xmlElement2.Attributes["name"].InnerText] = xmlElement2.Attributes["value"].InnerText;
        }
        if (xmlDocument.DocumentElement["Digits"] != null)
          highlightingStrategy.DigitColor = new HighlightColor(xmlDocument.DocumentElement["Digits"]);
        foreach (XmlElement el in xmlDocument.DocumentElement.GetElementsByTagName("RuleSet"))
          highlightingStrategy.AddRuleSet(new HighlightRuleSet(el));
        xmlTextReader.Close();
        if (HighlightingDefinitionParser.errors == null)
          return highlightingStrategy;
        HighlightingDefinitionParser.ReportErrors(syntaxMode.FileName);
        HighlightingDefinitionParser.errors = (ArrayList) null;
        return (DefaultHighlightingStrategy) null;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Could not load mode definition file.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        return (DefaultHighlightingStrategy) null;
      }
    }

    private static void ValidationHandler(object sender, ValidationEventArgs args)
    {
      if (HighlightingDefinitionParser.errors == null)
        HighlightingDefinitionParser.errors = new ArrayList();
      HighlightingDefinitionParser.errors.Add((object) args);
    }

    private static void ReportErrors(string fileName)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("Could not load mode definition file. Reason:\n\n");
      foreach (ValidationEventArgs validationEventArgs in HighlightingDefinitionParser.errors)
      {
        stringBuilder.Append(validationEventArgs.Message);
        stringBuilder.Append(Console.Out.NewLine);
      }
      int num = (int) MessageBox.Show(stringBuilder.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
    }
  }
}
