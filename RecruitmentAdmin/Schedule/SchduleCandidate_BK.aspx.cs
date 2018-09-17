using ASP;
using ErrorLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using XRecruitmentStatusLibrary;

public partial class Schedule_SchduleCandidate_BK : CustomBasePage, IRequiresSessionState
{

    public static int statusCode = 0;
    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    private SqlConnection Errogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    private string QueryStringVar = string.Empty;
    public string profileID;
    public string CandidateID;
    public string QueryString;
    public bool Istest;
    public static string SlotsID;
    public string DepartmentCode;
    public static string CandidateSlots;
    public static string Requisition_Code;
    private SecureQueryString secQueryString;
    protected Label lblSNo;
    protected Label lblSlotDate;
    protected Label lblStartTime;
    protected Label lblEndTime;
    protected Label lblvenue;
    protected HtmlTable tbSelected;
    protected Repeater rptEmployeeList;
    protected TextBox txtStartTime;
    protected HiddenField hdnStatusCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            if (QueryStringVar != null)
                secQueryString = new SecureQueryString(QueryStringVar);
            SetView();
            if (IsPostBack)
                return;
            postedFromDate.Attributes.Add("readonly", "readonly");
            postedFromDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            postedToDate.Attributes.Add("readonly", "readonly");
            postedToDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            ShowData();
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

