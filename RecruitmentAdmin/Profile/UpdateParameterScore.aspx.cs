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
using ErrorLog;
using System.Collections;

public partial class Profile_UpdateParameterScore : CustomBasePage
{
    #region Variables
  
    static DataView objDV = new DataView();
    static string SortDirection = "DESC";
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    public string QueryStringVar = string.Empty;
    public string ProfileCode = "0";
    public PagedDataSource objPDS = new PagedDataSource();
    public SecureQueryString secQueryString;
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
        QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
        secQueryString = new SecureQueryString(QueryStringVar);
        try
        {
            Profile_UpdateParameterScore.PageSize = 25;
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            foreach (RepeaterItem repeaterItem in rptParameter.Items)
            {
                HiddenField control1 = (HiddenField)repeaterItem.FindControl("hdnProfileParameterScoreCode");
                TextBox control2 = (TextBox)repeaterItem.FindControl("txtRank");
                if (control2.Text == "")
                    control2.Text = "0";
                SqlCommand sqlCommand = new SqlCommand("XRec_UpdateProfileParameterScore", connection);
                sqlCommand.Parameters.AddWithValue("@ProfileParameterScore_Code", control1.Value);
                sqlCommand.Parameters.AddWithValue("@Rank", control2.Text);
                sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
                sqlCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Convert.ToString(sqlCommand.ExecuteScalar());
            }
            SqlCommand sqlCommand1 = new SqlCommand("XRec_UpdateProfileParameterScoreByRank", connection);
            sqlCommand1.Parameters.AddWithValue("@Profile_Code", hdnProfileCode.Value);
            sqlCommand1.Parameters.AddWithValue("@Updated_By", UserCode);
            sqlCommand1.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            Convert.ToString(sqlCommand1.ExecuteScalar());
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
        Page.RegisterStartupScript("Close", "<script language=JavaScript> CloseHighSlideWithParentRefresh();</script>");
    }

    protected void rptParameter_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.Item)
                return;
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
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

    protected void rptParameter_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int num = e.CommandName == "UpdateScore" ? 1 : 0;
    }

    private void CheckQueryString()
    {
        if (secQueryString["pCode"] == null)
            return;
        ProfileCode = secQueryString["pCode"].ToString();
        hdnProfileCode.Value = secQueryString["pCode"].ToString();
    }

    public void GetRequisitionDetail(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectProfileParameterScoreByCode", connection);
        selectCommand.Parameters.AddWithValue("@Profile_Code", hdnProfileCode.Value);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            Profile_UpdateParameterScore.objDV = dataSet.Tables[0].DefaultView;
            trPagingControls.Attributes.Add("style", "display:''");
            PageNo = 0;
            btnUpdate.Visible = true;
            rptParameter.Visible = true;
            lblMsg.Visible = false;
            rptParameter.DataSource = ApplyPaging(Profile_UpdateParameterScore.objDV, PageNo);
            rptParameter.DataBind();
        }
        else
        {
            btnUpdate.Visible = false;
            rptParameter.Visible = false;
            lblMsg.Visible = true;
            lblMsg.Text = "No Data";
        }
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Profile_UpdateParameterScore.PageSize;
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
        rptParameter.DataSource = ApplyPaging(Profile_UpdateParameterScore.objDV, PageNo);
        rptParameter.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptParameter.DataSource = ApplyPaging(Profile_UpdateParameterScore.objDV, PageNo);
        rptParameter.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptParameter.DataSource = ApplyPaging(Profile_UpdateParameterScore.objDV, PageNo);
        rptParameter.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptParameter.DataSource = ApplyPaging(Profile_UpdateParameterScore.objDV, PageNo);
        rptParameter.DataBind();
    }
    #endregion

}