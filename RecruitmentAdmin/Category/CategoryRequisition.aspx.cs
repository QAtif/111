using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ErrorLog;
using System.Text;
using XRecruitmentStatusLibrary;


public partial class CategoryRequisition : CustomBasePage
{
    #region variables
   
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    SecureQueryString sQString = new SecureQueryString();
    public string listFilter = null;

    #endregion



    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            listFilter = (string)null;
            listFilter = BindName();
            if (IsPostBack)
                return;
            BindData();
            ShowHideActions();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private string BindName()
    {
        DataSet dataSet = new DataSet();
        connection.Open();
        SqlCommand selectCommand = new SqlCommand("XRec_SelectAllCategoryListByUser", connection);
        selectCommand.Parameters.AddWithValue("@UserCode", UserCode);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.ExecuteNonQuery();
        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
            sqlDataAdapter.Fill(dataSet);
        connection.Close();
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("[");
        for (int index = 0; index < dataSet.Tables[0].Rows.Count; ++index)
        {
            stringBuilder.Append("\"" + dataSet.Tables[0].Rows[index]["CatName"].ToString() + "\"");
            if (index != dataSet.Tables[0].Rows.Count - 1)
                stringBuilder.Append(",");
        }
        stringBuilder.Append("];");
        return stringBuilder.ToString();
    }

    private void ShowHideActions()
    {
        IEnumerable<HtmlGenericControl> allControlsOfType = Page.GetAllControlsOfType<HtmlGenericControl>();
        foreach (DataRow row in (InternalDataCollectionBase)DTActions.Rows)
        {
            foreach (Control control in allControlsOfType)
            {
                if (control.ClientID == "divAction" + row["MenuLinkActionCode"].ToString())
                    control.Visible = true;
            }
        }
    }

    protected void rptCategoryList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.Item)
                return;
            DataBinder.Eval(e.Item.DataItem, "CatCode");
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnRR");
            ((HtmlControl)e.Item.FindControl("aAddREquisition")).Attributes.Add("onclick", "openMyModal('" + ("AddRequisition.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + control1.Value)) + "'); return false;");
            HtmlAnchor control2 = (HtmlAnchor)e.Item.FindControl("aApprove");
            HiddenField control3 = (HiddenField)e.Item.FindControl("hdnUsertype");
            string str = "/Category/ViewRequisition.aspx?PC=" + control1.Value + "&UTC=" + control3.Value;
            control2.Attributes.Add("href", str);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private void BindData()
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectAllCategoryListByUser", connection);
        selectCommand.Parameters.AddWithValue("@UserCode", UserCode);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            rptCategoryList.DataSource = dataSet.Tables[0];
            rptCategoryList.DataBind();
            cblDept.DataSource = dataSet.Tables[0];
            cblDept.DataTextField = "CatName";
            cblDept.DataValueField = "CatCode";
            cblDept.DataBind();
            if (dataSet.Tables.Count >= 2 && dataSet.Tables[2].Rows.Count > 0)
            {
                ddlDept1.DataSource = dataSet.Tables[2];
                ddlDept1.DataTextField = "DomainName";
                ddlDept1.DataValueField = "DomainCode";
                ddlDept1.DataBind();
                ddlDept1.Items.Insert(0, new ListItem("----All----", "-1"));
            }
            trnorecords.Visible = false;
        }
        else
            trnorecords.Visible = true;
        if (dataSet.Tables[1].Rows.Count <= 0)
            return;
        hdnUserTypeCode.Value = dataSet.Tables[1].Rows[0]["UserTypeCode"].ToString();
    }

    private void UpdateRequisitionStatus(int categoryCode, int requisitionStatusCode)
    {
        SqlCommand sqlCommand = new SqlCommand("UPdate_RequisitonStatus", connection);
        sqlCommand.Parameters.AddWithValue("@CategoryCode", categoryCode);
        sqlCommand.Parameters.AddWithValue("@UserCode", UserCode);
        sqlCommand.Parameters.AddWithValue("@UserTypeCode", hdnUserTypeCode.Value);
        sqlCommand.Parameters.AddWithValue("@RequisitionStatusCode", requisitionStatusCode);
        sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
        sqlCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.ExecuteNonQuery();
    }

    protected void rptCategoryList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            connection.Open();
            HiddenField control = (HiddenField)e.Item.FindControl("hdnRR");
            if (e.CommandName == "Approved")
            {
                if (hdnUserTypeCode.Value == Convert.ToInt32(Constants.UserTypeCode.DomainOwnerOtherDept).ToString())
                    UpdateRequisitionStatus(int.Parse(control.Value), Convert.ToInt32(Constants.RequisitionStatus.HRDOApprovalPending));
                if (hdnUserTypeCode.Value == Convert.ToInt32(Constants.UserTypeCode.DomainOwner).ToString())
                    UpdateRequisitionStatus(int.Parse(control.Value), Convert.ToInt32(Constants.RequisitionStatus.OPDApprovalPending));
                if (hdnUserTypeCode.Value == Convert.ToInt32(Constants.UserTypeCode.OPD).ToString())
                    UpdateRequisitionStatus(int.Parse(control.Value), Convert.ToInt32((Constants.RequisitionStatus)11));
            }
            if (e.CommandName == "Rejected")
            {
                if (hdnUserTypeCode.Value == Convert.ToInt32(Constants.UserTypeCode.DomainOwnerOtherDept).ToString())
                    UpdateRequisitionStatus(int.Parse(control.Value), Convert.ToInt32(Constants.RequisitionStatus.DORejected));
                if (hdnUserTypeCode.Value == Convert.ToInt32(Constants.UserTypeCode.DomainOwner).ToString())
                    UpdateRequisitionStatus(int.Parse(control.Value), Convert.ToInt32(Constants.RequisitionStatus.HRDOReject));
                if (hdnUserTypeCode.Value == Convert.ToInt32(Constants.UserTypeCode.OPD).ToString())
                    UpdateRequisitionStatus(int.Parse(control.Value), Convert.ToInt32(Constants.RequisitionStatus.OPDReject));
            }
            BindData();
            ShowHideActions();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    protected void btn_SearchClick(object sender, EventArgs e)
    {
        try
        {
            search();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    public void search()
    {
        try
        {
            string str = "";
            foreach (ListItem listItem in cblDept.Items)
            {
                if (listItem.Selected)
                    str = str + listItem.Value + ",";
            }
            str.TrimEnd(',');
            connection.Open();
            DataSet dataSet = new DataSet();
            rptCategoryList.DataSource = null;
            rptCategoryList.DataBind();
            SqlCommand selectCommand = new SqlCommand("XRec_SelectAllCategoryListByUserFilter", connection);
            if (ddlDept1.SelectedValue != "-1")
                selectCommand.Parameters.AddWithValue("@DeptCode", ddlDept1.SelectedValue);
            if (str != "" && !cbdept.Checked)
                selectCommand.Parameters.AddWithValue("@CatCode", str);
            selectCommand.Parameters.AddWithValue("@UserCode", UserCode);
            selectCommand.CommandType = CommandType.StoredProcedure;
            new SqlDataAdapter(selectCommand).Fill(dataSet);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                rptCategoryList.DataSource = dataSet.Tables[0];
                rptCategoryList.DataBind();
                ShowHideActions();
                trnorecords.Visible = false;
            }
            else
                trnorecords.Visible = true;
            connection.Close();
        }
        catch
        {
        }
    }



}