using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ErrorLog;
using System.Collections;

public partial class Leads_xprotectdownloadreport : CustomBasePage
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
            postedFromDate.Attributes.Add("readonly", "readonly");
            postedFromDate.Value = "Aug 13, 2013";
            postedToDate.Attributes.Add("readonly", "readonly");
            postedToDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            Leads_xprotectdownloadreport.PageSize = 25;
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

    public void BindData(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_XProtect_SelectDownloadUserDataForAdmin", connection);
        if (!string.IsNullOrEmpty(txtName.Text))
            selectCommand.Parameters.AddWithValue("@name", txtName.Text.Trim());
        if (!string.IsNullOrEmpty(txtEmail.Text))
            selectCommand.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
        if (!string.IsNullOrEmpty(txtCountry.Text))
            selectCommand.Parameters.AddWithValue("@Counrty", txtCountry.Text.Trim());
        selectCommand.Parameters.AddWithValue("@FromDate", postedFromDate.Value);
        selectCommand.Parameters.AddWithValue("@ToDate", postedToDate.Value);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            Leads_xprotectdownloadreport.objDV = dataSet.Tables[0].DefaultView;
            trPagingControls.Attributes.Add("style", "display:''");
            PageNo = 0;
            rptData.Visible = true;
            lblMsg.Visible = false;
            rptData.DataSource = ApplyPaging(Leads_xprotectdownloadreport.objDV, PageNo);
            rptData.DataBind();
            lblTotalCount.Text = "Total Count: " + dataSet.Tables[0].Rows.Count.ToString();
            lblTotalCount.Visible = true;
        }
        else
        {
            trPagingControls.Attributes.Add("style", "display:none");
            rptData.DataSource = null;
            rptData.DataBind();
            rptData.Visible = false;
            lblMsg.Visible = true;
            lblTotalCount.Visible = false;
        }
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Leads_xprotectdownloadreport.PageSize;
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
        rptData.DataSource = ApplyPaging(Leads_xprotectdownloadreport.objDV, PageNo);
        rptData.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptData.DataSource = ApplyPaging(Leads_xprotectdownloadreport.objDV, PageNo);
        rptData.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptData.DataSource = ApplyPaging(Leads_xprotectdownloadreport.objDV, PageNo);
        rptData.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptData.DataSource = ApplyPaging(Leads_xprotectdownloadreport.objDV, PageNo);
        rptData.DataBind();
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        BindData(ref connection);
    }

    #endregion
}