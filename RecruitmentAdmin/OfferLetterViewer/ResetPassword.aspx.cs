using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace XRecruitmentAdmin.OfferLetterViewer
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        PasswordReset objRP = new PasswordReset();
        DataTable dt;
        SecureQueryString OBJ = new SecureQueryString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshControl();
            }
        }

        public void GetCandidateDetailForPasswordReset()
        {
            try
            {
                string RefNo = (Server.HtmlEncode(txtRefNo.Text) == "" ? null:Server.HtmlEncode(txtRefNo.Text));
                string Email = (Server.HtmlEncode(txtEmail.Text) == "" ? null : Server.HtmlEncode(txtEmail.Text));
            dt = objRP.GetCandidateDetail(RefNo,Email);

            if (dt.Rows.Count > 0)
            {
                lblName.Text = dt.Rows[0]["Full_Name"].ToString();
                lblRefNo.Text = dt.Rows[0]["Candidate_ID"].ToString();
                lblEmailAddress.Text = dt.Rows[0]["Email_Address"].ToString();
                lblPhoneNo.Text = dt.Rows[0]["Phone_Number"].ToString();
                hdfldCandidateID.Value = dt.Rows[0]["Candidate_ID"].ToString();
                trNoRec.Visible = false;
                btnUpdate.Visible = true;
                trRec.Visible = true;
            }
            else
            {
                trNoRec.Visible = true;
                trRec.Visible = false;
                btnUpdate.Visible = false;
                RefreshControl();
            }
            }
            catch (Exception ex)
            {
                throw ex;
                // ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentAdmin, "PasswordRestForm :: " + ex.StackTrace, ex, null);
            }

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetCandidateDetailForPasswordReset();
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            int result = objRP.UpdatePassword(OBJ.encrypt("BOL"), Request.ServerVariables["REMOTE_ADDR"], hdfldCandidateID.Value);
            if (result != 0)
            {

                lblError.Visible = true;
                lblError.ForeColor = Color.Black;
                lblError.Text = "Password reset successfully and your New Password is <b>BOL</b>";
              //  RefreshControl();
            }
            else
            {
                lblError.Visible = true;
                lblError.ForeColor = Color.Red;
                lblError.Text = "Error.";
            }

        }

        public void RefreshControl()
        {

            lblEmailAddress.Text = "";
            lblName.Text = "";
            lblRefNo.Text = "";
            lblPhoneNo.Text = "";
            trNoRec.Visible = true;
            btnUpdate.Visible = false;
            trRec.Visible = false;
            //txtResetPasswrord.Text = "";
        }
    }
    public class PasswordReset
    {
        DataTable dt = new DataTable();
        public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);

        public DataTable GetCandidateDetail(string CandidateID,string Email)
        {
            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("Xrec_Select_CandidateDetailForResetPassword", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandidateID", CandidateID);
                sqlCommand.Parameters.AddWithValue("@Email", Email);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
                //ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public int UpdatePassword(string Password, string UpdatedIp, string CandidateID)
        {
            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("Xrec_Update_Password", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Password", Password);
                //sqlCommand.Parameters.AddWithValue("@Updated_By", UpdatedBy);
                sqlCommand.Parameters.AddWithValue("@Updated_IP", UpdatedIp);
                sqlCommand.Parameters.AddWithValue("@Candidate_ID", CandidateID);
                int result = Convert.ToInt32(sqlCommand.ExecuteNonQuery());
                return result;
            }
            catch (Exception ex)
            {

                //ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

    }
}