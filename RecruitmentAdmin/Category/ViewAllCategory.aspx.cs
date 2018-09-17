using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ErrorLog;
using System.Collections;

public partial class Category_ViewAllCategory : CustomBasePage
{
    #region variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    #endregion

    #region Paging Variables
    
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
            Category_ViewAllCategory.PageSize = 25;
            BindData();
            GetRequisitionDetail();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
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
        if (dataSet.Tables[5].Rows.Count > 0)
        {
            ddlDomain.DataSource = dataSet.Tables[5];
            ddlDomain.DataTextField = "Domain_Name";
            ddlDomain.DataValueField = "Domain_Code";
            ddlDomain.DataBind();
            ddlDomain.Items.Insert(0, new ListItem("----All----", "0"));
        }
        if (dataSet.Tables[6].Rows.Count > 0)
        {
            ddlSubDomain.DataSource = dataSet.Tables[6];
            ddlSubDomain.DataTextField = "SubDomain_Name";
            ddlSubDomain.DataValueField = "SubDomain_Code";
            ddlSubDomain.DataBind();
            ddlSubDomain.Items.Insert(0, new ListItem("----All----", "0"));
        }
        DataSet bonusType = Common.GetBonusType();
        if (bonusType.Tables.Count >= 2 && bonusType.Tables[1].Rows.Count > 0)
        {
            ddlUserCategory.DataSource = bonusType.Tables[1];
            ddlUserCategory.DataTextField = "name";
            ddlUserCategory.DataValueField = "code";
            ddlUserCategory.DataBind();
            ddlUserCategory.Items.Insert(0, new ListItem("----All----", "0"));
        }
        DataSet jobRole = Common.GetJobRole();
        if (jobRole.Tables[0].Rows.Count <= 0)
            return;
        ddlJobRole.DataSource = jobRole.Tables[0];
        ddlJobRole.DataTextField = "JobRole";
        ddlJobRole.DataValueField = "JobRoleCode";
        ddlJobRole.DataBind();
        ddlJobRole.Items.Insert(0, new ListItem("----All----", "0"));
    }

    protected void ddlDomain_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (!(ddlDomain.SelectedValue != ""))
                return;
            DataSet subdomainByDomainCode = Common.GetSubdomainByDomainCode(Convert.ToInt32(ddlDomain.SelectedValue));
            if (subdomainByDomainCode.Tables[0].Rows.Count <= 0)
                return;
            ddlSubDomain.DataSource = subdomainByDomainCode;
            ddlSubDomain.DataTextField = "SubDomain_Name";
            ddlSubDomain.DataValueField = "SubDomain_Code";
            ddlSubDomain.DataBind();
            ddlSubDomain.Items.Insert(0, new ListItem("--All--", "0"));
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "Browse Resume");
        }
    }

    protected void rptCategoryLists_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(PageNo * Category_ViewAllCategory.PageSize + (e.Item.ItemIndex + 1));
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnCategoryCode");
            string str = "AddEditCategory.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("cCode=" + control1.Value);
            HtmlAnchor control2 = (HtmlAnchor)e.Item.FindControl("aEdit");
            control2.Disabled = false;
            control2.Attributes.Add("href", str);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptCategoryLists_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "Delete"))
            return;
        try
        {
            AdminClass.DeleteCategory(e.CommandArgument.ToString(), UserCode, Request.UserHostAddress.ToString());
            GetRequisitionDetail();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        GetRequisitionDetail();
    }

    public void GetRequisitionDetail()
    {
        DataSet requisitionDetail = AdminClass.GetRequisitionDetail(txtCategoryName.Text.Trim(), Convert.ToInt32(ddlDomain.SelectedValue), Convert.ToInt32(ddlSubDomain.SelectedValue), Convert.ToInt32(ddlProfile.SelectedValue), UserCode, Convert.ToInt32(ddlUserCategory.SelectedValue), Convert.ToInt32(ddlJobRole.SelectedValue));
        if (requisitionDetail.Tables[0].Rows.Count > 0)
        {
            rptCategoryLists.Visible = true;
            lblMsg.Visible = false;
            rptCategoryLists.DataSource = requisitionDetail.Tables[0];
            rptCategoryLists.DataBind();
        }
        else
        {
            rptCategoryLists.DataSource = null;
            rptCategoryLists.DataBind();
            rptCategoryLists.Visible = false;
            lblMsg.Visible = true;
        }
        ShowHideActions();
    }

    private void ShowHideActions()
    {
        if (DTActions.Rows.Count <= 0)
            return;
        foreach (DataRow row in (InternalDataCollectionBase)DTActions.Rows)
        {
            foreach (Control control in Page.GetAllControlsOfType<HtmlGenericControl>())
            {
                if (control.ClientID == "divAction" + row["MenuLinkActionCode"].ToString())
                    control.Visible = true;
            }
        }
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Category_ViewAllCategory.PageSize;
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
        rptCategoryLists.DataSource = ApplyPaging(Category_ViewAllCategory.objDV, PageNo);
        rptCategoryLists.DataBind();
        ShowHideActions();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptCategoryLists.DataSource = ApplyPaging(Category_ViewAllCategory.objDV, PageNo);
        rptCategoryLists.DataBind();
        ShowHideActions();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptCategoryLists.DataSource = ApplyPaging(Category_ViewAllCategory.objDV, PageNo);
        rptCategoryLists.DataBind();
        ShowHideActions();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptCategoryLists.DataSource = ApplyPaging(Category_ViewAllCategory.objDV, PageNo);
        rptCategoryLists.DataBind();
        ShowHideActions();
    }


    #endregion

}