using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ErrorLog;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.HtmlControls;
using AjaxControlToolkit;

public partial class A2_Reports_InterviewAudioAudit : CustomBasePage, IRequiresSessionState
{
    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    public string UpdatedBy;
    public string UpdatedIP;
    public DataTable dtCplc;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            UpdatedBy = UserCode.ToString();
            UpdatedIP = USERIP.ToString();
            if (IsPostBack)
                return;
            postedFromDate.Value = DateTime.Now.AddMonths(-1).ToString("MMM dd, yyyy");
            postedToDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            bindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptCanddiate_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HtmlImage control1 = (HtmlImage)e.Item.FindControl("imgDone");
            TextBox control2 = (TextBox)e.Item.FindControl("txtComments");
            DataRowView dataItem = e.Item.DataItem as DataRowView;
            HtmlAnchor control3 = (HtmlAnchor)e.Item.FindControl("asave");
            control3.Attributes.Add("onclick", "InsertOfferAudioComments(" + dataItem["Candidate_Code"].ToString() + ",'" + dataItem["CandDoc_Code"].ToString() + "','" + control2.ClientID + "','" + control3.ClientID + "','" + control1.ClientID + "')");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void ddlDepartment_OnChange(object sender, EventArgs e)
    {
        try
        {
            if (!(ddlDepartment.SelectedValue != ""))
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand selectCommand = new SqlCommand("XRec_SelectCategoryOnDomain", connection);
            selectCommand.Parameters.AddWithValue("@domain_Code", ddlDepartment.SelectedValue);
            selectCommand.CommandType = CommandType.StoredProcedure;
            new SqlDataAdapter(selectCommand).Fill(new DataSet());
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

    protected void OnRatingChanged(object sender, RatingEventArgs e)
    {
        Rating rating = (Rating)sender;
        string str = e.Value;
        string tag = rating.Tag;
        string backImageUrl = rating.BackImageUrl;
        if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(backImageUrl) || string.IsNullOrEmpty(tag))
            return;
        using (SqlCommand sqlCommand = new SqlCommand("UpdateOfferAudioRating", connection))
        {
            using (new SqlDataAdapter())
            {
                sqlCommand.Parameters.AddWithValue("@CandDoc_Code", backImageUrl);
                sqlCommand.Parameters.AddWithValue("@Rating", str);
                sqlCommand.Parameters.AddWithValue("@Candidate_Code", tag);
                sqlCommand.Parameters.AddWithValue("@Updated_By", UpdatedBy);
                sqlCommand.Parameters.AddWithValue("@Updated_IP", UpdatedIP);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }
    }

    public void bindData()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_SelectDomainAndReqstatus", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet == null)
            return;
        if (dataSet.Tables.Count >= 1)
        {
            ddlDepartment.DataSource = dataSet.Tables[0];
            ddlDepartment.DataTextField = "Domain_Name";
            ddlDepartment.DataValueField = "Domain_Code";
            ddlDepartment.DataBind();
        }
        ddlDepartment.Items.Insert(0, new ListItem(" Select Department ", "-1"));
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable requisitionData = GetRequisitionData();
            if (requisitionData.Rows.Count > 0)
            {
                rptCanddiate.DataSource = requisitionData;
                rptCanddiate.DataBind();
                lblError.Style.Add("display", "none");
            }
            else
            {
                rptCanddiate.DataSource = null;
                rptCanddiate.DataBind();
                lblError.Style.Add("display", "");
            }
            ShowHideActions();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    public DataTable GetRequisitionData()
    {
        SqlCommand selectCommand = new SqlCommand("dbo.Select_CandidateInterviewAudio", connection);
        if (ddlDepartment.SelectedValue != "-1")
            selectCommand.Parameters.Add("@Department", SqlDbType.VarChar).Value = ddlDepartment.SelectedValue;
        if (!string.IsNullOrEmpty(postedFromDate.Value))
            selectCommand.Parameters.Add("@StartDate", SqlDbType.Date).Value = postedFromDate.Value;
        if (!string.IsNullOrEmpty(postedToDate.Value))
            selectCommand.Parameters.Add("@EndDate", SqlDbType.Date).Value = postedToDate.Value;
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        return dataTable;
    }

    protected void imgExcel_Click(object sender, EventArgs e)
    {
        DataTable dataTable = new DataTable();
        DataTable requisitionData = GetRequisitionData();
        if (requisitionData.Rows.Count <= 0)
            return;
        ExportToSpreadsheet(requisitionData, "@E:\\products\\Record.xlsx");
    }

    public void ExportToSpreadsheet(DataTable table, string FileNameWithPath)
    {
        if (table.Rows.Count <= 0)
            return;
        string str1 = "attachment; filename=RequisitionReportData.xls";
        Page.Response.ClearContent();
        Response.AddHeader("content-disposition", str1);
        Response.ContentType = "application/vnd.ms-excel";
        string str2 = "";
        foreach (DataColumn column in (InternalDataCollectionBase)table.Columns)
        {
            if (column.ColumnName != "requisition_code")
            {
                Response.Write(str2 + column.ColumnName);
                str2 = "\t";
            }
        }
        Response.Write("\n");
        foreach (DataRow row in (InternalDataCollectionBase)table.Rows)
        {
            string str3 = "";
            for (int index = 0; index < table.Columns.Count; ++index)
            {
                if (table.Columns[index].ColumnName != "requisition_code")
                {
                    Response.Write(str3 + row[index].ToString());
                    str3 = "\t";
                }
            }
            Response.Write("\n");
        }
        Response.End();
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

    [WebMethod]
    public static void InsertOfferAudioComments(string items)
    {
        string[] strArray = new string[0];
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
            strArray = items.Split('|');
            if (((IEnumerable<string>)strArray).Count<string>() < 5)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("Insert_OfferAudioComments", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Candidate_Code", strArray[0].ToString());
            sqlCommand.Parameters.AddWithValue("@CandDoc_Code", strArray[1].ToString());
            sqlCommand.Parameters.AddWithValue("@Comments", strArray[2].ToString());
            sqlCommand.Parameters.AddWithValue("@Updated_By", strArray[3].ToString());
            sqlCommand.Parameters.AddWithValue("@Updated_IP", strArray[4].ToString());
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