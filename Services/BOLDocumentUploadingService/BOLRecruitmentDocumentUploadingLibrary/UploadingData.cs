using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace BOLRecruitmentDocumentUploadingLibrary
{
    public class UploadingData
    {

        public static DataTable GetDocumentData()
        {
            DataTable dt= new DataTable();
            string conStr = ConfigurationManager.AppSettings["RecruitmentLiveConn"].ToString();
            SqlDataAdapter adapter = new SqlDataAdapter("Select_CandidateOfficialDocumentForUploading", new SqlConnection(conStr));
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(dt);
            return dt;
        }
        public static void UpdateDocumentUpladingStatus(int CandDoc_Code, int DocumentStatus)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["RecruitmentLiveConn"].ToString());
            try
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand("Update_CandidateOfficialDocumentStatus", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandDoc_Code", CandDoc_Code);
                sqlCommand.Parameters.AddWithValue("@DocumentStatus", DocumentStatus);
                
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw exp1;
                //ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, UserCode.ToString());
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

