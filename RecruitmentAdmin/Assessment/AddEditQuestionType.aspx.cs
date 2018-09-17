
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using ErrorLog;


public partial class AddEditQuestionType : CustomBasePage//XRecBase
{
    #region Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    int QuestionTypeCode = 0;
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            trMessage.Style["display"] = "none";
            if (Request.QueryString != null && Request.QueryString["qtid"] != null && (Request.QueryString != null && Request.QueryString["qtid"] != null))
            {
                if (Request.QueryString["qtid"].ToString() != "")
                {
                    QuestionTypeCode = Convert.ToInt32(Request.QueryString["qtid"].ToString());
                    ViewState["qtid"] = Request.QueryString["qtid"].ToString();
                }
            }
            else
                QuestionTypeCode = 0;
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
            SqlCommand selectCommand = new SqlCommand("XREC_Insert_Update_QuestionType", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@QuestionTypeName", txtName.Text);
            selectCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
            selectCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
            if (QuestionTypeCode == 0 && ViewState["qtid"] == null)
                selectCommand.Parameters.AddWithValue("@QuestionTypeCode", 0);
            else if (ViewState["qtid"] != null && Request.QueryString["qtid"] != "" && Request.QueryString["qtid"] != string.Empty)
                selectCommand.Parameters.AddWithValue("@QuestionTypeCode", Convert.ToInt32(Request.QueryString["qtid"]));
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count <= 0)
                return;
            int int32 = Convert.ToInt32(dataTable.Rows[0]["QuestionTypeCode"].ToString());
            ViewState["qtid"] = int32;
            if (int32 == 0)
            {
                trMessage.Style["display"] = "";
                lblMessage.Text = "This Question Type already exists.";
            }
            else
            {
                lblMsg.Text = "";
                QuestionTypeCode = Convert.ToInt32(dataTable.Rows[0]["QuestionTypeCode"]);
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
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
        string empty = string.Empty;
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XREC_Select_QuestionTypeDetail ", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@QuestionTypeCode", Convert.ToInt32(Request.QueryString["qtid"]));
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return;
            txtName.Text = dataTable.Rows[0]["QuestionTypeName"].ToString();
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