    protected void rptSlot_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "Reserve"))
            return;
        try
        {
            if (!string.IsNullOrEmpty(CandidateID))
            {
                connection.Open();
                Label control1 = (Label)e.Item.FindControl("lblrvenueprefix");
                Label control2 = (Label)e.Item.FindControl("lblrSNo");
                Label control3 = (Label)e.Item.FindControl("lblrdate");
                Label control4 = (Label)e.Item.FindControl("lblrStartTime");
                Label control5 = (Label)e.Item.FindControl("lblrEndTime");
                CandidateSlots = e.CommandArgument.ToString();
                lblSlotDate.Text = control3.Text;
                lblStartTime.Text = control4.Text;
                lblSNo.Text = control2.Text;
                lblEndTime.Text = control5.Text;
                lblvenue.Text = control1.Text;
                string[] strArray1 = lblStartTime.Text.Split(':');
                string[] strArray2 = lblEndTime.Text.Split(':');
                if (statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.ShortlistedSchedulingPendingTest) || statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.TestFailedReSchedulingPendingTest) || statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.TestnotAppearedReSchedulingPending))
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Reserve_CadidateSlotTest", connection);
                    sqlCommand.Parameters.AddWithValue("@CandidateId", Convert.ToInt32(CandidateID));
                    sqlCommand.Parameters.AddWithValue("@CandidateSlotId", CandidateSlots);
                    sqlCommand.Parameters.AddWithValue("@StartTime", lblStartTime.Text);
                    sqlCommand.Parameters.AddWithValue("@Endtime", lblEndTime.Text);
                    sqlCommand.Parameters.AddWithValue("@StatusCode", statusCode);
                    sqlCommand.Parameters.AddWithValue("@UpdatedBy", Convert.ToInt16(UserCode));
                    sqlCommand.Parameters.AddWithValue("@UpdatedIp", USERIP);
                    sqlCommand.Parameters.AddWithValue("@SlotDate", Convert.ToDateTime(lblSlotDate.Text));
                    sqlCommand.Parameters.AddWithValue("@SlotStatusCode", 1);
                    sqlCommand.Parameters.AddWithValue("@RequisitionCode", Convert.ToInt32(Requisition_Code));
                    sqlCommand.Parameters.AddWithValue("@VenueCode", Convert.ToInt32(ddlVenue.SelectedValue));
                    sqlCommand.Parameters.AddWithValue("@SeatNumber", control1.Text);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
                    rptSlot.DataSource = GetUnreservedSlots(Convert.ToInt32(ddlVenue.SelectedValue), Convert.ToDateTime(postedFromDate.Value).ToString("yyyy-MM-dd"), Convert.ToInt32(lblProfileHour.Text), Convert.ToDateTime(postedToDate.Value).ToString("yyyy-MM-dd"));
                    rptSlot.DataBind();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Reservation has been cancel Succesfully.";
                    StatusManagement.MarkLifeCycleStatus(connection, int.Parse(CandidateID), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.SchedulingdoneTestPending, USERIP, UserCode);
                    if (secQueryString["pgno"] != null)
                    {
                        if (!string.IsNullOrEmpty(secQueryString["pgno"].ToString()))
                        {
                            if (secQueryString["pgno"].ToString() == "1")
                                ScriptManager.RegisterClientScriptBlock((Page)this, GetType(), "pass", "refreshParentCandidateDetail();", true);
                            else
                                ScriptManager.RegisterClientScriptBlock((Page)this, GetType(), "pass", "refreshParent();", true);
                        }
                        else
                            ScriptManager.RegisterClientScriptBlock((Page)this, GetType(), "pass", "refreshParent();", true);
                    }
                    else
                        ScriptManager.RegisterClientScriptBlock((Page)this, GetType(), "pass", "refreshParent();", true);
                }
                else
                {
                    if (statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.TestPassedSchedulingPendingInterview) && statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.InterviewPassedOfferGenerationPending) && (statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferGeneratedSchedulingPending) && statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.InterviewnotAppearedReSchedulingPending)) && (statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.InterviewFailedReSchedulingPending) && statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.NoTestSchedulingPendingInterview) && (statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.VerificationDoneAppointmentSchedulingPending) && statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferNotAcceptedReSchedulingPendingOffer))) && (statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferAcceptedVerificationSchedulingPending) && statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferAcceptedJoiningNotDone)))
                        return;
                    GetEmployee(lblSlotDate.Text, strArray1[0], strArray2[0]);
                    SlotsID = e.CommandArgument.ToString();
                    tbSelected.Visible = true;
                    rptSlot.Visible = false;
                }
            }
            else
                ErrorView("* No Candidate Selected");
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

    protected void btnSearch_Onclick(object sender, EventArgs e)
    {
        try
        {
            tbSelected.Visible = false;
            lblMsg.Visible = false;
            DataTable unreservedSlots = GetUnreservedSlots(Convert.ToInt32(ddlVenue.SelectedValue), Convert.ToDateTime(postedFromDate.Value).ToString("yyyy-MM-dd"), Convert.ToInt32(lblProfileHour.Text), Convert.ToDateTime(postedToDate.Value).ToString("yyyy-MM-dd"));
            if (unreservedSlots.Rows.Count > 0)
            {
                rptSlot.Visible = true;
                lblemptyMsg.Visible = false;
                rptSlot.DataSource = unreservedSlots;
                rptSlot.DataBind();
            }
            else
            {
                rptSlot.DataSource = null;
                rptSlot.Visible = false;
                lblemptyMsg.Text = "No Data Found.";
                lblemptyMsg.Visible = true;
            }
            ShowHideActions();
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

    protected void ddlVenue_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dataTable = BindVenueAndProfileDetail(Convert.ToInt32(ddlVenue.SelectedValue), (int)Convert.ToInt16(profileID));
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return;
            lblTotalSeat.Text = dataTable.Rows[0]["NoOfSeats"].ToString();
            lblMinimumTime.Text = dataTable.Rows[0]["MinDurationOfSlot"].ToString();
            lblAvailabletime.Text = "From " + dataTable.Rows[0]["SlotStartTime"].ToString() + " to " + dataTable.Rows[0]["SlotEndTime"].ToString();
            if (statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.ShortlistedSchedulingPendingTest) || statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.TestnotAppearedReSchedulingPending) || statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.TestFailedReSchedulingPendingTest))
            {
                lblProfileHour.Text = dataTable.Rows[0]["Test_Duration"].ToString();
            }
            else
            {
                if (statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.NoTestSchedulingPendingInterview) && statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.NoTestSchedulingPendingInterview) && (statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.InterviewnotAppearedReSchedulingPending) && statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.TestPassedSchedulingPendingInterview)) && (statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.InterviewPassedOfferGenerationPending) && statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferNotAcceptedReSchedulingPendingOffer) && (statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferAcceptedJoiningNotDone) && statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferAcceptedVerificationSchedulingPending))) && statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.VerificationDoneAppointmentSchedulingPending))
                    return;
                lblProfileHour.Text = dataTable.Rows[0]["interview_duration"].ToString();
            }
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

    protected void lnkReserveInt_Click(object sender, EventArgs e)
    {
        try
        {
            string str1 = string.Empty;
            foreach (RepeaterItem repeaterItem in rptEmployeeList.Items)
            {
                HtmlInputCheckBox control1 = (HtmlInputCheckBox)repeaterItem.FindControl("chkCandidate");
                HiddenField control2 = (HiddenField)repeaterItem.FindControl("hdnEmployeeCode");
                if (control1.Checked)
                    str1 = str1 + control2.Value + ",";
            }
            connection.Open();
            if (string.IsNullOrEmpty(str1))
                return;
            string str2 = str1.TrimEnd(',');
            lblStartTime.Text.Split(':');
            lblEndTime.Text.Split(':');
            SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Reserve_CadidateSlotInterview", connection);
            sqlCommand.Parameters.AddWithValue("@CandidateId", Convert.ToInt32(CandidateID));
            sqlCommand.Parameters.AddWithValue("@CandidateSlotId", CandidateSlots);
            sqlCommand.Parameters.AddWithValue("@StartTime", lblStartTime.Text);
            sqlCommand.Parameters.AddWithValue("@Endtime", lblEndTime.Text);
            sqlCommand.Parameters.AddWithValue("@StatusCode", statusCode);
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", Convert.ToInt16(UserCode));
            sqlCommand.Parameters.AddWithValue("@UpdatedIp", USERIP);
            sqlCommand.Parameters.AddWithValue("@EmployeeCode", str2);
            sqlCommand.Parameters.AddWithValue("@SlotDate", Convert.ToDateTime(lblSlotDate.Text));
            sqlCommand.Parameters.AddWithValue("@SlotStatusCode", 1);
            sqlCommand.Parameters.AddWithValue("@RequisitionCode", Convert.ToInt32(Requisition_Code));
            sqlCommand.Parameters.AddWithValue("@VenueCode", Convert.ToInt32(ddlVenue.SelectedValue));
            sqlCommand.Parameters.AddWithValue("@SeatNumber", lblvenue.Text);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            rptSlot.DataSource = GetUnreservedSlots(Convert.ToInt32(ddlVenue.SelectedValue), Convert.ToDateTime(postedFromDate.Value).ToString("yyyy-MM-dd"), Convert.ToInt32(lblProfileHour.Text), Convert.ToDateTime(postedToDate.Value).ToString("yyyy-MM-dd"));
            rptSlot.DataBind();
            lblMsg.Visible = true;
            lblMsg.Text = "Reservation has been save Succesfully.";
            if (statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.TestPassedSchedulingPendingInterview) || statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.InterviewnotAppearedReSchedulingPending) || (statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.InterviewFailedReSchedulingPending) || statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.NoTestSchedulingPendingInterview)))
            {
                StatusManagement.MarkLifeCycleStatus(connection, int.Parse(CandidateID), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.SchedulingDoneInterviewPending, USERIP, UserCode);
                RefreshParent();
            }
            else if (statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferGeneratedSchedulingPending) || statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferNotAcceptedReSchedulingPendingOffer) || statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferAcceptedJoiningNotDone))
            {
                StatusManagement.MarkLifeCycleStatus(connection, int.Parse(CandidateID), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.OfferSchedulingDoneOfferPending, USERIP, UserCode);
                RefreshParent();
            }
            else if (statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.VerificationDoneAppointmentSchedulingPending))
            {
                StatusManagement.MarkLifeCycleStatus(connection, int.Parse(CandidateID), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.AppointmentSchedulingDoneJoiningReportingPending, USERIP, UserCode);
                RefreshParent();
            }
            else
            {
                if (statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferAcceptedVerificationSchedulingPending))
                    return;
                StatusManagement.MarkLifeCycleStatus(connection, int.Parse(CandidateID), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.VerificationSchedulingDoneVerficationPending, USERIP, UserCode);
                RefreshParent();
            }
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

    protected void rptEmployee_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            HtmlInputCheckBox control = (HtmlInputCheckBox)e.Item.FindControl("chkCandidate");
            if (control == null)
                return;
            if (DataBinder.Eval(e.Item.DataItem, "Checked").ToString() == "1")
                control.Checked = true;
            else
                control.Checked = false;
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

    private void ShowHideActions()
    {
        if (DTActions.Rows.Count <= 0)
            return;
        IEnumerable<HtmlGenericControl> allControlsOfType = Page.GetAllControlsOfType<HtmlGenericControl>();
        foreach (Control control in allControlsOfType)
        {
            if (control.ClientID.Contains("divAction"))
                control.Visible = false;
        }
        foreach (DataRow row in (InternalDataCollectionBase)DTActions.Rows)
        {
            foreach (Control control in allControlsOfType)
            {
                if (control.ClientID == "divAction" + row["MenuLinkActionCode"].ToString())
                    control.Visible = true;
                else if (control.ClientID.Contains("divActionlbl" + row["MenuLinkActionCode"].ToString() + "_"))
                    control.Visible = true;
            }
        }
    }

    public void RefreshParent()
    {
        if (!string.IsNullOrEmpty(secQueryString["pgno"].ToString()))
        {
            if (secQueryString["pgno"].ToString() == "1")
                ScriptManager.RegisterClientScriptBlock((Page)this, GetType(), "pass", "refreshParentCandidateDetail();", true);
            else
                ScriptManager.RegisterClientScriptBlock((Page)this, GetType(), "pass", "refreshParent();", true);
        }
        else
            ScriptManager.RegisterClientScriptBlock((Page)this, GetType(), "pass", "refreshParent();", true);
    }

    public DataTable BindVenueAndProfileDetail(int venueCode, int profileCode)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_Select_OnlyVenueDetailsByVenueCode ", connection);
        selectCommand.Parameters.AddWithValue("@VenueCode", venueCode);
        selectCommand.Parameters.AddWithValue("@RequiositionCode", Requisition_Code);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        return dataTable;
    }

    public void GetVenue()
    {
        int num = 0;
        if (statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.ShortlistedSchedulingPendingTest) || statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.TestnotAppearedReSchedulingPending) || statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.TestFailedReSchedulingPendingTest))
            num = 3;
        else if (statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.NoTestSchedulingPendingInterview) || statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.InterviewFailedReSchedulingPending) || (statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.InterviewnotAppearedReSchedulingPending) || statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.TestPassedSchedulingPendingInterview)) || (statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferGeneratedSchedulingPending) || statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferNotAcceptedReSchedulingPendingOffer) || (statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferAcceptedJoiningNotDone) || statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferAcceptedVerificationSchedulingPending))) || statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.VerificationDoneAppointmentSchedulingPending))
            num = 2;
        SqlCommand selectCommand = new SqlCommand("XRec_Select_VenueBySchduleMediumType ", connection);
        selectCommand.Parameters.AddWithValue("@statusCode", statusCode);
        selectCommand.Parameters.AddWithValue("@mediumtype", num);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        if (dataTable == null || dataTable.Rows.Count <= 0)
            return;
        ddlVenue.DataSource = dataTable;
        ddlVenue.DataTextField = "VenueName";
        ddlVenue.DataValueField = "VenueCode";
        ddlVenue.DataBind();
        lblMinimumTime.Text = dataTable.Rows[0]["MinDurationOfSlot"].ToString();
        lblTotalSeat.Text = dataTable.Rows[0]["NoOfSeats"].ToString();
        lblAvailabletime.Text = "From " + dataTable.Rows[0]["StartTime"].ToString() + " to " + dataTable.Rows[0]["EndTime"].ToString();
    }

    public DataTable GetUnreservedSlots(int VenueCode, string SlotDate, int TestDuration, string SlotEndDate)
    {
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_Select_AvailableSLotsByDateRangeTest ", connection);
        selectCommand.Parameters.AddWithValue("@VenueCode", VenueCode);
        selectCommand.Parameters.AddWithValue("@SlotDate", SlotDate);
        selectCommand.Parameters.AddWithValue("@SlotEndDate", SlotEndDate);
        selectCommand.Parameters.AddWithValue("@TestDuration", TestDuration);
        if (!string.IsNullOrEmpty(txtStartTime.Text))
            selectCommand.Parameters.AddWithValue("@StartTimeM", txtStartTime.Text);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        return dataTable;
    }

    public void ShowData()
    {
        GetVenue();
    }

    public void GetEmployee(string SlotDate, string StartTime, string EndTime)
    {
        SqlCommand selectCommand = new SqlCommand("Xrec_Select_OGEmployees ", connection);
        selectCommand.Parameters.AddWithValue("@DepartmentCode", DepartmentCode);
        selectCommand.Parameters.AddWithValue("@SloteDate", SlotDate);
        selectCommand.Parameters.AddWithValue("@StartTime", Convert.ToInt16(StartTime));
        selectCommand.Parameters.AddWithValue("@EndTime", Convert.ToInt16(EndTime));
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        if (dataTable == null)
            return;
        rptEmployeeList.DataSource = dataTable;
        rptEmployeeList.DataBind();
    }

    public void ErrorView(string msg)
    {
        divPage.Visible = false;
        DivError.Visible = true;
        lblError.Text = msg;
    }

    public void SetView()
    {
        if (QueryStringVar != null)
        {
            if (secQueryString["refno"] != null)
            {
                SqlCommand selectCommand = new SqlCommand("Xrec_Select_CandidateAndProfileByCPMCode ", connection);
                selectCommand.Parameters.AddWithValue("@CPMCode", secQueryString["refno"].ToString());
                selectCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        CandidateID = dataTable.Rows[0]["Candidate_Code"].ToString();
                        QueryString = new SecureQueryString().encrypt("CID=" + CandidateID);
                        profileID = dataTable.Rows[0]["Profile_Code"].ToString();
                        lblProfileName.Text = dataTable.Rows[0]["Profile_Name"].ToString();
                        lblCandidateName.Text = dataTable.Rows[0]["Full_Name"].ToString();
                        lblCandidateReference.Text = secQueryString["refno"].ToString();
                        statusCode = int.Parse(dataTable.Rows[0]["Status_Code"].ToString());
                        hdnStatusCode.Value = dataTable.Rows[0]["Status_Code"].ToString();
                        DepartmentCode = dataTable.Rows[0]["SubDomain_Code"].ToString();
                        Requisition_Code = dataTable.Rows[0]["Requisition_Code"].ToString();
                        if (statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.ShortlistedSchedulingPendingTest))
                        {
                            lblReqType.Text = "Test";
                            lblProfileHour.Text = dataTable.Rows[0]["Test_Duration"].ToString();
                        }
                        else if (statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.TestnotAppearedReSchedulingPending) || statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.TestFailedReSchedulingPendingTest))
                        {
                            lblReqType.Text = "Re-Test";
                            lblProfileHour.Text = dataTable.Rows[0]["Test_Duration"].ToString();
                        }
                        else if (statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.TestPassedSchedulingPendingInterview) || statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.NoTestSchedulingPendingInterview))
                        {
                            lblReqType.Text = "Interview";
                            lblProfileHour.Text = dataTable.Rows[0]["interview_duration"].ToString();
                        }
                        else if (statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.InterviewnotAppearedReSchedulingPending) || statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.InterviewFailedReSchedulingPending))
                        {
                            lblReqType.Text = "Re-Interview";
                            lblProfileHour.Text = dataTable.Rows[0]["interview_duration"].ToString();
                        }
                        else if (statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferGeneratedSchedulingPending) || statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferNotAcceptedReSchedulingPendingOffer) || statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferAcceptedJoiningNotDone))
                        {
                            lblReqType.Text = "Offer Letter";
                            lblProfileHour.Text = dataTable.Rows[0]["interview_duration"].ToString();
                        }
                        else if (statusCode == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.VerificationDoneAppointmentSchedulingPending))
                        {
                            lblReqType.Text = "Appointment";
                            lblProfileHour.Text = dataTable.Rows[0]["interview_duration"].ToString();
                        }
                        else
                        {
                            if (statusCode != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferAcceptedVerificationSchedulingPending))
                                return;
                            lblReqType.Text = "Verification";
                            lblProfileHour.Text = dataTable.Rows[0]["interview_duration"].ToString();
                        }
                    }
                    else
                        ErrorView("* Either Candidate has already reserved slot or not active.");
                }
                else
                    ErrorView("* No Record Found against selected Candidate.");
            }
            else
                ErrorView("* Invalid Link, Please check and verify provided link.");
        }
        else
            ErrorView("* Invalid Link, Please check and verify provided link.");
    }
}