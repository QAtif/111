using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ErrorLog;



public partial class RunRecordingForCandidate : XRecBase
{
    public string Path = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //Response.Cookies["CC"].Expires = DateTime.Now.AddDays(-1);
                //Response.Cookies["TC"].Expires = DateTime.Now.AddDays(-1);

            }

            if (IsPostBack)
                return;
            if ((Request.QueryString["VID"].ToString() != null || Request.QueryString["VID"].ToString() != "") && Response.Cookies["CC"] != null)
            {
                CheckRecordingStatus(Convert.ToInt32(Request.QueryString["VID"].ToString()), Convert.ToInt32(Response.Cookies["CC"].ToString()));

            }
               
            else
                lblMsg.Text = "Kindly Login";
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }


    protected void btnStart_Click(object sender, EventArgs e)
    {
        try
        {
            if ((Request.QueryString["VID"].ToString() != null || Request.QueryString["VID"].ToString() != "") && Response.Cookies["CC"] != null)
                GetVideo(Convert.ToInt32(Request.QueryString["VID"].ToString()), Convert.ToInt32(Response.Cookies["CC"].ToString()));
            else
                lblMsg.Text = "Kindly Login";
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    
    private void CheckRecordingStatus(int VideoId, int CandCatCode)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);
        string empty = string.Empty;
        try
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand selectCommand = new SqlCommand("XREC_GetVideoStatus", connection);
            selectCommand.Parameters.AddWithValue("@VideoID", (object)VideoId);
            selectCommand.Parameters.AddWithValue("@Cand_Cat_Code", (object)CandCatCode);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables.Count <= 0 || dataSet.Tables[0].Rows.Count <= 0)
                return;
            if (dataSet.Tables[0].Rows[0]["Recording_Path"].ToString() == "")
            {
                this.lblMsg.Text = "The File Has already been Listen by the Candidate";
                this.btnContinue.Visible = false;
            }
            else
                this.lblMsg.Text = "This Recording will run Only Once..";
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, this.UserID.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    private void GetVideo(int VideoId, int CandCatCode)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);
        string empty = string.Empty;
        try
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand selectCommand = new SqlCommand("XREC_GetVideoPath", connection);
            selectCommand.Parameters.AddWithValue("@VideoID", VideoId);
            selectCommand.Parameters.AddWithValue("@Cand_Cat_Code", CandCatCode);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables.Count <= 0 || dataSet.Tables[0].Rows.Count <= 0)
                return;
            if (dataSet.Tables[0].Rows[0]["Recording_Path"].ToString() == "")
            {
                lblMsg.Text = "The File Has already been Listen by the Candidate";
                btnContinue.Visible = false;
            }
            else
            {
                lblMsg.Text = "";
                Path = dataSet.Tables[0].Rows[0]["Recording_Path"].ToString();
                divPlayer.Attributes.Add("style", "display:''");
                btnContinue.Visible = false;
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserID.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
    


}