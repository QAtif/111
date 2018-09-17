using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ErrorLog;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;



public partial class A2_Reports_RequisitionReport : CustomBasePage, IRequiresSessionState
{

    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    public string UpdatedBy;
    public string UpdatedIP;
    public DataTable dtCplc;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
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
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                ddlCategory.DataSource = dataSet;
                ddlCategory.DataTextField = "Category_Name";
                ddlCategory.DataValueField = "Category_Code";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("Select Category", "-1"));
            }
            else
            {
                ddlCategory.Items.Clear();
                ddlCategory.Items.Insert(0, new ListItem("Select Category", "-1"));
            }
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
        if (dataSet.Tables.Count >= 2)
        {
            ddlRequisitionStatus.DataSource = dataSet.Tables[1];
            ddlRequisitionStatus.DataTextField = "Status_name";
            ddlRequisitionStatus.DataValueField = "Status_Code";
            ddlRequisitionStatus.DataBind();
        }
        if (dataSet.Tables.Count >= 3)
        {
            ddlApprovalStatus.DataSource = dataSet.Tables[2];
            ddlApprovalStatus.DataTextField = "RequisitionStatus_Name";
            ddlApprovalStatus.DataValueField = "RequisitionStatus_Code";
            ddlApprovalStatus.DataBind();
        }
        ddlRequisitionStatus.Items.Insert(0, new ListItem(" Select Status ", "-1"));
        ddlDepartment.Items.Insert(0, new ListItem(" Select Department ", "-1"));
        ddlCategory.Items.Insert(0, new ListItem("Select Category", "-1"));
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
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    public DataTable GetRequisitionData()
    {
        SqlCommand selectCommand = new SqlCommand("dbo.Select_RequisitionReportData", connection);
        if (ddlDepartment.SelectedValue != "-1")
            selectCommand.Parameters.Add("@Department", SqlDbType.VarChar).Value = ddlDepartment.SelectedValue;
        if (ddlRequisitionStatus.SelectedValue != "-1")
            selectCommand.Parameters.Add("@RequisitionFillStatus", SqlDbType.VarChar).Value = ddlRequisitionStatus.SelectedValue;
        selectCommand.Parameters.Add("@RequisitionStatus", SqlDbType.VarChar).Value = ddlApprovalStatus.SelectedValue;
        if (ddlCategory.SelectedValue != "-1")
            selectCommand.Parameters.Add("@Category", SqlDbType.VarChar).Value = ddlCategory.SelectedValue;
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
}