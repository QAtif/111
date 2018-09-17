using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ErrorLog;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using XRecruitmentStatusLibrary;
using System.Web.SessionState;


public partial class Candidate_Profile_experience : CustomBasePage, IRequiresSessionState
{
    public string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString());
    public string QueryStringVar = string.Empty;
    public int EditCount;
    public static string CID;
    public SecureQueryString secQueryString;
    protected void Page_Load(object sender, EventArgs e)
    {
        QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
        if (QueryStringVar == null)
            return;
        secQueryString = new SecureQueryString(QueryStringVar);
        if (secQueryString["CID"] == null)
            return;
        Candidate_Profile_experience.CID = secQueryString["CID"].ToString();
        try
        {
            if (IsPostBack)
                return;
            LoadDates();
            bindExperience();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_experience.CID);
        }
    }

    protected void btn_Continue(object sender, EventArgs e)
    {
        try
        {
            if (ListView1.Items.Count > 0)
                StatusManagement.MarkProfileStatus(SqlConn, Convert.ToInt32(Candidate_Profile_experience.CID), Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.FilledProfessionalExperienceEducationalQualificationPending, Request.UserHostAddress, UserCode, Constants.ProfileNavigation.ProfessionalExperience);
            else
                StatusManagement.MarkProfileStatus(SqlConn, Convert.ToInt32(Candidate_Profile_experience.CID), Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.NoProfessionalExperienceEducationalQualificationPending, Request.UserHostAddress, UserCode, Constants.ProfileNavigation.ProfessionalExperience);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_experience.CID);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dataSet1 = new DataSet();
            DataSet dataSet2 = UpdateCandidateExperience();
            if (dataSet2 != null && dataSet2.Tables != null && dataSet2.Tables[0].Rows.Count > 0)
                UpdateCandidateBenefits(dataSet2.Tables[0].Rows[0]["ExperienceCode"].ToString());
            StatusManagement.MarkProfileStatus(SqlConn, Convert.ToInt32(Candidate_Profile_experience.CID), Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.FilledProfessionalExperienceEducationalQualificationPending, Request.UserHostAddress, UserCode, Constants.ProfileNavigation.ProfessionalExperience);
            ClearAllControls();
            bindExperience();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_experience.CID);
        }
    }

    protected void rptBenefitTypes_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataSet dataSet = new DataSet();
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        CheckBoxList control = (CheckBoxList)e.Item.FindControl("rptBenefit");
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectBenefit", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@BenefitTypeCode", DataBinder.Eval(e.Item.DataItem, "Benefit_Type_Code").ToString());
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
                if (dataSet == null || dataSet.Tables == null || dataSet.Tables[0].Rows.Count <= 0)
                    return;
                control.DataSource = dataSet;
                control.DataTextField = "Benefits";
                control.DataValueField = "Benefit_Code";
                control.DataBind();
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_experience.CID);
            }
        }
    }

    public void ListView1_ItemEditing(object sender, ListViewEditEventArgs e)
    {
    }

    public void ListView1_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
    }

    public void listView_itemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            DataSet objDS = new DataSet();
            if (e.CommandName == "Delete")
                DeleteSelectedExperience(e);
            if (!(e.CommandName == "Edit"))
                return;
            ClearAllControls();
            BindExperienceForEdit(e, objDS);
            BindCandidateBenefit(e, objDS);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_experience.CID);
        }
    }

    protected void listView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            DataSet dataSet = new DataSet();
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnISComplete");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hfExperienceCode");
            HtmlGenericControl control3 = (HtmlGenericControl)e.Item.FindControl("li");
            if (control1.Value == "0")
            {
                control3.Attributes.Add("class", "actionrequired");
                btnSave.Text = "Save";
                if (EditCount != 1)
                {
                    using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateExperienceNew", SqlConn))
                    {
                        selectCommand.CommandType = CommandType.StoredProcedure;
                        selectCommand.Parameters.AddWithValue("@ExperienceCode", Convert.ToInt32(control2.Value));
                        selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_experience.CID));
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                            sqlDataAdapter.Fill(dataSet);
                        if (dataSet != null)
                        {
                            if (dataSet.Tables != null)
                            {
                                if (dataSet.Tables[0].Rows.Count > 0)
                                {
                                    chkPresent.Checked = false;
                                    if (!string.IsNullOrEmpty(dataSet.Tables[0].Rows[0]["Company"].ToString()))
                                        txtCompany.Text = dataSet.Tables[0].Rows[0]["Company"].ToString();
                                    txtWebsite.Text = dataSet.Tables[0].Rows[0]["website"].ToString();
                                    txtEmail.Text = dataSet.Tables[0].Rows[0]["email"].ToString();
                                    txtNumber.Text = dataSet.Tables[0].Rows[0]["number"].ToString();
                                    if (!string.IsNullOrEmpty(dataSet.Tables[0].Rows[0]["Company_Code"].ToString()))
                                        hfCompany.Value = dataSet.Tables[0].Rows[0]["Company_Code"].ToString();
                                    if (!string.IsNullOrEmpty(dataSet.Tables[0].Rows[0]["Location"].ToString()))
                                        txtLocation.Text = dataSet.Tables[0].Rows[0]["Location"].ToString();
                                    if (!string.IsNullOrEmpty(dataSet.Tables[0].Rows[0]["Location_Code"].ToString()))
                                    {
                                        hfLocationType.Value = "Ci";
                                        hfLocation.Value = dataSet.Tables[0].Rows[0]["Location_Code"].ToString();
                                    }
                                    if (!string.IsNullOrEmpty(dataSet.Tables[0].Rows[0]["Country_Code"].ToString()))
                                    {
                                        hfLocationType.Value = "Co";
                                        hfLocation.Value = dataSet.Tables[0].Rows[0]["Country_Code"].ToString();
                                    }
                                    if (!string.IsNullOrEmpty(dataSet.Tables[0].Rows[0]["Position"].ToString()))
                                        txtTitle.Text = dataSet.Tables[0].Rows[0]["Position"].ToString();
                                    txtResponsibilities.Text = dataSet.Tables[0].Rows[0]["Responsibilties_Included"].ToString();
                                    if (!string.IsNullOrEmpty(dataSet.Tables[0].Rows[0]["DateFrom"].ToString()))
                                    {
                                        ddlFromMonth.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DateFrom"].ToString()).Month.ToString();
                                        ddlFromYear.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DateFrom"].ToString()).Year.ToString();
                                    }
                                    if (!string.IsNullOrEmpty(dataSet.Tables[0].Rows[0]["Is_Permanent"].ToString()))
                                        RadioButtonList1.SelectedValue = dataSet.Tables[0].Rows[0]["Is_Permanent"].ToString();
                                    if (!string.IsNullOrEmpty(dataSet.Tables[0].Rows[0]["Is_CurrentlyWorking"].ToString()))
                                    {
                                        chkPresent.Checked = dataSet.Tables[0].Rows[0]["Is_CurrentlyWorking"].ToString() == "True";
                                        if (chkPresent.Checked)
                                        {
                                            divtomonth.Attributes["class"] = "span2 xSetDisableExp hidden";
                                            divtoYear.Attributes["class"] = "span2 xSetDisableExp hidden";
                                            divTo.Attributes["class"] = "span4";
                                            divtomonth.Attributes.CssStyle.Add("display", "none");
                                            divtoYear.Attributes.CssStyle.Add("display", "none");
                                            divPresent.Attributes.CssStyle.Add("display", "");
                                            divPresent.Attributes["class"] = "span2";
                                        }
                                        else
                                        {
                                            divtomonth.Attributes["class"] = "span2 xSetDisableExp";
                                            divtoYear.Attributes["class"] = "span2 xSetDisableExp";
                                            divTo.Attributes["class"] = "span4";
                                            divtomonth.Attributes.CssStyle.Add("display", "");
                                            divtoYear.Attributes.CssStyle.Add("display", "");
                                            divPresent.Attributes.CssStyle.Add("display", "none");
                                        }
                                    }
                                    if (dataSet.Tables[0].Rows[0]["EndDate"].ToString() != "Present")
                                    {
                                        ddlToMonth.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EndDate"].ToString()).Month.ToString();
                                        ddlToYear.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EndDate"].ToString()).Year.ToString();
                                    }
                                    if (!string.IsNullOrEmpty(dataSet.Tables[0].Rows[0]["Current_Salary"].ToString()))
                                        txtCurrentSalary.Text = dataSet.Tables[0].Rows[0]["Current_Salary"].ToString().Split('.')[0].ToString();
                                    if (!string.IsNullOrEmpty(dataSet.Tables[0].Rows[0]["Initial_Salary"].ToString()))
                                        txtInitialSalary.Text = dataSet.Tables[0].Rows[0]["Initial_Salary"].ToString().Split('.')[0].ToString();
                                    hfExperienceCode.Value = dataSet.Tables[0].Rows[0]["CandidateExperience_Code"].ToString();
                                    if (!string.IsNullOrEmpty(dataSet.Tables[0].Rows[0]["JobTitle_Code"].ToString()))
                                        hfJobTitle.Value = dataSet.Tables[0].Rows[0]["JobTitle_Code"].ToString();
                                }
                            }
                        }
                    }
                    ++EditCount;
                }
                ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "document.getElementById('btnVDate').click();", true);
            }
            else
                btnSave.Text = "Save & Add more";
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_experience.CID);
        }
    }

    private void BindCandidateBenefit(ListViewCommandEventArgs e, DataSet objDS)
    {
        objDS = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateBenefit", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@ExperienceCode", Convert.ToInt32(e.CommandArgument.ToString()));
                    selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_experience.CID));
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(objDS);
                    if (objDS == null || objDS.Tables == null || objDS.Tables[0].Rows.Count <= 0)
                        return;
                    for (int index = 0; index < objDS.Tables[0].Rows.Count; ++index)
                    {
                        foreach (Control control in rptBenefitTypes.Items)
                        {
                            foreach (ListItem listItem in ((ListControl)control.FindControl("rptBenefit")).Items)
                            {
                                if (Convert.ToInt32(listItem.Value).ToString() == objDS.Tables[0].Rows[index]["Benefit_Code"].ToString())
                                    listItem.Selected = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_experience.CID);
            }
        }
    }

    public void BindExperienceForEdit(ListViewCommandEventArgs e, DataSet objDS)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                HiddenField control = (HiddenField)e.Item.FindControl("hdnISComplete");
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateExperienceNew", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@ExperienceCode", Convert.ToInt32(e.CommandArgument.ToString()));
                    selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_experience.CID));
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(objDS);
                    if (objDS != null)
                    {
                        if (objDS.Tables != null)
                        {
                            if (objDS.Tables[0].Rows.Count > 0)
                            {
                                chkPresent.Checked = false;
                                txtCompany.Text = objDS.Tables[0].Rows[0]["Company"].ToString();
                                txtWebsite.Text = objDS.Tables[0].Rows[0]["website"].ToString();
                                txtEmail.Text = objDS.Tables[0].Rows[0]["email"].ToString();
                                txtNumber.Text = objDS.Tables[0].Rows[0]["number"].ToString();
                                hfCompany.Value = objDS.Tables[0].Rows[0]["Company_Code"].ToString();
                                txtLocation.Text = objDS.Tables[0].Rows[0]["Location"].ToString();
                                if (!string.IsNullOrEmpty(objDS.Tables[0].Rows[0]["Location_Code"].ToString()))
                                {
                                    hfLocationType.Value = "Ci";
                                    hfLocation.Value = objDS.Tables[0].Rows[0]["Location_Code"].ToString();
                                }
                                if (!string.IsNullOrEmpty(objDS.Tables[0].Rows[0]["Country_Code"].ToString()))
                                {
                                    hfLocationType.Value = "Co";
                                    hfLocation.Value = objDS.Tables[0].Rows[0]["Country_Code"].ToString();
                                }
                                txtTitle.Text = objDS.Tables[0].Rows[0]["Position"].ToString();
                                txtResponsibilities.Text = objDS.Tables[0].Rows[0]["Responsibilties_Included"].ToString();
                                ddlFromMonth.SelectedValue = Convert.ToDateTime(objDS.Tables[0].Rows[0]["DateFrom"].ToString()).Month.ToString();
                                ddlFromYear.SelectedValue = Convert.ToDateTime(objDS.Tables[0].Rows[0]["DateFrom"].ToString()).Year.ToString();
                                RadioButtonList1.SelectedValue = objDS.Tables[0].Rows[0]["Is_Permanent"].ToString();
                                chkPresent.Checked = objDS.Tables[0].Rows[0]["Is_CurrentlyWorking"].ToString() == "True";
                                if (chkPresent.Checked)
                                {
                                    divtomonth.Attributes["class"] = "span2 xSetDisableExp hidden";
                                    divtoYear.Attributes["class"] = "span2 xSetDisableExp hidden";
                                    divTo.Attributes["class"] = "span4";
                                    divtomonth.Attributes.CssStyle.Add("display", "none");
                                    divtoYear.Attributes.CssStyle.Add("display", "none");
                                    divPresent.Attributes.CssStyle.Add("display", "");
                                    divPresent.Attributes["class"] = "span2";
                                }
                                else
                                {
                                    divtomonth.Attributes["class"] = "span2 xSetDisableExp";
                                    divtoYear.Attributes["class"] = "span2 xSetDisableExp";
                                    divTo.Attributes["class"] = "span4";
                                    divtomonth.Attributes.CssStyle.Add("display", "");
                                    divtoYear.Attributes.CssStyle.Add("display", "");
                                    divPresent.Attributes.CssStyle.Add("display", "none");
                                    ddlToMonth.SelectedValue = Convert.ToDateTime(objDS.Tables[0].Rows[0]["EndDate"].ToString()).Month.ToString();
                                    ddlToYear.SelectedValue = Convert.ToDateTime(objDS.Tables[0].Rows[0]["EndDate"].ToString()).Year.ToString();
                                }
                                txtCurrentSalary.Text = objDS.Tables[0].Rows[0]["Current_Salary"].ToString().Split('.')[0].ToString();
                                txtInitialSalary.Text = objDS.Tables[0].Rows[0]["Initial_Salary"].ToString().Split('.')[0].ToString();
                                hfExperienceCode.Value = objDS.Tables[0].Rows[0]["CandidateExperience_Code"].ToString();
                                hfJobTitle.Value = objDS.Tables[0].Rows[0]["JobTitle_Code"].ToString();
                            }
                        }
                    }
                }
                if (!(control.Value == "0"))
                    return;
                ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "document.getElementById('btnVDate').click();", true);
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_experience.CID);
            }
        }
    }

    private void DeleteSelectedExperience(ListViewCommandEventArgs e)
    {
        try
        {
            if (!(e.CommandName == "Delete"))
                return;
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                sqlConnection.Open();
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand("XRec_DeactivateCandidateExperience", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@CandidateExperienceCode", Convert.ToInt32(e.CommandArgument.ToString()));
                        sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
                        sqlCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_experience.CID));
                        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                        sqlCommand.ExecuteNonQuery();
                    }
                    bindExperience();
                    if (ListView1.Items.Count > 0)
                        return;
                    StatusManagement.RemoveProfileStatus(sqlConnection, Convert.ToInt32(Candidate_Profile_experience.CID), Constants.ModuleCode.ProfileStatus, Request.UserHostAddress, UserCode, Constants.ProfileNavigation.ProfessionalExperience);
                    Response.Redirect(DomainAddress + "profile/redirector.aspx", false);
                }
                catch (Exception ex)
                {
                    LogError.Write(LogError.AppType.RecruitmentAdmin, "XRec_DeactivateCandidateExperience", ex, Candidate_Profile_experience.CID);
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_experience.CID);
        }
    }

    private DataSet UpdateCandidateExperience()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            string empty1 = string.Empty;
            string str1 = RadioButtonList1.SelectedValue.ToString();
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_UpdateCandidateExperienceAdmin", connection))
            {
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string str2 = !txtCurrentSalary.Text.ToString().Contains("Rs.") ? txtCurrentSalary.Text : txtCurrentSalary.Text.ToString().Remove(0, 3);
                string str3 = !txtInitialSalary.Text.ToString().Contains("Rs.") ? txtInitialSalary.Text : txtInitialSalary.Text.ToString().Remove(0, 3);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_experience.CID));
                selectCommand.Parameters.AddWithValue("@ExperienceCode", hfExperienceCode.Value);
                selectCommand.Parameters.AddWithValue("@PositionTitleCode", hfJobTitle.Value);
                selectCommand.Parameters.AddWithValue("@PositionTitle", txtTitle.Text);
                selectCommand.Parameters.AddWithValue("@CompanyCode", Convert.ToInt32(hfCompany.Value.ToString()));
                selectCommand.Parameters.AddWithValue("@LocationCode", Convert.ToInt32(hfLocation.Value.ToString()));
                selectCommand.Parameters.AddWithValue("@LocationType", hfLocationType.Value.ToString());
                if (!string.IsNullOrEmpty(txtNumber.Text))
                    selectCommand.Parameters.AddWithValue("@CompanyNumber", txtNumber.Text);
                if (!string.IsNullOrEmpty(txtEmail.Text))
                    selectCommand.Parameters.AddWithValue("@CompanyEmail", txtEmail.Text);
                if (!string.IsNullOrEmpty(txtWebsite.Text))
                    selectCommand.Parameters.AddWithValue("@ComapnyWebsite", txtWebsite.Text);
                selectCommand.Parameters.AddWithValue("@CompanyText", txtCompany.Text);
                selectCommand.Parameters.AddWithValue("@LocationText", txtLocation.Text);
                DateTime dateTime = new DateTime(Convert.ToInt32(ddlFromYear.SelectedValue), Convert.ToInt32(ddlFromMonth.SelectedValue), 1);
                selectCommand.Parameters.AddWithValue("@DateFrom", dateTime);
                if (!chkPresent.Checked)
                    selectCommand.Parameters.AddWithValue("@DateTo", (chkPresent.Checked ? Convert.ToDateTime(DateTime.Now.ToString("MMM dd, yyyy")) : Convert.ToDateTime(new DateTime(Convert.ToInt32(ddlToYear.SelectedValue), Convert.ToInt32(ddlToMonth.SelectedValue), 1))));
                selectCommand.Parameters.AddWithValue("@CurrentlyWorking", (chkPresent.Checked ? 1 : 0));
                selectCommand.Parameters.AddWithValue("@Responsibilities", txtResponsibilities.Text.ToString());
                selectCommand.Parameters.AddWithValue("@CurrentSalaray", Convert.ToInt32(str2));
                selectCommand.Parameters.AddWithValue("@InitialSalary", Convert.ToInt32(str3));
                selectCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
                selectCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
                if (!string.IsNullOrEmpty(str1))
                    selectCommand.Parameters.AddWithValue("@IsPermanent", Convert.ToInt16(str1));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }

    private void UpdateCandidateBenefits(string ExperienceCode)
    {
        foreach (Control control in rptBenefitTypes.Items)
        {
            foreach (ListItem listItem in ((ListControl)control.FindControl("rptBenefit")).Items)
            {
                int num = !listItem.Selected ? 0 : 1;
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    connection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateBenefits", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@BenefitCode", Convert.ToInt32(listItem.Value));
                        sqlCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_experience.CID));
                        sqlCommand.Parameters.AddWithValue("@ExperienceCode", Convert.ToInt32(ExperienceCode));
                        sqlCommand.Parameters.AddWithValue("@Chked", num);
                        sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
                        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
        }
    }

    private void ClearAllControls()
    {
        txtWebsite.Text = "";
        txtEmail.Text = "";
        txtNumber.Text = "";
        txtLocation.Text = "";
        txtCompany.Text = "";
        txtCurrentSalary.Text = "";
        txtInitialSalary.Text = "";
        txtResponsibilities.Text = "";
        txtTitle.Text = "";
        ddlFromMonth.SelectedValue = "";
        ddlToMonth.SelectedValue = "";
        ddlToYear.SelectedValue = "";
        ddlFromYear.SelectedValue = "";
        divPresent.Attributes.CssStyle.Add("display", "none");
        divtomonth.Attributes["class"] = "span2 xSetDisableExp";
        divtoYear.Attributes["class"] = "span2 xSetDisableExp";
        divTo.Attributes["class"] = "span4";
        divtomonth.Attributes.CssStyle.Add("display", "");
        divtoYear.Attributes.CssStyle.Add("display", "");
        chkPresent.Checked = false;
        ddlToYear.Style.Add("display", "");
        ddlToMonth.Style.Add("display", "");
        foreach (Control control in rptBenefitTypes.Items)
        {
            foreach (ListItem listItem in ((ListControl)control.FindControl("rptBenefit")).Items)
                listItem.Selected = false;
        }
        hfExperienceCode.Value = "";
        hfCompany.Value = "";
        hfLocation.Value = "";
        if (RadioButtonList1.SelectedItem != null)
            RadioButtonList1.SelectedItem.Selected = false;
        hfJobTitle.Value = "";
    }

    private void BindDLL()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectBenefitType", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet != null && dataSet.Tables != null)
            {
                if (dataSet.Tables[0].Rows.Count <= 0)
                    return;
                rptBenefitTypes.DataSource = dataSet.Tables[0];
                rptBenefitTypes.DataBind();
            }
            else
            {
                rptBenefitTypes.DataSource = null;
                rptBenefitTypes.DataBind();
            }
        }
    }

    private void LoadDates()
    {
        try
        {
            for (int year = DateTime.Now.Year; year > DateTime.Now.Year - 80; --year)
            {
                ddlFromYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
                ddlToYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
            }
            ddlToYear.Items.Insert(0, new ListItem(" Year ", ""));
            ddlFromYear.Items.Insert(0, new ListItem(" Year ", ""));
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_experience.CID);
        }
    }

    public void bindExperience()
    {
        profeExpList.Style.Add("display", "");
        profeExpList.Visible = true;
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            DataSet dataSet = new DataSet();
            using (SqlCommand selectCommand = new SqlCommand("Xrec_SelectCandidateExperienxeList", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_experience.CID));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                ListView1.DataSource = dataSet;
                ListView1.DataBind();
                profeExpList.Style.Add("display", "");
                profeExpCheck.Style.Add("display", "none");
                profeExp.Attributes["class"] = "";
                divSavebtn.Attributes["class"] = "row-fluid";
                rbtnIsExperience.SelectedValue = "1";
            }
            else
            {
                ListView1.DataSource = null;
                ListView1.Items.Clear();
                profeExpList.Style.Add("display", "none");
                profeExpCheck.Style.Add("display", "");
                profeExp.Attributes["class"] = "hidden";
                rbtnIsExperience.SelectedValue = "0";
            }
            if (rbtnIsExperience == null || !(rbtnIsExperience.SelectedValue == "0"))
                return;
            divSavebtn.Attributes["class"] = "row-fluid hidden";
        }
    }
}