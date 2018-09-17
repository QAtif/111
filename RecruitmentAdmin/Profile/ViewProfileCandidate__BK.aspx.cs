using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Profile_ViewProfileCandidate__BK : System.Web.UI.Page
{

    public static DataView objDV = new DataView();
    public static string SortDirection = "DESC";
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    PagedDataSource objPDS = new PagedDataSource();
    public static int PageSize;

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
            Profile_ViewProfileCandidate__BK.PageSize = 25;
            connection.Open();
            BindData(ref connection);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    private void BindData(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectProfileCriteria", connection);
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
        Profile_ViewProfileCandidate__BK.objDV = dataSet.Tables[0].DefaultView;
        trPagingControls.Attributes.Add("style", "display:''");
        PageNo = 0;
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewProfileCandidate__BK.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    protected void rptProfileLists_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.Item)
            return;
        ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
        HiddenField control1 = (HiddenField)e.Item.FindControl("hdnProfileCode");
        Label control2 = (Label)e.Item.FindControl("lblStatus");
        HtmlTableRow control3 = (HtmlTableRow)e.Item.FindControl("trView");
        ((HtmlAnchor)e.Item.FindControl("aCandDetail")).HRef = "../Candidate/CandidateDetails.aspx?CID=" + DataBinder.Eval(e.Item.DataItem, "Candidate_Code").ToString();
        if (DataBinder.Eval(e.Item.DataItem, "Is_Locked").ToString() == "True" && DataBinder.Eval(e.Item.DataItem, "Requisition_Code").ToString() != "0" && DataBinder.Eval(e.Item.DataItem, "Requisition_Code").ToString() != "")
            control2.Text = "Shortlisted on Requisition <b>" + DataBinder.Eval(e.Item.DataItem, "Requisition_Name").ToString() + "</b>";
        else
            control2.Text = "Mapped";
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Profile_ViewProfileCandidate__BK.PageSize;
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
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewProfileCandidate__BK.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewProfileCandidate__BK.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewProfileCandidate__BK.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewProfileCandidate__BK.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        if (txtCandidateName.Text == "")
            hdnCandidateCode.Value = "-1";
        SqlCommand selectCommand = new SqlCommand("XRec_SelectProfileCandidateDetail", connection);
        if (ddlProfile.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@Profile_Code", ddlProfile.SelectedValue);
        if (ddlRequisition.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@Requisition_Code", ddlRequisition.SelectedValue);
        if (ddlStatus.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@Type", ddlStatus.SelectedValue);
        selectCommand.Parameters.AddWithValue("@Candidate_Code", hdnCandidateCode.Value);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            Profile_ViewProfileCandidate__BK.objDV = dataSet.Tables[0].DefaultView;
            trPagingControls.Attributes.Add("style", "display:''");
            PageNo = 0;
            rptProfileLists.Visible = true;
            lblMsg.Visible = false;
            rptProfileLists.DataSource = ApplyPaging(Profile_ViewProfileCandidate__BK.objDV, PageNo);
            rptProfileLists.DataBind();
        }
        else
        {
            rptProfileLists.DataSource = null;
            rptProfileLists.Visible = false;
            lblMsg.Text = "No Data";
            lblMsg.Visible = true;
        }
    }
}