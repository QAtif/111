using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;
using ErrorLog;
using System.Net;
using System.IO;

public partial class forgotpassword : System.Web.UI.Page
{
    #region Variable
    SecureQueryString oSecureString = null;

    string candidateCode = string.Empty;
    string emailAddress = string.Empty;
    string expiryTime = string.Empty;
    string qs = string.Empty;
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();

    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = string.Empty;
        lblError.Text = string.Empty;
    }

    protected void btnSendPassword_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (!Page.IsValid)
                return;
            DataSet dataSet1 = new DataSet();
            DataSet dataSet2 = SendPassword();
            SecureQueryString secureQueryString = new SecureQueryString();
            if (dataSet2 != null && dataSet2.Tables != null && dataSet2.Tables.Count > 0)
            {
                if (dataSet2.Tables[0].Rows.Count > 0)
                {
                    qs = "cid=" + dataSet2.Tables[0].Rows[0]["CandidateCode"].ToString() + "&email=" + dataSet2.Tables[0].Rows[0]["EmailAddress"].ToString() + "&expiry=" + DateTime.Now;
                    qs = DomainAddress + "ResetPassword.aspx?" + SecureQueryString.QueryStringVar + "=" + secureQueryString.encrypt(qs);
                    if (!(dataSet2.Tables[0].Rows[0]["EmailMatch"].ToString() == "1") && !(dataSet2.Tables[0].Rows[0]["MobileMatch"].ToString() == "1"))
                        return;
                    MarkEmail(dataSet2.Tables[0].Rows[0]["EmailAddress"].ToString(), Convert.ToInt32(dataSet2.Tables[0].Rows[0]["CandidateCode"].ToString()), qs);
                    lblMsg.Text = "Information has been sent on your Email Address.";
                    txtEmailOrMob.Text = "";
                }
                else
                    lblError.Text = "Invalid Email Address or Mobile Number.";
            }
            else
                lblError.Text = "Invalid Email Address or Mobile Number.";
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "0");
        }
    }
    #endregion

    #region Methods
    public void SendSMS(string FullName, string CandidatePassword, int CandidateCode)
    {
        oSecureString = new SecureQueryString();
        string empty1 = string.Empty;
        string empty2 = string.Empty;
        string SMS_Body = "Dear " + FullName + " your Password Reset Link is  : " + CandidatePassword;
        string str = "92" + txtEmailOrMob.Text;
        string empty3 = string.Empty;
        getString(forgotpassword.getPageHTML("http://bsms.ufone.com/bsms_app4/sendapi.jsp?id=" + ConfigurationManager.AppSettings["SMSID"].ToString() + "&message=" + SMS_Body + "&shortcode=" + ConfigurationManager.AppSettings["MsgShortCode"].ToString() + "&lang=English&mobilenum=" + str + "&password=" + ConfigurationManager.AppSettings["MsgPassword"].ToString()), "<body>", "</body>").Trim();
        forgotpassword.CandidateSMSMarking(7, CandidateCode, SMS_Body, txtEmailOrMob.Text, Request.UserHostAddress.ToString(), CandidateCode);
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

    public DataSet SendPassword()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateResetPasswordLink", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add(new SqlParameter("@EmailOrMobile", txtEmailOrMob.Text.TrimStart('0')));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }

    public void UpdateResetPasswordLink(string PhoneNumber, int candidatecode, string resetlink)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateResetPasswordLinkWithoutEmail", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@PhoneNumber", PhoneNumber));
                sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", candidatecode));
                sqlCommand.Parameters.Add(new SqlParameter("@ResetPasswordLink", resetlink));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    public void MarkEmail(string emailaddress, int candidatecode, string resetlink)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateResetPasswordLink", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@EmailAddress", emailaddress));
                sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", candidatecode));
                sqlCommand.Parameters.Add(new SqlParameter("@ResetPasswordLink", resetlink));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    public static bool CandidateSMSMarking(int SMSFunction_code, int CandidateCode, string SMS_Body, string Recepient_Number, string UserIP, int UserID)
    {
        using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "XRec_CandidateSMSMarking";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter("@Candidate_Code", CandidateCode));
            sqlCommand.Parameters.Add(new SqlParameter("@SMSFunction_Code", SMSFunction_code));
            sqlCommand.Parameters.Add(new SqlParameter("@Recepient_Number", Recepient_Number));
            sqlCommand.Parameters.Add(new SqlParameter("@SMS_Body", SMS_Body));
            sqlCommand.Parameters.Add(new SqlParameter("@Updated_By", UserID));
            sqlCommand.Parameters.Add(new SqlParameter("@Updated_IP", UserIP));
            return Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
        }
    }

    #endregion

}