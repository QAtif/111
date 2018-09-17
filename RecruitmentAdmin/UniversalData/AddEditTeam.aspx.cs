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

public partial class UniversalData_AddEditTeam : CustomBasePage
{
    #region Variables
    string TeamCode = "0";
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
        if (QueryStringVar != null)
            secQueryString = new SecureQueryString(QueryStringVar);
        lblMsg.Visible = false;
        try
        {
            CheckQueryString();
            connection.Open();
            if (TeamCode != "0")
                BindRequisition(ref connection);
            BindUsers();
            BindDomain();
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

    private void BindDomain()
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectAllDomainByTeam", connection);
        selectCommand.Parameters.AddWithValue("@TeamCode", hdnTeamCode.Value);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        chblistDomain.DataSource = dataSet;
        chblistDomain.DataTextField = "Domain_Name";
        chblistDomain.DataValueField = "Domain_Code";
        chblistDomain.DataBind();
        foreach (DataRow row in (InternalDataCollectionBase)dataSet.Tables[0].Rows)
        {
            foreach (ListItem listItem in chblistDomain.Items)
            {
                if (listItem.Value == row["Domain_Code"].ToString())
                    listItem.Selected = row["IsMark"].ToString() == "1";
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            string str1 = InsertRole(ref connection);
            if (str1 != null && str1 != "" && str1 != "0")
            {
                string str2 = hfUsers.Value;
                InsertTeamUsers(str1, ref connection);
                foreach (ListItem listItem in chblistDomain.Items)
                {
                    if (listItem.Selected)
                        InsertUserDomain(str1, listItem.Value);
                }
                foreach (ListItem listItem in chblistDomain.Items)
                {
                    if (!listItem.Selected)
                        removeDomainUserAssociation(str1, listItem.Value);
                }
                lblMsg.Text = "Successfully Saved!";
                lblMsg.Visible = true;
            }
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            Page.RegisterStartupScript("Close", "<script language=JavaScript> CloseHighSlideWithParentRefresh();</script>");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private void removeDomainUserAssociation(string TeamCode, string DomainID)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_DeleteDomainTeamRights", connection);
        sqlCommand.Parameters.AddWithValue("@DomainID", DomainID);
        sqlCommand.Parameters.AddWithValue("@UserID", TeamCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedIP", Request.UserHostAddress.ToString());
        sqlCommand.CommandType = CommandType.StoredProcedure;
        Convert.ToString(sqlCommand.ExecuteScalar());
    }

    private void InsertUserDomain(string TeamID, string DomainCode)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_InsertDomainUserRights", connection);
        sqlCommand.Parameters.AddWithValue("@DomainID", DomainCode);
        sqlCommand.Parameters.AddWithValue("@UserID", TeamID);
        sqlCommand.Parameters.AddWithValue("@TeamUserTypeCode", 2);
        sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedIP", Request.UserHostAddress.ToString());
        sqlCommand.CommandType = CommandType.StoredProcedure;
        Convert.ToString(sqlCommand.ExecuteScalar());
    }

    private void BindRequisition(ref SqlConnection connection)
    {
        SqlCommand selectCommand1 = new SqlCommand("XRec_SelectTeamByCode", connection);
        selectCommand1.Parameters.AddWithValue("@TeamCode", TeamCode);
        selectCommand1.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(selectCommand1);
        DataSet dataSet1 = new DataSet();
        sqlDataAdapter1.Fill(dataSet1);
        if (dataSet1.Tables[0].Rows.Count > 0)
        {
            txtTeamName.Text = dataSet1.Tables[0].Rows[0]["TeamName"].ToString();
            btnAdd.Text = "Update Team";
            lblHead.Text = "Edit Team";
        }
        SqlCommand selectCommand2 = new SqlCommand("XRec_SelectUsersMarked", connection);
        selectCommand2.Parameters.AddWithValue("@TeamCode", TeamCode);
        selectCommand2.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
        DataSet dataSet2 = new DataSet();
        sqlDataAdapter2.Fill(dataSet2);
        if (dataSet2.Tables[0].Rows.Count <= 0)
            return;
        lbUsersMark.DataSource = dataSet2.Tables[0];
        lbUsersMark.DataBind();
    }

    private void BindUsers()
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectUsersNotMarked", connection);
        selectCommand.Parameters.AddWithValue("@TeamCode", TeamCode);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        lbUsersNotMark.DataSource = dataSet.Tables[0];
        lbUsersNotMark.DataBind();
    }

    private void CheckQueryString()
    {
        if (secQueryString == null || secQueryString["TeamCode"] == null)
            return;
        TeamCode = secQueryString["TeamCode"].ToString();
        hdnTeamCode.Value = secQueryString["TeamCode"].ToString();
    }

    private string InsertTeamUsers(string TeamCode, ref SqlConnection connection)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Insert_Update_TeamUsers", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@TeamCode", TeamCode);
        sqlCommand.Parameters.AddWithValue("@UserCodeCSV", hfUsers.Value);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        return Convert.ToString(sqlCommand.ExecuteScalar());
    }

    private string InsertRole(ref SqlConnection connection)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Insert_Update_Team", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@TeamName", txtTeamName.Text);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        sqlCommand.Parameters.AddWithValue("@TeamCode", hdnTeamCode.Value);
        return Convert.ToString(sqlCommand.ExecuteScalar());
    }
    #endregion

}