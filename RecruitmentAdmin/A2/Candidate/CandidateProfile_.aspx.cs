using ErrorLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using XRecruitmentStatusLibrary;

public partial class A2_Candidate_CandidateProfile_ : CustomBasePage, IRequiresSessionState
{

    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    private SecureQueryString sQString = new SecureQueryString();
    private string QueryStringVar = string.Empty;
    private string CandidateCode = string.Empty;
    private string IsTest = "true";
    private DataSet CandidateDS = new DataSet();
    private SecureQueryString secQueryString;
    private int StatusCodeM;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            this.secQueryString = new SecureQueryString(this.QueryStringVar);
            this.CandidateCode = this.secQueryString["CID"].ToString();
            if (!this.IsPostBack && !string.IsNullOrEmpty(this.CandidateCode))
            {
                this.BindCandidateDetail(this.CandidateCode);
                this.ShowHideActions();
            }
            string str = ConfigurationManager.AppSettings["WebDomainAddress"].ToString() + "AdminRedirector.aspx?";
            this.aEditExperience.Attributes.Add("data-rel", str + SecureQueryString.QueryStringVar + "=" + this.sQString.encrypt("candidate_code=" + this.secQueryString["CID"].ToString() + "&url=Profile/Experience.aspx&utc=" + (object)Convert.ToInt32((object)Constants.UserTypeCode.Admin) + "&auc=" + (object)this.UserCode));
            this.aEditEducation.Attributes.Add("data-rel", str + SecureQueryString.QueryStringVar + "=" + this.sQString.encrypt("candidate_code=" + this.secQueryString["CID"].ToString() + "&url=Profile/Education.aspx&utc=" + (object)Convert.ToInt32((object)Constants.UserTypeCode.Admin) + "&auc=" + (object)this.UserCode));
            this.aPortfolio.Attributes.Add("data-rel", str + SecureQueryString.QueryStringVar + "=" + this.sQString.encrypt("candidate_code=" + this.secQueryString["CID"].ToString() + "&url=Profile/Portfolio.aspx&utc=" + (object)Convert.ToInt32((object)Constants.UserTypeCode.Admin) + "&auc=" + (object)this.UserCode));
            this.aDocuments.Attributes.Add("data-rel", str + SecureQueryString.QueryStringVar + "=" + this.sQString.encrypt("candidate_code=" + this.secQueryString["CID"].ToString() + "&url=Profile/uploadDocuments.aspx&utc=" + (object)Convert.ToInt32((object)Constants.UserTypeCode.Admin) + "&auc=" + (object)this.UserCode));
            this.aDiploma.Attributes.Add("data-rel", str + SecureQueryString.QueryStringVar + "=" + this.sQString.encrypt("candidate_code=" + this.secQueryString["CID"].ToString() + "&url=Profile/Diploma.aspx&utc=" + (object)Convert.ToInt32((object)Constants.UserTypeCode.Admin) + "&auc=" + (object)this.UserCode));
            this.aCertificate.Attributes.Add("data-rel", str + SecureQueryString.QueryStringVar + "=" + this.sQString.encrypt("candidate_code=" + this.secQueryString["CID"].ToString() + "&url=Profile/Certificate.aspx&utc=" + (object)Convert.ToInt32((object)Constants.UserTypeCode.Admin) + "&auc=" + (object)this.UserCode));
            this.aFamily.Attributes.Add("data-rel", str + SecureQueryString.QueryStringVar + "=" + this.sQString.encrypt("candidate_code=" + this.secQueryString["CID"].ToString() + "&url=Profile/Familydetails.aspx&utc=" + (object)Convert.ToInt32((object)Constants.UserTypeCode.Admin) + "&auc=" + (object)this.UserCode));
            this.lnkAddEditSkillSet.Attributes.Add("data-rel", str + SecureQueryString.QueryStringVar + "=" + this.sQString.encrypt("candidate_code=" + this.secQueryString["CID"].ToString() + "&url=Profile/skillset.aspx&utc=" + (object)Convert.ToInt32((object)Constants.UserTypeCode.Admin) + "&auc=" + (object)this.UserCode));
            this.APersonalEdit.Attributes.Add("data-rel", str + SecureQueryString.QueryStringVar + "=" + this.sQString.encrypt("candidate_code=" + this.secQueryString["CID"].ToString() + "&url=Profile/personaldetails.aspx&utc=" + (object)Convert.ToInt32((object)Constants.UserTypeCode.Admin) + "&auc=" + (object)this.UserCode));
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void Btn_SearchByRefno(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.txtRefNo.Text))
                return;
            if (this.connection.State != ConnectionState.Open)
                this.connection.Open();
            DataTable dataTable = new DataTable();
            using (SqlCommand selectCommand = new SqlCommand("dbo.xrec_Select_etIDByRefNo", this.connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add(new SqlParameter("@RefNo", (object)this.txtRefNo.Text));
                new SqlDataAdapter(selectCommand).Fill(dataTable);
            }
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
            if (dataTable == null)
                return;
            if (dataTable.Rows.Count > 0)
            {
                this.CandidateCode = dataTable.Rows[0]["candidate_code"].ToString();
                this.Page.RegisterStartupScript("REFRESHpAGESCRIPT", "<script language=JavaScript>window.location='" + ("/A2/Candidate/CandidateProfile.aspx?data=" + new SecureQueryString().encrypt("CID=" + this.CandidateCode)) + "';</script>");
            }
            else
                this.Page.RegisterStartupScript("REFRESHpAGESCRIPT11", "<script language=JavaScript>alert('No candidate found.');</script>");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void btnSaveContacts_Click(object sender, EventArgs e)
    {
        try
        {
            using (new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
            {
                if (this.connection.State != ConnectionState.Open)
                    this.connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.XRec_UpdatePrimaryInformation", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@CandidateCode", (object)this.CandidateCode);
                if (!string.IsNullOrEmpty(this.NewEmail.Value))
                    sqlCommand.Parameters.Add("@Email", (object)this.NewEmail.Value);
                if (!string.IsNullOrEmpty(this.NewContact.Value))
                    sqlCommand.Parameters.Add("@Contact", (object)this.NewContact.Value);
                sqlCommand.Parameters.Add("@UpdatedBy", (object)this.UserCode);
                sqlCommand.Parameters.Add("@UpdatedIP", (object)this.USERIP);
                sqlCommand.ExecuteNonQuery();
                this.InsertUserCommunicationComments("Manual Change Email and Mobile Number", "Personal Details");
                if (this.connection.State != ConnectionState.Closed)
                    this.connection.Close();
                this.Page.RegisterStartupScript("Close", "<script language=JavaScript>window.location=window.location;</script>");
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void btn_SaveBrowsedImg(object sender, EventArgs e)
    {
        try
        {
            if (!this.fuPic.HasFile)
                return;
            string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + "Official/" + this.CandidateCode + "/";
            if (!this.fuPic.HasFile)
                return;
            GeneralMethods.FileBrowse(this.fuPic, FolderPath, "InitialPicture");
            string str = FolderPath + "InitialPicture" + Path.GetExtension(this.fuPic.FileName);
            if (this.connection.State != ConnectionState.Open)
                this.connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateInitialPictatus", this.connection);
            sqlCommand.Parameters.AddWithValue("@CandidateCode", (object)this.CandidateCode);
            sqlCommand.Parameters.AddWithValue("@Path", (object)str);
            sqlCommand.Parameters.AddWithValue("@InitialPicStatus", (object)1);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            if (this.connection.State == ConnectionState.Closed)
                return;
            this.connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void rptOfficialDocuments_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (this.connection.State != ConnectionState.Open)
                this.connection.Open();
            if (e.CommandArgument.ToString() != "4" && e.CommandArgument.ToString() != "9")
            {
                SqlCommand sqlCommand = new SqlCommand("dbo.XREC_Insert_ReGenerateOfficialLetter", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Candidate_Code", SqlDbType.Int).Value = (object)e.CommandName;
                sqlCommand.Parameters.Add("@OfficialLetter_Code", SqlDbType.Int).Value = e.CommandArgument;
                sqlCommand.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = (object)this.UserCode;
                sqlCommand.Parameters.Add("@UpdationIP", SqlDbType.VarChar).Value = (object)this.USERIP;
                sqlCommand.ExecuteNonQuery();
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Document will be uploaded in few mins!');", true);
            }
            else if (e.CommandArgument.ToString() == "4" && e.CommandArgument.ToString() != "9")
            {
                FileUpload control1 = (FileUpload)e.Item.FindControl("FUDocs");
                HiddenField control2 = (HiddenField)e.Item.FindControl("CandidateDocumentName");
                HiddenField control3 = (HiddenField)e.Item.FindControl("hdnCandDocCode");
                HiddenField control4 = (HiddenField)e.Item.FindControl("hdnDocumentCode");
                if (string.IsNullOrEmpty(control4.Value))
                    control4.Value = "26";
                if (control1.HasFile)
                {
                    Path.GetExtension(control1.FileName).ToLower();
                    string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + this.CandidateCode + "/Official/";
                    GeneralMethods.FileBrowse(control1, FolderPath, control2.Value + "-" + control4.Value);
                    string str = FolderPath + control2.Value + "-" + control4.Value + Path.GetExtension(control1.FileName);
                    SqlCommand sqlCommand = new SqlCommand("dbo.insert_Update_CandidateDocumentDigitalization", this.connection);
                    sqlCommand.Parameters.AddWithValue("@Candidate_Code", (object)this.CandidateCode);
                    sqlCommand.Parameters.AddWithValue("@Document_Code", (object)control4.Value);
                    if (control3.Value != "0" && control3.Value != "")
                        sqlCommand.Parameters.AddWithValue("@CandDoc_Code", (object)control3.Value);
                    sqlCommand.Parameters.AddWithValue("@DocumentPath", (object)str);
                    sqlCommand.Parameters.AddWithValue("@CandidateDocumentName", (object)control2.Value);
                    sqlCommand.Parameters.AddWithValue("@UpdatedBy", (object)this.UserCode);
                    sqlCommand.Parameters.AddWithValue("@UpdatedIp", (object)this.USERIP);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
                }
            }
            if (this.connection.State == ConnectionState.Closed)
                return;
            this.connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void rptOfficialDocuments_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem || !(DataBinder.Eval(e.Item.DataItem, "OfficialLetter_Code").ToString() == "4") && !(DataBinder.Eval(e.Item.DataItem, "OfficialLetter_Code").ToString() == "3") && !(DataBinder.Eval(e.Item.DataItem, "OfficialLetter_Code").ToString() == "9"))
                return;
            LinkButton control1 = (LinkButton)e.Item.FindControl("btnReserve");
            Image control2 = (Image)e.Item.FindControl("Image2");
            control1.Visible = false;
            control2.Visible = false;
            if (!(DataBinder.Eval(e.Item.DataItem, "OfficialLetter_Code").ToString() == "4") && !(DataBinder.Eval(e.Item.DataItem, "OfficialLetter_Code").ToString() == "9"))
                return;
            HtmlAnchor control3 = (HtmlAnchor)e.Item.FindControl("AUploadDocs");
            FileUpload control4 = (FileUpload)e.Item.FindControl("FUDocs");
            LinkButton control5 = (LinkButton)e.Item.FindControl("lnkUploadDoc");
            control3.Attributes.Add("OnClick", "$('#" + control4.ClientID + "').click();");
            control3.Style.Add("display", "");
            control4.Attributes.Add("onchange", "$('#" + control5.ClientID + "').show();");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void rptScheduleHistory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            HtmlAnchor control1 = (HtmlAnchor)e.Item.FindControl("aShow");
            HtmlAnchor control2 = (HtmlAnchor)e.Item.FindControl("aHide");
            Repeater control3 = (Repeater)e.Item.FindControl("rptScheduledChild");
            HtmlTable control4 = (HtmlTable)e.Item.FindControl("tblChild");
            HiddenField control5 = (HiddenField)e.Item.FindControl("hdnRSCode");
            if (control5.Value == null)
                return;
            SqlCommand selectCommand = new SqlCommand("dbo.Xrec_Select_InterViewPanelDateWise", this.connection);
            selectCommand.Parameters.AddWithValue("@ReserveSlot_Code", (object)control5.Value);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0 && dataTable != null)
            {
                control3.DataSource = (object)dataTable;
                control3.DataBind();
                control2.Attributes.Add("onclick", "HidePanel('" + control2.ClientID + "','" + control1.ClientID + "','" + control4.ClientID + "')");
                control1.Attributes.Add("onclick", "ShowPanel('" + control1.ClientID + "','" + control2.ClientID + "','" + control4.ClientID + "')");
            }
            else
            {
                Label control6 = (Label)e.Item.FindControl("lblShow");
                Label control7 = (Label)e.Item.FindControl("lblHide");
                control6.Text = "-";
                control7.Text = "-";
                control2.HRef = (string)null;
                control1.HRef = (string)null;
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void rptQuestionGroup_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string str1 = DataBinder.Eval(e.Item.DataItem, "QuestionGroupCode").ToString();
                string str2 = DataBinder.Eval(e.Item.DataItem, "SectionCode").ToString();
                Label control1 = (Label)e.Item.FindControl("lblCorrect");
                Label control2 = (Label)e.Item.FindControl("lblWrong");
                Label control3 = (Label)e.Item.FindControl("lblTotal");
                Label control4 = (Label)e.Item.FindControl("lblPending");
                Label control5 = (Label)e.Item.FindControl("lblSno");
                if (this.CandidateDS.Tables.Count >= 14 && this.CandidateDS.Tables[13].Rows.Count > 0)
                {
                    float length1 = (float)this.CandidateDS.Tables[13].Select("SectionCode=" + str2 + " and QuestionGroupCode=" + str1 + " and IsCorrect=1").Length;
                    float length2 = (float)this.CandidateDS.Tables[13].Select("SectionCode=" + str2 + " and QuestionGroupCode=" + str1 + " and IsCorrect=0").Length;
                    float length3 = (float)this.CandidateDS.Tables[13].Select("SectionCode=" + str2 + " and QuestionGroupCode=" + str1).Length;
                    float length4 = (float)this.CandidateDS.Tables[13].Select("SectionCode=" + str2 + " and QuestionGroupCode=" + str1 + " and IsCorrect is null").Length;
                    control1.Text = length1.ToString();
                    control2.Text = length2.ToString();
                    control3.Text = (length1 * 100f / length3).ToString() + "%";
                    control4.Text = length4.ToString();
                }
            }
            if (e.Item.ItemType != ListItemType.Footer || this.CandidateDS.Tables[11].Rows.Count <= 0)
                return;
            Label control6 = (Label)e.Item.FindControl("lblCorrecttot");
            Label control7 = (Label)e.Item.FindControl("lblWrongtot");
            Label control8 = (Label)e.Item.FindControl("lblTotaltot");
            Label control9 = (Label)e.Item.FindControl("lblPendingtot");
            control6.Text = this.CandidateDS.Tables[11].Rows[0]["Correct"].ToString();
            control7.Text = this.CandidateDS.Tables[11].Rows[0]["Wrong"].ToString();
            control8.Text = "";
            control9.Text = this.CandidateDS.Tables[11].Rows[0]["ResultPending"].ToString();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void RptExperienence_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            DataRowView dataItem = (DataRowView)e.Item.DataItem;
            HtmlGenericControl control1 = (HtmlGenericControl)e.Item.FindControl("SpBenefit");
            HtmlGenericControl control2 = (HtmlGenericControl)e.Item.FindControl("SpCashAll");
            HtmlGenericControl control3 = (HtmlGenericControl)e.Item.FindControl("SpLifeStyle");
            HtmlGenericControl control4 = (HtmlGenericControl)e.Item.FindControl("SPOffDays");
            control1.InnerHtml = "<ul class=\"blueblocks\">" + dataItem["benefits"].ToString().Replace("&lt;", "<").Replace("&gt;", ">") + "</ul>";
            control2.InnerHtml = "<ul class=\"blueblocks\">" + dataItem["benefitsCA"].ToString().Replace("&lt;", "<").Replace("&gt;", ">") + "</ul>";
            control3.InnerHtml = "<ul class=\"blueblocks\">" + dataItem["benefitsLS"].ToString().Replace("&lt;", "<").Replace("&gt;", ">") + "</ul>";
            control4.InnerHtml = "<ul class=\"blueblocks\">" + dataItem["benefitsOD"].ToString().Replace("&lt;", "<").Replace("&gt;", ">") + "</ul>";
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void lnkMarkOfferDelivered_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.txtaOfferdelivered.InnerText))
                return;
            if (this.connection.State != ConnectionState.Open)
                this.connection.Open();
            if (this.fuOffer.HasFile)
            {
                if (string.IsNullOrEmpty(this.hdnDocumentCode.Value))
                    this.hdnDocumentCode.Value = "26";
                if (!string.IsNullOrEmpty(this.hdnDocName.Value) && !string.IsNullOrEmpty(this.hdnDocumentCode.Value))
                {
                    Path.GetExtension(this.fuOffer.FileName).ToLower();
                    string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + this.CandidateCode + "/Official/";
                    GeneralMethods.FileBrowse(this.fuOffer, FolderPath, this.hdnDocName.Value + "-" + this.hdnDocumentCode.Value);
                    string str = FolderPath + this.hdnDocName.Value + "-" + this.hdnDocumentCode.Value + Path.GetExtension(this.fuOffer.FileName);
                    SqlCommand sqlCommand = new SqlCommand("dbo.insert_Update_CandidateDocumentDigitalization", this.connection);
                    sqlCommand.Parameters.AddWithValue("@Candidate_Code", (object)this.CandidateCode);
                    sqlCommand.Parameters.AddWithValue("@Document_Code", (object)this.hdnDocumentCode.Value);
                    if (this.hdnCanDocCode.Value != "0" && this.hdnCanDocCode.Value != "")
                        sqlCommand.Parameters.AddWithValue("@CandDoc_Code", (object)this.hdnCanDocCode.Value);
                    sqlCommand.Parameters.AddWithValue("@DocumentPath", (object)str);
                    sqlCommand.Parameters.AddWithValue("@CandidateDocumentName", (object)this.hdnDocName.Value);
                    sqlCommand.Parameters.AddWithValue("@UpdatedBy", (object)this.UserCode);
                    sqlCommand.Parameters.AddWithValue("@UpdatedIp", (object)this.USERIP);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
                }
            }
            StatusManagement.MarkLifeCycleStatus(this.connection, Convert.ToInt32(this.CandidateCode), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.OfferDeliveredAcceptancePending, this.USERIP, this.UserCode);
            this.InsertUserOfferDeliveredComments();
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Saved Successfully!');", true);
            this.BindCandidateDetail(this.CandidateCode);
            if (this.connection.State == ConnectionState.Closed)
                return;
            this.connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
            this.lblMsgOffer.Text = "file not Uploaded.";
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void lnkMarkOfferAccepted_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.connection.State != ConnectionState.Open)
                this.connection.Open();
            if (!string.IsNullOrEmpty(this.txtaOfferAccepetance.InnerText))
            {
                this.InsertUserOfferAcceptedComments(true);
                StatusManagement.MarkLifeCycleStatus(this.connection, Convert.ToInt32(this.CandidateCode), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.OfferAcceptedVerificationSchedulingPending, this.USERIP, this.UserCode);
                this.ClearCandidateAvailedSlots();
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Saved Successfully!');", true);
                this.BindCandidateDetail(this.CandidateCode);
            }
            else
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please insert comments.');", true);
            if (this.connection.State == ConnectionState.Closed)
                return;
            this.connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void lnkAppointmentGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.connection.State != ConnectionState.Open)
                this.connection.Open();
            if (!string.IsNullOrEmpty(this.txtaAppointmentGeneration.InnerHtml))
            {
                SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateInterview", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = (object)Convert.ToInt32(this.CandidateCode);
                sqlCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = (object)this.UserCode;
                sqlCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = (object)this.txtaAppointmentGeneration.InnerText;
                sqlCommand.Parameters.Add("@LifeCycleStatus", SqlDbType.Int).Value = (object)Convert.ToInt32((object)Constants.CandidateLifeCycleStatus.AppointmentSchedulingDoneJoiningReportingPending);
                sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = (object)this.UserCode;
                sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = (object)this.USERIP;
                sqlCommand.ExecuteNonQuery();
            }
            this.InsertDocumentToGeneratePDF("CandidateAppointmentLetter", 2);
            this.BindCandidateDetail(this.CandidateCode);
            if (this.connection.State == ConnectionState.Closed)
                return;
            this.connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void lnkOfferLetter_OnClick(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.hdnOfferLetter.Value))
                return;
            this.FileResponses(this.hdnOfferLetter.Value, ConfigurationManager.AppSettings["CandidateDocumentPath"].ToString() + (object)Convert.ToInt32(this.CandidateCode) + "/OfferLetter/");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void lnkShortlist_Click(object sender, EventArgs e)
    {
        try
        {
            this.ShortlistCandidate();
            this.sShortlist.Style.Add("display", "none");
            this.lnkShortlist.Text = "";
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Shortlisted Successfully!'); window.location=window.location;", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void lnkCreatePortal_Click(object sender, EventArgs e)
    {
        try
        {
            string str = string.Empty;
            foreach (ListItem listItem in this.chkjobrole.Items)
            {
                if (listItem.Selected)
                    str = str + listItem.Value + ",";
            }
            if (this.connection.State != ConnectionState.Open)
                this.connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_CreatePortalGenerationRequest", this.connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@shift_code", SqlDbType.Int).Value = (object)this.ddlshift.SelectedValue;
            sqlCommand.Parameters.Add("@city_Code", SqlDbType.Int).Value = (object)this.ddlCity.SelectedValue;
            sqlCommand.Parameters.Add("@Candidate_ID", SqlDbType.VarChar).Value = (object)this.lblRefNo.Text;
            sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = (object)this.UserCode;
            sqlCommand.Parameters.Add("@Updation_IP", SqlDbType.VarChar).Value = (object)this.USERIP;
            sqlCommand.Parameters.Add("@JobRole_Code", SqlDbType.VarChar).Value = (object)str;
            sqlCommand.Parameters.Add("@City_Name", SqlDbType.VarChar).Value = (object)this.ddlCity.SelectedItem.Text;
            sqlCommand.Parameters.Add("@TeamLeaderCode", SqlDbType.Int).Value = (object)this.ddlTL.SelectedValue;
            sqlCommand.Parameters.Add("@AssignedUser_Code", SqlDbType.Int).Value = (object)this.ddlAssignUser.SelectedValue;
            sqlCommand.ExecuteNonQuery();
            this.BindCandidateDetail(this.CandidateCode);
            if (this.connection.State == ConnectionState.Closed)
                return;
            this.connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void lnkSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.txtaComments.InnerText))
                return;
            if (this.connection.State != ConnectionState.Open)
                this.connection.Open();
            this.InsertUserInterviewComments();
            if (this.txtDSalary.Text != "" && this.ddlStatement.SelectedValue != "-1")
                this.InsertUserInterviewCommentsOfferApproval();
            if (this.rdbPass.Checked && this.ddlGrade.SelectedValue != "-1" && this.ddlDesignation.SelectedValue != "-1")
            {
                StatusManagement.MarkLifeCycleStatus(this.connection, Convert.ToInt32(this.CandidateCode), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.InterviewDoneOfferGenerated, this.USERIP, this.UserCode);
                this.ClearCandidateAvailedSlots();
            }
            else if (this.rdbFail.Checked && ((IEnumerable<DataRow>)this.DTActions.Select("MenuLinkActionCode = 105")).Count<DataRow>() > 0)
            {
                StatusManagement.MarkLifeCycleStatus(this.connection, Convert.ToInt32(this.CandidateCode), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.InterviewFailedReSchedulingPending, this.USERIP, this.UserCode);
                this.ClearCandidateAvailedSlots();
            }
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Saved Successfully!'); window.location=window.location;", true);
            if (this.connection.State == ConnectionState.Closed)
                return;
            this.connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void lnkSkipStatus_click(object sender, EventArgs e)
    {
        try
        {
            StatusManagement.MarkLifeCycleStatus(this.connection, Convert.ToInt32(this.CandidateCode), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.VerificationSchedulingDoneVerficationPending, this.USERIP, this.UserCode);
            this.InsertUserCommunicationComments("Verification Schedulling Status Skip", "Status Skip");
            this.Page.RegisterStartupScript("REFRESHpAGESCRIPT", "<script language=JavaScript>window.location= window.location;</script>");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void lnkNotJoin_click(object sender, EventArgs e)
    {
        try
        {
            if (this.connection.State != ConnectionState.Open)
                this.connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XREC_Update_CandidateStatusManual", this.connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@StatusCode", (object)Convert.ToInt32((object)Constants.CandidateLifeCycleStatus.OfferAcceptedJoiningNotDone));
            sqlCommand.Parameters.AddWithValue("@Comments", (object)"Click on Not Join Button");
            sqlCommand.Parameters.AddWithValue("@UpdationIP", (object)this.USERIP);
            sqlCommand.Parameters.AddWithValue("@UpdatedByUser", (object)this.UserCode);
            sqlCommand.Parameters.AddWithValue("@Candidate_Code", (object)this.CandidateCode);
            sqlCommand.ExecuteNonQuery();
            this.Page.RegisterStartupScript("REFRESHpAGESCRIPT", "<script language=JavaScript>window.location= window.location;</script>");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void lnkEditDate_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.connection.State != ConnectionState.Open)
                this.connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateJoiningDate", this.connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = (object)Convert.ToInt32(this.CandidateCode);
            sqlCommand.Parameters.Add("@JoiningDate", SqlDbType.DateTime).Value = (object)Convert.ToDateTime(this.JoiningDate.Value);
            sqlCommand.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = (object)this.UserCode;
            sqlCommand.Parameters.Add("@UpdatedIp", SqlDbType.VarChar).Value = (object)this.USERIP;
            sqlCommand.ExecuteNonQuery();
            this.BindCandidateDetail(this.CandidateCode);
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Joining Date Changed Successfully!');", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void lnkEdiDesignation_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.connection.State != ConnectionState.Open)
                this.connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateDesignations", this.connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = (object)Convert.ToInt32(this.CandidateCode);
            sqlCommand.Parameters.Add("@DesignationCode", SqlDbType.Int).Value = (object)this.ddlDesignationC.SelectedValue;
            sqlCommand.Parameters.Add("@GradeCode", SqlDbType.Int).Value = (object)this.ddlgradeC.SelectedValue;
            sqlCommand.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = (object)this.UserCode;
            sqlCommand.Parameters.Add("@UpdatedIp", SqlDbType.VarChar).Value = (object)this.USERIP;
            sqlCommand.ExecuteNonQuery();
            this.InsertUserCommunicationComments("Manual Change Designation and grade", "Designation Change");
            this.BindCandidateDetail(this.CandidateCode);
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Designation and Grade has been saved successfully!');", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void lnkOfferGenerationPending_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.connection.State != ConnectionState.Open)
                this.connection.Open();
            if (!string.IsNullOrEmpty(this.txtaOfferGenerationPending.InnerHtml))
                this.InsertUserOfferGeneratedComments();
            this.InsertDocumentToGeneratePDF("Offer Letter", 1);
            StatusManagement.MarkLifeCycleStatus(this.connection, Convert.ToInt32(this.CandidateCode), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.OfferGeneratedSchedulingPending, this.USERIP, this.UserCode);
            this.BindCandidateDetail(this.CandidateCode);
            if (this.connection.State == ConnectionState.Closed)
                return;
            this.connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    protected void lnkMarkOfferNotAccepted_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(this.txtaOfferAccepetance.InnerText))
                this.InsertUserOfferAcceptedComments(false);
            if (this.connection.State != ConnectionState.Open)
                this.connection.Open();
            StatusManagement.MarkLifeCycleStatus(this.connection, Convert.ToInt32(this.CandidateCode), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.OfferNotAcceptedReSchedulingPendingOffer, this.USERIP, this.UserCode);
            this.ClearCandidateAvailedSlots();
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Saved Successfully!');", true);
            this.BindCandidateDetail(this.CandidateCode);
            if (this.connection.State == ConnectionState.Closed)
                return;
            this.connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    public void BindCandidateDetail(string CandCode)
    {
        try
        {
            string str1 = "0";
            string str2 = "0";
            string str3 = "0";
            this.aStatusChange.Attributes.Add("Data-rel", "http://recruitment.axact.com/Candidate/UpdateCandidateInfo.aspx?" + SecureQueryString.QueryStringVar + "=" + this.secQueryString.encrypt("type=1&CID=" + CandCode));
            this.aProfileChange.Attributes.Add("Data-rel", "http://recruitment.axact.com/Candidate/UpdateCandidateInfo.aspx?" + SecureQueryString.QueryStringVar + "=" + this.secQueryString.encrypt("type=2&CID=" + CandCode));
            this.aRequisitionChange.Attributes.Add("Data-rel", "http://recruitment.axact.com/Candidate/UpdateCandidateInfo.aspx?" + SecureQueryString.QueryStringVar + "=" + this.secQueryString.encrypt("type=3&CID=" + CandCode));
            this.aEditProfile.Attributes.Add("Data-rel", "http://recruitment.axact.com/Candidate/UpdateCandidateProfileInfo.aspx?" + SecureQueryString.QueryStringVar + "=" + this.secQueryString.encrypt("type=3&CID=" + CandCode));
            this.aDocVerification.Attributes.Add("Data-rel", "http://recruitment.axact.com/candidate/CandidateDocumentVerification.aspx?" + SecureQueryString.QueryStringVar + "=" + this.secQueryString.encrypt("CID=" + CandCode));
            this.aAppHistory.Attributes.Add("Data-rel", "http://recruitment.axact.com/Candidate/CandidateApplication.aspx?" + SecureQueryString.QueryStringVar + "=" + this.secQueryString.encrypt("CID=" + CandCode));
            SqlCommand selectCommand = new SqlCommand("dbo.XRec_SelectCandidateDetailNew", this.connection);
            selectCommand.Parameters.AddWithValue("@Candidate_Code", (object)CandCode);
            selectCommand.CommandType = CommandType.StoredProcedure;
            new SqlDataAdapter(selectCommand).Fill(this.CandidateDS);
            if (this.CandidateDS != null && this.CandidateDS.Tables.Count >= 1 && this.CandidateDS.Tables[0].Rows.Count > 0)
            {
                this.lblCanName.Text = this.CandidateDS.Tables[0].Rows[0]["full_name"].ToString();
                this.lblEmailAddress.Text = this.CandidateDS.Tables[0].Rows[0]["email_address"].ToString();
                this.lblGender.Text = this.CandidateDS.Tables[0].Rows[0]["gender"].ToString();
                this.lblMaritalStatus.Text = this.CandidateDS.Tables[0].Rows[0]["maritalstatus"].ToString();
                this.lblDOB.Text = this.CandidateDS.Tables[0].Rows[0]["DateOf_Birth"].ToString();
                this.lblAddress.Text = this.CandidateDS.Tables[0].Rows[0]["Address"].ToString();
                this.lblNIC.Text = this.CandidateDS.Tables[0].Rows[0]["NIC"].ToString();
                this.lblApplyDate.Text = this.CandidateDS.Tables[0].Rows[0]["ApplyDate"].ToString();
                this.lblRefferal.Text = this.CandidateDS.Tables[0].Rows[0]["Referral"].ToString();
                this.lblRefNo.Text = this.CandidateDS.Tables[0].Rows[0]["Candidate_ID"].ToString();
                this.lblReligion.Text = this.CandidateDS.Tables[0].Rows[0]["religion"].ToString();
                this.lblNationality.Text = this.CandidateDS.Tables[0].Rows[0]["Nationality"].ToString();
                this.SpShit.InnerHtml = this.CandidateDS.Tables[0].Rows[0]["AvailbilityShift"].ToString();
                this.SPMobile.InnerHtml = this.CandidateDS.Tables[0].Rows[0]["Home_Number"].ToString();
                this.imgCandidate.Src = this.CandidateDS.Tables[0].Rows[0]["PicPath"].ToString();
                this.txtEmailCandidate.Text = this.CandidateDS.Tables[0].Rows[0]["email_address"].ToString();
                this.txtMobileCandidate.Text = this.CandidateDS.Tables[0].Rows[0]["Phone_Number"].ToString();
                this.NewEmail.Value = this.CandidateDS.Tables[0].Rows[0]["email_address"].ToString();
                this.NewContact.Value = this.CandidateDS.Tables[0].Rows[0]["Phone_Number"].ToString();
                this.lblHeight.Text = this.CandidateDS.Tables[0].Rows[0]["Height"].ToString();
                this.lblExpectedSal.Text = this.CandidateDS.Tables[0].Rows[0]["ExpectedSalary"].ToString();
                this.lblWeight.Text = this.CandidateDS.Tables[0].Rows[0]["Weight"].ToString();
                str1 = this.CandidateDS.Tables[0].Rows[0]["Is_Staff"].ToString();
                if (!string.IsNullOrEmpty(this.CandidateDS.Tables[0].Rows[0]["PortalReferral"].ToString()))
                    this.lblPortalReferral.Text = this.CandidateDS.Tables[0].Rows[0]["PortalReferral"].ToString();
                else
                    this.trPRef.Style.Add("display", "none");
                this.imgBigImage.Src = this.CandidateDS.Tables[0].Rows[0]["PicPath"].ToString();
                this.lblTotalExp.Text = this.CandidateDS.Tables[0].Rows[0]["TotalExp"].ToString();
                this.ABigImage.Attributes.Add("data-rel", this.CandidateDS.Tables[0].Rows[0]["PicPath"].ToString());
                this.lblIsLinkedin.Text = this.CandidateDS.Tables[0].Rows[0]["IsLinkedin"].ToString();
                if (this.lblIsLinkedin.Text == "No")
                    this.trLink.Style.Add("display", "none");
                this.lblOldStatus.Text = this.CandidateDS.Tables[0].Rows[0]["OldStatus"].ToString();
                if (this.lblOldStatus.Text == "No")
                    this.trOldStatus.Style.Add("display", "none");
                this.lblRefferalUrl.Text = this.CandidateDS.Tables[0].Rows[0]["referralurl"].ToString();
                if (this.lblRefferalUrl.Text == "-")
                    this.trReferralUrl.Style.Add("display", "none");
                this.lblIsMigrated.Text = this.CandidateDS.Tables[0].Rows[0]["IsMigrated"].ToString();
                if (this.lblIsMigrated.Text == "No")
                    this.trMigrated.Style.Add("display", "none");
                if (!string.IsNullOrEmpty(this.CandidateDS.Tables[0].Rows[0]["Resume_Path"].ToString()))
                    this.lnkbtnCV.HRef = this.CandidateDS.Tables[0].Rows[0]["Resume_Path"].ToString();
                else
                    this.lnkbtnCV.Visible = false;
                if (this.CandidateDS.Tables[0].Rows[0]["Is_Redundent"].ToString() == "0")
                {
                    this.imgNICNotVerified.Visible = false;
                }
                else
                {
                    this.tdNic.Style.Add("Background-color", "#FFD9D9 !important");
                    this.tdNic.Style.Add("border", "2px solid #F00 !important");
                    this.lblNIC.Style.Add("text-shadow", "2px 2px 2px #ebebeb !important");
                }
                if ((bool)this.CandidateDS.Tables[0].Rows[0]["Is_EmailVerified"])
                {
                    this.imgEmailNotVerified.Visible = false;
                    this.lblemailverificationCode.Visible = false;
                }
                else
                {
                    this.lblemailverificationCode.Visible = true;
                    this.lblemailverificationCode.Text = this.CandidateDS.Tables[0].Rows[0]["emailVerificationCode"].ToString();
                    this.tdEmil.Style.Add("Background-color", "#FFD9D9");
                    this.tdEmil.Style.Add("border", "2px solid #F00");
                    this.lblemailverificationCode.Style.Add("text-shadow", "2px 2px 2px #ebebeb");
                    this.lblemailverificationCode.Style.Add("color", "#999");
                }
                if ((bool)this.CandidateDS.Tables[0].Rows[0]["is_PhoneVerified"])
                {
                    this.imgPhoneNotVerified.Visible = false;
                    this.lblPhoneVerificationCode.Visible = false;
                }
                else
                {
                    this.lblPhoneVerificationCode.Visible = true;
                    this.lblPhoneVerificationCode.Text = this.CandidateDS.Tables[0].Rows[0]["PhoneVerification_Code"].ToString();
                    this.tdPhone.Style.Add("Background-color", "#FFD9D9");
                    this.tdPhone.Style.Add("border", "2px solid #F00");
                    this.lblPhoneVerificationCode.Style.Add("text-shadow", "2px 2px 2px #ebebeb");
                }
            }
            int num = 0;
            if (this.CandidateDS.Tables.Count >= 6)
            {
                if (this.CandidateDS.Tables[5].Rows.Count > 0)
                {
                    this.SpCurrentStatus.InnerText = this.CandidateDS.Tables[5].Rows[0]["Status_Name"].ToString();
                    this.SpProfile.InnerText = this.CandidateDS.Tables[5].Rows[0]["Profile_Name"].ToString();
                    this.SpRequisition.InnerText = this.CandidateDS.Tables[5].Rows[0]["Requisition_Name"].ToString();
                    this.SpDomain.InnerText = this.CandidateDS.Tables[5].Rows[0]["Domain_name"].ToString();
                    this.SpSubDomain.InnerText = this.CandidateDS.Tables[5].Rows[0]["SubDomain_Name"].ToString();
                    this.SpRA.InnerText = this.CandidateDS.Tables[5].Rows[0]["RAName"].ToString();
                    this.SPGL.InnerText = this.CandidateDS.Tables[5].Rows[0]["GroupLeader"].ToString();
                    this.SPL.InnerText = this.CandidateDS.Tables[5].Rows[0]["TeamLeader"].ToString();
                    this.SPTeam.InnerText = this.CandidateDS.Tables[5].Rows[0]["TeamName"].ToString();
                    this.SPBU.InnerText = this.CandidateDS.Tables[5].Rows[0]["Unit"].ToString();
                    this.SpJoiningDate.InnerText = this.CandidateDS.Tables[5].Rows[0]["Joining_Date"].ToString() + "  " + this.CandidateDS.Tables[5].Rows[0]["Scheduling_Joining_Time"].ToString();
                    if (this.CandidateDS.Tables[5].Rows[0]["Joining_Date"].ToString() == "-")
                        this.JoiningDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
                    else
                        this.JoiningDate.Value = this.CandidateDS.Tables[5].Rows[0]["Joining_Date"].ToString();
                    this.SpDesignation.InnerText = this.CandidateDS.Tables[5].Rows[0]["Designation_Name"].ToString();
                    this.SpGrade.InnerText = this.CandidateDS.Tables[5].Rows[0]["Grade_Name"].ToString();
                    this.SpCategory.InnerText = this.CandidateDS.Tables[5].Rows[0]["Category_Name"].ToString();
                    str2 = this.CandidateDS.Tables[5].Rows[0]["TestCode"].ToString();
                    str3 = this.CandidateDS.Tables[5].Rows[0]["IsStaffDomain"].ToString();
                    if (this.CandidateDS.Tables[5].Rows[0]["Grade_Name"].ToString() != "-" && this.CandidateDS.Tables[5].Rows[0]["Designation_Name"].ToString() != "-")
                        this.aEditDesignation.Style.Add("display", "");
                    else
                        this.aEditDesignation.Style.Add("display", "none");
                    if (this.CandidateDS.Tables[5].Rows[0]["is_shift"].ToString() == "1")
                        this.trShifts.Style.Add("display", "");
                    if (this.CandidateDS.Tables[5].Rows[0]["is_height"].ToString() == "1")
                    {
                        this.trHeight.Style.Add("display", "");
                        this.trWeight.Style.Add("display", "");
                    }
                }
                this.ViewState["CurrentRefNo"] = (object)this.CandidateDS.Tables[5].Rows[0]["Candidate_ID"].ToString();
                num = Convert.ToInt32(this.CandidateDS.Tables[5].Rows[0]["Status_Code"]);
                this.StatusCodeM = Convert.ToInt32(this.CandidateDS.Tables[5].Rows[0]["Status_Code"]);
                this.IsTest = this.CandidateDS.Tables[5].Rows[0]["Is_Test"].ToString();
                if (Convert.ToInt32(this.CandidateDS.Tables[5].Rows[0]["AppCount"]) > 1)
                    this.aAppHistory.Visible = true;
                else
                    this.aAppHistory.Visible = false;
                if (!(bool)this.CandidateDS.Tables[5].Rows[0]["Is_locked"] && this.SpRequisition.InnerHtml != "-")
                {
                    this.sShortlist.Style.Add("display", "");
                    this.lnkShortlist.Text = "Shortlist";
                }
                else
                {
                    this.sShortlist.Style.Add("display", "none");
                    this.lnkShortlist.Text = "";
                }
            }
            if (num != 0)
            {
                if (num >= (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.VerificationSchedulingDoneVerficationPending))
                    this.aDocVerification.Visible = true;
                if (num == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.OfferAcceptedVerificationSchedulingPending))
                    this.aSkipSchedule.Style.Add("display", "");
                else
                    this.aSkipSchedule.Style.Add("display", "none");
                if (num == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.OfferAcceptedVerificationSchedulingPending) || num == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.VerificationSchedulingDoneVerficationPending) || (num == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.VerificationDoneAppointmentSchedulingPending) || num == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.AppointmentSchedulingDoneJoiningReportingPending)))
                    this.lnkNotJoin.Style.Add("display", "");
                else
                    this.lnkNotJoin.Style.Add("display", "none");
                if (num >= (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.OfferAcceptedVerificationSchedulingPending))
                    this.aEditDate.Visible = true;
                else
                    this.aEditDate.Visible = false;
                if (num <= (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.SignupdoneFormPending))
                {
                    this.aProfileChange.Visible = false;
                    this.aRequisitionChange.Visible = false;
                }
                else
                {
                    this.aRequisitionChange.Visible = false;
                    this.aProfileChange.Visible = true;
                }
                if (num >= (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.PositionMappedWaitingforPositionopening) && this.CandidateDS.Tables[5].Rows[0]["ReqCount"].ToString() != "0")
                    this.aRequisitionChange.Visible = true;
                else
                    this.aRequisitionChange.Visible = false;
                if (this.CandidateDS.Tables[5].Rows[0]["ReqCount"].ToString() == "0" && num >= (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.PositionMappedWaitingforPositionopening))
                    this.SpRequisition.InnerText = "No requisition mapped on selected Profile";
                else
                    this.SpCurrentStatus.InnerHtml = this.CandidateDS.Tables[5].Rows[0]["Status_Name"].ToString();
                this.ViewState["CurrentStatusCode"] = (object)num;
                if (num == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.ShortlistedSchedulingPendingTest) || num == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.TestFailedReSchedulingPendingTest) || num == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.TestnotAppearedReSchedulingPending))
                {
                    this.sSchedule.Style.Add("display", "");
                    this.aSchedule.InnerHtml = "Schedule For Test";
                    this.aSchedule.Attributes.Add("Data-rel", "http://recruitment.axact.com/schedule/SchduleCandidate.aspx?" + SecureQueryString.QueryStringVar + "=" + this.sQString.encrypt("refno=" + this.ViewState["CurrentRefNo"].ToString() + "&pgno=1"));
                }
                else if (num == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.TestPassedSchedulingPendingInterview) || num == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.NoTestSchedulingPendingInterview) || (num == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.InterviewFailedReSchedulingPending) || num == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.InterviewnotAppearedReSchedulingPending)))
                {
                    this.sSchedule.Style.Add("display", "");
                    this.aSchedule.InnerHtml = "Schedule For Interview";
                    this.aSchedule.Attributes.Add("Data-rel", "http://recruitment.axact.com/schedule/SchduleCandidate.aspx?" + SecureQueryString.QueryStringVar + "=" + this.sQString.encrypt("refno=" + this.ViewState["CurrentRefNo"].ToString() + "&pgno=1"));
                }
                else if (num == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.OfferGeneratedSchedulingPending) || num == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.OfferNotAcceptedReSchedulingPendingOffer) || num == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.OfferAcceptedJoiningNotDone))
                {
                    this.sSchedule.Style.Add("display", "");
                    this.aSchedule.InnerHtml = "Schedule For Offer";
                    this.aSchedule.Attributes.Add("Data-rel", "http://recruitment.axact.com/schedule/SchduleCandidate.aspx?" + SecureQueryString.QueryStringVar + "=" + this.sQString.encrypt("refno=" + this.ViewState["CurrentRefNo"].ToString() + "&pgno=1"));
                }
                else if (num == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.OfferAcceptedVerificationSchedulingPending))
                {
                    this.sSchedule.Style.Add("display", "");
                    this.aSchedule.InnerHtml = "Schedule For Verification";
                    this.aSchedule.Attributes.Add("Data-rel", "http://recruitment.axact.com/schedule/SchduleCandidate.aspx?" + SecureQueryString.QueryStringVar + "=" + this.sQString.encrypt("refno=" + this.ViewState["CurrentRefNo"].ToString() + "&pgno=1"));
                }
                else if (num == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.VerificationDoneAppointmentSchedulingPending))
                {
                    this.sSchedule.Style.Add("display", "");
                    this.aSchedule.InnerHtml = "Schedule For Appointment";
                    this.aSchedule.Attributes.Add("Data-rel", "http://recruitment.axact.com/schedule/SchduleCandidate.aspx?" + SecureQueryString.QueryStringVar + "=" + this.sQString.encrypt("refno=" + this.ViewState["CurrentRefNo"].ToString() + "&pgno=1"));
                }
                else
                {
                    this.sSchedule.Style.Add("display", "none");
                    this.aSchedule.InnerHtml = "";
                    this.aSchedule.HRef = "Javascript:;";
                }
                if (num >= (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.SchedulingDoneInterviewPending))
                {
                    if (str3 != "False" && str2 != "0")
                    {
                        this.DivStaffAction.Visible = true;
                        this.aMarkStaffTest.Attributes.Add("href", "http://recruitment.axact.com/A2/SupportStaff/Assessment.aspx?" + SecureQueryString.QueryStringVar + "=" + this.sQString.encrypt("TC=" + str2 + "&CC=" + this.CandidateCode));
                    }
                    else
                        this.DivStaffAction.Visible = false;
                }
            }
            else
                this.ViewState["CurrentStatusCode"] = (object)"0";
            if (this.CandidateDS.Tables.Count >= 2)
            {
                if (this.CandidateDS.Tables[1].Rows.Count > 0)
                {
                    this.rptExperience.DataSource = (object)this.CandidateDS.Tables[1];
                    this.rptExperience.DataBind();
                    this.lblinfoExp.Visible = false;
                }
                else
                {
                    this.lblinfoExp.Visible = true;
                    this.rptExperience.DataSource = (object)null;
                    this.rptExperience.DataBind();
                }
            }
            if (this.CandidateDS.Tables.Count >= 3)
            {
                DataView dataView1 = new DataView(this.CandidateDS.Tables[2]);
                dataView1.RowFilter = "Program_Code <> 7 and Program_Code <> 6";
                if (dataView1.Count > 0)
                {
                    this.lblinfoEdu.Visible = false;
                    this.rptEducation.DataSource = (object)dataView1;
                    this.rptEducation.DataBind();
                }
                else
                {
                    this.lblinfoEdu.Visible = true;
                    this.rptEducation.DataSource = (object)null;
                    this.rptEducation.DataBind();
                }
                DataView dataView2 = new DataView(this.CandidateDS.Tables[2]);
                dataView2.RowFilter = "Program_Code =6";
                if (dataView2.Count > 0)
                {
                    this.lblinfoDiploma.Visible = false;
                    this.rptDiploma.DataSource = (object)dataView2;
                    this.rptDiploma.DataBind();
                }
                else
                {
                    this.lblinfoDiploma.Visible = true;
                    this.rptDiploma.DataSource = (object)null;
                    this.rptDiploma.DataBind();
                }
                DataView dataView3 = new DataView(this.CandidateDS.Tables[2]);
                dataView3.RowFilter = "Program_Code =7";
                if (dataView3.Count > 0)
                {
                    this.lblinfoCertificate.Visible = false;
                    this.rptCertificate.DataSource = (object)dataView3;
                    this.rptCertificate.DataBind();
                }
                else
                {
                    this.lblinfoCertificate.Visible = true;
                    this.rptCertificate.DataSource = (object)null;
                    this.rptCertificate.DataBind();
                }
            }
            if (this.CandidateDS.Tables.Count >= 7)
            {
                if (this.CandidateDS.Tables[6].Rows.Count > 0)
                {
                    this.lblinfoFamily.Visible = false;
                    this.rptFamily.DataSource = (object)this.CandidateDS.Tables[6];
                    this.rptFamily.DataBind();
                }
                else
                {
                    this.lblinfoFamily.Visible = true;
                    this.rptFamily.DataSource = (object)null;
                    this.rptFamily.DataBind();
                }
            }
            if (this.CandidateDS.Tables.Count >= 20)
            {
                if (this.CandidateDS.Tables[19].Rows.Count > 0)
                {
                    this.rptPortfolioFiles.DataSource = (object)this.CandidateDS.Tables[19];
                    this.rptPortfolioFiles.DataBind();
                    this.lblPortFiles.Visible = false;
                }
                else
                {
                    this.rptPortfolioFiles.DataSource = (object)null;
                    this.rptPortfolioFiles.DataBind();
                    this.lblPortFiles.Visible = true;
                }
            }
            if (this.CandidateDS.Tables.Count >= 21)
            {
                if (this.CandidateDS.Tables[20].Rows.Count > 0)
                {
                    this.rptPortfolioUrl.DataSource = (object)this.CandidateDS.Tables[20];
                    this.rptPortfolioUrl.DataBind();
                    this.lblPortURL.Visible = false;
                }
                else
                {
                    this.lblPortURL.Visible = true;
                    this.rptPortfolioUrl.DataSource = (object)null;
                    this.rptPortfolioUrl.DataBind();
                }
            }
            if (this.CandidateDS.Tables.Count >= 5)
            {
                DataView dataView1 = new DataView(this.CandidateDS.Tables[4]);
                dataView1.RowFilter = "DocType_Code = 9";
                dataView1.Sort = "CandidateDocumentName,document_name ASC";
                if (dataView1.Count > 0)
                {
                    this.rptDocsExperience.DataSource = (object)dataView1;
                    this.rptDocsExperience.DataBind();
                    this.lblDocProfessional.Visible = false;
                }
                else
                {
                    this.lblDocProfessional.Visible = true;
                    this.rptDocsExperience.DataSource = (object)null;
                    this.rptDocsExperience.DataBind();
                }
                DataView dataView2 = new DataView(this.CandidateDS.Tables[4]);
                dataView2.RowFilter = "DocType_Code =1";
                if (dataView2.Count > 0)
                {
                    this.rptDocPersonal.DataSource = (object)dataView2;
                    this.rptDocPersonal.DataBind();
                    this.lblDocPersonal.Visible = false;
                }
                else
                {
                    this.lblDocPersonal.Visible = true;
                    this.rptDocPersonal.DataSource = (object)null;
                    this.rptDocPersonal.DataBind();
                }
                DataView dataView3 = new DataView(this.CandidateDS.Tables[4]);
                dataView3.RowFilter = "DocType_Code <> 9 and DocType_Code <> 1 and DocType_Code <> 7 and DocType_Code <> 8 and DocType_Code <> 13";
                dataView3.Sort = "CandidateDocumentName,document_name ASC";
                if (dataView3.Count > 0)
                {
                    this.rptDocsEducation.DataSource = (object)dataView3;
                    this.rptDocsEducation.DataBind();
                    this.lbldocEducation.Visible = false;
                }
                else
                {
                    this.lbldocEducation.Visible = true;
                    this.rptDocsEducation.DataSource = (object)null;
                    this.rptDocsEducation.DataBind();
                }
                DataView dataView4 = new DataView(this.CandidateDS.Tables[4]);
                dataView4.RowFilter = "DocType_Code =8 ";
                dataView4.Sort = "CandidateDocumentName ASC";
                if (dataView4.Count > 0)
                {
                    this.rptDocCertificate.DataSource = (object)dataView4;
                    this.rptDocCertificate.DataBind();
                    this.lbldocCertificate.Visible = false;
                }
                else
                {
                    this.lbldocCertificate.Visible = true;
                    this.rptDocCertificate.DataSource = (object)null;
                    this.rptDocCertificate.DataBind();
                }
                DataView dataView5 = new DataView(this.CandidateDS.Tables[4]);
                dataView5.RowFilter = "DocType_Code =7 ";
                dataView5.Sort = "CandidateDocumentName ASC";
                if (dataView5.Count > 0)
                {
                    this.rptDocDiploma.DataSource = (object)dataView5;
                    this.rptDocDiploma.DataBind();
                    this.lblDocDiploma.Visible = false;
                }
                else
                {
                    this.lblDocDiploma.Visible = true;
                    this.rptDocDiploma.DataSource = (object)null;
                    this.rptDocDiploma.DataBind();
                }
                DataView dataView6 = new DataView(this.CandidateDS.Tables[4]);
                dataView6.RowFilter = "DocType_Code =13 ";
                if (dataView6.Count > 0)
                {
                    this.rptHiredDocs.DataSource = (object)dataView6;
                    this.rptHiredDocs.DataBind();
                    this.lblHiredError.Visible = false;
                }
                else
                {
                    this.lblHiredError.Visible = true;
                    this.rptHiredDocs.DataSource = (object)null;
                    this.rptHiredDocs.DataBind();
                }
            }
            if (this.CandidateDS.Tables.Count >= 17)
            {
                if (this.CandidateDS.Tables[16].Rows.Count > 0)
                {
                    this.rptScheduleHistory.DataSource = (object)this.CandidateDS.Tables[16];
                    this.rptScheduleHistory.DataBind();
                    this.rptScheduleHistory.Visible = true;
                    this.trempty.Visible = false;
                }
                else
                {
                    this.rptScheduleHistory.DataSource = (object)null;
                    this.rptScheduleHistory.Visible = false;
                    this.trempty.Visible = true;
                }
            }
            if (this.CandidateDS.Tables.Count >= 8)
            {
                if (this.CandidateDS.Tables[9] != null && this.CandidateDS.Tables[9].Rows.Count > 0)
                {
                    this.ddlGrade.DataSource = (object)this.CandidateDS.Tables[9];
                    this.ddlGrade.DataTextField = "Grade_Name";
                    this.ddlGrade.DataValueField = "Grade_Code";
                    this.ddlGrade.DataBind();
                    this.ddlgradeC.DataSource = (object)this.CandidateDS.Tables[9];
                    this.ddlgradeC.DataTextField = "Grade_Name";
                    this.ddlgradeC.DataValueField = "Grade_Code";
                    this.ddlgradeC.DataBind();
                    if (this.CandidateDS.Tables[5].Rows[0]["Grade_Name"].ToString() != "-")
                    {
                        if (this.ddlgradeC.SelectedIndex >= 0)
                            this.ddlgradeC.Items[this.ddlgradeC.SelectedIndex].Selected = false;
                        if (this.CandidateDS.Tables[5].Rows[0]["Grade_Name"] != null && this.ddlgradeC.Items.FindByText(this.CandidateDS.Tables[5].Rows[0]["Grade_Name"].ToString()) != null)
                            this.ddlgradeC.Items.FindByText(this.CandidateDS.Tables[5].Rows[0]["Grade_Name"].ToString()).Selected = true;
                    }
                }
                this.ddlGrade.Items.Insert(0, new ListItem("--Grade--", "-1"));
                this.ddlgradeC.Items.Insert(0, new ListItem("--Grade--", "-1"));
                if (this.CandidateDS.Tables[10] != null && this.CandidateDS.Tables[10].Rows.Count > 0)
                {
                    this.ddlDesignation.DataSource = (object)this.CandidateDS.Tables[10];
                    this.ddlDesignation.DataTextField = "Designation_Name";
                    this.ddlDesignation.DataValueField = "Designation_Code";
                    this.ddlDesignation.DataBind();
                    this.ddlDesignationC.DataSource = (object)this.CandidateDS.Tables[10];
                    this.ddlDesignationC.DataTextField = "Designation_Name";
                    this.ddlDesignationC.DataValueField = "Designation_Code";
                    this.ddlDesignationC.DataBind();
                    if (this.CandidateDS.Tables[5].Rows[0]["Designation_Name"].ToString() != "-")
                    {
                        if (this.ddlDesignationC.SelectedIndex >= 0)
                            this.ddlDesignationC.Items[this.ddlDesignationC.SelectedIndex].Selected = false;
                        if (this.ddlDesignationC.Items.FindByText(this.CandidateDS.Tables[5].Rows[0]["Designation_Name"].ToString()) != null)
                            this.ddlDesignationC.Items.FindByText(this.CandidateDS.Tables[5].Rows[0]["Designation_Name"].ToString()).Selected = true;
                    }
                }
                this.ddlDesignation.Items.Insert(0, new ListItem("--Designation--", "-1"));
                this.ddlDesignationC.Items.Insert(0, new ListItem("--Designation--", "-1"));
            }
            if (this.CandidateDS.Tables.Count >= 15 && this.CandidateDS.Tables[14] != null && this.CandidateDS.Tables[14].Rows.Count > 0)
            {
                this.ddlRA.DataSource = (object)this.CandidateDS.Tables[14];
                this.ddlRA.DataTextField = "RA_Name";
                this.ddlRA.DataValueField = "RA_Code";
                this.ddlRA.DataBind();
            }
            if (this.CandidateDS.Tables[23] != null && this.CandidateDS.Tables[23].Rows.Count > 0)
            {
                this.ddlTL.DataSource = (object)this.CandidateDS.Tables[23];
                this.ddlTL.DataTextField = "TL_Name";
                this.ddlTL.DataValueField = "TL_Code";
                this.ddlTL.DataBind();
                this.ddlTL1.DataSource = (object)this.CandidateDS.Tables[23];
                this.ddlTL1.DataTextField = "TL_Name";
                this.ddlTL1.DataValueField = "TL_Code";
                this.ddlTL1.DataBind();
            }
            if (this.CandidateDS.Tables[22] != null && this.CandidateDS.Tables[22].Rows.Count > 0)
            {
                this.ddlGL.DataSource = (object)this.CandidateDS.Tables[22];
                this.ddlGL.DataTextField = "GL_Name";
                this.ddlGL.DataValueField = "GL_Code";
                this.ddlGL.DataBind();
            }
            if (this.CandidateDS.Tables[24] != null && this.CandidateDS.Tables[24].Rows.Count > 0)
            {
                this.ddlAssignUser.DataSource = (object)this.CandidateDS.Tables[24];
                this.ddlAssignUser.DataTextField = "AssignUser_Name";
                this.ddlAssignUser.DataValueField = "AssignUser_Code";
                this.ddlAssignUser.DataBind();
            }
            this.ddlRA.Items.Insert(0, new ListItem("--Reporting Authority--", "-1"));
            this.ddlTL.Items.Insert(0, new ListItem("--Team Leader--", "-1"));
            this.ddlTL1.Items.Insert(0, new ListItem("--Team Leader--", "-1"));
            this.ddlGL.Items.Insert(0, new ListItem("--Group Leader--", "-1"));
            this.ddlAssignUser.Items.Insert(0, new ListItem("--Assign User--", "-1"));
            ListItem byValue = this.ddlTL.Items.FindByValue(this.CandidateDS.Tables[5].Rows[0]["TeamLeaderCode"].ToString());
            if (byValue != null)
                this.ddlTL.SelectedValue = byValue.Value;
            if (this.CandidateDS.Tables.Count >= 13)
            {
                if (this.CandidateDS.Tables[12].Rows.Count > 0)
                {
                    this.rptQuestionGroup.DataSource = (object)this.CandidateDS.Tables[12];
                    this.rptQuestionGroup.DataBind();
                    this.alnkChktest.Attributes.Add("href", "http://recruitment.axact.com/assessment/checktest.aspx?cid=" + this.CandidateCode);
                    this.tblTest.Style.Add("display", "");
                    this.lblMsgTest.Visible = false;
                    this.tblTestmsg.Style.Add("display", "none");
                }
                else
                {
                    this.alnkChktest.Style.Add("display", "none");
                    this.lblMsgTest.Visible = true;
                    this.lblMsgTest.Text = "No record(s) found";
                    this.rptQuestionGroup.DataSource = (object)null;
                    this.rptQuestionGroup.DataBind();
                    this.tblTest.Style.Add("display", "none");
                    this.tblTestmsg.Style.Add("display", "");
                }
            }
            if (this.CandidateDS.Tables.Count >= 4)
            {
                if (this.CandidateDS.Tables[3].Rows.Count > 0)
                {
                    this.lblSkill.Visible = false;
                    this.rptSkills.DataSource = (object)this.CandidateDS.Tables[3];
                    this.rptSkills.DataBind();
                }
                else
                {
                    this.lblSkill.Visible = true;
                    this.rptSkills.DataSource = (object)null;
                    this.rptSkills.DataBind();
                }
            }
            if (this.CandidateDS.Tables.Count > 9)
            {
                if (this.CandidateDS.Tables[8] != null && this.CandidateDS.Tables[8].Rows.Count > 0)
                {
                    this.lblMsgCommu.Visible = false;
                    this.rptCommunication.DataSource = (object)this.CandidateDS.Tables[8];
                    this.rptCommunication.DataBind();
                }
                else
                {
                    this.lblMsgCommu.Visible = true;
                    this.rptCommunication.DataSource = (object)null;
                    this.rptCommunication.DataBind();
                }
            }
            if (this.CandidateDS.Tables[17].Rows.Count > 0)
            {
                this.rptOfficialDocuments.DataSource = (object)this.CandidateDS.Tables[17];
                this.rptOfficialDocuments.DataBind();
                DataView dataView = new DataView(this.CandidateDS.Tables[17]);
                dataView.RowFilter = "document_code=26 or CandidateDocumentName='Offer Letter Audio'";
                if (dataView != null && dataView.Count > 0)
                {
                    this.hdnDocName.Value = dataView[0].Row["CandidateDocumentName"].ToString();
                    this.hdnCanDocCode.Value = dataView[0].Row["CandDocCode"].ToString();
                    this.hdnDocumentCode.Value = dataView[0].Row["Document_Code"].ToString();
                }
            }
            if (this.CandidateDS.Tables.Count >= 19)
            {
                if (this.CandidateDS.Tables[18] != null && this.CandidateDS.Tables[18].Rows.Count > 0)
                {
                    this.rptOffer.DataSource = (object)this.CandidateDS.Tables[18];
                    this.rptOffer.DataBind();
                    this.lblOffer.Text = "";
                }
                else
                {
                    this.lblOffer.Text = "No record(s) found";
                    this.rptOffer.DataSource = (object)null;
                    this.rptOffer.DataBind();
                }
            }
            if (this.CandidateDS.Tables.Count >= 22 && this.CandidateDS.Tables[21] != null && (this.CandidateDS.Tables[21].Rows.Count > 0 && this.CandidateDS.Tables[21].Rows[0]["isPortalRequest"].ToString() == "True"))
                this.divAction109.Style.Add("display", "none");
            if (str1 == "1" || str3 == "True")
            {
                this.imgStaff.Visible = true;
                this.trAssignUsers.Style["display"] = "";
            }
            else
            {
                this.imgStaff.Visible = false;
                this.trAssignUsers.Style["display"] = "none";
            }
            if (this.CandidateDS.Tables.Count >= 26 && this.CandidateDS.Tables[25].Rows.Count > 0)
            {
                this.ddlJD.DataSource = (object)this.CandidateDS.Tables[25];
                this.ddlJD.DataTextField = "JDName";
                this.ddlJD.DataValueField = "ID";
                this.ddlJD.DataBind();
            }
            this.ddlJD.Items.Insert(0, new ListItem("--Team--", "-1"));
            if (this.CandidateDS.Tables.Count >= 27 && this.CandidateDS.Tables[26].Rows.Count > 0)
            {
                this.ddlBU.DataSource = (object)this.CandidateDS.Tables[26];
                this.ddlBU.DataTextField = "BU_Name";
                this.ddlBU.DataValueField = "BU_Code";
                this.ddlBU.DataBind();
            }
            this.ddlBU.Items.Insert(0, new ListItem("--BU--", "-1"));
            if (this.CandidateDS.Tables.Count >= 28 && this.CandidateDS.Tables[27].Rows.Count > 0)
            {
                if (this.CandidateDS.Tables[27].Rows[0]["IsNICVerified"].ToString() == "false")
                {
                    this.lnkCreatePortal.Visible = false;
                    this.lblNicverified.Visible = true;
                }
                else
                {
                    this.lnkCreatePortal.Visible = true;
                    this.lblNicverified.Visible = false;
                }
            }
            if (this.CandidateDS.Tables.Count >= 29 && this.CandidateDS.Tables[28].Rows.Count > 0)
            {
                this.ddlLeagueType.DataSource = (object)this.CandidateDS.Tables[28];
                this.ddlLeagueType.DataTextField = "League_Description";
                this.ddlLeagueType.DataValueField = "League_code";
                this.ddlLeagueType.DataBind();
            }
            this.CheckDivs();
            this.GetCandidateHistory();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    public void GetCandidateHistory()
    {
        if (string.IsNullOrEmpty(this.CandidateCode))
            return;
        SqlCommand selectCommand = new SqlCommand("Xrec_Select_Candidatehistory", this.connection);
        selectCommand.Parameters.AddWithValue("@CandidateCode", (object)this.CandidateCode);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables.Count == 0)
            return;
        if (dataSet.Tables.Count >= 2)
        {
            if (dataSet.Tables[1].Rows.Count > 0)
            {
                this.tblExpHistory.Visible = true;
                this.rptCandidateExHistory.DataSource = (object)dataSet.Tables[1];
                this.rptCandidateExHistory.DataBind();
            }
            else
            {
                this.tblExpHistory.Visible = false;
                this.rptCandidateExHistory.DataSource = (object)null;
                this.rptCandidateExHistory.Visible = false;
            }
        }
        if (dataSet.Tables.Count < 3)
            return;
        if (dataSet.Tables[2].Rows.Count > 0)
        {
            this.trQaHistory.Visible = true;
            this.rptQaHistory.DataSource = (object)dataSet.Tables[2];
            this.rptQaHistory.DataBind();
        }
        else
        {
            this.trQaHistory.Visible = false;
            this.rptQaHistory.DataSource = (object)null;
            this.rptQaHistory.Visible = false;
        }
    }

    public void FileResponses(string filename, string FolderPath)
    {
        FileInfo fileInfo = new FileInfo(HttpContext.Current.Server.MapPath(FolderPath + "/" + filename));
        if (!fileInfo.Exists)
            return;
        BinaryReader binaryReader = new BinaryReader((Stream)fileInfo.OpenRead());
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
        HttpContext.Current.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
        HttpContext.Current.Response.ContentType = "application/octet-stream";
        byte[] buffer = binaryReader.ReadBytes((int)fileInfo.Length);
        binaryReader.Close();
        HttpContext.Current.Response.BinaryWrite(buffer);
    }

    private void InsertUserOfferAcceptedComments(bool check)
    {
        try
        {
            SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateInterview", this.connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = (object)Convert.ToInt32(this.CandidateCode);
            sqlCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = (object)this.UserCode;
            sqlCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = (object)this.txtaOfferAccepetance.InnerText;
            sqlCommand.Parameters.Add("@LifeCycleStatus", SqlDbType.Int).Value = (object)Convert.ToInt32((object)Constants.CandidateLifeCycleStatus.OfferDeliveredAcceptancePending);
            if (this.ddlGrade.SelectedValue != "-1")
                sqlCommand.Parameters.Add("@GradeCode", SqlDbType.Int).Value = (object)this.ddlGrade.SelectedValue;
            sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = (object)this.UserCode;
            sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = (object)this.USERIP;
            if (this.connection.State != ConnectionState.Open)
                this.connection.Open();
            sqlCommand.ExecuteNonQuery();
            if (check)
                this.InsertExpectedDateOfJoining();
            if (this.connection.State == ConnectionState.Closed)
                return;
            this.connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    public void InsertDocumentToGeneratePDF(string DocumentName, int offerLetterCode)
    {
        try
        {
            SqlCommand sqlCommand = new SqlCommand("dbo.Insert_CandidateOfficialDocumentForMarkingPDF", this.connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = (object)Convert.ToInt32(this.CandidateCode);
            sqlCommand.Parameters.Add("@CandidateDocumentName", SqlDbType.VarChar).Value = (object)DocumentName;
            sqlCommand.Parameters.Add("@OfficialLetter_Code", SqlDbType.Int).Value = (object)offerLetterCode;
            if (!string.IsNullOrEmpty(this.ddlLeagueType.SelectedValue))
                sqlCommand.Parameters.Add("@OfferLeagueType", SqlDbType.Int).Value = (object)Convert.ToInt32(this.ddlLeagueType.SelectedValue);
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    private void InsertExpectedDateOfJoining()
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateDateOfJoining", this.connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = (object)Convert.ToInt32(this.CandidateCode);
        sqlCommand.Parameters.Add("@JoiningDate", SqlDbType.DateTime).Value = (object)Convert.ToDateTime(this.txtExpectedDOJ.Value);
        sqlCommand.Parameters.Add("@RACode", SqlDbType.Int).Value = (object)this.ddlRA.SelectedValue;
        sqlCommand.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = (object)this.UserCode;
        sqlCommand.Parameters.Add("@UpdatedIP", SqlDbType.VarChar).Value = (object)this.USERIP;
        sqlCommand.Parameters.Add("@GLCode", SqlDbType.Int).Value = (object)this.ddlGL.SelectedValue;
        sqlCommand.Parameters.Add("@TentativeShift_Code", SqlDbType.Int).Value = (object)this.ddlTentativeShift.SelectedValue;
        sqlCommand.Parameters.Add("@TeamLeaderCode", SqlDbType.Int).Value = (object)this.ddlTL1.SelectedValue;
        sqlCommand.ExecuteNonQuery();
    }

    private void InsertUserOfferDeliveredComments()
    {
        try
        {
            if (this.connection.State != ConnectionState.Open)
                this.connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateInterview", this.connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = (object)Convert.ToInt32(this.CandidateCode);
            sqlCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = (object)this.UserCode;
            sqlCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = (object)this.txtaOfferdelivered.InnerText;
            sqlCommand.Parameters.Add("@LifeCycleStatus", SqlDbType.Int).Value = (object)Convert.ToInt32((object)Constants.CandidateLifeCycleStatus.OfferSchedulingDoneOfferPending);
            if (this.ddlGrade.SelectedValue != "-1")
                sqlCommand.Parameters.Add("@GradeCode", SqlDbType.Int).Value = (object)this.ddlGrade.SelectedValue;
            sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = (object)this.UserCode;
            sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = (object)this.USERIP;
            sqlCommand.ExecuteNonQuery();
            if (this.connection.State == ConnectionState.Closed)
                return;
            this.connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    private void UpdateCandidateInformation(string FilePath)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("dbo.XRec_InsertCandidateOfferAudioPath", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", (object)this.CandidateCode));
                sqlCommand.Parameters.Add(new SqlParameter("@AudioPath", (object)FilePath));
                sqlCommand.Parameters.Add(new SqlParameter("@UpdatedBy", (object)this.UserCode));
                sqlCommand.Parameters.Add(new SqlParameter("@UpdatedIP", (object)this.USERIP));
                sqlCommand.ExecuteNonQuery();
            }
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
    }

    private void ShortlistCandidate()
    {
        try
        {
            if (this.connection.State != ConnectionState.Open)
                this.connection.Open();
            SqlCommand selectCommand = new SqlCommand("dbo.[XRec_UpdateSelectedCandidateLockBitNew]", this.connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.Add("@CandidateCode", SqlDbType.VarChar).Value = (object)this.CandidateCode;
            selectCommand.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = (object)this.UserCode;
            selectCommand.Parameters.Add("@UpdationIP", SqlDbType.VarChar).Value = (object)this.USERIP;
            DataSet dataSet = new DataSet();
            new SqlDataAdapter(selectCommand).Fill(dataSet);
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
            if (dataSet == null || dataSet.Tables == null || string.IsNullOrEmpty(dataSet.Tables[0].Rows[0]["IsTest"].ToString()))
                return;
            if (dataSet.Tables[0].Rows[0]["IsTest"].ToString().ToLower() == "true")
            {
                StatusManagement.MarkLifeCycleStatus(this.connection, int.Parse(this.CandidateCode), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.ShortlistedSchedulingPendingTest, this.USERIP, this.UserCode);
            }
            else
            {
                if (!(dataSet.Tables[0].Rows[0]["IsTest"].ToString().ToLower() == "false"))
                    return;
                StatusManagement.MarkLifeCycleStatus(this.connection, int.Parse(this.CandidateCode), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.NoTestSchedulingPendingInterview, this.USERIP, this.UserCode);
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    private void CheckDivs()
    {
        this.tblInterview.Style.Add("display", "none");
        this.tblOfferGenerationPending.Style.Add("display", "none");
        this.tblOfferGeneration.Style.Add("display", "none");
        this.tblOfferDelivered.Style.Add("display", "none");
        this.tblOfferAcceptance.Style.Add("display", "none");
        if ((int)Convert.ToInt16(this.ViewState["CurrentStatusCode"].ToString()) == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.SchedulingDoneInterviewPending))
        {
            this.tblInterview.Style.Add("display", "");
            this.tblOfferGenerationPending.Style.Add("display", "none");
            this.tblOfferGeneration.Style.Add("display", "none");
            this.tblOfferDelivered.Style.Add("display", "none");
            this.tblOfferAcceptance.Style.Add("display", "none");
        }
        else if ((int)Convert.ToInt16(this.ViewState["CurrentStatusCode"].ToString()) == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.InterviewPassedOfferGenerationPending))
        {
            this.tblInterview.Style.Add("display", "none");
            this.tblOfferGenerationPending.Style.Add("display", "");
            this.tblOfferDelivered.Style.Add("display", "none");
            this.tblOfferAcceptance.Style.Add("display", "none");
            this.AReserve.HRef = "../schedule/SchduleCandidate.aspx?" + SecureQueryString.QueryStringVar + "=" + this.sQString.encrypt("refno=" + this.ViewState["CurrentRefNo"].ToString() + "pgno=1");
            this.trOfferGenerationReserved.Style.Add("display", "none");
        }
        else if ((int)Convert.ToInt16(this.ViewState["CurrentStatusCode"].ToString()) == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.OfferSchedulingDoneOfferPending))
        {
            this.tblInterview.Style.Add("display", "none");
            this.tblOfferGenerationPending.Style.Add("display", "none");
            this.tblOfferGeneration.Style.Add("display", "none");
            this.tblOfferDelivered.Style.Add("display", "");
            this.tblOfferAcceptance.Style.Add("display", "none");
        }
        else if ((int)Convert.ToInt16(this.ViewState["CurrentStatusCode"].ToString()) == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.OfferDeliveredAcceptancePending))
        {
            this.tblInterview.Style.Add("display", "none");
            this.tblOfferGenerationPending.Style.Add("display", "none");
            this.tblOfferGeneration.Style.Add("display", "none");
            this.tblOfferDelivered.Style.Add("display", "none");
            this.tblOfferAcceptance.Style.Add("display", "");
            this.txtExpectedDOJ.Value = DateTime.Now.ToString("MMM dd, yyyy");
        }
        else if ((int)Convert.ToInt16(this.ViewState["CurrentStatusCode"].ToString()) == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.VerificationDoneAppointmentSchedulingPending))
        {
            this.tblInterview.Style.Add("display", "none");
            this.tblOfferGenerationPending.Style.Add("display", "none");
            this.tblOfferGeneration.Style.Add("display", "none");
            this.tblOfferDelivered.Style.Add("display", "none");
            this.tblOfferAcceptance.Style.Add("display", "none");
            this.tblAppointmentGeneration.Visible = true;
        }
        else if ((int)Convert.ToInt16(this.ViewState["CurrentStatusCode"].ToString()) == (int)Convert.ToInt16((object)Constants.CandidateLifeCycleStatus.AppointmentSchedulingDoneJoiningReportingPending))
        {
            this.tblInterview.Style.Add("display", "none");
            this.tblOfferGenerationPending.Style.Add("display", "none");
            this.tblOfferGeneration.Style.Add("display", "none");
            this.tblOfferDelivered.Style.Add("display", "none");
            this.tblOfferAcceptance.Style.Add("display", "none");
            this.tblAppointmentGeneration.Style.Add("display", "none");
            this.tblPortalActivation.Visible = true;
            SqlCommand selectCommand = new SqlCommand("dbo.Xrec_SelectCandidateOptionsForPortal", this.connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet == null)
                return;
            this.ddlshift.DataSource = (object)dataSet.Tables[0];
            this.ddlshift.DataTextField = "Shift_Name";
            this.ddlshift.DataValueField = "Shift_Code";
            this.ddlshift.DataBind();
            this.ddlshift.Items.Insert(0, new ListItem("--Select Shift--", "-1"));
            this.chkjobrole.DataSource = (object)dataSet.Tables[1];
            this.chkjobrole.DataTextField = "JobRole_Name";
            this.chkjobrole.DataValueField = "JobRole_ID";
            this.chkjobrole.DataBind();
            this.ddlCity.DataSource = (object)dataSet.Tables[2];
            this.ddlCity.DataTextField = "City";
            this.ddlCity.DataValueField = "Location_ID";
            this.ddlCity.DataBind();
            this.ddlCity.Items.Insert(0, new ListItem("--Select Location--", "-1"));
        }
        else
            this.div1.Style.Add("display", "none");
    }

    private void InsertUserInterviewComments()
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateInterview", this.connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = (object)Convert.ToInt32(this.CandidateCode);
        sqlCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = (object)this.UserCode;
        sqlCommand.Parameters.Add("@IsPassOrFail", SqlDbType.Bit).Value = (object)this.rdbPass.Checked;
        sqlCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = (object)this.txtaComments.InnerText;
        if (this.ddlGrade.SelectedValue != "-1" && this.ddlDesignation.SelectedValue != "-1")
            sqlCommand.Parameters.Add("@LifeCycleStatus", SqlDbType.Int).Value = (object)Convert.ToInt32((object)Constants.CandidateLifeCycleStatus.InterviewDoneOfferGenerated);
        else
            sqlCommand.Parameters.Add("@LifeCycleStatus", SqlDbType.Int).Value = (object)Convert.ToInt32((object)Constants.CandidateLifeCycleStatus.SchedulingDoneInterviewPending);
        if (this.ddlGrade.SelectedValue != "-1")
            sqlCommand.Parameters.Add("@GradeCode", SqlDbType.Int).Value = (object)this.ddlGrade.SelectedValue;
        if (this.ddlDesignation.SelectedValue != "-1")
            sqlCommand.Parameters.Add("@DesignationCode", SqlDbType.Int).Value = (object)this.ddlDesignation.SelectedValue;
        sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = (object)this.UserCode;
        sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = (object)this.USERIP;
        sqlCommand.ExecuteNonQuery();
    }

    private void InsertUserCommunicationComments(string comments, string CommentType)
    {
        try
        {
            SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_UserCommunicationComments", this.connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = (object)Convert.ToInt32(this.CandidateCode);
            sqlCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = (object)this.UserCode;
            sqlCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = (object)comments;
            sqlCommand.Parameters.Add("@LifeCycleStatus", SqlDbType.Int).Value = (object)0;
            sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = (object)this.UserCode;
            sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = (object)this.USERIP;
            sqlCommand.Parameters.Add("@CommentType", SqlDbType.VarChar).Value = (object)CommentType;
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, this.UserCode.ToString());
        }
        finally
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }
    }

    private void InsertUserInterviewCommentsOfferApproval()
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateInterviewOfferDetail", this.connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = (object)Convert.ToInt32(this.CandidateCode);
        sqlCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = (object)this.UserCode;
        sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = (object)this.UserCode;
        sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = (object)this.USERIP;
        sqlCommand.Parameters.Add("@Demanded_Salary", SqlDbType.Decimal).Value = (object)Convert.ToDecimal(this.txtDSalary.Text);
        sqlCommand.Parameters.Add("@BankStatement_Status", SqlDbType.VarChar).Value = (object)this.ddlStatement.SelectedItem.Text;
        sqlCommand.Parameters.Add("@Profile", SqlDbType.Int).Value = (object)this.ddlProfile.SelectedValue;
        if (this.ddlJD.SelectedValue != "-1")
            sqlCommand.Parameters.Add("@TeamCode", SqlDbType.Int).Value = (object)Convert.ToInt32(this.ddlJD.SelectedValue);
        if (this.ddlBU.SelectedValue != "-1")
            sqlCommand.Parameters.Add("@BUCode", SqlDbType.Int).Value = (object)Convert.ToInt32(this.ddlBU.SelectedValue);
        sqlCommand.ExecuteNonQuery();
    }

    public void ClearCandidateAvailedSlots()
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateSlotIsAvailed", this.connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = (object)this.CandidateCode;
        sqlCommand.ExecuteNonQuery();
    }

    private void InsertUserOfferGeneratedComments()
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateInterview", this.connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = (object)Convert.ToInt32(this.CandidateCode);
        sqlCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = (object)this.UserCode;
        sqlCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = (object)this.txtaOfferGenerationPending.InnerText;
        sqlCommand.Parameters.Add("@LifeCycleStatus", SqlDbType.Int).Value = (object)Convert.ToInt32((object)Constants.CandidateLifeCycleStatus.InterviewPassedOfferGenerationPending);
        if (this.ddlGrade.SelectedValue != "-1")
            sqlCommand.Parameters.Add("@GradeCode", SqlDbType.Int).Value = (object)this.ddlGrade.SelectedValue;
        sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = (object)this.UserCode;
        sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = (object)this.USERIP;
        sqlCommand.ExecuteNonQuery();
    }

    private void ShowHideActions()
    {
        IEnumerable<HtmlGenericControl> allControlsOfType = this.Page.GetAllControlsOfType<HtmlGenericControl>();
        foreach (DataRow row in (InternalDataCollectionBase)this.DTActions.Rows)
        {
            foreach (Control control in allControlsOfType)
            {
                if (control.ClientID == "divAction" + row["MenuLinkActionCode"].ToString())
                    control.Visible = true;
            }
        }
    }
}