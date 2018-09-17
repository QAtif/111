using ErrorLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using XRecruitmentStatusLibrary;

public partial class profile_education : CustomBaseClass, IRequiresSessionState
{


    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    private string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    private string FinishBtnText = ConfigurationManager.AppSettings["FinishButton"].ToString();
    public string skillsListHTML = string.Empty;
   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        if (Convert.ToInt32(Constants.ProfileNavigation.EducationalQualification) == Convert.ToInt32(GeneralMethods.GetProfileNavCount(connection, CandidateCode).Rows[0]["FinishCode"].ToString()))
            btnContinue.Text = FinishBtnText;
        LoadDates();
        GetProgramAndDropDownValues();
        BindData();
    }

    private void BindData()
    {
        profeCerList.Style.Add("display", "");
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateEducationDetails", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode.ToString());
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet != null && dataSet.Tables != null)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    lvEducation.Items.Clear();
                    lvEducation.DataSource = dataSet;
                    lvEducation.DataBind();
                    profeCerList.Style.Add("display", "");
                }
                else
                {
                    lvEducation.Items.Clear();
                    profeCerList.Style.Add("display", "none");
                }
                DataRow[] dataRowArray = dataSet.Tables[0].Select("Verified=0");
                if (dataRowArray.Length > 0)
                {
                    btnSave.Text = "Save";
                    int num = 0;
                    foreach (DataRow dataRow in dataRowArray)
                    {
                        ++num;
                        if (num == 1)
                        {
                            GetNotValidDetails(int.Parse(dataRow["CandidateQualificationCode"].ToString()));
                            foreach (Control control1 in (IEnumerable<ListViewDataItem>)lvEducation.Items)
                            {
                                HtmlGenericControl control2 = (HtmlGenericControl)control1.FindControl("li1");
                                if (((HiddenField)control2.FindControl("qualificationCode")).Value == dataRow["CandidateQualificationCode"].ToString())
                                    control2.Attributes.Add("class", "active");
                            }
                        }
                    }
                }
                else
                {
                    ClearControls();
                    btnSave.Text = "Save & Add more";
                }
            }
            else
            {
                lvEducation.Items.Clear();
                profeCerList.Style.Add("display", "none");
            }
        }
    }

    protected void GetNotValidDetails(int CQC)
    {
        DataSet dataSet = new DataSet();
        try
        {
            SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateEducationDetails", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode.ToString());
            selectCommand.Parameters.AddWithValue("@CandidateQualification_Code", CQC);
            selectCommand.ExecuteNonQuery();
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                sqlDataAdapter.Fill(dataSet);
            if (dataSet == null || dataSet.Tables == null || dataSet.Tables[0].Rows.Count <= 0)
                return;
            hfDegree.Value = dataSet.Tables[0].Rows[0]["Degree_Code"].ToString();
            txtDegree.Text = dataSet.Tables[0].Rows[0]["CandidateEducation"].ToString();
            hfInstitute.Value = dataSet.Tables[0].Rows[0]["Institute_Code"].ToString();
            txtInstitute.Text = dataSet.Tables[0].Rows[0]["Institute"].ToString();
            if (dataSet.Tables[0].Rows[0]["DateFrom"].ToString() != string.Empty)
            {
                ddlFromMonth.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DateFrom"].ToString()).Month.ToString();
                ddlFromYear.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DateFrom"].ToString()).Year.ToString();
            }
            ddllevelofEducation.SelectedValue = dataSet.Tables[0].Rows[0]["Program_Code"].ToString();
            if (ddlGrade.Items.FindByValue(dataSet.Tables[0].Rows[0]["Grade"].ToString()) != null)
                ddlGrade.SelectedValue = dataSet.Tables[0].Rows[0]["Grade"].ToString();
            if (dataSet.Tables[0].Rows[0]["CurrentlyStuding"].ToString() == "1")
            {
                chkEducationStatus.Checked = true;
                txtGPA.Attributes.Add("disabled", "");
                txtPercentage.Attributes.Add("disabled", "");
                ddlGrade.Attributes.Add("disabled", "");
            }
            else
            {
                chkEducationStatus.Checked = false;
                txtGPA.Attributes.Remove("disabled");
                txtPercentage.Attributes.Remove("disabled");
                ddlGrade.Attributes.Remove("disabled");
            }
            if (chkEducationStatus.Checked)
            {
                ddlToMonth.Attributes.Add("disabled", "");
                ddlToYear.Attributes.Add("disabled", "");
                ddlToYear.Attributes.Add("class", "ToYear");
            }
            else
            {
                ddlToMonth.Attributes.Remove("disabled");
                ddlToYear.Attributes.Remove("disabled");
                ddlToYear.Attributes.Add("class", "ToYear");
                dvTo.Style.Add("display", "");
                dvTo1.Style.Add("display", "");
                if (dataSet.Tables[0].Rows[0]["EndDate"].ToString() != "Now")
                {
                    ddlToMonth.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EndDate"].ToString()).Month.ToString();
                    ddlToYear.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EndDate"].ToString()).Year.ToString();
                }
            }
            hfCertificateCode.Value = dataSet.Tables[0].Rows[0]["CandidateQualificationCode"].ToString();
            rblPosition.SelectedValue = dataSet.Tables[0].Rows[0]["IsPosition"].ToString();
            txtActivities.Text = dataSet.Tables[0].Rows[0]["Activities"].ToString();
            txtGPA.Text = dataSet.Tables[0].Rows[0]["GPA"].ToString();
            txtPercentage.Text = dataSet.Tables[0].Rows[0]["Percentage"].ToString();
            ddlAs.SelectedValue = dataSet.Tables[0].Rows[0]["As_Count"].ToString();
            ddlBs.SelectedValue = dataSet.Tables[0].Rows[0]["Bs_Count"].ToString();
            ddlCs.SelectedValue = dataSet.Tables[0].Rows[0]["Cs_Count"].ToString();
            if (dataSet.Tables[0].Rows[0]["Board_Code"].ToString() != "0")
                ddlBoard.SelectedValue = dataSet.Tables[0].Rows[0]["Board_Code"].ToString();
            if (ddllevelofEducation.SelectedValue == "4" || ddllevelofEducation.SelectedValue == "5")
            {
                dvGrade.Style.Add("display", "none");
                dvGrade1.Style.Add("display", "none");
                dvBoard.Style.Add("display", "");
            }
            else
            {
                dvGrade.Style.Add("display", "");
                dvGrade1.Style.Add("display", "");
                dvBoard.Style.Add("display", "none");
            }
            if (ddllevelofEducation.SelectedValue == "8" || ddllevelofEducation.SelectedValue == "9")
            {
                dvAlevel.Style.Add("display", "none");
                dvAlevel1.Style.Add("display", "none");
                dvGradeCount.Style.Add("display", "");
                dvGradeCount1.Style.Add("display", "");
            }
            else
            {
                dvAlevel.Style.Add("display", "");
                dvAlevel1.Style.Add("display", "");
                dvGradeCount.Style.Add("display", "none");
                dvGradeCount1.Style.Add("display", "none");
            }
            hdnSkillList.Value = string.Empty;
            hdnSkillListName.Value = string.Empty;
            LoadCandidateMajors(CQC);
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "document.getElementById('btnVDate').click();", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void GetProgramAndDropDownValues()
    {
        DataSet ogData = GetOGData();
        if (ogData.Tables[0].Rows.Count > 0)
        {
            ddllevelofEducation.DataSource = ogData.Tables[0];
            ddllevelofEducation.DataTextField = "Program_Name";
            ddllevelofEducation.DataValueField = "Program_Code";
            ddllevelofEducation.DataBind();
        }
        if (ogData.Tables[2].Rows.Count <= 0)
            return;
        ddlBoard.DataSource = ogData.Tables[2];
        ddlBoard.DataValueField = "Board_Code";
        ddlBoard.DataTextField = "Board";
        ddlBoard.DataBind();
    }

    public DataSet GetOGData()
    {
        DataSet dataSet = new DataSet();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("XRec_SelectLevelOfEducation", new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString));
        sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        sqlDataAdapter.Fill(dataSet);
        return dataSet;
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateCandidateEduaction();
            StatusManagement.MarkProfileStatus(connection, CandidateCode, Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.FilledEducationalQualificationDiplomaPending, Request.UserHostAddress, AdminUserCode == -1 ? CandidateCode : AdminUserCode, Constants.ProfileNavigation.EducationalQualification);
            BindData();
            hfCertificateCode.Value = "0";
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    private void UpdateCandidateEduaction()
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XRec_UpdateCandidateQualificationDetails", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode.ToString());
            selectCommand.Parameters.AddWithValue("@QualificationCode", hfCertificateCode.Value);
            selectCommand.Parameters.AddWithValue("@InstituteCode", Convert.ToInt32(hfInstitute.Value.ToString()));
            selectCommand.Parameters.AddWithValue("@DegreeCode", Convert.ToInt32(hfDegree.Value.ToString()));
            selectCommand.Parameters.AddWithValue("@MajorCode", 0);
            selectCommand.Parameters.AddWithValue("@InstituteText", txtInstitute.Text);
            selectCommand.Parameters.AddWithValue("@DegreeText", txtDegree.Text);
            selectCommand.Parameters.AddWithValue("@MajorText", txtField.Text);
            DateTime dateTime = new DateTime(Convert.ToInt32(ddlFromYear.SelectedValue), Convert.ToInt32(ddlFromMonth.SelectedValue), 1);
            selectCommand.Parameters.AddWithValue("@DateFrom", dateTime);
            if (!chkEducationStatus.Checked)
                selectCommand.Parameters.AddWithValue("@DateTo", (chkEducationStatus.Checked ? Convert.ToDateTime(DateTime.Now.ToString("MMM dd, yyyy")) : Convert.ToDateTime(new DateTime(Convert.ToInt32(ddlToYear.SelectedValue), Convert.ToInt32(ddlToMonth.SelectedValue), 1))));
            selectCommand.Parameters.AddWithValue("@EducationStatus", (chkEducationStatus.Checked ? 1 : 0));
            selectCommand.Parameters.AddWithValue("@IsPosition", rblPosition.SelectedValue);
            selectCommand.Parameters.AddWithValue("@Activities", txtActivities.Text.ToString());
            selectCommand.Parameters.AddWithValue("@UpdatedBy", (AdminUserCode == -1 ? CandidateCode : AdminUserCode));
            selectCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
            selectCommand.Parameters.AddWithValue("@ProgramCode", Convert.ToInt32(ddllevelofEducation.SelectedValue));
            selectCommand.Parameters.AddWithValue("@Board_Code", ddlBoard.SelectedValue);
            selectCommand.Parameters.AddWithValue("@GPA", txtGPA.Text == string.Empty ? (string)null : txtGPA.Text);
            selectCommand.Parameters.AddWithValue("@Percentage", txtPercentage.Text == string.Empty ? (string)null : txtPercentage.Text);
            selectCommand.Parameters.AddWithValue("@As_Count", ddlAs.SelectedValue);
            selectCommand.Parameters.AddWithValue("@Bs_Count", ddlBs.SelectedValue);
            selectCommand.Parameters.AddWithValue("@Cs_Count", ddlCs.SelectedValue);
            selectCommand.Parameters.AddWithValue("@Grade", ddlGrade.SelectedValue);
            selectCommand.Parameters.AddWithValue("@UserType", UserTypeCode);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count <= 0)
                return;
            SqlCommand sqlCommand1 = new SqlCommand("XRec_UpdateCandidateMajorIsActiveNull", connection);
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            sqlCommand1.Parameters.AddWithValue("@CandidateCode", CandidateCode.ToString());
            sqlCommand1.Parameters.AddWithValue("@UpdatedBy", (AdminUserCode == -1 ? CandidateCode : AdminUserCode));
            sqlCommand1.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
            sqlCommand1.Parameters.AddWithValue("@CandidateQualification_Code", Convert.ToInt32(dataTable.Rows[0]["QualificationCode"].ToString()));
            sqlCommand1.ExecuteNonQuery();
            hdnSkillList.Value = hdnSkillList.Value.TrimStart('|');
            string[] strArray1 = hdnSkillList.Value.Split('|');
            hdnSkillListName.Value = hdnSkillListName.Value.TrimStart('|');
            string[] strArray2 = hdnSkillListName.Value.Split('|');
            for (int index = 0; index <= strArray1.Length - 1; ++index)
            {
                SqlCommand sqlCommand2 = new SqlCommand("XRec_InsertCandidateMajors", connection);
                sqlCommand2.CommandType = CommandType.StoredProcedure;
                sqlCommand2.Parameters.AddWithValue("@CandidateCode", CandidateCode.ToString());
                sqlCommand2.Parameters.AddWithValue("@MajorCode", strArray1[index]);
                sqlCommand2.Parameters.AddWithValue("@MajorText", strArray2[index]);
                sqlCommand2.Parameters.AddWithValue("@UpdatedBy", (AdminUserCode == -1 ? CandidateCode : AdminUserCode));
                sqlCommand2.Parameters.AddWithValue("@UpdatedIP", Request.UserHostAddress);
                sqlCommand2.Parameters.AddWithValue("@CandidateQualification_Code", Convert.ToInt32(dataTable.Rows[0]["QualificationCode"].ToString()));
                sqlCommand2.ExecuteNonQuery();
            }
            hdnSkillList.Value = string.Empty;
            hdnSkillListName.Value = string.Empty;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.StackTrace, ex, CandidateCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    private void ClearControls()
    {
        txtInstitute.Text = "";
        ddllevelofEducation.SelectedValue = "";
        txtDegree.Text = "";
        txtField.Text = "";
        ddlFromMonth.SelectedValue = "";
        ddlToMonth.SelectedValue = "";
        ddlToYear.SelectedValue = "";
        ddlFromYear.SelectedValue = "";
        hfInstitute.Value = "";
        hfDegree.Value = "";
        hfField.Value = "";
        txtPercentage.Text = string.Empty;
        txtGPA.Text = string.Empty;
        txtActivities.Text = string.Empty;
        ddlAs.SelectedValue = "0";
        ddlBs.SelectedValue = "0";
        ddlCs.SelectedValue = "0";
        ddlGrade.SelectedValue = "";
        ddlBoard.SelectedValue = "";
        CurrentlyStudy();
        foreach (Control control1 in (IEnumerable<ListViewDataItem>)lvEducation.Items)
        {
            HtmlGenericControl control2 = (HtmlGenericControl)control1.FindControl("li1");
            if (((HiddenField)control2.FindControl("hdnISComplete")).Value == "1")
            {
                control2.Attributes.Remove("class");
                control2.Attributes.Add("class", "jcarousel-item jcarousel-item-horizontal jcarousel-item-2 jcarousel-item-2-horizontal");
            }
            else
            {
                control2.Attributes.Remove("class");
                control2.Attributes.Add("class", "actionrequired");
            }
        }
    }

    private void CurrentlyStudy()
    {
        chkEducationStatus.Checked = false;
        ddlToMonth.Attributes.Remove("disabled");
        ddlToYear.Attributes.Remove("disabled");
        ddlToYear.Attributes.Add("class", "ToYear");
        ddlGrade.Attributes.Remove("disabled");
        txtGPA.Attributes.Remove("disabled");
        txtPercentage.Attributes.Remove("disabled");
    }

    protected void lvEducation_ItemEditing(object sender, ListViewEditEventArgs e)
    {
    }

    protected void lvEducation_OnItemCommand(object sender, ListViewCommandEventArgs e)
    {
        DataSet dataSet = new DataSet();
        if (e.CommandName == "Delete")
        {
            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("XRec_DeactivateCandidateEducation", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandidateQualificationCode", Convert.ToInt32(e.CommandArgument.ToString()));
                sqlCommand.Parameters.AddWithValue("@UpdatedBy", (AdminUserCode == -1 ? CandidateCode : AdminUserCode));
                sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                sqlCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode.ToString());
                sqlCommand.ExecuteNonQuery();
                BindData();
                if (lvEducation.Items.Count <= 0)
                {
                    StatusManagement.RemoveProfileStatus(connection, CandidateCode, Constants.ModuleCode.ProfileStatus, Request.UserHostAddress, CandidateCode, Constants.ProfileNavigation.EducationalQualification);
                    Response.Redirect(DomainAddress + "profile/education.aspx", false);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.StackTrace, ex, CandidateCode.ToString());
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        if (!(e.CommandName == "Edit"))
            return;
        try
        {
            ClearControls();
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateEducationDetails", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode.ToString());
            selectCommand.Parameters.AddWithValue("@CandidateQualification_Code", Convert.ToInt32(e.CommandArgument.ToString()));
            selectCommand.ExecuteNonQuery();
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                sqlDataAdapter.Fill(dataSet);
            if (dataSet != null && dataSet.Tables != null && dataSet.Tables[0].Rows.Count > 0)
            {
                hfDegree.Value = dataSet.Tables[0].Rows[0]["Degree_Code"].ToString();
                txtDegree.Text = dataSet.Tables[0].Rows[0]["CandidateEducation"].ToString();
                hfInstitute.Value = dataSet.Tables[0].Rows[0]["Institute_Code"].ToString();
                txtInstitute.Text = dataSet.Tables[0].Rows[0]["Institute"].ToString();
                if (dataSet.Tables[0].Rows[0]["DateFrom"].ToString() != string.Empty)
                {
                    ddlFromMonth.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DateFrom"].ToString()).Month.ToString();
                    ddlFromYear.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DateFrom"].ToString()).Year.ToString();
                }
                ddllevelofEducation.SelectedValue = dataSet.Tables[0].Rows[0]["Program_Code"].ToString();
                ddlGrade.SelectedValue = dataSet.Tables[0].Rows[0]["Grade"].ToString();
                if (dataSet.Tables[0].Rows[0]["CurrentlyStuding"].ToString() == "1")
                {
                    chkEducationStatus.Checked = true;
                    txtGPA.Attributes.Add("disabled", "");
                    txtPercentage.Attributes.Add("disabled", "");
                    ddlGrade.Attributes.Add("disabled", "");
                }
                else
                {
                    chkEducationStatus.Checked = false;
                    txtGPA.Attributes.Remove("disabled");
                    txtPercentage.Attributes.Remove("disabled");
                    ddlGrade.Attributes.Remove("disabled");
                }
                if (chkEducationStatus.Checked)
                {
                    ddlToMonth.Attributes.Add("disabled", "");
                    ddlToYear.Attributes.Add("disabled", "");
                    ddlToYear.Attributes.Add("class", "ToYear");
                }
                else
                {
                    ddlToMonth.Attributes.Remove("disabled");
                    ddlToYear.Attributes.Remove("disabled");
                    ddlToYear.Attributes.Add("class", "ToYear");
                    dvTo.Style.Add("display", "");
                    dvTo1.Style.Add("display", "");
                    ddlToMonth.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EndDate"].ToString()).Month.ToString();
                    ddlToYear.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EndDate"].ToString()).Year.ToString();
                }
                hfCertificateCode.Value = dataSet.Tables[0].Rows[0]["CandidateQualificationCode"].ToString();
                rblPosition.SelectedValue = dataSet.Tables[0].Rows[0]["IsPosition"].ToString();
                txtActivities.Text = dataSet.Tables[0].Rows[0]["Activities"].ToString();
                txtGPA.Text = dataSet.Tables[0].Rows[0]["GPA"].ToString();
                txtPercentage.Text = dataSet.Tables[0].Rows[0]["Percentage"].ToString();
                ddlAs.SelectedValue = dataSet.Tables[0].Rows[0]["As_Count"].ToString();
                ddlBs.SelectedValue = dataSet.Tables[0].Rows[0]["Bs_Count"].ToString();
                ddlCs.SelectedValue = dataSet.Tables[0].Rows[0]["Cs_Count"].ToString();
                if (dataSet.Tables[0].Rows[0]["Board_Code"].ToString() != "0")
                    ddlBoard.SelectedValue = dataSet.Tables[0].Rows[0]["Board_Code"].ToString();
                if (ddllevelofEducation.SelectedValue == "4" || ddllevelofEducation.SelectedValue == "5")
                {
                    dvGrade.Style.Add("display", "none");
                    dvGrade1.Style.Add("display", "none");
                    dvBoard.Style.Add("display", "");
                }
                else
                {
                    dvGrade.Style.Add("display", "");
                    dvGrade1.Style.Add("display", "");
                    dvBoard.Style.Add("display", "none");
                }
                if (ddllevelofEducation.SelectedValue == "8" || ddllevelofEducation.SelectedValue == "9")
                {
                    dvAlevel.Style.Add("display", "none");
                    dvAlevel1.Style.Add("display", "none");
                    dvGradeCount.Style.Add("display", "");
                    dvGradeCount1.Style.Add("display", "");
                }
                else
                {
                    dvAlevel.Style.Add("display", "");
                    dvAlevel1.Style.Add("display", "");
                    dvGradeCount.Style.Add("display", "none");
                    dvGradeCount1.Style.Add("display", "none");
                }
                hdnSkillList.Value = string.Empty;
                hdnSkillListName.Value = string.Empty;
                LoadCandidateMajors(Convert.ToInt32(e.CommandArgument.ToString()));
                if (dataSet.Tables[0].Rows[0]["Verified"].ToString() == "0")
                {
                    btnSave.Text = "Save";
                    ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "document.getElementById('btnVDate').click();", true);
                }
                else
                    btnSave.Text = "Save & Add more";
            }
          ((HtmlControl)e.Item.FindControl("li1")).Attributes.Add("class", "active");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.StackTrace, ex, CandidateCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    protected void lvEducation_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        CandidateCode.ToString();
        if (txtInstitute.Text != "")
            btnSave_Click(null, (EventArgs)null);
        if (sqlConnection.State == ConnectionState.Open)
            sqlConnection.Close();
        if (btnContinue.Text == FinishBtnText)
            Response.Redirect(DomainAddress + "/area/viewprofile.aspx", false);
        else
            Response.Redirect(DomainAddress + "/profile/redirector.aspx", false);
    }

    protected void btnAddSkill_Click(object sender, EventArgs e)
    {
    }

    public void SaveRecords(HiddenField hdnName, HiddenField hdnCode, CheckBoxList chkSave, DataList rpt, TextBox txtac)
    {
        try
        {
            if (hdnName.Value.ToString() != "")
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Major_Name");
                dataTable.Columns.Add("Major_Code");
                chkSave.Items.Add(new ListItem(hdnName.Value.ToString(), hdnCode.Value.ToString())
                {
                    Selected = true
                });
                foreach (ListItem listItem in chkSave.Items)
                {
                    DataRow row = dataTable.NewRow();
                    row["Major_Code"] = listItem.Value;
                    row["Major_Name"] = listItem.Text;
                    dataTable.Rows.Add(row);
                }
                rpt.DataSource = dataTable;
                rpt.DataBind();
                hdnCode.Value = (string)null;
                hdnName.Value = (string)null;
                txtac.Text = "";
                txtac.Focus();
                if (ddllevelofEducation.SelectedValue == "4" || ddllevelofEducation.SelectedValue == "5")
                {
                    dvGrade.Style.Add("display", "none");
                    dvGrade1.Style.Add("display", "none");
                    dvBoard.Style.Add("display", "");
                }
                else
                {
                    dvGrade.Style.Add("display", "");
                    dvGrade1.Style.Add("display", "");
                    dvBoard.Style.Add("display", "none");
                }
                if (ddllevelofEducation.SelectedValue == "8" || ddllevelofEducation.SelectedValue == "9")
                {
                    dvAlevel.Style.Add("display", "none");
                    dvAlevel1.Style.Add("display", "none");
                    dvGradeCount.Style.Add("display", "");
                    dvGradeCount1.Style.Add("display", "");
                }
                else
                {
                    dvAlevel.Style.Add("display", "");
                    dvAlevel1.Style.Add("display", "");
                    dvGradeCount.Style.Add("display", "none");
                    dvGradeCount1.Style.Add("display", "none");
                }
                if (chkEducationStatus.Checked)
                {
                    ddlToMonth.Enabled = false;
                    ddlToYear.Enabled = false;
                }
                else
                {
                    ddlToMonth.Enabled = true;
                    ddlToYear.Enabled = true;
                }
            }
            else
            {
                txtac.Text = "";
                txtac.Focus();
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    private void LoadCandidateMajors(int CandidateQualification_Code)
    {
        try
        {
            DataSet dataSet = new DataSet();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateMajors", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode.ToString());
                selectCommand.Parameters.AddWithValue("@CandidateQualification_Code", CandidateQualification_Code);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet == null || dataSet.Tables == null || dataSet.Tables[0].Rows.Count <= 0)
                return;
            for (int index = 0; index < dataSet.Tables[0].Rows.Count; ++index)
            {
                string s = dataSet.Tables[0].Rows[index]["Major_Code"].ToString();
                string str1 = dataSet.Tables[0].Rows[index]["Major_Name"].ToString();
     //           HiddenField hdnSkillList = hdnSkillList;
                string str2 = hdnSkillList.Value + "|" + s;
                hdnSkillList.Value = str2;
           //     HiddenField hdnSkillListName = hdnSkillListName;
                string str3 = hdnSkillListName.Value + "|" + str1;
                hdnSkillListName.Value = str3;
                string str4 = "'" + str1 + "'";
                string str5 = int.Parse(s).ToString() + "," + str4;
                profile_education profileEducation = this;
                string str6 = profileEducation.skillsListHTML + "<span class=\"taglinks\" runat=\"server\"><span>" + str1 + "</span><a id=\"lnkEdit\" style=\"cusror: pointer;\" onclick=\"RemoveSkill(this," + str5 + ");\"></a></span>";
                profileEducation.skillsListHTML = str6;
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        BindData();
        ClearControls();
    }

    protected void lvEducation_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        LinkButton control1 = (LinkButton)e.Item.FindControl("lbedit");
        HtmlGenericControl control2 = (HtmlGenericControl)e.Item.FindControl("li1");
        ((HtmlControl)e.Item.FindControl("DivFade")).Attributes.Add("onclick", "document.getElementById('" + e.Item.FindControl("lbedit").ClientID + "').click();");
        control2.Attributes.Remove("class");
        control2.Attributes.Add("class", "jcarousel-item jcarousel-item-horizontal jcarousel-item-2 jcarousel-item-2-horizontal");
        if (!(DataBinder.Eval(e.Item.DataItem, "Verified").ToString() == "0"))
            return;
        control2.Attributes.Add("class", "actionrequired");
    }


}