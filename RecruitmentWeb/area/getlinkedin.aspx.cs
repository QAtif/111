using ErrorLog;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using XRecruitmentStatusLibrary;

public partial class area_getLinkedIn : CustomBaseClass, IRequiresSessionState
{
    #region Variables
    private oAuthLinkedIn _oauth = new oAuthLinkedIn();
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    string TokenSecret = "";
    SecureQueryString oSecureString = null;
    string XML = string.Empty;
    #endregion



    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            if (Request.QueryString["oauth_token"] != null)
            {
                hdnAuth_token.Value = Request.QueryString["oauth_token"];
                _oauth.Verifier = Request.QueryString["oauth_verifier"];
                _oauth.Token = hdnAuth_token.Value;
                _oauth.TokenSecret = Application["reuqestTokenSecret"].ToString();
                TokenSecret = _oauth.TokenSecret;
                _oauth.AccessTokenGet(_oauth.Token);
                hdnAccessToken.Value = _oauth.Token;
                hdnAccessTokenSecret.Value = _oauth.TokenSecret;
                btnGetAccessToken.Focus();
                _oauth.Token = hdnAccessToken.Value;
                _oauth.TokenSecret = hdnAccessTokenSecret.Value;
                _oauth.Verifier = Request.QueryString["oauth_verifier"];
                string xml = _oauth.APIWebRequest("GET", "http://api.linkedin.com/v1/people/~:(id,first-name,last-name,headline,industry,location,positions,educations,picture-url,public-profile-url,email-address,skills,certifications,date-of-birth,phone-numbers,main-address)", (string)null);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xml);
                xmlDocument.SelectNodes("/person");
                string str = xmlDocument.InnerXml != null ? xmlDocument.InnerXml : string.Empty;
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    connection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateLinkedinXML", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@CandidateCode", CANDIDATE.ToString());
                        sqlCommand.Parameters.AddWithValue("@XML", str.ToString());
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                ParseXML(xmlDocument.InnerXml);
                ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "LinkedInProfileDone();", true);
            }
            else if (Request.QueryString["fi"] != null)
            {
                string url = _oauth.AuthorizationLinkGet();
                Application["reuqestToken"] = _oauth.Token;
                Application["reuqestTokenSecret"] = _oauth.TokenSecret;
                Application["oauthLink"] = url;
                hdnRequestToken.Value = _oauth.Token;
                hdnTokenSecret.Value = _oauth.TokenSecret;
                hypAuthToken.NavigateUrl = "javascript:;";
                hypAuthToken.Attributes.Add("onclick", "window.open('" + url + "')");
                int num = url.IndexOf('=');
                hdnAuth_token.Value = url.Substring(num + 1, url.Length - (num + 1));
                tblinkedin.Attributes.Add("style", "display:none");
                Response.Redirect(url);
            }
            else
                Response.Redirect("http://careers.axact.com/area/area.aspx");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + "LinkedIN Error" + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void btnGetAccessToken_Click(object sender, EventArgs e)
    {
        try
        {
            _oauth.Token = hdnAuth_token.Value;
            _oauth.TokenSecret = Application["reuqestTokenSecret"].ToString();
            TokenSecret = _oauth.TokenSecret;
            _oauth.Verifier = txtoAuth_verifier.Text;
            _oauth.AccessTokenGet(hdnAuth_token.Value);
            hdnAccessToken.Value = _oauth.Token;
            hdnAccessTokenSecret.Value = _oauth.TokenSecret;
            btnGetAccessToken.Focus();
            _oauth.Token = hdnAccessToken.Value;
            _oauth.TokenSecret = hdnAccessTokenSecret.Value;
            _oauth.Verifier = txtoAuth_verifier.Text;
            string xml = _oauth.APIWebRequest("GET", "http://api.linkedin.com/v1/people/~:(id,first-name,last-name,headline,industry,location,positions,educations,picture-url,public-profile-url,email-address,skills,certifications,date-of-birth,phone-numbers,main-address)", (string)null);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);
            xmlDocument.SelectNodes("/person");
            string str = xmlDocument.InnerXml != null ? xmlDocument.InnerXml : string.Empty;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateLinkedinXML", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@CandidateCode", CANDIDATE.ToString());
                    sqlCommand.Parameters.Add("@XML", str.ToString());
                    sqlCommand.ExecuteNonQuery();
                }
            }
            ParseXML(xmlDocument.InnerXml);
            Thread.Sleep(2000);
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "LinkedInProfileDone();", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + "LinkedIN Error" + ex.StackTrace, ex, "");
        }
    }

    protected void btnRedirect_Click(object sender, EventArgs e)
    {
        Response.Redirect(DomainAddress + "profile/Experience.apx", false);
    }

    private void ParseXML(string response)
    {
        XmlDocument xmlDocument = new XmlDocument();
        try
        {
            xmlDocument.LoadXml(response);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Session["CC"].ToString());
        }
        XmlNodeList xmlNodeList1 = xmlDocument.SelectNodes("/person");
        if (xmlNodeList1.Count <= 0)
            return;
        foreach (XmlNode xmlNode in xmlNodeList1)
        {
            string EducationID = string.Empty;
            string PositionID = string.Empty;
            string str1 = string.Empty;
            string str2 = string.Empty;
            string empty1 = string.Empty;
            string SkillID = string.Empty;
            string emailaddress = string.Empty;
            string DateOfBirthDay = string.Empty;
            bool Is_CurrentlyWorking = true;
            string DateOfBirthMonth = string.Empty;
            string phonenumber = string.Empty;
            string PositionTitle = string.Empty;
            string PositionSummary = string.Empty;
            string s1 = string.Empty;
            string s2 = string.Empty;
            string s3 = string.Empty;
            string s4 = string.Empty;
            string CompanyName = string.Empty;
            string InstituteName = string.Empty;
            string DegreeName = string.Empty;
            string FieldName = string.Empty;
            string StartDate = string.Empty;
            string EndDate = string.Empty;
            string SkillName = string.Empty;
            string IndustryName = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string Address = string.Empty;
            string empty4 = string.Empty;
            string CertificateID = string.Empty;
            string EducationActivities = string.Empty;
            string DateOfBirthYear = string.Empty;
            if (xmlNode["first-name"] != null)
                str1 = xmlNode["first-name"].InnerText;
            if (xmlNode["last-name"] != null)
                str2 = xmlNode["last-name"].InnerText;
            string FullName = str1 + " " + str2;
            if (xmlNode["email-address"] != null)
                emailaddress = xmlNode["email-address"].InnerText;
            if (xmlNode["main-address"] != null)
                Address = xmlNode["main-address"].InnerText;
            XmlNodeList xmlNodeList2 = xmlDocument.SelectNodes("/person/date-of-birth");
            if (xmlNodeList2.Count > 0)
            {
                if (xmlNodeList2[0]["day"] != null)
                    DateOfBirthDay = xmlNodeList2[0]["day"].InnerXml;
                if (xmlNodeList2[0]["month"] != null)
                    DateOfBirthMonth = xmlNodeList2[0]["month"].InnerXml;
                if (xmlNodeList2[0]["year"] != null)
                    DateOfBirthYear = xmlNodeList2[0]["year"].InnerXml;
            }
            XmlNodeList xmlNodeList3 = xmlDocument.SelectNodes("/person/phone-numbers/phone-number");
            if (xmlNodeList3.Count > 0 && xmlNodeList3[0]["phone-number"] != null)
                phonenumber = xmlNodeList3[0]["phone-number"].InnerXml;
            UpdateCandidatePersonalInformation(FullName, emailaddress, DateOfBirthDay, DateOfBirthMonth, DateOfBirthYear, phonenumber, Address);
            XmlNodeList xmlNodeList4 = xmlDocument.SelectNodes("/person/positions/position");
            if (xmlNodeList4.Count > 0)
            {
                for (int index = 0; index < xmlNodeList4.Count; ++index)
                {
                    if (xmlNodeList4[index]["id"] != null)
                        PositionID = xmlNodeList4[index]["id"].InnerText;
                    if (xmlNodeList4[index]["title"] != null)
                        PositionTitle = xmlNodeList4[index]["title"].InnerText;
                    if (xmlNodeList4[index]["summary"] != null)
                        PositionSummary = xmlNodeList4[index]["summary"].InnerText;
                    if (xmlNodeList4[index]["is-current"] != null)
                        Is_CurrentlyWorking = Convert.ToBoolean(xmlNodeList4[index]["is-current"].InnerText);
                    if (xmlNodeList4[index]["start-date"] != null && xmlNodeList4[index]["start-date"]["year"] != null)
                        s1 = xmlNodeList4[index]["start-date"]["year"].InnerXml;
                    if (xmlNodeList4[index]["start-date"] != null && xmlNodeList4[index]["start-date"]["month"] != null)
                        s2 = xmlNodeList4[index]["start-date"]["month"].InnerXml;
                    XmlNodeList xmlNodeList5 = xmlDocument.SelectNodes("/person/positions/position/company");
                    if (xmlNodeList5.Count > 0)
                    {
                        if (xmlNodeList5[index]["name"] != null)
                            CompanyName = xmlNodeList5[index]["name"].InnerText;
                        if (xmlNodeList5[index]["industry"] != null)
                            IndustryName = xmlNodeList5[index]["industry"].InnerText;
                    }
                    int result1;
                    int result2;
                    if (int.TryParse(s1, out result1) && int.TryParse(s2, out result2))
                    {
                        DateTime dateTime1 = new DateTime(result1, result2, 1);
                        if (!Is_CurrentlyWorking)
                        {
                            if (xmlDocument.SelectNodes("/person/positions/position/end-date").Count > 0)
                            {
                                if (xmlNodeList4[index]["end-date"] != null && xmlNodeList4[index]["end-date"]["year"] != null)
                                    s3 = xmlNodeList4[index]["end-date"]["year"].InnerXml;
                                if (xmlNodeList4[index]["end-date"] != null && xmlNodeList4[index]["end-date"]["month"] != null)
                                    s4 = xmlNodeList4[index]["end-date"]["month"].InnerXml;
                            }
                            int result3;
                            int.TryParse(s3, out result3);
                            int result4;
                            int.TryParse(s4, out result4);
                            DateTime dateTime2 = new DateTime(result3, result4, 1);
                            UpdateCandidateExperience(PositionTitle, PositionSummary, CompanyName, dateTime1.ToString(), dateTime2.ToString(), IndustryName, Is_CurrentlyWorking, PositionID);
                        }
                        else
                            UpdateCandidateExperience(PositionTitle, PositionSummary, CompanyName, dateTime1.ToString(), "", IndustryName, Is_CurrentlyWorking, PositionID);
                    }
                    else if (!Is_CurrentlyWorking)
                    {
                        if (xmlDocument.SelectNodes("/person/positions/position/end-date").Count > 0)
                        {
                            if (xmlNodeList4[index]["end-date"] != null && xmlNodeList4[index]["end-date"]["year"] != null)
                                s3 = xmlNodeList4[index]["end-date"]["year"].InnerXml;
                            if (xmlNodeList4[index]["end-date"] != null && xmlNodeList4[index]["end-date"]["month"] != null)
                                s4 = xmlNodeList4[index]["end-date"]["month"].InnerXml;
                        }
                        int result3;
                        int result4;
                        if (int.TryParse(s3, out result3) && int.TryParse(s4, out result4))
                        {
                            DateTime dateTime = new DateTime(result3, result4, 1);
                            UpdateCandidateExperience(PositionTitle, PositionSummary, CompanyName, "", dateTime.ToString(), IndustryName, Is_CurrentlyWorking, PositionID);
                        }
                        else
                            UpdateCandidateExperience(PositionTitle, PositionSummary, CompanyName, "", "", IndustryName, Is_CurrentlyWorking, PositionID);
                    }
                    else
                        UpdateCandidateExperience(PositionTitle, PositionSummary, CompanyName, "", "", IndustryName, Is_CurrentlyWorking, PositionID);
                }
            }
            XmlNodeList xmlNodeList6 = xmlDocument.SelectNodes("/person/educations/education");
            if (xmlNodeList6.Count > 0)
            {
                for (int index = 0; index < xmlNodeList6.Count; ++index)
                {
                    if (xmlNodeList6[index]["id"] != null)
                        EducationID = xmlNodeList6[index]["id"].InnerText;
                    if (xmlNodeList6[index]["school-name"] != null)
                        InstituteName = xmlNodeList6[index]["school-name"].InnerText;
                    if (xmlNodeList6[index]["degree"] != null)
                        DegreeName = xmlNodeList6[index]["degree"].InnerText;
                    if (xmlNodeList6[index]["field-of-study"] != null)
                        FieldName = xmlNodeList6[index]["field-of-study"].InnerText;
                    if (xmlNodeList6[index]["activities"] != null)
                        EducationActivities = xmlNodeList6[index]["activities"].InnerText;
                    if (xmlNodeList6[index]["start-date"] != null && xmlNodeList6[index]["start-date"]["year"] != null)
                        StartDate = xmlNodeList6[index]["start-date"]["year"].InnerXml;
                    if (xmlNodeList6[index]["end-date"] != null && xmlNodeList6[index]["end-date"]["year"] != null)
                        EndDate = xmlNodeList6[index]["end-date"]["year"].InnerXml;
                    UpdateCandidateEducationInformation(InstituteName, DegreeName, FieldName, StartDate, EndDate, EducationID, EducationActivities);
                }
            }
            XmlNodeList xmlNodeList7 = xmlDocument.SelectNodes("/person/certifications/certification");
            if (xmlNodeList7.Count > 0)
            {
                for (int index = 0; index < xmlNodeList7.Count; ++index)
                {
                    if (xmlNodeList7[index]["id"] != null)
                        CertificateID = xmlNodeList7[index]["id"].InnerXml;
                    UpdateCandidateCertificate(xmlNodeList7[index]["name"].InnerXml, CertificateID);
                }
            }
            XmlNodeList xmlNodeList8 = xmlDocument.SelectNodes("/person/skills/skill");
            if (xmlNodeList8.Count > 0)
            {
                for (int index = 0; index < xmlNodeList8.Count; ++index)
                {
                    if (xmlNodeList8[index]["skill"] != null && xmlNodeList8[index]["skill"]["name"] != null)
                        SkillName = xmlNodeList8[index]["skill"]["name"].InnerXml;
                    if (xmlNodeList8[index]["id"] != null)
                        SkillID = xmlNodeList8[index]["id"].InnerXml;
                    UpdateCandidateSkill(SkillName, SkillID);
                    if (index == 0)
                    {
                        using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                        {
                            sqlConn.Open();
                            StatusManagement.MarkProfileStatus(sqlConn, CandidateCode, Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.MarkedSkillSetPortfolioPending, Request.UserHostAddress, CandidateCode, Constants.ProfileNavigation.SkillSet);
                        }
                    }
                }
            }
        }
    }

    private void UpdateCandidateCertificate(string CertificateName, string CertificateID)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_Update_CandidateCertificateLinkedin", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandidateCode", Session["CC"].ToString());
                sqlCommand.Parameters.AddWithValue("@CertificateName", CertificateName);
                sqlCommand.Parameters.AddWithValue("@CertificateID", CertificateID);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    private void UpdateCandidateSkill(string SkillName, string SkillID)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_Update_CandidateSkillsLinkedin", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandidateCode", Session["CC"].ToString());
                sqlCommand.Parameters.AddWithValue("@SkillName", SkillName);
                sqlCommand.Parameters.AddWithValue("@SkillID", SkillID);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    private void UpdateCandidateExperience(string PositionTitle, string PositionSummary, string CompanyName, string StartDate, string EndDate, string IndustryName, bool Is_CurrentlyWorking, string PositionID)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_Update_CandidateExperienceLinkedin", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandidateCode", Session["CC"].ToString());
                sqlCommand.Parameters.AddWithValue("@Title", PositionTitle);
                sqlCommand.Parameters.AddWithValue("@Summary", PositionSummary);
                sqlCommand.Parameters.AddWithValue("@Company", CompanyName);
                sqlCommand.Parameters.AddWithValue("@PositionID", PositionID);
                sqlCommand.Parameters.AddWithValue("@StartDate", StartDate.ToString());
                if (EndDate.ToString() != "")
                    sqlCommand.Parameters.AddWithValue("@EndDate", EndDate.ToString());
                sqlCommand.Parameters.AddWithValue("@IndustryName", IndustryName);
                sqlCommand.Parameters.AddWithValue("@Is_CurrentlyWorking", Is_CurrentlyWorking);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    private void UpdateCandidatePersonalInformation(string FullName, string emailaddress, string DateOfBirthDay, string DateOfBirthMonth, string DateOfBirthYear, string phonenumber, string Address)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_Update_CandidatePersonalInformationLinkedin", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandidateCode", Session["CC"].ToString());
                sqlCommand.Parameters.AddWithValue("@FullName", FullName);
                sqlCommand.Parameters.AddWithValue("@EmailAddress", emailaddress);
                sqlCommand.Parameters.AddWithValue("@DateOfBirthDay", DateOfBirthDay);
                sqlCommand.Parameters.AddWithValue("@DateOfBirthMonth", DateOfBirthMonth);
                sqlCommand.Parameters.AddWithValue("@DateOfBirthYear", DateOfBirthYear);
                sqlCommand.Parameters.AddWithValue("@MainAddress", Address);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", phonenumber);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    private void UpdateCandidateEducationInformation(string InstituteName, string DegreeName, string FieldName, string StartDate, string EndDate, string EducationID, string EducationActivities)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_Update_CandidateEducationLinkedin", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandidateCode", Session["CC"].ToString());
                sqlCommand.Parameters.AddWithValue("@InstituteName", InstituteName);
                sqlCommand.Parameters.AddWithValue("@DegreeName", DegreeName);
                sqlCommand.Parameters.AddWithValue("@FieldName", FieldName);
                sqlCommand.Parameters.AddWithValue("@EducationID", EducationID);
                if (StartDate.ToString() != "")
                    sqlCommand.Parameters.AddWithValue("@StartDate", StartDate.ToString());
                if (EndDate.ToString() != "")
                    sqlCommand.Parameters.AddWithValue("@EndDate", EndDate.ToString());
                sqlCommand.Parameters.AddWithValue("@EducationActivities", EducationActivities);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    private DataSet GetXMLFromDataBase()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_Select_CandidateLinkedinXML", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add(new SqlParameter("@CandidateCode", Session["CC"].ToString()));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }

    public static string GetXml(string url)
    {
        string inputUri = url;
        XmlReaderSettings settings = new XmlReaderSettings()
        {
            IgnoreWhitespace = true
        };
        using (XmlReader reader = XmlReader.Create(inputUri, settings))
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create((TextWriter)stringWriter))
                    xmlWriter.WriteNode(reader, false);
                return stringWriter.ToString();
            }
        }
    }
    #endregion




}


