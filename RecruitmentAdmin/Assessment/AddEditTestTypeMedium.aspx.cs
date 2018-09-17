using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ErrorLog;

public partial class AddEditTestTypeMedium : CustomBasePage//XRecBase
{

    #region Variables
    int TestTypeMediumCode = 0;
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            trMessage.Style["display"] = "none";
            if (Request.QueryString != null && Request.QueryString["ttmid"] != null && (Request.QueryString != null && Request.QueryString["ttmid"] != null))
            {
                if (Request.QueryString["ttmid"].ToString() != "")
                {
                    TestTypeMediumCode = Convert.ToInt32(Request.QueryString["ttmid"].ToString());
                    ViewState["qtid"] = Request.QueryString["ttmid"].ToString();
                }
            }
            else
                TestTypeMediumCode = 0;
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
            SqlCommand selectCommand = new SqlCommand("XREC_Insert_Update_TestTypeMedium", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@TestTypeMediumName", txtName.Text);
            selectCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
            selectCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
            if (TestTypeMediumCode == 0 && ViewState["qtid"] == null)
                selectCommand.Parameters.AddWithValue("@TestTypeMediumCode", 0);
            else if (ViewState["qtid"] != null && Request.QueryString["ttmid"] != "" && Request.QueryString["ttmid"] != string.Empty)
                selectCommand.Parameters.AddWithValue("@TestTypeMediumCode", Convert.ToInt32(Request.QueryString["ttmid"]));
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count <= 0)
                return;
            int int32 = Convert.ToInt32(dataTable.Rows[0]["TestTypeMediumCode"].ToString());
            ViewState["qtid"] = int32;
            if (int32 == 0)
            {
                trMessage.Style["display"] = "";
                lblMessage.Text = "This Test Type Medium already exists.";
            }
            else
            {
                lblMsg.Text = "";
                TestTypeMediumCode = Convert.ToInt32(dataTable.Rows[0]["TestTypeMediumCode"]);
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
            SqlCommand selectCommand = new SqlCommand("XREC_Select_TestTypeMediumDetail", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@TestTypeMediumCode", Convert.ToInt32(Request.QueryString["ttmid"]));
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return;
            txtName.Text = dataTable.Rows[0]["TestTypeMediumName"].ToString();
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