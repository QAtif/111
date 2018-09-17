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
using ErrorLog;
using System.Collections;

public partial class Profile_ViewUnMappedCandidate : CustomBasePage
{
    #region variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    SecureQueryString sQString = new SecureQueryString();
    #endregion

    #region Paging Variables
    static DataView objDV = new DataView();
    static int PageSize;
    static string SortDirection = "DESC";
    PagedDataSource objPDS = new System.Web.UI.WebControls.PagedDataSource();
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
            Profile_ViewUnMappedCandidate.PageSize = 25;
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
            string SkillCSV = string.Empty;
            foreach (ListItem listItem in chkSkills.Items)
            {
                if (listItem.Selected)
                    SkillCSV = SkillCSV + listItem.Value + ",";
            }
            if (SkillCSV != string.Empty)
                SkillCSV = SkillCSV.Substring(0, SkillCSV.Length - 1);
            DataSet unmappedCandidate = AdminClass.GetUnmappedCandidate(txtCandidateName.Text, txtEmail.Text.Trim(), txtNIC.Text.Trim(), txtPhone.Text.Trim(), Convert.ToInt32(ddlCity.SelectedValue), SkillCSV);
            if (unmappedCandidate.Tables[0].Rows.Count > 0)
            {
                Profile_ViewUnMappedCandidate.objDV = unmappedCandidate.Tables[0].DefaultView;
                trPagingControls.Attributes.Add("style", "display:''");
                PageNo = 0;
                rptProfileLists.Visible = true;
                lblMsg.Visible = false;
                rptProfileLists.DataSource = ApplyPaging(Profile_ViewUnMappedCandidate.objDV, PageNo);
                rptProfileLists.DataBind();
            }
            else
            {
                rptProfileLists.DataSource = null;
                rptProfileLists.Visible = false;
                lblMsg.Text = "No Data";
                lblMsg.Visible = true;
                trPagingControls.Attributes.Add("style", "display:none");
            }
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
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(PageNo * Profile_ViewUnMappedCandidate.PageSize + (e.Item.ItemIndex + 1));
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnProfileCode");
            Label control2 = (Label)e.Item.FindControl("lblStatus");
            HtmlTableRow control3 = (HtmlTableRow)e.Item.FindControl("trView");
            ((HtmlAnchor)e.Item.FindControl("aCand")).HRef = "../Candidate/CandidateDetails.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + DataBinder.Eval(e.Item.DataItem, "Candidate_Code").ToString());
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void btnAddSkill_Click(object sender, EventArgs e)
    {
        try
        {
            chkSkills.Items.Add(new ListItem(hfSkillName.Value.ToString(), hfSkillCode.Value.ToString())
            {
                Selected = true
            });
            hfSkillCode.Value = (string)null;
            hfSkillName.Value = (string)null;
            txtacSkill.Text = "";
            txtacSkill.Focus();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Session["CC"].ToString());
        }
    }

    private void BindData()
    {
        DataSet profileCriteria = Common.GetProfileCriteria();
        if (profileCriteria.Tables[2].Rows.Count <= 0)
            return;
        ddlCity.DataSource = profileCriteria.Tables[2];
        ddlCity.DataTextField = "City";
        ddlCity.DataValueField = "City_Code";
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("----All----", "0"));
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Profile_ViewUnMappedCandidate.PageSize;
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
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewUnMappedCandidate.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewUnMappedCandidate.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewUnMappedCandidate.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewUnMappedCandidate.objDV, PageNo);
        rptProfileLists.DataBind();
    }
    #endregion


}