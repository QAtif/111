using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ErrorLog;

public partial class AddEditVenue : CustomBasePage//XRecBase
{
    #region Variable
    int VenueCode = 0;
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            trMessage.Style["display"] = "none";
            if (Request.QueryString != null && Request.QueryString["vid"] != null && (Request.QueryString != null && Request.QueryString["vid"] != null))
            {
                if (Request.QueryString["vid"].ToString() != "")
                {
                    VenueCode = Convert.ToInt32(Request.QueryString["vid"].ToString());
                    ViewState["vid"] = Request.QueryString["vid"].ToString();
                }
            }
            else
                VenueCode = 0;
            ShowData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XREC_Insert_Update_Venue", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@VenueName", txtName.Text);
            selectCommand.Parameters.AddWithValue("@TestTypeMediumCode", ddlTestTypeMedium.SelectedValue);
            selectCommand.Parameters.AddWithValue("@LocationCode", ddlLocation.SelectedValue);
            selectCommand.Parameters.AddWithValue("@TimeDuration", txtTimeDuration.Text);
            selectCommand.Parameters.AddWithValue("@NoOfSeats", txtNoofSeats.Text);
            selectCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
            selectCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
            selectCommand.Parameters.AddWithValue("@MinDurationOfSlot", txtMinSlotDuration.Text);
            selectCommand.Parameters.AddWithValue("@VenuePrefix", txtVenuePrefix.Text);
            if (VenueCode == 0 && ViewState["vid"] == null)
                selectCommand.Parameters.AddWithValue("@VenueCode", 0);
            else if (ViewState["vid"] != null && Request.QueryString["vid"] != "" && Request.QueryString["vid"] != string.Empty)
                selectCommand.Parameters.AddWithValue("@VenueCode", Convert.ToInt32(Request.QueryString["vid"]));
            selectCommand.Parameters.AddWithValue("@StartTime", ddlFromTime.SelectedValue);
            selectCommand.Parameters.AddWithValue("@EndTime", ddlToTime.SelectedValue);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count <= 0)
                return;
            int int32 = Convert.ToInt32(dataTable.Rows[0]["VenueCode"].ToString());
            ViewState["vid"] = int32;
            if (int32 == 0)
            {
                trMessage.Style["display"] = "";
                lblMessage.Text = "This Venue already exists.";
            }
            else
            {
                lblMsg.Text = "";
                VenueCode = Convert.ToInt32(dataTable.Rows[0]["VenueCode"]);
                ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "refreshParent();", true);
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    public void ShowData()
    {
        string empty = string.Empty;
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XRec_Select_VenueDetailsByVenueCode", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@VenueCode", Convert.ToInt32(Request.QueryString["vid"]));
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet == null)
                return;
            if (dataSet.Tables[1].Rows.Count > 0)
            {
                ddlLocation.DataSource = dataSet.Tables[1];
                ddlLocation.DataTextField = "LocationName";
                ddlLocation.DataValueField = "LocationCode";
                ddlLocation.DataBind();
            }
            if (dataSet.Tables[2].Rows.Count > 0)
            {
                ddlTestTypeMedium.DataSource = dataSet.Tables[2];
                ddlTestTypeMedium.DataTextField = "TestTypeMediumName";
                ddlTestTypeMedium.DataValueField = "TestTypeMediumCode";
                ddlTestTypeMedium.DataBind();
            }
            if (dataSet.Tables[0].Rows.Count <= 0)
                return;
            txtName.Text = dataSet.Tables[0].Rows[0]["VenueName"].ToString();
            txtNoofSeats.Text = dataSet.Tables[0].Rows[0]["NoOfSeats"].ToString();
            txtTimeDuration.Text = dataSet.Tables[0].Rows[0]["TimeDuration"].ToString();
            ddlLocation.SelectedValue = dataSet.Tables[0].Rows[0]["LocationCode"].ToString();
            ddlTestTypeMedium.SelectedValue = dataSet.Tables[0].Rows[0]["TestTypeMediumCode"].ToString();
            txtVenuePrefix.Text = dataSet.Tables[0].Rows[0]["VenuePrefix"].ToString();
            txtMinSlotDuration.Text = dataSet.Tables[0].Rows[0]["MinDurationOfSlot"].ToString();
            ddlFromTime.SelectedValue = dataSet.Tables[0].Rows[0]["StartTime"].ToString();
            ddlToTime.SelectedValue = dataSet.Tables[0].Rows[0]["EndTime"].ToString();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
    #endregion



}