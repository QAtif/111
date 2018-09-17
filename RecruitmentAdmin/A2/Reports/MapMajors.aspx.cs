﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using ErrorLog;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;

public partial class A2_Reports_MapMajors : CustomBasePage, IRequiresSessionState
{
    SecureQueryString sQString = new SecureQueryString();
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            BindMappedmajors();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptMajor_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        HiddenField control1 = (HiddenField)e.Item.FindControl("hdRefNo");
        ((HtmlAnchor)e.Item.FindControl("a1")).HRef = "../../A2/candidate/CandidateProfile.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + control1.Value);
        HiddenField control2 = (HiddenField)e.Item.FindControl("hdfMajorCode");
        CheckBox control3 = (CheckBox)e.Item.FindControl("chk");
        control3.Attributes.Add("onclick", "CreateCompanyArray(" + control3.ClientID + "," + control2.Value + ")");
    }

    private void BindUnMappedMajors()
    {
        DataTable table = AdminClass.GetUnmappedMajors(txtSearchKeyword.Text.Trim()).Tables[0];
        if (table.Rows.Count <= 0)
            return;
        rptMajor.DataSource = table;
        rptMajor.DataBind();
    }

    protected void BindMappedmajors()
    {
        DataTable table = AdminClass.GetMappedMajors().Tables[0];
        if (table.Rows.Count <= 0)
            return;
        client2View.DataSource = table;
        client2View.DataBind();
    }

    protected void BtnSearchFresh_Click(object sender, EventArgs e)
    {
        string empty = string.Empty;
        int MajorCode = int.Parse(client2View.SelectedValue);
        string UnMappedMajorCode = hdMajor.Value.TrimStart(',');
        try
        {
            AdminClass.UpdateMajorsMapping(MajorCode, UnMappedMajorCode, Request.UserHostAddress);
            BindMappedmajors();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void imgMajor_Click(object sender, EventArgs e)
    {
        try
        {
            AdminClass.InsertMajorsMapping(txtMajor.Text, Request.UserHostAddress, UserCode);
            txtMajor.Text = string.Empty;
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "exists", "alert('Major Entered Successfully!.');", true);
            BindMappedmajors();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void txtSearchKeyword_TextChanged(object sender, EventArgs e)
    {
        if (txtSearchKeyword.Text.Trim().Length < 3)
            return;
        BindUnMappedMajors();
    }
}