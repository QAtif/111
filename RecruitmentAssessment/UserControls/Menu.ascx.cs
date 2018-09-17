using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;


public partial class UserControls_Menu : System.Web.UI.UserControl
{
    public StringBuilder strBuilderMenu = new StringBuilder();
    private string employeeid = string.Empty;
    private string roleid = string.Empty;
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);

    public string Roleid
    {
        get { return roleid; }
        set { roleid = value; }
    }

    public string EmployeeID
    {
        get { return employeeid; }
        set { employeeid = value; }
    }

   
    protected void Page_Load(object sender, EventArgs e)
    {
        GenerateMenu();
    }

    protected void GenerateMenu()
    {
        try
        {
            DataSet ds = LoadMenu();
            string siteRoot = string.Empty;
            if (ConfigurationManager.AppSettings["SiteRoot"] != null)
                siteRoot = ConfigurationManager.AppSettings["SiteRoot"];
            if (ds != null && ds.Tables.Count > 0)
            {
                strBuilderMenu.Append("<ul class='menu'><li><a href=\"" + siteRoot + "/Default.aspx\">Home</a></li>");
                int rowcount1 = 0;
                int rowcount2 = 0;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //strBuilderMenu.Append("<li><a href=\"#\">" + ds.Tables[0].Rows[i]["ModuleName"].ToString() + "</a>");
                    strBuilderMenu.Append("<li><a ");

                    DataView dv = ds.Tables[1].DefaultView;
                    string expresion = "ParentModuleID = " + ds.Tables[0].Rows[i]["ModuleID"];
                    dv.RowFilter = expresion;
                    if (dv.Count > 0)
                    {
                        int j = 0;

                        strBuilderMenu.Append("href=\"#\">" + ds.Tables[0].Rows[i]["ModuleName"].ToString() + "</a>");

                        strBuilderMenu.Append("<ul>");
                        //foreach (DataRowView drV in dv)
                        //{
                        //    strBuilderMenu.Append("<li><a href=\"" + drV["ScreenURL"].ToString() + "\">" + drV["ScreenName"] + "</a></li>");
                        //}

                        for (; j < dv.Count; j++)
                        {
                            strBuilderMenu.Append("<li><a href=\"#\">" + dv[j]["ModuleName"] + "</a>");

                            strBuilderMenu.Append("<ul>");

                            DataView dv1 = ds.Tables[2].DefaultView;
                            string expresion1 = "ModuleID = " + ds.Tables[1].Rows[rowcount2]["ModuleID"];
                            dv1.RowFilter = expresion1;


                            if (dv1.Count > 0)
                            {
                                int k = 0;
                                if (dv1.Count == 1)
                                {
                                    strBuilderMenu.Append("<li><a href=\"" + siteRoot + dv1[0]["ScreenURL"].ToString() + "\">" + dv1[0]["ScreenName"].ToString() + "</a></li>");
                                    k = 1;
                                }
                                else
                                {
                                    for (; k < dv1.Count; k++)
                                    {
                                        strBuilderMenu.Append("<li><a href=\"" + siteRoot + dv1[k]["ScreenURL"].ToString() + "\">" + dv1[k]["ScreenName"] + "</a></li>");
                                    }

                                }
                                strBuilderMenu.Append("</ul>");
                            }
                            strBuilderMenu.Append("</li>");
                            rowcount2++;
                        }

                        //strBuilderMenu.Append("<li>");

                        DataView dv2 = ds.Tables[2].DefaultView;
                        string expresion2 = "ModuleID = " + ds.Tables[0].Rows[i]["ModuleID"];
                        dv2.RowFilter = expresion2;
                        if (dv2.Count > 0)
                        {
                            int k = 0;
                            //if (dv2.Count == 1)
                            //{
                            //    strBuilderMenu.Append("<li><a href=\"" + dv2[0]["ScreenURL"].ToString() + "\">" + dv2[0]["ScreenName"].ToString() + "</a></li>");
                            //    k = 1;
                            //}
                            //else
                            //{
                            for (; k < dv2.Count; k++)
                            {
                                strBuilderMenu.Append("<li><a href=\"" + siteRoot + dv2[k]["ScreenURL"].ToString() + "\">" + dv2[k]["ScreenName"] + "</a></li>");
                            }

                            //}

                        }
                        strBuilderMenu.Append("</ul>");
                    }
                    else
                    {
                        DataView dv3 = ds.Tables[2].DefaultView;
                        string expresion3 = "ModuleID = " + ds.Tables[0].Rows[i]["ModuleID"];
                        dv3.RowFilter = expresion3;
                        if (dv3.Count > 0)
                        {
                            strBuilderMenu.Append("href=\"#\">" + ds.Tables[0].Rows[i]["ModuleName"].ToString() + "</a>");

                            strBuilderMenu.Append("<ul>");
                            int k = 0;
                            //if (dv2.Count == 1)
                            //{
                            //    strBuilderMenu.Append("<li><a href=\"" + dv2[0]["ScreenURL"].ToString() + "\">" + dv2[0]["ScreenName"].ToString() + "</a></li>");
                            //    k = 1;
                            //}
                            //else
                            //{

                            for (; k < dv3.Count; k++)
                            {
                                strBuilderMenu.Append("<li><a href=\"" + siteRoot + dv3[k]["ScreenURL"].ToString() + "\">" + dv3[k]["ScreenName"] + "</a></li>");
                            }
                           
                            //}

                        }
                     

                        strBuilderMenu.Append("</ul>");
                        strBuilderMenu.Append("</li>");
                    }


                    rowcount1++;
                }
                strBuilderMenu.Append("</ul>");
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }


    public DataSet LoadMenu()
    {

        /*
        SqlCommand command;
        command = new SqlCommand("Procurement_Select_EmployeeMenu", connection);
        command.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
        command.Parameters.AddWithValue("@RoleID", Roleid);
        */
        DataSet ds = new DataSet();
        //adapter.Fill(ds);

        return ds;
    }
}