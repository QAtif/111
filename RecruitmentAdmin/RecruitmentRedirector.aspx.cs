using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class RecruitmentRedirector : System.Web.UI.Page
{
   

     CustomBasePage objCBP = new CustomBasePage();
     string userIP = string.Empty;
     int userCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        BindData();
    }

    private void BindData()
    {
        if (Request.QueryString["uid"] != null)
        {
            try
            {
                objCBP.UserCode = Convert.ToInt32(Request.QueryString["uid"]);
                userCode = Convert.ToInt32(Request.QueryString["uid"]);
                CreateCookie();
            }
            catch
            {
            }
        }
        if (Request.QueryString["uip"] != null)
        {
            try
            {
                objCBP.USERIP = Request.QueryString["uip"].ToString();
                userIP = Request.QueryString["uip"].ToString();
                if (Request.Cookies["userIP"] != null)
                    Request.Cookies.Remove("userIP");
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("userIP")
                {
                    Value = userIP,
                    Expires = DateTime.Now.AddDays(1.0)
                });
            }
            catch
            {
            }
        }
        if (Request.QueryString["url"] == null)
            return;
        Response.Redirect(Request.QueryString["url"], true);
    }

    private void CreateCookie()
    {
        if (Request.Cookies["userid"] != null)
            Request.Cookies.Remove("userid");
        HttpContext.Current.Response.Cookies.Add(new HttpCookie("userid")
        {
            Value = userCode.ToString(),
            Expires = DateTime.Now.AddDays(1.0)
        });
    }
}