using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.HtmlControls;
using XRecruitmentStatusLibrary;

public partial class Candidate_ViewSignupResume : CustomBasePage
{
    #region variable
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString = new SecureQueryString();
    static DataView objDV = new DataView();
    static int PageSize;
    PagedDataSource objPDS = new System.Web.UI.WebControls.PagedDataSource();

    #endregion

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
        Candidate_ViewSignupResume.PageSize = 25;
        BindOGData();
    }

    private void BindOGData()
    {
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_SelectProfileCriteriaByUser", connection);
        selectCommand.Parameters.AddWithValue("@UserCode", "-1");
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
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

    public void GetCandidateResume(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_Select_AllCandidateResume", connection);
        if (ddlDomain.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@DomainCode", ddlDomain.SelectedValue);
        if (ddlSubDomain.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@SubDomainCode", ddlSubDomain.SelectedValue);
        if (ddlCategory.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@CategoryCode", ddlCategory.SelectedValue);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            Candidate_ViewSignupResume.objDV = dataSet.Tables[0].DefaultView;
            trPagingControls.Attributes.Add("style", "display:''");
            PageNo = 0;
            rptResume.Visible = true;
            lblMsg.Visible = false;
            rptResume.DataSource = ApplyPaging(Candidate_ViewSignupResume.objDV, PageNo);
            rptResume.DataBind();
        }
        else
        {
            trPagingControls.Attributes.Add("style", "display:none");
            rptResume.DataSource = null;
            rptResume.DataBind();
            rptResume.Visible = false;
            lblMsg.Visible = true;
        }
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Candidate_ViewSignupResume.PageSize;
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
        rptResume.DataSource = ApplyPaging(Candidate_ViewSignupResume.objDV, PageNo);
        rptResume.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptResume.DataSource = ApplyPaging(Candidate_ViewSignupResume.objDV, PageNo);
        rptResume.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptResume.DataSource = ApplyPaging(Candidate_ViewSignupResume.objDV, PageNo);
        rptResume.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptResume.DataSource = ApplyPaging(Candidate_ViewSignupResume.objDV, PageNo);
        rptResume.DataBind();
    }

    protected void rptResume_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.Item)
            return;
        ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(PageNo * Candidate_ViewSignupResume.PageSize + (e.Item.ItemIndex + 1));
        HtmlAnchor control1 = (HtmlAnchor)e.Item.FindControl("aREsume");
        HtmlAnchor control2 = (HtmlAnchor)e.Item.FindControl("aSignUp");
        control1.HRef = DataBinder.Eval(e.Item.DataItem, "Resume_Path").ToString();
        control1.Target = "_blank";
        string serializedQueryString = "candidate_code=" + DataBinder.Eval(e.Item.DataItem, "Candidate_Code").ToString() + "&url=" + ConfigurationManager.AppSettings["WebDomainAddress"].ToString() + "Signup.aspx&utc=" + Convert.ToInt32(Constants.UserTypeCode.Admin) + "&auc=" + UserCode.ToString();
        string str = ConfigurationManager.AppSettings["WebDomainAddress"].ToString() + "AdminRedirector.aspx?" + SecureQueryString.QueryStringVar + "=" + secQueryString.encrypt(serializedQueryString);
        if (DataBinder.Eval(e.Item.DataItem, "Status_Code").ToString() == "1003")
        {
            secQueryString.encrypt("candcode=" + DataBinder.Eval(e.Item.DataItem, "Candidate_Code").ToString());
            control2.Attributes.Add("onclick", "window.open('" + str + "')");
            control2.Disabled = false;
        }
        else
        {
            control2.Attributes.Remove("onclick");
            control2.Disabled = true;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetCandidateResume(ref connection);
    }
}