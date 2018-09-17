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

public partial class CandidateFamilyMembers : CustomBasePage
{
    #region Page Variables
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    string CID;
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;
    #endregion Page Variables

    #region Methods
    private void BindData()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateMember", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", CID);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet != null && dataSet.Tables != null)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    rptCandidateMember.DataSource = dataSet;
                    rptCandidateMember.DataBind();
                }
                else
                {
                    rptCandidateMember.DataSource = null;
                    rptCandidateMember.DataBind();
                }
            }
            else
            {
                rptCandidateMember.DataSource = null;
                rptCandidateMember.DataBind();
            }
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
        txtOcupation.Text = "";
        txtOrganization.Text = "";
        txtQualification.Text = "";
        ddlRelation.SelectedValue = "";
        hfCandidateFamilyMemberCode.Value = "";
        fuNIC.Style.Add("display", "block");
        ImgbtnNIC.Visible = false;
        btnChangeNIC.Style.Add("display", "none");
        fuPicture.Style.Add("display", "block");
        ImgbtnPicture.Visible = false;
        btnChangePicture.Style.Add("display", "none");
        btnAddMore.Visible = false;
    }

    private DataSet UpdateCandidateFamilyMembers()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_UpdateCandidateFamilyMember", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(CID));
                selectCommand.Parameters.AddWithValue("@CandidateFamilyMember_Code", hfCandidateFamilyMemberCode.Value);
                selectCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
                selectCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
                selectCommand.Parameters.AddWithValue("@SiblingCount", Convert.ToInt32(ddlSiblingCount.SelectedValue.ToString()));
                selectCommand.Parameters.AddWithValue("@PositionInSiblings", Convert.ToInt32(ddlCandidateSiblingPosition.SelectedValue.ToString()));
                selectCommand.Parameters.AddWithValue("@Relation_Code", Convert.ToInt32(ddlRelation.SelectedValue.ToString()));
                selectCommand.Parameters.AddWithValue("@Qualification", txtQualification.Text);
                selectCommand.Parameters.AddWithValue("@Company_Name", txtOrganization.Text);
                selectCommand.Parameters.AddWithValue("@Member_Name", txtName.Text);
                DateTime dateTime = new DateTime(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlDay.SelectedValue));
                selectCommand.Parameters.AddWithValue("@DateOfBirth", dateTime);
                selectCommand.Parameters.AddWithValue("@Occupation", txtOcupation.Text);
                selectCommand.Parameters.AddWithValue("@Designation", txtDesignation.Text);
                selectCommand.Parameters.AddWithValue("@MonthlyIncome", txtMemberIncome.Text);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }

    private void UpdateCandidateNICPath(string FilePath, string FMemberCode)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateFamilyMemberFilePath", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", CID));
                sqlCommand.Parameters.Add(new SqlParameter("@NICPath", FilePath));
                sqlCommand.Parameters.Add(new SqlParameter("@FamilyMemberCode", FMemberCode));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    private void UpdateCandidatePicturePath(string FilePath, string FMemberCode)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateFamilyMemberFilePath", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", CID));
                sqlCommand.Parameters.Add(new SqlParameter("@PicturePath", FilePath));
                sqlCommand.Parameters.Add(new SqlParameter("@FamilyMemberCode", FMemberCode));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    private void BindRelation()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectRelation", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet != null && dataSet.Tables != null)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    ddlRelation.DataSource = dataSet;
                    ddlRelation.DataTextField = "Relation_Name";
                    ddlRelation.DataValueField = "Relation_Code";
                    ddlRelation.DataBind();
                    ddlRelation.Items.Insert(0, new ListItem("--Select--", ""));
                    ddlRelation.SelectedIndex = 0;
                }
                else
                {
                    ddlRelation.DataSource = null;
                    ddlRelation.DataTextField = "Relation_Name";
                    ddlRelation.DataValueField = "Relation_Code";
                    ddlRelation.DataBind();
                    ddlRelation.Items.Insert(0, new ListItem("--Select--", ""));
                    ddlRelation.SelectedIndex = 0;
                }
            }
            else
            {
                ddlRelation.DataSource = null;
                ddlRelation.DataTextField = "Relation_Name";
                ddlRelation.DataValueField = "Relation_Code";
                ddlRelation.DataBind();
                ddlRelation.Items.Insert(0, new ListItem("--Select--", ""));
                ddlRelation.SelectedIndex = 0;
            }
        }
    }

    public bool CreateDocumentFolder()
    {
        string cid = CID;
        string str = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["CandidateDocumentPath"].ToString());
        if (!Directory.Exists(str + cid + "/FamilyMembers"))
            Directory.CreateDirectory(str + cid + "/FamilyMembers");
        return true;
    }

    public void UploadFiles(string CandidateFamilyMemberCode)
    {
        UploadNIC(CandidateFamilyMemberCode);
        UploadPicture(CandidateFamilyMemberCode);
    }

    private void UploadPicture(string FamilyMemberCode)
    {
        if (!fuPicture.HasFile)
            return;
        string lower = Path.GetExtension(fuPicture.FileName).ToLower();
        if (CandidateSignup.validatefile(fuPicture))
        {
            string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + Convert.ToInt32(CID) + "/Family/";
            GeneralMethods.FileBrowse(fuPicture, FolderPath, FamilyMemberCode + "_PIC");
            UpdateCandidatePicturePath(FolderPath + FamilyMemberCode + "_PIC" + lower, FamilyMemberCode);
        }
        else
            lblMsg.Text = "Maximum Size for the file upload is 2MB";
    }

    private void UploadNIC(string FamilyMemberCode)
    {
        if (!fuNIC.HasFile)
            return;
        string lower = Path.GetExtension(fuNIC.FileName).ToLower();
        if (GeneralMethods.validatefile(fuNIC))
        {
            string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + Convert.ToInt32(CID) + "/Family/";
            GeneralMethods.FileBrowse(fuNIC, FolderPath, FamilyMemberCode + "_NIC");
            UpdateCandidateNICPath(FolderPath + FamilyMemberCode + "_NIC" + lower, FamilyMemberCode);
        }
        else
            lblMsg.Text = "Maximum Size for the file upload is 2MB";
    }

    private void BindCandidateSilblingCount()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateSiblingInfo", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", CID);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet == null || dataSet.Tables == null || dataSet.Tables[0].Rows.Count <= 0)
                return;
            ddlCandidateSiblingPosition.SelectedValue = dataSet.Tables[0].Rows[0]["PositionInSiblings"].ToString();
            ddlSiblingCount.SelectedValue = dataSet.Tables[0].Rows[0]["SiblingCount"].ToString();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            if (QueryStringVar == null)
                return;
            secQueryString = new SecureQueryString(QueryStringVar);
            if (secQueryString["CID"] == null)
                return;
            CID = secQueryString["CID"].ToString();
            if (IsPostBack)
                return;
            BindRelation();
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CID);
        }
    }

    protected void rptCandidateMember_OnItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            DataSet dataSet = new DataSet();
            if ((e.CommandName == "Delete" || e.CommandName == "Delete") && e.CommandName == "Delete")
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
                {
                    connection.Open();
                    try
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("XRec_DeactivateCandidateFamilyMember", connection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@CandidateFamilyMemberCode", Convert.ToInt32(e.CommandArgument.ToString()));
                            sqlCommand.Parameters.AddWithValue("@UpdatedBy", Convert.ToInt32(CID));
                            sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                            sqlCommand.ExecuteNonQuery();
                            BindData();
                            ClearControls();
                        }
                    }
                    catch (Exception ex)
                    {
                        LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CID);
                    }
                }
            }
            if (!(e.CommandName == "Edit"))
                return;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
            {
                connection.Open();
                try
                {
                    using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateMember", connection))
                    {
                        selectCommand.CommandType = CommandType.StoredProcedure;
                        selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(CID));
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
                                    txtMemberIncome.Text = dataSet.Tables[0].Rows[0]["MemberIncome"].ToString().Split('.')[0].ToString();
                                    txtName.Text = dataSet.Tables[0].Rows[0]["MemberName"].ToString();
                                    txtOcupation.Text = dataSet.Tables[0].Rows[0]["MemberOcupation"].ToString();
                                    txtOrganization.Text = dataSet.Tables[0].Rows[0]["MemberOrganization"].ToString();
                                    txtQualification.Text = dataSet.Tables[0].Rows[0]["MemberQualification"].ToString();
                                    ddlSiblingCount.SelectedValue = dataSet.Tables[0].Rows[0]["SiblingCount"].ToString();
                                    ddlCandidateSiblingPosition.SelectedValue = dataSet.Tables[0].Rows[0]["PositionInSiblings"].ToString();
                                    ddlRelation.SelectedValue = dataSet.Tables[0].Rows[0]["Relation_Code"].ToString();
                                    if (dataSet.Tables[0].Rows[0]["NIC_Path"].ToString() == "")
                                    {
                                        ImgbtnNIC.Visible = false;
                                        btnChangeNIC.Style.Add("display", "none");
                                        fuNIC.Style.Add("display", "block");
                                    }
                                    else
                                    {
                                        ImgbtnNIC.Visible = true;
                                        btnChangeNIC.Style.Add("display", "block");
                                        fuNIC.Style.Add("display", "none");
                                        ImgbtnNIC.CommandArgument = dataSet.Tables[0].Rows[0]["NIC_Path"].ToString();
                                    }
                                    if (dataSet.Tables[0].Rows[0]["PIC_Path"].ToString() == "")
                                    {
                                        ImgbtnPicture.Visible = false;
                                        btnChangePicture.Style.Add("display", "none");
                                        fuPicture.Style.Add("display", "block");
                                    }
                                    else
                                    {
                                        ImgbtnPicture.Visible = true;
                                        btnChangePicture.Style.Add("display", "block");
                                        fuPicture.Style.Add("display", "none");
                                        ImgbtnPicture.CommandArgument = dataSet.Tables[0].Rows[0]["PIC_Path"].ToString();
                                    }
                                }
                            }
                        }
                    }
                    hfCandidateFamilyMemberCode.Value = e.CommandArgument.ToString();
                    btnAddMore.Visible = true;
                }
                catch (Exception ex)
                {
                    LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CID);
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CID);
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
            if (dataSet2 != null && dataSet2.Tables != null && dataSet2.Tables[0].Rows.Count > 0)
                UploadFiles(dataSet2.Tables[0].Rows[0]["CandidateFamilyMember_Code"].ToString());
            ClearControls();
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CID);
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
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CID);
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
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CID);
        }
    }

    protected void btnProceed_Click(object sender, EventArgs e)
    {
        try
        {
            HttpContext.Current.Response.Redirect(DomainAddress + "CandidateArea/Area.aspx", false);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CID);
        }
    }

    protected void ImgbtnNIC_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImgbtnNIC.PostBackUrl = "";
            GeneralMethods.FileResponse(Path.GetFileName(ImgbtnNIC.CommandArgument.ToString()), Path.GetDirectoryName(ImgbtnNIC.CommandArgument.ToString()));
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CID);
        }
    }

    protected void ImgbtnPicture_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImgbtnPicture.PostBackUrl = "";
            GeneralMethods.FileResponse(Path.GetFileName(ImgbtnPicture.CommandArgument.ToString()), Path.GetDirectoryName(ImgbtnPicture.CommandArgument.ToString()));
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CID);
        }
    }
    #endregion
}