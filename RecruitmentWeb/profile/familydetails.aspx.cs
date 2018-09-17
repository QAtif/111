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
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

public partial class profile_familydetails : CustomBaseClass
{
    #region Page Variables
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    string FinishBtnText = ConfigurationManager.AppSettings["FinishButton"].ToString();
    SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    #endregion Page Variables

    #region Methods
    private void BindData()
    {
        profeExpList.Style.Add("display", "");
        profeExpList.Visible = true;
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            DataSet dataSet = new DataSet();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateMember", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(CandidateCode.ToString()));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                ListView1.DataSource = dataSet;
                ListView1.DataBind();
                profeExpList.Style.Add("display", "");
            }
            else
                profeExpList.Style.Add("display", "none");
        }
    }

    private void ClearControls()
    {
        ddlDay.SelectedValue = "";
        ddlMonth.SelectedValue = "";
        ddlYear.SelectedValue = "";
        txtDesignation.Text = "";
        txtMemberIncome.Text = "";
        txtName.Text = "";
        ddlOccupation.SelectedValue = "";
        txtOrganization.Text = "";
        txtQualification.Text = "";
        ddlRelation.SelectedValue = "";
        ddlStatus.SelectedValue = "-1";
        hfCandidateFamilyMemberCode.Value = "";
        lnkPic.Style["display"] = "none";
        lnkEdit.Style["display"] = "none";
        fuDocument.Style["display"] = "";
        foreach (Control control1 in (IEnumerable<ListViewDataItem>)ListView1.Items)
        {
            HtmlGenericControl control2 = (HtmlGenericControl)control1.FindControl("li");
            control2.Attributes.Remove("class");
            control2.Attributes.Add("class", "jcarousel-item jcarousel-item-horizontal jcarousel-item-2 jcarousel-item-2-horizontal");
        }
    }

    private DataSet UpdateCandidateFamilyMembers()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_UpdateCandidateFamilyMember", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode.ToString());
                selectCommand.Parameters.AddWithValue("@CandidateFamilyMember_Code", hfCandidateFamilyMemberCode.Value);
                selectCommand.Parameters.AddWithValue("@UpdatedBy", (AdminUserCode == -1 ? CandidateCode : AdminUserCode));
                selectCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
                selectCommand.Parameters.AddWithValue("@Relation_Code", Convert.ToInt32(ddlRelation.SelectedValue.ToString()));
                selectCommand.Parameters.AddWithValue("@Qualification", txtQualification.Text);
                selectCommand.Parameters.AddWithValue("@Member_Name", txtName.Text);
                DateTime dateTime = new DateTime(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlDay.SelectedValue));
                selectCommand.Parameters.AddWithValue("@DateOfBirth", dateTime);
                selectCommand.Parameters.AddWithValue("@Occupation_Code", ddlOccupation.SelectedValue);
                selectCommand.Parameters.AddWithValue("@UserType", UserTypeCode);
                if (txtDesignation.Text != "")
                    selectCommand.Parameters.AddWithValue("@Designation", txtDesignation.Text);
                if (txtMemberIncome.Text == "")
                    txtMemberIncome.Text = "0";
                selectCommand.Parameters.AddWithValue("@MonthlyIncome", txtMemberIncome.Text);
                if (txtOrganization.Text != "")
                    selectCommand.Parameters.AddWithValue("@Company_Name", txtOrganization.Text);
                selectCommand.Parameters.AddWithValue("@MaritalStatus_Code", Convert.ToInt32(ddlStatus.SelectedValue));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
                BindRelation("0");
            }
        }
        return dataSet;
    }

    private void UpdateCandidateNICPath(string FilePath, string FMemberCode)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateFamilyMemberFilePath", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", CandidateCode));
                sqlCommand.Parameters.Add(new SqlParameter("@NICPath", FilePath));
                sqlCommand.Parameters.Add(new SqlParameter("@FamilyMemberCode", FMemberCode));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    private void UpdateCandidatePicturePath(string FilePath, string FMemberCode)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateFamilyMemberFilePath", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", CandidateCode));
                sqlCommand.Parameters.Add(new SqlParameter("@PicturePath", FilePath));
                sqlCommand.Parameters.Add(new SqlParameter("@FamilyMemberCode", FMemberCode));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    private void BindOccupation()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectOccupation", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet != null && dataSet.Tables != null)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    ddlOccupation.DataSource = dataSet;
                    ddlOccupation.DataTextField = "Occupation_Name";
                    ddlOccupation.DataValueField = "Occupation_Code";
                    ddlOccupation.DataBind();
                    ddlOccupation.Items.Insert(0, new ListItem("Select", ""));
                    ddlOccupation.SelectedIndex = 0;
                }
                else
                {
                    ddlOccupation.DataSource = null;
                    ddlOccupation.DataTextField = "Occupation_Name";
                    ddlOccupation.DataValueField = "Occupation_Code";
                    ddlOccupation.DataBind();
                    ddlOccupation.Items.Insert(0, new ListItem("Select", ""));
                    ddlOccupation.SelectedIndex = 0;
                }
            }
            else
            {
                ddlOccupation.DataSource = null;
                ddlOccupation.DataTextField = "Occupation_Name";
                ddlOccupation.DataValueField = "Occupation_Code";
                ddlOccupation.DataBind();
                ddlOccupation.Items.Insert(0, new ListItem("Select", ""));
                ddlOccupation.SelectedIndex = 0;
            }
        }
    }

    private void BindRelation(string type)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectRelation", connection))
            {
                selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(CandidateCode.ToString()));
                if (type != "0")
                    selectCommand.Parameters.AddWithValue("@FamilyMemberCode", type);
                selectCommand.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet != null && dataSet.Tables != null)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    ddlRelation.DataSource = null;
                    ddlRelation.DataBind();
                    ddlRelation.DataSource = dataSet;
                    ddlRelation.DataTextField = "Relation_Name";
                    ddlRelation.DataValueField = "Relation_Code";
                    ddlRelation.DataBind();
                    ddlRelation.Items.Insert(0, new ListItem("Select", ""));
                    ddlRelation.SelectedIndex = 0;
                }
                else
                {
                    ddlRelation.DataSource = null;
                    ddlRelation.DataTextField = "Relation_Name";
                    ddlRelation.DataValueField = "Relation_Code";
                    ddlRelation.DataBind();
                    ddlRelation.Items.Insert(0, new ListItem("Select", ""));
                    ddlRelation.SelectedIndex = 0;
                }
            }
            else
            {
                ddlRelation.DataSource = null;
                ddlRelation.DataTextField = "Relation_Name";
                ddlRelation.DataValueField = "Relation_Code";
                ddlRelation.DataBind();
                ddlRelation.Items.Insert(0, new ListItem("Select", ""));
                ddlRelation.SelectedIndex = 0;
            }
        }
    }

    private void BindYear()
    {
        try
        {
            for (int year = DateTime.Now.Year; year > DateTime.Now.Year - 114; --year)
                ddlYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
            ddlYear.Items.Insert(0, new ListItem("Year", ""));
        }
        catch (Exception ex)
        {
        }
    }

    public void ListView1_ItemEditing(object sender, ListViewEditEventArgs e)
    {
    }

    public void ListView1_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
    }

    public void ListView1_OnItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            HtmlGenericControl control1 = (HtmlGenericControl)e.Item.FindControl("DivFade");
            HtmlGenericControl control2 = (HtmlGenericControl)e.Item.FindControl("li");
            LinkButton control3 = (LinkButton)e.Item.FindControl("lnkEdit");
            control2.Attributes.Remove("class");
            control2.Attributes.Add("class", "jcarousel-item jcarousel-item-horizontal jcarousel-item-2 jcarousel-item-2-horizontal");
            control1.Attributes.Add("onclick", "document.getElementById('" + control3.ClientID + "').click()");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    public void listView_itemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            DataSet objDS = new DataSet();
            if (e.CommandName == "Delete")
            {
                DeleteSelectedExperience(e);
                BindRelation("0");
            }
            if (!(e.CommandName == "Edit"))
                return;
            ClearControls();
            ((HtmlControl)e.Item.FindControl("li")).Attributes.Add("class", "active");
            BindRelation(e.CommandArgument.ToString());
            BindFamilyDetailForEdit(e, objDS);
        }
        catch (Exception ex)
        {
        }
    }

    public void BindFamilyDetailForEdit(ListViewCommandEventArgs e, DataSet objDS)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateMember", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateFamilyMemberCode", Convert.ToInt32(e.CommandArgument.ToString()));
                    selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(objDS);
                    if (objDS == null || objDS.Tables == null || objDS.Tables[0].Rows.Count <= 0)
                        return;
                    txtDesignation.Text = objDS.Tables[0].Rows[0]["MemberDesignation"].ToString();
                    ddlMonth.SelectedValue = Convert.ToDateTime(objDS.Tables[0].Rows[0]["MemberDOB"].ToString()).Month.ToString();
                    ddlYear.SelectedValue = Convert.ToDateTime(objDS.Tables[0].Rows[0]["MemberDOB"].ToString()).Year.ToString();
                    ddlDay.SelectedValue = Convert.ToDateTime(objDS.Tables[0].Rows[0]["MemberDOB"].ToString()).Day.ToString();
                    txtMemberIncome.Text = !(objDS.Tables[0].Rows[0]["MemberIncome"].ToString() == "0.00") ? objDS.Tables[0].Rows[0]["MemberIncome"].ToString() : "";
                    txtName.Text = objDS.Tables[0].Rows[0]["MemberName"].ToString();
                    ddlOccupation.SelectedValue = objDS.Tables[0].Rows[0]["Occupation_Code"].ToString();
                    txtOrganization.Text = objDS.Tables[0].Rows[0]["MemberOrganization"].ToString();
                    txtQualification.Text = objDS.Tables[0].Rows[0]["MemberQualification"].ToString();
                    ddlRelation.SelectedValue = objDS.Tables[0].Rows[0]["Relation_Code"].ToString();
                    ddlStatus.SelectedValue = objDS.Tables[0].Rows[0]["MaritalStatus_Code"].ToString();
                    hfCandidateFamilyMemberCode.Value = objDS.Tables[0].Rows[0]["CandidateFamilyMember_Code"].ToString();
                    if (objDS.Tables[0].Rows[0]["FamilyMemberPic_Path"].ToString() != string.Empty)
                    {
                        lnkPic.Style["display"] = "";
                        lnkEdit.Style["display"] = "";
                        lnkPic.HRef = objDS.Tables[0].Rows[0]["FamilyMemberPic_Path"].ToString();
                        fuDocument.Style["display"] = "none";
                    }
                    else
                    {
                        lnkEdit.Style["display"] = "none";
                        lnkPic.Style["display"] = "none";
                        fuDocument.Style["display"] = "";
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
            }
        }
    }

    private void DeleteSelectedExperience(ListViewCommandEventArgs e)
    {
        try
        {
            if (!(e.CommandName == "Delete"))
                return;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                connection.Open();
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand("XRec_DeactivateCandidateFamilyMember", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@CandidateFamilyMemberCode", Convert.ToInt32(e.CommandArgument.ToString()));
                        sqlCommand.Parameters.AddWithValue("@UpdatedBy", (AdminUserCode == -1 ? CandidateCode : AdminUserCode));
                        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                        sqlCommand.ExecuteNonQuery();
                    }
                    BindData();
                }
                catch (Exception ex)
                {
                    LogError.Write(LogError.AppType.Candidate, "XRec_DeactivateCandidateExperience", ex, CandidateCode.ToString());
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            if (Convert.ToInt32(Constants.ProfileNavigation.FamilyDetails) == Convert.ToInt32(GeneralMethods.GetProfileNavCount(SqlConn, CandidateCode).Rows[0]["FinishCode"].ToString()))
                btnContinue.Text = FinishBtnText;
            BindYear();
            BindOccupation();
            BindRelation("0");
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void rptCandidateMember_OnItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            DataSet dataSet = new DataSet();
            if ((e.CommandName == "Delete" || e.CommandName == "Delete") && e.CommandName == "Delete")
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    connection.Open();
                    try
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("XRec_DeactivateCandidateFamilyMember", connection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@CandidateFamilyMemberCode", Convert.ToInt32(e.CommandArgument.ToString()));
                            sqlCommand.Parameters.AddWithValue("@UpdatedBy", (AdminUserCode == -1 ? CandidateCode : AdminUserCode));
                            sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                            sqlCommand.ExecuteNonQuery();
                            BindData();
                            ClearControls();
                        }
                    }
                    catch (Exception ex)
                    {
                        LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
                    }
                }
            }
            if (!(e.CommandName == "Edit"))
                return;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                connection.Open();
                try
                {
                    using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateMember", connection))
                    {
                        selectCommand.CommandType = CommandType.StoredProcedure;
                        selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
                        selectCommand.Parameters.AddWithValue("@CandidateFamilyMemberCode", Convert.ToInt32(e.CommandArgument.ToString()));
                        selectCommand.ExecuteNonQuery();
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                            sqlDataAdapter.Fill(dataSet);
                        if (dataSet != null)
                        {
                            if (dataSet.Tables != null)
                            {
                                if (dataSet.Tables[0].Rows.Count > 0)
                                {
                                    txtDesignation.Text = dataSet.Tables[0].Rows[0]["MemberDesignation"].ToString();
                                    ddlMonth.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["MemberDOB"].ToString()).Month.ToString();
                                    ddlYear.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["MemberDOB"].ToString()).Year.ToString();
                                    ddlDay.SelectedValue = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["MemberDOB"].ToString()).Day.ToString();
                                    txtMemberIncome.Text = !(dataSet.Tables[0].Rows[0]["MemberIncome"].ToString() == "0.00") ? dataSet.Tables[0].Rows[0]["MemberIncome"].ToString() : "";
                                    txtName.Text = dataSet.Tables[0].Rows[0]["MemberName"].ToString();
                                    ddlOccupation.SelectedValue = dataSet.Tables[0].Rows[0]["Occupation_Code"].ToString();
                                    txtOrganization.Text = dataSet.Tables[0].Rows[0]["MemberOrganization"].ToString();
                                    txtQualification.Text = dataSet.Tables[0].Rows[0]["MemberQualification"].ToString();
                                    ddlRelation.SelectedValue = dataSet.Tables[0].Rows[0]["Relation_Code"].ToString();
                                }
                            }
                        }
                    }
                    hfCandidateFamilyMemberCode.Value = e.CommandArgument.ToString();
                }
                catch (Exception ex)
                {
                    LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
                }
            }
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
            if (!Page.IsValid)
                return;
            DataSet dataSet1 = new DataSet();
            DataSet dataSet2 = UpdateCandidateFamilyMembers();
            if (dataSet2.Tables[0].Rows.Count > 0)
                SaveDocuments(dataSet2.Tables[0].Rows[0]["CandidateFamilyMember_Code"].ToString());
            StatusManagement.MarkProfileStatus(SqlConn, CandidateCode, Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.ProfileDone, Request.UserHostAddress, CandidateCode, Constants.ProfileNavigation.FamilyDetails);
            ClearControls();
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    private void SaveDocuments(string CandidateFamilyMember_Code)
    {
        if (!fuDocument.HasFile)
            return;
        string empty = string.Empty;
        string path = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + CandidateCode + "/Personal/" + (CandidateFamilyMember_Code + "_PIC" + Path.GetExtension(fuDocument.FileName));
        if (!Directory.Exists(Server.MapPath(ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + CandidateCode + "/Personal/")))
            Directory.CreateDirectory(Server.MapPath(ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + CandidateCode + "/Personal/"));
        GeneralMethods.FileBrowse(fuDocument, ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + CandidateCode + "/Personal/", Path.GetFileNameWithoutExtension(path));
        try
        {
            SqlConn.Open();
            SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateFamilyMemberPic", SqlConn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
            sqlCommand.Parameters.AddWithValue("@CandidateFamilyMember_Code", CandidateFamilyMember_Code);
            sqlCommand.Parameters.AddWithValue("@DocumentPath", path);
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", CandidateCode);
            sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
        finally
        {
            SqlConn.Close();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            HttpContext.Current.Response.Redirect(DomainAddress + "CandidateArea/Area.aspx", false);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void btnAddMore_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ClearControls();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    public static void CreateFolder(string FolderPath)
    {
        string empty = string.Empty;
        string path = !profile_familydetails.IsValidPath(FolderPath) ? HttpContext.Current.Server.MapPath(FolderPath) : FolderPath;
        if (new DirectoryInfo(path).Exists)
            return;
        Directory.CreateDirectory(path);
    }

    public static bool IsValidPath(string path)
    {
        return new Regex("^(?:[a-zA-Z]\\:|\\\\\\\\[\\w\\.]+\\\\[\\w.]+)\\\\(?:[\\w]+\\\\)*").IsMatch(path);
    }

    protected void btnProceed_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dataSet1 = new DataSet();
            DataSet dataSet2 = UpdateCandidateFamilyMembers();
            if (dataSet2.Tables[0].Rows.Count > 0)
                SaveDocuments(dataSet2.Tables[0].Rows[0]["CandidateFamilyMember_Code"].ToString());
            ClearControls();
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlRelation.SelectedValue != "")
                btnSave_Click(null, (EventArgs)null);
            Response.Redirect(DomainAddress + "area/viewprofile.aspx", false);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    #endregion

}