using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using ErrorLog;
using System.Net;
using XRecruitmentStatusLibrary;
using System.Drawing;
using System.IO;

public partial class verification : CustomBaseClass
{
    #region Variables
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    #endregion


    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnVerify_Click(object sender, ImageClickEventArgs e)
    {
        lblMsg.Visible = false;
        DataSet dataSet1 = new DataSet();
        try
        {
            DataSet dataSet2 = Verify();
            if (dataSet2 == null || dataSet2.Tables == null || dataSet2.Tables[0].Rows.Count <= 0)
                return;
            if (dataSet2.Tables[0].Rows[0]["Verified"].ToString() == "1")
            {
                StatusManagement.MarkLifeCycleStatus(SqlConn, CANDIDATE, Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.VerificationDoneApplicationPending, Request.UserHostAddress.ToString(), CANDIDATE);
                Response.Redirect(DomainAddress + "/area/area.aspx", false);
            }
            else
            {
                lblError.Text = "Please provide valid Verification Code";
                lblError.ForeColor = Color.Red;
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CANDIDATE.ToString());
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblMsg.Visible = false;
        try
        {
            DataSet dataSet = new DataSet();
            DataSet verificationCode = GetVerificationCode();
            if (verificationCode == null || verificationCode.Tables == null || verificationCode.Tables[0].Rows.Count <= 0)
                return;
            if (verificationCode.Tables[0].Rows[0]["Result"].ToString() != "0")
            {
                verification.CandidateResendCode(CandidateCode.ToString(), Convert.ToInt32(Constants.CandidateLifeCycleStatus.SignupdoneFormPending), Request.UserHostAddress.ToString(), CandidateCode.ToString());
                lblMsg.Text = verificationCode.Tables[0].Rows[0]["Msg"].ToString();
                lblMsg.Visible = true;
                lblError.Text = string.Empty;
                lblMsg.ForeColor = Color.Green;
            }
            else
            {
                lblMsg.Text = verificationCode.Tables[0].Rows[0]["Msg"].ToString();
                lblMsg.Visible = true;
                lblError.Text = string.Empty;
                lblMsg.ForeColor = Color.Red;
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CANDIDATE.ToString());
        }
    }

    public static bool CandidateResendCode(string CandidateCode, int Status_Code, string UserIP, string UserID)
    {
        using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "XRec_CandidateGetVerificationCode";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter("@Candidate_Code", CandidateCode));
            sqlCommand.Parameters.Add(new SqlParameter("@StatusCode", Status_Code));
            sqlCommand.Parameters.Add(new SqlParameter("@Updated_By", UserID));
            sqlCommand.Parameters.Add(new SqlParameter("@Updated_IP", UserIP));
            return Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
        }
    }

    protected void LnkLogOut_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            Response.Redirect(DomainAddress + "/signin.aspx", false);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CANDIDATE.ToString());
        }
    }


    #endregion

    #region Methods
    private DataSet GetVerificationCode()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateVerificationCode", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add(new SqlParameter("@CandidateCode", CANDIDATE.ToString()));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }

    public DataSet Verify()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_VerifyCandidatePhoneCode", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add(new SqlParameter("@CandidateCode", CANDIDATE.ToString()));
                selectCommand.Parameters.Add(new SqlParameter("@PhoneVerificationCode", txtVerificationCode.Text));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }

    public void SendSMS(string FullName, string VerificationCode, string PhoneNumber)
    {
        string empty1 = string.Empty;
        string str = "Dear " + FullName + " your Verification Code is : " + VerificationCode;
        string empty2 = string.Empty;
        getString(verification.getPageHTML("http://bsms.ufone.com/bsms_app4/sendapi.jsp?id=" + ConfigurationManager.AppSettings["SMSID"].ToString() + "&message=" + str + "&shortcode=" + ConfigurationManager.AppSettings["MsgShortCode"].ToString() + "&lang=English&mobilenum=92" + PhoneNumber + "&password=" + ConfigurationManager.AppSettings["MsgPassword"].ToString()), "<body>", "</body>").Trim();
    }

    private string getString(string ActualString, string StartValue, string EndValue)
    {
        string empty = string.Empty;
        return ActualString.Substring(ActualString.IndexOf(StartValue), ActualString.IndexOf(EndValue, ActualString.IndexOf(StartValue)) - ActualString.IndexOf(StartValue)).Replace(StartValue, "").Trim();
    }

    protected static string getPageHTML(string _pageURL)
    {
        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(_pageURL);
        httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1;..NET CLR 1.1.4322)";
        return new StreamReader(httpWebRequest.GetResponse().GetResponseStream()).ReadToEnd();
    }


    #endregion
}