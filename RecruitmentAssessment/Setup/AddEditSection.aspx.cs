﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

using System.Configuration;
using System.Web.UI.HtmlControls;

public partial class AddEditSection : XRecBase
{
    int sectionCode = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            trMessage.Style["display"] = "none";
            if (Request.QueryString != null && Request.QueryString["sid"] != null && Request.QueryString != null && Request.QueryString["sid"] != null)
            {
                if (Request.QueryString["sid"].ToString() != "")
                {
                    sectionCode = Convert.ToInt32(Request.QueryString["sid"].ToString());
                    ViewState["sid"] = Request.QueryString["sid"].ToString();
                }
            }
            else
            {
                sectionCode = 0;
            }
            ShowData();
        }
    }



    public void ShowData()
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);
        string strSQL = string.Empty;

        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XREC_Select_SectionDetail ", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@SectionCode", Convert.ToInt32(Request.QueryString["sid"]));
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["SectionName"].ToString();
                }
            }
        }
        catch (Exception exp1)
        {
            //throw exp1;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, exp1.StackTrace, exp1, UserID.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);

        int Exist = 0;
        lblMsg.Text = "";
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("XREC_Insert_Update_Section", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@SectionName", txtName.Text);

            sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
            sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);

            if (sectionCode == 0 && ViewState["sid"] == null)
            {
                sqlCommand.Parameters.AddWithValue("@SectionCode", 0); // insert
            }

            else if (ViewState["sid"] != null && Request.QueryString["sid"] != "" && Request.QueryString["sid"] != string.Empty)
            {
                sqlCommand.Parameters.AddWithValue("@SectionCode", Convert.ToInt32(Request.QueryString["sid"])); // update
            }
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Exist = Convert.ToInt32(dt.Rows[0]["SectionCode"].ToString());
                ViewState["sid"] = Exist;
                if (Exist == 0)
                {
                    trMessage.Style["display"] = "";
                    lblMessage.Text = "This Section already exists.";
                }

                else
                {
                    lblMsg.Text = "";
                    sectionCode = Convert.ToInt32(dt.Rows[0]["SectionCode"]);
                    ScriptManager.RegisterStartupScript(this, GetType(), "pass", "refreshParent();", true);
                }
            }
        }

        catch (Exception exp1)
        {
            //throw exp1;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, exp1.StackTrace, exp1, UserID.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }


    }
}