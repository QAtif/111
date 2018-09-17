using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ErrorLog;
using XRecruitmentStatusLibrary;

public partial class ViewRequisition : CustomBasePage
{
    #region variables

    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    SecureQueryString sQString = new SecureQueryString();
    public string ProfileCode = string.Empty;
    public string UserTypeCode = string.Empty;

    #endregion


    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["PC"] != null)
                ProfileCode = Request.QueryString["PC"].ToString();
            if (Request.QueryString["UTC"] != null)
                UserTypeCode = Request.QueryString["UTC"].ToString();
            if (IsPostBack)
                return;
            BindData();
            ShowHideActions();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptCategoryList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            connection.Open();
            HiddenField control = (HiddenField)e.Item.FindControl("hdnRR");
            if (e.CommandName == "ApprovedDO")
                UpdateRequisitionStatus(int.Parse(control.Value), Convert.ToInt32(Constants.RequisitionStatus.HRDOApprovalPending), e.CommandArgument.ToString());
            if (e.CommandName == "ApprovedHrDo")
                UpdateRequisitionStatus(int.Parse(control.Value), Convert.ToInt32(Constants.RequisitionStatus.OPDApprovalPending), e.CommandArgument.ToString());
            if (e.CommandName == "ApprovedOPD")
            {
                UpdateRequisitionStatus(int.Parse(control.Value), Convert.ToInt32(Constants.RequisitionStatus.OPDApprove), e.CommandArgument.ToString());
                ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "refreshParent();", true);
            }
            if (e.CommandName == "RejectedDO")
                UpdateRequisitionStatus(int.Parse(control.Value), Convert.ToInt32(Constants.RequisitionStatus.DORejected), e.CommandArgument.ToString());
            if (e.CommandName == "RejectedHrDo")
                UpdateRequisitionStatus(int.Parse(control.Value), Convert.ToInt32(Constants.RequisitionStatus.HRDOReject), e.CommandArgument.ToString());
            if (e.CommandName == "RejectedOPD")
            {
                UpdateRequisitionStatus(int.Parse(control.Value), Convert.ToInt32(Constants.RequisitionStatus.OPDReject), e.CommandArgument.ToString());
                ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "refreshParent();", true);
            }
            BindData();
            ShowHideActions();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    protected void rptCategoryList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.Item)
                return;
            ((HtmlControl)e.Item.FindControl("aApprove")).Attributes.Add("href", "/ViewRequisition.aspx?PC=70&UTC=9");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private void UpdateRequisitionStatus(int categoryCode, int requisitionStatusCode, string RequisitionCode)
    {
        SqlCommand sqlCommand = new SqlCommand("UPdate_RequisitonStatusWise", connection);
        sqlCommand.Parameters.AddWithValue("@CategoryCode", categoryCode);
        sqlCommand.Parameters.AddWithValue("@RequisitionCode", RequisitionCode);
        sqlCommand.Parameters.AddWithValue("@UserCode", UserCode);
        sqlCommand.Parameters.AddWithValue("@UserTypeCode", UserTypeCode);
        sqlCommand.Parameters.AddWithValue("@RequisitionStatusCode", requisitionStatusCode);
        sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
        sqlCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.ExecuteNonQuery();
    }

    private void BindData()
    {
        if (string.IsNullOrEmpty(ProfileCode))
            return;
        SqlCommand selectCommand = new SqlCommand("Select_RequisitionCategoryWise", connection);
        selectCommand.Parameters.AddWithValue("@ProfileCode", ProfileCode);
        selectCommand.Parameters.AddWithValue("@userCodeType", UserTypeCode);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            rptCategoryList.DataSource = null;
            rptCategoryList.DataBind();
            rptCategoryList.DataSource = dataSet.Tables[0];
            rptCategoryList.DataBind();
            trnorecords.Visible = false;
        }
        else
        {
            rptCategoryList.DataSource = null;
            rptCategoryList.DataBind();
            trnorecords.Visible = true;
        }
    }

    private void ShowHideActions()
    {
        IEnumerable<HtmlGenericControl> allControlsOfType = Page.GetAllControlsOfType<HtmlGenericControl>();
        foreach (DataRow row in (InternalDataCollectionBase)DTActions.Rows)
        {
            foreach (Control control in allControlsOfType)
            {
                if (control.ClientID == "divAction" + row["MenuLinkActionCode"].ToString())
                    control.Visible = true;
            }
        }
    }
    #endregion


}