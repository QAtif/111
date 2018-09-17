using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using XRecruitmentStatusLibrary;


public partial class controls_verificationcontrol : System.Web.UI.UserControl
{

    #region Page Variables
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    string student_code = string.Empty;
    bool PhoneVerified = false;
    bool EmailVerified = false;
    int CandidateCode = 0;
    DataSet ds = new DataSet();

    #endregion Page Variables



    protected void Page_Load(object sender, EventArgs e)
    {
        CandidateCode = int.Parse(Session["CC"].ToString());
         ds = GetCandidateProfileData(CandidateCode);

         CheckControls();

    }



    #region Email Varification Events




    protected void lnkVerifyEmail_Click(Object sender, EventArgs e)
    {
       
        try
        {
            string code = txtVerificationCode.Text;
            ds = Verify(code);
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Verified"].ToString() == "1")
                {
                    ds = GetCandidateProfileData(CandidateCode);
                    CheckControls();
                }
                else
                {

                }
            }
        }
        catch (Exception ex)
        {
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.Candidate, "btnVerify_Click", ex, CandidateCode.ToString());
        }
    }

    protected void lnkResendCodeEmail_Click(Object sender, EventArgs e)
    {
        lblMsg.Visible = false;
        try
        {
            if (ConfigurationManager.AppSettings["SMSToRun"].ToString() == "1")
            {
              
                ds = GetVerificationCode();

                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Result"].ToString() != "0")
                    {
                        SendSMS(ds.Tables[0].Rows[0]["FullName"].ToString(), ds.Tables[0].Rows[0]["VerificationCode"].ToString(), ds.Tables[0].Rows[0]["PhoneNumber"].ToString());
                        lblMsg.Text = ds.Tables[0].Rows[0]["Msg"].ToString();
                        lblMsg.Visible = true;
                        spErrorMsg.Attributes.Add("style", "display:''");
                        
                    }
                    else
                    {
                        lblMsg.Text = ds.Tables[0].Rows[0]["Msg"].ToString();
                        lblMsg.Style.Add("ForeColor", "#009900");
                        lblMsg.Visible = true;
                        spErrorMsg.Attributes.Add("style", "display:''");
                        
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.Candidate, "btnSave_Click", ex, CandidateCode.ToString());
        }
    }

    #endregion Email Varification Events


    #region Phone Varification Events

    protected void lnkVerifyMobile_Click(Object sender, EventArgs e)
    {

       
        try
        {
            string code = txtVerificationCode1.Text;
            ds = Verify(code);
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Verified"].ToString() == "1")
                {
                    ds = GetCandidateProfileData(CandidateCode);
                    CheckControls();
                }
                else
                {

                }
            }
        }
        catch (Exception ex)
        {
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.Candidate, "btnVerify_Click", ex, CandidateCode.ToString());
        }

    }


    protected void lnkResendCodeMobile_Click(Object sender, EventArgs e)
    {
        lblMsg.Visible = false;
        try
        {
            if (ConfigurationManager.AppSettings["SMSToRun"].ToString() == "1")
            {
                
                ds = GetVerificationCode();

                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Result"].ToString() != "0")
                    {
                        SendSMS(ds.Tables[0].Rows[0]["FullName"].ToString(), ds.Tables[0].Rows[0]["VerificationCode"].ToString(), ds.Tables[0].Rows[0]["PhoneNumber"].ToString());
                        lblMsg1.Text = ds.Tables[0].Rows[0]["Msg"].ToString();
                        lblMsg1.Visible = true;
                        spErrorMsg1.Attributes.Add("style", "display:''");
                        
                    }
                    else
                    {
                        lblMsg1.Text = ds.Tables[0].Rows[0]["Msg"].ToString();
                        lblMsg1.Style.Add("ForeColor", "#009900");
                        lblMsg1.Visible = true;
                        spErrorMsg1.Attributes.Add("style", "display:''");
                        
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.Candidate, "btnSave_Click", ex, CandidateCode.ToString());
        }

    }



    #endregion Phone Varification Events


    public void CheckControls()
    {

        if (ds.Tables[0].Rows[0]["Candidate_ID"].ToString() != "" && ds.Tables[0].Rows[0]["Candidate_ID"].ToString() != "-")
        {
            lblPhoneNumber.Text = ds.Tables[0].Rows[0]["Phone_Number"].ToString();
            lblEmail.Text = ds.Tables[0].Rows[0]["Email_Address"].ToString();
            PhoneVerified = Convert.ToBoolean(ds.Tables[0].Rows[0]["Is_PhoneVerified"].ToString());
            EmailVerified = Convert.ToBoolean(ds.Tables[0].Rows[0]["Is_EmailVerified"].ToString());
        }
        else
        {
            lblPhoneNumber.Text = ds.Tables[0].Rows[0]["Phone_Number"].ToString();
            lblEmail.Text = ds.Tables[0].Rows[0]["Email_Address"].ToString();
            PhoneVerified = Convert.ToBoolean(ds.Tables[0].Rows[0]["Is_PhoneVerified"].ToString());
            EmailVerified = Convert.ToBoolean(ds.Tables[0].Rows[0]["Is_EmailVerified"].ToString());
        }



        if (EmailVerified)
        {
            spnotverified2.Attributes.Add("style", "display:none");
            spverified2.Attributes.Add("style", "display:''");

        }
        else
        {
            spnotverified2.Attributes.Add("style", "display:''");
            spverified2.Attributes.Add("style", "display:none");
        }


        if (PhoneVerified)
        {
            spnotverified1.Attributes.Add("style", "display:none");
            spverified1.Attributes.Add("style", "display:''");

        }
        else
        {
            spnotverified1.Attributes.Add("style", "display:''");
            spverified1.Attributes.Add("style", "display:none");
        }

    }



    public DataSet Verify(string Code)
    {
        DataSet objDS = new DataSet();
        using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            c.Open();
            using (SqlCommand command = new SqlCommand("XRec_VerifyCandidatePhoneCode", c))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CandidateCode", Session["CC"].ToString()));
                command.Parameters.Add(new SqlParameter("@PhoneVerificationCode", Code));
                using (SqlDataAdapter a = new SqlDataAdapter(command))
                {
                    a.Fill(objDS);
                }
            }
        }
        return objDS;
    }

    private DataSet GetVerificationCode()
    {
        DataSet objDS = new DataSet();
        using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            c.Open();
            using (SqlCommand command = new SqlCommand("XRec_SelectCandidateVerificationCode", c))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CandidateCode", Session["CC"].ToString()));
                using (SqlDataAdapter a = new SqlDataAdapter(command))
                {
                    a.Fill(objDS);
                }
            }
        }
        return objDS;
    }

    private DataSet GetCandidateProfileData(int candidatecode)
    {
        DataSet objDS = new DataSet();
        using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            c.Open();
            using (SqlCommand command = new SqlCommand("XRec_SelectCandidateProfileData", c))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CandidateCode", candidatecode));
                using (SqlDataAdapter a = new SqlDataAdapter(command))
                {
                    a.Fill(objDS);
                }
            }
        }
        return objDS;
    }

    public void SendSMS(string FullName, string VerificationCode, string PhoneNumber)
    {
        string Message = string.Empty;
        Message = "Dear " + FullName + " your Verification Code is : " + VerificationCode;
        string ReturnedStatus = string.Empty;
        ReturnedStatus = getPageHTML("http://bsms.ufone.com/bsms_app4/sendapi.jsp?id=" + ConfigurationManager.AppSettings["SMSID"].ToString()
            + "&message=" + Message + "&shortcode=" + ConfigurationManager.AppSettings["MsgShortCode"].ToString()
            + "&lang=English&mobilenum=" + "92" + PhoneNumber + "&password="
            + ConfigurationManager.AppSettings["MsgPassword"].ToString());
        string tempStatus = getString(ReturnedStatus, "<body>", "</body>").Trim();
    }
    string getString(string ActualString, string StartValue, string EndValue)
    {
        string str = string.Empty;
        str = ActualString.Substring(ActualString.IndexOf(StartValue),
        (ActualString.IndexOf(EndValue, ActualString.IndexOf(StartValue)) - ActualString.IndexOf(StartValue))).Replace(StartValue, "").Trim();
        return str;
    }

    protected static string getPageHTML(string _pageURL)
    {
        HttpWebRequest _HttpWRQ = (HttpWebRequest)WebRequest.Create(_pageURL);
        _HttpWRQ.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1;..NET CLR 1.1.4322)";

        HttpWebResponse _HttpWRS = (HttpWebResponse)_HttpWRQ.GetResponse();

        System.IO.Stream _InStream = _HttpWRS.GetResponseStream();

        System.IO.StreamReader _InStreamReader = new System.IO.StreamReader(_InStream);

        return _InStreamReader.ReadToEnd();
    }


}