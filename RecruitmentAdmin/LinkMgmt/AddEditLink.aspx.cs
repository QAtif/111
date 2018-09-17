
using ErrorLog;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;


public partial class LinkMgmt_AddEditLink : CustomBasePage
{
    #region variables

    string MenuLinkCode = "0", ParentCode = "0";
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
            if (MenuLinkCode != "0")
                BindRequisition(ref connection);
            else
                trMove.Visible = false;
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
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            if (dataSet.Tables[1].Rows.Count > 0)
            {
                ddlMove.DataSource = dataSet.Tables[1];
                ddlMove.DataValueField = "MenuLinkID";
                ddlMove.DataTextField = "MenuLinkName";
                ddlMove.DataBind();
            }
            txtLinkName.Text = dataSet.Tables[0].Rows[0]["MenuLinkName"].ToString();
            txtURL.Text = dataSet.Tables[0].Rows[0]["URL"].ToString();
            chkMain.Checked = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["Is_MainPage"]);
            ddlMove.SelectedValue = dataSet.Tables[0].Rows[0]["ParentCode"].ToString();
            btnAdd.Text = "Update Link Category";
            lblHead.Text = "Edit Link Category";
            trMove.Visible = true;
        }
        else
            trMove.Visible = false;
    }

    private void CheckQueryString()
    {
        if (QueryStringVar == null)
            return;
        if (secQueryString["LinkID"] != null)
        {
            MenuLinkCode = secQueryString["LinkID"].ToString();
            hdnLinkCode.Value = secQueryString["LinkID"].ToString();
        }
        if (secQueryString["ParentID"] == null)
            return;
        ParentCode = secQueryString["ParentID"].ToString();
        hdnParentCode.Value = secQueryString["ParentID"].ToString();
    }

    private string InsertLinkCategory(ref SqlConnection connection)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Insert_Update_LinkWithParent", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@LinkCategoryName", txtLinkName.Text);
        sqlCommand.Parameters.AddWithValue("@URL", txtURL.Text);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        sqlCommand.Parameters.AddWithValue("@MenuLinkID", hdnLinkCode.Value);
        sqlCommand.Parameters.AddWithValue("@ParentCode", hdnParentCode.Value);
        sqlCommand.Parameters.AddWithValue("@IsMain", chkMain.Checked);
        sqlCommand.Parameters.AddWithValue("@ParentID", ddlMove.SelectedValue);
        return Convert.ToString(sqlCommand.ExecuteScalar());
    }

    #endregion

}