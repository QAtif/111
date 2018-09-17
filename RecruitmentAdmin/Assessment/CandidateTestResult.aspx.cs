using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using ErrorLog;

public partial class CandidateTestResult : CustomBasePage
{
    int TestCode = 0;
    int CandidateCode = 0;
    int SectionCode = 0;
    int QuestionGroupCode = 0;

    DataView dvQuestions = new DataView();
    DataTable dtQuestions = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["tid"] != null && Request.QueryString["tid"].ToString() != string.Empty && (Request.QueryString["cid"] != null && Request.QueryString["cid"].ToString() != string.Empty) && (Request.QueryString["sid"] != null && Request.QueryString["sid"].ToString() != string.Empty && (Request.QueryString["qgid"] != null && Request.QueryString["qgid"].ToString() != string.Empty)))
        {
            TestCode = Convert.ToInt32(Request.QueryString["tid"].ToString());
            CandidateCode = Convert.ToInt32(Request.QueryString["cid"].ToString());
            SectionCode = Convert.ToInt32(Request.QueryString["sid"].ToString());
            QuestionGroupCode = Convert.ToInt32(Request.QueryString["qgid"].ToString());
        }
        else
            Response.End();
        if (IsPostBack)
            return;
        BindData();
    }

    public void BindData()
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
        string empty = string.Empty;
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XREC_Select_CandidateTestAnswers", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@TestCode", TestCode);
            selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
            selectCommand.Parameters.AddWithValue("@SectionCode", SectionCode);
            selectCommand.Parameters.AddWithValue("@QuestionGroupCode", QuestionGroupCode);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count <= 0)
                return;
            dtQuestions = dataSet.Tables[0];
            rptQuestion.DataSource = dtQuestions;
            rptQuestion.DataBind();
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
        if (DataBinder.Eval(e.Item.DataItem, "IsCorrect").ToString() == string.Empty)
            control2.Src = "/assets/images/icons/Pending1.jpg";
        if (DataBinder.Eval(e.Item.DataItem, "QuestionOptionCode").ToString() == "0")
        {
            if (DataBinder.Eval(e.Item.DataItem, "QuestionAnswer").ToString() != string.Empty)
                control1.Text = DataBinder.Eval(e.Item.DataItem, "QuestionAnswer").ToString();
            else
                control1.Text = "<a href=" + DataBinder.Eval(e.Item.DataItem, "FileAttachment").ToString() + ">" + DataBinder.Eval(e.Item.DataItem, "FileAttachment").ToString() + "</a>";
        }
        else
            control1.Text = DataBinder.Eval(e.Item.DataItem, "QuestionOptionDesc").ToString();
    }
}