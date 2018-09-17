// Decompiled with JetBrains decompiler
// Type: XRecCRMLibrary.XRecCRMAPI.CRMAPI
// Assembly: XRecCRMLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DABBCD86-4B3A-41D7-8F33-D19BFAA38EFD
// Assembly location: E:\Services\XCRMServices\XRecCRMLibrary.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using XRecCRMLibrary.Properties;

namespace XRecCRMLibrary.XRecCRMAPI
{
  [DesignerCategory("code")]
  [DebuggerStepThrough]
  [WebServiceBinding(Name = "CRMAPISoap", Namespace = "http://tempuri.org/")]
  [GeneratedCode("System.Web.Services", "4.0.30319.1")]
  public class CRMAPI : SoapHttpClientProtocol
  {
    private SendOrPostCallback AddCustomerOperationCompleted;
    private SendOrPostCallback AddStudentEmailFunctionwithMessageOperationCompleted;
    private SendOrPostCallback AddCustomerQueryOperationCompleted;
    private SendOrPostCallback AddStudentSMSFunctionwithMessageOperationCompleted;
    private bool useDefaultCredentialsSetExplicitly;

    public new string Url
    {
      get
      {
        return base.Url;
      }
      set
      {
        if (this.IsLocalFileSystemWebService(base.Url) && !this.useDefaultCredentialsSetExplicitly && !this.IsLocalFileSystemWebService(value))
          base.UseDefaultCredentials = false;
        base.Url = value;
      }
    }

    public new bool UseDefaultCredentials
    {
      get
      {
        return base.UseDefaultCredentials;
      }
      set
      {
        base.UseDefaultCredentials = value;
        this.useDefaultCredentialsSetExplicitly = true;
      }
    }

    public event AddCustomerCompletedEventHandler AddCustomerCompleted;

    public event AddStudentEmailFunctionwithMessageCompletedEventHandler AddStudentEmailFunctionwithMessageCompleted;

    public event AddCustomerQueryCompletedEventHandler AddCustomerQueryCompleted;

    public event AddStudentSMSFunctionwithMessageCompletedEventHandler AddStudentSMSFunctionwithMessageCompleted;

    public CRMAPI()
    {
      this.Url = Settings.Default.XRecCRMLibrary_XRecCRMAPI_CRMAPI;
      if (this.IsLocalFileSystemWebService(this.Url))
      {
        this.UseDefaultCredentials = true;
        this.useDefaultCredentialsSetExplicitly = false;
      }
      else
        this.useDefaultCredentialsSetExplicitly = true;
    }

