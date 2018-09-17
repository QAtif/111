using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using ErrorLog;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;

public partial class A2_Reports_MapInstitute : CustomBasePage, IRequiresSessionState
{
    SecureQueryString sQString = new SecureQueryString();
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
 
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            BindMappedData();
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
        HiddenField control2 = (HiddenField)e.Item.FindControl("hdfInstituteCode");
        CheckBox control3 = (CheckBox)e.Item.FindControl("chk");
        control3.Attributes.Add("onclick", "CreateCompanyArray(" + control3.ClientID + "," + control2.Value + ")");
    }

    private void BindUnMappedData(string InstituteName)
    {
        DataTable table = AdminClass.GetMappedInstitute().Tables[0];
        if (table.Rows.Count <= 0)
            return;
        rptInstitute.DataSource = table;
        rptInstitute.DataBind();
    }

    private void BindMappedData()
    {
        DataTable table = AdminClass.GetMappedInstitute().Tables[0];
        if (table.Rows.Count <= 0)
            return;
        client2View.DataSource = table;
        client2View.DataBind();
    }

    protected void BtnSearchFresh_Click(object sender, EventArgs e)
    {
        string empty = string.Empty;
        int InstituteCode = int.Parse(client2View.SelectedValue);
        string UnMappedInstituteCode = hdInstitute.Value.TrimStart(',');
        try
        {
            AdminClass.UpdateInstituteMapping(InstituteCode, UnMappedInstituteCode, Request.UserHostAddress);
            BindMappedData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void imgInstitute_Click(object sender, EventArgs e)
    {
        string empty = string.Empty;
        try
        {
            string LogoPath = string.Empty;
            if (fuDocument.HasFile)
            {
                string filename = Server.MapPath("/img/icon/institute/") + fuDocument.FileName;
                LogoPath = "/img/icon/institute/" + fuDocument.FileName;
                fuDocument.SaveAs(filename);
            }
            AdminClass.InsertInstituteMapping(txtInstitute.Text, LogoPath, Request.UserHostAddress, UserCode);
            txtInstitute.Text = string.Empty;
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "exists", "alert('Institute Entered Successfully!.');", true);
            BindMappedData();
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
        BindUnMappedData(txtSearchKeyword.Text.Trim());
    }
}