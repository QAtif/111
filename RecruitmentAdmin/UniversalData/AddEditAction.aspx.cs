using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ErrorLog;

public partial class UniversalData_AddEditAction : CustomBasePage
{
    #region Variables
    string ActionCode = "0";
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
        lblMsg.Visible = false;
        QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
        if (QueryStringVar != null)
            secQueryString = new SecureQueryString(QueryStringVar);
        try
        {
            CheckQueryString();
            connection.Open();
            BindUserType(ref connection);
            if (!(ActionCode != "0"))
                return;
            BindRequisition(ref connection);
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

    private void BindUserType(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectAllUserTypeByAction", connection);
        selectCommand.Parameters.AddWithValue("@ActionCode", ActionCode);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        chblUserType.DataSource = dataSet.Tables[0];
        chblUserType.DataValueField = "UserType_Code";
        chblUserType.DataTextField = "UserType";
        chblUserType.DataBind();
        foreach (DataRow row in (InternalDataCollectionBase)dataSet.Tables[0].Rows)
        {
            foreach (ListItem listItem in chblUserType.Items)
            {
                if (listItem.Value == row["UserType_Code"].ToString())
                    listItem.Selected = row["IsMark"].ToString() == "1";
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            string ActionCode = InsertRole(ref connection);
            if (ActionCode != null && ActionCode != "" && ActionCode != "0")
            {
                foreach (ListItem listItem in chblUserType.Items)
                {
                    if (listItem.Selected)
                        InsertUserType(ActionCode, listItem.Value);
                }
                foreach (ListItem listItem in chblUserType.Items)
                {
                    if (!listItem.Selected)
                        removeActionUserType(ActionCode, listItem.Value);
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

    private void removeActionUserType(string ActionCode, string UserTypeCode)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_DeleteActionUserType", connection);
        sqlCommand.Parameters.AddWithValue("@ActionCode", ActionCode);
        sqlCommand.Parameters.AddWithValue("@UserTypeCode", UserTypeCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedIP", Request.UserHostAddress.ToString());
        sqlCommand.CommandType = CommandType.StoredProcedure;
        Convert.ToString(sqlCommand.ExecuteScalar());
    }

    private void InsertUserType(string ActionCode, string UserTypeCode)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_InsertActionUserType", connection);
        sqlCommand.Parameters.AddWithValue("@ActionCode", ActionCode);
        sqlCommand.Parameters.AddWithValue("@UserTypeCode", UserTypeCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedIP", Request.UserHostAddress.ToString());
        sqlCommand.CommandType = CommandType.StoredProcedure;
        Convert.ToString(sqlCommand.ExecuteScalar());
    }

    private void BindRequisition(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectActionByCode", connection);
        selectCommand.Parameters.AddWithValue("@ActionCode", hdnActionCode.Value);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        txtActionName.Text = dataSet.Tables[0].Rows[0]["Action"].ToString();
        btnAdd.Text = "Update Action";
        lblHead.Text = "Edit Action";
    }

    private void CheckQueryString()
    {
        if (secQueryString == null || secQueryString["ActionCode"] == null)
            return;
        ActionCode = secQueryString["ActionCode"].ToString();
        hdnActionCode.Value = secQueryString["ActionCode"].ToString();
    }

    private string InsertRole(ref SqlConnection connection)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Insert_Update_Action", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@ActionName", txtActionName.Text);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        sqlCommand.Parameters.AddWithValue("@ActionCode", hdnActionCode.Value);
        return Convert.ToString(sqlCommand.ExecuteScalar());
    }
    #endregion


}