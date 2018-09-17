
using ErrorLog;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using XRecruitmentStatusLibrary;

public partial class SheduledCandidateReport : CustomBasePage
{
    #region Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    public SecureQueryString sQString = new SecureQueryString();


    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            postedFromDate.Attributes.Add("readonly", "readonly");
            postedFromDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            postedToDate.Attributes.Add("readonly", "readonly");
            postedToDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            bindData();
            bind_rptrptTestSheduled();
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
            HiddenField control = (HiddenField)e.Item.FindControl("hdnCandidateCode");
            ((HtmlControl)e.Item.FindControl("aCandidateLink")).Attributes.Add("href", "../A2/Candidate/CandidateProfile.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + control.Value));
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

    protected void rptTestSheduled_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "Cancel"))
            return;
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateSlotIsActive", connection);
            sqlCommand.Parameters.AddWithValue("@CandidateCode", e.CommandArgument);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            Label control1 = (Label)e.Item.FindControl("lblSchuduleFor");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnCanStatus");
            if (control2.Value == Convert.ToInt32(Constants.CandidateLifeCycleStatus.SchedulingdoneTestPending).ToString())
                StatusManagement.MarkLifeCycleStatus(connection, int.Parse(e.CommandArgument.ToString()), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.TestnotAppearedReSchedulingPending, USERIP, UserCode);
            if (control2.Value == Convert.ToInt32(Constants.CandidateLifeCycleStatus.SchedulingDoneInterviewPending).ToString())
                StatusManagement.MarkLifeCycleStatus(connection, int.Parse(e.CommandArgument.ToString()), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.InterviewnotAppearedReSchedulingPending, USERIP, UserCode);
            if (control2.Value == Convert.ToInt32(Constants.CandidateLifeCycleStatus.OfferSchedulingDoneOfferPending).ToString())
                StatusManagement.MarkLifeCycleStatus(connection, int.Parse(e.CommandArgument.ToString()), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.OfferNotAcceptedReSchedulingPendingOffer, USERIP, UserCode);
            lblMsg.Visible = true;
            lblMsg.Text = "reservation has been cancelled successfully.";
            bind_rptrptTestSheduled();
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
            lblMsg.Visible = false;
            bind_rptrptTestSheduled();
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

    public void bindData()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
        SqlCommand selectCommand = new SqlCommand("dbo.Xrec_SelectBindFilters", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet != null)
        {
            if (dataSet.Tables.Count > 0)
            {
                ddlProfile.DataSource = dataSet.Tables[0];
                ddlProfile.DataTextField = "profile_name";
                ddlProfile.DataValueField = "profile_code";
                ddlProfile.DataBind();
            }
            ddlProfile.Items.Insert(0, new ListItem(" Select Profile ", "0"));
            if (dataSet.Tables.Count > 0)
            {
                ddlDepartment.DataSource = dataSet.Tables[1];
                ddlDepartment.DataTextField = "Domain_Name";
                ddlDepartment.DataValueField = "Domain_Code";
                ddlDepartment.DataBind();
            }
            ddlDepartment.Items.Insert(0, new ListItem(" Select Department ", "0"));
            if (dataSet.Tables[2].Rows.Count > 0)
            {
                ddlRequisition.DataSource = dataSet.Tables[2];
                ddlRequisition.DataTextField = "Requisition_Name";
                ddlRequisition.DataValueField = "Requisition_Code";
                ddlRequisition.DataBind();
            }
            ddlRequisition.Items.Insert(0, new ListItem(" Select Requisition ", "0"));
        }
        if (connection.State == ConnectionState.Closed)
            return;
        connection.Close();
    }

    private void bind_rptrptTestSheduled()
    {
        //Convert.ToInt32(Constants.CandidateLifeCycleStatus.SchedulingdoneTestPending).ToString() + "," + Convert.ToInt32(Constants.CandidateLifeCycleStatus.SchedulingDoneInterviewPending).ToString() + "," + Convert.ToInt32(Constants.CandidateLifeCycleStatus.OfferSchedulingDoneOfferPending).ToString();
        DateTime dateTime1 = Convert.ToDateTime(postedFromDate.Value);
        DateTime dateTime2 = Convert.ToDateTime(postedToDate.Value);
        SqlCommand selectCommand = new SqlCommand("dbo.Xrec_Select_ReservedCandidateDetailNew", connection);
        selectCommand.Parameters.AddWithValue("@UserCode", UserCode);
        selectCommand.Parameters.AddWithValue("@startDate", dateTime1.ToString("yyyy-MM-dd"));
        selectCommand.Parameters.AddWithValue("@endDate", dateTime2.ToString("yyyy-MM-dd"));
        if (!string.IsNullOrEmpty(txtRefNo.Text))
            selectCommand.Parameters.AddWithValue("@Refno", txtRefNo.Text);
        if (ddlProfile.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@ProfileCode", ddlProfile.SelectedValue);
        if (ddlDepartment.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@SubdomainName", ddlDepartment.SelectedItem.Text);
        if (ddlScheduledFor.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@ScheduleFor", ddlScheduledFor.SelectedValue);
        if (ddlRequisition.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@Requisition_Code", ddlRequisition.SelectedValue);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        if (dataTable != null)
        {
            if (dataTable.Rows.Count > 0)
            {
                rptTestSheduled.Visible = true;
                lblemtyMsg.Visible = false;
                rptTestSheduled.DataSource = dataTable;
                rptTestSheduled.DataBind();
            }
            else
            {
                rptTestSheduled.DataSource = null;
                rptTestSheduled.Visible = false;
                lblemtyMsg.Text = "No record(s) found";
                lblemtyMsg.Visible = true;
            }
        }
        else
        {
            rptTestSheduled.DataSource = null;
            rptTestSheduled.Visible = false;
            lblemtyMsg.Text = "No record(s) found";
            lblemtyMsg.Visible = true;
        }
    }

    public static void CreateFolder(string FolderPath)
    {
        string path = HttpContext.Current.Server.MapPath(FolderPath);
        if (new DirectoryInfo(path).Exists)
            return;
        Directory.CreateDirectory(path);
    }
    #endregion

}
