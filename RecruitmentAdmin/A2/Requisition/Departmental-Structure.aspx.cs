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
using System.Web.Services;
using System.Web.SessionState;

public partial class Departments_Departmental_Structure : CustomBasePage, IRequiresSessionState
{

    public string UserCode1 = string.Empty;
    public string UserTypeCode = string.Empty;
    public string updateByIP = string.Empty;
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SecureQueryString sQString = new SecureQueryString();
    DataSet DSCategSpecialist;



    protected void Page_Load(object sender, EventArgs e)
    {
        updateByIP = USERIP;
        UserCode1 = UserCode.ToString();
        if (IsPostBack)
            return;
        try
        {
            FillDropDown();
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
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

    private void FillDropDown()
    {
        DataSet dataSet = Common.FillDropDown(UserCode);
        if (dataSet.Tables[5].Rows.Count > 0)
        {
            ddlDepartment.DataSource = dataSet.Tables[5];
            ddlDepartment.DataTextField = "Domain_Name";
            ddlDepartment.DataValueField = "Domain_Code";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("----All----", "-1"));
        }
        DataSet categoryByDomainCode = Common.GetCategoryByDomainCode(-1);
        if (categoryByDomainCode.Tables[0].Rows.Count <= 0)
            return;
        ddlCategory.DataSource = categoryByDomainCode.Tables[0];
        ddlCategory.DataTextField = "Category_Name";
        ddlCategory.DataValueField = "Category_Code";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("----All----", "-1"));
    }

    protected void ddlDomain_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet categoryByDomainCode = Common.GetCategoryByDomainCode(Convert.ToInt32(ddlDepartment.SelectedValue));
            if (categoryByDomainCode.Tables[0].Rows.Count <= 0)
                return;
            ddlCategory.DataSource = categoryByDomainCode;
            ddlCategory.DataTextField = "Category_Name";
            ddlCategory.DataValueField = "Category_Code";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("--All--", "-1"));
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, "Browse Resume");
        }
    }

    private void BindData()
    {
        DataSet dataSet = AdminClass.CategoryListByUserCode(Convert.ToInt32(ddlDepartment.SelectedValue), Convert.ToInt32(ddlCategory.SelectedValue), UserCode);
        if (dataSet != null)
        {
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                rptDeparments.DataSource = dataSet.Tables[0];
                rptDeparments.DataBind();
            }
            if (dataSet.Tables.Count >= 2)
            {
                if (dataSet.Tables[1].Rows.Count > 0)
                {
                    ddlCity.DataSource = dataSet.Tables[1];
                    ddlCity.DataTextField = "City";
                    ddlCity.DataValueField = "City_Code";
                    ddlCity.DataBind();
                }
                if (dataSet.Tables.Count >= 3 && dataSet.Tables[2].Rows.Count > 0)
                    UserTypeCode = dataSet.Tables[2].Rows[0]["UserTypeCode"].ToString();
            }
        }
        ShowHideActions();
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        BindData();
    }

    protected void rptDepartment_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            Repeater control1 = (Repeater)e.Item.FindControl("rptCat");
            Repeater control2 = (Repeater)e.Item.FindControl("rptRequisitions");
            HiddenField control3 = (HiddenField)e.Item.FindControl("hdnDepCode");
            if (control3 == null)
                return;
            string str = "UpdateRequisition.aspx?CatCode=" + sQString.encrypt(ddlCategory.SelectedValue) + "&DepCode=" + sQString.encrypt(control3.Value);
            ((HtmlControl)e.Item.FindControl("UpdateReqStatus")).Attributes.Add("href", str);
            DataSet categoriesOnDepartment = AdminClass.GetCategoriesOnDepartment(Convert.ToInt32(control3.Value), Convert.ToInt32(ddlCategory.SelectedValue));
            if (categoriesOnDepartment == null || categoriesOnDepartment.Tables[0].Rows.Count <= 0 || control1 == null)
                return;
            control1.DataSource = categoriesOnDepartment.Tables[0];
            control1.DataBind();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private void UpdateRequisitionStatus(int categoryCode, int requisitionStatusCode, string RequisitionCode, string CategorySpecialist)
    {
        try
        {
            AdminClass.UpdateRequisitionStatus(categoryCode, Convert.ToInt32(RequisitionCode), UserCode, UserTypeCode, Convert.ToInt32(requisitionStatusCode), UserCode, USERIP, CategorySpecialist);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    [WebMethod]
    public static void RaiseRequisition(string items)
    {
        string[] strArray = new string[0];
        try
        {
            strArray = items.Split('|');
            if (((IEnumerable<string>)strArray).Count<string>() < 5)
                return;
            AdminClass.InsertRequisition(Convert.ToInt32(strArray[0]), Convert.ToInt32(strArray[1]), Convert.ToInt32(strArray[2]), strArray[3] == null || strArray[3] == "" ? 0 : Convert.ToInt32(strArray[3]), strArray[4].ToString());
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, strArray[3].ToString());
        }
    }
}