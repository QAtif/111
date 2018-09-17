using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Data;
using ErrorLog;

public partial class Candidate_MasterSearch : CustomBasePage
{
    #region Paging Variables
    static DataView objDV = new DataView();
    SecureQueryString sQString = new SecureQueryString();
    static int PageSize;
    static string SortDirection = "DESC";
    PagedDataSource objPDS = new System.Web.UI.WebControls.PagedDataSource();
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    #endregion

    #region Event-Handlers

    private int PageNo
    {
        get
        {
            if (ViewState["PageNo"] != null)
                return Convert.ToInt32(ViewState["PageNo"]);
            return 0;
        }
        set
        {
            ViewState["PageNo"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            lblMsg.Visible = false;
            Candidate_MasterSearch.PageSize = 25;
            connection.Open();
            BindData();
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

    protected void rptCandidateLists_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(PageNo * Candidate_MasterSearch.PageSize + (e.Item.ItemIndex + 1));
            HiddenField control = (HiddenField)e.Item.FindControl("hdnCandidateCode");
            ((HtmlControl)e.Item.FindControl("aCandidateLink")).Attributes.Add("href", "CandidateDetails.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + control.Value));
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

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        if (!IsValid)
            return;
        try
        {
            if (txtCandidateName.Text == "")
                hdnCandidateCode.Value = "-1";
            GetCandidateDetail();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            lblMsg.Visible = true;
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    private void BindData()
    {
        SqlCommand selectCommand1 = new SqlCommand("dbo.XRec_SelectProfileCriteriaByUser", connection);
        selectCommand1.Parameters.AddWithValue("@UserCode", UserCode);
        selectCommand1.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(selectCommand1);
        DataSet dataSet1 = new DataSet();
        sqlDataAdapter1.Fill(dataSet1);
        if (dataSet1.Tables[4].Rows.Count > 0)
        {
            rptCategory.DataSource = dataSet1.Tables[4];
            rptCategory.DataBind();
        }
        if (dataSet1.Tables[9].Rows.Count > 0)
        {
            rptInstitute.DataSource = dataSet1.Tables[9];
            rptInstitute.DataBind();
        }
        if (dataSet1.Tables[10].Rows.Count > 0)
        {
            rptDegree.DataSource = dataSet1.Tables[10];
            rptDegree.DataBind();
        }
        if (dataSet1.Tables[11].Rows.Count > 0)
        {
            rptMajor.DataSource = dataSet1.Tables[11];
            rptMajor.DataBind();
        }
        if (dataSet1.Tables[12].Rows.Count > 0)
        {
            rptCompany.DataSource = dataSet1.Tables[12];
            rptCompany.DataBind();
        }
        LoadDates();
        if (dataSet1.Tables[7].Rows.Count > 0)
        {
            ddlMaritalStatus.DataSource = dataSet1.Tables[7];
            ddlMaritalStatus.DataTextField = "MaritalStatus";
            ddlMaritalStatus.DataValueField = "MaritalStatus_Code";
            ddlMaritalStatus.DataBind();
            ddlMaritalStatus.Items.Insert(0, new ListItem("----All----", ""));
        }
        if (dataSet1.Tables[8].Rows.Count > 0)
        {
            ddlGender.DataSource = dataSet1.Tables[8];
            ddlGender.DataTextField = "Gender";
            ddlGender.DataValueField = "Gender_Code";
            ddlGender.DataBind();
            ddlGender.Items.Insert(0, new ListItem("----All----", ""));
        }
        if (dataSet1.Tables[2].Rows.Count > 0)
        {
            ddlCity.DataSource = dataSet1.Tables[2];
            ddlCity.DataTextField = "City";
            ddlCity.DataValueField = "City_Code";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("----All----", "0"));
        }
        SqlCommand selectCommand2 = new SqlCommand("dbo.Xrec_Select_AllLyfeCycleStatus", connection);
        selectCommand2.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
        DataSet dataSet2 = new DataSet();
        sqlDataAdapter2.Fill(dataSet2);
        if (dataSet1.Tables[0].Rows.Count <= 0)
            return;
        ddlStatus.DataSource = dataSet2.Tables[0];
        ddlStatus.DataTextField = "Status_Name";
        ddlStatus.DataValueField = "Status_Code";
        ddlStatus.DataBind();
        ddlStatus.Items.Insert(0, new ListItem("----All----", "0"));
    }

    private void LoadDates()
    {
        postedFromDate.Attributes.Add("readonly", "readonly");
        postedFromDate.Value = DateTime.Now.AddMonths(-4).ToString("MMM dd, yyyy");
        postedToDate.Attributes.Add("readonly", "readonly");
        postedToDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
        for (int year = DateTime.Now.Year; year > DateTime.Now.Year - 80; --year)
            ddlYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
        ddlYear.Items.Insert(0, new ListItem("Year", ""));
        for (int index = 1; index <= 30; ++index)
            ddlNoOfYear.Items.Add(new ListItem(index.ToString(), index.ToString()));
        ddlNoOfYear.Items.Insert(0, new ListItem("No. Of Years", ""));
    }

    protected void btnAddSkill_Click(object sender, EventArgs e)
    {
        try
        {
            if (!(hfSkillName.Value != "") || !(hfSkillCode.Value != ""))
                return;
            chkSkills.Items.Add(new ListItem(hfSkillName.Value.ToString(), hfSkillCode.Value.ToString())
            {
                Selected = true
            });
            hfSkillCode.Value = (string)null;
            hfSkillName.Value = (string)null;
            txtacSkill.Text = "";
            txtacSkill.Focus();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Session["CC"].ToString());
        }
    }

    public void GetCandidateDetail()
    {
        string str1 = hdnCategory.Value;
        string str2 = hdnMajor.Value;
        string str3 = hdnDegree.Value;
        string str4 = hdnInstitute.Value;
        string str5 = hdnCompany.Value;
        string str6 = string.Empty;
        hdnCategory.Value = "";
        hdnMajor.Value = "";
        hdnDegree.Value = "";
        hdnInstitute.Value = "";
        foreach (ListItem listItem in chkSkills.Items)
        {
            if (listItem.Selected)
                str6 = str6 + listItem.Value + ",";
        }
        if (str6 != string.Empty)
            str6 = str6.Substring(0, str6.Length - 1);
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_SelectCandidateMasterSearch", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.CommandTimeout = 316000;
        if (!chkCategory.Checked && str1 != string.Empty && str1 != "")
            selectCommand.Parameters.Add("@CategoryCodes", SqlDbType.VarChar).Value = str1;
        if (!string.IsNullOrEmpty(txtCandidateName.Text.Trim()))
            selectCommand.Parameters.Add("@CandidateName", SqlDbType.VarChar).Value = txtCandidateName.Text.Trim();
        selectCommand.Parameters.Add("@ReferenceNo", SqlDbType.VarChar).Value = string.IsNullOrEmpty(txtRefNo.Text.Trim()) ? "-1" : Convert.ToString(txtRefNo.Text.Trim());
        if (!string.IsNullOrEmpty(txtEmail.Text))
            selectCommand.Parameters.Add("@CandidateEmail", SqlDbType.VarChar).Value = txtEmail.Text.Trim();
        if (!string.IsNullOrEmpty(txtNIC.Text))
            selectCommand.Parameters.Add("@CandidateNIC", SqlDbType.VarChar).Value = txtNIC.Text.Trim();
        if (!string.IsNullOrEmpty(txtPhone.Text))
            selectCommand.Parameters.Add("@CandidatePhone", SqlDbType.VarChar).Value = txtPhone.Text.Trim();
        if (ddlCity.SelectedValue != "0")
            selectCommand.Parameters.Add("@CityCode", SqlDbType.VarChar).Value = ddlCity.SelectedValue;
        if (str6 != string.Empty)
            selectCommand.Parameters.Add("@KeywordCodeCSV", SqlDbType.VarChar).Value = str6;
        if (ddlReferredBy.SelectedValue != "B")
            selectCommand.Parameters.Add("@ReferredBy", SqlDbType.VarChar).Value = ddlReferredBy.SelectedValue;
        selectCommand.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = postedFromDate.Value;
        selectCommand.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = postedToDate.Value;
        if (ddlMaritalStatus.SelectedValue != "")
            selectCommand.Parameters.Add("@MaritalStatusCode", SqlDbType.Int).Value = ddlMaritalStatus.SelectedValue;
        if (ddlGender.SelectedValue != "")
            selectCommand.Parameters.Add("@GenderCode", SqlDbType.Int).Value = ddlGender.SelectedValue;
        selectCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = UserCode;
        selectCommand.Parameters.Add("@EmailMatch", SqlDbType.Bit).Value = chkEmail.Checked;
        if (hdnFilterType.Value == "1")
        {
            if (!chkInstitute.Checked && str4 != string.Empty && str4 != "")
                selectCommand.Parameters.Add("@InstituteCodes", SqlDbType.VarChar).Value = str4;
            if (!chkDegree.Checked && str3 != string.Empty && str3 != "")
                selectCommand.Parameters.Add("@DegreeCodes", SqlDbType.VarChar).Value = str3;
            if (!chkMajor.Checked && str2 != string.Empty && str2 != "")
                selectCommand.Parameters.Add("@MajorCodes", SqlDbType.VarChar).Value = str2;
            if (ddlYear.SelectedValue != "")
                selectCommand.Parameters.Add("@Year", SqlDbType.Int).Value = ddlYear.SelectedValue;
        }
        if (hdnFilterType.Value == "2")
        {
            if (!chkCompany.Checked && str5 != string.Empty && str5 != "")
                selectCommand.Parameters.Add("@CompanyCodes", SqlDbType.VarChar).Value = str5;
            if (!string.IsNullOrEmpty(txtDesignation.Text))
                selectCommand.Parameters.Add("@Designation", SqlDbType.VarChar).Value = txtDesignation.Text;
            if (!string.IsNullOrEmpty(txtResponsibilities.Text))
                selectCommand.Parameters.Add("@Responsibility", SqlDbType.VarChar).Value = txtResponsibilities.Text;
            if (ddlSalaryFrom.SelectedValue != "" && ddlSalaryTo.SelectedValue != "")
            {
                selectCommand.Parameters.Add("@SalaryFrom", SqlDbType.Decimal).Value = ddlSalaryFrom.SelectedValue;
                selectCommand.Parameters.Add("@SalaryTo", SqlDbType.Decimal).Value = ddlSalaryTo.SelectedValue;
            }
            if (ddlNoOfYear.SelectedValue != "")
                selectCommand.Parameters.Add("@NoOfYear", SqlDbType.Int).Value = ddlNoOfYear.SelectedValue;
        }
        DataTable dataTable1 = new DataTable();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables.Count == 0)
            return;
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            if (ddlStatus.SelectedValue.ToString() != "0")
            {
                if (dataSet.Tables[0].Select("Status_Code='" + ddlStatus.SelectedValue.ToString() + "'").Length > 0)
                {
                    DataTable dataTable2 = ((IEnumerable<DataRow>)dataSet.Tables[0].Select("Status_Code='" + ddlStatus.SelectedValue.ToString() + "'")).CopyToDataTable<DataRow>();
                    rptCandidateLists.Visible = true;
                    lblMsg.Visible = false;
                    Candidate_MasterSearch.objDV = dataTable2.DefaultView;
                    trPagingControls.Attributes.Add("style", "display:''");
                    PageNo = 0;
                    rptCandidateLists.DataSource = ApplyPaging(Candidate_MasterSearch.objDV, PageNo);
                    rptCandidateLists.DataBind();
                }
                else
                {
                    trPagingControls.Attributes.Add("style", "display:none");
                    rptCandidateLists.DataSource = null;
                    rptCandidateLists.Visible = false;
                    lblMsg.Text = "No record(s) found";
                    lblMsg.Visible = true;
                }
            }
            else
            {
                DataTable table = dataSet.Tables[0];
                rptCandidateLists.Visible = true;
                lblMsg.Visible = false;
                Candidate_MasterSearch.objDV = table.DefaultView;
                trPagingControls.Attributes.Add("style", "display:''");
                PageNo = 0;
                rptCandidateLists.DataSource = ApplyPaging(Candidate_MasterSearch.objDV, PageNo);
                rptCandidateLists.DataBind();
            }
        }
        else
        {
            trPagingControls.Attributes.Add("style", "display:none");
            rptCandidateLists.DataSource = null;
            rptCandidateLists.Visible = false;
            lblMsg.Text = "No record(s) found";
            lblMsg.Visible = true;
        }
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Candidate_MasterSearch.PageSize;
        objPDS.CurrentPageIndex = PageNo;
        ViewState["PageCount"] = objPDS.PageCount.ToString();
        if (objPDS.PageCount > 1)
        {
            trPagingControls.Attributes.Add("style", "display:''");
            lblPageIndex.Visible = true;
            lblPageIndex.Text = "Page : " + (objPDS.CurrentPageIndex + 1).ToString() + " of " + objPDS.PageCount.ToString();
            if (objPDS.CurrentPageIndex == 0)
            {
                lnkbtnFirstPage.Visible = false;
                lnkbtnLastPage.Visible = true;
                lnkbtnNextPage.Visible = true;
                lnkbtnPrevPage.Visible = false;
            }
            else if (objPDS.CurrentPageIndex == objPDS.PageCount - 1)
            {
                lnkbtnFirstPage.Visible = true;
                lnkbtnLastPage.Visible = false;
                lnkbtnNextPage.Visible = false;
                lnkbtnPrevPage.Visible = true;
            }
            else
            {
                lnkbtnFirstPage.Visible = true;
                lnkbtnLastPage.Visible = true;
                lnkbtnNextPage.Visible = true;
                lnkbtnPrevPage.Visible = true;
            }
        }
        else
            trPagingControls.Attributes.Add("style", "display:none");
        return objPDS;
    }

    protected void lnkbtnFirstPage_Click(object sender, EventArgs e)
    {
        PageNo = 0;
        rptCandidateLists.DataSource = ApplyPaging(Candidate_MasterSearch.objDV, PageNo);
        rptCandidateLists.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptCandidateLists.DataSource = ApplyPaging(Candidate_MasterSearch.objDV, PageNo);
        rptCandidateLists.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptCandidateLists.DataSource = ApplyPaging(Candidate_MasterSearch.objDV, PageNo);
        rptCandidateLists.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptCandidateLists.DataSource = ApplyPaging(Candidate_MasterSearch.objDV, PageNo);
        rptCandidateLists.DataBind();
    }

    protected void btnFresh_Click(object sender, EventArgs e)
    {
        dvFresh.Visible = true;
        dvExperience.Visible = false;
    }

    protected void btnExperience_Click(object sender, EventArgs e)
    {
        dvExperience.Visible = true;
        dvFresh.Visible = false;
        dvFresh.Visible = true;
    }

    #endregion
}