using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;
using ErrorLog;
using XRecruitmentStatusLibrary;

public partial class addEditProfileParameterNew : CustomBasePage
{


    #region Page Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    public static string CID;
    #endregion Page Variables

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand selectCommand1 = new SqlCommand("XRec_SelectProfile", connection);
            selectCommand1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(selectCommand1);
            DataTable dataTable1 = new DataTable();
            sqlDataAdapter1.Fill(dataTable1);
            ddlprofile.DataSource = dataTable1;
            ddlprofile.DataTextField = "Profile_name";
            ddlprofile.DataValueField = "profile_code";
            ddlprofile.DataBind();
            ddlprofile.Items.Insert(0, new ListItem("--Select Profile--", "-1"));
            connection.Close();
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand selectCommand2 = new SqlCommand("Xrec_SelectOGExperience", connection);
            selectCommand2.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
            DataTable dataTable2 = new DataTable();
            sqlDataAdapter2.Fill(dataTable2);
            ddlExperience.DataSource = dataTable2;
            ddlExperience.DataTextField = "Experience";
            ddlExperience.DataValueField = "Experience_Code";
            ddlExperience.DataBind();
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, addEditProfileParameterNew.CID);
        }
    }

    protected void btnAddSkill_Click(object sender, EventArgs e)
    {
    }

    protected void btnAddInstitute_Click(object sender, EventArgs e)
    {
    }

    protected void btnIndustryAdd_Click(object sender, EventArgs e)
    {
    }

    protected void btnComapanyAdd_Click(object sender, EventArgs e)
    {
    }

    protected void btnDegreeAdd_Click(object sender, EventArgs e)
    {
    }

    protected void btnMajorAdd_Click(object sender, EventArgs e)
    {
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
    }

    public void getRecordsFroScreen()
    {
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
    }

    protected void ddlProfile_SelectedIndexChanged(object sender, EventArgs e)
    {
        getprofileData();
    }

    protected void btnSaveAll_Click(object sender, EventArgs e)
    {
        string empty1 = string.Empty;
        string empty2 = string.Empty;
        string empty3 = string.Empty;
        string empty4 = string.Empty;
        string empty5 = string.Empty;
        if (Request["txtSkill"] != null)
            empty1 = Request.Form["txtSkill"].ToString();
        if (Request["txtCompany"] != null)
            empty2 = Request.Form["txtCompany"].ToString();
        if (Request["txtDegree"] != null)
            empty3 = Request.Form["txtDegree"].ToString();
        if (Request["txtMajors"] != null)
            empty4 = Request.Form["txtMajors"].ToString();
        if (Request["txtInstitute"] != null)
            empty5 = Request.Form["txtInstitute"].ToString();
        SaveInputRecord(empty1, 5);
        SaveRecord(rptskill, "5");
        SaveInputRecord(empty3, 1);
        SaveRecord(rptDegree, "1");
        SaveInputRecord(empty5, 4);
        SaveRecord(rptInstitute, "4");
        SaveInputRecord(empty2, 7);
        SaveRecord(rptCompany, "7");
        SaveInputRecord(empty4, 3);
        SaveRecord(rptMajor, "3");
        if (connection.State != ConnectionState.Open)
            connection.Open();
        SqlCommand sqlCommand = new SqlCommand("Xrec_UpdateProfileparameterExperience", connection);
        sqlCommand.Parameters.AddWithValue("@Experience_Code ", ddlExperience.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@Profile_Code ", ddlprofile.SelectedValue);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.ExecuteNonQuery();
        connection.Close();
        getprofileData();
        lblmessage.Text = "Record(s) has been save sucessfully..!!!";
    }

    public void getprofileData()
    {
        lblmessage.Text = "";
        if (connection.State != ConnectionState.Open)
            connection.Open();
        SqlCommand selectCommand = new SqlCommand("Xrec_Select_ProfileAllPArameter", connection);
        selectCommand.Parameters.AddWithValue("@profileCode", ddlprofile.SelectedValue);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        SetCHkboxOnProfileChange(chkInstituteSave, dataSet.Tables[2]);
        if (dataSet.Tables[2].Rows.Count > 0)
        {
            rptInstitute.DataSource = dataSet.Tables[2];
            rptInstitute.DataBind();
        }
        else
        {
            rptInstitute.DataSource = null;
            rptInstitute.DataBind();
        }
        SetCHkboxOnProfileChange(chkDegreeSave, dataSet.Tables[0]);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            rptDegree.DataSource = dataSet.Tables[0];
            rptDegree.DataBind();
        }
        else
        {
            rptDegree.DataSource = null;
            rptDegree.DataBind();
        }
        SetCHkboxOnProfileChange(chkIndustrySave, dataSet.Tables[4]);
        if (dataSet.Tables[4].Rows.Count > 0)
        {
            rptIndustry.DataSource = dataSet.Tables[4];
            rptIndustry.DataBind();
        }
        else
        {
            rptIndustry.DataSource = null;
            rptIndustry.DataBind();
        }
        SetCHkboxOnProfileChange(chkSkillSave, dataSet.Tables[3]);
        if (dataSet.Tables[3].Rows.Count > 0)
        {
            rptskill.DataSource = dataSet.Tables[3];
            rptskill.DataBind();
        }
        else
        {
            rptskill.DataSource = null;
            rptskill.DataBind();
        }
        SetCHkboxOnProfileChange(chkMajorSave, dataSet.Tables[1]);
        if (dataSet.Tables[1].Rows.Count > 0)
        {
            rptMajor.DataSource = dataSet.Tables[1];
            rptMajor.DataBind();
        }
        else
        {
            rptMajor.DataSource = null;
            rptMajor.DataBind();
        }
        SetCHkboxOnProfileChange(chkCompanySave, dataSet.Tables[5]);
        if (dataSet.Tables[5].Rows.Count > 0)
        {
            rptCompany.DataSource = dataSet.Tables[5];
            rptCompany.DataBind();
        }
        else
        {
            rptCompany.DataSource = dataSet.Tables[5];
            rptCompany.DataBind();
        }
        if (dataSet.Tables[6].Rows.Count > 0)
            ddlExperience.SelectedIndex = Convert.ToInt32(dataSet.Tables[6].Rows[0]["Experience_Code"]) - 1;
        else
            ddlExperience.SelectedIndex = 0;
    }

    public void SaveRecords(HiddenField hdnName, HiddenField hdnCode, HiddenField hdnMandatory, CheckBoxList chkSave, Repeater rpt, TextBox txtac)
    {
        try
        {
            if (hdnName.Value.ToString() != "")
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Name");
                dataTable.Columns.Add("Code");
                dataTable.Columns.Add("Ismandatory");
                bool enabled = !(hdnMandatory.Value == "false");
                chkSave.Items.Add(new ListItem(hdnName.Value.ToString(), hdnCode.Value.ToString(), enabled)
                {
                    Selected = true
                });
                foreach (ListItem listItem in chkSave.Items)
                {
                    string str = listItem.Enabled ? "true" : "false";
                    DataRow row = dataTable.NewRow();
                    row["Code"] = listItem.Value;
                    row["Name"] = listItem.Text;
                    row["Ismandatory"] = str;
                    dataTable.Rows.Add(row);
                }
                rpt.DataSource = dataTable;
                rpt.DataBind();
                hdnCode.Value = (string)null;
                hdnName.Value = (string)null;
                hdnMandatory.Value = (string)null;
                txtac.Text = "";
                txtac.Focus();
            }
            else
            {
                txtac.Text = "";
                txtac.Focus();
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, addEditProfileParameterNew.CID);
        }
    }

    private void showRecord(Label txt, Repeater rpt)
    {
        string str = string.Empty;
        foreach (Control control1 in rpt.Items)
        {
            Label control2 = (Label)control1.FindControl("lbl");
            str = str + "-------" + control2.Text;
        }
        txt.Text = str;
    }

    public void SaveRecord(Repeater rpt, string parameterID)
    {
        string empty = string.Empty;
        foreach (RepeaterItem repeaterItem in rpt.Items)
        {
            CheckBox control1 = (CheckBox)repeaterItem.FindControl("ckhEnable");
            HiddenField control2 = (HiddenField)repeaterItem.FindControl("hdnParameterValue");
            CheckBox control3 = (CheckBox)repeaterItem.FindControl("chkMandatory");
            if (control1 != null && control3 != null && control2 != null)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand sqlCommand = new SqlCommand("Xrec_UpdateProfileparameter", connection);
                sqlCommand.Parameters.AddWithValue("@profile_code ", ddlprofile.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@parameter_code", parameterID);
                sqlCommand.Parameters.AddWithValue("@parameterValue_code", control2.Value);
                if (control1.Checked)
                    sqlCommand.Parameters.AddWithValue("@chkEnable", "true");
                else
                    sqlCommand.Parameters.AddWithValue("@chkEnable", "false");
                if (control3.Checked)
                    sqlCommand.Parameters.AddWithValue("@isMandatory", 1);
                else
                    sqlCommand.Parameters.AddWithValue("@isMandatory", 0);
                sqlCommand.Parameters.AddWithValue("@is_active", 1);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }
    }

    public void SaveInputRecord(string ParametersName, int parameterID)
    {
        string str1 = ParametersName;
        char[] chArray = new char[1] { ',' };
        foreach (string str2 in str1.Split(chArray))
        {
            if (str2 != "" && str2 != null)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand sqlCommand = new SqlCommand("Xrec_UpdateProfileparameter", connection);
                sqlCommand.Parameters.AddWithValue("@profile_code ", ddlprofile.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@parameter_code", parameterID);
                sqlCommand.Parameters.AddWithValue("@parameterValue_code", str2);
                sqlCommand.Parameters.AddWithValue("@chkEnable", "true");
                sqlCommand.Parameters.AddWithValue("@isMandatory", 0);
                sqlCommand.Parameters.AddWithValue("@is_active", 1);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }
    }

    public void SetCHkboxOnProfileChange(CheckBoxList chk, DataTable ds)
    {
        chk.Items.Clear();
        if (ds.Rows.Count <= 0)
            return;
        foreach (DataRow row in (InternalDataCollectionBase)ds.Rows)
        {
            bool enabled = row["Ismandatory"] != "false";
            chk.Items.Add(new ListItem(row["Name"].ToString(), row["Code"].ToString(), enabled)
            {
                Selected = true
            });
        }
    }
    #endregion

}