using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class AdminRedirector : System.Web.UI.Page
{
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString = new SecureQueryString();
    string candidatecode = string.Empty;
    string url = string.Empty;
    string usertypecode = string.Empty;
    string adminusercode = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString[SecureQueryString.QueryStringVar] == null)
            return;
        Hashtable hashtable = Utilities.decryptQueryString(Request.QueryString[SecureQueryString.QueryStringVar].ToString());
        candidatecode = hashtable["candidate_code"] != null ? hashtable["candidate_code"].ToString() : string.Empty;
        url = hashtable["url"] != null ? hashtable["url"].ToString() : string.Empty;
        usertypecode = hashtable["utc"] != null ? hashtable["utc"].ToString() : string.Empty;
        adminusercode = hashtable["auc"] != null ? hashtable["auc"].ToString() : string.Empty;
        if (!(candidatecode != string.Empty) || !(url != string.Empty) || (!(usertypecode != string.Empty) || !(adminusercode != string.Empty)))
            return;
        Session["CC"] = candidatecode;
        Session["UserTypeCode"] = usertypecode;
        Session["AdminUserCode"] = adminusercode;
        Response.Redirect(url, false);
    }
}