

using ErrorLog;
using System;
using System.Data;
using System.Data.SqlClient;
using XRecruitmentStatusLibrary;

namespace XRecruitmentStatusLibrary
{
    public class EmailManagement
    {
        public static bool MarkCandidateEmail(SqlConnection sqlConn, int CandidateCode, Constants.CandidateLifeCycleStatus StatusCode, string UserIP, int UserID)
        {
            bool flag = false;
            try
            {
                if (sqlConn.State != ConnectionState.Open)
                    sqlConn.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConn;
                sqlCommand.CommandText = "XRec_CandidateEmailMarking";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@Candidate_Code", (object)CandidateCode));
                switch (Convert.ToInt32((object)StatusCode))
                {
                    case 1160:
                        sqlCommand.Parameters.Add(new SqlParameter("@EmailFunction_Code", (object)9));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_By", (object)UserID));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_IP", (object)UserIP));
                        flag = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                        break;
                    case 1170:
                        sqlCommand.Parameters.Add(new SqlParameter("@EmailFunction_Code", (object)10));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_By", (object)UserID));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_IP", (object)UserIP));
                        flag = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                        break;
                    case 1190:
                        sqlCommand.Parameters.Add(new SqlParameter("@EmailFunction_Code", (object)11));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_By", (object)UserID));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_IP", (object)UserIP));
                        flag = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                        break;
                    case 1120:
                        sqlCommand.Parameters.Add(new SqlParameter("@EmailFunction_Code", (object)6));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_By", (object)UserID));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_IP", (object)UserIP));
                        flag = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                        break;
                    case 1130:
                        sqlCommand.Parameters.Add(new SqlParameter("@EmailFunction_Code", (object)7));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_By", (object)UserID));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_IP", (object)UserIP));
                        flag = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                        break;
                    case 1140:
                        sqlCommand.Parameters.Add(new SqlParameter("@EmailFunction_Code", (object)8));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_By", (object)UserID));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_IP", (object)UserIP));
                        flag = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                        break;
                    case 1050:
                        sqlCommand.Parameters.Add(new SqlParameter("@EmailFunction_Code", (object)3));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_By", (object)UserID));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_IP", (object)UserIP));
                        flag = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                        break;
                    case 1060:
                        sqlCommand.Parameters.Add(new SqlParameter("@EmailFunction_Code", (object)4));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_By", (object)UserID));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_IP", (object)UserIP));
                        flag = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                        break;
                    case 1110:
                        sqlCommand.Parameters.Add(new SqlParameter("@EmailFunction_Code", (object)5));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_By", (object)UserID));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_IP", (object)UserIP));
                        flag = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                        break;
                    case 1010:
                        sqlCommand.Parameters.Add(new SqlParameter("@EmailFunction_Code", (object)1));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_By", (object)UserID));
                        sqlCommand.Parameters.Add(new SqlParameter("@Updated_IP", (object)UserIP));
                        flag = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                        break;
                    case 1020:
                        sqlCommand.Parameters.Add(new SqlParameter("@EmailFunction_Code", (object)2));
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
                LogError.Write(LogError.AppType.Candidate, "MarkCandidateEmail" + ex.Message + " " + ex.StackTrace, ex, "");
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


