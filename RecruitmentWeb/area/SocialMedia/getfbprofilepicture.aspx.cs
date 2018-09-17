using Facebook;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Caching;



public partial class SocialMedia_getfbprofilepicture : CustomBaseClass
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string str1 = "";
        string str2 = "";
        int num1 = 1;
        int num2 = 1;
        string appSetting1 = ConfigurationManager.AppSettings["FacebookClientId"];
        string appSetting2 = ConfigurationManager.AppSettings["FacebookClientSecret"];
        string appSetting3 = ConfigurationManager.AppSettings["FacebookCallbackURL"];
        string appSetting4 = ConfigurationManager.AppSettings["FacebookScope"];
        if (IsPostBack)
            return;
        int candidateCode = CandidateCode;
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        StringCollection parameters = new StringCollection();
        string str3 = CandidateCode.ToString();
        if (Request.QueryString["picType"] != null)
            Session["picType"] = Request.QueryString["picType"].ToString();
        try
        {
            parameters.Add(CandidateCode.ToString());
            DataSet detailsPageMethod = GetAreaDetailsPageMethod(sqlCon, parameters);
            if (detailsPageMethod != null)
            {
                if (detailsPageMethod.Tables.Count > 0)
                {
                    if (detailsPageMethod.Tables[0].Rows.Count > 0)
                    {
                        string str4 = "";
                        if (Session["picType"].ToString() == "2" && detailsPageMethod.Tables[0].Rows[0]["CoverImage_Path"] != null && detailsPageMethod.Tables[0].Rows[0]["CoverImage_Path"].ToString() != "")
                        {
                            string[] strArray = detailsPageMethod.Tables[0].Rows[0]["CoverImage_Path"].ToString().Split('/');
                            num1 = int.Parse(strArray[strArray.Length - 1].Split('.')[0]) + 1;
                        }
                        if (Session["picType"].ToString() == "1")
                        {
                            if (detailsPageMethod.Tables[0].Rows[0]["ProfileImage_Path"] != null)
                            {
                                if (detailsPageMethod.Tables[0].Rows[0]["ProfileImage_Path"] != "")
                                {
                                    str4 = detailsPageMethod.Tables[0].Rows[0]["ProfileImage_Path"].ToString();
                                    string[] strArray = detailsPageMethod.Tables[0].Rows[0]["CoverImage_Path"].ToString().Split('/');
                                    num2 = int.Parse(strArray[strArray.Length - 1].Split('.')[0]) + 1;
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
        parameters.Clear();
        string str5 = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + str3 + "/ProfilePhotos/";
        string str6 = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + str3 + "/CoverPhotos/";
        string filename1 = Server.MapPath(str5 + num2.ToString() + ".jpg");
        string filename2 = Server.MapPath(str6 + num1.ToString() + ".jpg");
        string str7 = str3;
        try
        {
            CreateECMDocumentFolder();
            sqlCon.Open();
            if (Request.Params["code"] != null)
            {
                JSONObject jsonObject = new FacebookAPI(GetAccessToken()).Get("/me");
                string str4 = jsonObject.Dictionary["first_name"].String;
                string imageUrl1 = "https://graph.facebook.com/" + jsonObject.Dictionary["id"].String + "/picture?type=large";
                myimage.Src = imageUrl1;
                string address = "https://graph.facebook.com/" + jsonObject.Dictionary["id"].String + "?fields=cover";
                string json = string.Empty;
                try
                {
                    Stream stream = new WebClient().OpenRead(address);
                    json = new StreamReader(stream).ReadLine();
                    stream.Close();
                }
                catch (WebException ex)
                {
                }
                string imageUrl2 = string.Empty;
                JToken jtoken = (JToken)JObject.Parse(json);
                if (jtoken.SelectToken("cover") != null)
                    imageUrl2 = (string)JObject.Parse(jtoken.SelectToken("cover").ToString()).SelectToken("source");
                if (Session["picType"].ToString() == "1")
                {
                    DownloadImageFromUrl(imageUrl1).Save(filename1, ImageFormat.Jpeg);
                    parameters.Clear();
                    parameters.Add(str5 + num2.ToString() + ".jpg");
                    parameters.Add(str7);
                    str2 = str5 + num2.ToString() + ".jpg";
                    UpdateProfilePicture(sqlCon, parameters);
                }
                else if (Session["picType"].ToString() == "2")
                {
                    if (!string.IsNullOrEmpty(imageUrl2))
                    {
                        DownloadImageFromUrl(imageUrl2).Save(filename2, ImageFormat.Jpeg);
                        parameters.Clear();
                        parameters.Add(str6 + num1 + ".jpg");
                        parameters.Add(str7);
                        str1 = str6 + num1 + ".jpg";
                        UpdateCoverPicture(sqlCon, parameters);
                    }
                }
            }
            else
            {
                HttpRuntime.Cache.Remove("access_token");
                string str4 = appSetting3;
                Response.Redirect("https://graph.facebook.com/oauth/authorize?client_id=" + appSetting1 + "&redirect_uri=" + str4 + "&scope=" + appSetting4, false);
            }
        }
        catch (FacebookAPIException ex)
        {
        }
        catch (WebException ex)
        {
        }
        catch (Exception ex)
        {
        }
        finally
        {
            sqlCon.Close();
        }
        ClientScript.RegisterClientScriptBlock(GetType(), "redirect", "SetAreaImages('" + str1 + "','" + str2 + "'); window.close();", true);
    }

    private string GetAccessToken()
    {
        if (HttpRuntime.Cache["access_token"] == null)
            HttpRuntime.Cache.Insert("access_token", GetOauthTokens(Request.Params["code"])["access_token"], (CacheDependency)null, DateTime.Now.AddMinutes(Convert.ToDouble(100)), TimeSpan.Zero);
        return HttpRuntime.Cache["access_token"].ToString();
    }

    private Dictionary<string, string> GetOauthTokens(string code)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        string appSetting1 = ConfigurationManager.AppSettings["FacebookClientId"];
        string appSetting2 = ConfigurationManager.AppSettings["FacebookClientSecret"];
        string appSetting3 = ConfigurationManager.AppSettings["FacebookCallbackURL"];
        string appSetting4 = ConfigurationManager.AppSettings["FacebookScope"];
        HttpWebRequest httpWebRequest = WebRequest.Create("https://graph.facebook.com/oauth/access_token?client_id=" + appSetting1 + "&redirect_uri=" + appSetting3 + "&client_secret=" + appSetting2 + "&code=" + code + "&scope=" + appSetting4) as HttpWebRequest;
        try
        {
            using (HttpWebResponse response = httpWebRequest.GetResponse() as HttpWebResponse)
            {
                string end = new StreamReader(response.GetResponseStream()).ReadToEnd();
                char[] chArray = new char[1] { '&' };
                foreach (string str in end.Split(chArray))
                    dictionary.Add(str.Substring(0, str.IndexOf("=")), str.Substring(str.IndexOf("=") + 1, str.Length - str.IndexOf("=") - 1));
            }
        }
        catch (Exception ex)
        {
            dictionary.Add("access_token", "AAAF02Kcg31oBAK4PkZAwJQRKQta71YZBxWdm2tCNR564wU0b6KhnYiwKqWzqngtxIkWxhaQqe04oarzdFb3s3vc8fXsUoF7Tk1QgmqG0KK0OyKyeqb");
        }
        return dictionary;
    }

    public bool CreateECMDocumentFolder()
    {
        try
        {
            string str1 = CandidateCode.ToString();
            string str2 = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString());
            if (!Directory.Exists(str2 + str1 + "/ProfilePhotos"))
                Directory.CreateDirectory(str2 + str1 + "/ProfilePhotos");
            if (!Directory.Exists(str2 + str1 + "/CoverPhotos"))
                Directory.CreateDirectory(str2 + str1 + "/CoverPhotos");
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public System.Drawing.Image DownloadImageFromUrl(string imageUrl)
    {
        System.Drawing.Image image;
        try
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(imageUrl);
            httpWebRequest.AllowWriteStreamBuffering = true;
            httpWebRequest.Timeout = 30000;
            WebResponse response = httpWebRequest.GetResponse();
            image = System.Drawing.Image.FromStream(response.GetResponseStream());
            response.Close();
        }
        catch (Exception ex)
        {
            return (System.Drawing.Image)null;
        }
        return image;
    }

    public int UpdateProfilePicture(SqlConnection sqlCon, StringCollection parameters)
    {
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlCon;
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "XRec_UpdateCandidateProfileImage";
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = parameters[1];
        sqlCommand.Parameters.Add("@ProfileImagePath", SqlDbType.VarChar).Value = parameters[0];
        return sqlCommand.ExecuteNonQuery();
    }

    public int UpdateCoverPicture(SqlConnection sqlCon, StringCollection parameters)
    {
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlCon;
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "XRec_UpdateCandidateCoverImage";
        sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = parameters[1];
        sqlCommand.Parameters.Add("@CoverImagePath", SqlDbType.VarChar).Value = parameters[0];
        return sqlCommand.ExecuteNonQuery();
    }

    public DataSet GetAreaDetailsPageMethod(SqlConnection sqlCon, StringCollection parameters)
    {
        SqlCommand selectCommand = new SqlCommand();
        selectCommand.Connection = sqlCon;
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.CommandText = "XRec_SelectCandidateProfileImagePath";
        selectCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = parameters[0];
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        return dataSet;
    }


}