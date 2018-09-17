using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using XRecruitmentStatusLibrary;
using ErrorLog;
using System.Collections.Generic;
using System.IO;
using ZNet.Controls;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;




public partial class CandidateTest : XRecBase
{
    int TestCode = 3;
    int sectionCode = 0;
    int sectionCount = 0;
    int questionGroupCode = 0;
    public int TimmerCount = 0;
    bool pageIsPostBack = false;
    DataView dvQuestions = new DataView();
    DataView dvOptions = new DataView();

    DataTable dtOptions = new DataTable();
    DataTable dtQuestions = new DataTable();


    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            if (Request.QueryString != null && Request.QueryString["tid"] != null && Request.QueryString["tid"] != string.Empty)
            {
                if (Request.QueryString["tid"].ToString() != "")
                {
                    TestCode = Convert.ToInt32(Request.QueryString["tid"].ToString());
                    ViewState["tid"] = Request.QueryString["tid"].ToString();
                }
            }
            else
                TestCode = 3;
            if (IsPostBack)
            {
                return;
            }

            BindData();


        }
        catch (Exception ex)
        {
            //throw exp1;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAssessment, ex.StackTrace, ex, UserID.ToString());
        }
        

    }

    public void BindData()
    {
        if (ViewState["SectionCount"] != null)
            sectionCount = int.Parse(ViewState["SectionCount"].ToString());
        if (ViewState["questionGroupCode"] != null)
            questionGroupCode = int.Parse(ViewState["questionGroupCode"].ToString());
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);
        string empty = string.Empty;
        try
        {
            connection.Open();
            SqlCommand selectCommand1 = new SqlCommand("XREC_Select_CandidateTest", connection);
            selectCommand1.CommandType = CommandType.StoredProcedure;
            selectCommand1.Parameters.AddWithValue("@TestCode", TestCode);
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(selectCommand1);
            DataSet dataSet = new DataSet();
            sqlDataAdapter1.Fill(dataSet);
            if (dataSet.Tables[1].Rows.Count > 0)
                dtOptions = dataSet.Tables[1];
            SqlCommand selectCommand2 = new SqlCommand("XREC_Select_CandidateTestSectionCount", connection);
            selectCommand2.CommandType = CommandType.StoredProcedure;
            selectCommand2.Parameters.AddWithValue("@CandidateCode", UserID);
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
            DataTable dataTable = new DataTable();
            sqlDataAdapter2.Fill(dataTable);
            if (dataTable.Rows.Count > 0 && int.Parse(dataTable.Rows[0]["SectionCount"].ToString()) > 0)
            {
                sectionCount = int.Parse(dataTable.Rows[0]["SectionCount"].ToString());
                ViewState["CandidateTestCode"] = (object)dataTable.Rows[0]["CandidateTestCode"].ToString();
                questionGroupCode = int.Parse(dataTable.Rows[0]["QuestionGroupCode"].ToString());
                ViewState["questionGroupCode"] = questionGroupCode;
            }
            if (dataSet.Tables[0].Rows.Count <= 0 || dataSet.Tables[2].Rows.Count <= 0)
                return;
            if (dataSet.Tables[2].Rows.Count > sectionCount && dataSet.Tables[3].Rows.Count > questionGroupCode)
            {
                sectionCode = int.Parse(dataSet.Tables[2].Rows[sectionCount]["SectionCode"].ToString());
                hdSection.Value = sectionCode.ToString();
                lblSectionName.Text = dataSet.Tables[2].Rows[sectionCount]["SectionName"].ToString();
                ViewState["SectionCount"] = sectionCount;
                dtQuestions = ((IEnumerable<DataRow>)dataSet.Tables[0].Select("SectionCode=" + sectionCode)).CopyToDataTable<DataRow>();
                rptQuestion.DataSource = dtQuestions;
                rptQuestion.DataBind();
                TimmerCount = int.Parse(dataSet.Tables[2].Rows[sectionCount]["MaxTimeForSection"].ToString());
                TimmerCount = TimmerCount * 60;
                if (sectionCode == 6)
                {
                    trCaseStudy.Style["display"] = "";
                    trCaseStudy.Style["display"] = "";
                    ltrCaseStudy.Text = dataSet.Tables[3].Rows[questionGroupCode]["CaseStudy"].ToString();
                    hdQuestionGroupCode.Value = dataSet.Tables[3].Rows[questionGroupCode]["QuestionGroupCode"].ToString();
                    dtQuestions = ((IEnumerable<DataRow>)dataSet.Tables[0].Select("SectionCode=" + sectionCode + " and QuestionGroupCode=" + dataSet.Tables[3].Rows[questionGroupCode]["QuestionGroupCode"].ToString())).CopyToDataTable<DataRow>();
                    rptQuestion.DataSource = dtQuestions;
                    rptQuestion.DataBind();
                    ViewState["questionGroupCode"] = questionGroupCode;
                }
                else
                    trCaseStudy.Style["display"] = "none";
            }
            else
                Response.Redirect("ThankYou.aspx", false);
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
        HiddenField control1 = (HiddenField)e.Item.FindControl("hdnQuestionTypeCode");
        HiddenField control2 = (HiddenField)e.Item.FindControl("hdnQuestionCode");
        control1.Value = DataBinder.Eval(e.Item.DataItem, "QuestionTypeCode").ToString();
        control2.Value = DataBinder.Eval(e.Item.DataItem, "QuestionCode").ToString();
        RequiredFieldValidator control3 = (RequiredFieldValidator)e.Item.FindControl("rqdRequired");
        if (control1.Value == "1")
        {
            CheckBoxList control4 = (CheckBoxList)e.Item.FindControl("chkAnswer");
            control4.Visible = true;
            dvOptions = new DataView(dtOptions, "QuestionCode=" + control2.Value, (string)null, DataViewRowState.CurrentRows);
            control4.DataSource = dvOptions;
            control4.DataTextField = "QuestionOptionDesc";
            control4.DataValueField = "QuestionOptionCode";
            control4.DataBind();
            dvOptions = new DataView(dtOptions, "QuestionCode=" + control2.Value + "and IsCorrect=true", (string)null, DataViewRowState.CurrentRows);
            ((RequiredFieldValidatorForCheckBoxList)e.Item.FindControl("RequiredFieldValidatorForCheckBoxList1")).NumberOfCheckBoxesToBeChecked = dvOptions.Count;
        }
        if (control1.Value == "2")
        {
            e.Item.FindControl("txtAnswer").Visible = true;
            control3.ControlToValidate = "txtAnswer";
        }
        if (control1.Value == "4")
        {
            e.Item.FindControl("fuDocument").Visible = true;
            control3.ControlToValidate = "fuDocument";
        }
        if (!(control1.Value == "3"))
            return;
        RadioButtonList control5 = (RadioButtonList)e.Item.FindControl("rdoAnswer");
        control5.Visible = true;
        dvOptions = new DataView(dtOptions, "QuestionCode=" + control2.Value, (string)null, DataViewRowState.CurrentRows);
        control5.DataSource = dvOptions;
        control5.DataTextField = "QuestionOptionDesc";
        control5.DataValueField = "QuestionOptionCode";
        control5.DataBind();
        control3.ControlToValidate = "rdoAnswer";
    }

    protected void SaveTest()
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);
        lblMsg.Text = "";
        try
        {
            connection.Open();
            InsertTest(ref connection);
            InsertTestSection(ref connection, int.Parse(hdSection.Value));
            foreach (RepeaterItem repeaterItem1 in rptQuestion.Items)
            {
                HiddenField control1 = (HiddenField)repeaterItem1.FindControl("hdnQuestionCode");
                HiddenField control2 = (HiddenField)repeaterItem1.FindControl("hdnSectionCode");
                foreach (RepeaterItem repeaterItem2 in ((Repeater)repeaterItem1.FindControl("rptOptions")).Items)
                {
                    HiddenField control3 = (HiddenField)repeaterItem2.FindControl("hdnQuestionTypeCode");
                    if (control3.Value == "1")
                    {
                        foreach (ListItem listItem in ((ListControl)repeaterItem2.FindControl("chkAnswer")).Items)
                        {
                            if (listItem.Selected)
                                InsertAnswers(ref connection, int.Parse(control2.Value), int.Parse(control1.Value), int.Parse(listItem.Value), int.Parse(control3.Value), string.Empty, string.Empty);
                        }
                    }
                    if (control3.Value == "2")
                    {
                        TextBox control4 = (TextBox)repeaterItem2.FindControl("txtAnswer");
                        InsertAnswers(ref connection, int.Parse(control2.Value), int.Parse(control1.Value), 0, int.Parse(control3.Value), control4.Text, string.Empty);
                    }
                    if (control3.Value == "4")
                    {
                        FileUpload control4 = (FileUpload)repeaterItem2.FindControl("fuDocument");
                        string str = string.Empty;
                        string empty = string.Empty;
                        if (control4.HasFile)
                        {
                            str = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + UserID + "/CandidateTest/" + (ViewState["CandidateTestCode"].ToString() + "_" + control1.Value + Path.GetExtension(control4.FileName));
                            if (!Directory.Exists(Server.MapPath(ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + UserID + "/CandidateTest/")))
                                Directory.CreateDirectory(Server.MapPath(ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + UserID + "/CandidateTest/"));
                            GeneralMethods.FileBrowse(control4, ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + UserID + "/CandidateTest/", Path.GetFileNameWithoutExtension(str));
                        }
                        InsertAnswers(ref connection, int.Parse(control2.Value), int.Parse(control1.Value), 0, int.Parse(control3.Value), string.Empty, str);
                    }
                    if (control3.Value == "3")
                    {
                        foreach (ListItem listItem in ((ListControl)repeaterItem2.FindControl("rdoAnswer")).Items)
                        {
                            if (listItem.Selected)
                                InsertAnswers(ref connection, int.Parse(control2.Value), int.Parse(control1.Value), int.Parse(listItem.Value), int.Parse(control3.Value), string.Empty, string.Empty);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.StackTrace, ex, UserID.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                if (hdSection.Value == "6")
                {
                    sectionCount = int.Parse(ViewState["SectionCount"].ToString());
                    ++sectionCount;
                    ViewState["SectionCount"] = sectionCount;
                    questionGroupCode = int.Parse(ViewState["questionGroupCode"].ToString());
                    ++questionGroupCode;
                    ViewState["questionGroupCode"] = questionGroupCode;
                }
                else
                {
                    sectionCount = int.Parse(ViewState["SectionCount"].ToString());
                    ++sectionCount;
                    ViewState["SectionCount"] = sectionCount;
                }
                BindData();
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SaveTest();
    }

    protected void InsertAnswers(ref SqlConnection connection, int sectionCode, int QuestionCode, int QuestionOptionCode, int QuestionTypeCode, string answer, string filePath)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Insert_CandidateTestAnswers", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@TestCode", TestCode);
        sqlCommand.Parameters.AddWithValue("@CandidateCode", UserID);
        sqlCommand.Parameters.AddWithValue("@SectionCode", (object)sectionCode);
        sqlCommand.Parameters.AddWithValue("@QuestionCode", (object)QuestionCode);
        sqlCommand.Parameters.AddWithValue("@QuestionOptionCode", (object)QuestionOptionCode);
        sqlCommand.Parameters.AddWithValue("@QuestionTypeCode", (object)QuestionTypeCode);
        sqlCommand.Parameters.AddWithValue("@QuestionAnswer", (object)answer);
        sqlCommand.Parameters.AddWithValue("@FileBrowse", (object)filePath);
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        sqlCommand.Parameters.AddWithValue("@CandidateTestCode", ViewState["CandidateTestCode"].ToString());
        sqlCommand.ExecuteNonQuery();
    }

    protected void InsertTest(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XREC_Insert_CandidateTest", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.AddWithValue("@TestCode", TestCode);
        selectCommand.Parameters.AddWithValue("@CandidateCode", UserID);
        if (ViewState["CandidateTestCode"] == null)
            selectCommand.Parameters.AddWithValue("@CandidateTestCode", (object)0);
        else if (ViewState["CandidateTestCode"] != null)
            selectCommand.Parameters.AddWithValue("@CandidateTestCode", (object)Convert.ToInt32(ViewState["CandidateTestCode"].ToString()));
        selectCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
        selectCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        ViewState["CandidateTestCode"] = (object)dataSet.Tables[0].Rows[0]["CandidateTestCode"].ToString();
    }

    protected void InsertTestSection(ref SqlConnection connection, int sectionCode)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Insert_CandidateTestSection", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@TestCode", TestCode);
        sqlCommand.Parameters.AddWithValue("@CandidateCode", UserID);
        sqlCommand.Parameters.AddWithValue("@SectionCode", (object)sectionCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        if (sectionCode == 6)
            sqlCommand.Parameters.AddWithValue("@QuestionGroupCode", hdQuestionGroupCode.Value);
        sqlCommand.Parameters.AddWithValue("@CandidateTestCode", ViewState["CandidateTestCode"].ToString());
        sqlCommand.ExecuteNonQuery();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SaveTest();
    }
}