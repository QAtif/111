using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ErrorLog;
using System.Text;
namespace XRecruitmentAdmin.OfferLetterViewer
{
    public partial class CustomizeBenefitsForOfferLetter : CustomBasePage
    { DataTable dt = new DataTable();
        DataSet dsDropDownData = new DataSet();
        public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
        //int UserCode = 6841;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (connection.State != ConnectionState.Closed) 
            { 
                connection.Close(); 
            }
            if (!IsPostBack)
            {                             
                MainDiv.Visible = false;
                GetDropDownData();
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        public DataTable GetAppicationID(string CandidateID)
        {
            try
            {
                DataTable dtApplicationCode = new DataTable();
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("Xrec_Select_CandidateApplicationCode", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandidateID", CandidateID);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(dtApplicationCode);
                return dtApplicationCode;
            }
            catch (Exception ex)
            {
                //ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
                return null;
            }
            finally
            {
                connection.Close();
            }

        }

        public DataTable GetOfferApprovalData(int ApplicationID)
        {
            try
            {
                DataTable dtOfferApprovalData = new DataTable();
                connection.Open();
                //SqlCommand sqlCommand = new SqlCommand("Xrec_Select_CandidateOfferLetterPackage", connection);
				SqlCommand sqlCommand = new SqlCommand("Xrec_Select_CustomizeBenefit", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Cand_Cat_Code", ApplicationID);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(dtOfferApprovalData);
                return dtOfferApprovalData;
            }
            catch (Exception ex)
            {

                //ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
                return null;
            }
            finally
            {
                connection.Close();
            }

        }

        public void BindData()
        {

            dt = GetAppicationID(txtRefNo.Text);
            if (dt.Rows.Count > 0)
            {
                hdfldCandidateCode.Value = dt.Rows[0]["candidate_Code"].ToString();
                hdfldApplicationID.Value = dt.Rows[0]["Application_Code"].ToString();
                hdfldCandidateID.Value = dt.Rows[0]["candidate_ID"].ToString();

                dt = GetOfferApprovalData(Convert.ToInt32(hdfldApplicationID.Value));

                if (dt.Rows.Count > 0)
                {
                    MainDiv.Visible = true;
                    lblName.Text = dt.Rows[0]["FullName"].ToString();
                    lblRefNo.Text = hdfldCandidateID.Value;
                    lblGrade.Text = dt.Rows[0]["Grade"].ToString();
                    //  txtOfficeCarMonetization.Text = dt.Rows[0]["MonetizationCar1"].ToString();
                    // txtHomeCarMonetization.Text = dt.Rows[0]["MonetizationCar2"].ToString();
                    //txtHomeFuelAllowance.Text = dt.Rows[0]["FuelAllowance2"].ToString();
                    ddlHomeFuelAllowance.SelectedValue = dt.Rows[0]["FuelAllowance2"].ToString() == "0" ? "-1" : dt.Rows[0]["FuelAllowance2"].ToString();
                    //   txtHomeFuelAllowanceAmount.Text = dt.Rows[0]["FuelAllowanceAmount2"].ToString();
                    //txtOfficeFuelAllowance.Text = dt.Rows[0]["FuelAllowance"].ToString();
                    //   txtOfficeFuelAllowanceAmount.Text = dt.Rows[0]["FuelAllowanceAmount"].ToString();
                    ddlOfficeFuelAllowance.SelectedValue = dt.Rows[0]["FuelAllowance"].ToString() == "0" ? "-1" : dt.Rows[0]["FuelAllowance"].ToString();
                    //txtNaturalInsurance.Text = dt.Rows[0]["NDeathAllowance"].ToString();
                    ddlAccidentalInsurance.SelectedValue = dt.Rows[0]["ADeatthAllowance"].ToString() == "0" ? "-1" : dt.Rows[0]["ADeatthAllowance"].ToString();
                    //txtMedicalMonetizationSelf.Text = dt.Rows[0]["MonetizationHealthSelf"].ToString();
                    //txtMedicalMonetizationParent.Text = dt.Rows[0]["MonetizationHealthParent"].ToString();
                    ddlMedicalSelf.SelectedValue = dt.Rows[0]["MedicalSelf"].ToString() == "0" ? "-1" : dt.Rows[0]["MedicalSelf"].ToString();
                    //  txtMedicalParent.Text = dt.Rows[0]["MedicalParent"].ToString();
                   // txtMeternity.Text = dt.Rows[0]["Maternity"].ToString();
                    //txtMineralWaterBottles.Text = dt.Rows[0]["WaterAllowance"].ToString();
                    ddlMineralWaterBottles.SelectedValue = dt.Rows[0]["WaterAllowance"].ToString() == "0" ? "-1" : dt.Rows[0]["WaterAllowance"].ToString();
                    // txtMWAllowanceAmount.Text = dt.Rows[0]["MWAllowanceAmount"].ToString();
                    hdfMobileName.Value = dt.Rows[0]["MobileName"].ToString();
                    //txtMobileAllowance.Text = dt.Rows[0]["MobileAllowance"].ToString();
                    ddlMobileAllowance.SelectedValue = dt.Rows[0]["MobileAllowance"].ToString() == "0" ? "-1" : dt.Rows[0]["MobileAllowance"].ToString();
                    //txtMobileMonetization.Text = dt.Rows[0]["MonetizationMobile"].ToString();
                    //txtSalon.Text = dt.Rows[0]["SalonQuota"].ToString();
                    ddlSalon.SelectedValue = dt.Rows[0]["SalonSlot"].ToString() == "0" ? "-2" : dt.Rows[0]["SalonSlot"].ToString();
                   // txtServantCount.Text = dt.Rows[0]["ServantCount"].ToString();
                    ddlServantCount.SelectedValue = dt.Rows[0]["ServantCount"].ToString() == "0" ? "-1" : dt.Rows[0]["ServantCount"].ToString();
                    txtMonetizationServant.Text = dt.Rows[0]["MonetizationServant"].ToString();
                    ddlPaidVacations.SelectedValue = dt.Rows[0]["PaidVacations"].ToString() == "0.00" ? "-1" : dt.Rows[0]["PaidVacations"].ToString();
                    txtMonetizationLeaves.Text = dt.Rows[0]["MonetizationLeaves"].ToString();
                   // ddlMeternityLimit.SelectedItem.Text = dt.Rows[0]["MaternityLimit"].ToString();
                    hdfHomeCarname.Value = dt.Rows[0]["HomeCarName"].ToString();
                    hdfOfficeCarname.Value = dt.Rows[0]["OfficeCarName"].ToString();

                    txtGrossSalary.Text = dt.Rows[0]["TotalSalary"].ToString();
                    txtBasicSalary.Text = dt.Rows[0]["BasicSalary"].ToString();
                    txtOtherAllowance.Text = dt.Rows[0]["OtherAllow"].ToString();
                    txtCompensatoryAllowance.Text = Convert.ToString(Convert.ToInt32(dt.Rows[0]["TotalSalary"].ToString()) / 30);
                    txtProvidentFund.Text = Convert.ToString((dt.Rows[0]["BasicSalary"].ToString()==""?0:Convert.ToInt32(dt.Rows[0]["BasicSalary"].ToString())) * 0.0833);
                    txtEOBI.Text = dt.Rows[0]["EOBIAmount"].ToString();
                    chckBoxPickDrop.Checked = dt.Rows[0]["IsTransport"].ToString() == "0" ? false : true;
                    chckboxSecondPage.Checked = dt.Rows[0]["IsHideSecondPage"].ToString() == "0" ? false : true;
					//chckBoxBike.Checked = dt.Rows[0]["IsBike"].ToString() == "0" ? false : true;
                     rdbtnlstLastPage.SelectedValue  = dt.Rows[0]["IsShowLastPage"].ToString();
                    ddlHutFacility.SelectedValue = dt.Rows[0]["HutReservation"].ToString() == "" ? "-1" : dt.Rows[0]["HutReservation"].ToString();
                   ddlClubfacility.SelectedValue = dt.Rows[0]["DreamworldandGolfClubFacility"].ToString() == "" ? "-1" : dt.Rows[0]["DreamworldandGolfClubFacility"].ToString();
                   ddlClubFacilityDetail.SelectedValue = dt.Rows[0]["DreamworldandGolfClubFacilityDetail"].ToString() == "" ? "-1" : dt.Rows[0]["DreamworldandGolfClubFacilityDetail"].ToString();
				    txtSalaryInternationalPackage.Text = dt.Rows[0]["SalaryForInternationalPackage"].ToString();
					 hdfHomeMobileName.Value = dt.Rows[0]["MobileNameHome"].ToString();
                    ddlMobileAllowanceHome.SelectedValue = dt.Rows[0]["MobileAllowanceHome"].ToString() == "0" ? "-1" : dt.Rows[0]["MobileAllowanceHome"].ToString();
                    ddlBOLLeague.SelectedValue = dt.Rows[0]["League_Code"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["League_Code"].ToString()))
                    txtCarAllowance.Text = dt.Rows[0]["CarAllowance"].ToString();

                }
            }
            else
            {
                MainDiv.Visible = false;
                Toastr.ShowToastr(this.Page, "No Record Found", "", "Info");
            }
        }
        public DataSet GetDropDownData()
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtOfferApprovalData = new DataTable();
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("Xrec_Select_CandidateOfferData", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(ds);

                if (ds.Tables.Count >= 3 && ds.Tables[2].Rows.Count > 0)
                {
                    ddlPaidVacations.DataSource = ds.Tables[2];
                    ddlPaidVacations.DataTextField = "PaidVacationAllowance";
                    ddlPaidVacations.DataValueField = "PaidVacationAllowance";
                    ddlPaidVacations.DataBind();

                    ddlPaidVacations.Items.Insert(0, new ListItem("Select", "-1"));
                }

                if (ds.Tables.Count >= 4 && ds.Tables[3].Rows.Count > 0)
                {
                    ddlOfficeFuelAllowance.DataSource = ds.Tables[3];
                    ddlOfficeFuelAllowance.DataTextField = "FuelAllowance";
                    ddlOfficeFuelAllowance.DataValueField = "FuelAllowance";
                    ddlOfficeFuelAllowance.DataBind();
                    ddlOfficeFuelAllowance.Items.Insert(0, new ListItem("Select", "-1"));

                    ddlHomeFuelAllowance.DataSource = ds.Tables[3];
                    ddlHomeFuelAllowance.DataTextField = "FuelAllowance";
                    ddlHomeFuelAllowance.DataValueField = "FuelAllowance";
                    ddlHomeFuelAllowance.DataBind();
                    ddlHomeFuelAllowance.Items.Insert(0, new ListItem("Select", "-1"));
                }
                if (ds.Tables.Count >= 5 && ds.Tables[4].Rows.Count > 0)
                {
                    ddlMedicalSelf.DataSource = ds.Tables[4];
                    ddlMedicalSelf.DataTextField = "SelfMedicalAllowance";
                    ddlMedicalSelf.DataValueField = "SelfMedicalAllowance";
                    ddlMedicalSelf.DataBind();
                    ddlMedicalSelf.Items.Insert(0, new ListItem("Select", "-1"));
                }

                if (ds.Tables.Count >= 6 && ds.Tables[5].Rows.Count > 0)
                {
                    ddlAccidentalInsurance.DataSource = ds.Tables[5];
                    ddlAccidentalInsurance.DataTextField = "AccidentalInsurance";
                    ddlAccidentalInsurance.DataValueField = "AccidentalInsurance";
                    ddlAccidentalInsurance.DataBind();
                    ddlAccidentalInsurance.Items.Insert(0, new ListItem("Select", "-1"));
                }
                 if (ds.Tables.Count >= 7 && ds.Tables[6].Rows.Count > 0)
                {
                    ddlMineralWaterBottles.DataSource = ds.Tables[6];
                    ddlMineralWaterBottles.DataTextField = "WaterBottleAllowance";
                    ddlMineralWaterBottles.DataValueField = "WaterBottleAllowance";
                    ddlMineralWaterBottles.DataBind();
                    ddlMineralWaterBottles.Items.Insert(0, new ListItem("Select", "-1"));
                }

                 if (ds.Tables.Count >= 8 && ds.Tables[7].Rows.Count > 0)
                {
                    ddlSalon.DataSource = ds.Tables[7];
                    ddlSalon.DataTextField = "SalonSlot";
                    ddlSalon.DataValueField = "SalonSlot";
                    ddlSalon.DataBind();
                    ddlSalon.Items.Insert(0, new ListItem("Select", "-2"));
                }
                 if (ds.Tables.Count >= 9 && ds.Tables[8].Rows.Count > 0)
                 {
                     ddlClubFacilityDetail.DataSource = ds.Tables[8];
                     ddlClubFacilityDetail.DataTextField = "ReservationCount";
                     ddlClubFacilityDetail.DataValueField = "ReservationCount";
                     ddlClubFacilityDetail.DataBind();
                     ddlClubFacilityDetail.Items.Insert(0, new ListItem("Select", "-1"));

                     ddlHutFacility.DataSource = ds.Tables[8];
                     ddlHutFacility.DataTextField = "ReservationCount";
                     ddlHutFacility.DataValueField = "ReservationCount";
                     ddlHutFacility.DataBind();
                     ddlHutFacility.Items.Insert(0, new ListItem("Select", "-1"));
                 }     
                
                  if (ds.Tables.Count >= 10 && ds.Tables[9].Rows.Count > 0)
                {
                    ddlServantCount.DataSource = ds.Tables[9];
                    ddlServantCount.DataTextField = "ServantCount";
                    ddlServantCount.DataValueField = "ServantCount";
                    ddlServantCount.DataBind();
                    ddlServantCount.Items.Insert(0, new ListItem("Select", "-1"));
                }   

                   if (ds.Tables.Count >= 11 && ds.Tables[10].Rows.Count > 0)
                {
                    ddlMobileAllowance.DataSource = ds.Tables[10];
                    ddlMobileAllowance.DataTextField = "MobileAllowance";
                    ddlMobileAllowance.DataValueField = "MobileAllowance";
                    ddlMobileAllowance.DataBind();
                    ddlMobileAllowance.Items.Insert(0, new ListItem("Select", "-1"));
                }

                   if (ds.Tables.Count >= 12 && ds.Tables[11].Rows.Count > 0)
                   {
                       ddlClubfacility.DataSource = ds.Tables[11];
                       ddlClubfacility.DataTextField = "ClubFacility";
                       ddlClubfacility.DataValueField = "ClubFacility";
                       ddlClubfacility.DataBind();
                       ddlClubfacility.Items.Insert(0, new ListItem("Select", "-1"));
                   }
				    if (ds.Tables.Count >= 11 && ds.Tables[10].Rows.Count > 0)
                {
                    ddlMobileAllowanceHome.DataSource = ds.Tables[10];
                    ddlMobileAllowanceHome.DataTextField = "MobileAllowance";
                    ddlMobileAllowanceHome.DataValueField = "MobileAllowance";
                    ddlMobileAllowanceHome.DataBind();
                    ddlMobileAllowanceHome.Items.Insert(0, new ListItem("Select", "-1"));
                }
                   if (ds.Tables.Count >= 13 && ds.Tables[12].Rows.Count > 0)
                   {
                       ddlBOLLeague.DataSource = ds.Tables[12];
                       ddlBOLLeague.DataTextField = "League_Description";
                       ddlBOLLeague.DataValueField = "League_Code";
                       ddlBOLLeague.DataBind();
                       ddlBOLLeague.Items.Insert(0, new ListItem("Select", "-1"));
                   }
 
                return ds;
            }
            catch (Exception ex)
            {

                //ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
                return null;
            }
            finally
            {
                connection.Close();
            }

        }

        public void BindControl(DataTable dt, string ControlName)
        {
            try
            {
                // Utilities objUtilities = new Utilities();
                List<clsJsonObject> collectionItem = new List<clsJsonObject>();
                string errorMessage = string.Empty;
                string javaScript = string.Empty;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        clsJsonObject objJson = new clsJsonObject();
                        objJson.Id = dr["id"].ToString();
                        objJson.Name = dr["Name"].ToString();
                        collectionItem.Add(objJson);
                    }
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script" + ControlName, " Bind('" + GetJSONString(collectionItem) + "','" + ControlName + "');", true);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            }

        }

        public void GenerateOfferLetter()
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            try
            {
                SqlCommand sqlCommand = new SqlCommand("dbo.XREC_Insert_ReGenerateOfficialLetter", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Candidate_Code", SqlDbType.Int).Value = Convert.ToInt32(hdfldCandidateCode.Value);
                sqlCommand.Parameters.Add("@OfficialLetter_Code", SqlDbType.Int).Value = 10;
                sqlCommand.Parameters.AddWithValue("@UpdatedBy", Convert.ToInt32(UserCode));
                sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.ServerVariables["REMOTE_ADDR"].ToString());
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            }
            finally
            {
                connection.Close();
            }

        }

