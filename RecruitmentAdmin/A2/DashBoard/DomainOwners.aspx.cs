using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
using System.Web.Services;

public partial class DomainOwners : CustomBasePage
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["sessionId"] = UserCode.ToString();
        try
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            BindData();

        }
        catch (Exception ex)
        {
            ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            connection.Close();
        }

    }
    public void BindData()
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_GetOfferApprovalCount", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        DataSet ds = new DataSet();
        adapter.Fill(ds);
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblOfferPending.Text = ds.Tables[0].Rows[0]["Pending"].ToString();
            }

        }

        sqlCommand = new SqlCommand("XREC_GetRequisionOPDCount", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        adapter = new SqlDataAdapter(sqlCommand);
        ds = new DataSet();
        adapter.Fill(ds);
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblOPDPending.Text = ds.Tables[0].Rows[0]["Pending"].ToString();
            }

        }

        sqlCommand = new SqlCommand("XREC_GetCurrentRequisitionCount", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        adapter = new SqlDataAdapter(sqlCommand);
        ds = new DataSet();
        adapter.Fill(ds);
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblCurrentPending.Text = ds.Tables[0].Rows[0]["Pending"].ToString();
            }

        }

        sqlCommand = new SqlCommand("XREC_GetTodaysScheduleCount", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        adapter = new SqlDataAdapter(sqlCommand);
        ds = new DataSet();
        adapter.Fill(ds);
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTest.Text = ds.Tables[0].Rows[0]["Test"].ToString();
                lblIntervew.Text = ds.Tables[0].Rows[0]["FinalInterview"].ToString();
                lblOffer.Text = ds.Tables[0].Rows[0]["OfferLetter"].ToString();
                lblVerification.Text = ds.Tables[0].Rows[0]["Verification"].ToString();
                lblAppointment.Text = ds.Tables[0].Rows[0]["Appointment"].ToString();
                lblNewJoining.Text = ds.Tables[0].Rows[0]["NewJoining"].ToString();

            }

        }

    }

}