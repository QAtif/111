using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ErrorLog;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using XRecruitmentStatusLibrary;

public partial class A2_Requisition_UpdateRequisition : CustomBasePage, IRequiresSessionState
{

    public string UserCode1 = string.Empty;
    public string UserTypeCode = string.Empty;
    public string updateByIP = string.Empty;
    public string CategoryCode = string.Empty;
    public string DeptCode = string.Empty;
    SecureQueryString secQuery = new SecureQueryString();
    DataSet DSCategSpecialist;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            updateByIP = USERIP;
            UserCode1 = UserCode.ToString();
            CategoryCode = secQuery.decrypt(HttpContext.Current.Request["CatCode"]);
            DeptCode = secQuery.decrypt(HttpContext.Current.Request["DepCode"]);
            DataBind();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private new void DataBind()
    {
        DSCategSpecialist = AdminClass.GetCategorySpecialist();
        DataSet categoriesOnDepartment = AdminClass.GetCategoriesOnDepartment(Convert.ToInt32(DeptCode), Convert.ToInt32(CategoryCode));
        if (categoriesOnDepartment.Tables.Count >= 2)
        {
            if (categoriesOnDepartment.Tables[1].Rows.Count > 0 && rptRequisitions != null)
            {
                rptRequisitions.Visible = true;
                rptRequisitions.DataSource = categoriesOnDepartment.Tables[1];
                rptRequisitions.DataBind();
                lblMsg.Visible = false;
            }
            else
            {
                rptRequisitions.DataSource = null;
                rptRequisitions.DataBind();
                rptRequisitions.Visible = false;
                lblMsg.Visible = true;
            }
        }
        ShowHideActions();
    }

    private void ShowHideActions()
    {
        IEnumerable<HtmlGenericControl> allControlsOfType = Page.GetAllControlsOfType<HtmlGenericControl>();
        foreach (DataRow row in (InternalDataCollectionBase)DTActions.Rows)
        {
            foreach (Control control in allControlsOfType)
            {
                if (control.ClientID == "divAction" + row["MenuLinkActionCode"].ToString())
                    control.Visible = true;
            }
        }
    }

    protected void rptRequisitions_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnRR");
            Label control2 = (Label)e.Item.FindControl("lbltest");
            DropDownList control3 = (DropDownList)e.Item.FindControl("ddlCategorySpecialist");
            if (e.CommandName == "ApprovedDO")
                UpdateRequisitionStatus(int.Parse(control1.Value), Convert.ToInt32(Constants.RequisitionStatus.HRDOApprovalPending), e.CommandArgument.ToString(), control3.SelectedValue);
            if (e.CommandName == "ApprovedHrDo")
                UpdateRequisitionStatus(int.Parse(control1.Value), Convert.ToInt32(Constants.RequisitionStatus.OPDApprovalPending), e.CommandArgument.ToString(), control3.SelectedValue);
            if (e.CommandName == "ApprovedOPD")
            {
                UpdateRequisitionStatus(int.Parse(control1.Value), Convert.ToInt32(Constants.RequisitionStatus.OPDApprove), e.CommandArgument.ToString(), control3.SelectedValue);
                ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "refreshParent();", true);
            }
            if (e.CommandName == "RejectedDO")
                UpdateRequisitionStatus(int.Parse(control1.Value), Convert.ToInt32(Constants.RequisitionStatus.DORejected), e.CommandArgument.ToString(), control3.SelectedValue);
            if (e.CommandName == "RejectedHrDo")
                UpdateRequisitionStatus(int.Parse(control1.Value), Convert.ToInt32(Constants.RequisitionStatus.HRDOReject), e.CommandArgument.ToString(), control3.SelectedValue);
            if (!(e.CommandName == "RejectedOPD"))
                return;
            UpdateRequisitionStatus(int.Parse(control1.Value), Convert.ToInt32(Constants.RequisitionStatus.OPDReject), e.CommandArgument.ToString(), control3.SelectedValue);
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "refreshParent();", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private void UpdateRequisitionStatus(int categoryCode, int requisitionStatusCode, string RequisitionCode, string CategorySpecialist)
    {
        try
        {
            AdminClass.UpdateRequisitionStatus(categoryCode, Convert.ToInt32(RequisitionCode), UserCode, UserTypeCode, Convert.ToInt32(requisitionStatusCode), UserCode, USERIP, CategorySpecialist);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        Page.RegisterStartupScript("Close", "<script language=JavaScript> CloseHighSlideWithParentRefresh();</script>");
    }

    protected void rptRequisitions_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        DropDownList control = (DropDownList)e.Item.FindControl("ddlCategorySpecialist");
        if (DSCategSpecialist.Tables[0].Rows.Count <= 0)
            return;
        control.DataSource = DSCategSpecialist.Tables[0];
        control.DataTextField = "Name";
        control.DataValueField = "UserID";
        control.DataBind();
        control.Items.Insert(0, new ListItem("----Select----", "-1"));
        if (DataBinder.Eval(e.Item.DataItem, "CategorySpecialist").ToString() != null)
            control.SelectedValue = DataBinder.Eval(e.Item.DataItem, "CategorySpecialist").ToString();
        if (!(DataBinder.Eval(e.Item.DataItem, "RequisitionStatusCode").ToString() != "50"))
            return;
        control.Enabled = false;
    }
}