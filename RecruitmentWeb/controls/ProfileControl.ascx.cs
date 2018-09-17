using ErrorLog;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using XRecruitmentStatusLibrary;

public delegate void GotoAspxPage();
public partial class controls_ProfileControl : System.Web.UI.UserControl
{

    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    private string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    private DataSet ds = new DataSet();
    private StringCollection parameters = new StringCollection();
    protected Image imgProfileImageSmall;
    protected HtmlAnchor ATnGUpper;
    protected LinkButton logout;
    protected Label lblProfileFullName;
    protected Label lblCoverFullName;
    protected Button btnSaveCoverPositions;
    protected HtmlImage imgProfileImage;
    protected HtmlGenericControl removeProfilePict;
    protected HtmlGenericControl removeCoverPict;
    protected HtmlImage draggable;
    protected Label lblalertcount;
    protected HtmlGenericControl spanAlert;
    protected HtmlAnchor ATnG;
    protected Image imgNavImageSmall;
    protected Label lblNavFullName;
    protected HiddenField profileImagePath;
    protected HiddenField coverImageTopPosition;
    protected HiddenField coverImageleftPosition;
    protected Label lblName;
    protected Label lblDOB;
    protected Label lblGender;
    protected Label lblLocation;
    protected Label lblPhoneNumber;
    protected Label lblEmail;
    protected TextBox txtFirstName;
    protected TextBox txtLastName;
    protected DropDownList ddlMonth;
    protected DropDownList ddlDay;
    protected DropDownList ddlYear;
    protected RadioButtonList rblGender;
    protected LinkButton lbtnProfileInformation;
    protected DropDownList ddlPCountry;
    protected TextBox txtPPhoneCode;
    protected TextBox txtPPhoneNumber;
    protected TextBox txtEmailAddress;
    protected TextBox txtAlternateEmail;
    protected Label lblCompanyname;
    protected Label lblCompanyWebsite;
    protected Label lblIndustry;
    protected Label lblEstimatedEmployees;
    protected Label lblRepresentativeName;
    protected Label lblCLocation;
    protected Label lblCphoneNumber;
    protected Label lblCEmail;
    protected TextBox txtCompanyName;
    protected TextBox txtCompanyWebsite;
    protected TextBox txtIndustry;
    protected DropDownList ddlEstimatedEmployees;
    protected TextBox txtRepresentativeName;
    protected DropDownList ddlCLocation;
    protected TextBox txtCLPhoneCode;
    protected TextBox txtCLPhoneNumber;
    protected TextBox txtCEmailAddress;
    protected TextBox txtCAlternateEmail;
    protected Button lnkRemoveCoverPhoto;
    protected Button lnkRemoveProfilePhoto;
    protected HiddenField hdnValue;
    protected TextBox txtPMsg;
    protected Label lblPMsgGetAssistance;
    protected HiddenField hfPCandidateCode2;
    public int CanCode;
    private SecureQueryString oSecureString;


    public event GotoAspxPage gotoAspxPage;

    protected void Page_Load(object sender, EventArgs e)
    {
        CanCode = int.Parse(Session["CC"].ToString());
        hfPCandidateCode2.Value = Session["CC"].ToString();
        profileImagePath.Value = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + CanCode;
        ds = GetCandidateProfileData(CanCode);
        SetProfileImages();
        LoadData();
        BindCandidateAlerts(0);
        int num = IsPostBack ? 1 : 0;
    }

    public void LoadData()
    {
        try
        {
            if (CanCode == 0)
                return;
            lblProfileFullName.Text = CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(ds.Tables[0].Rows[0]["Name"].ToString());
            lblCoverFullName.Text = CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(ds.Tables[0].Rows[0]["Name"].ToString());
            lblNavFullName.Text = CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(ds.Tables[0].Rows[0]["Name"].ToString());
            if (ds.Tables[0].Rows[0]["ProfileImage_Path"].ToString() != "" && ds.Tables[0].Rows[0]["ProfileImage_Path"].ToString() != "0")
            {
                imgProfileImageSmall.ImageUrl = ds.Tables[0].Rows[0]["ProfileImage_Path"].ToString();
                imgNavImageSmall.ImageUrl = ds.Tables[0].Rows[0]["ProfileImage_Path"].ToString();
            }
            if (!(ds.Tables[0].Rows[0]["coverImageTopPosition"].ToString() != string.Empty) || !(ds.Tables[0].Rows[0]["coverImageTopPosition"].ToString() != "0"))
                return;
            draggable.Attributes.Remove("Style");
            draggable.Attributes.Add("Style", "width:100% !important; min-height:472px !important; top: " + ds.Tables[0].Rows[0]["coverImageTopPosition"].ToString() + "px;");
        }
        catch (Exception ex)
        {
        }
    }

