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

public partial class SlotGeneration : XRecBase
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);
    int MinDurationOfSlot;
    static DataView objDV = new DataView();
    PagedDataSource objPDS = new System.Web.UI.WebControls.PagedDataSource();
    static int PgSize;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PgSize = 20;
            postedFromDate.Attributes.Add("readonly", "readonly");
            postedFromDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            postedToDate.Attributes.Add("readonly", "readonly");
            postedToDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            ShowData();
        }
    }
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
            rptSlot.DataSource =ApplyPaging(objDV, PageNo);
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
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserID.ToString());

        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

    }
    protected void rptSlot_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
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
    }

    protected void rptSlot_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);

            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("XRec_Delete_CandidateSlot", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandidateSlotCode", e.CommandArgument);
                sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
                sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                GetDetails();
            }

            catch (Exception exp1)
            {
                //throw exp1;
                ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, exp1.StackTrace, exp1, UserID.ToString());
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
            //throw ex;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserID.ToString());
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
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            DateTime slotDate;
            slotDate = Convert.ToDateTime(postedFromDate.Value);            
            int count = 0;
            ltrMsg.Text = string.Empty;
            lblMsg.Visible = false;
            ltrMsg.Visible = false;
            if (CheckTimeSlotDuration(slotDate,int.Parse(ddlToTime.SelectedValue) - int.Parse(ddlFromTime.SelectedValue)))
            {
                while (slotDate <= Convert.ToDateTime(postedToDate.Value))
                {
                    if (CheckIfAvailable(slotDate))
                    {
                        DataTable dt = InsertSlot(slotDate);
                        if (dt.Rows.Count > 0)
                            InsertSlotDetails(int.Parse(dt.Rows[0]["SlotCode"].ToString()), int.Parse(dt.Rows[0]["NoOfSeats"].ToString()));
                        count++;
                    }
                    else
                    {
                        ltrMsg.Text = ltrMsg.Text + "Slots Already Exist from " + ddlFromTime.SelectedValue + ":00" + "  To " + ddlToTime.SelectedValue + ":00 of Date: " + slotDate.ToString("MMM dd, yyyy") + " <br >";
                        ltrMsg.Visible = true;
                    }
                    slotDate = slotDate.AddDays(1);

                }

                if (count > 0)
                {                    
                    lblMsg.Text = "Slots Created Successfully.";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Visible = true;
                    ShowSlots();
                }
            }
            else
            {
                ltrMsg.Text = "Selected Time is less than Slot Duration. Slot Duration Should be minimum " + MinDurationOfSlot +  " Hours.";
                ltrMsg.Visible = true;
            }
        }
        catch (Exception ex)
        {
            //throw ex;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserID.ToString());
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
        SqlCommand sqlCommand = new SqlCommand("XRec_Insert_Slots ", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SlotDate", slotDate);
        sqlCommand.Parameters.AddWithValue("@VenueCode", ddlVenue.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@StartTime", ddlFromTime.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@EndTime", ddlToTime.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        adapter.Fill(dtSlot);
        return dtSlot;
    }
    protected void InsertSlotDetails(int slotCode, int NoOfSeats)
    {

    }
    protected void ddlVenue_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetTimeByVenue();
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