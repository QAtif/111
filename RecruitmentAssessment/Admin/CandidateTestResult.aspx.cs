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

public partial class CandidateTestResult : XRecBase
{
    int TestCode = 0;
    int CandidateCode = 0;


    DataView dvQuestions = new DataView();
    DataTable dtQuestions = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {

        if ((Request.QueryString["tid"] != null && Request.QueryString["tid"].ToString() != string.Empty) &&
            (Request.QueryString["cid"] != null && Request.QueryString["cid"].ToString() != string.Empty))
        {
            TestCode = Convert.ToInt32(Request.QueryString["tid"].ToString());
            CandidateCode = Convert.ToInt32(Request.QueryString["cid"].ToString());
        }
        else
            Response.End();
        if (!IsPostBack)
        {
            BindData();
        }
    }
    public void BindData()
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);
        string strSQL = string.Empty;

        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand("XREC_Select_CandidateTestAnswers", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@TestCode", TestCode);
            sqlCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            /*
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblCorrect.Text = ds.Tables[0].Rows[0]["Correct"].ToString();
                lblWrong.Text = ds.Tables[0].Rows[0]["Wrong"].ToString();
                lblTotal.Text = ds.Tables[0].Rows[0]["TotalQuestion"].ToString();
            }
            */

            if (ds.Tables[0].Rows.Count > 0)
            {
                dtQuestions = ds.Tables[0];
                rptQuestion.DataSource = dtQuestions;
                rptQuestion.DataBind();
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
    protected void rptQuestion_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HiddenField hdnQuestionCode = (HiddenField)e.Item.FindControl("hdnQuestionCode");
            Repeater rptOptions = (Repeater)e.Item.FindControl("rptOptions");

            dvQuestions = new DataView(dtQuestions, "QuestionCode=" + hdnQuestionCode.Value, null, DataViewRowState.CurrentRows);

            rptOptions.DataSource = dvQuestions;
            rptOptions.DataBind();
        }
    }
    protected void rptOptions_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal ltrAnswer = (Literal)e.Item.FindControl("ltrAnswer");
            HtmlImage imgStatus = (HtmlImage)e.Item.FindControl("imgStatus");
            if (DataBinder.Eval(e.Item.DataItem, "IsCorrect").ToString() == "False")
            {
                imgStatus.Src = "/assets/images/icons/failure.png";
            }
            if (DataBinder.Eval(e.Item.DataItem, "IsCorrect").ToString() == string.Empty)
            {
                imgStatus.Src = "/assets/images/icons/Pending1.jpg";
            }

            if (DataBinder.Eval(e.Item.DataItem, "QuestionOptionCode").ToString() == "0")
                if (DataBinder.Eval(e.Item.DataItem, "QuestionAnswer").ToString() != string.Empty)
                    ltrAnswer.Text = DataBinder.Eval(e.Item.DataItem, "QuestionAnswer").ToString();
                else
                {
                    ltrAnswer.Text = "<a href=" + DataBinder.Eval(e.Item.DataItem, "FileAttachment").ToString() + ">" 
                        + DataBinder.Eval(e.Item.DataItem, "FileAttachment").ToString() + "</a>";
                }
            else
                ltrAnswer.Text = DataBinder.Eval(e.Item.DataItem, "QuestionOptionDesc").ToString();
            /*
            HiddenField hdnQuestionTypeCode = (HiddenField)e.Item.FindControl("hdnQuestionTypeCode");
            HiddenField hdnQuestionCode = (HiddenField)e.Item.FindControl("hdnQuestionCode");
            hdnQuestionTypeCode.Value = DataBinder.Eval(e.Item.DataItem, "QuestionTypeCode").ToString();
            hdnQuestionCode.Value = DataBinder.Eval(e.Item.DataItem, "QuestionCode").ToString();

            if (hdnQuestionTypeCode.Value == "1")//MCQs
            {
                

            }
            if (hdnQuestionTypeCode.Value == "2")//Blank
            {
                
            }
            if (hdnQuestionTypeCode.Value == "3")//Single Choice
            {
                
            }

            */
        }
    }

}