using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;
using ErrorLog;
using XRecruitmentStatusLibrary;

public partial class CandidateDiploma : CustomBasePage
{  

    #region Page Variables
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    public static string CID;
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;
    #endregion Page Variables


    #region Methods
    private void BindData()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDiploma", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateDiploma.CID);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet != null && dataSet.Tables != null)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    rptExperience.DataSource = dataSet;
                    rptExperience.DataBind();
                }
                else
                {
                    rptExperience.DataSource = null;
                    rptExperience.DataBind();
                }
            }
            else
            {
                rptExperience.DataSource = null;
                rptExperience.DataBind();
            }
        }
    }

    private void UpdateCandidateQulification()
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateQualificationAdmin", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(CandidateDiploma.CID));
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
                if (!chkStudy.Checked)
                    sqlCommand.Parameters.AddWithValue("@DateTo", (chkStudy.Checked ? Convert.ToDateTime(DateTime.Now.ToString("MMM dd, yyyy")) : Convert.ToDateTime(new DateTime(Convert.ToInt32(ddlToYear.SelectedValue), Convert.ToInt32(ddlToMonth.SelectedValue), 1))));
                sqlCommand.Parameters.AddWithValue("@EducationStatus", (chkStudy.Checked ? 1 : 0));
                sqlCommand.Parameters.AddWithValue("@GradingSystemCode ", Convert.ToInt32(rblGradingSystem.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("@Grade", txtGrade.Text.ToString());
                if (rblPosition.SelectedValue == "1")
                    sqlCommand.Parameters.AddWithValue("@Position", txtPosition.Text.ToString());
                sqlCommand.Parameters.AddWithValue("@Activities", txtActivities.Text.ToString());
                sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
                sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
                sqlCommand.Parameters.AddWithValue("@userType", 1);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    private void ClearControls()
    {
        txtInstitute.Text = "";
        txtDiploma.Text = "";
        txtField.Text = "";
        chkStudy.Checked = false;
        txtGrade.Text = "";
        txtPosition.Text = "";
        txtActivities.Text = "";
        hfDiplomaCode.Value = "";
        hfInstitute.Value = "";
        hfDiploma.Value = "";
        hfField.Value = "";
        ddlFromMonth.SelectedValue = "";
        ddlToMonth.SelectedValue = "";
        ddlToYear.SelectedValue = "";
        ddlFromYear.SelectedValue = "";
        CurrentlyStudy();
        btnAddMore.Visible = false;
    }

    private void BindGradings()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectAllGradingSystems", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet != null && dataSet.Tables != null)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    rblGradingSystem.DataSource = dataSet;
                    rblGradingSystem.DataTextField = "GradingSystem";
                    rblGradingSystem.DataValueField = "GradingSystem_Code";
                    rblGradingSystem.DataBind();
                    rblGradingSystem.SelectedIndex = 0;
                }
                else
                {
                    rblGradingSystem.DataSource = null;
                    rblGradingSystem.DataTextField = "GradingSystem";
                    rblGradingSystem.DataValueField = "GradingSystem_Code";
                    rptExperience.DataBind();
                    rblGradingSystem.SelectedIndex = 0;
                }
            }
            else
            {
                rblGradingSystem.DataSource = null;
                rblGradingSystem.DataTextField = "GradingSystem";
                rblGradingSystem.DataValueField = "GradingSystem_Code";
                rblGradingSystem.DataBind();
                rblGradingSystem.SelectedIndex = 0;
            }
        }
    }

    private void CurrentlyStudy()
    {
        if (chkStudy.Checked)
        {
            ddlToMonth.Style.Add("display", "none");
            ddlToYear.Style.Add("display", "none");
            lblTo.Style.Add("display", "none");
            rfvMonthTo.Enabled = false;
            rfvYearTo.Enabled = false;
        }
        else
        {
            ddlToMonth.Style.Add("display", "");
            ddlToYear.Style.Add("display", "");
            lblTo.Style.Add("display", "");
            rfvMonthTo.Enabled = true;
            rfvYearTo.Enabled = true;
        }
    }

    private void LoadDates()
    {
        for (int year = DateTime.Now.Year; year > DateTime.Now.Year - 80; --year)
        {
            ddlFromYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
            ddlToYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
        }
        ddlToYear.Items.Insert(0, new ListItem("-Year-", ""));
        ddlFromYear.Items.Insert(0, new ListItem("-Year-", ""));
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
        if (QueryStringVar == null)
            return;
        secQueryString = new SecureQueryString(QueryStringVar);
        if (secQueryString["CID"] != null)
            CandidateDiploma.CID = secQueryString["CID"].ToString();
        ShowHidePosition();
        try
        {
            if (IsPostBack)
                return;
            LoadDates();
            BindGradings();
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateDiploma.CID);
        }
    }

    private void ShowHidePosition()
    {
        try
        {
            if (rblPosition.SelectedValue == "2")
            {
                txtPosition.Attributes.CssStyle.Add("display", "none");
                RegularExpressionValidator1.Enabled = false;
                RequiredFieldValidator7.Enabled = false;
            }
            else
            {
                txtPosition.Attributes.CssStyle.Add("display", "block");
                RegularExpressionValidator1.Enabled = true;
                RequiredFieldValidator7.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateDiploma.CID);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ShowHidePosition();
            CurrentlyStudy();
            Page.Validate();
            if (!IsValid)
                return;
            UpdateCandidateQulification();
            BindData();
            ClearControls();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateDiploma.CID);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateDiploma.CID);
        }
    }

    protected void rptExperience_OnItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            DataSet dataSet = new DataSet();
            if ((e.CommandName == "Delete" || e.CommandName == "Delete") && e.CommandName == "Delete")
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
                {
                    connection.Open();
                    try
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("XRec_DeactivateCandidateQualification", connection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@CandidateQualificationCode", Convert.ToInt32(e.CommandArgument.ToString()));
                            sqlCommand.Parameters.AddWithValue("@UpdatedBy", Convert.ToInt32(CandidateDiploma.CID));
                            sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                            sqlCommand.ExecuteNonQuery();
                            BindData();
                            ClearControls();
                        }
                    }
                    catch (Exception ex)
                    {
                        LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateDiploma.CID);
                    }
                }
            }
            if (!(e.CommandName == "Edit") && !(e.CommandName == "Edit") || !(e.CommandName == "Edit"))
                return;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
            {
                connection.Open();
                try
                {
                    using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDiploma", connection))
                    {
                        selectCommand.CommandType = CommandType.StoredProcedure;
                        selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(CandidateDiploma.CID));
                        selectCommand.Parameters.AddWithValue("@QualificationCode", Convert.ToInt32(e.CommandArgument.ToString()));
                        selectCommand.ExecuteNonQuery();
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                            sqlDataAdapter.Fill(dataSet);
                        if (dataSet == null || dataSet.Tables == null || dataSet.Tables[0].Rows.Count <= 0)
                            return;
                        txtActivities.Text = dataSet.Tables[0].Rows[0]["Activities"].ToString();
                        txtDiploma.Text = dataSet.Tables[0].Rows[0]["Diploma"].ToString();
                        hfDiploma.Value = dataSet.Tables[0].Rows[0]["Degree_Code"].ToString();
                        txtField.Text = dataSet.Tables[0].Rows[0]["Field"].ToString();
                        hfField.Value = dataSet.Tables[0].Rows[0]["Major_Code"].ToString();
                        hfInstitute.Value = dataSet.Tables[0].Rows[0]["Institute_Code"].ToString();
                        ddlFromMonth.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DateFrom"].ToString()).Month.ToString();
                        ddlFromYear.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DateFrom"].ToString()).Year.ToString();
                        chkStudy.Checked = dataSet.Tables[0].Rows[0]["CurrentlyStuding"].ToString() == "1";
                        if (chkStudy.Checked)
                        {
                            ddlToMonth.Style.Add("display", "none");
                            ddlToYear.Style.Add("display", "none");
                            lblTo.Style.Add("display", "none");
                            rfvMonthTo.Enabled = false;
                            rfvYearTo.Enabled = false;
                        }
                        else
                        {
                            ddlToMonth.Style.Add("display", "");
                            ddlToYear.Style.Add("display", "");
                            lblTo.Style.Add("display", "");
                            rfvMonthTo.Enabled = true;
                            rfvYearTo.Enabled = true;
                            ddlToMonth.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EndDate"].ToString()).Month.ToString();
                            ddlToYear.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EndDate"].ToString()).Year.ToString();
                        }
                        if (dataSet.Tables[0].Rows[0]["Position"].ToString() == "")
                        {
                            rblPosition.SelectedValue = "2";
                            txtPosition.Attributes.CssStyle.Add("display", "none");
                            RegularExpressionValidator1.Enabled = false;
                            RequiredFieldValidator7.Enabled = false;
                        }
                        else
                        {
                            rblPosition.SelectedValue = "1";
                            txtPosition.Attributes.CssStyle.Add("display", "block");
                            RegularExpressionValidator1.Enabled = true;
                            RequiredFieldValidator7.Enabled = true;
                        }
                        txtPosition.Text = dataSet.Tables[0].Rows[0]["Position"].ToString();
                        txtInstitute.Text = dataSet.Tables[0].Rows[0]["Institute"].ToString();
                        txtGrade.Text = dataSet.Tables[0].Rows[0]["Grade"].ToString();
                        rblGradingSystem.SelectedValue = dataSet.Tables[0].Rows[0]["GradingSystem_Code"].ToString();
                        hfDiplomaCode.Value = dataSet.Tables[0].Rows[0]["CandidateQualificationCode"].ToString();
                        btnAddMore.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateDiploma.CID);
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateDiploma.CID);
        }
    }

    protected void btnAddMore_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateDiploma.CID);
        }
    }

    protected void ValidateTenure(object source, ServerValidateEventArgs args)
    {
        try
        {
            if (chkStudy.Checked)
                return;
            args.IsValid = new DateTime(Convert.ToInt32(ddlFromYear.SelectedValue.ToString()), Convert.ToInt32(ddlFromMonth.SelectedValue.ToString()), 1) < new DateTime(Convert.ToInt32(ddlToYear.SelectedValue.ToString()), Convert.ToInt32(ddlToMonth.SelectedValue.ToString()), 1);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateDiploma.CID);
        }
    }

    #endregion



}

