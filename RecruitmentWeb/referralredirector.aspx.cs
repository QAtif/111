using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class referralredirector : System.Web.UI.Page
{
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString = new SecureQueryString();

    protected void Page_Load(object sender, EventArgs e)
    {
        QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
        if (QueryStringVar != null)
        {
            secQueryString = new SecureQueryString(QueryStringVar);
            if (secQueryString != null)
            {
                if (secQueryString["rfc"] != null)
                    Response.Redirect("signup.aspx?data=" + QueryStringVar);
                else
                    Response.Redirect("signup.aspx");
            }
            else
                Response.Redirect("signup.aspx");
        }
        else
            Response.Redirect("signup.aspx");
    }

}