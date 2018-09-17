using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class CaseStudy : XRecBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {           
            ShowData();
        }
    }
    public void ShowData()
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);
        string strSQL = string.Empty;

        try
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            SqlCommand sqlCommand = new SqlCommand("XREC_Select_QuestionGroup", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
           

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
           
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    lblMsg.Visible = false;
                    tblMsg.Visible = false;
                    UpdatePanel1.Visible = true;
                    rptSection.DataSource = dt;
                    rptSection.DataBind();
                    
                }
                else
                {
                    UpdatePanel1.Visible = false;
                    rptSection.DataSource = null;
                    rptSection.DataBind();
                    lblMsg.Visible = true;
                    tblMsg.Visible = true;

                    lblMsg.Text = "No record(s) found";
                    
                }
            }

            else
            {
                lblMsg.Visible = true;
                tblMsg.Visible = true;

                lblMsg.Text = "No record(s) found";
                UpdatePanel1.Visible = false;
                rptSection.DataSource = null;
                rptSection.DataBind();
               
            }
        }
        catch (Exception ex)
        {
            //throw ex;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserID.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

    }
    protected void rptSection_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageButton btnDelete = (ImageButton)e.Item.FindControl("btnDelete");
            Label lblSno = (Label)e.Item.FindControl("lblSno");
            lblSno.Text = Convert.ToString((e.Item.ItemIndex + 1));
            
            
            btnDelete.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete this Case Study?')");

            HiddenField hfQuestionGroupCode = (HiddenField)e.Item.FindControl("hfQuestionGroupCode");
            HtmlAnchor btnEdit = (HtmlAnchor)e.Item.FindControl("btnEdit");

            string RedirectingLink = "AddEditCaseStudy.aspx?" + "qgid" + "=" + hfQuestionGroupCode.Value;

            btnEdit.Attributes.Add("href", RedirectingLink);
        }
    }

    protected void rptSection_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);

            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("XRec_Delete_QuestionGroupCode", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@QuestionGroupCode", e.CommandArgument);
                sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
                sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                Response.Redirect(Request.Path + (Request.QueryString.Count > 0 ? "?" + Request.QueryString : string.Empty), false);
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
}