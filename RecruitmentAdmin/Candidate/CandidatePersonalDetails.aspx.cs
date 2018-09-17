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

public partial class CandidatePersonalDetails : CustomBasePage
{

    #region Page Variables
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    public static string CID;
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;
    #endregion Page Variables

    #region Methods
    public void BindDLL()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectDataforPersonalInfo", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
                if (dataSet == null || dataSet.Tables == null)
                    return;
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    ddlGender.Items.Clear();
                    ddlGender.DataSource = dataSet.Tables[0];
                    ddlGender.DataTextField = "Gender";
                    ddlGender.DataValueField = "Genger_Code";
                    ddlGender.DataBind();
                    ddlGender.Items.Insert(0, new ListItem("--Select Gender--", ""));
                }
                if (dataSet.Tables[2].Rows.Count > 0)
                {
                    ddlMaritalStatus.Items.Clear();
                    ddlMaritalStatus.DataSource = dataSet.Tables[2];
                    ddlMaritalStatus.DataTextField = "MaritalStatus";
                    ddlMaritalStatus.DataValueField = "MaritalStatus_Code";
                    ddlMaritalStatus.DataBind();
                    ddlMaritalStatus.Items.Insert(0, new ListItem("--Select Marital Status--", ""));
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
                    ddlCountry.Items.Insert(0, new ListItem("--Select Country--", ""));
                }
                if (dataSet.Tables[4].Rows.Count > 0)
                {
                    ddlReligon.Items.Clear();
                    ddlReligon.DataSource = dataSet.Tables[4];
                    ddlReligon.DataTextField = "Religion";
                    ddlReligon.DataValueField = "Religion_Code";
                    ddlReligon.DataBind();
                    ddlReligon.Items.Insert(0, new ListItem("--Select Religion--", ""));
                }
                if (dataSet.Tables[5].Rows.Count <= 0)
                    return;
                ddlCity.Items.Clear();
                ddlCity.DataSource = dataSet.Tables[5];
                ddlCity.DataTextField = "City";
                ddlCity.DataValueField = "City_Code";
                ddlCity.DataBind();
                ddlCity.Items.Insert(0, new ListItem("--Select City--", ""));
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidatePersonalDetails.CID);
            }
        }
    }

    private void BindData()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidatePersonalInfo", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.Add("@CandidateCode", CandidatePersonalDetails.CID);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
                if (dataSet == null || dataSet.Tables == null)
                    return;
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    txtEmail.Text = dataSet.Tables[0].Rows[0]["Email"].ToString();
                    txtPhone.Text = dataSet.Tables[0].Rows[0]["Phone"].ToString();
                    if (dataSet.Tables[0].Rows[0]["DateOfBirth"].ToString() != "")
                    {
                        ddlMonth.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DateOfBirth"].ToString()).Month.ToString();
                        ddlDay.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DateOfBirth"].ToString()).Day.ToString();
                        ddlYear.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DateOfBirth"].ToString()).Year.ToString();
                    }
                    ddlGender.SelectedValue = dataSet.Tables[0].Rows[0]["Gender"].ToString();
                    ddlMaritalStatus.SelectedValue = dataSet.Tables[0].Rows[0]["MaritalStatus"].ToString();
                    ddlReligon.SelectedValue = dataSet.Tables[0].Rows[0]["Religion"].ToString();
                    rblNationality.SelectedValue = dataSet.Tables[0].Rows[0]["Nationality"].ToString();
                    if (dataSet.Tables[0].Rows[0]["Nationality"].ToString() == "1")
                    {
                        trNIC.Style.Add("display", "");
                        trPassport.Style.Add("display", "none");
                        rfvNIC.Enabled = true;
                        revNIC.Enabled = true;
                        rfvPassport.Enabled = false;
                    }
                    else if (dataSet.Tables[0].Rows[0]["Nationality"].ToString() == "2")
                    {
                        trNIC.Style.Add("display", "none");
                        trPassport.Style.Add("display", "");
                        rfvNIC.Enabled = false;
                        revNIC.Enabled = false;
                        rfvPassport.Enabled = true;
                    }
                    else
                    {
                        trNIC.Style.Add("display", "");
                        trPassport.Style.Add("display", "none");
                        rfvNIC.Enabled = true;
                        revNIC.Enabled = true;
                        rfvPassport.Enabled = false;
                    }
                    txtNIC.Text = dataSet.Tables[0].Rows[0]["NIC"].ToString();
                    txtPassport.Text = dataSet.Tables[0].Rows[0]["Passport"].ToString();
                    txtName.Text = dataSet.Tables[0].Rows[0]["FullName"].ToString();
                }
                if (dataSet.Tables[1].Rows.Count > 0)
                {
                    ddlCountry.SelectedValue = dataSet.Tables[1].Rows[0]["Country"].ToString();
                    txtMobile.Text = dataSet.Tables[1].Rows[0]["Mobile"].ToString();
                }
                if (dataSet.Tables[2].Rows.Count <= 0)
                    return;
                txtHouseNo.Text = dataSet.Tables[2].Rows[0]["HouseNumber"].ToString();
                txtArea.Text = dataSet.Tables[2].Rows[0]["Area"].ToString();
                txtBlock.Text = dataSet.Tables[2].Rows[0]["Block"].ToString();
                ddlCity.SelectedValue = dataSet.Tables[2].Rows[0]["Location_Code"].ToString();
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidatePersonalDetails.CID);
            }
        }
    }

    public void UpdateCandidatePersonalInfo()
    {
        string str1 = string.Empty;
        string str2 = string.Empty;
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidatePersonalDetailsWithHistory", connection))
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
                    sqlCommand.Parameters.Add(new SqlParameter("@EmailAddress", txtEmail.Text));
                    sqlCommand.Parameters.Add(new SqlParameter("@MobileNumber", txtMobile.Text));
                    sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", CandidatePersonalDetails.CID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOfBirth", dateTime.ToString()));
                    sqlCommand.Parameters.Add(new SqlParameter("@Gender", ddlGender.SelectedValue));
                    sqlCommand.Parameters.Add(new SqlParameter("@MaritalStatus", ddlMaritalStatus.SelectedValue));
                    sqlCommand.Parameters.Add(new SqlParameter("@Religion", ddlReligon.SelectedValue));
                    sqlCommand.Parameters.Add(new SqlParameter("@HouseNumber", txtHouseNo.Text));
                    sqlCommand.Parameters.Add(new SqlParameter("@Block", txtBlock.Text));
                    sqlCommand.Parameters.Add(new SqlParameter("@Area", txtArea.Text));
                    sqlCommand.Parameters.Add(new SqlParameter("@CityCode", Convert.ToInt32(ddlCity.SelectedValue.ToString())));
                    sqlCommand.Parameters.Add(new SqlParameter("@Nationality", rblNationality.SelectedValue));
                    sqlCommand.Parameters.Add(new SqlParameter("@NIC", str1));
                    sqlCommand.Parameters.Add(new SqlParameter("@Country", ddlCountry.SelectedValue));
                    sqlCommand.Parameters.Add(new SqlParameter("@PhoneNumber", txtPhone.Text));
                    sqlCommand.Parameters.Add(new SqlParameter("@passport", str2));
                    sqlCommand.Parameters.Add(new SqlParameter("@updatedBY", UserCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@UpdatedIP", Request.UserHostAddress));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionCode", 2));
                    sqlCommand.Parameters.Add(new SqlParameter("@UserType", 1));
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidatePersonalDetails.CID);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
        if (QueryStringVar == null)
            return;
        secQueryString = new SecureQueryString(QueryStringVar);
        if (secQueryString["CID"] == null)
            return;
        CandidatePersonalDetails.CID = secQueryString["CID"].ToString();
        try
        {
            if (IsPostBack)
                return;
            BindDLL();
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidatePersonalDetails.CID);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!IsValid)
            return;
        try
        {
            UpdateCandidatePersonalInfo();
            Page.RegisterStartupScript("Close", "<script language=JavaScript> CloseHighSlideWithParentRefresh();</script>");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidatePersonalDetails.CID);
        }
    }
    #endregion
}