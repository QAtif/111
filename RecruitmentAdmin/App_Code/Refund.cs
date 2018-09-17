// Decompiled with JetBrains decompiler
// Type: Refund
// Assembly: App_Code, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CCFCF570-EAC0-4D2F-8EF3-866C275AB6B3
// Assembly location: C:\Users\atifhussain\Desktop\Dlls\Axact Recruitment\App_Code.dll

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

public class Refund
{
  public DataSet GetOrderReport(SqlConnection sqlConnection, StringCollection parameters)
  {
    SqlCommand selectCommand = new SqlCommand();
    selectCommand.Connection = sqlConnection;
    selectCommand.CommandType = CommandType.StoredProcedure;
    selectCommand.CommandText = "PL_Summary_Select_StudentAccountHistory";
    selectCommand.Parameters.Add("@Student_Code", SqlDbType.Int).Value = (object) parameters[0];
    selectCommand.Parameters.Add("@Order_ID", SqlDbType.VarChar, 250).Value = (object) parameters[1];
    selectCommand.Parameters.Add("@From_Date", SqlDbType.VarChar).Value = (object) parameters[2];
    selectCommand.Parameters.Add("@To_Date", SqlDbType.VarChar).Value = (object) parameters[3];
    selectCommand.Parameters.Add("@Order_Type", SqlDbType.VarChar).Value = (object) parameters[4];
    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
    DataSet dataSet = new DataSet();
    sqlDataAdapter.Fill(dataSet);
    return dataSet;
  }

  public DataSet GetStudentRefundAgent(SqlConnection sqlConnection, ArrayList parameters)
  {
    SqlCommand selectCommand = new SqlCommand();
    selectCommand.Connection = sqlConnection;
    selectCommand.CommandType = CommandType.StoredProcedure;
    selectCommand.CommandText = "PL_Refund_Select_StudentRefundAgent";
    selectCommand.Parameters.Add("@Order_ID", SqlDbType.VarChar, 250).Value = parameters[0];
    selectCommand.Parameters.Add("@From_Date", SqlDbType.VarChar).Value = parameters[1];
    selectCommand.Parameters.Add("@To_Date", SqlDbType.VarChar).Value = parameters[2];
    selectCommand.Parameters.Add("@Order_Description", SqlDbType.VarChar).Value = parameters[3];
    selectCommand.Parameters.Add("@Student_Code", SqlDbType.Int).Value = parameters[4];
    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
    DataSet dataSet = new DataSet();
    sqlDataAdapter.Fill(dataSet);
    return dataSet;
  }

  public string InsertStudentRefundAgent(SqlTransaction sqlTrans, ArrayList parameters)
  {
    SqlCommand sqlCommand = new SqlCommand();
    sqlCommand.Connection = sqlTrans.Connection;
    sqlCommand.Transaction = sqlTrans;
    sqlCommand.CommandType = CommandType.StoredProcedure;
    sqlCommand.CommandText = "PL_Refund_Insert_StudentOrderRefundAgent";
    sqlCommand.Parameters.Add("@StudentProgram_Code", SqlDbType.Int).Value = parameters[0];
    sqlCommand.Parameters.Add("@Order_Code", SqlDbType.Int).Value = parameters[1];
    sqlCommand.Parameters.Add("@Refund_Amount_Requested", SqlDbType.Decimal).Value = parameters[2];
    sqlCommand.Parameters.Add("@Refund_Type_Code", SqlDbType.Int).Value = parameters[3];
    sqlCommand.Parameters.Add("@Refund_Type_Name", SqlDbType.VarChar).Value = parameters[4];
    sqlCommand.Parameters.Add("@Refund_Reason_Code", SqlDbType.Int).Value = parameters[5];
    sqlCommand.Parameters.Add("@Refund_Reason_Name", SqlDbType.VarChar).Value = parameters[6];
    sqlCommand.Parameters.Add("@Refund_Reason_Description", SqlDbType.VarChar).Value = parameters[7];
    sqlCommand.Parameters.Add("@Refund_Status_Code", SqlDbType.Int).Value = parameters[8];
    sqlCommand.Parameters.Add("@Refund_Status_Name", SqlDbType.VarChar).Value = parameters[9];
    sqlCommand.Parameters.Add("@Is_Order_Cancelled", SqlDbType.Bit).Value = parameters[10];
    sqlCommand.Parameters.Add("@Agent_Code", SqlDbType.Int).Value = parameters[11];
    sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = parameters[12];
    return Convert.ToString(sqlCommand.ExecuteScalar());
  }

  public string InsertStudentRefundAgent(SqlConnection sqlConn, ArrayList parameters)
  {
    SqlCommand sqlCommand = new SqlCommand();
    sqlCommand.Connection = sqlConn;
    sqlCommand.CommandType = CommandType.StoredProcedure;
    sqlCommand.CommandText = "PL_Refund_Insert_StudentOrderRefundAgent";
    sqlCommand.Parameters.Add("@StudentProgram_Code", SqlDbType.Int).Value = parameters[0];
    sqlCommand.Parameters.Add("@Order_Code", SqlDbType.Int).Value = parameters[1];
    sqlCommand.Parameters.Add("@Refund_Amount_Requested", SqlDbType.Decimal).Value = parameters[2];
    sqlCommand.Parameters.Add("@Refund_Type_Code", SqlDbType.Int).Value = parameters[3];
    sqlCommand.Parameters.Add("@Refund_Type_Name", SqlDbType.VarChar).Value = parameters[4];
    sqlCommand.Parameters.Add("@Refund_Reason_Code", SqlDbType.Int).Value = parameters[5];
    sqlCommand.Parameters.Add("@Refund_Reason_Name", SqlDbType.VarChar).Value = parameters[6];
    sqlCommand.Parameters.Add("@Refund_Reason_Description", SqlDbType.VarChar).Value = parameters[7];
    sqlCommand.Parameters.Add("@Refund_Status_Code", SqlDbType.Int).Value = parameters[8];
    sqlCommand.Parameters.Add("@Refund_Status_Name", SqlDbType.VarChar).Value = parameters[9];
    sqlCommand.Parameters.Add("@Is_Order_Cancelled", SqlDbType.Bit).Value = parameters[10];
    sqlCommand.Parameters.Add("@Agent_Code", SqlDbType.Int).Value = parameters[11];
    sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = parameters[12];
    return Convert.ToString(sqlCommand.ExecuteScalar());
  }

  public DataTable GetOrderInstallments(SqlConnection sqlConnection, string orderCode)
  {
    SqlCommand selectCommand = new SqlCommand();
    selectCommand.Connection = sqlConnection;
    selectCommand.CommandType = CommandType.StoredProcedure;
    selectCommand.CommandText = "PL_Refund_Select_OrderInstallments";
    selectCommand.Parameters.Add("@Order_Code", SqlDbType.Int).Value = (object) orderCode;
    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
    DataTable dataTable = new DataTable();
    sqlDataAdapter.Fill(dataTable);
    return dataTable;
  }
}
