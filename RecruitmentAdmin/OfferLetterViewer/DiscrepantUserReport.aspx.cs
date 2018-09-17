using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace XRecruitmentAdmin.OfferLetterViewer
{
    public partial class DiscrepantUserReport : System.Web.UI.Page
    {
		SecureQueryString sQString = new SecureQueryString();
        int totalResults = 0;
        DataTable dt = new DataTable();
        DataSet dsDropDownData = new DataSet();
        public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
        public int pageSize { get { return Convert.ToInt32(ddlPageSize.SelectedValue); } }
        public int totalPages { get { return (totalResults % pageSize) == 0 ? totalResults / pageSize : (totalResults / pageSize) + 1; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
//                GetCustomizeUsers(1);
  GetDropDownData();
 txtFromDate.Value = System.DateTime.Now.AddMonths(-1).ToString("MMM dd, yyyy");
                txtToDate.Value = System.DateTime.Now.ToString("MMM dd, yyyy");
trPaging.Visible = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetCustomizeUsers(1);
        }

                 public void GetCustomizeUsers(int PageNum)
        {
            DataTable dtCustomizeUser = GetData(PageNum,false);
            if (dtCustomizeUser.Rows.Count > 0)
            {
                totalResults = Convert.ToInt32(dtCustomizeUser.Rows[0]["TotalResult"]);
                lblTotalRec.Text = totalResults.ToString();
                FillddlPageNumber(PageNum);

                if (totalResults > Convert.ToInt32(ddlPageSize.Items[0].Value))
                {
                    trPaging.Visible = true;
                    setButtons(PageNum);
                }
                else
                {
                    trPaging.Visible = false;
                }

                rptCustomizeUsers.DataSource = dtCustomizeUser;
                rptCustomizeUsers.DataBind();
                divNoRcrd.Visible = false;
            }
            else
            {
                rptCustomizeUsers.DataSource = null;
                rptCustomizeUsers.DataBind();
                divNoRcrd.Visible = true;
                trPaging.Visible = false;
            }
        }
        public DataTable GetData(int PageNum,bool IsExcel)
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
                if (!string.IsNullOrEmpty(txtFromDate.Value)) {
                    sqlCommand.Parameters.AddWithValue("@FromDate", txtFromDate.Value);
                }
                if (!string.IsNullOrEmpty(txtToDate.Value))
                {
                    sqlCommand.Parameters.AddWithValue("@ToDate", txtToDate.Value);
                }
                if (ddlDomain.SelectedValue != "-1") {
                    sqlCommand.Parameters.AddWithValue("@DomainCode", ddlDomain.SelectedValue);
                }
				 if (!string.IsNullOrEmpty(txtRefNo.Text))
                {
                    sqlCommand.Parameters.AddWithValue("@CandidateID", txtRefNo.Text);
                }
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    sqlCommand.Parameters.AddWithValue("@CandidateName", txtName.Text);
                }
                if (!IsExcel) { 
                sqlCommand.Parameters.AddWithValue("@PageNum", PageNum);
                sqlCommand.Parameters.AddWithValue("@PageSize", ddlPageSize.SelectedValue);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(dt);

                return dt;
                
            }
            catch (Exception ex)
            {
                return null;
                //ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());

            }
            finally
            {
                
                connection.Close();
               
            }
        }
  public void GetDropDownData() {
            try
            {
                DataTable dtDomain = new DataTable();
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand sqlCommand = new SqlCommand("XRec_SelectAllDomain", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
              
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(dtDomain);
                if (dtDomain.Rows.Count > 0)
                {

                    ddlDomain.DataSource = dtDomain;
                    ddlDomain.DataTextField = "Domain_Name";
                    ddlDomain.DataValueField = "Domain_Code";
                    ddlDomain.DataBind();

                    ddlDomain.Items.Insert(0, new ListItem("Select", "-1"));
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

        #region Paging
        private void setButtons(int PageNum)
        {
            if (PageNum != 1 && ddlPageNum.Items.Count > 1)
            {
                //IbtnPrevious.ImageUrl = "/images/previous.png";
                IbtnPrevious.Enabled = true;
            }
            else
            {
                //IbtnPrevious.ImageUrl = "/images/previous-disabled.png";
                IbtnPrevious.Enabled = false;
            }

            if (PageNum != totalPages && ddlPageNum.Items.Count > 1)
            {
                //IbtnNext.ImageUrl = "/images/next.png";
                IbtnNext.Enabled = true;
            }
            else
            {
                //IbtnNext.ImageUrl = "/images/next-disabled.png";
                IbtnNext.Enabled = false;
            }
        }
        protected void FillddlPageNumber(int pageNumber)
        {
            try
            {
                ddlPageNum.Items.Clear();
                for (int i = 1; i <= totalPages; i++)
                {
                    ddlPageNum.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                ddlPageNum.SelectedValue = Convert.ToString(pageNumber);
            }
            catch (Exception ex)
            {
                //  lblError.Text = ex.ToString();
                throw;
            }
        }
        protected void ddlPageNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetCustomizeUsers(Convert.ToInt32(ddlPageNum.SelectedValue));
            }
            catch (Exception ex)
            {
                //lblError.Text = ex.ToString();
                throw;
            }
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetCustomizeUsers(1);
            }
            catch (Exception ex)
            {
                // lblError.Text = ex.ToString();
                throw;
            }
        }
        protected void IbtnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                ddlPageNum.SelectedIndex = ddlPageNum.SelectedIndex - 1;
                ddlPageNum_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                // lblError.Text = ex.ToString();
                throw;
            }
        }
        protected void IbtnNext_Click(object sender, EventArgs e)
        {
            try
            {
                ddlPageNum.SelectedIndex = ddlPageNum.SelectedIndex + 1;
                ddlPageNum_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                //  lblError.Text = ex.ToString();
                throw;
            }
        }
        #endregion

  protected void rptCustomizeUsers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                   /* Label lblUserID = (Label)e.Item.FindControl("lblUserID");
                    Label lblHomeCar = (Label)e.Item.FindControl("lblHomeCar");
                    Label lblMobileHome = (Label)e.Item.FindControl("lblMobileHome");
                    
                      
                    string UserID = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "UserID").ToString());
                    string HomeCarName =DataBinder.Eval(e.Item.DataItem, "HomeCarName").ToString();
                    string HomeFuelAllowance = DataBinder.Eval(e.Item.DataItem, "HomeFuelAllowance").ToString();
                    string MobileNameHome = DataBinder.Eval(e.Item.DataItem, "MobileNameHome").ToString();
                    string MobileAllowanceHome = DataBinder.Eval(e.Item.DataItem, "MobileAllowanceHome").ToString();


                    lblUserID.Text = (string.IsNullOrEmpty(UserID) ? "" : "(" + UserID + ")"); 
					lblHomeCar.Text = (string.IsNullOrEmpty(HomeCarName) ? "" : "<b>Home:</b> " + HomeCarName + " (" + HomeFuelAllowance + " Liters )");
                    lblMobileHome.Text = (string.IsNullOrEmpty(MobileNameHome) ? "" : "<b>Home:</b> " + MobileNameHome + " ( Rs " + MobileAllowanceHome + ")");*/
					 Label lblUserID = (Label)e.Item.FindControl("lblUserID");
                    Label lblHomeCar = (Label)e.Item.FindControl("lblHomeCar");
                    Label lblMobileHome = (Label)e.Item.FindControl("lblMobileHome");
                    HtmlAnchor lnkPackage = (HtmlAnchor)e.Item.FindControl("lnkPackage");
HtmlAnchor aCandidateLink = (HtmlAnchor)e.Item.FindControl("aCandidateLink");

                    string ApplicationCode = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "ApplicationCode"));
                    string UserID = DataBinder.Eval(e.Item.DataItem, "UserID").ToString();
                    string HomeCarName = DataBinder.Eval(e.Item.DataItem, "HomeCarName").ToString();
                    string HomeFuelAllowance = DataBinder.Eval(e.Item.DataItem, "HomeFuelAllowance").ToString();
                    string MobileNameHome = DataBinder.Eval(e.Item.DataItem, "MobileNameHome").ToString();
                    string MobileAllowanceHome = DataBinder.Eval(e.Item.DataItem, "MobileAllowanceHome").ToString();
 string CandidateID = DataBinder.Eval(e.Item.DataItem, "Candidate_Code").ToString();
 
                    lnkPackage.Attributes.Add("data-rel", "DiscrepantReportPopUp.aspx?aid=" + ApplicationCode);
