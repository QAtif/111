using System;
using ErrorLog;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;

public partial class Candidate_Profile_referral : CustomBasePage, IRequiresSessionState
{
    private string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    private SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString());
    private string QueryStringVar = string.Empty;
    private int CanCode;
    public static string CID;
    private SecureQueryString secQueryString;
    protected void Page_Load(object sender, EventArgs e)
    {
        QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
        if (QueryStringVar == null)
            return;
        secQueryString = new SecureQueryString(QueryStringVar);
        if (secQueryString["CID"] == null)
            return;
        Candidate_Profile_referral.CID = secQueryString["CID"].ToString();
        try
        {
            if (IsPostBack)
                return;
            CanCode = int.Parse(Candidate_Profile_referral.CID);
            BindMedium();
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_referral.CID);
        }
    }

    private void BindMedium()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectMedium", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
                if (dataSet == null || dataSet.Tables == null || dataSet.Tables[0].Rows.Count <= 0)
                    return;
                rblMedium.DataSource = dataSet.Tables[0];
                rblMedium.DataTextField = "Medium";
                rblMedium.DataValueField = "Medium_Code";
                rblMedium.DataBind();
            }
        }
    }

    protected void btnProceed_Click(object sender, EventArgs e)
    {
        try
        {
            SaveReferralCode();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString());
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_referral.CID);
        }
    }

    private void SaveReferralCode()
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateReferralCodeAdmin", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandidateCode", Candidate_Profile_referral.CID);
                sqlCommand.Parameters.AddWithValue("@MediumCode", rblMedium.SelectedValue);
                if (rblMedium.SelectedValue == "4")
                {
                    sqlCommand.Parameters.AddWithValue("@AxactianName", txtAxactianName.Text);
                    sqlCommand.Parameters.AddWithValue("@AxactianDepartment", txtDepartment.Text);
                }
                else if (rblMedium.SelectedValue == "5")
                    sqlCommand.Parameters.AddWithValue("@refferalCode", txtReferenceCode.Text);
                else if (rblMedium.SelectedValue == "6")
                    sqlCommand.Parameters.AddWithValue("@OtherMedium", txtOtherMedium.Text);
                sqlCommand.Parameters.AddWithValue("@UpdatedBy", Candidate_Profile_referral.CID);
                sqlCommand.Parameters.AddWithValue("@UpdatedIp", Request.UserHostAddress);
                sqlCommand.Parameters.AddWithValue("@UserType", 1);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
    }

    private void BindData()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateReferralCode", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", Candidate_Profile_referral.CID);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet == null || dataSet.Tables == null || dataSet.Tables[0].Rows.Count <= 0)
                return;
            rblMedium.SelectedValue = dataSet.Tables[0].Rows[0]["Medium_Code"].ToString();
            if (dataSet.Tables[0].Rows[0]["Medium_Code"].ToString() == "1")
            {
                xAxactian.Attributes.Add("class", "hidden");
                xRefDetails.Attributes.Add("class", "hidden");
                xOtherRef.Attributes.Add("class", "hidden");
            }
            else if (dataSet.Tables[0].Rows[0]["Medium_Code"].ToString() == "2")
            {
                xAxactian.Attributes.Add("class", "hidden");
                xRefDetails.Attributes.Add("class", "hidden");
                xOtherRef.Attributes.Add("class", "hidden");
            }
            else if (dataSet.Tables[0].Rows[0]["Medium_Code"].ToString() == "3")
            {
                xAxactian.Attributes.Add("class", "hidden");
                xRefDetails.Attributes.Add("class", "hidden");
                xOtherRef.Attributes.Add("class", "hidden");
            }
            else if (dataSet.Tables[0].Rows[0]["Medium_Code"].ToString() == "4")
            {
                txtAxactianName.Text = dataSet.Tables[0].Rows[0]["Axactian_Name"].ToString();
                txtDepartment.Text = dataSet.Tables[0].Rows[0]["Axactian_Department"].ToString();
                xAxactian.Attributes.Remove("class");
                xRefDetails.Attributes.Add("class", "hidden");
                xOtherRef.Attributes.Add("class", "hidden");
            }
            else if (dataSet.Tables[0].Rows[0]["Medium_Code"].ToString() == "5")
            {
                txtReferenceCode.Text = dataSet.Tables[0].Rows[0]["Referral"].ToString();
                xAxactian.Attributes.Add("class", "hidden");
                xRefDetails.Attributes.Remove("class");
                xOtherRef.Attributes.Add("class", "hidden");
            }
            else
            {
                if (!(dataSet.Tables[0].Rows[0]["Medium_Code"].ToString() == "6"))
                    return;
                txtOtherMedium.Text = dataSet.Tables[0].Rows[0]["Other_Medium"].ToString();
                xAxactian.Attributes.Add("class", "hidden");
                xRefDetails.Attributes.Add("class", "hidden");
                xOtherRef.Attributes.Remove("class");
            }
        }
    }
}