using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using ErrorLog;
using System.Threading;

public partial class StudentArea_UploadProfileImage2 : CustomBaseClass
{
    string coverphoto = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        int candidateCode = CandidateCode;
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        StringCollection stringCollection = new StringCollection();
        try
        {
            CreateInstituteDocumentFolder();
            string candidatecode = CandidateCode.ToString();
            string empty1 = string.Empty;
            string s = string.Empty;
            string empty2 = string.Empty;
            int result = 1;
            string str1 = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + candidatecode + "/CoverPhotos/";
            string str2 = Request.Files[0].FileName.Substring(Request.Files[0].FileName.LastIndexOf('.') + 1);
            if (IsImage(Request.Files[0].FileName))
            {
                int contentLength = Request.Files[0].ContentLength;
                if (contentLength > 2048 && contentLength < 2097152)
                {
                    DataSet dataSet = SelectProfileImageName(candidatecode);
                    if (dataSet.Tables[0].Rows[0][1].ToString() != "0")
                    {
                        string str3 = dataSet.Tables[0].Rows[0][1].ToString();
                        s = str3.Substring(str3.LastIndexOf('/') + 1);
                    }
                    if (!string.IsNullOrEmpty(s))
                        s = s.Split('.')[0];
                    string str4 = !int.TryParse(s, out result) ? "1." + str2 : (result + 1).ToString() + "." + str2;
                    Request.Files[0].SaveAs(Server.MapPath(str1 + str4));
                    UpdateCoverPicture(str1 + str4, candidatecode);
                    Thread.Sleep(5000);
                    lblImage.Text = str1 + str4;
                    imgUpload.ImageUrl = str1 + str4;
                }
                else
                    lblImage.Text = "2Error:Please Select file size between 2 Kb to 4 Mb.";
            }
            else
                lblImage.Text = "1Error:Please Select Image.";
        }
        catch (Exception ex)
        {
        }
        finally
        {
            sqlConnection.Close();
        }
    }

    private void UpdateCoverPicture(string ProfileImagePath, string candidatecode)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateCoverImage", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", candidatecode));
                    sqlCommand.Parameters.Add(new SqlParameter("@CoverImagePath", ProfileImagePath));
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "XRec_CreateCandidateLogin", ex, "0");
            }
        }
    }

    private DataSet SelectProfileImageName(string candidatecode)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateProfileImagePath", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.Add(new SqlParameter("@CandidateCode", candidatecode));
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "XRec_SelectCandidatePFPath", ex, "0");
            }
        }
        return dataSet;
    }

    public bool IsImage(string Path)
    {
        return new Regex("\\.jpg$|\\.jpeg$|\\.png$|\\.gif$|\\.bmp$", RegexOptions.IgnoreCase).IsMatch(Path);
    }

    public bool CreateInstituteDocumentFolder()
    {
        try
        {
            string str1 = CandidateCode.ToString();
            string str2 = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString());
            if (!Directory.Exists(str2 + str1 + "/CoverPhotos"))
                Directory.CreateDirectory(str2 + str1 + "/CoverPhotos");
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }




}
