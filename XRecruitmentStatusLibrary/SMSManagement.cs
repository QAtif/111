using ErrorLog;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace XRecruitmentStatusLibrary
{
    public class SMSManagement
    {
        private static DataTable objDatatable = new DataTable();
        private static string msg = string.Empty;
        private static string phone = string.Empty;

        public static bool MarkCandidateSMS(SqlConnection sqlConn, int CandidateCode, Constants.CandidateLifeCycleStatus StatusCode, string UserIP, int UserID)
        {
            bool flag = false;
            try
            {
                switch (Convert.ToInt32((object)StatusCode))
                {
                    case 1140:
                        SMSManagement.SendSMS(sqlConn, 4, CandidateCode);
                        flag = SMSManagement.CandidateSMSMarking(sqlConn, 4, CandidateCode, SMSManagement.msg, SMSManagement.phone, UserIP, UserID);
                        break;
                    case 1190:
                        SMSManagement.SendSMS(sqlConn, 5, CandidateCode);
                        flag = SMSManagement.CandidateSMSMarking(sqlConn, 5, CandidateCode, SMSManagement.msg, SMSManagement.phone, UserIP, UserID);
                        break;
                    case 1230:
                        SMSManagement.SendSMS(sqlConn, 6, CandidateCode);
                        flag = SMSManagement.CandidateSMSMarking(sqlConn, 6, CandidateCode, SMSManagement.msg, SMSManagement.phone, UserIP, UserID);
                        break;
                    case 1010:
                        SMSManagement.SendSMS(sqlConn, 1, CandidateCode);
                        flag = SMSManagement.CandidateSMSMarking(sqlConn, 1, CandidateCode, SMSManagement.msg, SMSManagement.phone, UserIP, UserID);
                        break;
                    case 1050:
                        SMSManagement.SendSMS(sqlConn, 2, CandidateCode);
                        flag = SMSManagement.CandidateSMSMarking(sqlConn, 2, CandidateCode, SMSManagement.msg, SMSManagement.phone, UserIP, UserID);
                        break;
                    case 1060:
                        SMSManagement.SendSMS(sqlConn, 3, CandidateCode);
                        flag = SMSManagement.CandidateSMSMarking(sqlConn, 3, CandidateCode, SMSManagement.msg, SMSManagement.phone, UserIP, UserID);
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "MarkCandidateSMS " + ex.Message + " " + ex.StackTrace, ex, "");
            }
            finally
            {
                if (sqlConn.State != ConnectionState.Closed)
                    sqlConn.Close();
            }
            return flag;
        }

        public static DataTable SelectSMS(SqlConnection sqlConn, int SMSFunction_code, int CandidateCode)
        {
            try
            {
                DataTable dataTable = new DataTable();
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = sqlConn;
            selectCommand.CommandText = "XRec_SelectCandidateSMS";
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.Add(new SqlParameter("@SMSFunction_Code", (object)SMSFunction_code));
            selectCommand.Parameters.Add(new SqlParameter("@CandidateCode", (object)CandidateCode));
            new SqlDataAdapter(selectCommand).Fill(dataTable);
            return dataTable;
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "SelectSMS " + ex.Message + " " + ex.StackTrace, ex, "");
                return null;
            }
            finally
            {
                if (sqlConn.State != ConnectionState.Closed)
                    sqlConn.Close();
            }
        }

        public static bool CandidateSMSMarking(SqlConnection sqlConn, int SMSFunction_code, int CandidateCode, string SMS_Body, string Recepient_Number, string UserIP, int UserID)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConn;
            sqlCommand.CommandText = "XRec_CandidateSMSMarking";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter("@Candidate_Code", (object)CandidateCode));
            sqlCommand.Parameters.Add(new SqlParameter("@SMSFunction_Code", (object)SMSFunction_code));
            sqlCommand.Parameters.Add(new SqlParameter("@Recepient_Number", (object)Recepient_Number));
            sqlCommand.Parameters.Add(new SqlParameter("@SMS_Body", (object)SMS_Body));
            sqlCommand.Parameters.Add(new SqlParameter("@Updated_By", (object)UserID));
            sqlCommand.Parameters.Add(new SqlParameter("@Updated_IP", (object)UserIP));
            return Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

                LogError.Write(LogError.AppType.Candidate, "CandidateSMSMarking " + ex.Message + " " + ex.StackTrace, ex, "");
                return false;
            }
            finally
            {
                if (sqlConn.State != ConnectionState.Closed)
                    sqlConn.Close();
            }
        }

        public static void SendSMS(SqlConnection sqlConn, int SMSFUnctionCode, int CandidateCode)
        {
            try
            {
                SMSManagement.objDatatable = SMSManagement.SelectSMS(sqlConn, SMSFUnctionCode, CandidateCode);
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string str1 = SMSManagement.objDatatable.Rows[0]["SMS_Body"].ToString();
            SMSManagement.msg = str1;
            string str2 = "92" + SMSManagement.objDatatable.Rows[0]["Phone_Number"].ToString();
            SMSManagement.phone = str2;
            string empty3 = string.Empty;
            SMSManagement.getString(SMSManagement.getPageHTML("http://bsms.ufone.com/bsms_app4/sendapi.jsp?id=" + ConfigurationManager.AppSettings["SMSID"].ToString() + "&message=" + str1 + "&shortcode=" + ConfigurationManager.AppSettings["MsgShortCode"].ToString() + "&lang=English&mobilenum=" + str2 + "&password=" + ConfigurationManager.AppSettings["MsgPassword"].ToString()), "<body>", "</body>").Trim();
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "SendSMS " + ex.Message + " " + ex.StackTrace, ex, "");
            }
        }

        private static string getString(string ActualString, string StartValue, string EndValue)
        {
            try
            {
                string empty = string.Empty;
            return ActualString.Substring(ActualString.IndexOf(StartValue), ActualString.IndexOf(EndValue, ActualString.IndexOf(StartValue)) - ActualString.IndexOf(StartValue)).Replace(StartValue, "").Trim();
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "getString " + ex.Message + " " + ex.StackTrace, ex, "");
                return null;
            }
        }

        protected static string getPageHTML(string _pageURL)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(_pageURL);
            httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1;..NET CLR 1.1.4322)";
            return new StreamReader(httpWebRequest.GetResponse().GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "getPageHTML " + ex.Message + " " + ex.StackTrace, ex, "");
                return null;
            }
        }
    }
}

