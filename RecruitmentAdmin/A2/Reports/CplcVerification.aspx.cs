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
using XRecruitmentStatusLibrary;
using ErrorLog;
using System.Web.Services;
using System.Web.SessionState;

public partial class CplcVerification : CustomBasePage, IRequiresSessionState
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    public string UpdatedBy, UpdatedIP;
    public DataTable dtCplc;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            UpdatedBy = UserCode.ToString();
            UpdatedIP = USERIP.ToString();
            if (connection.State != ConnectionState.Open)
                connection.Open();
            dtCplc = new DataTable();
            SqlCommand selectCommand = new SqlCommand("dbo.Select_AllCPLCStatus", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            new SqlDataAdapter(selectCommand).Fill(dtCplc);
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            if (IsPostBack)
                return;
            postedFromDate.Value = DateTime.Now.AddMonths(-1).ToString("MMM dd, yyyy");
            postedToDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            if (connection.State != ConnectionState.Open)
                connection.Open();
            BindData();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
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
            SqlCommand selectCommand = new SqlCommand("dbo.Select_CandidateForCPLCVerfication", connection);
            if (!string.IsNullOrEmpty(txtName.Text))
                selectCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtName.Text;
            if (!string.IsNullOrEmpty(txtref.Text))
                selectCommand.Parameters.Add("@ReferenceNo", SqlDbType.VarChar).Value = txtref.Text;
            if (!string.IsNullOrEmpty(postedFromDate.Value))
                selectCommand.Parameters.Add("@DateFrom", SqlDbType.Date).Value = postedFromDate.Value;
            if (!string.IsNullOrEmpty(postedToDate.Value))
                selectCommand.Parameters.Add("@DateTo", SqlDbType.Date).Value = postedToDate.Value;
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                rptCanddiate.DataSource = dataTable;
                rptCanddiate.DataBind();
                lblError.Style.Add("display", "none");
                ShowHideActions();
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

    public DataTable GetCandidateForCPLCVerifiction()
    {
        SqlCommand selectCommand = new SqlCommand("dbo.Select_CandidateForCPLCVerfication", connection);
        if (!string.IsNullOrEmpty(txtName.Text))
            selectCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtName.Text;
        if (!string.IsNullOrEmpty(txtref.Text))
            selectCommand.Parameters.Add("@ReferenceNo", SqlDbType.VarChar).Value = txtref.Text;
        if (!string.IsNullOrEmpty(postedFromDate.Value))
            selectCommand.Parameters.Add("@DateFrom", SqlDbType.Date).Value = postedFromDate.Value;
        if (!string.IsNullOrEmpty(postedToDate.Value))
            selectCommand.Parameters.Add("@DateTo", SqlDbType.Date).Value = postedToDate.Value;
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        return dataTable;
    }

    private void BindData()
    {
        try
        {
            DataTable forCplcVerifiction = GetCandidateForCPLCVerifiction();
            if (forCplcVerifiction.Rows.Count > 0)
            {
                rptCanddiate.DataSource = forCplcVerifiction;
                rptCanddiate.DataBind();
                ShowHideActions();
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

    protected void rptCanddiate_OnDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HtmlImage control1 = (HtmlImage)e.Item.FindControl("imgDone");
            DropDownList control2 = (DropDownList)e.Item.FindControl("ddlCplcStatus");
            TextBox control3 = (TextBox)e.Item.FindControl("txtCPLCComents");
            DataRowView dataItem = e.Item.DataItem as DataRowView;
            HtmlAnchor control4 = (HtmlAnchor)e.Item.FindControl("asave");
            if (dtCplc != null && dtCplc.Rows.Count > 0)
            {
                control2.Items.Clear();
                control2.DataSource = dtCplc;
                control2.DataTextField = "CplcStatus_Name";
                control2.DataValueField = "CPLCStatus_ID";
                control2.DataBind();
                control2.Items.Insert(0, new ListItem("N/A", "0"));
            }
            control2.SelectedValue = dataItem["CPLCStatus"].ToString();
            control4.Attributes.Add("onclick", "InsertCplcVerification(" + dataItem["Candidate_Code"].ToString() + ",'" + control2.ClientID + "','" + control3.ClientID + "','" + control4.ClientID + "','" + control1.ClientID + "')");
            if (dataItem["IsExsist"].ToString() == "")
                control1.Style.Add("display", "none");
            else
                control1.Style.Add("display", "");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptDocuments_ItemDatabound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HtmlAnchor control1 = (HtmlAnchor)e.Item.FindControl("aMarkPrinted");
            HtmlAnchor control2 = (HtmlAnchor)e.Item.FindControl("aUnMarkPrinted");
            DataRowView dataItem = e.Item.DataItem as DataRowView;
            control1.Attributes.Add("onclick", "UpdateDocPrintingStatus(" + dataItem["CandDoc_Code"] + ",1,'" + control1.ClientID + "','" + control2.ClientID + "')");
            control2.Attributes.Add("onclick", "UpdateDocPrintingStatus(" + dataItem["CandDoc_Code"] + ",0,'" + control2.ClientID + "','" + control1.ClientID + "')");
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

    [WebMethod]
    public static void InsertCplcVerification(string items)
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
            SqlCommand sqlCommand = new SqlCommand("Insert_InsertCplcVerification", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@CandidateCode", strArray[0].ToString());
            sqlCommand.Parameters.AddWithValue("@CPLCStatus", strArray[1].ToString());
            sqlCommand.Parameters.AddWithValue("@CPLCComents", strArray[2].ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", strArray[3].ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedIp", strArray[4].ToString());
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

    protected void imgExcel_Click(object sender, EventArgs e)
    {
        DataTable dataTable = new DataTable();
        DataTable forCplcVerifiction = GetCandidateForCPLCVerifiction();
        if (forCplcVerifiction.Rows.Count <= 0)
            return;
        ExportToSpreadsheet(forCplcVerifiction, "@E:\\products\\Record.xlsx");
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