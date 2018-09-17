
using ErrorLog;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public partial class LinkMgmt_AddEditLinkCategory : CustomBasePage
{
    #region Variables
    string MenuLinkCode = "0";
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
        try
        {
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            if (QueryStringVar != null)
                secQueryString = new SecureQueryString(QueryStringVar);
            CheckQueryString();
            connection.Open();
            if (!(MenuLinkCode != "0"))
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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            string str = InsertLinkCategory(ref connection);
            if (str != null && str != "" && str != "0")
            {
                lblMsg.Text = "Successfully Saved!";
                lblMsg.Visible = true;
            }
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

    private void BindRequisition(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectLinkCategoryByCode", connection);
        selectCommand.Parameters.AddWithValue("@MenuLinkID", MenuLinkCode);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        txtLinkName.Text = dataSet.Tables[0].Rows[0]["MenuLinkName"].ToString();
        btnAdd.Text = "Update Link Category";
        lblHead.Text = "Edit Link Category";
    }

    private void CheckQueryString()
    {
        if (QueryStringVar == null || secQueryString["LinkID"] == null)
            return;
        MenuLinkCode = secQueryString["LinkID"].ToString();
        hdnLinkCode.Value = secQueryString["LinkID"].ToString();
    }

    private string InsertLinkCategory(ref SqlConnection connection)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Insert_Update_LinkCategory", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@LinkCategoryName", txtLinkName.Text);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        sqlCommand.Parameters.AddWithValue("@MenuLinkID", hdnLinkCode.Value);
        return Convert.ToString(sqlCommand.ExecuteScalar());
    }
    #endregion

}