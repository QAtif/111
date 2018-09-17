using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using ErrorLog;
using System.Data.SqlClient;
using System.Collections;

public partial class ELogin : System.Web.UI.Page
{
    #region Page Variables
    SecureQueryString oSecureString = null;
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString = new SecureQueryString();
    #endregion Page Variables

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CheckQs();
            if (!(hdnCandidateCode.Value != "0") || !(hdnCandidateCode.Value != string.Empty) || (!(hdnURL.Value != "") || !(hdnURL.Value != string.Empty)))
                return;
            if (Session["CC"] != null)
                HttpContext.Current.Response.Redirect(hdnURL.Value, false);
            else
                BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "");
        }
    }

    private void BindData()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_Select_CandidateLoginDetail", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add("@Candidate_Code", hdnCandidateCode.Value);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                {
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet.Tables.Count <= 0 || dataSet.Tables[0].Rows.Count <= 0)
                        return;
                    lblEmail.Text = dataSet.Tables[0].Rows[0]["Email_Address"].ToString();
                }
            }
        }
    }

    private void CheckQs()
    {
        if (Request.QueryString[SecureQueryString.QueryStringVar] == null)
            return;
        Hashtable hashtable = Utilities.decryptQueryString(Request.QueryString[SecureQueryString.QueryStringVar].ToString());
        hdnCandidateCode.Value = hashtable["candcode"] != null ? hashtable["candcode"].ToString() : string.Empty;
        hdnURL.Value = hashtable["url"] != null ? hashtable["url"].ToString() : string.Empty;
    }

    protected void btnSignIn_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (!Page.IsValid)
                return;
            if (hdnCandidateCode.Value != "0" && hdnCandidateCode.Value != string.Empty && (hdnURL.Value != "" && hdnURL.Value != string.Empty))
            {
                DataSet dataSet1 = new DataSet();
                DataSet dataSet2 = CandidateSignIn();
                if (dataSet2 != null && dataSet2.Tables != null && (dataSet2.Tables.Count > 0 && dataSet2.Tables[0].Rows.Count > 0))
                {
                    bool boolean1 = Convert.ToBoolean(dataSet2.Tables[0].Rows[0]["is_EmailVerified"]);
                    bool boolean2 = Convert.ToBoolean(dataSet2.Tables[0].Rows[0]["is_PhoneVerified"]);
                    bool boolean3 = Convert.ToBoolean(dataSet2.Tables[0].Rows[0]["Is_Migrated"]);
                    Session["CC"] = dataSet2.Tables[0].Rows[0]["Candidate_Code"].ToString();
                    if (boolean2 || boolean1 || boolean3)
                        Response.Redirect(hdnURL.Value, false);
                    else
                        Response.Redirect(DomainAddress + "verification.aspx", false);
                }
                else
                {
                    lblError.Text = "Invalid Email and Password combination";
                    vldLoginFailed.IsValid = false;
                }
            }
            else
            {
                lblError.Text = "Error Occurred";
                vldLoginFailed.IsValid = false;
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "");
        }
    }


    #endregion

    #region Methods
    public DataSet CandidateSignIn()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_CandidateSignIn", connection))
            {
                oSecureString = new SecureQueryString();
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add(new SqlParameter("@EmailOrMob", lblEmail.Text.TrimStart('0')));
                selectCommand.Parameters.Add(new SqlParameter("@Password", oSecureString.encrypt(txtPassword.Text)));
                selectCommand.Parameters.Add(new SqlParameter("@UpdatedIP", Request.UserHostAddress));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }



    #endregion
}