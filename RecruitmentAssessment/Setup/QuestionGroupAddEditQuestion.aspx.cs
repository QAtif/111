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

public partial class QuestionGroupAddEditQuestion : XRecBase
{
    int QuestionCode = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            if (Request.QueryString != null && Request.QueryString["qgid"] != null && Request.QueryString != null && Request.QueryString["qgid"] != null)
            {
                if (Request.QueryString["qgid"].ToString() != "")
                {
                    QuestionCode = Convert.ToInt32(Request.QueryString["qgid"].ToString());
                    ViewState["qgid"] = Request.QueryString["qgid"].ToString();
                }
            }
            else
            {
                QuestionCode = 0;
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
            SqlCommand sqlCommand = new SqlCommand("XREC_Selcet_QuestionOGDataQuestionGroup", connection);
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
                if (ds.Tables[1].Rows.Count > 0)
                {
                    ddlQuestionType.DataSource = ds.Tables[1];
                    ddlQuestionType.DataTextField = "QuestionTypeName";
                    ddlQuestionType.DataValueField = "QuestionTypeCode";
                    ddlQuestionType.DataBind();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    ddlQuestionGroup.DataSource = ds.Tables[2];
                    ddlQuestionGroup.DataValueField = "QuestionGroupCode";
                    ddlQuestionGroup.DataTextField = "QuestionGroupName";
                    ddlQuestionGroup.DataBind();
                }

                if (Request["sid"] != null && Request["sid"].ToString() != string.Empty)
                    ddlSection.SelectedValue = Request["sid"].ToString();
                if (Request["qgid"] != null && Request["qgid"].ToString() != string.Empty)
                    ddlQuestionGroup.SelectedValue = Request["qgid"].ToString();
                
            }

            #region Temporary Commented by Ali Raza on Feb 27,2013

            /*
            if (QuestionCode > 0)
            {
                sqlCommand = new SqlCommand("XREC_Select_QuestionDetailsByQuestionCode", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@QuestionCode", QuestionCode);
                adapter = new SqlDataAdapter(sqlCommand);
                ds = new DataSet();
                adapter.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Content = ds.Tables[0].Rows[0]["QuestionName"].ToString();
                    ddlSection.SelectedValue = ds.Tables[0].Rows[0]["SectionCode"].ToString();
                    ddlQuestionType.SelectedValue = ds.Tables[0].Rows[0]["QuestionTypeCode"].ToString();
                    txtblank.Text = ds.Tables[0].Rows[0]["QuestionAnswer"].ToString();
                    lnkView.InnerText = "View";
                    lnkView.HRef = ds.Tables[0].Rows[0]["FileBrowse"].ToString();
                    if (ds.Tables[0].Rows[0]["FileBrowse"].ToString() != string.Empty)
                        fuDocument.Style["display"] = "none";
                    else
                        lnkView.Style["display"] = "none";

                }
                ShowDivs();

                if (ds.Tables[1].Rows.Count > 0)
                {
                    rptOptions.DataSource = ds.Tables[1];
                    rptOptions.DataBind();
                }

            }
            */
            #endregion
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
        if (ddlQuestionType.SelectedValue == "2")
        {
            trBlank.Style["display"] = "";
            trOption.Style["display"] = "none";
            trIsCorrect.Style["display"] = "none";
            trAdd.Style["display"] = "none";
            trBrowseFile.Style["display"] = "none";

        }
        if (ddlQuestionType.SelectedValue == "4")
        {
            trBlank.Style["display"] = "none";
            trOption.Style["display"] = "none";
            trIsCorrect.Style["display"] = "none";
            trAdd.Style["display"] = "none";
            trBrowseFile.Style["display"] = "";

        }
        if (ddlQuestionType.SelectedValue == "1" || ddlQuestionType.SelectedValue == "3")
        {
            trBlank.Style["display"] = "none";
            trOption.Style["display"] = "";
            trIsCorrect.Style["display"] = "";
            trAdd.Style["display"] = "";
            trBrowseFile.Style["display"] = "none";
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
        string completepath = string.Empty;
        string file = string.Empty;
        if (ddlQuestionType.SelectedValue == "4")
        {
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
        }


        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);
        int Exist = 0;
        lblMsg.Text = "";
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XREC_Insert_Update_QuestionGroup", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            //<!--</body-->
            //string txt= txtName.OnClientPasteHtml;
            //txt = txt.Replace("<!--</body-->", string.Empty);
            sqlCommand.Parameters.AddWithValue("@QuestionName", txtName.Content);
            sqlCommand.Parameters.AddWithValue("@SectionCode", ddlSection.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@QuestionTypeCode", ddlQuestionType.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@QuestionAnswer", txtblank.Text);

