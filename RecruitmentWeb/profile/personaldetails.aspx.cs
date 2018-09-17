using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;
using ErrorLog;
using XRecruitmentStatusLibrary;

public partial class profile_personaldetails : CustomBaseClass
{
    #region Page Variables
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    string FinishBtnText = ConfigurationManager.AppSettings["FinishButton"].ToString();
    SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    #endregion Page Variables

    #region Methods

    public void BindDLL()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectDataforPersonalInfo", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet == null || dataSet.Tables == null)
                return;
            int count = dataSet.Tables[0].Rows.Count;
            if (dataSet.Tables[2].Rows.Count > 0)
            {
                ddlMaritalStatus.Items.Clear();
                ddlMaritalStatus.DataSource = dataSet.Tables[2];
                ddlMaritalStatus.DataTextField = "MaritalStatus";
                ddlMaritalStatus.DataValueField = "MaritalStatus_Code";
                ddlMaritalStatus.DataBind();
                ddlMaritalStatus.Items.Insert(0, new ListItem("Select Marital Status", ""));
            }
            if (dataSet.Tables[1].Rows.Count > 0)
            {
                rblNationality.Items.Clear();
                rblNationality.DataSource = dataSet.Tables[1];
                rblNationality.DataTextField = "Nationality";
                rblNationality.DataValueField = "Nationality_Code";
                rblNationality.DataBind();
                rblNationality.SelectedIndex = 0;
            }
            if (dataSet.Tables[3].Rows.Count > 0)
            {
                ddlCountry.Items.Clear();
                ddlCountry.DataSource = dataSet.Tables[3];
                ddlCountry.DataTextField = "Country_Name";
                ddlCountry.DataValueField = "Country_Code";
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, new ListItem("Select Country", ""));
            }
            if (dataSet.Tables[4].Rows.Count > 0)
            {
                ddlReligon.Items.Clear();
                ddlReligon.DataSource = dataSet.Tables[4];
                ddlReligon.DataTextField = "Religion";
                ddlReligon.DataValueField = "Religion_Code";
                ddlReligon.DataBind();
                ddlReligon.Items.Insert(0, new ListItem("Select Religion", ""));
            }
            if (dataSet.Tables[5].Rows.Count > 0)
            {
                ddlCity.Items.Clear();
                ddlCity.DataSource = dataSet.Tables[5];
                ddlCity.DataTextField = "City";
                ddlCity.DataValueField = "City_Code";
                ddlCity.DataBind();
                ddlCity.Items.Insert(0, new ListItem("Select City", ""));
            }
            if (dataSet.Tables[6].Rows.Count <= 0)
                return;
            chklShift.Items.Clear();
            chklShift.DataSource = dataSet.Tables[6];
            chklShift.DataTextField = "AvailabilityShift";
            chklShift.DataValueField = "AvailabilityShift_Code";
            chklShift.DataBind();
        }
    }

    private void BindData()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidatePersonalInfo", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add("@CandidateCode", CandidateCode);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet == null || dataSet.Tables == null)
                return;
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                lblEmail.Text = dataSet.Tables[0].Rows[0]["Email"].ToString();
                lblPrimaryNumber.Text = dataSet.Tables[0].Rows[0]["Phone"].ToString();
                txtLandLineNumber.Text = dataSet.Tables[0].Rows[0]["Home_Number"].ToString();
                txtLandlineCode.Text = dataSet.Tables[0].Rows[0]["Home_Number_Code"].ToString();
                if (dataSet.Tables[0].Rows[0]["DateOfBirth"].ToString() != "")
                {
                    ddlMonth.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DateOfBirth"].ToString()).Month.ToString();
                    ddlDay.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DateOfBirth"].ToString()).Day.ToString();
                    ddlYear.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DateOfBirth"].ToString()).Year.ToString();
                }
                rbtnlGender.SelectedValue = dataSet.Tables[0].Rows[0]["Gender"].ToString();
                txtHeightFeet.Text = dataSet.Tables[0].Rows[0]["HeightInFeet"].ToString();
                txtHeightInches.Text = dataSet.Tables[0].Rows[0]["HeightInInches"].ToString();
                txtWeight.Text = dataSet.Tables[0].Rows[0]["Weight"].ToString();
                txtExpectedSalary.Text = dataSet.Tables[0].Rows[0]["ExpectedSalary"].ToString();
                ddlMaritalStatus.SelectedValue = dataSet.Tables[0].Rows[0]["MaritalStatus"].ToString();
                ddlReligon.SelectedValue = dataSet.Tables[0].Rows[0]["Religion"].ToString();
                rblNationality.SelectedValue = dataSet.Tables[0].Rows[0]["Nationality"].ToString();
                if (dataSet.Tables[0].Rows[0]["Nationality"].ToString() == "1")
                {
                    trNIC.Style.Add("display", "");
                    trPassport.Style.Add("display", "none");
                }
                else if (dataSet.Tables[0].Rows[0]["Nationality"].ToString() == "2")
                {
                    trNIC.Style.Add("display", "none");
                    trPassport.Style.Add("display", "");
                }
                else
                {
                    trNIC.Style.Add("display", "");
                    trPassport.Style.Add("display", "none");
                }
                txtNIC.Text = dataSet.Tables[0].Rows[0]["NIC"].ToString();
                txtPassport.Text = dataSet.Tables[0].Rows[0]["Passport"].ToString();
                txtName.Text = dataSet.Tables[0].Rows[0]["FullName"].ToString();
            }
            if (dataSet.Tables[1].Rows.Count > 0)
                ddlCountry.SelectedValue = dataSet.Tables[1].Rows[0]["Country"].ToString();
            if (dataSet.Tables[2].Rows.Count > 0)
            {
                txtHouse.Text = dataSet.Tables[2].Rows[0]["HouseNumber"].ToString();
                txtArea.Text = dataSet.Tables[2].Rows[0]["Area"].ToString();
                txtBlock.Text = dataSet.Tables[2].Rows[0]["Block"].ToString();
                ddlCity.SelectedValue = dataSet.Tables[2].Rows[0]["Location_Code"].ToString();
                txtCity.Text = dataSet.Tables[2].Rows[0]["OTHER_CITY"].ToString();
            }
            if (dataSet.Tables[1].Rows[0]["Country"].ToString() == "172")
            {
                ddlCity.Style["display"] = "";
                txtCity.Style["display"] = "none";
            }
            else
            {
                ddlCity.Style["display"] = "none";
                txtCity.Style["display"] = "";
            }
            if (dataSet.Tables[3].Rows.Count > 0)
            {
                for (int index = 0; index < dataSet.Tables[3].Rows.Count; ++index)
                {
                    if (index == 0)
                    {
                        ddlCode1.SelectedValue = dataSet.Tables[3].Rows[index]["Country_Code"].ToString();
                        txtMobileNumber1.Text = dataSet.Tables[3].Rows[index]["MobilePhone_Number"].ToString();
                    }
                    else if (index == 1)
                    {
                        hfContact2.Value = "1";
                        Contact2.Style["display"] = "block";
                        ddlCode2.SelectedValue = dataSet.Tables[3].Rows[index]["Country_Code"].ToString();
                        txtMobileNumber2.Text = dataSet.Tables[3].Rows[index]["MobilePhone_Number"].ToString();
                    }
                    else
                    {
                        hfContact3.Value = "1";
                        Contact3.Style["display"] = "block";
                        ddlCode3.SelectedValue = dataSet.Tables[3].Rows[index]["Country_Code"].ToString();
                        txtMobileNumber3.Text = dataSet.Tables[3].Rows[index]["MobilePhone_Number"].ToString();
                        PlusImg.Style["display"] = "none";
                    }
                }
            }
            if (dataSet.Tables[4].Rows.Count <= 0)
                return;
            foreach (DataRow row in (InternalDataCollectionBase)dataSet.Tables[4].Rows)
            {
                foreach (ListItem listItem in chklShift.Items)
                {
                    if (listItem.Value == row["AvailabilityShift_Code"].ToString())
                        listItem.Selected = true;
                }
            }
        }
    }

    private void SaveCandidateShift()
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_DeactivateAllCandidateShift", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", CandidateCode));
                sqlCommand.Parameters.Add(new SqlParameter("@UpdatedIp", Request.UserHostAddress.ToString()));
                sqlCommand.ExecuteNonQuery();
            }
            foreach (ListItem listItem in chklShift.Items)
            {
                if (listItem.Selected)
                {
                    using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateShift", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add(new SqlParameter("@ShiftCode", listItem.Value));
                        sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", CandidateCode.ToString()));
                        sqlCommand.Parameters.Add(new SqlParameter("@updatedBY", (AdminUserCode == -1 ? CandidateCode : AdminUserCode)));
                        sqlCommand.Parameters.Add(new SqlParameter("@UpdatedIP", Request.UserHostAddress));
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
        }
    }

    public void SaveCandidateContacts()
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateContactInformation", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", CANDIDATE.ToString()));
                sqlCommand.Parameters.Add(new SqlParameter("@UpdatedIp", Request.UserHostAddress.ToString()));
                sqlCommand.Parameters.Add(new SqlParameter("@updatedBY", (AdminUserCode == -1 ? CandidateCode : AdminUserCode)));
                if (txtMobileNumber1.Text != "")
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@MobilePhoneNumber1", txtMobileNumber1.Text));
                    sqlCommand.Parameters.Add(new SqlParameter("@MobilePhoneCode1", ddlCode1.SelectedValue.ToString()));
                }
                if (hfContact2.Value == "1" && txtMobileNumber2.Text != "")
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@MobilePhoneNumber2", txtMobileNumber2.Text));
                    sqlCommand.Parameters.Add(new SqlParameter("@MobilePhoneCode2", ddlCode2.SelectedValue.ToString()));
                }
                if (hfContact3.Value == "1" && txtMobileNumber3.Text != "")
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@MobilePhoneNumber3", txtMobileNumber3.Text));
                    sqlCommand.Parameters.Add(new SqlParameter("@MobilePhoneCode3", ddlCode3.SelectedValue.ToString()));
                }
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    public void UpdateCandidatePersonalInfo()
    {
        string str1 = string.Empty;
        string str2 = string.Empty;
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidatePersonalDetails", connection))
            {
                if (rblNationality.SelectedValue.ToString() == "1")
                {
                    str1 = txtNIC.Text;
                    str2 = "";
                }
                else if (rblNationality.SelectedValue.ToString() == "2")
                {
                    str2 = txtPassport.Text;
                    str1 = "";
                }
                DateTime dateTime = new DateTime(Convert.ToInt32(ddlYear.SelectedValue.ToString()), Convert.ToInt32(ddlMonth.SelectedValue.ToString()), Convert.ToInt32(ddlDay.SelectedValue.ToString()));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@FullName", txtName.Text));
                sqlCommand.Parameters.Add(new SqlParameter("@EmailAddress", lblEmail.Text));
                sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", CandidateCode.ToString()));
                sqlCommand.Parameters.Add(new SqlParameter("@DateOfBirth", dateTime.ToString()));
                sqlCommand.Parameters.Add(new SqlParameter("@Gender", rbtnlGender.SelectedValue));
                sqlCommand.Parameters.Add(new SqlParameter("@MaritalStatus", ddlMaritalStatus.SelectedValue));
                sqlCommand.Parameters.Add(new SqlParameter("@Religion", ddlReligon.SelectedValue));
                sqlCommand.Parameters.Add(new SqlParameter("@HouseNumber", txtHouse.Text));
                sqlCommand.Parameters.Add(new SqlParameter("@Block", txtBlock.Text));
                sqlCommand.Parameters.Add(new SqlParameter("@Area", txtArea.Text));
                sqlCommand.Parameters.Add(new SqlParameter("@CityCode", (ddlCountry.SelectedValue == "172" ? Convert.ToInt32(ddlCity.SelectedValue.ToString()) : 0)));
                sqlCommand.Parameters.Add(new SqlParameter("@OtherCity", txtCity.Text));
                sqlCommand.Parameters.Add(new SqlParameter("@Nationality", rblNationality.SelectedValue));
                sqlCommand.Parameters.Add(new SqlParameter("@NIC", str1));
                sqlCommand.Parameters.Add(new SqlParameter("@Country", ddlCountry.SelectedValue));
                sqlCommand.Parameters.Add(new SqlParameter("@PhoneNumber", txtLandLineNumber.Text));
                sqlCommand.Parameters.Add(new SqlParameter("@PhoneNumberCode", txtLandlineCode.Text));
                sqlCommand.Parameters.Add(new SqlParameter("@passport", str2));
                sqlCommand.Parameters.Add(new SqlParameter("@updatedBY", (AdminUserCode == -1 ? CandidateCode : AdminUserCode)));
                sqlCommand.Parameters.Add(new SqlParameter("@UpdatedIP", Request.UserHostAddress));
                sqlCommand.Parameters.Add(new SqlParameter("@UserType", UserTypeCode));
                sqlCommand.Parameters.Add(new SqlParameter("@HeightInFeet", txtHeightFeet.Text == string.Empty ? "0" : txtHeightFeet.Text));
                sqlCommand.Parameters.Add(new SqlParameter("@HeightInInches", txtHeightInches.Text == string.Empty ? "0" : txtHeightInches.Text));
                sqlCommand.Parameters.Add(new SqlParameter("@Weight", txtWeight.Text == string.Empty ? "0" : txtWeight.Text));
                sqlCommand.Parameters.Add(new SqlParameter("@ExpectedSalary", txtExpectedSalary.Text == string.Empty ? "0" : txtExpectedSalary.Text));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    public void BindPhoneCodes()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectService", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                {
                    sqlDataAdapter.Fill(dataSet);
                    ddlCode1.DataSource = dataSet.Tables[0];
                    ddlCode1.DataTextField = "ServiceName";
                    ddlCode1.DataValueField = "ServiceName";
                    ddlCode1.DataBind();
                    ddlCode2.DataSource = dataSet.Tables[0];
                    ddlCode2.DataTextField = "ServiceName";
                    ddlCode2.DataValueField = "ServiceName";
                    ddlCode2.DataBind();
                    ddlCode3.DataSource = dataSet.Tables[0];
                    ddlCode3.DataTextField = "ServiceName";
                    ddlCode3.DataValueField = "ServiceName";
                    ddlCode3.DataBind();
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            if (Convert.ToInt32(Constants.ProfileNavigation.PersonalDetails) == Convert.ToInt32(GeneralMethods.GetProfileNavCount(SqlConn, CandidateCode).Rows[0]["FinishCode"].ToString()))
                btnSave.Text = FinishBtnText;
            BindPhoneCodes();
            BindDLL();
            BindYear();
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CANDIDATE.ToString());
        }
    }

    private void BindYear()
    {
        try
        {
            for (int index = DateTime.Now.Year - 16; index > DateTime.Now.Year - 16 - 98; --index)
                ddlYear.Items.Add(new ListItem(index.ToString(), index.ToString()));
            ddlYear.Items.Insert(0, new ListItem("Year", ""));
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!IsValid)
                return;
            UpdateCandidatePersonalInfo();
            SaveCandidateContacts();
            SaveCandidateShift();
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            sqlConn.Open();
            StatusManagement.MarkProfileStatus(sqlConn, CandidateCode, Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.FilledPersonalDetailsReferralPending, Request.UserHostAddress, AdminUserCode == -1 ? CandidateCode : AdminUserCode, Constants.ProfileNavigation.PersonalDetails);
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

    #endregion
}