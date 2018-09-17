using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ErrorLog;
using System.Collections;


public partial class Leads_ViewAllLeads : CustomBasePage
{
    #region variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentLiveConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    #endregion


    #region Paging Variables
    static DataView objDV = new DataView();
    static int PageSize;
    static string SortDirection = "DESC";
    PagedDataSource objPDS = new System.Web.UI.WebControls.PagedDataSource();
    #endregion


    #region Events

    private int PageNoFeedBack
    {
        get
        {
            if (ViewState["PageNoFeedBack"] != null)
                return Convert.ToInt32(ViewState["PageNoFeedBack"]);
            return 0;
        }
        set
        {
            ViewState["PageNoFeedBack"] = value;
        }
    }

    private int PageNoMagazine
    {
        get
        {
            if (ViewState["PageNoMagazine"] != null)
                return Convert.ToInt32(ViewState["PageNoMagazine"]);
            return 0;
        }
        set
        {
            ViewState["PageNoMagazine"] = value;
        }
    }

    private int PageNoPreSignUP
    {
        get
        {
            if (ViewState["PageNoPreSignUP"] != null)
                return Convert.ToInt32(ViewState["PageNoPreSignUP"]);
            return 0;
        }
        set
        {
            ViewState["PageNoPreSignUP"] = value;
        }
    }

    private int PageNoContactUS
    {
        get
        {
            if (ViewState["PageNoContactUS"] != null)
                return Convert.ToInt32(ViewState["PageNoContactUS"]);
            return 0;
        }
        set
        {
            ViewState["PageNoContactUS"] = value;
        }
    }

    private int PageNoOther
    {
        get
        {
            if (ViewState["PageNoOther"] != null)
                return Convert.ToInt32(ViewState["PageNoOther"]);
            return 0;
        }
        set
        {
            ViewState["PageNoOther"] = value;
        }
    }

    private int PageNoBusEmp
    {
        get
        {
            if (ViewState["PageNoBusEmp"] != null)
                return Convert.ToInt32(ViewState["PageNoBusEmp"]);
            return 0;
        }
        set
        {
            ViewState["PageNoBusEmp"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            postedFromDate.Attributes.Add("readonly", "readonly");
            postedFromDate.Value = DateTime.Now.AddDays(-1.0).ToString("MMM dd, yyyy");
            postedToDate.Attributes.Add("readonly", "readonly");
            postedToDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            Leads_ViewAllLeads.PageSize = 25;
            connection.Open();
            BindOGData(ref connection);
            BindData();
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

    protected void rptFeedBack_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptMagazine_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptBusEmp_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptPreSignUp_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptContactUS_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptOther_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
            Label control = (Label)e.Item.FindControl("lblComment");
            if (DataBinder.Eval(e.Item.DataItem, "Agent_Comments").ToString().Length > 20)
            {
                control.Text = DataBinder.Eval(e.Item.DataItem, "Agent_Comments").ToString().Substring(0, 20) + " .....";
                control.ToolTip = DataBinder.Eval(e.Item.DataItem, "Agent_Comments").ToString();
            }
            else
            {
                control.Text = DataBinder.Eval(e.Item.DataItem, "Agent_Comments").ToString();
                control.ToolTip = DataBinder.Eval(e.Item.DataItem, "Agent_Comments").ToString();
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptContactUS_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "Delete"))
            return;
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("Xweb_Update_Lead", connection);
            selectCommand.Parameters.AddWithValue("@LeadID", e.CommandArgument);
            selectCommand.Parameters.AddWithValue("@Updated_By", UserCode);
            selectCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
            selectCommand.CommandType = CommandType.StoredProcedure;
            new SqlDataAdapter(selectCommand).Fill(new DataSet());
            BindData();
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

    protected void rptPreSignUp_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "Delete"))
            return;
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("Xweb_Update_Lead", connection);
            selectCommand.Parameters.AddWithValue("@LeadID", e.CommandArgument);
            selectCommand.Parameters.AddWithValue("@Updated_By", UserCode);
            selectCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
            selectCommand.CommandType = CommandType.StoredProcedure;
            new SqlDataAdapter(selectCommand).Fill(new DataSet());
            BindData();
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

