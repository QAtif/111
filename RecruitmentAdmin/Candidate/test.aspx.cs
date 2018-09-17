using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Onclick(object sender, EventArgs e)
    {
        string FolderPath = "xwebsrv/XRecruitmentNew/CandidateDocuments/" + "370" + "/Documents/";
        CreateFolder(FolderPath);
     // \\xwebsrv\XRecruitmentNew\CandidateDocuments\370\Documents
        if (fuPic.HasFile)
        {

            string path = System.IO.Path.Combine(FolderPath, System.IO.Path.GetFileName(fuPic.FileName));
            fuPic.SaveAs(path);
          
            
           

        }
    }
    public static void CreateFolder(string FolderPath)
    {
        string folderPath = System.Web.HttpContext.Current.Server.MapPath(FolderPath);
        DirectoryInfo dir = new DirectoryInfo(folderPath);
        if (!dir.Exists)
        {
            Directory.CreateDirectory(folderPath);
        }
    }
}