using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;
using System.Web.Services;
using ErrorLog;

public class Items
{
    public string requisition_id;
    public string requisition_priority;
}

public partial class Requisition_ChangePriority : CustomBasePage
{
    #region variables
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    #endregion

    #region Paging Variables
    public static DataView objDV = new DataView();
    public static int PageSize;
    public static string SortDirection = "DESC";
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
            Requisition_ChangePriority.PageSize = 25;
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

    protected void rptRequisitionLists_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnRequisitionCode");
            Label control2 = (Label)e.Item.FindControl("lblMsg");
            TextBox control3 = (TextBox)e.Item.FindControl("txtPriority");
            Button control4 = (Button)e.Item.FindControl("btnPriority");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptRequisitionLists_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
    }

    protected void btnPriority_Click(object sender, EventArgs e)
    {
        try
        {
            List<int> source = new List<int>();
            foreach (Control control1 in rptRequisitionLists.Items)
            {
                TextBox control2 = (TextBox)control1.FindControl("txtPriority");
                if (control2.Text != "")
                    source.Add(Convert.ToInt32(control2.Text));
            }
            if (source.Distinct<int>().ToList<int>().Count < source.Count)
                return;
            foreach (RepeaterItem repeaterItem in rptRequisitionLists.Items)
            {
                TextBox control1 = (TextBox)repeaterItem.FindControl("txtPriority");
                HiddenField control2 = (HiddenField)repeaterItem.FindControl("hdnRequisitionCode");
                if (control1.Enabled)
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("XREC_Update_RequisitionPriority", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@RequisitionCode", control2.Value);
                    sqlCommand.Parameters.AddWithValue("@Priority", control1.Text);
                    sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
                    sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserCode);
                    sqlCommand.ExecuteNonQuery();
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

    public void GetRequisitionDetail(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectAllRequisitionPriorityWise", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        Requisition_ChangePriority.objDV = dataSet.Tables[0].DefaultView;
        trPagingControls.Attributes.Add("style", "display:''");
        PageNo = 0;
        rptRequisitionLists.DataSource = ApplyPaging(Requisition_ChangePriority.objDV, PageNo);
        rptRequisitionLists.DataBind();
    }

    [WebMethod]
    public static string save_sort(Items[] items)
    {
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
            connection.Open();
            foreach (Items items1 in items)
            {
                if (items1 != null)
                {
                    SqlCommand sqlCommand = new SqlCommand("XREC_Update_RequisitionOnePriority", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@RequisitionCode", items1.requisition_id);
                    sqlCommand.Parameters.AddWithValue("@Priority", items1.requisition_priority);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            connection.Close();
            return "";
        }
        catch
        {
            return "";
        }
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = Requisition_ChangePriority.PageSize;
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
        rptRequisitionLists.DataSource = ApplyPaging(Requisition_ChangePriority.objDV, PageNo);
        rptRequisitionLists.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptRequisitionLists.DataSource = ApplyPaging(Requisition_ChangePriority.objDV, PageNo);
        rptRequisitionLists.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptRequisitionLists.DataSource = ApplyPaging(Requisition_ChangePriority.objDV, PageNo);
        rptRequisitionLists.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptRequisitionLists.DataSource = ApplyPaging(Requisition_ChangePriority.objDV, PageNo);
        rptRequisitionLists.DataBind();
    }
    #endregion


}