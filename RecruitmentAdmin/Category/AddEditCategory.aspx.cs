using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using ErrorLog;
using System.Web.SessionState;
using XRecruitmentStatusLibrary;


public partial class Category_AddEditCategory : CustomBasePage, IRequiresSessionState
{
    #region variable
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;

    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        aBrowsedFile.Style.Add("display", "none");
        if (IsPostBack)
            return;
        trTestDuration.Visible = false;
        trTest.Visible = false;
        trSampleTest.Visible = false;
        QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
        if (QueryStringVar != null)
            secQueryString = new SecureQueryString(QueryStringVar);
        lblMsg.Visible = false;
        try
        {
            CheckQueryString();
            BindData();
            FillDomainDDL(-1);
            PerformanceJobRole();
            if (hdnCategoryCode.Value != "0")
                BindCategory();
            if (ddlCatUserType.SelectedValue == "5")
                JobRole.Visible = true;
            else
                JobRole.Visible = false;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string str = InsertCategory();
            if (str != null)
            {
                if (str != "")
                {
                    if (str != "0")
                    {
                        lblMsg.Text = "Successfully Saved!";
                        lblMsg.Visible = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        Page.RegisterStartupScript("Close", "<script language=JavaScript> CloseHighSlideWithParentRefresh();</script>");
    }

    protected void ddlDomain_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (!(ddlDomain.SelectedValue != ""))
                return;
            DataSet subdomainByDomainCode = Common.GetSubdomainByDomainCode(Convert.ToInt32(ddlDomain.SelectedValue));
            if (subdomainByDomainCode.Tables[0].Rows.Count <= 0)
                return;
            ddlSubDomain.DataSource = subdomainByDomainCode;
            ddlSubDomain.DataTextField = "SubDomain_Name";
            ddlSubDomain.DataValueField = "SubDomain_Code";
            ddlSubDomain.DataBind();
            ddlSubDomain.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private void BindCategory()
    {
        DataSet categoryByCategoryCode = AdminClass.GetCategoryByCategoryCode(Convert.ToInt32(hdnCategoryCode.Value));
        if (categoryByCategoryCode.Tables[0].Rows.Count <= 0)
            return;
        txtCategoryName.Text = categoryByCategoryCode.Tables[0].Rows[0]["Category_Name"].ToString();
        ddlDomain.SelectedValue = categoryByCategoryCode.Tables[0].Rows[0]["Domain_Code"].ToString();
        ddlDomain_SelectedIndexChanged(null, (EventArgs)null);
        txtCategoryTitle.Text = categoryByCategoryCode.Tables[0].Rows[0]["Category_Title"].ToString();
        ddlGradeFrom.SelectedValue = categoryByCategoryCode.Tables[0].Rows[0]["Grade_FromCode"].ToString();
        ddlGradeTo.SelectedValue = categoryByCategoryCode.Tables[0].Rows[0]["Grade_ToCode"].ToString();
        ddlSubDomain.SelectedValue = categoryByCategoryCode.Tables[0].Rows[0]["SubDomain_Code"].ToString();
        ddlProfile.SelectedValue = categoryByCategoryCode.Tables[0].Rows[0]["Profile_Code"].ToString();
        ddlPositionType.SelectedValue = categoryByCategoryCode.Tables[0].Rows[0]["PositionTypeCode"].ToString();
        if (!string.IsNullOrEmpty(categoryByCategoryCode.Tables[0].Rows[0]["JobRoleCode"].ToString()))
            ddlJobRole.SelectedValue = categoryByCategoryCode.Tables[0].Rows[0]["JobRoleCode"].ToString();
        txtJobDesc.Text = categoryByCategoryCode.Tables[0].Rows[0]["Job_Description"].ToString();
        txtBonusFarmula.Text = categoryByCategoryCode.Tables[0].Rows[0]["Bonus_Formula"].ToString();
        ddlBonusType.SelectedValue = categoryByCategoryCode.Tables[0].Rows[0]["BonusType_Code"].ToString();
        txtTPC.Text = categoryByCategoryCode.Tables[0].Rows[0]["total_approved_count"].ToString();
        txtFP.Text = categoryByCategoryCode.Tables[0].Rows[0]["filled_position"].ToString();
        txtUP.Text = categoryByCategoryCode.Tables[0].Rows[0]["unfilled_position"].ToString();
        txtNr.Text = categoryByCategoryCode.Tables[0].Rows[0]["new_requisition"].ToString();
        txtPrefix.Text = categoryByCategoryCode.Tables[0].Rows[0]["prefix"].ToString();
        if (!string.IsNullOrEmpty(categoryByCategoryCode.Tables[0].Rows[0]["SampleTestPath"].ToString()))
        {
            aBrowsedFile.Style.Add("display", "");
            aBrowsedFile.HRef = categoryByCategoryCode.Tables[0].Rows[0]["SampleTestPath"].ToString();
            aBrowsedFile.InnerText = categoryByCategoryCode.Tables[0].Rows[0]["SampleTestPath"].ToString();
        }
        else
            aBrowsedFile.Style.Add("display", "none");
        if (!string.IsNullOrEmpty(categoryByCategoryCode.Tables[0].Rows[0]["catUserType"].ToString()))
            ddlCatUserType.SelectedValue = categoryByCategoryCode.Tables[0].Rows[0]["catUserType"].ToString();
        btnAdd.Text = "Update Category";
        lblHead.Text = "Edit Category";
        if (Convert.ToBoolean(categoryByCategoryCode.Tables[0].Rows[0]["Is_Student"]))
            chkcertified.Checked = true;
        if (Convert.ToBoolean(categoryByCategoryCode.Tables[0].Rows[0]["Isbike"]))
            chkIsBike.Checked = true;
        if (Convert.ToBoolean(categoryByCategoryCode.Tables[0].Rows[0]["Is_Test"]))
        {
            chkTest.Checked = true;
            txtTestDuration.Text = categoryByCategoryCode.Tables[0].Rows[0]["Test_Duration"].ToString();
            trTestDuration.Visible = true;
            trTest.Visible = true;
            trSampleTest.Visible = true;
        }
        else
        {
            chkTest.Checked = false;
            trTestDuration.Visible = false;
            trTest.Visible = false;
            trSampleTest.Visible = false;
        }
        if (categoryByCategoryCode.Tables[1].Rows.Count > 0)
        {
            foreach (DataRow row in (InternalDataCollectionBase)categoryByCategoryCode.Tables[1].Rows)
            {
                foreach (ListItem listItem in lbTest.Items)
                {
                    if (row["TestCode"].ToString() == listItem.Value)
                        listItem.Selected = true;
                }
            }
        }
        txtInterviewDuration.Text = categoryByCategoryCode.Tables[0].Rows[0]["Interview_Duration"].ToString();
    }

    private void CheckQueryString()
    {
        if (QueryStringVar == null || secQueryString["cCode"] == null)
            return;
        hdnCategoryCode.Value = secQueryString["cCode"].ToString();
    }

    private void FillDomainDDL(int IsStaff)
    {
        DataSet domainByStaffCode = Common.GetDomainByStaffCode(IsStaff);
        if (domainByStaffCode.Tables[0].Rows.Count <= 0)
            return;
        ddlDomain.DataSource = domainByStaffCode;
        ddlDomain.DataTextField = "Domain_Name";
        ddlDomain.DataValueField = "Domain_Code";
        ddlDomain.DataBind();
        ddlDomain.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    private void BindData()
    {
        DataSet profile = Common.GetProfile();
        if (profile.Tables[0].Rows.Count > 0)
        {
            ddlProfile.DataSource = profile;
            ddlProfile.DataTextField = "Profile_Name";
            ddlProfile.DataValueField = "Profile_Code";
            ddlProfile.DataBind();
            ddlProfile.Items.Insert(0, new ListItem("--Select--", ""));
        }
        DataSet hrGrade = Common.GetHRGrade();
        if (hrGrade.Tables[0].Rows.Count > 0)
        {
            ddlGradeFrom.DataSource = hrGrade;
            ddlGradeFrom.DataTextField = "HRGrade_Description";
            ddlGradeFrom.DataValueField = "HRGrade_ID";
            ddlGradeFrom.DataBind();
            ddlGradeFrom.Items.Insert(0, new ListItem("--Select--", ""));
            ddlGradeTo.DataSource = hrGrade;
            ddlGradeTo.DataTextField = "HRGrade_Description";
            ddlGradeTo.DataValueField = "HRGrade_ID";
            ddlGradeTo.DataBind();
            ddlGradeTo.Items.Insert(0, new ListItem("--Select--", ""));
        }
        DataSet test = Common.GetTest();
        if (test.Tables[0].Rows.Count > 0)
        {
            lbTest.DataSource = test;
            lbTest.DataTextField = "TestName";
            lbTest.DataValueField = "TestCode";
            lbTest.DataBind();
        }
        DataSet bonusType = Common.GetBonusType();
        if (bonusType == null)
            return;
        if (bonusType.Tables[0].Rows.Count > 0)
        {
            ddlBonusType.DataSource = bonusType.Tables[0];
            ddlBonusType.DataTextField = "BonusTypeName";
            ddlBonusType.DataValueField = "BonusTypeCode";
            ddlBonusType.DataBind();
            ddlBonusType.Items.Insert(0, new ListItem("N/A", "0"));
        }
        if (bonusType.Tables.Count >= 2 && bonusType.Tables[1].Rows.Count > 0)
        {
            ddlCatUserType.DataSource = bonusType.Tables[1];
            ddlCatUserType.DataTextField = "name";
            ddlCatUserType.DataValueField = "code";
            ddlCatUserType.DataBind();
        }
        ddlCatUserType.Items.Insert(0, new ListItem("Select Category User type", "0"));
        DataSet positionType = Common.GetPositionType();
        if (positionType == null || positionType.Tables[0].Rows.Count <= 0)
            return;
        ddlPositionType.DataSource = positionType.Tables[0];
        ddlPositionType.DataTextField = "PositionTypeName";
        ddlPositionType.DataValueField = "PositionTypeCode";
        ddlPositionType.DataBind();
        ddlPositionType.Items.Insert(0, new ListItem("--Select--", "-1"));
    }

    private void PerformanceJobRole()
    {
        DataSet jobRole = Common.GetJobRole();
        if (jobRole.Tables[0].Rows.Count <= 0)
            return;
        ddlJobRole.DataSource = jobRole.Tables[0];
        ddlJobRole.DataTextField = "JobRole";
        ddlJobRole.DataValueField = "JobRoleCode";
        ddlJobRole.DataBind();
        ddlJobRole.Items.Insert(0, new ListItem("--Select--", "-1"));
    }

    protected void ddlCatUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCatUserType.SelectedValue == "5")
        {
            JobRole.Visible = true;
            FillDomainDDL(1);
        }
        else
        {
            JobRole.Visible = false;
            FillDomainDDL(0);
        }
    }

    private string InsertCategory()
    {
        string TestCodeCSV = string.Empty;
        foreach (ListItem listItem in lbTest.Items)
        {
            if (listItem.Selected)
                TestCodeCSV = TestCodeCSV + listItem.Value + ",";
        }
        if (TestCodeCSV != string.Empty)
            TestCodeCSV = TestCodeCSV.Substring(0, TestCodeCSV.Length - 1);
        string SampleTestPath = UploadFile(txtCategoryName.Text);
        return AdminClass.UpdateInsertCategory(txtCategoryName.Text, Convert.ToInt32(ddlSubDomain.SelectedValue), Convert.ToInt32(ddlProfile.SelectedValue), txtCategoryTitle.Text, Convert.ToInt32(ddlGradeFrom.SelectedValue), Convert.ToInt32(ddlGradeTo.SelectedValue), txtJobDesc.Text.Trim(), Convert.ToInt32(ddlBonusType.SelectedValue), Convert.ToInt32(ddlBonusType.SelectedValue), txtBonusFarmula.Text.Trim(), txtTPC.Text.Trim(), txtFP.Text.Trim(), txtUP.Text.Trim(), txtNr.Text.Trim(), txtPrefix.Text.Trim(), chkTest.Checked, chkcertified.Checked, chkIsBike.Checked, Convert.ToInt32(ddlPositionType.SelectedValue), txtTestDuration.Text, TestCodeCSV, txtInterviewDuration.Text, USERIP, UserCode, Convert.ToInt32(hdnCategoryCode.Value), Convert.ToInt32(ddlCatUserType.SelectedValue), Convert.ToInt32(ddlJobRole.SelectedValue), SampleTestPath);
    }

    protected void chkTest_CheckedChanged(object sender, EventArgs e)
    {
        if (chkTest.Checked)
        {
            trTestDuration.Visible = true;
            trTest.Visible = true;
            trSampleTest.Visible = true;
        }
        else
        {
            trTestDuration.Visible = false;
            trTest.Visible = false;
            trSampleTest.Visible = false;
        }
    }

    protected string UploadFile(string CategoryName)
    {
        try
        {
            if (fuSampleTest.HasFile)
            {
                string FolderPath = ConfigurationManager.AppSettings["CategoryDocumentsPath"].ToString() + "/";
                GeneralMethods.FileBrowse(fuSampleTest, FolderPath, "SampleTest");
                return FolderPath + "SampleTest" + Path.GetExtension(fuSampleTest.FileName);
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        return "";
    }
    #endregion
}