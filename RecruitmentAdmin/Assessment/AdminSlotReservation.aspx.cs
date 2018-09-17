using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using ErrorLog;
using System.Drawing;
using System.Collections;
public partial class AdminSlotReservation : CustomBasePage//XRecBase
{
    #region Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    int MinDurationOfSlot;
    static DataView objDV = new DataView();
    PagedDataSource objPDS = new System.Web.UI.WebControls.PagedDataSource();
    static int PgSize;
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
            AdminSlotReservation.PgSize = 20;
            postedFromDate.Attributes.Add("readonly", "readonly");
            postedFromDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            postedToDate.Attributes.Add("readonly", "readonly");
            postedToDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            ShowData();
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

    protected void rptSlot_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item)
        {
            if (e.Item.ItemType != ListItemType.AlternatingItem)
                return;
        }
        try
        {
            ImageButton control1 = (ImageButton)e.Item.FindControl("btnDelete");
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
            control1.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete this Slot?')");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hfSlotCode");
            ((HtmlControl)e.Item.FindControl("btnEdit")).Attributes.Add("href", "AddEditVenue.aspx?vid=" + control2.Value);
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

    protected void ddlVenue_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetTimeByVenue();
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

    protected void rptSlot_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "Delete"))
            return;
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XRec_Delete_CandidateSlot", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@CandidateSlotCode", e.CommandArgument);
            selectCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
            selectCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
            new SqlDataAdapter(selectCommand).Fill(new DataTable());
            GetDetails();
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

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            GetDetails();
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

    protected void lnkGenerateSlot_Click(object sender, EventArgs e)
    {
        try
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            DateTime slotDate = Convert.ToDateTime(postedFromDate.Value);
            int num = 0;
            ltrMsg.Text = string.Empty;
            lblMsg.Visible = false;
            ltrMsg.Visible = false;
            if (CheckTimeSlotDuration(slotDate, int.Parse(ddlToTime.SelectedValue) - int.Parse(ddlFromTime.SelectedValue)))
            {
                for (; slotDate <= Convert.ToDateTime(postedToDate.Value); slotDate = slotDate.AddDays(1.0))
                {
                    if (CheckIfAvailable(slotDate))
                    {
                        DataTable dataTable = InsertSlot(slotDate);
                        if (dataTable.Rows.Count > 0)
                            InsertSlotDetails(int.Parse(dataTable.Rows[0]["SlotCode"].ToString()), int.Parse(dataTable.Rows[0]["NoOfSeats"].ToString()));
                        ++num;
                    }
                    else
                    {
                        ltrMsg.Text = ltrMsg.Text + "Slots Already Exist from " + ddlFromTime.SelectedValue + ":00  To " + ddlToTime.SelectedValue + ":00 of Date: " + slotDate.ToString("MMM dd, yyyy") + " <br >";
                        ltrMsg.Visible = true;
                    }
                }
                if (num <= 0)
                    return;
                lblMsg.Text = "Slots Created Successfully.";
                lblMsg.ForeColor = Color.Green;
                lblMsg.Visible = true;
                ShowSlots();
            }
            else
            {
                ltrMsg.Text = "Selected Time is less than Slot Duration. Slot Duration Should be minimum " + MinDurationOfSlot + " Hours.";
                ltrMsg.Visible = true;
            }
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

    protected void ShowSlots()
    {
        SqlCommand selectCommand = new SqlCommand("XRec_Select_SlotsDetails ", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.AddWithValue("@SlotDateFrom", postedFromDate.Value);
        selectCommand.Parameters.AddWithValue("@SlotDateTo", postedToDate.Value);
        selectCommand.Parameters.AddWithValue("@VenueCode", ddlVenue.SelectedValue);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        if (dataTable.Rows.Count <= 0)
            return;
        AdminSlotReservation.objDV = dataTable.DefaultView;
        PageNo = 0;
        trPagingControls.Attributes.Add("style", "display:block");
        rptSlot.DataSource = ApplyPaging(AdminSlotReservation.objDV, PageNo);
        rptSlot.DataBind();
    }

    protected bool CheckTimeSlotDuration(DateTime slotDate, int TimeDuration)
    {
        bool flag = false;
        DataTable dataTable = new DataTable();
        SqlCommand selectCommand = new SqlCommand("XRec_CheckTimeSlotDuration", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.AddWithValue("@VenueCode", ddlVenue.SelectedValue);
        selectCommand.Parameters.AddWithValue("@TimeDuration", TimeDuration);
        new SqlDataAdapter(selectCommand).Fill(dataTable);
        if (dataTable.Rows.Count > 0)
        {
            flag = Convert.ToBoolean(dataTable.Rows[0]["Available"].ToString());
            MinDurationOfSlot = int.Parse(dataTable.Rows[0]["MinDurationOfSlot"].ToString());
        }
        return flag;
    }

    protected bool CheckIfAvailable(DateTime slotDate)
    {
        bool flag = false;
        DataTable dataTable = new DataTable();
        SqlCommand selectCommand = new SqlCommand("XRec_Check_Slots", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.AddWithValue("@SlotDate", slotDate);
        selectCommand.Parameters.AddWithValue("@VenueCode", ddlVenue.SelectedValue);
        selectCommand.Parameters.AddWithValue("@StartTime", ddlFromTime.SelectedValue);
        selectCommand.Parameters.AddWithValue("@EndTime", ddlToTime.SelectedValue);
        new SqlDataAdapter(selectCommand).Fill(dataTable);
        if (dataTable.Rows.Count > 0)
            flag = Convert.ToBoolean(dataTable.Rows[0]["Available"].ToString());
        return flag;
    }

    protected DataTable InsertSlot(DateTime slotDate)
    {
        DataTable dataTable = new DataTable();
        SqlCommand selectCommand = new SqlCommand("XRec_Insert_Slots ", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.AddWithValue("@SlotDate", slotDate);
        selectCommand.Parameters.AddWithValue("@VenueCode", ddlVenue.SelectedValue);
        selectCommand.Parameters.AddWithValue("@StartTime", ddlFromTime.SelectedValue);
        selectCommand.Parameters.AddWithValue("@EndTime", ddlToTime.SelectedValue);
        selectCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        selectCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        new SqlDataAdapter(selectCommand).Fill(dataTable);
        return dataTable;
    }

    protected void InsertSlotDetails(int slotCode, int NoOfSeats)
    {
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
    }

    public void GetDetails()
    {
        SqlCommand selectCommand = new SqlCommand("XRec_Select_SlotsDetails ", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.AddWithValue("@SlotDateFrom", postedFromDate.Value);
        selectCommand.Parameters.AddWithValue("@SlotDateTo", postedToDate.Value);
        selectCommand.Parameters.AddWithValue("@VenueCode", ddlVenue.SelectedValue);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        if (dataTable.Rows.Count > 0)
        {
            AdminSlotReservation.objDV = dataTable.DefaultView;
            PageNo = 0;
            trPagingControls.Attributes.Add("style", "display:block");
            lblMsg.Visible = false;
            ltrMsg.Visible = false;
            rptSlot.DataSource = ApplyPaging(AdminSlotReservation.objDV, PageNo);
            rptSlot.DataBind();
        }
        else
        {
            lblMsg.Visible = true;
            ltrMsg.Visible = false;
            lblMsg.Text = "No record(s) found";
            lblMsg.ForeColor = Color.Red;
            rptSlot.DataSource = null;
            rptSlot.DataBind();
        }
    }

    public void ShowData()
    {
        try
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            GetVenue();
            GetTimeByVenue();
            GetDetails();
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

    public void GetTimeByVenue()
    {
        SqlCommand selectCommand = new SqlCommand("XRec_Select_VenueTimeRangeByVenueCode", connection);
        selectCommand.Parameters.AddWithValue("@VenueCode", ddlVenue.SelectedValue);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        if (dataTable == null || dataTable.Rows.Count <= 0)
            return;
        ddlFromTime.SelectedValue = dataTable.Rows[0]["StartTime"].ToString();
        ddlToTime.SelectedValue = dataTable.Rows[0]["EndTime"].ToString();
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = AdminSlotReservation.PgSize;
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
        rptSlot.DataSource = ApplyPaging(AdminSlotReservation.objDV, PageNo);
        rptSlot.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptSlot.DataSource = ApplyPaging(AdminSlotReservation.objDV, PageNo);
        rptSlot.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptSlot.DataSource = ApplyPaging(AdminSlotReservation.objDV, PageNo);
        rptSlot.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptSlot.DataSource = ApplyPaging(AdminSlotReservation.objDV, PageNo);
        rptSlot.DataBind();
    }
    #endregion
}