using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using XRecruitmentStatusLibrary;
using ErrorLog;

public partial class TestDoneReport : CustomBasePage
{
    #region Paging Variables
    static DataView objDV = new DataView();
    static int PageSize;
    static string SortDirection = "DESC";
    PagedDataSource objPDS = new System.Web.UI.WebControls.PagedDataSource();
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    #endregion
    #region Event-Handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            try
            {
                PageSize = 25;
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                BindData();

            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }
    }
    protected void rptCandidateLists_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            try
            {
                HiddenField hdnCandidateCode = (HiddenField)e.Item.FindControl("hdnCandidateCode");
                string RedirectingLink = "../assessment/checktest.aspx?" + "cid" + "=" + hdnCandidateCode.Value;
                HtmlAnchor aCheckTest = (HtmlAnchor)e.Item.FindControl("aCheckTest");
                aCheckTest.HRef = RedirectingLink;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }
    }
    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            try
            {
                if (txtCandidateName.Text == "")
                    hdnCandidateCode.Value = "-1";

                GetCandidateDetail();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }
    }
    #endregion
    #region Methods
    private void BindData()
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Select_Allrequisition", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        DataSet ds = new DataSet();
        adapter.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlrequisition.DataSource = ds;
            ddlrequisition.DataTextField = "Requisition_Name";
            ddlrequisition.DataValueField = "Requisition_Code";
            ddlrequisition.DataBind();
            ddlrequisition.Items.Insert(0, new ListItem("----All----", "0"));
        }

    }



    public void GetCandidateDetail()
    {

        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Select_TestDoneCandidate", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        if (!string.IsNullOrEmpty(txtCandidateName.Text))
            sqlCommand.Parameters.Add("@CandidateName", SqlDbType.VarChar).Value = txtCandidateName.Text;
        if (!string.IsNullOrEmpty(txtRefNo.Text))
        sqlCommand.Parameters.AddWithValue("@ReferenceNo", txtRefNo.Text);
        if(ddlrequisition.SelectedIndex!=0)
            sqlCommand.Parameters.AddWithValue("@requisitionCode", ddlrequisition.SelectedValue);




        DataTable dt = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        DataSet ds = new DataSet();
        adapter.Fill(ds);
        if (ds.Tables.Count == 0)
            return;
        if (ds.Tables[0].Rows.Count > 0)
        {
            dt = ds.Tables[0];
            rptCandidateLists.Visible = true;
            lblMsg.Visible = false;
            objDV = dt.DefaultView;
            trPagingControls.Attributes.Add("style", "display:''");
            PageNo = 0;

            rptCandidateLists.DataSource = ApplyPaging(objDV, PageNo);
            rptCandidateLists.DataBind();

        }
        else
        {
            trPagingControls.Attributes.Add("style", "display:none");
            rptCandidateLists.DataSource = null;
            rptCandidateLists.Visible = false;
            lblMsg.Text = "No record(s) found";
            lblMsg.Visible = true;
        }
    }
    #endregion
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
        rptCandidateLists.DataSource = ApplyPaging(objDV, PageNo);
        rptCandidateLists.DataBind();
    }
    // Takes To The Previous Page 
    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        PageNo--;
        rptCandidateLists.DataSource = ApplyPaging(objDV, PageNo);
        rptCandidateLists.DataBind();
    }
    // takes to the next page 
    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        PageNo++;
        rptCandidateLists.DataSource = ApplyPaging(objDV, PageNo);
        rptCandidateLists.DataBind();
    }
    // takes to the last page 
    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo =
        Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptCandidateLists.DataSource = ApplyPaging(objDV, PageNo);
        rptCandidateLists.DataBind();
    }

    #endregion


}