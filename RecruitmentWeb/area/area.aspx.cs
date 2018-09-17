using ErrorLog;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class area_area : CustomBaseClass, IRequiresSessionState
{
    #region Page Variables
    private string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    private string student_code = string.Empty;
    public string statusBarImagePath = string.Empty;
    public string statusWiseTemplate = string.Empty;
    public string statusWiseButtonDiv = string.Empty;
    public int javascriptvariable;
    private string parentcheck;
    private bool PhoneVerified;
    private bool EmailVerified;


    #endregion Page Variables






    public string ParentCheck
    {
        get
        {
            return parentcheck;
        }
        set
        {
            parentcheck = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            hfCandidateCode.Value = Session["CC"].ToString() ?? "0";
            hfCandidateCode1.Value = Session["CC"].ToString() ?? "0";
            hfCandidateCode2.Value = Session["CC"].ToString() ?? "0";
            DataTable dataTable = new DataTable();
            DataTable lifeCycleStatus = GetLifeCycleStatus(CandidateCode);
            if (!IsPostBack)
            {
                DataSet candidateProfileData = GetCandidateProfileData(CandidateCode);
                int progressBarPencentage = GetProgressBarPencentage(CandidateCode, 2000);
                if (progressBarPencentage >= 100)
                    dvProgressPercentage.Attributes.Add("style", "display:none");
                dvprogressbar.Attributes.Add("style", "width:" + progressBarPencentage + "%");
                lblProgressPercentage.Text = progressBarPencentage.ToString() + "%";
                if (candidateProfileData.Tables[0].Rows[0]["Candidate_ID"].ToString() != "" && candidateProfileData.Tables[0].Rows[0]["Candidate_ID"].ToString() != "-")
                {
                    lblID.Text = candidateProfileData.Tables[0].Rows[0]["Candidate_ID"].ToString();
                    lblStatus.Text = lifeCycleStatus.Rows[0]["StatusName"].ToString();
                    lblPhoneNumber.Text = candidateProfileData.Tables[0].Rows[0]["Phone_Number"].ToString();
                    lblEmail.Text = candidateProfileData.Tables[0].Rows[0]["Email_Address"].ToString();
                    lblEmail.ToolTip = candidateProfileData.Tables[0].Rows[0]["completeEmail"].ToString();
                    lblPhoneNumber.ToolTip = candidateProfileData.Tables[0].Rows[0]["Phone_Number"].ToString();
                    PhoneVerified = Convert.ToBoolean(candidateProfileData.Tables[0].Rows[0]["Is_PhoneVerified"].ToString());
                    EmailVerified = Convert.ToBoolean(candidateProfileData.Tables[0].Rows[0]["Is_EmailVerified"].ToString());
                }
                else
                {
                    lblID.Text = "-";
                    lblStatus.Text = lifeCycleStatus.Rows[0]["StatusName"].ToString();
                    lblPhoneNumber.Text = candidateProfileData.Tables[0].Rows[0]["Phone_Number"].ToString();
                    lblEmail.Text = candidateProfileData.Tables[0].Rows[0]["Email_Address"].ToString();
                    lblEmail.ToolTip = candidateProfileData.Tables[0].Rows[0]["completeEmail"].ToString();
                    lblPhoneNumber.ToolTip = candidateProfileData.Tables[0].Rows[0]["Phone_Number"].ToString();
                    PhoneVerified = Convert.ToBoolean(candidateProfileData.Tables[0].Rows[0]["Is_PhoneVerified"].ToString());
                    EmailVerified = Convert.ToBoolean(candidateProfileData.Tables[0].Rows[0]["Is_EmailVerified"].ToString());
                }
                if (EmailVerified)
                {
                    spnotverified2.Attributes.Add("style", "display:none");
                    spverified2.Attributes.Add("style", "display:''");
                }
                else
                {
                    spnotverified2.Attributes.Add("style", "display:''");
                    spverified2.Attributes.Add("style", "display:none");
                }
                if (PhoneVerified)
                {
                    spnotverified1.Attributes.Add("style", "display:none");
                    spverified1.Attributes.Add("style", "display:''");
                }
                else
                {
                    spnotverified1.Attributes.Add("style", "display:''");
                    spverified1.Attributes.Add("style", "display:none");
                }
                if (EmailVerified && PhoneVerified)
                    verification_skip.Attributes.Add("style", "display:none");
                statusWiseTemplate = lifeCycleStatus.Rows[0]["Status_Display_LongText"].ToString();
                BindData(CandidateCode);
            }
            else
                statusWiseTemplate = lifeCycleStatus.Rows[0]["Status_Display_LongText"].ToString();
            if (string.IsNullOrEmpty(Request["fb"]))
                return;
            ClientScript.RegisterStartupScript(GetType(), "CallMe", "document.getElementById('" + aUploadSucess.ClientID + "').click();", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, "Candidate Area", ex, CandidateCode.ToString());
        }
    }

    protected void lnkSendEmail_Click(object sender, EventArgs e)
    {
    }

    private DataSet CandidateAutomaticSignIn()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_CandidateAutomaticSignIn", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.Add(new SqlParameter("@Candidate_Code", Session["CC"]));
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "");
            }
        }
        return dataSet;
    }

    private int GetProgressBarPencentage(int CanCode, int moduleCode)
    {
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_GetPercentageBar", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.AddWithValue("@CandidateCode", CanCode);
        selectCommand.Parameters.AddWithValue("@ModuleCode", moduleCode);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        return int.Parse(dataSet.Tables[0].Rows[0][0].ToString());
    }

    private DataTable GetLifeCycleStatus(int CanCode)
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_GetLifeCycleStatus", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.Add(new SqlParameter("@CandidateCode", CanCode));
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "XRec_GetLifeCycleStatus", ex, "0");
            }
        }
        return dataTable;
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
        return dataSet;
    }

    protected void lnkVerifyEmail_Click(object sender, EventArgs e)
    {
    }

    public DataSet Verify(string Code)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_VerifyCandidatePhoneCode", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add(new SqlParameter("@CandidateCode", Session["CC"].ToString()));
                selectCommand.Parameters.Add(new SqlParameter("@PhoneVerificationCode", Code));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }

    private DataSet GetVerificationCode()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateVerificationCode", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add(new SqlParameter("@CandidateCode", Session["CC"].ToString()));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }

    public void SendSMS(string FullName, string VerificationCode, string PhoneNumber)
    {
        string empty1 = string.Empty;
        string str = "Dear " + FullName + " your Verification Code is : " + VerificationCode;
        string empty2 = string.Empty;
        getString(area_area.getPageHTML("http://bsms.ufone.com/bsms_app4/sendapi.jsp?id=" + ConfigurationManager.AppSettings["SMSID"].ToString() + "&message=" + str + "&shortcode=" + ConfigurationManager.AppSettings["MsgShortCode"].ToString() + "&lang=English&mobilenum=92" + PhoneNumber + "&password=" + ConfigurationManager.AppSettings["MsgPassword"].ToString()), "<body>", "</body>").Trim();
    }

    private string getString(string ActualString, string StartValue, string EndValue)
    {
        string empty = string.Empty;
        return ActualString.Substring(ActualString.IndexOf(StartValue), ActualString.IndexOf(EndValue, ActualString.IndexOf(StartValue)) - ActualString.IndexOf(StartValue)).Replace(StartValue, "").Trim();
    }

    protected static string getPageHTML(string _pageURL)
    {
        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(_pageURL);
        httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1;..NET CLR 1.1.4322)";
        return new StreamReader(httpWebRequest.GetResponse().GetResponseStream()).ReadToEnd();
    }

    protected void rptDocumentPersonal_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
            return;
        int itemType = (int)e.Item.ItemType;
    }

    protected void rptDocumentExperience_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
            return;
        int itemType = (int)e.Item.ItemType;
    }

    protected void rptDocumentOther_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
            return;
        int itemType = (int)e.Item.ItemType;
    }

    private DataSet BindPersonalDocumentsUploaders()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidatePersonalDocCheckList", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
            }
        }
        return dataSet;
    }

    private DataSet BindExperienceDocumentsUploaders()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateExperienceDocChecklist", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
            }
        }
        return dataSet;
    }

    private DataSet BindDocumentsUploaders()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateOtherDocChecklist", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
            }
        }
        return dataSet;
    }

    private void BindData(int CandidateCode)
    {
        DataSet dataSet1 = new DataSet();
        DataSet dataSet2 = BindPersonalDocumentsUploaders();
        if (dataSet2 != null && dataSet2.Tables != null)
        {
            if (dataSet2.Tables[0].Rows.Count > 0)
            {
                lblDocumentPersonal.Visible = false;
                rptDocumentPersonal.DataSource = dataSet2.Tables[0];
                rptDocumentPersonal.DataBind();
            }
            else
                lblDocumentPersonal.Visible = true;
            if (dataSet2.Tables[1].Rows.Count > 0)
            {
                lblName.Text = dataSet2.Tables[1].Rows[0]["Full_Name"].ToString();
                lblDept.Text = dataSet2.Tables[1].Rows[0]["domain_Name"].ToString();
                lblDesg.Text = dataSet2.Tables[1].Rows[0]["Designation_Name"].ToString();
                lblCat.Text = dataSet2.Tables[1].Rows[0]["Category_Name"].ToString();
            }
        }
        else
            lblDocumentPersonal.Visible = true;
        DataSet dataSet3 = new DataSet();
        DataSet dataSet4 = BindExperienceDocumentsUploaders();
        if (dataSet4 != null && dataSet4.Tables != null)
        {
            if (dataSet4.Tables[0].Rows.Count > 0)
            {
                lblDocumentExperience.Visible = false;
                rptDocumentExperience.DataSource = dataSet4.Tables[0];
                rptDocumentExperience.DataBind();
            }
            else
                lblDocumentExperience.Visible = true;
        }
        else
            lblDocumentExperience.Visible = true;
        DataSet dataSet5 = new DataSet();
        DataSet dataSet6 = BindDocumentsUploaders();
        if (dataSet6 != null && dataSet6.Tables != null)
        {
            if (dataSet6.Tables[0].Rows.Count > 0)
            {
                lblDocumentOther.Visible = false;
                rptDocumentOther.DataSource = dataSet6.Tables[0];
                rptDocumentOther.DataBind();
            }
            else
                lblDocumentOther.Visible = true;
        }
        else
            lblDocumentOther.Visible = true;
    }






}
