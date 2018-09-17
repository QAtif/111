
using ErrorLog;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using XRecruitmentStatusLibrary;

public partial class AddEditQuestion : CustomBasePage
{
    #region Variables
    int QuestionCode = 0;
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            if (Request.QueryString != null && Request.QueryString["qid"] != null && (Request.QueryString != null && Request.QueryString["qid"] != null))
            {
                if (Request.QueryString["qid"].ToString() != "")
                {
                    QuestionCode = Convert.ToInt32(Request.QueryString["qid"].ToString());
                    ViewState["qid"] = Request.QueryString["qid"].ToString();
                }
            }
            else
                QuestionCode = 0;
            ShowData();
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
        try
        {
            string empty = string.Empty;
            string path = string.Empty;
            if (ddlQuestionType.SelectedValue == "4" && fuDocument.HasFile)
            {
                path = ConfigurationManager.AppSettings["TestDocumentsPath"].ToString() + (DateTime.Now.Ticks.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + fuDocument.FileName);
                if (!Directory.Exists(Server.MapPath(ConfigurationManager.AppSettings["TestDocumentsPath"].ToString())))
                    Directory.CreateDirectory(Server.MapPath(ConfigurationManager.AppSettings["TestDocumentsPath"].ToString()));
                GeneralMethods.FileBrowse(fuDocument, ConfigurationManager.AppSettings["TestDocumentsPath"].ToString(), Path.GetFileNameWithoutExtension(path));
            }
            lblMsg.Text = "";
            connection.Open();
            SqlCommand selectCommand1 = new SqlCommand("XREC_Insert_Update_Question", connection);
            selectCommand1.CommandType = CommandType.StoredProcedure;
            selectCommand1.Parameters.AddWithValue("@QuestionName", txtName.Content);
            selectCommand1.Parameters.AddWithValue("@SectionCode", ddlSection.SelectedValue);
            selectCommand1.Parameters.AddWithValue("@QuestionTypeCode", ddlQuestionType.SelectedValue);
            selectCommand1.Parameters.AddWithValue("@QuestionAnswer", txtblank.Text);
            selectCommand1.Parameters.AddWithValue("@FileBrowse", path);
            selectCommand1.Parameters.AddWithValue("@UpdatedByUser", UserCode);
            selectCommand1.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
            if (QuestionCode == 0 && ViewState["qid"] == null)
                selectCommand1.Parameters.AddWithValue("@QuestionCode", 0);
            else if (ViewState["qid"] != null && Request.QueryString["qid"] != "" && Request.QueryString["qid"] != string.Empty)
                selectCommand1.Parameters.AddWithValue("@QuestionCode", Convert.ToInt32(Request.QueryString["qid"]));
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand1);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count <= 0)
                return;
            int int32 = Convert.ToInt32(dataTable.Rows[0]["QuestionCode"].ToString());
            ViewState["qid"] = int32;
            if (int32 == 0)
            {
                trMessage.Style["display"] = "";
                lblMessage.Text = "This Question already exists.";
            }
            else
            {
                lblMsg.Text = "";
                QuestionCode = Convert.ToInt32(dataTable.Rows[0]["QuestionCode"]);
                SqlCommand sqlCommand = new SqlCommand("XREC_Delete_Update_QuestionOptions", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@QuestionCode", QuestionCode);
                sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
                sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                sqlCommand.ExecuteNonQuery();
                foreach (RepeaterItem repeaterItem in rptOptions.Items)
                {
                    Label control1 = (Label)repeaterItem.FindControl("lblAnswer");
                    Label control2 = (Label)repeaterItem.FindControl("lblIsCorrect");
                    SqlCommand selectCommand2 = new SqlCommand("XREC_Insert_Update_QuestionOptions", connection);
                    selectCommand2.CommandType = CommandType.StoredProcedure;
                    selectCommand2.Parameters.AddWithValue("@QuestionOptionDesc", control1.Text);
                    selectCommand2.Parameters.AddWithValue("@IsCorrect", Convert.ToBoolean(control2.Text));
                    selectCommand2.Parameters.AddWithValue("@QuestionCode", QuestionCode);
                    selectCommand2.Parameters.AddWithValue("@UpdatedByUser", UserCode);
                    selectCommand2.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                    selectCommand2.Parameters.AddWithValue("@QuestionOptionCode", 0);
                    new SqlDataAdapter(selectCommand2).Fill(new DataTable());
                }
                ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "refreshParent();", true);
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

    protected void btnOptionAdd_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable selectedOptions = GetSelectedOptions();
            DataRow row = selectedOptions.NewRow();
            row["IsCorrect"] = chkIsCorrect.Checked;
            row["QuestionOptionDesc"] = txtOption.Text;
            row["QuestionOptionCode"] = (selectedOptions.Rows.Count + 1);
            selectedOptions.Rows.Add(row);
            rptOptions.DataSource = selectedOptions;
            rptOptions.DataBind();
            txtOption.Text = string.Empty;
            chkIsCorrect.Checked = false;
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
            if (Request.QueryString["qid"] != null && Request.QueryString["qid"].ToString() != "")
            {
                if (!(e.CommandName == "Delete"))
                    return;
                DataTable selectedOptions = GetSelectedOptions();
                selectedOptions.Rows[e.Item.ItemIndex].Delete();
                rptOptions.DataSource = selectedOptions;
                rptOptions.DataBind();
            }
            else
            {
                if (!(e.CommandName == "Delete"))
                    return;
                DataTable selectedOptions = GetSelectedOptions();
                selectedOptions.Rows[e.Item.ItemIndex].Delete();
                rptOptions.DataSource = selectedOptions;
                rptOptions.DataBind();
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

    private DataTable GetSelectedOptions()
    {
        DataTable dataTable = (DataTable)rptOptions.DataSource;
        if (dataTable == null)
        {
            dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("QuestionOptionDesc"));
            dataTable.Columns.Add(new DataColumn("IsCorrect"));
            dataTable.Columns.Add(new DataColumn("QuestionOptionCode"));
            foreach (RepeaterItem repeaterItem in rptOptions.Items)
            {
                DataRow row = dataTable.NewRow();
                row["IsCorrect"] = ((Label)repeaterItem.FindControl("lblIsCorrect")).Text;
                row["QuestionOptionDesc"] = ((Label)repeaterItem.FindControl("lblAnswer")).Text;
                row["QuestionOptionCode"] = (repeaterItem.ItemIndex + 1);
                dataTable.Rows.Add(row);
            }
        }
        return dataTable;
    }

    public void ShowData()
    {
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
                if (dataSet1.Tables[1].Rows.Count > 0)
                {
                    ddlQuestionType.DataSource = dataSet1.Tables[1];
                    ddlQuestionType.DataTextField = "QuestionTypeName";
                    ddlQuestionType.DataValueField = "QuestionTypeCode";
                    ddlQuestionType.DataBind();
                }
            }
            if (QuestionCode <= 0)
                return;
            SqlCommand selectCommand2 = new SqlCommand("XREC_Select_QuestionDetailsByQuestionCode", connection);
            selectCommand2.CommandType = CommandType.StoredProcedure;
            selectCommand2.Parameters.AddWithValue("@QuestionCode", QuestionCode);
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
            DataSet dataSet2 = new DataSet();
            sqlDataAdapter2.Fill(dataSet2);
            if (dataSet2.Tables[0].Rows.Count > 0)
            {
                txtName.Content = dataSet2.Tables[0].Rows[0]["QuestionName"].ToString();
                ddlSection.SelectedValue = dataSet2.Tables[0].Rows[0]["SectionCode"].ToString();
                ddlQuestionType.SelectedValue = dataSet2.Tables[0].Rows[0]["QuestionTypeCode"].ToString();
                txtblank.Text = dataSet2.Tables[0].Rows[0]["QuestionAnswer"].ToString();
                lnkView.InnerText = "View";
                lnkView.HRef = dataSet2.Tables[0].Rows[0]["FileBrowse"].ToString();
                if (dataSet2.Tables[0].Rows[0]["FileBrowse"].ToString() != string.Empty)
                    fuDocument.Style["display"] = "none";
                else
                    lnkView.Style["display"] = "none";
            }
            ShowDivs();
            if (dataSet2.Tables[1].Rows.Count <= 0)
                return;
            rptOptions.DataSource = dataSet2.Tables[1];
            rptOptions.DataBind();
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
        if (!(ddlQuestionType.SelectedValue == "1") && !(ddlQuestionType.SelectedValue == "3"))
            return;
        trBlank.Style["display"] = "none";
        trOption.Style["display"] = "";
        trIsCorrect.Style["display"] = "";
        trAdd.Style["display"] = "";
        trBrowseFile.Style["display"] = "none";
    }
    #endregion

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

}