// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Document.HighlightingManager
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using System;
using System.Collections;
using System.IO;

namespace Nikita.WinForm.ExtendControl.Document
{
  public class HighlightingManager
  {
    private ArrayList syntaxModeFileProviders = new ArrayList();
    private Hashtable highlightingDefs = new Hashtable();
    private Hashtable extensionsToName = new Hashtable();
    private static HighlightingManager highlightingManager = new HighlightingManager();

    public Hashtable HighlightingDefinitions
    {
      get
      {
        return this.highlightingDefs;
      }
    }

    public static HighlightingManager Manager
    {
      get
      {
        return HighlightingManager.highlightingManager;
      }
    }

    public event EventHandler ReloadSyntaxHighlighting;

    static HighlightingManager()
    {
      HighlightingManager.highlightingManager.AddSyntaxModeFileProvider((ISyntaxModeFileProvider) new ResourceSyntaxModeProvider());
    }

    public HighlightingManager()
    {
      this.CreateDefaultHighlightingStrategy();
    }

    public void AddSyntaxModeFileProvider(ISyntaxModeFileProvider syntaxModeFileProvider)
    {
      foreach (SyntaxMode syntaxMode in syntaxModeFileProvider.SyntaxModes)
      {
        this.highlightingDefs[(object) syntaxMode.Name] = (object) new DictionaryEntry((object) syntaxMode, (object) syntaxModeFileProvider);
        foreach (string str in syntaxMode.Extensions)
          this.extensionsToName[(object) str.ToUpperInvariant()] = (object) syntaxMode.Name;
      }
      if (this.syntaxModeFileProviders.Contains((object) syntaxModeFileProvider))
        return;
      this.syntaxModeFileProviders.Add((object) syntaxModeFileProvider);
    }

    public void ReloadSyntaxModes()
    {
      this.highlightingDefs.Clear();
      this.extensionsToName.Clear();
      this.CreateDefaultHighlightingStrategy();
      foreach (ISyntaxModeFileProvider syntaxModeFileProvider in this.syntaxModeFileProviders)
      {
        syntaxModeFileProvider.UpdateSyntaxModeList();
        this.AddSyntaxModeFileProvider(syntaxModeFileProvider);
      }
      this.OnReloadSyntaxHighlighting(EventArgs.Empty);
    }

    private void CreateDefaultHighlightingStrategy()
    {
      this.highlightingDefs[(object) "Default"] = (object) new DefaultHighlightingStrategy()
      {
        Extensions = new string[0],
        Rules = {
          new HighlightRuleSet()
        }
      };
    }

    private IHighlightingStrategy LoadDefinition(DictionaryEntry entry)
    {
      SyntaxMode syntaxMode = (SyntaxMode) entry.Key;
      ISyntaxModeFileProvider modeFileProvider = (ISyntaxModeFileProvider) entry.Value;
      DefaultHighlightingStrategy highlightingStrategy = HighlightingDefinitionParser.Parse(syntaxMode, modeFileProvider.GetSyntaxModeFile(syntaxMode));
      this.highlightingDefs[(object) syntaxMode.Name] = (object) highlightingStrategy;
      highlightingStrategy.ResolveReferences();
      return (IHighlightingStrategy) highlightingStrategy;
    }

    public IHighlightingStrategy FindHighlighter(string name)
    {
      object obj = this.highlightingDefs[(object) name];
      if (obj is DictionaryEntry)
        return this.LoadDefinition((DictionaryEntry) obj);
      return obj == null ? (IHighlightingStrategy) this.highlightingDefs[(object) "Default"] : (IHighlightingStrategy) obj;
    }

    public IHighlightingStrategy FindHighlighterForFile(string fileName)
    {
      string str = (string) this.extensionsToName[(object) Path.GetExtension(fileName).ToUpperInvariant()];
      if (str == null)
        return (IHighlightingStrategy) this.highlightingDefs[(object) "Default"];
      object obj = this.highlightingDefs[(object) str];
      if (obj is DictionaryEntry)
        return this.LoadDefinition((DictionaryEntry) obj);
      return obj == null ? (IHighlightingStrategy) this.highlightingDefs[(object) "Default"] : (IHighlightingStrategy) obj;
    }

    protected virtual void OnReloadSyntaxHighlighting(EventArgs e)
    {
      if (this.ReloadSyntaxHighlighting == null)
        return;
      this.ReloadSyntaxHighlighting((object) this, e);
    }
  }
}
