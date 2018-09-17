using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.HtmlControls;
using ErrorLog;
using System.Web.Services;
using System.Web.SessionState;

public partial class Assessment : CustomBasePage, IRequiresSessionState
{

    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SecureQueryString secQueryString = new SecureQueryString();
    string QueryStringVar = string.Empty;
    public string UpdatedBy;
    public string UpdatedIP;
    public string TestCode;
    public string CandidateCode;
    public string StatusCode;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            UpdatedBy = UserCode.ToString();
            UpdatedIP = USERIP.ToString();
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            secQueryString = new SecureQueryString(QueryStringVar);
            if (secQueryString["CC"] == null || secQueryString["TC"] == null || (string.IsNullOrEmpty(secQueryString["CC"].ToString()) || string.IsNullOrEmpty(secQueryString["TC"].ToString())))
                return;
            CandidateCode = secQueryString["CC"].ToString();
            TestCode = secQueryString["TC"].ToString();
            postedToDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            if (IsPostBack)
                return;
            bindData();
            ShowHideActions();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void btnSave_Onclick(object sender, EventArgs e)
    {
        try
        {
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            secQueryString = new SecureQueryString(QueryStringVar);
            if (secQueryString["CC"] == null || secQueryString["TC"] == null || (string.IsNullOrEmpty(secQueryString["CC"].ToString()) || string.IsNullOrEmpty(secQueryString["TC"].ToString())))
                return;
            CandidateCode = secQueryString["CC"].ToString();
            TestCode = secQueryString["TC"].ToString();
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Insert_StaffCandidateTest", connection);
            sqlCommand.Parameters.Add("@Candidate_Code", SqlDbType.Int).Value = CandidateCode;
            sqlCommand.Parameters.Add("@TestCode", SqlDbType.Int).Value = TestCode;
            sqlCommand.Parameters.Add("@TrailDate", SqlDbType.Date).Value = postedToDate.Value;
            sqlCommand.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UserCode;
            sqlCommand.Parameters.Add("@updatedIp", SqlDbType.VarChar).Value = USERIP;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            divMsg.Style.Add("display", "");
            lblMsg.Text = "Test has been save successfully.";
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    public void bindData()
    {
        try
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand selectCommand1 = new SqlCommand("dbo.Select_StaffCandidateForTest", connection);
            selectCommand1.Parameters.Add("@Candidate_Code", SqlDbType.Int).Value = CandidateCode;
            selectCommand1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(selectCommand1);
            DataTable dataTable = new DataTable();
            sqlDataAdapter1.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                txtCandidateName.Text = dataTable.Rows[0]["Full_Name"].ToString();
                txtDepartmentName.Text = dataTable.Rows[0]["Department"].ToString();
                txtPosition.Text = dataTable.Rows[0]["Position"].ToString();
                postedToDate.Value = Convert.ToDateTime(dataTable.Rows[0]["StaffrailDate"].ToString()).ToString("MMM dd, yyyy");
                StatusCode = dataTable.Rows[0]["Status_Code"].ToString();
                if (StatusCode != "1140")
                    btnSave.Attributes.Add("disabled", "disabled");
                else
                    btnSave.Attributes.Remove("disabled");
            }
            SqlCommand selectCommand2 = new SqlCommand("dbo.select_StaffTestHead", connection);
            selectCommand2.Parameters.Add("@TestCode", SqlDbType.Int).Value = TestCode;
            selectCommand2.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
            DataSet dataSet = new DataSet();
            sqlDataAdapter2.Fill(dataSet);
            if (dataSet.Tables.Count >= 1)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    RptStaffTestHead.DataSource = dataSet.Tables[0];
                    RptStaffTestHead.DataBind();
                }
                else
                {
                    RptStaffTestHead.DataSource = null;
                    RptStaffTestHead.DataBind();
                }
            }
            if (dataSet.Tables.Count >= 2)
                SpTestName.InnerText = dataSet.Tables[1].Rows[0]["TestName"].ToString();
            else
                SpTestName.InnerText = "Staff ";
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void RptStaffTestHead_onDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnTestHEadCode");
            DataList control2 = (DataList)e.Item.FindControl("rptStaffHeadDetail");
            SqlCommand selectCommand = new SqlCommand("dbo.select_StaffHeadDetail", connection);
            selectCommand.Parameters.Add("@TestHead_Code", SqlDbType.Int).Value = control1.Value;
            selectCommand.Parameters.Add("@Candidate_Code", SqlDbType.Int).Value = CandidateCode;
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                control2.DataSource = dataTable;
                control2.DataBind();
            }
            else
            {
                control2.DataSource = null;
                control2.DataBind();
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
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

    protected void rptStaffHeadDetail_onDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            DataRowView dataItem = e.Item.DataItem as DataRowView;
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnHeadDetailCode");
            HtmlInputCheckBox control2 = (HtmlInputCheckBox)e.Item.FindControl("chkHeadDetail");
            if (StatusCode != "1140")
                control2.Attributes.Add("disabled", "disabled");
            else
                control2.Attributes.Remove("disabled");
            control2.Attributes.Add("onchange", "Insert_StaffResult(" + CandidateCode + "," + control1.Value + ",'" + control2.ClientID + "')");
            if (dataItem["IsChecked"].ToString() == "True")
                control2.Attributes.Add("checked", "checked");
            else
                control2.Attributes.Remove("checked");
            Repeater control3 = (Repeater)e.Item.FindControl("rptstaffEvaluation");
            SqlCommand selectCommand = new SqlCommand("dbo.select_staffEvaluation", connection);
            selectCommand.Parameters.Add("@TestHead_Code", SqlDbType.Int).Value = control1.Value;
            selectCommand.Parameters.Add("@Candidate_Code", SqlDbType.Int).Value = CandidateCode;
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                control3.DataSource = dataTable;
                control3.DataBind();
            }
            else
            {
                control3.DataSource = null;
                control3.DataBind();
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptstaffEvaluation_onDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            DataRowView dataItem = e.Item.DataItem as DataRowView;
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnEvaluationCode");
            HtmlInputCheckBox control2 = (HtmlInputCheckBox)e.Item.FindControl("chkEvaluationCode");
            if (StatusCode != "1140")
                control2.Attributes.Add("disabled", "disabled");
            else
                control2.Attributes.Remove("disabled");
            control2.Attributes.Add("onchange", "Insert_StaffResultEvaluation(" + CandidateCode + "," + control1.Value + ",'" + control2.ClientID + "')");
            if (dataItem["IsChecked"].ToString() == "True")
                control2.Attributes.Add("checked", "checked");
            else
                control2.Attributes.Remove("checked");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    [WebMethod]
    public static void Insert_StaffResult(string items)
    {
        string[] strArray = new string[0];
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
            strArray = items.Split('|');
            if (((IEnumerable<string>)strArray).Count<string>() < 6)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("Insert_StaffResult", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Candidate_Code", strArray[0].ToString());
            sqlCommand.Parameters.AddWithValue("@HeadDetail_Code", strArray[1].ToString());
            sqlCommand.Parameters.AddWithValue("@TestCode", strArray[2].ToString());
            sqlCommand.Parameters.AddWithValue("@Is_Checked", strArray[3].ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", strArray[4].ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedIP", strArray[5].ToString());
            sqlCommand.ExecuteScalar();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            if (((IEnumerable<string>)strArray).Count<string>() >= 3)
                LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, strArray[3].ToString());
            else
                LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, "0");
        }
    }

    [WebMethod]
    public static void Insert_StaffResultEvaluation(string items)
    {
        string[] strArray = new string[0];
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
            strArray = items.Split('|');
            if (((IEnumerable<string>)strArray).Count<string>() < 6)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("Insert_StaffResultEvaluation", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Candidate_Code", strArray[0].ToString());
            sqlCommand.Parameters.AddWithValue("@Evaluation_Code", strArray[1].ToString());
            sqlCommand.Parameters.AddWithValue("@TestCode", strArray[2].ToString());
            sqlCommand.Parameters.AddWithValue("@Is_Checked", strArray[3].ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", strArray[4].ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedIP", strArray[5].ToString());
            sqlCommand.ExecuteScalar();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            if (((IEnumerable<string>)strArray).Count<string>() >= 3)
                LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, strArray[3].ToString());
            else
                LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, "0");
        }
    }

}