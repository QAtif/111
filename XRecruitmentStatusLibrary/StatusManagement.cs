
using ErrorLog;
using System;
using System.Data;
using System.Data.SqlClient;

namespace XRecruitmentStatusLibrary
{
    public class StatusManagement
    {
        public static bool MarkLifeCycleStatus(SqlConnection sqlConn, int CandidateCode, Constants.ModuleCode moduleCode, Constants.CandidateLifeCycleStatus StatusCode, string UserIP, int UserID)
        {
            try
            {
                if (moduleCode != Constants.ModuleCode.LifeCycleStatus)
                return false;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConn;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.XRec_SNT_Update_MarkLifeCycleStatus";
            sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = (object)CandidateCode;
            sqlCommand.Parameters.Add("@moduleCode", SqlDbType.Int).Value = (object)moduleCode;
            sqlCommand.Parameters.Add("@StatusCode", SqlDbType.Int).Value = (object)StatusCode;
            sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = (object)UserID;
            sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = (object)UserIP;
            if (sqlConn.State != ConnectionState.Open)
                sqlConn.Open();
            return Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "MarkLifeCycleStatus", ex, CandidateCode.ToString());
                return false;
            }
            finally
            {
                if (sqlConn.State != ConnectionState.Closed)
                    sqlConn.Close();
            }
        }

        public static bool MarkProfileStatus(SqlConnection sqlConn, int CandidateCode, Constants.ModuleCode moduleCode, Constants.CandidateProfileStatus StatusCode, string UserIP, int UserID, Constants.ProfileNavigation NavCode)
        {
            try
            {
                if (moduleCode != Constants.ModuleCode.ProfileStatus)
                return false;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConn;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.XRec_SNT_Update_MarkProfileStatus";
            sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = (object)CandidateCode;
            sqlCommand.Parameters.Add("@moduleCode", SqlDbType.Int).Value = (object)moduleCode;
            sqlCommand.Parameters.Add("@StatusCode", SqlDbType.Int).Value = (object)StatusCode;
            sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = (object)UserID;
            sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = (object)UserIP;
            sqlCommand.Parameters.Add("@NavigationCode", SqlDbType.Int).Value = (object)NavCode;
            if (sqlConn.State != ConnectionState.Open)
                sqlConn.Open();
            return Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "MarkProfileStatus", ex, CandidateCode.ToString());
                return false;
            }
            finally
            {
                if (sqlConn.State != ConnectionState.Closed)
                    sqlConn.Close();
            }
        }

        public static bool MarkStatus(SqlConnection sqlConn, int CandidateCode, Constants.ModuleCode moduleCode, Constants.CandidateProfileStatus StatusCode, string UserIP, int UserID)
        {
            try
            {
                if (moduleCode != Constants.ModuleCode.ProfileStatus)
                    return false;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConn;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "XRec_SNT_Update_MarkStatus";
                sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = (object)CandidateCode;
                sqlCommand.Parameters.Add("@moduleCode", SqlDbType.Int).Value = (object)moduleCode;
                sqlCommand.Parameters.Add("@StatusCode", SqlDbType.Int).Value = (object)StatusCode;
                sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = (object)UserID;
                sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = (object)UserIP;
                if (sqlConn.State != ConnectionState.Open)
                    sqlConn.Open();
                return Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "MarkStatus", ex, CandidateCode.ToString());
                return false;
            }
            finally
            {
                if (sqlConn.State != ConnectionState.Closed)
                    sqlConn.Close();
            }
        }

        public static bool RemoveProfileStatus(SqlConnection sqlConn, int CandidateCode, Constants.ModuleCode moduleCode, string UserIP, int UserID, Constants.ProfileNavigation NavCode)
        {
            try
            {
                if (moduleCode != Constants.ModuleCode.ProfileStatus)
                return false;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConn;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.XRec_SNT_Update_RemoveProfileStatus";
            sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = (object)CandidateCode;
            sqlCommand.Parameters.Add("@moduleCode", SqlDbType.Int).Value = (object)moduleCode;
            sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = (object)UserID;
            sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = (object)UserIP;
            sqlCommand.Parameters.Add("@NavigationCode", SqlDbType.Int).Value = (object)NavCode;
            if (sqlConn.State != ConnectionState.Open)
                sqlConn.Open();
            return Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "RemoveProfileStatus", ex, CandidateCode.ToString());
                return false;
            }
            finally
            {
                if (sqlConn.State != ConnectionState.Closed)
                    sqlConn.Close();
            }
        }
    }
}
