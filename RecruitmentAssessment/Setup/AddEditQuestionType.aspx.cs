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

public partial class AddEditQuestionType : XRecBase
{
    int QuestionTypeCode = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            trMessage.Style["display"] = "none";
            if (Request.QueryString != null && Request.QueryString["qtid"] != null && Request.QueryString != null && Request.QueryString["qtid"] != null)
            {
                if (Request.QueryString["qtid"].ToString() != "")
                {
                    QuestionTypeCode = Convert.ToInt32(Request.QueryString["qtid"].ToString());
                    ViewState["qtid"] = Request.QueryString["qtid"].ToString();
                }
            }
            else
            {
                QuestionTypeCode = 0;
            }
            ShowData();
        }
    }



    public void ShowData()
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);
        string strSQL = string.Empty;

        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XREC_Select_QuestionTypeDetail ", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@QuestionTypeCode", Convert.ToInt32(Request.QueryString["qtid"]));
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["QuestionTypeName"].ToString();
                }
            }
        }
        catch (Exception exp1)
        {
            //throw exp1;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, exp1.StackTrace, exp1, UserID.ToString());
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
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);

        int Exist = 0;
        lblMsg.Text = "";
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XREC_Insert_Update_QuestionType", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@QuestionTypeName", txtName.Text);

            sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
            sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);

            if (QuestionTypeCode == 0 && ViewState["qtid"] == null)
            {
                sqlCommand.Parameters.AddWithValue("@QuestionTypeCode", 0); // insert
            }

            else if (ViewState["qtid"] != null && Request.QueryString["qtid"] != "" && Request.QueryString["qtid"] != string.Empty)
            {
                sqlCommand.Parameters.AddWithValue("@QuestionTypeCode", Convert.ToInt32(Request.QueryString["qtid"])); // update
            }
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Exist = Convert.ToInt32(dt.Rows[0]["QuestionTypeCode"].ToString());
                ViewState["qtid"] = Exist;
                if (Exist == 0)
                {
                    trMessage.Style["display"] = "";
                    lblMessage.Text = "This Question Type already exists.";
                }

                else
                {
                    lblMsg.Text = "";
                    QuestionTypeCode = Convert.ToInt32(dt.Rows[0]["QuestionTypeCode"]);
                    ScriptManager.RegisterStartupScript(this, GetType(), "pass", "refreshParent();", true);
                }
            }
        }

        catch (Exception exp1)
        {
            //throw exp1;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, exp1.StackTrace, exp1, UserID.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }


    }
}