using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;
using ErrorLog;
using XRecruitmentStatusLibrary;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Collections;
using System.Drawing;

public partial class area_alert : CustomBaseClass
{
    #region Page Variables
    public static int Candcode = 0;
    public static string IP = string.Empty;
    private string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    private int pageSize = 50;
    public string accordianId = string.Empty;


    #endregion Page Variables

    public int count;
    public int counter;

    #region Events


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

    public int ReadCurrentPage
    {
        get
        {
            object obj = ViewState["Read_CurrentPage"];
            if (obj == null)
                return 0;
            return (int)obj;
        }
        set
        {
            ViewState["Read_CurrentPage"] = value;
        }
    }

    public int UnReadCurrentPage
    {
        get
        {
            object obj = ViewState["UnRead_CurrentPage"];
            if (obj == null)
                return 0;
            return (int)obj;
        }
        set
        {
            ViewState["UnRead_CurrentPage"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            area_alert.Candcode = Convert.ToInt32(Session["CC"].ToString());
            area_alert.IP = Request.UserHostAddress;
            if (IsPostBack)
                return;
            Session["Read"] = "All";
            BindCandidateAlerts();
            BindData(area_alert.Candcode);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Session["CC"].ToString());
        }
    }

    private DataSet BindPersonalDocumentsUploaders()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidatePersonalDocCheckList", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
            }
        }
        return dataSet;
    }

    private DataSet BindExperienceDocumentsUploaders()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateExperienceDocChecklist", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
            }
        }
        return dataSet;
    }

    private DataSet BindDocumentsUploaders()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateOtherDocChecklist", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", CandidateCode);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, CandidateCode.ToString());
            }
        }
        return dataSet;
    }

    private void BindData(int CandidateCode)
    {
        DataSet dataSet1 = new DataSet();
        DataSet dataSet2 = BindPersonalDocumentsUploaders();
        if (dataSet2 != null && dataSet2.Tables != null)
        {
            if (dataSet2.Tables[0].Rows.Count > 0)
            {
                lblDocumentPersonal.Visible = false;
                rptDocumentPersonal.DataSource = dataSet2.Tables[0];
                rptDocumentPersonal.DataBind();
            }
            else
                lblDocumentPersonal.Visible = true;
            if (dataSet2.Tables[1].Rows.Count > 0)
            {
                lblName.Text = dataSet2.Tables[1].Rows[0]["Full_Name"].ToString();
                lblDept.Text = dataSet2.Tables[1].Rows[0]["domain_Name"].ToString();
                lblDesg.Text = dataSet2.Tables[1].Rows[0]["Designation_Name"].ToString();
                lblCat.Text = dataSet2.Tables[1].Rows[0]["Category_Name"].ToString();
            }
        }
        else
            lblDocumentPersonal.Visible = true;
        DataSet dataSet3 = new DataSet();
        DataSet dataSet4 = BindExperienceDocumentsUploaders();
        if (dataSet4 != null && dataSet4.Tables != null)
        {
            if (dataSet4.Tables[0].Rows.Count > 0)
            {
                lblDocumentExperience.Visible = false;
                rptDocumentExperience.DataSource = dataSet4.Tables[0];
                rptDocumentExperience.DataBind();
            }
            else
                lblDocumentExperience.Visible = true;
        }
        else
            lblDocumentExperience.Visible = true;
        DataSet dataSet5 = new DataSet();
        DataSet dataSet6 = BindDocumentsUploaders();
        if (dataSet6 != null && dataSet6.Tables != null)
        {
            if (dataSet6.Tables[0].Rows.Count > 0)
            {
                lblDocumentOther.Visible = false;
                rptDocumentOther.DataSource = dataSet6.Tables[0];
                rptDocumentOther.DataBind();
            }
            else
                lblDocumentOther.Visible = true;
        }
        else
            lblDocumentOther.Visible = true;
    }

    public void lnkRead_OnClick(object sender, EventArgs e)
    {
        Session["Read"] = "Read";
        BindCandidateAlerts(1);
    }

    public void lnkUnRead_OnClick(object sender, EventArgs e)
    {
        Session["Read"] = "UnRead";
        BindCandidateAlerts(0);
    }

    public void lnkAll_OnClick(object sender, EventArgs e)
    {
        Session["Read"] = "All";
        BindCandidateAlerts();
    }

    protected void rptCandidateAlerts_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        HtmlGenericControl control1 = (HtmlGenericControl)e.Item.FindControl("dvhead");
        HtmlGenericControl control2 = (HtmlGenericControl)e.Item.FindControl("spanheading");
        if (DataBinder.Eval(e.Item.DataItem, "Is_Read").ToString() != "False")
        {
            control1.Attributes.Add("class", "accordion-heading");
            control2.Attributes.Add("style", "font-weight:normal !important;text-decoration: none;color:#333; ");
        }
        else
        {
            control1.Attributes.Add("class", "accordion-heading approved");
            control2.Attributes.Add("style", "font-weight:bold;color:#333;");
        }
    }

    public void rptCandidateAlerts_OnItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            DataSet dataSet = new DataSet();
            if (!(e.CommandName == "Read"))
                return;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                connection.Open();
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateAlertStatus", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@CandidateAlertCode", Convert.ToInt32(e.CommandArgument.ToString()));
                        sqlCommand.Parameters.AddWithValue("@CandidateCode", Convert.ToInt32(Session["CC"].ToString()));
                        sqlCommand.Parameters.AddWithValue("@UpdatedBy", Convert.ToInt32(Session["CC"].ToString()));
                        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                        sqlCommand.ExecuteNonQuery();
                        if (Session["Read"].ToString() == "All")
                            BindCandidateAlerts();
                        else if (Session["Read"].ToString() == "Read")
                        {
                            BindCandidateAlerts(1);
                        }
                        else
                        {
                            if (!(Session["Read"].ToString() == "UnRead"))
                                return;
                            BindCandidateAlerts(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Session["CC"].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Session["CC"].ToString());
        }
    }

    protected void rptDocumentPersonal_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
            return;
        int itemType = (int)e.Item.ItemType;
    }

    protected void rptDocumentExperience_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
            return;
        int itemType = (int)e.Item.ItemType;
    }

    protected void rptDocumentOther_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
            return;
        int itemType = (int)e.Item.ItemType;
    }

    private void SelectLink(LinkButton abc)
    {
        abc.BackColor = Color.Silver;
        abc.Font.Bold = true;
        abc.ForeColor = Color.White;
    }

    private void BindCandidateAlerts()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateAlerts", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", Session["CC"].ToString());
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
                if (dataSet != null && dataSet.Tables != null)
                {
                    if (dataSet.Tables[1].Rows.Count > 0)
                    {
                        lblMsg.Text = "";
                        AlertHead.Text = "Alerts";
                    }
                    else
                        lblMsg.Text = "No record found.";
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        lblMsg.Text = "";
                        DataView dataView = new DataView(dataSet.Tables[0]);
                        rptCandidateAlerts.DataSource = new PagedDataSource()
                        {
                            DataSource = (IEnumerable)dataSet.Tables[0].DefaultView,
                            AllowPaging = true,
                            PageSize = pageSize,
                            CurrentPageIndex = AllCurrentPage
                        };
                        rptCandidateAlerts.DataBind();
                    }
                    else
                    {
                        lblMsg.Text = "No record found.";
                        rptCandidateAlerts.DataSource = null;
                        rptCandidateAlerts.DataBind();
                    }
                }
                else
                {
                    rptCandidateAlerts.DataSource = null;
                    rptCandidateAlerts.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Session["CC"].ToString());
            }
        }
    }

    private void BindCandidateAlerts(int Read)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_SelectCandidateAlerts", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", Session["CC"].ToString());
                    selectCommand.Parameters.AddWithValue("@Read", Read);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
                if (dataSet != null && dataSet.Tables != null)
                {
                    if (dataSet.Tables[1].Rows.Count > 0)
                    {
                        lblMsg.Text = "";
                        AlertHead.Text = "Alert ( " + dataSet.Tables[1].Rows[0]["AlertCount"].ToString() + " )";
                    }
                    else
                        lblMsg.Text = "No record found.";
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        lblMsg.Text = "";
                        DataView dataView = new DataView(dataSet.Tables[0]);
                        PagedDataSource pagedDataSource = new PagedDataSource();
                        pagedDataSource.DataSource = (IEnumerable)dataSet.Tables[0].DefaultView;
                        pagedDataSource.AllowPaging = true;
                        pagedDataSource.PageSize = pageSize;
                        if (Session["Read"] == "Read")
                            pagedDataSource.CurrentPageIndex = ReadCurrentPage;
                        else if (Session["Read"] == "UnRead")
                            pagedDataSource.CurrentPageIndex = UnReadCurrentPage;
                        else if (Session["Read"] == "All")
                            pagedDataSource.CurrentPageIndex = AllCurrentPage;
                        rptCandidateAlerts.DataSource = pagedDataSource;
                        rptCandidateAlerts.DataBind();
                    }
                    else
                    {
                        lblMsg.Text = "No record found.";
                        rptCandidateAlerts.DataSource = null;
                        rptCandidateAlerts.DataBind();
                    }
                }
                else
                {
                    rptCandidateAlerts.DataSource = null;
                    rptCandidateAlerts.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Session["CC"].ToString());
            }
        }
    }


    #endregion

    [WebMethod]
    public static int ProcessIT(string alertcode)
    {
        int num = 0;
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("XRec_UpdateCandidateAlertStatus", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@CandidateAlertCode", Convert.ToInt32(alertcode));
                    sqlCommand.Parameters.AddWithValue("@CandidateCode", area_alert.Candcode);
                    sqlCommand.Parameters.AddWithValue("@UpdatedBy", area_alert.Candcode);
                    sqlCommand.Parameters.AddWithValue("@UpdationIP", area_alert.IP);
                    num = sqlCommand.ExecuteNonQuery();
                    if (num == -1)
                        return num;
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, area_alert.Candcode.ToString());
            }
            return num;
        }
    }

}