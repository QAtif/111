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

public partial class Profile_ViewAllProfile : CustomBasePage
{
    #region Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
  
    #endregion

    #region Paging Variables
  
    static DataView objDV = new DataView();
    static string SortDirection = "DESC";
    SecureQueryString sQString = new SecureQueryString();
    PagedDataSource objPDS = new PagedDataSource();
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
            Profile_ViewAllProfile.PageSize = 25;
            GetRequisitionDetail();
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
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(PageNo * Profile_ViewAllProfile.PageSize + (e.Item.ItemIndex + 1));
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnProfileCode");
            string str1 = "AddEditProfile.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("pCode=" + control1.Value);
            string str2 = "UpdateParameterScore.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("pCode=" + control1.Value);
            string str3 = "ViewProfileParameter.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("pCode=" + control1.Value);
            HtmlAnchor control2 = (HtmlAnchor)e.Item.FindControl("aEdit");
            HtmlAnchor control3 = (HtmlAnchor)e.Item.FindControl("aViewParameter");
            HtmlAnchor control4 = (HtmlAnchor)e.Item.FindControl("aUpdateScore");
            control2.Disabled = false;
            control2.Attributes.Add("href", str1);
            control3.Disabled = false;
            control3.Attributes.Add("href", str3);
            control4.Disabled = false;
            control4.Attributes.Add("href", str2);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptProfileLists_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "DeleteProfile"))
            return;
        try
        {
            Convert.ToString(AdminClass.DeleteProfile(e.CommandArgument.ToString(), UserCode, Request.UserHostAddress.ToString()));
            GetRequisitionDetail();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    public void GetRequisitionDetail()
    {
        DataSet allProfile = Common.GetAllProfile();
        if (allProfile.Tables[0].Rows.Count > 0)
        {
            Profile_ViewAllProfile.objDV = allProfile.Tables[0].DefaultView;
            trPagingControls.Attributes.Add("style", "display:''");
            PageNo = 0;
            rptProfileLists.DataSource = ApplyPaging(Profile_ViewAllProfile.objDV, PageNo);
            rptProfileLists.DataBind();
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
        objPDS.PageSize = Profile_ViewAllProfile.PageSize;
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
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewAllProfile.objDV, PageNo);
        rptProfileLists.DataBind();
        ShowHideActions();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewAllProfile.objDV, PageNo);
        rptProfileLists.DataBind();
        ShowHideActions();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewAllProfile.objDV, PageNo);
        rptProfileLists.DataBind();
        ShowHideActions();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewAllProfile.objDV, PageNo);
        rptProfileLists.DataBind();
        ShowHideActions();
    }

    #endregion

}