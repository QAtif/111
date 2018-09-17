using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ErrorLog;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;


public partial class A2_Candidate_TrainingUserCanDetail : CustomBasePage, IRequiresSessionState
{

   SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
   SecureQueryString secQueryString = new SecureQueryString();
   string QueryStringVar = string.Empty;
   string CandidateCode = string.Empty;
   string IsTest = "true";
   DataSet CandidateDS = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            if (!string.IsNullOrEmpty(QueryStringVar))
            {
                secQueryString = new SecureQueryString(QueryStringVar);
                CandidateCode = secQueryString["CID"].ToString();
                if (IsPostBack || string.IsNullOrEmpty(CandidateCode))
                    return;
                BindCandidateDetail(CandidateCode);
            }
            else
                DivDetail.Visible = false;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    public void BindCandidateDetail(string CandCode)
    {
        try
        {
            string str1 = "0";
            string str2 = "0";
            SqlCommand selectCommand = new SqlCommand("dbo.XRec_SelectCandidateDetailTrainingUser", connection);
            selectCommand.Parameters.AddWithValue("@Candidate_Code", CandCode);
            selectCommand.CommandType = CommandType.StoredProcedure;
            new SqlDataAdapter(selectCommand).Fill(CandidateDS);
            if (CandidateDS == null)
                return;
            DivDetail.Visible = true;
            if (CandidateDS.Tables.Count >= 1 && CandidateDS.Tables[0].Rows.Count > 0)
            {
                lblCanName.Text = CandidateDS.Tables[0].Rows[0]["full_name"].ToString();
                lblGender.Text = CandidateDS.Tables[0].Rows[0]["gender"].ToString();
                lblMaritalStatus.Text = CandidateDS.Tables[0].Rows[0]["maritalstatus"].ToString();
                lblRefNo.Text = CandidateDS.Tables[0].Rows[0]["Candidate_ID"].ToString();
                lblReligion.Text = CandidateDS.Tables[0].Rows[0]["religion"].ToString();
                lblNationality.Text = CandidateDS.Tables[0].Rows[0]["Nationality"].ToString();
                imgCandidate.Src = CandidateDS.Tables[0].Rows[0]["PicPath"].ToString();
                str1 = CandidateDS.Tables[0].Rows[0]["Is_Staff"].ToString();
                imgBigImage.Src = CandidateDS.Tables[0].Rows[0]["PicPath"].ToString();
                lblTotalExp.Text = CandidateDS.Tables[0].Rows[0]["TotalExp"].ToString();
                ABigImage.Attributes.Add("data-rel", CandidateDS.Tables[0].Rows[0]["PicPath"].ToString());
            }
            if (CandidateDS.Tables.Count >= 4 && CandidateDS.Tables[3].Rows.Count > 0)
            {
                SpDomain.InnerText = CandidateDS.Tables[3].Rows[0]["Domain_name"].ToString();
                SpSubDomain.InnerText = CandidateDS.Tables[3].Rows[0]["SubDomain_Name"].ToString();
                SpJoiningDate.InnerText = CandidateDS.Tables[3].Rows[0]["Joining_Date"].ToString() + "  " + CandidateDS.Tables[3].Rows[0]["Scheduling_Joining_Time"].ToString();
                SpDesignation.InnerText = CandidateDS.Tables[3].Rows[0]["Designation_Name"].ToString();
                SpGrade.InnerText = CandidateDS.Tables[3].Rows[0]["Grade_Name"].ToString();
                CandidateDS.Tables[3].Rows[0]["TestCode"].ToString();
                str2 = CandidateDS.Tables[3].Rows[0]["IsStaffDomain"].ToString();
            }
            if (CandidateDS.Tables.Count >= 2)
            {
                if (CandidateDS.Tables[1].Rows.Count > 0)
                {
                    rptExperience.DataSource = CandidateDS.Tables[1];
                    rptExperience.DataBind();
                    lblinfoExp.Visible = false;
                }
                else
                {
                    lblinfoExp.Visible = true;
                    rptExperience.DataSource = null;
                    rptExperience.DataBind();
                }
            }
            if (CandidateDS.Tables.Count >= 3)
            {
                DataView dataView1 = new DataView(CandidateDS.Tables[2]);
                dataView1.RowFilter = "Program_Code <> 7 and Program_Code <> 6";
                if (dataView1.Count > 0)
                {
                    lblinfoEdu.Visible = false;
                    rptEducation.DataSource = dataView1;
                    rptEducation.DataBind();
                }
                else
                {
                    lblinfoEdu.Visible = true;
                    rptEducation.DataSource = null;
                    rptEducation.DataBind();
                }
                DataView dataView2 = new DataView(CandidateDS.Tables[2]);
                dataView2.RowFilter = "Program_Code =6";
                if (dataView2.Count > 0)
                {
                    lblinfoDiploma.Visible = false;
                    rptDiploma.DataSource = dataView2;
                    rptDiploma.DataBind();
                }
                else
                {
                    lblinfoDiploma.Visible = true;
                    rptDiploma.DataSource = null;
                    rptDiploma.DataBind();
                }
                DataView dataView3 = new DataView(CandidateDS.Tables[2]);
                dataView3.RowFilter = "Program_Code =7";
                if (dataView3.Count > 0)
                {
                    lblinfoCertificate.Visible = false;
                    rptCertificate.DataSource = dataView3;
                    rptCertificate.DataBind();
                }
                else
                {
                    lblinfoCertificate.Visible = true;
                    rptCertificate.DataSource = null;
                    rptCertificate.DataBind();
                }
            }
            if (CandidateDS.Tables.Count >= 5)
            {
                if (CandidateDS.Tables[4].Rows.Count > 0)
                {
                    rptPortfolioFiles.DataSource = CandidateDS.Tables[4];
                    rptPortfolioFiles.DataBind();
                    lblPortFiles.Visible = false;
                }
                else
                {
                    rptPortfolioFiles.DataSource = null;
                    rptPortfolioFiles.DataBind();
                    lblPortFiles.Visible = true;
                }
            }
            if (CandidateDS.Tables.Count >= 6)
            {
                if (CandidateDS.Tables[5].Rows.Count > 0)
                {
                    rptPortfolioUrl.DataSource = CandidateDS.Tables[5];
                    rptPortfolioUrl.DataBind();
                    lblPortURL.Visible = false;
                }
                else
                {
                    lblPortURL.Visible = true;
                    rptPortfolioUrl.DataSource = null;
                    rptPortfolioUrl.DataBind();
                }
            }
            if (str1 == "1" || str2 == "True")
                imgStaff.Visible = true;
            else
                imgStaff.Visible = false;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void Btn_SearchByRefno(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtRefNo.Text))
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            DataTable dataTable = new DataTable();
            using (SqlCommand selectCommand = new SqlCommand("dbo.xrec_Select_etIDByRefNo", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add(new SqlParameter("@RefNo", txtRefNo.Text));
                new SqlDataAdapter(selectCommand).Fill(dataTable);
            }
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            if (dataTable == null)
                return;
            if (dataTable.Rows.Count > 0)
            {
                CandidateCode = dataTable.Rows[0]["candidate_code"].ToString();
                Page.RegisterStartupScript("REFRESHpAGESCRIPT", "<script language=JavaScript>window.location='" + ("/A2/Candidate/TrainingUserCanDetail.aspx?data=" + new SecureQueryString().encrypt("CID=" + CandidateCode)) + "';</script>");
            }
            else
                Page.RegisterStartupScript("REFRESHpAGESCRIPT11", "<script language=JavaScript>alert('No candidate found.');</script>");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void RptExperienence_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            DataRowView dataItem = (DataRowView)e.Item.DataItem;
            HtmlGenericControl control1 = (HtmlGenericControl)e.Item.FindControl("SpBenefit");
            HtmlGenericControl control2 = (HtmlGenericControl)e.Item.FindControl("SpCashAll");
            HtmlGenericControl control3 = (HtmlGenericControl)e.Item.FindControl("SpLifeStyle");
            HtmlGenericControl control4 = (HtmlGenericControl)e.Item.FindControl("SPOffDays");
            control1.InnerHtml = "<ul class=\"blueblocks\">" + dataItem["benefits"].ToString().Replace("&lt;", "<").Replace("&gt;", ">") + "</ul>";
            control2.InnerHtml = "<ul class=\"blueblocks\">" + dataItem["benefitsCA"].ToString().Replace("&lt;", "<").Replace("&gt;", ">") + "</ul>";
            control3.InnerHtml = "<ul class=\"blueblocks\">" + dataItem["benefitsLS"].ToString().Replace("&lt;", "<").Replace("&gt;", ">") + "</ul>";
            control4.InnerHtml = "<ul class=\"blueblocks\">" + dataItem["benefitsOD"].ToString().Replace("&lt;", "<").Replace("&gt;", ">") + "</ul>";
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }
}