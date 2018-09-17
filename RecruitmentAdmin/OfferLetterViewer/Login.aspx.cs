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

namespace XRecruitmentAdmin.OfferLetterViewer
{
    public partial class Login : System.Web.UI.Page
    {
        #region Events
        SecureQueryString objSecureQueryString = null;
        int CandidateCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["CC"] != null)
                    {
                        CandidateCode = int.Parse(Session["CC"].ToString());
                        HttpContext.Current.Response.Redirect("OfferLetter.aspx?CC=" + Server.UrlEncode(objSecureQueryString.encrypt(CandidateCode.ToString())), false);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "");
            }
        }
        protected void btnSignIn_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (!Page.IsValid)
                    return;

                DataSet ds = new DataSet();
                ds = CandidateSignIn();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                        Session["CC"] = ds.Tables[0].Rows[0]["CandidateCode"].ToString();
                        CandidateCode = int.Parse(ds.Tables[0].Rows[0]["CandidateCode"].ToString());


                        HttpContext.Current.Response.Redirect("OfferLetter.aspx?CC=" + Server.UrlEncode(objSecureQueryString.encrypt(CandidateCode.ToString())), false);
                    
                }
                else
                {
                    lblMsg.Text = "Your are not Authorize to Proceed.";
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "");
            }
        }
        #endregion

        #region Methods

        public DataSet CandidateSignIn()
        {
            objSecureQueryString = new SecureQueryString();
            DataSet objDS = new DataSet();
            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ToString()))
            {
                c.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("XRec_CandidateSignForOfferLetterViewer", c))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@EmailOrMob", txtCell.Text.TrimStart('0')));
                        command.Parameters.Add(new SqlParameter("@Password", objSecureQueryString.encrypt(txtPassword.Text)));
                        command.Parameters.Add(new SqlParameter("@RefNo", txtPassword.Text));
                        using (SqlDataAdapter a = new SqlDataAdapter(command))
                        {
                            a.Fill(objDS);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "");
                }
            }
            return objDS;
        }
        #endregion
    }
}