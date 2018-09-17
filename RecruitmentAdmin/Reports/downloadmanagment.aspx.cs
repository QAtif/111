

using ASP;
using DbErrorLog;
using ErrorLog;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections;
using System.IO;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public partial class Reports_downloadmanagment : Page, IRequiresSessionState
{

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public static void ZipFiles(string inputFolderPath, string outputPathAndFile, string password)
    {
        string path1 = inputFolderPath + outputPathAndFile;
        ZipOutputStream zipOutputStream = new ZipOutputStream((Stream)File.Create(path1));
        try
        {
            ArrayList fileList = GenerateFileList(inputFolderPath);
            int count = Directory.GetParent(inputFolderPath).ToString().Length + 1;
            if (password != null && password != string.Empty)
                zipOutputStream.Password = password;
            zipOutputStream.SetLevel(9);
            foreach (string path2 in fileList)
            {
                ZipEntry entry = new ZipEntry(path2.Remove(0, count));
                zipOutputStream.PutNextEntry(entry);
                if (!path2.EndsWith("/"))
                {
                    FileStream fileStream = File.OpenRead(path2);
                    byte[] buffer = new byte[fileStream.Length];
                    fileStream.Read(buffer, 0, buffer.Length);
                    zipOutputStream.Write(buffer, 0, buffer.Length);
                }
            }
            zipOutputStream.Finish();
            zipOutputStream.Close();
        }
        catch (Exception ex)
        {
            DbErrorLog.LogError.Write(AppType.MHS, ex.Message + path1 + " " + ex.StackTrace, ex);
        }
    }

    private static ArrayList GenerateFileList(string Dir)
    {
        ArrayList arrayList = new ArrayList();
        bool flag = true;
        foreach (string file in Directory.GetFiles(Dir))
        {
            arrayList.Add(file);
            flag = false;
        }
        if (flag && Directory.GetDirectories(Dir).Length == 0)
            arrayList.Add((Dir + "/"));
        foreach (string directory in Directory.GetDirectories(Dir))
        {
            foreach (object file in GenerateFileList(directory))
                arrayList.Add(file);
        }
        return arrayList;
    }

    public static void UnZipFiles(string zipPathAndFile, string outputFolder, string password, bool deleteZipFile)
    {
        ZipInputStream zipInputStream = new ZipInputStream((Stream)File.OpenRead(zipPathAndFile));
        if (password != null && password != string.Empty)
            zipInputStream.Password = password;
        string empty = string.Empty;
        ZipEntry nextEntry;
        while ((nextEntry = zipInputStream.GetNextEntry()) != null)
        {
            string path1 = outputFolder;
            string fileName = Path.GetFileName(nextEntry.Name);
            if (path1 != "")
                Directory.CreateDirectory(path1);
            if (fileName != string.Empty && nextEntry.Name.IndexOf(".ini") < 0)
            {
                string path2 = (path1 + "\\" + nextEntry.Name).Replace("\\ ", "\\");
                string directoryName = Path.GetDirectoryName(path2);
                if (!Directory.Exists(directoryName))
                    Directory.CreateDirectory(directoryName);
                FileStream fileStream = File.Create(path2);
                byte[] buffer = new byte[2048];
                while (true)
                {
                    int count = zipInputStream.Read(buffer, 0, buffer.Length);
                    if (count > 0)
                        fileStream.Write(buffer, 0, count);
                    else
                        break;
                }
                fileStream.Close();
            }
        }
        zipInputStream.Close();
        if (!deleteZipFile)
            return;
        File.Delete(zipPathAndFile);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string outputPathAndFile = "Downloadfolder_" + DateTime.Now.Second + ".zap";
            if (chkFolder.Checked)
            {
                if (Directory.Exists(Server.MapPath(txtfilepath.Text)))
                {
                    ZipFiles(Server.MapPath(txtfilepath.Text), outputPathAndFile, "");
                    if (File.Exists(Server.MapPath(txtfilepath.Text + outputPathAndFile)))
                    {
                        FileInfo fileInfo = new FileInfo(Server.MapPath(txtfilepath.Text + outputPathAndFile));
                        BinaryReader binaryReader = new BinaryReader((Stream)fileInfo.OpenRead());
                        try
                        {
                            Response.ClearContent();
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
                            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                            Response.ContentType = "application/octet-stream";
                            Response.BinaryWrite(binaryReader.ReadBytes((int)fileInfo.Length));
                            Response.Flush();
                            Response.End();
                        }
                        catch (Exception ex)
                        {
                            DbErrorLog.LogError.Write(AppType.MHS, ex.Message + " " + ex.StackTrace, ex);
                        }
                        finally
                        {
                            binaryReader.Close();
                            fileInfo.Delete();
                        }
                    }
                    else
                        spnError.Style.Add("display", "inline");
                }
                else
                    spnError.Style.Add("display", "inline");
            }
            else if (File.Exists(Server.MapPath(txtfilepath.Text)))
            {
                FileInfo fileInfo = new FileInfo(Server.MapPath(txtfilepath.Text));
                BinaryReader binaryReader = new BinaryReader((Stream)fileInfo.OpenRead());
                try
                {
                    Response.ClearContent();
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
                    Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                    Response.ContentType = "application/octet-stream";
                    Response.BinaryWrite(binaryReader.ReadBytes((int)fileInfo.Length));
                    Response.Flush();
                    Response.End();
                }
                catch (Exception ex)
                {
                    DbErrorLog.LogError.Write(AppType.MHS, ex.Message + " " + ex.StackTrace, ex);
                }
                finally
                {
                    binaryReader.Close();
                }
            }
            else
                spnError.Style.Add("display", "inline");
        }
        catch (Exception ex)
        {
            DbErrorLog.LogError.Write(AppType.MHS, ex.Message + " " + ex.StackTrace, ex);
        }
    }
}