    [SoapDocumentMethod("http://tempuri.org/AddCustomer", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal)]
    public bool AddCustomer(string ClientID, string ClientPassword, string Client_Code, string Customer_Code, string Customer_ID, string Customer_Life_Cycle_Status_Code, string First_Name, string Last_Name, string Full_Name, string Email_Address, string Password, string City, string State, string State_Code, string Country, string Country_Code, string Customer_IP, string Phone_1_Country_Code, string Phohe_1_Area_Code, string Phone_1_Number, PhoneType Phone_1_Type, string Phone_2_Country_Code, string Phohe_2_Area_Code, string Phone_2_Number, PhoneType Phone_2_Type, string Phone_3_Country_Code, string Phohe_3_Area_Code, string Phone_3_Number, PhoneType Phone_3_Type, string Date_Of_Birth, string Gender, int Agent_Code, int Sales_Medium_Code, CallType CallTypeCode, string Advertising_medium, string Medium_name, int Counter_Code, int SignupThrough_Code, string PhoneVerification_Code, string EmailVerification_Code, bool is_PhoneVerified, bool Is_EmailVerified, string Nationality, string MaritalStatus, string Religion, string NIC, string Passport_No, string HomePhoneNumber, string Address, string Department, string Position, string Designation, string Scheduling_Test_Date, string Scheduling_Test_Time, string Scheduling_Interview_Date, string Scheduling_Interview_Time, string Scheduling_Offer_Date, string Scheduling_Offer_Time, string Scheduling_Joining_Date, string Scheduling_Joining_Time, string ResetPassword_Link, string SampleTest_Link, bool Is_active, string Creation_Date, out string Message)
    {
      object[] objArray = this.Invoke("AddCustomer", new object[64]
      {
        (object) ClientID,
        (object) ClientPassword,
        (object) Client_Code,
        (object) Customer_Code,
        (object) Customer_ID,
        (object) Customer_Life_Cycle_Status_Code,
        (object) First_Name,
        (object) Last_Name,
        (object) Full_Name,
        (object) Email_Address,
        (object) Password,
        (object) City,
        (object) State,
        (object) State_Code,
        (object) Country,
        (object) Country_Code,
        (object) Customer_IP,
        (object) Phone_1_Country_Code,
        (object) Phohe_1_Area_Code,
        (object) Phone_1_Number,
        (object) Phone_1_Type,
        (object) Phone_2_Country_Code,
        (object) Phohe_2_Area_Code,
        (object) Phone_2_Number,
        (object) Phone_2_Type,
        (object) Phone_3_Country_Code,
        (object) Phohe_3_Area_Code,
        (object) Phone_3_Number,
        (object) Phone_3_Type,
        (object) Date_Of_Birth,
        (object) Gender,
        (object) Agent_Code,
        (object) Sales_Medium_Code,
        (object) CallTypeCode,
        (object) Advertising_medium,
        (object) Medium_name,
        (object) Counter_Code,
        (object) SignupThrough_Code,
        (object) PhoneVerification_Code,
        (object) EmailVerification_Code,
        (object) is_PhoneVerified,
        (object) Is_EmailVerified,
        (object) Nationality,
        (object) MaritalStatus,
        (object) Religion,
        (object) NIC,
        (object) Passport_No,
        (object) HomePhoneNumber,
        (object) Address,
        (object) Department,
        (object) Position,
        (object) Designation,
        (object) Scheduling_Test_Date,
        (object) Scheduling_Test_Time,
        (object) Scheduling_Interview_Date,
        (object) Scheduling_Interview_Time,
        (object) Scheduling_Offer_Date,
        (object) Scheduling_Offer_Time,
        (object) Scheduling_Joining_Date,
        (object) Scheduling_Joining_Time,
        (object) ResetPassword_Link,
        (object) SampleTest_Link,
        (object) Is_active,
        (object) Creation_Date
      });
      Message = (string) objArray[1];
      return (bool) objArray[0];
    }

    public void AddCustomerAsync(string ClientID, string ClientPassword, string Client_Code, string Customer_Code, string Customer_ID, string Customer_Life_Cycle_Status_Code, string First_Name, string Last_Name, string Full_Name, string Email_Address, string Password, string City, string State, string State_Code, string Country, string Country_Code, string Customer_IP, string Phone_1_Country_Code, string Phohe_1_Area_Code, string Phone_1_Number, PhoneType Phone_1_Type, string Phone_2_Country_Code, string Phohe_2_Area_Code, string Phone_2_Number, PhoneType Phone_2_Type, string Phone_3_Country_Code, string Phohe_3_Area_Code, string Phone_3_Number, PhoneType Phone_3_Type, string Date_Of_Birth, string Gender, int Agent_Code, int Sales_Medium_Code, CallType CallTypeCode, string Advertising_medium, string Medium_name, int Counter_Code, int SignupThrough_Code, string PhoneVerification_Code, string EmailVerification_Code, bool is_PhoneVerified, bool Is_EmailVerified, string Nationality, string MaritalStatus, string Religion, string NIC, string Passport_No, string HomePhoneNumber, string Address, string Department, string Position, string Designation, string Scheduling_Test_Date, string Scheduling_Test_Time, string Scheduling_Interview_Date, string Scheduling_Interview_Time, string Scheduling_Offer_Date, string Scheduling_Offer_Time, string Scheduling_Joining_Date, string Scheduling_Joining_Time, string ResetPassword_Link, string SampleTest_Link, bool Is_active, string Creation_Date)
    {
      this.AddCustomerAsync(ClientID, ClientPassword, Client_Code, Customer_Code, Customer_ID, Customer_Life_Cycle_Status_Code, First_Name, Last_Name, Full_Name, Email_Address, Password, City, State, State_Code, Country, Country_Code, Customer_IP, Phone_1_Country_Code, Phohe_1_Area_Code, Phone_1_Number, Phone_1_Type, Phone_2_Country_Code, Phohe_2_Area_Code, Phone_2_Number, Phone_2_Type, Phone_3_Country_Code, Phohe_3_Area_Code, Phone_3_Number, Phone_3_Type, Date_Of_Birth, Gender, Agent_Code, Sales_Medium_Code, CallTypeCode, Advertising_medium, Medium_name, Counter_Code, SignupThrough_Code, PhoneVerification_Code, EmailVerification_Code, is_PhoneVerified, Is_EmailVerified, Nationality, MaritalStatus, Religion, NIC, Passport_No, HomePhoneNumber, Address, Department, Position, Designation, Scheduling_Test_Date, Scheduling_Test_Time, Scheduling_Interview_Date, Scheduling_Interview_Time, Scheduling_Offer_Date, Scheduling_Offer_Time, Scheduling_Joining_Date, Scheduling_Joining_Time, ResetPassword_Link, SampleTest_Link, Is_active, Creation_Date, (object) null);
    }

