using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using ErrorLog;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Profile;
using System.Web.UI.HtmlControls;



public partial class A2_Reports_ProductivityHeadCount : CustomBasePage, IRequiresSessionState
{

    public string UserCode1 = string.Empty;
    public string UserTypeCode = string.Empty;
    public string updateByIP = string.Empty;
    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    private DataSet ds = new DataSet();


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            postedToDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            postedFromDate.Value = DateTime.Now.AddMonths(-1).ToString("MMM dd, yyyy");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void btnSearch_Onclick(object sender, EventArgs e)
    {
        try
        {
            BindData();
            imgLoadingF.Style.Add("display", "none");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private void BindData()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
        SqlCommand selectCommand = new SqlCommand("select_ProductivityReportData", connection);
        selectCommand.Parameters.AddWithValue("@StartDate", postedFromDate.Value);
        selectCommand.Parameters.AddWithValue("@EndDate", postedToDate.Value);
        selectCommand.CommandType = CommandType.StoredProcedure;
        new SqlDataAdapter(selectCommand).Fill(ds);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            rptDeparments.DataSource = ds.Tables[0];
            rptDeparments.DataBind();
        }
        if (connection.State == ConnectionState.Closed)
            return;
        connection.Close();
    }

    protected void rptDeparments_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            Repeater control1 = (Repeater)e.Item.FindControl("RptDeptHired");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnUserId");
            DataView defaultView = ds.Tables[1].DefaultView;
            defaultView.RowFilter = "UserId=" + control2.Value.ToString();
            control1.DataSource = defaultView;
            control1.DataBind();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptDeparments_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "Export"))
            return;
        DataTable dataTable = new DataTable();
        DataTable totalData = GetTotalData(int.Parse(e.CommandArgument.ToString()));
        if (totalData.Rows.Count <= 0)
            return;
        ExportToSpreadsheet(totalData, "@E:\\products\\ProductivityHeadCount.xlsx");
    }

    private DataTable GetTotalData(int userCode)
    {
        DataTable dataTable = new DataTable();
        SqlCommand selectCommand = new SqlCommand("select_ProductivityReportDataDetail", connection);
        selectCommand.Parameters.AddWithValue("@StartDate", postedFromDate.Value);
        selectCommand.Parameters.AddWithValue("@EndDate", postedToDate.Value);
        selectCommand.Parameters.AddWithValue("@UserID", userCode);
        selectCommand.CommandType = CommandType.StoredProcedure;
        new SqlDataAdapter(selectCommand).Fill(dataTable);
        return dataTable;
    }

    public void ExportToSpreadsheet(DataTable table, string FileNameWithPath)
    {
        if (table.Rows.Count <= 0)
            return;
        string str1 = "attachment; filename=ProductivityHeadCount.xls";
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