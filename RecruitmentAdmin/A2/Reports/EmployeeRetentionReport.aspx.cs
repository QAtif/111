using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using ErrorLog;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class A2_Reports_EmployeeRetentionReport : CustomBasePage
{
    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);


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

    public void bindData()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_SelectDomain", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet == null)
            return;
        if (dataSet.Tables.Count > 0)
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
            SqlCommand selectCommand = new SqlCommand("dbo.Select_EmployeeRetentionReportData", connection);
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
            if (dataTable.Rows.Count > 0)
            {
                rptCanddiate.DataSource = dataTable;
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

    protected void imgExcel_Click(object sender, EventArgs e)
    {
        DataTable table = new DataTable();
        if (table.Rows.Count <= 0)
            return;
        ExportToSpreadsheet(table, "@E:\\products\\Record.xlsx");
    }

    public void ExportToSpreadsheet(DataTable table, string FileNameWithPath)
    {
        if (table.Rows.Count <= 0)
            return;
        string str1 = "attachment; filename=CPLCVerificationSheet.xls";
        Page.Response.ClearContent();
        Response.AddHeader("content-disposition", str1);
        Response.ContentType = "application/vnd.ms-excel";
        string str2 = "";
        foreach (DataColumn column in (InternalDataCollectionBase)table.Columns)
        {
            if (column.ColumnName != "IsExsist" && column.ColumnName != "CPLCStatus" && column.ColumnName != "Candidate_Code")
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
                if (table.Columns[index].ColumnName != "IsExsist" && table.Columns[index].ColumnName != "CPLCStatus" && table.Columns[index].ColumnName != "Candidate_Code")
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