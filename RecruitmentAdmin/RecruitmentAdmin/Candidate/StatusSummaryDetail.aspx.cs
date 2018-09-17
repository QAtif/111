using System;
using System.Collections;
using System.Web.UI.WebControls;
using ErrorLog;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class RecruitmentAdmin_Candidate_StatusSummaryDetail : System.Web.UI.Page
{
    //int pageSize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
    int pageSize = 10;
    public int AllCurrentPage
    {
        get
        {
            object obj = ViewState["_CurrentPage"];
            if (obj == null)
                return 0;
            return (int)obj;
        }
        set
        {
            ViewState["_CurrentPage"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack || (Request.QueryString["Cat"] == null || Request.QueryString["Status"] == null) && (!(Request.QueryString["Cat"].ToString() != "") || !(Request.QueryString["Status"].ToString() != "")))
                return;
            BindCandidates();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "");
        }
    }

    private void BindCandidates()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateDetails", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@Category_Code", Convert.ToInt32(Request.QueryString["Cat"].ToString()));
                    selectCommand.Parameters.AddWithValue("@StatusCode_Code", Convert.ToInt32(Request.QueryString["Status"].ToString()));
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
                if (dataSet != null && dataSet.Tables != null)
                {
                    lblMsg.Text = dataSet.Tables[0].Rows.Count <= 0 ? "No record found." : "";
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        btnPrev.Enabled = true;
                        btnNext.Enabled = true;
                        lblMsg.Text = "";
                        DataView dataView = new DataView(dataSet.Tables[0]);
                        PagedDataSource pagedDataSource = new PagedDataSource();
                        pagedDataSource.DataSource = (IEnumerable)dataSet.Tables[0].DefaultView;
                        pagedDataSource.AllowPaging = true;
                        pagedDataSource.PageSize = pageSize;
                        pagedDataSource.CurrentPageIndex = AllCurrentPage;
                        lblCurrentPage.Text = "Page: " + (AllCurrentPage + 1).ToString() + " of " + pagedDataSource.PageCount.ToString();
                        btnPrev.Enabled = !pagedDataSource.IsFirstPage;
                        btnNext.Enabled = !pagedDataSource.IsLastPage;
                        rptCandidateLists.DataSource = pagedDataSource;
                        rptCandidateLists.DataBind();
                    }
                    else
                    {
                        lblMsg.Text = "No record found.";
                        rptCandidateLists.DataSource = null;
                        rptCandidateLists.DataBind();
                        btnPrev.Enabled = false;
                        btnNext.Enabled = false;
                    }
                }
                else
                {
                    rptCandidateLists.DataSource = null;
                    rptCandidateLists.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "");
            }
        }
    }

    public void btnPrev_Click(object sender, EventArgs e)
    {
        --AllCurrentPage;
        BindCandidates();
    }

    public void btnNext_Click(object sender, EventArgs e)
    {
        ++AllCurrentPage;
        BindCandidates();
    }

}