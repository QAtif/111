using System;
using System.Web.UI.WebControls;
using ErrorLog;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class A2_Reports_UserReferralReport : CustomBasePage, IRequiresSessionState
{
    private SecureQueryString sQString = new SecureQueryString();
    public string UpdatedBy;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            postedFromDate.Value = DateTime.Now.AddMonths(-1).ToString("MMM dd, yyyy");
            postedToDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            UpdatedBy = UserCode.ToString();
            DropDownBind();
            bindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private void DropDownBind()
    {
        DataSet department = Common.GetDepartment(UserCode);
        if (department.Tables[0].Rows.Count > 0)
        {
            ddlDomain.DataSource = department.Tables[0];
            ddlDomain.DataTextField = "Domain_Name";
            ddlDomain.DataValueField = "Dept_ID";
            ddlDomain.DataBind();
            ddlDomain.Items.Insert(0, new ListItem("----All----", "-1"));
        }
        DataSet user = Common.GetUser(-1, UserCode);
        if (user.Tables[0].Rows.Count > 0)
        {
            ddlUser.DataSource = user.Tables[0];
            ddlUser.DataTextField = "Name";
            ddlUser.DataValueField = "UserID";
            ddlUser.DataBind();
            ddlUser.Items.Insert(0, new ListItem("----All----", "-1"));
        }
        DataSet city = Common.GetCity();
        if (city.Tables[0].Rows.Count <= 0)
            return;
        ddlCity.DataSource = city.Tables[0];
        ddlCity.DataTextField = "City";
        ddlCity.DataValueField = "City_Code";
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("----All----", "-1"));
    }

    private void bindData()
    {
        DataTable table = AdminClass.GetReferralCandidates(txtName.Text, txtref.Text, ddlUser.SelectedValue, Convert.ToDateTime(postedFromDate.Value), Convert.ToDateTime(postedToDate.Value), Convert.ToInt32(ddlDomain.SelectedValue), Convert.ToInt32(ddlCity.SelectedValue), UserCode).Tables[0];
        if (table.Rows.Count > 0)
        {
            rptCanddiate.DataSource = table;
            rptCanddiate.DataBind();
            lblError.Style.Add("display", "none");
        }
        else
        {
            rptCanddiate.DataSource = null;
            rptCanddiate.DataBind();
            lblError.Style.Add("display", "");
        }
    }

    protected void rptCanddiate_OnDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnCandCode");
            HtmlAnchor control2 = (HtmlAnchor)e.Item.FindControl("aCandidateLink");
            if (control1 == null)
                return;
            string str = "../../A2/candidate/CandidateProfile.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + control1.Value);
            control2.HRef = str;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindData();
    }

    protected void ddlDomain_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet user = Common.GetUser(Convert.ToInt32(ddlDomain.SelectedValue), UserCode);
        if (user.Tables[0].Rows.Count <= 0)
            return;
        ddlUser.DataSource = user.Tables[0];
        ddlUser.DataTextField = "Name";
        ddlUser.DataValueField = "UserID";
        ddlUser.DataBind();
        ddlUser.Items.Insert(0, new ListItem("----All----", "-1"));
    }
}