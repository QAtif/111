using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Collections;
using System.IO;
using ASP;
using System.Web.Profile;
using System.Web.SessionState;
using XRecruitmentStatusLibrary;



public partial class Test : System.Web.UI.Page
{
    

    public string FolderPath = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + "10001/Personal/";
        ADL.HRef = FolderPath + "NIC.jpg";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!FileUpload1.HasFile)
            return;
        GeneralMethods.FileBrowse(FileUpload1, FolderPath, "NIC");
        ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Saved Successfully!')", true);
    }

    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        FolderPath = HttpContext.Current.Server.MapPath(FolderPath);
        GeneralMethods.FileResponse("NIC.jpg", FolderPath);
    }


    //protected void Page_Load(object sender, EventArgs e)
    //{

    //    System.Diagnostics.Debugger.Launch();
    //    CreateFolder(folderPath);
    //}

    //public static void CreateFolder(string FolderPath)
    //{
    //    DirectoryInfo dir = new DirectoryInfo(FolderPath);
    //    if (!dir.Exists)
    //    {
    //        Directory.CreateDirectory(FolderPath);
    //    }
    //}
    //protected void btnSave_Click(object sender, EventArgs e)
    //{
    //    if (FileUpload1.HasFile)
    //    {
    //        FileUpload1.SaveAs(folderPath + "NIC" + System.IO.Path.GetExtension(FileUpload1.FileName));

    //    }
    //}

    //protected void CallMe(object sender, EventArgs e)
    //{
    //    FileResponse("NIC.jpg", "/RecruitmentAssessment/RecruitmentDocuments/CandidateDocuments/1/Personal/");
    //}

    //public void FileResponse(string filename, string FolderPath)
    //{
    //    string path = System.Web.HttpContext.Current.Server.MapPath(FolderPath + "/" + filename);

    //    System.IO.FileInfo file = new System.IO.FileInfo(path); //-- if the file exists 
    //    if (file.Exists) //set appropriate headers  
    //    {
    //        BinaryReader fs = new BinaryReader(file.OpenRead());
    //        HttpContext.Current.Response.ClearContent();
    //        HttpContext.Current.Response.Clear();
    //        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
    //        HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
    //        HttpContext.Current.Response.ContentType = "application/octet-stream";
    //        byte[] bite = fs.ReadBytes((int)file.Length);
    //        fs.Close();
    //        HttpContext.Current.Response.BinaryWrite(bite);
    //    }
    //}


}