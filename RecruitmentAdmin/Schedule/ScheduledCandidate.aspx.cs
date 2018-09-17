
using ErrorLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using XRecruitmentStatusLibrary;

public partial class ScheduledCandidate : CustomBasePage, IRequiresSessionState
{
    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    private SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());

    public string UpdatedIp;
    public string UpdatedBy;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            UpdatedBy = UserCode.ToString();
            UpdatedIp = USERIP;
            if (!chkIsInclude.Checked)
                rfvreff.Enabled = true;
            else
                rfvreff.Enabled = false;
            if (IsPostBack)
                return;
            if (chkIsInclude.Checked)
                rfvreff.Enabled = false;
            else
                rfvreff.Enabled = true;
            postedFromDate.Attributes.Add("readonly", "readonly");
            //postedFromDate.Value = DateTime.Now.AddHours(10.0).ToString("MMM dd, yyyy"); // One Day after the current date
            postedFromDate.Value = DateTime.Now.ToString("MMM dd, yyyy");    //Current Date
            bindFields();
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

    private void bindFields()
    {
        DataSet dataSet = new DataSet();
        SqlCommand selectCommand = new SqlCommand("dbo.Xrec_Select_FilterFields_TodaySchedule", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet == null)
            return;
        ddlCity.DataSource = dataSet.Tables[0];
        ddlCity.DataTextField = "city";
        ddlCity.DataValueField = "city_code";
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, "All City");
        if (dataSet.Tables.Count <= 0)
            return;
        ddlDepartment.DataSource = dataSet.Tables[1];
        ddlDepartment.DataTextField = "Domain_Name";
        ddlDepartment.DataValueField = "Domain_Code";
        ddlDepartment.DataBind();
        ddlDepartment.Items.Insert(0, new ListItem(" All Department ", "0"));
    }

    protected void rptTestSheduled_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DoneTour")
        {
            try
            {
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }
        if (e.CommandName == "IsArrived")
        {
            try
            {
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }
        if (!(e.CommandName == "Save"))
            return;
        try
        {
            string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + "Official/" + e.CommandArgument.ToString() + "/";
            FileUpload control1 = (FileUpload)e.Item.FindControl("fuPic");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnCandidateCode");
            if (!control1.HasFile)
                return;
            lblMsg.Visible = false;
            GeneralMethods.FileBrowse(control1, FolderPath, "InitialPicture");
            string str = FolderPath + "InitialPicture" + Path.GetExtension(control1.FileName);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateInitialPictatus", connection);
            sqlCommand.Parameters.AddWithValue("@CandidateCode", control2.Value);
            sqlCommand.Parameters.AddWithValue("@Path", str);
            sqlCommand.Parameters.AddWithValue("@InitialPicStatus", 1);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
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

    protected void btnSave_Upload(object sender, EventArgs e)
    {
        string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + "Official/" + hdnCandidateCode.Value + "/";
        if (!FuPic.HasFile)
            return;
        lblMsg.Visible = false;
        GeneralMethods.FileBrowse(FuPic, FolderPath, "InitialPicture");
        string str = FolderPath + "InitialPicture" + Path.GetExtension(FuPic.FileName);
        connection.Open();
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateInitialPictatus", connection);
        sqlCommand.Parameters.AddWithValue("@CandidateCode", hdnCandidateCode.Value);
        sqlCommand.Parameters.AddWithValue("@Path", str);
        sqlCommand.Parameters.AddWithValue("@InitialPicStatus", 1);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.ExecuteNonQuery();
        Page.RegisterStartupScript("REFRESHpAGESCRIPT", "<script language=JavaScript>location.reload(true);</script>");
    }

    protected void rptInterViewScheduled_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DoneTour")
        {
            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateTourStatus", connection);
                sqlCommand.Parameters.AddWithValue("@CandidateCode", e.CommandArgument);
                sqlCommand.Parameters.AddWithValue("@CandidateStatus", 1);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                InsertScheduledComments(Convert.ToInt32(e.CommandArgument), "Tour Done");
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
        if (e.CommandName == "IsArrived")
        {
            try
            {
                HiddenField control = (HiddenField)e.Item.FindControl("hdnReservedSlotCode");
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Update_ScheduledIsArrived", connection);
                sqlCommand.Parameters.AddWithValue("@ReservedSlotCode", Convert.ToInt32(control.Value));
                sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
                sqlCommand.Parameters.AddWithValue("@Updated_IP", USERIP);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                InsertScheduledComments(Convert.ToInt32(e.CommandArgument), "Candidate Arrived Final Interview");
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
        if (!(e.CommandName == "Save"))
            return;
        try
        {
            string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + "Official/" + e.CommandArgument.ToString() + "/";
            FileUpload control1 = (FileUpload)e.Item.FindControl("fuPic");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnCandidateCode");
            if (control1.HasFile)
            {
                lblMsg.Visible = false;
                GeneralMethods.FileBrowse(control1, FolderPath, "InitialPicture");
                string str = FolderPath + "InitialPicture" + Path.GetExtension(control1.FileName);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateInitialPictatus", connection);
                sqlCommand.Parameters.AddWithValue("@CandidateCode", control2.Value);
                sqlCommand.Parameters.AddWithValue("@Path", str);
                sqlCommand.Parameters.AddWithValue("@InitialPicStatus", 1);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                bind_rptrptTestSheduled();
            }
            else
            {
                lblMsg.Text = "Please browse picture first.";
                lblMsg.Visible = true;
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

    protected void rptOfferInterview_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DoneTour")
        {
            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateTourStatus", connection);
                sqlCommand.Parameters.AddWithValue("@CandidateCode", e.CommandArgument);
                sqlCommand.Parameters.AddWithValue("@CandidateStatus", 1);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                InsertScheduledComments(Convert.ToInt32(e.CommandArgument), "Tour Done");
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
        if (e.CommandName == "IsArrived")
        {
            try
            {
                HiddenField control = (HiddenField)e.Item.FindControl("hdnReservedSlotCode");
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Update_ScheduledIsArrived", connection);
                sqlCommand.Parameters.AddWithValue("@ReservedSlotCode", Convert.ToInt32(control.Value));
                sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
                sqlCommand.Parameters.AddWithValue("@Updated_IP", USERIP);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                InsertScheduledComments(Convert.ToInt32(e.CommandArgument), "Candidate Arrived For Offer Letter");
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
        if (!(e.CommandName == "Save"))
            return;
        try
        {
            string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + "Official/" + e.CommandArgument.ToString() + "/";
            FileUpload control1 = (FileUpload)e.Item.FindControl("fuPic");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnCandidateCode");
            if (control1.HasFile)
            {
                lblMsg.Visible = false;
                GeneralMethods.FileBrowse(control1, FolderPath, "InitialPicture");
                string str = FolderPath + "InitialPicture" + Path.GetExtension(control1.FileName);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateInitialPictatus", connection);
                sqlCommand.Parameters.AddWithValue("@CandidateCode", control2.Value);
                sqlCommand.Parameters.AddWithValue("@Path", str);
                sqlCommand.Parameters.AddWithValue("@InitialPicStatus", 1);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                bind_rptrptTestSheduled();
            }
            else
            {
                lblMsg.Text = "Please browse picture first.";
                lblMsg.Visible = true;
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

    protected void rptAppointment_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DoneTour")
        {
            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateTourStatus", connection);
                sqlCommand.Parameters.AddWithValue("@CandidateCode", e.CommandArgument);
                sqlCommand.Parameters.AddWithValue("@CandidateStatus", 1);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                InsertScheduledComments(Convert.ToInt32(e.CommandArgument), "Tour Done");
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
        if (e.CommandName == "IsArrived")
        {
            try
            {
                HiddenField control = (HiddenField)e.Item.FindControl("hdnReservedSlotCode");
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Update_ScheduledIsArrived", connection);
                sqlCommand.Parameters.AddWithValue("@ReservedSlotCode", Convert.ToInt32(control.Value));
                sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
                sqlCommand.Parameters.AddWithValue("@Updated_IP", USERIP);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                InsertScheduledComments(Convert.ToInt32(e.CommandArgument), "Candidate Arrived For Appointment");
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
        if (!(e.CommandName == "Save"))
            return;
        try
        {
            string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + "Official/" + e.CommandArgument.ToString() + "/";
            FileUpload control1 = (FileUpload)e.Item.FindControl("fuPic");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnCandidateCode");
            if (control1.HasFile)
            {
                lblMsg.Visible = false;
                GeneralMethods.FileBrowse(control1, FolderPath, "InitialPicture");
                string str = FolderPath + "InitialPicture" + Path.GetExtension(control1.FileName);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateInitialPictatus", connection);
                sqlCommand.Parameters.AddWithValue("@CandidateCode", control2.Value);
                sqlCommand.Parameters.AddWithValue("@Path", str);
                sqlCommand.Parameters.AddWithValue("@InitialPicStatus", 1);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                bind_rptrptTestSheduled();
            }
            else
            {
                lblMsg.Text = "Please browse picture first.";
                lblMsg.Visible = true;
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

    protected void rptVerification_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DoneTour")
        {
            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateTourStatus", connection);
                sqlCommand.Parameters.AddWithValue("@CandidateCode", e.CommandArgument);
                sqlCommand.Parameters.AddWithValue("@CandidateStatus", 1);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                InsertScheduledComments(Convert.ToInt32(e.CommandArgument), "Tour Done");
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
        if (e.CommandName == "IsArrived")
        {
            try
            {
                HiddenField control = (HiddenField)e.Item.FindControl("hdnReservedSlotCode");
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Update_ScheduledIsArrived", connection);
                sqlCommand.Parameters.AddWithValue("@ReservedSlotCode", Convert.ToInt32(control.Value));
                sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
                sqlCommand.Parameters.AddWithValue("@Updated_IP", USERIP);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                InsertScheduledComments(Convert.ToInt32(e.CommandArgument), "Candidate Arrived For Verification");
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
        if (!(e.CommandName == "Save"))
            return;
        try
        {
            string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + "Official/" + e.CommandArgument.ToString() + "/";
            FileUpload control1 = (FileUpload)e.Item.FindControl("fuPic");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnCandidateCode");
            if (control1.HasFile)
            {
                lblMsg.Visible = false;
                GeneralMethods.FileBrowse(control1, FolderPath, "InitialPicture");
                string str = FolderPath + "InitialPicture" + Path.GetExtension(control1.FileName);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateInitialPictatus", connection);
                sqlCommand.Parameters.AddWithValue("@CandidateCode", control2.Value);
                sqlCommand.Parameters.AddWithValue("@Path", str);
                sqlCommand.Parameters.AddWithValue("@InitialPicStatus", 1);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                bind_rptrptTestSheduled();
            }
            else
            {
                lblMsg.Text = "Please browse picture first.";
                lblMsg.Visible = true;
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

    protected void rptTestSheduled_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem || !(((DataRow)e.Item.DataItem)["IsVisitedUnMark"].ToString() == "inline"))
            return;
        ((WebControl)e.Item.FindControl("trResult")).Style.Add("background-color", "#E5E5EE");
    }

    public void Check_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (!chkIsInclude.Checked)
                lnkSearch.ValidationGroup = "Unchecked";
            else
                lnkSearch.ValidationGroup = "";
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        try
        {
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
            }
        }
    }

    private void bind_rptrptTestSheduled()
    {
        SqlCommand selectCommand = new SqlCommand("dbo.Xrec_Select_ReservedCandidateDetailPro1", connection);
        if (chkIsInclude.Checked)
        {
            DateTime dateTime = Convert.ToDateTime(postedFromDate.Value);
            selectCommand.Parameters.AddWithValue("@startDate", dateTime.ToString("yyyy-MM-dd"));
            if (!string.IsNullOrEmpty(txtRefNo.Text))
                selectCommand.Parameters.AddWithValue("@refNo", txtRefNo.Text);
            if (ddlCity.SelectedIndex != 0)
                selectCommand.Parameters.AddWithValue("@CityCode", ddlCity.SelectedValue);
            if (!string.IsNullOrEmpty(txtName.Text))
                selectCommand.Parameters.AddWithValue("@Name", txtName.Text);
            if (ddlDepartment.SelectedIndex != 0)
                selectCommand.Parameters.AddWithValue("@DeptName", ddlDepartment.SelectedItem.Text);
        }
        else
        {
            if (!string.IsNullOrEmpty(txtRefNo.Text))
                selectCommand.Parameters.AddWithValue("@refNo", txtRefNo.Text);
            if (ddlCity.SelectedIndex != 0)
                selectCommand.Parameters.AddWithValue("@CityCode", ddlCity.SelectedValue);
            if (!string.IsNullOrEmpty(txtName.Text))
                selectCommand.Parameters.AddWithValue("@Name", txtName.Text);
            if (ddlDepartment.SelectedIndex != 0)
                selectCommand.Parameters.AddWithValue("@DeptName", ddlDepartment.SelectedItem.Text);
        }
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        if (dataTable != null)
        {
            if (dataTable.Rows.Count > 0)
            {
                DataView defaultView1 = dataTable.DefaultView;
                defaultView1.RowFilter = "canStatus='" + Convert.ToInt32(Constants.CandidateLifeCycleStatus.ShortlistedSchedulingPendingTest).ToString() + "' or canStatus='" + Convert.ToInt32(Constants.CandidateLifeCycleStatus.TestnotAppearedReSchedulingPending).ToString() + "' or canStatus='" + Convert.ToInt32(Constants.CandidateLifeCycleStatus.TestFailedReSchedulingPendingTest).ToString() + "'";
                defaultView1.Sort = "StartTime ASC";
                if (defaultView1.Count > 0)
                {
                    rptTestSheduled.DataSource = defaultView1;
                    rptTestSheduled.DataBind();
                    rptTestSheduled.Visible = true;
                    lblemtyMsg.Visible = false;
                    trTestButton.Style.Add("display", "");
                }
                else
                {
                    rptTestSheduled.DataSource = null;
                    rptTestSheduled.Visible = false;
                    lblemtyMsg.Text = "No record(s) found";
                    lblemtyMsg.Visible = true;
                    trTestButton.Style.Add("display", "none");
                }
                DataView defaultView2 = dataTable.DefaultView;
                defaultView2.RowFilter = "canStatus='" + Convert.ToInt32(Constants.CandidateLifeCycleStatus.NoTestSchedulingPendingInterview).ToString() + "' or canStatus='" + Convert.ToInt32(Constants.CandidateLifeCycleStatus.InterviewFailedReSchedulingPending).ToString() + "' or canStatus='" + Convert.ToInt32(Constants.CandidateLifeCycleStatus.InterviewnotAppearedReSchedulingPending).ToString() + "' or canStatus='" + Convert.ToInt32(Constants.CandidateLifeCycleStatus.TestPassedSchedulingPendingInterview).ToString() + "'";
                defaultView2.Sort = "StartTime ASC";
                if (defaultView2.Count > 0)
                {
                    rptInterViewScheduled.DataSource = defaultView2;
                    rptInterViewScheduled.DataBind();
                    rptInterViewScheduled.Visible = true;
                    lblemtyInterview.Visible = false;
                    trInterviewButton.Style.Add("display", "");
                }
                else
                {
                    rptInterViewScheduled.DataSource = null;
                    rptInterViewScheduled.Visible = false;
                    lblemtyInterview.Text = "No record(s) found";
                    lblemtyInterview.Visible = true;
                    trInterviewButton.Style.Add("display", "none");
                }
                DataView defaultView3 = dataTable.DefaultView;
                defaultView3.RowFilter = "canStatus='" + Convert.ToInt32(Constants.CandidateLifeCycleStatus.OfferGeneratedSchedulingPending).ToString() + "' or canStatus='" + Convert.ToInt32(Constants.CandidateLifeCycleStatus.OfferNotAcceptedReSchedulingPendingOffer).ToString() + "'";
                defaultView3.Sort = "StartTime ASC";
                if (defaultView3.Count > 0)
                {
                    rptOfferInterview.DataSource = defaultView3;
                    rptOfferInterview.DataBind();
                    rptOfferInterview.Visible = true;
                    lblemptyOffer.Visible = false;
                    trOfferButton.Style.Add("display", "");
                }
                else
                {
                    rptOfferInterview.DataSource = null;
                    rptOfferInterview.Visible = false;
                    lblemptyOffer.Text = "No record(s) found";
                    lblemptyOffer.Visible = true;
                    trOfferButton.Style.Add("display", "none");
                }
                DataView defaultView4 = dataTable.DefaultView;
                defaultView4.RowFilter = "canStatus='" + Convert.ToInt32(Constants.CandidateLifeCycleStatus.OfferAcceptedVerificationSchedulingPending).ToString() + "'";
                defaultView4.Sort = "StartTime ASC";
                if (defaultView4.Count > 0)
                {
                    rptVerification.DataSource = defaultView4;
                    rptVerification.DataBind();
                    rptVerification.Visible = true;
                    lblVarification.Visible = false;
                    trVerificationButton.Style.Add("display", "");
                }
                else
                {
                    rptVerification.DataSource = null;
                    rptVerification.Visible = false;
                    lblVarification.Text = "No record(s) found";
                    lblVarification.Visible = true;
                    trVerificationButton.Style.Add("display", "none");
                }
                DataView defaultView5 = dataTable.DefaultView;
                defaultView5.RowFilter = "canStatus='" + Convert.ToInt32(Constants.CandidateLifeCycleStatus.VerificationDoneAppointmentSchedulingPending).ToString() + "'";
                defaultView5.Sort = "StartTime ASC";
                if (defaultView5.Count > 0)
                {
                    rptAppointment.DataSource = defaultView5;
                    rptAppointment.DataBind();
                    rptAppointment.Visible = true;
                    lblAppointment.Visible = false;
                    trAppointmentButton.Style.Add("display", "");
                }
                else
                {
                    rptAppointment.DataSource = null;
                    rptAppointment.Visible = false;
                    lblAppointment.Text = "No record(s) found";
                    lblAppointment.Visible = true;
                    trAppointmentButton.Style.Add("display", "none");
                }
            }
            else
            {
                rptInterViewScheduled.DataSource = null;
                rptInterViewScheduled.Visible = false;
                lblemtyInterview.Text = "No record(s) found";
                lblemtyInterview.Visible = true;
                rptTestSheduled.DataSource = null;
                rptTestSheduled.Visible = false;
                lblemtyMsg.Text = "No record(s) found";
                lblemtyMsg.Visible = true;
                rptOfferInterview.DataSource = null;
                rptOfferInterview.Visible = false;
                lblemptyOffer.Text = "No record(s) found";
                lblemptyOffer.Visible = true;
                rptVerification.DataSource = null;
                rptVerification.Visible = false;
                lblVarification.Text = "No record(s) found";
                lblVarification.Visible = true;
                rptAppointment.DataSource = null;
                rptAppointment.Visible = false;
                lblAppointment.Text = "No record(s) found";
                lblAppointment.Visible = true;
                trTestButton.Style.Add("display", "none");
                trInterviewButton.Style.Add("display", "none");
                trOfferButton.Style.Add("display", "none");
                trVerificationButton.Style.Add("display", "none");
                trAppointmentButton.Style.Add("display", "none");
            }
        }
        else
        {
            rptInterViewScheduled.DataSource = null;
            rptInterViewScheduled.Visible = false;
            lblemtyInterview.Text = "No record(s) found";
            lblemtyInterview.Visible = true;
            rptTestSheduled.DataSource = null;
            rptTestSheduled.Visible = false;
            lblemtyMsg.Text = "No record(s) found";
            lblemtyMsg.Visible = true;
            rptOfferInterview.DataSource = null;
            rptOfferInterview.Visible = false;
            lblemptyOffer.Text = "No record(s) found";
            lblemptyOffer.Visible = true;
            rptVerification.DataSource = null;
            rptVerification.Visible = false;
            lblVarification.Text = "No record(s) found";
            lblVarification.Visible = true;
            rptAppointment.DataSource = null;
            rptAppointment.Visible = false;
            lblAppointment.Text = "No record(s) found";
            lblAppointment.Visible = true;
            trTestButton.Style.Add("display", "none");
            trInterviewButton.Style.Add("display", "none");
            trOfferButton.Style.Add("display", "none");
            trVerificationButton.Style.Add("display", "none");
            trAppointmentButton.Style.Add("display", "none");
        }
        ShowHideActions();
    }

    public static void CreateFolder(string FolderPath)
    {
        string path = HttpContext.Current.Server.MapPath(FolderPath);
        if (new DirectoryInfo(path).Exists)
            return;
        Directory.CreateDirectory(path);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            for (int index = 0; index <= rptTestSheduled.Items.Count - 1; ++index)
            {
                HiddenField control = (HiddenField)rptTestSheduled.Items[index].FindControl("hdCandidateCode");
                if (((CheckBox)rptTestSheduled.Items[index].FindControl("chkSelect")).Checked)
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateTourStatus", connection);
                    sqlCommand.Parameters.AddWithValue("@CandidateCode", control.Value);
                    sqlCommand.Parameters.AddWithValue("@CandidateStatus", 1);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
                }
            }
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

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            for (int index = 0; index <= rptInterViewScheduled.Items.Count - 1; ++index)
            {
                HiddenField control = (HiddenField)rptInterViewScheduled.Items[index].FindControl("hdCandidateCode");
                if (((CheckBox)rptInterViewScheduled.Items[index].FindControl("chkSelect")).Checked)
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateTourStatus", connection);
                    sqlCommand.Parameters.AddWithValue("@CandidateCode", control.Value);
                    sqlCommand.Parameters.AddWithValue("@CandidateStatus", 1);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
                }
            }
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

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            for (int index = 0; index <= rptOfferInterview.Items.Count - 1; ++index)
            {
                HiddenField control = (HiddenField)rptOfferInterview.Items[index].FindControl("hdCandidateCode");
                if (((CheckBox)rptOfferInterview.Items[index].FindControl("chkSelect")).Checked)
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateTourStatus", connection);
                    sqlCommand.Parameters.AddWithValue("@CandidateCode", control.Value);
                    sqlCommand.Parameters.AddWithValue("@CandidateStatus", 1);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
                }
            }
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

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            for (int index = 0; index <= rptVerification.Items.Count - 1; ++index)
            {
                HiddenField control = (HiddenField)rptVerification.Items[index].FindControl("hdCandidateCode");
                if (((CheckBox)rptVerification.Items[index].FindControl("chkSelect")).Checked)
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateTourStatus", connection);
                    sqlCommand.Parameters.AddWithValue("@CandidateCode", control.Value);
                    sqlCommand.Parameters.AddWithValue("@CandidateStatus", 1);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
                }
            }
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

    private void InsertScheduledComments(int candID, string comments)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Insert_ScheduledHistoryComments", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = candID;
        sqlCommand.Parameters.AddWithValue("@Comments", comments);
        sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
        sqlCommand.Parameters.AddWithValue("@Updated_IP", USERIP);
        sqlCommand.ExecuteNonQuery();
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            for (int index = 0; index <= rptAppointment.Items.Count - 1; ++index)
            {
                HiddenField control = (HiddenField)rptAppointment.Items[index].FindControl("hdCandidateCode");
                if (((CheckBox)rptAppointment.Items[index].FindControl("chkSelect")).Checked)
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateTourStatus", connection);
                    sqlCommand.Parameters.AddWithValue("@CandidateCode", control.Value);
                    sqlCommand.Parameters.AddWithValue("@CandidateStatus", 1);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
                }
            }
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

    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            for (int index = 0; index <= rptTestSheduled.Items.Count - 1; ++index)
            {
                HiddenField control1 = (HiddenField)rptTestSheduled.Items[index].FindControl("hdCandidateCode");
                if (((CheckBox)rptTestSheduled.Items[index].FindControl("chkSelect")).Checked)
                {
                    HiddenField control2 = (HiddenField)rptTestSheduled.Items[index].FindControl("hdnReservedSlotCode");
                    SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Update_ScheduledIsArrived", connection);
                    sqlCommand.Parameters.AddWithValue("@ReservedSlotCode", Convert.ToInt32(control2.Value));
                    sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
                    sqlCommand.Parameters.AddWithValue("@Updated_IP", USERIP);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
                    InsertScheduledComments(Convert.ToInt32(control1.Value), "Candidate Arrived For Test");
                }
            }
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

    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            for (int index = 0; index <= rptInterViewScheduled.Items.Count - 1; ++index)
            {
                HiddenField control1 = (HiddenField)rptInterViewScheduled.Items[index].FindControl("hdCandidateCode");
                if (((CheckBox)rptInterViewScheduled.Items[index].FindControl("chkSelect")).Checked)
                {
                    HiddenField control2 = (HiddenField)rptInterViewScheduled.Items[index].FindControl("hdnReservedSlotCode");
                    SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Update_ScheduledIsArrived", connection);
                    sqlCommand.Parameters.AddWithValue("@ReservedSlotCode", Convert.ToInt32(control2.Value));
                    sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
                    sqlCommand.Parameters.AddWithValue("@Updated_IP", USERIP);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
                    InsertScheduledComments(Convert.ToInt32(control1.Value), "Candidate Arrived For Final Interview");
                }
            }
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

    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            for (int index = 0; index <= rptOfferInterview.Items.Count - 1; ++index)
            {
                HiddenField control1 = (HiddenField)rptOfferInterview.Items[index].FindControl("hdCandidateCode");
                if (((CheckBox)rptOfferInterview.Items[index].FindControl("chkSelect")).Checked)
                {
                    HiddenField control2 = (HiddenField)rptOfferInterview.Items[index].FindControl("hdnReservedSlotCode");
                    SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Update_ScheduledIsArrived", connection);
                    sqlCommand.Parameters.AddWithValue("@ReservedSlotCode", Convert.ToInt32(control2.Value));
                    sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
                    sqlCommand.Parameters.AddWithValue("@Updated_IP", USERIP);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
                    InsertScheduledComments(Convert.ToInt32(control1.Value), "Candidate Arrived For Offer Letter");
                }
            }
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

    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            for (int index = 0; index <= rptVerification.Items.Count - 1; ++index)
            {
                HiddenField control1 = (HiddenField)rptVerification.Items[index].FindControl("hdCandidateCode");
                if (((CheckBox)rptVerification.Items[index].FindControl("chkSelect")).Checked)
                {
                    HiddenField control2 = (HiddenField)rptVerification.Items[index].FindControl("hdnReservedSlotCode");
                    SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Update_ScheduledIsArrived", connection);
                    sqlCommand.Parameters.AddWithValue("@ReservedSlotCode", Convert.ToInt32(control2.Value));
                    sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
                    sqlCommand.Parameters.AddWithValue("@Updated_IP", USERIP);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
                    InsertScheduledComments(Convert.ToInt32(control1.Value), "Candidate Arrived For Verification");
                }
            }
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

    protected void LinkButton11_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            for (int index = 0; index <= rptAppointment.Items.Count - 1; ++index)
            {
                HiddenField control1 = (HiddenField)rptAppointment.Items[index].FindControl("hdCandidateCode");
                if (((CheckBox)rptAppointment.Items[index].FindControl("chkSelect")).Checked)
                {
                    HiddenField control2 = (HiddenField)rptAppointment.Items[index].FindControl("hdnReservedSlotCode");
                    SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Update_ScheduledIsArrived", connection);
                    sqlCommand.Parameters.AddWithValue("@ReservedSlotCode", Convert.ToInt32(control2.Value));
                    sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
                    sqlCommand.Parameters.AddWithValue("@Updated_IP", USERIP);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
                    InsertScheduledComments(Convert.ToInt32(control1.Value), "Candidate Arrived For Appointment");
                }
            }
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

    [WebMethod]
    public static void UpdateCandidatebyPro(string items)
    {
        string[] strArray = new string[0];
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
            strArray = items.Split('|');
            if (((IEnumerable<string>)strArray).Count<string>() < 5)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XREC_UpdateCandidateByPro", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@CandidateCode", strArray[0].ToString());
            sqlCommand.Parameters.AddWithValue("@Type", strArray[1].ToString());
            sqlCommand.Parameters.AddWithValue("@Bit", strArray[2].ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedByUser", strArray[3].ToString());
            sqlCommand.Parameters.AddWithValue("@UpdationIP", strArray[4].ToString());
            sqlCommand.Parameters.AddWithValue("@ReservedSlot", strArray[5].ToString());
            sqlCommand.ExecuteScalar();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            if (((IEnumerable<string>)strArray).Count<string>() >= 5)
                LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, strArray[3].ToString());
            else
                LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, "0");
        }
    }
}