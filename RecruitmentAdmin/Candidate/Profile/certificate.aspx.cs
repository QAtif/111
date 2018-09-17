using System;
using ErrorLog;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using XRecruitmentStatusLibrary;

public partial class Candidate_Profile_certificate : CustomBasePage, IRequiresSessionState
{
    public string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString());
    public string QueryStringVar = string.Empty;
    public static string CID;
    public SecureQueryString secQueryString;

    protected void ValidateTenure(object source, ServerValidateEventArgs args)
    {
        try
        {
            if (chkEducationStatus.Checked)
                return;
            args.IsValid = new DateTime(Convert.ToInt32(ddlFromYear.SelectedValue.ToString()), Convert.ToInt32(ddlFromMonth.SelectedValue.ToString()), 1) < new DateTime(Convert.ToInt32(ddlToYear.SelectedValue.ToString()), Convert.ToInt32(ddlToMonth.SelectedValue.ToString()), 1);
            AddOrHideCertificate();
            ErrorSpan.InnerText = "To Date Must be greater then from Date";
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_certificate.CID);
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
            Candidate_Profile_certificate.CID = secQueryString["CID"].ToString();
            if (IsPostBack)
                return;
            LoadDates();
            BindData();
            CheckCandidateCertificates();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_certificate.CID);
        }
    }

    protected void lvCertificate_OnItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            DataSet dataSet = new DataSet();
            if (e.CommandName == "Delete")
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("XRec_DeactivateCandidateQualification", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@CandidateQualificationCode", Convert.ToInt32(e.CommandArgument.ToString()));
                        sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
                        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                        sqlCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_certificate.CID));
                        sqlCommand.Parameters.AddWithValue("@ProgramCode", Constants.EducationalPrograms.Certificate);
                        sqlCommand.ExecuteNonQuery();
                        CheckCandidateCertificates();
                        BindData();
                        ClearControls();
                    }
                    if (lvCertificate.Items.Count <= 0)
                        StatusManagement.RemoveProfileStatus(sqlConnection, Convert.ToInt32(Candidate_Profile_certificate.CID), Constants.ModuleCode.ProfileStatus, Request.UserHostAddress, UserCode, Constants.ProfileNavigation.Certification);
                }
            }
            if (!(e.CommandName == "Edit"))
                return;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                connection.Open();
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateCertificate", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_certificate.CID));
                    selectCommand.Parameters.AddWithValue("@QualificationCode", Convert.ToInt32(e.CommandArgument.ToString()));
                    selectCommand.ExecuteNonQuery();
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                    if (dataSet == null || dataSet.Tables == null || dataSet.Tables[0].Rows.Count <= 0)
                        return;
                    txtCertificate.Text = dataSet.Tables[0].Rows[0]["CandidateCertificate"].ToString();
                    hfCertificate.Value = dataSet.Tables[0].Rows[0]["Degree_Code"].ToString();
                    txtField.Text = dataSet.Tables[0].Rows[0]["Field"].ToString();
                    hfField.Value = dataSet.Tables[0].Rows[0]["Major_Code"].ToString();
                    hfInstitute.Value = dataSet.Tables[0].Rows[0]["Institute_Code"].ToString();
                    if (dataSet.Tables[0].Rows[0]["DateFrom"].ToString() != "")
                    {
                        ddlFromMonth.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DateFrom"].ToString()).Month.ToString();
                        ddlFromYear.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DateFrom"].ToString()).Year.ToString();
                    }
                    chkEducationStatus.Checked = dataSet.Tables[0].Rows[0]["CurrentlyStuding"].ToString() == "1";
                    if (chkEducationStatus.Checked)
                    {
                        ddlToMonth.Attributes.Add("disabled", "");
                        ddlToYear.Attributes.Add("disabled", "");
                        PaperCount.Attributes["class"] = "row-fluid xSetDisableCer2";
                    }
                    else
                    {
                        PaperCount.Attributes["class"] = "row-fluid xSetDisableCer2 hidden";
                        ddlToMonth.Attributes.Remove("disabled");
                        ddlToYear.Attributes.Remove("disabled");
                        if (dataSet.Tables[0].Rows[0]["EndDate"].ToString() != "")
                        {
                            ddlToMonth.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EndDate"].ToString()).Month.ToString();
                            ddlToYear.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EndDate"].ToString()).Year.ToString();
                        }
                    }
                    txtInstitute.Text = dataSet.Tables[0].Rows[0]["Institute"].ToString();
                    hfCertificateCode.Value = dataSet.Tables[0].Rows[0]["CandidateQualificationCode"].ToString();
                    txtTotalPapers.Text = dataSet.Tables[0].Rows[0]["TotalPaperCount"].ToString();
                    txtClearedPapers.Text = dataSet.Tables[0].Rows[0]["ClearedPaperCount"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_certificate.CID);
        }
    }

    protected void lvCertificate_ItemEditing(object sender, ListViewEditEventArgs e)
    {
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            CurrentlyStudy();
            Page.Validate();
            if (!Page.IsValid)
                return;
            ErrorSpan.InnerText = "";
            UpdateCandidateQulification();
            StatusManagement.MarkProfileStatus(SqlConn, Convert.ToInt32(Candidate_Profile_certificate.CID), Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.FilledCertificateQualificationSkillSetPending, Request.UserHostAddress, UserCode, Constants.ProfileNavigation.Certification);
            BindData();
            CheckCandidateCertificates();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_certificate.CID);
        }
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            string cid = Candidate_Profile_certificate.CID;
            if (rblHasCertificate.SelectedValue == "1")
            {
                StatusManagement.MarkProfileStatus(sqlConn, Convert.ToInt32(cid), Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.FilledCertificateQualificationSkillSetPending, Request.UserHostAddress, Convert.ToInt32(cid), Constants.ProfileNavigation.Certification);
            }
            else
            {
                if (!(rblHasCertificate.SelectedValue == "2"))
                    return;
                StatusManagement.MarkProfileStatus(sqlConn, Convert.ToInt32(cid), Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.NoCertificateQualificationSkillSetPending, Request.UserHostAddress, Convert.ToInt32(cid), Constants.ProfileNavigation.Certification);
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_certificate.CID);
        }
    }

    protected void lvCertificate_OnItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
    }

    protected void lvCertificate_OnDataBound(object sender, ListViewItemEventArgs e)
    {
        HtmlGenericControl control = (HtmlGenericControl)e.Item.FindControl("li1");
        if (!(DataBinder.Eval(e.Item.DataItem, "IsComplete").ToString() == "0"))
            return;
        control.Attributes.Add("class", "actionrequired");
    }

    private void AddOrHideCertificate()
    {
        if (rblHasCertificate.SelectedValue == "1")
        {
            profeCer.Attributes["class"] = "";
            footerCer.Attributes["class"] = "";
        }
        else
        {
            profeCer.Attributes["class"] = "hidden";
            footerCer.Attributes["class"] = "hidden";
        }
    }

    private void CheckCandidateCertificates()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateHasCertificate", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_certificate.CID));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet != null && dataSet.Tables != null)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    if (dataSet.Tables[0].Rows[0]["HasCertificate"].ToString() == "1")
                    {
                        tblHasCertificate.Visible = false;
                        rblHasCertificate.SelectedValue = "1";
                        AddOrHideCertificate();
                    }
                    else if (dataSet.Tables[0].Rows[0]["HasCertificate"].ToString() == "0")
                    {
                        tblHasCertificate.Visible = true;
                        rblHasCertificate.SelectedValue = "2";
                        AddOrHideCertificate();
                    }
                    else
                    {
                        if (!(dataSet.Tables[0].Rows[0]["HasCertificate"].ToString() == "2"))
                            return;
                        tblHasCertificate.Visible = true;
                        rblHasCertificate.SelectedValue = "2";
                        AddOrHideCertificate();
                    }
                }
                else
                    tblHasCertificate.Visible = true;
            }
            else
                tblHasCertificate.Visible = true;
        }
    }

    private void UpdateCandidateQulification()
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateQualificationAdmin", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_certificate.CID));
                sqlCommand.Parameters.AddWithValue("@QualificationCode", hfCertificateCode.Value);
                sqlCommand.Parameters.AddWithValue("@ProgramCode", Convert.ToInt32(Constants.EducationalPrograms.Certificate));
                sqlCommand.Parameters.AddWithValue("@InstituteCode", hfInstitute.Value.ToString());
                sqlCommand.Parameters.AddWithValue("@InstituteText", txtInstitute.Text);
                sqlCommand.Parameters.AddWithValue("@DegreeCode", hfCertificate.Value.ToString());
                sqlCommand.Parameters.AddWithValue("@MajorCode", hfField.Value.ToString());
                sqlCommand.Parameters.AddWithValue("@DegreeText", txtCertificate.Text);
                sqlCommand.Parameters.AddWithValue("@MajorText", txtField.Text);
                DateTime dateTime = new DateTime(Convert.ToInt32(ddlFromYear.SelectedValue), Convert.ToInt32(ddlFromMonth.SelectedValue), 1);
                sqlCommand.Parameters.AddWithValue("@DateFrom", dateTime);
                if (!chkEducationStatus.Checked)
                    sqlCommand.Parameters.AddWithValue("@DateTo", (chkEducationStatus.Checked ? Convert.ToDateTime(DateTime.Now.ToString("MMM dd, yyyy")) : Convert.ToDateTime(new DateTime(Convert.ToInt32(ddlToYear.SelectedValue), Convert.ToInt32(ddlToMonth.SelectedValue), 1))));
                sqlCommand.Parameters.AddWithValue("@EducationStatus", (chkEducationStatus.Checked ? 1 : 0));
                sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
                sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
                sqlCommand.Parameters.AddWithValue("@TotalPaperCount", txtTotalPapers.Text);
                sqlCommand.Parameters.AddWithValue("@ClearedPaperCount", txtClearedPapers.Text);
                sqlCommand.ExecuteNonQuery();
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

    private void BindData()
    {
        profeCerList.Style.Add("display", "");
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateCertificate", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_certificate.CID));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet != null && dataSet.Tables != null)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    lvCertificate.Items.Clear();
                    lvCertificate.DataSource = dataSet;
                    lvCertificate.DataBind();
                }
                else
                {
                    lvCertificate.Items.Clear();
                    profeCerList.Style.Add("display", "none");
                }
                DataRow[] dataRowArray = dataSet.Tables[0].Select("IsComplete=0");
                if (dataRowArray.Length > 0)
                {
                    int num = 0;
                    foreach (DataRow dataRow in dataRowArray)
                    {
                        ++num;
                        if (num == 1)
                        {
                            ClearControls();
                            BindInCompleteData(int.Parse(dataRow["CandidateQualificationCode"].ToString()));
                        }
                    }
                }
                else
                    ClearControls();
            }
            else
            {
                lvCertificate.Items.Clear();
                profeCerList.Style.Add("display", "none");
            }
        }
    }

    private void BindInCompleteData(int CandidateQualificationCode)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateCertificate", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_certificate.CID));
                selectCommand.Parameters.AddWithValue("@QualificationCode", CandidateQualificationCode);
                selectCommand.ExecuteNonQuery();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
                if (dataSet != null)
                {
                    if (dataSet.Tables != null)
                    {
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            txtCertificate.Text = dataSet.Tables[0].Rows[0]["CandidateCertificate"].ToString();
                            hfCertificate.Value = dataSet.Tables[0].Rows[0]["Degree_Code"].ToString();
                            txtField.Text = dataSet.Tables[0].Rows[0]["Field"].ToString();
                            hfField.Value = dataSet.Tables[0].Rows[0]["Major_Code"].ToString();
                            hfInstitute.Value = dataSet.Tables[0].Rows[0]["Institute_Code"].ToString();
                            if (dataSet.Tables[0].Rows[0]["DateFrom"].ToString() != "")
                            {
                                ddlFromMonth.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DateFrom"].ToString()).Month.ToString();
                                ddlFromYear.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DateFrom"].ToString()).Year.ToString();
                            }
                            chkEducationStatus.Checked = dataSet.Tables[0].Rows[0]["CurrentlyStuding"].ToString() == "1";
                            if (chkEducationStatus.Checked)
                            {
                                ddlToMonth.Attributes.Add("disabled", "");
                                ddlToYear.Attributes.Add("disabled", "");
                                PaperCount.Attributes["class"] = "row-fluid xSetDisableCer2";
                            }
                            else
                            {
                                PaperCount.Attributes["class"] = "row-fluid xSetDisableCer2 hidden";
                                ddlToMonth.Attributes.Remove("disabled");
                                ddlToYear.Attributes.Remove("disabled");
                                if (dataSet.Tables[0].Rows[0]["EndDate"].ToString() != "")
                                {
                                    ddlToMonth.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EndDate"].ToString()).Month.ToString();
                                    ddlToYear.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EndDate"].ToString()).Year.ToString();
                                }
                            }
                            txtInstitute.Text = dataSet.Tables[0].Rows[0]["Institute"].ToString();
                            hfCertificateCode.Value = dataSet.Tables[0].Rows[0]["CandidateQualificationCode"].ToString();
                            txtTotalPapers.Text = dataSet.Tables[0].Rows[0]["TotalPaperCount"].ToString();
                            txtClearedPapers.Text = dataSet.Tables[0].Rows[0]["ClearedPaperCount"].ToString();
                        }
                    }
                }
            }
        }
        ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "document.getElementById('btnVDate').click();", true);
    }

    private void ClearControls()
    {
        txtInstitute.Text = "";
        txtCertificate.Text = "";
        txtField.Text = "";
        ddlFromMonth.SelectedValue = "";
        ddlToMonth.SelectedValue = "";
        ddlToYear.SelectedValue = "";
        ddlFromYear.SelectedValue = "";
        chkEducationStatus.Checked = false;
        hfCertificateCode.Value = "";
        hfInstitute.Value = "";
        hfCertificate.Value = "";
        hfField.Value = "";
        txtClearedPapers.Text = "";
        txtTotalPapers.Text = "";
        CurrentlyStudy();
    }

    private void CurrentlyStudy()
    {
        if (chkEducationStatus.Checked)
        {
            ddlToMonth.Attributes.Add("disabled", "");
            ddlToYear.Attributes.Add("disabled", "");
            PaperCount.Attributes["class"] = "row-fluid xSetDisableCer2";
        }
        else
        {
            ddlToMonth.Attributes.Remove("disabled");
            ddlToYear.Attributes.Remove("disabled");
            PaperCount.Attributes["class"] = "row-fluid xSetDisableCer2 hidden";
        }
    }
}