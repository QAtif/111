using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

using System.Configuration;
using System.Web.UI.HtmlControls;

public partial class AddEditQuestion : XRecBase
{
    int TestCode = 0;
    int count = 0;
    DataTable dtOptions = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString != null && Request.QueryString["tid"] != null && Request.QueryString != null && Request.QueryString["tid"] != null)
        {
            if (Request.QueryString["tid"].ToString() != "")
            {
                TestCode = Convert.ToInt32(Request.QueryString["tid"].ToString());
                ViewState["tid"] = Request.QueryString["tid"].ToString();
            }
        }
        else
        {
            TestCode = 0;
        }

        if (!IsPostBack)
        {
            ShowData();
            ddlSection_SelectedIndexChanged(null, null);
        }
    }



    public void ShowData()
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);
        string strSQL = string.Empty;

        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XREC_Selcet_QuestionOGData", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlSection.DataSource = ds.Tables[0];
                    ddlSection.DataTextField = "SectionName";
                    ddlSection.DataValueField = "SectionCode";
                    ddlSection.DataBind();
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    ddlQuestionGroup.DataSource = ds.Tables[2];
                    ddlQuestionGroup.DataTextField = "QuestionGroupName";
                    ddlQuestionGroup.DataValueField = "QuestionGroupCode";
                    ddlQuestionGroup.DataBind();
                }

            }
            if (TestCode > 0)
            {
                sqlCommand = new SqlCommand("XREC_Select_TestDetail", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@TestCode", TestCode);
                adapter = new SqlDataAdapter(sqlCommand);
                ds = new DataSet();
                adapter.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0]["TestName"].ToString();
                    txtMinPassingMarks.Text = ds.Tables[0].Rows[0]["MinPassingMarks"].ToString();
                    txtMaxTimeOfTest.Text = ds.Tables[0].Rows[0]["MaxTimeOfTest"].ToString();
                    chkSectionTimeDependency.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["SectionTimeDependency"].ToString());
                    txtTotalMarks.Text = ds.Tables[0].Rows[0]["TotalMarks"].ToString();

                }
                if (ds.Tables[1].Rows.Count > 0)
                {


                    //txtMaxTimeForSection.Text = ds.Tables[1].Rows[0]["MaxTimeForSection"].ToString();
                    //txtWeightageofEachSection.Text = ds.Tables[1].Rows[0]["WeightageofEachSection"].ToString();

                    dtOptions = ds.Tables[1];
                    rptSection.DataSource = ds.Tables[1].DefaultView.ToTable(true, "SectionCode", "SectionName", "MaxTimeForSection", "WeightageofEachSection", "QuestionGroupName", "QuestionGroupCode");
                    rptSection.DataBind();

                    ddlSection.SelectedValue = ds.Tables[1].Rows[0]["SectionCode"].ToString();
                    txtMaxTimeForSection.Text = ds.Tables[1].Rows[0]["MaxTimeForSection"].ToString();
                    txtWeightageofEachSection.Text = ds.Tables[1].Rows[0]["WeightageofEachSection"].ToString();
                    txtCaseStudy.Content = ds.Tables[1].Rows[0]["CaseStudy"].ToString();

                }

            }
        }
        catch (Exception exp1)
        {
            //throw exp1;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, exp1.StackTrace, exp1, UserID.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

    }
    /*
       protected void rptOptions_ItemCommand(object source, RepeaterCommandEventArgs e)
       {
           if (e.CommandName == "Delete")
           {
           
               SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProcurementConnection"].ConnectionString);
               CustomBasePage objCBP = new CustomBasePage();
               SqlCommand sqlCommand = new SqlCommand("PUR_Delete_PurchaseOrderPolicyPurchaseOrderCategory", connection);
               sqlCommand.CommandType = CommandType.StoredProcedure;
               sqlCommand.Parameters.AddWithValue("@PurchaseOrderPolicyitemid", e.CommandArgument);
               sqlCommand.Parameters.AddWithValue("@UpdatedByUser", objCBP.EmployeeID);
               sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
               SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
               DataTable dt = new DataTable();
               adapter.Fill(dt);

               GetProcurementPolicyData(ref connection);
            
           }
       }
   */

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);
        int Exist = 0;
        int testSectionCode = 0;
        int TestDetailCode = 0;
        lblMsg.Text = "";
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XREC_Insert_Update_Test", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@TestName", txtName.Text);
            sqlCommand.Parameters.AddWithValue("@MinPassingMarks", txtMinPassingMarks.Text);
            sqlCommand.Parameters.AddWithValue("@MaxTimeOfTest", txtMaxTimeOfTest.Text);
            sqlCommand.Parameters.AddWithValue("@SectionTimeDependency", chkSectionTimeDependency.Checked);
            sqlCommand.Parameters.AddWithValue("@TotalMarks", txtTotalMarks.Text);

            sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
            sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);

            if (TestCode == 0 && ViewState["tid"] == null)
            {
                sqlCommand.Parameters.AddWithValue("@TestCode", 0); // insert
            }

            else if (ViewState["tid"] != null && Request.QueryString["tid"] != "" && Request.QueryString["tid"] != string.Empty)
            {
                sqlCommand.Parameters.AddWithValue("@TestCode", Convert.ToInt32(Request.QueryString["tid"])); // update
            }
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //Exist = Convert.ToInt32(dt.Rows[0]["TestCode"].ToString());
                //ViewState["tid"] = Exist;
                //if (Exist == 0)
                //{
                //    trMessage.Style["display"] = "";
                //    lblMessage.Text = "This Test already exists.";
                //}

                //else
                //{
                lblMsg.Text = "";
                TestCode = Convert.ToInt32(dt.Rows[0]["TestCode"]);

                foreach (RepeaterItem rpt in rptSection.Items)
                {
                    HiddenField hdnSectionCode = (HiddenField)rpt.FindControl("hdnSectionCode");
                    HiddenField hdnMaxTimeForSection = (HiddenField)rpt.FindControl("hdnMaxTimeForSection");
                    HiddenField hdnWeightageofEachSection = (HiddenField)rpt.FindControl("hdnWeightageofEachSection");
                    Literal ltrCaseStudy = (Literal)rpt.FindControl("ltrCaseStudy");
                    HiddenField hdnQuestionGroupCode = (HiddenField)rpt.FindControl("hdnQuestionGroupCode");


                    sqlCommand = new SqlCommand("XREC_Insert_Update_TestSection", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@TestCode", TestCode);
                    sqlCommand.Parameters.AddWithValue("@SectionCode", hdnSectionCode.Value);
                    sqlCommand.Parameters.AddWithValue("@MaxTimeForSection", hdnMaxTimeForSection.Value); // update
                    sqlCommand.Parameters.AddWithValue("@WeightageofEachSection", hdnWeightageofEachSection.Value); // update                        

                    sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
                    sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                    sqlCommand.Parameters.AddWithValue("@TestSectionCode", 0);                 
   
                    if( hdnSectionCode.Value=="6") /* JD Specific*/
                    sqlCommand.Parameters.AddWithValue("@QuestionGroupCode", hdnQuestionGroupCode.Value);


                    adapter = new SqlDataAdapter(sqlCommand);
                    dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        testSectionCode = Convert.ToInt32(dt.Rows[0]["TestSectionCode"].ToString());
                    }

                    Repeater rptQuestions = (Repeater)rpt.FindControl("rptOptions");

                    foreach (RepeaterItem rptQuesItem in rptQuestions.Items)
                    {
                        HiddenField hdnQuestionCode = (HiddenField)rptQuesItem.FindControl("hdnQuestionCode");


                        sqlCommand = new SqlCommand("XREC_Insert_Update_TestDetail", connection);
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.AddWithValue("@TestCode", TestCode);
                        sqlCommand.Parameters.AddWithValue("@QuestionCode", hdnQuestionCode.Value);
                        sqlCommand.Parameters.AddWithValue("@TestSectionCode", testSectionCode);

                        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
                        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                        sqlCommand.Parameters.AddWithValue("@TestDetailCode", 0);

                        adapter = new SqlDataAdapter(sqlCommand);
                        dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            TestDetailCode = Convert.ToInt32(dt.Rows[0]["TestDetailCode"].ToString());
                        }

                    }
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "pass", "refreshParent();", true);
                //}
            }
        }

        catch (Exception exp1)
        {
            //throw exp1;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, exp1.StackTrace, exp1, UserID.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }


    }
    protected void btnOptionAdd_Click(object sender, EventArgs e)
    {
        dtOptions = GetSelectedOptions();
        DataRow dRow;
        //if (dtApprovalAuthorities.Select("RoleID='" + ddlApprovalAuthority.SelectedValue + "'").Length > 0)
        //    return;


        for (int i = 0; i <= chkQuestion.Items.Count - 1; i++)
        {
            if (chkQuestion.Items[i].Selected)
            {
                if (dtOptions.Select("QuestionCode=" + chkQuestion.Items[i].Value).Length == 0)
                {
                    dRow = dtOptions.NewRow();
                    dRow["SectionCode"] = ddlSection.SelectedValue;
                    dRow["SectionName"] = ddlSection.SelectedItem.Text;
                    dRow["MaxTimeForSection"] = txtMaxTimeForSection.Text;
                    dRow["WeightageofEachSection"] = txtWeightageofEachSection.Text;
                    dRow["QuestionCode"] = chkQuestion.Items[i].Value;
                    dRow["QuestionName"] = chkQuestion.Items[i].Text;
                    dRow["IsNew"] = 1;
                    dRow["TestDetailCode"] = 0;
                    dRow["QuestionGroupName"] = ddlQuestionGroup.SelectedItem.Text;
                    dRow["QuestionGroupCode"] = ddlQuestionGroup.SelectedValue;

                    count += 1;
                    dRow["Index"] = count;
                    dtOptions.Rows.Add(dRow);
                }


            }
        }
        DataRow[] customerRow ;
        if( ddlSection.SelectedValue!="6")
            customerRow = dtOptions.Select("SectionCode =" + ddlSection.SelectedValue);
        else
            customerRow = dtOptions.Select("SectionCode =" + ddlSection.SelectedValue + "and QuestionGroupCode=" + ddlQuestionGroup.SelectedValue);

        foreach (DataRow dr in customerRow)
        {
            dr["MaxTimeForSection"] = txtMaxTimeForSection.Text;
            dr["WeightageofEachSection"] = txtWeightageofEachSection.Text;

        }

        rptSection.DataSource = dtOptions.DefaultView.ToTable(true, "SectionCode", "SectionName", "MaxTimeForSection", "WeightageofEachSection", "QuestionGroupName", "QuestionGroupCode");
        rptSection.DataBind();
        txtMaxTimeForSection.Text = string.Empty;
        txtWeightageofEachSection.Text = string.Empty;
        txtCaseStudy.Content = string.Empty;
        txtMinNoofQuestions.Text = string.Empty;
        ClearCheckList();

    }
    private void ClearCheckList()
    {
        for (int i = 0; i <= chkQuestion.Items.Count - 1; i++)
        {
            chkQuestion.Items[i].Selected = false;
        }
    }
    protected void rptSection_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rptOptions = (Repeater)e.Item.FindControl("rptOptions");
            //rptOptions.DataSource = dtOptions.Select("SectionCode=" + ((HiddenField)e.Item.FindControl("hdnSectionCode")).Value);
            DataView dv;
            if (((HiddenField)e.Item.FindControl("hdnSectionCode")).Value != "6")
            {
                dv = new DataView(dtOptions, "SectionCode=" + ((HiddenField)e.Item.FindControl("hdnSectionCode")).Value, null, DataViewRowState.CurrentRows);
            }
            else
            {
                dv = new DataView(dtOptions, "SectionCode=" + ((HiddenField)e.Item.FindControl("hdnSectionCode")).Value + "and QuestionGroupCode=" + ((HiddenField)e.Item.FindControl("hdnQuestionGroupCode")).Value, null, DataViewRowState.CurrentRows);
                HtmlTableRow trQuestionGroup = (HtmlTableRow)e.Item.FindControl("trQuestionGroup");
                trQuestionGroup.Style["display"] = "";
            }
            rptOptions.DataSource = dv;
            rptOptions.DataBind();
        }
    }

    private DataTable GetSelectedOptions()
    {
        dtOptions = (DataTable)rptSection.DataSource;
        DataRow dRow;
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

            foreach (RepeaterItem itemSection in rptSection.Items)
            {

                Repeater rptOptions = (Repeater)itemSection.FindControl("rptOptions");

                foreach (RepeaterItem item in rptOptions.Items)
                {
                    dRow = dtOptions.NewRow();
                    dRow["SectionCode"] = ((HiddenField)itemSection.FindControl("hdnSectionCode")).Value;
                    dRow["SectionName"] = ((Label)itemSection.FindControl("lblSectionName")).Text;
                    dRow["MaxTimeForSection"] = ((HiddenField)itemSection.FindControl("hdnMaxTimeForSection")).Value;
                    dRow["WeightageofEachSection"] = ((HiddenField)itemSection.FindControl("hdnWeightageofEachSection")).Value;
                    dRow["QuestionCode"] = ((HiddenField)item.FindControl("hdnQuestionCode")).Value;
                    dRow["QuestionName"] = ((Label)item.FindControl("lblQuestionName")).Text;
                    dRow["IsNew"] = ((HiddenField)item.FindControl("hdnIsNew")).Value;
                    dRow["TestDetailCode"] = ((HiddenField)item.FindControl("hdnTestDetailCode")).Value;
                    Literal ltrQuestionGroupName = (Literal)itemSection.FindControl("ltrQuestionGroupName");
                    dRow["QuestionGroupName"] = ltrQuestionGroupName.Text;
                    dRow["QuestionGroupCode"] = ((HiddenField)itemSection.FindControl("hdnQuestionGroupCode")).Value;



                    count += 1;
                    dRow["Index"] = count;
                    dtOptions.Rows.Add(dRow);
                }

            }

        }
        return dtOptions;
    }
    protected void DeleteQuestionsFromTest(int TestDetailCode)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XRec_Delete_QuestionFromTest", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@TestDetailCode", TestDetailCode);
            sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
            sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
            sqlCommand.ExecuteNonQuery();
        }

        catch (Exception exp1)
        {
            //throw exp1;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, exp1.StackTrace, exp1, UserID.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
    protected void rptOptions_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (Request.QueryString["tid"] != null && Request.QueryString["tid"].ToString() != "")
        {
            if (e.CommandName == "Delete")
            {
                HiddenField hdnIsNew = (HiddenField)e.Item.FindControl("hdnIsNew");
                if (hdnIsNew.Value == "0")
                {
                    HiddenField hdnTestDetailCode = (HiddenField)e.Item.FindControl("hdnTestDetailCode");
                    DeleteQuestionsFromTest(int.Parse(hdnTestDetailCode.Value));
                    ShowData();
                }
                if (hdnIsNew.Value == "1")
                {
                    dtOptions = GetSelectedOptions();
                    DataRow[] dr = dtOptions.Select("QuestionCode=" + e.CommandArgument);

                    foreach (DataRow dr1 in dr)
                    {
                        dtOptions.Rows.Remove(dr1);
                        dtOptions.AcceptChanges();
                    }

                    rptSection.DataSource = dtOptions.DefaultView.ToTable(true, "SectionCode", "SectionName", "MaxTimeForSection", "WeightageofEachSection", "CaseStudy");
                    rptSection.DataBind();
                }

            }
        }
        else
        {
            if (e.CommandName == "Delete")
            {
                dtOptions = GetSelectedOptions();
                DataRow[] dr = dtOptions.Select("QuestionCode=" + e.CommandArgument);
                //dtOptions.Rows[].Delete();
                //dtOptions.AcceptChanges();

                foreach (DataRow dr1 in dr)
                {
                    //Console.WriteLine(dr1.);
                    dtOptions.Rows.Remove(dr1);
                    dtOptions.AcceptChanges();
                }

                rptSection.DataSource = dtOptions.DefaultView.ToTable(true, "SectionCode", "SectionName", "MaxTimeForSection", "WeightageofEachSection", "CaseStudy");
                rptSection.DataBind();
            }
        }




    }
    protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);

        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XREC_Select_SectionWiseQuestions", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@SectionCode", ddlSection.SelectedValue);

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataView dv;
                if (ddlSection.SelectedValue == "6")
                    dv = new DataView(dt, "QuestionGroupCode=" + ddlQuestionGroup.SelectedValue, "", DataViewRowState.OriginalRows);
                else
                    dv = new DataView(dt);
                chkQuestion.DataSource = dv;
                chkQuestion.DataTextField = "QuestionName";
                chkQuestion.DataValueField = "QuestionCode";
                chkQuestion.DataBind();

            }
            /*
            if (ddlSection.SelectedValue == "6")
            {
                trCaseStudy.Style["display"]="";
            }
            else
                trCaseStudy.Style["display"] = "none";
            */

            if (ddlSection.SelectedValue == "6")
            {
                trQuestionGroup.Style["display"] = "";
            }
            else
                trQuestionGroup.Style["display"] = "none";




        }

        catch (Exception exp1)
        {
            //throw exp1;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, exp1.StackTrace, exp1, UserID.ToString());
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