using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;

public partial class testPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lblFileName_Click(object sender, EventArgs e)
    {
        FileResponse(Path.GetFileName("/RecruitmentDocuments/CandidateDocuments/249706/Personal/NIC.jpg"), Path.GetDirectoryName("/RecruitmentDocuments/CandidateDocuments/249706/Personal/NIC.jpg"));
    }
    public void FileResponse(string filename, string FolderPath)
    {
        string path = string.Empty;

        if (IsValidPath(FolderPath))
            path = FolderPath + "/" + filename;
        else
            path = System.Web.HttpContext.Current.Server.MapPath(FolderPath + "/" + filename);

        System.IO.FileInfo file = new System.IO.FileInfo(path); //-- if the file exists 
        if (file.Exists) //set appropriate headers  
        {
            BinaryReader fs = new BinaryReader(file.OpenRead());
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            byte[] bite = fs.ReadBytes((int)file.Length);
            fs.Close();
            HttpContext.Current.Response.BinaryWrite(bite);
        }
    }
    public static bool IsValidPath(string path)
    {
        Regex regex = new Regex(@"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.]+)\\(?:[\w]+\\)*");
        return regex.IsMatch(path);
    }
}