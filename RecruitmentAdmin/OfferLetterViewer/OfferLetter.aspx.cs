using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;


namespace XRecruitmentAdmin.OfferLetterViewer
{
    public partial class OfferLetter : System.Web.UI.Page
    {
        SecureQueryString objSecureQueryString = new SecureQueryString();
        string path = string.Empty;
        string CandidateCode = string.Empty;
        string Comments = string.Empty;

        public static SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["CC"] != null)
                {

                    if (!IsPostBack)
                    {
                        CandidateCode = Request.QueryString["CC"].ToString();
                        CandidateCode = objSecureQueryString.decrypt(CandidateCode);
                        hdnfldCondidateCode.Value = CandidateCode;
                        OfferLetterViewer(Convert.ToInt64(CandidateCode));
                    }

                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex) { }
        }

        public void OfferLetterViewer(long CandidateCode)
        {
            try
            {
                if (Con.State != ConnectionState.Open)
                    Con.Open();
                DataTable dataTable = new DataTable();
                SqlCommand selectCommand = new SqlCommand("dbo.Xrec_Select_CandidateOfferLetter", Con);
                selectCommand.CommandType = CommandType.StoredProcedure;

                selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
                new SqlDataAdapter(selectCommand).Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {

                   // iframLetterViewer.Src 
		iframLetterViewer.Attributes["src"]  = ConfigurationManager.AppSettings["LivePath"].ToString() + dataTable.Rows[0]["DocumentPath"].ToString();
}
            }
            catch (Exception ex)
            {

            }
            finally
            {

                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
        }

        protected void btnSaveStatus_Click(object sender, EventArgs e)
        {
            string UserIP = Request.ServerVariables["REMOTE_ADDR"].ToString();


            if (rdbtnlstStatus.SelectedValue == "2")
                Comments += " Offer Rejected -" + ' ' + txtComments.Text;
            else if (rdbtnlstStatus.SelectedValue == "1")
                Comments += " Offer Accepted -";

            bool result =  InsertComments(Convert.ToInt32(hdnfldCondidateCode.Value), Comments, UserIP);

            if (result)
            {
                btnSaveStatus.Visible = false;
                lblMessage.Text = "Updated successfully";
                Session.Clear();
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
            else {
                lblMessage.Text = "Not updated";
            }


        }

        protected void rdbtnlstStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbtnlstStatus.SelectedValue == "2")
            {
                txtComments.Visible = true;
                lblComments.Visible = true;
            }
            else
            {
                txtComments.Visible = false;
                lblComments.Visible = false;
            }
        }

        public static bool MarkLifeCycleStatus(int CandidateCode, int StatusCode, string UserIP, int UserID)
        {
            try
            {

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = Con;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "dbo.XRec_SNT_Update_MarkLifeCycleStatus";
                sqlCommand.Parameters.Add("@CandidateCode", SqlDbType.Int).Value = CandidateCode;
                sqlCommand.Parameters.Add("@moduleCode", SqlDbType.Int).Value = 1000;
                sqlCommand.Parameters.Add("@StatusCode", SqlDbType.Int).Value = StatusCode;
                sqlCommand.Parameters.Add("@Updated_By", SqlDbType.Int).Value = UserID;
                sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = UserIP;
                if (Con.State != ConnectionState.Open)
                    Con.Open();

                return Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
        }

        public static bool InsertComments(int CandidateCode, string Comments, string UserIP)
        {
            try
            {

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = Con;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "Xrec_Insert_CandidateComments";
                sqlCommand.Parameters.Add("@Candidate_Code", SqlDbType.Int).Value = CandidateCode;
                sqlCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = Comments;
                sqlCommand.Parameters.Add("@Updated_IP", SqlDbType.VarChar).Value = UserIP;
                if (Con.State != ConnectionState.Open)
                    Con.Open();

                return Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
        }
    }
}