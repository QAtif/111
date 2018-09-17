using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class signupredirector : System.Web.UI.Page
{
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;

    protected void Page_Load(object sender, EventArgs e)
    {
        QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
    }
}