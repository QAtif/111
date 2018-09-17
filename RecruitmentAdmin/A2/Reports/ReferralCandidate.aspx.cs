using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.HtmlControls;
using ErrorLog;
using System.Web.SessionState;


public partial class ReferralCandidate : CustomBasePage, IRequiresSessionState
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    public string UpdatedBy;
    SecureQueryString sQString = new SecureQueryString();
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
            bindfields();
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void bindfields()
    {
        try
        {
            SqlCommand selectCommand = new SqlCommand("dbo.Select_RefferdReportData", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet == null)
                return;
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                ddlDomain.DataSource = dataSet.Tables[0];
                ddlDomain.DataValueField = "code";
                ddlDomain.DataTextField = "name";
                ddlDomain.DataBind();
                ddlDomain.Items.Insert(0, new ListItem(" Select Domain ", "0"));
            }
            else
            {
                ddlDomain.DataSource = null;
                ddlDomain.DataBind();
            }
            if (dataSet.Tables[1].Rows.Count > 0)
            {
                ddlUsers.DataSource = dataSet.Tables[1];
                ddlUsers.DataValueField = "code";
                ddlUsers.DataTextField = "name";
                ddlUsers.DataBind();
                ddlUsers.Items.Insert(0, new ListItem(" Select Group Leader ", "0"));
            }
            else
            {
                ddlUsers.DataSource = null;
                ddlUsers.DataBind();
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }

    private void BindData()
    {
        try
        {
            DataTable dataTable = new DataTable();
            DataTable referraldata = GetReferraldata();
            if (referraldata.Rows.Count > 0)
            {
                rptCanddiate.DataSource = referraldata;
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

    protected void rptCanddiate_OnDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnCandCode");
            HtmlAnchor control2 = (HtmlAnchor)e.Item.FindControl("aCandidateLink");
            if (control1 == null)
                return;
            string str = "../../A2/candidate/CandidateProfile.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + control1.Value);
            control2.HRef = str;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    public DataTable GetReferraldata()
    {
        DataTable dataTable = new DataTable();
        try
        {
            SqlCommand selectCommand = new SqlCommand("dbo.XRECT_Select_ReferralDetaila", connection);
            selectCommand.Parameters.Add("@DateFrom", SqlDbType.VarChar).Value = postedFromDate.Value;
            selectCommand.Parameters.Add("@DateTo", SqlDbType.VarChar).Value = postedToDate.Value;
            selectCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtName.Text;
            selectCommand.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = txtref.Text;
            selectCommand.Parameters.Add("@AxactianName", SqlDbType.VarChar).Value = txtAxactian.Text;
            if (ddlDomain.SelectedValue != "0")
                selectCommand.Parameters.Add("@DomainCode", SqlDbType.Int).Value = Convert.ToInt32(ddlDomain.SelectedValue);
            if (ddlUsers.SelectedValue != "0")
                selectCommand.Parameters.Add("@UCode", SqlDbType.Int).Value = Convert.ToInt32(ddlUsers.SelectedValue);
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
        DataTable referraldata = GetReferraldata();
        if (referraldata.Rows.Count <= 0)
            return;
        ExportToSpreadsheet(referraldata, "@E:\\products\\Record.xlsx");
    }

    public void ExportToSpreadsheet(DataTable table, string FileNameWithPath)
    {
        if (table.Rows.Count <= 0)
            return;
        string str1 = "attachment; filename=Refferred-Candidate-Data.xls";
        Page.Response.ClearContent();
        Response.AddHeader("content-disposition", str1);
        Response.ContentType = "application/vnd.ms-excel";
        string str2 = "";
        foreach (DataColumn column in (InternalDataCollectionBase)table.Columns)
        {
            if (column.ColumnName != "Candidate_Code" && column.ColumnName != "gl_id")
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
                if (table.Columns[index].ColumnName != "Candidate_Code" && table.Columns[index].ColumnName != "gl_id")
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