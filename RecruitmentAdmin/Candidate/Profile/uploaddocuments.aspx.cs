
using ErrorLog;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using XRecruitmentStatusLibrary;

public partial class Candidate_Profile_uploaddocuments : CustomBasePage, IRequiresSessionState
{

    public string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    public DataTable dt = new DataTable();
    public DataSet ds = new DataSet();
    public string BindDocTypeName = "";
    public string BindDocTypeCode = "";
    public string CID = string.Empty;
    public string QueryStringVar = string.Empty;
    SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    SecureQueryString secQueryString;
    private void BindData()
    {
        lblMsg.Text = "";
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
                sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", CID));
                sqlCommand.Parameters.Add(new SqlParameter("@DocumentPath", FilePath));
                sqlCommand.Parameters.Add(new SqlParameter("@ReferenceCode", Convert.ToInt32(RefCode)));
                sqlCommand.Parameters.Add(new SqlParameter("@DocumentCode", Convert.ToInt32(DocumentCode)));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    public bool CreateDocumentFolder()
    {
        string cid = CID;
        string str = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["CandidateDocumentPath"].ToString());
        if (!Directory.Exists(str + cid + "/Documents"))
            Directory.CreateDirectory(str + cid + "/Documents");
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
                selectCommand.Parameters.AddWithValue("@CandidateCode", CID);
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
                selectCommand.Parameters.AddWithValue("@CandidateCode", CID);
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
                selectCommand.Parameters.AddWithValue("@CandidateCode", CID);
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
                selectCommand.Parameters.AddWithValue("@CandidateCode", CID);
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
                selectCommand.Parameters.AddWithValue("@CandidateCode", CID);
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
                selectCommand.Parameters.AddWithValue("@CandidateCode", CID);
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
                selectCommand.Parameters.AddWithValue("@CandidateCode", CID);
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
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            if (QueryStringVar != null)
            {
                secQueryString = new SecureQueryString(QueryStringVar);
                if (secQueryString["CID"] != null)
                    CID = secQueryString["CID"].ToString();
            }
            if (IsPostBack)
                return;
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, CID.ToString());
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
                control8.Attributes.Add("onclick", "clearFileUpload('" + control11.ClientID + "','" + control12.ClientID + "')");
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
                control8.Attributes.Add("onclick", "clearFileUpload('" + control11.ClientID + "','" + control12.ClientID + "')");
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CID);
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
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CID);
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
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CID);
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
            GeneralMethods.FileResponse(Path.GetFileName(e.CommandArgument.ToString()), Path.GetDirectoryName(e.CommandArgument.ToString()));
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CID);
        }
    }

    protected void btnSaveAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (SaveAllFiles() <= 0)
                return;
            StatusManagement.MarkProfileStatus(SqlConn, Convert.ToInt32(CID), Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.DocumentsUploadedProfileCompleted, Request.UserHostAddress, Convert.ToInt32(CID), Constants.ProfileNavigation.UploadDocuments);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CID);
            lblMsg.Text = "File Unable to upload!";
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (SaveAllFiles() <= 0)
                return;
            StatusManagement.MarkProfileStatus(SqlConn, Convert.ToInt32(CID), Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.DocumentsUploadedProfileCompleted, Request.UserHostAddress, Convert.ToInt32(CID), Constants.ProfileNavigation.UploadDocuments);
        }
        catch (Exception ex)
        {
            lblMsg.Text = "File Unable to upload!";
        }
    }

    public static void CreateFolder(string FolderPath)
    {
        string empty = string.Empty;
        string path = !Candidate_Profile_uploaddocuments.IsValidPath(FolderPath) ? HttpContext.Current.Server.MapPath(FolderPath) : FolderPath;
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
        Candidate_Profile_uploaddocuments.CreateFolder(FolderPath);
        string extension = Path.GetExtension(Source.GetName());
        string str1 = FileName + extension;
        string str2 = !Candidate_Profile_uploaddocuments.IsValidPath(FolderPath) ? HttpContext.Current.Server.MapPath(FolderPath) : FolderPath;
        if (str1 != "" && Source.ContentLength != 0)
        {
            string fileName = str2 + "\\" + str1;
            Source.SaveAs(fileName);
        }
        return str1;
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
                                        string FolderPath = control5.Text == "1" || control5.Text == "0" ? ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + CID + "/Personal/" : (!(control5.Text == "9") ? ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + CID + "/Educational/" : ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + CID + "/Professional/");
                                        if (control1.Value.ToString() != "0")
                                        {
                                            if (control5.Text != "1" && control5.Text != "0")
                                            {
                                                Candidate_Profile_uploaddocuments.FileBrowse(uploadedFile, FolderPath, control1.Value.ToString() + "_" + strArray[1].ToString().Replace(" ", ""));
                                                UpdateCandidateInformation(FolderPath + control1.Value.ToString() + "_" + strArray[1].ToString().Replace(" ", "") + lower, control1.Value, control2.Value);
                                            }
                                            else if (control1.Value.ToString() == "-1")
                                            {
                                                Candidate_Profile_uploaddocuments.FileBrowse(uploadedFile, FolderPath, control3.Text.ToString());
                                                UpdateCandidateInformation(FolderPath + strArray[1].ToString().Replace(" ", "") + lower, control1.Value, control2.Value);
                                            }
                                            else
                                            {
                                                Candidate_Profile_uploaddocuments.FileBrowse(uploadedFile, FolderPath, control1.Value.ToString() + "_" + control3.Text.ToString());
                                                UpdateCandidateInformation(FolderPath + control1.Value.ToString() + "_" + strArray[1].ToString().Replace(" ", "") + lower, control1.Value, control2.Value);
                                            }
                                            ++num;
                                        }
                                        else
                                        {
                                            Candidate_Profile_uploaddocuments.FileBrowse(uploadedFile, FolderPath, control3.Text.Replace(" ", ""));
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
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CID);
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
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CID);
            }
        }
        return dataSet;
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
}