using System;
using System.Web.UI.WebControls;
using ErrorLog;
using System.Data;
using System.Web.SessionState;



public partial class A2_Reports_UserReferralLink : CustomBasePage, IRequiresSessionState
{
    public string UpdatedBy;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            DropDownBind();
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private void DropDownBind()
    {
        DataSet department = Common.GetDepartment(UserCode);
        if (department.Tables[0].Rows.Count <= 0)
            return;
        ddlDomain.DataSource = department.Tables[0];
        ddlDomain.DataTextField = "Domain_Name";
        ddlDomain.DataValueField = "Dept_ID";
        ddlDomain.DataBind();
        ddlDomain.Items.Insert(0, new ListItem("----All----", "-1"));
    }

    private void BindData()
    {
        DataSet userReferralDetail = AdminClass.GetUserReferralDetail(Convert.ToInt32(ddlDomain.SelectedValue), txtUserID.Text, txtUserName.Text, UserCode);
        if (userReferralDetail == null)
            return;
        if (userReferralDetail.Tables[0].Rows.Count > 0)
        {
            rptUserReferral.DataSource = userReferralDetail.Tables[0];
            rptUserReferral.DataBind();
            lblError.Visible = false;
        }
        else
        {
            rptUserReferral.DataSource = null;
            rptUserReferral.DataBind();
            lblError.Visible = true;
        }
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }
}