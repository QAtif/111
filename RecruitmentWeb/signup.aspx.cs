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
using System.Web.Caching;
using Facebook;

public partial class signup : System.Web.UI.Page
{
    #region Variables
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    string TokenSecret = "";
    SecureQueryString oSecureString = null;
    string XML = string.Empty;
    string PhoneVerificationCode = string.Empty;
    string EmailVerificationCode = string.Empty;
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;

    #endregion


    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.RegisterStartupScript("hi", "<script>checkCookie()</script>");
        try
        {
            CheckQueryString();
            if (!IsPostBack)
            {
                if (hdnCanCode.Value != string.Empty && hdnCanCode.Value != "")
                    BindResume();
                else
                    dvResume.Visible = false;
                BindPhoneCodes();
                BindCountry();
                if (Request.QueryString["Code"] != null)
                    CheckLoginSucceed();
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

    private Dictionary<string, string> GetOauthTokens(string code)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        try
        {
            string appSetting1 = ConfigurationManager.AppSettings["FacebookLoginClientId"];
            string appSetting2 = ConfigurationManager.AppSettings["FacebookLoginClientSecret"];
            string appSetting3 = ConfigurationManager.AppSettings["FacebookLoginCallbackURL"];
            string appSetting4 = ConfigurationManager.AppSettings["FacebookScope"];
            using (HttpWebResponse response = (WebRequest.Create("https://graph.facebook.com/oauth/access_token?client_id=" + appSetting1 + "&redirect_uri=" + appSetting3 + "&client_secret=" + appSetting2 + "&code=" + code + "&scope=" + appSetting4) as HttpWebRequest).GetResponse() as HttpWebResponse)
            {
                string end = new StreamReader(response.GetResponseStream()).ReadToEnd();
                char[] chArray = new char[1] { '&' };
                foreach (string str in end.Split(chArray))
                    dictionary.Add(str.Substring(0, str.IndexOf("=")), str.Substring(str.IndexOf("=") + 1, str.Length - str.IndexOf("=") - 1));
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message, ex, "0");
        }
        return dictionary;
    }

    private string GetAccessToken()
    {
        if (HttpRuntime.Cache["access_token"] == null)
            HttpRuntime.Cache.Insert("access_token", GetOauthTokens(Request.Params["code"])["access_token"], (CacheDependency)null, DateTime.Now.AddMinutes(Convert.ToDouble(100)), TimeSpan.Zero);
        return HttpRuntime.Cache["access_token"].ToString();
    }

    private void CheckLoginSucceed()
    {
        JSONObject jsonObject = new FacebookAPI(GetAccessToken()).Get("/me");
        ClientScript.RegisterClientScriptBlock(GetType(), "redirect", "SetSignUpInfo('" + jsonObject.Dictionary["first_name"].String + " " + jsonObject.Dictionary["last_name"].String + "','" + jsonObject.Dictionary["email"].String + "'); window.close();", true);
        txtFullname.Text = jsonObject.Dictionary["first_name"].String + " " + jsonObject.Dictionary["last_name"].String;
        txtEmail.Text = jsonObject.Dictionary["email"].String;
    }

    protected void btnSignUp_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (!Page.IsValid)
                return;
            txtPassword.Attributes.Add("value", txtPassword.Text);
            txtReEnterPassPassword.Attributes.Add("value", txtReEnterPassPassword.Text);
            DataSet dataSet1 = new DataSet();
            DataSet dataSet2 = !(hdnCanCode.Value != string.Empty) || !(hdnCanCode.Value != "") || !(hdnCanCode.Value != "0") ? SignUp() : UpdateCandidate();
            if (dataSet2 != null && dataSet2.Tables != null && dataSet2.Tables.Count > 0)
            {
                if (dataSet2.Tables[0].Rows.Count > 0)
                {
                    if (dataSet2.Tables[0].Rows[0]["CandidateCode"].ToString() != "0")
                    {
                        Session["CC"] = dataSet2.Tables[0].Rows[0]["CandidateCode"].ToString();
                        Response.Redirect(DomainAddress + "area/area.aspx", false);
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
            else
                lblError.Text = "";
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "");
        }
    }



    #endregion


    #region Methods
    public DataSet UpdateCandidate()
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
        string str1 = hdnSignuptypecode.Value != null ? hdnSignuptypecode.Value : string.Empty;
        string str2 = hdnXML.Value != null ? hdnXML.Value : string.Empty;
        int length = 6;
        PhoneVerificationCode = GetRandomCode(length);
        EmailVerificationCode = GetRandomCode(length);
        string empty3 = string.Empty;
        string str3 = !(ddlCountry.SelectedValue == "172") ? txtCell2.Text.ToString() : ddlPhoneCodes.SelectedValue.ToString() + txtCell.Text.ToString();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_UpdateCandidateSignup", connection))
            {
                oSecureString = new SecureQueryString();
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add("@FullName", txtFullname.Text);
                selectCommand.Parameters.Add("@EmailAddress", txtEmail.Text);
                selectCommand.Parameters.Add("@CurrentURL", Request.Url.ToString());
                selectCommand.Parameters.Add("@ReferralURL", Request.UrlReferrer.ToString());
                selectCommand.Parameters.Add("@PhoneNumber", str3);
                selectCommand.Parameters.Add("@Password", oSecureString.encrypt(txtPassword.Text));
                selectCommand.Parameters.Add("@UpdationIP", Request.UserHostAddress.ToString());
                selectCommand.Parameters.Add("@PhoneVerificationCode", PhoneVerificationCode);
                selectCommand.Parameters.Add("@EmailVerificationCode", EmailVerificationCode);
                selectCommand.Parameters.Add("@SignUpType_code", Convert.ToInt32(str1));
                selectCommand.Parameters.Add("@Linkedin_XML", str2);
                selectCommand.Parameters.Add("@CountryCode", ddlCountry.SelectedValue);
                if (empty1 != string.Empty)
                    selectCommand.Parameters.Add("@AppliedCand_Code", empty1);
                if (empty2 != string.Empty)
                    selectCommand.Parameters.Add("@ReferralPortalID", empty2);
                selectCommand.Parameters.Add("@SignUpThroughCode", Convert.ToInt32(Constants.SignupThrough.AdminUser));
                selectCommand.Parameters.Add("@UserType", Convert.ToInt32(Constants.UserTypeCode.Admin));
                selectCommand.Parameters.Add("@UpdatedBy", Session["AdminUserCode"] == null ? "0" : Session["AdminUserCode"].ToString());
                selectCommand.Parameters.Add("@Candidate_Code", hdnCanCode.Value);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
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
                selectCommand.Parameters.Add("@Candidate_Code", hdnCanCode.Value);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                {
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet.Tables.Count <= 0 || dataSet.Tables[0].Rows.Count <= 0)
                        return;
                    dvResume.Visible = true;
                    aResume.HRef = dataSet.Tables[0].Rows[0]["Resume_Path"].ToString();
                    aResume.Target = "_blank";
                }
            }
        }
    }

    private void CheckQueryString()
    {
        if (Request.QueryString[SecureQueryString.QueryStringVar] == null)
            return;
        Hashtable hashtable = Utilities.decryptQueryString(Request.QueryString[SecureQueryString.QueryStringVar].ToString());
        hdnCanCode.Value = hashtable["candcode"] != null ? hashtable["candcode"].ToString() : string.Empty;
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
        getString(signup.getPageHTML("http://bsms.ufone.com/bsms_app4/sendapi.jsp?id=" + ConfigurationManager.AppSettings["SMSID"].ToString() + "&message=" + str1 + "&shortcode=" + ConfigurationManager.AppSettings["MsgShortCode"].ToString() + "&lang=English&mobilenum=" + str2 + "&password=" + ConfigurationManager.AppSettings["MsgPassword"].ToString()), "<body>", "</body>").Trim();
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
        string str1 = hdnSignuptypecode.Value != null ? hdnSignuptypecode.Value : string.Empty;
        string str2 = hdnXML.Value != null ? hdnXML.Value : string.Empty;
        int length = 6;
        PhoneVerificationCode = GetRandomCode(length);
        EmailVerificationCode = GetRandomCode(length);
        string empty3 = string.Empty;
        string str3 = !(ddlCountry.SelectedValue == "172") ? txtCell2.Text.ToString() : ddlPhoneCodes.SelectedValue.ToString() + txtCell.Text.ToString();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_CreateCandidateSignup", connection))
            {
                oSecureString = new SecureQueryString();
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add("@FullName", txtFullname.Text);
                selectCommand.Parameters.Add("@EmailAddress", txtEmail.Text);
                selectCommand.Parameters.Add("@CurrentURL", Request.Url.ToString());
                selectCommand.Parameters.Add("@ReferralURL", Request.UrlReferrer.ToString());
                selectCommand.Parameters.Add("@PhoneNumber", str3);
                selectCommand.Parameters.Add("@Password", oSecureString.encrypt(txtPassword.Text.Trim()));
                selectCommand.Parameters.Add("@UpdationIP", Request.UserHostAddress.ToString());
                selectCommand.Parameters.Add("@PhoneVerificationCode", PhoneVerificationCode);
                selectCommand.Parameters.Add("@EmailVerificationCode", EmailVerificationCode);
                selectCommand.Parameters.Add("@SignUpType_code", Convert.ToInt32(str1));
                selectCommand.Parameters.Add("@Linkedin_XML", str2);
                selectCommand.Parameters.Add("@CountryCode", ddlCountry.SelectedValue);
                if (empty1 != string.Empty)
                    selectCommand.Parameters.Add("@AppliedCand_Code", empty1);
                if (empty2 != string.Empty)
                    selectCommand.Parameters.Add("@ReferralPortalID", empty2);
                selectCommand.Parameters.Add("@SignUpThroughCode", Convert.ToInt32(Constants.SignupThrough.Candidate));
                selectCommand.Parameters.Add("@UserType", Convert.ToInt32(Constants.UserTypeCode.Candidate));
                selectCommand.Parameters.AddWithValue("@referringURL", txtParentUrl.Value);
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



    #endregion



}


public enum PasswordScore
{
    Blank = 0,
    VeryWeak = 1,
    Weak = 2,
    Medium = 3,
    Strong = 4,
    VeryStrong = 5
}

