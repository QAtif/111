using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ErrorLog;
using System.Text;
using System.Web.UI.HtmlControls;
using ASP;
using System.Web.Profile;
using System.Web.SessionState;


public partial class A2_Candidate_MasterSearch : CustomBasePage
{

    DataTable dtSearch = new DataTable();
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SecureQueryString sQString = new SecureQueryString();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            BindData();
            if (!string.IsNullOrEmpty(Request.QueryString["ls"]))
                ddlStatus.SelectedValue = Request.QueryString["Ls"].ToString();
            if (!string.IsNullOrEmpty(Request.QueryString["td"]))
                postedToDate.Value = Request.QueryString["td"].ToString();
            else
                postedToDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            if (!string.IsNullOrEmpty(Request.QueryString["fd"]))
                postedFromDate.Value = Request.QueryString["fd"].ToString();
            else
                postedFromDate.Value = DateTime.Now.AddMonths(-1).ToString("MMM dd, yyyy");
            if (Request["ls"] == null && Request["td"] == null && Request["fd"] == null)
                return;
            BtnSearchFresh_Click(btnSearchFresh, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    public void BindData()
    {
        try
        {
            DataSet dataSet = new DataSet();
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand selectCommand = new SqlCommand("dbo.BindMasterSerachFields", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            new SqlDataAdapter(selectCommand).Fill(dataSet);
            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                ddlStatus.DataSource = dataSet.Tables[0];
                ddlStatus.DataValueField = "code";
                ddlStatus.DataTextField = "name";
                ddlStatus.DataBind();
                ddlStatus.Items.Insert(0, new ListItem(" Select Status ", "0"));
            }
            else
            {
                ddlStatus.DataSource = null;
                ddlStatus.DataBind();
            }
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            for (int index = 15; index < 100; ++index)
            {
                ddlAgeFrom.Items.Add(new ListItem(index.ToString(), index.ToString()));
                ddlAgeTo.Items.Add(new ListItem(index.ToString(), index.ToString()));
                ddlEAgeFrom.Items.Add(new ListItem(index.ToString(), index.ToString()));
                ddlEAgeTo.Items.Add(new ListItem(index.ToString(), index.ToString()));
            }
            ddlAgeFrom.Items.Insert(0, new ListItem(" Year ", ""));
            ddlAgeTo.Items.Insert(0, new ListItem(" Year ", ""));
            ddlEAgeFrom.Items.Insert(0, new ListItem(" Year ", ""));
            ddlEAgeTo.Items.Insert(0, new ListItem(" Year ", ""));
            for (int year = DateTime.Now.Year; year > DateTime.Now.Year - 80; --year)
                ddlYears.Items.Add(new ListItem(year.ToString(), year.ToString()));
            ddlYears.Items.Insert(0, new ListItem(" Year ", ""));
            for (int index = 1; index < 30; ++index)
                ddlNoOfYear.Items.Add(new ListItem(index.ToString(), index.ToString()));
            ddlNoOfYear.Items.Insert(0, new ListItem(" Year ", ""));
            int num = 0;
            while (num < 1000000)
            {
                ddlSalaryFrom.Items.Add(new ListItem(num.ToString(), num.ToString()));
                ddlSalaryTo.Items.Add(new ListItem(num.ToString(), num.ToString()));
                num += 5000;
            }
            ddlSalaryFrom.Items.Insert(0, new ListItem(" Year ", ""));
            ddlSalaryTo.Items.Insert(0, new ListItem(" Year ", ""));
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptDeptCandidate_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnCandCode");
            HtmlAnchor control2 = (HtmlAnchor)e.Item.FindControl("aCandidateLink");
            HtmlAnchor control3 = (HtmlAnchor)e.Item.FindControl("aCandidateName");
            if (control1 == null)
                return;
            string str1 = "/A2/candidate/CandidateProfile.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + control1.Value);
            string str2 = "../../candidate/CandidateDetails.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + control1.Value);
            control2.HRef = str1;
            control3.HRef = str1;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptDepartments_itemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnDomainCode");
            Repeater control2 = (Repeater)e.Item.FindControl("rptDeptCandidate");
            if (dtSearch == null)
                return;
            if (dtSearch.Rows.Count > 0)
            {
                control2.DataSource = new DataView(dtSearch)
                {
                    RowFilter = ("Domain_code =" + control1.Value)
                };
                control2.DataBind();
            }
            else
            {
                control2.DataSource = null;
                control2.DataBind();
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void BtnSearchFresh_Click(object sender, EventArgs e)
    {
        try
        {
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            string empty5 = string.Empty;
            string empty6 = string.Empty;
            string empty7 = string.Empty;
            string empty8 = string.Empty;
            string empty9 = string.Empty;
            string empty10 = string.Empty;
            string empty11 = string.Empty;
            if (Request["ctl00$BodyContent$txtCategory"] != null)
                empty5 = Request.Form["ctl00$BodyContent$txtCategory"].ToString();
            if (Request["ctl00$BodyContent$txtCity"] != null)
                empty6 = Request.Form["ctl00$BodyContent$txtCity"].ToString();
            if (Request["ctl00$BodyContent$txtEducationLevel"] != null)
                empty7 = Request.Form["ctl00$BodyContent$txtEducationLevel"].ToString();
            if (Request["ctl00$BodyContent$txtEducationLevel"] != null)
                empty8 = Request.Form["ctl00$BodyContent$txtDegree"].ToString();
            if (Request["ctl00$BodyContent$txtEducationLevel"] != null)
                empty9 = Request.Form["ctl00$BodyContent$txtMajors"].ToString();
            if (Request["ctl00$BodyContent$txtEducationLevel"] != null)
                empty10 = Request.Form["ctl00$BodyContent$txtUniversity"].ToString();
            if (Request["ctl00$BodyContent$txtEducationLevel"] != null)
                empty11 = Request.Form["ctl00$BodyContent$txtSkills"].ToString();
            if (Request["ctl00$BodyContent$txtCompany"] != null)
                empty4 = Request.Form["ctl00$BodyContent$txtCompany"].ToString();
            if (Request["ctl00$BodyContent$txtDesignation"] != null)
                empty3 = Request.Form["ctl00$BodyContent$txtDesignation"].ToString();
            if (Request["ctl00$BodyContent$txtSKillSetE"] != null)
                empty2 = Request.Form["ctl00$BodyContent$txtSKillSetE"].ToString();
            if (Request["ctl00$BodyContent$txtSKillSetE"] != null)
                empty1 = Request.Form["ctl00$BodyContent$txtRefUrl"].ToString();
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand selectCommand = new SqlCommand("dbo.XRec_SelectCandidateforMasterSearch", connection);
            selectCommand.Parameters.Add("@UserCode", UserCode);
            if (!string.IsNullOrEmpty(postedFromDate.Value))
                selectCommand.Parameters.Add("@FromDate", postedFromDate.Value);
            if (!string.IsNullOrEmpty(postedToDate.Value))
                selectCommand.Parameters.Add("@ToDate", postedToDate.Value);
            if (!string.IsNullOrEmpty(txtName.Text))
                selectCommand.Parameters.Add("@CandidateName", txtName.Text.Trim());
            if (!string.IsNullOrEmpty(txtRefNo.Text))
                selectCommand.Parameters.Add("@ReferenceNo", txtRefNo.Text.Trim());
            if (!string.IsNullOrEmpty(txtEmail.Text))
                selectCommand.Parameters.Add("@CandidateEmail", txtEmail.Text.Trim());
            if (!string.IsNullOrEmpty(txtPhone.Text))
                selectCommand.Parameters.Add("@CandidatePhone", txtPhone.Text.Trim());
            if (!string.IsNullOrEmpty(txtNic.Text))
                selectCommand.Parameters.Add("@CandidateNIC", txtNic.Text.Trim());
            if (rdMaritalStatus.SelectedValue != "0")
                selectCommand.Parameters.Add("@MaritalStatusCode", rdMaritalStatus.SelectedValue);
            if (rdGender.SelectedValue != "0")
                selectCommand.Parameters.Add("@GenderCode", rdGender.SelectedValue);
            if (ddlStatus.SelectedValue != "0")
                selectCommand.Parameters.Add("@LifestyleStatus", ddlStatus.SelectedValue);
            if (!chkIsDate.Checked)
                selectCommand.Parameters.Add("@IsDate", 1);
            if (!string.IsNullOrEmpty(empty5))
                selectCommand.Parameters.Add("@CatID", empty5);
            if (!string.IsNullOrEmpty(empty6))
                selectCommand.Parameters.Add("@CityCode", empty6);
            if (!string.IsNullOrEmpty(empty7))
                selectCommand.Parameters.Add("@ProgramCode", empty7);
            if (!string.IsNullOrEmpty(empty1))
                selectCommand.Parameters.Add("@RefUrl", empty1);
            if (!string.IsNullOrEmpty(empty8))
                selectCommand.Parameters.Add("@DegreeCodes", empty8);
            if (!string.IsNullOrEmpty(empty9))
                selectCommand.Parameters.Add("@MajorCodes", empty9);
            if (!string.IsNullOrEmpty(empty10))
                selectCommand.Parameters.Add("@InstituteCodes", empty10);
            if (!string.IsNullOrEmpty(empty11))
                selectCommand.Parameters.Add("@KeywordCodeCSV", empty11);
            if (!string.IsNullOrEmpty(ddlYears.SelectedValue))
                selectCommand.Parameters.Add("@Year", ddlYears.SelectedValue);
            if (!string.IsNullOrEmpty(ddlAgeTo.SelectedValue))
                selectCommand.Parameters.Add("@AgeTo", ddlAgeTo.SelectedValue);
            if (!string.IsNullOrEmpty(ddlAgeFrom.SelectedValue))
                selectCommand.Parameters.Add("@AgeFrom", ddlAgeFrom.SelectedValue);
            if (rdPortfolio.SelectedValue != "0")
                selectCommand.Parameters.Add("@Portfolio", rdPortfolio.SelectedValue);
            selectCommand.CommandTimeout = 1000;
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet != null)
            {
                if (dataSet.Tables.Count >= 2)
                    dtSearch = dataSet.Tables[1].Rows.Count <= 0 ? (DataTable)null : dataSet.Tables[1];
                if (dataSet.Tables[1].Rows.Count > 0)
                {
                    rptDepartments.DataSource = dataSet.Tables[0];
                    rptDepartments.DataBind();
                }
                else
                {
                    rptDepartments.DataSource = null;
                    rptDepartments.DataBind();
                }
            }
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            RetrieveAutoCompleteData(empty5, empty6, empty7, empty9, empty8, empty11, empty10, empty4, empty3, empty2, empty1);
            chkIsDate.Checked = true;
            imgLoadingF.Style.Add("display", "none");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void BtnSearchExperienced_Click(object sender, EventArgs e)
    {
        try
        {
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            string empty5 = string.Empty;
            string empty6 = string.Empty;
            string empty7 = string.Empty;
            string empty8 = string.Empty;
            string empty9 = string.Empty;
            string empty10 = string.Empty;
            string empty11 = string.Empty;
            if (Request["ctl00$BodyContent$txtCategory"] != null)
                empty5 = Request.Form["ctl00$BodyContent$txtCategory"].ToString();
            if (Request["ctl00$BodyContent$txtCity"] != null)
                empty6 = Request.Form["ctl00$BodyContent$txtCity"].ToString();
            if (Request["ctl00$BodyContent$txtEducationLevel"] != null)
                empty7 = Request.Form["ctl00$BodyContent$txtEducationLevel"].ToString();
            if (Request["ctl00$BodyContent$txtEducationLevel"] != null)
                empty8 = Request.Form["ctl00$BodyContent$txtDegree"].ToString();
            if (Request["ctl00$BodyContent$txtEducationLevel"] != null)
                empty9 = Request.Form["ctl00$BodyContent$txtMajors"].ToString();
            if (Request["ctl00$BodyContent$txtEducationLevel"] != null)
                empty10 = Request.Form["ctl00$BodyContent$txtUniversity"].ToString();
            if (Request["ctl00$BodyContent$txtEducationLevel"] != null)
                empty11 = Request.Form["ctl00$BodyContent$txtSkills"].ToString();
            if (Request["ctl00$BodyContent$txtCompany"] != null)
                empty4 = Request.Form["ctl00$BodyContent$txtCompany"].ToString();
            if (Request["ctl00$BodyContent$txtDesignation"] != null)
                empty3 = Request.Form["ctl00$BodyContent$txtDesignation"].ToString();
            if (Request["ctl00$BodyContent$txtSKillSetE"] != null)
                empty2 = Request.Form["ctl00$BodyContent$txtSKillSetE"].ToString();
            if (Request["ctl00$BodyContent$txtSKillSetE"] != null)
                empty1 = Request.Form["ctl00$BodyContent$txtRefUrl"].ToString();
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand selectCommand = new SqlCommand("dbo.XRec_SelectCandidateforMasterSearch", connection);
            selectCommand.Parameters.Add("@UserCode", UserCode);
            if (!string.IsNullOrEmpty(postedFromDate.Value))
                selectCommand.Parameters.Add("@FromDate", postedFromDate.Value);
            if (!string.IsNullOrEmpty(postedToDate.Value))
                selectCommand.Parameters.Add("@ToDate", postedToDate.Value);
            if (!string.IsNullOrEmpty(txtName.Text))
                selectCommand.Parameters.Add("@CandidateName", txtName.Text.Trim());
            if (!string.IsNullOrEmpty(txtRefNo.Text))
                selectCommand.Parameters.Add("@ReferenceNo", txtRefNo.Text.Trim());
            if (!string.IsNullOrEmpty(txtEmail.Text))
                selectCommand.Parameters.Add("@CandidateEmail", txtEmail.Text.Trim());
            if (!string.IsNullOrEmpty(txtPhone.Text))
                selectCommand.Parameters.Add("@CandidatePhone", txtPhone.Text.Trim());
            if (!string.IsNullOrEmpty(txtNic.Text))
                selectCommand.Parameters.Add("@CandidateNIC", txtNic.Text.Trim());
            if (rdMaritalStatus.SelectedValue != "0")
                selectCommand.Parameters.Add("@MaritalStatusCode", rdMaritalStatus.SelectedValue);
            if (rdGender.SelectedValue != "0")
                selectCommand.Parameters.Add("@GenderCode", rdGender.SelectedValue);
            if (ddlStatus.SelectedValue != "0")
                selectCommand.Parameters.Add("@LifestyleStatus", ddlStatus.SelectedValue);
            if (!chkIsDate.Checked)
                selectCommand.Parameters.Add("@IsDate", 1);
            if (!string.IsNullOrEmpty(empty5))
                selectCommand.Parameters.Add("@CatID", empty5);
            if (!string.IsNullOrEmpty(empty6))
                selectCommand.Parameters.Add("@CityCode", empty6);
            if (!string.IsNullOrEmpty(empty7))
                selectCommand.Parameters.Add("@ProgramCode", empty7);
            if (!string.IsNullOrEmpty(empty4))
                selectCommand.Parameters.Add("@CompanyCodes", empty4);
            if (!string.IsNullOrEmpty(empty3))
                selectCommand.Parameters.Add("@Designation", empty3);
            if (!string.IsNullOrEmpty(txtResponsiblities.Text))
                selectCommand.Parameters.Add("@Responsibility", txtResponsiblities.Text.Trim());
            if (!string.IsNullOrEmpty(ddlSalaryFrom.SelectedValue))
                selectCommand.Parameters.Add("@SalaryFrom", ddlSalaryFrom.SelectedValue);
            if (!string.IsNullOrEmpty(ddlSalaryTo.SelectedValue))
                selectCommand.Parameters.Add("@SalaryTo", ddlSalaryTo.SelectedValue);
            if (!string.IsNullOrEmpty(ddlNoOfYear.SelectedValue))
                selectCommand.Parameters.Add("@NoOfYear", ddlNoOfYear.SelectedValue);
            if (!string.IsNullOrEmpty(empty2))
                selectCommand.Parameters.Add("@KeywordCodeCSV", empty2);
            if (!string.IsNullOrEmpty(ddlEAgeTo.SelectedValue))
                selectCommand.Parameters.Add("@AgeTo", ddlEAgeTo.SelectedValue);
            if (!string.IsNullOrEmpty(ddlEAgeFrom.SelectedValue))
                selectCommand.Parameters.Add("@AgeFrom", ddlEAgeFrom.SelectedValue);
            if (rdEPortfolio.SelectedValue != "0")
                selectCommand.Parameters.Add("@Portfolio", rdEPortfolio.SelectedValue);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet != null)
            {
                if (dataSet.Tables.Count >= 2)
                    dtSearch = dataSet.Tables[1].Rows.Count <= 0 ? (DataTable)null : dataSet.Tables[1];
                if (dataSet.Tables[1].Rows.Count > 0)
                {
                    rptDepartments.DataSource = dataSet.Tables[0];
                    rptDepartments.DataBind();
                }
                else
                {
                    rptDepartments.DataSource = null;
                    rptDepartments.DataBind();
                }
            }
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            RetrieveAutoCompleteData(empty5, empty6, empty7, empty9, empty8, empty11, empty10, empty4, empty3, empty2, empty1);
            chkIsDate.Checked = true;
            imgLoadingE.Style.Add("display", "none");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    public void RetrieveAutoCompleteData(string CategoryCode, string CityCode, string EducationLevel, string MajorCode, string DegreeCode, string skillCode, string UniCode, string CompanyCode, string DesignationCode, string SKillSetE, string RefUrl)
    {
        try
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand selectCommand = new SqlCommand("dbo.XRec_SelectAutoCompleteFieldDataByID", connection);
            if (!string.IsNullOrEmpty(CategoryCode))
                selectCommand.Parameters.Add("@CatID", CategoryCode);
            if (!string.IsNullOrEmpty(CityCode))
                selectCommand.Parameters.Add("@CityID", CityCode);
            if (!string.IsNullOrEmpty(EducationLevel))
                selectCommand.Parameters.Add("@EduID", EducationLevel);
            if (!string.IsNullOrEmpty(MajorCode))
                selectCommand.Parameters.Add("@MajorID", MajorCode);
            if (!string.IsNullOrEmpty(DegreeCode))
                selectCommand.Parameters.Add("@DegreeID", DegreeCode);
            if (!string.IsNullOrEmpty(skillCode))
                selectCommand.Parameters.Add("@SkillID", skillCode);
            if (!string.IsNullOrEmpty(UniCode))
                selectCommand.Parameters.Add("@InsID", UniCode);
            if (!string.IsNullOrEmpty(CompanyCode))
                selectCommand.Parameters.Add("@ComID", CompanyCode);
            if (!string.IsNullOrEmpty(DesignationCode))
                selectCommand.Parameters.Add("@DesgID", DesignationCode);
            if (!string.IsNullOrEmpty(SKillSetE))
                selectCommand.Parameters.Add("@SkillEID", SKillSetE);
            if (!string.IsNullOrEmpty(RefUrl))
                selectCommand.Parameters.Add("@RefUrl", RefUrl);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet != null)
            {
                if (dataSet.Tables.Count >= 1)
                    BindControl(dataSet.Tables[0], "txtCategory");
                if (dataSet.Tables.Count >= 2)
                    BindControl(dataSet.Tables[1], "txtCity");
                if (dataSet.Tables.Count >= 3)
                    BindControl(dataSet.Tables[2], "txtEducationLevel");
                if (dataSet.Tables.Count >= 4)
                    BindControl(dataSet.Tables[3], "txtDegree");
                if (dataSet.Tables.Count >= 5)
                    BindControl(dataSet.Tables[4], "txtMajors");
                if (dataSet.Tables.Count >= 6)
                    BindControl(dataSet.Tables[5], "txtUniversity");
                if (dataSet.Tables.Count >= 7)
                    BindControl(dataSet.Tables[6], "txtSkills");
                if (dataSet.Tables.Count >= 8)
                    BindControl(dataSet.Tables[7], "txtSKillSetE");
                if (dataSet.Tables.Count >= 9)
                    BindControl(dataSet.Tables[8], "txtCompany");
                if (dataSet.Tables.Count >= 10)
                    BindControl(dataSet.Tables[9], "txtDesignation");
                if (dataSet.Tables.Count >= 11)
                    BindControl(dataSet.Tables[10], "txtRefUrl");
            }
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private string GetJSONString(List<clsJsonObject> data)
    {
        StringBuilder stringBuilder = new StringBuilder();
        try
        {
            foreach (clsJsonObject clsJsonObject in data)
            {
                if (stringBuilder.Length != 0)
                    stringBuilder.Append(",");
                stringBuilder.Append("{");
                stringBuilder.Append(string.Format("\"{0}\":\"{1}\"", "id", clsJsonObject.Id));
                stringBuilder.Append(",");
                stringBuilder.Append(string.Format("\"{0}\":\"{1}\"", "name", clsJsonObject.Name));
                stringBuilder.Append("}");
            }
            stringBuilder.Insert(0, "[");
            stringBuilder.Append("]");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        return stringBuilder.ToString();
    }

    public void BindControl(DataTable dt, string ControlName)
    {
        try
        {
            Utilities utilities = new Utilities();
            List<clsJsonObject> data = new List<clsJsonObject>();
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in (InternalDataCollectionBase)dt.Rows)
                    data.Add(new clsJsonObject()
                    {
                        Id = row["id"].ToString(),
                        Name = row["Name"].ToString()
                    });
            }
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "Script" + ControlName, " Bind('" + GetJSONString(data) + "','" + ControlName + "');", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

}
public class clsJsonObject
{
    public string Id;
    public string Name;
}
