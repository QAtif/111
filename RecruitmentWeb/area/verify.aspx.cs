using System;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net;
using ErrorLog;
using System.Drawing;
using System.IO;

public partial class Area_verification : System.Web.UI.Page
{
    #region Page Variables

    int CandidateCode = 0;
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    DataSet ds = new DataSet();
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;
    SecureQueryString sQString = new SecureQueryString();

    #endregion

    #region Page Event Handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            secQueryString = new SecureQueryString(QueryStringVar);
            if (Session["CC"] != null && !string.IsNullOrEmpty(secQueryString["qs"].ToString()))
            {
                CandidateCode = Convert.ToInt32(Session["CC"]);
                if (IsPostBack)
                    return;
                if (secQueryString["qs"].ToString() == "1")
                {
                    divmainEAdd.Style.Add("display", "none");
                }
                else
                {
                    if (!(secQueryString["qs"].ToString() == "2"))
                        return;
                    divmainMob.Style.Add("display", "none");
                }
            }
            else
                ScriptManager.RegisterStartupScript((Page)this, GetType(), Guid.NewGuid().ToString(), "RefreshParent()", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + "-" + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void lnkVerifyMobile_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["CC"] == null)
                return;
            spErrorMsg1.Style.Add("display", "none");
            lblError1.Text = "";
            lblMsg.Attributes.Add("style", "display:none");
            lblMsg1.Attributes.Add("style", "display:none");
            lblError1.Attributes.Add("style", "display:none");
            lblError.Attributes.Add("style", "display:none");
            DataSet dataSet1 = new DataSet();
            DataSet dataSet2 = VerifyPhone(txtVerificationCode1.Text);
            if (dataSet2 == null || dataSet2.Tables == null || dataSet2.Tables[0].Rows.Count <= 0)
                return;
            if (dataSet2.Tables[0].Rows[0]["veritype"].ToString() != "3")
            {
                lblError1.Text = dataSet2.Tables[0].Rows[0]["Verified"].ToString();
                lblError1.Attributes.Add("style", "display:''");
                lblError1.ForeColor = Color.Green;
            }
            else
            {
                lblError1.Text = dataSet2.Tables[0].Rows[0]["Verified"].ToString();
                lblError1.Attributes.Add("style", "display:''");
                lblError1.ForeColor = Color.Red;
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + "-" + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void lnkResendCodeMobile_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["CC"] == null)
                return;
            lblMsg.Attributes.Add("style", "display:none");
            lblMsg1.Attributes.Add("style", "display:none");
            lblError1.Attributes.Add("style", "display:none");
            lblError.Attributes.Add("style", "display:none");
            DataSet dataSet = new DataSet();
            DataSet verificationCode = GetVerificationCode();
            if (verificationCode == null || verificationCode.Tables == null || verificationCode.Tables[0].Rows.Count <= 0)
                return;
            if (verificationCode.Tables[0].Rows[0]["Result"].ToString() != "0")
            {
                SendCodeBySMS(CandidateCode.ToString(), Request.UserHostAddress.ToString(), CandidateCode.ToString());
                lblMsg1.Text = "Verification code has been sent on your mobile number.";
                lblMsg1.ForeColor = Color.Green;
                lblMsg1.Attributes.Add("style", "display:''");
                spErrorMsg1.Attributes.Add("style", "display:''");
                ClientScript.RegisterClientScriptBlock(GetType(), "pass", "RefreshParent1();", true);
            }
            else
            {
                lblMsg1.Text = verificationCode.Tables[0].Rows[0]["MsgPhone"].ToString();
                lblMsg1.ForeColor = Color.Red;
                lblMsg1.Attributes.Add("style", "display:''");
                spErrorMsg1.Attributes.Add("style", "display:''");
                ClientScript.RegisterClientScriptBlock(GetType(), "pass2", "RefreshParent1();", true);
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + "-" + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    public static bool CandidateResendCode(string CandidateCode, int Status_Code, string UserIP, string UserID)
    {
        bool flag = false;
        try
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
                flag = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + "-" + ex.StackTrace, ex, CandidateCode.ToString());
        }
        return flag;
    }

    protected void lnkVerifyEmail_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["CC"] == null)
                return;
            spErrorMsg.Style.Add("display", "none");
            lblError.Text = "";
            lblMsg.Attributes.Add("style", "display:none");
            lblMsg1.Attributes.Add("style", "display:none");
            lblError1.Attributes.Add("style", "display:none");
            lblError.Attributes.Add("style", "display:none");
            DataSet dataSet1 = new DataSet();
            DataSet dataSet2 = VerifyEmail(txtVerificationCode.Text);
            if (dataSet2 == null || dataSet2.Tables == null || dataSet2.Tables[0].Rows.Count <= 0)
                return;
            if (dataSet2.Tables[0].Rows[0]["veritype"].ToString() != "2")
            {
                lblError.Text = dataSet2.Tables[0].Rows[0]["Verified"].ToString();
                lblError.Attributes.Add("style", "display:''");
                lblError.ForeColor = Color.Green;
            }
            else
            {
                lblError.Attributes.Add("style", "display:''");
                lblError.Text = dataSet2.Tables[0].Rows[0]["Verified"].ToString();
                lblError.ForeColor = Color.Red;
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + "-" + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void lnkResendCodeEmail_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["CC"] == null)
                return;
            lblMsg.Attributes.Add("style", "display:none");
            lblMsg1.Attributes.Add("style", "display:none");
            lblError1.Attributes.Add("style", "display:none");
            lblError.Attributes.Add("style", "display:none");
            DataSet dataSet = new DataSet();
            DataSet verificationCode = GetVerificationCode();
            if (verificationCode == null || verificationCode.Tables == null)
                return;
            if (verificationCode.Tables[0].Rows.Count > 0)
            {
                if (verificationCode.Tables[0].Rows[0]["Result"].ToString() != "0")
                {
                    SendCodeByEmail(CandidateCode.ToString(), Request.UserHostAddress.ToString(), CandidateCode.ToString());
                    lblMsg.Text = "Verification code has been sent on your email address.";
                    lblMsg.ForeColor = Color.Green;
                    lblMsg.Attributes.Add("style", "display:''");
                    spErrorMsg.Attributes.Add("style", "display:''");
                    ClientScript.RegisterClientScriptBlock(GetType(), "pass", "RefreshParent();", true);
                }
                else
                {
                    lblMsg.Text = verificationCode.Tables[0].Rows[0]["MsgEmail"].ToString();
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Attributes.Add("style", "display:''");
                    spErrorMsg.Attributes.Add("style", "display:''");
                    ClientScript.RegisterClientScriptBlock(GetType(), "pass", "RefreshParent();", true);
                }
            }
            else
            {
                lblMsg.Text = verificationCode.Tables[0].Rows[0]["MsgEmail"].ToString();
                lblMsg.ForeColor = Color.Red;
                lblMsg.Attributes.Add("style", "display:''");
                spErrorMsg.Attributes.Add("style", "display:''");
                ClientScript.RegisterClientScriptBlock(GetType(), "pass", "RefreshParent();", true);
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + "-" + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    private void SendCodeByEmail(string CandidateCode, string UpdatedIP, string UpdatedCode)
    {
        try
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                connection.Open();
                using (SqlCommand selectCommand = new SqlCommand("XRec_CandidateVerificationCodeByEmail", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.Add(new SqlParameter("@CandidateCode", Session["CC"].ToString()));
                    selectCommand.Parameters.Add(new SqlParameter("@UpdatedIP", Request.UserHostAddress.ToString()));
                    selectCommand.Parameters.Add(new SqlParameter("@Updated_By", Session["CC"].ToString()));
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + "-" + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    private void SendCodeBySMS(string CandidateCode, string UpdatedIP, string UpdatedCode)
    {
        try
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                connection.Open();
                using (SqlCommand selectCommand = new SqlCommand("XRec_CandidateVerificationCodeBySMS", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.Add(new SqlParameter("@CandidateCode", Session["CC"].ToString()));
                    selectCommand.Parameters.Add(new SqlParameter("@UpdatedIP", Request.UserHostAddress.ToString()));
                    selectCommand.Parameters.Add(new SqlParameter("@Updated_By", Session["CC"].ToString()));
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + "-" + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    public DataSet VerifyEmail(string Code)
    {
        DataSet dataSet = new DataSet();
        try
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                connection.Open();
                using (SqlCommand selectCommand = new SqlCommand("XRec_VerifyCandidateEmailCodeNew", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.Add(new SqlParameter("@CandidateCode", Session["CC"].ToString()));
                    selectCommand.Parameters.Add(new SqlParameter("@EmailVerificationCode", Code));
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + "-" + ex.StackTrace, ex, CandidateCode.ToString());
        }
        return dataSet;
    }

    public DataSet VerifyPhone(string Code)
    {
        DataSet dataSet = new DataSet();
        try
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                connection.Open();
                using (SqlCommand selectCommand = new SqlCommand("XRec_VerifyCandidatePhoneCodeNew", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.Add(new SqlParameter("@CandidateCode", Session["CC"].ToString()));
                    selectCommand.Parameters.Add(new SqlParameter("@PhoneVerificationCode", Code));
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + "-" + ex.StackTrace, ex, CandidateCode.ToString());
        }
        return dataSet;
    }

    private DataSet GetVerificationCode()
    {
        DataSet dataSet = new DataSet();
        try
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                connection.Open();
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateVerificationCode", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.Add(new SqlParameter("@CandidateCode", Session["CC"].ToString()));
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + "-" + ex.StackTrace, ex, CandidateCode.ToString());
        }
        return dataSet;
    }

    public void SendSMS(string FullName, string VerificationCode, string PhoneNumber)
    {
        try
        {
            string empty1 = string.Empty;
            string str = "Dear " + FullName + " your Verification Code is : " + VerificationCode;
            string empty2 = string.Empty;
            getString(Area_verification.getPageHTML("http://bsms.ufone.com/bsms_app4/sendapi.jsp?id=" + ConfigurationManager.AppSettings["SMSID"].ToString() + "&message=" + str + "&shortcode=" + ConfigurationManager.AppSettings["MsgShortCode"].ToString() + "&lang=English&mobilenum=92" + PhoneNumber + "&password=" + ConfigurationManager.AppSettings["MsgPassword"].ToString()), "<body>", "</body>").Trim();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + "-" + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected static string getPageHTML(string _pageURL)
    {
        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(_pageURL);
        httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1;..NET CLR 1.1.4322)";
        return new StreamReader(httpWebRequest.GetResponse().GetResponseStream()).ReadToEnd();
    }

    private string getString(string ActualString, string StartValue, string EndValue)
    {
        string empty = string.Empty;
        return ActualString.Substring(ActualString.IndexOf(StartValue), ActualString.IndexOf(EndValue, ActualString.IndexOf(StartValue)) - ActualString.IndexOf(StartValue)).Replace(StartValue, "").Trim();
    }

    #endregion



}