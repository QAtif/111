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


public partial class Candidate_UpdateCandidateInfo : CustomBasePage
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
        if (IsPostBack)
            return;
        QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
        secQueryString = new SecureQueryString(QueryStringVar);
        lblMsg.Visible = false;
        try
        {
            CheckQueryString();
            connection.Open();
            BindData();
            if (!(TypeCode != "0"))
                return;
            ShowHideColumn();
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
            string str = UpdateCandidateDetail(ref connection);
            if (hdnTypeCode.Value.ToString() == "2" && str != null && (str != "" && str != "0"))
                StatusManagement.MarkLifeCycleStatus(connection, int.Parse(hdnCandidateCode.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.PositionMappedWaitingforPositionopening, USERIP, UserCode);
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
        SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateInfo", connection);
        selectCommand.Parameters.AddWithValue("@CandidateCode", hdnCandidateCode.Value);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        ddlStatus.SelectedValue = dataSet.Tables[0].Rows[0]["Status_Code"].ToString();
        ddlProfile.SelectedValue = dataSet.Tables[0].Rows[0]["Profile_Code"].ToString();
        ddlRequisition.SelectedValue = dataSet.Tables[0].Rows[0]["Requisition_Code"].ToString();
    }

    private void BindData()
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectOgData", connection);
        selectCommand.Parameters.AddWithValue("@CandidateCode", hdnCandidateCode.Value);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            ddlStatus.DataSource = dataSet.Tables[0];
            ddlStatus.DataTextField = "Status_Name";
            ddlStatus.DataValueField = "Status_Code";
            ddlStatus.DataBind();
        }
        if (dataSet.Tables[1].Rows.Count > 0)
        {
            ddlProfile.DataSource = dataSet.Tables[1];
            ddlProfile.DataTextField = "Profile_Name";
            ddlProfile.DataValueField = "Profile_Code";
            ddlProfile.DataBind();
        }
        if (dataSet.Tables[2].Rows.Count <= 0)
            return;
        ddlRequisition.DataSource = dataSet.Tables[2];
        ddlRequisition.DataTextField = "Requisition_Name";
        ddlRequisition.DataValueField = "Requisition_Code";
        ddlRequisition.DataBind();
    }

    private void ShowHideColumn()
    {
        if (hdnTypeCode.Value == "1")
        {
            lblHead.Text = "Update Status";
            trStatus.Visible = true;
            trProfile.Visible = false;
            trRequisition.Visible = false;
            btnAdd.Text = "Update Status";
        }
        else if (hdnTypeCode.Value == "2")
        {
            lblHead.Text = "Update Profile";
            trStatus.Visible = false;
            trProfile.Visible = true;
            trRequisition.Visible = false;
            btnAdd.Text = "Update Profile";
        }
        else
        {
            if (!(hdnTypeCode.Value == "3"))
                return;
            lblHead.Text = "Update Requisition";
            trStatus.Visible = false;
            trProfile.Visible = false;
            trRequisition.Visible = true;
            btnAdd.Text = "Update Requisition";
        }
    }

    private string UpdateCandidateDetail(ref SqlConnection connection)
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
        SqlCommand sqlCommand = new SqlCommand("XREC_Update_CandidateInfo", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@Type", hdnTypeCode.Value);
        sqlCommand.Parameters.AddWithValue("@StatusCode", ddlStatus.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@StatusName", ddlStatus.SelectedItem.Text);
        sqlCommand.Parameters.AddWithValue("@ProfileCode", ddlProfile.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@ProfileName", ddlProfile.SelectedItem.Text);
        if (hdnTypeCode.Value == "3")
        {
            sqlCommand.Parameters.AddWithValue("@RequisitionCode", ddlRequisition.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@RequisitionName", ddlRequisition.SelectedItem.Text);
        }
        sqlCommand.Parameters.AddWithValue("@Comments", txtComments.Text);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", USERIP);
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        sqlCommand.Parameters.AddWithValue("@Candidate_Code", hdnCandidateCode.Value);
        return Convert.ToString(sqlCommand.ExecuteNonQuery());
    }

    #endregion
}