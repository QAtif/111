using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ErrorLog;



public partial class CandidateWelcome : XRecBase
{
    protected int TestCode = 0;
    protected int CandidateCode = 0;



    protected void Page_Load(object sender, EventArgs e)
    {
        try
      
        {
            if (Request.QueryString != null && Request.QueryString["tid"] != null && (Request.QueryString != null && Request.QueryString["tid"] != null))
            {
                if (Request.QueryString["tid"].ToString() != "")
                    TestCode = Convert.ToInt32(Request.QueryString["tid"].ToString());
                if (Request.Cookies["CC"] != null)
                    CandidateCode =Convert.ToInt32(Request.Cookies["CC"].Value.ToString());
            }
            if (IsPostBack)
                return;
           ShowData();
        }

        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAssessment, ex.StackTrace, ex, UserID.ToString());
        }

    }
    public void ShowData()
    {
        lblPhase1.Visible = false;
        lblGeneralIQ.Visible = false;
        tblIQ.Visible = false;
        lblPhase2.Visible = false;
        lblGeneralTest.Visible = false;
        tblIQ.Visible = false;

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);
        string empty = string.Empty;
        try
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand selectCommand = new SqlCommand("XREC_SELECT_TestInstructions", connection);
            selectCommand.Parameters.AddWithValue("@TestCode", TestCode);
            selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet == null)
                return;
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                lblCategoryName.Text = dataSet.Tables[0].Rows[0]["Category_Title"].ToString();
                lblHours.Text = dataSet.Tables[0].Rows[0]["Test_Duration"].ToString();
            }
            if (dataSet.Tables[1].Rows.Count > 0)
            {
                rptSection.DataSource = dataSet.Tables[1];
                rptSection.DataBind();
            }
            if (dataSet.Tables[3].Rows.Count > 0)
            { 
               DataTable dt = new DataTable();
               dt = dataSet.Tables[3];

               string searchIQ = "SectionCode = 2";
               DataRow[] foundRow = dt.Select(searchIQ);

               if (foundRow.Length != 0) 
               {
                   lblPhase1.Visible = true;
                   lblGeneralIQ.Visible = true;
                   tblIQ.Visible = true;
               }

               string searchTest = "SectionCode = 6";
               DataRow[] foundRow1 = dt.Select(searchTest);
               if (foundRow1.Length != 0 )
               {
                   lblPhase2.Visible = true;
                   lblGeneralTest.Visible = true;

                   if (foundRow.Length == 0 )
                      testphase.InnerText = "I";
                   else
                       testphase.InnerText = "II";
                  
               }


            }


            if (dataSet.Tables[2].Rows.Count <= 0)
                return;
            lblName.Text = dataSet.Tables[2].Rows[0]["Full_Name"].ToString();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAssessment, ex.StackTrace, ex, UserID.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            HttpContext.Current.Response.Redirect("/CandidateTest/CandidateTest.aspx?tid=" + TestCode, false);

        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAssessment, ex.StackTrace, ex, UserID.ToString());
        }

    }



}