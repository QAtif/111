<%@ WebHandler Language="C#" Class="verificationhandlerashx" %>

using System;
using System.Web;

public class verificationhandlerashx : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        HttpRequest request = context.Request;
        HttpResponse response = context.Response;
        string verificationCode = (request.QueryString["vc"] == null ? "" : request.QueryString["vc"].ToString());
        int CandidateCode = Convert.ToInt32(request.QueryString["cc"] == null ? "0" : request.QueryString["cc"].ToString());

        context.Response.ContentType = "text/plain";
        context.Response.Write(Handler.VerifyEmail(verificationCode, CandidateCode));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}