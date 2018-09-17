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

public partial class Test : Page
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

            SqlCommand sqlCommand = new SqlCommand("XREC_Select_Test", connection);
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
                    rptTest.DataSource = dt;
                    rptTest.DataBind();
                    
                }
                else
                {
                    UpdatePanel1.Visible = false;
                    rptTest.DataSource = null;
                    rptTest.DataBind();
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
                rptTest.DataSource = null;
                rptTest.DataBind();
               
            }
        }
        catch (Exception ex)
        {
            throw ex;

        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

    }
    protected void rptTest_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageButton btnDelete = (ImageButton)e.Item.FindControl("btnDelete");
            Label lblSno = (Label)e.Item.FindControl("lblSno");
            lblSno.Text = Convert.ToString((e.Item.ItemIndex + 1));
            
            
            btnDelete.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete this Test?')");

            HiddenField hfTestCode = (HiddenField)e.Item.FindControl("hfTestCode");
            HtmlAnchor btnEdit = (HtmlAnchor)e.Item.FindControl("btnEdit");

            string RedirectingLink = "AddEditTest.aspx?" + "tid" + "=" + hfTestCode.Value;

            btnEdit.Attributes.Add("href", RedirectingLink);
        }
    }

    protected void rptTest_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);

            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("XRec_Delete_Test", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@TestCode", e.CommandArgument);
                sqlCommand.Parameters.AddWithValue("@UpdatedByUser", 866);
                sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                Response.Redirect(Request.Path + (Request.QueryString.Count > 0 ? "?" + Request.QueryString : string.Empty), false);
            }

            catch (Exception exp1)
            {
                throw exp1;
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