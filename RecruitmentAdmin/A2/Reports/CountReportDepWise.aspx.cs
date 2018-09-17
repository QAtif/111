using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using ErrorLog;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Profile;
using System.Web.UI.HtmlControls;

public partial class A2_Reports_CountReportDepWise : CustomBasePage, IRequiresSessionState
{
    string UserCode1 = string.Empty;
    string UserTypeCode = string.Empty;
    string updateByIP = string.Empty;
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            postedToDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            postedFromDate.Value = DateTime.Now.AddMonths(-1).ToString("MMM dd, yyyy");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void btnSearch_Onclick(object sender, EventArgs e)
    {
        try
        {
            BindData();
            imgLoadingF.Style.Add("display", "none");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private void BindData()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
        SqlCommand selectCommand = new SqlCommand("Select_CountReportData", connection);
        selectCommand.Parameters.AddWithValue("@StartDate", postedFromDate.Value);
        selectCommand.Parameters.AddWithValue("@EndDate", postedToDate.Value);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
        {
            rptDeparments.DataSource = dataSet.Tables[0];
            rptDeparments.DataBind();
        }
        if (connection.State == ConnectionState.Closed)
            return;
        connection.Close();
    }


}