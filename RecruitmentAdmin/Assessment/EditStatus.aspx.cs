using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

using System.Configuration;
using System.Web.UI.HtmlControls;

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
            if (!IsPostBack)
            {
                trMessage.Style["display"] = "none";
                if (Request.QueryString != null && Request.QueryString["ttmid"] != null && Request.QueryString != null && Request.QueryString["ttmid"] != null)
                {
                    if (Request.QueryString["ttmid"].ToString() != "")
                    {
                        TestTypeMediumCode = Convert.ToInt32(Request.QueryString["ttmid"].ToString());
                        ViewState["qtid"] = Request.QueryString["ttmid"].ToString();
                    }
                }
                else
                {
                    TestTypeMediumCode = 0;
                }
                ShowData();
            }
        }

        catch (Exception exp1)
        {
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, exp1.StackTrace, exp1, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {


        int Exist = 0;
        lblMsg.Text = "";
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XREC_Update_StatusAreaText", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@StatusText", txtName.Text);

            sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
            sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);

            if (TestTypeMediumCode == 0 && ViewState["qtid"] == null)
            {
                sqlCommand.Parameters.AddWithValue("@StatusCode", 0); // insert
            }

            else if (ViewState["qtid"] != null && Request.QueryString["ttmid"] != "" && Request.QueryString["ttmid"] != string.Empty)
            {
                sqlCommand.Parameters.AddWithValue("@StatusCode", Convert.ToInt32(Request.QueryString["ttmid"])); // update
            }
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Exist = Convert.ToInt32(dt.Rows[0]["StatusCode"].ToString());
                ViewState["qtid"] = Exist;
                if (Exist == 0)
                {
                    trMessage.Style["display"] = "";
                    lblMessage.Text = "Status Already Exists.";
                }

                else
                {
                    lblMsg.Text = "";
                    TestTypeMediumCode = Convert.ToInt32(dt.Rows[0]["StatusCode"]);
                    ScriptManager.RegisterStartupScript(this, GetType(), "pass", "refreshParent();", true);
                }
            }
        }

        catch (Exception exp1)
        {
            
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, exp1.StackTrace, exp1, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }


    }
    #endregion

    #region Methods
    public void ShowData()
    {
        
        string strSQL = string.Empty;

        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XREC_Select_TestTypeMediumDetail", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@TestTypeMediumCode", Convert.ToInt32(Request.QueryString["ttmid"]));
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["TestTypeMediumName"].ToString();
                }
            }
        }
        catch (Exception exp1)
        {
            //throw exp1;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, exp1.StackTrace, exp1, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

    }
    #endregion



}