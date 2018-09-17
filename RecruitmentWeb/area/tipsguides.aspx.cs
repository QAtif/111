using System;
using ErrorLog;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class area_tipsguides : CustomBaseClass //System.Web.UI.Page
{
    #region Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    #endregion

    #region Events Handlers
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            GetCandidateName(CandidateCode);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, "Candidate Area", ex, CandidateCode.ToString());
        }
    }

    private void GetCandidateName(int CandidateCode)
    {
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_GetCandidateName", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        if (dataTable.Rows.Count <= 0)
            return;
        lblNameGen.Text = dataTable.Rows[0]["Full_Name"].ToString();
        lblNameGen.Visible = true;
        lblNameTest.Text = dataTable.Rows[0]["Full_Name"].ToString();
        lblNameTest.Visible = true;
    }
    #endregion
}