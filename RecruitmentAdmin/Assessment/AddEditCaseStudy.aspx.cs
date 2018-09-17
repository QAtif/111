using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Configuration;
using System.Web.UI.HtmlControls;
using ErrorLog;

public partial class AddEditCaseStudy : CustomBasePage//XRecBase
{
    #region Variables
     SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    int QuestionGroupCode = 0;
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            if (Request.QueryString != null && Request.QueryString["qgid"] != null && (Request.QueryString != null && Request.QueryString["qgid"] != null))
            {
                if (Request.QueryString["qgid"].ToString() != "")
                {
                    QuestionGroupCode = Convert.ToInt32(Request.QueryString["qgid"].ToString());
                    ViewState["qgid"] = Request.QueryString["qgid"].ToString();
                }
            }
            else
                this.QuestionGroupCode = 0;
            this.ShowData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string empty = string.Empty;
            string path = string.Empty;
            if (fuDocument.HasFile)
            {
                path = "\\Documents\\" + (DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + this.fuDocument.FileName);
                if (!Directory.Exists(Server.MapPath("/Documents/")))
                    Directory.CreateDirectory(Server.MapPath("/Documents/"));
                fuDocument.SaveAs(this.Server.MapPath(path));
            }
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XREC_Insert_Update_CaseStudy", this.connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@QuestionGroupName", txtName.Text);
            selectCommand.Parameters.AddWithValue("@QuestionGroupDetails", txtCaseStudy.Content);
            selectCommand.Parameters.AddWithValue("@SectionCode", ddlSection.SelectedValue);
            selectCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
            selectCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
            if (QuestionGroupCode == 0 && ViewState["qgid"] == null)
                selectCommand.Parameters.AddWithValue("@QuestionGroupCode", 0);
            else if (ViewState["qgid"] != null && Request.QueryString["qgid"] != "" && Request.QueryString["qgid"] != string.Empty)
                selectCommand.Parameters.AddWithValue("@QuestionGroupCode", Convert.ToInt32(Request.QueryString["qgid"]));
            selectCommand.Parameters.AddWithValue("@FileBrowse", path);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count <= 0)
                return;
            btnAdd.Style["display"] = "";
            btnAdd.HRef = "QuestionGroupAddEditQuestion.aspx?qgid=" + dataTable.Rows[0]["QuestionGroupCode"].ToString() + "&sid=" + ddlSection.SelectedValue;
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

    protected void rptOptions_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item)
        {
            if (e.Item.ItemType != ListItemType.AlternatingItem)
                return;
        }
        try
        {
            ((HtmlAnchor)e.Item.FindControl("lnkQuestion")).HRef = "AddEditQuestion.aspx?qid=" + DataBinder.Eval(e.Item.DataItem, "QuestionCode").ToString();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptOptions_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (Request.QueryString["qgid"] == null || !(Request.QueryString["qgid"].ToString() != "") || !(e.CommandName == "Delete"))
                return;
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XRec_Delete_Question", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@QuestionCode", e.CommandArgument);
            sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
            sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
            sqlCommand.ExecuteNonQuery();
            DataSet dataSet1 = new DataSet();
            SqlCommand selectCommand = new SqlCommand("XREC_Select_QuestionGroupDetailsByQuestionCode", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@QuestionGroupCode", Request["qgid"].ToString());
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet2 = new DataSet();
            sqlDataAdapter.Fill(dataSet2);
            if (dataSet2.Tables[0].Rows.Count > 0)
            {
                txtName.Text = dataSet2.Tables[0].Rows[0]["QuestionGroupName"].ToString();
                ddlSection.SelectedValue = dataSet2.Tables[0].Rows[0]["SectionCode"].ToString();
                txtCaseStudy.Content = dataSet2.Tables[0].Rows[0]["QuestionGroupDetails"].ToString();
                btnAdd.Style["display"] = "";
                btnAdd.HRef = "QuestionGroupAddEditQuestion.aspx?qgid=" + dataSet2.Tables[0].Rows[0]["QuestionGroupCode"].ToString() + "&sid=" + ddlSection.SelectedValue;
            }
            if (dataSet2.Tables[1].Rows.Count <= 0)
                return;
            SearchCategoryOptions2.Style["display"] = "";
            rptOptions.DataSource = (object)dataSet2.Tables[1];
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
            if (dataSet1 != null && dataSet1.Tables[0].Rows.Count > 0)
            {
                ddlSection.DataSource = dataSet1.Tables[0];
                ddlSection.DataTextField = "SectionName";
                ddlSection.DataValueField = "SectionCode";
                ddlSection.DataBind();
            }
            if (this.QuestionGroupCode <= 0)
                return;
            SqlCommand selectCommand2 = new SqlCommand("XREC_Select_QuestionGroupDetailsByQuestionCode", connection);
            selectCommand2.CommandType = CommandType.StoredProcedure;
            selectCommand2.Parameters.AddWithValue("@QuestionGroupCode", (object)this.QuestionGroupCode);
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
            DataSet dataSet2 = new DataSet();
            sqlDataAdapter2.Fill(dataSet2);
            if (dataSet2.Tables[0].Rows.Count > 0)
            {
                txtName.Text = dataSet2.Tables[0].Rows[0]["QuestionGroupName"].ToString();
                ddlSection.SelectedValue = dataSet2.Tables[0].Rows[0]["SectionCode"].ToString();
                txtCaseStudy.Content = dataSet2.Tables[0].Rows[0]["QuestionGroupDetails"].ToString();
                btnAdd.Style["display"] = "";
                btnAdd.HRef = "QuestionGroupAddEditQuestion.aspx?qgid=" + dataSet2.Tables[0].Rows[0]["QuestionGroupCode"].ToString() + "&sid=" + this.ddlSection.SelectedValue;
            }
            ShowDivs();
            if (dataSet2.Tables[1].Rows.Count <= 0)
                return;
            SearchCategoryOptions2.Style["display"] = "";
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
            foreach (RepeaterItem repeaterItem in this.rptOptions.Items)
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