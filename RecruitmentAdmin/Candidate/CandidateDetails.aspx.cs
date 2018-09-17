﻿using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using XRecruitmentStatusLibrary;
using ErrorLog;

public static class ResponseHelper
{
    public static void Redirect(this HttpResponse response, string url, string target, string windowFeatures)
    {
        if ((string.IsNullOrEmpty(target) || target.Equals("_self", StringComparison.OrdinalIgnoreCase)) && string.IsNullOrEmpty(windowFeatures))
        {
            response.Redirect(url);
        }
        else
        {
            Page handler = (Page)HttpContext.Current.Handler;
            if (handler == null)
                throw new InvalidOperationException("Cannot redirect to new window outside Page context.");
            url = handler.ResolveClientUrl(url);
            string script = string.Format(string.IsNullOrEmpty(windowFeatures) ? "window.open(\"{0}\", \"{1}\");" : "window.open(\"{0}\", \"{1}\", \"{2}\");", url, target, windowFeatures);
            ScriptManager.RegisterStartupScript(handler, typeof(Page), "Redirect", script, true);
        }
    }
}


public partial class Candidate_CandidateDetails : CustomBasePage//System.Web.UI.Page//
{
    #region Page Variables

    DataSet ds = new DataSet();
    public static string RefNo;
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    string DocumentFolderPath = System.Configuration.ConfigurationManager.AppSettings["DocumentFolderPath"].ToString();
    string PortfolioFolderPath = System.Configuration.ConfigurationManager.AppSettings["PortfolioFolderPath"].ToString();
    string candidateCode = "0";
    string supportFileName = string.Empty;
    string portfolioFileName = string.Empty;
    string CommCode = "0";
    static string IsTest = "true";
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;
    SecureQueryString sQString = new SecureQueryString();
    DataSet dsAction;

    public string divAddEditPersnalDetails = string.Empty;
    public string divAddEditProfessionalDetails = string.Empty;
    public string divAddEditEducationDetails = string.Empty;
    public string divAddEditSkill = string.Empty;
    public string divBrowseDocuments = string.Empty;
    public string divAddEditFamilyDetail = string.Empty;

    #endregion

    #region Event-Handlers

    //protected override void OnPreInit(EventArgs e)
    //{
    //    PreInit += new EventHandler(Page_PreInit);
    //    Load += new EventHandler(Page_Load);

    //    // And only then:
    //    base.OnPreInit(e);
    //}

    //protected void Page_PreInit(object sender, EventArgs e)
    //{
    //    GetActionUser();
    //}

    //public enum Action
    //{
    //    AddEditPersnalDetails = 5,
    //    AddEditProfessionalDetails = 6,
    //    AddEditEducationDetails = 7,
    //    AddEditSkill = 8,
    //    Browsedocuments = 9,
    //    AddEditFamilyDetail = 10,
    //}

    //public void GetActionUser()
    //{
    //    string URL = string.Empty;
    //    if (HttpContext.Current.Request.Url.AbsoluteUri.ToString().Contains('?'))
    //        URL = HttpContext.Current.Request.Url.AbsoluteUri.ToString().
    //             Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.ToString().IndexOf('?'));
    //    else
    //        URL = HttpContext.Current.Request.Url.AbsoluteUri.ToString();

    //    URL = "http://xwebsrv:60106/Candidate/CandidateDetails.aspx";

    //    SqlCommand sqlCommand = new SqlCommand("dbo.XRec_SelectUserActions", connection);
    //    sqlCommand.CommandType = CommandType.StoredProcedure;
    //    sqlCommand.Parameters.Add("@url", SqlDbType.VarChar).Value = URL;
    //    sqlCommand.Parameters.Add("@UserID", SqlDbType.Int).Value = UserCode;
    //    if (connection.State != ConnectionState.Open)
    //        connection.Open();

