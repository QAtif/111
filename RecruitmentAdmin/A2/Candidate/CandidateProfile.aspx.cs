using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ErrorLog;
using System.Web.UI.HtmlControls;
using XRecruitmentStatusLibrary;
using System.IO;
using System.Drawing;
using SecureQueryStringLib;


public partial class A2_Candidate_CandidateProfile : CustomBasePage
{
    //SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    //SecureQueryString secQueryString;
    //SecureQueryString sQString = new SecureQueryString();
    //string QueryStringVar = string.Empty, CandidateCode = string.Empty;
    //string IsTest = "true";
    //string Domain_Address = ConfigurationManager.AppSettings["Domain_Address"].ToString();
    //int StatusCodeM;
    //DataSet CandidateDS = new DataSet();
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SecureQueryString sQString = new SecureQueryString();
    SecureQueryString secQueryString;
    string QueryStringVar = string.Empty;
    string CandidateCode = string.Empty;
    string IsTest = "true";
    DataSet CandidateDS = new DataSet();
    int StatusCodeM;
    string Domain_Address = ConfigurationManager.AppSettings["Domain_Address"].ToString();
    //ring QueryStringVar = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            secQueryString = new SecureQueryString(QueryStringVar);
            CandidateCode = secQueryString["CID"].ToString();
            if (!IsPostBack && !string.IsNullOrEmpty(CandidateCode))
            {
                BindCandidateDetail(CandidateCode);
                ShowHideActions();
            }
            string str = ConfigurationManager.AppSettings["WebDomainAddress"].ToString() + "AdminRedirector.aspx?";
            aEditExperience.Attributes.Add("data-rel", str + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("candidate_code=" + secQueryString["CID"].ToString() + "&url=Profile/Experience.aspx&utc=" + Convert.ToInt32(Constants.UserTypeCode.Admin) + "&auc=" + UserCode));
            aEditEducation.Attributes.Add("data-rel", str + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("candidate_code=" + secQueryString["CID"].ToString() + "&url=Profile/Education.aspx&utc=" + Convert.ToInt32(Constants.UserTypeCode.Admin) + "&auc=" + UserCode));
            aPortfolio.Attributes.Add("data-rel", str + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("candidate_code=" + secQueryString["CID"].ToString() + "&url=Profile/Portfolio.aspx&utc=" + Convert.ToInt32(Constants.UserTypeCode.Admin) + "&auc=" + UserCode));
            aDocuments.Attributes.Add("data-rel", str + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("candidate_code=" + secQueryString["CID"].ToString() + "&url=Profile/uploadDocuments.aspx&utc=" + Convert.ToInt32(Constants.UserTypeCode.Admin) + "&auc=" + UserCode));
            aDiploma.Attributes.Add("data-rel", str + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("candidate_code=" + secQueryString["CID"].ToString() + "&url=Profile/Diploma.aspx&utc=" + Convert.ToInt32(Constants.UserTypeCode.Admin) + "&auc=" + UserCode));
            aCertificate.Attributes.Add("data-rel", str + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("candidate_code=" + secQueryString["CID"].ToString() + "&url=Profile/Certificate.aspx&utc=" + Convert.ToInt32(Constants.UserTypeCode.Admin) + "&auc=" + UserCode));
            aFamily.Attributes.Add("data-rel", str + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("candidate_code=" + secQueryString["CID"].ToString() + "&url=Profile/Familydetails.aspx&utc=" + Convert.ToInt32(Constants.UserTypeCode.Admin) + "&auc=" + UserCode));
            lnkAddEditSkillSet.Attributes.Add("data-rel", str + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("candidate_code=" + secQueryString["CID"].ToString() + "&url=Profile/skillset.aspx&utc=" + Convert.ToInt32(Constants.UserTypeCode.Admin) + "&auc=" + UserCode));
            APersonalEdit.Attributes.Add("data-rel", str + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("candidate_code=" + secQueryString["CID"].ToString() + "&url=Profile/personaldetails.aspx&utc=" + Convert.ToInt32(Constants.UserTypeCode.Admin) + "&auc=" + UserCode));
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

