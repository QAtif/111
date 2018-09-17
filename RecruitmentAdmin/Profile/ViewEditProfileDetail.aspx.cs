using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;
using ErrorLog;

public partial class Profile_ViewEditProfileDetail : CustomBasePage
{
    #region Variables
    
    private static DataView objDV = new DataView();
    private static string SortDirection = "DESC";
    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    private SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    private PagedDataSource objPDS = new PagedDataSource();
    private static int PageSize;
    protected DataTable myDt;
    protected DataSet dsOGData;
    private DataRow row;

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
        if (!IsPostBack)
        {
            try
            {
                Profile_ViewEditProfileDetail.PageSize = 25;
                GetOGData();
                connection.Open();
                GetProfileDetail(ref connection);
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
        else
        {
            if (dsOGData != null)
                return;
            dsOGData = (DataSet)ViewState["OgData"];
        }
    }

    protected void rptProfileLists_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnCounter");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnPageCounter");
            ((HtmlAnchor)e.Item.FindControl("aEdit")).HRef = "AddEditProfile.aspx?pCode=" + DataBinder.Eval(e.Item.DataItem, "Profile_Code").ToString();
            control2.Value = control1.Value;
            int counter = int.Parse(control1.Value);
            Repeater control3 = (Repeater)e.Item.FindControl("rptParameter");
            BindInitialTable(DataBinder.Eval(e.Item.DataItem, "Profile_Code").ToString(), control3, counter);
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

