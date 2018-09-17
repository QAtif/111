using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using XRecruitmentStatusLibrary;
using ErrorLog;
using System.IO;

public partial class Admin_CheckTest : CustomBasePage
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    int candidateCode;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["cid"] != null && Request["cid"].ToString() != string.Empty)
            candidateCode = int.Parse(Request["cid"].ToString());
        if (IsPostBack)
            return;
        BindData();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            SaveTest();
            if (ddlTestResult.SelectedValue == "1")
                UpdateCommunication(candidateCode, "Test Passed");
            else
                UpdateCommunication(candidateCode, "Test Faild");
            if (ddlTestResult.SelectedValue == "1")
                StatusManagement.MarkLifeCycleStatus(connection, candidateCode, Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.TestPassedSchedulingPendingInterview, Request.UserHostAddress.ToString(), UserCode);
            else
                StatusManagement.MarkLifeCycleStatus(connection, candidateCode, Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.TestFailedReSchedulingPendingTest, Request.UserHostAddress.ToString(), UserCode);
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "alert('Result Saved Successfully!');", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            connection.Close();
        }
    }

    private void UpdateCommunication(int Candidate_Code, string Comments)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_Insert_CheckTestComments", connection);
        sqlCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_Code);
        sqlCommand.Parameters.AddWithValue("@Comments", Comments);
        sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
        sqlCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.ExecuteNonQuery();
    }

    protected void SaveTest()
    {
        foreach (RepeaterItem repeaterItem1 in rptSection.Items)
        {
            HiddenField control1 = (HiddenField)repeaterItem1.FindControl("hdfCandidateTestSectionCode");
            Repeater control2 = (Repeater)repeaterItem1.FindControl("rptQuestions");
            foreach (RepeaterItem repeaterItem2 in control2.Items)
                MarkQuestionResult(((HiddenField)repeaterItem2.FindControl("hdfCandidateTestDetailCode")).Value, ((ListControl)repeaterItem2.FindControl("ddlQuestionResult")).SelectedValue);
            TextBox control3 = (TextBox)control2.Controls[control2.Controls.Count - 1].Controls[0].FindControl("txtSectionMarks");
            TextBox control4 = (TextBox)control2.Controls[control2.Controls.Count - 1].Controls[0].FindControl("txtSectionComments");
            DropDownList control5 = (DropDownList)control2.Controls[control2.Controls.Count - 1].Controls[0].FindControl("ddlSectionResult");
            MarkSectionResult(control1.Value, control3.Text, control4.Text, control5.SelectedValue);
        }
        MarkTestResult(hdfCandidateTestCode.Value, ddlTestResult.SelectedValue);
    }

    private void MarkSectionResult(string CandidateTestSectionCode, string marks, string comments, string isPass)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Update_CandidateTestSectionResult", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@CandidateTestSectionCode", CandidateTestSectionCode);
        sqlCommand.Parameters.AddWithValue("@Marks", marks);
        sqlCommand.Parameters.AddWithValue("@IsPass", isPass);
        sqlCommand.Parameters.AddWithValue("@Comments", comments);
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        sqlCommand.ExecuteNonQuery();
    }

    private void MarkQuestionResult(string CandidateTestDetailCode, string IsCorrect)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Update_CandidateTestQuestionResult", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@CandidateTestDetailCode", CandidateTestDetailCode);
        sqlCommand.Parameters.AddWithValue("@IsCorrect", IsCorrect);
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        sqlCommand.ExecuteNonQuery();
    }

    private void MarkTestResult(string CandidateTestDetailCode, string IsPass)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Update_CandidateTestResult", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@CandidateTestCode", CandidateTestDetailCode);
        sqlCommand.Parameters.AddWithValue("@IsPass", IsPass);
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        sqlCommand.ExecuteNonQuery();
    }

    private void MarkRATestResult(string CandidateTestDetailCode, string Plagiarism, string grammer, string compliance, string RAComments, string IsPass)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Update_CandidateTestResultByRA", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@CandidateTestCode", CandidateTestDetailCode);
        sqlCommand.Parameters.AddWithValue("@Plagiarism", Plagiarism);
        sqlCommand.Parameters.AddWithValue("@grammer", grammer);
        sqlCommand.Parameters.AddWithValue("@compliance", compliance);
        sqlCommand.Parameters.AddWithValue("@RAComments", RAComments);
        sqlCommand.Parameters.AddWithValue("@IsPass", IsPass);
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        sqlCommand.ExecuteNonQuery();
    }

    private void MarkRECTestResult(string CandidateTestDetailCode, string RECComments, string IsPass)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Update_CandidateTestResultByREC", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@CandidateTestCode", CandidateTestDetailCode);
        sqlCommand.Parameters.AddWithValue("@RECComments", RECComments);
        sqlCommand.Parameters.AddWithValue("@IsPass", IsPass);
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        sqlCommand.ExecuteNonQuery();
    }

    private void MarkDomianOwnerTestResult(string CandidateTestDetailCode, string DomainOwnerComments, string IsPass)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Update_CandidateTestResultByDomainOwner", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@CandidateTestCode", CandidateTestDetailCode);
        sqlCommand.Parameters.AddWithValue("@DomainOwnerComments", DomainOwnerComments);
        sqlCommand.Parameters.AddWithValue("@IsPass", IsPass);
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        sqlCommand.ExecuteNonQuery();
    }

    protected void rptSection_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        string str = DataBinder.Eval(e.Item.DataItem, "QuestionGroupCode").ToString();
        DataView dataView = new DataView(ds.Tables[2], "SectionCode=" + DataBinder.Eval(e.Item.DataItem, "SectionCode").ToString() + " and QuestionGroupCode=" + str, (string)null, DataViewRowState.CurrentRows);
        Repeater control = (Repeater)e.Item.FindControl("rptQuestions");
        control.DataSource = dataView;
        control.DataBind();
        ((HtmlControl)e.Item.FindControl("trHeading")).Attributes.Add("onclick", "ToggleRecord('" + e.Item.FindControl("trDetail").ClientID + "');");
    }

    protected void rptQuestionGroup_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        string str1 = DataBinder.Eval(e.Item.DataItem, "QuestionGroupCode").ToString();
        string str2 = DataBinder.Eval(e.Item.DataItem, "SectionCode").ToString();
        Label control1 = (Label)e.Item.FindControl("lblCorrect");
        Label control2 = (Label)e.Item.FindControl("lblWrong");
        Label control3 = (Label)e.Item.FindControl("lblTotal");
        HtmlAnchor control4 = (HtmlAnchor)e.Item.FindControl("lnkTotal");
        int num1 = int.Parse(DataBinder.Eval(e.Item.DataItem, "CandidateCode").ToString());
        int num2 = int.Parse(DataBinder.Eval(e.Item.DataItem, "TestCode").ToString());
        Label control5 = (Label)e.Item.FindControl("lblPending");
        ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
        if (ds.Tables[3].Rows.Count <= 0)
            return;
        int length1 = ds.Tables[3].Select("SectionCode=" + str2 + " and QuestionGroupCode=" + str1 + " and IsCorrect=1").Length;
        int length2 = ds.Tables[3].Select("SectionCode=" + str2 + " and QuestionGroupCode=" + str1 + " and IsCorrect=0").Length;
        int length3 = ds.Tables[3].Select("SectionCode=" + str2 + " and QuestionGroupCode=" + str1).Length;
        int length4 = ds.Tables[3].Select("SectionCode=" + str2 + " and QuestionGroupCode=" + str1 + " and IsCorrect is null").Length;
        control1.Text = length1.ToString();
        control2.Text = length2.ToString();
        control3.Text = length3.ToString();
        control5.Text = length4.ToString();
        control4.HRef = "CandidateTestResult.aspx?tid=" + num2 + "&cid=" + num1 + "&sid=" + str2 + "&qgid=" + str1;
    }

    public void BindData()
    {
        string empty = string.Empty;
        int num = 0;
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XREC_Select_CandidateTestDetails", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@CandidateCode", candidateCode);
            new SqlDataAdapter(selectCommand).Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblCorrect.Text = ds.Tables[0].Rows[0]["Correct"].ToString();
                lblWrong.Text = ds.Tables[0].Rows[0]["Wrong"].ToString();
                lblTotal.Text = ds.Tables[0].Rows[0]["TotalQuestion"].ToString();
                lblPending.Text = ds.Tables[0].Rows[0]["ResultPending"].ToString();
                num = int.Parse(ds.Tables[0].Rows[0]["DomainCode"].ToString());
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                rptQuestionGroup.DataSource = ds.Tables[1];
                rptQuestionGroup.DataBind();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                rptSection.DataSource = ds.Tables[1];
                rptSection.DataBind();
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                rptFile.DataSource = ds.Tables[5];
                rptFile.DataBind();
                tblQA.Style["display"] = "";
            }
            else
                tblQA.Style["display"] = "none";
            if (ds.Tables[4].Rows.Count > 0)
            {
                hdfCandidateTestCode.Value = ds.Tables[4].Rows[0]["CandidateTestCode"].ToString();
                lblCandStatus.Text = ds.Tables[4].Rows[0]["Status_Name"].ToString();
                lblName.Text = ds.Tables[4].Rows[0]["Name"].ToString();
                lblReferenceNo.Text = ds.Tables[4].Rows[0]["RefNo"].ToString();
                lblEmailAddress.Text = ds.Tables[4].Rows[0]["Email_Address"].ToString();
                lblCategory.Text = ds.Tables[4].Rows[0]["Category_Name"].ToString();
                lblSubDomain.Text = ds.Tables[4].Rows[0]["SubDomain_Name"].ToString();
                if (ds.Tables[4].Rows[0]["Status_Code"].ToString() == "1100")
                    tblTest.Style["display"] = "";
                else
                    tblTest.Style["display"] = "none";
            }
            if (num == 9)
            {
                if (ds.Tables[6].Rows.Count > 0)
                {
                    tblComments.Style["display"] = "";
                    trRA.Style["display"] = "";
                    lblRA.Text = ds.Tables[6].Rows[0]["User"].ToString();
                    lblRAStatus.Text = ds.Tables[6].Rows[0]["IsPassByRA"].ToString();
                    ltrRAComments.Text = ds.Tables[6].Rows[0]["CommentsByRA"].ToString();
                    lblPlagiarism.Text = ds.Tables[6].Rows[0]["PlagiarismRatio"].ToString();
                    lblGrammer.Text = ds.Tables[6].Rows[0]["Grammer"].ToString();
                    lblCompliance.Text = ds.Tables[6].Rows[0]["Compliance"].ToString();
                }
                if (ds.Tables[7].Rows.Count > 0)
                {
                    tblComments.Style["display"] = "";
                    trRec.Style["display"] = "";
                    lblRec.Text = ds.Tables[7].Rows[0]["User"].ToString();
                    lblRECStatus.Text = ds.Tables[7].Rows[0]["IsPassByRECR"].ToString();
                    ltrRECComments.Text = ds.Tables[7].Rows[0]["commentsbyRec"].ToString();
                }
                if (ds.Tables[8].Rows.Count > 0)
                {
                    tblComments.Style["display"] = "";
                    trDomainOwner.Style["display"] = "";
                    lblDomainOwner.Text = ds.Tables[8].Rows[0]["User"].ToString();
                    lblDomainOwnerStatus.Text = ds.Tables[8].Rows[0]["IsPassByDomainOwner"].ToString();
                    ltrDomainOWnerComments.Text = ds.Tables[8].Rows[0]["commentsbyDomainOwner"].ToString();
                }
                CheckUserType();
            }
            ShowHideActions();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    private void ShowHideActions()
    {
        IEnumerable<HtmlGenericControl> allControlsOfType = Page.GetAllControlsOfType<HtmlGenericControl>();
        foreach (DataRow row in (InternalDataCollectionBase)DTActions.Rows)
        {
            foreach (Control control in allControlsOfType)
            {
                if (control.ClientID == "divAction" + row["MenuLinkActionCode"].ToString())
                    control.Visible = true;
            }
        }
    }

    private void CheckUserType()
    {
        DataTable dataTable = new DataTable();
        SqlCommand selectCommand = new SqlCommand("XREC_Select_UserType", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.AddWithValue("@UserCode", UserCode);
        new SqlDataAdapter(selectCommand).Fill(dataTable);
        if (dataTable.Rows.Count <= 0)
            return;
        if (Convert.ToBoolean(dataTable.Rows[0]["Is_ReportingAuthority"].ToString()))
            tblContentRA.Style["display"] = "";
        if (dataTable.Rows[0]["UserTypeCode"].ToString() == "9")
            tblContentDomainOwner.Style["display"] = "";
        if (!(dataTable.Rows[0]["UserTypeCode"].ToString() == "3") && !(dataTable.Rows[0]["UserTypeCode"].ToString() == "4") && (!(dataTable.Rows[0]["UserTypeCode"].ToString() == "5") && !(dataTable.Rows[0]["UserTypeCode"].ToString() == "6")) && (!(dataTable.Rows[0]["UserTypeCode"].ToString() == "7") && !(dataTable.Rows[0]["UserTypeCode"].ToString() == "8")))
            return;
        tblContentREC.Style["display"] = "";
    }

    protected void rptFile_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        HtmlAnchor control = (HtmlAnchor)e.Item.FindControl("lnkFile");
        control.HRef = DataBinder.Eval(e.Item.DataItem, "Recording_Path").ToString();
        control.InnerText = Path.GetFileName(DataBinder.Eval(e.Item.DataItem, "Recording_Path").ToString());
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            MarkRATestResult(hdfCandidateTestCode.Value, txtPlagiarism.Text, ddlGrammer.SelectedValue, ddlCompliance.SelectedValue, txtRAComments.Text, ddlRATestResult.SelectedValue);
            txtPlagiarism.Text = string.Empty;
            txtRAComments.Text = string.Empty;
            ddlGrammer.SelectedValue = "A";
            ddlCompliance.SelectedValue = "A";
            tblContentRA.Style["display"] = "none";
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "alert('Result Saved Successfully!');", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            connection.Close();
        }
    }

    protected void btnRec_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            MarkRECTestResult(hdfCandidateTestCode.Value, txtRECComments.Text, ddlRECTestResult.SelectedValue);
            txtRECComments.Text = string.Empty;
            tblContentREC.Style["display"] = "none";
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "alert('Result Saved Successfully!');", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            connection.Close();
        }
    }

    protected void btnDomainOwner_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            MarkDomianOwnerTestResult(hdfCandidateTestCode.Value, txtDomainOwnerComments.Text, ddlDomainOwnerTestResult.SelectedValue);
            txtDomainOwnerComments.Text = string.Empty;
            tblContentDomainOwner.Style["display"] = "none";
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "alert('Result Saved Successfully!');", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            connection.Close();
        }
    }

    protected void rptQuestions_CommandArguments(object sender, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "SaveFile"))
            return;
        FileUpload control = (FileUpload)e.Item.FindControl("fuDocument");
        string str = string.Empty;
        if (control.HasFile)
        {
            str = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + candidateCode + "/CandidateTest/" + ("RES_" + e.CommandArgument.ToString() + Path.GetExtension(control.FileName));
            if (!Directory.Exists(Server.MapPath(ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + candidateCode + "/CandidateTest/")))
                Directory.CreateDirectory(Server.MapPath(ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + candidateCode + "/CandidateTest/"));
            GeneralMethods.FileBrowse(control, ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + candidateCode + "/CandidateTest/", Path.GetFileNameWithoutExtension(str));
        }
        InsertAnswers(ref connection, int.Parse(e.CommandArgument.ToString()), str);
        ScriptManager.RegisterStartupScript((Page)this, GetType(), "exists", "alert('Saved Successfully!.');", true);
        BindData();
    }

    protected void InsertAnswers(ref SqlConnection connection, int CandidateTestDetailCode, string filePath)
    {
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XREC_Update_CandidateTestAnswersSubmittedFile", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@CandidateTestDetailCode", CandidateTestDetailCode);
            sqlCommand.Parameters.AddWithValue("@FileBrowse", filePath);
            sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
            sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            connection.Close();
        }
    }


}