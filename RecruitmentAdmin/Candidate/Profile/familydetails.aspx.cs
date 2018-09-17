using System;
using ErrorLog;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Candidate_Profile_familydetails : CustomBasePage, IRequiresSessionState
{

    private string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    private string QueryStringVar = string.Empty;
    public static string CID;
    private SecureQueryString secQueryString;

    private void BindData()
    {
        profeExpList.Style.Add("display", "");
        profeExpList.Visible = true;
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            DataSet dataSet = new DataSet();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateMember", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_familydetails.CID));
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                ListView1.DataSource = dataSet;
                ListView1.DataBind();
                profeExpList.Style.Add("display", "");
            }
            else
                profeExpList.Style.Add("display", "none");
        }
    }

    private void ClearControls()
    {
        ddlDay.SelectedValue = "";
        ddlMonth.SelectedValue = "";
        ddlYear.SelectedValue = "";
        txtDesignation.Text = "";
        txtMemberIncome.Text = "";
        txtName.Text = "";
        ddlOccupation.SelectedValue = "";
        txtOrganization.Text = "";
        txtQualification.Text = "";
        ddlRelation.SelectedValue = "";
        hfCandidateFamilyMemberCode.Value = "";
    }

    private DataSet UpdateCandidateFamilyMembers()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_UpdateCandidateFamilyMemberAdmin", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_familydetails.CID));
                selectCommand.Parameters.AddWithValue("@CandidateFamilyMember_Code", hfCandidateFamilyMemberCode.Value);
                selectCommand.Parameters.AddWithValue("@UpdatedBy", Candidate_Profile_familydetails.CID);
                selectCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
                selectCommand.Parameters.AddWithValue("@Relation_Code", Convert.ToInt32(ddlRelation.SelectedValue.ToString()));
                selectCommand.Parameters.AddWithValue("@Qualification", txtQualification.Text);
                selectCommand.Parameters.AddWithValue("@Member_Name", txtName.Text);
                DateTime dateTime = new DateTime(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlDay.SelectedValue));
                selectCommand.Parameters.AddWithValue("@DateOfBirth", dateTime);
                selectCommand.Parameters.AddWithValue("@Occupation_Code", ddlOccupation.SelectedValue);
                if (txtDesignation.Text != "")
                    selectCommand.Parameters.AddWithValue("@Designation", txtDesignation.Text);
                if (txtMemberIncome.Text == "")
                    txtMemberIncome.Text = "0";
                selectCommand.Parameters.AddWithValue("@MonthlyIncome", txtMemberIncome.Text);
                if (txtOrganization.Text != "")
                    selectCommand.Parameters.AddWithValue("@Company_Name", txtOrganization.Text);
                selectCommand.Parameters.AddWithValue("@UserType", 1);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
        }
        return dataSet;
    }

    private void BindOccupation()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectOccupation", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet != null && dataSet.Tables != null)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    ddlOccupation.DataSource = dataSet;
                    ddlOccupation.DataTextField = "Occupation_Name";
                    ddlOccupation.DataValueField = "Occupation_Code";
                    ddlOccupation.DataBind();
                    ddlOccupation.Items.Insert(0, new ListItem("--Select--", ""));
                    ddlOccupation.SelectedIndex = 0;
                }
                else
                {
                    ddlOccupation.DataSource = null;
                    ddlOccupation.DataTextField = "Occupation_Name";
                    ddlOccupation.DataValueField = "Occupation_Code";
                    ddlOccupation.DataBind();
                    ddlOccupation.Items.Insert(0, new ListItem("--Select--", ""));
                    ddlOccupation.SelectedIndex = 0;
                }
            }
            else
            {
                ddlOccupation.DataSource = null;
                ddlOccupation.DataTextField = "Occupation_Name";
                ddlOccupation.DataValueField = "Occupation_Code";
                ddlOccupation.DataBind();
                ddlOccupation.Items.Insert(0, new ListItem("--Select--", ""));
                ddlOccupation.SelectedIndex = 0;
            }
        }
    }

    private void BindRelation()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand("XRec_SelectRelation", connection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    sqlDataAdapter.Fill(dataSet);
            }
            if (dataSet != null && dataSet.Tables != null)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    ddlRelation.DataSource = dataSet;
                    ddlRelation.DataTextField = "Relation_Name";
                    ddlRelation.DataValueField = "Relation_Code";
                    ddlRelation.DataBind();
                    ddlRelation.Items.Insert(0, new ListItem("--Select--", ""));
                    ddlRelation.SelectedIndex = 0;
                }
                else
                {
                    ddlRelation.DataSource = null;
                    ddlRelation.DataTextField = "Relation_Name";
                    ddlRelation.DataValueField = "Relation_Code";
                    ddlRelation.DataBind();
                    ddlRelation.Items.Insert(0, new ListItem("--Select--", ""));
                    ddlRelation.SelectedIndex = 0;
                }
            }
            else
            {
                ddlRelation.DataSource = null;
                ddlRelation.DataTextField = "Relation_Name";
                ddlRelation.DataValueField = "Relation_Code";
                ddlRelation.DataBind();
                ddlRelation.Items.Insert(0, new ListItem("--Select--", ""));
                ddlRelation.SelectedIndex = 0;
            }
        }
    }

    private void BindYear()
    {
        try
        {
            for (int year = DateTime.Now.Year; year > DateTime.Now.Year - 80; --year)
                ddlYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
            ddlYear.Items.Insert(0, new ListItem("Year", ""));
        }
        catch (Exception ex)
        {
        }
    }

    public void ListView1_ItemEditing(object sender, ListViewEditEventArgs e)
    {
    }

    public void ListView1_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
    }

    public void listView_itemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            DataSet objDS = new DataSet();
            if (e.CommandName == "Delete")
                DeleteSelectedExperience(e);
            if (!(e.CommandName == "Edit"))
                return;
            BindFamilyDetailForEdit(e, objDS);
        }
        catch (Exception ex)
        {
        }
    }

    public void BindFamilyDetailForEdit(ListViewCommandEventArgs e, DataSet objDS)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateMember", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateFamilyMemberCode", Convert.ToInt32(e.CommandArgument.ToString()));
                    selectCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Candidate_Profile_familydetails.CID));
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(objDS);
                    if (objDS == null || objDS.Tables == null || objDS.Tables[0].Rows.Count <= 0)
                        return;
                    txtDesignation.Text = objDS.Tables[0].Rows[0]["MemberDesignation"].ToString();
                    ddlMonth.SelectedValue = Convert.ToDateTime(objDS.Tables[0].Rows[0]["MemberDOB"].ToString()).Month.ToString();
                    ddlYear.SelectedValue = Convert.ToDateTime(objDS.Tables[0].Rows[0]["MemberDOB"].ToString()).Year.ToString();
                    ddlDay.SelectedValue = Convert.ToDateTime(objDS.Tables[0].Rows[0]["MemberDOB"].ToString()).Day.ToString();
                    if (objDS.Tables[0].Rows[0]["MemberIncome"].ToString() == "0.00")
                        txtMemberIncome.Text = "";
                    else
                        txtMemberIncome.Text = objDS.Tables[0].Rows[0]["MemberIncome"].ToString().Split('.')[0].ToString();
                    txtName.Text = objDS.Tables[0].Rows[0]["MemberName"].ToString();
                    ddlOccupation.SelectedValue = objDS.Tables[0].Rows[0]["Occupation_Code"].ToString();
                    txtOrganization.Text = objDS.Tables[0].Rows[0]["MemberOrganization"].ToString();
                    txtQualification.Text = objDS.Tables[0].Rows[0]["MemberQualification"].ToString();
                    ddlRelation.SelectedValue = objDS.Tables[0].Rows[0]["Relation_Code"].ToString();
                    hfCandidateFamilyMemberCode.Value = objDS.Tables[0].Rows[0]["CandidateFamilyMember_Code"].ToString();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }

    private void DeleteSelectedExperience(ListViewCommandEventArgs e)
    {
        try
        {
            if (!(e.CommandName == "Delete"))
                return;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
            {
                connection.Open();
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand("XRec_DeactivateCandidateFamilyMemberAdmin", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@CandidateFamilyMemberCode", Convert.ToInt32(e.CommandArgument.ToString()));
                        sqlCommand.Parameters.AddWithValue("@UpdatedBy", Convert.ToInt32(Candidate_Profile_familydetails.CID));
                        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                        sqlCommand.Parameters.AddWithValue("@UserType", 1);
                        sqlCommand.ExecuteNonQuery();
                    }
                    BindData();
                }
                catch (Exception ex)
                {
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
        if (QueryStringVar == null)
            return;
        secQueryString = new SecureQueryString(QueryStringVar);
        if (secQueryString["CID"] == null)
            return;
        Candidate_Profile_familydetails.CID = secQueryString["CID"].ToString();
        try
        {
            if (IsPostBack)
                return;
            BindYear();
            BindOccupation();
            BindRelation();
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_familydetails.CID);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsValid)
                return;
            DataSet dataSet = new DataSet();
            UpdateCandidateFamilyMembers();
            ClearControls();
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_familydetails.CID);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
    }

    protected void btnAddMore_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ClearControls();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_familydetails.CID);
        }
    }

    protected void btnProceed_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dataSet = new DataSet();
            UpdateCandidateFamilyMembers();
            ClearControls();
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Candidate_Profile_familydetails.CID);
        }
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
    }
}