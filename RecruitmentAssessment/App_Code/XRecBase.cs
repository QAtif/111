using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


public class XRecBase : Page//Page
    {
    #region Variables and Properties
    private int userID=0;
    private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public int UserID
        {
            //get { return userID; }

            get { 
                return int.Parse(Request.Cookies["CC"].Value.ToString()); }

            set { userID = value; }
        }
        override protected void OnInit(EventArgs e)
        {
            if (Request.Cookies["CC"] != null)
            {
              UserID = Convert.ToInt32(Request.Cookies["CC"].Value.ToString());
            }

            switch (userID)
            {
                case 0:
                    Response.Redirect("/Signin.aspx", true);
                    break;
               
            }

        }
        //DataSet ds = new DataSet();
        //CustomBasePage objCBP = new CustomBasePage();
        #endregion Variables and Properties

        #region Page Related Methods
        /*
        protected void Page_PreInit(object sender, EventArgs e)
        {
            //Response.Write("EmployeeID:"+EmployeeID);
            #region Special Check for Cookie Handling
            if (Request.QueryString["employeeid"]!=null)
            {
                // cookie creation
                HttpCookie empCookie = new HttpCookie("EmployeeID", Request.QueryString["employeeid"]);
                empCookie.Expires = DateTime.Now.AddDays(30);

                Response.SetCookie(empCookie);

            }
            #endregion Special Check for Cookie Handling

            SetSessionVariables();
            if (CheckAuthentication())
            {
                BindUserName();
            }
            else
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["AuthID"].ToString() == "0")
                    {
                        Server.Transfer("~/unauthorized.aspx");
                    }
                }
                else
                {
                    Server.Transfer("~/unauthorized.aspx");
                }
            }
        }

        protected void SetSessionVariables()
        {

            Session[Constants.UserID] = EmployeeID;
            UserID = EmployeeID;
            ////Following check is for local debugging purpose only
            //if (HttpContext.Current.Request.UserHostAddress == "127.0.0.1")
            //{
            //    Session[Constants.UserID] = 0;
            //    UserID = 0;
            //}
            //else if (HttpContext.Current.Request.Cookies[Constants.UserID] != null)
            //{
            //    UserID = Convert.ToInt32(HttpContext.Current.Request.Cookies[Constants.UserID].Value);
            //    Session[Constants.UserID] = UserID;
            //}
            //else
            //{
            //    HttpContext.Current.Response.Write("<a href='" + ConfigurationManager.AppSettings["LoginRedirector"] + "?url=" + HttpContext.Current.Request.Url.ToString() + "'>Click Here</a> to Login.");
            //    HttpContext.Current.Response.End();
            //    return;
            //}

        }

        protected bool CheckAuthentication()
        {
            //string[] strArray = HttpContext.Current.Request.Url.ToString().Split('/');

            ////to be implemented or overwritten by individual modules
            //return true;

            if (ConfigurationManager.AppSettings["CheckAuthentication"] != null && ConfigurationManager.AppSettings["CheckAuthentication"] == "0")
                return true;

            String[] url = HttpContext.Current.Request.Url.ToString().Split('?');
            String[] url2 = url[0].Split('/');
            string finalurl = url2[url2.Length - 1];

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProcurementConnection"].ConnectionString))
            {
                SqlCommand command;
                command = new SqlCommand("EMM_Select_EmployeeAuthentication", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                command.Parameters.AddWithValue("@URL", finalurl);
                adapter.Fill(ds);
            }

            //return Convert.ToBoolean(ds.Tables[0].Rows[0]["AuthID"]);
            return ds.Tables[0].Rows[0]["AuthID"].ToString() == "0" ? false : true;

        }

        protected void BindUserName()
        {
            if (UserID == 0)
            {
                UserName = "System";
                HttpContext.Current.Session[Constants.UserName] = UserName;
                return;
            }
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProcurementConnection"].ConnectionString))
            {
                SqlCommand command;
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Library_Select_EmployeeDetails";
                command.Parameters.AddWithValue("@UserID", UserID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    UserName = dt.Rows[0]["User_Name"].ToString();
                    HttpContext.Current.Session[Constants.UserName] = UserName;
                }
                else
                {
                    UserName = "Unknown";
                    HttpContext.Current.Session[Constants.UserName] = UserName;
                }
            }

        }
        */
        #endregion Page Related Methods

    }

