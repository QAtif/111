<%@ WebHandler Language="C#" Class="getassistancehandler" %>

using System;
using System.Web;

public class getassistancehandler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        HttpRequest request = context.Request;
        HttpResponse response = context.Response;
        string GetAssistanceCode = (request.QueryString["gc"] == null ? "" : request.QueryString["gc"].ToString());
        int CandidateCode = Convert.ToInt32(request.QueryString["cc"] == null ? "0" : request.QueryString["cc"].ToString());

        context.Response.ContentType = "text/plain";
        context.Response.Write(getAssistanceHandler.GetAssistance(GetAssistanceCode, CandidateCode));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}