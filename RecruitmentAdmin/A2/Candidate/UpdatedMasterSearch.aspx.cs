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
using System.Text.RegularExpressions;
public partial class A2_Candidate_UpdatedMasterSearch : CustomBasePage
{
    #region Variables
    DataTable dtSearch = new DataTable();
    int PageSize = 100;
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SecureQueryString sQString = new SecureQueryString();
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session.Clear();
                pagging.Style.Add("display", "none");
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
                if (Request["ls"] != null || Request["td"] != null || Request["fd"] != null)
                    BtnSearchFresh_Click(btnSearchFresh, EventArgs.Empty);
                rblType.SelectedValue = "0";
                Session["SType"] = hdnSelectedTab.Value.ToString();
            }
            Session["SType"] = hdnSelectedTab.Value.ToString();
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

    protected void rptResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnCandCode");
            HtmlAnchor control2 = (HtmlAnchor)e.Item.FindControl("aRefno");
            if (control1 == null)
                return;
            string str = "/A2/candidate/CandidateProfile.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + control1.Value);
            control2.HRef = str;
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

    protected void BtnSearchFresh_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Clear();
            pagging.Style.Add("display", "none");
            GetFreshCandidate(1);
            chkIsDate.Checked = true;
            imgLoadingF.Style.Add("display", "none");
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

    protected void BtnSearchExperienced_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Clear();
            pagging.Style.Add("display", "none");
            GetExperienceCandidate(1);
            chkIsDate.Checked = true;
            imgLoadingE.Style.Add("display", "none");
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

    protected void lbl_Click(object sender, EventArgs e)
    {
        try
        {
            int page;
            if (Session["PageNo"] != null)
            {
                page = Convert.ToInt32(Session["PageNo"].ToString()) + 1;
                Session["PageNo"] = page;
                if (page > 1)
                    lnkback.Style.Add("display", "");
                else
                    lnknext.Style.Add("display", "none");
            }
            else
                page = 1;
            if (hdnSelectedTab.Value == "1")
                GetFreshCandidate(page);
            if (!(hdnSelectedTab.Value == "2"))
                return;
            GetExperienceCandidate(page);
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

    protected void lblBack_Click(object sender, EventArgs e)
    {
        try
        {
            int page = Session["PageNo"] == null ? 1 : Convert.ToInt32(Session["PageNo"].ToString()) - 1;
            Session["PageNo"] = page;
            if (page != 0)
            {
                if (hdnSelectedTab.Value == "1")
                    GetFreshCandidate(page);
                if (!(hdnSelectedTab.Value == "2"))
                    return;
                GetExperienceCandidate(page);
            }
            else
                lnkback.Style.Add("display", "none");
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
            if (dataSet != null)
            {
                if (dataSet.Tables.Count >= 1)
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
                if (dataSet.Tables.Count >= 2)
                {
                    ddlDomain.DataSource = dataSet.Tables[1];
                    ddlDomain.DataValueField = "code";
                    ddlDomain.DataTextField = "name";
                    ddlDomain.DataBind();
                }
                else
                {
                    ddlDomain.DataSource = null;
                    ddlDomain.DataBind();
                }
                if (dataSet.Tables.Count >= 3)
                {
                    ddlReligion.DataSource = dataSet.Tables[2];
                    ddlReligion.DataValueField = "Religion_Code";
                    ddlReligion.DataTextField = "Religion";
                    ddlReligion.DataBind();
                    ddlReligion.Items.Insert(0, new ListItem(" Select Religion ", "0"));
                }
                else
                {
                    ddlReligion.DataSource = null;
                    ddlReligion.DataBind();
                }
                if (dataSet.Tables.Count >= 4)
                {
                    ddlCategory.DataSource = dataSet.Tables[3];
                    ddlCategory.DataValueField = "Category_Code";
                    ddlCategory.DataTextField = "Category_Name";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem(" Select Category ", "0"));
                }
                else
                {
                    ddlCategory.DataSource = null;
                    ddlCategory.DataBind();
                }
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
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    public void GetFreshCandidate(int page)
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_SelectCandidateforMasterSearchNew", connection);
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
        selectCommand.Parameters.Add("@CanType", rblType.SelectedValue);
        if (!string.IsNullOrEmpty(hfAgents.Value))
            selectCommand.Parameters.Add("@DomainCode", hfAgents.Value);
        if (ddlReligion.SelectedValue != "0")
            selectCommand.Parameters.Add("@Religion", ddlReligion.SelectedValue);
        if (ddlRefBy.SelectedValue != "0")
            selectCommand.Parameters.Add("@IsReferred", ddlRefBy.SelectedValue);
        if (!string.IsNullOrEmpty(txtCategory.Text))
            selectCommand.Parameters.Add("@CatID", txtCategory.Text);
        if (!string.IsNullOrEmpty(txtCity.Text))
            selectCommand.Parameters.Add("@CityCode", txtCity.Text);
        if (!string.IsNullOrEmpty(txtRefUrl.Text))
            selectCommand.Parameters.Add("@RefUrl", txtRefUrl.Text);
        if (!string.IsNullOrEmpty(txtDegree.Text))
            selectCommand.Parameters.Add("@DegreeCodes", txtDegree.Text);
        if (!string.IsNullOrEmpty(txtMajors.Text))
            selectCommand.Parameters.Add("@MajorCodes", txtMajors.Text);
        if (!string.IsNullOrEmpty(txtUniversity.Text))
            selectCommand.Parameters.Add("@InstituteCodes", txtUniversity.Text);
        if (!string.IsNullOrEmpty(txtSkills.Text))
            selectCommand.Parameters.Add("@KeywordCodeCSV", txtSkills.Text);
        if (!string.IsNullOrEmpty(ddlYears.SelectedValue))
            selectCommand.Parameters.Add("@Year", ddlYears.SelectedValue);
        if (!string.IsNullOrEmpty(ddlAgeTo.SelectedValue))
            selectCommand.Parameters.Add("@AgeTo", ddlAgeTo.SelectedValue);
        if (!string.IsNullOrEmpty(ddlAgeFrom.SelectedValue))
            selectCommand.Parameters.Add("@AgeFrom", ddlAgeFrom.SelectedValue);
        if (rdPortfolio.SelectedValue != "0")
            selectCommand.Parameters.Add("@Portfolio", rdPortfolio.SelectedValue);
        if (page != 0)
            selectCommand.Parameters.Add("@PageNo", page);
        if (ddlCategory.SelectedValue != "0")
            selectCommand.Parameters.Add("@Category", ddlCategory.SelectedValue);
        selectCommand.CommandTimeout = 0;
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet != null)
        {
            if (dataSet.Tables.Count >= 1)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    dtSearch = dataSet.Tables[0];
                    TotalCount.Value = dtSearch.Rows[0]["TotalCount"].ToString();
                }
                else
                    dtSearch = (DataTable)null;
            }
            if (dataSet.Tables[1].Rows.Count > 0)
            {
                rptResult.DataSource = null;
                rptResult.DataBind();
                lblPagging.Text = dataSet.Tables[1].Rows[0]["rownum"].ToString() + " - " + dataSet.Tables[1].Rows[dataSet.Tables[1].Rows.Count - 1]["rownum"].ToString() + " of " + TotalCount.Value;
                rptResult.DataSource = dataSet.Tables[1];
                rptResult.DataBind();
                if (Session["PageNo"] == null)
                {
                    Session["PageNo"] = "1";
                    lnkback.Style.Add("display", "none");
                    if (Convert.ToInt32(TotalCount.Value) > 100)
                        lnknext.Style.Add("display", "");
                    else
                        lnknext.Style.Add("display", "none");
                }
                else
                {
                    if (Session["PageNo"].ToString() == "1")
                        lnkback.Style.Add("display", "none");
                    else
                        lnkback.Style.Add("display", "");
                    if (Convert.ToInt32(Session["PageNo"]) < Convert.ToInt32(TotalCount.Value) / 100 + 1)
                        lnknext.Style.Add("display", "");
                    else
                        lnknext.Style.Add("display", "none");
                }
                pagging.Style.Add("display", "");
            }
            else
            {
                rptResult.DataSource = null;
                rptResult.DataBind();
                if (Session["PageNo"] == null)
                    pagging.Style.Add("display", "none");
            }
        }
        Session["SType"] = hdnSelectedTab.Value.ToString();
        if (Session["SType"] != null)
        {
            if (Session["SType"].ToString() == "1")
                Page.ClientScript.RegisterStartupScript(GetType(), "func2", "ClickSerachType(" + Session["SType"].ToString() + ")", true);
            if (Session["SType"].ToString() == "2")
                Page.ClientScript.RegisterStartupScript(GetType(), "func1", "ClickSerachType(" + Session["SType"].ToString() + ")", true);
        }
        if (connection.State == ConnectionState.Closed)
            return;
        connection.Close();
    }

    public void GetFreshCandidateToExcel(int page)
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_SelectCandidateforMasterSearchNewForExcel", connection);
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
        selectCommand.Parameters.Add("@CanType", rblType.SelectedValue);
        if (!string.IsNullOrEmpty(hfAgents.Value))
            selectCommand.Parameters.Add("@DomainCode", hfAgents.Value);
        if (ddlReligion.SelectedValue != "0")
            selectCommand.Parameters.Add("@Religion", ddlReligion.SelectedValue);
        if (ddlRefBy.SelectedValue != "0")
            selectCommand.Parameters.Add("@IsReferred", ddlRefBy.SelectedValue);
        if (!string.IsNullOrEmpty(txtCategory.Text))
            selectCommand.Parameters.Add("@CatID", txtCategory.Text);
        if (!string.IsNullOrEmpty(txtCity.Text))
            selectCommand.Parameters.Add("@CityCode", txtCity.Text);
        if (!string.IsNullOrEmpty(txtRefUrl.Text))
            selectCommand.Parameters.Add("@RefUrl", txtRefUrl.Text);
        if (!string.IsNullOrEmpty(txtDegree.Text))
            selectCommand.Parameters.Add("@DegreeCodes", txtDegree.Text);
        if (!string.IsNullOrEmpty(txtMajors.Text))
            selectCommand.Parameters.Add("@MajorCodes", txtMajors.Text);
        if (!string.IsNullOrEmpty(txtUniversity.Text))
            selectCommand.Parameters.Add("@InstituteCodes", txtUniversity.Text);
        if (!string.IsNullOrEmpty(txtSkills.Text))
            selectCommand.Parameters.Add("@KeywordCodeCSV", txtSkills.Text);
        if (!string.IsNullOrEmpty(ddlYears.SelectedValue))
            selectCommand.Parameters.Add("@Year", ddlYears.SelectedValue);
        if (!string.IsNullOrEmpty(ddlAgeTo.SelectedValue))
            selectCommand.Parameters.Add("@AgeTo", ddlAgeTo.SelectedValue);
        if (!string.IsNullOrEmpty(ddlAgeFrom.SelectedValue))
            selectCommand.Parameters.Add("@AgeFrom", ddlAgeFrom.SelectedValue);
        if (rdPortfolio.SelectedValue != "0")
            selectCommand.Parameters.Add("@Portfolio", rdPortfolio.SelectedValue);
        if (page != 0)
            selectCommand.Parameters.Add("@PageNo", page);
        if (ddlCategory.SelectedValue != "0")
            selectCommand.Parameters.Add("@Category", ddlCategory.SelectedValue);
        selectCommand.CommandTimeout = 0;
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet != null)
        {
            if (dataSet.Tables.Count >= 1)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    dtSearch = dataSet.Tables[0];
                    TotalCount.Value = dtSearch.Rows[0]["TotalCount"].ToString();
                }
                else
                    dtSearch = (DataTable)null;
            }
            if (dataSet.Tables[1].Rows.Count > 0 && dataSet.Tables[1].Rows.Count > 0)
                ExportToSpreadsheet(dataSet.Tables[1], "@E:\\products\\SearchResult.xlsx");
        }
        if (connection.State == ConnectionState.Closed)
            return;
        connection.Close();
    }

    public void GetExperienceCandidate(int page)
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_SelectCandidateforMasterSearchNew", connection);
        selectCommand.Parameters.AddWithValue("@UserCode", UserCode);
        if (!string.IsNullOrEmpty(postedFromDate.Value))
            selectCommand.Parameters.AddWithValue("@FromDate", postedFromDate.Value);
        if (!string.IsNullOrEmpty(postedToDate.Value))
            selectCommand.Parameters.AddWithValue("@ToDate", postedToDate.Value);
        if (!string.IsNullOrEmpty(txtName.Text))
            selectCommand.Parameters.AddWithValue("@CandidateName", txtName.Text.Trim());
        if (!string.IsNullOrEmpty(txtRefNo.Text))
            selectCommand.Parameters.AddWithValue("@ReferenceNo", txtRefNo.Text.Trim());
        if (!string.IsNullOrEmpty(txtEmail.Text))
            selectCommand.Parameters.AddWithValue("@CandidateEmail", txtEmail.Text.Trim());
        if (!string.IsNullOrEmpty(txtPhone.Text))
            selectCommand.Parameters.AddWithValue("@CandidatePhone", txtPhone.Text.Trim());
        if (!string.IsNullOrEmpty(txtNic.Text))
            selectCommand.Parameters.AddWithValue("@CandidateNIC", txtNic.Text.Trim());
        if (rdMaritalStatus.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@MaritalStatusCode", rdMaritalStatus.SelectedValue);
        if (rdGender.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@GenderCode", rdGender.SelectedValue);
        if (ddlStatus.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@LifestyleStatus", ddlStatus.SelectedValue);
        if (!chkIsDate.Checked)
            selectCommand.Parameters.AddWithValue("@IsDate", 1);
        selectCommand.Parameters.AddWithValue("@CanType", rblType.SelectedValue);
        if (!string.IsNullOrEmpty(hfAgents.Value))
            selectCommand.Parameters.AddWithValue("@DomainCode", hfAgents.Value);
        if (ddlReligion.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@Religion", ddlReligion.SelectedValue);
        if (!string.IsNullOrEmpty(txtCategory.Text))
            selectCommand.Parameters.AddWithValue("@CatID", txtCategory.Text);
        if (!string.IsNullOrEmpty(txtCity.Text))
            selectCommand.Parameters.AddWithValue("@CityCode", txtCity.Text);
        if (!string.IsNullOrEmpty(txtCompany.Text))
            selectCommand.Parameters.AddWithValue("@CompanyCodes", txtCompany.Text);
        if (!string.IsNullOrEmpty(txtDesignation.Text))
            selectCommand.Parameters.AddWithValue("@Designation", txtDesignation.Text);
        if (!string.IsNullOrEmpty(txtResponsiblities.Text))
            selectCommand.Parameters.AddWithValue("@Responsibility", txtResponsiblities.Text.Trim());
        if (!string.IsNullOrEmpty(ddlSalaryFrom.SelectedValue))
            selectCommand.Parameters.AddWithValue("@SalaryFrom", ddlSalaryFrom.SelectedValue);
        if (!string.IsNullOrEmpty(ddlSalaryTo.SelectedValue))
            selectCommand.Parameters.AddWithValue("@SalaryTo", ddlSalaryTo.SelectedValue);
        if (!string.IsNullOrEmpty(ddlNoOfYear.SelectedValue))
            selectCommand.Parameters.AddWithValue("@NoOfYear", ddlNoOfYear.SelectedValue);
        if (!string.IsNullOrEmpty(txtSKillSetE.Text))
            selectCommand.Parameters.AddWithValue("@KeywordCodeCSV", txtSKillSetE.Text);
        if (!string.IsNullOrEmpty(ddlEAgeTo.SelectedValue))
            selectCommand.Parameters.AddWithValue("@AgeTo", ddlEAgeTo.SelectedValue);
        if (!string.IsNullOrEmpty(ddlEAgeFrom.SelectedValue))
            selectCommand.Parameters.AddWithValue("@AgeFrom", ddlEAgeFrom.SelectedValue);
        if (rdEPortfolio.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@Portfolio", rdEPortfolio.SelectedValue);
        if (page != 0)
            selectCommand.Parameters.AddWithValue("@PageNo", page);
        if (ddlCategory.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@Category", ddlCategory.SelectedValue);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet != null)
        {
            if (dataSet.Tables.Count >= 1)
            {
                if (dataSet.Tables[1].Rows.Count > 0)
                {
                    dtSearch = dataSet.Tables[0];
                    TotalCount.Value = dtSearch.Rows[0]["TotalCount"].ToString();
                }
                else
                    dtSearch = (DataTable)null;
            }
            if (dataSet.Tables.Count >= 2)
            {
                if (dataSet.Tables[1].Rows.Count > 0)
                {
                    rptResult.DataSource = null;
                    rptResult.DataBind();
                    rptResult.DataSource = dataSet.Tables[1];
                    rptResult.DataBind();
                    if (Session["PageNo"] == null)
                    {
                        Session["PageNo"] = "1";
                        lnkback.Style.Add("display", "none");
                        if (Convert.ToInt32(TotalCount.Value) < 100)
                            lnknext.Style.Add("display", "none");
                        else
                            lnknext.Style.Add("display", "");
                    }
                    else
                    {
                        if (Session["PageNo"].ToString() == "1")
                            lnkback.Style.Add("display", "none");
                        else
                            lnkback.Style.Add("display", "");
                        if (Convert.ToInt32(TotalCount.Value) < 100)
                            lnknext.Style.Add("display", "none");
                        else
                            lnknext.Style.Add("display", "");
                    }
                    pagging.Style.Add("display", "");
                }
                else
                {
                    rptResult.DataSource = null;
                    rptResult.DataBind();
                    if (Session["PageNo"] == null)
                        pagging.Style.Add("display", "none");
                }
            }
        }
        if (connection.State != ConnectionState.Closed)
            connection.Close();
        Session["SType"] = hdnSelectedTab.Value.ToString();
        if (Session["SType"] == null)
            return;
        if (Session["SType"].ToString() == "1")
            Page.ClientScript.RegisterStartupScript(GetType(), "func2", "ClickSerachType(" + Session["SType"].ToString() + ")", true);
        if (!(Session["SType"].ToString() == "2"))
            return;
        Page.ClientScript.RegisterStartupScript(GetType(), "func1", "ClickSerachType(" + Session["SType"].ToString() + ")", true);
    }

    public void GetExperienceCandidateExcel(int page)
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_SelectCandidateforMasterSearchNewForExcel", connection);
        selectCommand.Parameters.AddWithValue("@UserCode", UserCode);
        if (!string.IsNullOrEmpty(postedFromDate.Value))
            selectCommand.Parameters.AddWithValue("@FromDate", postedFromDate.Value);
        if (!string.IsNullOrEmpty(postedToDate.Value))
            selectCommand.Parameters.AddWithValue("@ToDate", postedToDate.Value);
        if (!string.IsNullOrEmpty(txtName.Text))
            selectCommand.Parameters.AddWithValue("@CandidateName", txtName.Text.Trim());
        if (!string.IsNullOrEmpty(txtRefNo.Text))
            selectCommand.Parameters.AddWithValue("@ReferenceNo", txtRefNo.Text.Trim());
        if (!string.IsNullOrEmpty(txtEmail.Text))
            selectCommand.Parameters.AddWithValue("@CandidateEmail", txtEmail.Text.Trim());
        if (!string.IsNullOrEmpty(txtPhone.Text))
            selectCommand.Parameters.AddWithValue("@CandidatePhone", txtPhone.Text.Trim());
        if (!string.IsNullOrEmpty(txtNic.Text))
            selectCommand.Parameters.AddWithValue("@CandidateNIC", txtNic.Text.Trim());
        if (rdMaritalStatus.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@MaritalStatusCode", rdMaritalStatus.SelectedValue);
        if (rdGender.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@GenderCode", rdGender.SelectedValue);
        if (ddlStatus.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@LifestyleStatus", ddlStatus.SelectedValue);
        if (!chkIsDate.Checked)
            selectCommand.Parameters.AddWithValue("@IsDate", 1);
        selectCommand.Parameters.AddWithValue("@CanType", rblType.SelectedValue);
        if (!string.IsNullOrEmpty(hfAgents.Value))
            selectCommand.Parameters.AddWithValue("@DomainCode", hfAgents.Value);
        if (ddlReligion.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@Religion", ddlReligion.SelectedValue);
        if (!string.IsNullOrEmpty(txtCategory.Text))
            selectCommand.Parameters.AddWithValue("@CatID", txtCategory.Text);
        if (!string.IsNullOrEmpty(txtCity.Text))
            selectCommand.Parameters.AddWithValue("@CityCode", txtCity.Text);
        if (!string.IsNullOrEmpty(txtCompany.Text))
            selectCommand.Parameters.AddWithValue("@CompanyCodes", txtCompany.Text);
        if (!string.IsNullOrEmpty(txtDesignation.Text))
            selectCommand.Parameters.AddWithValue("@Designation", txtDesignation.Text);
        if (!string.IsNullOrEmpty(txtResponsiblities.Text))
            selectCommand.Parameters.AddWithValue("@Responsibility", txtResponsiblities.Text.Trim());
        if (!string.IsNullOrEmpty(ddlSalaryFrom.SelectedValue))
            selectCommand.Parameters.AddWithValue("@SalaryFrom", ddlSalaryFrom.SelectedValue);
        if (!string.IsNullOrEmpty(ddlSalaryTo.SelectedValue))
            selectCommand.Parameters.AddWithValue("@SalaryTo", ddlSalaryTo.SelectedValue);
        if (!string.IsNullOrEmpty(ddlNoOfYear.SelectedValue))
            selectCommand.Parameters.AddWithValue("@NoOfYear", ddlNoOfYear.SelectedValue);
        if (!string.IsNullOrEmpty(txtSKillSetE.Text))
            selectCommand.Parameters.AddWithValue("@KeywordCodeCSV", txtSKillSetE.Text);
        if (!string.IsNullOrEmpty(ddlEAgeTo.SelectedValue))
            selectCommand.Parameters.AddWithValue("@AgeTo", ddlEAgeTo.SelectedValue);
        if (!string.IsNullOrEmpty(ddlEAgeFrom.SelectedValue))
            selectCommand.Parameters.AddWithValue("@AgeFrom", ddlEAgeFrom.SelectedValue);
        if (rdEPortfolio.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@Portfolio", rdEPortfolio.SelectedValue);
        if (page != 0)
            selectCommand.Parameters.AddWithValue("@PageNo", page);
        if (ddlCategory.SelectedValue != "0")
            selectCommand.Parameters.AddWithValue("@Category", ddlCategory.SelectedValue);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet != null)
        {
            if (dataSet.Tables.Count >= 1)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    dtSearch = dataSet.Tables[0];
                    TotalCount.Value = dtSearch.Rows[0]["TotalCount"].ToString();
                }
                else
                    dtSearch = (DataTable)null;
            }
            if (dataSet.Tables[1].Rows.Count > 0 && dataSet.Tables[1].Rows.Count > 0)
                ExportToSpreadsheet(dataSet.Tables[1], "@E:\\products\\SearchResult.xlsx");
        }
        if (connection.State == ConnectionState.Closed)
            return;
        connection.Close();
    }

    protected void lnkExport_Click(object sender, EventArgs e)
    {
        if (hdnSelectedTab.Value == "1")
        {
            GetFreshCandidateToExcel(1);
            Page.ClientScript.RegisterStartupScript(GetType(), "func2", "ClickSerachType(" + hdnSelectedTab.Value + ")", true);
        }
        else
        {
            if (!(hdnSelectedTab.Value == "2"))
                return;
            GetExperienceCandidateExcel(1);
            Page.ClientScript.RegisterStartupScript(GetType(), "func1", "ClickSerachType(" + hdnSelectedTab.Value + ")", true);
        }
    }

    public void ExportToSpreadsheet(DataTable table, string FileNameWithPath)
    {
        if (table.Rows.Count <= 0)
            return;
        string str1 = "attachment; filename=SearchResult.xls";
        Page.Response.ClearContent();
        Response.AddHeader("content-disposition", str1);
        Response.ContentType = "application/vnd.ms-excel";
        string str2 = "";
        foreach (DataColumn column in (InternalDataCollectionBase)table.Columns)
        {
            if (column.ColumnName != "rownum" && column.ColumnName != "candidate_code" && (column.ColumnName != "Status_Code" && column.ColumnName != "sundomain_code") && column.ColumnName != "Domain_code")
            {
                Response.Write(str2 + column.ColumnName);
                str2 = "\t";
            }
        }
        Response.Write("\n");
        foreach (DataRow row in (InternalDataCollectionBase)table.Rows)
        {
            string str3 = "";
            for (int index = 0; index < table.Columns.Count; ++index)
            {
                if (table.Columns[index].ColumnName != "lastExperience" && table.Columns[index].ColumnName != "lastQualification" && (table.Columns[index].ColumnName != "rownum" && table.Columns[index].ColumnName != "candidate_code") && (table.Columns[index].ColumnName != "Status_Code" && table.Columns[index].ColumnName != "sundomain_code" && table.Columns[index].ColumnName != "Domain_code"))
                {
                    Response.Write(str3 + row[index].ToString());
                    str3 = "\t";
                }
                else if (table.Columns[index].ColumnName == "lastExperience" || table.Columns[index].ColumnName == "lastQualification")
                {
                    string str4 = row[index].ToString().Replace("<table style=\"margin: 5px 5px 5px 5px;\">", "").Replace("<tr>", "").Replace("<td align=\"left\" valign=\"top\" width=\"25%\">", "").Replace("</td>", "").Replace("<td>", "").Replace("<td valign=\"top\" align=\"left\">", "").Replace("</tr>", "").Replace("</table>", "").Replace("</b>", "").Replace("<b>", "-->  ").Replace("<div style=\"margin: 15px 5px 5px 5px;\">", "").Replace("</div>", "").Replace("<td align=\"left\" valign=\"top\" width=\"15%\">", "");
                    Response.Write(str3 + str4);
                    str3 = "\t";
                }
            }
            Response.Write("\n");
        }
        Response.End();
    }
    #endregion
}