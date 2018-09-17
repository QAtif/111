using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XRecruitmentAdmin.OfferLetterViewer
{
    public partial class DiscrepantReportPopUp1 : System.Web.UI.Page
    {
        public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                GetData(Convert.ToInt32(Request.QueryString["aid"]));
            }
        }

        public void GetData(int ApplicationCode)
        {
            try
            {
                DataTable dt = new DataTable();
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("Xrec_Select_CustomizeBenefitUser", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ApplicationCode", ApplicationCode);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(dt);

                if (dt != null && dt.Rows.Count > 0) {
                    lblFullName.Text = dt.Rows[0]["Full_Name"].ToString() + " ( " + dt.Rows[0]["Grade"].ToString() + " )";
                    lblSalary.Text = Convert.ToInt64(dt.Rows[0]["TotalSalary"]).ToString("#,##0");
                    lblIntSalary.Text = Convert.ToInt64(dt.Rows[0]["SalaryForInternationalPackage"]).ToString("#,##0");
                    lblMobileSet.Text = dt.Rows[0]["MobileName"].ToString();
                    lblMobileSetForHome.Text = dt.Rows[0]["MobileNameHome"].ToString();
                    lblMobileAllowance.Text = Convert.ToInt32(dt.Rows[0]["MobileAllowance"]).ToString("#,##0");
                    lblMobileAllowanceForHome.Text = Convert.ToInt32(dt.Rows[0]["MobileAllowanceHome"]).ToString("#,##0");
                    lblWaterAllowance.Text = Convert.ToInt32(dt.Rows[0]["WaterAllowance"]).ToString("#,##0");
                    lblFuelAllowanceOffice.Text = Convert.ToInt32(dt.Rows[0]["OfficeFuelAllowance"]).ToString("#,##0");
                    lblFuelAllowanceForHome.Text = Convert.ToInt32(dt.Rows[0]["HomeFuelAllowance"]).ToString("#,##0");
                    lblCarOffice.Text = dt.Rows[0]["OfficeCarName"].ToString();
                    lblCarHome.Text = dt.Rows[0]["HomeCarName"].ToString();
                    lblServantCount.Text = Convert.ToInt32(dt.Rows[0]["ServantCount"]).ToString("#,##0");
                    lblNdeathAllowance.Text = Convert.ToInt64(dt.Rows[0]["NaturalDeath"]).ToString("#,##0");
                    lblAdeathAllowance.Text = Convert.ToInt64(dt.Rows[0]["AccidentalDeath"]).ToString("#,##0");
                    lblMedicalSelf.Text = Convert.ToInt64(dt.Rows[0]["MedicalSelf"]).ToString("#,##0");
                    lblMedicalParent.Text = Convert.ToInt64(dt.Rows[0]["MedicalParent"]).ToString("#,##0");
                    lblMeternity.Text = dt.Rows[0]["MaternityLimit"].ToString();
                    lblPaidVacation.Text = dt.Rows[0]["PaidVacations"].ToString();
                    lblLeague.Text = dt.Rows[0]["League_Description"].ToString(); 
                }
              
            }
            catch (Exception ex)
            {
                //ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());

            }
            finally
            {

                connection.Close();

            }
        }
    }
}