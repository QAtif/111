using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using XRecruitmentStatusLibrary;
using ErrorLog;

public partial class Candidate_CandidateDocumentVerification : CustomBasePage
{
    DataSet ds = new DataSet();
    string candidateCode = "0";
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            secQueryString = new SecureQueryString(QueryStringVar);
            CheckQueryString();
            connection.Open();
            BindData();
            BindCandidateDetail();
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

    private void BindCandidateDetail()
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateAllDocument", connection);
        selectCommand.Parameters.AddWithValue("@Candidate_Code", hdnCandCode.Value);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            lblName.Text = dataSet.Tables[0].Rows[0]["Full_Name"].ToString();
            lblDesignation.Text = dataSet.Tables[0].Rows[0]["Designation_Name"].ToString();
            lblDepartment.Text = dataSet.Tables[0].Rows[0]["Domain_Name"].ToString();
            lblJobCategory.Text = dataSet.Tables[0].Rows[0]["Category_Name"].ToString();
        }
        if (dataSet.Tables[1].Rows.Count <= 0)
            return;
        if (Convert.ToBoolean(dataSet.Tables[1].Rows[0]["Is_MedicalPass"]))
        {
            rbtnPass.Checked = true;
            lblMedical.Text = "Passed";
        }
        else
        {
            rbtnFail.Checked = true;
            lblMedical.Text = "Failed";
        }
        foreach (DataRow row in (InternalDataCollectionBase)dataSet.Tables[1].Rows)
        {
            foreach (Control control1 in rptDocumentType.Items)
            {
                foreach (Control control2 in (control1.FindControl("rptCandidateDocument") as Repeater).Items)
                {
                    foreach (RepeaterItem repeaterItem in (control2.FindControl("rptUploadDocuments") as Repeater).Items)
                    {
                        HiddenField control3 = repeaterItem.FindControl("hdnCandDocCode") as HiddenField;
                        DropDownList control4 = repeaterItem.FindControl("ddlStatus") as DropDownList;
                        DropDownList control5 = repeaterItem.FindControl("ddlDayCount") as DropDownList;
                        TextBox control6 = repeaterItem.FindControl("txtStatusComment") as TextBox;
                        CheckBox control7 = repeaterItem.FindControl("chkSupportDoc") as CheckBox;
                        CheckBox control8 = repeaterItem.FindControl("chkOriginal") as CheckBox;
                        CheckBox control9 = repeaterItem.FindControl("chkObjection") as CheckBox;
                        TextBox control10 = repeaterItem.FindControl("txtObjectionComments") as TextBox;
                        HtmlGenericControl control11 = repeaterItem.FindControl("dvStatus") as HtmlGenericControl;
                        if (control3.Value == row["CandDoc_Code"].ToString())
                        {
                            control4.SelectedValue = row["DocumentStatus_Code"].ToString();
                            control5.SelectedValue = row["Days_Count"].ToString();
                            control6.Text = row["Status_Comments"].ToString();
                            control7.Checked = Convert.ToBoolean(row["Is_SupportiveDocument"]);
                            control8.Checked = Convert.ToBoolean(row["Is_OriginalSeen"]);
                            control9.Checked = Convert.ToBoolean(row["Is_Objection"]);
                            control10.Text = row["Objection_Comments"].ToString();
                            if (control4.SelectedValue == "2" || control4.SelectedValue == "3")
                                control11.Visible = true;
                            else
                                control11.Visible = false;
                            if (control9.Checked)
                                control10.Visible = true;
                            else
                                control10.Visible = false;
                        }
                    }
                }
            }
        }
    }

    private void BindData()
    {
        try
        {
            DataSet dataSet1 = new DataSet();
            DataSet dataSet2 = BindDocumentType();
            if (dataSet2 == null || dataSet2.Tables == null || dataSet2.Tables[0].Rows.Count <= 0)
                return;
            rptDocumentType.DataSource = dataSet2.Tables[0];
            rptDocumentType.DataBind();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, hdnCandCode.Value);
        }
    }

    private DataSet BindDocumentType()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectDocumentTypes", connection))
                {
                    selectCommand.Parameters.AddWithValue("@CandidateCode", hdnCandCode.Value);
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, hdnCandCode.Value);
            }
        }
        return dataSet;
    }

    protected void rptDocumentType_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            Repeater control1 = (Repeater)e.Item.FindControl("rptCandidateDocument");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnDocumentTypeCode");
            HiddenField control3 = (HiddenField)e.Item.FindControl("hdnProgramCode");
            if (Convert.ToInt32(control2.Value) == 1 || Convert.ToInt32(control2.Value) == 9)
            {
                if (Convert.ToInt32(control2.Value) == 9)
                {
                    DataSet dataSet1 = new DataSet();
                    DataSet dataSet2 = BindCandidateProfessionalExperienceDocuments(control2.Value);
                    if (dataSet2 != null && dataSet2.Tables != null && dataSet2.Tables[0].Rows.Count > 0)
                    {
                        control1.DataSource = dataSet2.Tables[0];
                        control1.DataBind();
                    }
                }
                if (Convert.ToInt32(control2.Value) != 1)
                    return;
                DataSet dataSet3 = new DataSet();
                DataSet dataSet4 = BindCandidatePersonalDocuments(control2.Value);
                if (dataSet4 == null || dataSet4.Tables == null || dataSet4.Tables[0].Rows.Count <= 0)
                    return;
                control1.DataSource = dataSet4.Tables[0];
                control1.DataBind();
            }
            else
            {
                DataSet dataSet1 = new DataSet();
                DataSet dataSet2 = BindCandidateDocuments(control2.Value, control3.Value);
                if (dataSet2 == null || dataSet2.Tables == null || dataSet2.Tables[0].Rows.Count <= 0)
                    return;
                control1.DataSource = dataSet2.Tables[0];
                control1.DataBind();
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, hdnCandCode.Value);
        }
    }

    protected void rptCandidateDocument_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            Repeater control1 = (Repeater)e.Item.FindControl("rptUploadDocuments");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnReferenceCode");
            HiddenField control3 = (HiddenField)e.Item.FindControl("hdnProgram");
            HiddenField control4 = (HiddenField)e.Item.FindControl("hdnDocument_Type");
            if (Convert.ToInt32(control4.Value) == 1 || Convert.ToInt32(control4.Value) == 9)
            {
                if (Convert.ToInt32(control4.Value) == 1)
                {
                    DataSet dataSet1 = new DataSet();
                    DataSet dataSet2 = BindPersonalDocumentsUploaders(control4.Value, control2.Value);
                    if (dataSet2 != null && dataSet2.Tables != null && dataSet2.Tables[0].Rows.Count > 0)
                    {
                        control1.DataSource = dataSet2.Tables[0];
                        control1.DataBind();
                    }
                }
                if (Convert.ToInt32(control4.Value) != 9)
                    return;
                DataSet dataSet3 = new DataSet();
                DataSet dataSet4 = BindExperienceDocumentsUploaders(control4.Value, control2.Value);
                if (dataSet4 == null || dataSet4.Tables == null || dataSet4.Tables[0].Rows.Count <= 0)
                    return;
                control1.DataSource = dataSet4.Tables[0];
                control1.DataBind();
            }
            else
            {
                DataSet dataSet1 = new DataSet();
                DataSet dataSet2 = BindDocumentsUploaders(control2.Value, control3.Value);
                if (dataSet2 == null || dataSet2.Tables == null || dataSet2.Tables[0].Rows.Count <= 0)
                    return;
                control1.DataSource = dataSet2.Tables[0];
                control1.DataBind();
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, hdnCandCode.Value);
        }
    }

    private DataSet BindCandidateProfessionalExperienceDocuments(string DocumentType)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDocument", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", hdnCandCode.Value);
                    selectCommand.Parameters.AddWithValue("@DocumentTypeCode", Convert.ToInt32(DocumentType));
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, hdnCandCode.Value);
            }
        }
        return dataSet;
    }

    private DataSet BindPersonalDocumentsUploaders(string DocumentType, string ReferenceCode)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDocumentstoBeUploaded", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", hdnCandCode.Value);
                    selectCommand.Parameters.AddWithValue("@ReferenceCode", ReferenceCode);
                    selectCommand.Parameters.AddWithValue("@DocumentTypeCode", DocumentType);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, hdnCandCode.Value);
            }
        }
        return dataSet;
    }

    private DataSet BindExperienceDocumentsUploaders(string DocumentType, string ReferenceCode)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDocumentstoBeUploaded", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", hdnCandCode.Value);
                    selectCommand.Parameters.AddWithValue("@ReferenceCode", ReferenceCode);
                    selectCommand.Parameters.AddWithValue("@DocumentTypeCode", DocumentType);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, hdnCandCode.Value);
            }
        }
        return dataSet;
    }

    private DataSet BindCandidatePersonalDocuments(string DocumentTypeCode)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDocument", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", hdnCandCode.Value);
                    selectCommand.Parameters.AddWithValue("@DocumentTypeCode", Convert.ToInt32(DocumentTypeCode));
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, hdnCandCode.Value);
            }
        }
        return dataSet;
    }

    private DataSet BindCandidateDocuments(string DocumentTypeCode, string ProgramCode)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDocument", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", hdnCandCode.Value);
                    selectCommand.Parameters.AddWithValue("@ProgramCode", Convert.ToInt32(ProgramCode));
                    selectCommand.Parameters.AddWithValue("@DocumentTypeCode", Convert.ToInt32(DocumentTypeCode));
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, hdnCandCode.Value);
            }
        }
        return dataSet;
    }

    private DataSet BindDocumentsUploaders(string ReferenceCode, string ProgramCode)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDocumentstoBeUploaded", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", hdnCandCode.Value);
                    selectCommand.Parameters.AddWithValue("@ReferenceCode", ReferenceCode);
                    selectCommand.Parameters.AddWithValue("@ProgramCode", ProgramCode);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, hdnCandCode.Value);
            }
        }
        return dataSet;
    }

    private void CheckQueryString()
    {
        if (secQueryString["CID"] == null)
            return;
        candidateCode = secQueryString["CID"].ToString();
        hdnCandCode.Value = secQueryString["CID"].ToString();
    }

    public void GetCandidateDetail(ref SqlConnection connection)
    {
    }

    protected void rptUploadDocuments_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            DropDownList control1 = (DropDownList)e.Item.FindControl("ddlStatus");
            DropDownList control2 = (DropDownList)e.Item.FindControl("ddlDayCount");
            HtmlAnchor control3 = (HtmlAnchor)e.Item.FindControl("aViewPersonal");
            for (int index = 1; index <= 365; ++index)
                control2.Items.Insert(index - 1, new ListItem(index.ToString(), index.ToString()));
            try
            {
                SqlCommand selectCommand = new SqlCommand("XRec_SelectDocumentStatus", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet.Tables[0] != null)
                {
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        control1.DataSource = dataSet;
                        control1.DataTextField = "DocumentStatus_Name";
                        control1.DataValueField = "DocumentStatus_Code";
                        control1.DataBind();
                        control1.Items.Insert(0, new ListItem("--Select Status--", "0"));
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
            if (!(DataBinder.Eval(e.Item.DataItem, "DOCUMENT_Path").ToString() == ""))
                return;
            control3.InnerText = "No Document";
            control3.HRef = "javascript:";
            control3.Target = "";
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, hdnCandCode.Value);
        }
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList dropDownList = sender as DropDownList;
            HtmlGenericControl control = (dropDownList.Parent as RepeaterItem).FindControl("dvStatus") as HtmlGenericControl;
            if (dropDownList.SelectedValue == "2" || dropDownList.SelectedValue == "3")
                control.Visible = true;
            else
                control.Visible = false;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    protected void chkObjection_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox checkBox = sender as CheckBox;
            TextBox control = (checkBox.Parent as RepeaterItem).FindControl("txtObjectionComments") as TextBox;
            if (checkBox.Checked)
                control.Visible = true;
            else
                control.Visible = false;
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
        bool flag = true;
        try
        {
            connection.Open();
            foreach (Control control1 in rptDocumentType.Items)
            {
                foreach (Control control2 in (control1.FindControl("rptCandidateDocument") as Repeater).Items)
                {
                    foreach (RepeaterItem repeaterItem in (control2.FindControl("rptUploadDocuments") as Repeater).Items)
                    {
                        HiddenField control3 = repeaterItem.FindControl("hdnCandDocCode") as HiddenField;
                        DropDownList control4 = repeaterItem.FindControl("ddlStatus") as DropDownList;
                        DropDownList control5 = repeaterItem.FindControl("ddlDayCount") as DropDownList;
                        TextBox control6 = repeaterItem.FindControl("txtStatusComment") as TextBox;
                        CheckBox control7 = repeaterItem.FindControl("chkSupportDoc") as CheckBox;
                        CheckBox control8 = repeaterItem.FindControl("chkOriginal") as CheckBox;
                        CheckBox control9 = repeaterItem.FindControl("chkObjection") as CheckBox;
                        TextBox control10 = repeaterItem.FindControl("txtObjectionComments") as TextBox;
                        SqlCommand sqlCommand = new SqlCommand("XRec_UpdateDocumentStatus", connection);
                        sqlCommand.Parameters.AddWithValue("@CandDoc_Code", control3.Value);
                        if (control4.SelectedValue == "0")
                        {
                            flag = false;
                            sqlCommand.Parameters.AddWithValue("@DocumentStatus_Code", control4.SelectedValue);
                        }
                        else if (control4.SelectedValue != "0")
                        {
                            sqlCommand.Parameters.AddWithValue("@DocumentStatus_Code", control4.SelectedValue);
                            sqlCommand.Parameters.AddWithValue("@Days_Count", control5.SelectedValue);
                            sqlCommand.Parameters.AddWithValue("@Status_Comments", control6.Text);
                            sqlCommand.Parameters.AddWithValue("@Is_SupportiveDocument", control7.Checked);
                        }
                        sqlCommand.Parameters.AddWithValue("@Is_OriginalSeen", control8.Checked);
                        sqlCommand.Parameters.AddWithValue("@Is_Objection", control9.Checked);
                        if (control9.Checked)
                            sqlCommand.Parameters.AddWithValue("@Objection_Comments", control10.Text);
                        sqlCommand.Parameters.AddWithValue("@Is_MedicalPass", rbtnPass.Checked);
                        sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
                        sqlCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        Convert.ToString(sqlCommand.ExecuteScalar());
                    }
                }
            }
            if (rbtnFail.Checked)
                StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(hdnCandCode.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.MedicalFailed, Request.UserHostAddress.ToString(), UserCode);
            else if (rbtnPass.Checked)
            {
                if (flag)
                    StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(hdnCandCode.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.VerificationDoneAppointmentSchedulingPending, Request.UserHostAddress.ToString(), UserCode);
                else
                    StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(hdnCandCode.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.InValidDocuments, Request.UserHostAddress.ToString(), UserCode);
            }
            ClearCandidateAvailedSlots();
            connection.Close();
            Page.RegisterStartupScript("Close", "<script language=JavaScript> CloseHighSlideWithParentRefresh();</script>");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    public void ClearCandidateAvailedSlots()
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_Update_CandidateSlotIsAvailed", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = Convert.ToInt32(hdnCandCode.Value);
        sqlCommand.ExecuteNonQuery();
    }
}