using ErrorLog;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for getAssistanceHandler
/// </summary>
public class getAssistanceHandler
{
    private static string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();

    public static bool GetAssistance(string GetAssistanceCode, int CandidateCode)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("XRec_Insert_CandidateAssistance", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Msg", (object)GetAssistanceCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", (object)CandidateCode));
                    if (sqlCommand.ExecuteNonQuery() == 1)
                        return true;
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, "btnSignIn_Click", ex, CandidateCode.ToString());
        }
        return false;
    }
}