

using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System;
using ErrorLog;

public partial class AddEditQuestion : CustomBasePage//XRecBase
{
    private DataTable dtOptions = new DataTable();
    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    private int TestCode;
    private int count;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
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
            ShowData();
            ddlSection_SelectedIndexChanged(null, (EventArgs)null);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int num = 0;
        lblMsg.Text = "";
        try
        {
            connection.Open();
            SqlCommand selectCommand1 = new SqlCommand("XREC_Insert_Update_Test", connection);
            selectCommand1.CommandType = CommandType.StoredProcedure;
            selectCommand1.Parameters.AddWithValue("@TestName", txtName.Text);
            selectCommand1.Parameters.AddWithValue("@MinPassingMarks", txtMinPassingMarks.Text);
            selectCommand1.Parameters.AddWithValue("@MaxTimeOfTest", txtMaxTimeOfTest.Text);
            selectCommand1.Parameters.AddWithValue("@SectionTimeDependency", chkSectionTimeDependency.Checked);
            selectCommand1.Parameters.AddWithValue("@TotalMarks", txtTotalMarks.Text);
            selectCommand1.Parameters.AddWithValue("@UpdatedByUser", UserCode);
            selectCommand1.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
            if (TestCode == 0 && ViewState["tid"] == null)
                selectCommand1.Parameters.AddWithValue("@TestCode", 0);
            else if (ViewState["tid"] != null && Request.QueryString["tid"] != "" && Request.QueryString["tid"] != string.Empty)
                selectCommand1.Parameters.AddWithValue("@TestCode", Convert.ToInt32(Request.QueryString["tid"]));
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(selectCommand1);
            DataTable dataTable1 = new DataTable();
            sqlDataAdapter1.Fill(dataTable1);
            if (dataTable1.Rows.Count <= 0)
                return;
            lblMsg.Text = "";
            TestCode = Convert.ToInt32(dataTable1.Rows[0]["TestCode"]);
            foreach (RepeaterItem repeaterItem in rptSection.Items)
            {
                HiddenField control1 = (HiddenField)repeaterItem.FindControl("hdnSectionCode");
                HiddenField control2 = (HiddenField)repeaterItem.FindControl("hdnMaxTimeForSection");
                HiddenField control3 = (HiddenField)repeaterItem.FindControl("hdnWeightageofEachSection");
                Literal control4 = (Literal)repeaterItem.FindControl("ltrCaseStudy");
                HiddenField control5 = (HiddenField)repeaterItem.FindControl("hdnQuestionGroupCode");
                HiddenField control6 = (HiddenField)repeaterItem.FindControl("hdnRandomQuestions");
                SqlCommand selectCommand2 = new SqlCommand("XREC_Insert_Update_TestSection", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.Parameters.AddWithValue("@TestCode", TestCode);
                selectCommand2.Parameters.AddWithValue("@SectionCode", control1.Value);
                selectCommand2.Parameters.AddWithValue("@MaxTimeForSection", control2.Value);
                selectCommand2.Parameters.AddWithValue("@WeightageofEachSection", control3.Value);
                selectCommand2.Parameters.AddWithValue("@UpdatedByUser", UserCode);
                selectCommand2.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                selectCommand2.Parameters.AddWithValue("@TestSectionCode", 0);
                if (control1.Value == "6")
                    selectCommand2.Parameters.AddWithValue("@QuestionGroupCode", control5.Value);
                selectCommand2.Parameters.AddWithValue("@RandomQuestions", control6.Value);
                SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
                DataTable dataTable2 = new DataTable();
                sqlDataAdapter2.Fill(dataTable2);
                if (dataTable2.Rows.Count > 0)
                    num = Convert.ToInt32(dataTable2.Rows[0]["TestSectionCode"].ToString());
                foreach (Control control7 in ((Repeater)repeaterItem.FindControl("rptOptions")).Items)
                {
                    HiddenField control8 = (HiddenField)control7.FindControl("hdnQuestionCode");
                    SqlCommand selectCommand3 = new SqlCommand("XREC_Insert_Update_TestDetail", connection);
                    selectCommand3.CommandType = CommandType.StoredProcedure;
                    selectCommand3.Parameters.AddWithValue("@TestCode", TestCode);
                    selectCommand3.Parameters.AddWithValue("@QuestionCode", control8.Value);
                    selectCommand3.Parameters.AddWithValue("@TestSectionCode", num);
                    selectCommand3.Parameters.AddWithValue("@UpdatedByUser", UserCode);
                    selectCommand3.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                    selectCommand3.Parameters.AddWithValue("@TestDetailCode", 0);
                    SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
                    DataTable dataTable3 = new DataTable();
                    sqlDataAdapter3.Fill(dataTable3);
                    if (dataTable3.Rows.Count > 0)
                        Convert.ToInt32(dataTable3.Rows[0]["TestDetailCode"].ToString());
                }
            }
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "refreshParent();", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    protected void btnOptionAdd_Click(object sender, EventArgs e)
    {
        try
        {
            dtOptions = GetSelectedOptions();
            for (int index = 0; index <= chkQuestion.Items.Count - 1; ++index)
            {
                if (chkQuestion.Items[index].Selected && dtOptions.Select("QuestionCode=" + chkQuestion.Items[index].Value).Length == 0)
                {
                    DataRow row = dtOptions.NewRow();
                    row["SectionCode"] = ddlSection.SelectedValue;
                    row["SectionName"] = ddlSection.SelectedItem.Text;
                    row["MaxTimeForSection"] = txtMaxTimeForSection.Text;
                    row["WeightageofEachSection"] = txtWeightageofEachSection.Text;
                    row["QuestionCode"] = chkQuestion.Items[index].Value;
                    row["QuestionName"] = chkQuestion.Items[index].Text;
                    row["IsNew"] = 1;
                    row["TestDetailCode"] = 0;
                    row["QuestionGroupName"] = ddlQuestionGroup.SelectedItem.Text;
                    row["QuestionGroupCode"] = ddlQuestionGroup.SelectedValue;
                    row["RandomQuestions"] = txtRandomQuestions.Text;
                    ++count;
                    row["Index"] = count;
                    dtOptions.Rows.Add(row);
                }
            }
            foreach (DataRow dataRow in !(ddlSection.SelectedValue != "6") ? dtOptions.Select("SectionCode =" + ddlSection.SelectedValue + "and QuestionGroupCode=" + ddlQuestionGroup.SelectedValue) : dtOptions.Select("SectionCode =" + ddlSection.SelectedValue))
            {
                dataRow["MaxTimeForSection"] = txtMaxTimeForSection.Text;
                dataRow["WeightageofEachSection"] = txtWeightageofEachSection.Text;
            }
            rptSection.DataSource = dtOptions.DefaultView.ToTable(true, "SectionCode", "SectionName", "MaxTimeForSection", "WeightageofEachSection", "QuestionGroupName", "QuestionGroupCode", "RandomQuestions");
            rptSection.DataBind();
            txtMaxTimeForSection.Text = string.Empty;
            txtWeightageofEachSection.Text = string.Empty;
            txtCaseStudy.Content = string.Empty;
            txtMinNoofQuestions.Text = string.Empty;
            ClearCheckList();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    protected void rptSection_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item)
        {
            if (e.Item.ItemType != ListItemType.AlternatingItem)
                return;
        }
        try
        {
            Repeater control = (Repeater)e.Item.FindControl("rptOptions");
            DataView dataView;
            if (((HiddenField)e.Item.FindControl("hdnSectionCode")).Value != "6")
            {
                dataView = new DataView(dtOptions, "SectionCode=" + ((HiddenField)e.Item.FindControl("hdnSectionCode")).Value, (string)null, DataViewRowState.CurrentRows);
            }
            else
            {
                dataView = new DataView(dtOptions, "SectionCode=" + ((HiddenField)e.Item.FindControl("hdnSectionCode")).Value + "and QuestionGroupCode=" + ((HiddenField)e.Item.FindControl("hdnQuestionGroupCode")).Value, (string)null, DataViewRowState.CurrentRows);
                ((HtmlControl)e.Item.FindControl("trQuestionGroup")).Style["display"] = "";
            }
            control.DataSource = dataView;
            control.DataBind();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    protected void rptOptions_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (Request.QueryString["tid"] != null && Request.QueryString["tid"].ToString() != "")
            {
                if (!(e.CommandName == "Delete"))
                    return;
                HiddenField control = (HiddenField)e.Item.FindControl("hdnIsNew");
                if (control.Value == "0")
                {
                    DeleteQuestionsFromTest(int.Parse(((HiddenField)e.Item.FindControl("hdnTestDetailCode")).Value));
                    ShowData();
                }
                if (!(control.Value == "1"))
                    return;
                dtOptions = GetSelectedOptions();
                foreach (DataRow row in dtOptions.Select("QuestionCode=" + e.CommandArgument))
                {
                    dtOptions.Rows.Remove(row);
                    dtOptions.AcceptChanges();
                }
                rptSection.DataSource = dtOptions.DefaultView.ToTable(true, "SectionCode", "SectionName", "MaxTimeForSection", "WeightageofEachSection", "CaseStudy");
                rptSection.DataBind();
            }
            else
            {
                if (!(e.CommandName == "Delete"))
                    return;
                dtOptions = GetSelectedOptions();
                foreach (DataRow row in dtOptions.Select("QuestionCode=" + e.CommandArgument))
                {
                    dtOptions.Rows.Remove(row);
                    dtOptions.AcceptChanges();
                }
                rptSection.DataSource = dtOptions.DefaultView.ToTable(true, "SectionCode", "SectionName", "MaxTimeForSection", "WeightageofEachSection", "CaseStudy");
                rptSection.DataBind();
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XREC_Select_SectionWiseQuestions", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@SectionCode", ddlSection.SelectedValue);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                chkQuestion.DataSource = !(ddlSection.SelectedValue == "6") ? new DataView(dataTable) : new DataView(dataTable, "QuestionGroupCode=" + ddlQuestionGroup.SelectedValue, "", DataViewRowState.OriginalRows);
                chkQuestion.DataTextField = "QuestionName";
                chkQuestion.DataValueField = "QuestionCode";
                chkQuestion.DataBind();
            }
            if (ddlSection.SelectedValue == "6")
                trQuestionGroup.Style["display"] = "";
            else
                trQuestionGroup.Style["display"] = "none";
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    public void ShowData()
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
        string empty = string.Empty;
        try
        {
            connection.Open();
            SqlCommand selectCommand1 = new SqlCommand("XREC_Selcet_QuestionOGData", connection);
            selectCommand1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(selectCommand1);
            DataSet dataSet1 = new DataSet();
            sqlDataAdapter1.Fill(dataSet1);
            if (dataSet1 != null)
            {
                if (dataSet1.Tables[0].Rows.Count > 0)
                {
                    ddlSection.DataSource = dataSet1.Tables[0];
                    ddlSection.DataTextField = "SectionName";
                    ddlSection.DataValueField = "SectionCode";
                    ddlSection.DataBind();
                }
                if (dataSet1.Tables[2].Rows.Count > 0)
                {
                    ddlQuestionGroup.DataSource = dataSet1.Tables[2];
                    ddlQuestionGroup.DataTextField = "QuestionGroupName";
                    ddlQuestionGroup.DataValueField = "QuestionGroupCode";
                    ddlQuestionGroup.DataBind();
                }
            }
            if (TestCode <= 0)
                return;
            SqlCommand selectCommand2 = new SqlCommand("XREC_Select_TestDetail", connection);
            selectCommand2.CommandType = CommandType.StoredProcedure;
            selectCommand2.Parameters.AddWithValue("@TestCode", TestCode);
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
            DataSet dataSet2 = new DataSet();
            sqlDataAdapter2.Fill(dataSet2);
            if (dataSet2.Tables[0].Rows.Count > 0)
            {
                txtName.Text = dataSet2.Tables[0].Rows[0]["TestName"].ToString();
                txtMinPassingMarks.Text = dataSet2.Tables[0].Rows[0]["MinPassingMarks"].ToString();
                txtMaxTimeOfTest.Text = dataSet2.Tables[0].Rows[0]["MaxTimeOfTest"].ToString();
                chkSectionTimeDependency.Checked = Convert.ToBoolean(dataSet2.Tables[0].Rows[0]["SectionTimeDependency"].ToString());
                txtTotalMarks.Text = dataSet2.Tables[0].Rows[0]["TotalMarks"].ToString();
            }
            if (dataSet2.Tables[1].Rows.Count <= 0)
                return;
            dtOptions = dataSet2.Tables[1];
            rptSection.DataSource = dataSet2.Tables[1].DefaultView.ToTable(true, "SectionCode", "SectionName", "MaxTimeForSection", "WeightageofEachSection", "QuestionGroupName", "QuestionGroupCode", "RandomQuestions");
            rptSection.DataBind();
            ddlSection.SelectedValue = dataSet2.Tables[1].Rows[0]["SectionCode"].ToString();
            txtMaxTimeForSection.Text = dataSet2.Tables[1].Rows[0]["MaxTimeForSection"].ToString();
            txtWeightageofEachSection.Text = dataSet2.Tables[1].Rows[0]["WeightageofEachSection"].ToString();
            txtCaseStudy.Content = dataSet2.Tables[1].Rows[0]["CaseStudy"].ToString();
            txtRandomQuestions.Text = dataSet2.Tables[1].Rows[0]["RandomQuestions"].ToString();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    private void ClearCheckList()
    {
        for (int index = 0; index <= chkQuestion.Items.Count - 1; ++index)
            chkQuestion.Items[index].Selected = false;
    }

    private DataTable GetSelectedOptions()
    {
        dtOptions = (DataTable)rptSection.DataSource;
        if (dtOptions == null)
        {
            dtOptions = new DataTable();
            dtOptions.Columns.Add(new DataColumn("SectionCode"));
            dtOptions.Columns.Add(new DataColumn("SectionName"));
            dtOptions.Columns.Add(new DataColumn("MaxTimeForSection"));
            dtOptions.Columns.Add(new DataColumn("WeightageofEachSection"));
            dtOptions.Columns.Add(new DataColumn("QuestionCode"));
            dtOptions.Columns.Add(new DataColumn("QuestionName"));
            dtOptions.Columns.Add(new DataColumn("IsNew"));
            dtOptions.Columns.Add(new DataColumn("Index"));
            dtOptions.Columns.Add(new DataColumn("TestDetailCode"));
            dtOptions.Columns.Add(new DataColumn("QuestionGroupName"));
            dtOptions.Columns.Add(new DataColumn("QuestionGroupCode"));
            dtOptions.Columns.Add(new DataColumn("RandomQuestions"));
            foreach (RepeaterItem repeaterItem1 in rptSection.Items)
            {
                foreach (RepeaterItem repeaterItem2 in ((Repeater)repeaterItem1.FindControl("rptOptions")).Items)
                {
                    DataRow row = dtOptions.NewRow();
                    row["SectionCode"] = ((HiddenField)repeaterItem1.FindControl("hdnSectionCode")).Value;
                    row["SectionName"] = ((Label)repeaterItem1.FindControl("lblSectionName")).Text;
                    row["MaxTimeForSection"] = ((HiddenField)repeaterItem1.FindControl("hdnMaxTimeForSection")).Value;
                    row["WeightageofEachSection"] = ((HiddenField)repeaterItem1.FindControl("hdnWeightageofEachSection")).Value;
                    row["QuestionCode"] = ((HiddenField)repeaterItem2.FindControl("hdnQuestionCode")).Value;
                    row["QuestionName"] = ((Label)repeaterItem2.FindControl("lblQuestionName")).Text;
                    row["IsNew"] = ((HiddenField)repeaterItem2.FindControl("hdnIsNew")).Value;
                    row["TestDetailCode"] = ((HiddenField)repeaterItem2.FindControl("hdnTestDetailCode")).Value;
                    Literal control = (Literal)repeaterItem1.FindControl("ltrQuestionGroupName");
                    row["QuestionGroupName"] = control.Text;
                    row["QuestionGroupCode"] = ((HiddenField)repeaterItem1.FindControl("hdnQuestionGroupCode")).Value;
                    row["RandomQuestions"] = ((HiddenField)repeaterItem1.FindControl("hdnRandomQuestions")).Value;
                    ++count;
                    row["Index"] = count;
                    dtOptions.Rows.Add(row);
                }
            }
        }
        return dtOptions;
    }

    protected void DeleteQuestionsFromTest(int TestDetailCode)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XRec_Delete_QuestionFromTest", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@TestDetailCode", TestDetailCode);
            sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
            sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }


}