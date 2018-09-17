using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using ErrorLog;

public partial class Reports_CandidateCountReport : CustomBasePage
{
    #region Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());

   // int UserCode = 1124;
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                txtDateFrom.Text = DateTime.Now.ToString("MMM dd, yyyy");
                txtDateTo.Text = DateTime.Now.ToString("MMM dd, yyyy");

                connection.Open();
                GetData(ref connection);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }
    }

    #endregion
    #region Methods
    public void GetData(ref SqlConnection connection)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_Admin_SelectStatusCountReport", connection);
        sqlCommand.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = txtDateFrom.Text;
        sqlCommand.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = txtDateTo.Text;

        sqlCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        DataSet ds = new DataSet();
        adapter.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            gvStudent.DataSource = ds.Tables[0];
            gvStudent.DataBind();
        }
        else
        {
            gvStudent.Visible = false;
            lblMsg.Text = "No Record found";
        }

    }
    #endregion

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        GetData(ref connection);
    }
}