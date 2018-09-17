
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using ErrorLog;

public partial class AddEditStatusText : CustomBasePage
{
    #region Variables
    int QuestionCode = 0;
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            if (Request.QueryString != null && Request.QueryString["sid"] != null && (Request.QueryString != null && Request.QueryString["sid"] != null))
            {
                if (Request.QueryString["sid"].ToString() != "")
                {
                    QuestionCode = Convert.ToInt32(Request.QueryString["sid"].ToString());
                    ViewState["sid"] = Request.QueryString["sid"].ToString();
                }
            }
            else
                QuestionCode = 0;
            BindMetaStatus();
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

    private void BindMetaStatus()
    {
        try
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand selectCommand = new SqlCommand("XRec_Select_MetaStatus ", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return;
            ddlMetaStatus.DataSource = dataTable;
            ddlMetaStatus.DataTextField = "MetaStatus_Name";
            ddlMetaStatus.DataValueField = "MetaStatus_Code";
            ddlMetaStatus.DataBind();
            ddlMetaStatus.Items.Insert(0, new ListItem("--Select--", ""));
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XREC_UpdateStatus", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@StatusCode", ViewState["sid"]);
            selectCommand.Parameters.AddWithValue("@Status_Name", txtStatusName.Text);
            selectCommand.Parameters.AddWithValue("@StatusDisplayText", txtStatusDisplayText.Text);
            selectCommand.Parameters.AddWithValue("@MetaStatusCode", ddlMetaStatus.SelectedValue);
            selectCommand.Parameters.AddWithValue("@Status_Display_LongText", txtName.Content);
            selectCommand.Parameters.AddWithValue("@StatusImage", txtStatusImage.Text);
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
            SqlCommand selectCommand = new SqlCommand("XRec_Select_StatusWiseArea ", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@StatusCode", ViewState["sid"]);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return;
            lblStatusName.Text = dataTable.Rows[0]["Status_Name"].ToString();
            txtStatusName.Text = dataTable.Rows[0]["Status_Name"].ToString();
            txtStatusDisplayText.Text = dataTable.Rows[0]["Status_Display_Text"].ToString();
            ddlMetaStatus.SelectedValue = dataTable.Rows[0]["MetaStatus_Code"].ToString();
            txtStatusImage.Text = dataTable.Rows[0]["StatusImage"].ToString();
            txtName.Content = dataTable.Rows[0]["Status_Display_LongText"].ToString();
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