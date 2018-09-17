using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using ErrorLog;

public partial class Existing_SubmittedPerInfoList2 : System.Web.UI.Page
{
    #region Variables
    protected string t_only = string.Empty;
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentLiveEConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    #endregion

    #region Events    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            try
            {
                txtdtFrom.Text = "01/01/2005";
                txtdtTo.Text = DateTime.Now.ToString("MM/dd/yyyy");


                CheckQS();
                connection.Open();
                GetFilterData(ref connection);
                FillSelected();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }
    }
    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            try
            {
                Label lblSno = (Label)e.Item.FindControl("lblSno");
                lblSno.Text = Convert.ToString((e.Item.ItemIndex + 1));
                Label lblCell = (Label)e.Item.FindControl("lblCell");
                if ((DataBinder.Eval(e.Item.DataItem, "CELL_PHONE").ToString() != ""))
                {
                    lblCell.Text = "<br>Cell:&nbsp;" + DataBinder.Eval(e.Item.DataItem, "CELL_PHONE").ToString();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            }            
        }
    }
    protected void submit1_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand("Xweb_Select_CandidatesInfo", connection);
            sqlCommand.Parameters.AddWithValue("@categorycode", category.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@Statuscode", StatusCode.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@MajorcodeCSV", Majors.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@InstitutecodeCSV", Institute.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@QualificationcodeCSV", Qualification.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@GenderCode", Gender.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@AgeL", AgeL.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@AgeG", AgeG.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@Priority1", Priority1.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@Priority2", Priority2.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@ExperienceYear", Experience.SelectedValue);
            // sqlCommand.Parameters.AddWithValue("@ForeignStudyCountry", Fore);

            sqlCommand.Parameters.AddWithValue("@certification", certification.Text);

            sqlCommand.Parameters.AddWithValue("@txthearabout", hearabout.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@matricPerc", matricPerc.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@OLevelA", OLevelA.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@interPerc", interPerc.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@ALevelA", ALevelA.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@graduationPerc", graduationPerc.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@graduationGPA", graduationGPA.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@masterPerc", masterPerc.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@masterGPA", masterGPA.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@DateFrom", txtdtFrom.Text);
            sqlCommand.Parameters.AddWithValue("@DateTo", txtdtTo.Text);

            if (ReferredBy.Text != "")
                sqlCommand.Parameters.AddWithValue("@ReferredBy", ReferredBy.Text);
            // sqlCommand.Parameters.AddWithValue("@CurrentlyStudying", cboCurrentlyStuding.ch);

            //  sqlCommand.Parameters.AddWithValue("@FOREIGN_QUALIFICATION", cboForeignQualification);
            // sqlCommand.Parameters.AddWithValue("@teststatus", Request.UserHostAddress.ToString());

            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                rptData.DataSource = ds;
                rptData.DataBind();
            }


        }
        catch (Exception ex)
        {
            ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }
    #endregion

    #region Metods
    private void FillSelected()
    {
        if (CategoryCode.Value != "" && CategoryCode.Value != "0")
            category.SelectedValue = CategoryCode.Value;

      //  ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "MyJSFunction", "showSkill2();", true);        
    }
    private void CheckQS()
    {
        if (Session["User_Code"] != null && Session["User_Code"] != "")
        {
            UserCode.Value = Convert.ToString(Session["User_Code"]);
        }
        else
        {
            UserCode.Value = "1";
        }

        if (Request["jPost"] != null && Request["jPost"] != "")
        {
            jPost.Value = Request["jPost"];
        }
        if (Request["Category"] != null && Request["Category"] != "")
        {
            CategoryCode.Value = Request["Category"];
            if (Request["Category"] == "24" && Request["Category"] != "4")
            {
                t_only = "Test Only";
                test.Visible = false;
            }
            else
            {
                test.Visible = false;
            }
        }
    }
    public void GetFilterData(ref SqlConnection connection)
    {
        SqlCommand sqlCommand = new SqlCommand("Xweb_Select_Status", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        DataSet ds = new DataSet();
        adapter.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            StatusCode.DataSource = ds;
            StatusCode.DataTextField = "STATUS";
            StatusCode.DataValueField = "STATUS_CODE";
            StatusCode.DataBind();
        }

        SqlCommand sqlCommandCat = new SqlCommand("Xweb_Select_Category", connection);
        sqlCommandCat.Parameters.AddWithValue("@job_posting", jPost.Value);
        sqlCommandCat.Parameters.AddWithValue("@User_Code", UserCode.Value);
        sqlCommandCat.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adapterCat = new SqlDataAdapter(sqlCommandCat);
        DataSet dsCat = new DataSet();
        adapterCat.Fill(dsCat);

        if (dsCat.Tables[0].Rows.Count > 0)
        {
            category.DataSource = dsCat;
            category.DataTextField = "CAT_DESC";
            category.DataValueField = "CAT_CODE";
            category.DataBind();

            category.Items.Insert(0, new ListItem("----------- Select Category -----------", ""));
        }


        SqlCommand sqlCommandInstitute = new SqlCommand("Xweb_Select_Institute", connection);
        sqlCommandInstitute.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adapterInstitute = new SqlDataAdapter(sqlCommandInstitute);
        DataSet dsInstitute = new DataSet();
        adapterInstitute.Fill(dsInstitute);

        if (dsInstitute.Tables[0].Rows.Count > 0)
        {
            Institute.DataSource = dsInstitute;
            Institute.DataTextField = "InstituteName";
            Institute.DataValueField = "InstituteID";
            Institute.DataBind();

            Institute.Items.Insert(0, new ListItem("Show All", "-1"));
        }


        SqlCommand sqlCommandDegree = new SqlCommand("Xweb_Select_Degree", connection);
        sqlCommandDegree.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adapterDegree = new SqlDataAdapter(sqlCommandDegree);
        DataSet dsDegree = new DataSet();
        adapterDegree.Fill(dsDegree);

        if (dsDegree.Tables[0].Rows.Count > 0)
        {
            Qualification.DataSource = dsDegree;
            Qualification.DataTextField = "DegreeName";
            Qualification.DataValueField = "DegreeID";
            Qualification.DataBind();

            Qualification.Items.Insert(0, new ListItem("Show All", "-1"));
        }


        SqlCommand sqlCommandMajor = new SqlCommand("Xweb_Select_Majors", connection);
        sqlCommandMajor.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adapterMajor = new SqlDataAdapter(sqlCommandMajor);
        DataSet dsMajor = new DataSet();
        adapterMajor.Fill(dsMajor);

        if (dsMajor.Tables[0].Rows.Count > 0)
        {
            Majors.DataSource = dsMajor;
            Majors.DataTextField = "MajorsName";
            Majors.DataValueField = "MajorsID";
            Majors.DataBind();

            Majors.Items.Insert(0, new ListItem("Show All", "-1"));
        }



        OLevelA.Items.Clear();
        for (int i = 12; i >= 0; i--)
        {
            if (i < 12)
                OLevelA.Items.Add(new ListItem(i.ToString() + "+", i.ToString()));
            else
                OLevelA.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }

        OLevelA.Items.Insert(0, new ListItem("Select", "0"));



        ALevelA.Items.Clear();
        for (int i = 12; i >= 0; i--)
        {
            if (i < 12)
                ALevelA.Items.Add(new ListItem(i.ToString() + "+", i.ToString()));
            else
                ALevelA.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }

        ALevelA.Items.Insert(0, new ListItem("Select", "0"));


    }
    #endregion

}
