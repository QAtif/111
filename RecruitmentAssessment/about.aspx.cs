using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ErrorLog;

public partial class about : System.Web.UI.Page
{
    protected int TestCode = 0;
    protected int CandidateCode = 0;
    XRecBase objXRecBase = new XRecBase();

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (Request.QueryString == null || Request.QueryString["tid"] == null || (Request.QueryString == null || Request.QueryString["tid"] == null) || !(Request.QueryString["tid"].ToString() != ""))
                return;
            hdTestID.Value = Request.QueryString["tid"].ToString();
            TestCode = Convert.ToInt32(Request.QueryString["tid"].ToString());

        }
        catch (Exception ex)
        {

            LogError.Write(LogError.AppType.RecruitmentAssessment, ex.StackTrace, ex, objXRecBase.UserID.ToString());
        }

    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            HttpContext.Current.Response.Redirect("CandidateWelcome.aspx?tid=" + TestCode, false);
        }
        catch (Exception ex)
        {

            LogError.Write(LogError.AppType.RecruitmentAssessment, ex.StackTrace, ex, objXRecBase.UserID.ToString());
        }


    }
}