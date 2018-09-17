using ErrorLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using XRecruitmentStatusLibrary;

public partial class A2_Reports_offerApproval : CustomBasePage
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SecureQueryString sQString = new SecureQueryString();
    DataSet dsRptCat = new DataSet();
    //  int UserCode = 660;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptDepartment_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        Repeater control1 = (Repeater)e.Item.FindControl("rptCat");
        HiddenField control2 = (HiddenField)e.Item.FindControl("hdnDepCode");
        if (control2 == null)
            return;
        SqlCommand selectCommand = new SqlCommand("OfferApprovalGetDepartmentWiseCandidate", connection);
        selectCommand.Parameters.AddWithValue("@DomainCode", control2.Value);
        selectCommand.Parameters.AddWithValue("@OfferApprovalStatus_Code", ddlStatus.SelectedValue);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet == null || dataSet.Tables[0].Rows.Count <= 0)
            return;
        control1.DataSource = dataSet.Tables[0];
        control1.DataBind();
    }

    public DataSet GetCandidateOfferApproval(int candidateCode)
    {
        DataSet dataSet = new DataSet();
        SqlCommand selectCommand = new SqlCommand("Select_OfferApprovalStatusHistory", connection);
        selectCommand.Parameters.AddWithValue("@CandidateCode", candidateCode);
        selectCommand.CommandType = CommandType.StoredProcedure;
        new SqlDataAdapter(selectCommand).Fill(dataSet);
        return dataSet;
    }

    protected void rptInterviewComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        ((WebControl)e.Item.FindControl("lblComments")).ToolTip = DataBinder.Eval(e.Item.DataItem, "Comments").ToString();
    }

    protected void rptCat_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        Repeater control1 = (Repeater)e.Item.FindControl("rptQualification");
        Repeater control2 = (Repeater)e.Item.FindControl("rptExperience");
        Repeater control3 = (Repeater)e.Item.FindControl("rptFamilyDetails");
        Repeater control4 = (Repeater)e.Item.FindControl("rptInterviewComments");
        HiddenField control5 = (HiddenField)e.Item.FindControl("hdnCandCode");
        ((HtmlImage)e.Item.FindControl("imgBigImage")).Src = DataBinder.Eval(e.Item.DataItem, "ProfileImage_Path").ToString();
        ((HtmlControl)e.Item.FindControl("ABigImage")).Attributes.Add("data-rel", DataBinder.Eval(e.Item.DataItem, "ProfileImage_Path").ToString());
        ((WebControl)e.Item.FindControl("lblDesignation")).ToolTip = DataBinder.Eval(e.Item.DataItem, "Designation_Name_Full").ToString();
        ((WebControl)e.Item.FindControl("lblCansideredForJD")).ToolTip = DataBinder.Eval(e.Item.DataItem, "CansideredForJD").ToString();
        Label control6 = (Label)e.Item.FindControl("lblDomain_Name");
        control6.ToolTip = DataBinder.Eval(e.Item.DataItem, "Domain_Name_Full").ToString();
        control6.Text = DataBinder.Eval(e.Item.DataItem, "Domain_Name").ToString();
        HtmlAnchor control7 = (HtmlAnchor)e.Item.FindControl("aCandidateLink");
        if (control5 != null)
        {
            string str = "../../A2/candidate/CandidateProfile.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + control5.Value);
            control7.HRef = str;
        }
        HtmlAnchor control8 = (HtmlAnchor)e.Item.FindControl("a1");
        if (control5 != null)
        {
            string str = "../../A2/candidate/CandidateProfile.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + control5.Value);
            control8.HRef = str;
        }
        if (control5 == null)
            return;
        SqlCommand selectCommand1 = new SqlCommand("XRec_SelectCandidateEducationDetailsForOfferApprovalDeatils", connection);
        selectCommand1.Parameters.AddWithValue("@CandidateCode", control5.Value);
        selectCommand1.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(selectCommand1);
        DataSet dataSet1 = new DataSet();
        sqlDataAdapter1.Fill(dataSet1);
        if (dataSet1.Tables[0].Rows.Count > 0)
        {
            Label control9 = (Label)e.Item.FindControl("lblDegree");
            Label control10 = (Label)e.Item.FindControl("lblInstitute");
            Label control11 = (Label)e.Item.FindControl("lblGPA");
            Label control12 = (Label)e.Item.FindControl("lblPassingYear");
            Label control13 = (Label)e.Item.FindControl("lblMajorName");
            control9.Text = dataSet1.Tables[0].Rows[0]["Degree"].ToString();
            control10.Text = dataSet1.Tables[0].Rows[0]["Institute"].ToString();
            control9.ToolTip = dataSet1.Tables[0].Rows[0]["DegreeFull"].ToString();
            control10.ToolTip = dataSet1.Tables[0].Rows[0]["InstituteFull"].ToString();
            control11.Text = dataSet1.Tables[0].Rows[0]["Grade"].ToString();
            control12.Text = dataSet1.Tables[0].Rows[0]["EndDate"].ToString();
            control13.Text = dataSet1.Tables[0].Rows[0]["Field"].ToString();
        }
        SqlCommand selectCommand2 = new SqlCommand("Xrec_SelectCandidateExperienxeListForOfferApprovalDeatils", connection);
        selectCommand2.Parameters.AddWithValue("@CandidateCode", control5.Value);
        selectCommand2.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
        DataSet dataSet2 = new DataSet();
        sqlDataAdapter2.Fill(dataSet2);
        if (dataSet2.Tables[0].Rows.Count > 0)
        {
            Label control9 = (Label)e.Item.FindControl("lblSalary");
            Label control10 = (Label)e.Item.FindControl("lblDuration");
            Label control11 = (Label)e.Item.FindControl("lblCompany");
            Label control12 = (Label)e.Item.FindControl("lblJobTitle");
            Label control13 = (Label)e.Item.FindControl("lblTotalExperience");
            control9.Text = dataSet2.Tables[0].Rows[0]["Current_Salary"].ToString();
            control10.Text = dataSet2.Tables[0].Rows[0]["duration"].ToString();
            control11.Text = dataSet2.Tables[0].Rows[0]["fullname"].ToString();
            control12.Text = dataSet2.Tables[0].Rows[0]["Position"].ToString();
            control13.Text = dataSet2.Tables[0].Rows[0]["TotalExperience"].ToString();
        }
        SqlCommand selectCommand3 = new SqlCommand("XRec_SelectCandidateEducationDetailsForOfferApproval", connection);
        selectCommand3.Parameters.AddWithValue("@CandidateCode", control5.Value);
        selectCommand3.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
        DataSet dataSet3 = new DataSet();
        sqlDataAdapter3.Fill(dataSet3);
        if (dataSet3.Tables[0].Rows.Count > 0)
        {
            control1.DataSource = dataSet3.Tables[0];
            control1.DataBind();
        }
        SqlCommand selectCommand4 = new SqlCommand("Xrec_SelectCandidateExperienxeListForOfferApproval", connection);
        selectCommand4.Parameters.AddWithValue("@candidateCode", control5.Value);
        selectCommand4.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
        DataSet dataSet4 = new DataSet();
        sqlDataAdapter4.Fill(dataSet4);
        if (dataSet4.Tables[0].Rows.Count > 0)
        {
            control2.DataSource = dataSet4.Tables[0];
            control2.DataBind();
        }
        SqlCommand selectCommand5 = new SqlCommand("Xrec_SelectCandidateFamilyDetailsForOfferApproval", connection);
        selectCommand5.Parameters.AddWithValue("@CandidateCode", control5.Value);
        selectCommand5.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
        DataSet dataSet5 = new DataSet();
        sqlDataAdapter5.Fill(dataSet5);
        if (dataSet5.Tables[0].Rows.Count > 0)
        {
            control3.DataSource = dataSet5.Tables[0];
            control3.DataBind();
        }
        if (dataSet5.Tables[1].Rows.Count > 0)
        {
            control4.DataSource = dataSet5.Tables[1];
            control4.DataBind();
        }
        DataSet candidateOfferApproval = GetCandidateOfferApproval(int.Parse(control5.Value));
        if (candidateOfferApproval.Tables[0].Rows.Count <= 0 || candidateOfferApproval.Tables[0].Rows.Count <= 0)
            return;
        if (Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.HRPDApprovalPending) || Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.HRPPDRejected))
        {
            ((HtmlControl)e.Item.FindControl("divAction84")).Style["display"] = "none";
            ((HtmlControl)e.Item.FindControl("divAction85")).Style["display"] = "none";
            ((HtmlControl)e.Item.FindControl("divAction86")).Style["display"] = "none";
        }
        if (Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.DOApprovalPending) || Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.DORejected))
        {
            ((HtmlControl)e.Item.FindControl("divAction83")).Style["display"] = "none";
            ((HtmlControl)e.Item.FindControl("divAction85")).Style["display"] = "none";
            ((HtmlControl)e.Item.FindControl("divAction86")).Style["display"] = "none";
        }
        if (Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.OPDApprovalPending) || Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.OPDRejected))
        {
            ((HtmlControl)e.Item.FindControl("divAction83")).Style["display"] = "none";
            ((HtmlControl)e.Item.FindControl("divAction84")).Style["display"] = "none";
            ((HtmlControl)e.Item.FindControl("divAction86")).Style["display"] = "none";
        }
        if (Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) != Convert.ToInt32(Constants.OfferApprovalStatus.AutidApprovalPending) && Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) != Convert.ToInt32(Constants.OfferApprovalStatus.Rejected))
            return;
        ((HtmlControl)e.Item.FindControl("divAction83")).Style["display"] = "none";
        ((HtmlControl)e.Item.FindControl("divAction84")).Style["display"] = "none";
        ((HtmlControl)e.Item.FindControl("divAction85")).Style["display"] = "none";
    }

    private void BindData()
    {
        try
        {
            connection.Open();
            SqlCommand selectCommand1 = new SqlCommand("XRec_SelectUserTypeByUser", connection);
            selectCommand1.Parameters.AddWithValue("@UserCode", UserCode);
            selectCommand1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(selectCommand1);
            DataSet dataSet1 = new DataSet();
            sqlDataAdapter1.Fill(dataSet1);
            if (dataSet1.Tables[0].Rows.Count > 0)
                hdnUserTypeCode.Value = dataSet1.Tables[0].Rows[0]["UserTypeCode"].ToString();
            SqlCommand selectCommand2 = new SqlCommand("OfferApprovalGetDepartment_New", connection);
            selectCommand2.Parameters.AddWithValue("@UserCode", UserCode);
            selectCommand2.Parameters.AddWithValue("@OfferApprovalStatus_Code", ddlStatus.SelectedValue);
            selectCommand2.Parameters.AddWithValue("@Is_SupportStaff", rdoSupportStaff.Checked ? "1" : "0");
            selectCommand2.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
            DataSet dataSet2 = new DataSet();
            sqlDataAdapter2.Fill(dataSet2);
            if (dataSet2 != null)
            {
                if (dataSet2.Tables[0].Rows.Count > 0)
                {
                    rptDeparments.DataSource = dataSet2.Tables[0];
                    rptDeparments.DataBind();
                    tblNoRecord.Style["display"] = "none";
                }
                else
                {
                    rptDeparments.DataSource = null;
                    rptDeparments.DataBind();
                    tblNoRecord.Style["display"] = "";
                }
            }
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

    private void UpdateOfferApprovalStatus(int Candidate_Code, int offerApprovalStatusCode, int userTypeCode)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_UpdateOfferApprovalStatus", connection);
        sqlCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_Code);
        sqlCommand.Parameters.AddWithValue("@OfferApproval_Code", offerApprovalStatusCode);
        sqlCommand.Parameters.AddWithValue("@UserTypeCode", userTypeCode);
        sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
        sqlCommand.Parameters.AddWithValue("@Updated_IP", USERIP);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.ExecuteNonQuery();
    }

    private void UpdateOfferApprovalStatusHistoryComments(int Candidate_Code, string Comments)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_Insert_OfferApprovalStatusHistoryComments", connection);
        sqlCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_Code);
        sqlCommand.Parameters.AddWithValue("@Comments", Comments);
        sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
        sqlCommand.Parameters.AddWithValue("@Updated_IP", USERIP);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.ExecuteNonQuery();
    }

    protected void rptCat_CommandArguments(object sender, RepeaterCommandEventArgs e)
    {
        RepeaterItem parent = (RepeaterItem)e.Item.Parent.Parent.Parent.Parent;
        string id = parent.ID;
        HtmlGenericControl control = (HtmlGenericControl)parent.FindControl("liDept").FindControl("dvContent");
        string clientId = control.ClientID;
        A2.Attributes.Add("onclick", "expandAllTo('" + control.ClientID + "')");
        if (!(e.CommandName == "ApproveHR"))
        {
            if (!(e.CommandName == "DisapproveHR"))
                goto label_11;
        }
        try
        {
            connection.Open();
            UpdateOfferApprovalStatus(int.Parse(e.CommandArgument.ToString()), e.CommandName == "ApproveHR" ? Convert.ToInt32(Constants.OfferApprovalStatus.DOApprovalPending) : Convert.ToInt32(Constants.OfferApprovalStatus.HRPPDRejected), int.Parse(hdnUserTypeCode.Value));
            if (e.CommandName == "DisapproveHR")
                UpdateOfferApprovalStatusHistoryComments(int.Parse(e.CommandArgument.ToString()), hdnComments.Value);
            if (e.CommandName == "ApproveHR")
                UpdateOfferApprovalStatusHistoryComments(int.Parse(e.CommandArgument.ToString()), hdnComments.Value);
            if (e.CommandName == "DisapproveHR")
                StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(e.CommandArgument.ToString()), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.InterviewFailedReSchedulingPending, USERIP, UserCode);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            connection.Close();
        }
        BindData();
        ShowHideActions();
        label_11:
        if (!(e.CommandName == "ApproveDO"))
        {
            if (!(e.CommandName == "DisapproveDO"))
                goto label_22;
        }
        try
        {
            connection.Open();
            UpdateOfferApprovalStatus(int.Parse(e.CommandArgument.ToString()), e.CommandName == "ApproveDO" ? Convert.ToInt32(Constants.OfferApprovalStatus.OPDApprovalPending) : Convert.ToInt32(Constants.OfferApprovalStatus.DORejected), int.Parse(hdnUserTypeCode.Value));
            if (e.CommandName == "DisapproveDO")
                UpdateOfferApprovalStatusHistoryComments(int.Parse(e.CommandArgument.ToString()), hdnComments.Value);
            if (e.CommandName == "ApproveDO")
                UpdateOfferApprovalStatusHistoryComments(int.Parse(e.CommandArgument.ToString()), hdnComments.Value);
            if (e.CommandName == "DisapproveDO")
                StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(e.CommandArgument.ToString()), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.InterviewFailedReSchedulingPending, USERIP, UserCode);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            connection.Close();
        }
        BindData();
        ShowHideActions();
        label_22:
        if (!(e.CommandName == "ApproveOPD"))
        {
            if (!(e.CommandName == "DisapproveOPD"))
                goto label_35;
        }
        try
        {
            connection.Open();
            UpdateOfferApprovalStatus(int.Parse(e.CommandArgument.ToString()), e.CommandName == "ApproveOPD" ? Convert.ToInt32(Constants.OfferApprovalStatus.AutidApprovalPending) : Convert.ToInt32(Constants.OfferApprovalStatus.OPDRejected), int.Parse(hdnUserTypeCode.Value));
            if (e.CommandName == "DisapproveOPD")
                UpdateOfferApprovalStatusHistoryComments(int.Parse(e.CommandArgument.ToString()), hdnComments.Value);
            if (e.CommandName == "ApproveOPD")
                UpdateOfferApprovalStatusHistoryComments(int.Parse(e.CommandArgument.ToString()), hdnComments.Value);
            if (e.CommandName == "ApproveOPD")
                StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(e.CommandArgument.ToString()), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.InterviewPassedOfferGenerationPending, USERIP, UserCode);
            if (e.CommandName == "DisapproveOPD")
                StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(e.CommandArgument.ToString()), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.InterviewFailedReSchedulingPending, USERIP, UserCode);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            connection.Close();
        }
        BindData();
        ShowHideActions();
        label_35:
        if (!(e.CommandName == "ApproveAA"))
        {
            if (!(e.CommandName == "DisapproveAA"))
                goto label_41;
        }
        try
        {
            connection.Open();
            UpdateOfferApprovalStatus(int.Parse(e.CommandArgument.ToString()), e.CommandName == "ApproveAA" ? Convert.ToInt32(Constants.OfferApprovalStatus.Approved) : Convert.ToInt32(Constants.OfferApprovalStatus.Rejected), int.Parse(hdnUserTypeCode.Value));
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            connection.Close();
        }
        BindData();
        ShowHideActions();
        label_41:
        ScriptManager.RegisterStartupScript((Page)this, GetType(), "exists", "document.getElementById('" + A2.ClientID + "').click();", true);
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

    protected void lnkapproveAll_Click(object sender, EventArgs e)
    {
        DataSet dataSet = new DataSet();
        try
        {
            connection.Open();
            for (int index1 = 0; index1 <= rptDeparments.Items.Count - 1; ++index1)
            {
                Repeater control1 = (Repeater)rptDeparments.Items[index1].FindControl("rptCat");
                for (int index2 = 0; index2 <= control1.Items.Count - 1; ++index2)
                {
                    if (((CheckBox)control1.Items[index2].FindControl("chkCandCode")).Checked)
                    {
                        HiddenField control2 = (HiddenField)control1.Items[index2].FindControl("hdnCandCode");
                        DataSet candidateOfferApproval = GetCandidateOfferApproval(int.Parse(control2.Value));
                        if (candidateOfferApproval.Tables[0].Rows.Count > 0)
                        {
                            if ((Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.HRPDApprovalPending) || Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.HRPPDRejected)) && control1.Items[index2].FindControl("divAction83").Visible)
                                UpdateOfferApprovalStatus(int.Parse(control2.Value), Convert.ToInt32(Constants.OfferApprovalStatus.DOApprovalPending), int.Parse(hdnUserTypeCode.Value));
                            if ((Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.DOApprovalPending) || Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.DORejected)) && control1.Items[index2].FindControl("divAction84").Visible)
                                UpdateOfferApprovalStatus(int.Parse(control2.Value), Convert.ToInt32(Constants.OfferApprovalStatus.OPDApprovalPending), int.Parse(hdnUserTypeCode.Value));
                            if ((Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.OPDApprovalPending) || Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.OPDRejected)) && control1.Items[index2].FindControl("divAction85").Visible)
                            {
                                UpdateOfferApprovalStatus(int.Parse(control2.Value), Convert.ToInt32(Constants.OfferApprovalStatus.AutidApprovalPending), int.Parse(hdnUserTypeCode.Value));
                                StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(control2.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.InterviewPassedOfferGenerationPending, USERIP, UserCode);
                            }
                            if ((Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.AutidApprovalPending) || Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.Rejected)) && control1.Items[index2].FindControl("divAction86").Visible)
                                UpdateOfferApprovalStatus(int.Parse(control2.Value), Convert.ToInt32(Constants.OfferApprovalStatus.Approved), int.Parse(hdnUserTypeCode.Value));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            connection.Close();
        }
        BindData();
        ShowHideActions();
    }

    protected void lnkDisapproveAll_Click(object sender, EventArgs e)
    {
        DataSet dataSet = new DataSet();
        try
        {
            connection.Open();
            for (int index1 = 0; index1 <= rptDeparments.Items.Count - 1; ++index1)
            {
                Repeater control1 = (Repeater)rptDeparments.Items[index1].FindControl("rptCat");
                for (int index2 = 0; index2 <= control1.Items.Count - 1; ++index2)
                {
                    if (((CheckBox)control1.Items[index2].FindControl("chkCandCode")).Checked)
                    {
                        HiddenField control2 = (HiddenField)control1.Items[index2].FindControl("hdnCandCode");
                        DataSet candidateOfferApproval = GetCandidateOfferApproval(int.Parse(control2.Value));
                        if (candidateOfferApproval.Tables[0].Rows.Count > 0)
                        {
                            if ((Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.HRPDApprovalPending) || Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.HRPPDRejected)) && control1.Items[index2].FindControl("divAction83").Visible)
                                UpdateOfferApprovalStatus(int.Parse(control2.Value), Convert.ToInt32(Constants.OfferApprovalStatus.HRPPDRejected), int.Parse(hdnUserTypeCode.Value));
                            if ((Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.DOApprovalPending) || Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.DORejected)) && control1.Items[index2].FindControl("divAction84").Visible)
                                UpdateOfferApprovalStatus(int.Parse(control2.Value), Convert.ToInt32(Constants.OfferApprovalStatus.DORejected), int.Parse(hdnUserTypeCode.Value));
                            if ((Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.OPDApprovalPending) || Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.OPDRejected)) && control1.Items[index2].FindControl("divAction85").Visible)
                            {
                                UpdateOfferApprovalStatus(int.Parse(control2.Value), Convert.ToInt32(Constants.OfferApprovalStatus.OPDRejected), int.Parse(hdnUserTypeCode.Value));
                                StatusManagement.MarkLifeCycleStatus(connection, Convert.ToInt32(control2.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.InterviewPassedOfferGenerationPending, USERIP, UserCode);
                            }
                            if ((Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.AutidApprovalPending) || Convert.ToInt32(candidateOfferApproval.Tables[0].Rows[0]["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.Rejected)) && control1.Items[index2].FindControl("divAction86").Visible)
                                UpdateOfferApprovalStatus(int.Parse(control2.Value), Convert.ToInt32(Constants.OfferApprovalStatus.Rejected), int.Parse(hdnUserTypeCode.Value));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            connection.Close();
        }
        BindData();
        ShowHideActions();
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rdoOfficer_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rdoSupportStaff_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }
}
