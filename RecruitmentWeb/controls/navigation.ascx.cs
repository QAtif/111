using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Specialized;
using ErrorLog;
using XRecruitmentStatusLibrary;

public partial class controls_navigation : System.Web.UI.UserControl
{
    int CanCode = 0;
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        //System.Uri url = Context.Request.UrlReferrer;
        //string referringURL = System.IO.Path.GetFileName(url.LocalPath);

        string CurrentUrl = HttpContext.Current.Request.Url.AbsoluteUri;

        CanCode = int.Parse(Session["CC"].ToString());
        DataSet ds = new DataSet();
        GetProfileLinksAndStatus(CanCode, ref ds);
        SetActiveLink(CurrentUrl, ref ds);
    }

    private void SetActiveLink(string CurrentUrl, ref DataSet ds)
    {
        //if (CurrentUrl.Contains("experience.aspx"))
        //    liProf.Attributes.Add("class", "active");
        //else if (CurrentUrl.Contains("education.aspx"))
        //    liEdu.Attributes.Add("class", "active");
        //else if (CurrentUrl.Contains("diploma.aspx"))
        //    liDip.Attributes.Add("class", "active");
        //else if (CurrentUrl.Contains("certificate.aspx"))
        //    liCert.Attributes.Add("class", "active");
        //else if (CurrentUrl.Contains("skillset.aspx"))
        //    liSkill.Attributes.Add("class", "active");
        //else if (CurrentUrl.Contains("portfolio.aspx"))
        //    liPort.Attributes.Add("class", "active");
        //else if (CurrentUrl.Contains("personaldetails.aspx"))
        //    liPD.Attributes.Add("class", "active");
        //else if (CurrentUrl.Contains("referral.aspx"))
        //    liRef.Attributes.Add("class", "active");
        //else if (CurrentUrl.Contains("uploaddocuments.aspx"))
        //    liDoc.Attributes.Add("class", "active");
        //else if (CurrentUrl.Contains("familydetails.aspx"))
        //    liFD.Attributes.Add("class", "active");

        if (ds.Tables[1] != null)
        {
            int NavCode = 0;
            int newNavCode = 0;
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                newNavCode = Convert.ToInt32(dr["NavigationCode"]);
                bool isCompleted = Convert.ToBoolean(dr["Completed"]);
                bool isVerified = Convert.ToBoolean(dr["Verified"]);
                string navURL = dr["NavigationURL"].ToString();
                string cssClass = string.Empty;

                if (newNavCode != NavCode)
                {
                    NavCode = newNavCode;
                    if (!isVerified)
                        cssClass += " actionrequired";
                    else if (isCompleted)
                        cssClass += " completed";
                    if (CurrentUrl.Contains(navURL))
                        cssClass += " active";
                    //liProf.Attributes.Add("class", cssClass);

                    switch (newNavCode)
                    {
                        case (int)Constants.ProfileNavigation.ProfessionalExperience:
                            liProf.Attributes.Add("class", cssClass);
                            break;
                        case (int)Constants.ProfileNavigation.EducationalQualification:
                            liEdu.Attributes.Add("class", cssClass);
                            break;
                        case (int)Constants.ProfileNavigation.Diploma:
                            liDip.Attributes.Add("class", cssClass);
                            break;
                        case (int)Constants.ProfileNavigation.Certification:
                            liCert.Attributes.Add("class", cssClass);
                            break;
                        case (int)Constants.ProfileNavigation.SkillSet:
                            liSkill.Attributes.Add("class", cssClass);
                            break;
                        case (int)Constants.ProfileNavigation.Portfolio:
                            liPort.Attributes.Add("class", cssClass);
                            break;
                        case (int)Constants.ProfileNavigation.PersonalDetails:
                            liPD.Attributes.Add("class", cssClass);
                            break;
                        case (int)Constants.ProfileNavigation.WheredidyouhearaboutAxactReferral:
                            liRef.Attributes.Add("class", cssClass);
                            break;
                        case (int)Constants.ProfileNavigation.UploadDocuments:
                            liDoc.Attributes.Add("class", cssClass);
                            break;
                        case (int)Constants.ProfileNavigation.FamilyDetails:
                            liFD.Style.Add("display", "");
                            liFD.Attributes.Add("class", cssClass);
                            break;

                    }
                }

                //if (Convert.ToInt32(dr["NavigationCode"].ToString()) == (int)Constants.ProfileNavigation.ProfessionalExperience)
                //{
                //    if (CurrentUrl.Contains("experience.aspx"))
                //        liProf.Attributes.Add("class", "completed active");
                //    else
                //        liProf.Attributes.Add("class", "completed");

                //    if (dr["Verified"].ToString() == "0")
                //        liProf.Attributes.Add("class", "actionrequired");

                //}
                //else if (Convert.ToInt32(dr["NavigationCode"].ToString()) == (int)Constants.ProfileNavigation.EducationalQualification)
                //{
                //    if (CurrentUrl.Contains("education.aspx"))
                //        liEdu.Attributes.Add("class", "completed active");
                //    else
                //        liEdu.Attributes.Add("class", "completed");

                //    if (dr["Verified"].ToString() == "0")
                //        liEdu.Attributes.Add("class", "actionrequired");
                //}
                //else if (Convert.ToInt32(dr["NavigationCode"].ToString()) == (int)Constants.ProfileNavigation.Diploma)
                //{
                //    if (CurrentUrl.Contains("diploma.aspx"))
                //        liDip.Attributes.Add("class", "completed active");
                //    else
                //        liDip.Attributes.Add("class", "completed");

                //    if (dr["Verified"].ToString() == "0")
                //        liDip.Attributes.Add("class", "actionrequired");
                //}
                //else if (Convert.ToInt32(dr["NavigationCode"].ToString()) == (int)Constants.ProfileNavigation.Certification)
                //{
                //    if (CurrentUrl.Contains("certificate.aspx"))
                //        liCert.Attributes.Add("class", "completed active");
                //    else
                //        liCert.Attributes.Add("class", "completed");

                //    if (dr["Verified"].ToString() == "0")
                //        liCert.Attributes.Add("class", "actionrequired");
                //}
                //else if (Convert.ToInt32(dr["NavigationCode"].ToString()) == (int)Constants.ProfileNavigation.SkillSet)
                //{
                //    if (CurrentUrl.Contains("skillset.aspx"))
                //        liSkill.Attributes.Add("class", "completed active");
                //    else
                //        liSkill.Attributes.Add("class", "completed");
                //}
                //else if (Convert.ToInt32(dr["NavigationCode"].ToString()) == (int)Constants.ProfileNavigation.Portfolio)
                //{
                //    if (CurrentUrl.Contains("portfolio.aspx"))
                //        liPort.Attributes.Add("class", "completed active");
                //    else
                //        liPort.Attributes.Add("class", "completed");
                //}
                //else if (Convert.ToInt32(dr["NavigationCode"].ToString()) == (int)Constants.ProfileNavigation.PersonalDetails)
                //{

                //    if (CurrentUrl.Contains("personaldetails.aspx"))
                //        liPD.Attributes.Add("class", "completed active");
                //    else
                //        liPD.Attributes.Add("class", "completed");
                //}
                //else if (Convert.ToInt32(dr["NavigationCode"].ToString()) == (int)Constants.ProfileNavigation.WheredidyouhearaboutAxactReferral)
                //{
                //    if (CurrentUrl.Contains("referral.aspx"))
                //        liRef.Attributes.Add("class", "completed active");
                //    else
                //        liRef.Attributes.Add("class", "completed");
                //}
                //else if (Convert.ToInt32(dr["NavigationCode"].ToString()) == (int)Constants.ProfileNavigation.UploadDocuments)
                //{
                //    if (CurrentUrl.Contains("uploaddocuments.aspx"))
                //        liDoc.Attributes.Add("class", "completed active");
                //    else
                //        liDoc.Attributes.Add("class", "completed");
                //}
                //else if (Convert.ToInt32(dr["NavigationCode"].ToString()) == 10)
                //{
                //    liFD.Style.Add("display", "");
                //    if (Convert.ToInt32(dr["SNo"].ToString()) == 0 && CurrentUrl.Contains("familydetails.aspx"))
                //        liFD.Attributes.Add("class", "completed active");
                //    else if (Convert.ToInt32(dr["SNo"].ToString()) == -1 && CurrentUrl.Contains("familydetails.aspx"))
                //        liFD.Attributes.Add("class", "active");
                //    else
                //        liFD.Attributes.Add("class", "completed");
                //}
            }
        }


        if (ds.Tables[0].Rows.Count > 0)
        {
            dvBar.Style.Add("width", ds.Tables[0].Rows[0]["StatusProgressBar"].ToString() + "%");
            lblProgress.Text = ds.Tables[0].Rows[0]["StatusProgressBar"].ToString();
        }
        else
        {
            dvBar.Style.Add("width", "0%");
            lblProgress.Text = "0";
        }
    }

    private void GetProfileLinksAndStatus(int CanCode, ref DataSet ds)
    {
        SqlCommand command;
        command = new SqlCommand("dbo.XRec_GetProfileLinks", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@CandidateCode", CanCode);
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        adapter.Fill(ds);
    }

    private void GetProfileLinksAndStatus(int CanCode, ref DataTable dt, string SPName)
    {
        SqlCommand command;
        command = new SqlCommand(SPName, connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@CandidateCode", CanCode);
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        DataSet ds = new DataSet();
        adapter.Fill(ds);
        dt = ds.Tables[0];
    }
}