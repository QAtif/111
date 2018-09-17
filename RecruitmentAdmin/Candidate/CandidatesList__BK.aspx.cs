using AjaxControlToolkit;
using ASP;
using ErrorLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Candidate_CandidatesList__BK : CustomBasePage, IRequiresSessionState
{
    private static DataView objDV = new DataView();
    private static string SortDirection = "DESC";
    private SecureQueryString sQString = new SecureQueryString();
    private PagedDataSource objPDS = new PagedDataSource();
    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    private SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    protected ScriptManager ScriptManager1;
    protected ValidationSummary vsValidators;
    protected DropDownList ddlCategory;
    protected TextBox txtRefNo;
    protected RegularExpressionValidator valNumbersOnly;
    protected TextBox txtCandidateName;
    protected HiddenField hdnCandidateCode;
    protected DropDownList ddlStatus;
    protected TextBox txtEmail;
    protected HiddenField HiddenField1;
    protected TextBox txtPhone;
    protected TextBox txtNIC;
    protected HiddenField HiddenField2;
    protected DropDownList ddlCity;
    protected TextBox txtacSkill;
    protected AutoCompleteExtender acSkill;
    protected HiddenField hfSkillCode;
    protected HiddenField hfSkillName;
    protected Button btnAddSkill;
    protected CheckBoxList chkSkills;
    protected LinkButton lnkSearch;
    protected UpdateProgress UpdateProgress1;
    protected Label lblMsg;
    protected UpdatePanel updatePanel1;
    private static int PageSize;

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
            Candidate_CandidatesList__BK.PageSize = 25;
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
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(PageNo * Candidate_CandidatesList__BK.PageSize + (e.Item.ItemIndex + 1));
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
            ddlCategory.DataSource = dataSet1.Tables[4];
            ddlCategory.DataTextField = "category_name";
            ddlCategory.DataValueField = "Category_code";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("----All----", "0"));
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
        string str = string.Empty;
        foreach (ListItem listItem in chkSkills.Items)
        {
            if (listItem.Selected)
                str = str + listItem.Value + ",";
        }
        if (str != string.Empty)
            str = str.Substring(0, str.Length - 1);
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_SelectCandidateLists", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        if (ddlCategory.SelectedValue != "0")
            selectCommand.Parameters.Add("@Category_Code", SqlDbType.Int).Value = int.Parse(ddlCategory.SelectedValue);
        if (!string.IsNullOrEmpty(txtCandidateName.Text))
            selectCommand.Parameters.Add("@CandidateName", SqlDbType.VarChar).Value = txtCandidateName.Text;
        selectCommand.Parameters.Add("@ReferenceNo", SqlDbType.VarChar).Value = string.IsNullOrEmpty(txtRefNo.Text) ? "-1" : Convert.ToString(txtRefNo.Text);
        if (!string.IsNullOrEmpty(txtEmail.Text))
            selectCommand.Parameters.Add("@CandidateEmail", SqlDbType.VarChar).Value = txtEmail.Text.Trim();
        if (!string.IsNullOrEmpty(txtNIC.Text))
            selectCommand.Parameters.Add("@CandidateNIC", SqlDbType.VarChar).Value = txtNIC.Text.Trim();
        if (!string.IsNullOrEmpty(txtPhone.Text))
            selectCommand.Parameters.Add("@CandidatePhone", SqlDbType.VarChar).Value = txtPhone.Text.Trim();
        if (ddlCity.SelectedValue != "0")
            selectCommand.Parameters.Add("@CityCode", SqlDbType.VarChar).Value = ddlCity.SelectedValue;
        if (str != string.Empty)
            selectCommand.Parameters.Add("@KeywordCodeCSV", SqlDbType.VarChar).Value = str;
        selectCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = UserCode;
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
                    Candidate_CandidatesList__BK.objDV = dataTable2.DefaultView;
                    trPagingControls.Attributes.Add("style", "display:''");
                    PageNo = 0;
                    rptCandidateLists.DataSource = ApplyPaging(Candidate_CandidatesList__BK.objDV, PageNo);
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
                Candidate_CandidatesList__BK.objDV = table.DefaultView;
                trPagingControls.Attributes.Add("style", "display:''");
                PageNo = 0;
                rptCandidateLists.DataSource = ApplyPaging(Candidate_CandidatesList__BK.objDV, PageNo);
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
        objPDS.PageSize = Candidate_CandidatesList__BK.PageSize;
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
        rptCandidateLists.DataSource = ApplyPaging(Candidate_CandidatesList__BK.objDV, PageNo);
        rptCandidateLists.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptCandidateLists.DataSource = ApplyPaging(Candidate_CandidatesList__BK.objDV, PageNo);
        rptCandidateLists.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptCandidateLists.DataSource = ApplyPaging(Candidate_CandidatesList__BK.objDV, PageNo);
        rptCandidateLists.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptCandidateLists.DataSource = ApplyPaging(Candidate_CandidatesList__BK.objDV, PageNo);
        rptCandidateLists.DataBind();
    }
}