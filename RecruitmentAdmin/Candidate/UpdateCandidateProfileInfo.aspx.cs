using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ErrorLog;
using System.Configuration;
using System.Web.SessionState;
using System.Data;

public partial class Candidate_UpdateCandidateProfileInfo : CustomBasePage, IRequiresSessionState
{

    public SecureQueryString secQueryString;
    public string TypeCode = "0";
    public string oldStatusName = string.Empty;
    public string oldProfileName = string.Empty;
    public string oldRequisitionName = string.Empty;
    public string oldCategoryName = string.Empty;
    public string oldJoiningDate = string.Empty;
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    public string QueryStringVar = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
        secQueryString = new SecureQueryString(QueryStringVar);
        lblMsg.Visible = false;
        try
        {
            CheckQueryString();
            connection.Open();
            BindCandidateData(ref connection);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            UpdateCandidateDetail(ref connection);
            Page.RegisterStartupScript("Close", "<script language=JavaScript> CloseHighSlideWithParentRefresh();</script>");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    private void CheckQueryString()
    {
        if (secQueryString["type"] != null)
        {
            TypeCode = secQueryString["type"].ToString();
            hdnTypeCode.Value = secQueryString["type"].ToString();
        }
        if (secQueryString["CID"] == null)
            return;
        hdnCandidateCode.Value = secQueryString["CID"].ToString();
    }

    private void BindCandidateData(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDetailForProfileEdit", connection);
        selectCommand.Parameters.AddWithValue("@Candidate_Code", hdnCandidateCode.Value);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        ddlGrade.DataSource = dataSet.Tables[0];
        ddlGrade.DataTextField = "Grade_Name";
        ddlGrade.DataValueField = "Grade_Code";
        ddlGrade.DataBind();
        ddlGrade.Items.Insert(0, new ListItem("--Grade--", "-1"));
        ddlDesignation.DataSource = dataSet.Tables[1];
        ddlDesignation.DataTextField = "Designation_Name";
        ddlDesignation.DataValueField = "Designation_Code";
        ddlDesignation.DataBind();
        ddlDesignation.Items.Insert(0, new ListItem("--Designation--", "-1"));
        ddlRA.DataSource = dataSet.Tables[2];
        ddlRA.DataTextField = "RA_Name";
        ddlRA.DataValueField = "RA_Code";
        ddlRA.DataBind();
        ddlRA.Items.Insert(0, new ListItem("--Reporting Authority--", "-1"));
        ddlTL.DataSource = dataSet.Tables[3];
        ddlTL.DataTextField = "TL_Name";
        ddlTL.DataValueField = "TL_Code";
        ddlTL.DataBind();
        ddlTL.Items.Insert(0, new ListItem("--Team Leader--", "-1"));
        ddlGL.DataSource = dataSet.Tables[4];
        ddlGL.DataTextField = "GL_Name";
        ddlGL.DataValueField = "GL_Code";
        ddlGL.DataBind();
        ddlGL.Items.Insert(0, new ListItem("--Group Leader--", "-1"));
        ddlBU.DataSource = dataSet.Tables[5];
        ddlBU.DataTextField = "BU_Name";
        ddlBU.DataValueField = "BU_Code";
        ddlBU.DataBind();
        ddlBU.Items.Insert(0, new ListItem("--BU--", "-1"));
        ddlJD.DataSource = dataSet.Tables[6];
        ddlJD.DataTextField = "JDName";
        ddlJD.DataValueField = "ID";
        ddlJD.DataBind();
        ddlJD.Items.Insert(0, new ListItem("--Team--", "-1"));
        ddlShift.DataSource = dataSet.Tables[7];
        ddlShift.DataTextField = "Shift_Name";
        ddlShift.DataValueField = "Shift_Code";
        ddlShift.DataBind();
        ddlShift.Items.Insert(0, new ListItem("--Shift--", "-1"));
        ddlGrade.SelectedValue = dataSet.Tables[8].Rows[0]["GradeCode"].ToString();
        ddlDesignation.SelectedValue = dataSet.Tables[8].Rows[0]["DesignationCode"].ToString();
        ddlRA.SelectedValue = dataSet.Tables[8].Rows[0]["RACode"].ToString();
        ddlTL.SelectedValue = dataSet.Tables[8].Rows[0]["TeamLeaderCode"].ToString();
        ddlGL.SelectedValue = dataSet.Tables[8].Rows[0]["GroupLeaderCode"].ToString();
        ddlBU.SelectedValue = dataSet.Tables[8].Rows[0]["UnitCode"].ToString();
        ddlJD.SelectedValue = dataSet.Tables[8].Rows[0]["TeamCode"].ToString();
        ddlShift.SelectedValue = dataSet.Tables[8].Rows[0]["Shift_Code"].ToString();
        if (dataSet.Tables[8].Rows[0]["Joining_Date"].ToString() == "-")
            JoiningDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
        else
            JoiningDate.Value = dataSet.Tables[8].Rows[0]["Joining_Date"].ToString();
    }

    private string UpdateCandidateDetail(ref SqlConnection connection)
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
        SqlCommand sqlCommand = new SqlCommand("XREC_Update_CandidateProfileInfo", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@Joining_Date", JoiningDate.Value);
        sqlCommand.Parameters.AddWithValue("@Grade_Code", ddlGrade.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@Designation_Code", ddlDesignation.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@RA_Code", ddlRA.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@DeptHeadUser_Code", ddlGL.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@DeptTeamLeader", ddlTL.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@BU_Code", ddlBU.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@TeamCode", ddlJD.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@Shift_Code", ddlShift.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", USERIP);
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        sqlCommand.Parameters.AddWithValue("@Candidate_Code", hdnCandidateCode.Value);
        return Convert.ToString(sqlCommand.ExecuteNonQuery());
    }
}