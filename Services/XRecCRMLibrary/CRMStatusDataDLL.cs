// Decompiled with JetBrains decompiler
// Type: XRecCRMLibrary.CRMStatusDataDLL
// Assembly: XRecCRMLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DABBCD86-4B3A-41D7-8F33-D19BFAA38EFD
// Assembly location: E:\Services\XCRMServices\XRecCRMLibrary.dll

using System;
using System.Data;
using System.Data.SqlClient;

namespace XRecCRMLibrary
{
  internal class CRMStatusDataDLL
  {
    public DataTable GetAllClients(SqlConnection PLLiveAdminConnection)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.Connection = PLLiveAdminConnection;
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.CommandTimeout = 216000;
      selectCommand.CommandText = "dbo.XRec_Select_AllClientsForCRMService";
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataTable dataTable = new DataTable();
      sqlDataAdapter.Fill(dataTable);
      return dataTable;
    }

    public DataTable GetAllCRMStatusData(SqlConnection sqlConn)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.Connection = sqlConn;
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.CommandText = "dbo.XRec_CRM_Select_ServiceExecutionData";
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      return dataSet.Tables[0];
    }

    public DataTable GetCandidatesDataCRM(SqlConnection sqlConnection, string CandidateCode)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.Connection = sqlConnection;
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.CommandText = "dbo.XRec_CRM_Select_CandidateData";
      selectCommand.Parameters.AddWithValue("@Candidate_Code", (object) CandidateCode);
      DataTable dataTable = new DataTable();
      new SqlDataAdapter(selectCommand).Fill(dataTable);
      return dataTable;
    }

    public DataTable GetCandidatesPasswordLink(SqlConnection sqlConnection, string CandidateCode)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.Connection = sqlConnection;
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.CommandText = "dbo.XRec_CRM_Select_ActionBaseCandidateData";
      selectCommand.Parameters.AddWithValue("@Candidate_Code", (object) CandidateCode);
      DataTable dataTable = new DataTable();
      new SqlDataAdapter(selectCommand).Fill(dataTable);
      return dataTable;
    }

    public DataTable GetCandidatesEmailVerificationCode(SqlConnection sqlConnection, string CandidateCode)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.Connection = sqlConnection;
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.CommandText = "dbo.XRec_CRM_Select_ActionBaseEmailVerification";
      selectCommand.Parameters.AddWithValue("@Candidate_Code", (object) CandidateCode);
      DataTable dataTable = new DataTable();
      new SqlDataAdapter(selectCommand).Fill(dataTable);
      return dataTable;
    }

    public DataTable GetCandidatesPhoneVerificationCode(SqlConnection sqlConnection, string CandidateCode)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.Connection = sqlConnection;
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.CommandText = "dbo.XRec_CRM_Select_ActionBasePhoneVerification";
      selectCommand.Parameters.AddWithValue("@Candidate_Code", (object) CandidateCode);
      DataTable dataTable = new DataTable();
      new SqlDataAdapter(selectCommand).Fill(dataTable);
      return dataTable;
    }

    public DataTable GetCandidateSMSData(SqlConnection sqlConnection, string CandidateCode)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.Connection = sqlConnection;
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.CommandText = "dbo.XRec_CRM_Select_ActionBasedCandidateSMS";
      selectCommand.Parameters.AddWithValue("@Candidate_Code", (object) CandidateCode);
      DataTable dataTable = new DataTable();
      new SqlDataAdapter(selectCommand).Fill(dataTable);
      return dataTable;
    }

    public DataTable GetCandidateQueryData(SqlConnection sqlConnection, string CandidateCommunicationCode)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.Connection = sqlConnection;
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.CommandText = "dbo.XRec_CRM_Select_CandidateCommunication";
      selectCommand.Parameters.AddWithValue("@CandidateCommunication_Code", (object) CandidateCommunicationCode);
      DataTable dataTable = new DataTable();
      new SqlDataAdapter(selectCommand).Fill(dataTable);
      return dataTable;
    }

    public static void MarkActionCompleted(int actionCode, SqlConnection sqlCon, string APIMsg, bool result)
    {
      try
      {
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlCon;
        sqlCommand.CommandText = "CRMStatusService_Delete_ExecutedAction";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CRMServiceExecution_Code", SqlDbType.Int, 4).Value = (object) actionCode;
        sqlCommand.Parameters.Add("@APIErrMsg", SqlDbType.VarChar).Value = (object) APIMsg;
        sqlCommand.Parameters.Add("@Is_MoveToCRM", SqlDbType.Bit).Value = (object) result;
        sqlCommand.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        NonThreadOriginate.WriteLog("Error on ActionCode: " + (object) actionCode + " . Error is: " + ex.ToString(), ex);
      }
    }

    public static void MarkActionError(int actionCode, SqlConnection sqlCon, int FunctionCode, string APIErrMsg, bool result)
    {
      try
      {
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlCon;
        sqlCommand.CommandText = "CRMStatusService_Update_FailureAction";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CRMServiceExecution_Code", SqlDbType.Int, 4).Value = (object) actionCode;
        sqlCommand.Parameters.Add("@APIErrMsg", SqlDbType.VarChar).Value = (object) APIErrMsg;
        sqlCommand.Parameters.Add("@Is_MoveToCRM", SqlDbType.Bit).Value = (object) result;
        sqlCommand.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        NonThreadOriginate.WriteLog("Error on ActionCode: " + (object) actionCode + " . Error is: " + ex.ToString(), ex);
      }
    }
  }
}
