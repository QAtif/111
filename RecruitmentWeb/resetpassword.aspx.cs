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
using facebook;
using System.Net;
using System.IO;
using System.Xml;
using System.Security.Cryptography;
using System.Text;
using System.Collections;


public partial class ResetPassword : System.Web.UI.Page
{
    #region Variable

    SecureQueryString oSecureString = null;
    string candidateCode = string.Empty;
    string emailAddress = string.Empty;
    string expiryTime = string.Empty;
    string qs = string.Empty;

    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CheckQueryString();
            lblMsg.Text = "";
            if (IsPostBack || !(emailAddress != "0") || (!(emailAddress != string.Empty) || !(candidateCode != "0")) || (!(candidateCode != string.Empty) || !(expiryTime != "0") || !(expiryTime != string.Empty)) || !(Convert.ToDateTime(expiryTime).Date != DateTime.Now.Date) && !(DateTime.Now >= Convert.ToDateTime(expiryTime).AddHours(2.0)))
                return;
            dvForm.Attributes.Add("style", "Display:none");
            dvbtn.Attributes.Add("style", "Display:none");
            lblMsg.Text = "Your Reset Password Link is expired.";
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "0");
        }
    }

    protected void btnSendPassword_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (!Page.IsValid)
                return;
            DataSet dataSet1 = new DataSet();
            DataSet dataSet2 = ChangeCandidatePassword();
            if (dataSet2 != null && dataSet2.Tables != null && dataSet2.Tables[0].Rows.Count > 0)
            {
                if (dataSet2.Tables[0].Rows[0]["Result"].ToString() != "0")
                {
                    lblMsg.Text = dataSet2.Tables[0].Rows[0]["Msg"].ToString();
                    aLogin.Style.Add("display", "");
                    dvForm.Attributes.Add("style", "Display:none");
                    dvbtn.Attributes.Add("style", "Display:none");
                }
                else
                {
                    aLogin.Style.Add("display", "none");
                    lblMsg.Text = dataSet2.Tables[0].Rows[0]["Msg"].ToString();
                }
            }
            else
            {
                aLogin.Style.Add("display", "none");
                lblMsg.Text = lblMsg.Text = dataSet2.Tables[0].Rows[0]["Msg"].ToString();
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Session["CC"].ToString());
        }
    }
    #endregion

    #region Methods

    private void CheckQueryString()
    {
        if (Request.QueryString[SecureQueryString.QueryStringVar] == null)
            return;
        Hashtable hashtable = Utilities.decryptQueryString(Request.QueryString[SecureQueryString.QueryStringVar].ToString());
        candidateCode = hashtable["cid"] != null ? hashtable["cid"].ToString() : string.Empty;
        hdncandidateCode.Value = hashtable["cid"] != null ? hashtable["cid"].ToString() : string.Empty;
        emailAddress = hashtable["email"] != null ? hashtable["email"].ToString() : string.Empty;
        hdnemailAddress.Value = hashtable["email"] != null ? hashtable["email"].ToString() : string.Empty;
        expiryTime = hashtable["expiry"] != null ? hashtable["expiry"].ToString() : string.Empty;
        hdnexpiry.Value = hashtable["expiry"] != null ? hashtable["expiry"].ToString() : string.Empty;
        qs = Request.QueryString[SecureQueryString.QueryStringVar];
    }

    public DataSet ChangeCandidatePassword()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_RestCandidatePassword", connection))
                {
                    oSecureString = new SecureQueryString();
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.Add(new SqlParameter("@NewPassword", oSecureString.encrypt(txtNewPassword.Text.ToString())));
                    selectCommand.Parameters.Add(new SqlParameter("@EmailAddres", hdnemailAddress.Value));
                    selectCommand.Parameters.Add(new SqlParameter("@CandidateCode", hdncandidateCode.Value));
                    selectCommand.Parameters.Add(new SqlParameter("@UpdatedBy", hdncandidateCode.Value));
                    selectCommand.Parameters.Add(new SqlParameter("@UpdationIP ", Request.UserHostAddress.ToString()));
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Session["CC"].ToString());
            }
        }
        return dataSet;
    }



    #endregion

}