// Decompiled with JetBrains decompiler
// Type: XRecCRMLibrary.Functions
// Assembly: XRecCRMLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DABBCD86-4B3A-41D7-8F33-D19BFAA38EFD
// Assembly location: E:\Services\XCRMServices\XRecCRMLibrary.dll

using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using XRecCRMLibrary.XRecCRMAPI;

namespace XRecCRMLibrary
{
  internal class Functions
  {
    private CRMStatusDataDLL objCRMStatusData = new CRMStatusDataDLL();

    public bool AddCandidateInfoCRM(SqlConnection sqlConn, StringCollection param, ref string APIErrMsg)
    {
      return this.AddCandidateDataCRM(this.objCRMStatusData.GetCandidatesDataCRM(sqlConn, param[0]), param[1], param[2], param[3], param[4], ref APIErrMsg);
    }

    public bool ActionBasedForgotPasswordCRM(SqlConnection sqlConn, StringCollection param, ref string APIErrMsg)
    {
      return this.ActionBasedEmailThroughCRM(this.objCRMStatusData.GetCandidatesPasswordLink(sqlConn, param[0]), param[1], param[2], param[3], param[4], param[5], param[6], ref APIErrMsg);
    }

    public bool ActionBasedEmailVerificationCRM(SqlConnection sqlConn, StringCollection param, ref string APIErrMsg)
    {
      return this.ActionBasedEmailThroughCRM(this.objCRMStatusData.GetCandidatesEmailVerificationCode(sqlConn, param[0]), param[1], param[2], param[3], param[4], param[5], param[6], ref APIErrMsg);
    }

    public bool ActionBasedPhoneVerificationCRM(SqlConnection sqlConn, StringCollection param, ref string APIErrMsg)
    {
      return this.ActionBasedSMSThroughCRM(this.objCRMStatusData.GetCandidatesPhoneVerificationCode(sqlConn, param[0]), param[1], param[2], param[3], param[4], param[5], param[6], ref APIErrMsg);
    }

    public bool StatusBasedSMSCRM(SqlConnection sqlConn, StringCollection param, ref string APIErrMsg)
    {
      return this.ActionBasedSMSThroughCRM(this.objCRMStatusData.GetCandidateSMSData(sqlConn, param[0]), param[1], param[2], param[3], param[4], param[5], param[6], ref APIErrMsg);
    }

    public bool CandidateQueryCRM(SqlConnection sqlConn, StringCollection param, ref string APIErrMsg)
    {
      return this.CandidateQueryDataToCRM(this.objCRMStatusData.GetCandidateQueryData(sqlConn, param[0]), param[1], param[2], param[3], param[4], param[5], param[6], ref APIErrMsg);
    }

    public bool AddCandidateDataCRM(DataTable dtCandidate, string clientCode, string CRMClientCode, string CRMclientID, string CRMclientPassword, ref string APIErrMsg)
    {
      bool flag = false;
      if (dtCandidate.Rows.Count > 0)
      {
        SecureQueryString secureQueryString = new SecureQueryString();
        if (Convert.ToInt32(clientCode) == 1)
          flag = new CRMAPI().AddCustomer(CRMclientID, CRMclientPassword, CRMClientCode, dtCandidate.Rows[0]["Candidate_Code"].ToString(), dtCandidate.Rows[0]["Candidate_ID"].ToString(), dtCandidate.Rows[0]["Status_Code"].ToString(), dtCandidate.Rows[0]["Full_Name"].ToString(), dtCandidate.Rows[0]["Full_Name"].ToString(), dtCandidate.Rows[0]["Full_Name"].ToString(), dtCandidate.Rows[0]["Email_Address"].ToString(), !string.IsNullOrEmpty(dtCandidate.Rows[0]["Password"].ToString()) ? secureQueryString.decrypt(dtCandidate.Rows[0]["Password"].ToString()) : "", dtCandidate.Rows[0]["City"].ToString(), dtCandidate.Rows[0]["State"].ToString(), "0", dtCandidate.Rows[0]["Country"].ToString(), dtCandidate.Rows[0]["Country_Code"].ToString(), dtCandidate.Rows[0]["Updated_IP"].ToString(), dtCandidate.Rows[0]["Phone_Code"].ToString(), "-", dtCandidate.Rows[0]["HomePhoneNumber"].ToString(), PhoneType.LandLine, dtCandidate.Rows[0]["Phone_Code"].ToString(), "-", dtCandidate.Rows[0]["Mobile_Number"].ToString(), PhoneType.MobileNumber, dtCandidate.Rows[0]["Phone_Code"].ToString(), "-", "-", PhoneType.MobileNumber, dtCandidate.Rows[0]["DateOf_Birth"].ToString(), dtCandidate.Rows[0]["Gender"].ToString(), 0, 0, CallType.Default, "-", "-", 0, Convert.ToInt32(dtCandidate.Rows[0]["SignUpThrough_Code"]), dtCandidate.Rows[0]["PhoneVerification_Code"].ToString(), dtCandidate.Rows[0]["EmailVerification_Code"].ToString(), Convert.ToBoolean(dtCandidate.Rows[0]["is_PhoneVerified"]), Convert.ToBoolean(dtCandidate.Rows[0]["Is_EmailVerified"]), dtCandidate.Rows[0]["Nationality"].ToString(), dtCandidate.Rows[0]["MaritalStatus"].ToString(), dtCandidate.Rows[0]["Religion"].ToString(), dtCandidate.Rows[0]["NIC"].ToString(), dtCandidate.Rows[0]["Passport_No"].ToString(), dtCandidate.Rows[0]["HomePhoneNumber"].ToString(), dtCandidate.Rows[0]["Address"].ToString(), dtCandidate.Rows[0]["Department"].ToString(), dtCandidate.Rows[0]["Position"].ToString(), dtCandidate.Rows[0]["Designation"].ToString(), dtCandidate.Rows[0]["Scheduling_Test_Date"].ToString(), dtCandidate.Rows[0]["Scheduling_Test_Time"].ToString(), dtCandidate.Rows[0]["Scheduling_Interview_Date"].ToString(), dtCandidate.Rows[0]["Scheduling_Interview_Time"].ToString(), dtCandidate.Rows[0]["Scheduling_Offer_Date"].ToString(), dtCandidate.Rows[0]["Scheduling_Offer_Time"].ToString(), dtCandidate.Rows[0]["Scheduling_Joining_Date"].ToString(), dtCandidate.Rows[0]["Scheduling_Joining_Time"].ToString(), dtCandidate.Rows[0]["ResetPasswordLink"].ToString(), dtCandidate.Rows[0]["SampleTest_Link"].ToString(), Convert.ToBoolean(dtCandidate.Rows[0]["Is_Active"]), dtCandidate.Rows[0]["Created_Date"].ToString(), out APIErrMsg);
      }
      return flag;
    }

