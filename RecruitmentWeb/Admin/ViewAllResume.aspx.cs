using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using ErrorLog;
using System.Configuration;
using Telerik.Web.UI;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;

public partial class Admin_ViewAllResume : System.Web.UI.Page
{
    #region variable
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString = new SecureQueryString();
    static DataView objDV = new DataView();
    static int PageSize;
    PagedDataSource objPDS = new System.Web.UI.WebControls.PagedDataSource();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindOGData();
        }
    }

    private void BindOGData()
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.XRec_SelectProfileCriteriaByUser", connection);
        sqlCommand.Parameters.AddWithValue("@UserCode", "-1");
        sqlCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        DataSet ds = new DataSet();
        adapter.Fill(ds);


        if (ds.Tables[4].Rows.Count > 0)
        {
            ddlCategory.DataSource = ds.Tables[4];
            ddlCategory.DataTextField = "category_name";
            ddlCategory.DataValueField = "Category_code";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("----All----", "0"));
        }

        if (ds.Tables[5].Rows.Count > 0)
        {
            ddlDomain.DataSource = ds.Tables[5];
            ddlDomain.DataTextField = "Domain_Name";
            ddlDomain.DataValueField = "Domain_Code";
            ddlDomain.DataBind();
            ddlDomain.Items.Insert(0, new ListItem("----All----", "0"));
        }

        if (ds.Tables[6].Rows.Count > 0)
        {
            ddlSubDomain.DataSource = ds.Tables[6];
            ddlSubDomain.DataTextField = "SubDomain_Name";
            ddlSubDomain.DataValueField = "SubDomain_Code";
            ddlSubDomain.DataBind();
            ddlSubDomain.Items.Insert(0, new ListItem("----All----", "0"));
        }
    }
 
    public void GetCandidateResume(ref SqlConnection connection)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_Select_AllCandidateResume", connection);


        if (ddlDomain.SelectedValue != "0")
            sqlCommand.Parameters.AddWithValue("@DomainCode", ddlDomain.SelectedValue);

        if (ddlSubDomain.SelectedValue != "0")
            sqlCommand.Parameters.AddWithValue("@SubDomainCode", ddlSubDomain.SelectedValue);

        if (ddlCategory.SelectedValue != "0")
            sqlCommand.Parameters.AddWithValue("@CategoryCode", ddlCategory.SelectedValue);

        sqlCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        DataSet ds = new DataSet();
        adapter.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {

            objDV = ds.Tables[0].DefaultView;
            trPagingControls.Attributes.Add("style", "display:''");
            PageNo = 0;

            rptResume.Visible = true;
            lblMsg.Visible = false;
            rptResume.DataSource = ApplyPaging(objDV, PageNo);
            rptResume.DataBind();

            // trNoData.Visible = false;
            //rptCandidateLists.DataSource = ds.Tables[0];
            //rptCandidateLists.DataBind();
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

    #region Paging
    private int PageNo
    {
        get
        {
            if (ViewState["PageNo"] != null)
                return Convert.ToInt32(ViewState["PageNo"]);
            else
                return 0;
        }
        set
        {
            ViewState["PageNo"] = value;
        }
    }


    public System.Web.UI.WebControls.PagedDataSource ApplyPaging(System.Data.DataView DV, int PageNo)
    {
        objPDS.DataSource = DV;
        objPDS.AllowPaging =
        true;
        //objPDS.PageSize = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["PageSize"]); 
        objPDS.PageSize = PageSize;
        objPDS.CurrentPageIndex = PageNo;
        ViewState["PageCount"] = objPDS.PageCount.ToString();
        if (objPDS.PageCount > 1)
        {
            trPagingControls.Attributes.Add("style", "display:''");
            lblPageIndex.Visible =
            true;
            lblPageIndex.Text = "Page : " + (objPDS.CurrentPageIndex + 1).ToString() + " of " + objPDS.PageCount.ToString();
            if (objPDS.CurrentPageIndex == 0)
            {
                lnkbtnFirstPage.Visible = false;
                lnkbtnLastPage.Visible = true;
                lnkbtnNextPage.Visible = true;
                lnkbtnPrevPage.Visible = false;
            }
            else
                if (objPDS.CurrentPageIndex == (objPDS.PageCount - 1))
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
        {
            //trLegends.Attributes.Add("style", "display:none");
            trPagingControls.Attributes.Add("style", "display:none");
        }
        return objPDS;
    }
    // Takes to the first page 
    protected void lnkbtnFirstPage_Click(object sender, EventArgs e)
    {
        PageNo = 0;
        rptResume.DataSource = ApplyPaging(objDV, PageNo);
        rptResume.DataBind();

    }
    // Takes To The Previous Page 
    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        PageNo--;
        rptResume.DataSource = ApplyPaging(objDV, PageNo);
        rptResume.DataBind();

    }
    // takes to the next page 
    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        PageNo++;
        rptResume.DataSource = ApplyPaging(objDV, PageNo);
        rptResume.DataBind();

    }
    // takes to the last page 
    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo =
        Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptResume.DataSource = ApplyPaging(objDV, PageNo);
        rptResume.DataBind();

    }

    #endregion
    protected void rptResume_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {

            Label lblSno = (Label)e.Item.FindControl("lblSno");
            lblSno.Text = Convert.ToString((PageNo * PageSize) + (e.Item.ItemIndex + 1));
            HtmlAnchor aREsume = (HtmlAnchor)e.Item.FindControl("aREsume");
            HtmlAnchor aSignUp = (HtmlAnchor)e.Item.FindControl("aSignUp");

            aREsume.HRef = DataBinder.Eval(e.Item.DataItem, "Resume_Path").ToString();
            aREsume.Target = "_blank";


            if (DataBinder.Eval(e.Item.DataItem, "Status_Code").ToString() == "1003")
            {
                string qs = secQueryString.encrypt("candcode=" + DataBinder.Eval(e.Item.DataItem, "Candidate_Code").ToString());
                string page = ConfigurationManager.AppSettings["DomainAddress"].ToString() + "signup.aspx?data=" + qs;
                aSignUp.Attributes.Add("onclick", "window.open('" + page + "')");
                aSignUp.Disabled = false;
            }
            else
            {

                aSignUp.Attributes.Remove("onclick");
                aSignUp.Disabled = true;
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetCandidateResume(ref connection);
    }
}