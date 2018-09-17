using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Web;
using System.Net;
using Chilkat;
using System.Text.RegularExpressions;
using ErrorLog;
using System.Net.Mail;


namespace BOLRecruitmentDocumentUploadingLibrary
{
    public class UploadingFunction
    {
        static Ftp2 ftpClient;
        public static string FTPUserID = ConfigurationManager.AppSettings["FTPUserID"].ToString();
        public static string FTPPassword = ConfigurationManager.AppSettings["FTPPassword"].ToString();
        public static string FTPUploadAddress = ConfigurationManager.AppSettings["FTPUploadAddress"].ToString();
        public static int candidateCode = 0;
        public static int officialLetterCode = 0;
        public int CandDoc_Code = 0;
        public int documentStatus = 0;
        string documentPath = string.Empty;
        bool conn = false;


        CrystalDecisions.CrystalReports.Engine.ReportDocument objReport = null;
        string userid = Convert.ToString(ConfigurationManager.AppSettings["rUserID"]);
        string password = Convert.ToString(ConfigurationManager.AppSettings["rPassword"]);


        public void SendDocument()
        {
            //System.Diagnostics.Debugger.Launch();
            string documentStatusName = string.Empty;
            try
            {
                string path = string.Empty;
                DataTable dt = new DataTable();
                dt = (DataTable)UploadingData.GetDocumentData();
                if (dt.Rows.Count > 0)
                {
                    if (ConnectFTP(FTPUploadAddress, FTPUserID, FTPPassword))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            candidateCode = int.Parse(dr["Candidate_Code"].ToString());
                            CandDoc_Code = int.Parse(dr["CandDoc_Code"].ToString());
                            officialLetterCode = int.Parse(dr["OfficialLetter_Code"].ToString());
                            documentPath = dr["DocumentPath"].ToString();
                            path = ConfigurationManager.AppSettings["LocalWebServer"].ToString();
                            path = path + dr["DocumentPath"].ToString();
                            path = path.Replace("/", "\\");

                            path = path.Replace("RecruitmentDocuments", "BOLCandidateDocuments$");

                            conn = UploadDocument(FTPUploadAddress, FTPUserID, FTPPassword, path, Path.GetDirectoryName(dr["DocumentPath"].ToString()), Path.GetFileName(path));
                            if (conn)
                                documentStatus = 1;//Success
                            else
                                documentStatus = 2;//Failure
                            UploadingData.UpdateDocumentUpladingStatus(CandDoc_Code, documentStatus);
                        }
                        ftpClient.Disconnect();
                    }

                }
            }
            catch (Exception e)
            {
                Logging.WriteToLog(Logging.GenerateDefaultLogFileName("XRecruitmentDocumentUploadingService"), documentStatusName + " >>> " + e.Message);
                ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, "XDocumentUploadingService :: " + e.Message, e, "0");
            }
        }

        public static bool UploadDocument(string ftpUploadAddress, string ftpUploadId, string ftpUploadPassword, string localZipPath, string uploadedZipDirectory, string uploadedZipName)
        {
            //This method uploads a file from localZipPath to ftpUploadAddress using FTP credentials provided.
            //The uploaded file is uploaded to the uploadedZipDirectory with name uploadedZipName.

            bool success;

            //Check that the ftpUploadAddress does not have a directory associated with it...
            if (ftpUploadAddress.Contains("/"))
            {
                string[] directories1 = ftpUploadAddress.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                for (int i = 1; i < directories1.Length; i++)//start from 1 since the first element will have the IP address
                {
                    ftpClient.ChangeRemoteDir(directories1[i]);
                }
            }
            string[] directories = ftpClient.GetTextDirListing("*.*").Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            bool makeDirectory = true;
            for (int i = 0; i < directories.Length; i++)
            {

                if (ftpClient.GetIsDirectory(i))
                {
                    string temp;
                    temp = directories[i].Substring(directories[i].IndexOf("<dir>", StringComparison.OrdinalIgnoreCase) + "<dir>".Length);
                    temp = temp.TrimStart(" ".ToCharArray());
                    if (temp.Equals(uploadedZipDirectory))
                    {
                        makeDirectory = false;
                        break;
                    }
                }
            }
            if (makeDirectory)
                ftpClient.CreateRemoteDir(uploadedZipDirectory.Replace("RecruitmentDocuments", "bolrecruitmentdocuments"));
            ftpClient.ChangeRemoteDir(uploadedZipDirectory.Replace("RecruitmentDocuments", "bolrecruitmentdocuments"));

            success = ftpClient.PutFile(localZipPath, uploadedZipName);
            if (success != true)
            {
                Logging.WriteToLog(Logging.GenerateDefaultLogFileName("XRecruitmentDocumentUploadingService"), "CandidateCode=" + candidateCode +
                    " OfficialLetteCode=" + officialLetterCode + "  FilePath = " + localZipPath + " >>> " + ftpClient.LastErrorText);
                Exception ex = new Exception(ftpClient.LastErrorText);
                //ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, "XDocumentUploadingService :: CandidateCode=" + candidateCode +
                //    " OfficialLetteCode=" + officialLetterCode + "  FilePath = " + localZipPath + " >>> " + ftpClient.LastErrorText, ex, "0");

            }

            return success;
        }

        public static bool ConnectFTP(string ftpUploadAddress, string ftpUploadId, string ftpUploadPassword)
        {
            //This method uploads a file from localZipPath to ftpUploadAddress using FTP credentials provided.
            //The uploaded file is uploaded to the uploadedZipDirectory with name uploadedZipName.

            ftpClient = new Ftp2();

            bool success;
            bool successConnection;


            // Any string unlocks the component for the 1st 30-days.
            //success = ftp.UnlockComponent("Anything for 30-day trial");
            success = ftpClient.UnlockComponent("FTP!TEAM!BEAN_0C8DDF599RDZ");
            if (success != true)
            {
                throw new Exception("Chilkat component could not be unlocked. Cannot upload file using Chilkat");
            }
            //Check that the ftpUploadAddress does not have a directory associated with it...
            if (ftpUploadAddress.Contains("/"))
                ftpClient.Hostname = ftpUploadAddress.Substring(0, ftpUploadAddress.IndexOf("/"));
            else
                ftpClient.Hostname = ftpUploadAddress;
            string ftpUserName = ftpUploadId;
            string ftpPassword = ftpUploadPassword;
            ftpClient.Username = ftpUserName;
            ftpClient.Password = ftpPassword;
            ftpClient.Passive = false;
            ftpClient.Connect();
            ftpClient.SetTypeBinary();
            if (!ftpClient.IsConnected)
            {
                //throw new Exception("Could not connect to " + ftpUploadAddress);
                successConnection = false;
                Logging.WriteToLog(Logging.GenerateDefaultLogFileName("XRecruitmentDocumentUploadingService"), " >>> " + ftpClient.LastErrorText);

                ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, "XDocumentUploadingService :: " + ftpClient.LastErrorText, null, null);

            }
            else
            {
                successConnection = true;
            }
            return successConnection;
        }
        public void GetDataforPDFGeneration()
        {
            int Is_SupportStaff = 0;
            int domainCode = 0;
            int CategoryType = 0;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentLiveConn"].ConnectionString);
            try
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand("Select_CandidateOfficialDocumentForPDFGeneration", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        try
                        {
                            candidateCode = int.Parse(ds.Tables[0].Rows[i]["Candidate_Code"].ToString());
                            CandDoc_Code = int.Parse(ds.Tables[0].Rows[i]["CandDoc_Code"].ToString());
                            officialLetterCode = int.Parse(ds.Tables[0].Rows[i]["OfficialLetter_Code"].ToString());
                            int refNo = int.Parse(ds.Tables[0].Rows[i]["RefNo"].ToString());
                            Is_SupportStaff = int.Parse(ds.Tables[0].Rows[i]["Is_SupportStaff"].ToString());
                            domainCode = int.Parse(ds.Tables[0].Rows[i]["Domain_Code"].ToString());
                            CategoryType= int.Parse(ds.Tables[0].Rows[i]["CategoryType"].ToString());
                            CreatePdf(refNo.ToString(), officialLetterCode, candidateCode, Is_SupportStaff, domainCode, CategoryType);
                        }
                        catch (Exception ex)
                        {
                            //ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, "");
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                //throw exp1;
                ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, "XDocumentUploadingService :: " + ex.StackTrace, ex, null);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        protected void
            CreatePdf(string refNo, int reportCode, int candidateCode, int Is_SupportStaff, int domainCode, int CategoryType)
        {
            CrystalDecisions.Shared.ExportOptions ExpOptions;
            CrystalDecisions.Shared.DiskFileDestinationOptions FileDesOption;
            CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
            CrystalDecisions.Shared.ParameterDiscreteValue paraValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
            objReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

            int DeptCode = Convert.ToInt32(ConfigurationManager.AppSettings["DeptCode"].ToString());

            string path = string.Empty;
            switch (reportCode)
            {
                case (int)ReportCode.CandidateOfferLetter:
                    if (Is_SupportStaff == 0 && domainCode != DeptCode && CategoryType != 6)
                    {
                        path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\BOLNETWORK\\BOLCandidateOfferLetter.rpt";
                    }
                    else if (Is_SupportStaff == 0 && domainCode != DeptCode && CategoryType == 6)
                    { path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\Consultant\\BOLCandidateOfferLetter.rpt"; }
                    else if (Is_SupportStaff == 0 && domainCode == DeptCode)
                    {
                        path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\PakNewsLetter\\PAKCandidateOfferLetter.rpt";
                    }
                    else
                        path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\BOLNETWORK\\SupportStaffOfferLetter.rpt";
                    break;

                case (int)ReportCode.Appointment_FirstPage:
                    if (domainCode == DeptCode)
                        path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\PakNewsLetter\\PAKAppointment_FirstPage.rpt";
                    else
                        path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\BOLNETWORK\\BOLAppointment_FirstPage.rpt";
                    break;

                case (int)ReportCode.CandidateAppointmentLetter:
                    if (Is_SupportStaff == 0 && domainCode != DeptCode)
                    {
                        path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\BOLNETWORK\\BOLCandidateAppointmentLetter.rpt";
                    }
                    else if (Is_SupportStaff == 0 && domainCode == DeptCode)
                    {
                        path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\PakNewsLetter\\PAKCandidateAppointmentLetter.rpt";
                    }
                    else
                        path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\BOLNETWORK\\SupportStaffAppointmentLetter.rpt";
                    break;

                case (int)ReportCode.FirstPage_OfferLetter:
                    if (domainCode == DeptCode)
                        path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\PakNewsLetter\\PAKFirstPage_OfferLetter.rpt";
                    else if (CategoryType != 6)
                        path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\BOLNETWORK\\BOLFirstPage_OfferLetter.rpt";
                    else if (CategoryType == 6)
                        path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\Consultant\\BOLFirstPage_OfferLetter.rpt";
                    break;
                case (int)ReportCode.FirstLastPageOfferLetter:
                    if (domainCode == DeptCode)
                        path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\PakNewsLetter\\PAKFirstLastPage_OfferLetter.rpt";
                    else if (CategoryType != 6)
                        path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\BOLNETWORK\\BOLFirstLastPage_OfferLetter.rpt";
                    else if (CategoryType == 6)
                        path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\Consultant\\BOLFirstLastPage_OfferLetter.rpt";
                    break;
                case (int)ReportCode.FirstLastPageAppointmentLetter:
                    path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\BOLNETWORK\\BOLFirstLastPage_AppointmentLetter.rpt";
                    break;

                case (int)ReportCode.Envalope:
                    path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\BOLNETWORK\\PrintEnvelopA4.rpt";
                    break;
                case (int)ReportCode.RemunerationSheet:
                    path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\RemunerationSheet.rpt";
                    break;
                case (int)ReportCode.MedicalLetter:
                    if (Is_SupportStaff == 0)
                    {
                        path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\BOLNETWORK\\MedicalLetter_org.rpt";
                    }
                    else
                    {
                        path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\BOLNETWORK\\SupportStaffMedicalLetter_org.rpt";
                    }
                    break;
                case (int)ReportCode.AddressVerificationLetter:
                    path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\BOLNETWORK\\AddressVerificationLetter.rpt";
                    break;
                case (int)ReportCode.DiscreoantUserAppointmentLetter:
                    path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\BOLNETWORK\\BOLCandidateDiscrepantAppointmentLetter.rpt";
                    break;

            }


            objReport.Load(path);


            string strTemp = "";
            string DirPath;
            string strExportFile;
            objReport.SetDatabaseLogon(userid, password);

            objReport.SetParameterValue(0, refNo);
            //DirPath = Server.MapPath("cr");

            switch (reportCode)
            {
                case (int)ReportCode.CandidateOfferLetter:
                    strTemp = "CandidateOfferLetter.pdf";
                    officialLetterCode = 1;
                    break;
                case (int)ReportCode.Appointment_FirstPage:
                    strTemp = "Appointment_FirstPage.pdf";
                    officialLetterCode = 7;
                    break;
                case (int)ReportCode.Envalope:
                    strTemp = "Envalope.pdf";
                    officialLetterCode = 8;
                    break;
                case (int)ReportCode.CandidateAppointmentLetter:
                    strTemp = "CandidateAppointmentLetter.pdf";
                    officialLetterCode = 2;
                    break;
                case (int)ReportCode.FirstPage_OfferLetter:
                    strTemp = "FirstPage_OfferLetter.pdf";
                    officialLetterCode = 6;
                    break;
                case (int)ReportCode.MedicalLetter:
                    strTemp = "MedicalLetter_org.doc";
                    officialLetterCode = 3;
                    break;
                case (int)ReportCode.RemunerationSheet:
                    strTemp = "RemunerationSheet.pdf";
                    officialLetterCode = 5;
                    break;

                case (int)ReportCode.FirstLastPageOfferLetter:
                    strTemp = "FirstLastPage_OfferLetter.pdf";
                    officialLetterCode = 10;
                    break;
                case (int)ReportCode.FirstLastPageAppointmentLetter:
                    strTemp = "FirstLastPage_AppointmentLetter.pdf";
                    officialLetterCode = 11;
                    break;
                case (int)ReportCode.AddressVerificationLetter:
                    strTemp = "AddressVerificationLetter.pdf";
                    officialLetterCode = 13;
                    break;
                case (int)ReportCode.DiscreoantUserAppointmentLetter:
                    strTemp = "DiscrepantUserAppointmentLetter.pdf";
                    officialLetterCode = 14;
                    break;

            }
            strExportFile = ConfigurationManager.AppSettings["PathforPDF"].ToString();
            CreateFolder(strExportFile += refNo);
            strExportFile += "\\" + strTemp;


            SaveCandidateDocument(ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + "official/" + refNo + "/" + strTemp, Path.GetFileNameWithoutExtension(strTemp), officialLetterCode, candidateCode);

            FileDesOption = new CrystalDecisions.Shared.DiskFileDestinationOptions();
            FileDesOption.DiskFileName = strExportFile;
            ExpOptions = (CrystalDecisions.Shared.ExportOptions)objReport.ExportOptions;
            ExpOptions.DestinationOptions = FileDesOption;
            ExpOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
            if (reportCode == (int)ReportCode.MedicalLetter)
                ExpOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.WordForWindows;
            else
                ExpOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            objReport.Export(ExpOptions);
            objReport.Close();
            objReport.Dispose();

            #region Medical Letter Generation in Case of OfferLetter
            if (reportCode == (int)ReportCode.CandidateOfferLetter)
            {
                objReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                if (Is_SupportStaff == 0)
                {
                    path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\BOLNETWORK\\MedicalLetter_org.rpt";
                }
                else
                {
                    path = ConfigurationManager.AppSettings["PathforRPT"].ToString() + "\\CR\\BOLNETWORK\\SupportStaffMedicalLetter_org.rpt";
                }
                objReport.Load(path);

                objReport.SetDatabaseLogon(userid, password);

                objReport.SetParameterValue(0, refNo);

                strTemp = "MedicalLetter_org.doc";
                officialLetterCode = 3;
                strExportFile = ConfigurationManager.AppSettings["PathforPDF"].ToString();
                CreateFolder(strExportFile += refNo);
                strExportFile += "\\" + strTemp;


                SaveCandidateDocument(ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + "official/" + refNo + "/" + strTemp, Path.GetFileNameWithoutExtension(strTemp), officialLetterCode, candidateCode);

                FileDesOption = new CrystalDecisions.Shared.DiskFileDestinationOptions();
                FileDesOption.DiskFileName = strExportFile;
                ExpOptions = (CrystalDecisions.Shared.ExportOptions)objReport.ExportOptions;
                ExpOptions.DestinationOptions = FileDesOption;
                ExpOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
                ExpOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.WordForWindows;
                objReport.Export(ExpOptions);
                objReport.Close();
                objReport.Dispose();

            }
            #endregion


        }
        private void SaveCandidateDocument(string documentPath, string documentName, int OfficialLetter_Code, int candidateCode)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentLiveConn"].ConnectionString);
            try
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand("Update_CandidateOfficialDocumentPDFPath", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Candidate_Code", candidateCode);
                sqlCommand.Parameters.AddWithValue("@DocumentPath", documentPath);
                sqlCommand.Parameters.AddWithValue("@OfficialLetter_Code", OfficialLetter_Code);
                sqlCommand.Parameters.AddWithValue("@UpdationIP", "Uploading service");
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //throw exp1;
                ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, null);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }
        public static void CreateFolder(string FolderPath)
        {
            string folderPath = string.Empty;

            //if (IsValidPath(FolderPath))
            folderPath = FolderPath;
            //else
            //    folderPath = System.Web.HttpContext.Current.Server.MapPath(FolderPath);
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            if (!dir.Exists)
                Directory.CreateDirectory(folderPath);
        }
        public static bool IsValidPath(string path)
        {
            Regex r = new Regex(@"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.]+)\\(?:[\w]+\\)*");
            return r.IsMatch(path);
        }
        enum ReportCode
        {
            CandidateOfferLetter = 1,
            CandidateAppointmentLetter = 2,
            MedicalLetter = 3,
            Appointment_FirstPage = 7,
            Envalope = 8,
            FirstPage_OfferLetter = 6,
            RemunerationSheet = 5,
            FirstLastPageOfferLetter = 10,
            FirstLastPageAppointmentLetter = 11,
            AddressVerificationLetter = 13,
            DiscreoantUserAppointmentLetter = 14,
        }

        public void SyncPortalUsersData(DateTime today)
        {
            DataTable dtPortal = GetPortalData();
            if (dtPortal.Rows.Count > 0)
            {
                for (int i = 0; i <= dtPortal.Rows.Count - 1; i++)
                {
                    Sync(int.Parse(dtPortal.Rows[i]["userID"].ToString()),
                        dtPortal.Rows[i]["fullName"].ToString(),
                        dtPortal.Rows[i]["deptName"].ToString(),
                        dtPortal.Rows[i]["Designation"].ToString(),
                        int.Parse(dtPortal.Rows[i]["cand_cat_code"].ToString()),
                        Convert.ToBoolean(dtPortal.Rows[i]["is_active"].ToString()),
                        dtPortal.Rows[i]["Is_ReportingAuthority"].ToString() == "0" ? false : true,
                        dtPortal.Rows[i]["EMAIL"].ToString(),
                        int.Parse(dtPortal.Rows[i]["DEPARTMENT_CODE"].ToString()),
                        dtPortal.Rows[i]["Is_PanelMember"].ToString() == "0" ? false : true,
                        dtPortal.Rows[i]["Gender"].ToString(),
                        dtPortal.Rows[i]["ph_extension"].ToString(),
                        dtPortal.Rows[i]["Is_GroupLeader"].ToString() == "0" ? false : true,
                        dtPortal.Rows[i]["Is_TeamLeader"].ToString() == "0" ? false : true,
                        int.Parse(dtPortal.Rows[i]["GL_ID"].ToString())

                        );
                }
                InsertSyncDate(today);
            }
        }

        protected void InsertSyncDate(DateTime todayDate)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentLiveConn"].ConnectionString);
            try
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand("XRec_Insert_CheckForPortalSyncForDate", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@todayDate", todayDate);

                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //throw exp1;
                ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, null);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }


        protected DataTable GetPortalData()
        {
            DataTable dt = new DataTable();
            string conStr = ConfigurationManager.ConnectionStrings["PortalConnection"].ToString();
            SqlDataAdapter adapter = new SqlDataAdapter("XRec_GetPortalUsers", new SqlConnection(conStr));
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(dt);
            return dt;
        }
        protected void Sync(int userID, string fullName, string deptName, string Designation, int cand_cat_code,
            bool is_active, bool Is_ReportingAuthority, string EMAIL, int DEPARTMENT_CODE, bool Is_PanelMember,
            string Gender, string ph_extension, bool Is_GroupLeader, bool Is_TeamLeader, int GL_ID)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["RecruitmentLiveConn"].ToString());
            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Sync_PortalUsers", connection);
                sqlCommand.Parameters.AddWithValue("@userID", userID);
                sqlCommand.Parameters.AddWithValue("@fullName", fullName);
                sqlCommand.Parameters.AddWithValue("@deptName", deptName);
                sqlCommand.Parameters.AddWithValue("@Designation", Designation);
                sqlCommand.Parameters.AddWithValue("@cand_cat_code", cand_cat_code);
                sqlCommand.Parameters.AddWithValue("@is_active", is_active);
                sqlCommand.Parameters.AddWithValue("@Is_ReportingAuthority", Is_ReportingAuthority);
                sqlCommand.Parameters.AddWithValue("@EMAIL", EMAIL);
                sqlCommand.Parameters.AddWithValue("@DEPARTMENT_CODE", DEPARTMENT_CODE);
                sqlCommand.Parameters.AddWithValue("@Is_PanelMember", Is_PanelMember);
                sqlCommand.Parameters.AddWithValue("@Gender", Gender);
                sqlCommand.Parameters.AddWithValue("@ph_extension", ph_extension);

                sqlCommand.Parameters.AddWithValue("@Is_GroupLeader", Is_GroupLeader);
                sqlCommand.Parameters.AddWithValue("@Is_TeamLeader", Is_TeamLeader);
                sqlCommand.Parameters.AddWithValue("@GL_ID", GL_ID);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, "XRecDocumentUploadingService");
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }




        }


        public bool CheckForTodaySyncPortalSchedul(DateTime today)
        {
            bool check = false;
            DataTable dtPortal = CheckTodayScheduled(today);
            if (dtPortal.Rows.Count > 0)
            {
                check = true;
            }
            return check;
        }
        protected DataTable CheckTodayScheduled(DateTime todayDate)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["RecruitmentLiveConn"].ToString());
            SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Select_CheckForPortalSyncForDate", connection);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@todayDate", todayDate);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            return dt;

        }
        public DataTable GetAllReferral()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["RecruitmentLiveConn"].ToString());
            SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Select_CandidateReferral", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            return dt;

        }
        public DataTable GetAllReferralByExt()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["RecruitmentLiveConn"].ToString());
            SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Select_CandidateReferralByExt", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            return dt;

        }
        public DataTable GetAllCandidatesForResignationSync()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["RecruitmentLiveConn"].ToString());
            SqlCommand sqlCommand = new SqlCommand("dbo.XREC_Select_CandidatesForResignationSync", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            return dt;

        }

        public void SyncReferralPortalIDByEmailAddress()
        {
            DataTable dt = GetAllReferral();
            DataTable dtPortID = new DataTable();
            string email = string.Empty;

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    email = dt.Rows[i]["Email_Address"].ToString();
                    dtPortID = GetReferralPortalID(email);
                    if (dtPortID.Rows.Count > 0)
                    {
                        UpdateReferralPortalID(email, dtPortID.Rows[0]["Userid"].ToString());
                    }
                }

            }

        }

        public void SyncReferralPortalIDByExtension()
        {
            DataTable dt = GetAllReferralByExt();
            DataTable dtPortID = new DataTable();
            string email = string.Empty;
            string referralExt = string.Empty;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    email = dt.Rows[i]["Email_Address"].ToString();
                    referralExt = dt.Rows[i]["referral"].ToString();
                    dtPortID = CheckExtensionInUsers(referralExt);
                    if (dtPortID.Rows.Count > 0)
                    {
                        UpdateReferralPortalID(email, dtPortID.Rows[0]["UserID"].ToString());
                    }
                }

            }

        }

        private void UpdateReferralPortalID(string email, string portalID)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentLiveConn"].ConnectionString);
            try
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand("XRec_Update_CandidateReferralPortalID", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@portalID", portalID);
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //throw exp1;
                ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, null);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }
        protected DataTable GetReferralPortalID(string email)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PortalConnection"].ToString());
            SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Select_ReferralPortalID", connection);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Email_Address", email);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            return dt;

        }

        protected DataTable CheckExtensionInUsers(string ext)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentLiveConn"].ToString());
            SqlCommand sqlCommand = new SqlCommand("dbo.XREC_Select_PortalUserIDByExtension", connection);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Ext", ext);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            return dt;

        }

        public void GetDataforPortalPic()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentLiveConn"].ConnectionString);
            try
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand("XREC_Select_PortalPicture", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                string InitialPicPath = string.Empty;
                int refNo = 0;
                int PortalToCreate_Code = 0;
                bool isStaff = false;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        candidateCode = int.Parse(ds.Tables[0].Rows[i]["Candidate_Code"].ToString());
                        PortalToCreate_Code = int.Parse(ds.Tables[0].Rows[i]["PortalToCreate_Code"].ToString());
                        isStaff = Convert.ToBoolean(ds.Tables[0].Rows[i]["Is_Staff"]);
                        InitialPicPath = ConfigurationManager.AppSettings["DomainAddress"].ToString() + ds.Tables[0].Rows[i]["INITIALPICPATH"].ToString();
                        refNo = int.Parse(ds.Tables[0].Rows[i]["RefNo"].ToString());

                        CopyFileToPortalLocation(InitialPicPath, refNo, PortalToCreate_Code, isStaff);

                    }
                }

            }
            catch (Exception ex)
            {
                //throw exp1;
                ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, "XDocumentUploadingService :: " + ex.StackTrace, ex, null);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }
        protected void UpdateIsPortalPicMoved(int PortalToCreate_Code)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentLiveConn"].ConnectionString);
            try
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand("XREC_Update_SyncPortalPic", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@PortalToCreate_Code", PortalToCreate_Code);
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //throw exp1;
                ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, null);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        protected void CopyFileToPortalLocation(string fileToDownload, int referenceCode, int PortalToCreate_Code, bool isStaff)
        {
            using (WebClient Client = new WebClient())
            {
                try
                {

                    if (isStaff)
                    {
                        if (!File.Exists(ConfigurationManager.AppSettings["PathforPortalPicStaff"].ToString()
                    + referenceCode + Path.GetExtension(fileToDownload)))
                        {
                            Client.DownloadFile(fileToDownload, ConfigurationManager.AppSettings["PathforPortalPicStaff"].ToString() + referenceCode + Path.GetExtension(fileToDownload));
                            UpdateIsPortalPicMoved(PortalToCreate_Code);
                        }
                    }
                    else
                    {
                        if (!File.Exists(ConfigurationManager.AppSettings["PathforPortalPic"].ToString()
                    + referenceCode + Path.GetExtension(fileToDownload)))
                        {
                            Client.DownloadFile(fileToDownload, ConfigurationManager.AppSettings["PathforPortalPic"].ToString() + referenceCode + Path.GetExtension(fileToDownload));
                            //Client.DownloadFile(fileToDownload,  @"d:\" + referenceCode + Path.GetExtension(fileToDownload));
                            //File.Copy(@"d:\" + referenceCode + Path.GetExtension(fileToDownload), ConfigurationManager.AppSettings["PathforPortalPic"].ToString() + referenceCode + Path.GetExtension(fileToDownload));
                            UpdateIsPortalPicMoved(PortalToCreate_Code);
                        }
                    }
                    //UpdateIsPortalPicMoved(PortalToCreate_Code);


                }
                catch (Exception ex)
                {
                    //throw exp1;
                    ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, "XDocumentUploadingService :: " + ex.StackTrace, ex, null);
                }
            }
        }



        public void SyncCandidatesForResignation()
        {

            DataTable dt = GetAllCandidatesForResignationSync();
            DataTable dtPortID = new DataTable();
            string PortalUserID = string.Empty;
            string candidateCode = string.Empty;
            DateTime portalSeperationDate;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    PortalUserID = dt.Rows[i]["PortalUserID"].ToString();
                    candidateCode = dt.Rows[i]["Candidate_Code"].ToString();
                    dtPortID = CheckPortalUserStatusForResignation(PortalUserID);
                    if (dtPortID.Rows.Count > 0)
                    {
                        portalSeperationDate = Convert.ToDateTime(dtPortID.Rows[0]["Seperation_Date"].ToString());
                        if (!Convert.ToBoolean(dtPortID.Rows[0]["Is_active"].ToString()) && dtPortID.Rows[0]["NewUserID"].ToString() == "0")
                            UpdateCandidateStatusForResignation(candidateCode, portalSeperationDate);
                    }
                }

            }

        }
        protected DataTable CheckPortalUserStatusForResignation(string portalUserID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PortalConnection"].ToString());
            SqlCommand sqlCommand = new SqlCommand("dbo.XREC_Select_PortalUserStatus", connection);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Userid", portalUserID);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            return dt;

        }
        private void UpdateCandidateStatusForResignation(string candidateCode, DateTime Seperation_Date)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentLiveConn"].ConnectionString);
            try
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand("XREC_Update_SyncCandidateStatusForResignation", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Candidate_Code", candidateCode);
                sqlCommand.Parameters.AddWithValue("@Updated_IP", "Sync Service");
                sqlCommand.Parameters.AddWithValue("@Seperation_Date", Seperation_Date);
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //throw exp1;
                ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, null);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }
        public void SyncDesignationsWithPortal()
        {

            DataTable dt = GetMaxDesignation();
            int maxDesignationID = 0;
            if (dt.Rows.Count > 0)
            {
                maxDesignationID = int.Parse(dt.Rows[0]["MaxDesignation"].ToString());
                DataTable dtDesignation = CheckPortalForNewlyAddedDesignation(maxDesignationID);
                int departmentid = 0;
                int DesignationID = 0;
                string title = string.Empty;
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentLiveConn"].ConnectionString);
                try
                {
                    connection.Open();
                    for (int i = 0; i <= dtDesignation.Rows.Count - 1; i++)
                    {
                        departmentid = int.Parse(dtDesignation.Rows[i]["departmentid"].ToString());
                        DesignationID = int.Parse(dtDesignation.Rows[i]["DesignationID"].ToString());
                        title = dtDesignation.Rows[i]["title"].ToString();

                        InsertNewDesigantion(departmentid, DesignationID, title, connection);
                    }
                }
                catch (Exception ex)
                {
                    //throw exp1;
                    ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, null);
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }

            }

        }

        public void SyncDepartmentWithPortal()
        {

            DataTable dt = GetMaxDepartment();
            int maxDepartmentID = 0;
            if (dt.Rows.Count > 0)
            {
                maxDepartmentID = int.Parse(dt.Rows[0]["MaxDepartmentCode"].ToString());
                DataTable dtDepartment = CheckPortalForNewlyAddedDepartment(maxDepartmentID);
                int departmentid = 0;
                string DepartmentName = string.Empty;
                int? DomainOwnerCode = 0;
                int? IsSupport = 0;
                int? HasShift = 0;
                if (dtDepartment.Rows.Count > 0)
                {
                    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentLiveConn"].ConnectionString);
                    try
                    {
                        connection.Open();
                        for (int i = 0; i <= dtDepartment.Rows.Count - 1; i++)
                        {
                            if (!string.IsNullOrEmpty(dtDepartment.Rows[i]["deptID"].ToString()))
                            {
                                departmentid = int.Parse(dtDepartment.Rows[i]["deptID"].ToString());
                            }
                            if (!string.IsNullOrEmpty(dtDepartment.Rows[i]["deptName"].ToString()))
                            {
                                DepartmentName = dtDepartment.Rows[i]["deptName"].ToString();
                            }
                            if (!string.IsNullOrEmpty(dtDepartment.Rows[i]["deptHeadID"].ToString()))
                            {
                                DomainOwnerCode = Convert.ToInt32(dtDepartment.Rows[i]["deptHeadID"].ToString());
                            }
                            if (!string.IsNullOrEmpty(dtDepartment.Rows[i]["isSupportDept"].ToString()))
                            {
                                IsSupport = Convert.ToInt32(dtDepartment.Rows[i]["isSupportDept"].ToString());
                            }
                            if (!string.IsNullOrEmpty(dtDepartment.Rows[i]["has_shift"].ToString()))
                            {
                                HasShift = Convert.ToInt32(dtDepartment.Rows[i]["has_shift"].ToString());
                            }

                            InsertNewDepartment(departmentid, DepartmentName, DomainOwnerCode, IsSupport, HasShift, connection);
                        }
                    }
                    catch (Exception ex)
                    {
                        //throw exp1;
                        ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, null);
                    }
                    finally
                    {
                        if (connection.State != ConnectionState.Closed)
                        {
                            connection.Close();
                        }
                    }
                }
            }

        }
        public void SendEmailForTentativeJoining()
        {
            DataTable dt = GetTentativeJoiningEmailData();
            if (dt.Rows.Count > 0)
            {
                DataView view = new DataView(dt);
                DataTable distinctValues = view.ToTable(true, "Domain");

                SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["RecruitmentLiveConn"].ToString());
                DataSet dataSet = new DataSet();
                string sql = "XREC_Select_EmailReceiversForTentativeJoining";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dataSet);

                string toEmail = dataSet.Tables[0].Rows[0]["toEmail"].ToString();
                string SenderEmail = dataSet.Tables[0].Rows[0]["SenderEmail"].ToString();
                string bcc = dataSet.Tables[0].Rows[0]["bcc"].ToString();
                string cc = dataSet.Tables[0].Rows[0]["cc"].ToString();
                string SenderName = dataSet.Tables[0].Rows[0]["SenderName"].ToString();

                //string toEmail = "alirizvi@axact.com,atifhussain@axact.com";
                //string SenderEmail = "alirizvi@axact.com";
                //string bcc = "alirizvi@axact.com";
                //string cc = "alirizvi@axact.com";
                //string SenderName = "Recruitment";

                DateTime Date = Convert.ToDateTime(dt.Rows[0]["postedFromDate"].ToString());
                EmailFunctions objEmailFunctions = new EmailFunctions();
                objEmailFunctions.SendOrderCodesThroughEmail(connection, dt, SenderName, toEmail, SenderEmail, Date, cc, bcc, distinctValues);
                string TentativeJoiningEmailData_Code = string.Empty;

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    TentativeJoiningEmailData_Code = TentativeJoiningEmailData_Code + "," + dt.Rows[i]["TentativeJoiningEmailData_Code"].ToString();
                }
                TentativeJoiningEmailData_Code = TentativeJoiningEmailData_Code.TrimStart(',');
                UpdateTentativeJoiningEmailDataStatus(TentativeJoiningEmailData_Code, connection);
            }
        }
        public void SyncJobRoleAndBenefitsForSupportStaffWithPortal()
        {

            DataTable dt = GetMaxJobRole();
            int jobrole_code = 0;
            if (dt.Rows.Count > 0)
            {
                jobrole_code = int.Parse(dt.Rows[0]["jobrole_code"].ToString());
                DataTable dtJobRole = CheckPortalForNewlyAddedJobRoleAndBenefits(jobrole_code);
                DataTable dtJobRoleBenefits = new DataTable();
                int newjobrole_code = 0;
                int deductionTypeID = 0;
                int Count = 0;
                int DeliveryTime = 0;
                decimal Amount = 0;
                decimal Benefit_Value = 0;
                string BenefitDescription = string.Empty;

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentLiveConn"].ConnectionString);
                try
                {
                    connection.Open();
                    for (int i = 0; i <= dtJobRole.Rows.Count - 1; i++)
                    {
                        newjobrole_code = int.Parse(dtJobRole.Rows[i]["jobrole_code"].ToString());
                        dtJobRoleBenefits = GetNewlyAddedJobRoleAndBenefits(newjobrole_code);
                        if (dtJobRoleBenefits.Rows.Count > 0)
                        {
                            for (int inner = 0; inner <= dtJobRoleBenefits.Rows.Count - 1; inner++)
                            {
                                deductionTypeID = int.Parse(dtJobRoleBenefits.Rows[inner]["deductionTypeID"].ToString());
                                Count = int.Parse(dtJobRoleBenefits.Rows[inner]["COUNT"].ToString());
                                DeliveryTime = int.Parse(dtJobRoleBenefits.Rows[inner]["DeliveryTime"].ToString());
                                Amount = Convert.ToDecimal(dtJobRoleBenefits.Rows[inner]["Amount"].ToString());
                                Benefit_Value = Convert.ToDecimal(dtJobRoleBenefits.Rows[inner]["Benefit_Value"].ToString());
                                BenefitDescription = dtJobRoleBenefits.Rows[inner]["BenefitDescription"].ToString();

                                InsertNewJobRoleBenefits(newjobrole_code, deductionTypeID, Count, DeliveryTime, Amount, Benefit_Value, BenefitDescription, connection);
                            }
                        }


                    }
                }
                catch (Exception ex)
                {
                    //throw exp1;
                    ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, null);
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }

            }

        }
        public DataTable GetMaxDesignation()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["RecruitmentLiveConn"].ToString());
            SqlCommand sqlCommand = new SqlCommand("dbo.XREC_GetMaxJobPosID", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            return dt;

        }

        public DataTable GetMaxDepartment()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["RecruitmentLiveConn"].ToString());
            SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Select_MaxDepartment", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            return dt;

        }
        public DataTable GetMaxJobRole()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["RecruitmentLiveConn"].ToString());
            SqlCommand sqlCommand = new SqlCommand("dbo.XREC_Select_MaxJobRole", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            return dt;

        }

        protected DataTable CheckPortalForNewlyAddedDesignation(int jobPosID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PortalConnection"].ToString());
            SqlCommand sqlCommand = new SqlCommand("dbo.XREC_SelectNewDesignation", connection);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@jobPosID", jobPosID);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            return dt;

        }

        protected DataTable CheckPortalForNewlyAddedDepartment(int DepartmentID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PortalConnection"].ToString());
            SqlCommand sqlCommand = new SqlCommand("dbo.XREC_SelectNewDepartment", connection);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@DepartmentCode", DepartmentID);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            return dt;

        }
        protected DataTable CheckPortalForNewlyAddedJobRoleAndBenefits(int jobrole_code)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PortalConnection"].ToString());
            SqlCommand sqlCommand = new SqlCommand("dbo.XREC_Select_NewlyAddedJobRole", connection);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@jobrole_code", jobrole_code);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            return dt;

        }
        protected DataTable GetNewlyAddedJobRoleAndBenefits(int jobrole_code)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PortalConnection"].ToString());
            SqlCommand sqlCommand = new SqlCommand("dbo.XREC_Select_NewlyAddedJobRoleBenefits", connection);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@jobrole_code", jobrole_code);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            return dt;

        }
        private void InsertNewDesigantion(int departmentid, int DesignationID, string title, SqlConnection sqlconn)
        {
            SqlCommand sqlCommand = new SqlCommand("XREC_InsertNewDesignation", sqlconn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@departmentid", departmentid);
            sqlCommand.Parameters.AddWithValue("@DesignationID", DesignationID);
            sqlCommand.Parameters.AddWithValue("@title", title);
            sqlCommand.ExecuteNonQuery();

        }

        private void InsertNewDepartment(int departmentid, string DepartmentName, int? DomainOwnerCode, int? IsSupport, int? HasShift, SqlConnection sqlconn)
        {
            SqlCommand sqlCommand = new SqlCommand("XREC_InsertNewDepartment", sqlconn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@DomainName", DepartmentName);
            sqlCommand.Parameters.AddWithValue("@DeptID", departmentid);
            sqlCommand.Parameters.AddWithValue("@DeptHeadID", DomainOwnerCode);
            sqlCommand.Parameters.AddWithValue("@IsShifts", HasShift);
            sqlCommand.Parameters.AddWithValue("@IsStaff", IsSupport);
            sqlCommand.ExecuteNonQuery();

        }
        private void InsertNewJobRoleBenefits(int jobRoleCode, int deductionTypeID, int count, int deliveryTime, decimal amount, decimal benefitValue, string benefitDescription, SqlConnection sqlconn)
        {
            SqlCommand sqlCommand = new SqlCommand("XREC_Insert_JobRoleBenefits", sqlconn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@newjobrole_code", jobRoleCode);
            sqlCommand.Parameters.AddWithValue("@deductionTypeID", deductionTypeID);
            sqlCommand.Parameters.AddWithValue("@Amount", amount);

            sqlCommand.Parameters.AddWithValue("@COUNT", count);
            sqlCommand.Parameters.AddWithValue("@BenefitDescription", benefitDescription);
            sqlCommand.Parameters.AddWithValue("@DeliveryTime", deliveryTime);
            sqlCommand.Parameters.AddWithValue("@Benefit_Value", benefitValue);
            sqlCommand.ExecuteNonQuery();

        }

        public void GetSyncDocument()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentLiveConn"].ConnectionString);
            DataTable dtDocument = new DataTable();
            try
            {
                SqlCommand sqlCommand = new SqlCommand("XREC_GetCandidateForDocumentDigitalization", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                string docName = string.Empty;
                string domainName = string.Empty;
                int portalUserID = 0;
                int docCode = 0;
                int candDoc_Code = 0;
                string folderToSearch = string.Empty;
                string PortalDocument_Head = string.Empty;
                int documentIDforPortal = 0;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        candidateCode = int.Parse(ds.Tables[0].Rows[i]["Candidate_Code"].ToString());
                        dtDocument = GetDocumentDetails(candidateCode);

                        for (int inner = 0; inner <= dtDocument.Rows.Count - 1; inner++)
                        {
                            try
                            {
                                string docPath = ConfigurationManager.AppSettings["DomainAddress"].ToString();
                                portalUserID = int.Parse(dtDocument.Rows[inner]["PortalUserID"].ToString());
                                docCode = int.Parse(dtDocument.Rows[inner]["Document_Code"].ToString());
                                domainName = dtDocument.Rows[inner]["Domain_Name"].ToString();
                                docName = dtDocument.Rows[inner]["DocumentName"].ToString();
                                docPath = docPath + dtDocument.Rows[inner]["DocumentPath"].ToString();
                                folderToSearch = dtDocument.Rows[inner]["Portaldocument_name"].ToString();
                                documentIDforPortal = int.Parse(dtDocument.Rows[inner]["Portaldocument_Code"].ToString());
                                PortalDocument_Head = dtDocument.Rows[inner]["PortalDocument_Head"].ToString();
                                candDoc_Code = int.Parse(dtDocument.Rows[inner]["CandDoc_Code"].ToString());

                                CopyCandidateDocumentToPortalLocation(PortalDocument_Head, docName, domainName, portalUserID, docCode, docPath, folderToSearch, documentIDforPortal, candDoc_Code);
                            }
                            catch (Exception ex)
                            {
                                //throw exp1;
                                ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, "XDocumentUploadingService :: " + ex.StackTrace, ex, null);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //throw exp1;
                ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, "XDocumentUploadingService :: " + ex.StackTrace, ex, null);
            }
        }

        private DataTable GetDocumentDetails(int candidateCode)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentLiveConn"].ConnectionString);
            DataTable dtDocument = new DataTable();
            try
            {
                SqlCommand sqlCommand = new SqlCommand("XREC_GetCandidateDocumentForDigitalization", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandidateCode", candidateCode);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(dtDocument);
            }
            catch (Exception ex)
            {
                //throw exp1;
                ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, "XDocumentUploadingService :: " + ex.StackTrace, ex, null);
            }
            return dtDocument;
        }


        protected void CopyCandidateDocumentToPortalLocation(string PortalDocument_Head, string DocumentName, string Domain_Name, int portalUserID, int documentCode, string documentPath, string folderToSearch, int documentIDForPortal, int candidateDocumentCode)
        {
            using (WebClient Client = new WebClient())
            {
                try
                {
                    //string folderToSearch = string.Empty;
                    //int documentIDForPortal = 0;
                    string fileName = string.Empty;
                    string completeFilePath = string.Empty;
                    string portalCompleteFilePath = string.Empty;
                    #region CreateFolders

                    if (!Directory.Exists(ConfigurationManager.AppSettings["PathforDocuments"].ToString() + DateTime.Today.Year))
                        CreateFolder(ConfigurationManager.AppSettings["PathforDocuments"].ToString() + DateTime.Today.Year);
                    if (!Directory.Exists(ConfigurationManager.AppSettings["PathforDocuments"].ToString() + DateTime.Today.Year + "\\Human Resource"))
                        CreateFolder(ConfigurationManager.AppSettings["PathforDocuments"].ToString() + DateTime.Today.Year + "\\Human Resource");

                    if (!Directory.Exists(ConfigurationManager.AppSettings["PathforDocuments"].ToString() + DateTime.Today.Year + "\\Human Resource\\" + PortalDocument_Head))
                        CreateFolder(ConfigurationManager.AppSettings["PathforDocuments"].ToString() + DateTime.Today.Year + "\\Human Resource\\" + PortalDocument_Head);

                    #region Old Commented Code
                    /*
                    switch (DocumentName)
                    {
                        case "Matric Marksheet":
                            folderToSearch = "Matric Marksheet\\";
                            documentIDForPortal = 11;
                            break;
                        case "Matric Certificate":
                            folderToSearch = "Matric or Equivalent Certificate\\";
                            documentIDForPortal = 10;
                            break;

                        case "Inter Certificate":
                            folderToSearch = "Intermediate or High School Certificate\\";
                            documentIDForPortal = 12;
                            break;
                        case "Inter Provisional":
                            folderToSearch = "Intermediate or High School Marksheet\\";
                            documentIDForPortal = 13;
                            break;


                        case "Graduation or Equivalent Degree":
                            folderToSearch = "Graduation or Equivalent Degree\\";
                            documentIDForPortal = 14;
                            break;
                        case "Bachelor Certificate":
                            folderToSearch = "Graduation Marksheet\\";
                            documentIDForPortal = 15;
                            break;

                        case "Master Certificate":
                            folderToSearch = "Masters Marksheet\\";
                            documentIDForPortal = 17;
                            break;
                        case "Master Degree":
                            folderToSearch = "Master or Equivalent Degree\\";
                            documentIDForPortal = 16;
                            break;

                        default:
                            break;
                    } 
                    */
                    #endregion


                    if (!Directory.Exists(ConfigurationManager.AppSettings["PathforDocuments"].ToString() + DateTime.Today.Year + "\\Human Resource\\" + PortalDocument_Head + "\\" + folderToSearch))
                        CreateFolder(ConfigurationManager.AppSettings["PathforDocuments"].ToString() + DateTime.Today.Year + "\\Human Resource\\" + PortalDocument_Head + "\\" + folderToSearch);

                    if (!Directory.Exists(ConfigurationManager.AppSettings["PathforDocuments"].ToString() + DateTime.Today.Year + "\\Human Resource\\" + PortalDocument_Head + "\\" + folderToSearch + "\\" + Domain_Name))
                        CreateFolder(ConfigurationManager.AppSettings["PathforDocuments"].ToString() + DateTime.Today.Year + "\\Human Resource\\" + PortalDocument_Head + "\\" + folderToSearch + "\\" + Domain_Name);

                    if (!Directory.Exists(ConfigurationManager.AppSettings["PathforDocuments"].ToString() + DateTime.Today.Year + "\\Human Resource\\" + PortalDocument_Head + "\\" + folderToSearch + "\\" + Domain_Name + "\\" + portalUserID))
                        CreateFolder(ConfigurationManager.AppSettings["PathforDocuments"].ToString() + DateTime.Today.Year + "\\Human Resource\\" + PortalDocument_Head + "\\" + folderToSearch + "\\" + Domain_Name + "\\" + portalUserID);


                    #endregion

                    fileName = DateTime.Now.Second.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + Path.GetExtension(documentPath);

                    completeFilePath = ConfigurationManager.AppSettings["PathforDocuments"].ToString() + DateTime.Today.Year
                        + "\\Human Resource\\" + PortalDocument_Head + "\\" + folderToSearch + "\\" + Domain_Name + "\\" + portalUserID
                        + "\\" + fileName;

                    portalCompleteFilePath = ConfigurationManager.AppSettings["PathforDocuments"].ToString()
                        + "//Human Resource//" + PortalDocument_Head + "//" + folderToSearch + "//" + Domain_Name + "//" + portalUserID
                        + "//" + fileName;

                    if (!File.Exists(completeFilePath))
                    {
                        Client.DownloadFile(documentPath,
                            completeFilePath);

                        UpdateDocumentInPortal(documentIDForPortal, fileSize(completeFilePath),
                        Path.GetExtension(documentPath), portalCompleteFilePath.Replace(ConfigurationManager.AppSettings["PathforDocuments"].ToString(), "Employeedocuments"),
                        "1", portalUserID, fileName);

                        UpdateDocumentSentToPortal(candidateDocumentCode);
                    }



                }
                catch (Exception ex)
                {
                    //throw exp1;
                    ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, "XDocumentUploadingService :: " + ex.StackTrace, ex, null);
                }
            }
        }

        private void UpdateDocumentSentToPortal(int CandDocCode)
        {
            SqlConnection connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentLiveConn"].ConnectionString);

            try
            {
                if (connection1.State == ConnectionState.Closed)
                    connection1.Open();
                SqlCommand sqlCommand = new SqlCommand("XREC_Update_DocumentSentToPortal", connection1);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandDoc_Code", CandDocCode);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw exp1;
                ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, "XDocumentUploadingService :: " + ex.StackTrace, ex, null);
            }
            finally
            {
                if (connection1.State == ConnectionState.Open)
                    connection1.Close();
            }
        }
        private string fileSize(string filePath)
        {
            long size = new FileInfo(filePath).Length / 1024;
            string KBSize = string.Format("{0} KB", size);
            return KBSize;
        }
        protected void UpdateDocumentInPortal(int Document_ID, string Doc_size, string doc_extension, string doc_path,
            string Doc_Version, int Emp_ID, string File_Name)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString);
            try
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand("XREC_InsertCandidateDocumentsFromRecruitment", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Document_ID", Document_ID);
                sqlCommand.Parameters.AddWithValue("@Doc_size", Doc_size);
                sqlCommand.Parameters.AddWithValue("@doc_extension", doc_extension);
                sqlCommand.Parameters.AddWithValue("@doc_path", doc_path);
                sqlCommand.Parameters.AddWithValue("@Doc_Version", Doc_Version);
                sqlCommand.Parameters.AddWithValue("@Emp_ID", Emp_ID);
                sqlCommand.Parameters.AddWithValue("@File_Name", File_Name);
                sqlCommand.Parameters.AddWithValue("@Updated_IP", "XRecruitement-SyncService");
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //throw exp1;
                ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, null);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public DataTable GetTentativeJoiningEmailData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["RecruitmentLiveConn"].ToString());
            SqlCommand sqlCommand = new SqlCommand("dbo.XREC_Select_TentativeJoiningEmailData", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            return dt;

        }

        public DataTable GetBGEmailData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection("User ID=recusr;Password=F7v#xyJ1iD;DataBase=BSMT;Server=184.154.101.79");
            SqlCommand sqlCommand = new SqlCommand("dbo.BSMT_Select_BGSignUpEmail", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            return dt;

        }

        private void UpdateTentativeJoiningEmailDataStatus(string TentativeJoiningEmailData_Code, SqlConnection sqlconn)
        {
            try
            {
                sqlconn.Open();
                SqlCommand sqlCommand = new SqlCommand("XREC_Update_TentativeJoiningEmailData", sqlconn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@TentativeJoiningEmailData_Code", TentativeJoiningEmailData_Code);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            }
            finally
            {
                sqlconn.Close();
            }

        }

        private void UpdateBGEmailDataStatus(int BGSignUp_Code)
        {
            SqlConnection connection = new SqlConnection("User ID=recusr;Password=F7v#xyJ1iD;DataBase=BSMT;Server=184.154.101.79");
            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("BSMT_Update_BGSignUpEmailData", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@BGSignUp_Code", BGSignUp_Code);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            }
            finally
            {
                connection.Close();
            }

        }

        public void SendEmailForBG()
        {
            DataTable dt = GetBGEmailData();
            if (dt.Rows.Count > 0)
            {
                string toEmail = string.Empty;
                string SenderEmail = string.Empty;
                string cc = string.Empty;
                string SenderName = string.Empty;
                int BGSignUp_Code = 0;
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    BGSignUp_Code = int.Parse(dt.Rows[i]["BGSignUp_Code"].ToString());
                    toEmail = dt.Rows[i]["Email"].ToString();
                    SenderEmail = "info@bgdevices.com";
                    //cc = "syedalirrizvi@yahoo.com";
                    SenderName = "BGDevices";

                    EmailFunctions objEmailFunctions = new EmailFunctions();
                    objEmailFunctions.SendBGThroughEmail(dt.Rows[i]["Full_Name"].ToString(), SenderName, toEmail, SenderEmail, cc);

                    UpdateBGEmailDataStatus(BGSignUp_Code);
                }
            }
        }

    }
    class EmailFunctions
    {
        internal void SendOrderCodesThroughEmail(SqlConnection sqlConnection, DataTable dtEmail, string SenderName, string toEmails, string SenderEmail, DateTime Date, string CC, string BCC, DataTable dtDistinctDomain)
        {
            if (dtEmail.Rows.Count > 0)
            {
                string StringDataTable = ConvertToHtmlFile(dtEmail, Date, dtDistinctDomain);

                MailMessage Mail_Message = new MailMessage();
                Mail_Message.From = new MailAddress(SenderEmail, SenderName);
                Mail_Message.To.Add(toEmails);
                Mail_Message.CC.Add(CC);
                Mail_Message.Bcc.Add(BCC);
                Mail_Message.Subject = "Tentative New Joining from " + Date.ToLongDateString();
                Mail_Message.Body = StringDataTable;
                Mail_Message.IsBodyHtml = true;
                Send_Email(Mail_Message);
                //dtEmail.Reset();
            }
        }
        internal void SendBGThroughEmail(string fullName, string SenderName, string toEmails, string SenderEmail, string CC)
        {

            string StringDataTable = ConvertToHtmlFileForBG(fullName);

            MailMessage Mail_Message = new MailMessage();
            Mail_Message.From = new MailAddress(SenderEmail, SenderName);
            Mail_Message.To.Add(toEmails);
            //Mail_Message.CC.Add(CC);                
            Mail_Message.Subject = "Thank You for your interest in BG’s LED TV";
            Mail_Message.Body = StringDataTable;
            Mail_Message.IsBodyHtml = true;
            Send_EmailBG(Mail_Message);
            //dtEmail.Reset();
            //}
        }
        private static string ConvertToHtmlFile(DataTable targetTable, DateTime date, DataTable DomainTable)
        {
            string myHtmlFile = "";
            int totalSelectedRows = 0;
            if (targetTable == null)
            {
                throw new System.ArgumentNullException("targetTable");
            }
            else
            {
                //Continue. 
            }

            //Get a worker object.
            StringBuilder myBuilder = new StringBuilder();

            myBuilder.Append("<span style='font-family: Calibri; font-size: small;'>");
            myBuilder.Append("<b>Dear All,</b>");
            myBuilder.Append("<br />");
            myBuilder.Append("<br />");
            myBuilder.Append("This is to inform you that following tentative number of new Axactian may join from <b>" + date.ToLongDateString() + "</b>. Final Notice of confirmed Axactian(s) will be circulated later. ");
            myBuilder.Append("<br />");
            myBuilder.Append("<br />");
            foreach (DataRow myRow in DomainTable.Rows)
            {
                myBuilder.Append("<li>");
                DataRow[] dr = targetTable.Select("Domain='" + myRow[0].ToString() + "'");
                myBuilder.Append(myRow[0].ToString() + " : " + dr.Length);
                myBuilder.Append("</li>");
                totalSelectedRows = totalSelectedRows + dr.Length;
            }

            myBuilder.Append("<br />");
            myBuilder.Append("<br />");

            myBuilder.Append("<b>Total :" + totalSelectedRows);

            myBuilder.Append("<br />");
            myBuilder.Append("<br />");
            myBuilder.Append("<u><b>Name of New Joining on " + date.ToLongDateString() + "</b></u>");
            myBuilder.Append("<br />");
            myBuilder.Append("<br />");
            myBuilder.Append("</span>");

            myBuilder.Append("<table border='1px' cellpadding='5' cellspacing='0' ");
            myBuilder.Append("style='border: solid 1px Silver; font-size: small; font-family: Calibri;'>");

            //Add the headings row.

            myBuilder.Append("<tr align='left' valign='top'>");

            foreach (DataColumn myColumn in targetTable.Columns)
            {
                if (myColumn.ColumnName != "postedFromDate" && myColumn.ColumnName != "TentativeJoiningEmailData_Code")
                {
                    myBuilder.Append("<td align='left' valign='top' style='border: solid 1px Silver;  background-color: #000; color:#F0F8FF; text-align: center;'>");
                    myBuilder.Append(myColumn.ColumnName);
                    myBuilder.Append("</td>");
                }
            }

            myBuilder.Append("</tr>");

            //Add the data rows. 
            foreach (DataRow myRow in targetTable.Rows)
            {
                myBuilder.Append("<tr align='left' valign='top'>");

                foreach (DataColumn myColumn in targetTable.Columns)
                {
                    if (myColumn.ColumnName != "postedFromDate" && myColumn.ColumnName != "TentativeJoiningEmailData_Code")
                    {
                        myBuilder.Append("<td align='left' valign='top' style='border: solid 1px Silver;'>");
                        myBuilder.Append(myRow[myColumn.ColumnName].ToString());
                        myBuilder.Append("</td>");
                    }
                }
                myBuilder.Append("</tr>");
            }
            //Close tags. 
            myBuilder.Append("</table>"); myBuilder.Append("</body>"); myBuilder.Append("</html>");

            myBuilder.Append("<br />"); myBuilder.Append("<br />");
            myBuilder.Append("<span style='font-family: Calibri; font-size: small;'>");
            myBuilder.Append("<b>Note:</b> This is system generated email. Please contact Talent Acquisition Department in case of any query.");
            myBuilder.Append("<br />");
            myBuilder.Append("<br />");
            myBuilder.Append("Regards,");
            myBuilder.Append("<br />");
            myBuilder.Append("BOL Recruitment Domain");
            myBuilder.Append("</span>");

            //Get the string for return. 
            myHtmlFile = myBuilder.ToString();

            return myHtmlFile;
        }
        private static string ConvertToHtmlFileForBG(string fullName)
        {
            string myHtmlFile = "";
            int totalSelectedRows = 0;


            //Get a worker object.
            StringBuilder myBuilder = new StringBuilder();

            myBuilder.Append("<span style='font-family: Calibri; font-size: small;'>");
            myBuilder.Append("<b>Dear " + fullName + ",</b>");
            myBuilder.Append("<br />");
            myBuilder.Append("<br />");
            myBuilder.Append("Thank you for signing up with BG Devices");
            myBuilder.Append("<br />");
            myBuilder.Append("<br />");

            myBuilder.Append("We appreciate your interest in BG’s LED. Our representative will be in touch with you as soon as you are selected for this exclusive offer. Please note, currently BG is only available to a few national and international enterprises.");

            myBuilder.Append("<br />");
            myBuilder.Append("<br />");
            myBuilder.Append("At BG, excellence is our way of life and it reflects in everything we do. We truly believe in creating <b>smart</b> and <b>beautifully designed</b> products.");
            myBuilder.Append("<br />");
            myBuilder.Append("<br />");
            myBuilder.Append("</span>");

            myBuilder.Append("</body>"); myBuilder.Append("</html>");

            myBuilder.Append("<br />");
            myBuilder.Append("<span style='font-family: Calibri; font-size: small;'>");
            myBuilder.Append("Looking forward to serve you in the best possible way.");
            myBuilder.Append("<br />");
            myBuilder.Append("<br />");
            myBuilder.Append("Regards,");
            myBuilder.Append("<br />");
            myBuilder.Append("<b>BG</b>");
            myBuilder.Append("</span>");

            //Get the string for return. 
            myHtmlFile = myBuilder.ToString();

            return myHtmlFile;
        }

        private bool Send_Email(MailMessage Mail_Message)
        {
            SmtpClient smtp = new SmtpClient();
            System.Net.NetworkCredential nc = new System.Net.NetworkCredential();
            nc.UserName = "mail";
            nc.Password = "mail123";
            smtp.Host = "172.16.10.210";
            smtp.Credentials = nc;
            try
            {
                smtp.Send(Mail_Message);
                return true;
            }
            catch
            {
                return false;
            }

        }
        private bool Send_EmailBG(MailMessage Mail_Message)
        {
            SmtpClient smtp = new SmtpClient();
            System.Net.NetworkCredential nc = new System.Net.NetworkCredential();
            nc.UserName = "info@bgdevices.com";
            nc.Password = "3m@!l654";
            smtp.Host = "mail.bgdevices.com";
            smtp.Credentials = nc;
            try
            {
                smtp.Send(Mail_Message);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}