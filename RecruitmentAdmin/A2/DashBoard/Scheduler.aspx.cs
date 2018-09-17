using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class A2_DashBoard_Scheduler : CustomBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["sessionId"] = UserCode.ToString();
    }
}