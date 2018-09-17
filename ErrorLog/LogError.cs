using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ErrorLog
{
    public class LogError
    {

        public enum AppType
        {
            Candidate = 1,
            RecruitmentModule = 2,
            StatusManagement = 3,
            RecruitmentAdmin = 4,
            PortalCreationService = 5,
            RecruitmentAssessment = 6,
            CRMIntegrationService=7
           

        }

        public static bool Write(AppType appID, string errorDetails, Exception ex, string userID)
        {
            int intSuccess = 0;
            intSuccess = WriteToDB(appID.ToString(), errorDetails, ex, userID);           

            if (intSuccess != 0)
                return true;
            else
                return false;
        }

        private static int WriteToDB(string _category, string _errMsg, Exception ex, string userID)
        {
            /* Comprehensive Error Logging*/
            int intStatus = 0;
            if (string.IsNullOrEmpty(userID))
                userID = "0";
            //if (HttpContext.Current != null && HttpContext.Current.Request != null)
            //{
            //    _errMsg = "Request from IP: " + HttpContext.Current.Request.UserHostAddress + ". " + _errMsg;
            //}

            _errMsg = _errMsg + " Error on Line: " + Get_strStackTrace(ex);
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ConnectionString);
            try
            {
                string requestPath = string.Empty;
                System.Collections.Specialized.NameValueCollection requestQueryString = null;
                string sessionVariables = string.Empty;
                string queryString = string.Empty;
                string referrer = string.Empty;
                string browserDetails = string.Empty;

                if (HttpContext.Current != null && HttpContext.Current.Request != null)
                {
                    requestPath = System.Web.HttpContext.Current.Request.Path != null ? System.Web.HttpContext.Current.Request.Path : string.Empty;
                    requestQueryString = System.Web.HttpContext.Current.Request.QueryString != null ? System.Web.HttpContext.Current.Request.QueryString : null;
                    sessionVariables = GetSessionKeys();
                    queryString = string.Empty;
                    if (requestQueryString != null)
                        queryString = requestQueryString.ToString();
                    referrer = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_REFERER"] != null ? System.Web.HttpContext.Current.Request.ServerVariables["HTTP_REFERER"].ToString() : string.Empty;

                    _errMsg = "Request from IP: " + HttpContext.Current.Request.UserHostAddress + ". " + _errMsg;

                    browserDetails = "Type: " + HttpContext.Current.Request.Browser.Browser
                    + " | Version: " + HttpContext.Current.Request.Browser.Version
                    + " | JavaScript: " + HttpContext.Current.Request.Browser.EcmaScriptVersion.ToString();
                }

                //_errMsg = _errMsg + " Error on Line: ";

                SqlCommand command;
                command = new SqlCommand();
                command.Connection = sqlCon;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ErrorLogWriting";
                command.Parameters.Add("@ErrorCategory", SqlDbType.VarChar, 50).Value = _category;
                command.Parameters.Add("@ErrorMessage", SqlDbType.Text).Value = _errMsg;
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
                command.Parameters.Add("@Request_Path", SqlDbType.VarChar).Value = requestPath;
                command.Parameters.Add("@Request_QueryString", SqlDbType.VarChar).Value = queryString;
                command.Parameters.Add("@Referer", SqlDbType.VarChar).Value = referrer;
                command.Parameters.Add("@Session_Variables", SqlDbType.VarChar).Value = sessionVariables;
                command.Parameters.Add("@Browser_Details", SqlDbType.VarChar).Value = browserDetails;

                sqlCon.Open();
                intStatus = command.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                sqlCon.Close();
            }
            return intStatus;
        }



        private static string Get_strStackTrace(Exception ex)
        {
            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
            string err = string.Empty;

            for (int i = 0; i < trace.FrameCount - 1; i++)
            {
                System.Diagnostics.StackFrame sf = trace.GetFrame(i);
                if (sf.GetFileName() != "" && sf.GetFileName() != null)
                {
                    err = " Method Name: "
                        + sf.GetMethod().Name + " File Name: "
                        + sf.GetFileName() + " Line: "
                        + sf.GetFileLineNumber() + " Column : "
                        + sf.GetFileColumnNumber();
                }
            }
            return err;
        }

        private static string GetSessionKeys()
        {
            string sessionVariables = string.Empty;
            foreach (string key in System.Web.HttpContext.Current.Session.Keys)
            {
                if (System.Web.HttpContext.Current.Session.Contents[key] == null)
                {
                    sessionVariables += key + "=null;";
                }
                else
                {
                    sessionVariables += key + "=" + System.Web.HttpContext.Current.Session.Contents[key].ToString() + ";";
                }
            }
            return sessionVariables;
        }

        public static void Write(AppType recruitmentAdmin, string v, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}

#region SQL Things

/*



-- ********************************************************************
-- ERROR LOG TABLE CREATION 
-- ********************************************************************

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ErrorLog](
	[AutoId] [int] IDENTITY(1,1) NOT NULL,
	[ErrorCategory] [varchar](50) NULL,
	[ErrorStackTrace] [text] NULL,
	[UserID] [int] NULL,
	[Request_Path] [varchar](500) NULL,
	[Request_QueryString] [varchar](1000) NULL,
	[Referer] [varchar](500) NULL,
	[Session_Variables] [varchar](1000) NULL,
	[Browser_Details] [varchar](1000) NULL,
	[Created_Date] [datetime] DEFAULT(getdate()),
	[Last_Update_Date] [datetime] DEFAULT(getdate()),
	[Is_Active] [bit] NULL  DEFAULT(1)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

-- ********************************************************************
-- STORED PROCEDURE CREATION
-- ********************************************************************


-- =============================================                        
-- Author:   Sh.M.Haris              
-- Create date: 05 January 2013
-- =============================================                        
CREATE PROCEDURE [dbo].[ErrorLogWriting]                  
(                        
 @ErrorCategory VARCHAR(50),                  
 @ErrorMessage TEXT  ,                
 @UserID int = null,            
 @Request_Path varchar (500) = null,            
 @Request_QueryString varchar (1000)= null,            
 @Referer varchar  (500)= null,            
 @Session_Variables varchar (1000)  = null  ,     
 @Browser_Details      varchar (1000)  = null       
)                        
AS                        
BEGIN                        
SET NOCOUNT ON;                        
INSERT INTO [ErrorLog]                        
(                        
ErrorCategory,                  
ErrorStackTrace ,                
UserID,            
Request_Path,            
Request_QueryString,            
Referer,            
Session_Variables      ,    
Browser_Details,  
Created_Date,    
Last_Update_Date,    
Is_Active         
)                        
Values                        
(                        
@ErrorCategory,                  
@ErrorMessage ,                
@UserID,               
@Request_Path,            
@Request_QueryString,            
@Referer,            
@Session_Variables,    
@Browser_Details,  
getdate(),    
getdate(),    
1    
)                        
                      
END 





*/

#endregion


