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
using System.Drawing;

public partial class Functions : System.Web.UI.Page
{
    string RequisitionCode = "0";
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        lblMsgMapping.Visible = false;
        lblMsgShortlisting.Visible = false;
    }

    protected void btnMapping_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XRec_Function_CandidateProfileMapping", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            Convert.ToString(sqlCommand.ExecuteScalar());
            lblMsgMapping.Visible = true;
            lblMsgMapping.Text = "Successfully Done!!";
            lblMsgMapping.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, "0");
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void btnShortlisting_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XRec_Function_CandidateShortListing", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            Convert.ToString(sqlCommand.ExecuteScalar());
            lblMsgShortlisting.Visible = true;
            lblMsgShortlisting.Text = "Successfully Done!!";
            lblMsgShortlisting.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, "0");
            lblMsgShortlisting.Visible = true;
            lblMsgShortlisting.Text = "Error Occurred!!";
            lblMsgShortlisting.ForeColor = Color.Red;
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }
}
