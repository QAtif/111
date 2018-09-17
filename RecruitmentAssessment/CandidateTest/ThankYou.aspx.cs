using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using XRecruitmentStatusLibrary;
using ErrorLog;




public partial class ThankYou : XRecBase
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            UpdateSlot(connection);
            StatusManagement.MarkLifeCycleStatus(connection, UserID, Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.TestDoneResultPending, Request.UserHostAddress.ToString(), UserID);

            RemoveCookie("CC");
            RemoveCookie("TC");
            //Remove Cookie
            //if (Response.Cookies["CC"] != null || Response.Cookies["TC"] != null)
            //{
            //    Response.Cookies["CC"].Expires = DateTime.Now.AddDays(-1);
            //    Response.Cookies["TC"].Expires = DateTime.Now.AddDays(-1);
            //    Response.Cookies.Remove("CC");
            //    Response.Cookies.Remove("TC");
            //}

            //This session change into cookie in above logic
            //Session.RemoveAll();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAssessment, ex.StackTrace, ex, UserID.ToString());
        }
        finally
        {
            connection.Close();
        }
    }
    public static void RemoveCookie(string key)
    {
        //get cookies value
        HttpCookie cookie = null;
        if (HttpContext.Current.Request.Cookies[key] != null)
        {
            cookie = HttpContext.Current.Request.Cookies[key];

            //set its expiry date to earlier date
            cookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);

        }


    }

    protected void UpdateSlot(SqlConnection connection)
    {
        try
        {
            SqlCommand sqlCommand = new SqlCommand("XREC_Update_CandidateSlotAvailed", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@CandidateCode", UserID);
            sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
            sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
            sqlCommand.ExecuteNonQuery();
        }

        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAssessment, ex.StackTrace, ex, UserID.ToString());
        }
        finally
        {
            connection.Close();
        }

    }


}