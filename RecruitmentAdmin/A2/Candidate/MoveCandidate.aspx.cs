using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class A2_Candidate_MoveCandidate : Page, IRequiresSessionState
{
    private SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString());



    protected void Page_Load(object sender, EventArgs e)
    {
        lblCandidate.Text = "";
    }

    protected void BtnSearchFresh_Click(object sender, EventArgs e)
    {
        GetData();
    }

    private void GetData()
    {
        try
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "Insert_MoveCandidateBol";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = sqlconn;
            sqlCommand.Parameters.AddWithValue("@candidate_id", txtbxRefNum.Text.Trim());
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            if (sqlconn.State == ConnectionState.Closed)
                sqlconn.Open();
            sqlDataAdapter.Fill(dataTable);
            if (sqlconn.State == ConnectionState.Open)
                sqlconn.Close();
            if (dataTable.Rows.Count > 0)
                lblCandidate.Text = dataTable.Rows[0][0].ToString();
            else
                lblCandidate.Text = "No Candidate Found";
        }
        catch (Exception ex)
        {
            lblCandidate.Text = "ERROR";
        }
    }

}