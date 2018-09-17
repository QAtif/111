using System;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ErrorLog;

public partial class AddRequisition : CustomBasePage
{

    string CategoryCode = string.Empty;
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Visible = false;
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            secQueryString = new SecureQueryString(QueryStringVar);
            if (secQueryString["CID"] != null)
                CategoryCode = secQueryString["CID"].ToString();
            if (IsPostBack)
                return;
            bindData();
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

    public void bindData()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
        SqlCommand selectCommand = new SqlCommand("XRec_SeletCity", connection);
        selectCommand.Parameters.AddWithValue("@UserCode", UserCode);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet != null)
        {
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                ddlcity.DataSource = dataSet.Tables[0];
                ddlcity.DataTextField = "City";
                ddlcity.DataValueField = "City_Code";
                ddlcity.DataBind();
            }
            if (dataSet.Tables[1].Rows.Count > 0)
                hdnUserTypeCode.Value = dataSet.Tables[1].Rows[0]["UserTypeCode"].ToString();
        }
        if (connection.State == ConnectionState.Closed)
            return;
        connection.Close();
    }

    private void UpdateRequisitionStatus(int categoryCode, int requisitionStatusCode)
    {
        SqlCommand sqlCommand = new SqlCommand("UPdate_RequisitonStatus", connection);
        sqlCommand.Parameters.AddWithValue("@CategoryCode", categoryCode);
        sqlCommand.Parameters.AddWithValue("@UserCode", UserCode);
        sqlCommand.Parameters.AddWithValue("@UserTypeCode", hdnUserTypeCode.Value);
        sqlCommand.Parameters.AddWithValue("@RequisitionStatusCode", requisitionStatusCode);
        sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
        sqlCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.ExecuteNonQuery();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XREC_Insert_Requisition", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@NoOfCandidate", txtNoOfCandidate.Text);
            sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
            sqlCommand.Parameters.AddWithValue("@City", ddlcity.SelectedValue);
            if (!string.IsNullOrEmpty(CategoryCode))
                sqlCommand.Parameters.AddWithValue("@CategoryCode", CategoryCode);
            sqlCommand.ExecuteScalar();
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "refreshParent();", true);
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

}


