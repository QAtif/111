// Decompiled with JetBrains decompiler
// Type: PLCRMStatusMarkingService.CRMStatusMarkingService
// Assembly: XRecCRMService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7FEAB8C4-2C93-4EF2-ADFC-4B29F705460E
// Assembly location: E:\Services\XCRMServices\XRecCRMService.exe

using ErrorLog;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;
using XRecCRMLibrary;

namespace PLCRMStatusMarkingService
{
  public class CRMStatusMarkingService : ServiceBase
  {
    private IContainer components = (IContainer) null;
    private Timer tmrExecutor;
    private Timer tmrExecutorError;

    public CRMStatusMarkingService()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.tmrExecutor = new System.Timers.Timer();
            this.tmrExecutorError = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.tmrExecutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmrExecutorError)).BeginInit();
            // 
            // tmrExecutor
            // 
            this.tmrExecutor.Enabled = true;
            this.tmrExecutor.Interval = 30000D;
            this.tmrExecutor.Elapsed += new System.Timers.ElapsedEventHandler(this.tmrExecutor_Elapsed);
            // 
            // tmrExecutorError
            // 
            this.tmrExecutorError.Enabled = true;
            this.tmrExecutorError.Interval = 30000D;
            this.tmrExecutorError.Elapsed += new System.Timers.ElapsedEventHandler(this.tmrExecutorError_Elapsed);
            // 
            // CRMStatusMarkingService
            // 
            this.ServiceName = "CRMStatusMarkingService";
            ((System.ComponentModel.ISupportInitialize)(this.tmrExecutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmrExecutorError)).EndInit();

    }

    protected override void OnStart(string[] args)
    {
            //Debugger.Launch();
      NonThreadOriginate.DtExecutionRecords = new DataTable();
      NonThreadOriginate.RowNo = 0;
      NonThreadOriginate.ThreadPool = 0;
      NonThreadOriginate.LastIndex = 0;
      NonThreadOriginate.WriteLog("<<< CRM Status Integration Service Started. Date: " + DateTime.Now.ToString() + " >>>");
      this.tmrExecutor.Interval = (double) int.Parse(ConfigurationManager.AppSettings["INTERVAL"]);
      this.tmrExecutor.Enabled = true;
    }

    protected override void OnStop()
    {
      NonThreadOriginate.StopExecution();
      NonThreadOriginate.WriteLog("<<< CRM Status Integration Service Started. Date: " + DateTime.Now.ToString() + " >>>");
      this.tmrExecutor.Enabled = false;
    }

    private void tmrExecutor_Elapsed(object sender, ElapsedEventArgs e)
    {
      this.tmrExecutor.Enabled = false;
      try
      {
        NonThreadOriginate.StartExecution();
      }
      catch (Exception ex1)
      {
        try
        {
          EventLog.WriteEntry("CRM Status Integration Service", DateTime.Now.ToString() + ":" + ex1.Message);
          LogError.Write(LogError.AppType.CRMIntegrationService, ex1.Message, ex1, "CRM Service");
        }
        catch (Exception ex2)
        {
        }
      }
      this.tmrExecutor.Enabled = true;
    }

        private void tmrExecutorError_Elapsed(object sender, ElapsedEventArgs e)
        {

        }
    }
}
