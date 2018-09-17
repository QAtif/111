using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using XRecruitmentStatusLibrary;

public partial class Admin_CheckTest : XRecBase
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);
    int candidateCode;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["cid"] != null && Request["cid"].ToString() != string.Empty)
            candidateCode = int.Parse(Request["cid"].ToString());

        if (!IsPostBack)
        {
            BindData();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();

            SaveTest();
            #region Status Marking

            if (ddlTestResult.SelectedValue == "1")
                StatusManagement.MarkLifeCycleStatus(connection, candidateCode, Constants.ModuleCode.LifeCycleStatus,
                                     Constants.CandidateLifeCycleStatus.TestPassedSchedulingPendingInterview, Request.UserHostAddress.ToString(), UserID);
            else
                StatusManagement.MarkLifeCycleStatus(connection, candidateCode, Constants.ModuleCode.LifeCycleStatus,
                                 Constants.CandidateLifeCycleStatus.TestFailedReSchedulingPendingTest, Request.UserHostAddress.ToString(), UserID);
            #endregion


            ScriptManager.RegisterStartupScript(this, GetType(), "pass", "alert('Result Saved Successfully!');", true);
        }
        catch (Exception ex)
        {
            //throw exp1;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.Candidate, ex.StackTrace, ex, UserID.ToString());
        }
        finally
        {
            connection.Close();
        }
    }
    protected void SaveTest()
    {
        foreach (RepeaterItem rptItem in rptSection.Items)
        {
            HiddenField hdfCandidateTestSectionCode = (HiddenField)rptItem.FindControl("hdfCandidateTestSectionCode");

            Repeater rptQuestions = (Repeater)rptItem.FindControl("rptQuestions");
            foreach (RepeaterItem rptAnswerItem in rptQuestions.Items)
            {
                HiddenField hdfCandidateTestDetailCode = (HiddenField)rptAnswerItem.FindControl("hdfCandidateTestDetailCode");
                DropDownList ddlQuestionResult = (DropDownList)rptAnswerItem.FindControl("ddlQuestionResult");
                MarkQuestionResult(hdfCandidateTestDetailCode.Value, ddlQuestionResult.SelectedValue);

            }
            TextBox txtSectionMarks = (TextBox)rptQuestions.Controls[rptQuestions.Controls.Count - 1].Controls[0].FindControl("txtSectionMarks");
            TextBox txtSectionComments = (TextBox)rptQuestions.Controls[rptQuestions.Controls.Count - 1].Controls[0].FindControl("txtSectionComments");
            DropDownList ddlSectionResult = (DropDownList)rptQuestions.Controls[rptQuestions.Controls.Count - 1].Controls[0].FindControl("ddlSectionResult");
            MarkSectionResult(hdfCandidateTestSectionCode.Value, txtSectionMarks.Text, txtSectionComments.Text, ddlSectionResult.SelectedValue);
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
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        sqlCommand.ExecuteNonQuery();
    }
    private void MarkQuestionResult(string CandidateTestDetailCode, string IsCorrect)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Update_CandidateTestQuestionResult", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@CandidateTestDetailCode", CandidateTestDetailCode);
        sqlCommand.Parameters.AddWithValue("@IsCorrect", IsCorrect);
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        sqlCommand.ExecuteNonQuery();
    }
    private void MarkTestResult(string CandidateTestDetailCode, string IsPass)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Update_CandidateTestResult", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@CandidateTestCode", CandidateTestDetailCode);
        sqlCommand.Parameters.AddWithValue("@IsPass", IsPass);
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        sqlCommand.ExecuteNonQuery();
    }
    protected void rptSection_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string QuestionGroupCode = DataBinder.Eval(e.Item.DataItem, "QuestionGroupCode").ToString();
            string SectionCode = DataBinder.Eval(e.Item.DataItem, "SectionCode").ToString();
            //Label lblCorrect = (Label)e.Item.FindControl("lblCorrect");
            //Label lblWrong = (Label)e.Item.FindControl("lblWrong");
            //Label lblTotal = (Label)e.Item.FindControl("lblTotal");
            //Label lblPending = (Label)e.Item.FindControl("lblPending");


            DataView dvQuestions = new DataView(ds.Tables[2], "SectionCode=" + SectionCode + " and QuestionGroupCode=" + QuestionGroupCode, null, DataViewRowState.CurrentRows);

            Repeater rptQuestions = (Repeater)e.Item.FindControl("rptQuestions");
            rptQuestions.DataSource = dvQuestions;
            rptQuestions.DataBind();

            HtmlTableRow trHeading = (HtmlTableRow)e.Item.FindControl("trHeading");
            HtmlTableRow trDetail = (HtmlTableRow)e.Item.FindControl("trDetail");

            trHeading.Attributes.Add("onclick", "ToggleRecord('" + trDetail.ClientID + "');");

            //if (ds.Tables[3].Rows.Count > 0)
            //{
            //    int correct = ds.Tables[3].Select("SectionCode=" + SectionCode + " and QuestionGroupCode=" + QuestionGroupCode + " and IsCorrect=1").Length;
            //    int wrong = ds.Tables[3].Select("SectionCode=" + SectionCode + " and QuestionGroupCode=" + QuestionGroupCode + " and IsCorrect=0").Length;
            //    int total = ds.Tables[3].Select("SectionCode=" + SectionCode + " and QuestionGroupCode=" + QuestionGroupCode).Length;
            //    int pending = ds.Tables[3].Select("SectionCode=" + SectionCode + " and QuestionGroupCode=" + QuestionGroupCode + " and IsCorrect is null").Length;

            //    lblCorrect.Text = correct.ToString();
            //    lblWrong.Text = wrong.ToString();
            //    lblTotal.Text = total.ToString();
            //    lblPending.Text = pending.ToString();
            //}

        }
    }
    protected void rptQuestionGroup_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string QuestionGroupCode = DataBinder.Eval(e.Item.DataItem, "QuestionGroupCode").ToString();
            string SectionCode = DataBinder.Eval(e.Item.DataItem, "SectionCode").ToString();
            Label lblCorrect = (Label)e.Item.FindControl("lblCorrect");
            Label lblWrong = (Label)e.Item.FindControl("lblWrong");
            Label lblTotal = (Label)e.Item.FindControl("lblTotal");

            HtmlAnchor lnkTotal = (HtmlAnchor)e.Item.FindControl("lnkTotal");
            int candidateCode = int.Parse(DataBinder.Eval(e.Item.DataItem, "CandidateCode").ToString());
            int TestCode = int.Parse(DataBinder.Eval(e.Item.DataItem, "TestCode").ToString());


            Label lblPending = (Label)e.Item.FindControl("lblPending");
            Label lblSno = (Label)e.Item.FindControl("lblSno");
            lblSno.Text = Convert.ToString((e.Item.ItemIndex + 1));

            if (ds.Tables[3].Rows.Count > 0)
            {
                int correct = ds.Tables[3].Select("SectionCode=" + SectionCode + " and QuestionGroupCode=" + QuestionGroupCode + " and IsCorrect=1").Length;
                int wrong = ds.Tables[3].Select("SectionCode=" + SectionCode + " and QuestionGroupCode=" + QuestionGroupCode + " and IsCorrect=0").Length;
                int total = ds.Tables[3].Select("SectionCode=" + SectionCode + " and QuestionGroupCode=" + QuestionGroupCode).Length;
                int pending = ds.Tables[3].Select("SectionCode=" + SectionCode + " and QuestionGroupCode=" + QuestionGroupCode + " and IsCorrect is null").Length;

                lblCorrect.Text = correct.ToString();
                lblWrong.Text = wrong.ToString();
                lblTotal.Text = total.ToString();
                lblPending.Text = pending.ToString();


                lnkTotal.HRef = "CandidateTestResult.aspx?tid=" + TestCode + "&cid=" + candidateCode;
            }
        }
    }
    public void BindData()
    {
        string strSQL = string.Empty;

        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand("XREC_Select_CandidateTestDetails", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@CandidateCode", candidateCode);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblCorrect.Text = ds.Tables[0].Rows[0]["Correct"].ToString();
                lblWrong.Text = ds.Tables[0].Rows[0]["Wrong"].ToString();
                lblTotal.Text = ds.Tables[0].Rows[0]["TotalQuestion"].ToString();
                lblPending.Text = ds.Tables[0].Rows[0]["ResultPending"].ToString();
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
            if (ds.Tables[4].Rows.Count > 0)
            {
                hdfCandidateTestCode.Value = ds.Tables[4].Rows[0]["CandidateTestCode"].ToString();
                lblCandStatus.Text = ds.Tables[4].Rows[0]["Status_Name"].ToString();
                
                if (ds.Tables[4].Rows[0]["Status_Name"].ToString() == "1100")
                    tblTest.Style["display"] = "";
                else
                    tblTest.Style["display"] = "none";
            }


        }
        catch (Exception ex)
        {
            //throw exp1;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.Candidate, ex.StackTrace, ex, UserID.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

    }
}