using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Data;
using ErrorLog;
using System.Web.Services;


public partial class UniversalData_AddEditDeleteDomain : CustomBasePage
{
    #region Variables
    public static DataView objDV = new DataView();
    public static string SortDirection = "DESC";
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    PagedDataSource objPDS = new PagedDataSource();
    protected DataTable myDt;
    public string UpdatedBy;
    public string UpdatedIP;
    public int addDomainCount;
    public DataRow row;
    public static int PageSize;
    #endregion


    #region Events
    private int PageNo
    {
        get
        {
            if (ViewState["PageNo"] != null)
                return Convert.ToInt32(ViewState["PageNo"]);
            return 0;
        }
        set
        {
            ViewState["PageNo"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            UpdatedBy = UserCode.ToString();
            UpdatedIP = USERIP.ToString();
            if (string.IsNullOrEmpty(counter.Value))
                counter.Value = addDomainCount.ToString();
            UniversalData_AddEditDeleteDomain.PageSize = 25;
            connection.Open();
            GetRequisitionDetail(ref connection);
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

    protected void rptDomain_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(PageNo * UniversalData_AddEditDeleteDomain.PageSize + (e.Item.ItemIndex + 1));
            Label control1 = (Label)e.Item.FindControl("lblDomainName");
            TextBox control2 = (TextBox)e.Item.FindControl("txtDomainName");
            ImageButton control3 = (ImageButton)e.Item.FindControl("lnkEdit");
            LinkButton control4 = (LinkButton)e.Item.FindControl("lnkCancelEdit");
            ImageButton control5 = (ImageButton)e.Item.FindControl("lnkDelete");
            LinkButton control6 = (LinkButton)e.Item.FindControl("lnkSave");
            Label control7 = (Label)e.Item.FindControl("lbl");
            CheckBox control8 = (CheckBox)e.Item.FindControl("chkShifts");
            CheckBox control9 = (CheckBox)e.Item.FindControl("chkHW");
            DataRowView dataItem = e.Item.DataItem as DataRowView;
            control8.Checked = Convert.ToBoolean(dataItem["is_shifts"]);
            control9.Checked = Convert.ToBoolean(dataItem["is_permeasurement"]);
            control8.Attributes.Add("OnClick", "MarkFeaturesOnDomain(" + dataItem["Domain_Code"].ToString() + ",'" + control8.ClientID + "',1)");
            control9.Attributes.Add("OnClick", "MarkFeaturesOnDomain(" + dataItem["Domain_Code"].ToString() + ",'" + control9.ClientID + "',2)");
            if (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Domain_Code")) == 0)
            {
                control1.Visible = false;
                control2.Visible = true;
                control3.Visible = false;
                control4.Visible = false;
                control5.Visible = false;
                control6.Visible = true;
                control7.Visible = false;
            }
            else
            {
                control1.Visible = true;
                control2.Visible = false;
                control3.Visible = true;
                control4.Visible = false;
                control5.Visible = true;
                control6.Visible = false;
                control7.Visible = true;
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

    protected void rptDomain_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            Label control1 = (Label)e.Item.FindControl("lblDomainName");
            TextBox control2 = (TextBox)e.Item.FindControl("txtDomainName");
            ImageButton control3 = (ImageButton)e.Item.FindControl("lnkEdit");
            LinkButton control4 = (LinkButton)e.Item.FindControl("lnkCancelEdit");
            ImageButton control5 = (ImageButton)e.Item.FindControl("lnkDelete");
            LinkButton control6 = (LinkButton)e.Item.FindControl("lnkSave");
            if (e.CommandName == "Edit")
            {
                control1.Visible = false;
                control2.Visible = true;
                control3.Visible = false;
                control4.Visible = true;
                control5.Visible = false;
                control6.Visible = true;
            }
            else if (e.CommandName == "CancelEdit")
            {
                control1.Visible = true;
                control2.Visible = false;
                control3.Visible = true;
                control4.Visible = false;
                control5.Visible = true;
                control6.Visible = false;
            }
            if (e.CommandName == "Save")
            {
                connection.Open();
                if (control2.Text != "")
                {
                    SqlCommand sqlCommand = new SqlCommand("XRec_updateDomain", connection);
                    sqlCommand.Parameters.AddWithValue("@DomainID", e.CommandArgument.ToString());
                    sqlCommand.Parameters.AddWithValue("@DomainName", control2.Text);
                    sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
                    sqlCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    Convert.ToString(sqlCommand.ExecuteScalar());
                }
                GetRequisitionDetail(ref connection);
            }
            if (!(e.CommandName == "Delete"))
                return;
            connection.Open();
            SqlCommand sqlCommand1 = new SqlCommand("XRec_DeleteDomain", connection);
            sqlCommand1.Parameters.AddWithValue("@DomainID", e.CommandArgument.ToString());
            sqlCommand1.Parameters.AddWithValue("@Updated_By", UserCode);
            sqlCommand1.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            Convert.ToString(sqlCommand1.ExecuteScalar());
            GetRequisitionDetail(ref connection);
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            foreach (RepeaterItem repeaterItem in rptDomain.Items)
            {
                TextBox control1 = (TextBox)repeaterItem.FindControl("txtDomainName");
                HiddenField control2 = (HiddenField)repeaterItem.FindControl("hdnDomainCode");
                if (control1.Text != "")
                {
                    SqlCommand sqlCommand = new SqlCommand("XRec_updateDomain", connection);
                    sqlCommand.Parameters.AddWithValue("@DomainID", control2.Value);
                    sqlCommand.Parameters.AddWithValue("@DomainName", control1.Text);
                    sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
                    sqlCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    Convert.ToString(sqlCommand.ExecuteScalar());
                }
            }
            GetRequisitionDetail(ref connection);
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
            ArrayList arrayList = new ArrayList();
            myDt = new DataTable();
            SqlCommand selectCommand = new SqlCommand("XRec_SelectAllDomain", connection);
            selectCommand.Parameters.AddWithValue("@DomainName", txtDomainName.Text.Trim());
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            rptDomain.DataSource = dataSet.Tables[0];
            rptDomain.DataBind();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void lbtnAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            AddNewDomain();
            btnSave.Focus();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    public void GetRequisitionDetail(ref SqlConnection connection)
    {
        ArrayList arrayList = new ArrayList();
        myDt = new DataTable();
        SqlCommand selectCommand = new SqlCommand("XRec_SelectAllDomain", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        rptDomain.DataSource = dataSet.Tables[0];
        rptDomain.DataBind();
    }

    private void AddNewDomain()
    {
        ArrayList arr = new ArrayList();
        ++addDomainCount;
        arr.Add("0");
        arr.Add("");
        arr.Add(addDomainCount);
        SaveData();
        AddDataToTable(arr, (DataTable)ViewState["myDatatable"], false);
        rptDomain.DataSource = ((DataTable)ViewState["myDatatable"]).DefaultView;
        rptDomain.DataBind();
    }

    private void SaveData()
    {
        DataTable dataTable = CreateDataTable();
        foreach (RepeaterItem repeaterItem in rptDomain.Items)
        {
            ArrayList arr = new ArrayList();
            Label control1 = repeaterItem.FindControl("lblDomainName") as Label;
            repeaterItem.FindControl("txtDomainName");
            HiddenField control2 = repeaterItem.FindControl("hdnDomainCode") as HiddenField;
            HiddenField control3 = repeaterItem.FindControl("hdnCount") as HiddenField;
            arr.Add(control2.Value);
            arr.Add(control1.Text);
            arr.Add(control3.Value);
            AddDataToTable(arr, dataTable, true);
        }
        ViewState.Remove("myDatatable");
        ViewState["myDatatable"] = dataTable;
    }

    private DataTable CreateDataTable()
    {
        return new DataTable()
        {
            Columns = {
        new DataColumn()
        {
          DataType = Type.GetType("System.Int32"),
          ColumnName = "Domain_Code"
        },
        new DataColumn()
        {
          DataType = Type.GetType("System.String"),
          ColumnName = "Domain_Name"
        },
        new DataColumn()
        {
          DataType = Type.GetType("System.Int32"),
          ColumnName = "count"
        }
      }
        };
    }

    protected void AddDataToTable(ArrayList arr, DataTable myTable, bool type)
    {
        if (type)
        {
            row = myTable.NewRow();
            row["Domain_Code"] = arr[0];
            row["Domain_Name"] = arr[1];
            row["count"] = arr[2];
            myTable.Rows.Add(row);
        }
        else
        {
            for (int index = 0; index < Convert.ToInt32(ddlNo.SelectedValue); ++index)
            {
                row = myTable.NewRow();
                row["Domain_Code"] = arr[0];
                row["Domain_Name"] = arr[1];
                row["count"] = arr[2];
                myTable.Rows.Add(row);
            }
        }
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = UniversalData_AddEditDeleteDomain.PageSize;
        objPDS.CurrentPageIndex = PageNo;
        ViewState["PageCount"] = objPDS.PageCount.ToString();
        if (objPDS.PageCount > 1)
        {
            trPagingControls.Attributes.Add("style", "display:''");
            lblPageIndex.Visible = true;
            lblPageIndex.Text = "Page : " + (objPDS.CurrentPageIndex + 1).ToString() + " of " + objPDS.PageCount.ToString();
            if (objPDS.CurrentPageIndex == 0)
            {
                lnkbtnFirstPage.Visible = false;
                lnkbtnLastPage.Visible = true;
                lnkbtnNextPage.Visible = true;
                lnkbtnPrevPage.Visible = false;
            }
            else if (objPDS.CurrentPageIndex == objPDS.PageCount - 1)
            {
                lnkbtnFirstPage.Visible = true;
                lnkbtnLastPage.Visible = false;
                lnkbtnNextPage.Visible = false;
                lnkbtnPrevPage.Visible = true;
            }
            else
            {
                lnkbtnFirstPage.Visible = true;
                lnkbtnLastPage.Visible = true;
                lnkbtnNextPage.Visible = true;
                lnkbtnPrevPage.Visible = true;
            }
        }
        else
            trPagingControls.Attributes.Add("style", "display:none");
        return objPDS;
    }

    protected void lnkbtnFirstPage_Click(object sender, EventArgs e)
    {
        PageNo = 0;
        rptDomain.DataSource = ApplyPaging(UniversalData_AddEditDeleteDomain.objDV, PageNo);
        rptDomain.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptDomain.DataSource = ApplyPaging(UniversalData_AddEditDeleteDomain.objDV, PageNo);
        rptDomain.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptDomain.DataSource = ApplyPaging(UniversalData_AddEditDeleteDomain.objDV, PageNo);
        rptDomain.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptDomain.DataSource = ApplyPaging(UniversalData_AddEditDeleteDomain.objDV, PageNo);
        rptDomain.DataBind();
    }

    [WebMethod]
    public static void MarkFeaturesOnDomain(string items)
    {
        string[] strArray = new string[0];
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
            strArray = items.Split('|');
            if (((IEnumerable<string>)strArray).Count<string>() < 5)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("MarkFeaturesOnDomain", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@domain_code", strArray[0].ToString());
            sqlCommand.Parameters.AddWithValue("@IsActive", strArray[1].ToString());
            sqlCommand.Parameters.AddWithValue("@type", strArray[2].ToString());
            sqlCommand.Parameters.AddWithValue("@updatedby", strArray[3].ToString());
            sqlCommand.Parameters.AddWithValue("@updatedIp", strArray[4].ToString());
            sqlCommand.ExecuteScalar();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            if (((IEnumerable<string>)strArray).Count<string>() >= 3)
                LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, strArray[3].ToString());
            else
                LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, "0");
        }
    }

    #endregion


}