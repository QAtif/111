using ErrorLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_UpdateAllowanceRate : CustomBasePage, IRequiresSessionState
{
    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    private SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            lblMsg.Text = "";
            lblMsg.Visible = false;
            BindData();
            ShowHideActions();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        UpdateAllowance();
    }

    private void ShowHideActions()
    {
        IEnumerable<HtmlGenericControl> allControlsOfType = Page.GetAllControlsOfType<HtmlGenericControl>();
        foreach (DataRow row in (InternalDataCollectionBase)DTActions.Rows)
        {
            foreach (Control control in allControlsOfType)
            {
                if (control.ClientID == "divAction" + row["MenuLinkActionCode"].ToString())
                    control.Visible = true;
            }
        }
    }

    public void BindData()
    {
        try
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand selectCommand = new SqlCommand("Select_AllowanceValue", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            new SqlDataAdapter(selectCommand).Fill(dataTable);
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return;
            txtFuelRate.Text = dataTable.Rows[0]["AllowanceRate"].ToString();
            txtMineralwater.Text = dataTable.Rows[1]["AllowanceRate"].ToString();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    public void UpdateAllowance()
    {
        try
        {
            if (string.IsNullOrEmpty(txtFuelRate.Text) || string.IsNullOrEmpty(txtMineralwater.Text))
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("Update_AllowanceValue", connection);
            sqlCommand.Parameters.Add("@Fuelrate", SqlDbType.Decimal).Value = txtFuelRate.Text;
            sqlCommand.Parameters.Add("@MiniralWatarRate", SqlDbType.Decimal).Value = txtMineralwater.Text;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            lblMsg.Text = "Saved Sucessfully.";
            lblMsg.ForeColor = Color.Green;
            lblMsg.Visible = true;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }
}