

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using XRecruitmentStatusLibrary;
using ErrorLog;
using System.IO;

public partial class AddEditCallRecording : CustomBasePage
{
    int CandidateCode = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString != null && Request.QueryString["cid"] != null && (Request.QueryString != null && Request.QueryString["cid"] != null) && Request.QueryString["cid"].ToString() != "")
            CandidateCode = Convert.ToInt32(Request.QueryString["cid"].ToString());
        if (IsPostBack)
            return;
        ShowData();
    }

    public void ShowData()
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
        string empty = string.Empty;
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XREC_Selcet_CandidateQARecording", connection);
            selectCommand.Parameters.AddWithValue("@Candidate_Code", CandidateCode);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count <= 0)
                return;
            rptFile.DataSource = dataSet.Tables[0];
            rptFile.DataBind();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string empty = string.Empty;
        string path = string.Empty;
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
        lblMessage.Text = "";
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("XREC_Insert_Update_CandidateCallRecording", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@Candidate_Code", CandidateCode);
            selectCommand.Parameters.AddWithValue("@Recording_Path", path);
            selectCommand.Parameters.AddWithValue("@Comments", txtComments.Text);
            selectCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
            selectCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                int num = int.Parse(dataTable.Rows[0]["CandidateQARecording_Code"].ToString());
                if (fuDocument.HasFile)
                {
                    string extension = Path.GetExtension(fuDocument.FileName);
                    path = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + CandidateCode + "/CandidateTest/Recordings/" + num + extension;
                    if (!Directory.Exists(Server.MapPath(ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + CandidateCode + "/CandidateTest/Recordings/")))
                        Directory.CreateDirectory(Server.MapPath(ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + CandidateCode + "/CandidateTest/Recordings/"));
                    GeneralMethods.FileBrowse(fuDocument, ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + CandidateCode + "/CandidateTest/Recordings/", Path.GetFileNameWithoutExtension(path));
                }
                SqlCommand sqlCommand = new SqlCommand("XREC_Insert_Update_CandidateCallRecordingPath", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CandidateQARecording_Code", num);
                sqlCommand.Parameters.AddWithValue("@Recording_Path", path);
                sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
                sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                sqlCommand.ExecuteNonQuery();
            }
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "pass", "refreshParent();", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    protected void rptFile_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        HtmlAnchor control = (HtmlAnchor)e.Item.FindControl("lnkFile");
        control.HRef = DataBinder.Eval(e.Item.DataItem, "Recording_Path").ToString();
        control.InnerText = Path.GetFileName(DataBinder.Eval(e.Item.DataItem, "Recording_Path").ToString());
    }

}