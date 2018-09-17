using ErrorLog;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class area_documentchecklist : CustomBaseClass, IRequiresSessionState
{
    #region Variables

    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    string TokenSecret = "";
    SecureQueryString oSecureString = null;
    string XML = string.Empty;
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            BindData(CandidateCode);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
        }
    }

    protected void rptDocumentPersonal_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
            return;
        int itemType = (int)e.Item.ItemType;
    }

    protected void rptDocumentExperience_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
            return;
        int itemType = (int)e.Item.ItemType;
    }

    protected void rptDocumentOther_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
            return;
        int itemType = (int)e.Item.ItemType;
    }

    private DataSet BindPersonalDocumentsUploaders()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidatePersonalDocCheckList", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
            }
        }
        return dataSet;
    }

    private DataSet BindExperienceDocumentsUploaders()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateExperienceDocChecklist", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
            }
        }
        return dataSet;
    }

    private DataSet BindDocumentsUploaders()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateOtherDocChecklist", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
            }
        }
        return dataSet;
    }

    private void BindData(int CandidateCode)
    {
        DataSet dataSet1 = new DataSet();
        DataSet dataSet2 = BindPersonalDocumentsUploaders();
        if (dataSet2 != null && dataSet2.Tables != null)
        {
            if (dataSet2.Tables[0].Rows.Count > 0)
            {
                rptDocumentPersonal.DataSource = dataSet2.Tables[0];
                rptDocumentPersonal.DataBind();
            }
            else
                lblMsgPersonal.Visible = true;
            if (dataSet2.Tables[1].Rows.Count > 0)
            {
                lblName.Text = dataSet2.Tables[1].Rows[0]["Full_Name"].ToString();
                lblDept.Text = dataSet2.Tables[1].Rows[0]["domain_Name"].ToString();
                lblDesg.Text = dataSet2.Tables[1].Rows[0]["Designation_Name"].ToString();
                lblCat.Text = dataSet2.Tables[1].Rows[0]["Category_Name"].ToString();
            }
        }
        DataSet dataSet3 = new DataSet();
        DataSet dataSet4 = BindExperienceDocumentsUploaders();
        if (dataSet4 != null && dataSet4.Tables != null)
        {
            if (dataSet4.Tables[0].Rows.Count > 0)
            {
                rptDocumentExperience.DataSource = dataSet4.Tables[0];
                rptDocumentExperience.DataBind();
            }
            else
                lblMsgExperience.Visible = true;
        }
        DataSet dataSet5 = new DataSet();
        DataSet dataSet6 = BindDocumentsUploaders();
        if (dataSet6 == null || dataSet6.Tables == null)
            return;
        if (dataSet6.Tables[0].Rows.Count > 0)
        {
            rptDocumentOther.DataSource = dataSet6.Tables[0];
            rptDocumentOther.DataBind();
        }
        else
            lblMsgOther.Visible = true;
    }

    #endregion
}