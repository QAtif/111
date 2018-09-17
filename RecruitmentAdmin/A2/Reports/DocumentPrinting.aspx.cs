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

public partial class DocumentPrinting : CustomBasePage, IRequiresSessionState
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    public string UpdatedBy;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            UpdatedBy = UserCode.ToString();
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
            SqlCommand selectCommand = new SqlCommand("dbo.Select_CandidateDocumentForPrinting", connection);
            if (!string.IsNullOrEmpty(txtName.Text))
                selectCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtName.Text;
            if (!string.IsNullOrEmpty(txtref.Text))
                selectCommand.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = txtref.Text;
            if (ddlDepartment.SelectedValue != "-1")
                selectCommand.Parameters.Add("@DepCode", SqlDbType.Int).Value = ddlDepartment.SelectedValue;
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

    private void BindData()
    {
        try
        {
            SqlCommand selectCommand1 = new SqlCommand("dbo.Select_CandidateDocumentForPrinting", connection);
            if (!string.IsNullOrEmpty(postedFromDate.Value))
                selectCommand1.Parameters.Add("@DateFrom", SqlDbType.Date).Value = postedFromDate.Value;
            if (!string.IsNullOrEmpty(postedToDate.Value))
                selectCommand1.Parameters.Add("@DateTo", SqlDbType.Date).Value = postedToDate.Value;
            selectCommand1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(selectCommand1);
            DataTable dataTable1 = new DataTable();
            sqlDataAdapter1.Fill(dataTable1);
            if (dataTable1.Rows.Count > 0)
            {
                rptCanddiate.DataSource = dataTable1;
                rptCanddiate.DataBind();
            }
            else
            {
                rptCanddiate.DataSource = null;
                rptCanddiate.DataBind();
                lblError.Style.Add("display", "");
            }
            SqlCommand selectCommand2 = new SqlCommand("dbo.XRec_SelectAllDomainCode", connection);
            selectCommand2.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
            DataTable dataTable2 = new DataTable();
            sqlDataAdapter2.Fill(dataTable2);
            if (dataTable2.Rows.Count <= 0)
                return;
            ddlDepartment.DataSource = dataTable2;
            ddlDepartment.DataTextField = "dept_name";
            ddlDepartment.DataValueField = "dept_code";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem(" All ", "-1"));
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
            Repeater control1 = (Repeater)e.Item.FindControl("rptDocuments");
            HiddenField control2 = (HiddenField)e.Item.FindControl("HdnCandidateCode");
            SqlCommand selectCommand = new SqlCommand("dbo.Select_DocumentForPrinting", connection);
            selectCommand.Parameters.Add("@Candidate_Code", SqlDbType.Int).Value = control2.Value;
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count <= 0)
                return;
            control1.DataSource = dataTable;
            control1.DataBind();
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

    [WebMethod]
    public static void UpdateDocPrintingStatus(string items)
    {
        string[] strArray = new string[0];
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
            strArray = items.Split('|');
            if (((IEnumerable<string>)strArray).Count<string>() < 3)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("update_DocumentPrintingStatus", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@CandDocCode", strArray[0].ToString());
            sqlCommand.Parameters.AddWithValue("@PrintedBy", strArray[1].ToString());
            sqlCommand.Parameters.AddWithValue("@isPrinted", strArray[2].ToString());
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