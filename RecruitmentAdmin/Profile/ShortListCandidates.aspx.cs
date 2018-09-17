using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using XRecruitmentStatusLibrary;
using ErrorLog;
using System.Collections;

public partial class Profile_ShortListCandidates : CustomBasePage
{
    #region Paging Variables
    
     public static DataView objDV = new DataView();
     public static string SortDirection = "DESC";
     SecureQueryString sQString = new SecureQueryString();
     PagedDataSource objPDS = new PagedDataSource();
     SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
     SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
     public static int PageSize;
    #endregion

    #region Event-Handlers

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
            Profile_ShortListCandidates.PageSize = 25;
            connection.Open();
            BindData(ref connection);
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

    protected void rptProfileLists_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.Item)
                return;
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(PageNo * Profile_ShortListCandidates.PageSize + (e.Item.ItemIndex + 1));
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnProfileCode");
            Label control2 = (Label)e.Item.FindControl("lblStatus");
            HtmlTableRow control3 = (HtmlTableRow)e.Item.FindControl("trView");
            ((HtmlAnchor)e.Item.FindControl("aCandDetail")).HRef = "../Candidate/CandidateDetails.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + DataBinder.Eval(e.Item.DataItem, "Candidate_Code").ToString());
            if (DataBinder.Eval(e.Item.DataItem, "Is_Locked").ToString() == "True" && DataBinder.Eval(e.Item.DataItem, "Requisition_Code").ToString() != "0" && DataBinder.Eval(e.Item.DataItem, "Requisition_Code").ToString() != "")
                control2.Text = "Shortlisted on Requisition <b>" + DataBinder.Eval(e.Item.DataItem, "Requisition_Name").ToString() + "</b>";
            else
                control2.Text = "Mapped";
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

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtCandidateName.Text == "")
                hdnCandidateCode.Value = "-1";
            GetData();
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

    protected void lnkLockCandidate_Click(object sender, EventArgs e)
    {
        try
        {
            string str = string.Empty;
            foreach (RepeaterItem repeaterItem in rptProfileLists.Items)
            {
                HtmlInputCheckBox control1 = (HtmlInputCheckBox)repeaterItem.FindControl("chkCandidate");
                HiddenField control2 = (HiddenField)repeaterItem.FindControl("hdnCPM_Code");
                HiddenField control3 = (HiddenField)repeaterItem.FindControl("hdnTestOrInterview");
                if (control1.Checked)
                    str = str + control2.Value + ",";
            }
            if (string.IsNullOrEmpty(str))
                return;
            UpdateSelectedCandidateLockBit(str.TrimEnd(','));
            if (connection.State != ConnectionState.Open)
                connection.Open();
            foreach (RepeaterItem repeaterItem in rptProfileLists.Items)
            {
                HtmlInputCheckBox control1 = (HtmlInputCheckBox)repeaterItem.FindControl("chkCandidate");
                HiddenField control2 = (HiddenField)repeaterItem.FindControl("hdnTestOrInterview");
                HiddenField control3 = (HiddenField)repeaterItem.FindControl("hdnCandCode");
                if (control1.Checked)
                {
                    if (control2.Value.ToLower() == "false")
                        StatusManagement.MarkLifeCycleStatus(connection, int.Parse(control3.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.NoTestSchedulingPendingInterview, Request.UserHostAddress.ToString(), UserCode);
                    else if (control2.Value.ToLower() == "true")
                        StatusManagement.MarkLifeCycleStatus(connection, int.Parse(control3.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.ShortlistedSchedulingPendingTest, Request.UserHostAddress.ToString(), UserCode);
                }
            }
            GetData();
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Saved Successfully!');", true);
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
        IEnumerable<HtmlGenericControl> allControlsOfType = Page.GetAllControlsOfType<HtmlGenericControl>();
        foreach (Control control in allControlsOfType)
        {
            if (control.ClientID.Contains("divAction"))
                control.Visible = false;
        }
        foreach (DataRow row in (InternalDataCollectionBase)DTActions.Rows)
        {
            foreach (Control control in allControlsOfType)
            {
                if (control.ClientID == "divAction" + row["MenuLinkActionCode"].ToString())
                    control.Visible = true;
            }
        }
    }

    private void BindData(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectProfileCriteriaByUser", connection);
        selectCommand.Parameters.AddWithValue("@UserCode", UserCode);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
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

    public void GetRequisitionDetail(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectAllProfile", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        Profile_ShortListCandidates.objDV = dataSet.Tables[0].DefaultView;
        trPagingControls.Attributes.Add("style", "display:''");
        PageNo = 0;
        rptProfileLists.DataSource = ApplyPaging(Profile_ShortListCandidates.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    private void GetData()
    {
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_SelectProfileCandidate", connection);
        if (ddlProfile.SelectedValue != "0")
            selectCommand.Parameters.Add("@Profile_Code", SqlDbType.Int).Value = int.Parse(ddlProfile.SelectedValue);
        if (ddlRequisition.SelectedValue != "0")
            selectCommand.Parameters.Add("@Requisition_Code", SqlDbType.Int).Value = int.Parse(ddlRequisition.SelectedValue);
        selectCommand.Parameters.Add("@Candidate_Code", SqlDbType.Int).Value = int.Parse(hdnCandidateCode.Value);
        selectCommand.Parameters.Add("@ReferenceNo", SqlDbType.VarChar).Value = string.IsNullOrEmpty(txtRefNo.Text) ? "-1" : txtRefNo.Text;
        selectCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = UserCode;
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            Profile_ShortListCandidates.objDV = dataSet.Tables[0].DefaultView;
            trPagingControls.Attributes.Add("style", "display:''");
            PageNo = 0;
            rptProfileLists.Visible = true;
            lblMsg.Visible = false;
            DLock.Style.Add("display", "");
            rptProfileLists.DataSource = ApplyPaging(Profile_ShortListCandidates.objDV, PageNo);
            rptProfileLists.DataBind();
        }
        else
        {
            rptProfileLists.DataSource = null;
            rptProfileLists.Visible = false;
            DLock.Style.Add("display", "none");
            lblMsg.Text = "No Data";
            lblMsg.Visible = true;
        }
        ShowHideActions();
    }

    private void UpdateSelectedCandidateLockBit(string CPMCode)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.XRec_UpdateSelectedCandidateLockBit", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CPM_Codes", SqlDbType.VarChar).Value = CPMCode;
        sqlCommand.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UserCode;
        sqlCommand.Parameters.Add("@UpdationIP", SqlDbType.VarChar).Value = Request.UserHostAddress;
        if (connection.State != ConnectionState.Open)
            connection.Open();
        sqlCommand.ExecuteNonQuery();
        if (connection.State == ConnectionState.Closed)
            return;
        connection.Close();
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Profile_ShortListCandidates.PageSize;
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
        rptProfileLists.DataSource = ApplyPaging(Profile_ShortListCandidates.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptProfileLists.DataSource = ApplyPaging(Profile_ShortListCandidates.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptProfileLists.DataSource = ApplyPaging(Profile_ShortListCandidates.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptProfileLists.DataSource = ApplyPaging(Profile_ShortListCandidates.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    #endregion

}