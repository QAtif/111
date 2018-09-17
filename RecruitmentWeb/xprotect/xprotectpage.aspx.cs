using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using ImpactWorks.FBGraph.Connector;
using ImpactWorks.FBGraph.Core;
using ImpactWorks.FBGraph.Interfaces;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;


public partial class xprotect_xprotectpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Write("THANK YOU FOR CHOOSING OUR PRODUCT");
        Response.Write("<br/>");
        Response.Write("<br/>");
        if (Request.Params["signed_request"] != null)
        {
            string payload = Request.Params["signed_request"].Split('.')[1];
            var encoding = new UTF8Encoding();
            var decodedJson = payload.Replace("=", string.Empty).Replace('-', '+').Replace('_', '/');
            var base64JsonArray = Convert.FromBase64String(decodedJson.PadRight(decodedJson.Length + (4 - decodedJson.Length % 4) % 4, '='));
            var json = encoding.GetString(base64JsonArray);
            var o = JObject.Parse(json);
            var lPid = Convert.ToString(o.SelectToken("page.id")).Replace("\"", "");
            var lLiked = Convert.ToString(o.SelectToken("page.liked")).Replace("\"", "");
            var lUserId = Convert.ToString(o.SelectToken("user_id")).Replace("\"", "");

            if (Convert.ToBoolean(lLiked))
            {

                Response.Write("THANK YOU FOR LIKING");

                //Response.AddHeader("Refresh", "1; url=http://xwebsrvde:705/products/protect/thanks.asp");


                //ScriptManager.RegisterClientScriptBlock(this, GetType(), "close", "window.open('http://www.axact.com/xprotect/axact-protect.exe');", true);

                //FbPermissionsAndFetchData();

                try
                {
                    // FileResponse(Path.GetFileName(Server.MapPath(ConfigurationManager.AppSettings["XProtectPath"])), Path.GetDirectoryName(Server.MapPath(ConfigurationManager.AppSettings["XProtectPath"])));

                    Response.Write("<br/>");
                    //Response.Write(getDigitalSignature(Path.GetFileName(Server.MapPath(ConfigurationManager.AppSettings["XProtectPath"])), Path.GetDirectoryName(Server.MapPath(ConfigurationManager.AppSettings["XProtectPath"]))));


                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }



            }
            else
                Response.Write("PLEASE LIKE THE PAGE FIRST");

        }

    }
    public static void getDigitalSignature2(string fileName, string FolderPath)
    {

        string path = string.Empty;

        if (IsValidPath(FolderPath))
            path = FolderPath + "/" + fileName;
        else
            path = System.Web.HttpContext.Current.Server.MapPath(FolderPath + "/" + fileName);

        System.IO.FileInfo thisfile = new System.IO.FileInfo(path); //-- if the file exists 
        BinaryReader fs = new BinaryReader(thisfile.OpenRead());
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
        HttpContext.Current.Response.AddHeader("Content-Length", thisfile.Length.ToString());
        HttpContext.Current.Response.ContentType = "application/octet-stream";
        byte[] bite = fs.ReadBytes((int)thisfile.Length);

        fs.Close();
        HttpContext.Current.Response.BinaryWrite(bite);




    }
    public static string getDigitalSignature(string fileName, string FolderPath)
    {
        string key = "NetXcl0Ud0910 ";
        string result;

        string path = string.Empty;

        if (IsValidPath(FolderPath))
            path = FolderPath + "/" + fileName;
        else
            path = System.Web.HttpContext.Current.Server.MapPath(FolderPath + "/" + fileName);


        DSACryptoServiceProvider MySigner = new DSACryptoServiceProvider();

        FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
        BinaryReader reader = new BinaryReader(file);
        byte[] data = reader.ReadBytes((int)file.Length);

        byte[] signature = MySigner.SignData(data);

        string publicKey = MySigner.ToXmlString(false);
        Console.WriteLine("Signature: " + Convert.ToBase64String(signature));
        reader.Close();
        file.Close();

        DSACryptoServiceProvider verifier = new DSACryptoServiceProvider();
        verifier.FromXmlString(publicKey);
        FileStream file2 = new FileStream(path, FileMode.Open, FileAccess.Read);
        BinaryReader reader2 = new BinaryReader(file2);
        byte[] data2 = reader2.ReadBytes((int)file2.Length);

        if (verifier.VerifyData(data2, signature))
        {

            System.IO.FileInfo thisfile = new System.IO.FileInfo(path); //-- if the file exists 
            BinaryReader fs = new BinaryReader(thisfile.OpenRead());
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            HttpContext.Current.Response.AddHeader("Content-Length", thisfile.Length.ToString());
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            byte[] bite = fs.ReadBytes((int)thisfile.Length);

            fs.Close();
            HttpContext.Current.Response.BinaryWrite(bite);
            /*
            using (var f = File.Open(path, FileMode.Append))
            {
                f.Write(signature, 0, signature.Length);

                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                HttpContext.Current.Response.AddHeader("Content-Length", thisfile.Length.ToString());
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                BinaryReader fs = new BinaryReader(f);
                byte[] bite = fs.ReadBytes((int)thisfile.Length);
                fs.Close();
                HttpContext.Current.Response.BinaryWrite(bite);

            }
            */

            //X509Certificate certificate = X509Certificate.CreateFromSignedFile(path);
            //HttpContext.Current.Request.ClientCertificate.Add(certificate);




            // result = theSigner.;


            //byte[] signature = MySigner.SignData(data);  
            result = "Signature";
        }
        else
            result = "Signature is not verified";

        reader2.Close();
        file2.Close();

        return result;
    }

    public static void FileResponse(string filename, string FolderPath)
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
            //HttpContext.Current.Response.ClearContent();
            //HttpContext.Current.Response.Clear();
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
        Regex r = new Regex(@"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.]+)\\(?:[\w]+\\)*");
        return r.IsMatch(path);
    }
}