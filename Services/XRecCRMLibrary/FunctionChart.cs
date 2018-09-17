// Decompiled with JetBrains decompiler
// Type: XRecCRMLibrary.FunctionChart
// Assembly: XRecCRMLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DABBCD86-4B3A-41D7-8F33-D19BFAA38EFD
// Assembly location: E:\Services\XCRMServices\XRecCRMLibrary.dll

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace XRecCRMLibrary
{
  internal class FunctionChart
  {
    private CRMStatusDataDLL objCRMStatusData = new CRMStatusDataDLL();
    private Functions objFunctions = new Functions();
    private StringCollection parameters = new StringCollection();

    public void CRMStatusFunction(DataRow drClient)
    {
      bool result = false;
      string str1 = drClient["Client_Master_Credentials"].ToString();
      SqlConnection sqlConnection = new SqlConnection();
      sqlConnection.ConnectionString = str1;
      if (sqlConnection.State != ConnectionState.Open)
        sqlConnection.Open();
      string str2 = drClient["Client_Name"].ToString();
      string str3 = drClient["Client_Code"].ToString();
      string str4 = drClient["CRMClient_Code"].ToString();
      string str5 = drClient["CRMClient_ID"].ToString();
      string str6 = drClient["CRMClient_Password"].ToString();
      string str7 = drClient["Client_Email"].ToString();
      foreach (DataRow row in (InternalDataCollectionBase) this.objCRMStatusData.GetAllCRMStatusData(sqlConnection).Rows)
      {
        int FunctionCode = -1;
        int num = -1;
        int actionCode = -1;
        string empty1 = string.Empty;
        try
        {
          List<Thread> threadList = new List<Thread>();
          FunctionCode = Convert.ToInt32(row["CRMService_Function_Code"]);
          num = Convert.ToInt32(row["Argument"]);
          actionCode = Convert.ToInt32(row["CRMServiceExecution_Code"]);
          switch (FunctionCode)
          {
            case 1:
              this.parameters.Add(num.ToString());
              this.parameters.Add(str3);
              this.parameters.Add(str4);
              this.parameters.Add(str5);
              this.parameters.Add(str6);
              result = this.objFunctions.AddCandidateInfoCRM(sqlConnection, this.parameters, ref empty1);
              this.parameters.Clear();
              break;
            case 2:
              this.parameters.Add(num.ToString());
              this.parameters.Add(str3);
              this.parameters.Add(str4);
              this.parameters.Add(str5);
              this.parameters.Add(str6);
              this.parameters.Add(str2);
              this.parameters.Add(str7);
              result = this.objFunctions.ActionBasedForgotPasswordCRM(sqlConnection, this.parameters, ref empty1);
              this.parameters.Clear();
              break;
            case 3:
              this.parameters.Add(num.ToString());
              this.parameters.Add(str3);
              this.parameters.Add(str4);
              this.parameters.Add(str5);
              this.parameters.Add(str6);
              this.parameters.Add(str2);
              this.parameters.Add(str7);
              result = this.objFunctions.ActionBasedEmailVerificationCRM(sqlConnection, this.parameters, ref empty1);
              this.parameters.Clear();
              break;
            case 4:
              this.parameters.Add(num.ToString());
              this.parameters.Add(str3);
              this.parameters.Add(str4);
              this.parameters.Add(str5);
              this.parameters.Add(str6);
              this.parameters.Add(str2);
              this.parameters.Add(str7);
              result = this.objFunctions.ActionBasedPhoneVerificationCRM(sqlConnection, this.parameters, ref empty1);
              this.parameters.Clear();
              break;
            case 5:
              this.parameters.Add(num.ToString());
              this.parameters.Add(str3);
              this.parameters.Add(str4);
              this.parameters.Add(str5);
              this.parameters.Add(str6);
              this.parameters.Add(str2);
              this.parameters.Add(str7);
              result = this.objFunctions.StatusBasedSMSCRM(sqlConnection, this.parameters, ref empty1);
              this.parameters.Clear();
              break;
            case 6:
              this.parameters.Add(num.ToString());
              this.parameters.Add(str3);
              this.parameters.Add(str4);
              this.parameters.Add(str5);
              this.parameters.Add(str6);
              this.parameters.Add(str2);
              this.parameters.Add(str7);
              result = this.objFunctions.CandidateQueryCRM(sqlConnection, this.parameters, ref empty1);
              this.parameters.Clear();
              break;
          }
        }
        catch (Exception ex)
        {
          result = false;
        }
        try
        {
          string empty2;
          if (result)
          {
            CRMStatusDataDLL.MarkActionCompleted(actionCode, sqlConnection, "Successfully Moved", result);
            empty2 = string.Empty;
            result = false;
          }
          else if (!result)
          {
            CRMStatusDataDLL.MarkActionError(actionCode, sqlConnection, FunctionCode, empty1, result);
            empty2 = string.Empty;
            result = false;
          }
        }
        catch (Exception ex)
        {
          NonThreadOriginate.WriteLog("Error on ActionCode: " + (object) actionCode + ". Function Code: " + FunctionCode.ToString() + ". Argument: " + (object) num + " . Error is: " + ex.ToString(), ex);
        }
        finally
        {
        }
      }
      if (sqlConnection.State == ConnectionState.Closed)
        return;
      sqlConnection.Close();
    }
  }
}
