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
using ErrorLog;



public partial class CandidateTestResult : XRecBase
{
    
    DataView dvQuestions = new DataView();
    DataView dvOptions = new DataView();
    DataTable dtOptions = new DataTable();
    DataTable dtQuestions = new DataTable();
    public int TestCode;
    public int sectionCount;
    public int sectionCode;



    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString != null && Request.QueryString["tid"] != null && (Request.QueryString != null && Request.QueryString["tid"] != null))
        {
            if (Request.QueryString["tid"].ToString() != "")
            {
                TestCode = Convert.ToInt32(Request.QueryString["tid"].ToString());
                ViewState["tid"] = Request.QueryString["tid"].ToString();
            }
        }
        else
            TestCode = 0;
        if (IsPostBack)
            return;
        BindData();
    }

    public void BindData()
    {
        if (ViewState["SectionCount"] != null)
            sectionCount = int.Parse(ViewState["SectionCount"].ToString());
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);
        string empty = string.Empty;
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XREC_Select_CandidateTestAnswers", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@TestCode", TestCode);
            selectCommand.Parameters.AddWithValue("@CandidateCode", UserID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                lblCorrect.Text = dataSet.Tables[0].Rows[0]["Correct"].ToString();
                lblWrong.Text = dataSet.Tables[0].Rows[0]["Wrong"].ToString();
                lblTotal.Text = dataSet.Tables[0].Rows[0]["TotalQuestion"].ToString();
            }
            if (dataSet.Tables[1].Rows.Count > 0)
                dtOptions = dataSet.Tables[1];
            if (dataSet.Tables[1].Rows.Count <= 0)
                return;
            dtQuestions = dataSet.Tables[1];
            rptQuestion.DataSource = dtQuestions;
            rptQuestion.DataBind();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.StackTrace, ex, UserID.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    protected void rptQuestion_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        HiddenField control1 = (HiddenField)e.Item.FindControl("hdnQuestionCode");
        Repeater control2 = (Repeater)e.Item.FindControl("rptOptions");
        dvQuestions = new DataView(dtQuestions, "QuestionCode=" + control1.Value, (string)null, DataViewRowState.CurrentRows);
        control2.DataSource = dvQuestions;
        control2.DataBind();
    }

    protected void rptOptions_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        Literal control1 = (Literal)e.Item.FindControl("ltrAnswer");
        HtmlImage control2 = (HtmlImage)e.Item.FindControl("imgStatus");
        if (DataBinder.Eval(e.Item.DataItem, "IsCorrect").ToString() == "False")
            control2.Src = "/assets/images/icons/failure.png";
        if (DataBinder.Eval(e.Item.DataItem, "QuestionOptionCode").ToString() == "0")
            control1.Text = DataBinder.Eval(e.Item.DataItem, "QuestionAnswer").ToString();
        else
            control1.Text = DataBinder.Eval(e.Item.DataItem, "QuestionOptionDesc").ToString();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
    }

    protected void InsertAnswers(ref SqlConnection connection, int sectionCode, int QuestionCode, int QuestionOptionCode, int QuestionTypeCode, string answer, string filePath)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Insert_CandidateTestAnswers", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@TestCode", TestCode);
        sqlCommand.Parameters.AddWithValue("@CandidateCode", UserID);
        sqlCommand.Parameters.AddWithValue("@SectionCode", sectionCode);
        sqlCommand.Parameters.AddWithValue("@QuestionCode", QuestionCode);
        sqlCommand.Parameters.AddWithValue("@QuestionOptionCode", QuestionOptionCode);
        sqlCommand.Parameters.AddWithValue("@QuestionTypeCode", QuestionTypeCode);
        sqlCommand.Parameters.AddWithValue("@QuestionAnswer", answer);
        sqlCommand.Parameters.AddWithValue("@FileBrowse", filePath);
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        sqlCommand.ExecuteNonQuery();
    }

    protected void InsertTest(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XREC_Insert_CandidateTest", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.AddWithValue("@TestCode", TestCode);
        selectCommand.Parameters.AddWithValue("@CandidateCode", UserID);
        if (ViewState["CandidateTestCode"] == null)
            selectCommand.Parameters.AddWithValue("@CandidateTestCode", 0);
        else if (ViewState["CandidateTestCode"] != null)
            selectCommand.Parameters.AddWithValue("@CandidateTestCode", Convert.ToInt32(ViewState["CandidateTestCode"].ToString()));
        selectCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
        selectCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        ViewState["CandidateTestCode"] = dataSet.Tables[0].Rows[0]["CandidateTestCode"].ToString();
    }

    protected void InsertTestSection(ref SqlConnection connection, int sectionCode)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Insert_CandidateTestSection", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@TestCode", TestCode);
        sqlCommand.Parameters.AddWithValue("@CandidateCode", UserID);
        sqlCommand.Parameters.AddWithValue("@SectionCode", sectionCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        sqlCommand.ExecuteNonQuery();
    }








}