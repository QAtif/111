using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ErrorLog;
using System.Collections;

public partial class Requisition_MarkShortListCandidate :CustomBasePage
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
            Requisition_MarkShortListCandidate.PageSize = 25;
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

    protected void rptRequisitionLists_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(PageNo * Requisition_MarkShortListCandidate.PageSize + (e.Item.ItemIndex + 1));
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnRequisitionCode");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnProfileCode");
            HtmlAnchor control3 = (HtmlAnchor)e.Item.FindControl("aViewCandidate");
            Label control4 = (Label)e.Item.FindControl("lblQuantity");
            string str = "MarkShortListCandidateDetail.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("PID=" + control2.Value + "&RID=" + control1.Value + "&candCount=" + control4.Text);
            control3.Attributes.Add("href", str);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptRequisitionLists_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
    }

    public void GetRequisitionDetail(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidatesFromMapping", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        Requisition_MarkShortListCandidate.objDV = dataSet.Tables[0].DefaultView;
        trPagingControls.Attributes.Add("style", "display:''");
        PageNo = 0;
        rptRequisitionLists.DataSource = ApplyPaging(Requisition_MarkShortListCandidate.objDV, PageNo);
        rptRequisitionLists.DataBind();
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Requisition_MarkShortListCandidate.PageSize;
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
        rptRequisitionLists.DataSource = ApplyPaging(Requisition_MarkShortListCandidate.objDV, PageNo);
        rptRequisitionLists.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptRequisitionLists.DataSource = ApplyPaging(Requisition_MarkShortListCandidate.objDV, PageNo);
        rptRequisitionLists.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptRequisitionLists.DataSource = ApplyPaging(Requisition_MarkShortListCandidate.objDV, PageNo);
        rptRequisitionLists.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptRequisitionLists.DataSource = ApplyPaging(Requisition_MarkShortListCandidate.objDV, PageNo);
        rptRequisitionLists.DataBind();
    }

    #endregion

}