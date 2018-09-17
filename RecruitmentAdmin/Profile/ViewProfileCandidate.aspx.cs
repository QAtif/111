using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using XRecruitmentStatusLibrary;
using ErrorLog;
using System.Collections;

public partial class Profile_ViewProfileCandidate : CustomBasePage
{
    #region Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());


    public static DataView objDV = new DataView();
    public static string SortDirection = "DESC";
    PagedDataSource objPDS = new PagedDataSource();
    SecureQueryString sQString = new SecureQueryString();
    public static int PageSize;

    #endregion

    #region Events
    private int PageNo
    {
        get
        {
            if (ViewState["PageNo"] != null)
                return Convert.ToInt32(ViewState["PageNo"]);
            return 0;
        }
        set
        {
            ViewState["PageNo"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            Profile_ViewProfileCandidate.PageSize = 25;
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtCandidateName.Text == "")
                hdnCandidateCode.Value = "-1";
            DataSet profileCandidateDetail = AdminClass.GetProfileCandidateDetail(Convert.ToInt32(ddlProfile.SelectedValue), Convert.ToInt32(ddlRequisition.SelectedValue), Convert.ToInt32(ddlStatus.SelectedValue), Convert.ToInt32(hdnCandidateCode.Value), UserCode);
            if (profileCandidateDetail.Tables[0].Rows.Count > 0)
            {
                Profile_ViewProfileCandidate.objDV = profileCandidateDetail.Tables[0].DefaultView;
                trPagingControls.Attributes.Add("style", "display:''");
                PageNo = 0;
                rptProfileLists.Visible = true;
                lblMsg.Visible = false;
                rptProfileLists.DataSource = ApplyPaging(Profile_ViewProfileCandidate.objDV, PageNo);
                rptProfileLists.DataBind();
            }
            else
            {
                rptProfileLists.DataSource = null;
                rptProfileLists.Visible = false;
                lblMsg.Text = "No Data";
                lblMsg.Visible = true;
            }
            ShowHideActions();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptProfileLists_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnProfileCode");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnStatus_Code");
            Label control3 = (Label)e.Item.FindControl("lblStatus");
            HtmlTableRow control4 = (HtmlTableRow)e.Item.FindControl("trView");
            HtmlAnchor control5 = (HtmlAnchor)e.Item.FindControl("aCandDetail");
            HtmlTableCell control6 = (HtmlTableCell)e.Item.FindControl("tdAction");
            HtmlAnchor control7 = (HtmlAnchor)e.Item.FindControl("AReserve");
            if (DataBinder.Eval(e.Item.DataItem, "Is_Locked").ToString() == "True" && (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Status_Code").ToString()) == Convert.ToInt32(Constants.CandidateLifeCycleStatus.ShortlistedSchedulingPendingTest) || Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Status_Code").ToString()) == Convert.ToInt32(Constants.CandidateLifeCycleStatus.TestFailedReSchedulingPendingTest) || (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Status_Code").ToString()) == Convert.ToInt32(Constants.CandidateLifeCycleStatus.TestnotAppearedReSchedulingPending) || Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Status_Code").ToString()) == Convert.ToInt32(Constants.CandidateLifeCycleStatus.TestPassedSchedulingPendingInterview)) || (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Status_Code").ToString()) == Convert.ToInt32(Constants.CandidateLifeCycleStatus.InterviewnotAppearedReSchedulingPending) || Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Status_Code").ToString()) == Convert.ToInt32(Constants.CandidateLifeCycleStatus.InterviewFailedReSchedulingPending) || (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Status_Code").ToString()) == Convert.ToInt32(Constants.CandidateLifeCycleStatus.NoTestSchedulingPendingInterview) || Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Status_Code").ToString()) == Convert.ToInt32(Constants.CandidateLifeCycleStatus.OfferNotAcceptedReSchedulingPendingOffer))) || (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Status_Code").ToString()) == Convert.ToInt32(Constants.CandidateLifeCycleStatus.OfferAcceptedVerificationSchedulingPending) || Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Status_Code").ToString()) == Convert.ToInt32(Constants.CandidateLifeCycleStatus.OfferGeneratedSchedulingPending) || Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Status_Code").ToString()) == Convert.ToInt32(Constants.CandidateLifeCycleStatus.VerificationDoneAppointmentSchedulingPending))))
            {
                control7.HRef = "../schedule/SchduleCandidate.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("refno=" + DataBinder.Eval(e.Item.DataItem, "Candidate_ID").ToString());
            }
            else
            {
                control7.InnerHtml = "-";
                control7.HRef = "";
                control7.Attributes.Add("class", "");
            }
            control5.HRef = "../Candidate/CandidateDetails.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + DataBinder.Eval(e.Item.DataItem, "Candidate_Code").ToString());
            if (DataBinder.Eval(e.Item.DataItem, "Is_Locked").ToString() == "True" && DataBinder.Eval(e.Item.DataItem, "Requisition_Code").ToString() != "0" && DataBinder.Eval(e.Item.DataItem, "Requisition_Code").ToString() != "")
                control3.Text = "Shortlisted on Requisition <b>" + DataBinder.Eval(e.Item.DataItem, "Requisition_Name").ToString() + "</b>";
            else
                control3.Text = "Mapped";
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private void ShowHideActions()
    {
        if (DTActions.Rows.Count <= 0)
            return;
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

    private void BindData()
    {
        DataSet dataSet = Common.FillDropDown(UserCode);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            ddlProfile.DataSource = dataSet.Tables[0];
            ddlProfile.DataTextField = "Profile_Name";
            ddlProfile.DataValueField = "Profile_Code";
            ddlProfile.DataBind();
            ddlProfile.Items.Insert(0, new ListItem("----All----", "0"));
        }
        if (dataSet.Tables[1].Rows.Count <= 0)
            return;
        ddlRequisition.DataSource = dataSet.Tables[1];
        ddlRequisition.DataTextField = "Requisition_Name";
        ddlRequisition.DataValueField = "Requisition_Code";
        ddlRequisition.DataBind();
        ddlRequisition.Items.Insert(0, new ListItem("----All----", "0"));
    }

    public void GetRequisitionDetail()
    {
        DataSet allProfile = Common.GetAllProfile();
        if (allProfile.Tables[0].Rows.Count <= 0)
            return;
        Profile_ViewProfileCandidate.objDV = allProfile.Tables[0].DefaultView;
        trPagingControls.Attributes.Add("style", "display:''");
        PageNo = 0;
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewProfileCandidate.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Profile_ViewProfileCandidate.PageSize;
        objPDS.CurrentPageIndex = PageNo;
        ViewState["PageCount"] = objPDS.PageCount.ToString();
        if (objPDS.PageCount > 1)
        {
            trPagingControls.Attributes.Add("style", "display:''");
            lblPageIndex.Visible = true;
            lblPageIndex.Text = "Page : " + (objPDS.CurrentPageIndex + 1).ToString() + " of " + objPDS.PageCount.ToString();
            if (objPDS.CurrentPageIndex == 0)
            {
                lnkbtnFirstPage.Visible = false;
                lnkbtnLastPage.Visible = true;
                lnkbtnNextPage.Visible = true;
                lnkbtnPrevPage.Visible = false;
            }
            else if (objPDS.CurrentPageIndex == objPDS.PageCount - 1)
            {
                lnkbtnFirstPage.Visible = true;
                lnkbtnLastPage.Visible = false;
                lnkbtnNextPage.Visible = false;
                lnkbtnPrevPage.Visible = true;
            }
            else
            {
                lnkbtnFirstPage.Visible = true;
                lnkbtnLastPage.Visible = true;
                lnkbtnNextPage.Visible = true;
                lnkbtnPrevPage.Visible = true;
            }
        }
        else
            trPagingControls.Attributes.Add("style", "display:none");
        return objPDS;
    }

    protected void lnkbtnFirstPage_Click(object sender, EventArgs e)
    {
        PageNo = 0;
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewProfileCandidate.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewProfileCandidate.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewProfileCandidate.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewProfileCandidate.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    #endregion


}