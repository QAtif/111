using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ErrorLog;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using XRecruitmentStatusLibrary;
using System.Web.UI.HtmlControls;

public partial class profile_certificate : CustomBaseClass
{
    #region Page Variables
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    string FinishBtnText = ConfigurationManager.AppSettings["FinishButton"].ToString();
    SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

    #endregion Page Variables

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
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            if (Convert.ToInt32(Constants.ProfileNavigation.Certification) == Convert.ToInt32(GeneralMethods.GetProfileNavCount(SqlConn, CandidateCode).Rows[0]["FinishCode"].ToString()))
                btnContinue.Text = FinishBtnText;
            LoadDates();
            BindData();
            CheckCandidateCertificates();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void lvCertificate_OnItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            ClearControls();
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
                        sqlCommand.Parameters.AddWithValue("@UpdatedBy", (AdminUserCode == -1 ? CandidateCode : AdminUserCode));
                        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                        sqlCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(CandidateCode.ToString()));
                        sqlCommand.Parameters.AddWithValue("@ProgramCode", Constants.EducationalPrograms.Certificate);
                        sqlCommand.ExecuteNonQuery();
                        CheckCandidateCertificates();
                        BindData();
                        ClearControls();
                    }
                    if (lvCertificate.Items.Count <= 0)
                    {
                        StatusManagement.RemoveProfileStatus(sqlConnection, CandidateCode, Constants.ModuleCode.ProfileStatus, Request.UserHostAddress, CandidateCode, Constants.ProfileNavigation.Certification);
                        Response.Redirect(DomainAddress + "profile/certificate.aspx", false);
                    }
                }
            }
            if (e.CommandName == "Edit")
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    connection.Open();
                    using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateCertificate", connection))
                    {
                        selectCommand.CommandType = CommandType.StoredProcedure;
                        selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(CandidateCode.ToString()));
                        selectCommand.Parameters.AddWithValue("@QualificationCode", Convert.ToInt32(e.CommandArgument.ToString()));
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
            }
          ((HtmlControl)e.Item.FindControl("li1")).Attributes.Add("class", "active");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
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
            StatusManagement.MarkProfileStatus(SqlConn, CandidateCode, Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.FilledCertificateQualificationSkillSetPending, Request.UserHostAddress, AdminUserCode == -1 ? CandidateCode : AdminUserCode, Constants.ProfileNavigation.Certification);
            BindData();
            CheckCandidateCertificates();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            if (rblHasCertificate.SelectedValue == "1")
            {
                if (txtInstitute.Text != "")
                    btnSave_Click(null, (EventArgs)null);
            }
            else if (rblHasCertificate.SelectedValue == "2")
                StatusManagement.MarkProfileStatus(sqlConn, CandidateCode, Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.NoCertificateQualificationSkillSetPending, Request.UserHostAddress, CandidateCode, Constants.ProfileNavigation.Certification);
            if (btnContinue.Text == FinishBtnText)
                Response.Redirect(DomainAddress + "/area/viewprofile.aspx", false);
            else
                Response.Redirect(DomainAddress + "/profile/redirector.aspx", false);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void lvCertificate_OnItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
    }

    protected void lvCertificate_OnDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            HtmlGenericControl control1 = (HtmlGenericControl)e.Item.FindControl("li1");
            HtmlGenericControl control2 = (HtmlGenericControl)e.Item.FindControl("DivFade");
            LinkButton control3 = (LinkButton)e.Item.FindControl("lbedit");
            control1.Attributes.Remove("class");
            control1.Attributes.Add("class", "jcarousel-item jcarousel-item-horizontal jcarousel-item-2 jcarousel-item-2-horizontal");
            control2.Attributes.Add("onclick", "document.getElementById('" + control3.ClientID + "').click()");
            if (!(DataBinder.Eval(e.Item.DataItem, "IsComplete").ToString() == "0"))
                return;
            control1.Attributes.Add("class", "actionrequired");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
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
                selectCommand.Parameters.AddWithValue("@CandidateCode", CANDIDATE.ToString());
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
            using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateQualification", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(CANDIDATE.ToString()));
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
                sqlCommand.Parameters.AddWithValue("@UpdatedBy", (AdminUserCode == -1 ? CandidateCode : AdminUserCode));
                sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
                sqlCommand.Parameters.AddWithValue("@TotalPaperCount", txtTotalPapers.Text);
                sqlCommand.Parameters.AddWithValue("@ClearedPaperCount", txtClearedPapers.Text);
                sqlCommand.Parameters.AddWithValue("@UserType", UserTypeCode);
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
                selectCommand.Parameters.AddWithValue("@CandidateCode", CANDIDATE.ToString());
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
                selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(CANDIDATE.ToString()));
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
        foreach (Control control1 in (IEnumerable<ListViewDataItem>)lvCertificate.Items)
        {
            HtmlGenericControl control2 = (HtmlGenericControl)control1.FindControl("li1");
            control2.Attributes.Remove("class");
            control2.Attributes.Add("class", "jcarousel-item jcarousel-item-horizontal jcarousel-item-2 jcarousel-item-2-horizontal");
        }
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