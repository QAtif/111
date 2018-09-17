using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using ErrorLog;
using System.Data;
using System.Web.UI.HtmlControls;
using XRecruitmentStatusLibrary;
public partial class A2_Reports_MapSkills : CustomBasePage
{
    SecureQueryString sQString = new SecureQueryString();
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            BindMappedSkills();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptInstitute_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        HiddenField control1 = (HiddenField)e.Item.FindControl("hdRefNo");
        ((HtmlAnchor)e.Item.FindControl("a1")).HRef = "../../A2/candidate/CandidateProfile.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + control1.Value);
        HiddenField control2 = (HiddenField)e.Item.FindControl("hdfSkillCode");
        CheckBox control3 = (CheckBox)e.Item.FindControl("chk");
        control3.Attributes.Add("onclick", "CreateCompanyArray(" + control3.ClientID + "," + control2.Value + ")");
    }

    private void BindUnMappedSkills(string SkillName)
    {
        DataTable table = AdminClass.GetUnmappedSkills(SkillName).Tables[0];
        if (table.Rows.Count <= 0)
            return;
        rptInstitute.DataSource = table;
        rptInstitute.DataBind();
    }

    private void BindMappedSkills()
    {
        DataTable table = AdminClass.GetMappedSkills().Tables[0];
        if (table.Rows.Count <= 0)
            return;
        client2View.DataSource = table;
        client2View.DataBind();
    }

    protected void BtnSearchFresh_Click(object sender, EventArgs e)
    {
        string empty = string.Empty;
        int SkillCode = int.Parse(client2View.SelectedValue);
        string UnMappedSkillCode = hdSkill.Value.TrimStart(',');
        try
        {
            AdminClass.UpdateSkillMapping(SkillCode, UnMappedSkillCode, Request.UserHostAddress);
            BindMappedSkills();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void imgInstitute_Click(object sender, ImageClickEventArgs e)
    {
    }

    protected void imgInstitute_Click(object sender, EventArgs e)
    {
        try
        {
            AdminClass.InsertSkillMapping(txtSkill.Text, Request.UserHostAddress, UserCode);
            txtSkill.Text = string.Empty;
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "exists", "alert('Skill Entered Successfully!.');", true);
            BindMappedSkills();
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
        BindUnMappedSkills(txtSearchKeyword.Text.Trim());
    }
}