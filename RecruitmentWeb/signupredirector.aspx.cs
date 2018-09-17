using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class signupredirector : System.Web.UI.Page
{
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString = new SecureQueryString();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.QueryString.ToString() != null && HttpContext.Current.Request.QueryString.ToString() != string.Empty)
        {
            QueryStringVar = HttpContext.Current.Request.QueryString.ToString();
            Response.Redirect("signup.aspx?data=" + secQueryString.encrypt(QueryStringVar));
        }
        else
            Response.Redirect("signup.aspx");
    }
}