    public void AddCustomerAsync(string ClientID, string ClientPassword, string Client_Code, string Customer_Code, string Customer_ID, string Customer_Life_Cycle_Status_Code, string First_Name, string Last_Name, string Full_Name, string Email_Address, string Password, string City, string State, string State_Code, string Country, string Country_Code, string Customer_IP, string Phone_1_Country_Code, string Phohe_1_Area_Code, string Phone_1_Number, PhoneType Phone_1_Type, string Phone_2_Country_Code, string Phohe_2_Area_Code, string Phone_2_Number, PhoneType Phone_2_Type, string Phone_3_Country_Code, string Phohe_3_Area_Code, string Phone_3_Number, PhoneType Phone_3_Type, string Date_Of_Birth, string Gender, int Agent_Code, int Sales_Medium_Code, CallType CallTypeCode, string Advertising_medium, string Medium_name, int Counter_Code, int SignupThrough_Code, string PhoneVerification_Code, string EmailVerification_Code, bool is_PhoneVerified, bool Is_EmailVerified, string Nationality, string MaritalStatus, string Religion, string NIC, string Passport_No, string HomePhoneNumber, string Address, string Department, string Position, string Designation, string Scheduling_Test_Date, string Scheduling_Test_Time, string Scheduling_Interview_Date, string Scheduling_Interview_Time, string Scheduling_Offer_Date, string Scheduling_Offer_Time, string Scheduling_Joining_Date, string Scheduling_Joining_Time, string ResetPassword_Link, string SampleTest_Link, bool Is_active, string Creation_Date, object userState)
    {
      if (this.AddCustomerOperationCompleted == null)
        this.AddCustomerOperationCompleted = new SendOrPostCallback(this.OnAddCustomerOperationCompleted);
      this.InvokeAsync("AddCustomer", new object[64]
      {
        (object) ClientID,
        (object) ClientPassword,
        (object) Client_Code,
        (object) Customer_Code,
        (object) Customer_ID,
        (object) Customer_Life_Cycle_Status_Code,
        (object) First_Name,
        (object) Last_Name,
        (object) Full_Name,
        (object) Email_Address,
        (object) Password,
        (object) City,
        (object) State,
        (object) State_Code,
        (object) Country,
        (object) Country_Code,
        (object) Customer_IP,
        (object) Phone_1_Country_Code,
        (object) Phohe_1_Area_Code,
        (object) Phone_1_Number,
        (object) Phone_1_Type,
        (object) Phone_2_Country_Code,
        (object) Phohe_2_Area_Code,
        (object) Phone_2_Number,
        (object) Phone_2_Type,
        (object) Phone_3_Country_Code,
        (object) Phohe_3_Area_Code,
        (object) Phone_3_Number,
        (object) Phone_3_Type,
        (object) Date_Of_Birth,
        (object) Gender,
        (object) Agent_Code,
        (object) Sales_Medium_Code,
        (object) CallTypeCode,
        (object) Advertising_medium,
        (object) Medium_name,
        (object) Counter_Code,
        (object) SignupThrough_Code,
        (object) PhoneVerification_Code,
        (object) EmailVerification_Code,
        (object) is_PhoneVerified,
        (object) Is_EmailVerified,
        (object) Nationality,
        (object) MaritalStatus,
        (object) Religion,
        (object) NIC,
        (object) Passport_No,
        (object) HomePhoneNumber,
        (object) Address,
        (object) Department,
        (object) Position,
        (object) Designation,
        (object) Scheduling_Test_Date,
        (object) Scheduling_Test_Time,
        (object) Scheduling_Interview_Date,
        (object) Scheduling_Interview_Time,
        (object) Scheduling_Offer_Date,
        (object) Scheduling_Offer_Time,
        (object) Scheduling_Joining_Date,
        (object) Scheduling_Joining_Time,
        (object) ResetPassword_Link,
        (object) SampleTest_Link,
        (object) Is_active,
        (object) Creation_Date
      }, this.AddCustomerOperationCompleted, userState);
    }

