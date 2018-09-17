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
using System.Globalization;
using XRecruitmentStatusLibrary;
using ErrorLog;


public partial class BulkSchduleCandidate : CustomBasePage
{
    #region Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    public string profileID;
    public string CandidateID;
    public string QueryString;
    public bool Istest;
    public static int statusCode = 0;
    public static string SlotsID;
    public string DepartmentCode;
    public static string CandidateSlots;
    public static string Requisition_Code;
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;
    #endregion
    #region Events
    public static string StatusCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            if (QueryStringVar != null)
                secQueryString = new SecureQueryString(QueryStringVar);
            StatusCode = ddlStatus.SelectedValue;
            // SetView();
            if (!IsPostBack)
            {
                //postedFromDate.Attributes.Add("readonly", "readonly");
                //postedFromDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
                //postedToDate.Attributes.Add("readonly", "readonly");
                //postedToDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
                // ShowData();



                //setview();
                bindData();
                txtSelectedDate.Text = DateTime.UtcNow.ToString("yyyy-MM-dd");
                GetUnreservedSlots();

            }
        }
        catch (Exception ex)
        {
            //  ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }
    protected void Save_click(object sender, EventArgs e)
    {
        if (ddlSlotTime.SelectedValue != "-1" && ddlcategories.SelectedValue != "-1")
        {

            string CPMCode = string.Empty;

            foreach (RepeaterItem rpt in rptCandidates.Items)
            {
                HtmlInputCheckBox chkCandidate = (HtmlInputCheckBox)rpt.FindControl("chkCandidate");
                HiddenField hdnCandCode = (HiddenField)rpt.FindControl("hdnCandCode");


                if (chkCandidate.Checked)
                {

                    string[] slottime = ddlSlotTime.SelectedItem.Text.Split('-');
                    string starttimee = String.Format("{0:HH:mm}", (DateTime)Convert.ToDateTime(slottime[0]));
                    string endtimee = String.Format("{0:HH:mm}", (DateTime)Convert.ToDateTime(slottime[1]));
                    string[] starttime = starttimee.Split(':');
                    string[] endtime = endtimee.Split(':');

                    SqlCommand sqlCommand = new SqlCommand("dbo.XRec_ReserveslotbyCandidate_admin ", connection);
                    sqlCommand.Parameters.AddWithValue("@slotStartTime", starttime[0]);
                    sqlCommand.Parameters.AddWithValue("@slotEndTime", endtime[0]);
                    sqlCommand.Parameters.AddWithValue("@category_code", ddlcategories.SelectedValue);
                    sqlCommand.Parameters.AddWithValue("@SlotDate", txtSelectedDate.Text);
                    sqlCommand.Parameters.AddWithValue("@candidateCode", hdnCandCode.Value);
                    sqlCommand.Parameters.AddWithValue("@updatedIp", "");
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                }
                CPMCode += hdnCandCode.Value + ",";
            }
        }
    }
    protected void GetUnreservedSlots(object sender, System.EventArgs e)
    {

        if (Convert.ToDateTime(txtSelectedDate.Text).Date >= DateTime.Now.Date)
        {
            // lblerror.Text = "";
            GetUnreservedSlots();
        }
        else
        {
            CustomValidator1.IsValid = false;
            //lblerror.Text = "Date must be greater than or equal to current date.";
            ddlSlotTime.Items.Clear();
            ddlSlotTime.Items.Add(new ListItem("--No Slot Available--", "-1"));
        }

    }
    public void GetUnreservedSlots()
    {
        if (ddlcategories.SelectedValue != "-1" && ddlVenue.SelectedValue != "-1")
        {
            SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Select_AvailableSLots_Admin ", connection);
            sqlCommand.Parameters.AddWithValue("@SlotDate", txtSelectedDate.Text);
            sqlCommand.Parameters.AddWithValue("@categoryCode ", ddlcategories.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@VenueCode", ddlVenue.SelectedValue);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ddlSlotTime.DataSource = null;
                ddlSlotTime.Items.Clear();
                ddlSlotTime.DataSource = dt;
                ddlSlotTime.DataTextField = "SlotTime";
                ddlSlotTime.DataValueField = "availableSeats";
                ddlSlotTime.DataBind();
                ddlSlotTime.Items.Insert(0, new ListItem("--Please Select--", "-1"));
                lblCount.Text = "";

            }
            else
            {
                ddlSlotTime.Items.Clear();
                ddlSlotTime.Items.Insert(0, new ListItem("--No Slots Available--", "-1"));
            }
        }
        else
        {
            ddlSlotTime.Items.Clear();
            ddlSlotTime.Items.Insert(0, new ListItem("--No Slots Available--", "-1"));
        }
    }
    protected void btnSearchCandidate_Click(object sender, EventArgs e)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_SerachCandidateForBulkSchedule ", connection);
        sqlCommand.Parameters.AddWithValue("@Category_Code", ddlcategories.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@Status_code", ddlStatus.SelectedValue);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            tblCandidate.Style.Add("display", "");
            rptCandidates.DataSource = dt;
            rptCandidates.DataBind();
        }
        else
        {
            tblCandidate.Style.Add("display", "none");
            rptCandidates.DataSource = null;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string[] slottime = ddlSlotTime.Text.Split('-');
            string starttimee = String.Format("{0:HH:mm}", (DateTime)Convert.ToDateTime(slottime[0]));
            string endtimee = String.Format("{0:HH:mm}", (DateTime)Convert.ToDateTime(slottime[1]));
            string[] starttime = starttimee.Split(':');
            string[] endtime = endtimee.Split(':');

            SqlCommand sqlCommand = new SqlCommand("dbo.XRec_ReserveslotbyCandidate ", connection);
            sqlCommand.Parameters.AddWithValue("@slotStartTime", starttime[0]);
            sqlCommand.Parameters.AddWithValue("@slotEndTime", endtime[0]);
            sqlCommand.Parameters.AddWithValue("@TestDuration", Convert.ToInt16(endtime[0]) - Convert.ToInt16(starttime[0]));
            sqlCommand.Parameters.AddWithValue("@SlotDate", txtSelectedDate.Text);
            sqlCommand.Parameters.AddWithValue("@candidateCode", 1);
            sqlCommand.Parameters.AddWithValue("@updatedIp", "");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["is_Done"].ToString() == "1")
                {
                    //StatusManagement.MarkLifeCycleStatus(connection, int.Parse(CID), Constants.ModuleCode.LifeCycleStatus,
                    //                             Constants.CandidateLifeCycleStatus.SchedulingdoneTestPending, Request.UserHostAddress.ToString(), int.Parse(CID));
                }
                //divmain.Visible = false;
                //divmsg.Visible = true;
                //lblmessage.Text = dt.Rows[0][0].ToString();
                // ScriptManager.RegisterClientScriptBlock(this, GetType(), "pass", "refreshParentArea();", true);
                //  ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "window.parent.location.reload();", true);
                ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript>parent.location.href = parent.location.href;</script>", false);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript>window.parent.location.reload();</script>", false);
            }
            else
                lbltime.Text = "no date found";
        }
        catch (Exception ex)
        {
            //ErrorLog.LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CID);
        }

    }
    protected void OnCategoryChange(object sender, EventArgs e)
    {
        //GetUnreservedSlots();
        //SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_BulkSchedule_OnCategoryChange ", connection);
        //if (ddlcategories.SelectedValue != "-1")
        //    sqlCommand.Parameters.AddWithValue("@Category_Code", ddlcategories.SelectedValue);
        //if (ddlStatus.SelectedValue != "-1")
        //    sqlCommand.Parameters.AddWithValue("@Status_code", ddlStatus.SelectedValue);
        //sqlCommand.CommandType = CommandType.StoredProcedure;
        //SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        //DataSet ds = new DataSet();
        //adapter.Fill(ds);

        //if (ds.Tables.Count >= 1)
        //{
        //    ddlStatus.DataSource = ds.Tables[0];
        //    ddlStatus.DataTextField = "Status_Name";
        //    ddlStatus.DataValueField = "Status_Code";
        //    ddlStatus.DataBind();
        //    ddlStatus.Items.Insert(0, new ListItem("--Please Select--", "-1"));
        //    ddlStatus.SelectedValue = StatusCode;
        //}
        //else
        //{
        //    ddlStatus.Items.Clear();
        //    ddlStatus.Items.Insert(0, new ListItem("--No Status Available--", "-1"));
        //}
        //if (ds.Tables.Count >= 2)
        //{
        //    ddlVenue.DataSource = ds.Tables[1];
        //    ddlVenue.DataTextField = "VenueName";
        //    ddlVenue.DataValueField = "VenueCode";
        //    ddlVenue.DataBind();
        //    ddlVenue.Items.Insert(0, new ListItem("--Please Select--", "-1"));
        //}
        //else
        //{
        //    ddlVenue.Items.Clear();
        //    ddlVenue.Items.Insert(0, new ListItem("--No Venue Available--", "-1"));
        //}
        //if (ds.Tables.Count >= 3)
        //{
        //    rptCandidates.DataSource = ds.Tables[2];
        //    rptCandidates.DataBind();
        //}
        //else
        //{
        //    rptCandidates.DataSource = null;
        //}

        if (ddlcategories.SelectedValue != "-1")
        {
            trStatus.Style.Add("display", "");
        }
        else
        {
            trStatus.Style.Add("display", "none");
            trVanue.Style.Add("display", "none");
        }
    }

    protected void OnStatusChange(object sender, EventArgs e)
    {

        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_BulkSchedule_OnStatusChange ", connection);
        if (ddlcategories.SelectedValue != "-1")
            sqlCommand.Parameters.AddWithValue("@Category_Code", ddlcategories.SelectedValue);
        if (ddlStatus.SelectedValue != "-1")
            sqlCommand.Parameters.AddWithValue("@Status_code", ddlStatus.SelectedValue);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        DataSet ds = new DataSet();
        adapter.Fill(ds);

        if (ds.Tables.Count >= 1)
        {
            ddlVenue.DataSource = ds.Tables[0];
            ddlVenue.DataTextField = "VenueName";
            ddlVenue.DataValueField = "VenueCode";
            ddlVenue.DataBind();
            ddlVenue.Items.Insert(0, new ListItem("--Please Select--", "-1"));
        }
        else
        {
            ddlVenue.Items.Clear();
            ddlVenue.Items.Insert(0, new ListItem("--No Venue Available--", "-1"));
        }
        if (ds.Tables.Count >= 2)
        {
            rptCandidates.DataSource = ds.Tables[1];
            rptCandidates.DataBind();
        }
        else
        {
            rptCandidates.DataSource = null;
        }
        if (ddlStatus.SelectedValue != "-1")
        {
            trVanue.Style.Add("display", "");
            trStatus.Style.Add("display", "");

        }
        else
        {
            trVanue.Style.Add("display", "none");

        }
        trSlots.Style.Add("display", "none");
        trSearchBtn.Style.Add("display", "none");
        tblCandidate.Style.Add("display", "none");
    }
    protected void OnVanueChange(object sender, EventArgs e)
    {
        if (ddlVenue.SelectedValue != "-1")
        {
            trVanue.Style.Add("display", "");
            trSlots.Style.Add("display", "");
            trSearchBtn.Style.Add("display", "");
            GetUnreservedSlots();
        }
        else
        {
            trSearchBtn.Style.Add("display", "none");
            trSlots.Style.Add("display", "none");
           
        }
        tblCandidate.Style.Add("display", "none");

    }



    protected void OnSlotChange(object sender, EventArgs e)
    {
        if (ddlSlotTime.SelectedValue != "-1")
            lblCount.Text = "Total available seat(s) : " + ddlSlotTime.SelectedValue;
        else
            lblCount.Text = "";


    }
    protected void OnChange(object sender, EventArgs e)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_BindDataForBulkSchedule ", connection);
        if (ddlcategories.SelectedValue != "-1")
            sqlCommand.Parameters.AddWithValue("@Category_Code", ddlcategories.SelectedValue);
        if (ddlStatus.SelectedValue != "-1")
            sqlCommand.Parameters.AddWithValue("@Status_code", ddlStatus.SelectedValue);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        DataSet ds = new DataSet();
        adapter.Fill(ds);
        if (ds.Tables.Count >= 1)
        {
            ddlcategories.DataSource = ds.Tables[0];
            ddlcategories.DataTextField = "Category_Name";
            ddlcategories.DataValueField = "Category_Code";
            ddlcategories.DataBind();
            ddlcategories.Items.Insert(0, new ListItem("--Please Select--", "-1"));
        }
        else
        {
            ddlSlotTime.Items.Clear();
            ddlSlotTime.Items.Insert(0, new ListItem("--No Category Available--", "-1"));
        }
        if (ds.Tables.Count >= 2)
        {
            ddlStatus.DataSource = ds.Tables[1];
            ddlStatus.DataTextField = "Status_Name";
            ddlStatus.DataValueField = "Status_Code";
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new ListItem("--Please Select--", "-1"));
        }
        else
        {
            ddlStatus.Items.Clear();
            ddlStatus.Items.Insert(0, new ListItem("--No Status Available--", "-1"));
        }
        if (ds.Tables.Count >= 3)
        {
            ddlVenue.DataSource = ds.Tables[2];
            ddlVenue.DataTextField = "VenueName";
            ddlVenue.DataValueField = "VenueCode";
            ddlVenue.DataBind();
            ddlVenue.Items.Insert(0, new ListItem("--Please Select--", "-1"));
        }
        else
        {
            ddlVenue.Items.Clear();
            ddlVenue.Items.Insert(0, new ListItem("--No Venue Available--", "-1"));
        }
        if (ds.Tables.Count >= 4)
        {
            rptCandidates.DataSource = ds.Tables[3];
            rptCandidates.DataBind();
        }
        else
        {
            rptCandidates.DataSource = null;
        }
    }



    #endregion
    #region Methods
    public void bindData()
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_BindDataForBulkSchedule ", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        DataSet ds = new DataSet();
        adapter.Fill(ds);
        if (ds.Tables.Count >= 1)
        {
            ddlcategories.DataSource = ds.Tables[0];
            ddlcategories.DataTextField = "Category_Name";
            ddlcategories.DataValueField = "Category_Code";
            ddlcategories.DataBind();
            ddlcategories.Items.Insert(0, new ListItem("--Please Select--", "-1"));
        }
        else
        {
            ddlSlotTime.Items.Clear();
            ddlSlotTime.Items.Insert(0, new ListItem("--No Category Available--", "-1"));
        }
        if (ds.Tables.Count >= 2)
        {
            ddlStatus.DataSource = ds.Tables[1];
            ddlStatus.DataTextField = "Status_Name";
            ddlStatus.DataValueField = "Status_Code";
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new ListItem("--Please Select--", "-1"));
        }
        else
        {
            ddlStatus.Items.Clear();
            ddlStatus.Items.Insert(0, new ListItem("--No Status Available--", "-1"));
        }
        if (ds.Tables.Count >= 3)
        {
            ddlVenue.DataSource = ds.Tables[2];
            ddlVenue.DataTextField = "VenueName";
            ddlVenue.DataValueField = "VenueCode";
            ddlVenue.DataBind();
            ddlVenue.Items.Insert(0, new ListItem("--Please Select--", "-1"));
        }
        else
        {
            ddlVenue.Items.Clear();
            ddlVenue.Items.Insert(0, new ListItem("--No Venue Available--", "-1"));
        }
        if (ds.Tables.Count >= 4)
        {
            rptCandidates.DataSource = ds.Tables[3];
            rptCandidates.DataBind();
        }
        else
        {
            rptCandidates.DataSource = null;
        }
    }

    public void RefreshParent()
    {
        if (!string.IsNullOrEmpty(secQueryString["pgno"].ToString()))
        {
            if (secQueryString["pgno"].ToString() == "1")
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "pass", "refreshParentCandidateDetail();", true);
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "pass", "refreshParent();", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "pass", "refreshParent();", true);
        }
    }
    #endregion

}