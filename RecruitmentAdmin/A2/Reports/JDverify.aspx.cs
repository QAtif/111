using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using ErrorLog;
using System.Configuration;


public partial class A2_Reports_JDverify : CustomBasePage, IRequiresSessionState
{
    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    public string UpdatedBy;
    public string UpdatedIP;
    public DataTable dtCplc;

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ddlDepartment_OnChange(object sender, EventArgs e)
    {
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
        DataTable dataTable = new DataTable();
        try
        {
            SqlCommand selectCommand = new SqlCommand("dbo.Select_Candidate_JDverify", connection);
            if (!string.IsNullOrEmpty(txtbxName.Text))
                selectCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtbxName.Text;
            if (!string.IsNullOrEmpty(txtbxEmail.Text))
                selectCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtbxEmail.Text;
            if (!string.IsNullOrEmpty(txtbxRefNo.Text))
                selectCommand.Parameters.Add("@refNum", SqlDbType.VarChar).Value = txtbxRefNo.Text;
            if (!string.IsNullOrEmpty(txtbxUserCode.Text))
                selectCommand.Parameters.Add("@PortalID", SqlDbType.Int).Value = int.Parse(txtbxUserCode.Text);
            selectCommand.CommandType = CommandType.StoredProcedure;
            new SqlDataAdapter(selectCommand).Fill(dataTable);
            return dataTable;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            return dataTable;
        }
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
        string str1 = "attachment; filename=JDverificationReportData.xls";
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