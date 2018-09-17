﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;
using ErrorLog;
public partial class UniversalData_AddEditDeleteIndustry : CustomBasePage
{
    #region Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    int addIndustryCount = 0;
    protected DataTable myDt;
    DataRow row;
    #endregion


    #region Paging Variables
    static DataView objDV = new DataView();
    static int PageSize;
    static string SortDirection = "DESC";
    PagedDataSource objPDS = new System.Web.UI.WebControls.PagedDataSource();
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
            if (string.IsNullOrEmpty(counter.Value))
                counter.Value = addIndustryCount.ToString();
            UniversalData_AddEditDeleteIndustry.PageSize = 25;
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

    protected void rptIndustry_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(PageNo * UniversalData_AddEditDeleteIndustry.PageSize + (e.Item.ItemIndex + 1));
            Label control1 = (Label)e.Item.FindControl("lblIndustryName");
            TextBox control2 = (TextBox)e.Item.FindControl("txtIndustryName");
            ImageButton control3 = (ImageButton)e.Item.FindControl("lnkEdit");
            LinkButton control4 = (LinkButton)e.Item.FindControl("lnkCancelEdit");
            ImageButton control5 = (ImageButton)e.Item.FindControl("lnkDelete");
            LinkButton control6 = (LinkButton)e.Item.FindControl("lnkSave");
            Label control7 = (Label)e.Item.FindControl("lbl");
            if (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Industry_Code")) == 0)
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

    protected void rptIndustry_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            Label control1 = (Label)e.Item.FindControl("lblIndustryName");
            TextBox control2 = (TextBox)e.Item.FindControl("txtIndustryName");
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
                    SqlCommand sqlCommand = new SqlCommand("XRec_updateIndustry", connection);
                    sqlCommand.Parameters.AddWithValue("@IndustryID", e.CommandArgument.ToString());
                    sqlCommand.Parameters.AddWithValue("@IndustryName", control2.Text);
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
            SqlCommand sqlCommand1 = new SqlCommand("XRec_DeleteIndustry", connection);
            sqlCommand1.Parameters.AddWithValue("@IndustryID", e.CommandArgument.ToString());
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
            foreach (RepeaterItem repeaterItem in rptIndustry.Items)
            {
                TextBox control1 = (TextBox)repeaterItem.FindControl("txtIndustryName");
                HiddenField control2 = (HiddenField)repeaterItem.FindControl("hdnIndustryCode");
                if (control1.Text != "")
                {
                    SqlCommand sqlCommand = new SqlCommand("XRec_updateIndustry", connection);
                    sqlCommand.Parameters.AddWithValue("@IndustryID", control2.Value);
                    sqlCommand.Parameters.AddWithValue("@IndustryName", control1.Text);
                    sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
                    sqlCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    Convert.ToString(sqlCommand.ExecuteScalar());
                }
            }
            GetRequisitionDetail(ref connection);
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        try
        {
            ArrayList arr = new ArrayList();
            myDt = new DataTable();
            SqlCommand selectCommand = new SqlCommand("XRec_SelectAllIndustry", connection);
            selectCommand.Parameters.AddWithValue("@IndustryName", txtIndustryName.Text.Trim());
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                myDt = dataSet.Tables[0].Copy();
                ViewState["myDatatable"] = myDt;
            }
            else
            {
                myDt = CreateDataTable();
                ViewState.Remove("myDatatable");
                ViewState["myDatatable"] = myDt;
                arr.Add("0");
                arr.Add("");
                arr.Add(addIndustryCount);
                AddDataToTable(arr, (DataTable)ViewState["myDatatable"], true);
            }
            UniversalData_AddEditDeleteIndustry.objDV = ((DataTable)ViewState["myDatatable"]).DefaultView;
            trPagingControls.Attributes.Add("style", "display:''");
            PageNo = 0;
            rptIndustry.DataSource = ApplyPaging(UniversalData_AddEditDeleteIndustry.objDV, PageNo);
            rptIndustry.DataBind();
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
            AddNewIndustry();
            btnSave.Focus();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    public void GetRequisitionDetail(ref SqlConnection connection)
    {
        ArrayList arr = new ArrayList();
        myDt = new DataTable();
        try
        {
            SqlCommand selectCommand = new SqlCommand("XRec_SelectAllIndustry", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                myDt = dataSet.Tables[0].Copy();
                ViewState["myDatatable"] = myDt;
            }
            else
            {
                myDt = CreateDataTable();
                ViewState.Remove("myDatatable");
                ViewState["myDatatable"] = myDt;
                arr.Add("0");
                arr.Add("");
                arr.Add(addIndustryCount);
                AddDataToTable(arr, (DataTable)ViewState["myDatatable"], true);
            }
            UniversalData_AddEditDeleteIndustry.objDV = ((DataTable)ViewState["myDatatable"]).DefaultView;
            trPagingControls.Attributes.Add("style", "display:''");
            PageNo = 0;
            rptIndustry.DataSource = ApplyPaging(UniversalData_AddEditDeleteIndustry.objDV, PageNo);
            rptIndustry.DataBind();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private void AddNewIndustry()
    {
        ArrayList arr = new ArrayList();
        ++addIndustryCount;
        arr.Add("0");
        arr.Add("");
        arr.Add(addIndustryCount);
        SaveData();
        AddDataToTable(arr, (DataTable)ViewState["myDatatable"], false);
        rptIndustry.DataSource = ((DataTable)ViewState["myDatatable"]).DefaultView;
        rptIndustry.DataBind();
    }

    private void SaveData()
    {
        DataTable dataTable = CreateDataTable();
        foreach (RepeaterItem repeaterItem in rptIndustry.Items)
        {
            ArrayList arr = new ArrayList();
            Label control1 = repeaterItem.FindControl("lblIndustryName") as Label;
            repeaterItem.FindControl("txtIndustryName");
            HiddenField control2 = repeaterItem.FindControl("hdnIndustryCode") as HiddenField;
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
          ColumnName = "Industry_Code"
        },
        new DataColumn()
        {
          DataType = Type.GetType("System.String"),
          ColumnName = "Industry"
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
            row["Industry_Code"] = arr[0];
            row["Industry"] = arr[1];
            row["count"] = arr[2];
            myTable.Rows.Add(row);
        }
        else
        {
            for (int index = 0; index < Convert.ToInt32(ddlNo.SelectedValue); ++index)
            {
                row = myTable.NewRow();
                row["Industry_Code"] = arr[0];
                row["Industry"] = arr[1];
                row["count"] = arr[2];
                myTable.Rows.Add(row);
            }
        }
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = UniversalData_AddEditDeleteIndustry.PageSize;
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
        rptIndustry.DataSource = ApplyPaging(UniversalData_AddEditDeleteIndustry.objDV, PageNo);
        rptIndustry.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptIndustry.DataSource = ApplyPaging(UniversalData_AddEditDeleteIndustry.objDV, PageNo);
        rptIndustry.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptIndustry.DataSource = ApplyPaging(UniversalData_AddEditDeleteIndustry.objDV, PageNo);
        rptIndustry.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptIndustry.DataSource = ApplyPaging(UniversalData_AddEditDeleteIndustry.objDV, PageNo);
        rptIndustry.DataBind();
    }
    #endregion


}