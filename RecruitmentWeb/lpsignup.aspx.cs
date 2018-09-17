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
using XRecruitmentStatusLibrary;
using System.Net;
using System.IO;
using System.Xml;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.EnterpriseServices;
using System.Collections;
using facebook;

public partial class lpsignup : System.Web.UI.Page
{

    #region Variables
    
    public string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    public string TokenSecret = "";
    public string XML = string.Empty;
    public string PhoneVerificationCode = string.Empty;
    public string EmailVerificationCode = string.Empty;
    public string QueryStringVar = string.Empty;
    public SecureQueryString oSecureString;
    public SecureQueryString secQueryString;


    #endregion

   

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindPhoneCodes();
                BindCountry();
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "");
        }
        if (ddlCountry.SelectedValue == "172")
        {
            dvOther.Attributes.Add("style", "display:none");
            dvCode.Attributes.Add("style", "display:''");
            dvCell.Attributes.Add("style", "display:''");
        }
        else
        {
            dvOther.Attributes.Add("style", "display:''");
            dvCode.Attributes.Add("style", "display:none");
            dvCell.Attributes.Add("style", "display:none");
        }
    }

    private void BindResume()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_Select_CandidateResume", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                {
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet.Tables.Count <= 0)
                        return;
                    int count = dataSet.Tables[0].Rows.Count;
                }
            }
        }
    }

    private void BindCountry()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCountry", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                {
                    sqlDataAdapter.Fill(dataSet);
                    ddlCountry.DataSource = dataSet.Tables[0];
                    ddlCountry.DataTextField = "Country_Name";
                    ddlCountry.DataValueField = "Country_Code";
                    ddlCountry.DataBind();
                    ddlCountry.SelectedValue = "172";
                }
            }
        }
    }

    public void SendSMS()
    {
        string empty1 = string.Empty;
        string empty2 = string.Empty;
        string str1 = "Dear " + txtFullname.Text + ", thank you for signing up with Axact Careers. Your mobile verification code is " + PhoneVerificationCode + ". Please enter this code in the verification field to proceed.";
        string str2 = "92" + ddlPhoneCodes.SelectedValue.ToString() + txtCell.Text;
        string empty3 = string.Empty;
        getString(lpsignup.getPageHTML("http://bsms.ufone.com/bsms_app4/sendapi.jsp?id=" + ConfigurationManager.AppSettings["SMSID"].ToString() + "&message=" + str1 + "&shortcode=" + ConfigurationManager.AppSettings["MsgShortCode"].ToString() + "&lang=English&mobilenum=" + str2 + "&password=" + ConfigurationManager.AppSettings["MsgPassword"].ToString()), "<body>", "</body>").Trim();
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

    public string GetRandomCode(int length)
    {
        string str = Guid.NewGuid().ToString().Replace("-", string.Empty);
        if (length <= 0 || length > str.Length)
            throw new ArgumentException("Length must be between 1 and " + str.Length);
        return str.Substring(0, length);
    }

    private string GeneratePhoneVerificationCode()
    {
        string str1 = ddlPhoneCodes.SelectedValue.ToString();
        string str2 = txtCell.Text.ToString();
        int int32_1 = Convert.ToInt32(str1);
        int int32_2 = Convert.ToInt32(str2);
        string str3 = ConfigurationManager.AppSettings["EncodingPattren"].ToString();
        string str4 = "";
        while (int32_1 > 0)
        {
            str4 += (string)(object)str3[int32_1 % str3.Length];
            int32_1 /= str3.Length;
        }
        while (int32_2 > 0)
        {
            str4 += (string)(object)str3[int32_2 % str3.Length];
            int32_2 /= str3.Length;
        }
        return str4;
    }

    public static string EncodeTo64(string toEncode)
    {
        return Convert.ToBase64String(Encoding.ASCII.GetBytes(toEncode));
    }

    public DataSet SignUp()
    {
        string empty1 = string.Empty;
        string empty2 = string.Empty;
        QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
        if (QueryStringVar != null)
        {
            secQueryString = new SecureQueryString(QueryStringVar);
            if (secQueryString != null)
            {
                if (secQueryString["cc"] != null)
                    empty1 = secQueryString["cc"].ToString();
                if (secQueryString["rfc"] != null)
                    empty2 = secQueryString["rfc"].ToString();
            }
        }
        DataSet dataSet = new DataSet();
        int length = 6;
        PhoneVerificationCode = GetRandomCode(length);
        EmailVerificationCode = GetRandomCode(length);
        string empty3 = string.Empty;
        string str = !(ddlCountry.SelectedValue == "172") ? txtCell2.Text.ToString() : ddlPhoneCodes.SelectedValue.ToString() + txtCell.Text.ToString();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_CreateCandidateSignup", connection))
            {
                oSecureString = new SecureQueryString();
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@FullName", txtFullname.Text);
                selectCommand.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
                selectCommand.Parameters.AddWithValue("@CurrentURL", Request.Url.ToString());
                selectCommand.Parameters.AddWithValue("@ReferralURL", Request.UrlReferrer.ToString());
                selectCommand.Parameters.AddWithValue("@PhoneNumber", str);
                selectCommand.Parameters.AddWithValue("@Password", oSecureString.encrypt(txtPassword.Text.Trim()));
                selectCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
                selectCommand.Parameters.AddWithValue("@PhoneVerificationCode", PhoneVerificationCode);
                selectCommand.Parameters.AddWithValue("@EmailVerificationCode", EmailVerificationCode);
                selectCommand.Parameters.AddWithValue("@CountryCode", ddlCountry.SelectedValue);
                if (empty1 != string.Empty)
                    selectCommand.Parameters.AddWithValue("@AppliedCand_Code", empty1);
                if (empty2 != string.Empty)
                    selectCommand.Parameters.AddWithValue("@ReferralPortalID", empty2);
                selectCommand.Parameters.AddWithValue("@SignUpThroughCode", Convert.ToInt32(Constants.SignupThrough.Candidate));
                selectCommand.Parameters.AddWithValue("@UserType", Convert.ToInt32(Constants.UserTypeCode.Candidate));
                selectCommand.Parameters.AddWithValue("@referringURL", txtParentUrl.Text);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }

    public void BindPhoneCodes()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectService", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                {
                    sqlDataAdapter.Fill(dataSet);
                    ddlPhoneCodes.DataSource = dataSet.Tables[0];
                    ddlPhoneCodes.DataTextField = "ServiceName";
                    ddlPhoneCodes.DataValueField = "ServiceName";
                    ddlPhoneCodes.DataBind();
                }
            }
        }
    }

    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsValid)
                return;
            txtPassword.Attributes.Add("value", txtPassword.Text);
            txtReEnterPassPassword.Attributes.Add("value", txtReEnterPassPassword.Text);
            DataSet dataSet1 = new DataSet();
            DataSet dataSet2 = SignUp();
            if (dataSet2 == null || dataSet2.Tables == null || dataSet2.Tables.Count <= 0)
                return;
            if (dataSet2.Tables[0].Rows.Count > 0)
            {
                if (dataSet2.Tables[0].Rows[0]["CandidateCode"].ToString() != "0")
                {
                    Session["CC"] = dataSet2.Tables[0].Rows[0]["CandidateCode"].ToString();
                    ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "refreshParent('area/area.aspx');", true);
                }
                else
                {
                    if (dataSet2.Tables[0].Rows[0]["EmailAddressExist"].ToString() == "1")
                        lblError.Text = "Email Address Already Exist. <br/>";
                    if (dataSet2.Tables[0].Rows[0]["MobileNumberExist"].ToString() == "1")
                        lblError.Text = "Phone Number Already Exist. <br/>";
                    if (!(dataSet2.Tables[0].Rows[0]["EmailAddressExist"].ToString() == "1") || !(dataSet2.Tables[0].Rows[0]["MobileNumberExist"].ToString() == "1"))
                        return;
                    lblError.Text = "Phone Number / Email Address Already Exist.";
                }
            }
            else
                lblError.Text = "Phone Number / Email Address Already Exist.";
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "");
        }
    }

}