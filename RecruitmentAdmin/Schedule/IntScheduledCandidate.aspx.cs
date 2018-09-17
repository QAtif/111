
using ASP;
using ErrorLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using XRecruitmentStatusLibrary;

public partial class IntScheduledCandidate : CustomBasePage
{
    #region Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    SecureQueryString sQString = new SecureQueryString();
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
            LinkButton control1 = (LinkButton)e.Item.FindControl("lnkCancel");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnCandidateCode");
            HtmlAnchor control3 = (HtmlAnchor)e.Item.FindControl("aCandidateLink");
            string str = "~/Candidate/CandidateDetails.aspx?CID=" + control2.Value;
            Label control4 = (Label)e.Item.FindControl("lblSchuduleFor");
            HiddenField control5 = (HiddenField)e.Item.FindControl("hdnCanStatus");
            if (control5.Value == Convert.ToInt32(Constants.CandidateLifeCycleStatus.SchedulingdoneTestPending).ToString())
            {
                control4.Text = "Test";
                control1.Text = "Mark Not Appeared";
            }
            else if (control5.Value == Convert.ToInt32(Constants.CandidateLifeCycleStatus.SchedulingDoneInterviewPending).ToString())
            {
                control4.Text = "Interview";
                control1.Text = "Mark Not Appeared";
            }
            else if (control5.Value == Convert.ToInt32(Constants.CandidateLifeCycleStatus.OfferSchedulingDoneOfferPending).ToString())
            {
                control4.Text = "Offer Letter";
                control1.Text = "Mark Not Appeared";
            }
            else
            {
                control4.Text = "-";
                control1.Text = "-";
                control1.Enabled = false;
            }
            control3.Attributes.Add("href", str);
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
                StatusManagement.MarkLifeCycleStatus(connection, int.Parse(e.CommandArgument.ToString()), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.TestnotAppearedReSchedulingPending, Request.UserHostAddress.ToString(), UserCode);
            if (control2.Value == Convert.ToInt32(Constants.CandidateLifeCycleStatus.SchedulingDoneInterviewPending).ToString())
                StatusManagement.MarkLifeCycleStatus(connection, int.Parse(e.CommandArgument.ToString()), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.InterviewnotAppearedReSchedulingPending, Request.UserHostAddress.ToString(), UserCode);
            if (control2.Value == Convert.ToInt32(Constants.CandidateLifeCycleStatus.OfferSchedulingDoneOfferPending).ToString())
                StatusManagement.MarkLifeCycleStatus(connection, int.Parse(e.CommandArgument.ToString()), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.OfferNotAcceptedReSchedulingPendingOffer, Request.UserHostAddress.ToString(), UserCode);
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

    private void bind_rptrptTestSheduled()
    {
        string str = Convert.ToInt32(Constants.CandidateLifeCycleStatus.SchedulingdoneTestPending).ToString() + "," + Convert.ToInt32(Constants.CandidateLifeCycleStatus.SchedulingDoneInterviewPending).ToString() + "," + Convert.ToInt32(Constants.CandidateLifeCycleStatus.OfferSchedulingDoneOfferPending).ToString();
        DateTime dateTime1 = Convert.ToDateTime(postedFromDate.Value);
        DateTime dateTime2 = Convert.ToDateTime(postedToDate.Value);
        SqlCommand selectCommand = new SqlCommand("dbo.Select_ReservedCandidateDateRangeWise", connection);
        selectCommand.Parameters.AddWithValue("@RequiredfromDate", dateTime1.ToString("yyyy-MM-dd"));
        selectCommand.Parameters.AddWithValue("@RequiredtoDate", dateTime2.ToString("yyyy-MM-dd"));
        selectCommand.Parameters.AddWithValue("@Status", str);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable1 = new DataTable();
        sqlDataAdapter.Fill(dataTable1);
        if (dataTable1 != null)
        {
            if (dataTable1.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(txtRefNo.Text))
                {
                    if (dataTable1.Select("reffNo='" + txtRefNo.Text + "'").Length > 0)
                    {
                        dataTable1 = ((IEnumerable<DataRow>)dataTable1.Select("reffNo='" + txtRefNo.Text + "'")).CopyToDataTable<DataRow>();
                    }
                    else
                    {
                        rptTestSheduled.DataSource = null;
                        rptTestSheduled.Visible = false;
                        lblemtyMsg.Text = "No record(s) found";
                        lblemtyMsg.Visible = true;
                        return;
                    }
                }
                if (ddlScheduledFor.SelectedValue != "0")
                {
                    if (dataTable1.Select("canStatus=" + ddlScheduledFor.SelectedValue).Length > 0)
                    {
                        DataTable dataTable2 = ((IEnumerable<DataRow>)dataTable1.Select("canStatus=" + ddlScheduledFor.SelectedValue)).CopyToDataTable<DataRow>();
                        rptTestSheduled.Visible = true;
                        lblemtyMsg.Visible = false;
                        rptTestSheduled.DataSource = dataTable2;
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
                    rptTestSheduled.Visible = true;
                    lblemtyMsg.Visible = false;
                    rptTestSheduled.DataSource = dataTable1;
                    rptTestSheduled.DataBind();
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
