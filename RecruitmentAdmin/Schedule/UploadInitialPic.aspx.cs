
using ErrorLog;
using System;
using System.IO;
using System.Web.UI;

public partial class UploadInitialPic : CustomBasePage
{
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        int num = IsPostBack ? 1 : 0;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            if (fuDocument.HasFile)
            {
                string path = DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + fuDocument.FileName;
                if (!Directory.Exists(Server.MapPath("/Documents/")))
                    Directory.CreateDirectory(Server.MapPath("/assets/"));
                fuDocument.SaveAs(Server.MapPath(path));
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "refreshParent();", true);
    }
    #endregion

}