            sqlCommand.Parameters.AddWithValue("@FileBrowse", file);

            sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
            sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);

            if (QuestionCode == 0 && ViewState["qid"] == null)
            {
                sqlCommand.Parameters.AddWithValue("@QuestionCode", 0); // insert
            }

            else if (ViewState["qid"] != null && Request.QueryString["qid"] != "" && Request.QueryString["qid"] != string.Empty)
            {
                sqlCommand.Parameters.AddWithValue("@QuestionCode", Convert.ToInt32(Request.QueryString["qid"])); // update
            }
            sqlCommand.Parameters.AddWithValue("@QuestionGroupCode", ddlQuestionGroup.SelectedValue);

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Exist = Convert.ToInt32(dt.Rows[0]["QuestionCode"].ToString());
                ViewState["qid"] = Exist;
                if (Exist == 0)
                {
                    trMessage.Style["display"] = "";
                    lblMessage.Text = "This Question already exists.";
                }

                else
                {
                    lblMsg.Text = "";

                    QuestionCode = Convert.ToInt32(dt.Rows[0]["QuestionCode"]);

                    #region Set IsActive 0
                    sqlCommand = new SqlCommand("XREC_Delete_Update_QuestionOptions", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    
                    sqlCommand.Parameters.AddWithValue("@QuestionCode", QuestionCode); // update
                    sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
                    sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                    sqlCommand.ExecuteNonQuery();

                    #endregion
                    

                    foreach (RepeaterItem rpt in rptOptions.Items)
                    {
                        Label lblAnswer = (Label)rpt.FindControl("lblAnswer");
                        Label lblIsCorrect = (Label)rpt.FindControl("lblIsCorrect");

                        sqlCommand = new SqlCommand("XREC_Insert_Update_QuestionOptions", connection);
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.AddWithValue("@QuestionOptionDesc", lblAnswer.Text);
                        sqlCommand.Parameters.AddWithValue("@IsCorrect", Convert.ToBoolean(lblIsCorrect.Text));
                        sqlCommand.Parameters.AddWithValue("@QuestionCode", QuestionCode); // update
                        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
                        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                        sqlCommand.Parameters.AddWithValue("@QuestionOptionCode", 0);

                        adapter = new SqlDataAdapter(sqlCommand);
                        dt = new DataTable();
                        adapter.Fill(dt);

                    }

                    ScriptManager.RegisterStartupScript(this, GetType(), "pass", "refreshParent();", true);
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
    protected void btnOptionAdd_Click(object sender, EventArgs e)
    {
        DataTable dtOptions = GetSelectedOptions();
        DataRow dRow;
        //if (dtApprovalAuthorities.Select("RoleID='" + ddlApprovalAuthority.SelectedValue + "'").Length > 0)
        //    return;
        dRow = dtOptions.NewRow();
        dRow["IsCorrect"] = chkIsCorrect.Checked;
        dRow["QuestionOptionDesc"] = txtOption.Text;
        dRow["QuestionOptionCode"] = dtOptions.Rows.Count + 1;
        dtOptions.Rows.Add(dRow);
        rptOptions.DataSource = dtOptions;
        rptOptions.DataBind();
        txtOption.Text = string.Empty;
        chkIsCorrect.Checked = false;
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

        if (Request.QueryString["qid"] != null && Request.QueryString["qid"].ToString() != "")
        {
            if (e.CommandName == "Delete")
            {
                DataTable dtOptions = GetSelectedOptions();
                dtOptions.Rows[e.Item.ItemIndex].Delete();
                rptOptions.DataSource = dtOptions;
                rptOptions.DataBind();
            }
        }
        else
        {
            if (e.CommandName == "Delete")
            {
                DataTable dtOptions = GetSelectedOptions();
                dtOptions.Rows[e.Item.ItemIndex].Delete();
                rptOptions.DataSource = dtOptions;
                rptOptions.DataBind();
            }
        }




    }
}