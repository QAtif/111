using ErrorLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BOLRecruitmentDocumentUploadingLibrary
{
    public class UploadingOriginate
    {
        #region "Execution"
        public static void StartExecution()
        {
            //System.Diagnostics.Debugger.Launch();
            UploadingFunction objEmail = new UploadingFunction();
            try
            {
                objEmail.GetDataforPDFGeneration();
            }
            catch (Exception ex)
            {
                Logging.WriteToLog(Logging.GenerateDefaultLogFileName("BRecruitmentDocumentUploadingService"), "Inner Exception in GetDataforPDFGeneration. >>> " + ex.ToString());
                LogError.Write(LogError.AppType.Candidate, ex.Message + " GetDataforPDFGeneration " + ex.StackTrace, ex, "");
            }
            try
            {
                objEmail.SendDocument();
            }
            catch (Exception ex)
            {
                Logging.WriteToLog(Logging.GenerateDefaultLogFileName("BRecruitmentDocumentUploadingService"), "Inner Exception in Send Document. >>> " + ex.ToString());
                LogError.Write(LogError.AppType.Candidate, ex.Message + " Send Document " + ex.StackTrace, ex, "");
            }

            #region PortalSyn

             try
            {
                objEmail.GetDataforPortalPic();
            }
            catch (Exception ex)
            {
                Logging.WriteToLog(Logging.GenerateDefaultLogFileName("BRecruitmentDocumentUploadingService"), "Inner Exception in GetDataforPortalPic. >>> " + ex.ToString());
                LogError.Write(LogError.AppType.Candidate, ex.Message + " GetDataforPortalPic " + ex.StackTrace, ex, "");
            }
            try
            {
                objEmail.SyncDesignationsWithPortal();
            }
            catch (Exception ex)
            {
                Logging.WriteToLog(Logging.GenerateDefaultLogFileName("BRecruitmentDocumentUploadingService"), "Inner Exception in SyncDesignationsWithPortal. >>> " + ex.ToString());
                LogError.Write(LogError.AppType.Candidate, ex.Message + " SyncDesignationsWithPortal " + ex.StackTrace, ex, "");
            }
            try
            {
                objEmail.SyncDepartmentWithPortal();
            }
            catch (Exception ex)
            {
                Logging.WriteToLog(Logging.GenerateDefaultLogFileName("BRecruitmentDocumentUploadingService"), "Inner Exception in SyncDepartmentWithPortal. >>> " + ex.ToString());
                LogError.Write(LogError.AppType.Candidate, ex.Message + " SyncDepartmentWithPortal " + ex.StackTrace, ex, "");
            }
           
            //objEmail.SyncJobRoleAndBenefitsForSupportStaffWithPortal();
            //objEmail.SendEmailForTentativeJoining();
            //objEmail.SendEmailForBG();
            ////objEmail.GetSyncDocument();

            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;

            if (hour == 3 && minute >= 30)
            {
                if (!objEmail.CheckForTodaySyncPortalSchedul(DateTime.Now.Date))
                {
                    try
                    {
                        objEmail.SyncPortalUsersData(DateTime.Now.Date);
                    }
                    catch (Exception ex)
                    {
                        Logging.WriteToLog(Logging.GenerateDefaultLogFileName("BRecruitmentDocumentUploadingService"), "Inner Exception in SyncPortalUsersData. >>> " + ex.ToString());
                        LogError.Write(LogError.AppType.Candidate, ex.Message + " SyncPortalUsersData " + ex.StackTrace, ex, "");
                    }
                    try
                    {
                        objEmail.SyncReferralPortalIDByEmailAddress();
                    }
                    catch (Exception ex)
                    {
                        Logging.WriteToLog(Logging.GenerateDefaultLogFileName("BRecruitmentDocumentUploadingService"), "Inner Exception in SyncReferralPortalIDByEmailAddress. >>> " + ex.ToString());
                        LogError.Write(LogError.AppType.Candidate, ex.Message + " SyncReferralPortalIDByEmailAddress " + ex.StackTrace, ex, "");
                    }
                    try
                    {
                        objEmail.SyncReferralPortalIDByExtension();
                    }
                    catch (Exception ex)
                    {
                        Logging.WriteToLog(Logging.GenerateDefaultLogFileName("BRecruitmentDocumentUploadingService"), "Inner Exception in SyncReferralPortalIDByExtension. >>> " + ex.ToString());
                        LogError.Write(LogError.AppType.Candidate, ex.Message + " SyncReferralPortalIDByExtension " + ex.StackTrace, ex, "");
                    }
                    try
                    {
                        objEmail.SyncCandidatesForResignation();
                    }
                    catch (Exception ex)
                    {
                        Logging.WriteToLog(Logging.GenerateDefaultLogFileName("BRecruitmentDocumentUploadingService"), "Inner Exception in SyncCandidatesForResignation. >>> " + ex.ToString());
                        LogError.Write(LogError.AppType.Candidate, ex.Message + " SyncCandidatesForResignation " + ex.StackTrace, ex, "");
                    }
                    //        //objEmail.UpdateJobDescriptionFromPeroformanceSystem();
                 
                }
            }
            #endregion
        }
        #endregion
    }
}
