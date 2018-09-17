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
using System.Collections;
using ErrorLog;

public partial class Profile_AddEditProfile : CustomBasePage
{
    #region Variables
    string ProfileCode = "0";
    protected DataTable myDt;
    int addProfileCount = 0;
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;
    protected DataSet dsOGData;
    DataRow row;
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    #endregion

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
            if (QueryStringVar != null)
                secQueryString = new SecureQueryString(QueryStringVar);
            lblMsg.Visible = false;
            try
            {
                CheckQueryString();
                GetOGData();
                if (string.IsNullOrEmpty(counter.Value))
                    counter.Value = addProfileCount.ToString();
                else
                    addProfileCount = int.Parse(counter.Value);
                if (!(ProfileCode != "0"))
                    return;
                BindProfile();
                BindInitialTable();
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            }
        }
        else
        {
            if (dsOGData != null)
                return;
            dsOGData = (DataSet)ViewState["OgData"];
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string str = InsertProfile();
            if (str != null)
            {
                if (str != "")
                {
                    if (str != "0")
                    {
                        foreach (RepeaterItem repeaterItem in rptParameter.Items)
                        {
                            ArrayList arrayList = new ArrayList();
                            DropDownList control1 = repeaterItem.FindControl("ddlParameter") as DropDownList;
                            DropDownList control2 = repeaterItem.FindControl("ddlValue") as DropDownList;
                            CheckBox control3 = repeaterItem.FindControl("chkMandatory") as CheckBox;
                            repeaterItem.FindControl("hdnProfileParameterCode");
                            if (control1.SelectedValue != "" && control1.SelectedValue != "0" && (control2.SelectedValue != "" && control2.SelectedValue != "0"))
                                Convert.ToString(AdminClass.InsertProfileParameter(Convert.ToInt32(str), Convert.ToInt32(control1.SelectedValue), Convert.ToInt32(control2.SelectedValue), control3.Checked, UserCode, Request.UserHostAddress.ToString()));
                        }
                        Convert.ToString(AdminClass.InsertProfileParameterScore(Convert.ToInt32(str), UserCode, Request.UserHostAddress.ToString()));
                        lblMsg.Text = "Successfully Saved!";
                        lblMsg.Visible = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        Page.RegisterStartupScript("Close", "<script language=JavaScript> CloseHighSlideWithParentRefresh();</script>");
    }

    protected void rptParameter_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (!(e.CommandName == "Delete"))
                return;
            SaveData();
            string s = e.CommandArgument.ToString();
            string str = (e.Item.FindControl("hdnCount") as HiddenField).Value;
            myDt = ViewState["myDatatable"] as DataTable;
            if (int.Parse(s) > 0)
                RemoveProfileParameter(int.Parse(s));
            for (int index = 0; index < myDt.Rows.Count; ++index)
            {
                myDt.Rows[index]["ProfileParameter_Code"].ToString();
                myDt.Rows[index]["count"].ToString();
                if (index == e.Item.ItemIndex)
                    myDt.Rows.Remove(myDt.Rows[index]);
            }
            ViewState["myDatatable"] = myDt;
            rptParameter.DataSource = myDt;
            rptParameter.DataBind();
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
            AddNewProfile();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptParameter_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.Item)
                return;
            ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
            DropDownList control1 = (DropDownList)e.Item.FindControl("ddlParameter");
            DropDownList control2 = (DropDownList)e.Item.FindControl("ddlValue");
            CheckBox control3 = (CheckBox)e.Item.FindControl("chkMandatory");
            HiddenField control4 = (HiddenField)e.Item.FindControl("hdnCount");
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
            if (DataBinder.Eval(e.Item.DataItem, "Is_Mandatory") != null)
                control3.Checked = Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "Is_Mandatory"));
            control4.Value = DataBinder.Eval(e.Item.DataItem, "count").ToString();
            counter.Value = control4.Value;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private void GetOGData()
    {
        dsOGData = Common.GetParameter();
        if (dsOGData.Tables[0].Rows.Count <= 0)
            return;
        ViewState["OgData"] = dsOGData;
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
            DataSet valuebyParameterCode = Common.GetParameterValuebyParameterCode(Convert.ToInt32(dropDownList.SelectedValue));
            if (valuebyParameterCode.Tables.Count == 0 || valuebyParameterCode.Tables[0].Rows.Count <= 0)
                return;
            control.DataSource = valuebyParameterCode;
            control.DataTextField = "ValColumn_Name";
            control.DataValueField = "Column_Name";
            control.DataBind();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    public DataTable BindInitialTable()
    {
        ArrayList arr = new ArrayList();
        myDt = new DataTable();
        DataSet profileParameterByCode = AdminClass.GetProfileParameterByCode(Convert.ToInt32(ProfileCode));
        if (profileParameterByCode.Tables[0].Rows.Count > 0)
        {
            myDt = profileParameterByCode.Tables[0].Copy();
            ViewState["myDatatable"] = myDt;
        }
        else
        {
            myDt = CreateDataTable();
            ViewState.Remove("myDatatable");
            ViewState["myDatatable"] = myDt;
            arr.Add("0");
            arr.Add("0");
            arr.Add("0");
            arr.Add("0");
            arr.Add("False");
            arr.Add(addProfileCount);
            AddDataToTable(arr, (DataTable)ViewState["myDatatable"]);
        }
        rptParameter.DataSource = ((DataTable)ViewState["myDatatable"]).DefaultView;
        rptParameter.DataBind();
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

    private void BindProfile()
    {
        DataSet profileByCode = AdminClass.GetProfileByCode(Convert.ToInt32(ProfileCode));
        if (profileByCode.Tables[0].Rows.Count <= 0)
            return;
        txtProfileName.Text = profileByCode.Tables[0].Rows[0]["Profile_Name"].ToString();
        txtDesc.Text = profileByCode.Tables[0].Rows[0]["Profile_Desc"].ToString();
        txtPrefix.Text = profileByCode.Tables[0].Rows[0]["prefix"].ToString();
        btnAdd.Text = "Update Profile";
        lblHead.Text = "Edit Profile";
    }

    private void CheckQueryString()
    {
        if (QueryStringVar == null || secQueryString["pCode"] == null)
            return;
        ProfileCode = secQueryString["pCode"].ToString();
        hdnProfileCode.Value = secQueryString["pCode"].ToString();
    }

    private string InsertProfile()
    {
        return Convert.ToString(AdminClass.InsertProfile(txtProfileName.Text, txtDesc.Text, Request.UserHostAddress.ToString(), UserCode, Convert.ToInt32(hdnProfileCode.Value), txtPrefix.Text));
    }

    private void AddNewProfile()
    {
        ++addProfileCount;
        ArrayList arr = new ArrayList();
        arr.Add("0");
        arr.Add("0");
        arr.Add("0");
        arr.Add("0");
        arr.Add("False");
        arr.Add(addProfileCount);
        SaveData();
        AddDataToTable(arr, (DataTable)ViewState["myDatatable"]);
        rptParameter.DataSource = ((DataTable)ViewState["myDatatable"]).DefaultView;
        rptParameter.DataBind();
    }

    private void SaveData()
    {
        DataTable dataTable = CreateDataTable();
        foreach (RepeaterItem repeaterItem in rptParameter.Items)
        {
            ArrayList arr = new ArrayList();
            DropDownList control1 = repeaterItem.FindControl("ddlParameter") as DropDownList;
            DropDownList control2 = repeaterItem.FindControl("ddlValue") as DropDownList;
            CheckBox control3 = repeaterItem.FindControl("chkMandatory") as CheckBox;
            HiddenField control4 = repeaterItem.FindControl("hdnProfileParameterCode") as HiddenField;
            HiddenField control5 = repeaterItem.FindControl("hdnCount") as HiddenField;
            arr.Add(control4.Value);
            arr.Add(hdnProfileCode.Value);
            arr.Add(control1.SelectedValue);
            arr.Add(control2.SelectedValue);
            arr.Add(control3.Checked);
            arr.Add(control5.Value);
            AddDataToTable(arr, dataTable);
        }
        ViewState.Remove("myDatatable");
        ViewState["myDatatable"] = dataTable;
    }

    private void RemoveProfileParameter(int ProfileParameter_Code)
    {
        try
        {
            Convert.ToString(AdminClass.DeleteProfileParameter(ProfileParameter_Code, UserCode, Request.UserHostAddress.ToString()));
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }
    #endregion



}