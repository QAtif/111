using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class signup_HRDPSignUp : System.Web.UI.Page
{
    SqlConnection DBConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LiveConnectionString"].ConnectionString);
    int userID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.QueryString["sutc"] != null)
        //{
        //    signUpThrough = Convert.ToInt32(Request.QueryString["sutc"]);
        //}

        //if (Session["UserID"] != null)
        //    userID = Convert.ToInt32(Session["UserID"]);
        //else if (HttpContext.Current.Request.Cookies["UserID"] != null)
        //{
        //    userID = Convert.ToInt32(HttpContext.Current.Request.Cookies["UserID"].Value);            
        //}
        SignUp();

    }
    protected void SignUp()
    {
        try
        {
            SqlCommand command;
            command = new SqlCommand();
            command.Connection = DBConnection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Rec_Insert_SignupLead_HRDP";
            command.Parameters.Add("@Company_Name", SqlDbType.VarChar).Value = Request["cmpname"].ToString();
            command.Parameters.Add("@Industry_Code", SqlDbType.Int).Value = int.Parse(Request["ic"].ToString());
            command.Parameters.Add("@Industry_Name", SqlDbType.VarChar).Value = Request["iname"].ToString();
            command.Parameters.Add("@Name", SqlDbType.VarChar).Value = Request["cname"].ToString();
            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = Request["em"].ToString();
            //command.Parameters.Add("@County_Code", SqlDbType.Int).Value = ddlCountryMobile.SelectedValue;
            //command.Parameters.Add("@Phone_Code", SqlDbType.VarChar).Value = txtphonecode.Text;
            command.Parameters.Add("@PhoneNo", SqlDbType.VarChar).Value = Request["pno"].ToString();
            command.Parameters.Add("@URL", SqlDbType.VarChar).Value = Request["ru"].ToString();
            command.Parameters.Add("@Referer_URL", SqlDbType.VarChar).Value = Request["ru"].ToString();
            command.Parameters.Add("@Updated_By", SqlDbType.Int).Value = userID;
            command.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = Request.UserHostAddress;
            command.Parameters.Add("@Designation_Code", SqlDbType.Int).Value = int.Parse(Request["dc"].ToString());
            command.Parameters.Add("@Designation", SqlDbType.VarChar).Value = Request["dn"].ToString();
            command.Parameters.Add("@SignUpType_Code", SqlDbType.Int).Value = (int)SignUpTypes.HRDP;
            command.Parameters.Add("@SignUpType_Name", SqlDbType.VarChar).Value = SignUpTypes.HRDP.ToString();
            command.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;


            DBConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            HttpCookie userCookie = new HttpCookie("UserID", ds.Tables[0].Rows[0]["UserID"].ToString());
            userCookie.Expires = DateTime.Now.AddDays(180);
            Response.SetCookie(userCookie);

            Session.Add("UserID", ds.Tables[0].Rows[0]["UserID"].ToString());

            //Response.Redirect(Request["tpth"].ToString() + "?cname=" + Request["cname"].ToString());
        }
        catch (Exception ex)
        {
            //ErrorLogging.LogError.Write(ErrorLogging.AppType.Portal, ex.Message + " " + ex.StackTrace, ex, "");
        }
        finally
        {
            if (DBConnection.State != ConnectionState.Closed)
                DBConnection.Close();

            Response.Redirect(Request["tpth"].ToString() + "?cname=" + Request["cname"].ToString() + "&fp=" + Request["fp"].ToString());

            //ClientScript.RegisterStartupScript(this.GetType(), "exampleScript",
            //"<script language =javascript>window.parent.location=document.getElementById('hdnRedirect').value;</script>");
        }
    }

    public enum SignUpTypes
    {
        Product = 1,
        Service = 2,
        Platform = 3,
        SedAxact = 4,
        About = 5,
        Partner = 6,
        PreSignUp = 7,
        BusinessEmpowerment = 9,
        HRDP = 10,

    }
}