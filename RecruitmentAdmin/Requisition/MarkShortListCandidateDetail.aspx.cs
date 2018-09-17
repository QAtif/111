using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ErrorLog;



public partial class Requisition_MarkShortListCandidateDetail : CustomBasePage
{
   
    #region Paging Variables
    public static DataView objDV = new DataView();
    public static string SortDirection = "DESC";
    public string ProfileCode = "0";
    public string RequisitionCode = "0";
    public string CandCount = "0";
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    PagedDataSource objPDS = new PagedDataSource();
    public string QueryStringVar = string.Empty;
    public static int PageSize;
    public SecureQueryString secQueryString;
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
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            secQueryString = new SecureQueryString(QueryStringVar);
            Requisition_MarkShortListCandidateDetail.PageSize = 25;
            CheckQueryString();
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            int num = 0;
            foreach (Control control in rptRequisitionLists.Items)
            {
                if (((CheckBox)control.FindControl("chk")).Checked)
                    ++num;
            }
            if (num == 0)
            {
                lblError.Visible = true;
                lblError.Text = "Please Select Atleast One.";
            }
            else if (num <= Convert.ToInt32(hdnCount.Value))
            {
                lblError.Visible = false;
                foreach (RepeaterItem repeaterItem in rptRequisitionLists.Items)
                {
                    CheckBox control1 = (CheckBox)repeaterItem.FindControl("chk");
                    HiddenField control2 = (HiddenField)repeaterItem.FindControl("hdnCandidateCode");
                    HiddenField control3 = (HiddenField)repeaterItem.FindControl("hdnProfileCode");
                    if (control1.Checked)
                    {
                        SqlCommand sqlCommand = new SqlCommand("XRec_UpdateLockedCandidate", connection);
                        sqlCommand.Parameters.AddWithValue("@Candidate_Code", control2.Value);
                        sqlCommand.Parameters.AddWithValue("@Profile_Code", control3.Value);
                        sqlCommand.Parameters.AddWithValue("@Requisition_Code", hdnRequisitionCode.Value);
                        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
                        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.ExecuteScalar();
                    }
                }
                Page.RegisterStartupScript("Close", "<script language=JavaScript> CloseHighSlideWithParentRefresh();</script>");
            }
            else
            {
                if (num <= Convert.ToInt32(hdnCount.Value))
                    return;
                lblError.Visible = true;
                lblError.Text = "Number of Candidates Can't Exceed From Required Count!";
            }
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
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
            HiddenField control = (HiddenField)e.Item.FindControl("hdnCandidateCode");
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
        SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidatesByProfileCode", connection);
        selectCommand.Parameters.AddWithValue("@Profile_Code", hdnProfileCode.Value);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            Requisition_MarkShortListCandidateDetail.objDV = dataSet.Tables[0].DefaultView;
            trPagingControls.Attributes.Add("style", "display:''");
            PageNo = 0;
            lblMsg.Visible = false;
            rptRequisitionLists.Visible = true;
            btnSave.Visible = true;
            rptRequisitionLists.DataSource = ApplyPaging(Requisition_MarkShortListCandidateDetail.objDV, PageNo);
            rptRequisitionLists.DataBind();
        }
        else
        {
            rptRequisitionLists.Visible = false;
            lblMsg.Visible = true;
            btnSave.Visible = false;
            lblMsg.Text = "No Data";
        }
    }

    private void CheckQueryString()
    {
        if (secQueryString["PID"] == null || secQueryString["RID"] == null)
            return;
        ProfileCode = secQueryString["PID"].ToString();
        hdnProfileCode.Value = secQueryString["PID"].ToString();
        RequisitionCode = secQueryString["RID"].ToString();
        hdnRequisitionCode.Value = secQueryString["RID"].ToString();
        CandCount = secQueryString["candCount"].ToString();
        hdnCount.Value = secQueryString["candCount"].ToString();
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (System.Collections.IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Requisition_MarkShortListCandidateDetail.PageSize;
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
        rptRequisitionLists.DataSource = ApplyPaging(Requisition_MarkShortListCandidateDetail.objDV, PageNo);
        rptRequisitionLists.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptRequisitionLists.DataSource = ApplyPaging(Requisition_MarkShortListCandidateDetail.objDV, PageNo);
        rptRequisitionLists.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptRequisitionLists.DataSource = ApplyPaging(Requisition_MarkShortListCandidateDetail.objDV, PageNo);
        rptRequisitionLists.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptRequisitionLists.DataSource = ApplyPaging(Requisition_MarkShortListCandidateDetail.objDV, PageNo);
        rptRequisitionLists.DataBind();
    }

    #endregion

}