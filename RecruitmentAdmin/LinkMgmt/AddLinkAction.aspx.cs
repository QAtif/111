
using ErrorLog;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;


public partial class UniversalData_AddLinkAction : CustomBasePage
{
    #region Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    string MenuLinkCode = "0";
    #endregion

    #region Paging Variables
    static DataView objDV = new DataView();
    static int PageSize;
    static string SortDirection = "DESC";
    SecureQueryString sQString = new SecureQueryString();
    PagedDataSource objPDS = new System.Web.UI.WebControls.PagedDataSource();
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
        trActions.Visible = false;
        trbtn.Visible = false;
        try
        {
            UniversalData_AddLinkAction.PageSize = 25;
            CheckQueryString();
            connection.Open();
            GetRequisitionDetail(ref connection);
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
            foreach (ListItem listItem in chblAction.Items)
            {
                if (listItem.Selected)
                    InsertMenuLinkAction(hdnMenuLinkCode.Value, listItem.Value);
            }
            foreach (ListItem listItem in chblAction.Items)
            {
                if (!listItem.Selected)
                    DeleteMenuLinkAction(hdnMenuLinkCode.Value, listItem.Value);
            }
            GetRequisitionDetail(ref connection);
            lblMsg.Text = "Updated Successfully!!";
            lblMsg.Visible = true;
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

    protected void rptLink_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem)
            return;
        int itemType = (int)e.Item.ItemType;
    }

    protected void rptRoleLists_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "Delete"))
            return;
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XRec_DeleteAction", connection);
            sqlCommand.Parameters.AddWithValue("@ActionCode", e.CommandArgument.ToString());
            sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
            sqlCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            Convert.ToString(sqlCommand.ExecuteScalar());
            GetRequisitionDetail(ref connection);
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
        if (secQueryString == null)
            return;
        if (secQueryString["MenuLinkCode"] != null)
        {
            MenuLinkCode = secQueryString["MenuLinkCode"].ToString();
            hdnMenuLinkCode.Value = secQueryString["MenuLinkCode"].ToString();
        }
        if (secQueryString["Heading"] == null)
            return;
        lblHead.Text = secQueryString["Heading"].ToString();
    }

    public void GetRequisitionDetail(ref SqlConnection connection)
    {
        trActions.Visible = true;
        trbtn.Visible = true;
        SqlCommand selectCommand = new SqlCommand("XRec_SelectAllActionByLink", connection);
        selectCommand.Parameters.AddWithValue("@MenuLinkCode", hdnMenuLinkCode.Value);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            chblAction.DataSource = dataSet.Tables[0];
            chblAction.DataValueField = "ActionCode";
            chblAction.DataTextField = "Action";
            chblAction.DataBind();
            foreach (DataRow row in (InternalDataCollectionBase)dataSet.Tables[0].Rows)
            {
                foreach (ListItem listItem in chblAction.Items)
                {
                    if (listItem.Value == row["ActionCode"].ToString())
                        listItem.Selected = row["IsMark"].ToString() == "1";
                }
            }
        }
        if (dataSet.Tables[1].Rows.Count > 0)
        {
            rptLink.DataSource = dataSet.Tables[1];
            rptLink.DataBind();
        }
        else
        {
            rptLink.DataSource = null;
            rptLink.DataBind();
        }
    }

    private void InsertMenuLinkAction(string MenuLinkCode, string ActionCode)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_InsertLinkAction", connection);
        sqlCommand.Parameters.AddWithValue("@MenuLinkID", MenuLinkCode);
        sqlCommand.Parameters.AddWithValue("@ActionID", ActionCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedIP", Request.UserHostAddress.ToString());
        sqlCommand.CommandType = CommandType.StoredProcedure;
        Convert.ToString(sqlCommand.ExecuteScalar());
    }

    private void DeleteMenuLinkAction(string MenuLinkCode, string ActionCode)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_DeleteLinkAction", connection);
        sqlCommand.Parameters.AddWithValue("@MenuLinkID", MenuLinkCode);
        sqlCommand.Parameters.AddWithValue("@ActionID", ActionCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedIP", Request.UserHostAddress.ToString());
        sqlCommand.CommandType = CommandType.StoredProcedure;
        Convert.ToString(sqlCommand.ExecuteScalar());
    }
    #endregion

}