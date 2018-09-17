using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using XRecruitmentStatusLibrary;
using System.Data;
using ErrorLog;

public partial class profile_referral : CustomBaseClass
{

    #region Page Variables
    int CanCode = 0;
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    string FinishBtnText = ConfigurationManager.AppSettings["FinishButton"].ToString();
    SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    #endregion Page Variables

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            if (Convert.ToInt32(Constants.ProfileNavigation.WheredidyouhearaboutAxactReferral) == Convert.ToInt32(GeneralMethods.GetProfileNavCount(SqlConn, CandidateCode).Rows[0]["FinishCode"].ToString()))
                btnSave.Text = FinishBtnText;
            CanCode = CandidateCode;
            BindMedium();
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    private void BindMedium()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
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
                rblMedium.Items[0].Selected = true;
            }
        }
    }

    protected void btnProceed_Click(object sender, EventArgs e)
    {
        try
        {
            SaveReferralCode();
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            sqlConn.Open();
            StatusManagement.MarkProfileStatus(sqlConn, CandidateCode, Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.ReferralsDoneDocumentsUploadingPending, Request.UserHostAddress, AdminUserCode == -1 ? CandidateCode : AdminUserCode, Constants.ProfileNavigation.WheredidyouhearaboutAxactReferral);
            if (sqlConn.State != ConnectionState.Closed)
                sqlConn.Close();
            if (btnSave.Text == FinishBtnText)
                Response.Redirect(DomainAddress + "/area/viewprofile.aspx", false);
            else
                Response.Redirect(DomainAddress + "/profile/redirector.aspx", false);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    private void SaveReferralCode()
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateReferralCode", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
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
                sqlCommand.Parameters.AddWithValue("@UpdatedBy", (AdminUserCode == -1 ? CandidateCode : AdminUserCode));
                sqlCommand.Parameters.AddWithValue("@UpdatedIp", Request.UserHostAddress);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Redirect(DomainAddress + "CandidateArea/Area.aspx", false);
    }

    private void BindData()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateReferralCode", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet != null && dataSet.Tables != null && dataSet.Tables[0].Rows.Count > 0)
            {
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
                else if (dataSet.Tables[0].Rows[0]["Medium_Code"].ToString() == "6")
                {
                    txtOtherMedium.Text = dataSet.Tables[0].Rows[0]["Other_Medium"].ToString();
                    xAxactian.Attributes.Add("class", "hidden");
                    xRefDetails.Attributes.Add("class", "hidden");
                    xOtherRef.Attributes.Remove("class");
                }
            }
            if (dataSet.Tables.Count < 2 || dataSet.Tables[1].Rows.Count <= 0)
                return;
            if (Convert.ToInt32(dataSet.Tables[1].Rows[0]["Status_Code"].ToString()) >= 1020 || AdminUserCode != -1)
                txtReferenceCode.Enabled = false;
            else
                txtReferenceCode.Attributes.Remove("Enabled");
        }
    }
    #endregion
}