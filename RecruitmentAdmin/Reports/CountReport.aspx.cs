using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ErrorLog;
using System.Net.Sockets;
using System.Net;

public partial class Reports_CandidateCountReport : CustomBasePage
{
    #region Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());

    //int UserCode = 1124;
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            txtDateFrom.Text = DateTime.Now.ToString("MMM dd, yyyy");
            txtDateTo.Text = DateTime.Now.ToString("MMM dd, yyyy");
            connection.Open();
            GetData(ref connection);
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

    public void GetData(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_Admin_SelectStatusCountReport", connection);
        selectCommand.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = txtDateFrom.Text;
        selectCommand.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = txtDateTo.Text;
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            gvStudent.DataSource = dataSet.Tables[0];
            gvStudent.DataBind();
        }
        else
        {
            gvStudent.Visible = false;
            lblMsg.Text = "No Record found";
        }
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        GetData(ref connection);
    }

    public string LocalIPAddress()
    {
        string str = "";
        foreach (IPAddress address in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
        {
            if (address.AddressFamily == AddressFamily.InterNetwork)
            {
                str = address.ToString();
                break;
            }
        }
        return str;
    }


    #endregion

}