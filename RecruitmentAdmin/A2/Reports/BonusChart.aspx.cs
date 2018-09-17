using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using ErrorLog;
using System.Configuration;


public partial class Candidate_BonusChart : CustomBasePage
{
    #region variable
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString = new SecureQueryString();
    static DataView objDV = new DataView();
    static int PageSize;
    PagedDataSource objPDS = new System.Web.UI.WebControls.PagedDataSource();
    int categoryIndex = 0;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            BindOGData();
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private void BindOGData()
    {
        SqlCommand selectCommand = new SqlCommand("dbo.XREC_Select_DomainFiltered", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        ddlDomain.DataSource = dataSet.Tables[0];
        ddlDomain.DataTextField = "Domain_Name";
        ddlDomain.DataValueField = "Domain_Code";
        ddlDomain.DataBind();
    }

    private void BindData()
    {
        SqlCommand selectCommand = new SqlCommand("dbo.XREC_Select_DomainFiltered", connection);
        selectCommand.Parameters.AddWithValue("@DomainCode", ddlDomain.SelectedValue);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        rptDomain.DataSource = dataSet.Tables[0];
        rptDomain.DataBind();
    }

    public void GetCandidateResume(ref SqlConnection connection)
    {
    }

    protected void rptDomain_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.Item)
            return;
        HiddenField control1 = (HiddenField)e.Item.FindControl("hdnDomainCode");
        DataList control2 = (DataList)e.Item.FindControl("rptSubDomain");
        SqlCommand selectCommand = new SqlCommand("dbo.XREC_Select_Select_DomainWiseSubDomain", connection);
        selectCommand.Parameters.AddWithValue("@DomainCode", control1.Value);
        selectCommand.Parameters.AddWithValue("@BonusType_Code", int.Parse(Request["btc"].ToString()));
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        control2.DataSource = dataSet.Tables[0];
        control2.DataBind();
    }

    protected void rptSubDomain_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.Item)
            return;
        HiddenField control1 = (HiddenField)e.Item.FindControl("hdnSubDomainCode");
        DataList control2 = (DataList)e.Item.FindControl("rptCategory");
        SqlCommand selectCommand = new SqlCommand("dbo.XREC_Select_Select_CategorySubDomain", connection);
        selectCommand.Parameters.AddWithValue("@SubDomain_Code", control1.Value);
        selectCommand.Parameters.AddWithValue("@BonusType_Code", int.Parse(Request["btc"].ToString()));
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        control2.DataSource = dataSet.Tables[0];
        control2.DataBind();
    }

    protected void rptCategory_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.Item)
            return;
        ++categoryIndex;
        HiddenField control1 = (HiddenField)e.Item.FindControl("hdnCategoryCode");
        Repeater control2 = (Repeater)e.Item.FindControl("rptGrade");
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_Select_AllGrade", connection);
        selectCommand.Parameters.AddWithValue("@Category_Code", control1.Value);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        control2.DataSource = dataSet.Tables[0];
        control2.DataBind();
    }

    protected void rptGrade_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.Item || categoryIndex <= 1)
            return;
        e.Item.FindControl("tdGrade").Visible = false;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SaveData();
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "exists", "alert('Updated Successfully!');", true);
            BindData();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void SaveData()
    {
        foreach (DataListItem dataListItem1 in rptDomain.Items)
        {
            if (dataListItem1.ItemType == ListItemType.Item || dataListItem1.ItemType == ListItemType.AlternatingItem)
            {
                foreach (DataListItem dataListItem2 in ((DataList)dataListItem1.FindControl("rptSubDomain")).Items)
                {
                    if (dataListItem2.ItemType == ListItemType.Item || dataListItem2.ItemType == ListItemType.AlternatingItem)
                    {
                        foreach (DataListItem dataListItem3 in ((DataList)dataListItem2.FindControl("rptCategory")).Items)
                        {
                            if (dataListItem3.ItemType == ListItemType.Item || dataListItem3.ItemType == ListItemType.AlternatingItem)
                            {
                                int Category_Code = int.Parse(((HiddenField)dataListItem3.FindControl("hdnCategoryCode")).Value);
                                foreach (RepeaterItem repeaterItem in ((Repeater)dataListItem3.FindControl("rptGrade")).Items)
                                {
                                    TextBox control1 = (TextBox)repeaterItem.FindControl("txtAmount");
                                    if (control1.Text != string.Empty && int.Parse(control1.Text) > 0)
                                    {
                                        HiddenField control2 = (HiddenField)repeaterItem.FindControl("hdnHRGrade_ID");
                                        InsertData(Category_Code, int.Parse(control2.Value), Convert.ToDecimal(control1.Text));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    protected void InsertData(int Category_Code, int HRGrade_ID, Decimal Amount)
    {
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.XREC_Update_BonusChart", connection);
            sqlCommand.Parameters.AddWithValue("@Category_Code", Category_Code);
            sqlCommand.Parameters.AddWithValue("@HRGrade_ID", HRGrade_ID);
            sqlCommand.Parameters.AddWithValue("@Amount", Amount);
            sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
            sqlCommand.Parameters.AddWithValue("@Updated_IP", USERIP);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            connection.Close();
        }
    }

}