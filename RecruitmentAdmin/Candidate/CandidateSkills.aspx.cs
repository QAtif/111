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

public partial class CandidateSkills : CustomBasePage
{

    #region Page Variables
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    public static string CID;
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;
    #endregion Page Variables

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
        if (QueryStringVar == null)
            return;
        secQueryString = new SecureQueryString(QueryStringVar);
        if (secQueryString["CID"] == null)
            return;
        CandidateSkills.CID = secQueryString["CID"].ToString();
        try
        {
            if (IsPostBack)
                return;
            LoadCandidateSkills();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateSkills.CID);
        }
    }

    protected void btnAddSkill_Click(object sender, EventArgs e)
    {
        try
        {
            bool AlreadyPresent = false;
            if (hfSkillName.Value.ToString() != "")
            {
                AddSkillList(AlreadyPresent);
            }
            else
            {
                if (txtacSkill.Text != "")
                    AddSkillList(AlreadyPresent);
                txtacSkill.Text = "";
                txtacSkill.Focus();
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateSkills.CID);
        }
    }

    private void AddSkillList(bool AlreadyPresent)
    {
        ListItem listItem1 = new ListItem();
        if (hfSkillName.Value.ToString() != "")
        {
            listItem1.Text = hfSkillName.Value.ToString();
            listItem1.Value = hfSkillCode.Value.ToString();
        }
        else
        {
            listItem1.Text = txtacSkill.Text;
            listItem1.Value = "0";
        }
        listItem1.Selected = true;
        foreach (ListItem listItem2 in chkSkills.Items)
        {
            if (listItem2.Value == listItem1.Value && listItem2.Text == listItem1.Text)
            {
                AlreadyPresent = true;
                break;
            }
        }
        if (!AlreadyPresent)
            chkSkills.Items.Add(listItem1);
        hfSkillCode.Value = (string)null;
        hfSkillName.Value = (string)null;
        txtacSkill.Text = "";
        txtacSkill.Focus();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtacSkill.Text != "")
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
                {
                    connection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateSkills", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(CandidateSkills.CID));
                        sqlCommand.Parameters.AddWithValue("@SkillCode", 0);
                        sqlCommand.Parameters.AddWithValue("@Chked", 1);
                        sqlCommand.Parameters.AddWithValue("@SkillText", txtacSkill.Text);
                        sqlCommand.Parameters.AddWithValue("@UpdatedBy", Convert.ToInt32(UserCode));
                        sqlCommand.Parameters.AddWithValue("@UpdatedIP", Request.UserHostAddress);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            foreach (ListItem listItem in chkSkills.Items)
            {
                int num = !listItem.Selected ? 0 : 1;
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
                {
                    connection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateSkills", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add(new SqlParameter("@CandidateCode", Convert.ToInt32(CandidateSkills.CID)));
                        sqlCommand.Parameters.Add(new SqlParameter("@SkillCode", listItem.Value.ToString()));
                        sqlCommand.Parameters.AddWithValue("@SkillText", listItem.Text.ToString());
                        sqlCommand.Parameters.Add(new SqlParameter("@Chked", num));
                        sqlCommand.Parameters.Add(new SqlParameter("@UpdatedBy", Convert.ToInt32(CandidateSkills.CID)));
                        sqlCommand.Parameters.Add(new SqlParameter("@UpdatedIP", Request.UserHostAddress));
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString());
            sqlConnection.Open();
            if (sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
            Page.RegisterStartupScript("Close", "<script language=JavaScript> CloseHighSlideWithParentRefresh();</script>");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateSkills.CID);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
    }

    private void LoadCandidateSkills()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateSkill", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateSkills.CID);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
                if (dataSet == null || dataSet.Tables == null || dataSet.Tables[0].Rows.Count <= 0)
                    return;
                for (int index = 0; index < dataSet.Tables[0].Rows.Count; ++index)
                    chkSkills.Items.Add(new ListItem(dataSet.Tables[0].Rows[index]["Skill"].ToString(), dataSet.Tables[0].Rows[index]["Skill_Code"].ToString())
                    {
                        Selected = true
                    });
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateSkills.CID);
            }
        }
    }
    #endregion    


}