    protected void Btn_SearchByRefno(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtRefNo.Text))
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            DataTable dataTable = new DataTable();
            using (SqlCommand selectCommand = new SqlCommand("dbo.xrec_Select_etIDByRefNo", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add(new SqlParameter("@RefNo", txtRefNo.Text));
                new SqlDataAdapter(selectCommand).Fill(dataTable);
            }
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            if (dataTable == null)
                return;
            if (dataTable.Rows.Count > 0)
            {
                CandidateCode = dataTable.Rows[0]["candidate_code"].ToString();
                Page.RegisterStartupScript("REFRESHpAGESCRIPT", "<script language=JavaScript>window.location='" + ("/A2/Candidate/CandidateProfile.aspx?data=" + new SecureQueryString().encrypt("CID=" + CandidateCode)) + "';</script>");
            }
            else
                Page.RegisterStartupScript("REFRESHpAGESCRIPT11", "<script language=JavaScript>alert('No candidate found.');</script>");
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

    protected void btnSaveContacts_Click(object sender, EventArgs e)
    {
        try
        {
            using (new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.XRec_UpdatePrimaryInformation", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@CandidateCode", CandidateCode);
                if (!string.IsNullOrEmpty(NewEmail.Value))
                    sqlCommand.Parameters.Add("@Email", NewEmail.Value);
                if (!string.IsNullOrEmpty(NewContact.Value))
                    sqlCommand.Parameters.Add("@Contact", NewContact.Value);
                sqlCommand.Parameters.Add("@UpdatedBy", UserCode);
                sqlCommand.Parameters.Add("@UpdatedIP", USERIP);
                sqlCommand.ExecuteNonQuery();
                InsertUserCommunicationComments("Manual Change Email and Mobile Number", "Personal Details");
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
                Page.RegisterStartupScript("Close", "<script language=JavaScript>window.location=window.location;</script>");
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

    protected void btn_SaveBrowsedImg(object sender, EventArgs e)
    {
        try
        {
            if (!fuPic.HasFile)
                return;
            string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + "Official/" + CandidateCode + "/";
            if (!fuPic.HasFile)
                return;
            GeneralMethods.FileBrowse(fuPic, FolderPath, "InitialPicture");
            string str = FolderPath + "InitialPicture" + Path.GetExtension(fuPic.FileName);
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateInitialPictatus", connection);
            sqlCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
            sqlCommand.Parameters.AddWithValue("@Path", str);
            sqlCommand.Parameters.AddWithValue("@InitialPicStatus", 1);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
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

    protected void rptOfficialDocuments_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            if (e.CommandArgument.ToString() != "4" && e.CommandArgument.ToString() != "9")
            {
                SqlCommand sqlCommand = new SqlCommand("dbo.XREC_Insert_ReGenerateOfficialLetter", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Candidate_Code", SqlDbType.Int).Value = e.CommandName;
                sqlCommand.Parameters.Add("@OfficialLetter_Code", SqlDbType.Int).Value = e.CommandArgument;
                sqlCommand.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UserCode;
                sqlCommand.Parameters.Add("@UpdationIP", SqlDbType.VarChar).Value = USERIP;               
                
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable != null && dataTable.Rows.Count > 0)
            { 
                if (dataTable.Rows[0]["status"].ToString() == "1")
                    ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Document will be uploaded in few mins!');", true);
                else
                    ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Not uploaded ! OPD Approval Pending!');", true);
            }

               // sqlCommand.ExecuteNonQuery();
               // ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Document will be uploaded in few mins!');", true);
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
                    string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + CandidateCode + "/Official/";
                    GeneralMethods.FileBrowse(control1, FolderPath, control2.Value + "-" + control4.Value);
                    string str = FolderPath + control2.Value + "-" + control4.Value + Path.GetExtension(control1.FileName);
                    SqlCommand sqlCommand = new SqlCommand("dbo.insert_Update_CandidateDocumentDigitalization", connection);
                    sqlCommand.Parameters.AddWithValue("@Candidate_Code", CandidateCode);
                    sqlCommand.Parameters.AddWithValue("@Document_Code", control4.Value);
                    if (control3.Value != "0" && control3.Value != "")
                        sqlCommand.Parameters.AddWithValue("@CandDoc_Code", control3.Value);
                    sqlCommand.Parameters.AddWithValue("@DocumentPath", str);
                    sqlCommand.Parameters.AddWithValue("@CandidateDocumentName", control2.Value);
                    sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
                    sqlCommand.Parameters.AddWithValue("@UpdatedIp", USERIP);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
                }
            }
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
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

    protected void rptOfficialDocuments_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem || !(DataBinder.Eval(e.Item.DataItem, "OfficialLetter_Code").ToString() == "4") && !(DataBinder.Eval(e.Item.DataItem, "OfficialLetter_Code").ToString() == "3") && !(DataBinder.Eval(e.Item.DataItem, "OfficialLetter_Code").ToString() == "9"))
                return;
            LinkButton control1 = (LinkButton)e.Item.FindControl("btnReserve");
            System.Web.UI.WebControls.Image control2 = (System.Web.UI.WebControls.Image)e.Item.FindControl("Image2");
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
                if (CandidateDS.Tables.Count >= 14 && CandidateDS.Tables[13].Rows.Count > 0)
                {
                    float length1 = (float)CandidateDS.Tables[13].Select("SectionCode=" + str2 + " and QuestionGroupCode=" + str1 + " and IsCorrect=1").Length;
                    float length2 = (float)CandidateDS.Tables[13].Select("SectionCode=" + str2 + " and QuestionGroupCode=" + str1 + " and IsCorrect=0").Length;
                    float length3 = (float)CandidateDS.Tables[13].Select("SectionCode=" + str2 + " and QuestionGroupCode=" + str1).Length;
                    float length4 = (float)CandidateDS.Tables[13].Select("SectionCode=" + str2 + " and QuestionGroupCode=" + str1 + " and IsCorrect is null").Length;
                    control1.Text = length1.ToString();
                    control2.Text = length2.ToString();
                    control3.Text = (length1 * 100f / length3).ToString() + "%";
                    control4.Text = length4.ToString();
                }
            }
            if (e.Item.ItemType != ListItemType.Footer || CandidateDS.Tables[11].Rows.Count <= 0)
                return;
            Label control6 = (Label)e.Item.FindControl("lblCorrecttot");
            Label control7 = (Label)e.Item.FindControl("lblWrongtot");
            Label control8 = (Label)e.Item.FindControl("lblTotaltot");
            Label control9 = (Label)e.Item.FindControl("lblPendingtot");
            control6.Text = CandidateDS.Tables[11].Rows[0]["Correct"].ToString();
            control7.Text = CandidateDS.Tables[11].Rows[0]["Wrong"].ToString();
            control8.Text = "";
            control9.Text = CandidateDS.Tables[11].Rows[0]["ResultPending"].ToString();
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
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void lnkMarkOfferDelivered_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtaOfferdelivered.InnerText))
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            if (fuOffer.HasFile)
            {
                if (string.IsNullOrEmpty(hdnDocumentCode.Value))
                    hdnDocumentCode.Value = "26";
                if (!string.IsNullOrEmpty(hdnDocName.Value) && !string.IsNullOrEmpty(hdnDocumentCode.Value))
                {
                    Path.GetExtension(fuOffer.FileName).ToLower();
                    string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + CandidateCode + "/Official/";
                    GeneralMethods.FileBrowse(fuOffer, FolderPath, hdnDocName.Value + "-" + hdnDocumentCode.Value);
                    string str = FolderPath + hdnDocName.Value + "-" + hdnDocumentCode.Value + Path.GetExtension(fuOffer.FileName);
                    SqlCommand sqlCommand = new SqlCommand("dbo.insert_Update_CandidateDocumentDigitalization", connection);
                    sqlCommand.Parameters.AddWithValue("@Candidate_Code", CandidateCode);
                    sqlCommand.Parameters.AddWithValue("@Document_Code", hdnDocumentCode.Value);
                    if (hdnCanDocCode.Value != "0" && hdnCanDocCode.Value != "")
                        sqlCommand.Parameters.AddWithValue("@CandDoc_Code", hdnCanDocCode.Value);
                    sqlCommand.Parameters.AddWithValue("@DocumentPath", str);
                    sqlCommand.Parameters.AddWithValue("@CandidateDocumentName", hdnDocName.Value);
                    sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
                    sqlCommand.Parameters.AddWithValue("@UpdatedIp", USERIP);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
                }
            }
            StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(CandidateCode), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.OfferDeliveredAcceptancePending, USERIP, UserCode);
            InsertUserOfferDeliveredComments();
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Saved Successfully!');", true);
            BindCandidateDetail(CandidateCode);
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
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
            {
                InsertUserOfferAcceptedComments(true);
                StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(CandidateCode), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.OfferAcceptedVerificationSchedulingPending, USERIP, UserCode);
                ClearCandidateAvailedSlots();
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Saved Successfully!');", true);
                BindCandidateDetail(CandidateCode);
            }
            else
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Please insert comments.');", true);
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
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
            if (connection.State != ConnectionState.Open)
                connection.Open();
            if (!string.IsNullOrEmpty(txtaAppointmentGeneration.InnerHtml))
            {
                SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateInterview", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(CandidateCode);
                sqlCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = UserCode;
                sqlCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = txtaAppointmentGeneration.InnerText;
                sqlCommand.Parameters.Add("@LifeCycleStatus", SqlDbType.Int).Value = Convert.ToInt32(Constants.CandidateLifeCycleStatus.AppointmentSchedulingDoneJoiningReportingPending);
                sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = UserCode;
                sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = USERIP;
                sqlCommand.ExecuteNonQuery();
            }
            InsertDocumentToGeneratePDF("CandidateAppointmentLetter", 2);
            BindCandidateDetail(CandidateCode);
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
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
            FileResponses(hdnOfferLetter.Value, ConfigurationManager.AppSettings["CandidateDocumentPath"].ToString() + Convert.ToInt32(CandidateCode) + "/OfferLetter/");
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
            sShortlist.Style.Add("display", "none");
            lnkShortlist.Text = "";
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Shortlisted Successfully!'); window.location=window.location;", true);
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
            sqlCommand.Parameters.Add("@Candidate_ID", SqlDbType.VarChar).Value = lblRefNo.Text;
            sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = UserCode;
            sqlCommand.Parameters.Add("@Updation_IP", SqlDbType.VarChar).Value = USERIP;
            sqlCommand.Parameters.Add("@JobRole_Code", SqlDbType.VarChar).Value = str;
            sqlCommand.Parameters.Add("@City_Name", SqlDbType.VarChar).Value = ddlCity.SelectedItem.Text;
            sqlCommand.Parameters.Add("@TeamLeaderCode", SqlDbType.Int).Value = ddlTL.SelectedValue;
            sqlCommand.Parameters.Add("@AssignedUser_Code", SqlDbType.Int).Value = ddlAssignUser.SelectedValue;
            sqlCommand.ExecuteNonQuery();
            BindCandidateDetail(CandidateCode);
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
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
            if (connection.State != ConnectionState.Open)
                connection.Open();
            InsertUserInterviewComments();
            if (txtDSalary.Text != "" && ddlStatement.SelectedValue != "-1")
                InsertUserInterviewCommentsOfferApproval();
            if (rdbPass.Checked && ddlGrade.SelectedValue != "-1" && ddlDesignation.SelectedValue != "-1")
            {
                StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(CandidateCode), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.InterviewDoneOfferGenerated, USERIP, UserCode);
                ClearCandidateAvailedSlots();
            }
            else if (rdbFail.Checked && ((IEnumerable<DataRow>)DTActions.Select("MenuLinkActionCode = 105")).Count<DataRow>() > 0)
            {
                StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(CandidateCode), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.InterviewFailedReSchedulingPending, USERIP, UserCode);
                ClearCandidateAvailedSlots();
            }
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Saved Successfully!'); window.location=window.location;", true);
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
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

    protected void lnkSkipStatus_click(object sender, EventArgs e)
    {
        try
        {
            StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(CandidateCode), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.VerificationSchedulingDoneVerficationPending, USERIP, UserCode);
            InsertUserCommunicationComments("Verification Schedulling Status Skip", "Status Skip");
            Page.RegisterStartupScript("REFRESHpAGESCRIPT", "<script language=JavaScript>window.location= window.location;</script>");
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

    protected void lnkNotJoin_click(object sender, EventArgs e)
    {
        try
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XREC_Update_CandidateStatusManual", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@StatusCode", Convert.ToInt32(Constants.CandidateLifeCycleStatus.OfferAcceptedJoiningNotDone));
            sqlCommand.Parameters.AddWithValue("@Comments", "Click on Not Join Button");
            sqlCommand.Parameters.AddWithValue("@UpdationIP", USERIP);
            sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
            sqlCommand.Parameters.AddWithValue("@Candidate_Code", CandidateCode);
            sqlCommand.ExecuteNonQuery();
            Page.RegisterStartupScript("REFRESHpAGESCRIPT", "<script language=JavaScript>window.location= window.location;</script>");
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

    protected void lnkEditDate_Click(object sender, EventArgs e)
    {
        try
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateJoiningDate", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(CandidateCode);
            sqlCommand.Parameters.Add("@JoiningDate", SqlDbType.DateTime).Value = Convert.ToDateTime(JoiningDate.Value);
            sqlCommand.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UserCode;
            sqlCommand.Parameters.Add("@UpdatedIp", SqlDbType.VarChar).Value = USERIP;
            sqlCommand.ExecuteNonQuery();
            BindCandidateDetail(CandidateCode);
            if (connection.State != ConnectionState.Closed)
                connection.Close();
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

    protected void lnkEdiDesignation_Click(object sender, EventArgs e)
    {
        try
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateDesignations", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(CandidateCode);
            sqlCommand.Parameters.Add("@DesignationCode", SqlDbType.Int).Value = ddlDesignationC.SelectedValue;
            sqlCommand.Parameters.Add("@GradeCode", SqlDbType.Int).Value = ddlgradeC.SelectedValue;
            sqlCommand.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UserCode;
            sqlCommand.Parameters.Add("@UpdatedIp", SqlDbType.VarChar).Value = USERIP;
            sqlCommand.ExecuteNonQuery();
            InsertUserCommunicationComments("Manual Change Designation and grade", "Designation Change");
            BindCandidateDetail(CandidateCode);
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Designation and Grade has been saved successfully!');", true);
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
            if (connection.State != ConnectionState.Open)
                connection.Open();
            if (!string.IsNullOrEmpty(txtaOfferGenerationPending.InnerHtml))
                InsertUserOfferGeneratedComments();
            InsertDocumentToGeneratePDF("Offer Letter", 1);
            StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(CandidateCode), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.OfferGeneratedSchedulingPending, USERIP, UserCode);
            BindCandidateDetail(CandidateCode);
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
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

    protected void lnkMarkOfferNotAccepted_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(txtaOfferAccepetance.InnerText))
                InsertUserOfferAcceptedComments(false);
            if (connection.State != ConnectionState.Open)
                connection.Open();
            StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(CandidateCode), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.OfferNotAcceptedReSchedulingPendingOffer, USERIP, UserCode);
            ClearCandidateAvailedSlots();
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Saved Successfully!');", true);
            BindCandidateDetail(CandidateCode);
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
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

    public void BindCandidateDetail(string CandCode)
    {
        try
        {
            string str1 = "0";
            string str2 = "0";
            string str3 = "0";
            aStatusChange.Attributes.Add("Data-rel", Domain_Address + "Candidate/UpdateCandidateInfo.aspx?" + SecureQueryString.QueryStringVar + "=" + secQueryString.encrypt("type=1&CID=" + CandCode));
            aProfileChange.Attributes.Add("Data-rel", Domain_Address + "Candidate/UpdateCandidateInfo.aspx?" + SecureQueryString.QueryStringVar + "=" + secQueryString.encrypt("type=2&CID=" + CandCode));
            aRequisitionChange.Attributes.Add("Data-rel", Domain_Address + "Candidate/UpdateCandidateInfo.aspx?" + SecureQueryString.QueryStringVar + "=" + secQueryString.encrypt("type=3&CID=" + CandCode));
            aEditProfile.Attributes.Add("Data-rel", Domain_Address + "Candidate/UpdateCandidateProfileInfo.aspx?" + SecureQueryString.QueryStringVar + "=" + secQueryString.encrypt("type=3&CID=" + CandCode));
            aDocVerification.Attributes.Add("Data-rel", Domain_Address + "candidate/CandidateDocumentVerification.aspx?" + SecureQueryString.QueryStringVar + "=" + secQueryString.encrypt("CID=" + CandCode));
            aAppHistory.Attributes.Add("Data-rel", Domain_Address + "Candidate/CandidateApplication.aspx?" + SecureQueryString.QueryStringVar + "=" + secQueryString.encrypt("CID=" + CandCode));
            SqlCommand selectCommand = new SqlCommand("dbo.XRec_SelectCandidateDetail", connection);
            selectCommand.Parameters.AddWithValue("@Candidate_Code", CandCode);
            selectCommand.CommandType = CommandType.StoredProcedure;
            new SqlDataAdapter(selectCommand).Fill(CandidateDS);
            if (CandidateDS != null && CandidateDS.Tables.Count >= 1 && CandidateDS.Tables[0].Rows.Count > 0)
            {
                lblCanName.Text = CandidateDS.Tables[0].Rows[0]["full_name"].ToString();
                lblEmailAddress.Text = CandidateDS.Tables[0].Rows[0]["email_address"].ToString();
                lblGender.Text = CandidateDS.Tables[0].Rows[0]["gender"].ToString();
                lblMaritalStatus.Text = CandidateDS.Tables[0].Rows[0]["maritalstatus"].ToString();
                lblDOB.Text = CandidateDS.Tables[0].Rows[0]["DateOf_Birth"].ToString();
                lblAddress.Text = CandidateDS.Tables[0].Rows[0]["Address"].ToString();
                lblNIC.Text = CandidateDS.Tables[0].Rows[0]["NIC"].ToString();
                lblApplyDate.Text = CandidateDS.Tables[0].Rows[0]["ApplyDate"].ToString();
                lblRefferal.Text = CandidateDS.Tables[0].Rows[0]["Referral"].ToString();
                lblRefNo.Text = CandidateDS.Tables[0].Rows[0]["Candidate_ID"].ToString();
                lblReligion.Text = CandidateDS.Tables[0].Rows[0]["religion"].ToString();
                lblNationality.Text = CandidateDS.Tables[0].Rows[0]["Nationality"].ToString();
                SpShit.InnerHtml = CandidateDS.Tables[0].Rows[0]["AvailbilityShift"].ToString();
                SPMobile.InnerHtml = CandidateDS.Tables[0].Rows[0]["Home_Number"].ToString();
                imgCandidate.Src = CandidateDS.Tables[0].Rows[0]["PicPath"].ToString();
                txtEmailCandidate.Text = CandidateDS.Tables[0].Rows[0]["email_address"].ToString();
                txtMobileCandidate.Text = CandidateDS.Tables[0].Rows[0]["Phone_Number"].ToString();
                NewEmail.Value = CandidateDS.Tables[0].Rows[0]["email_address"].ToString();
                NewContact.Value = CandidateDS.Tables[0].Rows[0]["Phone_Number"].ToString();
                lblHeight.Text = CandidateDS.Tables[0].Rows[0]["Height"].ToString();
                lblExpectedSal.Text = CandidateDS.Tables[0].Rows[0]["ExpectedSalary"].ToString();
                lblWeight.Text = CandidateDS.Tables[0].Rows[0]["Weight"].ToString();
                str1 = CandidateDS.Tables[0].Rows[0]["Is_Staff"].ToString();
                if (!string.IsNullOrEmpty(CandidateDS.Tables[0].Rows[0]["PortalReferral"].ToString()))
                    lblPortalReferral.Text = CandidateDS.Tables[0].Rows[0]["PortalReferral"].ToString();
                else
                    trPRef.Style.Add("display", "none");
                imgBigImage.Src = CandidateDS.Tables[0].Rows[0]["PicPath"].ToString();
                lblTotalExp.Text = CandidateDS.Tables[0].Rows[0]["TotalExp"].ToString();
                ABigImage.Attributes.Add("data-rel", CandidateDS.Tables[0].Rows[0]["PicPath"].ToString());
                lblIsLinkedin.Text = CandidateDS.Tables[0].Rows[0]["IsLinkedin"].ToString();
                if (lblIsLinkedin.Text == "No")
                    trLink.Style.Add("display", "none");
                lblOldStatus.Text = CandidateDS.Tables[0].Rows[0]["OldStatus"].ToString();
                if (lblOldStatus.Text == "No")
                    trOldStatus.Style.Add("display", "none");
                lblRefferalUrl.Text = CandidateDS.Tables[0].Rows[0]["referralurl"].ToString();
                if (lblRefferalUrl.Text == "-")
                    trReferralUrl.Style.Add("display", "none");
                lblIsMigrated.Text = CandidateDS.Tables[0].Rows[0]["IsMigrated"].ToString();
                if (lblIsMigrated.Text == "No")
                    trMigrated.Style.Add("display", "none");
                if (!string.IsNullOrEmpty(CandidateDS.Tables[0].Rows[0]["Resume_Path"].ToString()))
                    lnkbtnCV.HRef = CandidateDS.Tables[0].Rows[0]["Resume_Path"].ToString();
                else
                    lnkbtnCV.Visible = false;
                if (CandidateDS.Tables[0].Rows[0]["Is_Redundent"].ToString() == "0")
                {
                    imgNICNotVerified.Visible = false;
                }
                else
                {
                    tdNic.Style.Add("Background-color", "#FFD9D9 !important");
                    tdNic.Style.Add("border", "2px solid #F00 !important");
                    lblNIC.Style.Add("text-shadow", "2px 2px 2px #ebebeb !important");
                }
                if ((bool)CandidateDS.Tables[0].Rows[0]["Is_EmailVerified"])
                {
                    imgEmailNotVerified.Visible = false;
                    lblemailverificationCode.Visible = false;
                }
                else
                {
                    lblemailverificationCode.Visible = true;
                    lblemailverificationCode.Text = CandidateDS.Tables[0].Rows[0]["emailVerificationCode"].ToString();
                    tdEmil.Style.Add("Background-color", "#FFD9D9");
                    tdEmil.Style.Add("border", "2px solid #F00");
                    lblemailverificationCode.Style.Add("text-shadow", "2px 2px 2px #ebebeb");
                    lblemailverificationCode.Style.Add("color", "#999");
                }
                if ((bool)CandidateDS.Tables[0].Rows[0]["is_PhoneVerified"])
                {
                    imgPhoneNotVerified.Visible = false;
                    lblPhoneVerificationCode.Visible = false;
                }
                else
                {
                    lblPhoneVerificationCode.Visible = true;
                    lblPhoneVerificationCode.Text = CandidateDS.Tables[0].Rows[0]["PhoneVerification_Code"].ToString();
                    tdPhone.Style.Add("Background-color", "#FFD9D9");
                    tdPhone.Style.Add("border", "2px solid #F00");
                    lblPhoneVerificationCode.Style.Add("text-shadow", "2px 2px 2px #ebebeb");
                }
            }
            int num = 0;
            if (CandidateDS.Tables.Count >= 6)
            {
                if (CandidateDS.Tables[5].Rows.Count > 0)
                {
                    SpCurrentStatus.InnerText = CandidateDS.Tables[5].Rows[0]["Status_Name"].ToString();
                    SpProfile.InnerText = CandidateDS.Tables[5].Rows[0]["Profile_Name"].ToString();
                    SpRequisition.InnerText = CandidateDS.Tables[5].Rows[0]["Requisition_Name"].ToString();
                    SpDomain.InnerText = CandidateDS.Tables[5].Rows[0]["Domain_name"].ToString();
                    SpSubDomain.InnerText = CandidateDS.Tables[5].Rows[0]["SubDomain_Name"].ToString();
                    SpRA.InnerText = CandidateDS.Tables[5].Rows[0]["RAName"].ToString();
                    SPGL.InnerText = CandidateDS.Tables[5].Rows[0]["GroupLeader"].ToString();
                    SPL.InnerText = CandidateDS.Tables[5].Rows[0]["TeamLeader"].ToString();
                    SPTeam.InnerText = CandidateDS.Tables[5].Rows[0]["TeamName"].ToString();
                    SPBU.InnerText = CandidateDS.Tables[5].Rows[0]["Unit"].ToString();
                    SpJoiningDate.InnerText = CandidateDS.Tables[5].Rows[0]["Joining_Date"].ToString() + "  " + CandidateDS.Tables[5].Rows[0]["Scheduling_Joining_Time"].ToString();
                    if (CandidateDS.Tables[5].Rows[0]["Joining_Date"].ToString() == "-")
                        JoiningDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
                    else
                        JoiningDate.Value = CandidateDS.Tables[5].Rows[0]["Joining_Date"].ToString();
                    SpDesignation.InnerText = CandidateDS.Tables[5].Rows[0]["Designation_Name"].ToString();
                    SpGrade.InnerText = CandidateDS.Tables[5].Rows[0]["Grade_Name"].ToString();
                    SpCategory.InnerText = CandidateDS.Tables[5].Rows[0]["Category_Name"].ToString();
                    str2 = CandidateDS.Tables[5].Rows[0]["TestCode"].ToString();
                    str3 = CandidateDS.Tables[5].Rows[0]["IsStaffDomain"].ToString();
                    if (CandidateDS.Tables[5].Rows[0]["Grade_Name"].ToString() != "-" && CandidateDS.Tables[5].Rows[0]["Designation_Name"].ToString() != "-")
                        aEditDesignation.Style.Add("display", "");
                    else
                        aEditDesignation.Style.Add("display", "none");
                    if (CandidateDS.Tables[5].Rows[0]["is_shift"].ToString() == "1")
                        trShifts.Style.Add("display", "");
                    if (CandidateDS.Tables[5].Rows[0]["is_height"].ToString() == "1")
                    {
                        trHeight.Style.Add("display", "");
                        trWeight.Style.Add("display", "");
                    }

                    if (int.Parse(CandidateDS.Tables[5].Rows[0]["CategoryType"].ToString()) == 6)
                        trFixedSalary.Style.Add("display", "");
                    else
                        trFixedSalary.Style.Add("display", "none");

                }
                ViewState["CurrentRefNo"] = CandidateDS.Tables[5].Rows[0]["Candidate_ID"].ToString();
                num = Convert.ToInt32(CandidateDS.Tables[5].Rows[0]["Status_Code"]);
                StatusCodeM = Convert.ToInt32(CandidateDS.Tables[5].Rows[0]["Status_Code"]);
                IsTest = CandidateDS.Tables[5].Rows[0]["Is_Test"].ToString();
                if (Convert.ToInt32(CandidateDS.Tables[5].Rows[0]["AppCount"]) > 1)
                    aAppHistory.Visible = true;
                else
                    aAppHistory.Visible = false;
                if (!(bool)CandidateDS.Tables[5].Rows[0]["Is_locked"] && SpRequisition.InnerHtml != "-")
                {
                    sShortlist.Style.Add("display", "");
                    lnkShortlist.Text = "Shortlist";
                }
                else
                {
                    sShortlist.Style.Add("display", "none");
                    lnkShortlist.Text = "";
                }
            }
            if (num != 0)
            {
                if (num >= (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.VerificationSchedulingDoneVerficationPending))
                    aDocVerification.Visible = true;
                if (num == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferAcceptedVerificationSchedulingPending))
                    aSkipSchedule.Style.Add("display", "");
                else
                    aSkipSchedule.Style.Add("display", "none");
                if (num == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferAcceptedVerificationSchedulingPending) || num == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.VerificationSchedulingDoneVerficationPending) || (num == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.VerificationDoneAppointmentSchedulingPending) || num == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.AppointmentSchedulingDoneJoiningReportingPending)))
                    lnkNotJoin.Style.Add("display", "");
                else
                    lnkNotJoin.Style.Add("display", "none");
                if (num >= (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferAcceptedVerificationSchedulingPending))
                    aEditDate.Visible = true;
                else
                    aEditDate.Visible = false;
                if (num <= (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.SignupdoneFormPending))
                {
                    aProfileChange.Visible = false;
                    aRequisitionChange.Visible = false;
                }
                else
                {
                    aRequisitionChange.Visible = false;
                    aProfileChange.Visible = true;
                }
                if (num >= (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.PositionMappedWaitingforPositionopening) && CandidateDS.Tables[5].Rows[0]["ReqCount"].ToString() != "0")
                    aRequisitionChange.Visible = true;
                else
                    aRequisitionChange.Visible = false;
                if (CandidateDS.Tables[5].Rows[0]["ReqCount"].ToString() == "0" && num >= (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.PositionMappedWaitingforPositionopening))
                    SpRequisition.InnerText = "No requisition mapped on selected Profile";
                else
                    SpCurrentStatus.InnerHtml = CandidateDS.Tables[5].Rows[0]["Status_Name"].ToString();
                ViewState["CurrentStatusCode"] = num;
                if (num == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.ShortlistedSchedulingPendingTest) || num == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.TestFailedReSchedulingPendingTest) || num == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.TestnotAppearedReSchedulingPending))
                {
                    sSchedule.Style.Add("display", "");
                    aSchedule.InnerHtml = "Schedule For Test";
                    aSchedule.Attributes.Add("Data-rel", Domain_Address + "schedule/SchduleCandidate.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("refno=" + ViewState["CurrentRefNo"].ToString() + "&pgno=1"));
                }
                else if (num == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.TestPassedSchedulingPendingInterview) || num == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.NoTestSchedulingPendingInterview) || (num == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.InterviewFailedReSchedulingPending) || num == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.InterviewnotAppearedReSchedulingPending)))
                {
                    sSchedule.Style.Add("display", "");
                    aSchedule.InnerHtml = "Schedule For Interview";
                    aSchedule.Attributes.Add("Data-rel", Domain_Address + "schedule/SchduleCandidate.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("refno=" + ViewState["CurrentRefNo"].ToString() + "&pgno=1"));
                }
                else if (num == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferGeneratedSchedulingPending) || num == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferNotAcceptedReSchedulingPendingOffer) || num == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferAcceptedJoiningNotDone))
                {
                    sSchedule.Style.Add("display", "");
                    aSchedule.InnerHtml = "Schedule For Offer";
                    aSchedule.Attributes.Add("Data-rel", Domain_Address + "schedule/SchduleCandidate.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("refno=" + ViewState["CurrentRefNo"].ToString() + "&pgno=1"));
                }
                else if (num == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.OfferAcceptedVerificationSchedulingPending))
                {
                    sSchedule.Style.Add("display", "");
                    aSchedule.InnerHtml = "Schedule For Verification";
                    aSchedule.Attributes.Add("Data-rel", Domain_Address + "schedule/SchduleCandidate.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("refno=" + ViewState["CurrentRefNo"].ToString() + "&pgno=1"));
                }
                else if (num == (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.VerificationDoneAppointmentSchedulingPending))
                {
                    sSchedule.Style.Add("display", "");
                    aSchedule.InnerHtml = "Schedule For Appointment";
                    aSchedule.Attributes.Add("Data-rel", Domain_Address + "schedule/SchduleCandidate.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("refno=" + ViewState["CurrentRefNo"].ToString() + "&pgno=1"));
                }
                else
                {
                    sSchedule.Style.Add("display", "none");
                    aSchedule.InnerHtml = "";
                    aSchedule.HRef = "Javascript:;";
                }
                if (num >= (int)Convert.ToInt16(Constants.CandidateLifeCycleStatus.SchedulingDoneInterviewPending))
                {
                    if (str3 != "False" && str2 != "0")
                    {
                        DivStaffAction.Visible = true;
                        aMarkStaffTest.Attributes.Add("href", Domain_Address + "A2/SupportStaff/Assessment.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("TC=" + str2 + "&CC=" + CandidateCode));
                    }
                    else
                        DivStaffAction.Visible = false;
                }
            }
            else
                ViewState["CurrentStatusCode"] = "0";
            if (CandidateDS.Tables.Count >= 2)
            {
                if (CandidateDS.Tables[1].Rows.Count > 0)
                {
                    rptExperience.DataSource = CandidateDS.Tables[1];
                    rptExperience.DataBind();
                    lblinfoExp.Visible = false;
                }
                else
                {
                    lblinfoExp.Visible = true;
                    rptExperience.DataSource = null;
                    rptExperience.DataBind();
                }
            }
            if (CandidateDS.Tables.Count >= 3)
            {
                DataView dataView1 = new DataView(CandidateDS.Tables[2]);
                dataView1.RowFilter = "Program_Code <> 7 and Program_Code <> 6";
                if (dataView1.Count > 0)
                {
                    lblinfoEdu.Visible = false;
                    rptEducation.DataSource = dataView1;
                    rptEducation.DataBind();
                }
                else
                {
                    lblinfoEdu.Visible = true;
                    rptEducation.DataSource = null;
                    rptEducation.DataBind();
                }
                DataView dataView2 = new DataView(CandidateDS.Tables[2]);
                dataView2.RowFilter = "Program_Code =6";
                if (dataView2.Count > 0)
                {
                    lblinfoDiploma.Visible = false;
                    rptDiploma.DataSource = dataView2;
                    rptDiploma.DataBind();
                }
                else
                {
                    lblinfoDiploma.Visible = true;
                    rptDiploma.DataSource = null;
                    rptDiploma.DataBind();
                }
                DataView dataView3 = new DataView(CandidateDS.Tables[2]);
                dataView3.RowFilter = "Program_Code =7";
                if (dataView3.Count > 0)
                {
                    lblinfoCertificate.Visible = false;
                    rptCertificate.DataSource = dataView3;
                    rptCertificate.DataBind();
                }
                else
                {
                    lblinfoCertificate.Visible = true;
                    rptCertificate.DataSource = null;
                    rptCertificate.DataBind();
                }
            }
            if (CandidateDS.Tables.Count >= 7)
            {
                if (CandidateDS.Tables[6].Rows.Count > 0)
                {
                    lblinfoFamily.Visible = false;
                    rptFamily.DataSource = CandidateDS.Tables[6];
                    rptFamily.DataBind();
                }
                else
                {
                    lblinfoFamily.Visible = true;
                    rptFamily.DataSource = null;
                    rptFamily.DataBind();
                }
            }
            if (CandidateDS.Tables.Count >= 20)
            {
                if (CandidateDS.Tables[19].Rows.Count > 0)
                {
                    rptPortfolioFiles.DataSource = CandidateDS.Tables[19];
                    rptPortfolioFiles.DataBind();
                    lblPortFiles.Visible = false;
                }
                else
                {
                    rptPortfolioFiles.DataSource = null;
                    rptPortfolioFiles.DataBind();
                    lblPortFiles.Visible = true;
                }
            }
            if (CandidateDS.Tables.Count >= 21)
            {
                if (CandidateDS.Tables[20].Rows.Count > 0)
                {
                    rptPortfolioUrl.DataSource = CandidateDS.Tables[20];
                    rptPortfolioUrl.DataBind();
                    lblPortURL.Visible = false;
                }
                else
                {
                    lblPortURL.Visible = true;
                    rptPortfolioUrl.DataSource = null;
                    rptPortfolioUrl.DataBind();
                }
            }
            if (CandidateDS.Tables.Count >= 5)
            {
                DataView dataView1 = new DataView(CandidateDS.Tables[4]);
                dataView1.RowFilter = "DocType_Code = 9";
                dataView1.Sort = "CandidateDocumentName,document_name ASC";
                if (dataView1.Count > 0)
                {
                    rptDocsExperience.DataSource = dataView1;
                    rptDocsExperience.DataBind();
                    lblDocProfessional.Visible = false;
                }
                else
                {
                    lblDocProfessional.Visible = true;
                    rptDocsExperience.DataSource = null;
                    rptDocsExperience.DataBind();
                }
                DataView dataView2 = new DataView(CandidateDS.Tables[4]);
                dataView2.RowFilter = "DocType_Code =1";
                if (dataView2.Count > 0)
                {
                    rptDocPersonal.DataSource = dataView2;
                    rptDocPersonal.DataBind();
                    lblDocPersonal.Visible = false;
                }
                else
                {
                    lblDocPersonal.Visible = true;
                    rptDocPersonal.DataSource = null;
                    rptDocPersonal.DataBind();
                }
                DataView dataView3 = new DataView(CandidateDS.Tables[4]);
                dataView3.RowFilter = "DocType_Code <> 9 and DocType_Code <> 1 and DocType_Code <> 7 and DocType_Code <> 8 and DocType_Code <> 13";
                dataView3.Sort = "CandidateDocumentName,document_name ASC";
                if (dataView3.Count > 0)
                {
                    rptDocsEducation.DataSource = dataView3;
                    rptDocsEducation.DataBind();
                    lbldocEducation.Visible = false;
                }
                else
                {
                    lbldocEducation.Visible = true;
                    rptDocsEducation.DataSource = null;
                    rptDocsEducation.DataBind();
                }
                DataView dataView4 = new DataView(CandidateDS.Tables[4]);
                dataView4.RowFilter = "DocType_Code =8 ";
                dataView4.Sort = "CandidateDocumentName ASC";
                if (dataView4.Count > 0)
                {
                    rptDocCertificate.DataSource = dataView4;
                    rptDocCertificate.DataBind();
                    lbldocCertificate.Visible = false;
                }
                else
                {
                    lbldocCertificate.Visible = true;
                    rptDocCertificate.DataSource = null;
                    rptDocCertificate.DataBind();
                }
                DataView dataView5 = new DataView(CandidateDS.Tables[4]);
                dataView5.RowFilter = "DocType_Code =7 ";
                dataView5.Sort = "CandidateDocumentName ASC";
                if (dataView5.Count > 0)
                {
                    rptDocDiploma.DataSource = dataView5;
                    rptDocDiploma.DataBind();
                    lblDocDiploma.Visible = false;
                }
                else
                {
                    lblDocDiploma.Visible = true;
                    rptDocDiploma.DataSource = null;
                    rptDocDiploma.DataBind();
                }
                DataView dataView6 = new DataView(CandidateDS.Tables[4]);
                dataView6.RowFilter = "DocType_Code =13 ";
                if (dataView6.Count > 0)
                {
                    rptHiredDocs.DataSource = dataView6;
                    rptHiredDocs.DataBind();
                    lblHiredError.Visible = false;
                }
                else
                {
                    lblHiredError.Visible = true;
                    rptHiredDocs.DataSource = null;
                    rptHiredDocs.DataBind();
                }
            }
            if (CandidateDS.Tables.Count >= 17)
            {
                if (CandidateDS.Tables[16].Rows.Count > 0)
                {
                    rptScheduleHistory.DataSource = CandidateDS.Tables[16];
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
            }
            if (CandidateDS.Tables.Count >= 8)
            {
                if (CandidateDS.Tables[9] != null && CandidateDS.Tables[9].Rows.Count > 0)
                {
                    ddlGrade.DataSource = CandidateDS.Tables[9];
                    ddlGrade.DataTextField = "Grade_Name";
                    ddlGrade.DataValueField = "Grade_Code";
                    ddlGrade.DataBind();
                    ddlgradeC.DataSource = CandidateDS.Tables[9];
                    ddlgradeC.DataTextField = "Grade_Name";
                    ddlgradeC.DataValueField = "Grade_Code";
                    ddlgradeC.DataBind();
                    if (CandidateDS.Tables[5].Rows[0]["Grade_Name"].ToString() != "-")
                    {
                        if (ddlgradeC.SelectedIndex >= 0)
                            ddlgradeC.Items[ddlgradeC.SelectedIndex].Selected = false;
                        if (CandidateDS.Tables[5].Rows[0]["Grade_Name"] != null && ddlgradeC.Items.FindByText(CandidateDS.Tables[5].Rows[0]["Grade_Name"].ToString()) != null)
                            ddlgradeC.Items.FindByText(CandidateDS.Tables[5].Rows[0]["Grade_Name"].ToString()).Selected = true;
                    }
                }
                ddlGrade.Items.Insert(0, new ListItem("--Grade--", "-1"));
                ddlgradeC.Items.Insert(0, new ListItem("--Grade--", "-1"));
                if (CandidateDS.Tables[10] != null && CandidateDS.Tables[10].Rows.Count > 0)
                {
                    ddlDesignation.DataSource = CandidateDS.Tables[10];
                    ddlDesignation.DataTextField = "Designation_Name";
                    ddlDesignation.DataValueField = "Designation_Code";
                    ddlDesignation.DataBind();
                    ddlDesignationC.DataSource = CandidateDS.Tables[10];
                    ddlDesignationC.DataTextField = "Designation_Name";
                    ddlDesignationC.DataValueField = "Designation_Code";
                    ddlDesignationC.DataBind();
                    if (CandidateDS.Tables[5].Rows[0]["Designation_Name"].ToString() != "-")
                    {
                        if (ddlDesignationC.SelectedIndex >= 0)
                            ddlDesignationC.Items[ddlDesignationC.SelectedIndex].Selected = false;
                        if (ddlDesignationC.Items.FindByText(CandidateDS.Tables[5].Rows[0]["Designation_Name"].ToString()) != null)
                            ddlDesignationC.Items.FindByText(CandidateDS.Tables[5].Rows[0]["Designation_Name"].ToString()).Selected = true;
                    }
                }
                ddlDesignation.Items.Insert(0, new ListItem("--Designation--", "-1"));
                ddlDesignationC.Items.Insert(0, new ListItem("--Designation--", "-1"));
            }
            if (CandidateDS.Tables.Count >= 15 && CandidateDS.Tables[14] != null && CandidateDS.Tables[14].Rows.Count > 0)
            {
                ddlRA.DataSource = CandidateDS.Tables[14];
                ddlRA.DataTextField = "RA_Name";
                ddlRA.DataValueField = "RA_Code";
                ddlRA.DataBind();
            }
            if (CandidateDS.Tables[23] != null && CandidateDS.Tables[23].Rows.Count > 0)
            {
                ddlTL.DataSource = CandidateDS.Tables[23];
                ddlTL.DataTextField = "TL_Name";
                ddlTL.DataValueField = "TL_Code";
                ddlTL.DataBind();
                ddlTL1.DataSource = CandidateDS.Tables[23];
                ddlTL1.DataTextField = "TL_Name";
                ddlTL1.DataValueField = "TL_Code";
                ddlTL1.DataBind();
            }
            if (CandidateDS.Tables[22] != null && CandidateDS.Tables[22].Rows.Count > 0)
            {
                ddlGL.DataSource = CandidateDS.Tables[22];
                ddlGL.DataTextField = "GL_Name";
                ddlGL.DataValueField = "GL_Code";
                ddlGL.DataBind();
            }
            if (CandidateDS.Tables[24] != null && CandidateDS.Tables[24].Rows.Count > 0)
            {
                ddlAssignUser.DataSource = CandidateDS.Tables[24];
                ddlAssignUser.DataTextField = "AssignUser_Name";
                ddlAssignUser.DataValueField = "AssignUser_Code";
                ddlAssignUser.DataBind();
            }
            ddlRA.Items.Insert(0, new ListItem("--Reporting Authority--", "-1"));
            ddlTL.Items.Insert(0, new ListItem("--Team Leader--", "-1"));
            ddlTL1.Items.Insert(0, new ListItem("--Team Leader--", "-1"));
            ddlGL.Items.Insert(0, new ListItem("--Group Leader--", "-1"));
            ddlAssignUser.Items.Insert(0, new ListItem("--Assign User--", "-1"));
            ListItem byValue = ddlTL.Items.FindByValue(CandidateDS.Tables[5].Rows[0]["TeamLeaderCode"].ToString());
            if (byValue != null)
                ddlTL.SelectedValue = byValue.Value;
            if (CandidateDS.Tables.Count >= 13)
            {
                if (CandidateDS.Tables[12].Rows.Count > 0)
                {
                    rptQuestionGroup.DataSource = CandidateDS.Tables[12];
                    rptQuestionGroup.DataBind();
                    alnkChktest.Attributes.Add("href", Domain_Address + "assessment/checktest.aspx?cid=" + CandidateCode);
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
            }
            if (CandidateDS.Tables.Count >= 4)
            {
                if (CandidateDS.Tables[3].Rows.Count > 0)
                {
                    lblSkill.Visible = false;
                    rptSkills.DataSource = CandidateDS.Tables[3];
                    rptSkills.DataBind();
                }
                else
                {
                    lblSkill.Visible = true;
                    rptSkills.DataSource = null;
                    rptSkills.DataBind();
                }
            }
            if (CandidateDS.Tables.Count > 9)
            {
                if (CandidateDS.Tables[8] != null && CandidateDS.Tables[8].Rows.Count > 0)
                {
                    lblMsgCommu.Visible = false;
                    rptCommunication.DataSource = CandidateDS.Tables[8];
                    rptCommunication.DataBind();
                }
                else
                {
                    lblMsgCommu.Visible = true;
                    rptCommunication.DataSource = null;
                    rptCommunication.DataBind();
                }
            }
            if (CandidateDS.Tables[17].Rows.Count > 0)
            {
                rptOfficialDocuments.DataSource = CandidateDS.Tables[17];
                rptOfficialDocuments.DataBind();
                DataView dataView = new DataView(CandidateDS.Tables[17]);
                dataView.RowFilter = "document_code=26 or CandidateDocumentName='Offer Letter Audio'";
                if (dataView != null && dataView.Count > 0)
                {
                    hdnDocName.Value = dataView[0].Row["CandidateDocumentName"].ToString();
                    hdnCanDocCode.Value = dataView[0].Row["CandDocCode"].ToString();
                    hdnDocumentCode.Value = dataView[0].Row["Document_Code"].ToString();
                }
            }
            if (CandidateDS.Tables.Count >= 19)
            {
                if (CandidateDS.Tables[18] != null && CandidateDS.Tables[18].Rows.Count > 0)
                {
                    rptOffer.DataSource = CandidateDS.Tables[18];
                    rptOffer.DataBind();
                    lblOffer.Text = "";
                }
                else
                {
                    lblOffer.Text = "No record(s) found";
                    rptOffer.DataSource = null;
                    rptOffer.DataBind();
                }
            }
            if (CandidateDS.Tables.Count >= 22 && CandidateDS.Tables[21] != null && (CandidateDS.Tables[21].Rows.Count > 0 && CandidateDS.Tables[21].Rows[0]["isPortalRequest"].ToString() == "True"))
                divAction109.Style.Add("display", "none");
            if (str1 == "1" || str3 == "True")
            {
                imgStaff.Visible = true;
                trAssignUsers.Style["display"] = "";
            }
            else
            {
                imgStaff.Visible = false;
                trAssignUsers.Style["display"] = "none";
            }
            if (CandidateDS.Tables.Count >= 26 && CandidateDS.Tables[25].Rows.Count > 0)
            {
                ddlJD.DataSource = CandidateDS.Tables[25];
                ddlJD.DataTextField = "JDName";
                ddlJD.DataValueField = "ID";
                ddlJD.DataBind();
            }
            ddlJD.Items.Insert(0, new ListItem("--Team--", "-1"));
            if (CandidateDS.Tables.Count >= 27 && CandidateDS.Tables[26].Rows.Count > 0)
            {
                ddlBU.DataSource = CandidateDS.Tables[26];
                ddlBU.DataTextField = "BU_Name";
                ddlBU.DataValueField = "BU_Code";
                ddlBU.DataBind();
            }
            ddlBU.Items.Insert(0, new ListItem("--BU--", "-1"));
            if (CandidateDS.Tables.Count >= 28 && CandidateDS.Tables[27].Rows.Count > 0)
            {
                if (CandidateDS.Tables[27].Rows[0]["IsNICVerified"].ToString() == "false")
                {
                    lnkCreatePortal.Visible = false;
                    lblNicverified.Visible = true;
                }
                else
                {
                    lnkCreatePortal.Visible = true;
                    lblNicverified.Visible = false;
                }
            }
            if (CandidateDS.Tables.Count >= 29 && CandidateDS.Tables[28].Rows.Count > 0)
            {
                ddlLeagueType.DataSource = CandidateDS.Tables[28];
                ddlLeagueType.DataTextField = "League_Description";
                ddlLeagueType.DataValueField = "League_code";
                ddlLeagueType.DataBind();
            }
            CheckDivs();
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

    public void GetCandidateHistory()
    {
        if (string.IsNullOrEmpty(CandidateCode))
            return;
        SqlCommand selectCommand = new SqlCommand("Xrec_Select_Candidatehistory", connection);
        selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
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
                tblExpHistory.Visible = true;
                rptCandidateExHistory.DataSource = dataSet.Tables[1];
                rptCandidateExHistory.DataBind();
            }
            else
            {
                tblExpHistory.Visible = false;
                rptCandidateExHistory.DataSource = null;
                rptCandidateExHistory.Visible = false;
            }
        }
        if (dataSet.Tables.Count < 3)
            return;
        if (dataSet.Tables[2].Rows.Count > 0)
        {
            trQaHistory.Visible = true;
            rptQaHistory.DataSource = dataSet.Tables[2];
            rptQaHistory.DataBind();
        }
        else
        {
            trQaHistory.Visible = false;
            rptQaHistory.DataSource = null;
            rptQaHistory.Visible = false;
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
            SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateInterview", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(CandidateCode);
            sqlCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = UserCode;
            sqlCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = txtaOfferAccepetance.InnerText;
            sqlCommand.Parameters.Add("@LifeCycleStatus", SqlDbType.Int).Value = Convert.ToInt32(Constants.CandidateLifeCycleStatus.OfferDeliveredAcceptancePending);
            if (ddlGrade.SelectedValue != "-1")
                sqlCommand.Parameters.Add("@GradeCode", SqlDbType.Int).Value = ddlGrade.SelectedValue;
            sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = UserCode;
            sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = USERIP;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            sqlCommand.ExecuteNonQuery();
            if (check)
                InsertExpectedDateOfJoining();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
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

    public void InsertDocumentToGeneratePDF(string DocumentName, int offerLetterCode)
    {
        try
        {
            SqlCommand sqlCommand = new SqlCommand("dbo.Insert_CandidateOfficialDocumentForMarkingPDF", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(CandidateCode);
            sqlCommand.Parameters.Add("@CandidateDocumentName", SqlDbType.VarChar).Value = DocumentName;
            sqlCommand.Parameters.Add("@OfficialLetter_Code", SqlDbType.Int).Value = offerLetterCode;
            if (!string.IsNullOrEmpty(ddlLeagueType.SelectedValue))
                sqlCommand.Parameters.Add("@OfferLeagueType", SqlDbType.Int).Value = Convert.ToInt32(ddlLeagueType.SelectedValue);
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

    private void InsertExpectedDateOfJoining()
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateDateOfJoining", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(CandidateCode);
        sqlCommand.Parameters.Add("@JoiningDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtExpectedDOJ.Value);
        sqlCommand.Parameters.Add("@RACode", SqlDbType.Int).Value = ddlRA.SelectedValue;
        sqlCommand.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UserCode;
        sqlCommand.Parameters.Add("@UpdatedIP", SqlDbType.VarChar).Value = USERIP;
        sqlCommand.Parameters.Add("@GLCode", SqlDbType.Int).Value = ddlGL.SelectedValue;
        sqlCommand.Parameters.Add("@TentativeShift_Code", SqlDbType.Int).Value = ddlTentativeShift.SelectedValue;
        sqlCommand.Parameters.Add("@TeamLeaderCode", SqlDbType.Int).Value = ddlTL1.SelectedValue;
        sqlCommand.ExecuteNonQuery();
    }

    private void InsertUserOfferDeliveredComments()
    {
        try
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateInterview", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(CandidateCode);
            sqlCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = UserCode;
            sqlCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = txtaOfferdelivered.InnerText;
            sqlCommand.Parameters.Add("@LifeCycleStatus", SqlDbType.Int).Value = Convert.ToInt32(Constants.CandidateLifeCycleStatus.OfferSchedulingDoneOfferPending);
            if (ddlGrade.SelectedValue != "-1")
                sqlCommand.Parameters.Add("@GradeCode", SqlDbType.Int).Value = ddlGrade.SelectedValue;
            sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = UserCode;
            sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = USERIP;
            sqlCommand.ExecuteNonQuery();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
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

    private void UpdateCandidateInformation(string FilePath)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("dbo.XRec_InsertCandidateOfferAudioPath", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", CandidateCode));
                sqlCommand.Parameters.Add(new SqlParameter("@AudioPath", FilePath));
                sqlCommand.Parameters.Add(new SqlParameter("@UpdatedBy", UserCode));
                sqlCommand.Parameters.Add(new SqlParameter("@UpdatedIP", USERIP));
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
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand selectCommand = new SqlCommand("dbo.[XRec_UpdateSelectedCandidateLockBitNew]", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.Add("@CandidateCode", SqlDbType.VarChar).Value = CandidateCode;
            selectCommand.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UserCode;
            selectCommand.Parameters.Add("@UpdationIP", SqlDbType.VarChar).Value = USERIP;
            DataSet dataSet = new DataSet();
            new SqlDataAdapter(selectCommand).Fill(dataSet);
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            if (dataSet == null || dataSet.Tables == null || string.IsNullOrEmpty(dataSet.Tables[0].Rows[0]["IsTest"].ToString()))
                return;
            if (dataSet.Tables[0].Rows[0]["IsTest"].ToString().ToLower() == "true")
            {
                StatusManagement.MarkLifeCycleStatus(connection, int.Parse(CandidateCode), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.ShortlistedSchedulingPendingTest, USERIP, UserCode);
            }
            else
            {
                if (!(dataSet.Tables[0].Rows[0]["IsTest"].ToString().ToLower() == "false"))
                    return;
                StatusManagement.MarkLifeCycleStatus(connection, int.Parse(CandidateCode), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.NoTestSchedulingPendingInterview, USERIP, UserCode);
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

    private void CheckDivs()
    {
        tblInterview.Style.Add("display", "none");
        tblOfferGenerationPending.Style.Add("display", "none");
        tblOfferGeneration.Style.Add("display", "none");
        tblOfferDelivered.Style.Add("display", "none");
        tblOfferAcceptance.Style.Add("display", "none");
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
            div1.Style.Add("display", "none");
    }

    private void InsertUserInterviewComments()
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateInterview", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(CandidateCode);
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
        sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = USERIP;
        sqlCommand.ExecuteNonQuery();
    }

    private void InsertUserCommunicationComments(string comments, string CommentType)
    {
        try
        {
            SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_UserCommunicationComments", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(CandidateCode);
            sqlCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = UserCode;
            sqlCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = comments;
            sqlCommand.Parameters.Add("@LifeCycleStatus", SqlDbType.Int).Value = 0;
            sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = UserCode;
            sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = USERIP;
            sqlCommand.Parameters.Add("@CommentType", SqlDbType.VarChar).Value = CommentType;
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

    private void InsertUserInterviewCommentsOfferApproval()

    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateInterviewOfferDetail", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(CandidateCode);
        sqlCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = UserCode;
        sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = UserCode;
        sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = USERIP;
        sqlCommand.Parameters.Add("@Demanded_Salary", SqlDbType.Decimal).Value = Convert.ToDecimal(txtDSalary.Text);
        if (!string.IsNullOrEmpty(txtFixedSalary.Text))
            sqlCommand.Parameters.Add("@FixedSalary", SqlDbType.Int).Value = Convert.ToInt32(txtFixedSalary.Text);
        sqlCommand.Parameters.Add("@BankStatement_Status", SqlDbType.VarChar).Value = ddlStatement.SelectedItem.Text;
        sqlCommand.Parameters.Add("@Profile", SqlDbType.Int).Value = ddlProfile.SelectedValue;
        if (ddlJD.SelectedValue != "-1")
            sqlCommand.Parameters.Add("@TeamCode", SqlDbType.Int).Value = Convert.ToInt32(ddlJD.SelectedValue);
        if (ddlBU.SelectedValue != "-1")
            sqlCommand.Parameters.Add("@BUCode", SqlDbType.Int).Value = Convert.ToInt32(ddlBU.SelectedValue);
        sqlCommand.ExecuteNonQuery();
    }

    public void ClearCandidateAvailedSlots()
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateSlotIsAvailed", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = CandidateCode;
        sqlCommand.ExecuteNonQuery();
    }

    private void InsertUserOfferGeneratedComments()
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Insert_CandidateInterview", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(CandidateCode);
        sqlCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = UserCode;
        sqlCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = txtaOfferGenerationPending.InnerText;
        sqlCommand.Parameters.Add("@LifeCycleStatus", SqlDbType.Int).Value = Convert.ToInt32(Constants.CandidateLifeCycleStatus.InterviewPassedOfferGenerationPending);
        if (ddlGrade.SelectedValue != "-1")
            sqlCommand.Parameters.Add("@GradeCode", SqlDbType.Int).Value = ddlGrade.SelectedValue;
        sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = UserCode;
        sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = USERIP;
        sqlCommand.ExecuteNonQuery();
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
}
