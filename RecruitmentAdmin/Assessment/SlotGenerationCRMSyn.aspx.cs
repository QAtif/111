using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using ServiceReference1;



public partial class SlotGenerationCRMSyn : CustomBasePage//XRecBase
{
    #region Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    int MinDurationOfSlot;
    static DataView objDV = new DataView();
    PagedDataSource objPDS = new System.Web.UI.WebControls.PagedDataSource();
    static int PgSize;
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {

       
        if (!IsPostBack)
        {
            try
            {
                PgSize = 20;
                postedFromDate.Attributes.Add("readonly", "readonly");
                postedFromDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
                postedToDate.Attributes.Add("readonly", "readonly");
                postedToDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
                ShowData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
    public void test()
    {
        SlotManagementAPIClient api = new SlotManagementAPIClient();
        CompositeType ct = new CompositeType();
        ct.DateFrom = Convert.ToDateTime(postedFromDate.Value);
        ct.DateTo = Convert.ToDateTime(postedToDate.Value);
        ct.IsAdmin = false;

        DataTable dt = new DataTable();
        if (ddlVenue.SelectedValue=="1")
        dt = api.GetFacilitySlots(ct, Facility.BoardRoom);
        else
        if (ddlVenue.SelectedValue=="2")
        dt = api.GetFacilitySlots(ct, Facility.Library);
        else
        if (ddlVenue.SelectedValue=="3")
        dt = api.GetFacilitySlots(ct, Facility.TrainingRoom);
        else
        if (ddlVenue.SelectedValue=="4")
        dt = api.GetFacilitySlots(ct, Facility.BoardRoomIsl);
       

        DateTime dayFrom = Convert.ToDateTime(postedFromDate.Value);
        DateTime dayTo = Convert.ToDateTime(postedToDate.Value);
        DataTable ndt = new DataTable();
        ndt.Columns.Add("Facility_Slot_Detail_ID");
        ndt.Columns.Add("Facility_Slot_Date");
        ndt.Columns.Add("Start_Time");
        ndt.Columns.Add("End_Time");
        ndt.Columns.Add("Facility_Slot_ID");
        ndt.Columns.Add("VenueCode");
        if (dt != null && dt.Rows.Count > 0)
        {
            int duration;
         
            int startTime = Convert.ToDateTime(dt.Rows[0]["Start_Time"].ToString()).Minute;           
            int endTime = Convert.ToDateTime(dt.Rows[0]["End_Time"].ToString()).Minute;

            if (startTime != 0 || endTime!=0)
                duration = 2;
            else
                duration = 1;
            int ExistCount;
            int i;
            string Facility_Slot_Detail_ID;
           
            while (dayFrom <= dayTo)
            {
                if (dt.Select("Facility_Slot_Date='" + dayFrom.ToString() + "'").Length > 0)
                {
                    i = 0;
                    ;
                    while (i < 24)
                    {
                        DataTable dtselect = new DataTable();
                       Facility_Slot_Detail_ID = string.Empty;
                       if (i == 0)
                        ExistCount = dt.Select("Start_Time  like '" + i.ToString() + "0:%' and Facility_Slot_Date='" + dayFrom.ToString() + "'").Length; 
                       else
                           if (i > 0 && i<10)
                               ExistCount = dt.Select("Start_Time  like '0" + i.ToString() + ":%' and Facility_Slot_Date='" + dayFrom.ToString() + "'").Length; 
                        else
                           ExistCount = dt.Select("Start_Time  like '" + i.ToString() + ":%' and Facility_Slot_Date='" + dayFrom.ToString() + "'").Length; 
                        if ( ExistCount== duration)
                        {
                            if (i == 0)
                              dtselect = dt.Select("Start_Time  like '" + i.ToString() + "0:%' and Facility_Slot_Date='" + dayFrom.ToString() + "'").CopyToDataTable();
                            else
                                if (i > 0 && i < 10)
                                    dtselect = dt.Select("Start_Time  like '0" + i.ToString() + ":%' and Facility_Slot_Date='" + dayFrom.ToString() + "'").CopyToDataTable();
                            else

                               dtselect = dt.Select("Start_Time  like '" + i.ToString() + ":%' and Facility_Slot_Date='" + dayFrom.ToString() + "'").CopyToDataTable();
                                foreach (DataRow ddr in dtselect.Rows)
                                    Facility_Slot_Detail_ID = Facility_Slot_Detail_ID + "," + Convert.ToString(ddr["Facility_Slot_Detail_ID"]);
                                DataRow ndr = ndt.NewRow();
                            
                            ndr["Start_Time"] = i;
                            if (i != 23)
                                ndr["End_Time"] = i+1;
                            else
                                ndr["End_Time"] = 0;
                            ndr["Facility_Slot_ID"] = 0;
                            ndr["VenueCode"] = ddlVenue.SelectedValue.ToString();
                            ndr["Facility_Slot_Date"] = dayFrom;
                            ndr["Facility_Slot_Detail_ID"] = Facility_Slot_Detail_ID;
                            ndt.Rows.Add(ndr);
                        }
                        i = i + 1;
                    }
                    dayFrom = dayFrom.AddDays(1);

                }
            }
        }
        dayFrom = Convert.ToDateTime(postedFromDate.Value);
        dayTo = Convert.ToDateTime(postedToDate.Value);
        while (dayFrom <= dayTo)
        {

            DataTable dtslotCode = new DataTable();
            dtslotCode= InsertSlot(dayFrom);
            DataTable dtCurrentDate = ndt.Select("Facility_Slot_Date = '" +dayFrom.ToString()+"'").CopyToDataTable();
            foreach (DataRow dr in dtCurrentDate.Rows)
            {
                //DataTable dtSlot = new DataTable();
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                SqlCommand sqlCommand = new SqlCommand("XRec_Insert_SlotsDetailsCRM ", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StartTime", dr["Start_Time"].ToString());
                sqlCommand.Parameters.AddWithValue("@EndTime", dr["End_Time"].ToString());
                sqlCommand.Parameters.AddWithValue("@SlotCode", dtslotCode.Rows[0]["Slot_Code"]);
                sqlCommand.Parameters.AddWithValue("@MinDurationOfSlot", 1);
                sqlCommand.Parameters.AddWithValue("@NoOfSeats", dtslotCode.Rows[0]["NoOfSeats"]);
                sqlCommand.Parameters.AddWithValue("@VenuePrefix", dtslotCode.Rows[0]["VenuePrefix"]);
                sqlCommand.Parameters.AddWithValue("@TimeDuration", 1);               
                sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
                sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);              
                sqlCommand.ExecuteNonQuery();
                if (dr["Facility_Slot_Detail_ID"].ToString().Contains(','))
                {
                    string[] slotCode = dr["Facility_Slot_Detail_ID"].ToString().Split(',');
                    foreach (string str in slotCode)
                    {
                        if (str != "" && str != "," && str != null)
                        {
                            StatusParameterType spt = new StatusParameterType();
                            spt.FacilitySlotDetailID = Convert.ToInt32(str);
                            spt.Comments = "Slots resereved By Recruitment";
                            spt.UpdatedBy = UserCode;
                            spt.UpdatedDate = DateTime.Now;
                            spt.UpdatedIP = "UserHostAddress";
                            api.UpdateSlotStatus(spt, Status.Pending);
                        }
                    }
                }
                else
                {
                    StatusParameterType spt = new StatusParameterType();
                    spt.FacilitySlotDetailID = Convert.ToInt32(dr["Facility_Slot_Detail_ID"].ToString());
                    spt.Comments = "Slots resereved By Recruitment";
                    spt.UpdatedBy = UserCode;
                    spt.UpdatedDate = DateTime.Now;
                    spt.UpdatedIP = "UserHostAddress";
                    api.UpdateSlotStatus(spt, Status.Pending);
                }
               
               
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }



            dayFrom = dayFrom.AddDays(1);
        }



        //sqlCommand.Parameters.AddWithValue("@SlotDate", slotDate);
        //sqlCommand.Parameters.AddWithValue("@VenueCode", ddlVenue.SelectedValue);
        //sqlCommand.Parameters.AddWithValue("@StartTime", ddlFromTime.SelectedValue);

        //sqlCommand.Parameters.AddWithValue("@EndTime", ddlToTime.SelectedValue);
        //sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        //sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
    }
    protected void rptSlot_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            try
            {
                ImageButton btnDelete = (ImageButton)e.Item.FindControl("btnDelete");
                Label lblSno = (Label)e.Item.FindControl("lblSno");
                lblSno.Text = Convert.ToString((e.Item.ItemIndex + 1));
                btnDelete.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete this Slot?')");
                HiddenField hfSlotCode = (HiddenField)e.Item.FindControl("hfSlotCode");
                HtmlAnchor btnEdit = (HtmlAnchor)e.Item.FindControl("btnEdit");
                string RedirectingLink = "AddEditVenue.aspx?" + "vid" + "=" + hfSlotCode.Value;
                btnEdit.Attributes.Add("href", RedirectingLink);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
            }
        }
    }
    protected void rptSlot_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("XRec_Delete_CandidateSlot", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandidateSlotCode", e.CommandArgument);
                sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
                sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                GetDetails();
            }

            catch (Exception exp1)
            {
                ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, exp1.StackTrace, exp1, UserCode.ToString());
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
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
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

    }
    protected void lnkGenerateSlot_Click(object sender, EventArgs e)
    {
        try
        {
            test();
            GetDetails();
            //if (connection.State == ConnectionState.Closed)
            //    connection.Open();
            //DateTime slotDate;
            //slotDate = Convert.ToDateTime(postedFromDate.Value);
            //int count = 0;
            //ltrMsg.Text = string.Empty;
            //lblMsg.Visible = false;
            //ltrMsg.Visible = false;
            //if (CheckTimeSlotDuration(slotDate, int.Parse(ddlToTime.SelectedValue) - int.Parse(ddlFromTime.SelectedValue)))
            //{
            //    while (slotDate <= Convert.ToDateTime(postedToDate.Value))
            //    {
            //        if (CheckIfAvailable(slotDate))
            //        {
            //            DataTable dt = InsertSlot(slotDate);
            //            if (dt.Rows.Count > 0)
                //           InsertSlotDetails(int.Parse(dt.Rows[0]["SlotCode"].ToString()), int.Parse(dt.Rows[0]["NoOfSeats"].ToString()));
            //            count++;
            //        }
            //        else
            //        {
            //            ltrMsg.Text = ltrMsg.Text + "Slots Already Exist from " + ddlFromTime.SelectedValue + ":00" + "  To " + ddlToTime.SelectedValue + ":00 of Date: " + slotDate.ToString("MMM dd, yyyy") + " <br >";
            //            ltrMsg.Visible = true;
            //        }
            //        slotDate = slotDate.AddDays(1);

            //    }

            //    if (count > 0)
            //    {
            //        lblMsg.Text = "Slots Created Successfully.";
            //        lblMsg.ForeColor = System.Drawing.Color.Green;
            //        lblMsg.Visible = true;
            //        ShowSlots();
            //    }
            //}
            //else
            //{
            //    ltrMsg.Text = "Selected Time is less than Slot Duration. Slot Duration Should be minimum " + MinDurationOfSlot + " Hours.";
            //    ltrMsg.Visible = true;
            //}
        }
        catch (Exception ex)
        {
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
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
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
    #endregion

    #region Methods
    public void GetVenue()
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_Select_Venue ", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ddlVenue.DataSource = dt;
                ddlVenue.DataTextField = "VenueName";
                ddlVenue.DataValueField = "VenueCode";
                ddlVenue.DataBind();
            }
        }
    }
    public void GetDetails()
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_Select_SlotsDetails ", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SlotDateFrom", postedFromDate.Value);
        sqlCommand.Parameters.AddWithValue("@SlotDateTo", postedToDate.Value);
        sqlCommand.Parameters.AddWithValue("@VenueCode", ddlVenue.SelectedValue);
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            objDV = dt.DefaultView;
            PageNo = 0;
            trPagingControls.Attributes.Add("style", "display:block");


            lblMsg.Visible = false;
            ltrMsg.Visible = false;
            //tblMsg.Visible = false;
            rptSlot.DataSource = ApplyPaging(objDV, PageNo);
            //rptSlot.DataSource = dt;
            rptSlot.DataBind();
        }
        else
        {
            lblMsg.Visible = true;
            //tblMsg.Visible = true;
            ltrMsg.Visible = false;

            lblMsg.Text = "No record(s) found";
            lblMsg.ForeColor = System.Drawing.Color.Red;
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
            //throw ex;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());

        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

    }
    protected void ShowSlots()
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_Select_SlotsDetails ", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SlotDateFrom", postedFromDate.Value);
        sqlCommand.Parameters.AddWithValue("@SlotDateTo", postedToDate.Value);
        sqlCommand.Parameters.AddWithValue("@VenueCode", ddlVenue.SelectedValue);
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            objDV = dt.DefaultView;
            PageNo = 0;
            trPagingControls.Attributes.Add("style", "display:block");

            rptSlot.DataSource = ApplyPaging(objDV, PageNo);
            rptSlot.DataBind();
        }





    }
    protected bool CheckTimeSlotDuration(DateTime slotDate, int TimeDuration)
    {
        bool available = false;
        DataTable dtSlot = new DataTable();
        SqlCommand sqlCommand = new SqlCommand("XRec_CheckTimeSlotDuration", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@VenueCode", ddlVenue.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@TimeDuration", TimeDuration);
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        adapter.Fill(dtSlot);
        if (dtSlot.Rows.Count > 0)
        {
            available = Convert.ToBoolean(dtSlot.Rows[0]["Available"].ToString());
            MinDurationOfSlot = int.Parse(dtSlot.Rows[0]["MinDurationOfSlot"].ToString());
        }

        return available;
    }
    protected bool CheckIfAvailable(DateTime slotDate)
    {
        bool available = false;
        DataTable dtSlot = new DataTable();
        SqlCommand sqlCommand = new SqlCommand("XRec_Check_Slots", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SlotDate", slotDate);
        sqlCommand.Parameters.AddWithValue("@VenueCode", ddlVenue.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@StartTime", ddlFromTime.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@EndTime", ddlToTime.SelectedValue);
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        adapter.Fill(dtSlot);
        if (dtSlot.Rows.Count > 0)
        {
            available = Convert.ToBoolean(dtSlot.Rows[0]["Available"].ToString());
        }

        return available;
    }
    protected DataTable InsertSlot(DateTime slotDate)
    {
        DataTable dtSlot = new DataTable();
        SqlCommand sqlCommand = new SqlCommand("XRec_Insert_SlotsCRM ", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SlotDate", slotDate);
        sqlCommand.Parameters.AddWithValue("@VenueCode", ddlVenue.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@StartTime",0);
        sqlCommand.Parameters.AddWithValue("@EndTime", 24);
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        adapter.Fill(dtSlot);
        return dtSlot;
    }
    protected void InsertSlotDetails(int slotCode, int NoOfSeats)
    {

    }
    public void GetTimeByVenue()
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_Select_VenueTimeRangeByVenueCode", connection);
        sqlCommand.Parameters.AddWithValue("@VenueCode", ddlVenue.SelectedValue);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ddlFromTime.SelectedValue = dt.Rows[0]["StartTime"].ToString();
                ddlToTime.SelectedValue = dt.Rows[0]["EndTime"].ToString();
            }
        }
    }
    #endregion

    #region Paging
    private int PageNo
    {
        get
        {
            if (ViewState["PageNo"] != null)
                return Convert.ToInt32(ViewState["PageNo"]);
            else
                return 0;
        }
        set
        {
            ViewState["PageNo"] = value;
        }
    }

    public PagedDataSource ApplyPaging(System.Data.DataView DV, int PageNo)
    {
        objPDS.DataSource = DV;
        objPDS.AllowPaging =
        true;
        //objPDS.PageSize = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["PgSize"]); 
        objPDS.PageSize = PgSize;
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
            else
                if (objPDS.CurrentPageIndex == (objPDS.PageCount - 1))
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
        {
            //trLegends.Attributes.Add("style", "display:none");
            trPagingControls.Attributes.Add("style", "display:none");
        }
        return objPDS;
    }
    // Takes to the first page 
    protected void lnkbtnFirstPage_Click(object sender, EventArgs e)
    {
        PageNo = 0;
        rptSlot.DataSource = ApplyPaging(objDV, PageNo);
        rptSlot.DataBind();
    }
    // Takes To The Previous Page 
    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        PageNo--;
        rptSlot.DataSource = ApplyPaging(objDV, PageNo);
        rptSlot.DataBind();
    }
    // takes to the next page 
    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        PageNo++;
        rptSlot.DataSource = ApplyPaging(objDV, PageNo);
        rptSlot.DataBind();
    }
    // takes to the last page 
    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo =
        Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptSlot.DataSource = ApplyPaging(objDV, PageNo);
        rptSlot.DataBind();
    }
    #endregion
}