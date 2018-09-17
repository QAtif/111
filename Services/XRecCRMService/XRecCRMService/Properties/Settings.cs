// Decompiled with JetBrains decompiler
// Type: XRecCRMService.Properties.Settings
// Assembly: XRecCRMService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7FEAB8C4-2C93-4EF2-ADFC-4B29F705460E
// Assembly location: E:\Services\XCRMServices\XRecCRMService.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace XRecCRMService.Properties
{
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
  [CompilerGenerated]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        Settings defaultInstance = Settings.defaultInstance;
        return defaultInstance;
      }
    }
  }
}
