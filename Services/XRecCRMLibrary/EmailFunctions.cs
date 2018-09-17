// Decompiled with JetBrains decompiler
// Type: XRecCRMLibrary.EmailFunctions
// Assembly: XRecCRMLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DABBCD86-4B3A-41D7-8F33-D19BFAA38EFD
// Assembly location: E:\Services\XCRMServices\XRecCRMLibrary.dll

using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace XRecCRMLibrary
{
  internal class EmailFunctions
  {
    internal void EmailOnServiceStop()
    {
      this.MailingObjects();
    }

    private void MailingObjects()
    {
      MailMessage Mail_Message = new MailMessage("pl_CRMStatusMarkingService@axact.com", "syedtabish@axact.com, imranahmedkhan@axact.com, sheikhharis@axact.com, syedmobin@axact.com");
      string hostName = Dns.GetHostName();
      string str1 = Dns.GetHostByName(hostName).AddressList[0].ToString();
      string str2 = "CRMStatusMarkingService that runs on <br /> Host : " + hostName + "<br /> IP : " + str1 + "<br /> has now been stopped due to some reason.";
      Mail_Message.Subject = "IMP:CRMStatusMarkingService is stopped.";
      Mail_Message.Body = str2;
      Mail_Message.IsBodyHtml = true;
      this.Send_Email(Mail_Message);
    }

    private bool Send_Email(MailMessage Mail_Message)
    {
      SmtpClient smtpClient = new SmtpClient();
      NetworkCredential networkCredential = new NetworkCredential();
      networkCredential.UserName = ConfigurationSettings.AppSettings["MailUsername"].ToString();
      networkCredential.Password = ConfigurationSettings.AppSettings["Mailpassword"].ToString();
      smtpClient.Host = ConfigurationSettings.AppSettings["MailServerHost"].ToString();
      smtpClient.Credentials = (ICredentialsByHost) networkCredential;
      try
      {
        smtpClient.Send(Mail_Message);
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}
