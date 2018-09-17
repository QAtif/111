// Decompiled with JetBrains decompiler
// Type: CustomBasePage
// Assembly: App_Code, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CCFCF570-EAC0-4D2F-8EF3-866C275AB6B3
// Assembly location: C:\Users\atifhussain\Desktop\Dlls\Axact Recruitment\App_Code.dll

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

public class CustomBasePage : Page
{
    private string userName = string.Empty;
    private string userip = string.Empty;
    private DataTable dtactions = new DataTable();
    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    private int userCode;

    public int UserCode
    {
        get
        {
            return userCode;
        }
        set
        {
            userCode = value;
        }
    }

    public string USERIP
    {
        get
        {
            return userip;
        }
        set
        {
            userip = value;
        }
    }

    public DataTable DTActions
    {
        get
        {
            return dtactions;
        }
        set
        {
            dtactions = value;
        }
    }

    public string UserName
    {
        get
        {
            if (userName == string.Empty)
                GetUserDetails();
            return userName;
        }
    }

    public CustomBasePage()
    {
        if (HttpContext.Current.Request.Cookies["userid"] != null)
            UserCode = Convert.ToInt32(HttpContext.Current.Request.Cookies["userid"].Value);
        if (HttpContext.Current.Request.Cookies["userIP"] == null)
            return;
        USERIP = HttpContext.Current.Request.Cookies["userIP"].Value;
    }

    protected void GetUserDetails()
    {
        if (HttpContext.Current.Session["UserName"] != null)
        {
            userName = HttpContext.Current.Session["UserName"].ToString();
        }
        else
        {
            if (connection.State != ConnectionState.Open) connection.Open();
            SqlCommand selectCommand = new SqlCommand("XRec_UserDetailsHeader", connection);
            selectCommand.Parameters.AddWithValue("@UserID", userCode);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count <= 0)
                return;
            userName = dataSet.Tables[0].Rows[0]["User_Name"].ToString();
            HttpContext.Current.Session["UserName"] = userName;
            if (connection.State != ConnectionState.Closed) connection.Close();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        //if (HttpContext.Current.Request.Cookies["userid"] != null)
        //{
        //  UserCode = Convert.ToInt32(HttpContext.Current.Request.Cookies["userid"].Value);
        UserCode = 3179;
        //  switch (userCode)
        //  {
        //    case -1:
        //      Response.Redirect(ConfigurationSettings.AppSettings["RedirectPage"] + "?url=" + HttpContext.Current.Request.Url.AbsoluteUri, true);
        //      break;
        //    case 0:
        //      Response.Redirect(ConfigurationSettings.AppSettings["RedirectPage"] + "?url=" + HttpContext.Current.Request.Url.AbsoluteUri, true);
        //      break;
        //  }
        VerifyRights();
        //}
        //else
        //  Response.Redirect(ConfigurationSettings.AppSettings["RedirectPage"] + "?url=" + HttpContext.Current.Request.Url.AbsoluteUri, true);
    }

    private void VerifyRights()
    {
        string str1 = string.Empty;
        string str2 = string.Empty;
        string empty = string.Empty;
        string str3 = string.Empty;
        string str4 = string.Empty;
        string str5 = string.Empty;
        if (HttpContext.Current != null && HttpContext.Current.Request != null)
        {
            str1 = HttpContext.Current.Request.Path != null ? HttpContext.Current.Request.Path : string.Empty;
            NameValueCollection nameValueCollection = HttpContext.Current.Request.QueryString != null ? HttpContext.Current.Request.QueryString : null;
            str2 = CustomBasePage.GetSessionKeys();
            empty = string.Empty;
            if (nameValueCollection != null)
                empty = nameValueCollection.ToString();
            str3 = HttpContext.Current.Request.ServerVariables["HTTP_REFERER"] != null ? HttpContext.Current.Request.ServerVariables["HTTP_REFERER"].ToString() : string.Empty;
            str5 = USERIP;
            str4 = "Type: " + HttpContext.Current.Request.Browser.Browser + " | Version: " + HttpContext.Current.Request.Browser.Version + " | JavaScript: " + HttpContext.Current.Request.Browser.EcmaScriptVersion.ToString();
        }

        if (connection.State != ConnectionState.Open) connection.Open();
        SqlCommand selectCommand = new SqlCommand("XRec_CheckUserRightsWithLog", connection);
        selectCommand.Parameters.AddWithValue("@UserID", userCode);
        if ((HttpContext.Current.Request.Url.AbsoluteUri.ToString().Replace("http://localhost:17538/", "http://recruitment.bolnetwork.com/")).Contains('?'))
        {
            string str6 = HttpContext.Current.Request.Url.AbsoluteUri.ToString().Replace("http://localhost:17538/", "http://recruitment.bolnetwork.com/");
            selectCommand.Parameters.AddWithValue("@url", str6.Substring(0, str6.IndexOf('?')));
        }
        else
            selectCommand.Parameters.AddWithValue("@url", HttpContext.Current.Request.Url.AbsoluteUri.ToString().Replace("http://localhost:17538/", "http://recruitment.bolnetwork.com/"));
        selectCommand.Parameters.AddWithValue("@UserIP", str5);
        selectCommand.Parameters.AddWithValue("@Request_Path", str1);
        selectCommand.Parameters.AddWithValue("@Request_QueryString", empty);
        selectCommand.Parameters.AddWithValue("@Referer", str3);
        selectCommand.Parameters.AddWithValue("@Session_Variables", str2);
        selectCommand.Parameters.AddWithValue("@Browser_Details", str4);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (connection.State != ConnectionState.Closed) connection.Close();
        if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["RetVal"].ToString() == "0")
            Response.Redirect(ConfigurationSettings.AppSettings["NotAuthorize"], true);
        if (dataSet.Tables[1].Rows.Count <= 0)
            return;
        DTActions = dataSet.Tables[1];
    }

    private static string GetSessionKeys()
    {
        string str = string.Empty;
        foreach (string key in HttpContext.Current.Session.Keys)
        {
            if (HttpContext.Current.Session.Contents[key] == null)
                str = str + key + "=null;";
            else
                str = str + key + "=" + HttpContext.Current.Session.Contents[key].ToString() + ";";
        }
        return str;
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
    }
}
