using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ErrorLog;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class controls_profileheadercontrol : System.Web.UI.UserControl
{
    SecureQueryString oSecureString = null;
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    string candidateCode = "0";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["CC"] != null)
            {
                candidateCode = Session["CC"].ToString();
                GetCandidateProfileData(candidateCode);
            }
            // else
            //Response.Redirect(DomainAddress + "signin.aspx");
        }
        catch (Exception ex)
        {
            ErrorLog.LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, candidateCode);
        }

    }

    protected void logout_Click(object sender, EventArgs e)
    {
        try
        {
            Session.RemoveAll();
            Session.Abandon();
            Session.Clear();
            Response.Redirect(DomainAddress + "signin.aspx", false);
        }
        catch (Exception ex)
        {
            ErrorLog.LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, candidateCode);
        }
    }

    private void GetCandidateProfileData(string candidatecode)
    {
        DataSet objDS = new DataSet();
        using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            c.Open();
            using (SqlCommand command = new SqlCommand("XRec_SelectCandidateProfileData", c))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CandidateCode", candidatecode));
                using (SqlDataAdapter a = new SqlDataAdapter(command))
                {
                    a.Fill(objDS);
                }
            }
        }

        

        //if (Convert.ToInt32(objDS.Tables[0].Rows[0]["Status_Code"]) == Convert.ToInt32(XRecruitmentStatusLibrary.Constants.CandidateLifeCycleStatus.SchedulingdoneTestPending))
        //    ATnG.HRef = "../area/tipsnguides.aspx?var=gtg-test";
        //else if (Convert.ToInt32(objDS.Tables[0].Rows[0]["Status_Code"]) == Convert.ToInt32(XRecruitmentStatusLibrary.Constants.CandidateLifeCycleStatus.SchedulingDoneInterviewPending))
        //    ATnG.HRef = "../area/tipsnguides.aspx?var=gtg-interview";
        //else if (Convert.ToInt32(objDS.Tables[0].Rows[0]["Status_Code"]) == Convert.ToInt32(XRecruitmentStatusLibrary.Constants.CandidateLifeCycleStatus.SchedulingdoneOfferPending))
        //    ATnG.HRef = "../area/tipsnguides.aspx?var=gtg-offer";
        //else
        //    ATnG.HRef = "../area/tipsnguides.aspx";

        if (objDS.Tables[0].Rows[0]["ProfileImage_Path"].ToString() != "" && objDS.Tables[0].Rows[0]["ProfileImage_Path"].ToString() != "0")
        {
            imgProfileImageSmall.ImageUrl = objDS.Tables[0].Rows[0]["ProfileImage_Path"].ToString();
            lblProfileFullName.Text = System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(objDS.Tables[0].Rows[0]["Name"].ToString());
        }
        else
        {
            imgProfileImageSmall.ImageUrl = "../area/SocialMedia/UserImagePath/profile.jpg";
            lblProfileFullName.Text = System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(objDS.Tables[0].Rows[0]["Name"].ToString());

        }
        //return objDS;
    }

    //protected void btnChangePassword_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (!Page.IsValid)
    //            return;

    //        DataSet ds = new DataSet();
    //        ds = ChangeCandidatePassword();

    //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
    //        {
    //            if (ds.Tables[0].Rows[0]["Result"].ToString() != "0")
    //            {
    //                //HttpContext.Current.Response.Redirect(DomainAddress + "/area/area.aspx#myModal_ChangePassword", false);
    //                lblError.Text = ds.Tables[0].Rows[0]["Msg"].ToString();
    //                ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "RefreshParent()", true);

    //                //System.Threading.Thread.Sleep(3000);
    //            }
    //            else
    //            {
    //                // HttpContext.Current.Response.Redirect(DomainAddress + "/area/area.aspx#myModal_ChangePassword", false);
    //                lblError.Text = ds.Tables[0].Rows[0]["Msg"].ToString();
    //                ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "RefreshParent()", true);
    //                //System.Threading.Thread.Sleep(3000);
    //            }
    //        }
    //        else
    //        {

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ErrorLog.LogError.Write(ErrorLog.LogError.AppType.Candidate, "btnChangePassword_Click", ex, candidateCode);
    //    }
    //}

    //public DataSet ChangeCandidatePassword()
    //{
    //    DataSet objDS = new DataSet();
    //    using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
    //    {
    //        c.Open();
    //        try
    //        {
    //            using (SqlCommand command = new SqlCommand("XRec_UpdateCandidatePassword", c))
    //            {
    //                oSecureString = new SecureQueryString();

    //                command.CommandType = CommandType.StoredProcedure;
    //                command.Parameters.Add(new SqlParameter("@Currentpassword", oSecureString.encrypt(txtCurrentPassword.Text.ToString())));
    //                command.Parameters.Add(new SqlParameter("@NewPassword", oSecureString.encrypt(txtNewPassword.Text.ToString())));
    //                command.Parameters.Add(new SqlParameter("@CandidateCode", candidateCode.ToString()));
    //                command.Parameters.Add(new SqlParameter("@UpdatedBy", candidateCode.ToString()));
    //                command.Parameters.Add(new SqlParameter("@UpdationIP ", Request.UserHostAddress.ToString()));
    //                using (SqlDataAdapter a = new SqlDataAdapter(command))
    //                {
    //                    a.Fill(objDS);
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.Candidate, "ChangeCandidatePassword", ex, candidateCode);
    //        }
    //    }
    //    return objDS;
    //}
}