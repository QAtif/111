using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.UI;
using System.Web.UI.WebControls;
using ErrorLog;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;





public partial class A2_Reports_StaffSignupReport : CustomBasePage, IRequiresSessionState
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
            binddata();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    public void binddata()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
        SqlCommand selectCommand = new SqlCommand("dbo.Select_StaffDomain", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (connection.State != ConnectionState.Closed)
            connection.Close();
        if (dataSet != null && dataSet.Tables.Count >= 1 && dataSet.Tables[0].Rows.Count > 0)
        {
            ddlDept.DataSource = dataSet.Tables[0];
            ddlDept.DataTextField = "Domain_Name";
            ddlDept.DataValueField = "Domain_Code";
            ddlDept.DataBind();
        }
        if (dataSet.Tables.Count >= 2 && dataSet.Tables[1].Rows.Count > 0)
        {
            ddlUsers.DataSource = dataSet.Tables[1];
            ddlUsers.DataTextField = "name";
            ddlUsers.DataValueField = "Userid";
            ddlUsers.DataBind();
        }
        ddlDept.Items.Insert(0, new ListItem("Department", "-1"));
        ddlUsers.Items.Insert(0, new ListItem("Created By", "-1"));
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable offerRejectionData = GetOfferRejectionData();
            if (offerRejectionData.Rows.Count > 0)
            {
                rptstaffsignup.DataSource = offerRejectionData;
                rptstaffsignup.DataBind();
                lblError.Style.Add("display", "none");
            }
            else
            {
                rptstaffsignup.DataSource = null;
                rptstaffsignup.DataBind();
                lblError.Style.Add("display", "");
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    public DataTable GetOfferRejectionData()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
        SqlCommand selectCommand = new SqlCommand("dbo.Select_StaffsignupReport", connection);
        if (!string.IsNullOrEmpty(postedFromDate.Value))
            selectCommand.Parameters.Add("@FromDate", SqlDbType.Date).Value = postedFromDate.Value;
        if (!string.IsNullOrEmpty(postedToDate.Value))
            selectCommand.Parameters.Add("@ToDate", SqlDbType.Date).Value = postedToDate.Value;
        if (ddlDept.SelectedValue != "-1")
            selectCommand.Parameters.Add("@Department", SqlDbType.Int).Value = ddlDept.SelectedValue;
        if (ddlUsers.SelectedValue != "-1")
            selectCommand.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = ddlUsers.SelectedValue;
        if (!string.IsNullOrEmpty(txtReferenceNo.Text))
            selectCommand.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = txtReferenceNo.Text;
        if (!string.IsNullOrEmpty(txtName.Text))
            selectCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtName.Text;
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        if (connection.State != ConnectionState.Closed)
            connection.Close();
        return dataTable;
    }

    protected void imgExcel_Click(object sender, EventArgs e)
    {
        DataTable dataTable = new DataTable();
        DataTable offerRejectionData = GetOfferRejectionData();
        if (offerRejectionData.Rows.Count <= 0)
            return;
        ExportToSpreadsheet(offerRejectionData, "@E:\\products\\Record.xlsx");
    }

    public void ExportToSpreadsheet(DataTable table, string FileNameWithPath)
    {
        if (table.Rows.Count <= 0)
            return;
        string str1 = "attachment; filename=Staff-SignUp-Report.xls";
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