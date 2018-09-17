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

public partial class AddEditCaseStudy : XRecBase
{
    int QuestionGroupCode = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            if (Request.QueryString != null && Request.QueryString["qgid"] != null && Request.QueryString != null && Request.QueryString["qgid"] != null)
            {
                if (Request.QueryString["qgid"].ToString() != "")
                {
                    QuestionGroupCode = Convert.ToInt32(Request.QueryString["qgid"].ToString());
                    ViewState["qgid"] = Request.QueryString["qgid"].ToString();
                }
            }
            else
            {
                QuestionGroupCode = 0;
            }
            ShowData();
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
            }
            if (QuestionGroupCode > 0)
            {
                sqlCommand = new SqlCommand("XREC_Select_QuestionGroupDetailsByQuestionCode", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@QuestionGroupCode", QuestionGroupCode);
                adapter = new SqlDataAdapter(sqlCommand);
                ds = new DataSet();
                adapter.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0]["QuestionGroupName"].ToString();
                    ddlSection.SelectedValue = ds.Tables[0].Rows[0]["SectionCode"].ToString();
                    txtCaseStudy.Content = ds.Tables[0].Rows[0]["QuestionGroupDetails"].ToString();

                    btnAdd.Style["display"] = "";
                    btnAdd.HRef = "QuestionGroupAddEditQuestion.aspx?qgid=" + ds.Tables[0].Rows[0]["QuestionGroupCode"].ToString() + "&sid=" + ddlSection.SelectedValue;

                }
                ShowDivs();

                if (ds.Tables[1].Rows.Count > 0)
                {
                    SearchCategoryOptions2.Style["display"] = "";
                    rptOptions.DataSource = ds.Tables[1];
                    rptOptions.DataBind();
                }

            }
        }
        catch (Exception ex)
        {
            //throw exp1;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserID.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

    }
    protected void ShowDivs()
    {

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
        string completepath = string.Empty;
        string file = string.Empty;
        if (fuDocument.HasFile)
        {
            file = DateTime.Now.Day.ToString() + "_" +
               DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + fuDocument.FileName;

            file = "\\Documents\\" + file;

            if (!System.IO.Directory.Exists(Server.MapPath("/Documents/")))
            {
                System.IO.Directory.CreateDirectory(Server.MapPath("/Documents/"));
            }

            completepath = Server.MapPath(file);

            fuDocument.SaveAs(completepath);

        }

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);        
        //lblMsg.Text = "";
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XREC_Insert_Update_CaseStudy", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;            
            sqlCommand.Parameters.AddWithValue("@QuestionGroupName", txtName.Text);
            sqlCommand.Parameters.AddWithValue("@QuestionGroupDetails", txtCaseStudy.Content);
            sqlCommand.Parameters.AddWithValue("@SectionCode", ddlSection.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
            sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);

            if (QuestionGroupCode == 0 && ViewState["qgid"] == null)
            {
                sqlCommand.Parameters.AddWithValue("@QuestionGroupCode", 0); // insert
            }
            else if (ViewState["qgid"] != null && Request.QueryString["qgid"] != "" && Request.QueryString["qgid"] != string.Empty)
            {
                sqlCommand.Parameters.AddWithValue("@QuestionGroupCode", Convert.ToInt32(Request.QueryString["qgid"])); // update
            }

            sqlCommand.Parameters.AddWithValue("@FileBrowse", file);

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                btnAdd.Style["display"] = "";
                btnAdd.HRef = "QuestionGroupAddEditQuestion.aspx?qgid=" + dt.Rows[0]["QuestionGroupCode"].ToString() + "&sid=" + ddlSection.SelectedValue;
            }
            //ScriptManager.RegisterStartupScript(this, GetType(), "pass", "refreshParent();", true);

        }

        catch (Exception ex)
        {
            //throw exp1;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserID.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }


    }
    protected void rptOptions_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlAnchor lnkQuestion = (HtmlAnchor)e.Item.FindControl("lnkQuestion");
            lnkQuestion.HRef = "AddEditQuestion.aspx?qid=" + DataBinder.Eval(e.Item.DataItem, "QuestionCode").ToString();
        }
    }
    private DataTable GetSelectedOptions()
    {
        DataTable dtOptions = (DataTable)rptOptions.DataSource;
        if (dtOptions == null)
        {
            dtOptions = new DataTable();
            dtOptions.Columns.Add(new DataColumn("QuestionOptionDesc"));
            dtOptions.Columns.Add(new DataColumn("IsCorrect"));
            dtOptions.Columns.Add(new DataColumn("QuestionOptionCode"));


            foreach (RepeaterItem item in rptOptions.Items)
            {
                DataRow dRow;
                dRow = dtOptions.NewRow();
                dRow["IsCorrect"] = ((Label)item.FindControl("lblIsCorrect")).Text;
                dRow["QuestionOptionDesc"] = ((Label)item.FindControl("lblAnswer")).Text;
                dRow["QuestionOptionCode"] = item.ItemIndex + 1;
                dtOptions.Rows.Add(dRow);
            }
        }
        return dtOptions;
    }
    protected void rptOptions_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (Request.QueryString["qgid"] != null && Request.QueryString["qgid"].ToString() != "")
        {
            if (e.CommandName == "Delete")
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);

                try
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("XRec_Delete_Question", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@QuestionCode", e.CommandArgument);
                    sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
                    sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                    sqlCommand.ExecuteNonQuery();

                    DataSet ds = new DataSet();
                    sqlCommand = new SqlCommand("XREC_Select_QuestionGroupDetailsByQuestionCode", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@QuestionGroupCode", Request["qgid"].ToString());
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    ds = new DataSet();
                    adapter.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtName.Text = ds.Tables[0].Rows[0]["QuestionGroupName"].ToString();
                        ddlSection.SelectedValue = ds.Tables[0].Rows[0]["SectionCode"].ToString();
                        txtCaseStudy.Content = ds.Tables[0].Rows[0]["QuestionGroupDetails"].ToString();

                        btnAdd.Style["display"] = "";
                        btnAdd.HRef = "QuestionGroupAddEditQuestion.aspx?qgid=" + ds.Tables[0].Rows[0]["QuestionGroupCode"].ToString() + "&sid=" + ddlSection.SelectedValue;
                    }
                    
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        SearchCategoryOptions2.Style["display"] = "";
                        rptOptions.DataSource = ds.Tables[1];
                        rptOptions.DataBind();
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
        }

    }
}