using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

using System.Configuration;
using System.Web.UI.HtmlControls;

public partial class AddEditVenue : XRecBase
{
    int VenueCode = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            trMessage.Style["display"] = "none";
            if (Request.QueryString != null && Request.QueryString["vid"] != null && Request.QueryString != null && Request.QueryString["vid"] != null)
            {
                if (Request.QueryString["vid"].ToString() != "")
                {
                    VenueCode = Convert.ToInt32(Request.QueryString["vid"].ToString());
                    ViewState["vid"] = Request.QueryString["vid"].ToString();
                }
            }
            else
            {
                VenueCode = 0;
            }
            ShowData();
        }
    }



    public void ShowData()
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);
        string strSQL = string.Empty;

        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XRec_Select_VenueDetailsByVenueCode", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@VenueCode", Convert.ToInt32(Request.QueryString["vid"]));
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            if (ds != null)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    ddlLocation.DataSource = ds.Tables[1];
                    ddlLocation.DataTextField = "LocationName";
                    ddlLocation.DataValueField = "LocationCode";
                    ddlLocation.DataBind();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    ddlTestTypeMedium.DataSource = ds.Tables[2];
                    ddlTestTypeMedium.DataTextField = "TestTypeMediumName";
                    ddlTestTypeMedium.DataValueField = "TestTypeMediumCode";
                    ddlTestTypeMedium.DataBind();
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0]["VenueName"].ToString();
                    txtNoofSeats.Text = ds.Tables[0].Rows[0]["NoOfSeats"].ToString();
                    txtTimeDuration.Text = ds.Tables[0].Rows[0]["TimeDuration"].ToString();
                    ddlLocation.SelectedValue = ds.Tables[0].Rows[0]["LocationCode"].ToString();
                    ddlTestTypeMedium.SelectedValue = ds.Tables[0].Rows[0]["TestTypeMediumCode"].ToString();
                    txtVenuePrefix.Text = ds.Tables[0].Rows[0]["VenuePrefix"].ToString();
                    txtMinSlotDuration.Text = ds.Tables[0].Rows[0]["MinDurationOfSlot"].ToString();

                    ddlFromTime.SelectedValue = ds.Tables[0].Rows[0]["StartTime"].ToString();
                    ddlToTime.SelectedValue = ds.Tables[0].Rows[0]["EndTime"].ToString();

                }
                
            }
        }
        catch (Exception exp1)
        {
            //throw exp1;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, exp1.StackTrace, exp1, UserID.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);

        int Exist = 0;
        lblMsg.Text = "";
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XREC_Insert_Update_Venue", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@VenueName", txtName.Text);
            sqlCommand.Parameters.AddWithValue("@TestTypeMediumCode", ddlTestTypeMedium.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@LocationCode", ddlLocation.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@TimeDuration", txtTimeDuration.Text);
            sqlCommand.Parameters.AddWithValue("@NoOfSeats", txtNoofSeats.Text);

            sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
            sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);

            sqlCommand.Parameters.AddWithValue("@MinDurationOfSlot", txtMinSlotDuration.Text);
            sqlCommand.Parameters.AddWithValue("@VenuePrefix", txtVenuePrefix.Text);

            if (VenueCode == 0 && ViewState["vid"] == null)
            {
                sqlCommand.Parameters.AddWithValue("@VenueCode", 0); // insert
            }

            else if (ViewState["vid"] != null && Request.QueryString["vid"] != "" && Request.QueryString["vid"] != string.Empty)
            {
                sqlCommand.Parameters.AddWithValue("@VenueCode", Convert.ToInt32(Request.QueryString["vid"])); // update
            }

            sqlCommand.Parameters.AddWithValue("@StartTime", ddlFromTime.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@EndTime", ddlToTime.SelectedValue);

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Exist = Convert.ToInt32(dt.Rows[0]["VenueCode"].ToString());
                ViewState["vid"] = Exist;
                if (Exist == 0)
                {
                    trMessage.Style["display"] = "";
                    lblMessage.Text = "This Venue already exists.";
                }

                else
                {
                    lblMsg.Text = "";
                    VenueCode = Convert.ToInt32(dt.Rows[0]["VenueCode"]);
                    ScriptManager.RegisterStartupScript(this, GetType(), "pass", "refreshParent();", true);
                }
            }
        }

        catch (Exception exp1)
        {
            //throw exp1;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, exp1.StackTrace, exp1, UserID.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }


    }
}