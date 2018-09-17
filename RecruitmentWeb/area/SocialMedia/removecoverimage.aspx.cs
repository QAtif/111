using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Specialized;
using ErrorLog;


public partial class StudentArea_removecoverimage : CustomBaseClass
{
    #region Page Variables

    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    StringCollection parameters = new StringCollection();
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();

    #endregion Page Variables

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        int candidateCode = CandidateCode;
        try
        {
            parameters.Add(CandidateCode.ToString());
            DataSet detailsPageMethod = GetAreaDetailsPageMethod(connection, parameters);
            if (!(detailsPageMethod.Tables[0].Rows[0]["CoverImage_Path"].ToString() != ""))
                return;
            imgCoverImage.Src = detailsPageMethod.Tables[0].Rows[0]["CoverImage_Path"].ToString();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, "RemoveCoverImage", ex, "0");
        }
    }

    protected void lnkRemoveCover_Click(object sender, EventArgs e)
    {
        try
        {
            int candidateCode = CandidateCode;
            connection.Open();
            parameters.Add(CandidateCode.ToString());
            removeCoverPicture(connection, parameters);
            ClientScript.RegisterClientScriptBlock(GetType(), "pass", "RefreshParent();", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, "RemoveCoverImage", ex, "0");
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
            LogError.Write(LogError.AppType.Candidate, "RemoveCoverImage", ex, "0");
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

    public int removeCoverPicture(SqlConnection sqlCon, StringCollection parameters)
    {
        SqlCommand selectCommand = new SqlCommand();
        selectCommand.Connection = sqlCon;
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.CommandText = "XRec_UpdateCandidateCoverImage";
        selectCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = parameters[0];
        selectCommand.Parameters.Add("@CoverImagePath", SqlDbType.VarChar).Value = DBNull.Value;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        return Convert.ToInt32(selectCommand.ExecuteScalar());
    }


}
