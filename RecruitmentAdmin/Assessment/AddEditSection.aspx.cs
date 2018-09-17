using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ErrorLog;

public partial class AddEditSection : CustomBasePage//XRecBase
{
    #region Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    int sectionCode = 0;
    #endregion

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            trMessage.Style["display"] = "none";
            if (Request.QueryString != null && Request.QueryString["sid"] != null && (Request.QueryString != null && Request.QueryString["sid"] != null))
            {
                if (Request.QueryString["sid"].ToString() != "")
                {
                    sectionCode = Convert.ToInt32(Request.QueryString["sid"].ToString());
                    ViewState["sid"] = Request.QueryString["sid"].ToString();
                }
            }
            else
                sectionCode = 0;
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XREC_Insert_Update_Section", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@SectionName", txtName.Text);
            selectCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
            selectCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
            if (sectionCode == 0 && ViewState["sid"] == null)
                selectCommand.Parameters.AddWithValue("@SectionCode", 0);
            else if (ViewState["sid"] != null && Request.QueryString["sid"] != "" && Request.QueryString["sid"] != string.Empty)
                selectCommand.Parameters.AddWithValue("@SectionCode", Convert.ToInt32(Request.QueryString["sid"]));
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count <= 0)
                return;
            int int32 = Convert.ToInt32(dataTable.Rows[0]["SectionCode"].ToString());
            ViewState["sid"] = int32;
            if (int32 == 0)
            {
                trMessage.Style["display"] = "";
                lblMessage.Text = "This Section already exists.";
            }
            else
            {
                lblMsg.Text = "";
                sectionCode = Convert.ToInt32(dataTable.Rows[0]["SectionCode"]);
                ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "refreshParent();", true);
            }
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

    public void ShowData()
    {
        string empty = string.Empty;
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XREC_Select_SectionDetail ", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@SectionCode", Convert.ToInt32(Request.QueryString["sid"]));
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return;
            txtName.Text = dataTable.Rows[0]["SectionName"].ToString();
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