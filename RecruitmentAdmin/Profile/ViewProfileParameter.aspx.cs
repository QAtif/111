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

public partial class Profile_ViewProfileParameter : CustomBasePage
{
    #region Variables
    string ProfileCode = "0";
    protected DataTable myDt;
    int addProfileCount = 0;
    protected DataSet dsOGData;
    DataRow row;

    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString;
    #endregion

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        QueryStringVar = HttpContext.Current.Request[SecureQueryString.QueryStringVar];
        secQueryString = new SecureQueryString(QueryStringVar);
        try
        {
            CheckQueryString();
            connection.Open();
            if (!(ProfileCode != "0"))
                return;
            BindProfile(ref connection);
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

    protected void rptProfile_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem)
            return;
        int itemType = (int)e.Item.ItemType;
    }

    private void BindProfile(ref SqlConnection connection)
    {
        SqlCommand selectCommand1 = new SqlCommand("XRec_SelectProfileByCode", connection);
        selectCommand1.Parameters.AddWithValue("@ProfileCode", ProfileCode);
        selectCommand1.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(selectCommand1);
        DataSet dataSet1 = new DataSet();
        sqlDataAdapter1.Fill(dataSet1);
        if (dataSet1.Tables[0].Rows.Count > 0)
        {
            rptProfile.DataSource = dataSet1.Tables[0];
            rptProfile.DataBind();
        }
        SqlCommand selectCommand2 = new SqlCommand("XRec_SelectProfileAllParameter", connection);
        selectCommand2.Parameters.AddWithValue("@ProfileCode", ProfileCode);
        selectCommand2.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
        DataSet dataSet2 = new DataSet();
        sqlDataAdapter2.Fill(dataSet2);
        if (dataSet2.Tables[0].Rows.Count <= 0)
            return;
        BindGridView(dataSet2.Tables[0], dataSet2.Tables[1]);
    }

    private void BindGridView(DataTable dtData, DataTable dtParameter)
    {
        foreach (DataColumn column in (InternalDataCollectionBase)dtParameter.Columns)
        {
            BoundField boundField = new BoundField();
            boundField.DataField = column.ColumnName;
            boundField.HeaderText = column.ColumnName;
            gvTotalLeads.Columns.Add((DataControlField)boundField);
        }
        gvTotalLeads.DataSource = dtParameter;
        gvTotalLeads.DataBind();
        gvTotalLeads.Columns[0].Visible = false;
    }

    protected void gvTotalLeads_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.Header || e.Row.Cells.Count <= 0)
            return;
        foreach (TableCell cell in e.Row.Cells)
        {
            if (cell.Text.Contains("S_"))
                cell.Text = "";
        }
    }

    private void CheckQueryString()
    {
        if (secQueryString["pCode"] == null)
            return;
        ProfileCode = secQueryString["pCode"].ToString();
        hdnProfileCode.Value = secQueryString["pCode"].ToString();
    }

    #endregion


}