// Decompiled with JetBrains decompiler
// Type: PLCRMStatusMarkingService.Program
// Assembly: XRecCRMService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7FEAB8C4-2C93-4EF2-ADFC-4B29F705460E
// Assembly location: E:\Services\XCRMServices\XRecCRMService.exe

using System.ServiceProcess;

namespace PLCRMStatusMarkingService
{
  internal static class Program
  {
    private static void Main()
    {
      ServiceBase.Run(new ServiceBase[1]
      {
        (ServiceBase) new CRMStatusMarkingService()
      });
    }
  }
}
