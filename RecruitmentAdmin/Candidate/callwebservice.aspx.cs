using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Data;

public partial class Candidate_callwebservice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MakeRestfulWebServiceCall();
    }
    private static void MakeRestfulWebServiceCall()
    {
        try
        {
            string param = "hello";

            string url = String.Format("http://10.1.20.16/WebserviceRestful/users/getusers", param);

            WebClient serviceRequest = new WebClient();
            string response = serviceRequest.DownloadString(new Uri(url));
            DataSet ds = new DataSet();
            StringReader reader = new StringReader(response);
        ds.ReadXml(reader);
       // dataGridView1.DataSource = ds.Tables["TableName"];

        }
        catch (Exception e)
        {

        }
    }
}