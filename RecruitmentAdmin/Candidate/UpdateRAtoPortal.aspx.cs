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
using XRecruitmentStatusLibrary;


public partial class Candidate_UpdateRAtoPortal : CustomBasePage
{
    #region Variables

    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    string portalConnection = "Data Source=xdbsrv02;Initial Catalog=hrs;Persist Security Info=True;User ID=hrs;Password=myaxact;";
    #endregion

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            SyncPortalUsersData(DateTime.Now.Date);
            lblMsg.Text = "Portal Data will be updated in few minutes.";
        }
        catch (Exception ex)
        {
            ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }


    public void SyncPortalUsersData(DateTime today)
    {
        DataTable dtPortal = GetPortalData();
        if (dtPortal.Rows.Count > 0)
        {
            for (int i = 0; i <= dtPortal.Rows.Count - 1; i++)
            {
                Sync(int.Parse(dtPortal.Rows[i]["userID"].ToString()),
                    dtPortal.Rows[i]["fullName"].ToString(),
                    dtPortal.Rows[i]["deptName"].ToString(),
                    dtPortal.Rows[i]["Designation"].ToString(),
                    int.Parse(dtPortal.Rows[i]["cand_cat_code"].ToString()),
                    Convert.ToBoolean(dtPortal.Rows[i]["is_active"].ToString()),
                    dtPortal.Rows[i]["Is_ReportingAuthority"].ToString() == "0" ? false : true,
                    dtPortal.Rows[i]["EMAIL"].ToString(),
                    int.Parse(dtPortal.Rows[i]["DEPARTMENT_CODE"].ToString()),
                    dtPortal.Rows[i]["Is_PanelMember"].ToString() == "0" ? false : true,
                    dtPortal.Rows[i]["Gender"].ToString(),
                    dtPortal.Rows[i]["ph_extension"].ToString(),
                    dtPortal.Rows[i]["Is_GroupLeader"].ToString() == "0" ? false : true,
                    dtPortal.Rows[i]["Is_TeamLeader"].ToString() == "0" ? false : true,
                    int.Parse(dtPortal.Rows[i]["GL_ID"].ToString())

                    );
            }
            InsertSyncDate(today);
        }
    }

    #endregion

    #region Methods
    protected DataTable GetPortalData()
    {
        DataTable dt = new DataTable();
        string conStr = portalConnection;
        SqlDataAdapter adapter = new SqlDataAdapter("XRec_GetPortalUsers", new SqlConnection(conStr));
        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        adapter.Fill(dt);
        return dt;
    }
    protected void Sync(int userID, string fullName, string deptName, string Designation, int cand_cat_code,
           bool is_active, bool Is_ReportingAuthority, string EMAIL, int DEPARTMENT_CODE, bool Is_PanelMember,
           string Gender, string ph_extension, bool Is_GroupLeader, bool Is_TeamLeader, int GL_ID)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["RecruitmentAdminConn"].ToString());
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.XRec_Sync_PortalUsers", connection);
            sqlCommand.Parameters.AddWithValue("@userID", userID);
            sqlCommand.Parameters.AddWithValue("@fullName", fullName);
            sqlCommand.Parameters.AddWithValue("@deptName", deptName);
            sqlCommand.Parameters.AddWithValue("@Designation", Designation);
            sqlCommand.Parameters.AddWithValue("@cand_cat_code", cand_cat_code);
            sqlCommand.Parameters.AddWithValue("@is_active", is_active);
            sqlCommand.Parameters.AddWithValue("@Is_ReportingAuthority", Is_ReportingAuthority);
            sqlCommand.Parameters.AddWithValue("@EMAIL", EMAIL);
            sqlCommand.Parameters.AddWithValue("@DEPARTMENT_CODE", DEPARTMENT_CODE);
            sqlCommand.Parameters.AddWithValue("@Is_PanelMember", Is_PanelMember);
            sqlCommand.Parameters.AddWithValue("@Gender", Gender);
            sqlCommand.Parameters.AddWithValue("@ph_extension", ph_extension);

            sqlCommand.Parameters.AddWithValue("@Is_GroupLeader", Is_GroupLeader);
            sqlCommand.Parameters.AddWithValue("@Is_TeamLeader", Is_TeamLeader);
            sqlCommand.Parameters.AddWithValue("@GL_ID", GL_ID);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();

        }
        catch (Exception ex)
        {

            ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, "XRecDocumentUploadingService");
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }




    }

    protected void InsertSyncDate(DateTime todayDate)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand("XRec_Insert_CheckForPortalSyncForDate", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@todayDate", todayDate);

            sqlCommand.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            //throw exp1;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, null);
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
    #endregion
}