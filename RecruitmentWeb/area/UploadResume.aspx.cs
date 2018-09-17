using System;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using XRecruitmentStatusLibrary;
using System.IO;
using ErrorLog;
using Telerik.Web.UI;
using System.Text.RegularExpressions;



public partial class UploadResume : CustomBaseClass
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    int CandidateCode = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
        CandidateCode = Convert.ToInt32(Session["CC"].ToString());
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int num = SaveAllFiles();
            if (num > 0)
            {
                StatusManagement.MarkLifeCycleStatus(connection, CandidateCode, Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.VerificationDoneApplicationPending, Request.UserHostAddress, CandidateCode);
                try
                {
                    ScriptManager.RegisterStartupScript((Page)this, typeof(string), "script", "<script type=text/javascript>parent.location.href = parent.location.href+'?fb=1';</script>", false);
                }
                catch (Exception ex)
                {
                    lblErrorMessage.Text = "Redirect Error: " + ex.Message;
                }
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            else if (num == -1)
                lblErrorMessage.Text = "* Please select resume.";
            else
                lblErrorMessage.Text = "* Resume not uploaded this time.";
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    private int SaveAllFiles()
    {
        int num = 0;
        try
        {
            RadAsyncUpload asyncUpload1 = AsyncUpload1;
            if (asyncUpload1.UploadedFiles.Count > 0)
            {
                UploadedFile uploadedFile = asyncUpload1.UploadedFiles[0];
                string lower = Path.GetExtension(asyncUpload1.UploadedFiles[0].FileName).ToLower();
                string empty = string.Empty;
                string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + CandidateCode + "/Personal/";
                UploadResume.FileBrowse(uploadedFile, FolderPath, "Resume");
                num = UpdateCandidateInformation(FolderPath + "Resume" + lower);
            }
            else
                num = -1;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
        return num;
    }

    public static string FileBrowse(UploadedFile Source, string FolderPath, string FileName)
    {
        UploadResume.CreateFolder(FolderPath);
        string extension = Path.GetExtension(Source.GetName());
        string str1 = FileName + extension;
        string str2 = !UploadResume.IsValidPath(FolderPath) ? HttpContext.Current.Server.MapPath(FolderPath) : FolderPath;
        if (str1 != "" && Source.ContentLength != 0)
        {
            string fileName = str2 + "\\" + str1;
            Source.SaveAs(fileName);
        }
        return str1;
    }

    public static void CreateFolder(string FolderPath)
    {
        string empty = string.Empty;
        string path = !UploadResume.IsValidPath(FolderPath) ? HttpContext.Current.Server.MapPath(FolderPath) : FolderPath;
        if (new DirectoryInfo(path).Exists)
            return;
        Directory.CreateDirectory(path);
    }

    public static bool IsValidPath(string path)
    {
        return new Regex("^(?:[a-zA-Z]\\:|\\\\\\\\[\\w\\.]+\\\\[\\w.]+)\\\\(?:[\\w]+\\\\)*").IsMatch(path);
    }

    public int UpdateCandidateInformation(string FilePath)
    {
        int num = 0;
        connection.Open();
        using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateResumePath", connection))
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", CandidateCode));
            sqlCommand.Parameters.Add(new SqlParameter("@DocumentPath", FilePath));
            num = sqlCommand.ExecuteNonQuery();
        }
        connection.Close();
        return num;
    }



}