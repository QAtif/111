using ErrorLog;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Handler
/// </summary>
public class Handler
{
    private static string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();

    public static bool VerifyEmail(string verificationCode, int CandidateCode)
    {
        DataSet dataSet1 = new DataSet();
        try
        {
            DataSet dataSet2 = Handler.Verify(verificationCode, CandidateCode);
            if (dataSet2 != null)
            {
                if (dataSet2.Tables != null)
                {
                    if (dataSet2.Tables[0].Rows.Count > 0)
                    {
                        if (dataSet2.Tables[0].Rows[0]["Verified"].ToString() == "1")
                            return true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, "btnVerify_Click", ex, CandidateCode.ToString());
        }
        return false;
    }

    public static DataSet Verify(string Code, int CandidateCode)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_VerifyCandidatePhoneCode", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add(new SqlParameter("@CandidateCode", (object)CandidateCode));
                selectCommand.Parameters.Add(new SqlParameter("@PhoneVerificationCode", (object)Code));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }
}