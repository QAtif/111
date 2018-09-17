using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ErrorLog;


public partial class Candidate_CandidateApplication : CustomBasePage
{
    #region Variables
    string TypeCode = "0";
    string oldStatusName = string.Empty, oldProfileName = string.Empty, oldRequisitionName = string.Empty,
        oldCategoryName = string.Empty, oldJoiningDate = string.Empty;
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;
    #endregion
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
        secQueryString = new SecureQueryString(QueryStringVar);
        try
        {
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

    private void BindData()
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateApplication", connection);
        selectCommand.Parameters.AddWithValue("@CandidateCode", hdnCandidateCode.Value);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        rptApplication.DataSource = dataSet.Tables[0];
        rptApplication.DataBind();
    }

    private void CheckQueryString()
    {
        if (secQueryString["CID"] == null)
            return;
        hdnCandidateCode.Value = secQueryString["CID"].ToString();
    }

    protected void rptApplication_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.Item)
            return;
        ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
        Label control1 = (Label)e.Item.FindControl("lblStatusActive");
        LinkButton control2 = (LinkButton)e.Item.FindControl("lnkbtnStatusInActive");
        if (!(DataBinder.Eval(e.Item.DataItem, "Is_ActiveApplication").ToString() != ""))
            return;
        if (DataBinder.Eval(e.Item.DataItem, "Is_ActiveApplication").ToString() == "True")
        {
            control1.Text = "Active";
        }
        else
        {
            if (!(DataBinder.Eval(e.Item.DataItem, "Is_ActiveApplication").ToString() == "False"))
                return;
            control2.Text = "InActive";
        }
    }

    protected void rptApplication_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "InActive"))
            return;
        try
        {
            connection.Open();
            LinkButton control = (LinkButton)e.Item.FindControl("lnkbtnStatusInActive");
            SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateApplicationStatusActive", connection);
            sqlCommand.Parameters.AddWithValue("@Application_Code", control.CommandArgument.ToString());
            sqlCommand.Parameters.AddWithValue("@Candidate_Code", hdnCandidateCode.Value);
            sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
            sqlCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            Convert.ToString(sqlCommand.ExecuteScalar());
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
    #endregion

}