    protected void rptParameter_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
            DropDownList control1 = (DropDownList)e.Item.FindControl("ddlParameter");
            DropDownList control2 = (DropDownList)e.Item.FindControl("ddlValue");
            CheckBox control3 = (CheckBox)e.Item.FindControl("chkMandatory");
            if (dsOGData != null && dsOGData.Tables[0] != null && dsOGData.Tables[0].Rows.Count > 0)
            {
                control1.DataSource = dsOGData.Tables[0];
                control1.DataTextField = "Parameter_Name";
                control1.DataValueField = "Parameter_Code";
                control1.DataBind();
                control1.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            control2.Items.Insert(0, new ListItem("--Select--", "0"));
            if (DataBinder.Eval(e.Item.DataItem, "Parameter_Code") != null)
                control1.SelectedValue = DataBinder.Eval(e.Item.DataItem, "Parameter_Code").ToString();
            ddlParameter_SelectedIndexChanged(control1, (EventArgs)null);
            if (DataBinder.Eval(e.Item.DataItem, "ParameterValue_Code") != null)
                control2.SelectedValue = DataBinder.Eval(e.Item.DataItem, "ParameterValue_Code").ToString();
            if (DataBinder.Eval(e.Item.DataItem, "Is_Mandatory") == null)
                return;
            if (Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "Is_Mandatory")))
                control3.Checked = true;
            else
                control3.Checked = false;
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

    protected void ddlParameter_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList dropDownList = (DropDownList)sender;
        DropDownList control = dropDownList.Parent.FindControl("ddlValue") as DropDownList;
        if (!(dropDownList.SelectedValue != ""))
            return;
        if (!(dropDownList.SelectedValue != "0"))
            return;
        try
        {
            SqlCommand selectCommand = new SqlCommand("XRec_SelectProfileOGValueDataByCode", connection);
            selectCommand.Parameters.AddWithValue("@Parameter_Code", dropDownList.SelectedValue);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables.Count == 0 || dataSet.Tables[0].Rows.Count <= 0)
                return;
            control.DataSource = dataSet;
            control.DataTextField = "ValColumn_Name";
            control.DataValueField = "Column_Name";
            control.DataBind();
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

    protected void rptProfileLists_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            connection.Open();
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnCounter");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnProfileCode");
            int num = int.Parse(control1.Value);
            Repeater control3 = (Repeater)e.Item.FindControl("rptParameter");
            if (e.CommandName == "AddMore")
            {
                int counter = num + 1;
                BindInitialTable(control2.Value, control3, counter);
                control1.Value = counter.ToString();
            }
            if (!(e.CommandName == "DeleteProfile"))
                return;
            SqlCommand sqlCommand = new SqlCommand("XRec_DeleteProfile", connection);
            sqlCommand.Parameters.AddWithValue("@Profile_Code", e.CommandArgument.ToString());
            sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
            sqlCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            Convert.ToString(sqlCommand.ExecuteScalar());
            GetProfileDetail(ref connection);
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

    protected void rptParameter_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "Delete"))
            return;
        try
        {
            Repeater rpt = (Repeater)source;
            HiddenField control1 = (HiddenField)e.Item.Parent.Parent.FindControl("hdnCounter");
            HiddenField control2 = (HiddenField)e.Item.Parent.Parent.FindControl("hdnProfileCode");
            int num = int.Parse(control1.Value);
            string s = e.CommandArgument.ToString();
            int counter = num - 1;
            if (int.Parse(s) > 0)
            {
                RemoveProfileParameter(int.Parse(s));
                RemoveRow(control2.Value, rpt, counter, e.Item.ItemIndex);
            }
            else
                RemoveRow(control2.Value, rpt, counter, e.Item.ItemIndex);
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            foreach (RepeaterItem repeaterItem1 in rptProfileLists.Items)
            {
                Repeater control1 = (Repeater)repeaterItem1.FindControl("rptParameter");
                HiddenField control2 = repeaterItem1.FindControl("hdnProfileCode") as HiddenField;
                repeaterItem1.FindControl("hdnCounter");
                foreach (RepeaterItem repeaterItem2 in control1.Items)
                {
                    ArrayList arrayList = new ArrayList();
                    DropDownList control3 = repeaterItem2.FindControl("ddlParameter") as DropDownList;
                    DropDownList control4 = repeaterItem2.FindControl("ddlValue") as DropDownList;
                    CheckBox control5 = repeaterItem2.FindControl("chkMandatory") as CheckBox;
                    repeaterItem2.FindControl("hdnProfileParameterCode");
                    if (control3.SelectedValue != "" && control3.SelectedValue != "0" && (control4.SelectedValue != "" && control4.SelectedValue != "0"))
                    {
                        SqlCommand sqlCommand = new SqlCommand("XRec_InsertProfileParameter", connection);
                        sqlCommand.Parameters.AddWithValue("@Profile_Code", control2.Value);
                        sqlCommand.Parameters.AddWithValue("@Parameter_Code", control3.SelectedValue);
                        sqlCommand.Parameters.AddWithValue("@ParameterValue_Code", control4.SelectedValue);
                        sqlCommand.Parameters.AddWithValue("@Is_Mandatory", control5.Checked);
                        sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
                        sqlCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        Convert.ToString(sqlCommand.ExecuteScalar());
                    }
                }
                SqlCommand sqlCommand1 = new SqlCommand("XRec_InsertProfileParameterScore", connection);
                sqlCommand1.Parameters.AddWithValue("@Profile_Code", control2.Value);
                sqlCommand1.Parameters.AddWithValue("@Updated_By", UserCode);
                sqlCommand1.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
                sqlCommand1.CommandType = CommandType.StoredProcedure;
                Convert.ToString(sqlCommand1.ExecuteScalar());
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

    private void RemoveProfileParameter(int ProfileParameter_Code)
    {
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XRec_DeleteProfileParameter", connection);
            sqlCommand.Parameters.AddWithValue("@ProfileParameter_Code", ProfileParameter_Code);
            sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
            sqlCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress.ToString());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            Convert.ToString(sqlCommand.ExecuteScalar());
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private void GetOGData()
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectProfileOGData", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        dsOGData = new DataSet();
        sqlDataAdapter.Fill(dsOGData);
        if (dsOGData.Tables[0].Rows.Count <= 0)
            return;
        ViewState["OgData"] = dsOGData;
    }

    public DataTable BindInitialTable(string Profile_Code, Repeater rpt, int counter)
    {
        ArrayList arrayList = new ArrayList();
        myDt = new DataTable();
        SqlCommand selectCommand = new SqlCommand("XRec_SelectProfileParameterByCode", connection);
        selectCommand.Parameters.AddWithValue("@Profile_Code", Profile_Code);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            myDt = dataSet.Tables[0].Copy();
            int num = int.Parse(myDt.Rows[0]["count"].ToString());
            if (counter > num)
            {
                myDt = SaveData(Profile_Code);
                AddDataToTable(new ArrayList()
        {
           "0",
           "0",
           "0",
           "0",
           "False",
           counter
        }, myDt);
            }
        }
        else
        {
            myDt = CreateDataTable();
            myDt = SaveData(Profile_Code);
            AddDataToTable(new ArrayList()
      {
         "0",
         "0",
         "0",
         "0",
         "False",
         counter
      }, myDt);
        }
        rpt.DataSource = myDt.DefaultView;
        rpt.DataBind();
        return myDt;
    }

    public DataTable RemoveRow(string Profile_Code, Repeater rpt, int counter, int rowid)
    {
        myDt = CreateDataTable();
        myDt = SaveData(Profile_Code);
        myDt.Rows.Remove(myDt.Rows[rowid]);
        rpt.DataSource = myDt.DefaultView;
        rpt.DataBind();
        return myDt;
    }

    private DataTable CreateDataTable()
    {
        return new DataTable()
        {
            Columns = {
        new DataColumn()
        {
          DataType = Type.GetType("System.Int32"),
          ColumnName = "ProfileParameter_Code"
        },
        new DataColumn()
        {
          DataType = Type.GetType("System.Int32"),
          ColumnName = "Profile_Code"
        },
        new DataColumn()
        {
          DataType = Type.GetType("System.Int32"),
          ColumnName = "Parameter_Code"
        },
        new DataColumn()
        {
          DataType = Type.GetType("System.Int32"),
          ColumnName = "ParameterValue_Code"
        },
        new DataColumn()
        {
          DataType = Type.GetType("System.Boolean"),
          ColumnName = "Is_Mandatory"
        },
        new DataColumn()
        {
          DataType = Type.GetType("System.Int32"),
          ColumnName = "count"
        }
      }
        };
    }

    protected void AddDataToTable(ArrayList arr, DataTable myTable)
    {
        row = myTable.NewRow();
        row["ProfileParameter_Code"] = arr[0];
        row["Profile_Code"] = arr[1];
        row["Parameter_Code"] = arr[2];
        row["ParameterValue_Code"] = arr[3];
        row["Is_Mandatory"] = Convert.ToBoolean(arr[4]);
        row["count"] = arr[5];
        myTable.Rows.Add(row);
    }

    private DataTable SaveData(string Profile_Code)
    {
        DataTable dataTable = CreateDataTable();
        foreach (RepeaterItem repeaterItem1 in rptProfileLists.Items)
        {
            Repeater control1 = (Repeater)repeaterItem1.FindControl("rptParameter");
            HiddenField control2 = repeaterItem1.FindControl("hdnProfileCode") as HiddenField;
            HiddenField control3 = repeaterItem1.FindControl("hdnCounter") as HiddenField;
            if (control2.Value == Profile_Code)
            {
                foreach (RepeaterItem repeaterItem2 in control1.Items)
                {
                    ArrayList arr = new ArrayList();
                    DropDownList control4 = repeaterItem2.FindControl("ddlParameter") as DropDownList;
                    DropDownList control5 = repeaterItem2.FindControl("ddlValue") as DropDownList;
                    CheckBox control6 = repeaterItem2.FindControl("chkMandatory") as CheckBox;
                    HiddenField control7 = repeaterItem2.FindControl("hdnProfileParameterCode") as HiddenField;
                    arr.Add(control7.Value);
                    arr.Add(control2.Value);
                    arr.Add(control4.SelectedValue);
                    arr.Add(control5.SelectedValue);
                    arr.Add(control6.Checked);
                    arr.Add(control3.Value);
                    AddDataToTable(arr, dataTable);
                }
            }
        }
        return dataTable;
    }

    public void GetProfileDetail(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectAllProfile", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        Profile_ViewEditProfileDetail.objDV = dataSet.Tables[0].DefaultView;
        trPagingControls.Attributes.Add("style", "display:''");
        PageNo = 0;
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewEditProfileDetail.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Profile_ViewEditProfileDetail.PageSize;
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
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewEditProfileDetail.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewEditProfileDetail.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewEditProfileDetail.objDV, PageNo);
        rptProfileLists.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptProfileLists.DataSource = ApplyPaging(Profile_ViewEditProfileDetail.objDV, PageNo);
        rptProfileLists.DataBind();
    }
    #endregion

}