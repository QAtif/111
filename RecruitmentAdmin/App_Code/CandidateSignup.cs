// Decompiled with JetBrains decompiler
// Type: CandidateSignup
// Assembly: App_Code, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CCFCF570-EAC0-4D2F-8EF3-866C275AB6B3
// Assembly location: C:\Users\atifhussain\Desktop\Dlls\Axact Recruitment\App_Code.dll

using System.IO;
using System.Web;
using System.Web.UI.WebControls;

public static class CandidateSignup
{
  public static void CreateFolder(string FolderPath)
  {
    string path = HttpContext.Current.Server.MapPath(FolderPath);
    if (new DirectoryInfo(path).Exists)
      return;
    Directory.CreateDirectory(path);
  }

  public static string FileBrowse(FileUpload Source, string FolderPath, string FileName)
  {
    string extension = Path.GetExtension(Source.PostedFile.FileName);
    string str1 = FileName + extension;
    string str2 = HttpContext.Current.Server.MapPath(FolderPath);
    if (str1 != "" && Source.PostedFile.ContentLength != 0)
    {
      string filename = str2 + "\\" + str1;
      Source.PostedFile.SaveAs(filename);
    }
    return str1;
  }

  public static void FileResponse(string filename, string FolderPath)
  {
    FileInfo fileInfo = new FileInfo(HttpContext.Current.Server.MapPath(FolderPath + "/" + filename));
    if (!fileInfo.Exists)
      return;
    BinaryReader binaryReader = new BinaryReader((Stream) fileInfo.OpenRead());
    HttpContext.Current.Response.ClearContent();
    HttpContext.Current.Response.Clear();
    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
    HttpContext.Current.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
    HttpContext.Current.Response.ContentType = "application/octet-stream";
    byte[] buffer = binaryReader.ReadBytes((int) fileInfo.Length);
    binaryReader.Close();
    HttpContext.Current.Response.BinaryWrite(buffer);
  }

  public static bool validatefile(FileUpload myFile)
  {
    int num = 0;
    if (myFile.HasFile && myFile.FileBytes.Length >= 2097152)
      ++num;
    return num <= 0;
  }
}
