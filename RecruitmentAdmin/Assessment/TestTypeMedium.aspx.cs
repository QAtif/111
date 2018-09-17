﻿using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using ErrorLog;

public partial class TestTypeMedium : CustomBasePage//XRecBase
{
    #region Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);

    #endregion

    #region Events
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
    }

    protected void rptTestTypeMedium_ItemDataBound(object source, RepeaterItemEventArgs e)
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
            control1.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete this Test Medium?')");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hfTestTypeMediumCode");
            ((HtmlControl)e.Item.FindControl("btnEdit")).Attributes.Add("href", "AddEditTestTypeMedium.aspx?ttmid=" + control2.Value);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptTestTypeMedium_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "Delete"))
            return;
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XRec_Delete_TestTypeMedium", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@TestTypeMediumCode", e.CommandArgument);
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
            SqlCommand selectCommand = new SqlCommand("XRec_Select_TestTypeMedium ", connection);
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
                    UpdatePanel1.Visible = true;
                    rptTestTypeMedium.DataSource = dataTable;
                    rptTestTypeMedium.DataBind();
                }
                else
                {
                    UpdatePanel1.Visible = false;
                    rptTestTypeMedium.DataSource = null;
                    rptTestTypeMedium.DataBind();
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
                rptTestTypeMedium.DataSource = null;
                rptTestTypeMedium.DataBind();
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
    #endregion
}