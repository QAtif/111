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

public partial class Role_AddEditRole : CustomBasePage
{
    #region Variables
    string RoleCode = "0";
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        lblMsg.Visible = false;
        try
        {
            CheckQueryString();
            connection.Open();
            if (!(RoleCode != "0"))
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
            string str = InsertRole(ref connection);
            if (str != null && str != "" && str != "0")
            {
                lblMsg.Text = "Successfully Saved!";
                lblMsg.Visible = true;
                Page.RegisterStartupScript("Close", "<script language=JavaScript> CloseHighSlideWithParentRefresh();</script>");
            }
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private void BindRequisition(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectRoleByCode", connection);
        selectCommand.Parameters.AddWithValue("@RoleCode", RoleCode);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        txtRoleName.Text = dataSet.Tables[0].Rows[0]["RoleName"].ToString();
        txtRoleDesc.Text = dataSet.Tables[0].Rows[0]["RoleDescription"].ToString();
        btnAdd.Text = "Update Role";
        lblHead.Text = "Edit Role";
    }

    private void CheckQueryString()
    {
        if (Request.QueryString["role"] == null)
            return;
        RoleCode = Request.QueryString["role"].ToString();
        hdnRoleCode.Value = Request.QueryString["role"].ToString();
    }

    private string InsertRole(ref SqlConnection connection)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Insert_Update_Role", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@RoleName", txtRoleName.Text);
        sqlCommand.Parameters.AddWithValue("@RoleDescription", txtRoleDesc.Text);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        sqlCommand.Parameters.AddWithValue("@RoleCode", hdnRoleCode.Value);
        return Convert.ToString(sqlCommand.ExecuteScalar());
    }
    #endregion

}