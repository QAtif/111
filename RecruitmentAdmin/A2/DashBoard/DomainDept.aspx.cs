using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using ErrorLog;
using System.Data;

public partial class A2_DashBoard_DomainDept : CustomBasePage
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
    private void BindData()
    {
        //try
        //{
        //    connection.Open();

        //    SqlCommand sqlCommand = new SqlCommand("XREC_GetDomainOwnerValues", connection);            
        //    //sqlCommand.Parameters.AddWithValue("@UserCode", UserCode);            
        //    sqlCommand.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        //    DataSet ds = new DataSet();
        //    adapter.Fill(ds);
        //    if (ds != null)
        //    {
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            lblTest.Text = ds.Tables[0].Rows[0]["Test"].ToString();
        //            lblIntervew.Text = ds.Tables[0].Rows[0]["FinalInterview"].ToString();
        //            lblOffer.Text = ds.Tables[0].Rows[0]["OfferLetter"].ToString();
        //            lblVerification.Text = ds.Tables[0].Rows[0]["Verification"].ToString();
        //            lblAppointment.Text = ds.Tables[0].Rows[0]["Appointment"].ToString();

        //        }

        //        if (ds.Tables[2].Rows.Count > 0)
        //        {
        //            lblOPDNew.Text = ds.Tables[2].Rows[0]["New"].ToString();
        //            lblOPDPending.Text = ds.Tables[2].Rows[0]["Pending"].ToString();
        //        }

        //        if (ds.Tables[3].Rows.Count > 0)
        //        {
        //            lblOfferNew.Text = ds.Tables[3].Rows[0]["New"].ToString();
        //            lblOfferPending.Text = ds.Tables[3].Rows[0]["Pending"].ToString();
        //        }


        //    }

        //}
        //catch (Exception ex)
        //{
        //    ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        //}
        //finally
        //{
        //    if (connection.State != ConnectionState.Closed)
        //        connection.Close();
        //}

        SqlCommand sqlCommand = new SqlCommand("Xrec_Select_CandidateInterviewCount", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        DataSet ds = new DataSet();
        adapter.Fill(ds);
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblOfferPending.Text = ds.Tables[0].Rows[0]["InterviewCount"].ToString();
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