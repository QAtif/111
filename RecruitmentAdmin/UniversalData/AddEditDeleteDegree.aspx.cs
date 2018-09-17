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

public partial class UniversalData_AddEditDeleteDegree : CustomBasePage
{
    #region Variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    int addDegreeCount = 0;
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
                counter.Value = addDegreeCount.ToString();
            UniversalData_AddEditDeleteDegree.PageSize = 25;
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

    protected void rptDegree_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(PageNo * UniversalData_AddEditDeleteDegree.PageSize + (e.Item.ItemIndex + 1));
            Label control1 = (Label)e.Item.FindControl("lblDegreeName");
            TextBox control2 = (TextBox)e.Item.FindControl("txtDegreeName");
            ImageButton control3 = (ImageButton)e.Item.FindControl("lnkEdit");
            LinkButton control4 = (LinkButton)e.Item.FindControl("lnkCancelEdit");
            ImageButton control5 = (ImageButton)e.Item.FindControl("lnkDelete");
            LinkButton control6 = (LinkButton)e.Item.FindControl("lnkSave");
            Label control7 = (Label)e.Item.FindControl("lbl");
            Label control8 = (Label)e.Item.FindControl("lblProgram");
            DropDownList control9 = (DropDownList)e.Item.FindControl("ddlProgram");
            SqlCommand selectCommand = new SqlCommand("XRec_SelectAllProgram", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                control9.DataSource = dataSet;
                control9.DataTextField = "Program_Name";
                control9.DataValueField = "Program_Code";
                control9.DataBind();
                if (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Program_Code")) != 0)
                    control9.SelectedValue = DataBinder.Eval(e.Item.DataItem, "Program_Code").ToString();
            }
            if (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Degree_Code")) == 0)
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

    protected void rptDegree_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            Label control1 = (Label)e.Item.FindControl("lblDegreeName");
            TextBox control2 = (TextBox)e.Item.FindControl("txtDegreeName");
            ImageButton control3 = (ImageButton)e.Item.FindControl("lnkEdit");
            LinkButton control4 = (LinkButton)e.Item.FindControl("lnkCancelEdit");
            ImageButton control5 = (ImageButton)e.Item.FindControl("lnkDelete");
            LinkButton control6 = (LinkButton)e.Item.FindControl("lnkSave");
            Label control7 = (Label)e.Item.FindControl("lblProgram");
            DropDownList control8 = (DropDownList)e.Item.FindControl("ddlProgram");
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
                    SqlCommand sqlCommand = new SqlCommand("XRec_updateDegree", connection);
                    sqlCommand.Parameters.AddWithValue("@DegreeID", e.CommandArgument.ToString());
                    sqlCommand.Parameters.AddWithValue("@DegreeName", control2.Text);
                    sqlCommand.Parameters.AddWithValue("@ProgramCode", control8.SelectedValue);
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
            SqlCommand sqlCommand1 = new SqlCommand("XRec_DeleteDegree", connection);
            sqlCommand1.Parameters.AddWithValue("@DegreeID", e.CommandArgument.ToString());
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
            AddNewDegree();
            btnSave.Focus();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            foreach (RepeaterItem repeaterItem in rptDegree.Items)
            {
                TextBox control1 = (TextBox)repeaterItem.FindControl("txtDegreeName");
                HiddenField control2 = (HiddenField)repeaterItem.FindControl("hdnDegreeCode");
                DropDownList control3 = (DropDownList)repeaterItem.FindControl("ddlProgram");
                if (control1.Text != "")
                {
                    SqlCommand sqlCommand = new SqlCommand("XRec_updateDegree", connection);
                    sqlCommand.Parameters.AddWithValue("@DegreeID", control2.Value);
                    sqlCommand.Parameters.AddWithValue("@DegreeName", control1.Text);
                    sqlCommand.Parameters.AddWithValue("@ProgramCode", control3.SelectedValue);
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
            SqlCommand selectCommand = new SqlCommand("XRec_SelectAllDegree", connection);
            selectCommand.Parameters.AddWithValue("@DegreeName", txtDegreeName.Text.Trim());
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
                arr.Add(addDegreeCount);
                AddDataToTable(arr, (DataTable)ViewState["myDatatable"], true);
            }
            UniversalData_AddEditDeleteDegree.objDV = ((DataTable)ViewState["myDatatable"]).DefaultView;
            trPagingControls.Attributes.Add("style", "display:''");
            PageNo = 0;
            rptDegree.DataSource = ApplyPaging(UniversalData_AddEditDeleteDegree.objDV, PageNo);
            rptDegree.DataBind();
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
        SqlCommand selectCommand = new SqlCommand("XRec_SelectAllDegree", connection);
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
            arr.Add(addDegreeCount);
            AddDataToTable(arr, (DataTable)ViewState["myDatatable"], true);
        }
        UniversalData_AddEditDeleteDegree.objDV = ((DataTable)ViewState["myDatatable"]).DefaultView;
        trPagingControls.Attributes.Add("style", "display:''");
        PageNo = 0;
        rptDegree.DataSource = ApplyPaging(UniversalData_AddEditDeleteDegree.objDV, PageNo);
        rptDegree.DataBind();
    }

    private void AddNewDegree()
    {
        ArrayList arr = new ArrayList();
        ++addDegreeCount;
        arr.Add("0");
        arr.Add("");
        arr.Add("0");
        arr.Add("");
        arr.Add(addDegreeCount);
        SaveData();
        AddDataToTable(arr, (DataTable)ViewState["myDatatable"], false);
        rptDegree.DataSource = ((DataTable)ViewState["myDatatable"]).DefaultView;
        rptDegree.DataBind();
    }

    private void SaveData()
    {
        DataTable dataTable = CreateDataTable();
        foreach (RepeaterItem repeaterItem in rptDegree.Items)
        {
            ArrayList arr = new ArrayList();
            Label control1 = repeaterItem.FindControl("lblDegreeName") as Label;
            repeaterItem.FindControl("txtDegreeName");
            HiddenField control2 = repeaterItem.FindControl("hdnDegreeCode") as HiddenField;
            HiddenField control3 = repeaterItem.FindControl("hdnCount") as HiddenField;
            Label control4 = (Label)repeaterItem.FindControl("lblProgram");
            DropDownList control5 = (DropDownList)repeaterItem.FindControl("ddlProgram");
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
          ColumnName = "Degree_Code"
        },
        new DataColumn()
        {
          DataType = Type.GetType("System.String"),
          ColumnName = "Degree"
        },
        new DataColumn()
        {
          DataType = Type.GetType("System.Int32"),
          ColumnName = "Program_Code"
        },
        new DataColumn()
        {
          DataType = Type.GetType("System.String"),
          ColumnName = "Program_Name"
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
            row["Degree_Code"] = arr[0];
            row["Degree"] = arr[1];
            row["Program_Code"] = arr[2];
            row["Program_Name"] = arr[3];
            row["count"] = arr[4];
            myTable.Rows.Add(row);
        }
        else
        {
            for (int index = 0; index < Convert.ToInt32(ddlNo.SelectedValue); ++index)
            {
                row = myTable.NewRow();
                row["Degree_Code"] = arr[0];
                row["Degree"] = arr[1];
                row["Program_Code"] = arr[2];
                row["Program_Name"] = arr[3];
                row["count"] = arr[4];
                myTable.Rows.Add(row);
            }
        }
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = UniversalData_AddEditDeleteDegree.PageSize;
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
        rptDegree.DataSource = ApplyPaging(UniversalData_AddEditDeleteDegree.objDV, PageNo);
        rptDegree.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptDegree.DataSource = ApplyPaging(UniversalData_AddEditDeleteDegree.objDV, PageNo);
        rptDegree.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptDegree.DataSource = ApplyPaging(UniversalData_AddEditDeleteDegree.objDV, PageNo);
        rptDegree.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptDegree.DataSource = ApplyPaging(UniversalData_AddEditDeleteDegree.objDV, PageNo);
        rptDegree.DataBind();
    }

    #endregion

}