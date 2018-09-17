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

public partial class profile_diploma : CustomBaseClass
{
    #region Page Variables
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    string FinishBtnText = ConfigurationManager.AppSettings["FinishButton"].ToString();
    SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    #endregion Page Variables

    #region Events
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
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void lvDiploma_ItemEditing(object sender, ListViewEditEventArgs e)
    {
    }

    protected void lvDiploma_OnItemCommand(object sender, ListViewCommandEventArgs e)
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
                        sqlCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(CANDIDATE.ToString()));
                        sqlCommand.Parameters.AddWithValue("@ProgramCode", Constants.EducationalPrograms.Diploma);
                        sqlCommand.ExecuteNonQuery();
                        CheckCandidateDiploma();
                        BindData();
                        ClearControls();
                        if (lvDiploma.Items.Count <= 0)
                        {
                            StatusManagement.RemoveProfileStatus(sqlConnection, CandidateCode, Constants.ModuleCode.ProfileStatus, Request.UserHostAddress, CandidateCode, Constants.ProfileNavigation.Diploma);
                            Response.Redirect(DomainAddress + "profile/diploma.aspx", false);
                        }
                    }
                }
            }
            if (e.CommandName == "Edit")
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    connection.Open();
                    using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDiploma", connection))
                    {
                        selectCommand.CommandType = CommandType.StoredProcedure;
                        selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(CANDIDATE.ToString()));
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
                                    txtDiploma.Text = dataSet.Tables[0].Rows[0]["Diploma"].ToString();
                                    hfDiploma.Value = dataSet.Tables[0].Rows[0]["Degree_Code"].ToString();
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
                                    }
                                    else
                                    {
                                        ddlToMonth.Attributes.Remove("disabled");
                                        ddlToYear.Attributes.Remove("disabled");
                                        if (dataSet.Tables[0].Rows[0]["EndDate"].ToString() != "")
                                        {
                                            ddlToMonth.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EndDate"].ToString()).Month.ToString();
                                            ddlToYear.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EndDate"].ToString()).Year.ToString();
                                        }
                                    }
                                    txtInstitute.Text = dataSet.Tables[0].Rows[0]["Institute"].ToString();
                                    hfDiplomaCode.Value = dataSet.Tables[0].Rows[0]["CandidateQualificationCode"].ToString();
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
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CANDIDATE.ToString());
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            if (Convert.ToInt32(Constants.ProfileNavigation.Diploma) == Convert.ToInt32(GeneralMethods.GetProfileNavCount(SqlConn, CandidateCode).Rows[0]["FinishCode"].ToString()))
                btnSaveAndContinue.Text = FinishBtnText;
            LoadDates();
            BindData();
            CheckCandidateDiploma();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CANDIDATE.ToString());
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
            StatusManagement.MarkProfileStatus(SqlConn, CandidateCode, Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.FilledDiplomaQualificationCertificatePending, Request.UserHostAddress, AdminUserCode == -1 ? CandidateCode : AdminUserCode, Constants.ProfileNavigation.Diploma);
            BindData();
            CheckCandidateDiploma();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void btnSaveAndContinue_Click(object sender, EventArgs e)
    {
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        string str = CANDIDATE.ToString();
        if (rblHasDiploma.SelectedValue == "1")
        {
            if (txtInstitute.Text != "")
                btnSave_Click(null, (EventArgs)null);
        }
        else if (rblHasDiploma.SelectedValue == "2")
            StatusManagement.MarkProfileStatus(sqlConn, Convert.ToInt32(str), Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.NoDiplomaQualificationCertificatePending, Request.UserHostAddress, Convert.ToInt32(str), Constants.ProfileNavigation.Diploma);
        if (btnSaveAndContinue.Text == FinishBtnText)
            Response.Redirect(DomainAddress + "/area/viewprofile.aspx", false);
        else
            Response.Redirect(DomainAddress + "/profile/redirector.aspx", false);
    }

    protected void lvDiploma_OnItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
    }

    protected void lvDiploma_OnDataBound(object sender, ListViewItemEventArgs e)
    {
        HtmlGenericControl control = (HtmlGenericControl)e.Item.FindControl("li1");
        ((HtmlControl)e.Item.FindControl("DivFade")).Attributes.Add("onclick", "document.getElementById('" + e.Item.FindControl("lbedit").ClientID + "').click()");
        control.Attributes.Remove("class");
        control.Attributes.Add("class", "jcarousel-item jcarousel-item-horizontal jcarousel-item-2 jcarousel-item-2-horizontal");
        if (!(DataBinder.Eval(e.Item.DataItem, "IsComplete").ToString() == "0"))
            return;
        control.Attributes.Add("class", "actionrequired");
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
                sqlCommand.Parameters.AddWithValue("@UpdatedBy", (AdminUserCode == -1 ? CandidateCode : AdminUserCode));
                sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
                sqlCommand.Parameters.AddWithValue("@UserType", UserTypeCode);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    private void CheckCandidateDiploma()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateHasDiploma", connection))
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
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CANDIDATE.ToString());
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
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDiploma", connection))
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
                    lvDiploma.Items.Clear();
                    lvDiploma.DataSource = dataSet;
                    lvDiploma.DataBind();
                }
                else
                {
                    lvDiploma.Items.Clear();
                    profeDipList.Visible = false;
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
        foreach (Control control1 in (IEnumerable<ListViewDataItem>)lvDiploma.Items)
        {
            HtmlGenericControl control2 = (HtmlGenericControl)control1.FindControl("li1");
            control2.Attributes.Remove("class");
            control2.Attributes.Add("class", "jcarousel-item jcarousel-item-horizontal jcarousel-item-2 jcarousel-item-2-horizontal");
        }
    }

    private void BindInCompleteData(int CandidateQualificationCode)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDiploma", connection))
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
                            txtDiploma.Text = dataSet.Tables[0].Rows[0]["Diploma"].ToString();
                            hfDiploma.Value = dataSet.Tables[0].Rows[0]["Degree_Code"].ToString();
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
                            }
                            else
                            {
                                ddlToMonth.Attributes.Remove("disabled");
                                ddlToYear.Attributes.Remove("disabled");
                                if (dataSet.Tables[0].Rows[0]["EndDate"].ToString() != "")
                                {
                                    ddlToMonth.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EndDate"].ToString()).Month.ToString();
                                    ddlToYear.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EndDate"].ToString()).Year.ToString();
                                }
                            }
                            txtInstitute.Text = dataSet.Tables[0].Rows[0]["Institute"].ToString();
                            hfDiplomaCode.Value = dataSet.Tables[0].Rows[0]["CandidateQualificationCode"].ToString();
                        }
                    }
                }
            }
        }
        ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "document.getElementById('btnVDate').click();", true);
    }

    #endregion



}