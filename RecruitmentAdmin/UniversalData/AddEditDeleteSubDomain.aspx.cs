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
using System.Collections;
using ErrorLog;

public partial class UniversalData_AddEditDeleteSubDomain : CustomBasePage
{
    #region Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    int addSubDomainCount = 0;
    protected DataTable myDt;
    DataRow row;
    #endregion

    #region Paging Variables
    static DataView objDV = new DataView();
    static int PageSize;
    static string SortDirection = "DESC";
    PagedDataSource objPDS = new System.Web.UI.WebControls.PagedDataSource();
    #endregion

    #region Event
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
                counter.Value = addSubDomainCount.ToString();
            BindData();
            UniversalData_AddEditDeleteSubDomain.PageSize = 25;
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

    private void BindData()
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectAllDomain", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        ddlDomain.DataSource = dataSet;
        ddlDomain.DataTextField = "Domain_Name";
        ddlDomain.DataValueField = "Domain_Code";
        ddlDomain.DataBind();
        ddlDomain.Items.Insert(0, new ListItem("--All--", "0"));
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            foreach (RepeaterItem repeaterItem in rptSubDomain.Items)
            {
                TextBox control1 = (TextBox)repeaterItem.FindControl("txtSubDomainName");
                HiddenField control2 = (HiddenField)repeaterItem.FindControl("hdnSubDomainCode");
                DropDownList control3 = (DropDownList)repeaterItem.FindControl("ddlDomain");
                if (control1.Text.Trim() != "")
                {
                    SqlCommand sqlCommand = new SqlCommand("XRec_updateSubDomain", connection);
                    sqlCommand.Parameters.AddWithValue("@SubDomainID", control2.Value);
                    sqlCommand.Parameters.AddWithValue("@SubDomainName", control1.Text);
                    sqlCommand.Parameters.AddWithValue("@DomainCode", control3.SelectedValue);
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
            ArrayList arr = new ArrayList();
            myDt = new DataTable();
            SqlCommand selectCommand = new SqlCommand("XRec_SelectAllSubDomain", connection);
            selectCommand.Parameters.AddWithValue("@SubDomainName", txtSubDomainName.Text.Trim());
            if (ddlDomain.SelectedValue != "0")
                selectCommand.Parameters.AddWithValue("@DomainCode", ddlDomain.SelectedValue);
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
                arr.Add("0");
                arr.Add("");
                arr.Add(addSubDomainCount);
                AddDataToTable(arr, (DataTable)ViewState["myDatatable"], true);
            }
            UniversalData_AddEditDeleteSubDomain.objDV = ((DataTable)ViewState["myDatatable"]).DefaultView;
            trPagingControls.Attributes.Add("style", "display:''");
            PageNo = 0;
            rptSubDomain.DataSource = ApplyPaging(UniversalData_AddEditDeleteSubDomain.objDV, PageNo);
            rptSubDomain.DataBind();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptSubDomain_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(PageNo * UniversalData_AddEditDeleteSubDomain.PageSize + (e.Item.ItemIndex + 1));
            Label control1 = (Label)e.Item.FindControl("lblSubDomainName");
            TextBox control2 = (TextBox)e.Item.FindControl("txtSubDomainName");
            ImageButton control3 = (ImageButton)e.Item.FindControl("lnkEdit");
            LinkButton control4 = (LinkButton)e.Item.FindControl("lnkCancelEdit");
            ImageButton control5 = (ImageButton)e.Item.FindControl("lnkDelete");
            LinkButton control6 = (LinkButton)e.Item.FindControl("lnkSave");
            Label control7 = (Label)e.Item.FindControl("lbl");
            Label control8 = (Label)e.Item.FindControl("lblDomain");
            DropDownList control9 = (DropDownList)e.Item.FindControl("ddlDomain");
            SqlCommand selectCommand = new SqlCommand("XRec_SelectAllDomain", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                control9.DataSource = dataSet;
                control9.DataTextField = "Domain_Name";
                control9.DataValueField = "Domain_Code";
                control9.DataBind();
                if (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Domain_Code")) != 0)
                    control9.SelectedValue = DataBinder.Eval(e.Item.DataItem, "Domain_Code").ToString();
            }
            if (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "SubDomain_Code")) == 0)
            {
                control1.Visible = false;
                control2.Visible = true;
                control3.Visible = false;
                control4.Visible = false;
                control5.Visible = false;
                control6.Visible = true;
                control7.Visible = false;
                control8.Visible = false;
                control9.Visible = true;
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
                control8.Visible = true;
                control9.Visible = false;
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

    protected void rptSubDomain_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            Label control1 = (Label)e.Item.FindControl("lblSubDomainName");
            TextBox control2 = (TextBox)e.Item.FindControl("txtSubDomainName");
            ImageButton control3 = (ImageButton)e.Item.FindControl("lnkEdit");
            LinkButton control4 = (LinkButton)e.Item.FindControl("lnkCancelEdit");
            ImageButton control5 = (ImageButton)e.Item.FindControl("lnkDelete");
            LinkButton control6 = (LinkButton)e.Item.FindControl("lnkSave");
            Label control7 = (Label)e.Item.FindControl("lblDomain");
            DropDownList control8 = (DropDownList)e.Item.FindControl("ddlDomain");
            if (e.CommandName == "Edit")
            {
                control1.Visible = false;
                control2.Visible = true;
                control3.Visible = false;
                control4.Visible = true;
                control5.Visible = false;
                control6.Visible = true;
                control7.Visible = false;
                control8.Visible = true;
            }
            else if (e.CommandName == "CancelEdit")
            {
                control1.Visible = true;
                control2.Visible = false;
                control3.Visible = true;
                control4.Visible = false;
                control5.Visible = true;
                control6.Visible = false;
                control7.Visible = true;
                control8.Visible = false;
            }
            if (e.CommandName == "Save")
            {
                connection.Open();
                if (control2.Text != "")
                {
                    SqlCommand sqlCommand = new SqlCommand("XRec_updateSubDomain", connection);
                    sqlCommand.Parameters.AddWithValue("@SubDomainID", e.CommandArgument.ToString());
                    sqlCommand.Parameters.AddWithValue("@SubDomainName", control2.Text);
                    sqlCommand.Parameters.AddWithValue("@DomainCode", control8.SelectedValue);
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
            SqlCommand sqlCommand1 = new SqlCommand("XRec_DeleteSubDomain", connection);
            sqlCommand1.Parameters.AddWithValue("@SubDomainID", e.CommandArgument.ToString());
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

    protected void lbtnAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            AddNewSubDomain();
            btnSave.Focus();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private void AddNewSubDomain()
    {
        ArrayList arr = new ArrayList();
        ++addSubDomainCount;
        arr.Add("0");
        arr.Add("");
        arr.Add("0");
        arr.Add("");
        arr.Add(addSubDomainCount);
        SaveData();
        AddDataToTable(arr, (DataTable)ViewState["myDatatable"], false);
        rptSubDomain.DataSource = ((DataTable)ViewState["myDatatable"]).DefaultView;
        rptSubDomain.DataBind();
    }

    private void SaveData()
    {
        DataTable dataTable = CreateDataTable();
        foreach (RepeaterItem repeaterItem in rptSubDomain.Items)
        {
            ArrayList arr = new ArrayList();
            Label control1 = repeaterItem.FindControl("lblSubDomainName") as Label;
            repeaterItem.FindControl("txtSubDomainName");
            HiddenField control2 = repeaterItem.FindControl("hdnSubDomainCode") as HiddenField;
            HiddenField control3 = repeaterItem.FindControl("hdnCount") as HiddenField;
            Label control4 = (Label)repeaterItem.FindControl("lblDomain");
            DropDownList control5 = (DropDownList)repeaterItem.FindControl("ddlDomain");
            arr.Add(control2.Value);
            arr.Add(control1.Text);
            arr.Add(control5.SelectedValue);
            arr.Add(control5.SelectedItem.Text);
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
          ColumnName = "SubDomain_Code"
        },
        new DataColumn()
        {
          DataType = Type.GetType("System.String"),
          ColumnName = "SubDomain_Name"
        },
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

    public void GetRequisitionDetail(ref SqlConnection connection)
    {
        ArrayList arr = new ArrayList();
        myDt = new DataTable();
        SqlCommand selectCommand = new SqlCommand("XRec_SelectAllSubDomain", connection);
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
            arr.Add("0");
            arr.Add("");
            arr.Add(addSubDomainCount);
            AddDataToTable(arr, (DataTable)ViewState["myDatatable"], true);
        }
        UniversalData_AddEditDeleteSubDomain.objDV = ((DataTable)ViewState["myDatatable"]).DefaultView;
        trPagingControls.Attributes.Add("style", "display:''");
        PageNo = 0;
        rptSubDomain.DataSource = ApplyPaging(UniversalData_AddEditDeleteSubDomain.objDV, PageNo);
        rptSubDomain.DataBind();
    }

    protected void AddDataToTable(ArrayList arr, DataTable myTable, bool type)
    {
        if (type)
        {
            row = myTable.NewRow();
            row["SubDomain_Code"] = arr[0];
            row["SubDomain_Name"] = arr[1];
            row["Domain_Code"] = arr[2];
            row["Domain_Name"] = arr[3];
            row["count"] = arr[4];
            myTable.Rows.Add(row);
        }
        else
        {
            for (int index = 0; index < Convert.ToInt32(ddlNo.SelectedValue); ++index)
            {
                row = myTable.NewRow();
                row["SubDomain_Code"] = arr[0];
                row["SubDomain_Name"] = arr[1];
                row["Domain_Code"] = arr[2];
                row["Domain_Name"] = arr[3];
                row["count"] = arr[4];
                myTable.Rows.Add(row);
            }
        }
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = UniversalData_AddEditDeleteSubDomain.PageSize;
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
        rptSubDomain.DataSource = ApplyPaging(UniversalData_AddEditDeleteSubDomain.objDV, PageNo);
        rptSubDomain.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptSubDomain.DataSource = ApplyPaging(UniversalData_AddEditDeleteSubDomain.objDV, PageNo);
        rptSubDomain.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptSubDomain.DataSource = ApplyPaging(UniversalData_AddEditDeleteSubDomain.objDV, PageNo);
        rptSubDomain.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptSubDomain.DataSource = ApplyPaging(UniversalData_AddEditDeleteSubDomain.objDV, PageNo);
        rptSubDomain.DataBind();
    }

    #endregion
}