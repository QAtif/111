
using ErrorLog;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI.WebControls;

public partial class SlotReservation : CustomBasePage
{
    #region Variables
    public static DataView objDV = new DataView();
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    PagedDataSource objPDS = new PagedDataSource();
    public static int PgSize;

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
            trcandidate.Visible = false;
            SlotReservation.PgSize = 5;
            postedFromDate.Attributes.Add("readonly", "readonly");
            postedFromDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            postedToDate.Attributes.Add("readonly", "readonly");
            postedToDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            ShowData();
            lblCandidate.Text = "For reserve slot please select Candidate first";
            lblCandidate.ForeColor = Color.Gray;
            lblCandidateName.Text = "";
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

    protected void rptCandidateShow_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "Select"))
            return;
        try
        {
            Label control = (Label)e.Item.FindControl("lblReffno");
            lblCandidateName.Text = e.CommandArgument.ToString();
            lblCandidate.Text = "You have selected Candidate Reference No : " + control.Text;
            trcandidate.Visible = false;
            lblMsg.Text = "";
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
            if (!string.IsNullOrEmpty(lblCandidateName.Text))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Reserve_CadidateSlot", connection);
                sqlCommand.Parameters.AddWithValue("@CandidateId", Convert.ToInt32(lblCandidateName.Text));
                sqlCommand.Parameters.AddWithValue("@CandidateSlotId", e.CommandArgument.ToString());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                rptSlot.DataSource = GetUnreservedSlots(Convert.ToInt32(ddlVenue.SelectedValue), Convert.ToDateTime(postedFromDate.Value).ToString("yyyy-MM-dd"), Convert.ToInt32(lblProfileHour.Text), Convert.ToDateTime(postedToDate.Value).ToString("yyyy-MM-dd"));
                rptSlot.DataBind();
                BindCandidate(Convert.ToInt32(ddlProfile.SelectedValue));
                lblCandidate.Text = "For reserve slot please select Candidate first";
                lblCandidateName.Text = "";
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "* please select Candidate first";
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

    protected void lnkViewCandidate(object sender, EventArgs e)
    {
        try
        {
            trcandidate.Visible = true;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void btnSearch_Onclick(object sender, EventArgs e)
    {
        try
        {
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

    protected void ddlProfile_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dataTable = BindVenueAndProfileDetail(Convert.ToInt32(ddlVenue.SelectedValue), Convert.ToInt32(ddlProfile.SelectedValue));
            if (dataTable != null && dataTable.Rows.Count > 0)
                lblProfileHour.Text = dataTable.Rows[0]["TestDuration"].ToString();
            BindCandidate(Convert.ToInt32(ddlProfile.SelectedValue));
            lblCandidate.Text = "For reserve slot please select Candidate first";
            lblCandidate.ForeColor = Color.Gray;
            lblCandidateName.Text = "";
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
            DataTable dataTable = BindVenueAndProfileDetail(Convert.ToInt32(ddlVenue.SelectedValue), Convert.ToInt32(ddlProfile.SelectedValue));
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return;
            lblTotalSeat.Text = dataTable.Rows[0]["NoOfSeats"].ToString();
            lblMinimumTime.Text = dataTable.Rows[0]["MinDurationOfSlot"].ToString();
            lblAvailabletime.Text = "From " + dataTable.Rows[0]["SlotStartTime"].ToString() + " to " + dataTable.Rows[0]["SlotEndTime"].ToString();
            lblProfileHour.Text = dataTable.Rows[0]["TestDuration"].ToString();
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

    protected void BindCandidate(int ProfileID)
    {
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_Select_CandidateByProfileCode ", connection);
        selectCommand.Parameters.AddWithValue("@ProfileCode", ProfileID);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        if (dataTable == null)
            return;
        if (dataTable.Rows.Count > 0)
        {
            lblemtyMsgCandidate.Visible = false;
            SlotReservation.objDV = dataTable.DefaultView;
            PageNo = 0;
            trPagingControls.Attributes.Add("style", "display:block");
            lblMsg.Visible = false;
            rptCandidateView.Visible = true;
            rptCandidateView.DataSource = ApplyPaging(SlotReservation.objDV, PageNo);
            rptCandidateView.DataBind();
        }
        else
        {
            trPagingControls.Attributes.Add("style", "display:none");
            rptCandidateView.DataSource = null;
            rptCandidateView.Visible = false;
            lblemtyMsgCandidate.Visible = true;
            lblemtyMsgCandidate.Text = "No Data Found.";
        }
    }

    public DataTable GetUnreservedSlots(int VenueCode, string SlotDate, int TestDuration, string SlotEndDate)
    {
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_Select_AvailableSLotsByDateRange ", connection);
        selectCommand.Parameters.AddWithValue("@VenueCode", VenueCode);
        selectCommand.Parameters.AddWithValue("@SlotDate", SlotDate);
        selectCommand.Parameters.AddWithValue("@SlotEndDate", SlotEndDate);
        selectCommand.Parameters.AddWithValue("@TestDuration", TestDuration);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        return dataTable;
    }

    public void ShowData()
    {
        GetVenue();
        GetProfile();
    }

    public DataTable BindVenueAndProfileDetail(int venueCode, int profileCode)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_Select_OnlyVenueDetailsByVenueCode ", connection);
        selectCommand.Parameters.AddWithValue("@VenueCode", venueCode);
        selectCommand.Parameters.AddWithValue("@RequiositionCode", profileCode);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        return dataTable;
    }

    public DataTable CreateMaxCombination(int Testduration, int venuelimit, int startTime, int EndTime)
    {
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add(new DataColumn("RowNumber", typeof(int)));
        dataTable.Columns.Add(new DataColumn("Column1", typeof(string)));
        int num = 1;
        while (startTime + Testduration <= EndTime)
        {
            DataRow row = dataTable.NewRow();
            row["RowNumber"] = num;
            row["Column1"] = (startTime.ToString() + " to " + (startTime + Testduration).ToString());
            ++num;
            startTime += Testduration;
            dataTable.Rows.Add(row);
        }
        return dataTable;
    }

    public void GetVenue()
    {
        SqlCommand selectCommand = new SqlCommand("XRec_Select_Venue ", connection);
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

    public void GetProfile()
    {
        SqlCommand selectCommand = new SqlCommand("XRec_Select_Profile_TestDuration", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        if (dataTable == null || dataTable.Rows.Count <= 0)
            return;
        ddlProfile.DataSource = dataTable;
        ddlProfile.DataTextField = "Profile_Name";
        ddlProfile.DataValueField = "Profile_Code";
        ddlProfile.DataBind();
        lblProfileHour.Text = dataTable.Rows[0]["TestTimeDuration"].ToString();
        BindCandidate(Convert.ToInt32(ddlProfile.SelectedValue));
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = SlotReservation.PgSize;
        objPDS.CurrentPageIndex = PageNo;
        ViewState["PageCount"] = objPDS.PageCount.ToString();
        if (objPDS.PageCount > 1)
        {
            trPagingControls.Attributes.Add("style", "display:block");
            lblPageIndex.Visible = true;
            lblPageIndex.Font.Bold = true;
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
        rptCandidateView.DataSource = ApplyPaging(SlotReservation.objDV, PageNo);
        rptCandidateView.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptCandidateView.DataSource = ApplyPaging(SlotReservation.objDV, PageNo);
        rptCandidateView.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptCandidateView.DataSource = ApplyPaging(SlotReservation.objDV, PageNo);
        rptCandidateView.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptCandidateView.DataSource = ApplyPaging(SlotReservation.objDV, PageNo);
        rptCandidateView.DataBind();
    }
    #endregion
}