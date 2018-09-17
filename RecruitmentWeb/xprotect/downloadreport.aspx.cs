using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class xprotect_downloadreport : System.Web.UI.Page
{
    string LoginID = ConfigurationManager.AppSettings["UID"].ToString();
    string Pwd = ConfigurationManager.AppSettings["PWD"].ToString();
    public DataSet objDS = new DataSet();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["auc"] != null && !string.IsNullOrEmpty(Session["auc"].ToString()))
            {
                GetData();
                divLogin.Visible = false;
                divData.Visible = true;
                lblMsg.Text = "";
            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {

            if (Page.IsValid)
            {
                if (LoginID == txtLogin.Text && Pwd == txtPass.Text)
                {
                    Session["auc"] = LoginID;
                    GetData();
                    divLogin.Visible = false;
                    divData.Visible = true;
                    lblMsg.Text = "";
                }
                else
                {
                    Session.Abandon();
                    lblMsg.Text = "Sorry! You are not authorized to view this page.";
                }
            }

        }
        catch (Exception)
        {
            Session.Abandon();
            lblMsg.Text = "Sorry! You are not authorized to view this page.";
        }
    }


    public void GetData()
    {
        using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            c.Open();
            using (SqlCommand command = new SqlCommand("XRec_XProtect_SelectDownloadUserData", c))
            {
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter a = new SqlDataAdapter(command))
                {
                    a.Fill(objDS);
                    grdData.DataSource = objDS.Tables[0];
                    grdData.DataBind();
                }
            }
        }
    }

}