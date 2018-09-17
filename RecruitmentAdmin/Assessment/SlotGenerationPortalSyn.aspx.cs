using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using ServiceReference1;
using ErrorLog;
using System.Drawing;
using System.Collections;


public partial class SlotGenerationPortalSyn : CustomBasePage//XRecBase
{
    #region Variables
    SlotManagementAPIClient api = new SlotManagementAPIClient();
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
            SlotGenerationPortalSyn.PgSize = 20;
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

    public void test()
    {
        CompositeType composite = new CompositeType();
        composite.DateFrom = Convert.ToDateTime(postedFromDate.Value);
        composite.DateTo = Convert.ToDateTime(postedToDate.Value);
        composite.IsAdmin = false;
        DataTable dataTable1 = new DataTable();
        if (ddlVenue.SelectedValue == "1")
            dataTable1 = api.GetFacilitySlots(composite, Facility.BoardRoom);
        else if (ddlVenue.SelectedValue == "2")
            dataTable1 = api.GetFacilitySlots(composite, Facility.Library);
        else if (ddlVenue.SelectedValue == "3")
            dataTable1 = api.GetFacilitySlots(composite, Facility.TrainingRoom);
        else if (ddlVenue.SelectedValue == "4")
            dataTable1 = api.GetFacilitySlots(composite, Facility.BoardRoomIsl);
        DateTime dateTime1 = Convert.ToDateTime(postedFromDate.Value);
        DateTime dateTime2 = Convert.ToDateTime(postedToDate.Value);
        DataTable dataTable2 = new DataTable();
        dataTable2.Columns.Add("Facility_Slot_Detail_ID");
        dataTable2.Columns.Add("Facility_Slot_Date");
        dataTable2.Columns.Add("Start_Time");
        dataTable2.Columns.Add("End_Time");
        dataTable2.Columns.Add("Facility_Slot_ID");
        dataTable2.Columns.Add("VenueCode");
        if (dataTable1 != null && dataTable1.Rows.Count > 0)
        {
            int num = Convert.ToDateTime(dataTable1.Rows[0]["Start_Time"].ToString()).Minute != 0 || Convert.ToDateTime(dataTable1.Rows[0]["End_Time"].ToString()).Minute != 0 ? 2 : 1;
            while (dateTime1 <= dateTime2)
            {
                if (dataTable1.Select("Facility_Slot_Date='" + dateTime1.ToString() + "'").Length > 0)
                {
                    for (int index = 0; index < 24; ++index)
                    {
                        DataTable dataTable3 = new DataTable();
                        string str = string.Empty;
                        int length;
                        if (index == 0)
                            length = dataTable1.Select("Start_Time  like '" + index.ToString() + "0:%' and Facility_Slot_Date='" + dateTime1.ToString() + "'").Length;
                        else if (index > 0 && index < 10)
                            length = dataTable1.Select("Start_Time  like '0" + index.ToString() + ":%' and Facility_Slot_Date='" + dateTime1.ToString() + "'").Length;
                        else
                            length = dataTable1.Select("Start_Time  like '" + index.ToString() + ":%' and Facility_Slot_Date='" + dateTime1.ToString() + "'").Length;
                        if (length == num)
                        {
                            DataTable dataTable4;
                            if (index == 0)
                                dataTable4 = ((IEnumerable<DataRow>)dataTable1.Select("Start_Time  like '" + index.ToString() + "0:%' and Facility_Slot_Date='" + dateTime1.ToString() + "'")).CopyToDataTable<DataRow>();
                            else if (index > 0 && index < 10)
                                dataTable4 = ((IEnumerable<DataRow>)dataTable1.Select("Start_Time  like '0" + index.ToString() + ":%' and Facility_Slot_Date='" + dateTime1.ToString() + "'")).CopyToDataTable<DataRow>();
                            else
                                dataTable4 = ((IEnumerable<DataRow>)dataTable1.Select("Start_Time  like '" + index.ToString() + ":%' and Facility_Slot_Date='" + dateTime1.ToString() + "'")).CopyToDataTable<DataRow>();
                            foreach (DataRow row in (InternalDataCollectionBase)dataTable4.Rows)
                                str = str + "," + Convert.ToString(row["Facility_Slot_Detail_ID"]);
                            DataRow row1 = dataTable2.NewRow();
                            row1["Start_Time"] = index;
                            row1["End_Time"] = index == 23 ? 0 : (index + 1);
                            row1["Facility_Slot_ID"] = 0;
                            row1["VenueCode"] = ddlVenue.SelectedValue.ToString();
                            row1["Facility_Slot_Date"] = dateTime1;
                            row1["Facility_Slot_Detail_ID"] = str;
                            dataTable2.Rows.Add(row1);
                        }
                    }
                    dateTime1 = dateTime1.AddDays(1.0);
                }
            }
        }
        DateTime slotDate = Convert.ToDateTime(postedFromDate.Value);
        for (DateTime dateTime3 = Convert.ToDateTime(postedToDate.Value); slotDate <= dateTime3; slotDate = slotDate.AddDays(1.0))
        {
            DataTable dataTable3 = new DataTable();
            DataTable dataTable4 = InsertSlot(slotDate);
            foreach (DataRow row in (InternalDataCollectionBase)((IEnumerable<DataRow>)dataTable2.Select("Facility_Slot_Date = '" + slotDate.ToString() + "'")).CopyToDataTable<DataRow>().Rows)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand sqlCommand = new SqlCommand("XRec_Insert_SlotsDetailsCRM ", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StartTime", row["Start_Time"].ToString());
                sqlCommand.Parameters.AddWithValue("@EndTime", row["End_Time"].ToString());
                sqlCommand.Parameters.AddWithValue("@SlotCode", dataTable4.Rows[0]["Slot_Code"]);
                sqlCommand.Parameters.AddWithValue("@MinDurationOfSlot", 1);
                sqlCommand.Parameters.AddWithValue("@NoOfSeats", dataTable4.Rows[0]["NoOfSeats"]);
                sqlCommand.Parameters.AddWithValue("@VenuePrefix", dataTable4.Rows[0]["VenuePrefix"]);
                sqlCommand.Parameters.AddWithValue("@TimeDuration", 1);
                sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
                sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                sqlCommand.ExecuteNonQuery();
                if (row["Facility_Slot_Detail_ID"].ToString().Contains<char>(','))
                {
                    string str1 = row["Facility_Slot_Detail_ID"].ToString();
                    char[] chArray = new char[1] { ',' };
                    foreach (string str2 in str1.Split(chArray))
                    {
                        if (str2 != "" && str2 != "," && str2 != null)
                            api.ReserveSlot(new ParameterType()
                            {
                                FacilitySlotDetailID = Convert.ToInt32(str2),
                                Comments = "Reserved By Recruitment System",
                                UpdatedBy = UserCode,
                                UpdatedDate = DateTime.Now,
                                UpdatedIP = Request.UserHostAddress,
                                AppointeeID = UserCode
                            }, Status.Scheduled);
                    }
                }
                else
                    api.ReserveSlot(new ParameterType()
                    {
                        FacilitySlotDetailID = Convert.ToInt32(row["Facility_Slot_Detail_ID"].ToString()),
                        Comments = "Reserved By Recruitment System",
                        UpdatedBy = UserCode,
                        UpdatedDate = DateTime.Now,
                        UpdatedIP = Request.UserHostAddress,
                        AppointeeID = UserCode
                    }, Status.Scheduled);
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
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
            tblRecruitmentRecord.Visible = true;
            tblPortalRecord.Visible = false;
            trgenerate.Visible = false;
            tblpagging.Visible = true;
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

    protected void lnkPortalSearch_Click(object sender, EventArgs e)
    {
        tblRecruitmentRecord.Visible = false;
        tblPortalRecord.Visible = true;
        trgenerate.Visible = true;
        tblpagging.Visible = false;
        lblMsg.Visible = false;
        ltrMsg.Visible = true;
        SlotManagementAPIClient managementApiClient = new SlotManagementAPIClient();
        CompositeType composite = new CompositeType();
        composite.DateFrom = Convert.ToDateTime(postedFromDate.Value);
        composite.DateTo = Convert.ToDateTime(postedToDate.Value);
        composite.IsAdmin = false;
        DataTable dataTable1 = new DataTable();
        if (ddlVenue.SelectedValue == "1")
            dataTable1 = managementApiClient.GetFacilitySlots(composite, Facility.BoardRoom);
        else if (ddlVenue.SelectedValue == "2")
            dataTable1 = managementApiClient.GetFacilitySlots(composite, Facility.Library);
        else if (ddlVenue.SelectedValue == "3")
            dataTable1 = managementApiClient.GetFacilitySlots(composite, Facility.TrainingRoom);
        else if (ddlVenue.SelectedValue == "4")
            dataTable1 = managementApiClient.GetFacilitySlots(composite, Facility.BoardRoomIsl);
        DateTime dateTime1 = Convert.ToDateTime(postedFromDate.Value);
        DateTime dateTime2 = Convert.ToDateTime(postedToDate.Value);
        DataTable dataTable2 = new DataTable();
        dataTable2.Columns.Add("Facility_Slot_Detail_ID");
        dataTable2.Columns.Add("Facility_Slot_Date");
        dataTable2.Columns.Add("Start_Time");
        dataTable2.Columns.Add("End_Time");
        dataTable2.Columns.Add("Facility_Slot_ID");
        dataTable2.Columns.Add("VenueCode");
        if (dataTable1 != null && dataTable1.Rows.Count > 0)
        {
            int num = Convert.ToDateTime(dataTable1.Rows[0]["Start_Time"].ToString()).Minute != 0 || Convert.ToDateTime(dataTable1.Rows[0]["End_Time"].ToString()).Minute != 0 ? 2 : 1;
            while (dateTime1 <= dateTime2)
            {
                if (dataTable1.Select("Facility_Slot_Date='" + dateTime1.ToString() + "'").Length > 0)
                {
                    for (int index = 0; index < 24; ++index)
                    {
                        DataTable dataTable3 = new DataTable();
                        string str = string.Empty;
                        int length;
                        if (index == 0)
                            length = dataTable1.Select("Start_Time  like '" + index.ToString() + "0:%' and Facility_Slot_Date='" + dateTime1.ToString() + "'").Length;
                        else if (index > 0 && index < 10)
                            length = dataTable1.Select("Start_Time  like '0" + index.ToString() + ":%' and Facility_Slot_Date='" + dateTime1.ToString() + "'").Length;
                        else
                            length = dataTable1.Select("Start_Time  like '" + index.ToString() + ":%' and Facility_Slot_Date='" + dateTime1.ToString() + "'").Length;
                        if (length == num)
                        {
                            DataTable dataTable4;
                            if (index == 0)
                                dataTable4 = ((IEnumerable<DataRow>)dataTable1.Select("Start_Time  like '" + index.ToString() + "0:%' and Facility_Slot_Date='" + dateTime1.ToString() + "'")).CopyToDataTable<DataRow>();
                            else if (index > 0 && index < 10)
                                dataTable4 = ((IEnumerable<DataRow>)dataTable1.Select("Start_Time  like '0" + index.ToString() + ":%' and Facility_Slot_Date='" + dateTime1.ToString() + "'")).CopyToDataTable<DataRow>();
                            else
                                dataTable4 = ((IEnumerable<DataRow>)dataTable1.Select("Start_Time  like '" + index.ToString() + ":%' and Facility_Slot_Date='" + dateTime1.ToString() + "'")).CopyToDataTable<DataRow>();
                            foreach (DataRow row in (InternalDataCollectionBase)dataTable4.Rows)
                                str = str + "," + Convert.ToString(row["Facility_Slot_Detail_ID"]);
                            DataRow row1 = dataTable2.NewRow();
                            row1["Start_Time"] = index;
                            row1["End_Time"] = index == 23 ? 0 : (index + 1);
                            row1["Facility_Slot_ID"] = 0;
                            row1["VenueCode"] = ddlVenue.SelectedValue.ToString();
                            row1["Facility_Slot_Date"] = dateTime1;
                            row1["Facility_Slot_Detail_ID"] = str;
                            dataTable2.Rows.Add(row1);
                        }
                    }
                    dateTime1 = dateTime1.AddDays(1.0);
                }
            }
        }
        if (dataTable2.Rows.Count > 0)
        {
            rptPortalRecord.DataSource = dataTable2;
            rptPortalRecord.DataBind();
        }
        else
        {
            lblMsg.Visible = true;
            ltrMsg.Visible = false;
            lblMsg.Text = "No record(s) found";
            lblMsg.ForeColor = Color.Red;
            rptPortalRecord.DataSource = null;
            rptPortalRecord.DataBind();
            tblpagging.Visible = false;
            trgenerate.Visible = false;
        }
    }

    protected void lnkGenerateSlot_Click(object sender, EventArgs e)
    {
        try
        {
            test();
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

    public void GenerateSelectedRecords()
    {
        tblRecruitmentRecord.Visible = true;
        tblPortalRecord.Visible = false;
        trgenerate.Visible = false;
        tblpagging.Visible = true;
        foreach (RepeaterItem repeaterItem in rptPortalRecord.Items)
        {
            CheckBox control1 = (CheckBox)repeaterItem.FindControl("chkProtalSlots");
            HiddenField control2 = (HiddenField)repeaterItem.FindControl("hdnSlotDetaiId");
            Label control3 = (Label)repeaterItem.FindControl("Facility_Slot_Date");
            Label control4 = (Label)repeaterItem.FindControl("Start_Time");
            Label control5 = (Label)repeaterItem.FindControl("End_Time");
            DataTable dataTable1 = new DataTable();
            if (!string.IsNullOrEmpty(control3.Text))
            {
                DataTable dataTable2 = InsertSlot(Convert.ToDateTime(control3.Text));
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                if (control1.Checked)
                {
                    SqlCommand sqlCommand = new SqlCommand("XRec_Insert_SlotsDetailsCRM ", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@StartTime", control4.Text);
                    sqlCommand.Parameters.AddWithValue("@EndTime", control5.Text);
                    sqlCommand.Parameters.AddWithValue("@SlotCode", dataTable2.Rows[0]["Slot_Code"]);
                    sqlCommand.Parameters.AddWithValue("@MinDurationOfSlot", 1);
                    sqlCommand.Parameters.AddWithValue("@NoOfSeats", dataTable2.Rows[0]["NoOfSeats"]);
                    sqlCommand.Parameters.AddWithValue("@VenuePrefix", dataTable2.Rows[0]["VenuePrefix"]);
                    sqlCommand.Parameters.AddWithValue("@TimeDuration", 1);
                    sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
                    sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                    sqlCommand.ExecuteNonQuery();
                    if (control2.Value.ToString().Contains<char>(','))
                    {
                        string str1 = control2.Value.ToString();
                        char[] chArray = new char[1] { ',' };
                        foreach (string str2 in str1.Split(chArray))
                        {
                            if (str2 != "" && str2 != "," && str2 != null)
                                api.ReserveSlot(new ParameterType()
                                {
                                    FacilitySlotDetailID = Convert.ToInt32(str2),
                                    Comments = "Reserved By Recruitment System",
                                    UpdatedBy = UserCode,
                                    UpdatedDate = DateTime.Now,
                                    UpdatedIP = Request.UserHostAddress,
                                    AppointeeID = UserCode
                                }, Status.Scheduled);
                        }
                    }
                    else
                        api.ReserveSlot(new ParameterType()
                        {
                            FacilitySlotDetailID = Convert.ToInt32(control2.Value),
                            Comments = "Reserved By Recruitment System",
                            UpdatedBy = UserCode,
                            UpdatedDate = DateTime.Now,
                            UpdatedIP = Request.UserHostAddress,
                            AppointeeID = UserCode
                        }, Status.Scheduled);
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                    GetDetails();
                }
            }
        }
    }

    protected void btn_GeneratePortal(object sender, EventArgs e)
    {
        GenerateSelectedRecords();
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
            SlotGenerationPortalSyn.objDV = dataTable.DefaultView;
            PageNo = 0;
            trPagingControls.Attributes.Add("style", "display:block");
            lblMsg.Visible = false;
            ltrMsg.Visible = false;
            rptSlot.DataSource = ApplyPaging(SlotGenerationPortalSyn.objDV, PageNo);
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
            trPagingControls.Visible = false;
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
        SlotGenerationPortalSyn.objDV = dataTable.DefaultView;
        PageNo = 0;
        trPagingControls.Attributes.Add("style", "display:block");
        rptSlot.DataSource = ApplyPaging(SlotGenerationPortalSyn.objDV, PageNo);
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
        SqlCommand selectCommand = new SqlCommand("XRec_Insert_SlotsCRM ", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.AddWithValue("@SlotDate", slotDate);
        selectCommand.Parameters.AddWithValue("@VenueCode", ddlVenue.SelectedValue);
        selectCommand.Parameters.AddWithValue("@StartTime", 0);
        selectCommand.Parameters.AddWithValue("@EndTime", 24);
        selectCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        selectCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        new SqlDataAdapter(selectCommand).Fill(dataTable);
        return dataTable;
    }

    protected void InsertSlotDetails(int slotCode, int NoOfSeats)
    {
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
        objPDS.PageSize = SlotGenerationPortalSyn.PgSize;
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
        rptSlot.DataSource = ApplyPaging(SlotGenerationPortalSyn.objDV, PageNo);
        rptSlot.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptSlot.DataSource = ApplyPaging(SlotGenerationPortalSyn.objDV, PageNo);
        rptSlot.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptSlot.DataSource = ApplyPaging(SlotGenerationPortalSyn.objDV, PageNo);
        rptSlot.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptSlot.DataSource = ApplyPaging(SlotGenerationPortalSyn.objDV, PageNo);
        rptSlot.DataBind();
    }
    #endregion
}