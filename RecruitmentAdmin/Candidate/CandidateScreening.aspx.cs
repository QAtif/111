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


public partial class Candidate_CandidateScreening : CustomBasePage
{
    #region Variables
    string TypeCode = "0";
    string oldStatusName = string.Empty, oldProfileName = string.Empty, oldRequisitionName = string.Empty,
        oldCategoryName = string.Empty, oldJoiningDate = string.Empty;
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;
    #endregion
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            secQueryString = new SecureQueryString(QueryStringVar);

            try
            {
                CheckQueryString();
                connection.Open();
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
    }


    protected void btnNoreponse_Click(object sender, EventArgs e)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_SaveCandidateScreening", connection);
        sqlCommand.Parameters.AddWithValue("@CandidateCode", hdnCandidateCode.Value);
        sqlCommand.Parameters.AddWithValue("@Comments", "No Response -- " + txtCallComments.Text);
        sqlCommand.Parameters.AddWithValue("@UpDatedBy", UserCode);
        sqlCommand.Parameters.AddWithValue("@Type", "Screening");
        sqlCommand.CommandType = CommandType.StoredProcedure;
        if (connection.State != ConnectionState.Open)
            connection.Open();
        sqlCommand.ExecuteNonQuery();
        connection.Close();
        BindData();
        Page.RegisterStartupScript("Close", "<script language=JavaScript> CloseHighSlideWithParentRefresh();</script>");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand sqlCommand = new SqlCommand("XRec_SaveCandidateScreening", connection);
            sqlCommand.Parameters.AddWithValue("@CandidateCode", hdnCandidateCode.Value);
            sqlCommand.Parameters.AddWithValue("@Comments", "Response -- " + txtCallComments.Text);
            sqlCommand.Parameters.AddWithValue("@UpDatedBy", UserCode);
            sqlCommand.Parameters.AddWithValue("@Type", "Screening");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            BindData();
            Page.RegisterStartupScript("Close", "<script language=JavaScript> CloseHighSlideWithParentRefresh();</script>");
        }
        catch (Exception ex)
        {
            LogError.Write((LogError.AppType)4, "Screening Comments " + ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }

    }
    private void BindData()
    {
        try
        {
            SqlCommand sqlCommand = new SqlCommand("XRec_SelectCandidateScreening", connection);
            sqlCommand.Parameters.AddWithValue("@CandidateCode", hdnCandidateCode.Value);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            adapter.Fill(ds);


            if (ds.Tables[0].Rows.Count > 0)
            {
                rptCalls.DataSource = ds.Tables[0];
                rptCalls.DataBind();
            }
        }
        catch (Exception ex)
        {
            LogError.Write((LogError.AppType)4, "Screening Comments " + ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }

    }

    #endregion
    #region Methods

    private void CheckQueryString()
    {
        if (secQueryString["CID"] != null)
        {
            hdnCandidateCode.Value = secQueryString["CID"].ToString();
        }
    }

    #endregion

}