    public bool ActionBasedEmailThroughCRM(DataTable dtCandidate, string clientCode, string CRMClientCode, string CRMclientID, string CRMclientPassword, string ClientName, string ClientEmail, ref string APIErrMsg)
    {
      bool flag = false;
      if (dtCandidate.Rows.Count > 0)
      {
        SecureQueryString secureQueryString = new SecureQueryString();
        if (Convert.ToInt32(clientCode) == 1)
          flag = new CRMAPI().AddStudentEmailFunctionwithMessage(CRMclientID, CRMclientPassword, dtCandidate.Rows[0]["Email_Address"].ToString(), dtCandidate.Rows[0]["Full_Name"].ToString(), ClientName, ClientEmail, dtCandidate.Rows[0]["Email_Subject"].ToString(), dtCandidate.Rows[0]["Email_Body"].ToString(), dtCandidate.Rows[0]["EmailFunction_Code"].ToString(), dtCandidate.Rows[0]["Candidate_Code"].ToString(), CRMClientCode, EmailSendingStatus.Pending, out APIErrMsg);
      }
      return flag;
    }

    public bool ActionBasedSMSThroughCRM(DataTable dtCandidate, string clientCode, string CRMClientCode, string CRMclientID, string CRMclientPassword, string ClientName, string ClientEmail, ref string APIErrMsg)
    {
      bool flag = false;
      if (dtCandidate.Rows.Count > 0)
      {
        SecureQueryString secureQueryString = new SecureQueryString();
        if (Convert.ToInt32(clientCode) == 1)
          flag = new CRMAPI().AddStudentSMSFunctionwithMessage(CRMclientID, CRMclientPassword, dtCandidate.Rows[0]["Phone_Country_Code"].ToString(), dtCandidate.Rows[0]["Phone_Number"].ToString(), dtCandidate.Rows[0]["SMS_Body"].ToString(), dtCandidate.Rows[0]["Candidate_Code"].ToString(), CRMClientCode, out APIErrMsg);
      }
      return flag;
    }

    public bool CandidateQueryDataToCRM(DataTable dtCandidateQuery, string clientCode, string CRMClientCode, string CRMclientID, string CRMclientPassword, string ClientName, string ClientEmail, ref string APIErrMsg)
    {
      bool flag = false;
      if (dtCandidateQuery.Rows.Count > 0)
      {
        SecureQueryString secureQueryString = new SecureQueryString();
        if (Convert.ToInt32(clientCode) == 1)
          flag = new CRMAPI().AddCustomerQuery(CRMclientID, CRMclientPassword, dtCandidateQuery.Rows[0]["Subject"].ToString(), dtCandidateQuery.Rows[0]["Body"].ToString(), dtCandidateQuery.Rows[0]["Email"].ToString(), dtCandidateQuery.Rows[0]["Date"].ToString(), CRMClientCode, dtCandidateQuery.Rows[0]["Candidate_Code"].ToString(), dtCandidateQuery.Rows[0]["OMQuery_Code"].ToString(), dtCandidateQuery.Rows[0]["QueryStatus_Code"].ToString(), out APIErrMsg);
      }
      return flag;
    }
  }
}
