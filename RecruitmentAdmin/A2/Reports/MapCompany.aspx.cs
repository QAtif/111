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
using System.Web.SessionState;

public partial class A2_Reports_MapCompany : CustomBasePage, IRequiresSessionState
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

    protected void rptCompany_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        HiddenField control1 = (HiddenField)e.Item.FindControl("hdRefNo");
        ((HtmlAnchor)e.Item.FindControl("a1")).HRef = "../../A2/candidate/CandidateProfile.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + control1.Value);
        HiddenField control2 = (HiddenField)e.Item.FindControl("hdfCompanyCode");
        CheckBox control3 = (CheckBox)e.Item.FindControl("chk");
        control3.Attributes.Add("onclick", "CreateCompanyArray(" + control3.ClientID + "," + control2.Value + ")");
    }

    private void BindUnMappedData()
    {
        DataTable table = AdminClass.GetCompanyNotMapped(txtSearchKeyword.Text.Trim()).Tables[0];
        if (table.Rows.Count <= 0)
            return;
        rptCompany.DataSource = table;
        rptCompany.DataBind();
    }

    private void BindMappedData()
    {
        DataTable dataTable = new DataTable();
        DataTable table = AdminClass.GetCompanyMapped().Tables[0];
        if (table.Rows.Count <= 0)
            return;
        client2View.DataSource = table;
        client2View.DataBind();
    }

    protected void BtnSearchFresh_Click(object sender, EventArgs e)
    {
        string empty = string.Empty;
        int CompanyCode = int.Parse(client2View.SelectedValue);
        string UnMappedCompanyCode = hdCompany.Value.TrimStart(',');
        try
        {
            AdminClass.UpdateCompanyMapping(CompanyCode, UnMappedCompanyCode, Request.UserHostAddress);
            BindUnMappedData();
            BindMappedData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void imgCompany_Click(object sender, ImageClickEventArgs e)
    {
    }

    protected void imgCompany_Click(object sender, EventArgs e)
    {
        string empty = string.Empty;
        try
        {
            string LogoPath = string.Empty;
            if (fuDocument.HasFile)
            {
                string filename = Server.MapPath("/img/icon/Company/") + fuDocument.FileName;
                LogoPath = "/img/icon/Company/" + fuDocument.FileName;
                fuDocument.SaveAs(filename);
            }
            AdminClass.InsertCompanyMapping(txtCompany.Text, LogoPath, Request.UserHostAddress, UserCode);
            txtCompany.Text = string.Empty;
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "exists", "alert('Company Entered Successfully!.');", true);
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
        BindUnMappedData();
    }
}