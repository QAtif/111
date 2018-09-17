using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using ErrorLog;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;


public partial class A2_PLRecruitment_PLSignUp : CustomBasePage
{

   SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
   SecureQueryString secQueryString = new SecureQueryString();
   string QueryStringVar = string.Empty;
   string CandidateCode = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            if (QueryStringVar != null)
            {
                secQueryString = new SecureQueryString(QueryStringVar);
                CandidateCode = secQueryString["CID"].ToString();
            }
            if (IsPostBack)
                return;
            BindPhoneCodes();
            ShowHideActions();
            if (string.IsNullOrEmpty(CandidateCode))
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            DataSet dataSet = new DataSet();
            using (SqlCommand selectCommand = new SqlCommand("Xrec_SelectALreadySignUpCandidate", connection))
            {
                selectCommand.Parameters.AddWithValue("@candidateCode", CandidateCode);
                selectCommand.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                {
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet == null || dataSet.Tables[0].Rows.Count < 1)
                        return;
                    txtName.Text = dataSet.Tables[0].Rows[0]["full_name"].ToString();
                    txtName.Enabled = false;
                    txtPhoneNumber.Text = dataSet.Tables[0].Rows[0]["phone_number"].ToString();
                    txtPhoneNumber.Enabled = false;
                    ddlPhoneCodes.Visible = false;
                    txtEmail.Text = dataSet.Tables[0].Rows[0]["email_address"].ToString();
                    txtEmail.Enabled = false;
                    ddlRefferredBy.SelectedValue = dataSet.Tables[0].Rows[0]["userid"].ToString();
                    if (Convert.ToInt32(dataSet.Tables[0].Rows[0]["status_code"].ToString()) <= 1040)
                    {
                        lblStatus.Text = dataSet.Tables[0].Rows[0]["Status_Display_Text"].ToString();
                    }
                    else
                    {
                        ddlRefferredBy.Enabled = false;
                        lblStatus.Text = dataSet.Tables[0].Rows[0]["Status_Display_Text"].ToString() + ". Already mapped. Please contact to HR";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(CandidateCode))
            {
                string empty1 = string.Empty;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string str1 = new SecureQueryString().encrypt(GetRandomCode(8));
                int length = 6;
                string randomCode1 = GetRandomCode(length);
                string randomCode2 = GetRandomCode(length);
                string empty4 = string.Empty;
                string str2 = ddlPhoneCodes.SelectedValue.ToString() + txtPhoneNumber.Text.ToString();
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand selectCommand = new SqlCommand("dbo.XRec_PLCreateCandidateSignup", connection);
                selectCommand.Parameters.Add("@FullName", SqlDbType.VarChar).Value = txtName.Text;
                if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
                    selectCommand.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = txtEmail.Text.Trim();
                selectCommand.Parameters.AddWithValue("@PhoneNumber", SqlDbType.VarChar).Value = str2;
                selectCommand.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = str1;
                selectCommand.Parameters.AddWithValue("@PhoneVerificationCode", SqlDbType.VarChar).Value = randomCode1;
                selectCommand.Parameters.AddWithValue("@UpdationIP", SqlDbType.VarChar).Value = USERIP;
                selectCommand.Parameters.AddWithValue("@stupdatedBy", SqlDbType.Int).Value = Convert.ToInt32(UserCode);
                selectCommand.Parameters.AddWithValue("@EmailVerificationCode", SqlDbType.VarChar).Value = randomCode2;
                selectCommand.Parameters.AddWithValue("@CurrentURL", Request.Url.ToString());
                selectCommand.Parameters.AddWithValue("@ReferralURL", Request.UrlReferrer.ToString());
                if (ddlRefferredBy.SelectedValue != "-1")
                    selectCommand.Parameters.Add("@ReferralPortalID", SqlDbType.Int).Value = Convert.ToInt32(ddlRefferredBy.SelectedValue);
                selectCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
                if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count > 0)
                {
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        if (dataSet.Tables[0].Rows[0]["CandidateCode"].ToString() != "0")
                        {
                            lblError.Text = "Saved Successfully. Candidate Refference No. is " + dataSet.Tables[0].Rows[0]["RefNo"].ToString();
                            Clearfields();
                        }
                        else
                        {
                            if (dataSet.Tables[0].Rows[0]["EmailAddressExist"].ToString() == "1")
                                lblError.Text = "Email Address Already Exist. <br/>";
                            if (dataSet.Tables[0].Rows[0]["MobileNumberExist"].ToString() == "1")
                                lblError.Text = "Phone Number Already Exist. <br/>";
                            if (!(dataSet.Tables[0].Rows[0]["EmailAddressExist"].ToString() == "1") || !(dataSet.Tables[0].Rows[0]["MobileNumberExist"].ToString() == "1"))
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
            else
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.XRec_PLUpdateReferral", connection);
                sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(CandidateCode);
                sqlCommand.Parameters.Add("@ReferralPortalID", SqlDbType.Int).Value = Convert.ToInt32(ddlRefferredBy.SelectedValue);
                sqlCommand.Parameters.Add("@Updaed_by", SqlDbType.Int).Value = UserCode;
                sqlCommand.Parameters.Add("@Updated_ip", SqlDbType.VarChar).Value = USERIP;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
                lblError.Text = "Sucessfully Updated!";
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    public void BindPhoneCodes()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
        DataSet dataSet1 = new DataSet();
        using (SqlCommand selectCommand = new SqlCommand("XRec_SelectService", connection))
        {
            selectCommand.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
            {
                sqlDataAdapter.Fill(dataSet1);
                ddlPhoneCodes.DataSource = dataSet1.Tables[0];
                ddlPhoneCodes.DataTextField = "ServiceName";
                ddlPhoneCodes.DataValueField = "ServiceName";
                ddlPhoneCodes.DataBind();
            }
        }
        DataSet dataSet2 = new DataSet();
        using (SqlCommand selectCommand = new SqlCommand("XRec_AllUsers", connection))
        {
            selectCommand.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
            {
                sqlDataAdapter.Fill(dataSet2);
                ddlRefferredBy.DataSource = dataSet2.Tables[0];
                ddlRefferredBy.DataTextField = "name";
                ddlRefferredBy.DataValueField = "id";
                ddlRefferredBy.DataBind();
            }
            ddlRefferredBy.Items.Insert(0, new ListItem("None", "-1"));
        }
    }

    public void Clearfields()
    {
        txtEmail.Text = "";
        txtName.Text = "";
        txtPhoneNumber.Text = "";
    }

    private void ShowHideActions()
    {
        IEnumerable<HtmlGenericControl> allControlsOfType = Page.GetAllControlsOfType<HtmlGenericControl>();
        foreach (DataRow row in (InternalDataCollectionBase)DTActions.Rows)
        {
            foreach (Control control in allControlsOfType)
            {
                if (control.ClientID == "divAction" + row["MenuLinkActionCode"].ToString())
                    control.Visible = true;
            }
        }
    }

    public string GetRandomCode(int length)
    {
        string str = Guid.NewGuid().ToString().Replace("-", string.Empty);
        if (length <= 0 || length > str.Length)
            throw new ArgumentException("Length must be between 1 and " + str.Length);
        return str.Substring(0, length);
    }
}