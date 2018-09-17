using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
public partial class Requisition_UpdateRequisitionStatus : CustomBasePage
{
    #region Variables
    string RequisitionCode = "0";
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    public string QueryStringVar = string.Empty;
    public SecureQueryString secQueryString;


    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
        secQueryString = new SecureQueryString(QueryStringVar);
        lblMsg.Visible = false;
        try
        {
            CheckQueryString();
            connection.Open();
            BindData(ref connection, RequisitionCode);
            if (!(RequisitionCode != "0"))
                return;
            BindRequisition(ref connection);
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

    protected void ddlSubDomain_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSubDomain.SelectedValue != "")
            {
                SqlCommand selectCommand = new SqlCommand("XRec_SelectCategoryBySubDomain", connection);
                selectCommand.Parameters.AddWithValue("@SubDomainCode", ddlSubDomain.SelectedValue);
                selectCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    ddlCategory.DataSource = dataSet;
                    ddlCategory.DataTextField = "Category_Name";
                    ddlCategory.DataValueField = "Category_Code";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("--Select--", ""));
                }
                else
                {
                    ddlCategory.Items.Clear();
                    ddlCategory.Items.Insert(0, new ListItem("--Select--", ""));
                }
            }
            else
            {
                ddlCategory.Items.Clear();
                ddlCategory.Items.Insert(0, new ListItem("--Select--", ""));
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void ddlDomain_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlDomain.SelectedValue != "")
            {
                ddlCategory.Items.Clear();
                ddlCategory.Items.Insert(0, new ListItem("--Select--", ""));
                SqlCommand selectCommand = new SqlCommand("XRec_SelectSubDomain", connection);
                selectCommand.Parameters.AddWithValue("@DomainCode", ddlDomain.SelectedValue);
                selectCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    ddlSubDomain.DataSource = dataSet;
                    ddlSubDomain.DataTextField = "SubDomain_Name";
                    ddlSubDomain.DataValueField = "SubDomain_Code";
                    ddlSubDomain.DataBind();
                    ddlSubDomain.Items.Insert(0, new ListItem("--Select--", ""));
                }
                else
                {
                    ddlSubDomain.Items.Clear();
                    ddlSubDomain.Items.Insert(0, new ListItem("--Select--", ""));
                }
            }
            else
            {
                ddlSubDomain.Items.Clear();
                ddlSubDomain.Items.Insert(0, new ListItem("--Select--", ""));
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            string str = InsertRequisition(ref connection);
            if (str != null && str != "" && str != "0")
            {
                lblMsg.Text = "Successfully Saved!";
                lblMsg.Visible = true;
            }
            Page.RegisterStartupScript("Close", "<script language=JavaScript> CloseHighSlideWithParentRefresh();</script>");
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private void BindRequisition(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectRequisitionByCode", connection);
        selectCommand.Parameters.AddWithValue("@RequisitionCode", RequisitionCode);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        txtRequisitionName.Text = dataSet.Tables[0].Rows[0]["Requisition_Name"].ToString();
        ddlDomain.SelectedValue = dataSet.Tables[0].Rows[0]["Domain_Code"].ToString();
        ddlDomain_SelectedIndexChanged(null, (EventArgs)null);
        ddlSubDomain.SelectedValue = dataSet.Tables[0].Rows[0]["SubDomain_Code"].ToString();
        ddlSubDomain_SelectedIndexChanged(null, (EventArgs)null);
        ddlCategory.SelectedValue = dataSet.Tables[0].Rows[0]["Category_Code"].ToString();
        txtNoOfCandidate.Text = dataSet.Tables[0].Rows[0]["Quantity"].ToString();
        ddlCity.SelectedValue = dataSet.Tables[0].Rows[0]["City_Code"].ToString();
        btnAdd.Text = "Update Requisition";
        lblHead.Text = "Edit Requisition";
    }

    private void CheckQueryString()
    {
        if (secQueryString["RID"] == null)
            return;
        RequisitionCode = secQueryString["RID"].ToString();
        hdnRequisitionCode.Value = secQueryString["RID"].ToString();
    }

    private void BindData(ref SqlConnection connection, string Requisition_Code)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectDomainByUser", connection);
        selectCommand.Parameters.AddWithValue("@UserCode", UserCode);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet == null)
            return;
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            ddlDomain.DataSource = dataSet;
            ddlDomain.DataTextField = "Domain_Name";
            ddlDomain.DataValueField = "Domain_Code";
            ddlDomain.DataBind();
            ddlDomain.Items.Insert(0, new ListItem("--Select--", ""));
        }
        if (dataSet.Tables.Count >= 2 && dataSet.Tables[1].Rows.Count > 0)
        {
            ddlSubDomain.DataSource = dataSet.Tables[1];
            ddlSubDomain.DataTextField = "subdomain_name";
            ddlSubDomain.DataValueField = "subdomain_code";
            ddlSubDomain.DataBind();
            ddlSubDomain.Items.Insert(0, new ListItem("--Select--", ""));
        }
        if (dataSet.Tables.Count >= 3 && dataSet.Tables[2].Rows.Count > 0)
        {
            ddlCity.DataSource = dataSet.Tables[2];
            ddlCity.DataTextField = "City";
            ddlCity.DataValueField = "City_Code";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("--Select--", ""));
        }
        if (dataSet.Tables.Count < 4 || dataSet.Tables[3].Rows.Count <= 0)
            return;
        ddlCategory.DataSource = dataSet.Tables[3];
        ddlCategory.DataTextField = "Category_Name";
        ddlCategory.DataValueField = "Category_Code";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("--Select--", ""));
    }

    private string InsertRequisition(ref SqlConnection connection)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Insert_Update_RequisitionStatus", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@RequisitionName", txtRequisitionName.Text);
        sqlCommand.Parameters.AddWithValue("@SubDomainCode", ddlSubDomain.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@Category_Code", ddlCategory.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@NoOfCandidate", txtNoOfCandidate.Text);
        sqlCommand.Parameters.AddWithValue("@DomainCode", ddlDomain.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", USERIP);
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        sqlCommand.Parameters.AddWithValue("@RequisitionCode", hdnRequisitionCode.Value);
        sqlCommand.Parameters.AddWithValue("@CityCode", ddlCity.SelectedValue);
        return Convert.ToString(sqlCommand.ExecuteScalar());
    }
    #endregion

}