    private void OnAddCustomerOperationCompleted(object arg)
    {
      if (this.AddCustomerCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.AddCustomerCompleted((object) this, new AddCustomerCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://tempuri.org/AddCustomerEmailFunctionwithMessageV5", ParameterStyle = SoapParameterStyle.Wrapped, RequestElementName = "AddCustomerEmailFunctionwithMessageV5", RequestNamespace = "http://tempuri.org/", ResponseElementName = "AddCustomerEmailFunctionwithMessageV5Response", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal)]
    [return: XmlElement("AddCustomerEmailFunctionwithMessageV5Result")]
    public bool AddStudentEmailFunctionwithMessage(string ClientID, string ClientPassword, string Customer_EmailAddress, string Customer_Name, string Client_Name, string Client_EmailAddress, string Email_Subject, string Email_Body, string EmailFunction_Code, string Customer_Code, string Client_Code, EmailSendingStatus sending_status, out string Message)
    {
      object[] objArray = this.Invoke("AddStudentEmailFunctionwithMessage", new object[12]
      {
        (object) ClientID,
        (object) ClientPassword,
        (object) Customer_EmailAddress,
        (object) Customer_Name,
        (object) Client_Name,
        (object) Client_EmailAddress,
        (object) Email_Subject,
        (object) Email_Body,
        (object) EmailFunction_Code,
        (object) Customer_Code,
        (object) Client_Code,
        (object) sending_status
      });
      Message = (string) objArray[1];
      return (bool) objArray[0];
    }

    public void AddStudentEmailFunctionwithMessageAsync(string ClientID, string ClientPassword, string Customer_EmailAddress, string Customer_Name, string Client_Name, string Client_EmailAddress, string Email_Subject, string Email_Body, string EmailFunction_Code, string Customer_Code, string Client_Code, EmailSendingStatus sending_status)
    {
      this.AddStudentEmailFunctionwithMessageAsync(ClientID, ClientPassword, Customer_EmailAddress, Customer_Name, Client_Name, Client_EmailAddress, Email_Subject, Email_Body, EmailFunction_Code, Customer_Code, Client_Code, sending_status, (object) null);
    }

    public void AddStudentEmailFunctionwithMessageAsync(string ClientID, string ClientPassword, string Customer_EmailAddress, string Customer_Name, string Client_Name, string Client_EmailAddress, string Email_Subject, string Email_Body, string EmailFunction_Code, string Customer_Code, string Client_Code, EmailSendingStatus sending_status, object userState)
    {
      if (this.AddStudentEmailFunctionwithMessageOperationCompleted == null)
        this.AddStudentEmailFunctionwithMessageOperationCompleted = new SendOrPostCallback(this.OnAddStudentEmailFunctionwithMessageOperationCompleted);
      this.InvokeAsync("AddStudentEmailFunctionwithMessage", new object[12]
      {
        (object) ClientID,
        (object) ClientPassword,
        (object) Customer_EmailAddress,
        (object) Customer_Name,
        (object) Client_Name,
        (object) Client_EmailAddress,
        (object) Email_Subject,
        (object) Email_Body,
        (object) EmailFunction_Code,
        (object) Customer_Code,
        (object) Client_Code,
        (object) sending_status
      }, this.AddStudentEmailFunctionwithMessageOperationCompleted, userState);
    }

    private void OnAddStudentEmailFunctionwithMessageOperationCompleted(object arg)
    {
      if (this.AddStudentEmailFunctionwithMessageCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.AddStudentEmailFunctionwithMessageCompleted((object) this, new AddStudentEmailFunctionwithMessageCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://tempuri.org/AddCustomerQueryV5", ParameterStyle = SoapParameterStyle.Wrapped, RequestElementName = "AddCustomerQueryV5", RequestNamespace = "http://tempuri.org/", ResponseElementName = "AddCustomerQueryV5Response", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal)]
    [return: XmlElement("AddCustomerQueryV5Result")]
    public bool AddCustomerQuery(string ClientID, string ClientPassword, string Subject, string Body, string Email, string Date, string Client_Code, string Customer_Code, string Omquery_Code, string QueryStatus_Code, out string Message)
    {
      object[] objArray = this.Invoke("AddCustomerQuery", new object[10]
      {
        (object) ClientID,
        (object) ClientPassword,
        (object) Subject,
        (object) Body,
        (object) Email,
        (object) Date,
        (object) Client_Code,
        (object) Customer_Code,
        (object) Omquery_Code,
        (object) QueryStatus_Code
      });
      Message = (string) objArray[1];
      return (bool) objArray[0];
    }

    public void AddCustomerQueryAsync(string ClientID, string ClientPassword, string Subject, string Body, string Email, string Date, string Client_Code, string Customer_Code, string Omquery_Code, string QueryStatus_Code)
    {
      this.AddCustomerQueryAsync(ClientID, ClientPassword, Subject, Body, Email, Date, Client_Code, Customer_Code, Omquery_Code, QueryStatus_Code, (object) null);
    }

    public void AddCustomerQueryAsync(string ClientID, string ClientPassword, string Subject, string Body, string Email, string Date, string Client_Code, string Customer_Code, string Omquery_Code, string QueryStatus_Code, object userState)
    {
      if (this.AddCustomerQueryOperationCompleted == null)
        this.AddCustomerQueryOperationCompleted = new SendOrPostCallback(this.OnAddCustomerQueryOperationCompleted);
      this.InvokeAsync("AddCustomerQuery", new object[10]
      {
        (object) ClientID,
        (object) ClientPassword,
        (object) Subject,
        (object) Body,
        (object) Email,
        (object) Date,
        (object) Client_Code,
        (object) Customer_Code,
        (object) Omquery_Code,
        (object) QueryStatus_Code
      }, this.AddCustomerQueryOperationCompleted, userState);
    }

    private void OnAddCustomerQueryOperationCompleted(object arg)
    {
      if (this.AddCustomerQueryCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.AddCustomerQueryCompleted((object) this, new AddCustomerQueryCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://tempuri.org/AddStudentSMSFunctionwithMessageV5", ParameterStyle = SoapParameterStyle.Wrapped, RequestElementName = "AddStudentSMSFunctionwithMessageV5", RequestNamespace = "http://tempuri.org/", ResponseElementName = "AddStudentSMSFunctionwithMessageV5Response", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal)]
    [return: XmlElement("AddStudentSMSFunctionwithMessageV5Result")]
    public bool AddStudentSMSFunctionwithMessage(string ClientID, string ClientPassword, string Phone_Country_Code, string Phone_Number, string SMS_Body, string Student_Code, string Client_Code, out string Message)
    {
      object[] objArray = this.Invoke("AddStudentSMSFunctionwithMessage", new object[7]
      {
        (object) ClientID,
        (object) ClientPassword,
        (object) Phone_Country_Code,
        (object) Phone_Number,
        (object) SMS_Body,
        (object) Student_Code,
        (object) Client_Code
      });
      Message = (string) objArray[1];
      return (bool) objArray[0];
    }

    public void AddStudentSMSFunctionwithMessageAsync(string ClientID, string ClientPassword, string Phone_Country_Code, string Phone_Number, string SMS_Body, string Student_Code, string Client_Code)
    {
      this.AddStudentSMSFunctionwithMessageAsync(ClientID, ClientPassword, Phone_Country_Code, Phone_Number, SMS_Body, Student_Code, Client_Code, (object) null);
    }

    public void AddStudentSMSFunctionwithMessageAsync(string ClientID, string ClientPassword, string Phone_Country_Code, string Phone_Number, string SMS_Body, string Student_Code, string Client_Code, object userState)
    {
      if (this.AddStudentSMSFunctionwithMessageOperationCompleted == null)
        this.AddStudentSMSFunctionwithMessageOperationCompleted = new SendOrPostCallback(this.OnAddStudentSMSFunctionwithMessageOperationCompleted);
      this.InvokeAsync("AddStudentSMSFunctionwithMessage", new object[7]
      {
        (object) ClientID,
        (object) ClientPassword,
        (object) Phone_Country_Code,
        (object) Phone_Number,
        (object) SMS_Body,
        (object) Student_Code,
        (object) Client_Code
      }, this.AddStudentSMSFunctionwithMessageOperationCompleted, userState);
    }

    private void OnAddStudentSMSFunctionwithMessageOperationCompleted(object arg)
    {
      if (this.AddStudentSMSFunctionwithMessageCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.AddStudentSMSFunctionwithMessageCompleted((object) this, new AddStudentSMSFunctionwithMessageCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    public new void CancelAsync(object userState)
    {
      base.CancelAsync(userState);
    }

    private bool IsLocalFileSystemWebService(string url)
    {
      if (url == null || url == string.Empty)
        return false;
      Uri uri = new Uri(url);
      return uri.Port >= 1024 && string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0;
    }
  }
}
