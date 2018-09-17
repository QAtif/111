using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using System.Web.Profile;
using System.Web.UI.HtmlControls;



public partial class Site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        spnName.InnerText = new CustomBasePage().UserName;
    }
}