    public void SetProfileImages()
    {
        try
        {
            if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count <= 0)
                return;
            if (ds.Tables[0].Rows[0]["ProfileImage_Path"].ToString() != "" && ds.Tables[0].Rows[0]["ProfileImage_Path"].ToString() != "0")
            {
                imgProfileImage.Src = ds.Tables[0].Rows[0]["ProfileImage_Path"].ToString();
                removeProfilePict.Attributes.Add("style", "visibility:visible; height:auto;");
            }
            else
            {
                imgProfileImage.Src = "../area/SocialMedia/UserImagePath/profile.jpg";
                imgProfileImageSmall.ImageUrl = "../area/SocialMedia/UserImagePath/profile.jpg";
                imgNavImageSmall.ImageUrl = "../area/SocialMedia/UserImagePath/profile.jpg";
                removeProfilePict.Attributes.Add("style", "visibility:hidden; height:0px;");
            }
            if (ds.Tables[0].Rows[0]["CoverImage_Path"].ToString() != "" && ds.Tables[0].Rows[0]["CoverImage_Path"].ToString() != "0")
            {
                draggable.Src = ds.Tables[0].Rows[0]["CoverImage_Path"].ToString();
                removeCoverPict.Attributes.Add("style", "visibility:visible; height:auto;");
            }
            else
            {
                draggable.Src = "../area/SocialMedia/UserImagePath/cover.jpg";
                removeCoverPict.Attributes.Add("style", "visibility:hidden; height:0px;");
            }
        }
        catch (Exception ex)
        {
        }
    }

    private void BindCandidateAlerts(int Read)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateAlerts", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", CanCode);
                    selectCommand.Parameters.AddWithValue("@Read", Read);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
                if (dataSet == null || dataSet.Tables == null || dataSet.Tables[1].Rows.Count <= 0)
                    return;
                if ((int)dataSet.Tables[1].Rows[0]["AlertCount"] > 0)
                {
                    lblalertcount.Text = dataSet.Tables[1].Rows[0]["AlertCount"].ToString();
                    spanAlert.Visible = true;
                }
                else
                    spanAlert.Visible = false;
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "BindCandidateAlerts", ex, CanCode.ToString());
            }
        }
    }

    private DataSet GetCandidateProfileData(int candidatecode)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateProfileData", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add(new SqlParameter("@CandidateCode", candidatecode));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        int int32 = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Status_Code"]);
        if (int32 < Convert.ToInt32(Constants.CandidateLifeCycleStatus.ShortlistedSchedulingPendingTest))
        {
            ATnG.HRef = "../area/tipsguides.aspx?var=gtg-general";
            ATnGUpper.HRef = "../area/tipsguides.aspx?var=gtg-general";
        }
        else if (int32 < Convert.ToInt32(Constants.CandidateLifeCycleStatus.SchedulingDoneInterviewPending))
        {
            ATnG.HRef = "../area/tipsguides.aspx?var=gtg-test";
            ATnGUpper.HRef = "../area/tipsguides.aspx?var=gtg-test";
        }
        else if (int32 < Convert.ToInt32(Constants.CandidateLifeCycleStatus.OfferGeneratedSchedulingPending))
        {
            ATnG.HRef = "../area/tipsguides.aspx?var=gtg-interview";
            ATnGUpper.HRef = "../area/tipsguides.aspx?var=gtg-interview";
        }
        else if (int32 < Convert.ToInt32(Constants.CandidateLifeCycleStatus.VerificationSchedulingDoneVerficationPending))
        {
            ATnG.HRef = "../area/tipsguides.aspx?var=gtg-offer";
            ATnGUpper.HRef = "../area/tipsguides.aspx?var=gtg-offer";
        }
        else if (int32 <= Convert.ToInt32(Constants.CandidateLifeCycleStatus.AppointmentSchedulingDoneJoiningReportingPending))
        {
            ATnG.HRef = "../area/tipsguides.aspx?var=gtg-docsub";
            ATnGUpper.HRef = "../area/tipsguides.aspx?var=gtg-docsub";
        }
        else if (int32 <= Convert.ToInt32(Constants.CandidateLifeCycleStatus.HiredBenefitsAcknowledged))
        {
            ATnG.HRef = "../area/tipsguides.aspx?var=gtg-joining";
            ATnGUpper.HRef = "../area/tipsguides.aspx?var=gtg-joining";
        }
        else
        {
            ATnG.HRef = "../area/tipsguides.aspx?var=gtg-general";
            ATnGUpper.HRef = "../area/tipsguides.aspx?var=gtg-general";
        }
        return dataSet;
    }

    protected void logout_Click(object sender, EventArgs e)
    {
        try
        {
            Session.RemoveAll();
            Session.Abandon();
            Session.Clear();
            Response.Redirect(DomainAddress + "SignIn.aspx", false);
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnSaveCoverPositions_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateCoverPicturePosition(coverImageTopPosition.Value, CanCode.ToString());
            if (!(coverImageTopPosition.Value != string.Empty))
                return;
            draggable.Attributes.Remove("Style");
            draggable.Attributes.Add("Style", "width:100% !important; min-height:472px !important; top: " + coverImageTopPosition.Value + "px;");
        }
        catch (Exception ex)
        {
        }
    }

    private void UpdateCoverPicturePosition(string coverimageposition, string candidatecode)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateCoverImagePosition", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", candidatecode));
                    sqlCommand.Parameters.Add(new SqlParameter("@coverImageTopPosition", coverimageposition));
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "XRec_CreateCandidateLogin", ex, "0");
            }
        }
    }

    protected void lbtnProfileInformation_Click(object sender, EventArgs e)
    {
    }

    protected void btnRemoveCoverPhoto_Click(object sender, EventArgs e)
    {
        try
        {
            if (CanCode == 0)
                return;
            connection.Open();
            parameters.Add(CanCode.ToString());
            removeCoverPicture(connection, parameters);
            ds = GetCandidateProfileData(CanCode);
            SetProfileImages();
            LoadData();
            BindCandidateAlerts(0);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, "btnRemoveCoverPhoto_Click", ex, CanCode.ToString());
        }
        finally
        {
            connection.Close();
        }
    }

    protected void btnRemoveProfilePhoto_Click(object sender, EventArgs e)
    {
        try
        {
            if (CanCode == 0)
                return;
            connection.Open();
            parameters.Add(CanCode.ToString());
            removeProfilePicture(connection, parameters);
            ds = GetCandidateProfileData(CanCode);
            SetProfileImages();
            LoadData();
            BindCandidateAlerts(0);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, "btnRemoveProfilePhoto_Click", ex, CanCode.ToString());
        }
        finally
        {
            connection.Close();
        }
    }

    public int removeCoverPicture(SqlConnection sqlCon, StringCollection parameters)
    {
        SqlCommand selectCommand = new SqlCommand();
        selectCommand.Connection = sqlCon;
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.CommandText = "XRec_UpdateCandidateCoverImage";
        selectCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = parameters[0];
        selectCommand.Parameters.Add("@CoverImagePath", SqlDbType.VarChar).Value = DBNull.Value;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        return Convert.ToInt32(selectCommand.ExecuteScalar());
    }

    public int removeProfilePicture(SqlConnection sqlCon, StringCollection parameters)
    {
        SqlCommand selectCommand = new SqlCommand();
        selectCommand.Connection = sqlCon;
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.CommandText = "XRec_UpdateCandidateProfileImage";
        selectCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = parameters[0];
        selectCommand.Parameters.Add("@ProfileImagePath", SqlDbType.VarChar).Value = DBNull.Value;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        return Convert.ToInt32(selectCommand.ExecuteScalar());
    }

    [WebMethod]
    public static void NeedHelpSave(string items)
    {
    }

    private enum OG
    {
        CounterCode = 1,
        Is_Active = 1,
        SignUpThroughCode = 1,
        LifeCycleStatusCode = 100,
    }


}