// Decompiled with JetBrains decompiler
// Type: XRecCRMLibrary.NonThreadOriginate
// Assembly: XRecCRMLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DABBCD86-4B3A-41D7-8F33-D19BFAA38EFD
// Assembly location: E:\Services\XCRMServices\XRecCRMLibrary.dll

using ErrorLog;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace XRecCRMLibrary
{
  public class NonThreadOriginate
  {
    private static string strDirectoryName = string.Empty;
    private static string strFileName = string.Empty;
    private static bool Is_Stream_Closed = true;
    private static SqlConnection SqlConn = new SqlConnection(ConfigurationManager.AppSettings["Master"]);
    private static DataTable dtExecutionRecords;
    private static int rowNo;
    private static int threadPool;
    private static int lastIndex;
    private static StreamWriter ObjStreamWriter;
    private static FileStream ObjFileStream;

    public static DataTable DtExecutionRecords
    {
      get
      {
        return NonThreadOriginate.dtExecutionRecords;
      }
      set
      {
        NonThreadOriginate.dtExecutionRecords = value;
      }
    }

    public static int RowNo
    {
      get
      {
        return NonThreadOriginate.rowNo;
      }
      set
      {
        NonThreadOriginate.rowNo = value;
      }
    }

    public static int ThreadPool
    {
      get
      {
        return NonThreadOriginate.threadPool;
      }
      set
      {
        NonThreadOriginate.threadPool = value;
      }
    }

    public static int LastIndex
    {
      get
      {
        return NonThreadOriginate.lastIndex;
      }
      set
      {
        NonThreadOriginate.lastIndex = value;
      }
    }

    public static void SetLogFile()
    {
      if (!NonThreadOriginate.Is_Stream_Closed)
        return;
      Directory.SetCurrentDirectory(Application.StartupPath);
      DateTime now = DateTime.Now;
      NonThreadOriginate.strDirectoryName = now.ToString("yyyy");
      Directory.CreateDirectory(NonThreadOriginate.strDirectoryName);
      Directory.SetCurrentDirectory(NonThreadOriginate.strDirectoryName);
      now = DateTime.Now;
      NonThreadOriginate.strDirectoryName = now.ToString("MMMM");
      Directory.CreateDirectory(NonThreadOriginate.strDirectoryName);
      Directory.SetCurrentDirectory(NonThreadOriginate.strDirectoryName);
      now = DateTime.Now;
      NonThreadOriginate.strDirectoryName = now.ToString("dd");
      Directory.CreateDirectory(NonThreadOriginate.strDirectoryName);
      Directory.SetCurrentDirectory(NonThreadOriginate.strDirectoryName);
      NonThreadOriginate.strFileName = "Log.txt";
      NonThreadOriginate.ObjFileStream = new FileStream(NonThreadOriginate.strFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
      NonThreadOriginate.ObjStreamWriter = new StreamWriter((Stream) NonThreadOriginate.ObjFileStream);
      NonThreadOriginate.ObjStreamWriter.BaseStream.Seek(0L, SeekOrigin.End);
      NonThreadOriginate.Is_Stream_Closed = false;
    }

    public static void CloseLogFile()
    {
      NonThreadOriginate.ObjStreamWriter.Close();
      NonThreadOriginate.ObjFileStream.Close();
      NonThreadOriginate.Is_Stream_Closed = true;
    }

    public static void WriteLog(string message, Exception e)
    {
      try
      {
        try
        {
          LogError.Write(LogError.AppType.CRMIntegrationService, message, e, "CRM Service");
        }
        catch (Exception ex)
        {
          EventLog.WriteEntry("CRM Status Integration Service", DateTime.Now.ToString() + ": " + ex.Message);
        }
        NonThreadOriginate.ObjStreamWriter.WriteLine(message);
        NonThreadOriginate.ObjStreamWriter.Flush();
      }
      catch (Exception ex)
      {
        EventLog.WriteEntry("CRM Status Integration Service", DateTime.Now.ToString() + ": " + ex.Message);
      }
    }

    public static void WriteLog(string message)
    {
      try
      {
        try
        {
          Exception ex = (Exception) null;
          LogError.Write(LogError.AppType.CRMIntegrationService, message, ex, "CRM Service");
        }
        catch (Exception ex)
        {
          EventLog.WriteEntry("CRM Status Integration Service", DateTime.Now.ToString() + ": " + ex.Message);
        }
        NonThreadOriginate.ObjStreamWriter.WriteLine(message);
        NonThreadOriginate.ObjStreamWriter.Flush();
      }
      catch (Exception ex)
      {
        EventLog.WriteEntry("CRM Status Integration Service", DateTime.Now.ToString() + ": " + ex.Message);
      }
    }

    public static void WriteProcessingLog(string message)
    {
      try
      {
        NonThreadOriginate.ObjStreamWriter.WriteLine(message);
        NonThreadOriginate.ObjStreamWriter.Flush();
      }
      catch (Exception ex)
      {
        EventLog.WriteEntry("CRM Status Integration Service", DateTime.Now.ToString() + ": " + ex.Message);
      }
    }

    public static void DBLog(string message)
    {
      new SqlDataAdapter(ConfigurationManager.AppSettings["LogSP"].ToString() + " '" + message.Replace("'", "''") + "','" + (object) DateTime.Now + "'", NonThreadOriginate.SqlConn).Fill(new DataTable());
    }

    public static void StartExecution()
    {
      try
      {
        SqlConnection PLLiveAdminConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Master"].ConnectionString);
        FunctionChart functionChart = new FunctionChart();
        CRMStatusDataDLL crmStatusDataDll = new CRMStatusDataDLL();
        PLLiveAdminConnection.Open();
        DataTable allClients = crmStatusDataDll.GetAllClients(PLLiveAdminConnection);
        SecureQueryString secureQueryString = new SecureQueryString();
        foreach (DataRow row in (InternalDataCollectionBase) allClients.Rows)
          functionChart.CRMStatusFunction(row);
        allClients.Clear();
      }
      catch (Exception ex)
      {
        NonThreadOriginate.WriteLog(DateTime.Now.ToString() + ": Error while Fetching Records. Error: " + ex.ToString(), ex);
      }
    }

    public static void StopExecution()
    {
      try
      {
        new EmailFunctions().EmailOnServiceStop();
      }
      catch (Exception ex)
      {
        NonThreadOriginate.WriteLog(DateTime.Now.ToString() + ": Error while Fetching Records. Error: " + ex.ToString(), ex);
      }
    }

    public static void StartExecutionError()
    {
    }

    public static void ClearPreviousRecords()
    {
      if (NonThreadOriginate.ThreadPool != 0 || NonThreadOriginate.RowNo != NonThreadOriginate.LastIndex)
        return;
      NonThreadOriginate.DtExecutionRecords.Clear();
      NonThreadOriginate.RowNo = 0;
      NonThreadOriginate.LastIndex = 0;
    }

    private static void CloseSqlConnections(SqlConnection sqlConn)
    {
      try
      {
        sqlConn.Close();
      }
      catch (Exception ex)
      {
        NonThreadOriginate.WriteLog(ex.ToString(), ex);
      }
    }

    private static void SetSqlConnections(SqlConnection sqlConn)
    {
      try
      {
        sqlConn = new SqlConnection(ConfigurationManager.AppSettings["Master"]);
        sqlConn.Open();
      }
      catch (Exception ex)
      {
        NonThreadOriginate.WriteLog(ex.ToString(), ex);
      }
    }

    private static DataRow GetRecord()
    {
      if (NonThreadOriginate.rowNo <= NonThreadOriginate.lastIndex)
        return NonThreadOriginate.dtExecutionRecords.Rows[NonThreadOriginate.rowNo++];
      return (DataRow) null;
    }
  }
}
