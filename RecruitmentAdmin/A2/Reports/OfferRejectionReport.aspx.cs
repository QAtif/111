using System;
using System.Web.UI;
using ErrorLog;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;



public partial class A2_Reports_OfferRejectionReport : CustomBasePage, IRequiresSessionState
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
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable offerRejectionData = GetOfferRejectionData();
            if (offerRejectionData.Rows.Count > 0)
            {
                rptOfferRejection.DataSource = offerRejectionData;
                rptOfferRejection.DataBind();
                lblError.Style.Add("display", "none");
            }
            else
            {
                rptOfferRejection.DataSource = null;
                rptOfferRejection.DataBind();
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
        SqlCommand selectCommand = new SqlCommand("dbo.Select_offerRejectionData", connection);
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
        DataTable offerRejectionData = GetOfferRejectionData();
        if (offerRejectionData.Rows.Count <= 0)
            return;
        ExportToSpreadsheet(offerRejectionData, "@E:\\products\\Record.xlsx");
    }

    public void ExportToSpreadsheet(DataTable table, string FileNameWithPath)
    {
        if (table.Rows.Count <= 0)
            return;
        string str1 = "attachment; filename=offer-Rejection-Report.xls";
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