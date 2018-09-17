using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using XRecruitmentStatusLibrary;

public partial class Admin_QA : Page
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    int candidateCode;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {   //if (Request["cid"] != null && Request["cid"].ToString() != string.Empty)
        //    candidateCode = int.Parse(Request["cid"].ToString());

        if (!IsPostBack)
        {
            BindData();
        }
    }
    private void MarkQuestionResult(string CandidateTestDetailCode, string IsCorrect)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Update_CandidateTestQuestionResult", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@CandidateTestDetailCode", CandidateTestDetailCode);
        sqlCommand.Parameters.AddWithValue("@IsCorrect", IsCorrect);
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", "866");
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
        sqlCommand.ExecuteNonQuery();
    }
    protected void rptDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HiddenField hdfCandidate_Code = (HiddenField)e.Item.FindControl("hdfCandidate_Code");
            HtmlAnchor btnEdit = (HtmlAnchor)e.Item.FindControl("btnEdit");

            string RedirectingLink = "AddEditCallRecording.aspx?" + "cid" + "=" + hdfCandidate_Code.Value;

            btnEdit.Attributes.Add("href", RedirectingLink);
        }
    }
    public void BindData()
    {
        string strSQL = string.Empty;

        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand("XRec_Select_CandidateStatuses", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;            
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(ds);

            rptDetails.DataSource = ds;
            rptDetails.DataBind();

        }
        catch (Exception ex)
        {
            //throw exp1;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.Candidate, ex.StackTrace, ex, "866".ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

    }
}