using ErrorLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using XRecruitmentStatusLibrary;


public partial class profile_portfolio : CustomBaseClass
{

    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    string FinishBtnText = ConfigurationManager.AppSettings["FinishButton"].ToString();
    public List<CustomUploadedFileInfo> uploadedFiles = new List<CustomUploadedFileInfo>();
    SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    public string controlID = "ContentContainer_";



    public List<CustomUploadedFileInfo> UploadedFiles
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
        try
        {
            Page.RegisterStartupScript("controlIDPrefix", "<script language=JavaScript>SetControlIDPrefix('" + controlID + "');</script>");
            if (IsPostBack)
                return;
            if (Convert.ToInt32(Constants.ProfileNavigation.Portfolio) == Convert.ToInt32(GeneralMethods.GetProfileNavCount(SqlConn, CandidateCode).Rows[0]["FinishCode"].ToString()))
                btnSave.Text = FinishBtnText;
            BindData();
            CheckCandidatePortFolio();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void lvPortFolio_OnItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
    }

    protected void lvPortFolio_ItemEditing(object sender, ListViewEditEventArgs e)
    {
    }

    protected void lvPortFolio_OnItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            DataSet dataSet = new DataSet();
            if (e.CommandName == "Delete")
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    connection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("XRec_DeactivatePortFolioFile", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@CandidatePortFolioFileCode", Convert.ToInt32(e.CommandArgument.ToString()));
                        sqlCommand.Parameters.AddWithValue("@UpdatedBy", (AdminUserCode == -1 ? CandidateCode : AdminUserCode));
                        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                        sqlCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
                        sqlCommand.ExecuteNonQuery();
                        CheckCandidatePortFolio();
                        BindData();
                    }
                }
            }
            if (!(e.CommandName == "Download"))
                return;
            GeneralMethods.FileResponse(Path.GetFileName(Server.MapPath(((Label)e.Item.FindControl("lblFilePath")).Text)), Path.GetDirectoryName(Server.MapPath(((Label)e.Item.FindControl("lblFilePath")).Text)));
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
            SaveCandidatePortfolioURLs();
            CheckCandidatePortFolio();
            UpdateStatus();
            if (btnSave.Text == FinishBtnText)
                Response.Redirect(DomainAddress + "/area/viewprofile.aspx", false);
            else
                Response.Redirect(DomainAddress + "/profile/redirector.aspx", false);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void btnUpload_OnClick(object sender, EventArgs e)
    {
        try
        {
            UploadFile();
            BindPortfolioFiles();
            CheckCandidatePortFolio();
            BindPortfolioURLs();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
            ErrorSpan.InnerHtml = "File Unable to upload!";
        }
    }

    private void PopulateUploadedFilesList()
    {
        foreach (UploadedFile uploadedFile in (CollectionBase)AsyncUpload1.UploadedFiles)
            UploadedFiles.Add(new CustomUploadedFileInfo()
            {
                FileName = uploadedFile.GetName(),
                FileExtension = uploadedFile.GetExtension().Replace(".", string.Empty),
                ContentLength = (long)(uploadedFile.ContentLength / 1024)
            });
    }

    public static void CreateFolder(string FolderPath)
    {
        string empty = string.Empty;
        string path = !profile_portfolio.IsValidPath(FolderPath) ? HttpContext.Current.Server.MapPath(FolderPath) : FolderPath;
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
        profile_portfolio.CreateFolder(FolderPath);
        string extension = Path.GetExtension(Source.GetName());
        string str1 = FileName + extension;
        string str2 = !profile_portfolio.IsValidPath(FolderPath) ? HttpContext.Current.Server.MapPath(FolderPath) : FolderPath;
        if (str1 != "" && Source.ContentLength != 0)
        {
            string fileName = str2 + "\\" + str1;
            Source.SaveAs(fileName);
        }
        return str1;
    }

    private void UploadFile()
    {
        foreach (UploadedFile uploadedFile in (CollectionBase)AsyncUpload1.UploadedFiles)
        {
            string empty = string.Empty;
            if (uploadedFile != null)
            {
                string lower = Path.GetExtension(uploadedFile.FileName).ToLower();
                string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + CandidateCode.ToString() + "/Personal/";
                string str1 = GetRandomCode(6).ToString();
                string str2 = string.Empty;
                if (str2 == "")
                    str2 = uploadedFile.FileName.Replace(lower, "");
                profile_portfolio.FileBrowse(uploadedFile, FolderPath, str2 + "_" + str1);
                if (lower.ToLower() == ".bmp" || lower.ToLower() == ".jpg" || (lower.ToLower() == ".jpeg" || lower.ToLower() == "gif") || (lower.ToLower() == ".png" || lower.ToLower() == ".tif"))
                {
                    GenerateThumbNail(FolderPath + str2 + "_" + str1 + lower, FolderPath + "Thumbnail" + str2 + "_" + str1 + lower, 100);
                    UpdateCandidateInformation(FolderPath + "Thumbnail" + str2 + "_" + str1 + lower, FolderPath + str2 + "_" + str1 + lower);
                }
                else
                    UpdateCandidateInformation("", FolderPath + str2 + "_" + str1 + lower);
            }
        }
    }

    private void UpdateStatus()
    {
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        string str = CandidateCode.ToString();
        if (rblHasPortfolio.SelectedValue == "1")
        {
            StatusManagement.MarkProfileStatus(sqlConn, Convert.ToInt32(str), Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.PortfolioBrowsedPersonalDetailPending, Request.UserHostAddress, AdminUserCode == -1 ? CandidateCode : AdminUserCode, Constants.ProfileNavigation.Portfolio);
            Response.Redirect(DomainAddress + "/profile/redirector.aspx", false);
        }
        else
        {
            if (!(rblHasPortfolio.SelectedValue == "2"))
                return;
            StatusManagement.MarkProfileStatus(sqlConn, Convert.ToInt32(str), Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.NoPortfolioBrowsedPersonalDetailPending, Request.UserHostAddress, AdminUserCode == -1 ? CandidateCode : AdminUserCode, Constants.ProfileNavigation.Portfolio);
            Response.Redirect(DomainAddress + "/profile/redirector.aspx", false);
        }
    }

    private void SaveCandidatePortfolioURLs()
    {
        int num1 = int.Parse(hdfFileCounter.Value);
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_DeactivateAllCandidatePortFolioURLs", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", CandidateCode.ToString()));
                sqlCommand.Parameters.Add(new SqlParameter("@UpdatedIp", Request.UserHostAddress.ToString()));
                sqlCommand.ExecuteNonQuery();
            }
            for (int index = 2; index <= num1; ++index)
            {
                string str1 = Request.Form["txtTitle" + index.ToString()] == null ? "" : Request.Form["txtTitle" + index.ToString()];
                string str2 = Request.Form["txtURL" + index.ToString()] == null ? "" : Request.Form["txtURL" + index.ToString()];
                if (!string.IsNullOrEmpty(str1.Trim()))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidatePortFolioURLs", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", CandidateCode.ToString()));
                        sqlCommand.Parameters.Add(new SqlParameter("@UpdatedIp", Request.UserHostAddress.ToString()));
                        sqlCommand.Parameters.Add(new SqlParameter("@portfoliourl", str2.Trim()));
                        sqlCommand.Parameters.Add(new SqlParameter("@portfoliotitle", str1.Trim()));
                        sqlCommand.Parameters.Add(new SqlParameter("@UserType", UserTypeCode));
                        sqlCommand.Parameters.Add(new SqlParameter("@UpdatedBy", (AdminUserCode == -1 ? CandidateCode : AdminUserCode)));
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            int num2 = 1;
            string str3 = Request.Form["txtTitle" + num2.ToString()] == null ? "" : Request.Form["txtTitle" + num2.ToString()];
            string str4 = Request.Form["txtURL" + num2.ToString()] == null ? "" : Request.Form["txtURL" + num2.ToString()];
            if (string.IsNullOrEmpty(str3.Trim()))
                return;
            using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidatePortFolioURLs", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", CandidateCode.ToString()));
                sqlCommand.Parameters.Add(new SqlParameter("@UpdatedIp", Request.UserHostAddress.ToString()));
                sqlCommand.Parameters.Add(new SqlParameter("@portfoliourl", str4.Trim()));
                sqlCommand.Parameters.Add(new SqlParameter("@portfoliotitle", str3.Trim()));
                sqlCommand.Parameters.Add(new SqlParameter("@UserType", UserTypeCode));
                sqlCommand.Parameters.Add(new SqlParameter("@UpdatedBy", (AdminUserCode == -1 ? CandidateCode : AdminUserCode)));
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

    private void AddOrHidePortFolio()
    {
        if (rblHasPortfolio.SelectedValue == "1")
        {
            profePort.Attributes["class"] = "";
            footerport.Attributes["class"] = "";
        }
        else
        {
            profePort.Attributes["class"] = "hidden";
            footerport.Attributes["class"] = "hidden";
        }
    }

    private void CheckCandidatePortFolio()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateHasPortFolio", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode.ToString());
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet == null || dataSet.Tables == null)
                return;
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                if (dataSet.Tables[0].Rows[0]["HasPortfolio"].ToString() == "1")
                {
                    profeportfolioCheck.Visible = false;
                    rblHasPortfolio.SelectedValue = "1";
                    AddOrHidePortFolio();
                }
                else if (dataSet.Tables[0].Rows[0]["HasPortfolio"].ToString() == "0")
                {
                    profeportfolioCheck.Visible = true;
                    rblHasPortfolio.SelectedValue = "2";
                    AddOrHidePortFolio();
                }
                else if (dataSet.Tables[0].Rows[0]["HasPortfolio"].ToString() == "2")
                {
                    profeportfolioCheck.Visible = true;
                    rblHasPortfolio.SelectedValue = "2";
                    AddOrHidePortFolio();
                }
                else
                    profeportfolioCheck.Visible = true;
            }
            else
                profeportfolioCheck.Visible = true;
        }
    }

    private DataSet CheckCandidatePF()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidatePortFolioDetails", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add(new SqlParameter("@CandidateCode", CandidateCode.ToString()));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }

    private void BindData()
    {
        BindPortfolioFiles();
        BindPortfolioURLs();
    }

    private void BindPortfolioURLs()
    {
        DataSet dataSet1 = new DataSet();
        DataSet dataSet2 = CheckCandidatePortFolioURLs();
        string str = string.Empty;
        int num = dataSet2.Tables[0].Rows.Count + 1;
        if (dataSet2 != null && dataSet2.Tables.Count > 0 && dataSet2.Tables[0].Rows.Count > 0)
        {
            for (int index = 0; index < dataSet2.Tables[0].Rows.Count; ++index)
                str = str + dataSet2.Tables[0].Rows[index]["URLTitle"].ToString() + "~" + dataSet2.Tables[0].Rows[index]["URL"].ToString() + "|";
            str = str.Remove(str.LastIndexOf("|"));
        }
        ScriptManager.RegisterStartupScript((Page)this, GetType(), "Test", "BindURLData('" + str + "'," + num + ");", true);
    }

    private DataSet CheckCandidatePortFolioURLs()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidatePortFolioURLs", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add(new SqlParameter("@CandidateCode", CandidateCode.ToString()));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }

    private void BindPortfolioFiles()
    {
        profePortList.Style.Add("display", "block");
        DataSet dataSet1 = new DataSet();
        DataSet dataSet2 = CheckCandidatePF();
        if (dataSet2 != null && dataSet2.Tables != null)
        {
            if (dataSet2.Tables[0].Rows.Count > 0)
            {
                lvPortFolio.Items.Clear();
                lvPortFolio.DataSource = dataSet2;
                lvPortFolio.DataBind();
            }
            else
            {
                lvPortFolio.Items.Clear();
                profePortList.Style.Add("display", "none");
            }
        }
        else
        {
            lvPortFolio.Items.Clear();
            profePortList.Style.Add("display", "none");
        }
    }

    private void UpdateCandidateInformation(string ThumbnailPath, string FilePath)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidatePortFolioDetails", connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", CandidateCode.ToString()));
                sqlCommand.Parameters.Add(new SqlParameter("@PFPath", FilePath));
                sqlCommand.Parameters.Add(new SqlParameter("@FileName", Path.GetFileName(FilePath)));
                sqlCommand.Parameters.Add(new SqlParameter("@FileExtension", Path.GetExtension(FilePath).ToLower()));
                Decimal num = Convert.ToDecimal(new FileInfo(Server.MapPath(FilePath)).Length);
                string[] strArray = new string[4]
                {
          "B",
          "KB",
          "MB",
          "GB"
                };
                int index;
                for (index = 0; num >= new Decimal(1024) && index + 1 < strArray.Length; num = Math.Round(Convert.ToDecimal(num) / new Decimal(1024), 2))
                    ++index;
                sqlCommand.Parameters.Add(new SqlParameter("@FileSize", string.Format("{0:0.##} {1}", num, strArray[index])));
                sqlCommand.Parameters.Add(new SqlParameter("@UpdatedIP", Request.UserHostAddress.ToString()));
                if (ThumbnailPath != "")
                    sqlCommand.Parameters.Add(new SqlParameter("@ThumbnailPath", ThumbnailPath));
                sqlCommand.Parameters.Add(new SqlParameter("@FileDescription", ""));
                sqlCommand.Parameters.Add(new SqlParameter("@UserType", UserTypeCode));
                sqlCommand.Parameters.Add(new SqlParameter("@UpdatedBy", (AdminUserCode == -1 ? CandidateCode : AdminUserCode)));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    public void GenerateThumbNail(string sourcefile, string destinationfile, int width)
    {
        System.Drawing.Image image = System.Drawing.Image.FromFile(Server.MapPath(sourcefile));
        int width1 = image.Width;
        int height1 = image.Height;
        int width2 = width;
        int height2;
        Bitmap bitmap;
        if (height1 > width1)
        {
            height2 = height1 / width1 * width2;
            bitmap = new Bitmap(width2, height2);
        }
        else
        {
            height2 = width2;
            width2 = width1 / height1 * height2;
            bitmap = new Bitmap(width2, height2);
        }
        Graphics graphics = Graphics.FromImage((System.Drawing.Image)bitmap);
        graphics.SmoothingMode = SmoothingMode.HighQuality;
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.High;
        Rectangle destRect = new Rectangle(0, 0, width2, height2);
        graphics.DrawImage(image, destRect, 0, 0, width1, height1, GraphicsUnit.Pixel);
        bitmap.Save(Server.MapPath(destinationfile));
        bitmap.Dispose();
        image.Dispose();
    }
}
public class CustomUploadedFileInfo
{
    public string FileName { get; set; }

    public string FileExtension { get; set; }

    public long ContentLength { get; set; }
}