    protected void rptFeedBack_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "Delete"))
            return;
        try
        {
            SqlCommand selectCommand = new SqlCommand("Xweb_Update_Lead", connection);
            selectCommand.Parameters.AddWithValue("@LeadID", e.CommandArgument);
            selectCommand.Parameters.AddWithValue("@Updated_By", UserCode);
            selectCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
            selectCommand.CommandType = CommandType.StoredProcedure;
            new SqlDataAdapter(selectCommand).Fill(new DataSet());
            BindData();
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

    protected void rptMagazine_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "Delete"))
            return;
        try
        {
            SqlCommand selectCommand = new SqlCommand("Xweb_Update_LeadMagazine", connection);
            selectCommand.Parameters.AddWithValue("@Subscription_Code", e.CommandArgument);
            selectCommand.Parameters.AddWithValue("@Updated_By", UserCode);
            selectCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
            selectCommand.CommandType = CommandType.StoredProcedure;
            new SqlDataAdapter(selectCommand).Fill(new DataSet());
            BindData();
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

    protected void rptOther_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "Delete"))
            return;
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("Xweb_Update_Lead", connection);
            sqlCommand.Parameters.AddWithValue("@LeadID", e.CommandArgument);
            sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
            sqlCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            Convert.ToString(sqlCommand.ExecuteScalar());
            BindData();
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

    protected void rptBusEmp_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "Delete"))
            return;
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("Xweb_Update_Lead", connection);
            sqlCommand.Parameters.AddWithValue("@LeadID", e.CommandArgument);
            sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
            sqlCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            Convert.ToString(sqlCommand.ExecuteScalar());
            BindData();
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
            BindData();
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

    private void BindData()
    {
        if (ddlSignupType.SelectedValue != "10")
        {
            SqlCommand selectCommand = new SqlCommand("Xweb_Select_SignupLeads", connection);
            if (ddlIndustry.SelectedValue != "0")
                selectCommand.Parameters.AddWithValue("@Industry_Code", ddlIndustry.SelectedValue);
            if (ddlIntrest.SelectedValue != "0")
                selectCommand.Parameters.AddWithValue("@Intrest_Code", ddlIntrest.SelectedValue);
            if (ddlDesignation.SelectedValue != "0")
                selectCommand.Parameters.AddWithValue("@Designation_Code", ddlDesignation.SelectedValue);
            if (ddlFeedBackType.SelectedValue != "0")
                selectCommand.Parameters.AddWithValue("@FeedbackType_Code", ddlFeedBackType.SelectedValue);
            selectCommand.Parameters.AddWithValue("@SignUpType_Code", ddlSignupType.SelectedValue);
            if (ddlCountry.SelectedValue != "-1")
                selectCommand.Parameters.AddWithValue("@County_Code", ddlCountry.SelectedValue);
            selectCommand.Parameters.AddWithValue("@Name", txtName.Text.Trim());
            selectCommand.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            selectCommand.Parameters.AddWithValue("@FromDate", postedFromDate.Value);
            selectCommand.Parameters.AddWithValue("@ToDate", postedToDate.Value);
            if (ddlSignupType.SelectedValue == "0")
                selectCommand.Parameters.AddWithValue("@ProductID", ddlProduct.SelectedValue);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            Leads_ViewAllLeads.PageSize = 25;
            rptMagazine.Visible = false;
            rptFeedBack.Visible = false;
            rptPreSignUp.Visible = false;
            rptContactUS.Visible = false;
            rptOther.Visible = false;
            trPagingControlsMagazine.Attributes.Add("style", "display:none");
            trPagingControlsOther.Attributes.Add("style", "display:none");
            trPagingControlsFeedBack.Attributes.Add("style", "display:none");
            trPagingControlsPreSignup.Attributes.Add("style", "display:none");
            trPagingControlsContactUS.Attributes.Add("style", "display:none");
            if (ddlSignupType.SelectedValue == "5" || ddlSignupType.SelectedValue == "6")
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    Leads_ViewAllLeads.objDV = dataSet.Tables[0].DefaultView;
                    PageNoFeedBack = 0;
                    rptFeedBack.Visible = true;
                    lblMsg.Visible = false;
                    rptFeedBack.DataSource = ApplyPagingFeedBack(Leads_ViewAllLeads.objDV, PageNoFeedBack);
                    rptFeedBack.DataBind();
                }
                else
                {
                    rptFeedBack.DataSource = null;
                    rptFeedBack.Visible = false;
                    lblMsg.Text = "No Data";
                    lblMsg.Visible = true;
                }
            }
            else if (ddlSignupType.SelectedValue == "7")
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    Leads_ViewAllLeads.objDV = dataSet.Tables[0].DefaultView;
                    PageNoPreSignUP = 0;
                    rptPreSignUp.Visible = true;
                    lblMsg.Visible = false;
                    rptPreSignUp.DataSource = ApplyPagingPreSignUp(Leads_ViewAllLeads.objDV, PageNoPreSignUP);
                    rptPreSignUp.DataBind();
                }
                else
                {
                    rptPreSignUp.DataSource = null;
                    rptPreSignUp.Visible = false;
                    lblMsg.Text = "No Data";
                    lblMsg.Visible = true;
                }
            }
            else if (ddlSignupType.SelectedValue == "8")
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    Leads_ViewAllLeads.objDV = dataSet.Tables[0].DefaultView;
                    PageNoContactUS = 0;
                    rptContactUS.Visible = true;
                    lblMsg.Visible = false;
                    rptContactUS.DataSource = ApplyPagingContactUS(Leads_ViewAllLeads.objDV, PageNoContactUS);
                    rptContactUS.DataBind();
                }
                else
                {
                    rptContactUS.DataSource = null;
                    rptContactUS.Visible = false;
                    lblMsg.Text = "No Data";
                    lblMsg.Visible = true;
                }
            }
            else if (ddlSignupType.SelectedValue == "0")
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    Leads_ViewAllLeads.objDV = dataSet.Tables[0].DefaultView;
                    PageNoOther = 0;
                    rptOther.Visible = true;
                    lblMsg.Visible = false;
                    rptOther.DataSource = ApplyPagingOther(Leads_ViewAllLeads.objDV, PageNoOther);
                    rptOther.DataBind();
                }
                else
                {
                    rptOther.DataSource = null;
                    rptOther.Visible = false;
                    lblMsg.Text = "No Data";
                    lblMsg.Visible = true;
                }
            }
            else
            {
                if (!(ddlSignupType.SelectedValue == "9"))
                    return;
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    Leads_ViewAllLeads.objDV = dataSet.Tables[0].DefaultView;
                    PageNoBusEmp = 0;
                    rptBusEmp.Visible = true;
                    lblMsg.Visible = false;
                    rptBusEmp.DataSource = ApplyPagingBusEmp(Leads_ViewAllLeads.objDV, PageNoBusEmp);
                    rptBusEmp.DataBind();
                }
                else
                {
                    rptBusEmp.DataSource = null;
                    rptBusEmp.Visible = false;
                    lblMsg.Text = "No Data";
                    lblMsg.Visible = true;
                }
            }
        }
        else
        {
            SqlCommand selectCommand = new SqlCommand("Xweb_Select_SignupLeadsForMagazineSubs", connection);
            if (ddlCountry.SelectedValue != "-1")
                selectCommand.Parameters.AddWithValue("@County_Code", ddlCountry.SelectedValue);
            selectCommand.Parameters.AddWithValue("@Name", txtName.Text.Trim());
            selectCommand.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            selectCommand.Parameters.AddWithValue("@FromDate", postedFromDate.Value);
            selectCommand.Parameters.AddWithValue("@ToDate", postedToDate.Value);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            Leads_ViewAllLeads.PageSize = 25;
            rptBusEmp.Visible = false;
            rptMagazine.Visible = false;
            rptFeedBack.Visible = false;
            rptPreSignUp.Visible = false;
            rptContactUS.Visible = false;
            rptOther.Visible = false;
            trPagingControlsMagazine.Attributes.Add("style", "display:none");
            trPagingControlsOther.Attributes.Add("style", "display:none");
            trPagingControlsFeedBack.Attributes.Add("style", "display:none");
            trPagingControlsPreSignup.Attributes.Add("style", "display:none");
            trPagingControlsContactUS.Attributes.Add("style", "display:none");
            trPagingControlsBusEmp.Attributes.Add("style", "display:none");
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                Leads_ViewAllLeads.objDV = dataSet.Tables[0].DefaultView;
                PageNoMagazine = 0;
                rptMagazine.Visible = true;
                lblMsg.Visible = false;
                rptMagazine.DataSource = ApplyPagingMagazine(Leads_ViewAllLeads.objDV, PageNoMagazine);
                rptMagazine.DataBind();
            }
            else
            {
                rptMagazine.DataSource = null;
                rptMagazine.Visible = false;
                lblMsg.Text = "No Data";
                lblMsg.Visible = true;
            }
        }
    }

    private void BindOGData(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("Xweb_Select_SearchCriteria", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            ddlIndustry.DataSource = dataSet.Tables[0];
            ddlIndustry.DataTextField = "IndustryName";
            ddlIndustry.DataValueField = "IndustryID";
            ddlIndustry.DataBind();
            ddlIndustry.Items.Insert(0, new ListItem("----All----", "0"));
        }
        if (dataSet.Tables[1].Rows.Count > 0)
        {
            ddlIntrest.DataSource = dataSet.Tables[1];
            ddlIntrest.DataTextField = "IntrestName";
            ddlIntrest.DataValueField = "IntrestID";
            ddlIntrest.DataBind();
            ddlIntrest.Items.Insert(0, new ListItem("----All----", "0"));
        }
        if (dataSet.Tables[2].Rows.Count > 0)
        {
            ddlDesignation.DataSource = dataSet.Tables[2];
            ddlDesignation.DataTextField = "DesignationName";
            ddlDesignation.DataValueField = "DesignationID";
            ddlDesignation.DataBind();
            ddlDesignation.Items.Insert(0, new ListItem("----All----", "0"));
        }
        if (dataSet.Tables[3].Rows.Count > 0)
        {
            ddlFeedBackType.DataSource = dataSet.Tables[3];
            ddlFeedBackType.DataTextField = "FeedbackTypeName";
            ddlFeedBackType.DataValueField = "FeedbackTypeID";
            ddlFeedBackType.DataBind();
            ddlFeedBackType.Items.Insert(0, new ListItem("----All----", "0"));
        }
        if (dataSet.Tables[4].Rows.Count > 0)
        {
            ddlSignupType.DataSource = dataSet.Tables[4];
            ddlSignupType.DataTextField = "SignupTypeName";
            ddlSignupType.DataValueField = "SignupTypeID";
            ddlSignupType.DataBind();
        }
        if (dataSet.Tables[5].Rows.Count > 0)
        {
            ddlCountry.DataSource = dataSet.Tables[5];
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "CountryCode";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("----All----", "-1"));
        }
        if (dataSet.Tables[6].Rows.Count <= 0)
            return;
        ddlProduct.DataSource = dataSet.Tables[6];
        ddlProduct.DataTextField = "ProductName";
        ddlProduct.DataValueField = "ProductID";
        ddlProduct.DataBind();
        ddlProduct.Items.Insert(0, new ListItem("----All----", "-1"));
    }

    public PagedDataSource ApplyPagingFeedBack(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Leads_ViewAllLeads.PageSize;
        objPDS.CurrentPageIndex = PageNo;
        ViewState["PageCountFeedBack"] = objPDS.PageCount.ToString();
        if (objPDS.PageCount > 1)
        {
            trPagingControlsFeedBack.Attributes.Add("style", "display:''");
            trPagingControlsPreSignup.Attributes.Add("style", "display:none");
            trPagingControlsContactUS.Attributes.Add("style", "display:none");
            trPagingControlsOther.Attributes.Add("style", "display:none ");
            lblPageIndexFeedBack.Visible = true;
            lblPageIndexSignUp.Visible = false;
            lblPageIndexContact.Visible = false;
            lblPageIndexOther.Visible = false;
            lblPageIndexFeedBack.Text = "Page : " + (objPDS.CurrentPageIndex + 1).ToString() + " of " + objPDS.PageCount.ToString();
            if (objPDS.CurrentPageIndex == 0)
            {
                lnkbtnFirstPageFeedBack.Visible = false;
                lnkbtnLastPageFeedBack.Visible = true;
                lnkbtnNextPageFeedBack.Visible = true;
                lnkbtnPrevPageFeedBack.Visible = false;
            }
            else if (objPDS.CurrentPageIndex == objPDS.PageCount - 1)
            {
                lnkbtnFirstPageFeedBack.Visible = true;
                lnkbtnLastPageFeedBack.Visible = false;
                lnkbtnNextPageFeedBack.Visible = false;
                lnkbtnPrevPageFeedBack.Visible = true;
            }
            else
            {
                lnkbtnFirstPageFeedBack.Visible = true;
                lnkbtnLastPageFeedBack.Visible = true;
                lnkbtnNextPageFeedBack.Visible = true;
                lnkbtnPrevPageFeedBack.Visible = true;
            }
        }
        else
        {
            trPagingControlsFeedBack.Attributes.Add("style", "display:none");
            trPagingControlsPreSignup.Attributes.Add("style", "display:none");
            trPagingControlsContactUS.Attributes.Add("style", "display:none");
            trPagingControlsOther.Attributes.Add("style", "display:none ");
            trPagingControlsBusEmp.Attributes.Add("style", "display:none");
            trPagingControlsMagazine.Attributes.Add("style", "display:none");
        }
        return objPDS;
    }

    public PagedDataSource ApplyPagingMagazine(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Leads_ViewAllLeads.PageSize;
        objPDS.CurrentPageIndex = PageNo;
        ViewState["PageCountMagazine"] = objPDS.PageCount.ToString();
        if (objPDS.PageCount > 1)
        {
            trPagingControlsMagazine.Attributes.Add("style", "display:''");
            trPagingControlsFeedBack.Attributes.Add("style", "display:none");
            trPagingControlsPreSignup.Attributes.Add("style", "display:none");
            trPagingControlsContactUS.Attributes.Add("style", "display:none");
            trPagingControlsOther.Attributes.Add("style", "display:none ");
            trPagingControlsBusEmp.Attributes.Add("style", "display:none ");
            lblPageIndexMagazine.Visible = true;
            lblPageIndexFeedBack.Visible = false;
            lblPageIndexSignUp.Visible = false;
            lblPageIndexContact.Visible = false;
            lblPageIndexBusEmp.Visible = false;
            lblPageIndexOther.Visible = false;
            lblPageIndexMagazine.Text = "Page : " + (objPDS.CurrentPageIndex + 1).ToString() + " of " + objPDS.PageCount.ToString();
            if (objPDS.CurrentPageIndex == 0)
            {
                lnkbtnFirstPageMagazine.Visible = false;
                lnkbtnLastPageMagazine.Visible = true;
                lnkbtnNextPageMagazine.Visible = true;
                lnkbtnPrevPageMagazine.Visible = false;
            }
            else if (objPDS.CurrentPageIndex == objPDS.PageCount - 1)
            {
                lnkbtnFirstPageMagazine.Visible = true;
                lnkbtnLastPageMagazine.Visible = false;
                lnkbtnNextPageMagazine.Visible = false;
                lnkbtnPrevPageMagazine.Visible = true;
            }
            else
            {
                lnkbtnFirstPageMagazine.Visible = true;
                lnkbtnLastPageMagazine.Visible = true;
                lnkbtnNextPageMagazine.Visible = true;
                lnkbtnPrevPageMagazine.Visible = true;
            }
        }
        else
        {
            trPagingControlsMagazine.Attributes.Add("style", "display:none");
            trPagingControlsFeedBack.Attributes.Add("style", "display:none");
            trPagingControlsPreSignup.Attributes.Add("style", "display:none");
            trPagingControlsContactUS.Attributes.Add("style", "display:none");
            trPagingControlsOther.Attributes.Add("style", "display:none ");
            trPagingControlsBusEmp.Attributes.Add("style", "display:none");
        }
        return objPDS;
    }

    public PagedDataSource ApplyPagingPreSignUp(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Leads_ViewAllLeads.PageSize;
        objPDS.CurrentPageIndex = PageNo;
        ViewState["PageCountPreSignUp"] = objPDS.PageCount.ToString();
        if (objPDS.PageCount > 1)
        {
            trPagingControlsPreSignup.Attributes.Add("style", "display:''");
            trPagingControlsFeedBack.Attributes.Add("style", "display:none");
            trPagingControlsContactUS.Attributes.Add("style", "display:none");
            trPagingControlsOther.Attributes.Add("style", "display:none");
            lblPageIndexSignUp.Visible = true;
            lblPageIndexFeedBack.Visible = false;
            lblPageIndexContact.Visible = false;
            lblPageIndexOther.Visible = false;
            lblPageIndexSignUp.Text = "Page : " + (objPDS.CurrentPageIndex + 1).ToString() + " of " + objPDS.PageCount.ToString();
            if (objPDS.CurrentPageIndex == 0)
            {
                lnkbtnFirstPageSignup.Visible = false;
                lnkbtnLastPageSignUp.Visible = true;
                lnkbtnNextPageSignUp.Visible = true;
                lnkbtnPrevPageSignUp.Visible = false;
            }
            else if (objPDS.CurrentPageIndex == objPDS.PageCount - 1)
            {
                lnkbtnFirstPageSignup.Visible = true;
                lnkbtnLastPageSignUp.Visible = false;
                lnkbtnNextPageSignUp.Visible = false;
                lnkbtnPrevPageSignUp.Visible = true;
            }
            else
            {
                lnkbtnFirstPageSignup.Visible = true;
                lnkbtnLastPageSignUp.Visible = true;
                lnkbtnNextPageSignUp.Visible = true;
                lnkbtnPrevPageSignUp.Visible = true;
            }
        }
        else
        {
            trPagingControlsPreSignup.Attributes.Add("style", "display:none");
            trPagingControlsFeedBack.Attributes.Add("style", "display:none");
            trPagingControlsContactUS.Attributes.Add("style", "display:none");
            trPagingControlsOther.Attributes.Add("style", "display:none");
            trPagingControlsBusEmp.Attributes.Add("style", "display:none");
            trPagingControlsMagazine.Attributes.Add("style", "display:none");
        }
        return objPDS;
    }

    public PagedDataSource ApplyPagingContactUS(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Leads_ViewAllLeads.PageSize;
        objPDS.CurrentPageIndex = PageNo;
        ViewState["PageCountContactUS"] = objPDS.PageCount.ToString();
        if (objPDS.PageCount > 1)
        {
            trPagingControlsContactUS.Attributes.Add("style", "display:''");
            trPagingControlsFeedBack.Attributes.Add("style", "display:none");
            trPagingControlsPreSignup.Attributes.Add("style", "display:none");
            trPagingControlsOther.Attributes.Add("style", "display:none");
            lblPageIndexContact.Visible = true;
            lblPageIndexFeedBack.Visible = false;
            lblPageIndexSignUp.Visible = false;
            lblPageIndexOther.Visible = false;
            lblPageIndexContact.Text = "Page : " + (objPDS.CurrentPageIndex + 1).ToString() + " of " + objPDS.PageCount.ToString();
            if (objPDS.CurrentPageIndex == 0)
            {
                lnkbtnFirstPageContact.Visible = false;
                lnkbtnLastPageContact.Visible = true;
                lnkbtnNextPageContact.Visible = true;
                lnkbtnPrevPageContact.Visible = false;
            }
            else if (objPDS.CurrentPageIndex == objPDS.PageCount - 1)
            {
                lnkbtnFirstPageContact.Visible = true;
                lnkbtnLastPageContact.Visible = false;
                lnkbtnNextPageContact.Visible = false;
                lnkbtnPrevPageContact.Visible = true;
            }
            else
            {
                lnkbtnFirstPageContact.Visible = true;
                lnkbtnLastPageContact.Visible = true;
                lnkbtnNextPageContact.Visible = true;
                lnkbtnPrevPageContact.Visible = true;
            }
        }
        else
        {
            trPagingControlsContactUS.Attributes.Add("style", "display:none");
            trPagingControlsFeedBack.Attributes.Add("style", "display:none");
            trPagingControlsPreSignup.Attributes.Add("style", "display:none");
            trPagingControlsOther.Attributes.Add("style", "display:none");
            trPagingControlsBusEmp.Attributes.Add("style", "display:none");
            trPagingControlsMagazine.Attributes.Add("style", "display:none");
        }
        return objPDS;
    }

    public PagedDataSource ApplyPagingOther(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Leads_ViewAllLeads.PageSize;
        objPDS.CurrentPageIndex = PageNo;
        ViewState["PageCountOther"] = objPDS.PageCount.ToString();
        if (objPDS.PageCount > 1)
        {
            trPagingControlsOther.Attributes.Add("style", "display:''");
            trPagingControlsFeedBack.Attributes.Add("style", "display:none");
            trPagingControlsPreSignup.Attributes.Add("style", "display:none");
            trPagingControlsContactUS.Attributes.Add("style", "display:none");
            lblPageIndexOther.Visible = true;
            lblPageIndexFeedBack.Visible = false;
            lblPageIndexSignUp.Visible = false;
            lblPageIndexContact.Visible = false;
            lblPageIndexOther.Text = "Page : " + (objPDS.CurrentPageIndex + 1).ToString() + " of " + objPDS.PageCount.ToString();
            if (objPDS.CurrentPageIndex == 0)
            {
                lnkbtnFirstPageOther.Visible = false;
                lnkbtnLastPageOther.Visible = true;
                lnkbtnNextPageOther.Visible = true;
                lnkbtnPrevPageOther.Visible = false;
            }
            else if (objPDS.CurrentPageIndex == objPDS.PageCount - 1)
            {
                lnkbtnFirstPageOther.Visible = true;
                lnkbtnLastPageOther.Visible = false;
                lnkbtnNextPageOther.Visible = false;
                lnkbtnPrevPageOther.Visible = true;
            }
            else
            {
                lnkbtnFirstPageOther.Visible = true;
                lnkbtnLastPageOther.Visible = true;
                lnkbtnNextPageOther.Visible = true;
                lnkbtnPrevPageOther.Visible = true;
            }
        }
        else
        {
            trPagingControlsOther.Attributes.Add("style", "display:none");
            trPagingControlsFeedBack.Attributes.Add("style", "display:none");
            trPagingControlsPreSignup.Attributes.Add("style", "display:none");
            trPagingControlsContactUS.Attributes.Add("style", "display:none");
            trPagingControlsBusEmp.Attributes.Add("style", "display:none");
            trPagingControlsMagazine.Attributes.Add("style", "display:none");
        }
        return objPDS;
    }

    public PagedDataSource ApplyPagingBusEmp(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Leads_ViewAllLeads.PageSize;
        objPDS.CurrentPageIndex = PageNo;
        ViewState["PageCountBusEmp"] = objPDS.PageCount.ToString();
        if (objPDS.PageCount > 1)
        {
            trPagingControlsBusEmp.Attributes.Add("style", "display:''");
            trPagingControlsOther.Attributes.Add("style", "display:none");
            trPagingControlsFeedBack.Attributes.Add("style", "display:none");
            trPagingControlsPreSignup.Attributes.Add("style", "display:none");
            trPagingControlsContactUS.Attributes.Add("style", "display:none");
            trPagingControlsMagazine.Attributes.Add("style", "display:none");
            lblPageIndexBusEmp.Visible = true;
            lblPageIndexFeedBack.Visible = false;
            lblPageIndexSignUp.Visible = false;
            lblPageIndexContact.Visible = false;
            lblPageIndexMagazine.Visible = false;
            lblPageIndexBusEmp.Text = "Page : " + (objPDS.CurrentPageIndex + 1).ToString() + " of " + objPDS.PageCount.ToString();
            if (objPDS.CurrentPageIndex == 0)
            {
                lnkbtnFirstPageBusEmp.Visible = false;
                lnkbtnLastPageBusEmp.Visible = true;
                lnkbtnNextPageBusEmp.Visible = true;
                lnkbtnPrevPageBusEmp.Visible = false;
            }
            else if (objPDS.CurrentPageIndex == objPDS.PageCount - 1)
            {
                lnkbtnFirstPageBusEmp.Visible = true;
                lnkbtnLastPageBusEmp.Visible = false;
                lnkbtnNextPageBusEmp.Visible = false;
                lnkbtnPrevPageBusEmp.Visible = true;
            }
            else
            {
                lnkbtnFirstPageBusEmp.Visible = true;
                lnkbtnLastPageBusEmp.Visible = true;
                lnkbtnNextPageBusEmp.Visible = true;
                lnkbtnPrevPageBusEmp.Visible = true;
            }
        }
        else
        {
            trPagingControlsBusEmp.Attributes.Add("style", "display:none");
            trPagingControlsMagazine.Attributes.Add("style", "display:none");
            trPagingControlsFeedBack.Attributes.Add("style", "display:none");
            trPagingControlsPreSignup.Attributes.Add("style", "display:none");
            trPagingControlsContactUS.Attributes.Add("style", "display:none");
        }
        return objPDS;
    }

    protected void lnkbtnFirstPageFeedBack_Click(object sender, EventArgs e)
    {
        PageNoFeedBack = 0;
        rptFeedBack.DataSource = ApplyPagingFeedBack(Leads_ViewAllLeads.objDV, PageNoFeedBack);
        rptFeedBack.DataBind();
    }

    protected void lnkbtnPrevPageFeedBack_Click(object sender, EventArgs e)
    {
        --PageNoFeedBack;
        rptFeedBack.DataSource = ApplyPagingFeedBack(Leads_ViewAllLeads.objDV, PageNoFeedBack);
        rptFeedBack.DataBind();
    }

    protected void lnkbtnNextPageFeedBack_Click(object sender, EventArgs e)
    {
        ++PageNoFeedBack;
        rptFeedBack.DataSource = ApplyPagingFeedBack(Leads_ViewAllLeads.objDV, PageNoFeedBack);
        rptFeedBack.DataBind();
    }

    protected void lnkbtnLastPageFeedBack_Click(object sender, EventArgs e)
    {
        PageNoFeedBack = Convert.ToInt32(ViewState["PageCountFeedBack"]) - 1;
        rptFeedBack.DataSource = ApplyPagingFeedBack(Leads_ViewAllLeads.objDV, PageNoFeedBack);
        rptFeedBack.DataBind();
    }

    protected void lnkbtnFirstPageSignup_Click(object sender, EventArgs e)
    {
        PageNoPreSignUP = 0;
        rptPreSignUp.DataSource = ApplyPagingPreSignUp(Leads_ViewAllLeads.objDV, PageNoPreSignUP);
        rptPreSignUp.DataBind();
    }

    protected void lnkbtnPrevPageSignUp_Click(object sender, EventArgs e)
    {
        --PageNoPreSignUP;
        rptPreSignUp.DataSource = ApplyPagingPreSignUp(Leads_ViewAllLeads.objDV, PageNoPreSignUP);
        rptPreSignUp.DataBind();
    }

    protected void lnkbtnNextPageSignUp_Click(object sender, EventArgs e)
    {
        ++PageNoPreSignUP;
        rptPreSignUp.DataSource = ApplyPagingPreSignUp(Leads_ViewAllLeads.objDV, PageNoPreSignUP);
        rptPreSignUp.DataBind();
    }

    protected void lnkbtnLastPageSignUp_Click(object sender, EventArgs e)
    {
        PageNoPreSignUP = Convert.ToInt32(ViewState["PageCountPreSignUp"]) - 1;
        rptPreSignUp.DataSource = ApplyPagingPreSignUp(Leads_ViewAllLeads.objDV, PageNoPreSignUP);
        rptPreSignUp.DataBind();
    }

    protected void lnkbtnFirstPageContact_Click(object sender, EventArgs e)
    {
        PageNoContactUS = 0;
        rptContactUS.DataSource = ApplyPagingContactUS(Leads_ViewAllLeads.objDV, PageNoContactUS);
        rptContactUS.DataBind();
    }

    protected void lnkbtnPrevPageContact_Click(object sender, EventArgs e)
    {
        --PageNoContactUS;
        rptContactUS.DataSource = ApplyPagingContactUS(Leads_ViewAllLeads.objDV, PageNoContactUS);
        rptContactUS.DataBind();
    }

    protected void lnkbtnNextPageContact_Click(object sender, EventArgs e)
    {
        ++PageNoContactUS;
        rptContactUS.DataSource = ApplyPagingContactUS(Leads_ViewAllLeads.objDV, PageNoContactUS);
        rptContactUS.DataBind();
    }

    protected void lnkbtnLastPageContact_Click(object sender, EventArgs e)
    {
        PageNoContactUS = Convert.ToInt32(ViewState["PageCountContactUS"]) - 1;
        rptContactUS.DataSource = ApplyPagingContactUS(Leads_ViewAllLeads.objDV, PageNoContactUS);
        rptContactUS.DataBind();
    }

    protected void lnkbtnFirstPageOther_Click(object sender, EventArgs e)
    {
        PageNoOther = 0;
        rptOther.DataSource = ApplyPagingOther(Leads_ViewAllLeads.objDV, PageNoOther);
        rptOther.DataBind();
    }

    protected void lnkbtnPrevPageOther_Click(object sender, EventArgs e)
    {
        --PageNoOther;
        rptOther.DataSource = ApplyPagingOther(Leads_ViewAllLeads.objDV, PageNoOther);
        rptOther.DataBind();
    }

    protected void lnkbtnNextPageOther_Click(object sender, EventArgs e)
    {
        ++PageNoOther;
        rptOther.DataSource = ApplyPagingOther(Leads_ViewAllLeads.objDV, PageNoOther);
        rptOther.DataBind();
    }

    protected void lnkbtnLastPageOther_Click(object sender, EventArgs e)
    {
        PageNoOther = Convert.ToInt32(ViewState["PageCountOther"]) - 1;
        rptOther.DataSource = ApplyPagingOther(Leads_ViewAllLeads.objDV, PageNoOther);
        rptOther.DataBind();
    }

    protected void lnkbtnFirstPageMagazine_Click(object sender, EventArgs e)
    {
        PageNoMagazine = 0;
        rptMagazine.DataSource = ApplyPagingMagazine(Leads_ViewAllLeads.objDV, PageNoMagazine);
        rptMagazine.DataBind();
    }

    protected void lnkbtnPrevPageMagazine_Click(object sender, EventArgs e)
    {
        --PageNoMagazine;
        rptMagazine.DataSource = ApplyPagingMagazine(Leads_ViewAllLeads.objDV, PageNoMagazine);
        rptMagazine.DataBind();
    }

    protected void lnkbtnNextPageMagazine_Click(object sender, EventArgs e)
    {
        ++PageNoMagazine;
        rptMagazine.DataSource = ApplyPagingMagazine(Leads_ViewAllLeads.objDV, PageNoMagazine);
        rptMagazine.DataBind();
    }

    protected void lnkbtnLastPageMagazine_Click(object sender, EventArgs e)
    {
        PageNoMagazine = Convert.ToInt32(ViewState["PageCountMagazine"]) - 1;
        rptMagazine.DataSource = ApplyPagingMagazine(Leads_ViewAllLeads.objDV, PageNoMagazine);
        rptMagazine.DataBind();
    }

    protected void lnkbtnFirstPageBusEmp_Click(object sender, EventArgs e)
    {
        PageNoBusEmp = 0;
        rptBusEmp.DataSource = ApplyPagingBusEmp(Leads_ViewAllLeads.objDV, PageNoBusEmp);
        rptBusEmp.DataBind();
    }

    protected void lnkbtnPrevPageBusEmp_Click(object sender, EventArgs e)
    {
        --PageNoBusEmp;
        rptBusEmp.DataSource = ApplyPagingBusEmp(Leads_ViewAllLeads.objDV, PageNoBusEmp);
        rptBusEmp.DataBind();
    }

    protected void lnkbtnNextPageBusEmp_Click(object sender, EventArgs e)
    {
        ++PageNoBusEmp;
        rptBusEmp.DataSource = ApplyPagingBusEmp(Leads_ViewAllLeads.objDV, PageNoBusEmp);
        rptBusEmp.DataBind();
    }

    protected void lnkbtnLastPageBusEmp_Click(object sender, EventArgs e)
    {
        PageNoBusEmp = Convert.ToInt32(ViewState["PageCountBusEmp"]) - 1;
        rptBusEmp.DataSource = ApplyPagingBusEmp(Leads_ViewAllLeads.objDV, PageNoBusEmp);
        rptBusEmp.DataBind();
    }
    #endregion
}