aCandidateLink.HRef = "../../A2/candidate/CandidateProfile.aspx?" + (string)SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + CandidateID);
                    lblUserID.Text = (string.IsNullOrEmpty(UserID) ? "" : "" + UserID + "");
                    lblHomeCar.Text = (string.IsNullOrEmpty(HomeCarName) ? "" : "<b>Home:</b> " + HomeCarName + "<br/><b>Fuel (Home):</b> " + HomeFuelAllowance + " Liters");
                    lblMobileHome.Text = (string.IsNullOrEmpty(MobileNameHome) ? "" : "<b>Mobile 2:</b> " + MobileNameHome + " <br/><b>SIM 2:</b> Rs " + MobileAllowanceHome + "");
                
                }
            }
            catch (Exception ex) { 
            }
        }

 protected void btnClearFilter_Click(object sender, EventArgs e)
        {
             txtFromDate.Value = System.DateTime.Now.AddMonths(-1).ToString("MMM dd, yyyy");
                txtToDate.Value = System.DateTime.Now.ToString("MMM dd, yyyy");
            ddlDomain.SelectedValue = "-1";
			 txtRefNo.Text = "";
            txtName.Text = "";
        }
protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            DataTable dtExcel = GetData(1,true);
            if (dtExcel != null && dtExcel.Rows.Count > 0)
            {
                string attachment = "attachment; filename=CustomizeuserDetail.xls";
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/vnd.ms-excel";

                ///HEADER
                Response.Write("User ID\tReference No\tName\tGrade\tDesignation\tDepartment\tLocation\tJoining Date\tSalary\tInt. Salary Package\tCar (Office)\tCar (Home)\tFuel Allowance (Office)\tFuel Allowance (Home)\tMobile (Office)\tMobile (Home)\tMobile Allowance (Office)\tMobile Allowance (Home)"+
                    "\tMedical (Self)\tMedical (Parent)\tMeternity\tAccidental Death Insurance\tNatural Death Insurance\tWater Allowance\tServant\tLeague");

                foreach (DataRow dr in dtExcel.Rows)
                {
                    Response.Write("\n");
                    Response.Write(dr["UserID"] + "\t");
					 Response.Write(dr["Candidate_ID"] + "\t");
                    Response.Write(dr["Full_Name"] + "\t");
                    Response.Write(dr["Grade"] + "\t");
                    Response.Write(dr["Designation_Name"] + "\t");
                    Response.Write(dr["Domain_Name"] + "\t");
                    Response.Write(dr["City"] + "\t");
                    Response.Write(dr["JoiningDate"] + "\t");
                    Response.Write(dr["TotalSalary"] + "\t");
                    Response.Write(dr["SalaryForInternationalPackage"] + "\t");
                    Response.Write(dr["OfficeCarName"] + "\t");
                    Response.Write(dr["HomeCarName"] + "\t");
                    Response.Write(dr["OfficeFuelAllowance"] + "\t");
                    Response.Write(dr["HomeFuelAllowance"] + "\t");
                    Response.Write(dr["MobileName"]+ "\t");
                    Response.Write(dr["MobileNameHome"] + "\t");
                    Response.Write(dr["MobileAllowance"] + "\t");
                    Response.Write(dr["MobileAllowanceHome"] + "\t");
                    Response.Write(dr["MedicalSelf"] + "\t");
                    Response.Write(dr["MedicalParent"] + "\t");
                    Response.Write(dr["MaternityLimit"] + "\t");
                    Response.Write(dr["AccidentalDeath"] + "\t");
                    Response.Write(dr["NaturalDeath"] + "\t");
                    Response.Write(dr["WaterAllowance"] + "\t");
                    Response.Write(dr["ServantCount"] + "\t");
                    Response.Write(dr["League_Description"] + "\t");
                    
                }

                Response.Flush();
                Response.End();
            }
           
        }
    }
}