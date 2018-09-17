using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;
using ErrorLog;
using XRecruitmentStatusLibrary;

public partial class SignIn : Page
{
    #region Events
    SecureQueryString objSecureQueryString = null;
    int TestCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
            if (!IsPostBack)
            {
                //Response.Cookies["CC"].Expires = DateTime.Now.AddDays(-5);
                //Response.Cookies["TC"].Expires = DateTime.Now.AddDays(-5);
                //Response.Cookies.Remove("CC");
                //Response.Cookies.Remove("TC");
                //Session.Abandon();
                //Response.Cookies.Clear();
                RemoveCookie("CC");
                RemoveCookie("TC");
                //Session.Abandon();
                //Response.Cookies.Clear();
            }


           // if (!IsPostBack)
            //{
                //Session.Abandon();
                //if (Request.Cookies["CC"] != null && Request.Cookies["TC"] != null)
                //{
                //    if (Response.Cookies["TC"].Value !=null)
                //    { 
                //    TestCode = int.Parse(Response.Cookies["TC"].Value.ToString());
                //    HttpContext.Current.Response.Redirect("about.aspx?tid=" + TestCode, false);
                //    }
                //}
                //else
                //    BindPhoneCodes();
            //}
        }
        catch (Exception ex)
        {
            ErrorLog.LogError.Write(LogError.AppType.RecruitmentAssessment, ex.Message + " " + ex.StackTrace, ex, "");
        }
    }
    public static void RemoveCookie(string key)
    {
        //get cookies value
        HttpCookie cookie = null;
        if (HttpContext.Current.Request.Cookies[key] != null)
        {
            cookie = HttpContext.Current.Request.Cookies[key];

            //set its expiry date to earlier date
            cookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
           
        }


    }

    public static void CreateCookie(string key,string Value)
    {
      
        if (HttpContext.Current.Request.Cookies[key] != null)
        {
           // RemoveCookie(key);
        }
        else
        {
            HttpCookie NewCookie = new HttpCookie(key);
            NewCookie.Value = Value;
            NewCookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(NewCookie);       

        }


    }


    protected void btnSignIn_Click(object sender, ImageClickEventArgs e)
    {
        int studentCode=0;
        XRecBase objXRecBase = new XRecBase();
        try
        {
            
            if (!Page.IsValid)
                return;

            DataSet ds = new DataSet();
            ds = CandidateSignIn();

            if (ds != null && ds.Tables.Count >0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // Creating Cookies
                    CreateCookie("CC", ds.Tables[0].Rows[0]["CandidateCode"].ToString());
                    CreateCookie("TC", ds.Tables[0].Rows[0]["TestCode"].ToString());

                    //Response.Cookies["CC"].Value = ds.Tables[0].Rows[0]["CandidateCode"].ToString();
                    //Response.Cookies["CC"].Expires = DateTime.Now.AddHours(6);
                    //Response.Cookies["TC"].Value = ds.Tables[0].Rows[0]["TestCode"].ToString();
                    //Response.Cookies["TC"].Expires = DateTime.Now.AddHours(6);

                    studentCode = int.Parse(ds.Tables[0].Rows[0]["CandidateCode"].ToString());
                    TestCode = int.Parse(ds.Tables[0].Rows[0]["TestCode"].ToString());

                    //This changed to Cookies in Above Code
                    //Session["CC"] = ds.Tables[0].Rows[0]["CandidateCode"].ToString();                   
                    //Session["TC"] = int.Parse(ds.Tables[0].Rows[0]["TestCode"].ToString());
                    

                    objXRecBase.UserID = int.Parse(Response.Cookies["CC"].Value.ToString());
                    //HttpContext.Current.Response.Redirect("/assessment/CandidateTest/CandidateTest.aspx?tid=" + TestCode, false);

                    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);
                    try
                    {
                      //  connection.Open();
                        //StatusManagement.MarkLifeCycleStatus(connection, objXRecBase.UserID, Constants.ModuleCode.LifeCycleStatus,
                        //                     Constants.CandidateStatus.TestReportingdoneTourPending, Request.UserHostAddress.ToString(), objXRecBase.UserID);

                       // StatusManagement.MarkLifeCycleStatus(connection, objXRecBase.UserID, Constants.ModuleCode.LifeCycleStatus,
                                         //    Constants.CandidateLifeCycleStatus.TestReportingdoneTourPending, Request.UserHostAddress.ToString(), objXRecBase.UserID);
                    }
                    catch (Exception ex)
                    {
                        //throw exp1;
                        ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAssessment, ex.StackTrace, ex, objXRecBase.UserID.ToString());
                    }
                    finally
                    {
                        connection.Close();
                    }

                    //CookieCreation(TestCode,studentCode);
                    HttpContext.Current.Response.Redirect("about.aspx?tid=" + TestCode, false);


                }
            }
            else
            {
                lblMsg.Text = "Your are not Authorize to Proceed.";
            }
        }
        catch (Exception ex)
        {
            ErrorLog.LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "");
        }
    }
    #endregion

    #region Methods
    //protected void CookieCreation(int TestCode,int studentCode)
    //{
    //    Response.Cookies["Assessment"]["StudentCode"] = studentCode.ToString();
    //    Response.Cookies["Assessment"]["TestCode"] = TestCode.ToString();
    //    Response.Cookies["Assessment"].Expires = DateTime.Now.AddDays(1);
    //}
    public DataSet CandidateSignIn()
    {
        objSecureQueryString = new SecureQueryString();
        DataSet objDS = new DataSet();
        using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ToString()))
        {
            c.Open();
            try
            {
                using (SqlCommand command = new SqlCommand("XRec_CandidateSignInTest", c))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@EmailOrMob", txtCell.Text.Trim()));
                    command.Parameters.Add(new SqlParameter("@Password", objSecureQueryString.encrypt(txtPassword.Text)));
                    command.Parameters.Add(new SqlParameter("@RefNo", txtPassword.Text.Trim()));
                    using (SqlDataAdapter a = new SqlDataAdapter(command))
                    {
                        a.Fill(objDS);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(LogError.AppType.RecruitmentAssessment, ex.Message + " " + ex.StackTrace, ex, "");
            }
        }
        return objDS;
    }
    #endregion

}