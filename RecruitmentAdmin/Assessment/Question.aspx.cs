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
using ErrorLog;

public partial class Question : CustomBasePage//XRecBase
{
    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
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

    protected void rptSection_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item)
        {
            if (e.Item.ItemType != ListItemType.AlternatingItem)
                return;
        }
        try
        {
            ImageButton control1 = (ImageButton)e.Item.FindControl("btnDelete");
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
            control1.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete this Section?')");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hfQuestionCode");
            ((HtmlControl)e.Item.FindControl("btnEdit")).Attributes.Add("href", "AddEditQuestion.aspx?qid=" + control2.Value);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptSection_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "Delete"))
            return;
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XRec_Delete_Question", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@QuestionCode", e.CommandArgument);
            selectCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
            selectCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
            new SqlDataAdapter(selectCommand).Fill(new DataTable());
            Response.Redirect(Request.Path + (Request.QueryString.Count > 0 ? "?" + Request.QueryString : string.Empty), false);
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
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand selectCommand = new SqlCommand("XREC_Select_QuestionOption ", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable != null)
            {
                if (dataTable.Rows.Count > 0)
                {
                    lblMsg.Visible = false;
                    tblMsg.Visible = false;
                    lblMsg.Visible = false;
                    rptSection.DataSource = dataTable;
                    rptSection.DataBind();
                }
                else
                {
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
                rptSection.DataSource = null;
                rptSection.DataBind();
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

}