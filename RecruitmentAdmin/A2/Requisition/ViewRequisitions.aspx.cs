using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ErrorLog;
using System.Web.SessionState;




public partial class Requisition_ViewRequisitions : CustomBasePage, IRequiresSessionState
{
    #region Variables

     public static DataView objDV = new DataView();
     public static string SortDirection = "DESC";
     SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
     SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
     SecureQueryString sQString = new SecureQueryString();
     PagedDataSource objPDS = new PagedDataSource();
     public static int PageSize;

    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            Requisition_ViewRequisitions.PageSize = 25;
            BindData();
            GetRequisitionDetail();
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
        foreach (DataRow row in (InternalDataCollectionBase)DTActions.Rows)
        {
            foreach (Control control in Page.GetAllControlsOfType<HtmlGenericControl>())
            {
                if (control.ClientID == "divAction" + row["MenuLinkActionCode"].ToString())
                    control.Visible = true;
            }
        }
    }

    private void BindData()
    {
        DataSet dataSet = Common.FillDropDown(UserCode);
        if (dataSet.Tables[2].Rows.Count > 0)
        {
            ddlCity.DataSource = dataSet.Tables[2];
            ddlCity.DataTextField = "City";
            ddlCity.DataValueField = "City_Code";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("----All----", "0"));
        }
        if (dataSet.Tables[4].Rows.Count > 0)
        {
            ddlCategory.DataSource = dataSet.Tables[4];
            ddlCategory.DataTextField = "category_name";
            ddlCategory.DataValueField = "Category_code";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("----All----", "0"));
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
        DataSet categorySpecialist = AdminClass.GetCategorySpecialist();
        if (categorySpecialist.Tables[0].Rows.Count <= 0)
            return;
        ddlCategorySpecialist.DataSource = categorySpecialist.Tables[0];
        ddlCategorySpecialist.DataTextField = "Name";
        ddlCategorySpecialist.DataValueField = "UserID";
        ddlCategorySpecialist.DataBind();
        ddlCategorySpecialist.Items.Insert(0, new ListItem("----Select----", "-1"));
    }

    protected void rptRequisitionLists_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType != ListItemType.Item)
            ;
    }

    public void GetRequisitionDetail()
    {
        DataSet allRequisition = AdminClass.GetAllRequisition(txtRequisitionName.Text.Trim(), Convert.ToInt32(ddlDomain.SelectedValue), Convert.ToInt32(ddlSubDomain.SelectedValue), Convert.ToInt32(ddlCategory.SelectedValue), Convert.ToInt32(ddlCity.SelectedValue), UserCode, Convert.ToInt32(ddlCategorySpecialist.SelectedValue));
        if (allRequisition.Tables[0].Rows.Count > 0)
        {
            Requisition_ViewRequisitions.objDV = allRequisition.Tables[0].DefaultView;
            rptRequisitionLists.Visible = true;
            lblMsg.Visible = false;
            rptRequisitionLists.DataSource = Requisition_ViewRequisitions.objDV;
            rptRequisitionLists.DataBind();
        }
        else
        {
            rptRequisitionLists.DataSource = null;
            rptRequisitionLists.DataBind();
            rptRequisitionLists.Visible = false;
            lblMsg.Visible = true;
        }
        ShowHideActions();
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        GetRequisitionDetail();
    }

    protected void ddlDomain_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet subdomainByDomainCode = Common.GetSubdomainByDomainCode(Convert.ToInt32(ddlDomain.SelectedValue));
        if (subdomainByDomainCode.Tables[0].Rows.Count > 0)
        {
            ddlSubDomain.DataSource = subdomainByDomainCode.Tables[0];
            ddlSubDomain.DataTextField = "SubDomain_Name";
            ddlSubDomain.DataValueField = "SubDomain_Code";
            ddlSubDomain.DataBind();
            ddlSubDomain.Items.Insert(0, new ListItem("----All----", "0"));
        }
        DataSet categoryByDomainCode = Common.GetCategoryByDomainCode(Convert.ToInt32(ddlDomain.SelectedValue));
        if (categoryByDomainCode.Tables[0].Rows.Count <= 0)
            return;
        ddlCategory.DataSource = categoryByDomainCode.Tables[0];
        ddlCategory.DataTextField = "category_name";
        ddlCategory.DataValueField = "Category_code";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("----All----", "0"));
    }

}