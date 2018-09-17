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



public partial class A2_Reports_RecruiterPerformanceReport : CustomBasePage, IRequiresSessionState
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
        SqlCommand selectCommand = new SqlCommand("[XRec_SelectRecruiterPerformanceReport]", connection);
        selectCommand.Parameters.AddWithValue("@DateFrom", postedFromDate.Value);
        selectCommand.Parameters.AddWithValue("@DateTo", postedToDate.Value);
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
            LinkButton lnkExport = (LinkButton)e.Item.FindControl("lnkExport");
            Label lblMsg = (Label)e.Item.FindControl("lblMsg");

            //Hide Export to Excel on Zero
            DataView defaultViewMain = ds.Tables[0].DefaultView;
            defaultViewMain.RowFilter = "UserID=" + control2.Value.ToString();
            if (defaultViewMain != null)
                if (defaultViewMain.Table.Rows[e.Item.ItemIndex]["TotalScheduleCount"].ToString() == "0")
                    lnkExport.Style.Add("display", "none");
            defaultViewMain.Dispose();
            // Bind Detail 
            if (ds.Tables.Count > 0)
                if (ds.Tables[1].Rows.Count > 0)
                {
                    DataView defaultView = ds.Tables[1].DefaultView;
                    defaultView.RowFilter = "UserID=" + control2.Value.ToString();
                    if (defaultView != null)
                        if (defaultView.Count > 0)
                        {
                            control1.DataSource = defaultView;
                            control1.DataBind();
                        }
                        else
                            lblMsg.Visible = true;
                }
                else
                    lblMsg.Visible = true;
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

    private DataTable GetTotalData(int UserID)
    {
        DataTable dataTable = new DataTable();
        SqlCommand selectCommand = new SqlCommand("XRec_SelectRecruiterPerformanceDetail", connection);
        selectCommand.Parameters.AddWithValue("@DateFrom", postedFromDate.Value);
        selectCommand.Parameters.AddWithValue("@DateTo", postedToDate.Value);
        selectCommand.Parameters.AddWithValue("@UserID", UserID);
        selectCommand.CommandType = CommandType.StoredProcedure;
        new SqlDataAdapter(selectCommand).Fill(dataTable);
        return dataTable;
    }

    public void ExportToSpreadsheet(DataTable table, string FileNameWithPath)
    {

        if (table.Rows.Count <= 0)
            return;
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.Clear();
        string fileName = "ProductivityHeadCountCandidateDetail_" + DateTime.Now.ToString("MMddyyyy") + ".xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        string str2 = "";
        foreach (DataColumn column in (InternalDataCollectionBase)table.Columns)
        {
            //if (column.ColumnName != "requisition_code")
            //{
            string colname = str2 + column.ColumnName;
            Response.Write(colname);
            str2 = "\t";
            //}
        }
        Response.Write("\n");
        foreach (DataRow row in (InternalDataCollectionBase)table.Rows)
        {
            string str3 = "";
            for (int index = 0; index < table.Columns.Count; ++index)
            {
                //if (table.Columns[index].ColumnName != "requisition_code")
                //{
                string rowname = str3 + row[index].ToString();
                Response.Write(rowname);
                str3 = "\t";
                // }
            }
            Response.Write("\n");
        }
        Response.End();
    }
}