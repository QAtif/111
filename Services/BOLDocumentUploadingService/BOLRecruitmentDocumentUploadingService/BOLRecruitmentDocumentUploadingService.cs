using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Configuration;
using BOLRecruitmentDocumentUploadingLibrary;


namespace BOLRecruitmentDocumentUploadingService
{
    public partial class BOLRecruitmentDocumentUploadingService : ServiceBase
    {
        public BOLRecruitmentDocumentUploadingService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
       
            try
            {
                Debugger.Launch();
                Logging.WriteToLog(Logging.GenerateDefaultLogFileName("BOLRecruitmentDocumentUploadingService"), "Email Service Started.");

                tmrExecutor.Interval = int.Parse(ConfigurationManager.AppSettings["INTERVAL"].ToString());
                //tmrExecutorError.Interval = int.Parse(ConfigurationManager.AppSettings["INTERVALError"].ToString());
            }
            catch (Exception exc)
            {
                EventLog.WriteEntry("BOLRecruitment Document Uploading Service", exc.Message);
            }
        }

        protected override void OnStop()
        {
            Logging.WriteToLog(Logging.GenerateDefaultLogFileName("BOLRecruitmentDocumentUploadingService"), "Service Stop.");
        }


        private void tmrExecutorError_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

        }

        private void tmrExecutor_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
           
            Logging.WriteToLog(Logging.GenerateDefaultLogFileName("BOLRecruitmentDocumentUploadingService"), "tmrExecutor_Elapsed - Start");
            
            try
            {
                tmrExecutor.Enabled = false;
                try
                {
                    UploadingOriginate.StartExecution();
                    //NonThreadOriginate.StartExecution();


                }
                catch (Exception ex)
                {
                    Logging.WriteToLog(Logging.GenerateDefaultLogFileName("BOLRecruitmentDocumentUploadingService"), "Inner Exception in Timer Elapsed. >>> " + ex.ToString());
                }
                tmrExecutor.Enabled = true;
            }
            catch (Exception exc)
            {
                Logging.WriteToLog(Logging.GenerateDefaultLogFileName("BOLRecruitmentDocumentUploadingService"), "Exception in Timer Elapsed. >>> " + exc.ToString());
            }

            Logging.WriteToLog(Logging.GenerateDefaultLogFileName("BOLRecruitmentDocumentUploadingService"), "tmrExecutor_Elapsed - End");

        }


    }
}
