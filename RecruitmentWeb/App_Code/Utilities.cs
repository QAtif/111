using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Utilities
/// </summary>
public class Utilities
{
    public static string encryptQueryString(string fullString)
    {
        SecureQueryString secureQueryString = new SecureQueryString();
        StringBuilder stringBuilder = new StringBuilder("page=" + Utilities.getPageName(fullString));
        if (Utilities.getAppendQueryString(fullString) != string.Empty)
            stringBuilder.Append("&" + Utilities.getAppendQueryString(fullString));
        return fullString.Substring(0, fullString.IndexOf(".aspx") + 5) + "?" + Convert.ToString(SecureQueryString.QueryStringVar + "=" + HttpContext.Current.Server.HtmlEncode(secureQueryString.encrypt(stringBuilder.ToString())));
    }

    public static string encryptQueryStringPartner(string fullString, string sessionID)
    {
        SecureQueryString secureQueryString = new SecureQueryString();
        StringBuilder stringBuilder = new StringBuilder("page=" + Utilities.getPageName(fullString) + "&guid=" + sessionID + "&sCode=" + HttpContext.Current.Session["Student_Code"].ToString() + "&isPartner=1");
        if (Utilities.getAppendQueryString(fullString) != string.Empty)
            stringBuilder.Append("&" + Utilities.getAppendQueryString(fullString));
        return fullString.Substring(0, fullString.IndexOf(".aspx") + 5) + "?" + Convert.ToString(SecureQueryString.QueryStringVar + "=" + HttpContext.Current.Server.HtmlEncode(secureQueryString.encrypt(stringBuilder.ToString())));
    }

    public static Hashtable decryptQueryString(string _qs)
    {
        Hashtable hashtable = new Hashtable();
        SecureQueryString secureQueryString = new SecureQueryString(HttpContext.Current.Server.HtmlDecode(_qs));
        foreach (object obj in (NameObjectCollectionBase)secureQueryString)
            hashtable.Add((object)obj.ToString(), (object)secureQueryString[obj.ToString()]);
        return hashtable;
    }

    public static string decryptString(string _qs)
    {
        string empty = string.Empty;
        return new SecureQueryString(HttpContext.Current.Server.HtmlDecode(_qs)).decrypt(_qs).ToString();
    }

    public static string getPageName(string fullPath)
    {
        string empty = string.Empty;
        string str1;
        if (fullPath.IndexOf("/") != -1)
        {
            string str2 = fullPath.Substring(0, fullPath.LastIndexOf(".aspx"));
            str1 = str2.Substring(str2.LastIndexOf("/") + 1, str2.Length - str2.LastIndexOf("/") - 1);
        }
        else if (fullPath.IndexOf("\\") != -1)
        {
            string str2 = fullPath.Substring(0, fullPath.LastIndexOf(".aspx"));
            str1 = str2.Substring(str2.LastIndexOf("\\") + 1, str2.Length - str2.LastIndexOf("\\") - 1);
        }
        else
            str1 = fullPath.Substring(0, fullPath.LastIndexOf(".aspx"));
        return str1;
    }

    public static string getAppendQueryString(string fullPath)
    {
        string str = string.Empty;
        if (fullPath.IndexOf("?") != -1)
            str = fullPath.Substring(fullPath.IndexOf("?") + 1, fullPath.Length - fullPath.IndexOf("?") - 1);
        return str;
    }

    public static string encryptQueryString(string fullString, string sessionID, string ClientCode)
    {
        SecureQueryString secureQueryString = new SecureQueryString();
        StringBuilder stringBuilder = new StringBuilder("page=" + Utilities.getPageName(fullString) + "&guid=" + sessionID + "&sCode=" + HttpContext.Current.Session["Student_Code"].ToString() + "&cc=" + ClientCode + "&cid=" + HttpContext.Current.Session["Student_Code"].ToString());
        if (Utilities.getAppendQueryString(fullString) != string.Empty)
            stringBuilder.Append("&" + Utilities.getAppendQueryString(fullString));
        return fullString.Substring(0, fullString.IndexOf(".aspx") + 5) + "?" + Convert.ToString(SecureQueryString.QueryStringVar + "=" + HttpContext.Current.Server.HtmlEncode(secureQueryString.encrypt(stringBuilder.ToString())));
    }

    public static void changePaymentPlan(string studentCode, string studentProgramCode, SqlConnection displayConnection, SqlTransaction displayTransaction)
    {
    }

    public static void CancelPreviousSubscriptionsForNewProgram(string studentCode, string studentProgramCode, SqlConnection displayConnection, SqlTransaction displayTransaction)
    {
    }

    public static void CallReverseOnRecurring(string Order_Code)
    {
    }
}
