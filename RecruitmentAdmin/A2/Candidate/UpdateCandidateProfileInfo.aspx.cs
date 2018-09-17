using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using ErrorLog;
using XRecruitmentStatusLibrary;


public partial class A2_Candidate_UpdateCandidateProfileInfo : CustomBasePage
{
    #region Variables
    string TypeCode = "0";
    string oldStatusName = string.Empty, oldProfileName = string.Empty, oldRequisitionName = string.Empty,
        oldCategoryName = string.Empty, oldJoiningDate = string.Empty;
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;
    #endregion

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            secQueryString = new SecureQueryString(QueryStringVar);

            lblMsg.Visible = false;
            try
            {
                CheckQueryString();
                connection.Open();
                //if (TypeCode != "0")
                //{
                BindCandidateData(ref connection);
                //}

            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string rCode = "";
            connection.Open();
            rCode = UpdateCandidateDetail(ref connection);

            Page.RegisterStartupScript("Close", "<script language=JavaScript> CloseHighSlideWithParentRefresh();</script>");

        }
        catch (Exception ex)
        {
            ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();

        }
    }

    #endregion

    #region Methods

    private void CheckQueryString()
    {
        if (secQueryString["type"] != null)
        {
            TypeCode = secQueryString["type"].ToString();
            hdnTypeCode.Value = secQueryString["type"].ToString();
        }

        if (secQueryString["CID"] != null)
        {
            hdnCandidateCode.Value = secQueryString["CID"].ToString();
        }
    }

    private void BindCandidateData(ref SqlConnection connection)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_SelectCandidateDetailForProfileEdit", connection);
        sqlCommand.Parameters.AddWithValue("@Candidate_Code", hdnCandidateCode.Value);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        DataSet ds = new DataSet();
        adapter.Fill(ds);


        ddlGrade.DataSource = ds.Tables[0];
        ddlGrade.DataTextField = "Grade_Name";
        ddlGrade.DataValueField = "Grade_Code";
        ddlGrade.DataBind();
        ddlGrade.Items.Insert(0, new ListItem("--Grade--", "-1"));

        ddlDesignation.DataSource = ds.Tables[1];
        ddlDesignation.DataTextField = "Designation_Name";
        ddlDesignation.DataValueField = "Designation_Code";
        ddlDesignation.DataBind();
        ddlDesignation.Items.Insert(0, new ListItem("--Designation--", "-1"));

        ddlRA.DataSource = ds.Tables[2];
        ddlRA.DataTextField = "RA_Name";
        ddlRA.DataValueField = "RA_Code";
        ddlRA.DataBind();
        ddlRA.Items.Insert(0, new ListItem("--Reporting Authority--", "-1"));

        ddlTL.DataSource = ds.Tables[3];
        ddlTL.DataTextField = "TL_Name";
        ddlTL.DataValueField = "TL_Code";
        ddlTL.DataBind();
        ddlTL.Items.Insert(0, new ListItem("--Team Leader--", "-1"));

        ddlGL.DataSource = ds.Tables[4];
        ddlGL.DataTextField = "GL_Name";
        ddlGL.DataValueField = "GL_Code";
        ddlGL.DataBind();
        ddlGL.Items.Insert(0, new ListItem("--Group Leader--", "-1"));

        ddlBU.DataSource = ds.Tables[5];
        ddlBU.DataTextField = "BU_Name";
        ddlBU.DataValueField = "BU_Code";
        ddlBU.DataBind();
        ddlBU.Items.Insert(0, new ListItem("--BU--", "-1"));

        ddlJD.DataSource = ds.Tables[6];
        ddlJD.DataTextField = "JDName";
        ddlJD.DataValueField = "ID";
        ddlJD.DataBind();
        ddlJD.Items.Insert(0, new ListItem("--Team--", "-1"));

        ddlShift.DataSource = ds.Tables[7];
        ddlShift.DataTextField = "Shift_Name";
        ddlShift.DataValueField = "Shift_Code";
        ddlShift.DataBind();
        ddlShift.Items.Insert(0, new ListItem("--Shift--", "-1"));


        ddlGrade.SelectedValue = ds.Tables[8].Rows[0]["GradeCode"].ToString();
        ddlDesignation.SelectedValue = ds.Tables[8].Rows[0]["DesignationCode"].ToString();
        ddlRA.SelectedValue = ds.Tables[8].Rows[0]["RACode"].ToString();
        ddlTL.SelectedValue = ds.Tables[8].Rows[0]["TeamLeaderCode"].ToString();
        ddlGL.SelectedValue = ds.Tables[8].Rows[0]["GroupLeaderCode"].ToString();
        ddlBU.SelectedValue = ds.Tables[8].Rows[0]["UnitCode"].ToString();
        ddlJD.SelectedValue = ds.Tables[8].Rows[0]["TeamCode"].ToString();
        ddlShift.SelectedValue = ds.Tables[8].Rows[0]["Shift_Code"].ToString();

        if (ds.Tables[8].Rows[0]["Joining_Date"].ToString() == "-")
            JoiningDate.Value = System.DateTime.Now.ToString("MMM dd, yyyy");
        else
            JoiningDate.Value = ds.Tables[8].Rows[0]["Joining_Date"].ToString();

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

    #endregion
}