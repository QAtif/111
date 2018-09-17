using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.Services;


public partial class A2_DashBoard_highchart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    [WebMethod]
    public static object UpdateCandidatebyPro(string items)
    {
        DataSet dataSet = new DataSet();
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand selectCommand = new SqlCommand("XREC_Select_HiredCountMonthWise", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            new SqlDataAdapter(selectCommand).Fill(dataSet);
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            object[] objArray1 = new object[12];
            object[] objArray2 = new object[12];
            object[] objArray3 = new object[2];
            Dictionary<string, object> dictionary1 = new Dictionary<string, object>();
            for (int index = 0; index <= dataSet.Tables[0].Rows.Count - 1; ++index)
                objArray1[index] = dataSet.Tables[0].Rows[index].ItemArray;
            dictionary1.Add("data", objArray1);
            objArray3[0] = objArray1;
            Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
            for (int index = 0; index <= dataSet.Tables[1].Rows.Count - 1; ++index)
                objArray2[index] = dataSet.Tables[1].Rows[index].ItemArray;
            dictionary2.Add("data", objArray2);
            objArray3[1] = objArray2;
            JavaScriptSerializer scriptSerializer = new JavaScriptSerializer();
            return objArray3;
        }
        catch (Exception ex)
        {
            return "";
        }
    }
}