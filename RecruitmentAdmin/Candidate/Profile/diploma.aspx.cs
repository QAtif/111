using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using ErrorLog;
using System.Web.SessionState;
using System.Data;
using XRecruitmentStatusLibrary;


public partial class Candidate_Profile_diploma : CustomBasePage, IRequiresSessionState
{
    public string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString());
    private string QueryStringVar = string.Empty;
    public static string CID;
    public SecureQueryString secQueryString;

    protected void ValidateTenure(object source, ServerValidateEventArgs args)
    {
        try
        {
            if (chkEducationStatus.Checked)
                return;
            args.IsValid = new DateTime(Convert.ToInt32(ddlFromYear.SelectedValue.ToString()), Convert.ToInt32(ddlFromMonth.SelectedValue.ToString()), 1) < new DateTime(Convert.ToInt32(ddlToYear.SelectedValue.ToString()), Convert.ToInt32(ddlToMonth.SelectedValue.ToString()), 1);
            AddOrHideDiploma();
            ErrorSpan.InnerText = "To Date Must be greater then from Date";
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void lvDiploma_ItemEditing(object sender, ListViewEditEventArgs e)
    {
    }

    protected void lvDiploma_OnItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            DataSet dataSet = new DataSet();
            if (e.CommandName == "Delete")
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("XRec_DeactivateCandidateQualification", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@CandidateQualificationCode", Convert.ToInt32(e.CommandArgument.ToString()));
                        sqlCommand.Parameters.AddWithValue("@UpdatedBy", Convert.ToInt32(UserCode.ToString()));
                        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                        sqlCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(UserCode.ToString()));
                        sqlCommand.Parameters.AddWithValue("@ProgramCode", Constants.EducationalPrograms.Diploma);
                        sqlCommand.ExecuteNonQuery();
                        CheckCandidateDiploma();
                        BindData();
                        ClearControls();
                        if (lvDiploma.Items.Count <= 0)
                        {
                            StatusManagement.RemoveProfileStatus(sqlConnection, Convert.ToInt32(Candidate_Profile_diploma.CID), Constants.ModuleCode.ProfileStatus, Request.UserHostAddress, UserCode, Constants.ProfileNavigation.Diploma);
                            Response.Redirect(DomainAddress + "profile/diploma.aspx", false);
                        }
                    }
                }
            }
            if (!(e.CommandName == "Edit"))
                return;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
            {
                connection.Open();
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDiploma", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_diploma.CID));
                    selectCommand.Parameters.AddWithValue("@QualificationCode", Convert.ToInt32(e.CommandArgument.ToString()));
                    selectCommand.ExecuteNonQuery();
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                    if (dataSet == null || dataSet.Tables == null || dataSet.Tables[0].Rows.Count <= 0)
                        return;
                    txtDiploma.Text = dataSet.Tables[0].Rows[0]["Diploma"].ToString();
                    hfDiploma.Value = dataSet.Tables[0].Rows[0]["Degree_Code"].ToString();
                    txtField.Text = dataSet.Tables[0].Rows[0]["Field"].ToString();
                    hfField.Value = dataSet.Tables[0].Rows[0]["Major_Code"].ToString();
                    hfInstitute.Value = dataSet.Tables[0].Rows[0]["Institute_Code"].ToString();
                    ddlFromMonth.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DateFrom"].ToString()).Month.ToString();
                    ddlFromYear.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DateFrom"].ToString()).Year.ToString();
                    chkEducationStatus.Checked = dataSet.Tables[0].Rows[0]["CurrentlyStuding"].ToString() == "1";
                    if (chkEducationStatus.Checked)
                    {
                        ddlToMonth.Attributes.Add("disabled", "");
                        ddlToYear.Attributes.Add("disabled", "");
                    }
                    else
                    {
                        ddlToMonth.Attributes.Remove("disabled");
                        ddlToYear.Attributes.Remove("disabled");
                        ddlToMonth.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EndDate"].ToString()).Month.ToString();
                        ddlToYear.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EndDate"].ToString()).Year.ToString();
                    }
                    txtInstitute.Text = dataSet.Tables[0].Rows[0]["Institute"].ToString();
                    hfDiplomaCode.Value = dataSet.Tables[0].Rows[0]["CandidateQualificationCode"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            if (QueryStringVar == null)
                return;
            secQueryString = new SecureQueryString(Request.QueryString["data"].ToString());
            if (secQueryString["CID"] == null)
                return;
            Candidate_Profile_diploma.CID = secQueryString["CID"].ToString();
            if (IsPostBack)
                return;
            GeneralMethods.GetProfileNavCount(SqlConn, Convert.ToInt32(Candidate_Profile_diploma.CID));
            LoadDates();
            BindData();
            ClearControls();
            CheckCandidateDiploma();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            CurrentlyStudy();
            Page.Validate();
            if (!IsValid)
                return;
            ErrorSpan.InnerText = "";
            UpdateCandidateQulification();
            StatusManagement.MarkProfileStatus(SqlConn, Convert.ToInt32(Candidate_Profile_diploma.CID), Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.FilledDiplomaQualificationCertificatePending, Request.UserHostAddress, UserCode, Constants.ProfileNavigation.Diploma);
            BindData();
            ClearControls();
            CheckCandidateDiploma();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void btnSaveAndContinue_Click(object sender, EventArgs e)
    {
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString());
        if (rblHasDiploma.SelectedValue == "1")
            StatusManagement.MarkProfileStatus(sqlConn, Convert.ToInt32(Candidate_Profile_diploma.CID), Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.FilledDiplomaQualificationCertificatePending, Request.UserHostAddress, Convert.ToInt32(UserCode), Constants.ProfileNavigation.Diploma);
        else if (rblHasDiploma.SelectedValue == "2")
            StatusManagement.MarkProfileStatus(sqlConn, Convert.ToInt32(Candidate_Profile_diploma.CID), Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.NoDiplomaQualificationCertificatePending, Request.UserHostAddress, Convert.ToInt32(Candidate_Profile_diploma.CID), Constants.ProfileNavigation.Diploma);
        Response.Redirect(DomainAddress + "/profile/redirector.aspx", false);
    }

    protected void lvDiploma_OnItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
    }

    private void UpdateCandidateQulification()
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateQualificationAdmin", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_diploma.CID));
                sqlCommand.Parameters.AddWithValue("@QualificationCode", hfDiplomaCode.Value);
                sqlCommand.Parameters.AddWithValue("@ProgramCode", Convert.ToInt32(Constants.EducationalPrograms.Diploma));
                sqlCommand.Parameters.AddWithValue("@InstituteCode", Convert.ToInt32(hfInstitute.Value.ToString()));
                sqlCommand.Parameters.AddWithValue("@DegreeCode", Convert.ToInt32(hfDiploma.Value.ToString()));
                sqlCommand.Parameters.AddWithValue("@MajorCode", Convert.ToInt32(hfField.Value.ToString()));
                sqlCommand.Parameters.AddWithValue("@InstituteText", txtInstitute.Text);
                sqlCommand.Parameters.AddWithValue("@DegreeText", txtDiploma.Text);
                sqlCommand.Parameters.AddWithValue("@MajorText", txtField.Text);
                DateTime dateTime = new DateTime(Convert.ToInt32(ddlFromYear.SelectedValue), Convert.ToInt32(ddlFromMonth.SelectedValue), 1);
                sqlCommand.Parameters.AddWithValue("@DateFrom", dateTime);
                if (!chkEducationStatus.Checked)
                    sqlCommand.Parameters.AddWithValue("@DateTo", (chkEducationStatus.Checked ? Convert.ToDateTime(DateTime.Now.ToString("MMM dd, yyyy")) : Convert.ToDateTime(new DateTime(Convert.ToInt32(ddlToYear.SelectedValue), Convert.ToInt32(ddlToMonth.SelectedValue), 1))));
                sqlCommand.Parameters.AddWithValue("@EducationStatus", (chkEducationStatus.Checked ? 1 : 0));
                sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode.ToString());
                sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    private void CheckCandidateDiploma()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateHasDiploma", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", Candidate_Profile_diploma.CID);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
                if (dataSet != null && dataSet.Tables != null)
                {
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        if (dataSet.Tables[0].Rows[0]["HasDiploma"].ToString() == "1")
                        {
                            tblHasDiploma.Visible = false;
                            rblHasDiploma.SelectedValue = "1";
                            AddOrHideDiploma();
                        }
                        else if (dataSet.Tables[0].Rows[0]["HasDiploma"].ToString() == "0")
                        {
                            tblHasDiploma.Visible = true;
                            rblHasDiploma.SelectedValue = "2";
                            AddOrHideDiploma();
                        }
                        else
                        {
                            if (!(dataSet.Tables[0].Rows[0]["HasDiploma"].ToString() == "2"))
                                return;
                            tblHasDiploma.Visible = true;
                            rblHasDiploma.SelectedValue = "2";
                            AddOrHideDiploma();
                        }
                    }
                    else
                        tblHasDiploma.Visible = true;
                }
                else
                    tblHasDiploma.Visible = true;
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            }
        }
    }

    private void CurrentlyStudy()
    {
        if (chkEducationStatus.Checked)
        {
            ddlToMonth.Attributes.Add("disabled", "");
            ddlToYear.Attributes.Add("disabled", "");
        }
        else
        {
            ddlToMonth.Attributes.Remove("disabled");
            ddlToYear.Attributes.Remove("disabled");
        }
    }

    private void BindData()
    {
        profeDipList.Visible = true;
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDiploma", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", Candidate_Profile_diploma.CID);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet != null && dataSet.Tables != null)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    lvDiploma.Items.Clear();
                    lvDiploma.DataSource = dataSet;
                    lvDiploma.DataBind();
                }
                else
                {
                    lvDiploma.Items.Clear();
                    profeDipList.Visible = false;
                }
            }
            else
            {
                lvDiploma.Items.Clear();
                profeDipList.Visible = false;
            }
        }
    }

    private void LoadDates()
    {
        for (int year = DateTime.Now.Year; year > DateTime.Now.Year - 80; --year)
        {
            ddlFromYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
            ddlToYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
        }
        ddlToYear.Items.Insert(0, new ListItem("Year", ""));
        ddlFromYear.Items.Insert(0, new ListItem("Year", ""));
    }

    private void AddOrHideDiploma()
    {
        if (rblHasDiploma.SelectedValue == "1")
        {
            profeDip.Attributes["class"] = "";
            footerDip.Attributes["class"] = "";
        }
        else
        {
            profeDip.Attributes["class"] = "hidden";
            footerDip.Attributes["class"] = "hidden";
        }
    }

    private void ClearControls()
    {
        txtInstitute.Text = "";
        txtDiploma.Text = "";
        txtField.Text = "";
        chkEducationStatus.Checked = false;
        hfDiplomaCode.Value = "";
        hfInstitute.Value = "";
        hfDiploma.Value = "";
        hfField.Value = "";
        ddlFromMonth.SelectedValue = "";
        ddlToMonth.SelectedValue = "";
        ddlToYear.SelectedValue = "";
        ddlFromYear.SelectedValue = "";
        CurrentlyStudy();
    }
}