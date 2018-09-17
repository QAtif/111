using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ErrorLog;


public partial class UniversalData_AddEditSMS : CustomBasePage
{
    #region Variables
    int SMSCode = 0;
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            if (QueryStringVar != null)
                secQueryString = new SecureQueryString(QueryStringVar);
            CheckQueryString();
            ShowData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    private void CheckQueryString()
    {
        if (QueryStringVar == null || secQueryString["smsid"] == null)
            return;
        SMSCode = Convert.ToInt32(secQueryString["smsid"].ToString());
        ViewState["smsid"] = secQueryString["smsid"].ToString();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XREC_UpdateSMS", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@SMSFunction_Code", ViewState["smsid"]);
            selectCommand.Parameters.AddWithValue("@SMSFunction_Name", txtSMSName.Text);
            selectCommand.Parameters.AddWithValue("@SMS_Body", txtSMSBody.Text);
            selectCommand.Parameters.AddWithValue("@Updated_By", UserCode);
            selectCommand.Parameters.AddWithValue("@UpdatedIP", Request.UserHostAddress);
            new SqlDataAdapter(selectCommand).Fill(new DataTable());
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "refreshParent();", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    protected void btnOptionAdd_Click(object sender, EventArgs e)
    {
        try
        {
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    protected void rptOptions_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    public void ShowData()
    {
        string empty = string.Empty;
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XRec_Select_AllSMS ", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@SMSFunctionCode", ViewState["smsid"]);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return;
            lblSMSName.Text = dataTable.Rows[0]["SMSFunction_Name"].ToString();
            txtSMSName.Text = dataTable.Rows[0]["SMSFunction_Name"].ToString();
            txtSMSBody.Text = dataTable.Rows[0]["SMS_Body"].ToString();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
  
    #endregion
}