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
using System.ComponentModel;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using System.Text.RegularExpressions;
using System.Web.Script.Services;
using System.Web.Services;

public partial class profile_uploaddocuments : CustomBaseClass
{
    #region Page Variables
    private string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    private string FinishBtnText = ConfigurationManager.AppSettings["FinishButton"].ToString();
    private DataTable dt = new DataTable();
    private DataSet ds = new DataSet();
    private string BindDocTypeName = "";
    private string BindDocTypeCode = "";
    private SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
  

    #endregion Page Variables

    #region Methods
    private void BindData()
    {
        lblMsg.Text = "";
        hdnCandidateCode.Value = CandidateCode.ToString();
        DataSet dataSet1 = new DataSet();
        DataSet dataSet2 = BindDocumentType();
        if (dataSet2 != null && dataSet2.Tables != null)
        {
            if (dataSet2.Tables[0].Rows.Count > 0)
            {
                rptDocumentType.DataSource = dataSet2.Tables[0];
                rptDocumentType.DataBind();
            }
            else
                lblMsg.Text = "";
        }
        else
            lblMsg.Text = "";
    }

    private void UpdateCandidateInformation(string FilePath, string RefCode, string DocumentCode)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateDocumentPath", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", CandidateCode));
                sqlCommand.Parameters.Add(new SqlParameter("@DocumentPath", FilePath));
                sqlCommand.Parameters.Add(new SqlParameter("@ReferenceCode", Convert.ToInt32(RefCode)));
                sqlCommand.Parameters.Add(new SqlParameter("@DocumentCode", Convert.ToInt32(DocumentCode)));
                sqlCommand.Parameters.Add(new SqlParameter("@UserType", UserTypeCode));
                sqlCommand.Parameters.Add(new SqlParameter("@UpdatedBy", (AdminUserCode == -1 ? CandidateCode : AdminUserCode)));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    public bool CreateDocumentFolder()
    {
        string str1 = CandidateCode.ToString();
        string str2 = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["CandidateDocumentPath"].ToString());
        if (!Directory.Exists(str2 + str1 + "/Documents"))
            Directory.CreateDirectory(str2 + str1 + "/Documents");
        return true;
    }

    private DataSet BindDocumentType()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectDocumentTypes", connection))
            {
                selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode.ToString());
                selectCommand.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }

    private DataSet BindCandidateDocuments(string DocumentTypeCode, string ProgramCode)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDocument", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode.ToString());
                selectCommand.Parameters.AddWithValue("@ProgramCode", Convert.ToInt32(ProgramCode));
                selectCommand.Parameters.AddWithValue("@DocumentTypeCode", Convert.ToInt32(DocumentTypeCode));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }

    private DataSet BindDocumentsUploaders(string ReferenceCode, string ProgramCode)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDocumentstoBeUploaded", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode.ToString());
                selectCommand.Parameters.AddWithValue("@ReferenceCode", ReferenceCode);
                selectCommand.Parameters.AddWithValue("@ProgramCode", ProgramCode);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }

    public bool validateExtension(FileUpload myFile)
    {
        string lower = Path.GetExtension(myFile.FileName).ToLower();
        return lower == ".jpg" || lower == ".doc" || (lower == ".pdf" || lower == ".jpeg") || lower == ".png";
    }

    private DataSet BindCandidatePersonalDocuments(string DocumentTypeCode)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDocument", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode.ToString());
                selectCommand.Parameters.AddWithValue("@DocumentTypeCode", Convert.ToInt32(DocumentTypeCode));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }

    private DataSet BindCandidateProfessionalExperienceDocuments(string DocumentType)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDocument", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode.ToString());
                selectCommand.Parameters.AddWithValue("@DocumentTypeCode", Convert.ToInt32(DocumentType));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }

    private DataSet BindPersonalDocumentsUploaders(string DocumentType, string ReferenceCode)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDocumentstoBeUploaded", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode.ToString());
                selectCommand.Parameters.AddWithValue("@ReferenceCode", ReferenceCode);
                selectCommand.Parameters.AddWithValue("@DocumentTypeCode", DocumentType);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }

    private DataSet BindExperienceDocumentsUploaders(string DocumentType, string ReferenceCode)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDocumentstoBeUploaded", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode.ToString());
                selectCommand.Parameters.AddWithValue("@ReferenceCode", ReferenceCode);
                selectCommand.Parameters.AddWithValue("@DocumentTypeCode", DocumentType);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            if (Convert.ToInt32(Constants.ProfileNavigation.UploadDocuments) == Convert.ToInt32(GeneralMethods.GetProfileNavCount(SqlConn, CandidateCode).Rows[0]["FinishCode"].ToString()))
                btnSave.Text = FinishBtnText;
            ds = GetLifeCycleStatus(CandidateCode);
            ViewState["dtStatus"] = ds.Tables[0].Rows[0]["Status_Code"].ToString();
            ViewState["StatusProgress"] = ds.Tables[1].Rows[0]["StatusProgressBar"].ToString();
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void rptUploadDocuments_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            Image control1 = (Image)e.Item.FindControl("Imgbtn");
            Label control2 = (Label)e.Item.FindControl("lblDocumentTypeCode");
            Label control3 = (Label)e.Item.FindControl("lblDocumentTypeName");
            HtmlTableRow control4 = (HtmlTableRow)e.Item.FindControl("trDocName");
            HtmlAnchor control5 = (HtmlAnchor)e.Item.FindControl("aFU");
            LinkButton control6 = (LinkButton)e.Item.FindControl("lblFileName");
            HtmlGenericControl control7 = (HtmlGenericControl)e.Item.FindControl("sFileName");
            HtmlAnchor control8 = (HtmlAnchor)e.Item.FindControl("lnkdeleteFile");
            RadAsyncUpload control9 = (RadAsyncUpload)e.Item.FindControl("AsyncUpload1");
            HtmlInputButton control10 = (HtmlInputButton)e.Item.FindControl("AsyncUpload1file0");
            HtmlGenericControl control11 = (HtmlGenericControl)e.Item.FindControl("tel");
            HtmlGenericControl control12 = (HtmlGenericControl)e.Item.FindControl("teln");
            if (BindDocTypeCode == control2.Text)
                control4.Visible = false;
            BindDocTypeCode = control2.Text;
            if (DataBinder.Eval(e.Item.DataItem, "DOCUMENT_Path") == "")
            {
                control1.ImageUrl = "/Area/assets/img/U1.PNG";
                control6.Style.Add("display", "");
                control9.OnClientFileSelected = "test";
                control11.Attributes.Add("display", "");
                control11.Attributes.Remove("Class");
                control11.Attributes.Add("Class", "");
            }
            else
            {
                control1.ImageUrl = "/Area/assets/img/d1.png";
                control5.Style.Add("display", "");
                control5.InnerHtml = "";
                control6.Style.Add("display", "");
                control6.Text = Path.GetFileName(DataBinder.Eval(e.Item.DataItem, "DOCUMENT_Path").ToString());
                control7.Attributes.Add("class", " filename");
                control11.Attributes.Add("display", "none");
                control11.Attributes.Add("Class", "hidden");
                control8.Attributes.Add("onclick", "clearFileUpload('" + control11.ClientID + "','" + control12.ClientID + "','" + DataBinder.Eval(e.Item.DataItem, "CandidateCodument_Code").ToString() + "','" + control2.Text + "')");
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
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
            HiddenField control4 = (HiddenField)e.Item.FindControl("hdntblID");
            Label control5 = (Label)e.Item.FindControl("lblDocTypeName");
            HtmlTableRow control6 = (HtmlTableRow)e.Item.FindControl("trDocTypeName");
            if (BindDocTypeName == control5.Text)
                control6.Visible = false;
            BindDocTypeName = control5.Text;
            if (Convert.ToInt32(control2.Value) == 1 || Convert.ToInt32(control2.Value) == 9 || Convert.ToInt32(control2.Value) == 0)
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
                if (Convert.ToInt32(control2.Value) != 1 && Convert.ToInt32(control2.Value) != 0)
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
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
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
            if (Convert.ToInt32(control4.Value) == 1 || Convert.ToInt32(control4.Value) == 9 || Convert.ToInt32(control4.Value) == 0)
            {
                if (Convert.ToInt32(control4.Value) == 1 || Convert.ToInt32(control4.Value) == 0)
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
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void rptUploadDocuments_OnItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "View")
            {
                Image control = (Image)e.Item.FindControl("Imgbtn");
                GeneralMethods.FileResponse(Path.GetFileName(e.CommandArgument.ToString()), Path.GetDirectoryName(e.CommandArgument.ToString()));
            }
            if (!(e.CommandName == "Download"))
                return;
            LinkButton control1 = (LinkButton)e.Item.FindControl("lblFileName");
            FileResponse(Path.GetFileName(e.CommandArgument.ToString()), Path.GetDirectoryName(e.CommandArgument.ToString()));
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void btnSaveAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (SaveAllFiles() <= 0)
                return;
            StatusManagement.MarkProfileStatus(SqlConn, CandidateCode, Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.DocumentsUploadedProfileCompleted, Request.UserHostAddress, CandidateCode, Constants.ProfileNavigation.UploadDocuments);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
            lblMsg.Text = "File Unable to upload!";
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnSave.Text == FinishBtnText || SaveAllFiles() > 0)
                StatusManagement.MarkProfileStatus(SqlConn, CandidateCode, Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.DocumentsUploadedProfileCompleted, Request.UserHostAddress, AdminUserCode == -1 ? CandidateCode : AdminUserCode, Constants.ProfileNavigation.UploadDocuments);
            if (btnSave.Text == FinishBtnText)
                Response.Redirect(DomainAddress + "/area/viewprofile.aspx", false);
            else
                Response.Redirect(DomainAddress + "/profile/redirector.aspx", false);
        }
        catch (Exception ex)
        {
            lblMsg.Text = "File Unable to upload!";
        }
    }

    public static void CreateFolder(string FolderPath)
    {
        string empty = string.Empty;
        string path = !profile_uploaddocuments.IsValidPath(FolderPath) ? HttpContext.Current.Server.MapPath(FolderPath) : FolderPath;
        if (new DirectoryInfo(path).Exists)
            return;
        Directory.CreateDirectory(path);
    }

    public static bool IsValidPath(string path)
    {
        return new Regex("^(?:[a-zA-Z]\\:|\\\\\\\\[\\w\\.]+\\\\[\\w.]+)\\\\(?:[\\w]+\\\\)*").IsMatch(path);
    }

    public static string FileBrowse(UploadedFile Source, string FolderPath, string FileName)
    {
        profile_uploaddocuments.CreateFolder(FolderPath);
        string extension = Path.GetExtension(Source.GetName());
        string str1 = FileName + extension;
        string str2 = !profile_uploaddocuments.IsValidPath(FolderPath) ? HttpContext.Current.Server.MapPath(FolderPath) : FolderPath;
        if (str1 != "" && Source.ContentLength != 0)
        {
            string fileName = str2 + "\\" + str1;
            Source.SaveAs(fileName);
        }
        return str1;
    }

    [ScriptMethod]
    [WebMethod]
    public static void DeleteResume(string candcode)
    {
        using (SqlConnection sqlConnection = new SqlConnection())
        {
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "dbo.XRec_UpdateCandidateResume";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandidateCode", candcode);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.ExecuteReader();
                sqlConnection.Close();
            }
        }
    }

    [ScriptMethod]
    [WebMethod]
    public static void DeleteCandidateDocument(string CandDoc_Code)
    {
        using (SqlConnection sqlConnection = new SqlConnection())
        {
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "dbo.XRec_UpdateCandidateDocument";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandDocCode", CandDoc_Code);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.ExecuteReader();
                sqlConnection.Close();
            }
        }
    }

    private int SaveAllFiles()
    {
        int num = 0;
        try
        {
            foreach (RepeaterItem repeaterItem1 in rptDocumentType.Items)
            {
                if (repeaterItem1.ItemType == ListItemType.Item || repeaterItem1.ItemType == ListItemType.AlternatingItem)
                {
                    foreach (RepeaterItem repeaterItem2 in ((Repeater)repeaterItem1.FindControl("rptCandidateDocument")).Items)
                    {
                        if (repeaterItem2.ItemType == ListItemType.Item || repeaterItem2.ItemType == ListItemType.AlternatingItem)
                        {
                            foreach (RepeaterItem repeaterItem3 in ((Repeater)repeaterItem2.FindControl("rptUploadDocuments")).Items)
                            {
                                if (repeaterItem3.ItemType == ListItemType.Item || repeaterItem3.ItemType == ListItemType.AlternatingItem)
                                {
                                    lblMsg.Text = "";
                                    HiddenField control1 = (HiddenField)repeaterItem3.FindControl("ReferenceCode");
                                    HiddenField control2 = (HiddenField)repeaterItem3.FindControl("hdnDocumentCode");
                                    Label control3 = (Label)repeaterItem3.FindControl("lblDocumentTypeName");
                                    Label control4 = (Label)repeaterItem3.FindControl("lblDocumentCategory");
                                    Label control5 = (Label)repeaterItem3.FindControl("lblDocumentTypeCode");
                                    string[] strArray = new string[5];
                                    if (control5.Text.ToString() != "1" && control5.Text.ToString() != "0")
                                        strArray = control3.Text.ToString().Split('-');
                                    else
                                        strArray[1] = control3.Text.ToString();
                                    FileUpload control6 = (FileUpload)repeaterItem3.FindControl("fuCandidateDocument");
                                    RadAsyncUpload control7 = (RadAsyncUpload)repeaterItem3.FindControl("AsyncUpload1");
                                    if (control7.UploadedFiles.Count > 0)
                                    {
                                        UploadedFile uploadedFile = control7.UploadedFiles[0];
                                        string lower = Path.GetExtension(control7.UploadedFiles[0].FileName).ToLower();
                                        string empty = string.Empty;
                                        string FolderPath = control5.Text == "1" || control5.Text == "0" ? ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + CandidateCode + "/Personal/" : (!(control5.Text == "9") ? ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + CandidateCode + "/Educational/" : ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + CandidateCode + "/Professional/");
                                        if (control1.Value.ToString() != "0")
                                        {
                                            if (control5.Text != "1" && control5.Text != "0")
                                            {
                                                profile_uploaddocuments.FileBrowse(uploadedFile, FolderPath, control1.Value.ToString() + "_" + strArray[1].ToString().Replace(" ", ""));
                                                UpdateCandidateInformation(FolderPath + control1.Value.ToString() + "_" + strArray[1].ToString().Replace(" ", "") + lower, control1.Value, control2.Value);
                                            }
                                            else if (control1.Value.ToString() == "-1")
                                            {
                                                profile_uploaddocuments.FileBrowse(uploadedFile, FolderPath, control3.Text.ToString());
                                                UpdateCandidateInformation(FolderPath + strArray[1].ToString().Replace(" ", "") + lower, control1.Value, control2.Value);
                                            }
                                            else
                                            {
                                                profile_uploaddocuments.FileBrowse(uploadedFile, FolderPath, control1.Value.ToString() + "_" + control3.Text.ToString());
                                                UpdateCandidateInformation(FolderPath + control1.Value.ToString() + "_" + strArray[1].ToString().Replace(" ", "") + lower, control1.Value, control2.Value);
                                            }
                                            ++num;
                                        }
                                        else
                                        {
                                            profile_uploaddocuments.FileBrowse(uploadedFile, FolderPath, control3.Text.Replace(" ", ""));
                                            UpdateCandidateInformation(FolderPath + control3.Text.Replace(" ", "") + lower, control1.Value, control2.Value);
                                            ++num;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
            lblMsg.Text = "File Unable to upload!";
        }
        BindData();
        return num;
    }

    private DataSet GetLifeCycleStatus(int CanCode)
    {
        DataSet dataSet = new DataSet();
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

    public void FileResponse(string filename, string FolderPath)
    {
        string empty = string.Empty;
        FileInfo fileInfo = new FileInfo(!profile_uploaddocuments.IsValidPath(FolderPath) ? HttpContext.Current.Server.MapPath(FolderPath + "/" + filename) : FolderPath + "/" + filename);
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

    public enum OG_Program
    {
        Doctorateorequivalent = 1,
        Mastersorequivalent = 2,
        Bachelorsorequivalent = 3,
        Intermediateorequivalent = 4,
        Matricorequivalent = 5,
        Diploma = 6,
        Certificate = 7,
        ALevel = 8,
        OLevel = 9,
    }

    #endregion

}