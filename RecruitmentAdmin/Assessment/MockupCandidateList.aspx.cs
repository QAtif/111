using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using ErrorLog;

public partial class Admin_MockupCandidateList : CustomBasePage
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    int candidateCode;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        BindData();
    }

    private void MarkQuestionResult(string CandidateTestDetailCode, string IsCorrect)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Update_CandidateTestQuestionResult", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@CandidateTestDetailCode", CandidateTestDetailCode);
        sqlCommand.Parameters.AddWithValue("@IsCorrect", IsCorrect);
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        sqlCommand.ExecuteNonQuery();
    }

    protected void rptDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        HiddenField control = (HiddenField)e.Item.FindControl("hdfCandidate_Code");
        ((HtmlControl)e.Item.FindControl("btnEdit")).Attributes.Add("href", "AddEditCallRecording.aspx?cid=" + control.Value);
    }

    public void BindData()
    {
        string empty = string.Empty;
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XRec_Select_CandidateStatuses", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            new SqlDataAdapter(selectCommand).Fill(ds);
            rptDetails.DataSource = ds;
            rptDetails.DataBind();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
}