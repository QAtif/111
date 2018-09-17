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
using System.Collections;

public partial class ResultPending : CustomBasePage
{
    #region Paging Variables
    SecureQueryString sQString = new SecureQueryString();
    static DataView objDV = new DataView();
    static int PageSize;
    static string SortDirection = "DESC";
    PagedDataSource objPDS = new System.Web.UI.WebControls.PagedDataSource();
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
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
            ResultPending.PageSize = 25;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            BindData();
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

    protected void rptCandidateLists_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnCandidateCode");
            string str1 = "../assessment/checktest.aspx?cid=" + control1.Value;
            ((HtmlAnchor)e.Item.FindControl("aCheckTest")).HRef = str1;
            HtmlAnchor control2 = (HtmlAnchor)e.Item.FindControl("a1");
            if (control1 == null)
                return;
            string str2 = "../../A2/candidate/CandidateProfile.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + control1.Value);
            control2.HRef = str2;
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
        if (!IsValid)
            return;
        try
        {
            GetCandidateDetail();
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

    private void BindData()
    {
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_Select_Allrequisition", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            ddlrequisition.DataSource = dataSet.Tables[0];
            ddlrequisition.DataTextField = "Requisition_Name";
            ddlrequisition.DataValueField = "Requisition_Code";
            ddlrequisition.DataBind();
            ddlrequisition.Items.Insert(0, new ListItem("----All----", "0"));
        }
        if (dataSet.Tables[1].Rows.Count <= 0)
            return;
        ddlDepartment.DataSource = dataSet.Tables[1];
        ddlDepartment.DataTextField = "SubDomain_Name";
        ddlDepartment.DataValueField = "SubDomain_Code";
        ddlDepartment.DataBind();
        ddlDepartment.Items.Insert(0, new ListItem("----All----", "0"));
    }

    public void GetCandidateDetail()
    {
        SqlCommand selectCommand = new SqlCommand("dbo.Xrec_Select_TestDoneCandidate", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        if (!string.IsNullOrEmpty(txtCandidateName.Text))
            selectCommand.Parameters.Add("@CandidateName", SqlDbType.VarChar).Value = txtCandidateName.Text;
        if (!string.IsNullOrEmpty(txtRefNo.Text))
            selectCommand.Parameters.AddWithValue("@ReferenceNo", txtRefNo.Text);
        if (ddlrequisition.SelectedIndex != 0)
            selectCommand.Parameters.AddWithValue("@requisitionCode", ddlrequisition.SelectedValue);
        if (!string.IsNullOrEmpty(txtEmail.Text))
            selectCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
        if (!string.IsNullOrEmpty(txtNIC.Text))
            selectCommand.Parameters.AddWithValue("@nic", txtNIC.Text);
        if (ddlDepartment.SelectedIndex != 0)
            selectCommand.Parameters.AddWithValue("@departmentCode", ddlDepartment.SelectedValue);
        DataTable dataTable = new DataTable();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables.Count == 0)
            return;
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            DataTable table = dataSet.Tables[0];
            rptCandidateLists.Visible = true;
            lblMsg.Visible = false;
            ResultPending.objDV = table.DefaultView;
            trPagingControls.Attributes.Add("style", "display:''");
            PageNo = 0;
            rptCandidateLists.DataSource = ApplyPaging(ResultPending.objDV, PageNo);
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

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = ResultPending.PageSize;
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
        rptCandidateLists.DataSource = ApplyPaging(ResultPending.objDV, PageNo);
        rptCandidateLists.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptCandidateLists.DataSource = ApplyPaging(ResultPending.objDV, PageNo);
        rptCandidateLists.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptCandidateLists.DataSource = ApplyPaging(ResultPending.objDV, PageNo);
        rptCandidateLists.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptCandidateLists.DataSource = ApplyPaging(ResultPending.objDV, PageNo);
        rptCandidateLists.DataBind();
    }

    #endregion


}