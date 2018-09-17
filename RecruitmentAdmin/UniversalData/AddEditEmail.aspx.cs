using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ErrorLog;


public partial class UniversalData_AddEditEmail : CustomBasePage
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
        if (QueryStringVar == null || secQueryString["emailid"] == null)
            return;
        SMSCode = Convert.ToInt32(secQueryString["emailid"].ToString());
        ViewState["emailid"] = secQueryString["emailid"].ToString();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XREC_UpdateEmail", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@EmailFunction_Code", ViewState["emailid"]);
            selectCommand.Parameters.AddWithValue("@EmailFunction_Name", txtEmailName.Text);
            selectCommand.Parameters.AddWithValue("@Email_Subject", txtEmailSubject.Text);
            selectCommand.Parameters.AddWithValue("@Email_Body", txtName.Content);
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
            SqlCommand selectCommand = new SqlCommand("XRec_Select_AllEmail ", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@EmailFunctionCode", ViewState["emailid"]);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return;
            lblEmailName.Text = dataTable.Rows[0]["EmailFunction_Name"].ToString();
            txtEmailName.Text = dataTable.Rows[0]["EmailFunction_Name"].ToString();
            txtEmailSubject.Text = dataTable.Rows[0]["Template_Subject"].ToString();
            txtName.Content = dataTable.Rows[0]["Email_Body"].ToString();
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