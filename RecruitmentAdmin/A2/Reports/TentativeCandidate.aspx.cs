using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using ErrorLog;
using System.Configuration;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;


public partial class A2_Reports_TentativeCandidate : CustomBasePage, IRequiresSessionState
{

    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    private SecureQueryString sQString = new SecureQueryString();
    private int totalCount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            if (IsPostBack)
                return;
            postedFromDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            postedToDate.Value = DateTime.Now.AddDays(1.0).ToString("MMM dd, yyyy");
            BindData();
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
            SqlCommand selectCommand = new SqlCommand("dbo.XRECT_Select_TentativeJoiningData", connection);
            selectCommand.Parameters.Add("@DateFrom", SqlDbType.VarChar).Value = postedFromDate.Value;
            selectCommand.Parameters.Add("@DateTo", SqlDbType.VarChar).Value = postedToDate.Value;
            selectCommand.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = txtref.Text;
            selectCommand.Parameters.AddWithValue("@Is_SupportStaff", rdoSupportStaff.Checked ? "1" : "0");
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                rptCanddiate.DataSource = dataSet.Tables[0];
                rptCanddiate.DataBind();
                lblError.Style.Add("display", "none");
            }
            else
            {
                rptCanddiate.DataSource = null;
                rptCanddiate.DataBind();
                lblError.Style.Add("display", "");
            }
            if (dataSet.Tables[1].Rows.Count > 0)
            {
                rptDepartment.DataSource = dataSet.Tables[1];
                rptDepartment.DataBind();
                dv.Style["display"] = "";
            }
            else
            {
                rptDepartment.DataSource = null;
                rptDepartment.DataBind();
                dv.Style["display"] = "none";
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

    protected void rptDepartment_OnDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                totalCount = totalCount + int.Parse(DataBinder.Eval(e.Item.DataItem, "Count").ToString());
            if (e.Item.ItemType != ListItemType.Footer)
                return;
            ((Label)e.Item.FindControl("lblTotalCount")).Text = totalCount.ToString();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        DataTable table = new DataTable();
        table.Columns.Add("Sr. No", typeof(int));
        table.Columns.Add("Ref. No.", typeof(string));
        table.Columns.Add("Name", typeof(string));
        table.Columns.Add("Designations", typeof(string));
        table.Columns.Add("Domain", typeof(string));
        table.Columns.Add("Location", typeof(string));
        table.Columns.Add("Shift", typeof(string));
        table.Columns.Add("Assigned to", typeof(string));
        int count = 0;
        try
        {
            connection.Open();
            for (int index = 0; index <= rptCanddiate.Items.Count - 1; ++index)
            {
                if (((CheckBox)rptCanddiate.Items[index].FindControl("chkRows")).Checked)
                {
                    HiddenField control1 = (HiddenField)rptCanddiate.Items[index].FindControl("hdnCandidate_ID");
                    HiddenField control2 = (HiddenField)rptCanddiate.Items[index].FindControl("hdnFull_Name");
                    HiddenField control3 = (HiddenField)rptCanddiate.Items[index].FindControl("hdnDesignation");
                    HiddenField control4 = (HiddenField)rptCanddiate.Items[index].FindControl("hdnCandidateDepartment");
                    HiddenField control5 = (HiddenField)rptCanddiate.Items[index].FindControl("hdnCity");
                    HiddenField control6 = (HiddenField)rptCanddiate.Items[index].FindControl("hdnShift");
                    HiddenField control7 = (HiddenField)rptCanddiate.Items[index].FindControl("hdnAssignTo");
                    ++count;
                    table.Rows.Add(count, control1.Value, control2.Value, control3.Value, control4.Value, control5.Value, control6.Value, control7.Value);
                    InsertTentativeJoiningEmailData(count, control1.Value, control2.Value, control3.Value, control4.Value, control5.Value, control6.Value, control7.Value, Convert.ToDateTime(postedFromDate.Value), ref connection);
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            connection.Close();
        }
        if (new DataView(table).ToTable(true, "Domain").Rows.Count <= 0)
            return;
        ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Email will be sent soon!');", true);
    }

    private void UpdateTentativeJoiningEmailDataStatus(string TentativeJoiningEmailData_Code, SqlConnection sqlconn)
    {
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XREC_Update_TentativeJoiningEmailData", sqlconn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@TentativeJoiningEmailData_Code", TentativeJoiningEmailData_Code);
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            connection.Close();
        }
    }

    private void InsertTentativeJoiningEmailData(int count, string RefNo, string Name, string Designation, string Domain, string Location, string Shift, string Assignedto, DateTime FromDate, ref SqlConnection connection)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.XREC_Insert_TentativeJoiningEmailData", connection);
        sqlCommand.Parameters.Add("@SrNo", SqlDbType.Int).Value = count;
        sqlCommand.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = RefNo;
        sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
        sqlCommand.Parameters.Add("@Designation", SqlDbType.VarChar).Value = Designation;
        sqlCommand.Parameters.Add("@Domain", SqlDbType.VarChar).Value = Domain;
        sqlCommand.Parameters.Add("@Location", SqlDbType.VarChar).Value = Location;
        sqlCommand.Parameters.Add("@Shift", SqlDbType.VarChar).Value = Shift;
        sqlCommand.Parameters.Add("@Assignedto", SqlDbType.VarChar).Value = Assignedto;
        sqlCommand.Parameters.Add("@postedFromDate", SqlDbType.DateTime).Value = FromDate;
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.ExecuteNonQuery();
    }

    protected void rdoOfficer_CheckedChanged(object sender, EventArgs e)
    {
        BindData();
    }

    protected void rdoSupportStaff_CheckedChanged(object sender, EventArgs e)
    {
        BindData();
    }
}