using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ErrorLog;
using System.Web.Services;
using System.Collections;

public partial class Reports_CandidateCommunicationReport : CustomBasePage
{
    #region Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    #endregion

    #region Paging Variables
    static DataView objDV = new DataView();     
    static int PageSize;
    static string SortDirection = "DESC";
    SecureQueryString sQString = new SecureQueryString();
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
            Reports_CandidateCommunicationReport.PageSize = 25;
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
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(PageNo * Reports_CandidateCommunicationReport.PageSize + (e.Item.ItemIndex + 1));
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnCandidateCode");
            string str = "../Candidate/CandidateDetails.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + control1.Value);
            ((HtmlControl)e.Item.FindControl("aView")).Attributes.Add("href", str);
            HtmlAnchor control2 = (HtmlAnchor)e.Item.FindControl("aMarkArrive");
            HtmlAnchor control3 = (HtmlAnchor)e.Item.FindControl("aUnmarkArrive");
            control2.Attributes.Add("onclick", "javascript:;UpdateCandidateQuery(" + DataBinder.Eval(e.Item.DataItem, "CandidateCommunication_Code").ToString() + ",1,'" + control2.ClientID + "','" + control3.ClientID + "')");
            control3.Attributes.Add("onclick", "javascript:;UpdateCandidateQuery(" + DataBinder.Eval(e.Item.DataItem, "CandidateCommunication_Code").ToString() + ",0,'" + control2.ClientID + "','" + control3.ClientID + "')");
            if (Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "Is_Solved").ToString()))
            {
                control2.Style["display"] = "none";
                control3.Style["display"] = "";
            }
            else
            {
                control2.Style["display"] = "";
                control3.Style["display"] = "none";
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    public void GetRequisitionDetail(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateQuery", connection);
        if (!string.IsNullOrEmpty(txtCandidateName.Text))
            selectCommand.Parameters.AddWithValue("@CandidateName", txtCandidateName.Text.Trim());
        selectCommand.Parameters.AddWithValue("@Is_Solved", ddlStatus.SelectedValue);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            Reports_CandidateCommunicationReport.objDV = dataSet.Tables[0].DefaultView;
            trPagingControls.Attributes.Add("style", "display:''");
            PageNo = 0;
            rptRequisitionLists.Visible = true;
            lblMsg.Visible = false;
            rptRequisitionLists.DataSource = ApplyPaging(Reports_CandidateCommunicationReport.objDV, PageNo);
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
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Reports_CandidateCommunicationReport.PageSize;
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
        rptRequisitionLists.DataSource = ApplyPaging(Reports_CandidateCommunicationReport.objDV, PageNo);
        rptRequisitionLists.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptRequisitionLists.DataSource = ApplyPaging(Reports_CandidateCommunicationReport.objDV, PageNo);
        rptRequisitionLists.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptRequisitionLists.DataSource = ApplyPaging(Reports_CandidateCommunicationReport.objDV, PageNo);
        rptRequisitionLists.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptRequisitionLists.DataSource = ApplyPaging(Reports_CandidateCommunicationReport.objDV, PageNo);
        rptRequisitionLists.DataBind();
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        GetRequisitionDetail(ref connection);
    }

    [WebMethod]
    public static void UpdateCandidateQuery(string items)
    {
        string[] strArray1 = new string[0];
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
            string[] strArray2 = items.Split('|');
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XREC_UpdateCandidateQuery", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@CandidateCommunication_Code", strArray2[0].ToString());
            sqlCommand.Parameters.AddWithValue("@Type", strArray2[1].ToString());
            sqlCommand.ExecuteScalar();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
        }
    }

    #endregion

}