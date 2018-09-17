using System;
using System.Data;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using ErrorLog;
using XRecruitmentStatusLibrary;

public partial class profile_redirector : CustomBaseClass//System.Web.UI.Page
{
    #region Page Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();

    #endregion Page Variables

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string fileName = Path.GetFileName(Context.Request.UrlReferrer.LocalPath);
            DataSet dsPercent = new DataSet();
            GetProfileLinksAndStatus(CandidateCode, ref dsPercent);
            int Progress = 0;
            if (dsPercent.Tables[0].Rows.Count > 0)
            {
                int int32 = Convert.ToInt32(dsPercent.Tables[0].Rows[0]["StatusProgressBar"]);
                Redirector(fileName, dsPercent.Tables[1], int32);
            }
            else
                Redirector(string.Empty, dsPercent.Tables[1], Progress);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    private void Redirector(string referringURL, DataTable dsLinks, int Progress)
    {
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_GetNavigationURL", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = (object)CandidateCode;
        selectCommand.Parameters.Add("@ModuleCode", SqlDbType.Int).Value = (object)Constants.ModuleCode.ProfileStatus;
        if (Progress == 100 && !referringURL.Contains("area.aspx"))
            selectCommand.Parameters.Add("@RefererURL", SqlDbType.VarChar).Value = (object)referringURL;
        if (connection.State != ConnectionState.Open)
            connection.Open();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        string str = dataTable.Rows[0]["NavigationURL"].ToString();
        if (connection.State != ConnectionState.Closed)
            connection.Close();
        Response.Redirect(DomainAddress + str, false);
    }

    private void GetProfileLinksAndStatus(int CanCode, ref DataSet dsPercent)
    {
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_GetProfileLinks", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.AddWithValue("@CandidateCode", (object)CanCode);
        new SqlDataAdapter(selectCommand).Fill(dsPercent);
    }
}