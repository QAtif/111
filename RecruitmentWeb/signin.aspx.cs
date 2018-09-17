using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using ErrorLog;
using System.Data.SqlClient;

public partial class signin : Page
{
    #region Page Variables
    SecureQueryString oSecureString = null;
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    #endregion Page Variables

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack || Session["CC"] == null)
                return;
            HttpContext.Current.Response.Redirect("area/area.aspx", false);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "");
        }
    }

    protected void btnSignIn_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (!Page.IsValid)
                return;
            DataSet dataSet1 = new DataSet();
            DataSet dataSet2 = CandidateSignIn();
            if (dataSet2 != null && dataSet2.Tables != null && (dataSet2.Tables.Count > 0 && dataSet2.Tables[0].Rows.Count > 0))
            {
                Convert.ToBoolean(dataSet2.Tables[0].Rows[0]["is_EmailVerified"]);
                Convert.ToBoolean(dataSet2.Tables[0].Rows[0]["is_PhoneVerified"]);
                Convert.ToBoolean(dataSet2.Tables[0].Rows[0]["Is_Migrated"]);
                Session["CC"] = dataSet2.Tables[0].Rows[0]["Candidate_Code"].ToString();
                Response.Redirect(DomainAddress + "area/area.aspx", false);
            }
            else
            {
                lblError.Text = "Invalid Mobile/Email and Password combination";
                vldLoginFailed.IsValid = false;
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "");
        }
    }


    #endregion

    #region Methods

    public DataSet CandidateSignIn()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_CandidateSignIn", connection))
            {
                oSecureString = new SecureQueryString();
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add(new SqlParameter("@EmailOrMob", txtEmailOrMob.Text.TrimStart('0')));
                selectCommand.Parameters.Add(new SqlParameter("@Password", oSecureString.encrypt(txtPassword.Text)));
                selectCommand.Parameters.Add(new SqlParameter("@UpdatedIP", Request.UserHostAddress));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }


    #endregion
}