using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImpactWorks.FBGraph.Connector;
using ImpactWorks.FBGraph.Core;
using ImpactWorks.FBGraph.Interfaces;
using System.Net;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Specialized;
using System.Configuration;
using System.Text.RegularExpressions;

public partial class FBConnectPage : System.Web.UI.Page
{
    string AppID = ConfigurationManager.AppSettings["FBApiKey"];
    string Secret = ConfigurationManager.AppSettings["FBSecretKey"];
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    ImpactWorks.FBGraph.Connector.Facebook facebook = new ImpactWorks.FBGraph.Connector.Facebook();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["code"]))
            {
                CheckFB();
                //ScriptManager.RegisterClientScriptBlock(this, GetType(), "close", "CloseWindow();", true);

            }
            else if (!String.IsNullOrEmpty(Request.QueryString["error"]))
            {
                Response.Redirect("http://www.axact.com/products/protect/", false);
            }
            else
            {
                FbPermissionsAndFetchData();
            }
        }
    }
    public void CheckFB()
    {
        try
        {
            //Get the code returned by facebook
            string Code = Request.QueryString["code"];

            facebook.AppID = AppID;
            facebook.Secret = Secret;
            facebook.CallBackURL = ConfigurationManager.AppSettings["FBCallBackAccountUrl"].ToString();

            //process code for auth token
            facebook.GetAccessToken(Code);

            //Get User info
            FBUser currentUser = facebook.GetLoggedInUserInfo();

            ViewState["FbID"] = currentUser.id == null ? "" : currentUser.id.ToString().Trim() ?? "";
            ViewState["FbFullName"] = currentUser.name == null ? "" : currentUser.name.Trim() ?? "";
            ViewState["Fbemail"] = currentUser.email == null ? "" : currentUser.email.Trim() ?? "";
            ViewState["FbcountryName"] = "";
            ViewState["FBPost"] = "";
            try
            {
                ViewState["FbcountryName"] = currentUser.location == null || currentUser.location.name.Trim() == string.Empty ? "" : currentUser.location.name.Remove(0, currentUser.location.name.LastIndexOf(",") + 1).Trim() ?? "";
            }
            catch (Exception)
            {
                ViewState["FbcountryName"] = "";
            }

            ViewState["FbFName"] = currentUser.first_name == null ? "" : currentUser.first_name.Trim() ?? "";
            ViewState["FbLName"] = currentUser.last_name == null ? "" : currentUser.last_name.Trim() ?? "";
            ViewState["FbLink"] = currentUser.link == null ? "" : currentUser.link.Trim() ?? "";
            ViewState["Fbhometown"] = currentUser.hometown == null || currentUser.hometown.name.Trim() == string.Empty ? "" : currentUser.hometown.name.Trim() ?? "";
            ViewState["Fbgender"] = currentUser.gender == null ? "" : currentUser.gender.Trim() ?? "";
            ViewState["FbbirthDay"] = currentUser.birthday == null ? "" : currentUser.birthday.ToString() ?? "";
            ViewState["FbBio"] = currentUser.Bio == null || currentUser.Bio.ToString() == string.Empty ? "" : currentUser.Bio.ToString() ?? "";

            // For saving User and facebook Info 
            SaveUserAndFacebookInfo();

            #region WallPost
            try
            {
                IFeedPost FBpost = new FeedPost();
                FBpost.Action = new FBAction { Name = "Axact Protect", Link = "http://www.facebook.com/axactians" };
                FBpost.Caption = "Axact Protect, a highly acclaimed data protection software.";
                FBpost.Description = "The ALL-IN-ONE data protection suite with an advanced, secure, complete, affordable, user-friendly, and convenient data protection solution for your confidential files, folders, and drives.";
                FBpost.ImageUrl = "http://www.axact.com/products/protect/axact-protect-fb-post.png";
                FBpost.Message = "I have started using Axact Protect.";
                FBpost.Name = "Axact Protect";
                FBpost.Url = "http://www.facebook.com/axactians";

            
                var postID = facebook.PostToWall(currentUser.id.GetValueOrDefault(), FBpost);

                ViewState["FBPost"] = postID;
            }
            catch (Exception ex)
            {
                //Response.Write("POST ERROR || " + ex.Message);
            }
            #endregion

            #region Download Exe

            try
            {

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "close", "window.open('" + ConfigurationManager.AppSettings["xPrortectDownloadLink"].ToString() + "'); ", true);


                // FileResponse(Path.GetFileName(Server.MapPath(ConfigurationManager.AppSettings["XProtectPath"])), Path.GetDirectoryName(Server.MapPath(ConfigurationManager.AppSettings["XProtectPath"])));

                Response.AddHeader("Refresh", "5; url=http://www.axact.com/products/protect/thanks.asp");

            }
            catch (Exception ex)
            {
                //Response.Write("DOWNLOAD FILE ERROR || " + ex.Message);
            }
            #endregion


        }
        catch (Exception ex)
        {
            //Response.Write(ex.Message);
            Response.AddHeader("Refresh", "5; url=http://www.axact.com/products/protect/");
        }
        finally
        {
            //Response.Redirect("http://www.axact.com/products/protect/thanks.asp", false);
        }
    }

    public bool SaveUserAndFacebookInfo()
    {
        bool status = false;

        try
        {
            //decimal userInfoId;
            string AlternativeEmail = string.Empty;
            #region Insert UserInfo

            connection.Open();
            SqlCommand command;
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "XRec_InsertProductUserInfo";
            command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = ViewState["FbFName"].ToString();
            command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = ViewState["FbLName"].ToString();
            command.Parameters.Add("@DOB", SqlDbType.DateTime).Value = ViewState["FbbirthDay"].ToString();
            command.Parameters.Add("@Gender", SqlDbType.VarChar).Value = ViewState["Fbgender"].ToString();
            command.Parameters.Add("@LocationName", SqlDbType.VarChar).Value = ViewState["FbcountryName"].ToString();
            command.Parameters.Add("@UpdatedIP", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"].ToString();
            command.Parameters.Add("@CurrentURL", SqlDbType.VarChar).Value = Request.Url.ToString();
            command.Parameters.Add("@ReferrerURL", SqlDbType.VarChar).Value = Request.UrlReferrer == null ? "" : Request.UrlReferrer.ToString();
            command.Parameters.Add("@FBProfileURL", SqlDbType.VarChar).Value = ViewState["FbLink"].ToString();
            command.Parameters.Add("@FullName", SqlDbType.VarChar).Value = ViewState["FbFullName"].ToString();
            command.Parameters.Add("@FBID", SqlDbType.VarChar).Value = ViewState["FbID"].ToString();
            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = ViewState["Fbemail"].ToString();
            command.Parameters.Add("@IsFBPost", SqlDbType.VarChar).Value = ViewState["FBPost"].ToString();


            command.ExecuteNonQuery();


            #endregion

            status = true;
            Session["openPopup"] = "Completed";
            Session["syncFacebookWithAccount"] = 1;
        }
        catch (Exception ex)
        {
            status = false;
        }
        finally
        {
            connection.Close();
        }
        return status;
    }


    public void FbPermissionsAndFetchData()
    {
        try
        {
            facebook.AppID = AppID;
            facebook.Secret = Secret;
            facebook.CallBackURL = ConfigurationManager.AppSettings["FBCallBackAccountUrl"].ToString();

            FBPermissions[] input = { 
                FBPermissions.email,
                FBPermissions.user_about_me, 
                FBPermissions.user_birthday,
                FBPermissions.user_location,
                FBPermissions.publish_stream,
                FBPermissions.read_stream,
                //FBPermissions.user_education_history,
                //FBPermissions.user_relationships,
                //FBPermissions.user_work_history,
                //FBPermissions.user_website,
                //FBPermissions.offline_access,
                //FBPermissions.manage_friendlists,
                //FBPermissions.read_friendlists,
                //FBPermissions.create_event,
                //FBPermissions.user_events,
                //FBPermissions.friends_events
           };

            //Setting up the permissions
            List<FBPermissions> permissions = new List<FBPermissions>(input);
            //Pass the permissions object to facebook instance
            facebook.Permissions = permissions;

            if (String.IsNullOrEmpty(Request.QueryString["code"]))
            {
                String authLink = facebook.GetAuthorizationLink();
                Response.Redirect(authLink, false);
            }
        }
        catch (Exception ex)
        {
            //Response.Write(ex.Message);
        }
        finally
        {
        }
    }

    #region FileDownload

    public static void FileResponse(string fileName, string FolderPath)
    {
        string path = string.Empty;

        if (IsValidPath(FolderPath))
            path = FolderPath + "/" + fileName;
        else
            path = System.Web.HttpContext.Current.Server.MapPath(FolderPath + "/" + fileName);

        System.IO.FileInfo thisfile = new System.IO.FileInfo(path); //-- if the file exists 
        BinaryReader fs = new BinaryReader(thisfile.OpenRead());
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
        HttpContext.Current.Response.AddHeader("Content-Length", thisfile.Length.ToString());
        HttpContext.Current.Response.ContentType = "application/octet-stream";
        byte[] bite = fs.ReadBytes((int)thisfile.Length);

        fs.Close();
        HttpContext.Current.Response.BinaryWrite(bite);

        /*
                string path = string.Empty;

                if (IsValidPath(FolderPath))
                    path = FolderPath + "/" + filename;
                else
                    path = System.Web.HttpContext.Current.Server.MapPath(FolderPath + "/" + filename);

                System.IO.FileInfo file = new System.IO.FileInfo(path); //-- if the file exists 
                if (file.Exists) //set appropriate headers  
                {
                    BinaryReader fs = new BinaryReader(file.OpenRead());
                    //HttpContext.Current.Response.ClearContent();
                    //HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                    HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
                    HttpContext.Current.Response.ContentType = "application/octet-stream";
                    byte[] bite = fs.ReadBytes((int)file.Length);
                    fs.Close();
                    HttpContext.Current.Response.BinaryWrite(bite);
                }
        */
    }

    public static bool IsValidPath(string path)
    {
        Regex r = new Regex(@"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.]+)\\(?:[\w]+\\)*");
        return r.IsMatch(path);
    }

    #endregion
}