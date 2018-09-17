
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using ErrorLog;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using XRecruitmentStatusLibrary;



public partial class Reports_ResultPendingMarkStatus : CustomBasePage
{
    public static DataView objDV = new DataView();
    public static string SortDirection = "DESC";
    SecureQueryString sQString = new SecureQueryString();
    PagedDataSource objPDS = new PagedDataSource();
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    public static int PageSize;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            postedFromDate.Attributes.Add("readonly", "readonly");
            postedFromDate.Value = DateTime.Now.AddDays(-7.0).ToString("MMM dd, yyyy");
            postedToDate.Attributes.Add("readonly", "readonly");
            postedToDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            BindData();
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

    protected void rptCandidateLists_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnCandidateCode");
            string str1 = "../assessment/checktest.aspx?cid=" + control1.Value;
            HtmlAnchor control2 = (HtmlAnchor)e.Item.FindControl("a1");
            if (control1 == null)
                return;
            string str2 = "../../A2/candidate/CandidateProfile.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + control1.Value);
            control2.HRef = str2;
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

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        if (!IsValid)
            return;
        try
        {
            GetCandidateDetail();
            ShowHideActions();
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

    private void ShowHideActions()
    {
        IEnumerable<HtmlGenericControl> allControlsOfType = Page.GetAllControlsOfType<HtmlGenericControl>();
        foreach (DataRow row in (InternalDataCollectionBase)DTActions.Rows)
        {
            foreach (Control control in allControlsOfType)
            {
                if (control.ClientID == "divAction" + row["MenuLinkActionCode"].ToString())
                    control.Visible = true;
            }
        }
    }

    private void BindData()
    {
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_Select_AllData", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            ddlrequisition.DataSource = dataSet.Tables[0];
            ddlrequisition.DataTextField = "Requisition_Name";
            ddlrequisition.DataValueField = "Requisition_Code";
            ddlrequisition.DataBind();
            ddlrequisition.Items.Insert(0, new ListItem("----All----", "0"));
        }
        if (dataSet.Tables[1].Rows.Count > 0)
        {
            ddlDepartment.DataSource = dataSet.Tables[1];
            ddlDepartment.DataTextField = "SubDomain_Name";
            ddlDepartment.DataValueField = "SubDomain_Code";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("----All----", "0"));
        }
        if (dataSet.Tables[2].Rows.Count <= 0)
            return;
        ddlStatus.DataSource = dataSet.Tables[2];
        ddlStatus.DataTextField = "Status_Name";
        ddlStatus.DataValueField = "Status_Code";
        ddlStatus.DataBind();
    }

    public void GetCandidateDetail()
    {
        SqlCommand selectCommand = new SqlCommand("dbo.Xrec_Select_CandidateInterviewTestAction", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        if (!string.IsNullOrEmpty(txtCandidateName.Text))
            selectCommand.Parameters.Add("@CandidateName", SqlDbType.VarChar).Value = txtCandidateName.Text;
        if (!string.IsNullOrEmpty(txtRefNo.Text))
            selectCommand.Parameters.AddWithValue("@ReferenceNo", txtRefNo.Text);
        if (ddlrequisition.SelectedIndex != 0)
            selectCommand.Parameters.AddWithValue("@requisitionCode", ddlrequisition.SelectedValue);
        if (!string.IsNullOrEmpty(txtEmail.Text))
            selectCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
        if (!string.IsNullOrEmpty(txtNIC.Text))
            selectCommand.Parameters.AddWithValue("@nic", txtNIC.Text);
        if (ddlDepartment.SelectedIndex != 0)
            selectCommand.Parameters.AddWithValue("@departmentCode", ddlDepartment.SelectedValue);
        selectCommand.Parameters.AddWithValue("@Status_Code", ddlStatus.SelectedValue);
        selectCommand.Parameters.AddWithValue("@DateFrom", postedFromDate.Value);
        selectCommand.Parameters.AddWithValue("@DateTo", postedToDate.Value);
        DataTable dataTable = new DataTable();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables.Count == 0)
            return;
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            DataTable table = dataSet.Tables[0];
            rptCandidateLists.Visible = true;
            lblMsg.Visible = false;
            objDV = table.DefaultView;
            rptCandidateLists.DataSource = table;
            rptCandidateLists.DataBind();
        }
        else
        {
            rptCandidateLists.DataSource = null;
            rptCandidateLists.Visible = false;
            lblMsg.Text = "No record(s) found";
            lblMsg.Visible = true;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            for (int index = 0; index <= rptCandidateLists.Items.Count - 1; ++index)
            {
                if (((CheckBox)rptCandidateLists.Items[index].FindControl("chkSelect")).Checked)
                {
                    HiddenField control1 = (HiddenField)rptCandidateLists.Items[index].FindControl("hdnStatus");
                    HiddenField control2 = (HiddenField)rptCandidateLists.Items[index].FindControl("hdnCandidateCode");
                    if (control1.Value == "1155")
                    {
                        if (ddlTestResult.SelectedValue == "1")
                            StatusManagement.MarkLifeCycleStatus(connection, int.Parse(control2.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.InterviewDoneOfferGenerated, Request.UserHostAddress.ToString(), UserCode);
                        else
                            StatusManagement.MarkLifeCycleStatus(connection, int.Parse(control2.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.InterviewFailedReSchedulingPending, Request.UserHostAddress.ToString(), UserCode);
                        InsertUserInterviewComments(int.Parse(control2.Value), ddlTestResult.SelectedValue == "1", txtComments.Text, Convert.ToInt32((Constants.CandidateLifeCycleStatus)(ddlTestResult.SelectedValue == "1" ? 1155 : 1170)));
                    }
                    if (control1.Value == "1100")
                    {
                        if (ddlTestResult.SelectedValue == "1")
                            StatusManagement.MarkLifeCycleStatus(connection, int.Parse(control2.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.TestPassedSchedulingPendingInterview, Request.UserHostAddress.ToString(), UserCode);
                        else
                            StatusManagement.MarkLifeCycleStatus(connection, int.Parse(control2.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.TestFailedReSchedulingPendingTest, Request.UserHostAddress.ToString(), UserCode);
                        InsertUserInterviewComments(int.Parse(control2.Value), ddlTestResult.SelectedValue == "1", txtComments.Text, Convert.ToInt32((Constants.CandidateLifeCycleStatus)(ddlTestResult.SelectedValue == "1" ? 1110 : 1130)));
                    }
                }
            }
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "alert('Result Saved Successfully!');", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            connection.Close();
            lnkSearch_Click(null, (EventArgs)null);
        }
    }

    private void InsertUserInterviewComments(int CandidateCode, bool result, string comments, int lifeCycleStatusCode)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateInterviewResult", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(CandidateCode);
        sqlCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = UserCode;
        sqlCommand.Parameters.Add("@IsPassOrFail", SqlDbType.Bit).Value = result;
        sqlCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = comments;
        sqlCommand.Parameters.Add("@LifeCycleStatus", SqlDbType.Int).Value = lifeCycleStatusCode;
        sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = UserCode;
        sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = USERIP;
        sqlCommand.ExecuteNonQuery();
    }
}