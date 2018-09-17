using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.HtmlControls;
using XRecruitmentStatusLibrary;
using ErrorLog;
using System.Web.Services;
using ASP;
using System.Web.Profile;
using System.Web.SessionState;



public partial class StaffSignUp : CustomBasePage, IRequiresSessionState
{
    #region Variables
   
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    public string UpdatedBy;


    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            bindData();
            BindPhoneCodes();
            ShowHideActions();
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
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string str1 = "HFvxqAAS6T8=";
            int length = 6;
            string randomCode1 = GetRandomCode(length);
            string randomCode2 = GetRandomCode(length);
            string empty4 = string.Empty;
            string str2 = ddlPhoneCodes.SelectedValue.ToString() + txtPhoneNumber.Text.ToString();
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand selectCommand = new SqlCommand("dbo.XRec_StaffCreateCandidateSignup", connection);
            selectCommand.Parameters.Add("@FullName", SqlDbType.VarChar).Value = txtName.Text;
            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
                selectCommand.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = txtEmail.Text.Trim();
            selectCommand.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = str2;
            selectCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = str1;
            selectCommand.Parameters.Add("@PhoneVerificationCode", SqlDbType.VarChar).Value = randomCode1;
            selectCommand.Parameters.Add("@UpdationIP", SqlDbType.VarChar).Value = USERIP;
            selectCommand.Parameters.Add("@stupdatedBy", SqlDbType.Int).Value = Convert.ToInt32(UserCode);
            selectCommand.Parameters.Add("@EmailVerificationCode", SqlDbType.VarChar).Value = randomCode2;
            if (ddlDepartment.SelectedValue != "-1")
                selectCommand.Parameters.Add("@StaffDepartment", SqlDbType.VarChar).Value = ddlDepartment.SelectedValue;
            if (ddlCategory.SelectedValue != "-1")
                selectCommand.Parameters.Add("@StaffCategory", SqlDbType.VarChar).Value = ddlCategory.SelectedValue;
            if (!string.IsNullOrEmpty(hfCompany.Value))
                selectCommand.Parameters.Add("@LastCompanycode", SqlDbType.VarChar).Value = hfCompany.Value;
            if (!string.IsNullOrEmpty(txtLastExp.Text))
                selectCommand.Parameters.Add("@LastCompanyName", SqlDbType.VarChar).Value = txtLastExp.Text;
            selectCommand.Parameters.Add("@stPositionTitleCode", SqlDbType.VarChar).Value = hfJobTitle.Value;
            if (!string.IsNullOrEmpty(txtDesignation.Text))
                selectCommand.Parameters.Add("@stPositionTitle", SqlDbType.VarChar).Value = txtDesignation.Text;
            if (ddlQualification.SelectedValue != "-1")
                selectCommand.Parameters.Add("@Qualification", SqlDbType.VarChar).Value = ddlQualification.SelectedValue;
            if (ddlUsers.SelectedValue != "-1")
                selectCommand.Parameters.Add("@ReferralPortalID", SqlDbType.Int).Value = Convert.ToInt32(ddlUsers.SelectedValue);
            selectCommand.Parameters.Add("@CurrentURL", Request.Url.ToString());
            selectCommand.Parameters.Add("@ReferralURL", Request.UrlReferrer.ToString());
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
        DataSet dataSet = new DataSet();
        using (SqlCommand selectCommand = new SqlCommand("XRec_SelectService", connection))
        {
            selectCommand.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
            {
                sqlDataAdapter.Fill(dataSet);
                ddlPhoneCodes.DataSource = dataSet.Tables[0];
                ddlPhoneCodes.DataTextField = "ServiceName";
                ddlPhoneCodes.DataValueField = "ServiceName";
                ddlPhoneCodes.DataBind();
            }
        }
    }

    protected void ddlDepartment_OnChange(object sender, EventArgs e)
    {
        try
        {
            if (!(ddlDepartment.SelectedValue != ""))
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand selectCommand = new SqlCommand("XRec_SelectCategoryOnDomain", connection);
            selectCommand.Parameters.AddWithValue("@domain_Code", ddlDepartment.SelectedValue);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                ddlCategory.DataSource = dataSet;
                ddlCategory.DataTextField = "Category_Name";
                ddlCategory.DataValueField = "Category_Code";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("Select Category", "-1"));
            }
            else
            {
                ddlCategory.Items.Clear();
                ddlCategory.Items.Insert(0, new ListItem("Select Category", "-1"));
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

    protected void ddlDep_OnChange(object sender, EventArgs e)
    {
        try
        {
            if (!(ddlDep.SelectedValue != ""))
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand selectCommand = new SqlCommand("XRec_SelectUsersOnDomain", connection);
            selectCommand.Parameters.AddWithValue("@domain_Code", ddlDep.SelectedValue);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                ddlUsers.Items.Clear();
                ddlUsers.DataSource = dataSet;
                ddlUsers.DataTextField = "name";
                ddlUsers.DataValueField = "UserID";
                ddlUsers.DataBind();
                ddlUsers.Items.Insert(0, new ListItem("Select User", "-1"));
            }
            else
            {
                ddlUsers.Items.Clear();
                ddlUsers.Items.Insert(0, new ListItem("Select User", "-1"));
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

    public void Clearfields()
    {
        txtDesignation.Text = "";
        txtEmail.Text = "";
        txtLastExp.Text = "";
        txtMobile.Text = "";
        txtName.Text = "";
        txtPhoneNumber.Text = "";
    }

    public void bindData()
    {
        try
        {
            SqlCommand selectCommand = new SqlCommand("dbo.XRec_Select_DataForStaffSignup", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables.Count >= 1 && dataSet.Tables[0].Rows.Count > 0)
            {
                ddlQualification.DataSource = dataSet.Tables[0];
                ddlQualification.DataValueField = "Program_Code";
                ddlQualification.DataTextField = "Program_Name";
                ddlQualification.DataBind();
            }
            ddlQualification.Items.Insert(0, new ListItem("Select Qualification", "-1"));
            if (dataSet.Tables.Count >= 2 && dataSet.Tables[1].Rows.Count >= 0)
            {
                ddlDepartment.DataSource = dataSet.Tables[1];
                ddlDepartment.DataValueField = "Domain_Code";
                ddlDepartment.DataTextField = "Domain_Name";
                ddlDepartment.DataBind();
            }
            if (dataSet.Tables.Count >= 3 && dataSet.Tables[2].Rows.Count >= 0)
            {
                ddlDep.DataSource = dataSet.Tables[2];
                ddlDep.DataValueField = "Domain_Code";
                ddlDep.DataTextField = "Domain_Name";
                ddlDep.DataBind();
            }
            ddlDepartment.Items.Insert(0, new ListItem("Select Department", "-1"));
            ddlDep.Items.Insert(0, new ListItem("Select Department", "-1"));
            ddlCategory.Items.Insert(0, new ListItem("Select Category", "-1"));
            ddlUsers.Items.Insert(0, new ListItem("Select User", "-1"));
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
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

    #endregion

}