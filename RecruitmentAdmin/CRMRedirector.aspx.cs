using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using XRecruitmentStatusLibrary;

public partial class CRMRedirector : System.Web.UI.Page
{

    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString = new SecureQueryString();
    string candidatecode = string.Empty;
    string agentcode = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString[SecureQueryString.QueryStringVar] == null)
            return;
        Hashtable hashtable = Utilities.decryptQueryString(Request.QueryString[SecureQueryString.QueryStringVar].ToString());
        candidatecode = hashtable["CustomerCode"] != null ? hashtable["CustomerCode"].ToString() : string.Empty;
        agentcode = hashtable["ac"] != null ? hashtable["ac"].ToString() : string.Empty;
        if (candidatecode != string.Empty && agentcode != string.Empty)
        {
            DataTable candidateStatus = GetCandidateStatus(candidatecode);
            if (candidateStatus.Rows.Count > 0)
            {
                if (candidateStatus.Rows[0]["Status_Code"].ToString() == "1003")
                {
                    string serializedQueryString = "candidate_code=" + candidatecode + "&url=" + ConfigurationManager.AppSettings["WebDomainAddress"].ToString() + "Signup.aspx&utc=" + Convert.ToInt32(Constants.UserTypeCode.Admin) + "&auc=" + agentcode;
                    Response.Redirect(ConfigurationManager.AppSettings["WebDomainAddress"].ToString() + "AdminRedirector.aspx?" + SecureQueryString.QueryStringVar + "=" + secQueryString.encrypt(serializedQueryString), false);
                }
                else
                    Response.Redirect(ConfigurationManager.AppSettings["Domain_Address"].ToString() + "RecruitmentRedirector.aspx?uid=" + agentcode + "&url=" + ConfigurationManager.AppSettings["Domain_Address"].ToString() + "/A2/Candidate/CandidateProfile.aspx?" + SecureQueryString.QueryStringVar + "=" + secQueryString.encrypt("CID=" + candidatecode), false);
            }
            else
                Response.Redirect(ConfigurationSettings.AppSettings["NotAuthorize"], true);
        }
        else
            Response.Redirect(ConfigurationSettings.AppSettings["NotAuthorize"], true);
    }

    private DataTable GetCandidateStatus(string candidatecode)
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_Select_CandidateStatusByCode", connection))
            {
                secQueryString = new SecureQueryString();
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add(new SqlParameter("@Candidate_Code", candidatecode));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataTable);
            }
        }
        return dataTable;
    }

}