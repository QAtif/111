using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using ErrorLog;
using System.Data;
using System.Web.SessionState;

public partial class A2_Reports_CreateDatabase : CustomBasePage, IRequiresSessionState
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            if (!string.IsNullOrEmpty(Request.QueryString["fd"]))
                postedFromDate.Value = Request.QueryString["fd"].ToString();
            else
                postedFromDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            bind_rptrptTestSheduled();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptDeptCandidate_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem || !Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "Is_DBCreated")))
            return;
        e.Item.FindControl("chk").Visible = false;
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        try
        {
            bind_rptrptTestSheduled();
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

    private void bind_rptrptTestSheduled()
    {
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_Select_CandidateForAssessment", connection);
        DateTime dateTime = Convert.ToDateTime(postedFromDate.Value);
        selectCommand.Parameters.AddWithValue("@startDate", dateTime.ToString("yyyy-MM-dd"));
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        if (dataTable != null)
        {
            if (dataTable.Rows.Count > 0)
            {
                rptCandidate.DataSource = dataTable;
                rptCandidate.DataBind();
                rptCandidate.Visible = true;
                lnkDatabase.Visible = true;
                lblemtyMsg.Visible = false;
            }
            else
            {
                rptCandidate.DataSource = null;
                rptCandidate.Visible = false;
                lblemtyMsg.Text = "No record(s) found";
                lblemtyMsg.Visible = true;
                lnkDatabase.Visible = false;
            }
        }
        else
        {
            rptCandidate.DataSource = null;
            rptCandidate.Visible = false;
            lblemtyMsg.Text = "No record(s) found";
            lblemtyMsg.Visible = true;
            lnkDatabase.Visible = false;
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            string str1 = string.Empty;
            for (int index = 0; index <= rptCandidate.Items.Count - 1; ++index)
            {
                CheckBox control1 = (CheckBox)rptCandidate.Items[index].FindControl("chk");
                HiddenField control2 = (HiddenField)rptCandidate.Items[index].FindControl("hdRefNo");
                if (control1.Checked)
                    str1 = str1 + control2.Value + ",";
            }
            string str2 = str1.TrimEnd(',');
            SqlCommand selectCommand = new SqlCommand("dbo.GenerateDatabaseForTest", connection);
            selectCommand.CommandTimeout = 10000;
            selectCommand.Parameters.AddWithValue("@ReferenceNo", str2);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                try
                {
                    connection.Open();
                    for (int index = 0; index <= dataTable.Rows.Count - 1; ++index)
                    {
                        SqlCommand sqlCommand = new SqlCommand("dbo.UpdateGenerateDatabaseForTest", connection);
                        sqlCommand.Parameters.AddWithValue("@DBLogin_Id", dataTable.Rows[index]["login_id"].ToString());
                        sqlCommand.Parameters.AddWithValue("@DBpassword", dataTable.Rows[index]["password"].ToString());
                        sqlCommand.Parameters.AddWithValue("@Is_DBCreated", 1);
                        sqlCommand.Parameters.AddWithValue("@refNo", dataTable.Rows[index]["refNo"].ToString());
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "exists", "alert('All Databases Created Successfully!');", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }
}