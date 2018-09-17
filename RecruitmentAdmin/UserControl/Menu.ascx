<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="UserControl_Menu" %>

<script runat="server">
 
    public StringBuilder UsertypeHtml = new StringBuilder();
    public string UserID = string.Empty;    
    System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    System.Data.SqlClient.SqlConnection Errlogconnection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    private void Page_Load(object sender, System.EventArgs e)
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

    private void GenerateTopMenu()
    {
        try
        {
            CustomBasePage objuser = new CustomBasePage();
            UserID = objuser.UserCode.ToString();
            System.Data.SqlClient.SqlCommand command;
            command = new System.Data.SqlClient.SqlCommand();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "XRec_SelectMenuLinks ";
            command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = objuser.UserCode;

            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(command);
            System.Data.DataSet ds = new System.Data.DataSet();
            adapter.Fill(ds);
            BindMenuField(ds);

        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }
      private void BindMenuField(System.Data.DataSet dsData)
    {
        if (dsData.Tables.Count > 0 && dsData.Tables[0].Rows.Count > 0)
        {
            foreach (System.Data.DataRow dr in dsData.Tables[0].Rows)
            {
                if (Convert.ToBoolean(dr["IsParent"]))
                {
                    System.Data.DataRow[] drFilter = dsData.Tables[1].Select("ParentCode = " + Convert.ToInt32(dr["MenuLinkID"]));
                    if (drFilter.Length > 0)
                    {
                        UsertypeHtml.Append("<li><a href=\" " + dr["URL"].ToString() + "\">" + dr["MenuLinkName"].ToString() + "</a>");
                        UsertypeHtml.Append("<ul>");
                        foreach (System.Data.DataRow drNew in dsData.Tables[1].Rows)
                        {
                            if (Convert.ToString(dr["MenuLinkID"]) == Convert.ToString(drNew["ParentCode"]))
                            {
                                UsertypeHtml.Append("<li><a href=\" " + drNew["URL"].ToString() + "\">" + drNew["MenuLinkName"].ToString() + "</a></li>");

                            }
                        }
                        UsertypeHtml.Append("</ul>");
                    }
                }
                UsertypeHtml.Append("</li>");
            }
        }
    }


    protected void LnkLogout_Click(object sender, EventArgs e)
    {
        //Session.Abandon();
        // Response.Redirect(Constants.AdminLoginPage);

    }
</script>

<div id="myslidemenu" class="jqueryslidemenu" style="height: 26px;
    font-size: 11px; background-color: #222222; text-align: left;">
    <ul style="height: 26px">
        <%=UsertypeHtml.ToString() %>
    </ul>
</div>