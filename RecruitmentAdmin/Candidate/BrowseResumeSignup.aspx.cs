using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using ErrorLog;
using System.Configuration;
using Telerik.Web.UI;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;


public partial class Candidate_BrowseResumeSignup : CustomBasePage
{
    #region variable
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;
    public List<UploadedResumeFileInfo> uploadedFiles = new List<UploadedResumeFileInfo>();
    #endregion

    #region  Events
    public List<UploadedResumeFileInfo> UploadedFiles
    {
        get
        {
            return uploadedFiles;
        }
        set
        {
            uploadedFiles = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        BindData();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                UploadFile();
                lblMsg.Visible = true;
                lblMsg.ForeColor = Color.Green;
                lblMsg.Text = "Successfully Saved";
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Please Browse File";
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "Browse Resume");
            lblMsg.Visible = true;
            lblMsg.ForeColor = Color.Red;
            lblMsg.Text = ex.Message;
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    public DataTable SignUp()
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_CreateCandidateSignupResume", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add(new SqlParameter("@Updated_IP", Request.UserHostAddress.ToString()));
                selectCommand.Parameters.Add(new SqlParameter("@UpdatedBy", UserCode));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataTable);
            }
        }
        return dataTable;
    }

    private void BrowseResume()
    {
        foreach (UploadedFile uploadedFile in (CollectionBase)AsyncUpload1.UploadedFiles)
            UploadedFiles.Add(new UploadedResumeFileInfo()
            {
                FileName = uploadedFile.GetName(),
                FileExtension = uploadedFile.GetExtension().Replace(".", string.Empty),
                ContentLength = (long)(uploadedFile.ContentLength / 1024)
            });
    }

    public static bool FileBrowse(UploadedFile Source, string FolderPath, string FileName)
    {
        bool flag = false;
        Candidate_BrowseResumeSignup.CreateFolder(FolderPath);
        string extension = Path.GetExtension(Source.GetName());
        string str1 = FileName + extension;
        string str2 = !Candidate_BrowseResumeSignup.IsValidPath(FolderPath) ? HttpContext.Current.Server.MapPath(FolderPath) : FolderPath;
        if (str1 != "" && Source.ContentLength != 0)
        {
            string fileName = str2 + "\\" + str1;
            Source.SaveAs(fileName);
            flag = true;
        }
        return flag;
    }

    public static void CreateFolder(string FolderPath)
    {
        string empty = string.Empty;
        string path = !Candidate_BrowseResumeSignup.IsValidPath(FolderPath) ? HttpContext.Current.Server.MapPath(FolderPath) : FolderPath;
        if (new DirectoryInfo(path).Exists)
            return;
        Directory.CreateDirectory(path);
    }

    public static bool IsValidPath(string path)
    {
        return new Regex("^(?:[a-zA-Z]\\:|\\\\\\\\[\\w\\.]+\\\\[\\w.]+)\\\\(?:[\\w]+\\\\)*").IsMatch(path);
    }

    private void UploadFile()
    {
        foreach (UploadedFile uploadedFile in (CollectionBase)AsyncUpload1.UploadedFiles)
        {
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            if (uploadedFile != null)
            {
                DataTable dataTable = SignUp();
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    string lower = Path.GetExtension(uploadedFile.FileName).ToLower();
                    string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + dataTable.Rows[0][0].ToString() + "/Resume/";
                    string str1 = GetRandomCode(6).ToString();
                    string str2 = string.Empty;
                    if (str2 == "")
                        str2 = uploadedFile.FileName.Replace(lower, "");
                    if ((lower.ToLower() == ".doc" || lower.ToLower() == ".docx" || lower.ToLower() == ".pdf") && Candidate_BrowseResumeSignup.FileBrowse(uploadedFile, FolderPath, str2 + "_" + str1))
                        InsertUserResume(FolderPath + str2 + "_" + str1 + lower, dataTable.Rows[0][0].ToString(), str2 + "_" + str1 + lower);
                }
            }
        }
    }

    private void InsertUserResume(string FilePath, string CandCode, string FileName)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_InsertUerResume", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@Candidate_Code", CandCode));
                sqlCommand.Parameters.Add(new SqlParameter("@Category_Code", ddlCategory.SelectedValue));
                sqlCommand.Parameters.Add(new SqlParameter("@Resume_Path", FilePath));
                sqlCommand.Parameters.Add(new SqlParameter("@Updated_IP", Request.UserHostAddress.ToString()));
                sqlCommand.Parameters.Add(new SqlParameter("@FileName", FileName));
                sqlCommand.Parameters.Add(new SqlParameter("@UpdatedBy", UserCode));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    public string GetRandomCode(int length)
    {
        string str = Guid.NewGuid().ToString().Replace("-", string.Empty);
        if (length <= 0 || length > str.Length)
            throw new ArgumentException("Length must be between 1 and " + str.Length);
        return str.Substring(0, length);
    }

    private void BindData()
    {
        BindDomain(ref connection);
    }

    private void BindCategory(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectProfileCategory", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        ddlCategory.DataSource = dataSet;
        ddlCategory.DataTextField = "Category_Name";
        ddlCategory.DataValueField = "Category_Code";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("--Select--", ""));
    }

    private void BindDomain(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectDomainByUserWeb", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        ddlDomain.DataSource = dataSet;
        ddlDomain.DataTextField = "Domain_Name";
        ddlDomain.DataValueField = "Domain_Code";
        ddlDomain.DataBind();
        ddlDomain.Items.Insert(0, new ListItem("--Select--", ""));
    }

    protected void ddlDomain_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (!(ddlDomain.SelectedValue != ""))
                return;
            SqlCommand selectCommand = new SqlCommand("XRec_SelectSubDomain", connection);
            selectCommand.Parameters.AddWithValue("@DomainCode", ddlDomain.SelectedValue);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count <= 0)
                return;
            ddlSubDomain.DataSource = dataSet;
            ddlSubDomain.DataTextField = "SubDomain_Name";
            ddlSubDomain.DataValueField = "SubDomain_Code";
            ddlSubDomain.DataBind();
            ddlSubDomain.Items.Insert(0, new ListItem("--Select--", ""));
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "Browse Resume");
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void ddlSubDomain_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSubDomain.SelectedValue != "")
            {
                SqlCommand selectCommand = new SqlCommand("XRec_SelectCategoryBySubDomain", connection);
                selectCommand.Parameters.AddWithValue("@SubDomainCode", ddlSubDomain.SelectedValue);
                selectCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    ddlCategory.DataSource = dataSet;
                    ddlCategory.DataTextField = "Category_Name";
                    ddlCategory.DataValueField = "Category_Code";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("--Select--", ""));
                }
                else
                {
                    ddlCategory.Items.Clear();
                    ddlCategory.Items.Insert(0, new ListItem("--Select--", ""));
                }
            }
            else
            {
                ddlCategory.Items.Clear();
                ddlCategory.Items.Insert(0, new ListItem("--Select--", ""));
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "Category Bind");
        }
    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs e)
    {
        if (AsyncUpload1.UploadedFiles.Count == 0)
            e.IsValid = false;
        else
            e.IsValid = true;
    }

    #endregion
}

public class UploadedResumeFileInfo
{
    public string FileName { get; set; }

    public string FileExtension { get; set; }

    public long ContentLength { get; set; }
}