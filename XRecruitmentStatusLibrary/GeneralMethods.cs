using ErrorLog;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace XRecruitmentStatusLibrary
{
    public class GeneralMethods
    {
        public static bool IsValidPath(string path)
        {
            try
            {
                return new Regex("^(?:[a-zA-Z]\\:|\\\\\\\\[\\w\\.]+\\\\[\\w.]+)\\\\(?:[\\w]+\\\\)*").IsMatch(path);
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "IsValidPath" + ex.Message + " " + ex.StackTrace, ex, "");
                return false;
            }
        }

        public static void CreateFolder(string FolderPath)
        {
            try
            {
                string empty = string.Empty;
                string path = !GeneralMethods.IsValidPath(FolderPath) ? HttpContext.Current.Server.MapPath(FolderPath) : FolderPath;
                if (new DirectoryInfo(path).Exists)
                    return;
                Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "CreateFolder" + ex.Message + " " + ex.StackTrace, ex, "");
            }
        }

        public static string FileBrowse(FileUpload Source, string FolderPath, string FileName)
        {
            try
            {
                GeneralMethods.CreateFolder(FolderPath);
                string extension = Path.GetExtension(Source.PostedFile.FileName);
                string str1 = FileName + extension;
                string str2 = !GeneralMethods.IsValidPath(FolderPath) ? HttpContext.Current.Server.MapPath(FolderPath) : FolderPath;
                if (str1 != "" && Source.PostedFile.ContentLength != 0)
                {
                    string filename = str2 + "\\" + str1;
                    Source.PostedFile.SaveAs(filename);
                }
                return str1;
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "FileBrowse" + ex.Message + " " + ex.StackTrace, ex, "");
                return null;
            }
        }

        public static void FileResponse(string filename, string FolderPath)
        {
            try
            {
                string empty = string.Empty;
                FileInfo fileInfo = new FileInfo(!GeneralMethods.IsValidPath(FolderPath) ? HttpContext.Current.Server.MapPath(FolderPath + "/" + filename) : FolderPath + "/" + filename);
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
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "FileResponse" + ex.Message + " " + ex.StackTrace, ex, "");
            }
        }

        public static bool validatefile(FileUpload myFile)
        {
            try
            {
                int num = 0;
                if (myFile.HasFile && myFile.FileBytes.Length >= 2097152)
                    ++num;
                return num <= 0;
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "validatefile" + ex.Message + " " + ex.StackTrace, ex, "");
                return false;
            }
        }

        public static DataTable GetProfileNavCount(SqlConnection SqlConn, int CandidateCode)
        {
            try
            {
                if (SqlConn.State != ConnectionState.Open)
                    SqlConn.Open();
                SqlCommand selectCommand = new SqlCommand("dbo.XRec_GetNavigationCount", SqlConn);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", (object)CandidateCode);
                DataTable dataTable = new DataTable();
                new SqlDataAdapter(selectCommand).Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "GetProfileNavCount" + ex.Message + " " + ex.StackTrace, ex, "");
                return null;
            }
            finally
            {
                if (SqlConn.State != ConnectionState.Closed)
                    SqlConn.Close();
            }
        }
    }
}

