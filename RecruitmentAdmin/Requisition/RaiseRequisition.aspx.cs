using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ErrorLog;

public partial class Requisition_RaiseRequisition : CustomBasePage
{
    #region Variables
    public string RequisitionCode = "0";
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());


    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        lblMsg.Visible = false;
        try
        {
            CheckQueryString();
            connection.Open();
            BindData(ref connection);
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

    private void BindRequisition(ref SqlConnection connection)
    {
        try
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
            ddlCategory.SelectedValue = dataSet.Tables[0].Rows[0]["Category_Code"].ToString();
            txtNoOfCandidate.Text = dataSet.Tables[0].Rows[0]["Quantity"].ToString();
            txtShortListCount.Text = dataSet.Tables[0].Rows[0]["ShortList_Count"].ToString();
            btnAdd.Text = "Update Requisition";
            lblHead.Text = "Edit Requisition";
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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            string str = InsertRequisition(ref connection);
            if (str == null || !(str != "") || !(str != "0"))
                return;
            lblMsg.Text = "Successfully Saved!";
            lblMsg.Visible = true;
            Page.RegisterStartupScript("Close", "<script language=JavaScript> CloseHighSlideWithParentRefresh();</script>");
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

    private void CheckQueryString()
    {
        if (Request.QueryString["RID"] == null)
            return;
        RequisitionCode = Request.QueryString["RID"].ToString();
        hdnRequisitionCode.Value = Request.QueryString["RID"].ToString();
    }

    private void BindData(ref SqlConnection connection)
    {
        SqlCommand selectCommand1 = new SqlCommand("XRec_SelectDomainByUser", connection);
        selectCommand1.Parameters.AddWithValue("@UserCode", UserCode);
        selectCommand1.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(selectCommand1);
        DataSet dataSet1 = new DataSet();
        sqlDataAdapter1.Fill(dataSet1);
        if (dataSet1.Tables[0].Rows.Count > 0)
        {
            ddlDomain.DataSource = dataSet1;
            ddlDomain.DataTextField = "Domain_Name";
            ddlDomain.DataValueField = "Domain_Code";
            ddlDomain.DataBind();
            ddlDomain.Items.Insert(0, new ListItem("--Select--", ""));
        }
        SqlCommand selectCommand2 = new SqlCommand("XRec_SelectCity", connection);
        selectCommand2.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
        DataSet dataSet2 = new DataSet();
        sqlDataAdapter2.Fill(dataSet2);
        if (dataSet2.Tables[0].Rows.Count <= 0)
            return;
        ddlCity.DataSource = dataSet2;
        ddlCity.DataTextField = "City";
        ddlCity.DataValueField = "City_Code";
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("--Select--", ""));
    }

    private string InsertRequisition(ref SqlConnection connection)
    {
        SqlCommand sqlCommand = new SqlCommand("XREC_Insert_Update_Requisition", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@RequisitionName", txtRequisitionName.Text);
        sqlCommand.Parameters.AddWithValue("@SubDomainCode", ddlSubDomain.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@Category_Code", ddlCategory.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@NoOfCandidate", txtNoOfCandidate.Text);
        sqlCommand.Parameters.AddWithValue("@ShortListCount", txtShortListCount.Text);
        sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
        sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
        sqlCommand.Parameters.AddWithValue("@RequisitionCode", hdnRequisitionCode.Value);
        sqlCommand.Parameters.AddWithValue("@CityCode", ddlCity.SelectedValue);
        return Convert.ToString(sqlCommand.ExecuteScalar());
    }

    #endregion


}