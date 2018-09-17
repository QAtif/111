using ErrorLog;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using XRecruitmentStatusLibrary;

public partial class CandidateDocument : CustomBaseClass, IRequiresSessionState
{
    #region Page Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    public static string CID;
    string[] slottime;
    #endregion Page Variables

    #region Methods

    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            if (Session["CC"] != null)
            {
                if (!string.IsNullOrEmpty(Session["CC"].ToString()))
                {
                    CandidateDocument.CID = Session["CC"].ToString();
                }
                else
                {
                    divmain.Visible = false;
                    lblmessage.Text = "Error: Session Out";
                }
                setview();
                txtSelectedDate.Text = DateTime.UtcNow.ToString("yyyy-MM-dd");
                GetUnreservedSlots();
            }
            else
            {
                divmain.Visible = false;
                lblmessage.Text = "Error: Session Out";
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateDocument.CID);
        }
    }

    public void setview()
    {
        SqlCommand selectCommand = new SqlCommand("Xrec_ValidateCandidateForReservation ", connection);
        selectCommand.Parameters.AddWithValue("@candidate_code", CandidateDocument.CID);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        if (dataTable.Rows.Count > 0)
        {
            lblmessage.Text = "* You are already reserved";
            btnSave1.Style.Add("display", "none");
        }
        else
        {
            lblmessage.Text = "";
            btnSave1.Style.Add("display", "");
        }
    }

    protected void GetUnreservedSlots(object sender, EventArgs e)
    {
        try
        {
            GetUnreservedSlots();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateDocument.CID);
        }
    }

    public void GetUnreservedSlots()
    {
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_Select_AvailableSLots_Frontend ", connection);
        selectCommand.Parameters.AddWithValue("@SlotDate", txtSelectedDate.Text);
        selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateDocument.CID);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        if (dataTable.Rows.Count > 0)
        {
            rblSlot.Items.Clear();
            foreach (DataRow row in (InternalDataCollectionBase)dataTable.Rows)
            {
                rblSlot.Items.Add(new ListItem()
                {
                    Text = row["SlotTime"].ToString(),
                    Value = row["SlotTime"].ToString()
                });
                lblSlotMsg.Text = "";
            }
        }
        else
        {
            rblSlot.Items.Clear();
            lblSlotMsg.Text = "   No slots available on selected date.";
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            slottime = rblSlot.SelectedValue.ToString().Split('-');
            string str1 = string.Format("{0:HH:mm}", Convert.ToDateTime(slottime[0]));
            string str2 = string.Format("{0:HH:mm}", Convert.ToDateTime(slottime[1]));
            string[] strArray1 = str1.Split(':');
            string[] strArray2 = str2.Split(':');
            SqlCommand selectCommand = new SqlCommand("dbo.XRec_ReserveslotbyCandidate ", connection);
            selectCommand.Parameters.AddWithValue("@slotStartTime", strArray1[0]);
            selectCommand.Parameters.AddWithValue("@slotEndTime", strArray2[0]);
            selectCommand.Parameters.AddWithValue("@TestDuration", ((int)Convert.ToInt16(strArray2[0]) - (int)Convert.ToInt16(strArray1[0])));
            selectCommand.Parameters.AddWithValue("@SlotDate", txtSelectedDate.Text);
            selectCommand.Parameters.AddWithValue("@candidateCode", CandidateDocument.CID);
            selectCommand.Parameters.AddWithValue("@updatedIp", "");
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count <= 0)
                return;
            if (dataTable.Rows[0]["is_Done"].ToString() == "1")
                StatusManagement.MarkLifeCycleStatus(connection, int.Parse(CandidateDocument.CID), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.SchedulingdoneTestPending, Request.UserHostAddress.ToString(), int.Parse(CandidateDocument.CID));
            ScriptManager.RegisterStartupScript((Page)this, typeof(string), "script", "<script type=text/javascript>parent.location.href = parent.location.href;</script>", false);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateDocument.CID);
        }
    }
    #endregion




}