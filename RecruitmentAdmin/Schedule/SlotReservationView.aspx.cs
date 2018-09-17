using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Collections;
using ErrorLog;

public partial class SlotReservationView : CustomBasePage
{
    #region Variables 
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    public long lRecordsPerRow = 2;
    public long lCurrentRecord;

    #endregion


    #region Events
    public int CurrentPage
    {
        get
        {
            object obj = ViewState["CurrentPage"];
            if (obj == null)
                return 0;
            return Convert.ToInt32(obj);
        }
        set
        {
            ViewState["CurrentPage"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
                bindrepeater();
            if (IsPostBack)
                return;
            postedFromDate.Attributes.Add("readonly", "readonly");
            postedFromDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            GetVenue();
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

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item)
        {
            if (e.Item.ItemType != ListItemType.AlternatingItem)
                goto label_14;
        }
        try
        {
            DateTime dateTime = Convert.ToDateTime(postedFromDate.Value);
            SqlCommand selectCommand = new SqlCommand("Select_ReservedCandidateVenueWise_Test", connection);
            selectCommand.Parameters.AddWithValue("@RequiredSlotDate", dateTime.ToString("yyyy-MM-dd"));
            selectCommand.Parameters.AddWithValue("@RequiredVenueCode", ddlVenue.SelectedValue);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable1 = new DataTable();
            sqlDataAdapter.Fill(dataTable1);
            Repeater control1 = (Repeater)e.Item.FindControl("rptChild");
            Label control2 = (Label)e.Item.FindControl("lblVenueprefix");
            Label control3 = (Label)e.Item.FindControl("lblemtyMsg");
            DataTable dataTable2 = new DataTable();
            if (dataTable1 != null)
            {
                if (dataTable1.Rows.Count > 0)
                {
                    Repeater1.Visible = true;
                    lblemtyMsgAll.Visible = false;
                    if (dataTable1.Select("VenuePrefix='" + control2.Text + "'").Length > 0)
                    {
                        control3.Visible = false;
                        DataTable dataTable3 = ((IEnumerable<DataRow>)dataTable1.Select("VenuePrefix='" + control2.Text + "'")).CopyToDataTable<DataRow>();
                        control1.DataSource = dataTable3;
                        control1.DataBind();
                    }
                    else
                    {
                        control3.Text = "No slots generated.";
                        control3.Visible = true;
                    }
                }
                else
                {
                    Repeater1.Visible = false;
                    Repeater1.DataSource = null;
                    lblemtyMsgAll.Text = "No slots generated.";
                    lblemtyMsgAll.Visible = true;
                }
            }
            else
            {
                Repeater1.Visible = false;
                Repeater1.DataSource = null;
                lblemtyMsgAll.Text = "No slots generated.";
                lblemtyMsgAll.Visible = true;
            }
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
        label_14:
        if (!(e.Item.ItemType != ListItemType.Header & e.Item.ItemType != ListItemType.Footer))
            return;
        try
        {
            for (int index = 0; index <= e.Item.Controls.Count - 1; ++index)
            {
                Literal control = e.Item.Controls[index] as Literal;
                if (control != null && control.ID == "litRowStart")
                {
                    ++lCurrentRecord;
                    if (lCurrentRecord == 1L)
                    {
                        control.Text = "<tr>";
                        break;
                    }
                    break;
                }
            }
            for (int index = 0; index <= e.Item.Controls.Count - 1; ++index)
            {
                Literal control = e.Item.Controls[index] as Literal;
                if (control != null && control.ID == "litRowEnd")
                {
                    if (lCurrentRecord % lRecordsPerRow != 0L)
                        break;
                    control.Text = "</tr>";
                    lCurrentRecord = 0L;
                    break;
                }
            }
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

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        try
        {
            bindrepeater();
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

    public void GetVenue()
    {
        SqlCommand selectCommand = new SqlCommand("XRec_Select_Venue ", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        if (dataTable == null || dataTable.Rows.Count <= 0)
            return;
        ddlVenue.DataSource = dataTable;
        ddlVenue.DataTextField = "VenueName";
        ddlVenue.DataValueField = "VenueCode";
        ddlVenue.DataBind();
    }

    private void bindrepeater()
    {
        SqlCommand selectCommand = new SqlCommand("Select_AllVenuePrefixBYVenueID", connection);
        selectCommand.Parameters.AddWithValue("@VenueCode", ddlVenue.SelectedValue);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        if (dataTable == null || dataTable.Rows.Count <= 0)
            return;
        Repeater1.DataSource = dataTable;
        Repeater1.DataBind();
    }

    #endregion


}
