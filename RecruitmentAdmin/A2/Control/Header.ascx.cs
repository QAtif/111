using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Control_Header : System.Web.UI.UserControl
{
    public StringBuilder UsertypeHtml = new StringBuilder();
    public string UserID = string.Empty;
    System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    System.Data.SqlClient.SqlConnection Errlogconnection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    private void Page_Load(object sender, EventArgs e)
    {
        try
        {
            GenerateTopMenu();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void BindPortalUser(string UserCode)
    {
        DataTable dataTable = new DataTable();
        if (connection.State != ConnectionState.Open)
            connection.Open();
        SqlCommand selectCommand = new SqlCommand("dbo.BCO_Get_PortalUserInfo", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.Add("@UserCode", SqlDbType.Int).Value = UserCode;
        new SqlDataAdapter(selectCommand).Fill(dataTable);
        if (dataTable == null || dataTable.Rows.Count <= 0)
            return;
        spnPortalUserName.InnerHtml = dataTable.Rows[0]["Name"].ToString();
        spnPortalUserName1.InnerHtml = "<img ID='imgPortalUser' runat='server' src='" + dataTable.Rows[0]["PicPath"].ToString() + "' alt='' width='28' height='28' />" + dataTable.Rows[0]["Name"].ToString();
    }

    private void GenerateTopMenu()
    {
        try
        {
            CustomBasePage customBasePage = new CustomBasePage();
            UserID = customBasePage.UserCode.ToString();
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.CommandText = "XRec_SelectMenuLinks ";
            selectCommand.Parameters.Add("@UserID", SqlDbType.Int).Value = customBasePage.UserCode;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            BindMenuField(dataSet);
            if (string.IsNullOrEmpty(UserID))
                return;
            BindPortalUser(UserID);
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }

    private void BindMenuField(DataSet dsData)
    {
        if (dsData.Tables.Count <= 0 || dsData.Tables[0].Rows.Count <= 0)
            return;
        foreach (DataRow row1 in (InternalDataCollectionBase)dsData.Tables[0].Rows)
        {
            if (Convert.ToBoolean(row1["IsParent"]) && dsData.Tables[1].Select("ParentCode = " + Convert.ToInt32(row1["MenuLinkID"])).Length > 0)
            {
                UsertypeHtml.Append("<li><a>" + row1["MenuLinkName"].ToString() + "</a>");
                UsertypeHtml.Append("<ul>");
                foreach (DataRow row2 in (InternalDataCollectionBase)dsData.Tables[1].Rows)
                {
                    if (Convert.ToString(row1["MenuLinkID"]) == Convert.ToString(row2["ParentCode"]))
                        UsertypeHtml.Append("<li><a href=\" " + row2["URL"].ToString() + "\">" + row2["MenuLinkName"].ToString() + "</a></li>");
                }
                UsertypeHtml.Append("</ul>");
            }
            UsertypeHtml.Append("</li>");
        }
    }

    protected void LnkLogout_Click(object sender, EventArgs e)
    {
    }
}