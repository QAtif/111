using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ErrorLog;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.HtmlControls;
using XRecruitmentStatusLibrary;



public partial class A2_Candidate_CandidateDocsUpload : CustomBasePage, IRequiresSessionState
{

    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    public string CandidateCode = string.Empty;
    public string QueryStringVar = string.Empty;
    SecureQueryString secQueryString = new SecureQueryString();
    string exp = string.Empty;
    string edu = string.Empty;
    string Fam = string.Empty;
    string Cer = string.Empty;
    string Dip = string.Empty;
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
            if (!string.IsNullOrEmpty(CandidateCode))
            {
                BindData();
                Candetail.CandCode = CandidateCode;
                divCanDocdetail.Style.Add("display", "");
                divCanDocdetail.Style.Add("display", "");
            }
            else
            {
                divCandetail.Style.Add("display", "none");
                divCanDocdetail.Style.Add("display", "none");
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

    protected void btrnSaveAll_OnClick(object sender, EventArgs e)
    {
        try
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SaveRepeaterData(rptHiredDocs, "HiredDocs");
            SaveRepeaterData(rptOfficial, "Official");
            SaveRepeaterData(rptDocPersonal, "Personal");
            SaveRepeaterData(rptDocsEducation, "Educational");
            SaveRepeaterData(rptDocDiploma, "Educational");
            SaveRepeaterData(rptDocCertificate, "Educational");
            SaveRepeaterData(rptDocsExperience, "Professional");
            SaveRepeaterData(rptAxEdu, "AxactianEducation");
            SaveRepeaterData(rptAxExp, "AxactianExperience");
            SaveRepeaterData(rptAxMisc, "AxactianMisc");
            SaveRepeaterData(rptAxSep, "AxactianSeperation");
            SaveRepeaterData(rptAxPer, "AxactianPersonal");
            SaveRepeaterData(rptAxFam, "AxactianFamily");
            BindData();
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
                Page.RegisterStartupScript("REFRESHpAGESCRIPT", "<script language=JavaScript>window.location='" + ("/A2/Candidate/CandidateDocsUpload.aspx?data=" + new SecureQueryString().encrypt("CID=" + CandidateCode)) + "';</script>");
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

    public void BindData()
    {
        SqlCommand selectCommand = new SqlCommand("dbo.Select_CandidateDocumentsAfterHiredNew", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.Add("@Candidate_Code", SqlDbType.Int).Value = CandidateCode;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet != null && dataSet.Tables.Count == 1)
        {
            DataView dataView1 = new DataView(dataSet.Tables[0]);
            dataView1.RowFilter = "DocType_Code = 9  and CandDoc_Code<>0";
            dataView1.Sort = "CandidateDocumentName";
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
            DataView dataView2 = new DataView(dataSet.Tables[0]);
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
            DataView dataView3 = new DataView(dataSet.Tables[0]);
            dataView3.RowFilter = "(DocType_Code >= 2 and DocType_Code <= 6 and CandDoc_Code<>0) or (DocType_Code =10 and CandDoc_Code<>0) or (DocType_Code =11 and CandDoc_Code<>0) ";
            dataView3.Sort = "CandidateDocumentName";
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
            DataView dataView4 = new DataView(dataSet.Tables[0]);
            dataView4.RowFilter = "DocType_Code =8 and CandDoc_Code<>0 ";
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
            DataView dataView5 = new DataView(dataSet.Tables[0]);
            dataView5.RowFilter = "DocType_Code =7 and CandDoc_Code<>0 ";
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
            DataView dataView6 = new DataView(dataSet.Tables[0]);
            dataView6.RowFilter = "DocType_Code = 13 ";
            if (dataView6.Count > 0)
            {
                rptHiredDocs.DataSource = dataView6;
                rptHiredDocs.DataBind();
                lblHiredDoc.Visible = false;
            }
            else
            {
                lblHiredDoc.Visible = true;
                rptHiredDocs.DataSource = null;
                rptHiredDocs.DataBind();
            }
            DataView dataView7 = new DataView(dataSet.Tables[0]);
            dataView7.RowFilter = "DocType_Code = 12 ";
            if (dataView7.Count > 0)
            {
                rptOfficial.DataSource = dataView7;
                rptOfficial.DataBind();
                lblOfficial.Visible = false;
            }
            else
            {
                lblOfficial.Visible = true;
                rptOfficial.DataSource = null;
                rptOfficial.DataBind();
            }
            DataView dataView8 = new DataView(dataSet.Tables[0]);
            dataView8.RowFilter = "DocType_Code = 14 ";
            if (dataView8.Count > 0)
            {
                rptAxPer.DataSource = dataView8;
                rptAxPer.DataBind();
                lblrptAxPer.Visible = false;
            }
            else
            {
                lblrptAxPer.Visible = true;
                rptAxPer.DataSource = null;
                rptAxPer.DataBind();
            }
            DataView dataView9 = new DataView(dataSet.Tables[0]);
            dataView9.RowFilter = "DocType_Code = 15 ";
            if (dataView9.Count > 0)
            {
                rptAxExp.DataSource = dataView9;
                rptAxExp.DataBind();
                lblAxExp.Visible = false;
            }
            else
            {
                lblAxExp.Visible = true;
                rptAxExp.DataSource = null;
                rptAxExp.DataBind();
            }
            DataView dataView10 = new DataView(dataSet.Tables[0]);
            dataView10.RowFilter = "DocType_Code = 16 ";
            if (dataView10.Count > 0)
            {
                rptAxEdu.DataSource = dataView10;
                rptAxEdu.DataBind();
                lblAxEdu.Visible = false;
            }
            else
            {
                lblAxEdu.Visible = true;
                rptAxEdu.DataSource = null;
                rptAxEdu.DataBind();
            }
            DataView dataView11 = new DataView(dataSet.Tables[0]);
            dataView11.RowFilter = "DocType_Code = 17 and CandDoc_Code<>0";
            dataView11.Sort = "candidatedocumentname ASC";
            if (dataView11.Count > 0)
            {
                rptAxFam.DataSource = dataView11;
                rptAxFam.DataBind();
                lblAxFam.Visible = false;
            }
            else
            {
                lblAxFam.Visible = true;
                rptAxFam.DataSource = null;
                rptAxFam.DataBind();
            }
            DataView dataView12 = new DataView(dataSet.Tables[0]);
            dataView12.RowFilter = "DocType_Code = 18 ";
            if (dataView12.Count > 0)
            {
                rptAxSep.DataSource = dataView12;
                rptAxSep.DataBind();
                lblAxSep.Visible = false;
            }
            else
            {
                lblAxSep.Visible = true;
                rptAxSep.DataSource = null;
                rptAxSep.DataBind();
            }
            DataView dataView13 = new DataView(dataSet.Tables[0]);
            dataView13.RowFilter = "DocType_Code = 19 ";
            if (dataView13.Count > 0)
            {
                rptAxMisc.DataSource = dataView13;
                rptAxMisc.DataBind();
                lblAxMisc.Visible = false;
            }
            else
            {
                lblAxMisc.Visible = true;
                rptAxMisc.DataSource = null;
                rptAxMisc.DataBind();
            }
        }
        ShowHideActions();
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

    public void SaveRepeaterData(Repeater RPT, string FilePathName)
    {
        foreach (RepeaterItem repeaterItem in RPT.Items)
        {
            FileUpload control1 = (FileUpload)repeaterItem.FindControl("Fu");
            HiddenField control2 = (HiddenField)repeaterItem.FindControl("CandidateDocumentName");
            HiddenField control3 = (HiddenField)repeaterItem.FindControl("hdnCandDocCode");
            HiddenField control4 = (HiddenField)repeaterItem.FindControl("hdnDocumentCode");
            string str1 = repeaterItem.ItemIndex.ToString();
            if (control1.HasFile)
            {
                string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + CandidateCode + "/" + FilePathName + "/";
                if (control1.HasFile)
                {
                    GeneralMethods.FileBrowse(control1, FolderPath, control2.Value + "-" + str1);
                    string str2 = FolderPath + control2.Value + "-" + str1 + Path.GetExtension(control1.FileName);
                    SqlCommand sqlCommand = new SqlCommand("dbo.insert_Update_CandidateDocumentDigitalization", connection);
                    sqlCommand.Parameters.AddWithValue("@Candidate_Code", CandidateCode);
                    sqlCommand.Parameters.AddWithValue("@Document_Code", control4.Value);
                    if (control3.Value != "0")
                        sqlCommand.Parameters.AddWithValue("@CandDoc_Code", control3.Value);
                    sqlCommand.Parameters.AddWithValue("@DocumentPath", str2);
                    sqlCommand.Parameters.AddWithValue("@CandidateDocumentName", control2.Value);
                    sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
                    sqlCommand.Parameters.AddWithValue("@UpdatedIp", USERIP);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }

    public void reloadpage()
    {
        Page.RegisterStartupScript("REFRESHpAGESCRIPT", "<script language=JavaScript>window.location.href = window.location.href ;</script>");
    }

    protected void rptExp_OnDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HtmlTableRow control1 = (HtmlTableRow)e.Item.FindControl("SpDocNameHeading");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnDocName");
            if (exp == control2.Value)
                control1.Style.Add("display", "none");
            else
                exp = control2.Value;
            HtmlAnchor control3 = (HtmlAnchor)e.Item.FindControl("AimgEdit");
            HtmlImage control4 = (HtmlImage)e.Item.FindControl("imgcheck");
            FileUpload control5 = (FileUpload)e.Item.FindControl("Fu");
            control3.Attributes.Add("onclick", "$('#" + control5.ClientID + "').click()");
            control5.Attributes.Add("onchange", "$('#" + control4.ClientID + "').show();");
            HtmlAnchor control6 = (HtmlAnchor)e.Item.FindControl("aDownload");
            if (string.IsNullOrEmpty(((DataRowView)e.Item.DataItem)["DocumentPath1"].ToString()))
                return;
            control6.Attributes.Add("class", "show");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptEdu_OnDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HtmlTableRow control1 = (HtmlTableRow)e.Item.FindControl("SpDocNameHeading");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnDocName");
            if (edu == control2.Value)
                control1.Style.Add("display", "none");
            else
                edu = control2.Value;
            HtmlAnchor control3 = (HtmlAnchor)e.Item.FindControl("AimgEdit");
            HtmlImage control4 = (HtmlImage)e.Item.FindControl("imgcheck");
            FileUpload control5 = (FileUpload)e.Item.FindControl("Fu");
            control3.Attributes.Add("onclick", "$('#" + control5.ClientID + "').click()");
            control5.Attributes.Add("onchange", "$('#" + control4.ClientID + "').show();");
            HtmlAnchor control6 = (HtmlAnchor)e.Item.FindControl("aDownload");
            if (string.IsNullOrEmpty(((DataRowView)e.Item.DataItem)["DocumentPath1"].ToString()))
                return;
            control6.Attributes.Add("class", "show");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptCertificate_OnDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HtmlTableRow control1 = (HtmlTableRow)e.Item.FindControl("SpDocNameHeading");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnDocName");
            if (Cer == control2.Value)
                control1.Style.Add("display", "none");
            else
                Cer = control2.Value;
            HtmlAnchor control3 = (HtmlAnchor)e.Item.FindControl("AimgEdit");
            HtmlImage control4 = (HtmlImage)e.Item.FindControl("imgcheck");
            FileUpload control5 = (FileUpload)e.Item.FindControl("Fu");
            control3.Attributes.Add("onclick", "$('#" + control5.ClientID + "').click()");
            control5.Attributes.Add("onchange", "$('#" + control4.ClientID + "').show();");
            HtmlAnchor control6 = (HtmlAnchor)e.Item.FindControl("aDownload");
            if (string.IsNullOrEmpty(((DataRowView)e.Item.DataItem)["DocumentPath1"].ToString()))
                return;
            control6.Attributes.Add("class", "show");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptDiploma_OnDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HtmlTableRow control1 = (HtmlTableRow)e.Item.FindControl("SpDocNameHeading");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnDocName");
            if (Dip == control2.Value)
                control1.Style.Add("display", "none");
            else
                Dip = control2.Value;
            HtmlAnchor control3 = (HtmlAnchor)e.Item.FindControl("AimgEdit");
            HtmlImage control4 = (HtmlImage)e.Item.FindControl("imgcheck");
            FileUpload control5 = (FileUpload)e.Item.FindControl("Fu");
            control3.Attributes.Add("onclick", "$('#" + control5.ClientID + "').click()");
            control5.Attributes.Add("onchange", "$('#" + control4.ClientID + "').show();");
            HtmlAnchor control6 = (HtmlAnchor)e.Item.FindControl("aDownload");
            if (string.IsNullOrEmpty(((DataRowView)e.Item.DataItem)["DocumentPath1"].ToString()))
                return;
            control6.Attributes.Add("class", "show");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptPer_OnDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HtmlAnchor control1 = (HtmlAnchor)e.Item.FindControl("AimgEdit");
            HtmlImage control2 = (HtmlImage)e.Item.FindControl("imgcheck");
            FileUpload control3 = (FileUpload)e.Item.FindControl("Fu");
            control1.Attributes.Add("onclick", "$('#" + control3.ClientID + "').click()");
            control3.Attributes.Add("onchange", "$('#" + control2.ClientID + "').show();");
            HtmlAnchor control4 = (HtmlAnchor)e.Item.FindControl("aDownload");
            if (string.IsNullOrEmpty(((DataRowView)e.Item.DataItem)["DocumentPath1"].ToString()))
                return;
            control4.Attributes.Add("class", "show");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptHired_OnDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HtmlAnchor control1 = (HtmlAnchor)e.Item.FindControl("AimgEdit");
            HtmlImage control2 = (HtmlImage)e.Item.FindControl("imgcheck");
            FileUpload control3 = (FileUpload)e.Item.FindControl("Fu");
            control1.Attributes.Add("onclick", "$('#" + control3.ClientID + "').click()");
            control3.Attributes.Add("onchange", "$('#" + control2.ClientID + "').show();");
            HtmlAnchor control4 = (HtmlAnchor)e.Item.FindControl("aDownload");
            if (string.IsNullOrEmpty(((DataRowView)e.Item.DataItem)["DocumentPath1"].ToString()))
                return;
            control4.Attributes.Add("class", "show");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptOfficial_OnDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HtmlAnchor control1 = (HtmlAnchor)e.Item.FindControl("AimgEdit");
            HtmlImage control2 = (HtmlImage)e.Item.FindControl("imgcheck");
            FileUpload control3 = (FileUpload)e.Item.FindControl("Fu");
            control1.Attributes.Add("onclick", "$('#" + control3.ClientID + "').click()");
            control3.Attributes.Add("onchange", "$('#" + control2.ClientID + "').show();");
            HtmlAnchor control4 = (HtmlAnchor)e.Item.FindControl("aDownload");
            if (string.IsNullOrEmpty(((DataRowView)e.Item.DataItem)["DocumentPath1"].ToString()))
                return;
            control4.Attributes.Add("class", "show");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptAxPer_OnDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HtmlAnchor control1 = (HtmlAnchor)e.Item.FindControl("AimgEdit");
            HtmlImage control2 = (HtmlImage)e.Item.FindControl("imgcheck");
            FileUpload control3 = (FileUpload)e.Item.FindControl("Fu");
            control1.Attributes.Add("onclick", "$('#" + control3.ClientID + "').click()");
            control3.Attributes.Add("onchange", "$('#" + control2.ClientID + "').show();");
            HtmlAnchor control4 = (HtmlAnchor)e.Item.FindControl("aDownload");
            if (string.IsNullOrEmpty(((DataRowView)e.Item.DataItem)["DocumentPath1"].ToString()))
                return;
            control4.Attributes.Add("class", "show");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptAxExp_OnDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HtmlAnchor control1 = (HtmlAnchor)e.Item.FindControl("AimgEdit");
            HtmlImage control2 = (HtmlImage)e.Item.FindControl("imgcheck");
            FileUpload control3 = (FileUpload)e.Item.FindControl("Fu");
            control1.Attributes.Add("onclick", "$('#" + control3.ClientID + "').click()");
            control3.Attributes.Add("onchange", "$('#" + control2.ClientID + "').show();");
            HtmlAnchor control4 = (HtmlAnchor)e.Item.FindControl("aDownload");
            if (string.IsNullOrEmpty(((DataRowView)e.Item.DataItem)["DocumentPath1"].ToString()))
                return;
            control4.Attributes.Add("class", "show");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptAxEdu_OnDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HtmlAnchor control1 = (HtmlAnchor)e.Item.FindControl("AimgEdit");
            HtmlImage control2 = (HtmlImage)e.Item.FindControl("imgcheck");
            FileUpload control3 = (FileUpload)e.Item.FindControl("Fu");
            control1.Attributes.Add("onclick", "$('#" + control3.ClientID + "').click()");
            control3.Attributes.Add("onchange", "$('#" + control2.ClientID + "').show();");
            HtmlAnchor control4 = (HtmlAnchor)e.Item.FindControl("aDownload");
            if (string.IsNullOrEmpty(((DataRowView)e.Item.DataItem)["DocumentPath1"].ToString()))
                return;
            control4.Attributes.Add("class", "show");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptAxFam_OnDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HtmlTableRow control1 = (HtmlTableRow)e.Item.FindControl("SpDocNameHeading");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnDocName");
            if (Fam == control2.Value)
                control1.Style.Add("display", "none");
            else
                Fam = control2.Value;
            HtmlAnchor control3 = (HtmlAnchor)e.Item.FindControl("AimgEdit");
            HtmlImage control4 = (HtmlImage)e.Item.FindControl("imgcheck");
            FileUpload control5 = (FileUpload)e.Item.FindControl("Fu");
            control3.Attributes.Add("onclick", "$('#" + control5.ClientID + "').click()");
            control5.Attributes.Add("onchange", "$('#" + control4.ClientID + "').show();");
            HtmlAnchor control6 = (HtmlAnchor)e.Item.FindControl("aDownload");
            if (string.IsNullOrEmpty(((DataRowView)e.Item.DataItem)["DocumentPath1"].ToString()))
                return;
            control6.Attributes.Add("class", "show");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptAxSep_OnDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HtmlAnchor control1 = (HtmlAnchor)e.Item.FindControl("AimgEdit");
            HtmlImage control2 = (HtmlImage)e.Item.FindControl("imgcheck");
            FileUpload control3 = (FileUpload)e.Item.FindControl("Fu");
            control1.Attributes.Add("onclick", "$('#" + control3.ClientID + "').click()");
            control3.Attributes.Add("onchange", "$('#" + control2.ClientID + "').show();");
            HtmlAnchor control4 = (HtmlAnchor)e.Item.FindControl("aDownload");
            if (string.IsNullOrEmpty(((DataRowView)e.Item.DataItem)["DocumentPath1"].ToString()))
                return;
            control4.Attributes.Add("class", "show");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptAxMisc_OnDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            HtmlAnchor control1 = (HtmlAnchor)e.Item.FindControl("AimgEdit");
            HtmlImage control2 = (HtmlImage)e.Item.FindControl("imgcheck");
            FileUpload control3 = (FileUpload)e.Item.FindControl("Fu");
            control1.Attributes.Add("onclick", "$('#" + control3.ClientID + "').click()");
            control3.Attributes.Add("onchange", "$('#" + control2.ClientID + "').show();");
            HtmlAnchor control4 = (HtmlAnchor)e.Item.FindControl("aDownload");
            if (string.IsNullOrEmpty(((DataRowView)e.Item.DataItem)["DocumentPath1"].ToString()))
                return;
            control4.Attributes.Add("class", "show");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptExp_OnItemCammand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            if (!(e.CommandName == "Delete") || e.CommandArgument == null)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Delete_CandidateDocument", connection);
            sqlCommand.Parameters.AddWithValue("@CandDoc_Code", e.CommandArgument.ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
            sqlCommand.Parameters.AddWithValue("@UpdatedIp", USERIP);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            BindData();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptEdu_OnItemCammand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            if (!(e.CommandName == "Delete") || e.CommandArgument == null)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Delete_CandidateDocument", connection);
            sqlCommand.Parameters.AddWithValue("@CandDoc_Code", e.CommandArgument.ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
            sqlCommand.Parameters.AddWithValue("@UpdatedIp", USERIP);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            BindData();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptCertificate_OnItemCammand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            if (!(e.CommandName == "Delete") || e.CommandArgument == null)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Delete_CandidateDocument", connection);
            sqlCommand.Parameters.AddWithValue("@CandDoc_Code", e.CommandArgument.ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
            sqlCommand.Parameters.AddWithValue("@UpdatedIp", USERIP);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            BindData();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptDiploma_OnItemCammand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            if (!(e.CommandName == "Delete") || e.CommandArgument == null)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Delete_CandidateDocument", connection);
            sqlCommand.Parameters.AddWithValue("@CandDoc_Code", e.CommandArgument.ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
            sqlCommand.Parameters.AddWithValue("@UpdatedIp", USERIP);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            BindData();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptPer_OnItemCammand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            if (!(e.CommandName == "Delete") || e.CommandArgument == null)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Delete_CandidateDocument", connection);
            sqlCommand.Parameters.AddWithValue("@CandDoc_Code", e.CommandArgument.ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
            sqlCommand.Parameters.AddWithValue("@UpdatedIp", USERIP);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            BindData();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptHired_OnItemCammand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            if (!(e.CommandName == "Delete") || e.CommandArgument == null)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Delete_CandidateDocument", connection);
            sqlCommand.Parameters.AddWithValue("@CandDoc_Code", e.CommandArgument.ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
            sqlCommand.Parameters.AddWithValue("@UpdatedIp", USERIP);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            BindData();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptOfficial_OnItemCammand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            if (!(e.CommandName == "Delete") || e.CommandArgument == null)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Delete_CandidateDocument", connection);
            sqlCommand.Parameters.AddWithValue("@CandDoc_Code", e.CommandArgument.ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
            sqlCommand.Parameters.AddWithValue("@UpdatedIp", USERIP);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            BindData();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptAxPer_OnItemCammand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            if (!(e.CommandName == "Delete") || e.CommandArgument == null)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Delete_CandidateDocument", connection);
            sqlCommand.Parameters.AddWithValue("@CandDoc_Code", e.CommandArgument.ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
            sqlCommand.Parameters.AddWithValue("@UpdatedIp", USERIP);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            BindData();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptAxExp_OnItemCammand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            if (!(e.CommandName == "Delete") || e.CommandArgument == null)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Delete_CandidateDocument", connection);
            sqlCommand.Parameters.AddWithValue("@CandDoc_Code", e.CommandArgument.ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
            sqlCommand.Parameters.AddWithValue("@UpdatedIp", USERIP);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            BindData();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptAxEdu_OnItemCammand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            if (!(e.CommandName == "Delete") || e.CommandArgument == null)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Delete_CandidateDocument", connection);
            sqlCommand.Parameters.AddWithValue("@CandDoc_Code", e.CommandArgument.ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
            sqlCommand.Parameters.AddWithValue("@UpdatedIp", USERIP);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            BindData();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptAxFam_OnItemCammand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            if (!(e.CommandName == "Delete") || e.CommandArgument == null)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Delete_CandidateDocument", connection);
            sqlCommand.Parameters.AddWithValue("@CandDoc_Code", e.CommandArgument.ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
            sqlCommand.Parameters.AddWithValue("@UpdatedIp", USERIP);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            BindData();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptAxSep_OnItemCammand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            if (!(e.CommandName == "Delete") || e.CommandArgument == null)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Delete_CandidateDocument", connection);
            sqlCommand.Parameters.AddWithValue("@CandDoc_Code", e.CommandArgument.ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
            sqlCommand.Parameters.AddWithValue("@UpdatedIp", USERIP);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            BindData();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptAxMisc_OnItemCammand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            if (!(e.CommandName == "Delete") || e.CommandArgument == null)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Delete_CandidateDocument", connection);
            sqlCommand.Parameters.AddWithValue("@CandDoc_Code", e.CommandArgument.ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
            sqlCommand.Parameters.AddWithValue("@UpdatedIp", USERIP);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            BindData();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

}