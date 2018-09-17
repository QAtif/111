using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    DataSet ds = new DataSet();
    string RoleID = string.Empty;
    string localPath = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }


    protected string GetRoleID(string EmpID)
    {
        localPath = HttpContext.Current.Request.Url.LocalPath;
        localPath = localPath.ToString().ToLower();
        if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("http://localhost"))
        {
            localPath = localPath.Substring(localPath.IndexOf("/") + 1);
            localPath = localPath.Substring(localPath.IndexOf("/"));
        }
        if (ConfigurationManager.AppSettings["CheckAuthentication"] != null && ConfigurationManager.AppSettings["CheckAuthentication"] == "0")
            return "7";
        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["RoleID"].ToString()))
            return ds.Tables[0].Rows[0]["RoleID"].ToString();
        return "0";
    }

    
   
}
