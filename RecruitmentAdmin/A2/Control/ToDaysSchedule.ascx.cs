using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using ErrorLog;

public partial class Control_HeaderToDaysSchedule : System.Web.UI.UserControl
{

    System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    public string CandidateCode = string.Empty, UserCode = string.Empty;

    //public string CandCode
    //{
    //    get { return hdnCancode.Value; }
    //    set { hdnCancode.Value = value; }
    //}
    private void Page_Load(object sender, System.EventArgs e)
    {
        try
        {
            BindData();

        }
        catch (Exception ex)
        {
            ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    public void BindData()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();

        SqlCommand sqlCommand = new SqlCommand("XREC_GetTodaysScheduleCount", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        DataSet ds = new DataSet();
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

            }

        }

    }

}