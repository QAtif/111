// Decompiled with JetBrains decompiler
// Type: AppSettings
// Assembly: App_Code, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CCFCF570-EAC0-4D2F-8EF3-866C275AB6B3
// Assembly location: C:\Users\atifhussain\Desktop\Dlls\Axact Recruitment\App_Code.dll

using System.Configuration;

public class AppSettings
{
  public static string ConnectionString
  {
    get
    {
      return ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
    }
  }

  public static string connection
  {
    get
    {
      return ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString();
    }
  }

  public static string RecruitmentConnection
  {
    get
    {
      return ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ToString();
    }
  }

  public static string Errlogconnection
  {
    get
    {
      return ConfigurationManager.ConnectionStrings["errLogConnection"].ToString();
    }
  }

  public static string RecruitmentLiveConn
  {
    get
    {
      return ConfigurationManager.ConnectionStrings["RecruitmentLiveConn"].ToString();
    }
  }
}
