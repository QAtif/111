using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Specialized;
using ErrorLog;

public partial class StudentArea_removeprofileimage : CustomBaseClass
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    StringCollection parameters = new StringCollection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        int candidateCode = CandidateCode;
        try
        {
            parameters.Add(CandidateCode.ToString());
            DataSet detailsPageMethod = GetAreaDetailsPageMethod(connection, parameters);
            if (!(detailsPageMethod.Tables[0].Rows[0]["ProfileImage_Path"].ToString() != ""))
                return;
            imgProfileImage.Src = detailsPageMethod.Tables[0].Rows[0]["ProfileImage_Path"].ToString();
        }
        catch (Exception ex)
        {
        }
    }

    protected void lnkRemoveProfile_Click(object sender, EventArgs e)
    {
        try
        {
            int candidateCode = CandidateCode;
            connection.Open();
            parameters.Add(CandidateCode.ToString());
            removeProfilePicture(connection, parameters);
            ClientScript.RegisterClientScriptBlock(GetType(), "pass", "RefreshParent();", true);
        }
        catch (Exception ex)
        {
        }
        finally
        {
            connection.Close();
        }
    }

    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "pass", "RefreshParent();", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, "RemoveProfileImage", ex, "0");
        }
    }

    public DataSet GetAreaDetailsPageMethod(SqlConnection sqlCon, StringCollection parameters)
    {
        SqlCommand selectCommand = new SqlCommand();
        selectCommand.Connection = sqlCon;
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.CommandText = "XRec_SelectCandidateProfileImagePath";
        selectCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = parameters[0];
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        return dataSet;
    }

    public int removeProfilePicture(SqlConnection sqlCon, StringCollection parameters)
    {
        SqlCommand selectCommand = new SqlCommand();
        selectCommand.Connection = sqlCon;
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.CommandText = "XRec_UpdateCandidateProfileImage";
        selectCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = parameters[0];
        selectCommand.Parameters.Add("@ProfileImagePath", SqlDbType.VarChar).Value = DBNull.Value;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        return Convert.ToInt32(selectCommand.ExecuteScalar());
    }

}
