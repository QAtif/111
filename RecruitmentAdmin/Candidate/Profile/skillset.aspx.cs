
using ErrorLog;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using XRecruitmentStatusLibrary;

public partial class Candidate_Profile_skillset : CustomBasePage, IRequiresSessionState
{

    private string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    private SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString());
    public string skillsListHTML = string.Empty;
    private string QueryStringVar = string.Empty;
    public static string CID;
    private SecureQueryString secQueryString;
    protected void Page_Load(object sender, EventArgs e)
    {
        QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
        if (QueryStringVar == null)
            return;
        secQueryString = new SecureQueryString(QueryStringVar);
        if (secQueryString["CID"] == null)
            return;
        Candidate_Profile_skillset.CID = secQueryString["CID"].ToString();
        try
        {
            if (IsPostBack)
                return;
            try
            {
                hdnSkillList.Value = string.Empty;
                hdnSkillListName.Value = string.Empty;
                LoadCandidateSkills();
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_skillset.CID);
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_skillset.CID);
        }
    }

    protected void btnAddSkill_Click(object sender, EventArgs e)
    {
        SaveRecords(hdnSkillName, hdnSkillCode, chkSkills, rptskill, txtacSkill);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
        try
        {
            connection.Open();
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            int num = 0;
            hdnSkillList.Value = hdnSkillList.Value.TrimStart('|');
            string[] strArray1 = hdnSkillList.Value.Split('|');
            hdnSkillListName.Value = hdnSkillListName.Value.TrimStart('|');
            string[] strArray2 = hdnSkillListName.Value.Split('|');
            SqlCommand sqlCommand1 = new SqlCommand("XRec_UpdateCandidateSkillIsActiveNull", connection);
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            sqlCommand1.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_skillset.CID));
            sqlCommand1.Parameters.AddWithValue("@UpdatedBy", UserCode);
            sqlCommand1.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
            sqlCommand1.ExecuteNonQuery();
            for (int index = 0; index <= strArray1.Length - 1; ++index)
            {
                if (strArray1[index].ToString() != string.Empty)
                {
                    ++num;
                    SqlCommand sqlCommand2 = new SqlCommand("XRec_InsertCandidateSkills", connection);
                    sqlCommand2.CommandType = CommandType.StoredProcedure;
                    sqlCommand2.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_skillset.CID));
                    sqlCommand2.Parameters.AddWithValue("@SkillCode", strArray1[index]);
                    sqlCommand2.Parameters.AddWithValue("@SkillName", strArray2[index]);
                    sqlCommand2.Parameters.AddWithValue("@UpdatedBy", UserCode);
                    sqlCommand2.Parameters.AddWithValue("@UpdatedIP", Request.UserHostAddress);
                    sqlCommand2.ExecuteNonQuery();
                }
            }
            hdnSkillList.Value = string.Empty;
            hdnSkillListName.Value = string.Empty;
            StatusManagement.MarkProfileStatus(c, Convert.ToInt32(Candidate_Profile_skillset.CID), Constants.ModuleCode.ProfileStatus, Constants.CandidateProfileStatus.MarkedSkillSetPortfolioPending, Request.UserHostAddress, UserCode, Constants.ProfileNavigation.SkillSet);
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "refreshParent();", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_skillset.CID);
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    private void LoadCandidateSkills()
    {
        try
        {
            DataSet dataSet = new DataSet();
            if (c.State != ConnectionState.Open)
                c.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateSkill", c))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_skillset.CID));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet == null || dataSet.Tables == null || dataSet.Tables[0].Rows.Count <= 0)
                return;
            for (int index = 0; index < dataSet.Tables[0].Rows.Count; ++index)
            {
                string s = dataSet.Tables[0].Rows[index]["Skill_Code"].ToString();
                string str1 = dataSet.Tables[0].Rows[index]["Skill"].ToString();
                //HiddenField hdnSkillList = hdnSkillList;
                string str2 = hdnSkillList.Value + "|" + s;
                hdnSkillList.Value = str2;
                //HiddenField hdnSkillListName = hdnSkillListName;
                string str3 = hdnSkillListName.Value + "|" + str1;
                hdnSkillListName.Value = str3;
                string str4 = "'" + str1 + "'";
                string str5 = int.Parse(s).ToString() + "|" + str4;
                Candidate_Profile_skillset profileSkillset = this;
                string str6 = profileSkillset.skillsListHTML + "<span class=\"taglinks\" runat=\"server\"><span>" + str1 + "</span><a id=\"lnkEdit\" style=\"cusror: pointer;\" onclick=\"RemoveSkill(this," + str5 + ");\"></a></span>";
                profileSkillset.skillsListHTML = str6;
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_skillset.CID);
        }
    }

    public void SaveRecords(HiddenField hdnName, HiddenField hdnCode, CheckBoxList chkSave, Repeater rpt, TextBox txtac)
    {
        try
        {
            if (hdnName.Value.ToString() != "")
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Name");
                dataTable.Columns.Add("Code");
                chkSave.Items.Add(new ListItem(hdnName.Value.ToString(), hdnCode.Value.ToString())
                {
                    Selected = true
                });
                foreach (ListItem listItem in chkSave.Items)
                {
                    DataRow row = dataTable.NewRow();
                    row["Code"] = listItem.Value;
                    row["Name"] = listItem.Text;
                    dataTable.Rows.Add(row);
                }
                rpt.DataSource = dataTable;
                rpt.DataBind();
                hdnCode.Value = (string)null;
                hdnName.Value = (string)null;
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
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_skillset.CID);
        }
    }

    protected void Repeater_itemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Code");
            if (!(e.CommandName == "Delete"))
                return;
            foreach (ListItem listItem in chkSkills.Items)
            {
                if (listItem.Value.ToString() == e.CommandArgument.ToString())
                {
                    chkSkills.Items.Remove(listItem);
                    break;
                }
            }
            foreach (ListItem listItem in chkSkills.Items)
            {
                DataRow row = dataTable.NewRow();
                row["Code"] = listItem.Value;
                row["Name"] = listItem.Text;
                dataTable.Rows.Add(row);
            }
            rptskill.DataSource = dataTable;
            rptskill.DataBind();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_skillset.CID);
        }
    }

    [ScriptMethod]
    [WebMethod]
    public static void TestMethod(string pra)
    {
        ((ListControl)(HttpContext.Current.Handler as Page).FindControl("chkSkills")).Items[0].Text.ToString();
    }
}