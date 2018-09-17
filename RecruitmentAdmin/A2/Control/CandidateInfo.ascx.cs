using ErrorLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class A2_Control_CandidateInfo : System.Web.UI.UserControl
{
    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    public string CandidateCode = string.Empty;
    public string UserCode = string.Empty;
    public string CandCode
    {
        get
        {
            return hdnCancode.Value;
        }
        set
        {
            hdnCancode.Value = value;
        }
    }

    private void Page_Load(object sender, EventArgs e)
    {
        try
        {
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    public void BindData()
    {
        DataTable dataTable = new DataTable();
        if (connection.State != ConnectionState.Open)
            connection.Open();
        SqlCommand selectCommand = new SqlCommand("dbo.select_CandidateBasicInfo", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.Add("@CandidateCode", SqlDbType.VarChar).Value = hdnCancode.Value;
        new SqlDataAdapter(selectCommand).Fill(dataTable);
        if (connection.State != ConnectionState.Closed)
            connection.Close();
        if (dataTable == null || dataTable.Rows.Count <= 0)
            return;
        lblName.Text = dataTable.Rows[0]["Full_Name"].ToString();
        lblref.Text = dataTable.Rows[0]["Candidate_ID"].ToString();
        lblsts.Text = dataTable.Rows[0]["CanStatus"].ToString();
        lbldep.Text = dataTable.Rows[0]["Department"].ToString();
    }
}