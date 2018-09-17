using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using XRecruitmentStatusLibrary;
using ErrorLog;

public partial class Candidate_CandidateCheckList : CustomBasePage
{
    DataSet ds = new DataSet();
    string candidateCode = "0";
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            secQueryString = new SecureQueryString(QueryStringVar);
            CheckQueryString();
            connection.Open();
            BindData();
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

    private void CheckQueryString()
    {
        if (secQueryString["CID"] == null)
            return;
        candidateCode = secQueryString["CID"].ToString();
        hdnCandCode.Value = secQueryString["CID"].ToString();
    }

    private void BindData()
    {
        try
        {
            SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateAllDocument", connection);
            selectCommand.Parameters.AddWithValue("@Candidate_Code", hdnCandCode.Value);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet1 = new DataSet();
            sqlDataAdapter.Fill(dataSet1);
            if (dataSet1.Tables[0].Rows.Count > 0)
            {
                lblCandidateName.Text = dataSet1.Tables[0].Rows[0]["Full_Name"].ToString();
                lblCandidateDesignation.Text = dataSet1.Tables[0].Rows[0]["Designation_Name"].ToString();
                lblDepartment.Text = dataSet1.Tables[0].Rows[0]["Domain_Name"].ToString();
                lblCandidateJobCategory.Text = dataSet1.Tables[0].Rows[0]["Category_Name"].ToString();
            }
            DataSet dataSet2 = new DataSet();
            DataSet dataSet3 = BindPersonalDocumentsUploaders();
            if (dataSet3 != null && dataSet3.Tables != null && dataSet3.Tables[0].Rows.Count > 0)
            {
                rptDocumentPersonal.DataSource = dataSet3.Tables[0];
                rptDocumentPersonal.DataBind();
            }
            DataSet dataSet4 = new DataSet();
            DataSet dataSet5 = BindExperienceDocumentsUploaders();
            if (dataSet5 != null && dataSet5.Tables != null && dataSet5.Tables[0].Rows.Count > 0)
            {
                rptDocumentExperience.DataSource = dataSet5.Tables[0];
                rptDocumentExperience.DataBind();
            }
            DataSet dataSet6 = new DataSet();
            DataSet dataSet7 = BindDocumentsUploaders();
            if (dataSet7 == null || dataSet7.Tables == null || dataSet7.Tables[0].Rows.Count <= 0)
                return;
            rptDocumentOther.DataSource = dataSet7.Tables[0];
            rptDocumentOther.DataBind();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, hdnCandCode.Value);
        }
    }

    protected void rptDocumentPersonal_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
    }

    protected void rptDocumentExperience_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
    }

    protected void rptDocumentOther_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
    }

    private DataSet BindPersonalDocumentsUploaders()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidatePersonalDoc", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", hdnCandCode.Value);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, hdnCandCode.Value);
            }
        }
        return dataSet;
    }

    private DataSet BindExperienceDocumentsUploaders()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateExperienceDoc", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", hdnCandCode.Value);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, hdnCandCode.Value);
            }
        }
        return dataSet;
    }

    private DataSet BindDocumentsUploaders()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateOtherDoc", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", hdnCandCode.Value);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, hdnCandCode.Value);
            }
        }
        return dataSet;
    }

}