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


public partial class Leads_AddAgentLead : CustomBasePage
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            Leads_AddAgentLead.PageSize = 25;
            connection.Open();
            BindData();
            ddlProductType_SelectedIndexChanged(null, (EventArgs)null);
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

    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            string empty = string.Empty;
            SqlCommand selectCommand = new SqlCommand("Rec_Insert_SignupLeadAgent", connection);
            selectCommand.Parameters.AddWithValue("@Company_Name", txtComapanyName.Text);
            selectCommand.Parameters.AddWithValue("@Industry_Code", ddlIndustry.SelectedValue);
            selectCommand.Parameters.AddWithValue("@Industry_Name", ddlIndustry.SelectedItem.Text);
            selectCommand.Parameters.AddWithValue("@Intrest_Code", ddlInterest.SelectedValue);
            selectCommand.Parameters.AddWithValue("@Intrest_Name", ddlInterest.SelectedItem.Text);
            selectCommand.Parameters.AddWithValue("@Name", txtName.Text);
            selectCommand.Parameters.AddWithValue("@Email", txtemail.Text);
            selectCommand.Parameters.AddWithValue("@County_Code", ddlCountry.SelectedValue);
            selectCommand.Parameters.AddWithValue("@Phone_Code", txtphonecode.Text);
            selectCommand.Parameters.AddWithValue("@PhoneNo", txtphoneNo.Text);
            selectCommand.Parameters.AddWithValue("@Designation_Code", ddlDesignation.SelectedValue);
            selectCommand.Parameters.AddWithValue("@Designation", ddlDesignation.SelectedItem.Text);
            selectCommand.Parameters.AddWithValue("@SignUpType_Code", 1);
            selectCommand.Parameters.AddWithValue("@SignUpType_Name", "Product");
            selectCommand.Parameters.AddWithValue("@ProductID", ddlProduct.SelectedValue);
            selectCommand.Parameters.AddWithValue("@ProductName", ddlProduct.SelectedItem.Text);
            selectCommand.Parameters.AddWithValue("@Updated_By", UserCode);
            selectCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
            selectCommand.Parameters.AddWithValue("@AgentComment", txtComment.Text);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
                empty = dataSet.Tables[0].Rows[0][0].ToString();
            if (!(empty != string.Empty))
                return;
            lblMsg.Text = "Successfully Saved!!";
            lblMsg.Visible = true;
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

    protected void ddlProductType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            SqlCommand selectCommand = new SqlCommand("Rec_Select_Product", connection);
            selectCommand.Parameters.AddWithValue("@ProductTypeID", ddlProductType.SelectedValue);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count <= 0)
                return;
            ddlProduct.DataSource = null;
            ddlProduct.DataBind();
            ddlProduct.DataSource = dataSet;
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataValueField = "ProductID";
            ddlProduct.DataBind();
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
    }

    #endregion


}