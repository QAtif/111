using ErrorLog;
using System;
using System.Data;
using System.Data.SqlClient;

namespace XRecruitmentStatusLibrary
{
    public class AlertManagement
    {
        public static bool MarkCandidateAlert(SqlConnection sqlConn, int CandidateCode, Constants.CandidateLifeCycleStatus StatusCode, string UserIP, int UserID)
        {
            bool flag = false;
            try
            {
                if (sqlConn.State != ConnectionState.Open)
                    sqlConn.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConn;
                sqlCommand.CommandText = "XRec_MarkCandidateAlert";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", (object)CandidateCode));
                switch (Convert.ToInt32((object)StatusCode))
                {
                    case 1060:
                        sqlCommand.Parameters.Add(new SqlParameter("@AlertCode", (object)3));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_By", (object)UserID));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_IP", (object)UserIP));
                        flag = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                        break;
                    case 1140:
                        sqlCommand.Parameters.Add(new SqlParameter("@AlertCode", (object)4));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_By", (object)UserID));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_IP", (object)UserIP));
                        flag = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                        break;
                    case 1190:
                        sqlCommand.Parameters.Add(new SqlParameter("@AlertCode", (object)5));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_By", (object)UserID));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_IP", (object)UserIP));
                        flag = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                        break;
                    case 1010:
                        sqlCommand.Parameters.Add(new SqlParameter("@AlertCode", (object)1));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_By", (object)UserID));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_IP", (object)UserIP));
                        flag = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                        break;
                    case 1050:
                        sqlCommand.Parameters.Add(new SqlParameter("@AlertCode", (object)2));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_By", (object)UserID));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_IP", (object)UserIP));
                        flag = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "MarkCandidateAlert" + ex.Message + " " + ex.StackTrace, ex, "");
            }
            finally
            {
                if (sqlConn.State != ConnectionState.Closed)
                    sqlConn.Close();
            }
            return flag;
        }
    }
}