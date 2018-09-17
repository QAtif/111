
using ErrorLog;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections;


public partial class LinkMgmt_ViewLinks : CustomBasePage
{
    #region Varaibles
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    #endregion

    #region Paging Variables
    static DataView objDV = new DataView();
    static int PageSize;    
    static string SortDirection = "DESC";
    PagedDataSource objPDS = new System.Web.UI.WebControls.PagedDataSource();
    SecureQueryString sQString = new SecureQueryString();
    #endregion

    #region Events

    private int PageNo
    {
        get
        {
            if (this.ViewState["PageNo"] != null)
                return Convert.ToInt32(this.ViewState["PageNo"]);
            return 0;
        }
        set
        {
            this.ViewState["PageNo"] = (object)value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            LinkMgmt_ViewLinks.PageSize = 25;
            connection.Open();
            GetLinkDetail(ref connection);
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

    protected void rptLink_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            Repeater control1 = (Repeater)e.Item.FindControl("rptLinkChild");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnLinkCode");
            HtmlAnchor control3 = (HtmlAnchor)e.Item.FindControl("aEdit");
            HtmlTableRow control4 = (HtmlTableRow)e.Item.FindControl("tr");
            HtmlAnchor control5 = (HtmlAnchor)e.Item.FindControl("aAdd");
            control3.HRef = "AddEditLinkCategory.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("LinkID=" + control2.Value);
            control5.HRef = "AddEditLink.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("ParentID=" + control2.Value);
            SqlCommand selectCommand = new SqlCommand("XRec_SelectChildMenuLink", connection);
            selectCommand.Parameters.AddWithValue("@ParentCode", control2.Value);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                control4.Visible = true;
                control1.DataSource = dataSet;
                control1.DataBind();
            }
            else
                control4.Visible = false;
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

    protected void rptLinkChild_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            HtmlAnchor control1 = (HtmlAnchor)e.Item.FindControl("aEdit");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnLinkCode");
            HtmlAnchor control3 = (HtmlAnchor)e.Item.FindControl("aMarkMenuAction");
            control1.HRef = "AddEditLink.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("LinkID=" + control2.Value);
            control3.HRef = "AddLinkAction.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("MenuLinkCode=" + control2.Value + "&Heading=" + DataBinder.Eval(e.Item.DataItem, "MenuLinkName").ToString() + " (" + DataBinder.Eval(e.Item.DataItem, "URL").ToString() + ")");
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

    protected void rptLinkChild_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "Delete"))
            return;
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XRec_DeleteLinkCategory", connection);
            sqlCommand.Parameters.AddWithValue("@MenuLinkID", e.CommandArgument.ToString());
            sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
            sqlCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            Convert.ToString(sqlCommand.ExecuteScalar());
            GetLinkDetail(ref connection);
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

    protected void rptLink_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "Delete"))
            return;
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XRec_DeleteLinkCategory", connection);
            sqlCommand.Parameters.AddWithValue("@MenuLinkID", e.CommandArgument.ToString());
            sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
            sqlCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            Convert.ToString(sqlCommand.ExecuteScalar());
            GetLinkDetail(ref connection);
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

    public void GetLinkDetail(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectParentMenuLink", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        LinkMgmt_ViewLinks.objDV = dataSet.Tables[0].DefaultView;
        trPagingControls.Attributes.Add("style", "display:''");
        PageNo = 0;
        rptLink.DataSource = ApplyPaging(LinkMgmt_ViewLinks.objDV, PageNo);
        rptLink.DataBind();
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = LinkMgmt_ViewLinks.PageSize;
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
        rptLink.DataSource = ApplyPaging(LinkMgmt_ViewLinks.objDV, PageNo);
        rptLink.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptLink.DataSource = ApplyPaging(LinkMgmt_ViewLinks.objDV, PageNo);
        rptLink.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptLink.DataSource = ApplyPaging(LinkMgmt_ViewLinks.objDV, PageNo);
        rptLink.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptLink.DataSource = ApplyPaging(LinkMgmt_ViewLinks.objDV, PageNo);
        rptLink.DataBind();
    }

    #endregion


}


