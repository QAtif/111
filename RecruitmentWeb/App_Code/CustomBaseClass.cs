using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ErrorLog;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class CustomBaseClass : System.Web.UI.Page
{
    #region Page Variables
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    #endregion Page Variables

    protected int CandidateCode = -1;
    protected int UserTypeCode = 2;
    protected int AdminUserCode = -1;
    public CustomBaseClass()
    {

    }
    public int CANDIDATE
    {
        get { return CandidateCode; }
        set { CandidateCode = value; }
    }

    public int USERTYPE
    {
        get { return UserTypeCode; }
        set { UserTypeCode = value; }
    }

    public int ADMINUSERCODE
    {
        get { return AdminUserCode; }
        set { AdminUserCode = value; }
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        try
        {
            //Session["CC"] = "354";
            if (Session["CC"] == null)
                base.OnInit(e);

            if (Session["CC"] != null)
            {
                CANDIDATE = Convert.ToInt32(Session["CC"].ToString());
                if (Session["Hasverified"] == null)
                {
                    // Commented by Sheikh Haris on 03-Dec-2013 
                    //Verification check Not Required here
                  //  ValidatePhoneVerification();
                }

                if (Session["UserTypeCode"] != null)
                {
                    USERTYPE = Convert.ToInt32(Session["UserTypeCode"].ToString());
                }

                if (Session["AdminUserCode"] != null)
                {
                    ADMINUSERCODE = Convert.ToInt32(Session["AdminUserCode"].ToString());
                }
            }
            else
            {
                Response.Redirect(DomainAddress + "SignIn.aspx");
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "a", "alert('OOPS !!!  Something Went Wrong Kindly Login Again')", true);
            ErrorLog.LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Session["CC"].ToString());
            Response.Redirect(DomainAddress + "SignIn.aspx");
        }
    }


    private void ValidatePhoneVerification()
    {
        DataSet DSSigin = new DataSet();
        DSSigin = CandidateAutomaticSignIn();

        if (DSSigin != null && DSSigin.Tables != null && DSSigin.Tables[0].Rows.Count > 0)
        {
            if (DSSigin.Tables[0].Rows[0]["hasverified"].ToString() != "0" && DSSigin.Tables[0].Rows[0]["CandidateCode"].ToString() != "0")
                Session["Hasverified"] = "1";
            else
            {
                string CurrentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                if (!CurrentUrl.Contains("verification.aspx"))
                    HttpContext.Current.Response.Redirect(DomainAddress + "verification.aspx", false);
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect(DomainAddress + "Signin.aspx", false);
        }
    }

    private DataSet CandidateAutomaticSignIn()
    {
        DataSet objDS = new DataSet();
        using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            c.Open();
            using (SqlCommand command = new SqlCommand("XRec_CandidateAutomaticSignIn", c))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Candidate_Code", CANDIDATE.ToString()));
                using (SqlDataAdapter a = new SqlDataAdapter(command))
                {
                    a.Fill(objDS);
                }
            }
        }
        return objDS;
    }
}