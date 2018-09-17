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

public partial class UserControl_Menu : System.Web.UI.UserControl
{
    //public StringBuilder UsertypeHtml = new StringBuilder();
    //public string UserID = string.Empty;
    //System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    //System.Data.SqlClient.SqlConnection Errlogconnection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    //private void Page_Load(object sender, System.EventArgs e)
    //{
    //    try
    //    {
    //        GenerateTopMenu();

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    //private void BindPortalUser(string UserCode)
    //{
    //    DataTable dt = new DataTable();

    //    if (connection.State != ConnectionState.Open)
    //        connection.Open();
    //    SqlCommand command = new SqlCommand("dbo.BCO_Get_PortalUserInfo", connection);
    //    command.CommandType = CommandType.StoredProcedure;
    //    command.Parameters.Add("@UserCode", SqlDbType.Int).Value = UserCode;
    //    SqlDataAdapter a = new SqlDataAdapter(command);
    //    a.Fill(dt);

    //    if (dt != null && dt.Rows.Count > 0)
    //    {
    //        // imgPortalUser.Src = dt.Rows[0]["PicPath"].ToString();
    //        spnPortalUserName.InnerHtml = dt.Rows[0]["Name"].ToString();

    //        //imgdp1.Src = dt.Rows[0]["PicPath"].ToString();
    //        spnPortalUserName1.InnerHtml = "<img ID='imgPortalUser' runat='server' src='" + dt.Rows[0]["PicPath"].ToString() + "' alt='' width='28' height='28' />" + dt.Rows[0]["Name"].ToString();

    //        //imgdp2.Src = dt.Rows[0]["PicPath"].ToString();
    //        // SUserName2.Text = dt.Rows[0]["Name"].ToString();
    //    }
    //}

    //private void GenerateTopMenu()
    //{
    //    try
    //    {
    //        CustomBasePage objuser = new CustomBasePage();
    //        UserID = objuser.UserCode.ToString();
    //        System.Data.SqlClient.SqlCommand command;
    //        command = new System.Data.SqlClient.SqlCommand();
    //        command.Connection = connection;
    //        command.CommandType = System.Data.CommandType.StoredProcedure;
    //        command.CommandText = "XRec_SelectMenuLinks ";
    //        command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = objuser.UserCode;

    //        System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(command);
    //        System.Data.DataSet ds = new System.Data.DataSet();
    //        adapter.Fill(ds);
    //        BindMenuField(ds);
    //        if (!string.IsNullOrEmpty(UserID))
    //            BindPortalUser(UserID);

    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex);
    //    }
    //}
    //private void BindMenuField(System.Data.DataSet dsData)
    //{
    //    if (dsData.Tables.Count > 0 && dsData.Tables[0].Rows.Count > 0)
    //    {
    //        foreach (System.Data.DataRow dr in dsData.Tables[0].Rows)
    //        {
    //            if (Convert.ToBoolean(dr["IsParent"]))
    //            {
    //                System.Data.DataRow[] drFilter = dsData.Tables[1].Select("ParentCode = " + Convert.ToInt32(dr["MenuLinkID"]));
    //                if (drFilter.Length > 0)
    //                {
    //                    UsertypeHtml.Append("<li><a href=\" " + dr["URL"].ToString() + "\">" + dr["MenuLinkName"].ToString() + "</a>");
    //                    UsertypeHtml.Append("<ul>");
    //                    foreach (System.Data.DataRow drNew in dsData.Tables[1].Rows)
    //                    {
    //                        if (Convert.ToString(dr["MenuLinkID"]) == Convert.ToString(drNew["ParentCode"]))
    //                        {
    //                            UsertypeHtml.Append("<li><a href=\" " + drNew["URL"].ToString() + "\">" + drNew["MenuLinkName"].ToString() + "</a></li>");

    //                        }
    //                    }
    //                    UsertypeHtml.Append("</ul>");
    //                }
    //            }
    //            UsertypeHtml.Append("</li>");
    //        }
    //    }
    //}


    //protected void LnkLogout_Click(object sender, EventArgs e)
    //{
    //    //Session.Abandon();
    //    // Response.Redirect(Constants.AdminLoginPage);

    //}
}