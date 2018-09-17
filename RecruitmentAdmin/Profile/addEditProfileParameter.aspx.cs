
using ErrorLog;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addEditProfileParameter : CustomBasePage
{


    #region Page Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    public string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
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
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, addEditProfileParameter.CID);
        }
    }

    protected void btnAddSkill_Click(object sender, EventArgs e)
    {
        SaveRecords(hdnSkillName, hdnSkillCode, hdnSkillM, chkSkillSave, rptskill, txtacSkill);
    }

    protected void btnAddInstitute_Click(object sender, EventArgs e)
    {
        SaveRecords(hdnInstituteName, hdnInstituteCode, hdnInstituteM, chkInstituteSave, rptInstitute, txtacInstitute);
    }

    protected void btnIndustryAdd_Click(object sender, EventArgs e)
    {
        SaveRecords(hdnIndustryName, hdnIndustryCode, hdnIndustryMandatory, chkIndustrySave, rptIndustry, txtacIndustry);
    }

    protected void btnComapanyAdd_Click(object sender, EventArgs e)
    {
        SaveRecords(hdnComapanyName, hdnComapanyCode, hdnComapanyMandatory, chkCompanySave, rptCompany, txtacComapany);
    }

    protected void btnDegreeAdd_Click(object sender, EventArgs e)
    {
        SaveRecords(hdnDegreeName, hdnDegreeCode, hdnDegreeMandatory, chkDegreeSave, rptDegree, txtacDegree);
    }

    protected void btnMajorAdd_Click(object sender, EventArgs e)
    {
        SaveRecords(hdnMajorName, hdnMajorCode, hdnMajorMandatory, chkMajorSave, rptMajor, txtacMajor);
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
        SaveRecord(rptskill, "5");
        SaveRecord(rptDegree, "1");
        SaveRecord(rptInstitute, "4");
        SaveRecord(rptCompany, "7");
        SaveRecord(rptIndustry, "6");
        SaveRecord(rptMajor, "3");
        if (connection.State != ConnectionState.Open)
            connection.Open();
        SqlCommand sqlCommand = new SqlCommand("Xrec_UpdateProfileparameterExperience", connection);
        sqlCommand.Parameters.AddWithValue("@Experience_Code ", ddlExperience.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@Profile_Code ", ddlprofile.SelectedValue);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.ExecuteNonQuery();
        connection.Close();
        ddlprofile.SelectedIndex = -1;
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
        rptInstitute.DataSource = dataSet.Tables[2];
        rptInstitute.DataBind();
        SetCHkboxOnProfileChange(chkDegreeSave, dataSet.Tables[0]);
        rptDegree.DataSource = dataSet.Tables[0];
        rptDegree.DataBind();
        SetCHkboxOnProfileChange(chkIndustrySave, dataSet.Tables[4]);
        rptIndustry.DataSource = dataSet.Tables[4];
        rptIndustry.DataBind();
        SetCHkboxOnProfileChange(chkSkillSave, dataSet.Tables[3]);
        rptskill.DataSource = dataSet.Tables[3];
        rptskill.DataBind();
        SetCHkboxOnProfileChange(chkMajorSave, dataSet.Tables[1]);
        rptMajor.DataSource = dataSet.Tables[1];
        rptMajor.DataBind();
        SetCHkboxOnProfileChange(chkCompanySave, dataSet.Tables[5]);
        rptCompany.DataSource = dataSet.Tables[5];
        rptCompany.DataBind();
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
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, addEditProfileParameter.CID);
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