    //    dsAction = new DataSet();
    //    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
    //    adapter.Fill(dsAction);

    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            secQueryString = new SecureQueryString(QueryStringVar);
            if (!string.IsNullOrEmpty(secQueryString["CID"].ToString()))
            {
                string str = ConfigurationManager.AppSettings["WebDomainAddress"].ToString() + "AdminRedirector.aspx?";
                lnkAddEditProfessional.Attributes.Add("href", str + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("candidate_code=" + secQueryString["CID"].ToString() + "&url=Profile/Experience.aspx&utc=" + Convert.ToInt32(Constants.UserTypeCode.Admin) + "&auc=" + UserCode));
                lnkAddEditEducational.Attributes.Add("href", str + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("candidate_code=" + secQueryString["CID"].ToString() + "&url=Profile/Education.aspx&utc=" + Convert.ToInt32(Constants.UserTypeCode.Admin) + "&auc=" + UserCode));
                lnkAddEditPersonal.Attributes.Add("href", str + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("candidate_code=" + secQueryString["CID"].ToString() + "&url=Profile/PersonalDetails.aspx&utc=" + Convert.ToInt32(Constants.UserTypeCode.Admin) + "&auc=" + UserCode));
                lnkAddEditSkillSet.Attributes.Add("href", str + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("candidate_code=" + secQueryString["CID"].ToString() + "&url=Profile/Skillset.aspx&utc=" + Convert.ToInt32(Constants.UserTypeCode.Admin) + "&auc=" + UserCode));
                lnkAddEditDocuments.Attributes.Add("href", str + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("candidate_code=" + secQueryString["CID"].ToString() + "&url=Profile/uploadDocuments.aspx&utc=" + Convert.ToInt32(Constants.UserTypeCode.Admin) + "&auc=" + UserCode));
                lnkAddEditDiploma.Attributes.Add("href", str + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("candidate_code=" + secQueryString["CID"].ToString() + "&url=Profile/Diploma.aspx&utc=" + Convert.ToInt32(Constants.UserTypeCode.Admin) + "&auc=" + UserCode));
                lnkAddEditCertificate.Attributes.Add("href", str + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("candidate_code=" + secQueryString["CID"].ToString() + "&url=Profile/Certificate.aspx&utc=" + Convert.ToInt32(Constants.UserTypeCode.Admin) + "&auc=" + UserCode));
                lnkAddEditFamily.Attributes.Add("href", str + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("candidate_code=" + secQueryString["CID"].ToString() + "&url=Profile/Familydetails.aspx&utc=" + Convert.ToInt32(Constants.UserTypeCode.Admin) + "&auc=" + UserCode));
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        if (IsPostBack)
            return;
        try
        {
            CheckQueryString();
            connection.Open();
            GetCandidateDetail(ref connection);
            GetCandidateHistory();
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

    protected void lnkViewPortfolio_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(hdnpFileName.Value))
                return;
            FileResponses(Path.GetFileName(hdnpFileName.Value), ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + Convert.ToInt32(hdnCandidateCode.Value) + "/Personal/");
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

    protected void lnkSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtaComments.InnerText))
                return;
            InsertUserInterviewComments();
            InsertUserInterviewCommentsOfferApproval();
            if (rdbPass.Checked && ddlGrade.SelectedValue != "-1" && ddlDesignation.SelectedValue != "-1")
            {
                StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(hdnCandidateCode.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.InterviewDoneOfferGenerated, Request.UserHostAddress.ToString(), UserCode);
                ClearCandidateAvailedSlots();
            }
            else if (rdbFail.Checked)
            {
                StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(hdnCandidateCode.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.InterviewFailedReSchedulingPending, Request.UserHostAddress.ToString(), UserCode);
                ClearCandidateAvailedSlots();
            }
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Saved Successfully!');", true);
            GetCandidateDetail(ref connection);
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

    private void InsertUserInterviewCommentsOfferApproval()
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateInterviewOfferDetail", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(hdnCandidateCode.Value);
        sqlCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = UserCode;
        sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = UserCode;
        sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = Request.UserHostAddress.ToString();
        sqlCommand.Parameters.Add("@Demanded_Salary", SqlDbType.Decimal).Value = Convert.ToDecimal(txtDSalary.Text);
        sqlCommand.Parameters.Add("@BankStatement_Status", SqlDbType.Bit).Value = (ddlStatement.SelectedValue == "1");
        sqlCommand.Parameters.Add("@Profile", SqlDbType.Int).Value = ddlProfile.SelectedValue;
        if (connection.State != ConnectionState.Open)
            connection.Open();
        sqlCommand.ExecuteNonQuery();
        if (connection.State == ConnectionState.Closed)
            return;
        connection.Close();
    }

    protected void lnkMarkOfferDelivered_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtaOfferdelivered.InnerText))
                return;
            if (fuOffer.HasFile)
            {
                int num = 0;
                string lower = Path.GetExtension(fuOffer.FileName).ToLower();
                if (fuOffer.FileBytes.Length >= 10485760)
                    ++num;
                if (num > 0)
                {
                    lblMsgOffer.Text = "Maximum Size for the file upload is 10MB";
                }
                else
                {
                    string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + "Official/" + ViewState["CurrentRefNo"].ToString() + "/";
                    GeneralMethods.FileBrowse(fuOffer, FolderPath, "OfferLetterAudio");
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    UpdateCandidateInformation(FolderPath + "OfferLetterAudio" + lower);
                    InsertUserOfferDeliveredComments();
                }
            }
            StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(hdnCandidateCode.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.OfferDeliveredAcceptancePending, Request.UserHostAddress.ToString(), UserCode);
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Saved Successfully!');", true);
            GetCandidateDetail(ref connection);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            lblMsgOffer.Text = "file not Uploaded.";
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void lnkMarkOfferAccepted_Click(object sender, EventArgs e)
    {
        try
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            if (!string.IsNullOrEmpty(txtaOfferAccepetance.InnerText))
                InsertUserOfferAcceptedComments(true);
            StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(hdnCandidateCode.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.OfferAcceptedVerificationSchedulingPending, Request.UserHostAddress.ToString(), UserCode);
            ClearCandidateAvailedSlots();
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Saved Successfully!');", true);
            GetCandidateDetail(ref connection);
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

    protected void rptQuestionGroup_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string str1 = DataBinder.Eval(e.Item.DataItem, "QuestionGroupCode").ToString();
            string str2 = DataBinder.Eval(e.Item.DataItem, "SectionCode").ToString();
            Label control1 = (Label)e.Item.FindControl("lblCorrect");
            Label control2 = (Label)e.Item.FindControl("lblWrong");
            Label control3 = (Label)e.Item.FindControl("lblTotal");
            Label control4 = (Label)e.Item.FindControl("lblPending");
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
            if (ds.Tables[13].Rows.Count > 0)
            {
                int length1 = ds.Tables[13].Select("SectionCode=" + str2 + " and QuestionGroupCode=" + str1 + " and IsCorrect=1").Length;
                int length2 = ds.Tables[13].Select("SectionCode=" + str2 + " and QuestionGroupCode=" + str1 + " and IsCorrect=0").Length;
                int length3 = ds.Tables[13].Select("SectionCode=" + str2 + " and QuestionGroupCode=" + str1).Length;
                int length4 = ds.Tables[13].Select("SectionCode=" + str2 + " and QuestionGroupCode=" + str1 + " and IsCorrect is null").Length;
                control1.Text = length1.ToString();
                control2.Text = length2.ToString();
                control3.Text = length3.ToString();
                control4.Text = length4.ToString();
            }
        }
        if (e.Item.ItemType != ListItemType.Footer || ds.Tables[11].Rows.Count <= 0)
            return;
        Label control5 = (Label)e.Item.FindControl("lblCorrecttot");
        Label control6 = (Label)e.Item.FindControl("lblWrongtot");
        Label control7 = (Label)e.Item.FindControl("lblTotaltot");
        Label control8 = (Label)e.Item.FindControl("lblPendingtot");
        control5.Text = ds.Tables[11].Rows[0]["Correct"].ToString();
        control6.Text = ds.Tables[11].Rows[0]["Wrong"].ToString();
        control7.Text = ds.Tables[11].Rows[0]["TotalQuestion"].ToString();
        control8.Text = ds.Tables[11].Rows[0]["ResultPending"].ToString();
    }

    protected void lnkMarkOfferNotAccepted_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(txtaOfferAccepetance.InnerText))
                InsertUserOfferAcceptedComments(false);
            if (connection.State != ConnectionState.Open)
                connection.Open();
            StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(hdnCandidateCode.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.OfferNotAcceptedReSchedulingPendingOffer, Request.UserHostAddress.ToString(), UserCode);
            ClearCandidateAvailedSlots();
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Saved Successfully!');", true);
            GetCandidateDetail(ref connection);
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

    protected void rptPersonal_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                HtmlTableCell control = (HtmlTableCell)e.Item.FindControl("thPersonalAction");
                if ((int)Convert.ToInt16(ViewState["CurrentStatusCode"].ToString()) == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.VerificationSchedulingDoneVerficationPending))
                    control.Style.Add("display", "");
                else
                    control.Style.Add("display", "none");
            }
            if (e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.Item)
                return;
            HtmlTableCell control1 = (HtmlTableCell)e.Item.FindControl("tdPersonalAction");
            if ((int)Convert.ToInt16(ViewState["CurrentStatusCode"].ToString()) == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.VerificationSchedulingDoneVerficationPending))
                control1.Style.Add("display", "");
            else
                control1.Style.Add("display", "none");
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

    protected void rptPersonal_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "MarkDocVerified")
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateDocVerified", connection);
                sqlCommand.Parameters.Add("@CandDocCode", SqlDbType.Int).Value = Convert.ToInt32(e.CommandArgument.ToString());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                GetCandidateDetail(ref connection);
            }
            if (!(e.CommandName == "View"))
                return;
            ((ImageButton)e.Item.FindControl("Imgbtn")).PostBackUrl = "";
            GeneralMethods.FileResponse(Path.GetFileName(e.CommandArgument.ToString()), Path.GetDirectoryName(e.CommandArgument.ToString()));
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

    protected void rptEducational_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            try
            {
                HtmlTableCell control = (HtmlTableCell)e.Item.FindControl("thEduAction");
                if ((int)Convert.ToInt16(ViewState["CurrentStatusCode"].ToString()) == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.VerificationSchedulingDoneVerficationPending))
                    control.Style.Add("display", "");
                else
                    control.Style.Add("display", "none");
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
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            HtmlTableCell control = (HtmlTableCell)e.Item.FindControl("tdEduAction");
            if ((int)Convert.ToInt16(ViewState["CurrentStatusCode"].ToString()) == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.VerificationSchedulingDoneVerficationPending))
                control.Style.Add("display", "");
            else
                control.Style.Add("display", "none");
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

    protected void rptEducational_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "MarkDocVerified")
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateDocVerified", connection);
                sqlCommand.Parameters.Add("@CandDocCode", SqlDbType.Int).Value = Convert.ToInt32(e.CommandArgument.ToString());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                GetCandidateDetail(ref connection);
            }
            if (!(e.CommandName == "View"))
                return;
            ((ImageButton)e.Item.FindControl("Imgbtn")).PostBackUrl = "";
            GeneralMethods.FileResponse(Path.GetFileName(e.CommandArgument.ToString()), Path.GetDirectoryName(e.CommandArgument.ToString()));
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

    protected void rptProfessional_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            try
            {
                HtmlTableCell control = (HtmlTableCell)e.Item.FindControl("thProfAction");
                if ((int)Convert.ToInt16(ViewState["CurrentStatusCode"].ToString()) == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.VerificationSchedulingDoneVerficationPending))
                    control.Style.Add("display", "");
                else
                    control.Style.Add("display", "none");
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
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            HtmlTableCell control = (HtmlTableCell)e.Item.FindControl("tDProfAction");
            if ((int)Convert.ToInt16(ViewState["CurrentStatusCode"].ToString()) == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.VerificationSchedulingDoneVerficationPending))
                control.Style.Add("display", "");
            else
                control.Style.Add("display", "none");
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

    protected void rptProfessional_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "MarkDocVerified")
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateDocVerified", connection);
                sqlCommand.Parameters.Add("@CandDocCode", SqlDbType.Int).Value = Convert.ToInt32(e.CommandArgument.ToString());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                GetCandidateDetail(ref connection);
            }
            if (!(e.CommandName == "View"))
                return;
            ((ImageButton)e.Item.FindControl("Imgbtn")).PostBackUrl = "";
            GeneralMethods.FileResponse(Path.GetFileName(e.CommandArgument.ToString()), Path.GetDirectoryName(e.CommandArgument.ToString()));
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

    protected void lnkShortlist_Click(object sender, EventArgs e)
    {
        try
        {
            ShortlistCandidate();
            if (Candidate_CandidateDetails.IsTest.ToLower() == "true")
                StatusManagement.MarkLifeCycleStatus(connection, int.Parse(hdnCandidateCode.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.ShortlistedSchedulingPendingTest, Request.UserHostAddress.ToString(), UserCode);
            else if (Candidate_CandidateDetails.IsTest.ToLower() == "false")
                StatusManagement.MarkLifeCycleStatus(connection, int.Parse(hdnCandidateCode.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.NoTestSchedulingPendingInterview, Request.UserHostAddress.ToString(), UserCode);
            sShortlist.Style.Add("display", "none");
            lnkShortlist.Text = "";
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Shortlisted Successfully!');", true);
            GetCandidateDetail(ref connection);
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

    protected void lnkbtnCV_OnClick(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(hdnCVPath.Value))
                return;
            GeneralMethods.FileResponse(Path.GetFileName(hdnCVPath.Value), ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + Convert.ToInt32(hdnCandidateCode.Value) + "/Personal/");
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

    protected void rptCommunication_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item)
                return;
            int itemType = (int)e.Item.ItemType;
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

    protected void lnkChangeJoiningDate_Click(object sender, EventArgs e)
    {
        try
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateJoiningDate", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(hdnCandidateCode.Value);
            sqlCommand.Parameters.Add("@JoiningDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtJoiningDate.Value);
            sqlCommand.ExecuteNonQuery();
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            GetCandidateDetail(ref connection);
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Joining Date Changed Successfully!');", true);
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

    protected void lnkOfferLetter_OnClick(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(hdnOfferLetter.Value))
                return;
            FileResponses(hdnOfferLetter.Value, ConfigurationManager.AppSettings["CandidateDocumentPath"].ToString() + Convert.ToInt32(hdnCandidateCode.Value) + "/OfferLetter/");
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

    protected void lnkOfferGenerationPending_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(txtaOfferGenerationPending.InnerHtml))
                InsertUserOfferGeneratedComments();
            InsertDocumentToGeneratePDF(ref connection, "Offer Letter", 1);
            if (connection.State != ConnectionState.Open)
                connection.Open();
            StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(hdnCandidateCode.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.OfferGeneratedSchedulingPending, Request.UserHostAddress.ToString(), UserCode);
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            GetCandidateDetail(ref connection);
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

    public void InsertDocumentToGeneratePDF(ref SqlConnection connection, string DocumentName, int offerLetterCode)
    {
        try
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Insert_CandidateOfficialDocumentForMarkingPDF", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(hdnCandidateCode.Value);
            sqlCommand.Parameters.Add("@CandidateDocumentName", SqlDbType.VarChar).Value = DocumentName;
            sqlCommand.Parameters.Add("@OfficialLetter_Code", SqlDbType.Int).Value = offerLetterCode;
            sqlCommand.ExecuteNonQuery();
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

    protected void lnkAppointmentGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(txtaAppointmentGeneration.InnerHtml))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateInterview", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(hdnCandidateCode.Value);
                sqlCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = UserCode;
                sqlCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = txtaAppointmentGeneration.InnerText;
                sqlCommand.Parameters.Add("@LifeCycleStatus", SqlDbType.Int).Value = Convert.ToInt32(Constants.CandidateLifeCycleStatus.AppointmentSchedulingDoneJoiningReportingPending);
                sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = UserCode;
                sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = Request.UserHostAddress.ToString();
                sqlCommand.ExecuteNonQuery();
            }
            InsertDocumentToGeneratePDF(ref connection, "CandidateAppointmentLetter", 2);
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            GetCandidateDetail(ref connection);
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

    protected void lnkCreatePortal_Click(object sender, EventArgs e)
    {
        try
        {
            string str = string.Empty;
            foreach (ListItem listItem in chkjobrole.Items)
            {
                if (listItem.Selected)
                    str = str + listItem.Value + ",";
            }
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_CreatePortalGenerationRequest", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@shift_code", SqlDbType.Int).Value = ddlshift.SelectedValue;
            sqlCommand.Parameters.Add("@city_Code", SqlDbType.Int).Value = ddlCity.SelectedValue;
            sqlCommand.Parameters.Add("@Candidate_ID", SqlDbType.VarChar).Value = lblRefNo.InnerText;
            sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = UserCode;
            sqlCommand.Parameters.Add("@Updation_IP", SqlDbType.VarChar).Value = Request.UserHostAddress.ToString();
            sqlCommand.Parameters.Add("@JobRole_Code", SqlDbType.VarChar).Value = str;
            sqlCommand.Parameters.Add("@City_Name", SqlDbType.VarChar).Value = ddlCity.SelectedItem.Text;
            sqlCommand.ExecuteNonQuery();
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            GetCandidateDetail(ref connection);
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
            SqlCommand selectCommand = new SqlCommand("dbo.Xrec_Select_InterViewPanelDateWise", connection);
            selectCommand.Parameters.AddWithValue("@ReserveSlot_Code", control5.Value);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0 && dataTable != null)
            {
                control3.DataSource = dataTable;
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
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void rptScheduleChild_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Header)
            return;
        try
        {
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
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

    public void ClearCandidateAvailedSlots()
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateSlotIsAvailed", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(hdnCandidateCode.Value);
        sqlCommand.ExecuteNonQuery();
    }

    public void GetCandidateHistory()
    {
        if (string.IsNullOrEmpty(hdnCandidateCode.Value))
            return;
        SqlCommand selectCommand = new SqlCommand("Xrec_Select_Candidatehistory", connection);
        selectCommand.Parameters.AddWithValue("@CandidateCode", hdnCandidateCode.Value);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables.Count == 0)
            return;
        if (dataSet.Tables.Count >= 1)
        {
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                rptCandidatehistory.Visible = true;
                rptCandidatehistory.DataSource = dataSet;
                rptCandidatehistory.DataBind();
                lblCHmessage.Visible = false;
                tblPersonalHistory.Style.Add("display", "");
            }
            else
            {
                lblCHmessage.Visible = true;
                lblCHmessage.Text = "No history";
                rptCandidatehistory.DataSource = null;
                rptCandidatehistory.Visible = false;
                tblPersonalHistory.Style.Add("display", "none");
            }
        }
        if (dataSet.Tables.Count >= 2)
        {
            if (dataSet.Tables[1].Rows.Count > 0)
            {
                rptCandidateExHistory.Visible = true;
                rptCandidateExHistory.DataSource = dataSet.Tables[1];
                rptCandidateExHistory.DataBind();
                lblCEHMessage.Visible = false;
                tblProfessionalHistory.Style.Add("display", "");
            }
            else
            {
                lblCEHMessage.Visible = true;
                lblCEHMessage.Text = "No history";
                rptCandidateExHistory.DataSource = null;
                rptCandidateExHistory.Visible = false;
                tblProfessionalHistory.Style.Add("display", "none");
            }
        }
        if (dataSet.Tables.Count < 3)
            return;
        if (dataSet.Tables[2].Rows.Count > 0)
        {
            rptQaHistory.Visible = true;
            rptQaHistory.DataSource = dataSet.Tables[2];
            rptQaHistory.DataBind();
            lblQaMessage.Visible = false;
            tblEduHistory.Style.Add("display", "");
        }
        else
        {
            lblQaMessage.Visible = true;
            lblQaMessage.Text = "No history";
            rptQaHistory.DataSource = null;
            rptQaHistory.Visible = false;
            tblEduHistory.Style.Add("display", "none");
        }
    }

    private void UpdateCandidateInformation(string FilePath)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("dbo.XRec_InsertCandidateOfferAudioPath", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", hdnCandidateCode.Value));
                sqlCommand.Parameters.Add(new SqlParameter("@AudioPath", FilePath));
                sqlCommand.Parameters.Add(new SqlParameter("@UpdatedBy", UserCode));
                sqlCommand.Parameters.Add(new SqlParameter("@UpdatedIP", Request.UserHostAddress.ToString()));
                sqlCommand.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public bool CreateDocumentFolder(string PathPreFix)
    {
        try
        {
            string str1 = hdnCandidateCode.Value;
            string str2 = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["CandidateDocumentPath"].ToString());
            if (!Directory.Exists(str2 + str1 + PathPreFix))
                Directory.CreateDirectory(str2 + str1 + PathPreFix);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public void FileResponses(string filename, string FolderPath)
    {
        FileInfo fileInfo = new FileInfo(HttpContext.Current.Server.MapPath(FolderPath + "/" + filename));
        if (fileInfo.Exists)
        {
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
        else
            APortFile.Visible = false;
    }

    private void CheckDivs()
    {
        if ((int)Convert.ToInt16(ViewState["CurrentStatusCode"].ToString()) == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.SchedulingDoneInterviewPending))
        {
            tblInterview.Style.Add("display", "");
            tblOfferGenerationPending.Style.Add("display", "none");
            tblOfferGeneration.Style.Add("display", "none");
            tblOfferDelivered.Style.Add("display", "none");
            tblOfferAcceptance.Style.Add("display", "none");
        }
        else if ((int)Convert.ToInt16(ViewState["CurrentStatusCode"].ToString()) == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.InterviewPassedOfferGenerationPending))
        {
            tblInterview.Style.Add("display", "none");
            tblOfferGenerationPending.Style.Add("display", "");
            tblOfferDelivered.Style.Add("display", "none");
            tblOfferAcceptance.Style.Add("display", "none");
            AReserve.HRef = "../schedule/SchduleCandidate.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("refno=" + ViewState["CurrentRefNo"].ToString() + "pgno=1");
            trOfferGenerationReserved.Style.Add("display", "none");
        }
        else if ((int)Convert.ToInt16(ViewState["CurrentStatusCode"].ToString()) == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferSchedulingDoneOfferPending))
        {
            tblInterview.Style.Add("display", "none");
            tblOfferGenerationPending.Style.Add("display", "none");
            tblOfferGeneration.Style.Add("display", "none");
            tblOfferDelivered.Style.Add("display", "");
            tblOfferAcceptance.Style.Add("display", "none");
        }
        else if ((int)Convert.ToInt16(ViewState["CurrentStatusCode"].ToString()) == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferDeliveredAcceptancePending))
        {
            tblInterview.Style.Add("display", "none");
            tblOfferGenerationPending.Style.Add("display", "none");
            tblOfferGeneration.Style.Add("display", "none");
            tblOfferDelivered.Style.Add("display", "none");
            tblOfferAcceptance.Style.Add("display", "");
            txtExpectedDOJ.Value = DateTime.Now.ToString("MMM dd, yyyy");
        }
        else if ((int)Convert.ToInt16(ViewState["CurrentStatusCode"].ToString()) == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.VerificationDoneAppointmentSchedulingPending))
        {
            tblInterview.Style.Add("display", "none");
            tblOfferGenerationPending.Style.Add("display", "none");
            tblOfferGeneration.Style.Add("display", "none");
            tblOfferDelivered.Style.Add("display", "none");
            tblOfferAcceptance.Style.Add("display", "none");
            tblAppointmentGeneration.Visible = true;
        }
        else if ((int)Convert.ToInt16(ViewState["CurrentStatusCode"].ToString()) == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.AppointmentSchedulingDoneJoiningReportingPending))
        {
            tblInterview.Style.Add("display", "none");
            tblOfferGenerationPending.Style.Add("display", "none");
            tblOfferGeneration.Style.Add("display", "none");
            tblOfferDelivered.Style.Add("display", "none");
            tblOfferAcceptance.Style.Add("display", "none");
            tblAppointmentGeneration.Style.Add("display", "none");
            tblPortalActivation.Visible = true;
            SqlCommand selectCommand = new SqlCommand("dbo.Xrec_SelectCandidateOptionsForPortal", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet == null)
                return;
            ddlshift.DataSource = dataSet.Tables[0];
            ddlshift.DataTextField = "Shift_Name";
            ddlshift.DataValueField = "Shift_Code";
            ddlshift.DataBind();
            ddlshift.Items.Insert(0, new ListItem("--Select Shift--", "-1"));
            chkjobrole.DataSource = dataSet.Tables[1];
            chkjobrole.DataTextField = "JobRole_Name";
            chkjobrole.DataValueField = "JobRole_ID";
            chkjobrole.DataBind();
            ddlCity.DataSource = dataSet.Tables[2];
            ddlCity.DataTextField = "City";
            ddlCity.DataValueField = "Location_ID";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("--Select Location--", "-1"));
        }
        else
            HActions.Style.Add("display", "none");
    }

    private void ShortlistCandidate()
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.XRec_UpdateSelectedCandidateLockBit", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CPM_Codes", SqlDbType.VarChar).Value = ViewState["CurrentRefNo"].ToString();
        sqlCommand.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UserCode;
        sqlCommand.Parameters.Add("@UpdationIP", SqlDbType.VarChar).Value = Request.UserHostAddress;
        if (connection.State != ConnectionState.Open)
            connection.Open();
        sqlCommand.ExecuteNonQuery();
        if (connection.State == ConnectionState.Closed)
            return;
        connection.Close();
    }

    private void InsertUserInterviewComments()
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateInterview", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(hdnCandidateCode.Value);
        sqlCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = UserCode;
        sqlCommand.Parameters.Add("@IsPassOrFail", SqlDbType.Bit).Value = rdbPass.Checked;
        sqlCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = txtaComments.InnerText;
        if (ddlGrade.SelectedValue != "-1" && ddlDesignation.SelectedValue != "-1")
            sqlCommand.Parameters.Add("@LifeCycleStatus", SqlDbType.Int).Value = Convert.ToInt32(Constants.CandidateLifeCycleStatus.InterviewDoneOfferGenerated);
        else
            sqlCommand.Parameters.Add("@LifeCycleStatus", SqlDbType.Int).Value = Convert.ToInt32(Constants.CandidateLifeCycleStatus.SchedulingDoneInterviewPending);
        if (ddlGrade.SelectedValue != "-1")
            sqlCommand.Parameters.Add("@GradeCode", SqlDbType.Int).Value = ddlGrade.SelectedValue;
        if (ddlDesignation.SelectedValue != "-1")
            sqlCommand.Parameters.Add("@DesignationCode", SqlDbType.Int).Value = ddlDesignation.SelectedValue;
        sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = UserCode;
        sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = Request.UserHostAddress.ToString();
        if (connection.State != ConnectionState.Open)
            connection.Open();
        sqlCommand.ExecuteNonQuery();
        if (connection.State == ConnectionState.Closed)
            return;
        connection.Close();
    }

    private void InsertUserOfferDeliveredComments()
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateInterview", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(hdnCandidateCode.Value);
        sqlCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = UserCode;
        sqlCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = txtaOfferdelivered.InnerText;
        sqlCommand.Parameters.Add("@LifeCycleStatus", SqlDbType.Int).Value = Convert.ToInt32(Constants.CandidateLifeCycleStatus.OfferSchedulingDoneOfferPending);
        if (ddlGrade.SelectedValue != "-1")
            sqlCommand.Parameters.Add("@GradeCode", SqlDbType.Int).Value = ddlGrade.SelectedValue;
        sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = UserCode;
        sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = Request.UserHostAddress.ToString();
        if (connection.State != ConnectionState.Open)
            connection.Open();
        sqlCommand.ExecuteNonQuery();
        if (connection.State == ConnectionState.Closed)
            return;
        connection.Close();
    }

    private void InsertUserOfferAcceptedComments(bool check)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateInterview", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(hdnCandidateCode.Value);
        sqlCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = UserCode;
        sqlCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = txtaOfferAccepetance.InnerText;
        sqlCommand.Parameters.Add("@LifeCycleStatus", SqlDbType.Int).Value = Convert.ToInt32(Constants.CandidateLifeCycleStatus.OfferDeliveredAcceptancePending);
        if (ddlGrade.SelectedValue != "-1")
            sqlCommand.Parameters.Add("@GradeCode", SqlDbType.Int).Value = ddlGrade.SelectedValue;
        sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = UserCode;
        sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = Request.UserHostAddress.ToString();
        if (connection.State != ConnectionState.Open)
            connection.Open();
        sqlCommand.ExecuteNonQuery();
        if (check)
            InsertExpectedDateOfJoining();
        if (connection.State == ConnectionState.Closed)
            return;
        connection.Close();
    }

    private void InsertUserOfferGeneratedComments()
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateInterview", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(hdnCandidateCode.Value);
        sqlCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = UserCode;
        sqlCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = txtaOfferGenerationPending.InnerText;
        sqlCommand.Parameters.Add("@LifeCycleStatus", SqlDbType.Int).Value = Convert.ToInt32(Constants.CandidateLifeCycleStatus.InterviewPassedOfferGenerationPending);
        if (ddlGrade.SelectedValue != "-1")
            sqlCommand.Parameters.Add("@GradeCode", SqlDbType.Int).Value = ddlGrade.SelectedValue;
        sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = UserCode;
        sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = Request.UserHostAddress.ToString();
        if (connection.State != ConnectionState.Open)
            connection.Open();
        sqlCommand.ExecuteNonQuery();
        if (connection.State == ConnectionState.Closed)
            return;
        connection.Close();
    }

    private void InsertExpectedDateOfJoining()
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateDateOfJoining", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(hdnCandidateCode.Value);
        sqlCommand.Parameters.Add("@JoiningDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtExpectedDOJ.Value);
        sqlCommand.Parameters.Add("@RACode", SqlDbType.Int).Value = ddlRA.SelectedValue;
        sqlCommand.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UserCode;
        sqlCommand.Parameters.Add("@UpdatedIP", SqlDbType.VarChar).Value = Request.UserHostAddress.ToString();
        sqlCommand.ExecuteNonQuery();
    }

    public void GetCandidateDetail(ref SqlConnection connection)
    {
        aStatusChange.HRef = "UpdateCandidateInfo.aspx?" + SecureQueryString.QueryStringVar + "=" + secQueryString.encrypt("type=1&CID=" + candidateCode);
        aProfileChange.HRef = "UpdateCandidateInfo.aspx?" + SecureQueryString.QueryStringVar + "=" + secQueryString.encrypt("type=2&CID=" + candidateCode);
        aRequisitionChange.HRef = "UpdateCandidateInfo.aspx?" + SecureQueryString.QueryStringVar + "=" + secQueryString.encrypt("type=3&CID=" + candidateCode);
        aDocVerification.HRef = "CandidateDocumentVerification.aspx?" + SecureQueryString.QueryStringVar + "=" + secQueryString.encrypt("CID=" + candidateCode);
        aAppHistory.HRef = "CandidateApplication.aspx?" + SecureQueryString.QueryStringVar + "=" + secQueryString.encrypt("CID=" + candidateCode);
        aDocCheckList.Attributes.Add("onclick", "window.open('CandidateCheckList.aspx?" + SecureQueryString.QueryStringVar + "=" + secQueryString.encrypt("CID=" + candidateCode) + "','mywindow', 'location=0,toolbar=0,menubar=0,resizable=1,scrollbars=1,width=1100,height=900')");
        aDocCheckList.HRef = "javascript:";
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_SelectCandidateDetail", connection);
        selectCommand.Parameters.AddWithValue("@Candidate_Code", candidateCode == "0" ? hdnCandidateCode.Value : candidateCode);
        selectCommand.CommandType = CommandType.StoredProcedure;
        new SqlDataAdapter(selectCommand).Fill(ds);
        if (ds.Tables.Count == 0)
            return;
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblCandidateID.InnerText = ds.Tables[0].Rows[0]["Candidate_ID"].ToString();
            lblAvailbilityShift.InnerHtml = ds.Tables[0].Rows[0]["AvailbilityShift"].ToString();
            lblReferral.InnerHtml = ds.Tables[0].Rows[0]["Referral"].ToString();
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Resume_Path"].ToString()))
            {
                lnkbtnCV.HRef = ds.Tables[0].Rows[0]["Resume_Path"].ToString();
            }
            else
            {
                lnkbtnCV.Visible = false;
                hdnCVPath.Value = "";
            }
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["OfferLetterDoc"].ToString()))
            {
                lnkOfferLetter.Style.Add("display", "");
                lblNoOffer.InnerText = "";
                hdnOfferLetter.Value = ds.Tables[0].Rows[0]["OfferLetterDoc"].ToString();
            }
            else
            {
                lnkOfferLetter.Style.Add("display", "none");
                lblNoOffer.InnerText = "No Offer Letter";
                hdnOfferLetter.Value = "";
            }
            portfolioFileName = !string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Portfolio_Path"].ToString()) ? ds.Tables[0].Rows[0]["Portfolio_Path"].ToString() : ds.Tables[0].Rows[0]["Portfolio_URL"].ToString();
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Portfolio_Path"].ToString()))
            {
                APortFile.Visible = true;
                APortFile.HRef = ds.Tables[0].Rows[0]["Portfolio_Path"].ToString();
                hdnpFileName.Value = ds.Tables[0].Rows[0]["Portfolio_Path"].ToString();
            }
            else
                APortFile.Visible = false;
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Portfolio_URL"].ToString()))
            {
                APortURL.Visible = true;
                APortURL.HRef = ds.Tables[0].Rows[0]["Portfolio_URL"].ToString();
                hdnpFileName.Value = ds.Tables[0].Rows[0]["Portfolio_URL"].ToString();
            }
            else
                APortURL.Visible = false;
            lblName.InnerText = ds.Tables[0].Rows[0]["Full_Name"].ToString();
            lblEmailAddress.InnerText = ds.Tables[0].Rows[0]["Email_Address"].ToString();
            lblDoB.InnerText = ds.Tables[0].Rows[0]["DateOf_Birth"].ToString();
            lblNic.InnerText = ds.Tables[0].Rows[0]["NIC"].ToString();
            lblLandline.Text = ds.Tables[0].Rows[0]["home_number"].ToString();
            if ((bool)ds.Tables[0].Rows[0]["Is_EmailVerified"])
            {
                imgEmailNotVerified.Visible = false;
                lblemailverificationCode.Visible = false;
            }
            else
            {
                lblemailverificationCode.Visible = true;
                lblemailverificationCode.Text = ds.Tables[0].Rows[0]["emailVerificationCode"].ToString();
                tdEmil.Style.Add("Background-color", "#FFD9D9");
                tdEmil.Style.Add("border", "2px solid #F00");
                lblEmailAddress.Style.Add("text-shadow", "2px 2px 2px #ebebeb");
            }
            if ((bool)ds.Tables[0].Rows[0]["is_PhoneVerified"])
            {
                imgPhoneNotVerified.Visible = false;
                lblPhoneVerificationCode.Visible = false;
            }
            else
            {
                lblPhoneVerificationCode.Visible = true;
                lblPhoneVerificationCode.Text = ds.Tables[0].Rows[0]["PhoneVerification_Code"].ToString();
                tdPhone.Style.Add("Background-color", "#FFD9D9");
                tdPhone.Style.Add("border", "2px solid #F00");
                lblPhoneNumber.Style.Add("text-shadow", "2px 2px 2px #ebebeb");
            }
            if (ds.Tables[0].Rows[0]["Is_Redundent"].ToString() == "0")
            {
                imgNICNotVerified.Visible = false;
            }
            else
            {
                tdNic.Style.Add("Background-color", "#FFD9D9");
                tdNic.Style.Add("border", "2px solid #F00");
                lblNic.Style.Add("text-shadow", "2px 2px 2px #ebebeb");
            }
            lblGender.InnerText = ds.Tables[0].Rows[0]["Gender"].ToString();
            lblPhoneNumber.InnerHtml = "<b>" + ds.Tables[0].Rows[0]["Phone_Number"].ToString() + " (Primary)</b>" + ds.Tables[0].Rows[0]["MutliplePhoneNo"].ToString();
            lblReligion.InnerText = ds.Tables[0].Rows[0]["Religion"].ToString();
            lblMaritalStatus.InnerText = ds.Tables[0].Rows[0]["MaritalStatus"].ToString();
            lblNationality.InnerText = ds.Tables[0].Rows[0]["Nationality"].ToString();
            lblAddress.InnerText = ds.Tables[0].Rows[0]["Address"].ToString();
            imgCandidatePic.Src = !(ds.Tables[0].Rows[0]["PicPath"].ToString() != "-") ? "/assets/images/noimage.jpg" : ".." + ds.Tables[0].Rows[0]["PicPath"].ToString();
            lblVeriCode.InnerHtml = ds.Tables[0].Rows[0]["PhoneVerification_Code"].ToString();
            if ((bool)ds.Tables[0].Rows[0]["is_PhoneVerified"])
                trPhoneCode.Style.Add("display", "none");
            else
                trPhoneCode.Style.Add("display", "");
            if ((bool)ds.Tables[0].Rows[0]["Is_OGVisited"])
                lblTour.InnerText = "Tour Done";
            else
                lblTour.InnerText = "Tour Not Done";
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            rptProfessionalExperience.DataSource = ds.Tables[1];
            rptProfessionalExperience.DataBind();
        }
        if (ds.Tables[2].Rows.Count > 0)
        {
            if (ds.Tables[2].Select("Program_Code =6").Length > 0)
            {
                rptDiploma.DataSource = ((IEnumerable<DataRow>)ds.Tables[2].Select("Program_Code = 6", "OStart_Date ASC")).CopyToDataTable<DataRow>();
                rptDiploma.DataBind();
            }
            if (ds.Tables[2].Select("Program_Code =7").Length > 0)
            {
                rptCertificate.DataSource = ((IEnumerable<DataRow>)ds.Tables[2].Select("Program_Code = 7", "OStart_Date ASC")).CopyToDataTable<DataRow>();
                rptCertificate.DataBind();
            }
            if (ds.Tables[2].Select("Program_Code <> 7 and Program_Code <> 6").Length > 0)
            {
                rptEduQualification.DataSource = ((IEnumerable<DataRow>)ds.Tables[2].Select("Program_Code <> 7 and Program_Code <> 6", "OStart_Date ASC")).CopyToDataTable<DataRow>();
                rptEduQualification.DataBind();
            }
        }
        if (ds.Tables[3].Rows.Count > 0)
        {
            rptSkills.DataSource = ds.Tables[3];
            rptSkills.DataBind();
        }
        if (ds.Tables[5] != null && ds.Tables[5].Rows.Count > 0)
        {
            lblCurrentStatus.InnerHtml = ds.Tables[5].Rows[0]["Status_Name"].ToString();
            if (!string.IsNullOrEmpty(ds.Tables[5].Rows[0]["Status_Name"].ToString()))
                lblstatus.InnerHtml = " (" + ds.Tables[5].Rows[0]["Status_Name"].ToString() + ")";
            lblProfileName.InnerHtml = ds.Tables[5].Rows[0]["Profile_Name"].ToString();
            lblRequisitionName.InnerHtml = ds.Tables[5].Rows[0]["Requisition_Name"].ToString();
            lblCategoryName.InnerHtml = ds.Tables[5].Rows[0]["Category_Name"].ToString();
            lblJoiningDateName.InnerHtml = ds.Tables[5].Rows[0]["Joining_Date"].ToString();
            ViewState["CurrentRefNo"] = ds.Tables[5].Rows[0]["Candidate_ID"].ToString();
            lblRefNo.InnerHtml = ds.Tables[5].Rows[0]["Candidate_ID"].ToString();
            Candidate_CandidateDetails.RefNo = ds.Tables[5].Rows[0]["Candidate_ID"].ToString();
            Candidate_CandidateDetails.IsTest = ds.Tables[5].Rows[0]["Is_Test"].ToString();
            if (!(bool)ds.Tables[5].Rows[0]["Is_locked"] && lblRequisitionName.InnerHtml != "-")
            {
                sShortlist.Style.Add("display", "");
                lnkShortlist.Text = "Shortlist";
            }
            else
            {
                sShortlist.Style.Add("display", "none");
                lnkShortlist.Text = "";
            }
            if (Convert.ToInt32(ds.Tables[5].Rows[0]["AppCount"]) > 1)
                aAppHistory.Visible = true;
            else
                aAppHistory.Visible = false;
            if (!string.IsNullOrEmpty(ds.Tables[5].Rows[0]["Status_Code"].ToString()))
            {
                if ((int)Convert.ToInt16(ds.Tables[5].Rows[0]["Status_Code"].ToString()) <= (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.SignupdoneFormPending))
                {
                    aProfileChange.Visible = false;
                    aRequisitionChange.Visible = false;
                }
                else
                {
                    aRequisitionChange.Visible = false;
                    aProfileChange.Visible = true;
                }
                if ((int)Convert.ToInt16(ds.Tables[5].Rows[0]["Status_Code"].ToString()) >= (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.PositionMappedWaitingforPositionopening) && ds.Tables[5].Rows[0]["ReqCount"].ToString() != "0")
                    aRequisitionChange.Visible = true;
                else
                    aRequisitionChange.Visible = false;
                if (ds.Tables[5].Rows[0]["ReqCount"].ToString() == "0" && (int)Convert.ToInt16(ds.Tables[5].Rows[0]["Status_Code"].ToString()) >= (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.PositionMappedWaitingforPositionopening))
                    lblRequisitionName.InnerText = "No requisition mapped on selected Profile";
                else
                    lblCurrentStatus.InnerHtml = ds.Tables[5].Rows[0]["Status_Name"].ToString();
                if ((int)Convert.ToInt16(ds.Tables[5].Rows[0]["Status_Code"].ToString()) >= (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferAcceptedVerificationSchedulingPending) && (int)Convert.ToInt16(ds.Tables[5].Rows[0]["Status_Code"].ToString()) != (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferNotAcceptedReSchedulingPendingOffer))
                    lnkChangeJoiningDate.Visible = true;
                else
                    lnkChangeJoiningDate.Visible = false;
                int int32 = Convert.ToInt32(ds.Tables[5].Rows[0]["Status_Code"]);
                ViewState["CurrentStatusCode"] = int32;
                if (int32 == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.ShortlistedSchedulingPendingTest) || int32 == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.TestFailedReSchedulingPendingTest) || int32 == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.TestnotAppearedReSchedulingPending))
                {
                    sSchedule.Style.Add("display", "");
                    aSchedule.InnerHtml = "Schedule For Test";
                    aSchedule.HRef = "../schedule/SchduleCandidate.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("refno=" + ViewState["CurrentRefNo"].ToString() + "&pgno=1");
                    aSchedule.Attributes.Add("class", "openframe");
                }
                else if (int32 == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.TestPassedSchedulingPendingInterview) || int32 == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.NoTestSchedulingPendingInterview) || (int32 == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.InterviewFailedReSchedulingPending) || int32 == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.InterviewnotAppearedReSchedulingPending)))
                {
                    sSchedule.Style.Add("display", "");
                    aSchedule.InnerHtml = "Schedule For Interview";
                    aSchedule.HRef = "../schedule/SchduleCandidate.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("refno=" + ViewState["CurrentRefNo"].ToString() + "&pgno=1");
                    aSchedule.Attributes.Add("class", "openframe");
                }
                else if (int32 == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferGeneratedSchedulingPending) || int32 == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferNotAcceptedReSchedulingPendingOffer))
                {
                    sSchedule.Style.Add("display", "");
                    aSchedule.InnerHtml = "Schedule For Offer";
                    aSchedule.HRef = "../schedule/SchduleCandidate.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("refno=" + ViewState["CurrentRefNo"].ToString() + "&pgno=1");
                    aSchedule.Attributes.Add("class", "openframe");
                }
                else if (int32 == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferAcceptedVerificationSchedulingPending))
                {
                    sSchedule.Style.Add("display", "");
                    aSchedule.InnerHtml = "Schedule For Verification";
                    aSchedule.HRef = "../schedule/SchduleCandidate.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("refno=" + ViewState["CurrentRefNo"].ToString() + "&pgno=1");
                    aSchedule.Attributes.Add("class", "openframe");
                }
                else if (int32 == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.VerificationDoneAppointmentSchedulingPending))
                {
                    sSchedule.Style.Add("display", "");
                    aSchedule.InnerHtml = "Schedule For Appointment";
                    aSchedule.HRef = "../schedule/SchduleCandidate.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("refno=" + ViewState["CurrentRefNo"].ToString() + "&pgno=1");
                    aSchedule.Attributes.Add("class", "openframe");
                }
                else
                {
                    sSchedule.Style.Add("display", "none");
                    aSchedule.InnerHtml = "";
                    aSchedule.HRef = "Javascript:;";
                }
            }
            else
                ViewState["CurrentStatusCode"] = "0";
            if (!string.IsNullOrEmpty(ds.Tables[5].Rows[0]["SubDomain_Name"].ToString()))
                lblSubDomain.InnerHtml = ds.Tables[5].Rows[0]["SubDomain_Name"].ToString();
            if (!string.IsNullOrEmpty(ds.Tables[5].Rows[0]["Domain_Name"].ToString()))
                lblDomain.InnerHtml = ds.Tables[5].Rows[0]["Domain_Name"].ToString();
            else
                trDomain.Style.Add("display", "none");
            if (!string.IsNullOrEmpty(ds.Tables[5].Rows[0]["Grade_Name"].ToString()))
                lblGradeName.InnerHtml = ds.Tables[5].Rows[0]["Grade_Name"].ToString();
            if (!string.IsNullOrEmpty(ds.Tables[5].Rows[0]["Designation_Name"].ToString()))
                lblDesignation.InnerHtml = ds.Tables[5].Rows[0]["Designation_Name"].ToString();
            if (!string.IsNullOrEmpty(ds.Tables[5].Rows[0]["RAName"].ToString()))
                lblRA.InnerHtml = ds.Tables[5].Rows[0]["RAName"].ToString();
            else
                trRA.Style.Add("display", "none");
        }
        else
        {
            lblCurrentStatus.InnerText = "-";
            sSchedule.Style.Add("display", "none");
            ViewState["CurrentStatusCode"] = "0";
            ViewState["CurrentRefNo"] = "0";
        }
        if (ds.Tables[4] != null)
        {
            if (ds.Tables[4].Rows.Count > 0)
            {
                if (ds.Tables[4].Select("DocType_Code =" + 9).Length > 0)
                {
                    DataTable dataTable = ((IEnumerable<DataRow>)ds.Tables[4].Select("DocType_Code =" + 9)).CopyToDataTable<DataRow>();
                    rptProfessional.Visible = true;
                    lblemtyProfessional.Visible = false;
                    rptProfessional.DataSource = dataTable;
                    rptProfessional.DataBind();
                }
                else
                {
                    rptProfessional.DataSource = null;
                    rptProfessional.Visible = false;
                    lblemtyProfessional.Visible = true;
                    lblemtyProfessional.Text = "No documents browsed.";
                }
                if (ds.Tables[4].Select("DocType_Code =" + 1).Length > 0)
                {
                    DataTable dataTable = ((IEnumerable<DataRow>)ds.Tables[4].Select("DocType_Code =" + 1)).CopyToDataTable<DataRow>();
                    rptPersonal.Visible = true;
                    lblemtypersonal.Visible = false;
                    rptPersonal.DataSource = dataTable;
                    rptPersonal.DataBind();
                }
                else
                {
                    rptPersonal.DataSource = null;
                    rptPersonal.Visible = false;
                    lblemtypersonal.Visible = true;
                    lblemtypersonal.Text = "No documents browsed.";
                }
                if (ds.Tables[4].Select("DocType_Code <>" + 9 + "and DocType_Code <>" + 1).Length > 0)
                {
                    DataTable dataTable = ((IEnumerable<DataRow>)ds.Tables[4].Select("DocType_Code <>" + 9 + "and DocType_Code <>" + 1)).CopyToDataTable<DataRow>();
                    rptEducational.Visible = true;
                    lblemtyEducational.Visible = false;
                    rptEducational.DataSource = dataTable;
                    rptEducational.DataBind();
                }
                else
                {
                    rptEducational.DataSource = null;
                    rptEducational.Visible = false;
                    lblemtyEducational.Visible = true;
                    lblemtyEducational.Text = "No documents browsed.";
                }
            }
            else
            {
                rptEducational.DataSource = null;
                rptEducational.Visible = false;
                lblemtyEducational.Visible = true;
                lblemtyEducational.Text = "No documents browsed.";
                rptPersonal.DataSource = null;
                rptPersonal.Visible = false;
                lblemtypersonal.Visible = true;
                lblemtypersonal.Text = "No documents browsed.";
                rptProfessional.DataSource = null;
                rptProfessional.Visible = false;
                lblemtyProfessional.Visible = true;
                lblemtyProfessional.Text = "No documents browsed.";
            }
        }
        else
        {
            rptEducational.DataSource = null;
            rptEducational.Visible = false;
            lblemtyEducational.Visible = true;
            lblemtyEducational.Text = "No documents browsed.";
            rptPersonal.DataSource = null;
            rptPersonal.Visible = false;
            lblemtypersonal.Visible = true;
            lblemtypersonal.Text = "No documents browsed.";
            rptProfessional.DataSource = null;
            rptProfessional.Visible = false;
            lblemtyProfessional.Visible = true;
            lblemtyProfessional.Text = "No documents browsed.";
        }
        if (ds.Tables[6] != null && ds.Tables[6].Rows.Count > 0)
        {
            rptFamily.DataSource = ds.Tables[6];
            rptFamily.DataBind();
        }
        else
        {
            lblMsgfamily.Text = "No record(s) found";
            rptFamily.DataSource = null;
            rptFamily.DataBind();
        }
        if (ds.Tables[8] != null && ds.Tables[8].Rows.Count > 0)
        {
            rptCommunication.DataSource = ds.Tables[8];
            rptCommunication.DataBind();
        }
        else
        {
            lblMsgCommu.Text = "No record(s) found";
            rptCommunication.DataSource = null;
            rptCommunication.DataBind();
        }
        if (ds.Tables[9] != null && ds.Tables[9].Rows.Count > 0)
        {
            ddlGrade.DataSource = ds.Tables[9];
            ddlGrade.DataTextField = "Grade_Name";
            ddlGrade.DataValueField = "Grade_Code";
            ddlGrade.DataBind();
        }
        ddlGrade.Items.Insert(0, new ListItem("--Grade--", "-1"));
        if (ds.Tables[10] != null && ds.Tables[10].Rows.Count > 0)
        {
            ddlDesignation.DataSource = ds.Tables[10];
            ddlDesignation.DataTextField = "Designation_Name";
            ddlDesignation.DataValueField = "Designation_Code";
            ddlDesignation.DataBind();
        }
        ddlDesignation.Items.Insert(0, new ListItem("--Designation--", "-1"));
        if (ds.Tables[14] != null && ds.Tables[14].Rows.Count > 0)
        {
            ddlRA.DataSource = ds.Tables[14];
            ddlRA.DataTextField = "RA_Name";
            ddlRA.DataValueField = "RA_Code";
            ddlRA.DataBind();
        }
        ddlRA.Items.Insert(0, new ListItem("--Reporting Authority--", "-1"));
        if (ds.Tables[12].Rows.Count > 0)
        {
            rptQuestionGroup.DataSource = ds.Tables[12];
            rptQuestionGroup.DataBind();
            alnkChktest.HRef = "../assessment/checktest.aspx?cid=" + hdnCandidateCode.Value;
            tblTest.Style.Add("display", "");
            lblMsgTest.Visible = false;
            tblTestmsg.Style.Add("display", "none");
        }
        else
        {
            alnkChktest.Style.Add("display", "none");
            lblMsgTest.Visible = true;
            lblMsgTest.Text = "No record(s) found";
            rptQuestionGroup.DataSource = null;
            rptQuestionGroup.DataBind();
            tblTest.Style.Add("display", "none");
            tblTestmsg.Style.Add("display", "");
        }
        if (ds.Tables[15].Rows.Count > 0)
        {
            aOfferLetterAudio.HRef = ds.Tables[15].Rows[0]["DocumentPath"].ToString();
            trOfferLetterAudio.Style.Add("display", "");
        }
        else
        {
            aOfferLetterAudio.HRef = "javascript:;";
            trOfferLetterAudio.Style.Add("display", "none");
        }
        CheckDivs();
        if (ds.Tables[16].Rows.Count > 0)
        {
            rptScheduleHistory.DataSource = ds.Tables[16];
            rptScheduleHistory.DataBind();
            rptScheduleHistory.Visible = true;
            trempty.Visible = false;
        }
        else
        {
            rptScheduleHistory.DataSource = null;
            rptScheduleHistory.Visible = false;
            trempty.Visible = true;
        }
        if (ds.Tables[17].Rows.Count > 0)
        {
            if (((IEnumerable<DataRow>)ds.Tables[17].Select("OfficialLetter_Code=1")).Count<DataRow>() > 0)
            {
                aOfferLetter.HRef = ((IEnumerable<DataRow>)ds.Tables[17].Select("OfficialLetter_Code=1")).CopyToDataTable<DataRow>().Rows[0]["DocumentPath"].ToString();
                aOfferLetter.Target = "_blank";
            }
            if (((IEnumerable<DataRow>)ds.Tables[17].Select("OfficialLetter_Code=2")).Count<DataRow>() > 0)
            {
                aAppointmentLetter.HRef = ((IEnumerable<DataRow>)ds.Tables[17].Select("OfficialLetter_Code=2")).CopyToDataTable<DataRow>().Rows[0]["DocumentPath"].ToString();
                aAppointmentLetter.Target = "_blank";
                tblAppointmentGeneration.Visible = false;
            }
            if (((IEnumerable<DataRow>)ds.Tables[17].Select("OfficialLetter_Code=3")).Count<DataRow>() > 0)
            {
                aMedicalLetter.HRef = ((IEnumerable<DataRow>)ds.Tables[17].Select("OfficialLetter_Code=3")).CopyToDataTable<DataRow>().Rows[0]["DocumentPath"].ToString();
                aMedicalLetter.Target = "_blank";
            }
            if (((IEnumerable<DataRow>)ds.Tables[17].Select("OfficialLetter_Code=5")).Count<DataRow>() > 0)
            {
                aRemuneration.HRef = ((IEnumerable<DataRow>)ds.Tables[17].Select("OfficialLetter_Code=5")).CopyToDataTable<DataRow>().Rows[0]["DocumentPath"].ToString();
                aRemuneration.Target = "_blank";
            }
        }
        if (ds.Tables[18] != null && ds.Tables[18].Rows.Count > 0)
        {
            rptOffer.DataSource = ds.Tables[18];
            rptOffer.DataBind();
        }
        else
        {
            lblOffer.Text = "No record(s) found";
            rptOffer.DataSource = null;
            rptOffer.DataBind();
        }
        ShowHideActions();
        if ((int)Convert.ToInt16(ds.Tables[5].Rows[0]["Status_Code"].ToString()) < (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.VerificationSchedulingDoneVerficationPending))
            return;
        aDocVerification.Visible = true;
    }

    private void CheckQueryString()
    {
        if (secQueryString == null)
            return;
        candidateCode = secQueryString["CID"].ToString();
        hdnCandidateCode.Value = secQueryString["CID"].ToString();
    }

    public void FileResponse(string filename, string FolderPath)
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

    #endregion

}