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

public partial class Leads_EditAgentLead : CustomBasePage
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
            Leads_EditAgentLead.PageSize = 25;
            CheckQueryString();
            connection.Open();
            BindData();
            ddlProductType_SelectedIndexChanged(null, (EventArgs)null);
            int num = hdnLeadID.Value != "0" ? 1 : 0;
            BindLead();
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
            if (ddlProduct.SelectedValue == "0" || ddlProduct.SelectedValue == "")
            {
                CustomValidator customValidator = new CustomValidator();
                customValidator.IsValid = false;
                customValidator.ErrorMessage = "Please Select Product.";
                customValidator.ValidationGroup = "valida";
                Page.Validators.Add((IValidator)customValidator);
            }
            else
            {
                SqlCommand selectCommand = new SqlCommand("Rec_Insert_SignupLeadAgent", connection);
                selectCommand.Parameters.AddWithValue("@Company_Name", txtcompanyname.Text);
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
                selectCommand.Parameters.AddWithValue("@ProductID", ddlProduct.SelectedValue);
                selectCommand.Parameters.AddWithValue("@ProductName", ddlProduct.SelectedItem.Text);
                selectCommand.Parameters.AddWithValue("@AgentComment", txtComment.Text);
                selectCommand.Parameters.AddWithValue("@Updated_By", UserCode);
                selectCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
                selectCommand.Parameters.AddWithValue("@UserID", hdnLeadID.Value);
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
                Page.RegisterStartupScript("Close", "<script language=JavaScript> ClosebtnClick();</script>");
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

    protected void ddlProductType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlProductType.SelectedValue != "" && ddlProductType.SelectedValue != "0")
            {
                SqlCommand selectCommand = new SqlCommand("Rec_Select_Product", connection);
                selectCommand.Parameters.AddWithValue("@ProductTypeID", ddlProductType.SelectedValue);
                selectCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    ddlProduct.DataSource = dataSet;
                    ddlProduct.DataTextField = "ProductName";
                    ddlProduct.DataValueField = "ProductID";
                    ddlProduct.DataBind();
                    ddlProduct.Items.Insert(0, new ListItem("--Select--", ""));
                }
                else
                {
                    ddlProduct.DataSource = null;
                    ddlProduct.DataBind();
                }
            }
            else
            {
                ddlProduct.DataSource = null;
                ddlProduct.Items.Clear();
                ddlProduct.Items.Insert(0, new ListItem("--Select--", ""));
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

    private void BindLead()
    {
    }

    private void CheckQueryString()
    {
        if (Request.QueryString["lCode"] == null)
            return;
        hdnLeadID.Value = Request.QueryString["lCode"].ToString();
    }

    private void BindData()
    {
        SqlCommand selectCommand = new SqlCommand("Rec_Select_LeadData", connection);
        selectCommand.Parameters.AddWithValue("@LeadID", hdnLeadID.Value);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        txtcompanyname.Text = dataSet.Tables[0].Rows[0]["Company_Name"].ToString();
        ddlIndustry.SelectedValue = dataSet.Tables[0].Rows[0]["Industry_Code"].ToString();
        ddlInterest.SelectedValue = dataSet.Tables[0].Rows[0]["Intrest_Code"].ToString();
        txtName.Text = dataSet.Tables[0].Rows[0]["Name"].ToString();
        ddlDesignation.SelectedValue = dataSet.Tables[0].Rows[0]["Designation_Code"].ToString();
        ddlCountry.SelectedValue = dataSet.Tables[0].Rows[0]["County_Code"].ToString();
        txtphonecode.Text = dataSet.Tables[0].Rows[0]["Phone_Code"].ToString();
        txtphoneNo.Text = dataSet.Tables[0].Rows[0]["PhoneNo"].ToString();
        txtemail.Text = dataSet.Tables[0].Rows[0]["Email"].ToString();
        ddlProductType.SelectedValue = dataSet.Tables[0].Rows[0]["ProductTypeID"].ToString();
        txtComment.Text = dataSet.Tables[0].Rows[0]["Agent_Comments"].ToString();
        if (dataSet.Tables[0].Rows[0]["ProductID"].ToString() != "0")
            ddlProduct.SelectedValue = dataSet.Tables[0].Rows[0]["ProductID"].ToString();
        else
            ddlProduct.SelectedValue = "";
    }
    #endregion

}