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

public partial class CandidateExperience : CustomBasePage
{

    #region Page Variables
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;
    public static string CID;
    #endregion Page Variables

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            if (QueryStringVar == null)
                return;
            secQueryString = new SecureQueryString(QueryStringVar);
            if (secQueryString["CID"] == null)
                return;
            CandidateExperience.CID = secQueryString["CID"].ToString();
            if (IsPostBack)
                return;
            LoadDates();
            BindDLL();
            BindData();
            CheckCandidateExperience();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateExperience.CID);
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
            ddlToYear.Items.Insert(0, new ListItem("-Year-", ""));
            ddlFromYear.Items.Insert(0, new ListItem("-Year-", ""));
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, CandidateExperience.CID);
        }
    }

    private void CheckCandidateExperience()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateHasExperience", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateExperience.CID);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
                if (dataSet == null || dataSet.Tables == null || dataSet.Tables[0].Rows.Count <= 0)
                    return;
                if (dataSet.Tables[0].Rows[0]["HasExperience"].ToString() == "1")
                    AddOrHideExperience();
                else if (dataSet.Tables[0].Rows[0]["HasExperience"].ToString() == "0")
                {
                    AddOrHideExperience();
                }
                else
                {
                    if (!(dataSet.Tables[0].Rows[0]["HasExperience"].ToString() == "2"))
                        return;
                    AddOrHideExperience();
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateExperience.CID);
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!IsValid)
                return;
            DataSet dataSet1 = new DataSet();
            DataSet dataSet2 = UpdateCandidateExperience();
            if (dataSet2 != null && dataSet2.Tables != null && dataSet2.Tables[0].Rows.Count > 0)
                UpdateCandidateBenefits(dataSet2.Tables[0].Rows[0]["ExperienceCode"].ToString());
            BindData();
            ClearAllControls();
            CheckCandidateExperience();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateExperience.CID);
        }
    }

    protected void rptBenefitTypes_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataSet dataSet = new DataSet();
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        Repeater control = (Repeater)e.Item.FindControl("rptBenefit");
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
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
                control.DataBind();
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateExperience.CID);
            }
        }
    }

    protected void rptExperience_OnItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            DataSet objDS = new DataSet();
            if (e.CommandName == "Delete")
            {
                DeleteSelectedExperience(e);
                BindData();
            }
            if (!(e.CommandName == "Edit"))
                return;
            BindExperienceForEdit(e, objDS);
            BindCandidateBenefit(e, objDS);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateExperience.CID);
        }
    }

    private void BindCandidateBenefit(RepeaterCommandEventArgs e, DataSet objDS)
    {
        objDS = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateBenefit", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@ExperienceCode", Convert.ToInt32(e.CommandArgument.ToString()));
                    selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(CandidateExperience.CID));
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(objDS);
                    if (objDS == null || objDS.Tables == null || objDS.Tables[0].Rows.Count <= 0)
                        return;
                    for (int index = 0; index < objDS.Tables[0].Rows.Count; ++index)
                    {
                        foreach (Control control1 in rptBenefitTypes.Items)
                        {
                            foreach (RepeaterItem repeaterItem in ((Repeater)control1.FindControl("rptBenefit")).Items)
                            {
                                CheckBox control2 = (CheckBox)repeaterItem.FindControl("chkBenefitName");
                                if (Convert.ToInt32(((Label)repeaterItem.FindControl("lblBenefitCode")).Text).ToString() == objDS.Tables[0].Rows[index]["Benefit_Code"].ToString())
                                    control2.Checked = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateExperience.CID);
            }
        }
    }

    private void DeleteSelectedExperience(RepeaterCommandEventArgs e)
    {
        try
        {
            if (!(e.CommandName == "Delete"))
                return;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
            {
                connection.Open();
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand("XRec_DeactivateCandidateExperience", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@CandidateExperienceCode", Convert.ToInt32(e.CommandArgument.ToString()));
                        sqlCommand.Parameters.AddWithValue("@UpdatedBy", Convert.ToInt32(CandidateExperience.CID));
                        sqlCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(CandidateExperience.CID));
                        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                        sqlCommand.ExecuteNonQuery();
                        CheckCandidateExperience();
                    }
                }
                catch (Exception ex)
                {
                    LogError.Write(LogError.AppType.Candidate, "XRec_DeactivateCandidateExperience", ex, CandidateExperience.CID);
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateExperience.CID);
        }
    }

    private void BindExperienceForEdit(RepeaterCommandEventArgs e, DataSet objDS)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateExperience", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@ExperienceCode", Convert.ToInt32(e.CommandArgument.ToString()));
                    selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(CandidateExperience.CID));
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(objDS);
                    if (objDS == null || objDS.Tables == null || objDS.Tables[0].Rows.Count <= 0)
                        return;
                    chkPresent.Checked = false;
                    txtIndustry.Text = objDS.Tables[0].Rows[0]["Industry"].ToString();
                    hfIndustry.Value = objDS.Tables[0].Rows[0]["Industry_Code"].ToString();
                    txtCompany.Text = objDS.Tables[0].Rows[0]["Company"].ToString();
                    hfCompany.Value = objDS.Tables[0].Rows[0]["Company_Code"].ToString();
                    txtLocation.Text = objDS.Tables[0].Rows[0]["Location"].ToString();
                    hfLocation.Value = objDS.Tables[0].Rows[0]["Location_Code"].ToString();
                    txtTitle.Text = objDS.Tables[0].Rows[0]["Position"].ToString();
                    ddlFromMonth.SelectedValue = Convert.ToDateTime(objDS.Tables[0].Rows[0]["DateFrom"].ToString()).Month.ToString();
                    ddlFromYear.SelectedValue = Convert.ToDateTime(objDS.Tables[0].Rows[0]["DateFrom"].ToString()).Year.ToString();
                    chkPresent.Checked = objDS.Tables[0].Rows[0]["Is_CurrentlyWorking"].ToString() == "True";
                    if (chkPresent.Checked)
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
                        ddlToMonth.SelectedValue = Convert.ToDateTime(objDS.Tables[0].Rows[0]["EndDate"].ToString()).Month.ToString();
                        ddlToYear.SelectedValue = Convert.ToDateTime(objDS.Tables[0].Rows[0]["EndDate"].ToString()).Year.ToString();
                    }
                    txtResponsibilities.Text = objDS.Tables[0].Rows[0]["Responsibilties_Included"].ToString();
                    txtResonforleaving.Text = objDS.Tables[0].Rows[0]["ReasonFor_Leaving"].ToString();
                    chkPresent.Checked = objDS.Tables[0].Rows[0]["Is_CurrentlyWorking"].ToString() == "True";
                    txtCurrentSalary.Text = objDS.Tables[0].Rows[0]["Current_Salary"].ToString().Split('.')[0].ToString();
                    txtInitialSalary.Text = objDS.Tables[0].Rows[0]["Initial_Salary"].ToString().Split('.')[0].ToString();
                    hfExperienceCode.Value = objDS.Tables[0].Rows[0]["CandidateExperience_Code"].ToString();
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateExperience.CID);
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearAllControls();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateExperience.CID);
        }
    }

    protected void btnAddMore_Click(object sender, EventArgs e)
    {
        try
        {
            ClearAllControls();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateExperience.CID);
        }
    }

    protected void chkPresent_CheckedChanged(object sender, EventArgs e)
    {
        CurrentlyWorking();
    }

    protected void rblHasExperience_SelectedIndexChanged(object sender, EventArgs e)
    {
        AddOrHideExperience();
    }

    protected void ValidateTenure(object source, ServerValidateEventArgs args)
    {
        args.IsValid = new DateTime(Convert.ToInt32(ddlFromYear.SelectedValue.ToString()), Convert.ToInt32(ddlFromMonth.SelectedValue.ToString()), 1) < new DateTime(Convert.ToInt32(ddlToYear.SelectedValue.ToString()), Convert.ToInt32(ddlToMonth.SelectedValue.ToString()), 1);
    }

    private void CurrentlyWorking()
    {
        if (chkPresent.Checked)
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

    private void AddOrHideExperience()
    {
        int count = rptExperience.Items.Count;
    }

    private void BindData()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateExperience", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateExperience.CID);
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
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateExperience.CID);
            }
        }
    }

    private void BindDLL()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
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
                    rptBenefitTypes.DataSource = dataSet;
                    rptBenefitTypes.DataBind();
                }
                else
                {
                    rptBenefitTypes.DataSource = null;
                    rptBenefitTypes.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateExperience.CID);
            }
        }
    }

    private void UpdateCandidateBenefits(string ExperienceCode)
    {
        foreach (Control control1 in rptBenefitTypes.Items)
        {
            foreach (RepeaterItem repeaterItem in ((Repeater)control1.FindControl("rptBenefit")).Items)
            {
                Label control2 = (Label)repeaterItem.FindControl("lblBenefitCode");
                int num = !((CheckBox)repeaterItem.FindControl("chkBenefitName")).Checked ? 0 : 1;
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
                {
                    connection.Open();
                    try
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateBenefits", connection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@BenefitCode", Convert.ToInt32(control2.Text));
                            sqlCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(CandidateExperience.CID));
                            sqlCommand.Parameters.AddWithValue("@ExperienceCode", Convert.ToInt32(ExperienceCode));
                            sqlCommand.Parameters.AddWithValue("@Chked", num);
                            sqlCommand.Parameters.AddWithValue("@UpdatedBy", Convert.ToInt32(CandidateExperience.CID));
                            sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateExperience.CID);
                    }
                }
            }
        }
    }

    private DataSet UpdateCandidateExperience()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_UpdateCandidateExperienceAdmin", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateExperience.CID);
                    selectCommand.Parameters.AddWithValue("@ExperienceCode", hfExperienceCode.Value);
                    selectCommand.Parameters.AddWithValue("@PositionTitle", txtTitle.Text.ToString());
                    selectCommand.Parameters.AddWithValue("@IndustryCode", Convert.ToInt32(hfIndustry.Value.ToString()));
                    selectCommand.Parameters.AddWithValue("@CompanyCode", Convert.ToInt32(hfCompany.Value.ToString()));
                    selectCommand.Parameters.AddWithValue("@LocationCode", Convert.ToInt32(hfLocation.Value.ToString()));
                    selectCommand.Parameters.AddWithValue("@IndustryText", txtIndustry.Text);
                    selectCommand.Parameters.AddWithValue("@CompanyText", txtCompany.Text);
                    selectCommand.Parameters.AddWithValue("@LocationText", txtLocation.Text);
                    DateTime dateTime = new DateTime(Convert.ToInt32(ddlFromYear.SelectedValue), Convert.ToInt32(ddlFromMonth.SelectedValue), 1);
                    selectCommand.Parameters.AddWithValue("@DateFrom", dateTime);
                    if (!chkPresent.Checked)
                        selectCommand.Parameters.AddWithValue("@DateTo", (chkPresent.Checked ? Convert.ToDateTime(DateTime.Now.ToString("MMM dd, yyyy")) : Convert.ToDateTime(new DateTime(Convert.ToInt32(ddlToYear.SelectedValue), Convert.ToInt32(ddlToMonth.SelectedValue), 1))));
                    selectCommand.Parameters.AddWithValue("@CurrentlyWorking", (chkPresent.Checked ? 1 : 0));
                    selectCommand.Parameters.AddWithValue("@Responsibilities", txtResponsibilities.Text.ToString());
                    selectCommand.Parameters.AddWithValue("@ReasonOfLeaving", txtResonforleaving.Text.ToString());
                    selectCommand.Parameters.AddWithValue("@CurrentSalaray", txtCurrentSalary.Text.ToString());
                    selectCommand.Parameters.AddWithValue("@InitialSalary", txtInitialSalary.Text.ToString());
                    selectCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
                    selectCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
                    selectCommand.Parameters.AddWithValue("@UserType", 1);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateExperience.CID);
            }
        }
        return dataSet;
    }

    private void ClearAllControls()
    {
        try
        {
            txtCompany.Text = "";
            txtCurrentSalary.Text = "";
            txtIndustry.Text = "";
            txtInitialSalary.Text = "";
            txtLocation.Text = "";
            txtResonforleaving.Text = "";
            txtResponsibilities.Text = "";
            txtTitle.Text = "";
            chkPresent.Checked = false;
            foreach (Control control1 in rptBenefitTypes.Items)
            {
                foreach (Control control2 in ((Repeater)control1.FindControl("rptBenefit")).Items)
                    ((CheckBox)control2.FindControl("chkBenefitName")).Checked = false;
            }
            hfExperienceCode.Value = "";
            hfIndustry.Value = "";
            hfCompany.Value = "";
            hfLocation.Value = "";
            CurrentlyWorking();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateExperience.CID);
        }
    }
    #endregion


}