        string GetJSONString(List<clsJsonObject> data)
        {
            StringBuilder sb = new StringBuilder();
            try
            {

                foreach (clsJsonObject dr in data)
                {

                    if (sb.Length != 0)
                        sb.Append(",");
                    sb.Append("{");
                    sb.Append(string.Format("\"{0}\":\"{1}\"", "id", dr.Id));
                    sb.Append(",");
                    sb.Append(string.Format("\"{0}\":\"{1}\"", "name", dr.Name));
                    // sb.Append(string.Format("\"{0}\":\"{1}\"", "name", dr.SubCategoryName));
                    sb.Append("}");
                }

                sb.Insert(0, "[");
                sb.Append("]");


            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            }
            return sb.ToString();
        }

        public int InsertCustomizeBenefits()
        {

            try
            {
                DataTable dtApplicationCode = new DataTable();
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("Xrec_Insert_CustomizeBenefits", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(hdfldCandidateCode.Value));
                sqlCommand.Parameters.AddWithValue("@ApplicationCode", Convert.ToInt32(hdfldApplicationID.Value));

                if (!string.IsNullOrEmpty(hdfOfficeCarname.Value))
                    sqlCommand.Parameters.AddWithValue("@OfficeCarName", hdfOfficeCarname.Value);// txtCarOfficeName.Text

                // if (!string.IsNullOrEmpty(txtOfficeCarMonetization.Text))
                //   sqlCommand.Parameters.AddWithValue("@MonetizationOfficeCar", Convert.ToDecimal(txtOfficeCarMonetization.Text));

                if (!string.IsNullOrEmpty(hdfHomeCarname.Value))
                    sqlCommand.Parameters.AddWithValue("@HomeCarName", hdfHomeCarname.Value);

                // if (!string.IsNullOrEmpty(txtHomeCarMonetization.Text))
                //   sqlCommand.Parameters.AddWithValue("@MonetizationHomeCar", Convert.ToDecimal(txtHomeCarMonetization.Text));

                if (ddlOfficeFuelAllowance.SelectedValue != "-1")
                    sqlCommand.Parameters.AddWithValue("@OfficeFuelAllowance", Convert.ToInt32(ddlOfficeFuelAllowance.SelectedValue));

                // if (!string.IsNullOrEmpty(txtOfficeFuelAllowanceAmount.Text))
                //     sqlCommand.Parameters.AddWithValue("@OfficeFuelAllowanceAmount", Convert.ToDecimal(txtOfficeFuelAllowanceAmount.Text));

                //      if (!string.IsNullOrEmpty(txtHomeFuelAllowance.Text))
                // sqlCommand.Parameters.AddWithValue("@HomeFuelAllowance", Convert.ToInt32(txtHomeFuelAllowance.Text));

                if (ddlHomeFuelAllowance.SelectedValue != "-1")
                    sqlCommand.Parameters.AddWithValue("@HomeFuelAllowance", Convert.ToInt32(ddlHomeFuelAllowance.SelectedValue));

                //  if (!string.IsNullOrEmpty(txtHomeFuelAllowanceAmount.Text))
                //      sqlCommand.Parameters.AddWithValue("@HomeFuelAllowanceAmount", Convert.ToDecimal(txtHomeFuelAllowanceAmount.Text));

               /* if (!string.IsNullOrEmpty(txtMobileAllowance.Text))
                    sqlCommand.Parameters.AddWithValue("@MobileAllowance", Convert.ToInt32(txtMobileAllowance.Text));*/
                if (ddlMobileAllowance.SelectedValue != "-1")
                    sqlCommand.Parameters.AddWithValue("@MobileAllowance", Convert.ToInt32(ddlMobileAllowance.SelectedValue));

             //   if (!string.IsNullOrEmpty(txtMineralWaterBottles.Text))
               //     sqlCommand.Parameters.AddWithValue("@WaterAllowance", Convert.ToInt32(txtMineralWaterBottles.Text));

                if (ddlMineralWaterBottles.SelectedValue != "-1")
                    sqlCommand.Parameters.AddWithValue("@WaterAllowance", Convert.ToDecimal(ddlMineralWaterBottles.SelectedValue));

                //   if (!string.IsNullOrEmpty(txtMWAllowanceAmount.Text))
                //       sqlCommand.Parameters.AddWithValue("@WaterAllowanceAmount", Convert.ToDecimal(txtMWAllowanceAmount.Text));

               /* if (!string.IsNullOrEmpty(txtServantCount.Text))
                    sqlCommand.Parameters.AddWithValue("@ServantCount", Convert.ToInt32(txtServantCount.Text));*/

                if (ddlServantCount.SelectedValue != "-1")
                    sqlCommand.Parameters.AddWithValue("@ServantCount", Convert.ToInt32(ddlServantCount.SelectedValue));

                if (ddlMedicalSelf.SelectedValue != "-1")
                    sqlCommand.Parameters.AddWithValue("@MedicalSelf", Convert.ToDecimal(ddlMedicalSelf.SelectedValue));

                /* if (!string.IsNullOrEmpty(txtMedicalParent.Text))
                     sqlCommand.Parameters.AddWithValue("@MedicalParent", Convert.ToDecimal(txtMedicalParent.Text));*/

                /*if (!string.IsNullOrEmpty(ddlMeternityLimit.SelectedItem.Text))
                    sqlCommand.Parameters.AddWithValue("@MaternityLimit", ddlMeternityLimit.SelectedItem.Text);

                 if (!string.IsNullOrEmpty(txtMedicalMonetizationSelf.Text))
                     sqlCommand.Parameters.AddWithValue("@MonetizationHealthSelf", Convert.ToDecimal(txtMedicalMonetizationSelf.Text));

                 if (!string.IsNullOrEmpty(txtMedicalMonetizationParent.Text))
                     sqlCommand.Parameters.AddWithValue("@MonetizationHealthParent", Convert.ToDecimal(txtMedicalMonetizationParent.Text));

                if (!string.IsNullOrEmpty(txtMeternity.Text))
                    sqlCommand.Parameters.AddWithValue("@Maternity", Convert.ToDecimal(txtMeternity.Text));*/

                if (!string.IsNullOrEmpty(txtMonetizationLeaves.Text))
                    sqlCommand.Parameters.AddWithValue("@MonetizationLeaves", Convert.ToDecimal(txtMonetizationLeaves.Text));

                if (ddlAccidentalInsurance.SelectedValue != "-1")
                    sqlCommand.Parameters.AddWithValue("@AccidentalDeath", Convert.ToDecimal(ddlAccidentalInsurance.SelectedValue));

                /* if (!string.IsNullOrEmpty(txtNaturalInsurance.Text))
                     sqlCommand.Parameters.AddWithValue("@NaturalDeath", Convert.ToDecimal(txtNaturalInsurance.Text));*/

                if (!string.IsNullOrEmpty(hdfMobileName.Value))
                    sqlCommand.Parameters.AddWithValue("@MobileName", hdfMobileName.Value);

                if (!string.IsNullOrEmpty(txtMonetizationServant.Text))
                    sqlCommand.Parameters.AddWithValue("@MonetizationServant", Convert.ToDecimal(txtMonetizationServant.Text));

                /*if (!string.IsNullOrEmpty(txtSalon.Text))
                    sqlCommand.Parameters.AddWithValue("@SalonSlot", Convert.ToInt32(txtSalon.Text));*/
                if (ddlSalon.SelectedValue != "-2")
                    sqlCommand.Parameters.AddWithValue("@SalonSlot", (ddlSalon.SelectedValue == "Un Limited" ? "-1" : ddlSalon.SelectedValue));

                if (ddlPaidVacations.SelectedValue != "-1")
                    sqlCommand.Parameters.AddWithValue("@PaidVacations", Convert.ToDecimal(ddlPaidVacations.SelectedValue));

                if (!string.IsNullOrEmpty(txtGrossSalary.Text))
                    sqlCommand.Parameters.AddWithValue("@GrossSalary", Convert.ToDecimal(txtGrossSalary.Text));
                if (!string.IsNullOrEmpty(txtBasicSalary.Text))
                    sqlCommand.Parameters.AddWithValue("@BasicSalary", Convert.ToDecimal(txtBasicSalary.Text));
                if (!string.IsNullOrEmpty(txtOtherAllowance.Text))
                    sqlCommand.Parameters.AddWithValue("@OtherAllowance", Convert.ToDecimal(txtOtherAllowance.Text));
                if (!string.IsNullOrEmpty(txtCompensatoryAllowance.Text))
                    sqlCommand.Parameters.AddWithValue("@CompensatoryAllowance", Convert.ToDecimal(txtCompensatoryAllowance.Text));
                if (!string.IsNullOrEmpty(txtProvidentFund.Text))
                    sqlCommand.Parameters.AddWithValue("@ProvidentFund", Convert.ToDecimal(txtProvidentFund.Text));
                if (!string.IsNullOrEmpty(txtEOBI.Text))
                    sqlCommand.Parameters.AddWithValue("@EOBI", Convert.ToDecimal(txtEOBI.Text));
                if (chckBoxPickDrop.Checked)
                    sqlCommand.Parameters.AddWithValue("@IsTransport", 1);
                else
                    sqlCommand.Parameters.AddWithValue("@IsTransport", 0);

                if (chckboxSecondPage.Checked)
                    sqlCommand.Parameters.AddWithValue("@IsHideSecondPage", 1);
                else
                    sqlCommand.Parameters.AddWithValue("@IsHideSecondPage", 0);

                sqlCommand.Parameters.AddWithValue("@IsShowLastPage", rdbtnlstLastPage.SelectedItem.Value);

                if (ddlHutFacility.SelectedValue != "-1")
                    sqlCommand.Parameters.AddWithValue("@HutReservation", ddlHutFacility.SelectedValue);

                if (ddlClubFacilityDetail.SelectedValue != "-1")
                    sqlCommand.Parameters.AddWithValue("@DreamworldandGolfClubFacilityDetail", ddlClubFacilityDetail.SelectedValue);

                if (ddlClubfacility.SelectedValue != "-1")
                    sqlCommand.Parameters.AddWithValue("@DreamworldandGolfClubFacility", ddlClubfacility.SelectedValue);
				 if (!string.IsNullOrEmpty(txtSalaryInternationalPackage.Text))
                    sqlCommand.Parameters.AddWithValue("@SalaryForInternationalPackage", Convert.ToDecimal(txtSalaryInternationalPackage.Text));
				  if (!string.IsNullOrEmpty(hdfHomeMobileName.Value))
                    sqlCommand.Parameters.AddWithValue("@MobileNameHome", hdfHomeMobileName.Value);
                if (ddlMobileAllowanceHome.SelectedValue != "-1")
                    sqlCommand.Parameters.AddWithValue("@MobileAllowanceHome", Convert.ToInt32(ddlMobileAllowanceHome.SelectedValue));
                if (ddlBOLLeague.SelectedValue != "-1")
                    sqlCommand.Parameters.AddWithValue("@LeagueCode", Convert.ToInt32(ddlBOLLeague.SelectedValue));

                if (!string.IsNullOrEmpty(txtCarAllowance.Text))
                    sqlCommand.Parameters.AddWithValue("@CarAllowance", Convert.ToInt32(txtCarAllowance.Text));   
                             
                sqlCommand.Parameters.AddWithValue("@CreatedBy", Convert.ToInt32(UserCode));
                sqlCommand.Parameters.AddWithValue("@UserIP", Request.ServerVariables["REMOTE_ADDR"].ToString());
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
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int Result = InsertCustomizeBenefits();
            if (Result != 0)
            {
                GenerateOfferLetter();
                BindData();
                Toastr.ShowToastr(this.Page, "Offer generated successfully", "", "Success");
            }
            else {
                Toastr.ShowToastr(this.Page, "Error", "", "Error");
            }
        }

    }

    public class clsJsonObject
    {
        public string Id;
        public string Name;
        // public string SubCategoryName;
    }

    public static class Toastr
    {
        public static void ShowToastr(this Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                  String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }
    }
}