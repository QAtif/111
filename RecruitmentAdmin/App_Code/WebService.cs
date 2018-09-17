// Decompiled with JetBrains decompiler
// Type: WebService
// Assembly: App_Code, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CCFCF570-EAC0-4D2F-8EF3-866C275AB6B3
// Assembly location: C:\Users\atifhussain\Desktop\Dlls\Axact Recruitment\App_Code.dll

using System.Web.Services;

[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Services.WebService(Namespace = "http://tempuri.org/")]
public class WebService : System.Web.Services.WebService
{
  [WebMethod]
  public string HelloWorld()
  {
    return "Hello World";
  }
}
