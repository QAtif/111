// Decompiled with JetBrains decompiler
// Type: XRecCRMLibrary.Properties.Settings
// Assembly: XRecCRMLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DABBCD86-4B3A-41D7-8F33-D19BFAA38EFD
// Assembly location: E:\Services\XCRMServices\XRecCRMLibrary.dll

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace XRecCRMLibrary.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
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

    [SpecialSetting(SpecialSetting.WebServiceUrl)]
    [DefaultSettingValue("http://recruitment5ws.xcrmlivepro.com/crmapi.asmx")]
    [DebuggerNonUserCode]
    [ApplicationScopedSetting]
    public string XRecCRMLibrary_XRecCRMAPI_CRMAPI
    {
      get
      {
        return (string) this["XRecCRMLibrary_XRecCRMAPI_CRMAPI"];
      }
    }
  }
}
