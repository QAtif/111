
using ErrorLog;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class ViewInitialPic : CustomBasePage
{

   
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
            if (Request.QueryString["ID"] == null || string.IsNullOrEmpty(Request.QueryString["ID"].ToString()))
                return;
            SqlCommand selectCommand = new SqlCommand("XRec_Select_InitialPicPathByCandidateID", connection);
            selectCommand.Parameters.AddWithValue("@candidateCode", Request.QueryString["ID"].ToString());
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return;
            imgCandidate.ImageUrl = "~" + dataTable.Rows[0]["InitialPicPath"].ToString();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

}