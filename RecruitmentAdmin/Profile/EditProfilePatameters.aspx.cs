using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Collections;
using System.IO;
using XRecruitmentStatusLibrary;
using ErrorLog;

public partial class EditProfilePatameters : CustomBasePage
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
   public static DataSet ds = new DataSet();
    private void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlcommand = new SqlCommand("Xrec_Select_AllOG", connection);
            sqlcommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sqlcommand);
            da.Fill(ds);
            dataBind();

        }
    }
   
    public void dataBind()
    {        
        ddlprofile.DataSource = ds.Tables[5];
        ddlprofile.DataTextField = "Profile_name";
        ddlprofile.DataValueField = "profile_code";
        ddlprofile.DataBind();

        lstskill.DataSource = ds.Tables[2];
        lstskill.DataBind();

        lstEducationl.DataSource = ds.Tables[0];
        lstEducationl.DataBind();

        lstindustryl.DataSource = ds.Tables[1];
        lstindustryl.DataBind();

        lstdegree.DataSource = ds.Tables[4];
        lstdegree.DataBind();


        lstmajor.DataSource = ds.Tables[3];
        lstmajor.DataBind();
        connection.Close();
    }

    protected void txtsearch_ontextChange(object sender, EventArgs e)
    {
        if (txtsearch.Text != string.Empty)
        {
            DataTable dt = new DataTable();
            if (ds.Tables[0].Select("institute like '%" + txtsearch.Text + "%'").Length > 0)
            {
                dt = ds.Tables[0].Select("institute like '%" + txtsearch.Text + "%'").CopyToDataTable();
                lstEducationl.DataSource = dt;
                lstEducationl.DataBind();
            }
            DataTable dt1 = new DataTable();
            if (ds.Tables[2].Select("skill like '%" + txtsearch.Text + "%'").Length > 0)
            {
                dt1 = ds.Tables[2].Select("skill like '%" + txtsearch.Text + "%'").CopyToDataTable();
                lstskill.DataSource = dt1;
                lstskill.DataBind();
            }

            DataTable dt2 = new DataTable();
            if (ds.Tables[1].Select("industry like '%" + txtsearch.Text + "%'").Length > 0)
            {
                dt2 = ds.Tables[1].Select("industry like '%" + txtsearch.Text + "%'").CopyToDataTable();
                lstindustryl.DataSource = dt2;
                lstindustryl.DataBind();
            }
            
            
            DataTable dt3 = new DataTable();
            if (ds.Tables[4].Select("degree like '%" + txtsearch.Text + "%'").Length > 0)
            {
                dt3 = ds.Tables[4].Select("degree like '%" + txtsearch.Text + "%'").CopyToDataTable();
                lstdegree.DataSource = dt3;
                lstdegree.DataBind();
            }

            DataTable dt4 = new DataTable();
            if (ds.Tables[3].Select("major_name like '%" + txtsearch.Text + "%'").Length > 0)
            {
                dt4 = ds.Tables[3].Select("major_name like '%" + txtsearch.Text + "%'").CopyToDataTable();
                lstmajor.DataSource = dt4;
                lstmajor.DataBind();
            }
        }
        else
        {
            dataBind();
        }
    }
    public void moveRight(ListBox ListBox1, ListBox ListBox2)
    {
        for (int i = ListBox1.Items.Count - 1; i >= 0; i--)
        {
            if (ListBox1.Items[i].Selected == true)
            {
                ListBox2.Items.Add(ListBox1.Items[i]);
                ListItem li = ListBox1.Items[i];
                //lbl.Text = ListBox1.Items[i].Value;
                //  ListBox1.Items.Remove(li);

            }
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveRecord(lstskill, "5");
        SaveRecord(lstEducationl, "4");
        SaveRecord(lstdegree, "1");
        SaveRecord(lstmajor, "3");
        SaveRecord(lstindustryl, "6");
        dataBind();
    }
    public void SaveRecord(Repeater rpt, string parameterID)
    {
        string ID = string.Empty;

        foreach (RepeaterItem rptitem in rpt.Items)
        {
            CheckBox chk = (CheckBox)rptitem.FindControl("checkBoxPanel");
            HiddenField hdn = (HiddenField)rptitem.FindControl("parameterValueCode");
            CheckBox chkM = (CheckBox)rptitem.FindControl("chkmandatory");
            if (chk != null && chkM != null && hdn != null)
            {
                if (chk.Checked == true)
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    SqlCommand sqlcom = new SqlCommand("Xrec_UpdateProfileparameter", connection);
                    sqlcom.Parameters.AddWithValue("@profile_code ", ddlprofile.SelectedValue);
                    sqlcom.Parameters.AddWithValue("@parameter_code", parameterID);
                    sqlcom.Parameters.AddWithValue("@parameterValue_code", hdn.Value);
                    if (chkM.Checked == true)
                        sqlcom.Parameters.AddWithValue("@isMandatory", 1);
                    else
                        sqlcom.Parameters.AddWithValue("@isMandatory", 0);
                    sqlcom.Parameters.AddWithValue("@is_active", 1);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.ExecuteNonQuery();
                    connection.Close();
                }
            }

        }

    }

}
