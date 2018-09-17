using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ErrorLog;
using System.Collections;

public partial class Requisition_ViewRequisition : CustomBasePage
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
            Requisition_ViewRequisition.PageSize = 25;
            BindData();
            connection.Open();
            GetRequisitionDetail(ref connection);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
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
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_SelectProfileCriteriaByUser", connection);
        selectCommand.Parameters.AddWithValue("@UserCode", UserCode);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
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
        if (dataSet.Tables[6].Rows.Count <= 0)
            return;
        ddlSubDomain.DataSource = dataSet.Tables[6];
        ddlSubDomain.DataTextField = "SubDomain_Name";
        ddlSubDomain.DataValueField = "SubDomain_Code";
        ddlSubDomain.DataBind();
        ddlSubDomain.Items.Insert(0, new ListItem("----All----", "0"));
    }

    protected void rptRequisitionLists_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(PageNo * Requisition_ViewRequisition.PageSize + (e.Item.ItemIndex + 1));
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnRequisitionCode");
            string str = "UpdateRequisitionStatus.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("RID=" + control1.Value);
            HtmlAnchor control2 = (HtmlAnchor)e.Item.FindControl("aEdit");
            ((HtmlControl)e.Item.FindControl("aStatus")).Attributes.Add("href", str);
            control2.Disabled = false;
            control2.Attributes.Add("href", str);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptRequisitionLists_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "Delete"))
            return;
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XRec_DeleteRequisition", connection);
            sqlCommand.Parameters.AddWithValue("@Requisition_Code", e.CommandArgument.ToString());
            sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
            sqlCommand.Parameters.AddWithValue("@Updated_IP", USERIP);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            Convert.ToString(sqlCommand.ExecuteScalar());
            GetRequisitionDetail(ref connection);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    public void GetRequisitionDetail(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectAllRequisition", connection);
        if (!string.IsNullOrEmpty(txtRequisitionName.Text))
            selectCommand.Parameters.AddWithValue("@RequisitionName", txtRequisitionName.Text.Trim());
        if (ddlDomain.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@DomainCode", ddlDomain.SelectedValue);
        if (ddlSubDomain.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@SubDomainCode", ddlSubDomain.SelectedValue);
        if (ddlCategory.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@CategoryCode", ddlCategory.SelectedValue);
        if (ddlCity.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@CityCode", ddlCity.SelectedValue);
        selectCommand.Parameters.AddWithValue("@UserCode", UserCode);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            Requisition_ViewRequisition.objDV = dataSet.Tables[0].DefaultView;
            rptRequisitionLists.Visible = true;
            lblMsg.Visible = false;
            rptRequisitionLists.DataSource = Requisition_ViewRequisition.objDV;
            rptRequisitionLists.DataBind();
        }
        else
        {
            trPagingControls.Attributes.Add("style", "display:none");
            rptRequisitionLists.DataSource = null;
            rptRequisitionLists.DataBind();
            rptRequisitionLists.Visible = false;
            lblMsg.Visible = true;
        }
        ShowHideActions();
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Requisition_ViewRequisition.PageSize;
        objPDS.CurrentPageIndex = PageNo;
        ViewState["PageCount"] = objPDS.PageCount.ToString();
        if (objPDS.PageCount > 1)
        {
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
        rptRequisitionLists.DataSource = ApplyPaging(Requisition_ViewRequisition.objDV, PageNo);
        rptRequisitionLists.DataBind();
        ShowHideActions();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptRequisitionLists.DataSource = ApplyPaging(Requisition_ViewRequisition.objDV, PageNo);
        rptRequisitionLists.DataBind();
        ShowHideActions();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptRequisitionLists.DataSource = ApplyPaging(Requisition_ViewRequisition.objDV, PageNo);
        rptRequisitionLists.DataBind();
        ShowHideActions();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptRequisitionLists.DataSource = ApplyPaging(Requisition_ViewRequisition.objDV, PageNo);
        rptRequisitionLists.DataBind();
        ShowHideActions();
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        GetRequisitionDetail(ref connection);
    }



}